using CallAddOnInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CallAddOn
{
    public interface ILoadAddOns
    {
        int LoadFiles(DirectoryInfo directory);
    }

    public class LoadAddOns : ILoadAddOns
    {
        public int LoadFiles(DirectoryInfo directory)
        {
            if (directory == null) return 0;
            if (!directory.Exists) return 0;

            var files = directory.GetFiles("*.dll");
            foreach (var file in files) Assembly.LoadFile(file.FullName);
            return files.Length;
        }
    }

    public interface ICallAddOn<Feature, Arg>
    {
        void Init();
        IEnumerable<Feature> Create(Arg arg);
    }

    public class CallAddOn<Feature, Factory, Arg> : ICallAddOn<Feature, Arg> where Factory : IFactory<Feature, Arg>
    {
        Factory[] factories;

        public void Init()
        {
            factories =
                AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes())
                .Where(t => t.GetInterfaces().Contains(typeof(Factory)))
                .Select(t => (Factory)Activator.CreateInstance(t))
                .ToArray() ?? new Factory[0];
        }

        public IEnumerable<Feature> Create(Arg arg) =>
            factories?.Select(factory => factory.Create(arg)).ToArray() ?? Enumerable.Empty<Feature>();
    }
}
