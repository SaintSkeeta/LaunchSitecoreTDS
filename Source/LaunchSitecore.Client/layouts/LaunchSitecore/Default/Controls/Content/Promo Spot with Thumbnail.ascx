<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promo Spot with Thumbnail.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Promo_Spot_with_Thumbnail" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="promospot">
 <h2>
  <sc:Image id="Thumbnail" runat="server" Field="Image" maxwidth="30" maxheight="26" />
  <sc:fieldrenderer id="Title" runat="server" fieldname="Title" />
 </h2>
 <sc:fieldrenderer id="Abstract" runat="server" fieldname="Abstract" />
 <asp:HyperLink ID="LinkTo" runat="server" class="readmore" />
</div>
<div class="floatClear"></div>