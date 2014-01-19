<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Secondary Nav.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation.Secondary_Nav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="side-nav sidebar-block" id="menuWrapper" runat="server">
 <h2><sc:FieldRenderer ID="MenuHeader" runat="server" FieldName="Menu Title" /></h2>
 <asp:Repeater ID="rptTree" runat="server" OnItemDataBound="rptTree_ItemDataBound">
  <HeaderTemplate><ul></HeaderTemplate>
  <ItemTemplate>
   <li>
    <asp:Hyperlink ID="MenuLink" runat="server">
     <sc:FieldRenderer ID="MenuText" runat="server" FieldName="Menu Title" />
    </asp:Hyperlink>
    <asp:PlaceHolder ID="phSubTree" runat="server" />
   </li>
  </ItemTemplate>
  <FooterTemplate></ul></FooterTemplate> 
 </asp:Repeater>
</div>


