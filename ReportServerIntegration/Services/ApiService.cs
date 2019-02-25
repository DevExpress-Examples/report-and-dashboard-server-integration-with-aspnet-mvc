using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ReportServerIntegration.Services {
    public interface IApiService {
        Task<HttpResponseMessage> GetAsync(string path);
    }

    public class ApiService : IApiService {
        static string GetUri(string path) {
            return $"api/{path}";
        }

        readonly ITokenService tokenService;
        readonly IHttpClientFactory httpClientFactory;

        public ApiService(ITokenService tokenService, IHttpClientFactory httpClientFactory) {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<HttpResponseMessage> GetAsync(string path) {
            string token = await tokenService.GetToken();

            using(var request = new HttpRequestMessage(HttpMethod.Get, GetUri(path))) {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpClient client = httpClientFactory.CreateClient("reportServer");
                return await client.SendAsync(request);
            }
        }
    }
}
