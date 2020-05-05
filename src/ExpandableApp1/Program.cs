using AddOnInterfaces;
using CallAddOn;
using System;
using System.IO;
using System.Linq;

namespace ExpandableApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoadAddOns loadAddOns = new LoadAddOns();
            ICallAddOn<ITextDecorateAddOnFeature, string> callAddOn
                = new CallAddOn<ITextDecorateAddOnFeature, ITextDecorateAddOnFactory, string>();

            loadAddOns.LoadFiles(new DirectoryInfo("addons"));
            callAddOn.Init();

            var addOnFeatures = callAddOn.Create("hello, ");

            var text = Console.ReadLine();

            var result = addOnFeatures.Aggregate(text, (text, feature) => feature.Decorate(text));

            Console.WriteLine(result);
        }
    }
}
