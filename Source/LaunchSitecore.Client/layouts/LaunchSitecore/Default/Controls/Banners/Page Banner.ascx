<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Page Banner.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Banners.Page_Banner" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="plainBanner">
 <h1><sc:FieldRenderer id="frTitle" runat="server" FieldName="Title" /></h1>
</div>