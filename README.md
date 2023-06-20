<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/172048906/23.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830459)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Reporting for Web - How to display documents from the Report and Dashboard Server in an ASP.NET MVC application

This example demonstrates how to use the [Report and Dashboard Server](https://docs.devexpress.com/ReportServer/12432/index)'s API to obtain report/dashboard documents and display them in the Document/Dashboard Viewers.

The table below lists controls that display documents depending on their types:

| Document Type | Control | Configuration Options |
|---|---|---|
| Report | [ASP.NET MVC Document Viewer Extension](https://docs.devexpress.com/XtraReports/400221/create-end-user-reporting-applications/web-reporting/asp-net-mvc-reporting/document-viewer/html5-document-viewer) | [WebDocumentViewerSettings.SettingsRemoteSource](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.WebDocumentViewerSettings.SettingsRemoteSource) |
| Dashboard | [ASP.NET MVC Dashboard Extension](https://docs.devexpress.com/Dashboard/16977/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension) (in the [ViewerOnly](https://docs.devexpress.com/Dashboard/16982/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension/designer-and-viewer-modes) mode) | [DashboardExtensionSettings.BackendOptions](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.Mvc.DashboardExtensionSettings.BackendOptions) |

> **Note**
> Before running the example, perform the steps described below in the Report and Dashboard Server Configuration and Application Configuration sections.

## Report and Dashboard Server Configuration

1. Configure the Report and Dashboard Server to [use the HTTPS protocol](https://docs.devexpress.com/ReportServer/117012/configuration-and-api/configure-ssl).

1. Configure the [Email Settings](https://docs.devexpress.com/ReportServer/119486/administrative-panel/manage-server-settings/email-settings) required to verify the email address that you enter when you create a new user account in the next step.

1. [Create a user account](https://docs.devexpress.com/ReportServer/14361/administrative-panel/manage-user-accounts-and-grant-security-permissions) with Server authentication and give this account permissions to view documents. The account's credentials will be used to obtain a [Bearer token](https://oauth.net/2/bearer-tokens/), which is required to access the Report and Dashboard Server's API.

1. Enable Cross-Origin Resource Sharing (CORS) on the screen with the [General Settings](https://docs.devexpress.com/ReportServer/119485/administrative-panel/manage-server-settings/general-settings) and restart the DevExpress.ReportServer web site in the Internet Information Services (IIS) Manager to apply the changes.

## Application Configuration

1. In Visual Studio, right-click the solution and select **Restore NuGet Packages**. You can use the **DevExpress Local** package source shipped with installation or [setup a new package source](https://docs.devexpress.com/GeneralInformation/116698/installation/install-devexpress-controls-using-nuget-packages/setup-visual-studio's-nuget-package-manager).

1. Open the `Web.config` file and assign your Report and Dashboard Server's URI to the `appSettings/ReportServer:BaseUri` property.

1. Create the `Web.SECRETS.config`* file with the following content and specify the API user name and password. 

    ```console
    <appSettings>
      <add key="ReportServer:UserName" value="api-user-name" />
      <add key="ReportServer:UserPassword" value="api-user-password" />
    </appSettings>
    ```

    Review the following blog post for more details: [Best practices for private config data and connection strings](https://www.hanselman.com/blog/BestPracticesForPrivateConfigDataAndConnectionStringsInConfigurationInASPNETAndAzure.aspx).

## Run the Example

The page displays a list of reports and dashboards available to the current user on the Report and Dashboard Server. When the user clicks the link, the report (or dashboard) is loaded to the viewer.

## Files to Review

- [Global.asax.cs](ReportServerIntegration/Global.asax.cs)
- [ReportService.cs](ReportServerIntegration/Services/ReportService.cs)
- [DashboardService.cs](ReportServerIntegration/Services/DashboardService.cs)
- [HomeController.cs](ReportServerIntegration/Controllers/HomeController.cs)
- [Index.cshtml](ReportServerIntegration/Views/Home/Index.cshtml)
- [ReportViewer.cshtml](ReportServerIntegration/Views/Home/ReportViewer.cshtml)
- [DashboardViewer.cshtml](ReportServerIntegration/Views//Home/DashboardViewer.cshtml)
- [Web.config](/ReportServerIntegration/Web.config)
- 
## Documentation

- [Report and Dashboard Server](https://docs.devexpress.com/ReportServer/12432/report-and-dashboard-server)
- [Display Documents from the Report and Dashboard Server](https://docs.devexpress.com/XtraReports/400034/web-reporting/general-information-on-web-reporting/display-documents-from-the-report-and-dashboard-server)

## More Examples

- [How to display documents from the Report and Dashboard Server in an ASP.NET Core MVC application](https://github.com/DevExpress-Examples/report-and-dashboard-server-integration-with-aspnet-core-mvc)
