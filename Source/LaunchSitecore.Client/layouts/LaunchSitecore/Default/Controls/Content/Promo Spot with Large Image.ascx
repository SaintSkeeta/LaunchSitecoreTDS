<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Promo Spot with Large Image.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Promo_Spot_with_Large_Image" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="promospot">
 <h2><sc:fieldrenderer id="Title" runat="server" fieldname="Title" /></h2>
 <div class="picture"><sc:image id="Thumbnail" runat="server" field="Image" maxwidth="195" maxheight="106" /></div>
 <sc:fieldrenderer id="Abstract" runat="server" fieldname="Abstract" />
 <asp:HyperLink ID="LinkTo" runat="server" class="readmore" />
</div>