using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ReportServerIntegration.Services {
    public interface IAppSettings {
        string GetValue(string key);
    }

    public class AppSettings : IAppSettings {
        public string GetValue(string key) {
            return WebConfigurationManager.AppSettings[key];
        }
    }
}
