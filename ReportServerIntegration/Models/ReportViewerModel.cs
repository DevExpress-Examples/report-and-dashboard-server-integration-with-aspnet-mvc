using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportServerIntegration.Models {
    public class ReportViewerModel {
        public string ReportUri { get; set; }
        public string ServerUri { get; set; }
        public string AuthToken { get; set; }
    }
}
