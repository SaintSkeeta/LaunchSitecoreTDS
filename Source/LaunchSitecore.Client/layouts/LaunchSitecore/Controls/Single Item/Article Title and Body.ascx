<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article Title and Body.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Article_Title_and_Body" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<article>
 <h1><sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Title" /></h1>
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Body" />
</article>
