<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promo with Image.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Promo_with_Image" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnl">
<div class="thumbnail">
 <sc:FieldRenderer ID="frImage" CssClass="img-rounded" runat="server" FieldName="Image" Parameters="MaxWidth=300px" />
 <div class="caption">
  <h3><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h3>
  <sc:FieldRenderer ID="frText" runat="server" FieldName="Text" />
  <p><asp:HyperLink ID="LinkTo" runat="server" CssClass="btn btn-primary">
   <sc:FieldRenderer ID="frLinkText" runat="server" FieldName="Link Text" />
  </asp:HyperLink></p>
 </div>
</div>
</asp:Panel>
