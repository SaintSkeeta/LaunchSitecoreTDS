<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Jumbotron.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Jumbotron" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="jumbotron">
 <div class="container">
  <h1><sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Title" /></h1>
  <sc:FieldRenderer ID="frBody" runat="server" FieldName="Body" />
  <p><asp:HyperLink ID="calltoaction" runat="server" class="btn btn-primary btn-lg" /></p>
 </div>
</div>
