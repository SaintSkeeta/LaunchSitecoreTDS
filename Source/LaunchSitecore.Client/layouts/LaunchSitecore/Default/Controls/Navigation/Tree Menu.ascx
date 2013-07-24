<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tree Menu.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.TreeMenu" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptTree" runat="server" OnItemDataBound="rptTree_ItemDataBound">
 <HeaderTemplate><ul id="secnav"></HeaderTemplate>
 <ItemTemplate>
  <li runat="server" id="liwrapper">
   <asp:Hyperlink ID="MenuLink" runat="server" />
   <asp:PlaceHolder ID="phSubTree" runat="server" />
  </li>
 </ItemTemplate>
 <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
