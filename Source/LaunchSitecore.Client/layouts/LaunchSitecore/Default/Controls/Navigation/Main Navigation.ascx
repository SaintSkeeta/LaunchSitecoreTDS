<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Main Navigation.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.Main_Navigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- There are two menus in this file.  The drop down and the mega nav. The code behind will hide one. -->

<!-- drop down nav -->
<div id="dropdownwrapper" runat="server">
<div id="myslidemenu" class="jqueryslidemenu">
 <asp:Repeater ID="rptDropDownMenu" runat="server" OnItemDataBound="rptDropDownMenu_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
     <li>
      <asp:HyperLink ID="MenuLink" runat="server">
       <asp:Literal ID="MenuText" runat="server" />
      </asp:HyperLink>
      <asp:PlaceHolder ID="phSubMenu" runat="server" />      
     </li>
    </ItemTemplate>   
    <FooterTemplate></ul></FooterTemplate>
   </asp:Repeater>
  <br style="clear: left" />
</div>
</div> 

<!-- Meg Nav -->
 <asp:Repeater ID="rptMegaNavMenu" runat="server" OnItemDataBound="rptMegaNavMenu_ItemDataBound">
  <HeaderTemplate><ul id="mega-menu-1"></HeaderTemplate>
  <ItemTemplate>
   <li>
    <asp:HyperLink ID="MenuLink" runat="server"><asp:Literal ID="MenuText" runat="server" /></asp:HyperLink>
    <asp:PlaceHolder ID="phSubMenu" runat="server" />
   </li>
  </ItemTemplate>
  <FooterTemplate></ul></FooterTemplate>
 </asp:Repeater>