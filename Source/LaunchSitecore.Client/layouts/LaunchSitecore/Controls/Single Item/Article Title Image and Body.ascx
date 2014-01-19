<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Article Title Image and Body.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Article_Title_Image_and_Body" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<article>
 <h1>
  <sc:FieldRenderer ID="FieldRenderer1" runat="server" FieldName="Title" />
 </h1>
 <div class="post-img pull-right img-polaroid bio-img">
  <sc:FieldRenderer ID="frImage" runat="server" FieldName="Image" Parameters="MaxWidth=200" />
 </div> 
 <sc:FieldRenderer ID="frBody" runat="server" FieldName="Body" /> 
</article>
<div style="clear: both;"></div>
