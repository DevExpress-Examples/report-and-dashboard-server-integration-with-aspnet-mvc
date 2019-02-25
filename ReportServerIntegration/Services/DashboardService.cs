using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ReportServerIntegration.Models;

namespace ReportServerIntegration.Services {
    public interface IDashboardService {
        Task<DashboardViewerModel> GetViewerModel(string dashboardId);
    }

    public class DashboardService : IDashboardService {
        readonly ITokenService tokenService;
        readonly IAppSettings configuration;

        public DashboardService(ITokenService tokenService, IAppSettings configuration) {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<DashboardViewerModel> GetViewerModel(string dashboardId) {
            string token = await tokenService.GetToken();
            return new DashboardViewerModel {
                DesignerUri = $"{configuration.GetValue("ReportServer:BaseUri")}/dashboardDesigner",
                DashboardId = dashboardId,
                AuthorizationHeader = $"Bearer {token}"
            };
        }
    }
}
