<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Child List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Child_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="childarticlelist">
 <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
  <HeaderTemplate><ul></HeaderTemplate>
  <ItemTemplate>
   <li>
    <asp:HyperLink ID="ItemLink" runat="server" CssClass="featuredlink"><sc:FieldRenderer id="ItemName" runat="server" fieldname="Title" /></asp:HyperLink>
    <sc:FieldRenderer id="ItemAbstract" runat="server" fieldname="Abstract" />
   </li>
  </ItemTemplate>
  <FooterTemplate></ul></FooterTemplate>
 </asp:Repeater>
</div>