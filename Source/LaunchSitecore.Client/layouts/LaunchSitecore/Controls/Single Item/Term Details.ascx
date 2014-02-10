<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Term Details.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Term_Details" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
 <article>
  <h1><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h1>
  <div class="post-img pull-right img-polaroid bio-img">
   <sc:FieldRenderer ID="Image" runat="server" FieldName="Image" Parameters="MaxWidth=350" />
  </div>
  <h3><asp:Literal ID="DefinitionLabel" runat="server" /></h3>
  <sc:FieldRenderer ID="Defintion" runat="server" FieldName="Definition" />
  <h3><asp:Literal ID="UsageLabel" runat="server" /></h3>
  <sc:FieldRenderer ID="Usage" runat="server" FieldName="Usage" />
 </article>
</div>