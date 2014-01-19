<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer Navigation.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation.Footer_Navigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h4 class="center-title">Navigate</h4>
<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
 <HeaderTemplate><ul class="footer-navigate"></HeaderTemplate>
 <ItemTemplate><li><asp:HyperLink ID="MenuLink" runat="server"><asp:Literal ID="MenuText" runat="server" /></asp:HyperLink></li></ItemTemplate>   
 <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>