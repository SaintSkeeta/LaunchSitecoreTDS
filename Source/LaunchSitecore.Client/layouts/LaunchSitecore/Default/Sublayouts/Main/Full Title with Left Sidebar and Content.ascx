<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Full Title with Left Sidebar and Content.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Sublayouts.Full_Title_with_Left_Sidebar_and_Content" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="content_top">
 <sc:Placeholder ID="phContentTop" Key="content-top" runat="server" />
</div>
<div id="content">
 <sc:Placeholder ID="phContent" Key="content" runat="server" />
</div>
<div id="sidebar">
 <sc:Placeholder ID="phSidebar" Key="sidebar" runat="server" />
</div>
