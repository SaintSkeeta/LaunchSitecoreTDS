<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Article_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptArticles" runat="server" OnItemDataBound="rptArticles_ItemDataBound">
 <HeaderTemplate>
 <div class="related_articles">
  <h3><asp:Literal ID="SectionTitle" runat="server" /></h3>
  <ul>
 </HeaderTemplate>
 <ItemTemplate>
  <li>
   <asp:HyperLink ID="ArticleLink" runat="server">
    <sc:FieldRenderer ID="ArticleName" runat="server" FieldName="Title" />    
   </asp:HyperLink>
  </li>
 </ItemTemplate>
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>
<asp:Panel ID="showIfEmpty" runat="server" Visible="false">
<em class="PageEditorNote">This Article List is empty.  Please update the inputs or remove this component.</em>
</asp:Panel>