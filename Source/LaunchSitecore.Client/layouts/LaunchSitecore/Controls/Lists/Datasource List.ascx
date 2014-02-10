<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Datasource List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Datasource_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
 <HeaderTemplate>
  <div class="side-nav sidebar-block">
   <h2><asp:Literal ID="SectionTitle" runat="server" /></h2><ul></HeaderTemplate>
 <ItemTemplate>
  <li><asp:Hyperlink ID="LinkTo" runat="server"><sc:FieldRenderer ID="Title" runat="server" FieldName="Title" /></asp:Hyperlink></li> 
 </ItemTemplate> 
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>