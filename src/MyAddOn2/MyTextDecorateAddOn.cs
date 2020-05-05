using AddOnInterfaces;

namespace MyAddOn2
{
    public class MyTextDecorateAddOnFactory : ITextDecorateAddOnFactory
    {
        public ITextDecorateAddOnFeature Create(string arg) => new MyTextDecorateAddOnFeature(arg);
    }

    public class MyTextDecorateAddOnFeature : ITextDecorateAddOnFeature
    {
        readonly string prefix;

        public MyTextDecorateAddOnFeature(string arg)
        {
            prefix = arg;
        }

        public string Decorate(string text) => $"{prefix}{text}?";
    }
}
