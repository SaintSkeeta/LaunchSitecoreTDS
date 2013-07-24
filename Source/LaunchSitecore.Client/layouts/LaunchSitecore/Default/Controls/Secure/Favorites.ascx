<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Favorites.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure.Favorites" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="favorites">
 <div class="promospot">
  <h1><asp:Literal id="SectionTitle" runat="server"  /></h1>
  <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound" EnableViewState="false">
   <HeaderTemplate><dl></HeaderTemplate>
   <ItemTemplate>
    <dt><asp:HyperLink ID="ItemLink" runat="server" CssClass="featuredlink" /></dt>
    <dd><asp:Literal id="ItemAbstract" runat="server" /></dd>
   </ItemTemplate>
   <FooterTemplate></dl></FooterTemplate>
  </asp:Repeater>
  <asp:Literal ID="showIfEmpty" runat="server" Visible="false" EnableViewState="false" />
 </div>
</div>