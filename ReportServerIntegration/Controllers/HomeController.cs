using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ReportServerIntegration.Models;
using ReportServerIntegration.Services;

namespace ReportServerIntegration.Controllers {
    public class HomeController : Controller {
        readonly IApiService apiService;
        readonly IReportService reportService;
        readonly IDashboardService dashboardService;

        public HomeController(IApiService apiService, IReportService reportService, IDashboardService dashboardService) {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            this.reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            this.dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        }

        [HttpGet]
        public async Task<ActionResult> Index() {
            HttpResponseMessage response = await apiService.GetAsync("documents");
            var documents = await response.EnsureSuccessStatusCode().Content.ReadAsAsync<DocumentModel[]>();
            return View(documents);
        }

        [HttpGet]
        public async Task<ActionResult> ReportViewer(string reportId) {
            var model = await reportService.GetViewerModel(reportId);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> DashboardViewer(string dashboardId) {
            var model = await dashboardService.GetViewerModel(dashboardId);
            return View(model);
        }
    }
}
