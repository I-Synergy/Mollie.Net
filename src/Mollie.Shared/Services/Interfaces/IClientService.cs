using Mollie.Models.Url;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mollie.Services
{
    public interface IClientService
    {
        string ApiKey { get; }
        Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string relativeUri, object data = null);
        Task<T> GetListAsync<T>(string relativeUri, string from, int? limit, IDictionary<string, string> otherParameters = null);
        Task<T> GetAsync<T>(string relativeUri);
        Task<T> GetAsync<T>(UrlObjectLink<T> urlObject);
        Task<T> PostAsync<T>(string relativeUri, object data);
        Task<T> PatchAsync<T>(string relativeUri, object data);
        Task DeleteAsync(string relativeUri, object data = null);
    }
}
