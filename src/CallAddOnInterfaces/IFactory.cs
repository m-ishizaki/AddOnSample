
namespace CallAddOnInterfaces
{
    public interface IFactory<IFeature, Arg>
    {
        IFeature Create(Arg arg);
    }
}
