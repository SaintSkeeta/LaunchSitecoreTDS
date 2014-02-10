<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Breadcrumbs.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation.Breadcrumbs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptCrumbs" runat="server" OnItemDataBound="rptCrumbs_ItemDataBound">
  <HeaderTemplate><div id="breadcrumb"><ul></HeaderTemplate>
  <ItemTemplate>     
   <li runat="server" id="liwrapper">
    <asp:HyperLink ID="CrumbLink" runat="server">
     <sc:FieldRenderer ID="CrumbText" runat="server" FieldName="Menu Title" />
    </asp:HyperLink>
    <asp:Literal ID="CrumbLiteral" runat="server" Visible="false" /></li>
  </ItemTemplate>  
  <FooterTemplate></ul><div class="pull-right addtofavsbutton"><asp:LinkButton runat="server" ID="btnAddtoFavs" OnClick="btnAddtoFavs_Click" Visible="false">Add to Favorites</asp:LinkButton></div></div></FooterTemplate>
 </asp:Repeater> 
