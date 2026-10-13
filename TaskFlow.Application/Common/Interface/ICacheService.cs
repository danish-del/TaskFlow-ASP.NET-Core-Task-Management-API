namespace TaskFlow.Application.Common.Interface
{
    public interface ICacheService
    {
        Task SetData(string key, string value);
        Task<string?> GetData(string key);
    }
}
