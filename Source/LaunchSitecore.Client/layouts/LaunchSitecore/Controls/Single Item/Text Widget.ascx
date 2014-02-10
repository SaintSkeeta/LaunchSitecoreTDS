<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Text Widget.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Text_Widget" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel runat="server" ID="pnl">
 <div class="text-widget sidebar-block">
  <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
  <sc:FieldRenderer ID="frText" runat="server" FieldName="Text" />
 </div>
</asp:Panel>