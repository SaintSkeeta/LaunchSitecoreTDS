<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Biography.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Biography" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h3><asp:Literal ID="BiographyTitle" runat="server" /></h3>
<div id="contentblock">
 <sc:FieldRenderer ID="frBio" runat="server" FieldName="Bio" />
</div>
