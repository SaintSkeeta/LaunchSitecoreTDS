<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Title and Body for Footer.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Title_and_Body_for_Footer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
 <h4><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h4>
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Body" />