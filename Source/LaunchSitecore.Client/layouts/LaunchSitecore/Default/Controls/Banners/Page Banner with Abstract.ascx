<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Page Banner with Abstract.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Banners.Page_Banner_with_Abstract" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="abstractbanner"> 
 <div class="thickhr"></div>
 <div id="bannercolumns">
  <div class="picture">
   <sc:Image id="ItemImage" runat="server" field="Image" maxwidth="185" maxheight="185" />
  </div>
  <div class="text"> 
   <h1><sc:FieldRenderer id="frTitle" runat="server" FieldName="Title" /></h1>
   <sc:FieldRenderer id="frAbstract" runat="server" FieldName="Abstract" />
  </div><div class="floatClear"></div>
 </div> 
</div>