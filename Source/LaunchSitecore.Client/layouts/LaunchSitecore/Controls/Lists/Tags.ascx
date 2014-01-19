<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tags.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Tags" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
 <HeaderTemplate><div class="tags-widget sidebar-block"><h2><asp:Literal ID="SectionTitle" runat="server" /></h2><ul></HeaderTemplate>
 <ItemTemplate><li><p><i class="icon-tags"></i><asp:LinkButton ID="RelatedLink" runat="server" OnClick="SearchByTag" /></p></li></ItemTemplate>
 <FooterTemplate></ul></div></FooterTemplate>
</asp:Repeater>
