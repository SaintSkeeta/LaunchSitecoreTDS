<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mobile_Menu.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.Mobile_Menu" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="mobilemenu">
 <asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
  <HeaderTemplate><ul></HeaderTemplate>
  <ItemTemplate>
   <li>
    <asp:HyperLink ID="MenuLink" runat="server">
     <asp:Literal ID="MenuText" runat="server" />
    </asp:HyperLink>
   </li>
  </ItemTemplate>
  <FooterTemplate></ul></FooterTemplate>
 </asp:Repeater>
</div>
