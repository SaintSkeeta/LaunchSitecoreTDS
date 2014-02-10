<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Abstract Spot.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.AbstractSpot" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="pnlAbstract" runat="server" CssClass="abstract-spot">
 <div class="image-wrapper"><sc:FieldRenderer ID="frIcon" runat="server" FieldName="Icon" Parameters="MaxWidth=64" /></div>
 <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
 <sc:FieldRenderer ID="frAbstract" runat="server" FieldName="Abstract" />
 <p><asp:HyperLink ID="LinkTo" runat="server" /></p>
</asp:Panel>