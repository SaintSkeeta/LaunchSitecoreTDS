<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Security Buttons.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure.Security_Buttons" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="loginButtons" runat="server" style="display: inline;">
 <asp:HyperLink NavigateUrl="/Login.aspx" ID="Login" runat="server" /> | 
 <asp:HyperLink NavigateUrl="/Login.aspx" ID="Register" runat="server" />
</asp:Panel>

<asp:Panel ID="authenticatedUser" runat="server" Visible="false" Style="display: inline;"> 
 <a class='favorties' href="#favorties_content"><asp:Literal ID="MyFavorites" runat="server" /></a> | 
 <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" />
</asp:Panel>

<!-- This contains the hidden content for inline calls -->
<div style='display: none'>
 <div id='favorties_content' style='padding: 10px; background: #fff;'>
  <sc:Sublayout ID="Favorites" runat="server" Path="/layouts/LaunchSitecore/Default/Controls/Secure/Favorites.ascx" />
 </div>
</div>
