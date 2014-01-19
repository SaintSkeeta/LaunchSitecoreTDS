<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Related Articles.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Related_Articles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<asp:Repeater ID="rptPrereq" runat="server" OnItemDataBound="rptRelated_ItemDataBound">
 <HeaderTemplate><div class="side-nav sidebar-block"><h2><asp:Literal ID="SectionTitle" runat="server" /></h2><ul></HeaderTemplate>
 <ItemTemplate><li><asp:HyperLink ID="RelatedLink" runat="server"><sc:FieldRenderer ID="RelatedName" runat="server" FieldName="Title" /></asp:HyperLink></li></ItemTemplate>
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>

<asp:Repeater ID="rptAdditional" runat="server" OnItemDataBound="rptRelated_ItemDataBound">
 <HeaderTemplate><div class="side-nav sidebar-block"><h2><asp:Literal ID="SectionTitle" runat="server" /></h2><ul></HeaderTemplate>
 <ItemTemplate><li><asp:HyperLink ID="RelatedLink" runat="server"><sc:FieldRenderer ID="RelatedName" runat="server" FieldName="Title" /></asp:HyperLink></li></ItemTemplate>
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>