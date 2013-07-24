<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Related Articles List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Related_Articles_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptBackground" runat="server" OnItemDataBound="rptRelated_ItemDataBound">
 <HeaderTemplate>
  <div class="related_articles">
  <h3><asp:Literal ID="SectionTitle" runat="server" /></h3>
  <ul>
 </HeaderTemplate>
 <ItemTemplate>
  <li><asp:HyperLink ID="RelatedLink" runat="server"><sc:FieldRenderer ID="RelatedName" runat="server" FieldName="Title" /></asp:HyperLink></li>
 </ItemTemplate>
 <FooterTemplate>
  </ul>
  </div>
 </FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptDigDeeper" runat="server" OnItemDataBound="rptRelated_ItemDataBound">
 <HeaderTemplate>
  <div class="related_articles">
  <h3><asp:Literal ID="SectionTitle" runat="server" /></h3>
  <ul>
 </HeaderTemplate>
 <ItemTemplate>
  <li><asp:HyperLink ID="RelatedLink" runat="server"><sc:FieldRenderer ID="RelatedName" runat="server" FieldName="Title" /></asp:HyperLink></li>
 </ItemTemplate>
 <FooterTemplate>
  </ul>
  </div>
 </FooterTemplate>
</asp:Repeater>