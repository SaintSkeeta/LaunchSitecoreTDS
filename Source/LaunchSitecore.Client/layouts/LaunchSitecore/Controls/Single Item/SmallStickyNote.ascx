<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmallStickyNote.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.SmallStickyNote" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnlStickyNote">
 <h3><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h3>
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Message" />
</asp:Panel>
