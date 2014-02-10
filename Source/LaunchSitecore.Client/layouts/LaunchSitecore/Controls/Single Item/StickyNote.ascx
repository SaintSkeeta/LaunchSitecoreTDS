<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StickyNote.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.StickyNote" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnlStickyNote">
 <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Message" />
</asp:Panel>