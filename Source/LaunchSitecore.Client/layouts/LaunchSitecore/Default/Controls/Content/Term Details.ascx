<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Term Details.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Term_Details" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="abstract_item">
 <h3><asp:Literal id="DefinitionLabel" runat="server" /></h3>
 <sc:FieldRenderer id="Definition" runat="server" FieldName="Definition" />
</div>
<div class="abstract_item">
 <h3><asp:Literal id="ImageLabel" runat="server" /></h3>
 <sc:FieldRenderer id="Image" runat="server" FieldName="Image" />
</div>
<div class="abstract_item">
 <h3><asp:Literal id="UsageLabel" runat="server" /></h3>
 <sc:FieldRenderer id="Usage" runat="server" FieldName="Usage" />
</div>