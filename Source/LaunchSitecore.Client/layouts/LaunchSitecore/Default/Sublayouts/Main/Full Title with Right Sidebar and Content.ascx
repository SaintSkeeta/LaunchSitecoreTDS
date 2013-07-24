<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Full Title with Right Sidebar and Content.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Sublayouts.Full_Title_with_Right_Sidebar_and_Content" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="content_top">
 <sc:Placeholder ID="phContentTop" Key="content-top" runat="server" />
</div>
<div id="sidebar_right">
 <sc:Placeholder ID="phSidebar" Key="sidebar" runat="server" />
</div>
<div id="content_left">
 <sc:Placeholder ID="phContent" Key="content" runat="server" />
</div>