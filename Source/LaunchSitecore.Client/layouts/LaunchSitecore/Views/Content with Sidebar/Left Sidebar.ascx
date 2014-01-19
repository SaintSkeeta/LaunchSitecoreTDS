<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Left Sidebar.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Views.Content_with_Sidebar.Left_Sidebar" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<sc:Sublayout ID="breadcrumbs" runat="server" Path="/layouts/LaunchSitecore/Controls/Navigation/Breadcrumbs.ascx" />
<div class="row show-grid clear-both">
 <div id="left-sidebar" class="span3 sidebar">
  <sc:placeholder id="contentsecondary" runat="server" key="content-secondary" />
  <sc:placeholder id="contenttertiary" runat="server" key="content-tertiary" />
 </div>
 <div class="span9 main-column two-columns-left"><sc:placeholder id="contentprimary" runat="server" key="content-primary" /></div>
</div>


