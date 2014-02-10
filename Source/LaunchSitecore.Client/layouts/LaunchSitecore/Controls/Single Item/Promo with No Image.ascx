<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promo with No Image.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Promo_with_No_Image" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnl">
 <div class="grey-box">
  <div class="hero-block3">
   <div class="row show-grid">
    <div class="span9">
     <div class="hero-content-3">
      <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
      <sc:FieldRenderer ID="frText" runat="server" FieldName="Text" />
     </div>
    </div>
    <div class="span3">
     <div class="tour-btn">
      <asp:HyperLink ID="LinkTo" runat="server" CssClass="btn btn-primary">
       <sc:FieldRenderer ID="frLinkText" runat="server" FieldName="Link Text" />
      </asp:HyperLink>
     </div>
    </div>
   </div>
  </div>
 </div>
</asp:Panel>