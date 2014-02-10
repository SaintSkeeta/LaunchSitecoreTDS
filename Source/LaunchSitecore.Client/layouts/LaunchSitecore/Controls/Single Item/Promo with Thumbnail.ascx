<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promo with Thumbnail.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Promo_with_Thumbnail" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnl">
  <div class="grey-box hero-block-2">
   <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
    <p><sc:FieldRenderer ID="frIcon" runat="server" FieldName="Icon" Parameters="MaxWidth=64" /></p>
    <sc:FieldRenderer ID="frAbstract" runat="server" FieldName="Text" />     
    <asp:HyperLink ID="LinkTo" runat="server" class="btn btn-primary">
     <sc:FieldRenderer ID="frLinkText" runat="server" FieldName="Link Text" />
    </asp:HyperLink>
  </div>
</asp:Panel>