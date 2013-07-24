<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Site Selector.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.Site_Selector" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="sitesnav">
 <asp:HyperLink CssClass="downArrow" id="SitesLink" runat="server" />
 <div class="sitescontainer">
  <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
   <HeaderTemplate><ul></HeaderTemplate>
   <ItemTemplate><li><asp:HyperLink ID="LinkTo" runat="server" /></li></ItemTemplate>
   <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
  <hr id="divider" runat="server" visible="false" />
  <asp:Repeater ID="rptExternal" runat="server" OnItemDataBound="rptExternal_ItemDataBound">
   <HeaderTemplate><ul></HeaderTemplate>
   <ItemTemplate><li><sc:Link id="LinkTo" runat="server" Field="Site Link" /></li></ItemTemplate>
   <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
 </div>
</div>