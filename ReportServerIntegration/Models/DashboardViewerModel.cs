using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportServerIntegration.Models {
    public class DashboardViewerModel {
        public string DesignerUri { get; set; }
        public string DashboardId { get; set; }
        public string AuthorizationHeader { get; set; }

    }
}
