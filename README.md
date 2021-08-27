<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/172048906/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830459)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to display documents from the Report and Dashboard Server in an ASP.NET MVC application

This example demonstrates how to use the [Report and Dashboard Server](https://docs.devexpress.com/ReportServer/12432/index)'s API to obtain available documents and display them in the Document/Dashboard Viewers.

The table below lists controls that display documents depending on their types:

| Document Type | Control | Configuration Options |
|---|---|---|
| Report | [ASP.NET MVC Document Viewer Extension](https://docs.devexpress.com/XtraReports/400221/create-end-user-reporting-applications/web-reporting/asp-net-mvc-reporting/document-viewer/html5-document-viewer) | [WebDocumentViewerSettings.SettingsRemoteSource](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.WebDocumentViewerSettings.SettingsRemoteSource) |
| Dashboard | [ASP.NET MVC Dashboard Extension](https://docs.devexpress.com/Dashboard/16977/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension) (in the [ViewerOnly](https://docs.devexpress.com/Dashboard/16982/creating-the-designer-and-viewer-applications/web-dashboard/asp.net-mvc-dashboard-extension/designer-and-viewer-modes) mode) | [DashboardExtensionSettings.BackendOptions](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWeb.Mvc.DashboardExtensionSettings.BackendOptions) |

Before running the example, perform the following steps:

**1. Configure the Report and Dashboard Server**

* Configure the Report and Dashboard Server to use the HTTPS protocol.

* [Create a user account](https://docs.devexpress.com/ReportServer/14361/administrative-panel/manage-user-accounts-and-grant-security-permissions) with Server authentication and give this account permissions to view documents. The account's credentials will be used to obtain a [Bearer token](https://oauth.net/2/bearer-tokens/), which is required to access the Report and Dashboard Server's API.

* Enable Cross-Origin Resource Sharing (CORS) on the screen with the [General Settings](https://docs.devexpress.com/ReportServer/119485/administrative-panel/manage-server-settings/general-settings) and restart the Report and Dashboard Server to apply the changes.

**2. Download Resources and Specify Server Settings**

* In Visual Studio, right-click the solution and select **Restore NuGet Packages**. You can use the **DevExpress Local** package source shipped with installation or [setup a new package source](https://docs.devexpress.com/GeneralInformation/116698/installation/install-devexpress-controls-using-nuget-packages/setup-visual-studio's-nuget-package-manager).

* Open the **Web.config** file and assign your Report and Dashboard Server's URI to the **appSettings/ReportServer:BaseUri** property.

*  Create the **Web.SECRETS.config** file with the following content and specify the API user name and password. 

    ```
    <appSettings>
      <add key="ReportServer:UserName" value="<api-user-name>" />
      <add key="ReportServer:UserPassword" value="<api-user-password>" />
    </appSettings>
    ```

    See the following post for more details: [Best practices for private config data and connection strings](https://www.hanselman.com/blog/BestPracticesForPrivateConfigDataAndConnectionStringsInConfigurationInASPNETAndAzure.aspx).

**3. Run the Example**
