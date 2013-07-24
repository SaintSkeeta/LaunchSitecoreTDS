<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumbs.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Navigation.Breadcrumbs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
 <asp:Repeater ID="rptCrumbs" runat="server" OnItemDataBound="rptCrumbs_ItemDataBound">
  <HeaderTemplate><p id="breadcrumb"></HeaderTemplate>
  <ItemTemplate>     
   <asp:HyperLink ID="CrumbLink" runat="server" />
   <asp:Literal ID="CrumbLiteral" runat="server" Visible="false" />
  </ItemTemplate>   
  <SeparatorTemplate><span>&gt;</span></SeparatorTemplate>
  <FooterTemplate></p></FooterTemplate>
 </asp:Repeater> 