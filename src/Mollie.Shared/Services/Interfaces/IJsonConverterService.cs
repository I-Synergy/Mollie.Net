namespace Mollie.Services
{
    public interface IJsonConverterService
    {
        T Deserialize<T>(string json);
        string Serialize(object objectToSerialize);
    }
}
