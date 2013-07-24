<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer Navigation.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.Footer_Navigation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="footer_nav">
<asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
 <HeaderTemplate></HeaderTemplate>
 <ItemTemplate>
  <div class="tab">  
   <h2><asp:HyperLink ID="MenuLink" runat="server"><asp:Literal ID="MenuText" runat="server" /></asp:HyperLink></h2>
   <asp:Repeater ID="rptSub" runat="server" OnItemDataBound="rptSubMenu_ItemDataBound">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate><li><asp:HyperLink ID="MenuLink" runat="server"><asp:Literal ID="MenuText" runat="server" /></asp:HyperLink></li></ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
   </asp:Repeater>
  </div>
 </ItemTemplate>   
</asp:Repeater>
<div class="floatClear"></div>
</div>
