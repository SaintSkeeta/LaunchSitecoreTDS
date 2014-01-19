<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedQuotation.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.FeaturedQuotation" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnlQuotation">
  <blockquote>
    <p><sc:FieldRenderer runat="server" FieldName="Quotation" ID="quotation" /></p>
    <p class="autor"><sc:FieldRenderer runat="server" FieldName="Author" ID="author" /></p>
  </blockquote>
</asp:Panel>