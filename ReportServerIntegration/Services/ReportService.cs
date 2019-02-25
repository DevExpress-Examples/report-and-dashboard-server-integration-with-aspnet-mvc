using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ReportServerIntegration.Models;

namespace ReportServerIntegration.Services {
    public interface IReportService {
        Task<ReportViewerModel> GetViewerModel(string reportId);
    }

    public class ReportService : IReportService {
        readonly ITokenService tokenService;
        readonly IAppSettings configuration;

        public ReportService(ITokenService tokenService, IAppSettings configuration) {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ReportViewerModel> GetViewerModel(string reportId) {
            string token = await tokenService.GetToken();
            return new ReportViewerModel {
                ServerUri = configuration.GetValue("ReportServer:BaseUri"),
                ReportUri = $"report/{reportId}",
                AuthToken = token
            };
        }
    }
}
