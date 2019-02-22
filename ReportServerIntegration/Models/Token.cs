using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ReportServerIntegration.Models {
    public class Token {
        [JsonProperty("access_token")]
        public string AuthToken { get; set; }
    }
}
