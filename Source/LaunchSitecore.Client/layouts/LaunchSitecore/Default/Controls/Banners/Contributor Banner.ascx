<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contributor Banner.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Banners.Contributor_Banner" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="bio_top">
<div class="imagewrapper">
 <sc:FieldRenderer ID="frImage" runat="server" FieldName="Image" />
</div>
 <div class="detailswrapper">
  <div class="details">
   <h1><sc:FieldRenderer ID="frFullName" runat="server" FieldName="Full Name" /></h1>
   <h3><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h3>
   <h3 class="location">
    <asp:Literal ID="LocationTitle" runat="server" /> 
    <sc:FieldRenderer ID="frLocation" runat="server" FieldName="Location" />
   </h3>
  </div>
 </div>
</div>
