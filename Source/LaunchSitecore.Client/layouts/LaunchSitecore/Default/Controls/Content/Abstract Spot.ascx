<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Abstract Spot.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Abstract_Spot" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="abstract_item">
 <h3><sc:fieldrenderer id="Title" runat="server" fieldname="Title" /></h3>
 <sc:fieldrenderer id="Abstract" runat="server" fieldname="Abstract" />
 <asp:HyperLink ID="LinkTo" runat="server" class="readmore" />
</div>
