<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Two_Columns.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Sublayouts.Partial.Two_Columns" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="floatClear"></div>
<div class="two_cols">
 <div class="twocolleft"><sc:Placeholder ID="leftcol" Key="left-column" runat="server" /></div>      
 <div class="twocolright"><sc:Placeholder ID="rightcol" Key="right-column" runat="server" /></div>
 <div class="floatClear"></div>
</div>
