<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Both Sidebars.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Views.Content_with_Sidebar.Both_Sidebars" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<sc:Sublayout ID="breadcrumbs" runat="server" Path="/layouts/LaunchSitecore/Controls/Navigation/Breadcrumbs.ascx" />
<div class="row show-grid"><div class="span12">
 <div class="row show-grid clear-both">
  <div id="left-sidebar" class="span3 sidebar"><sc:placeholder id="contentsecondary" runat="server" key="content-secondary" /></div>
  <div class="span6 main-column three-columns-central"><sc:placeholder id="contentprimary" runat="server" key="content-primary" /></div>
  <div id="right-sidebar" class="span3 sidebar"><sc:placeholder id="contenttertiary" runat="server" key="content-tertiary" /></div>
 </div>
</div>
   </div> 

