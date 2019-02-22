# How to display documents from the Report and Dashboard Server in an ASP.NET MVC application

This example demonstrates how to use the [Report and Dashboard Server](https://docs.devexpress.com/ReportServer/12432/index)'s API to obtain available documents and display them in the Document/Dashboard Viewers.

The table below lists the controls that display documents depending on their types:

| Document Type | Control | Configuration Options |
|---|---|---|
| Report | [ASP.NET MVC Document Viewer Extension](https://docs.devexpress.com/AspNet/114491/asp.net-mvc-extensions/reporting/document-viewer/html5-document-viewer) | [WebDocumentViewerSettings](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.WebDocumentViewerSettings) |
| Dashboard | [ASP.NET MVC Dashboard Extension](https://docs.devexpress.com/Dashboard/16977/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension) (in the [ViewerOnly](https://docs.devexpress.com/Dashboard/16982/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension/designer-and-viewer-modes) mode) | [DashboardExtensionSettings](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.Mvc.DashboardExtensionSettings) |

Before running the example, perform the following steps:

**1. Configure the Report and Dashboard Server**

* Configure the Report and Dashboard Server to use the HTTPS protocol.

* [Create a user account](https://docs.devexpress.com/ReportServer/14361/administrative-panel/manage-user-accounts-and-grant-security-permissions) with Server authentication and give this account permissions to view documents. The account's credentials will be used to obtain a [Bearer token](https://oauth.net/2/bearer-tokens/), which is required to access the Report and Dashboard Server's API.

* Enable Cross-Origin Resource Sharing (CORS) on the screen with the [General Settings](https://docs.devexpress.com/ReportServer/119485/administrative-panel/manage-server-settings/general-settings) and restart the Report and Dashboard Server to apply the changes.

**2. Download Resources and Specify Server Settings**

* Refer to the [https://nuget.devexpress.com/#feed-url](https://nuget.devexpress.com/#feed-url) page and [obtain the NuGet Feed URL](https://docs.devexpress.com/GeneralInformation/116042/installation/install-devexpress-controls-using-nuget-packages/obtain-your-nuget-feed-url). This URL includes your personal feed authorization key.

* [Setup Visual Studio's NuGet Package Manager](https://docs.devexpress.com/GeneralInformation/116698/installation/install-devexpress-controls-using-nuget-packages/setup-visual-studio's-nuget-package-manager).

* Open the **web.config** file and assign your Report and Dashboard Server's URI to the **appSettings/ReportServer:BaseUri** property.

* TBD: username and password in the web.SECRETS.config

**Run the Example**

Use Visual Studio to build and run the example.



