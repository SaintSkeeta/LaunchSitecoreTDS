<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Queried List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Queried_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
 <HeaderTemplate><div class="side-nav sidebar-block"><h2><asp:Literal ID="SectionTitle" runat="server" /></h2><ul></HeaderTemplate>
 <ItemTemplate>
  <li>
   <asp:HyperLink ID="ItemLink" runat="server">
    <sc:FieldRenderer ID="ItemName" runat="server" FieldName="Title" />
    </asp:HyperLink>
  </li>
 </ItemTemplate>
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>
