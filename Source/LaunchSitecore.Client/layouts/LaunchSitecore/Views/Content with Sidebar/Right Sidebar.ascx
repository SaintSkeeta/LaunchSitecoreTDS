<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Right Sidebar.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Views.Content_with_Sidebar.Right_Sidebar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<sc:Sublayout ID="breadcrumbs" runat="server" Path="/layouts/LaunchSitecore/Controls/Navigation/Breadcrumbs.ascx" />
<div class="row show-grid clear-both">
 <div class="span9 main-column two-columns-right"><sc:placeholder id="contentprimary" runat="server" key="content-primary" /></div>
 <div id="left-sidebar" class="span3 sidebar">
  <sc:placeholder id="contentsecondary" runat="server" key="content-secondary" />
  <sc:placeholder id="contenttertiary" runat="server" key="content-tertiary" />
 </div>
</div>


