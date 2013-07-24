<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Three Column.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Sublayouts.Partial.Three_Column" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="floatClear"></div>
<div class="three_cols">
 <div class="threecolleft"><sc:Placeholder ID="leftcol" Key="left-column" runat="server" /></div>   
 <div class="threecolmiddle"><sc:Placeholder ID="midcol" Key="middle-column" runat="server" /></div>    
 <div class="threecolright"><sc:Placeholder ID="rightcol" Key="right-column" runat="server" /></div>
 <div class="floatClear"></div>
</div>