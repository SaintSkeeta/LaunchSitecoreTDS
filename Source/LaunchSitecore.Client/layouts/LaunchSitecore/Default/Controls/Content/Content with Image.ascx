<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Content with Image.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Content_with_Image" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="demo_block">
 <div class="left">
  <div class="messaging">
   <h1><sc:fieldrenderer id="title" runat="server" fieldname="Title" /></h1>
   <sc:fieldrenderer id="body" runat="server" fieldname="Body" />
   <div class="links">
    <asp:HyperLink ID="calltoaction" runat="server">
     <span class="left_bg"></span>
     <span class="inner"><sc:text id="calltoactiontext" runat="server" field="Call to Action Text" /></span>
     <span class="right_bg"></span>
    </asp:HyperLink>
   </div>
  </div>
 </div>
 <div class="right"><sc:Image id="mainimage" runat="server" field="Image" maxwidth="350" maxheight="219" /></div>
 <div class="floatClear"></div>
</div>
