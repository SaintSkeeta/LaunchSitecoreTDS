<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Title and Body.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Title_and_Body" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
 <h1><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h1>
 <h2 id="subtitlewrapper" runat="server" Visible="false"><sc:FieldRenderer ID="frSubTitle" runat="server" FieldName="Subtitle" /></h2>
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Body" />