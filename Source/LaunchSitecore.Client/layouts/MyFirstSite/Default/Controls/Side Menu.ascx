<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Side Menu.ascx.cs" Inherits="LaunchSitecore.layouts.MyFirstSite.Controls.Side_Menu" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="MenuRepeater" runat="server" OnItemDataBound="Menu_OnItemDataBound">
 <HeaderTemplate>
  <div class="menu">
   <h3 class="headerbar">Site Menu</h3>
   <ul>
    <li><asp:HyperLink ID="homeLink" runat="server" /></li>
 </HeaderTemplate>
 <ItemTemplate>
  <li><asp:HyperLink ID="subLink" runat="server" /></li>
 </ItemTemplate>
 <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>
</div>