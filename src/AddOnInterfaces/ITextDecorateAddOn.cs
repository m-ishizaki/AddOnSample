using CallAddOnInterfaces;

namespace AddOnInterfaces
{
    public interface ITextDecorateAddOnFactory : IFactory<ITextDecorateAddOnFeature, string>
    {
    }

    public interface ITextDecorateAddOnFeature
    {
        string Decorate(string text);
    }
}
