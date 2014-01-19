<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Biography.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Biography" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
 <article>
  <h1>
   <sc:FieldRenderer ID="frName" runat="server" FieldName="Title" />
   <small><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Job Title" /></small>
  </h1>
  <div class="post-img pull-right img-polaroid bio-img">
   <sc:FieldRenderer ID="frImage" runat="server" FieldName="Image" Parameters="MaxWidth=200" />
  </div>
  <sc:FieldRenderer ID="frBody" runat="server" FieldName="Abstract" />  
  <blockquote><p><sc:FieldRenderer ID="frQuote" runat="server" FieldName="Quote" /></p></blockquote>
  <sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Body" />
 </article>
</div>
