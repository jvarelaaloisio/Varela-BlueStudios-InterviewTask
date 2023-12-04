using EventChannels.Runtime.Additions.Ids;

namespace Customization
{
    public interface ICustomizable<T>
    {
        Id ID { get; }
        T Value { get; set; }
    }
}