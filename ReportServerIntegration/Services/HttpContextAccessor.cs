using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportServerIntegration.Services {
    public interface IHttpContextAccessor {
        HttpContext GetContext();
    }

    public class HttpContextAccessor : IHttpContextAccessor {
        public HttpContext GetContext() {
            return HttpContext.Current;
        }
    }
}
