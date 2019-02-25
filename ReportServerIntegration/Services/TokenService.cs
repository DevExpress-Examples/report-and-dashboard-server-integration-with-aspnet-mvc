using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ReportServerIntegration.Models;

namespace ReportServerIntegration.Services {
    public interface ITokenService {
        Task<string> GetToken();
    }

    public class TokenService : ITokenService {
        const string TokenCookie = "ReportServerToken";

        readonly IHttpContextAccessor httpContextAccessor;
        readonly IHttpClientFactory httpClientFactory;
        readonly IAppSettings configuration;

        HttpRequest Request => httpContextAccessor.GetContext().Request;
        HttpResponse Response => httpContextAccessor.GetContext().Response;

        public TokenService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IAppSettings configuration) {
            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> GetToken() {
            string token = Request.Cookies[TokenCookie]?.Value;

            if(string.IsNullOrEmpty(token)) {
                token = await RequestToken();
                Response.Cookies.Add(new HttpCookie(TokenCookie, token) { HttpOnly = true });
            }

            return token;
        }

        async Task<string> RequestToken() {
            string username = configuration.GetValue("ReportServer:UserName");
            string password = configuration.GetValue("ReportServer:UserPassword");

            if(string.IsNullOrEmpty(username)) {
                throw new InvalidOperationException("Server API user name is not configured.");
            }

            var requestContent = new Dictionary<string, string> {
                { "grant_type", "password"},
                { "username", username },
                { "password", password }
            };

            HttpClient client = httpClientFactory.CreateClient("reportServer");
            HttpResponseMessage response = await client.PostAsync("oauth/token", new FormUrlEncodedContent(requestContent));
            Token token = await response.EnsureSuccessStatusCode().Content.ReadAsAsync<Token>();

            return token.AuthToken;
        }
    }
}
