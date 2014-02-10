<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Enhanced Carousel.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Carousel.Enhanced_Carousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- To make this carousel full width, use a view that takes this out of the container div. 
     Example: http://getbootstrap.com/2.3.2/examples/carousel.html -->
<div id="enhanced-carousel" class="carousel slide">
 <div class="carousel-inner">
  <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
   <HeaderTemplate><div class="item active"></HeaderTemplate>
   <ItemTemplate>
     <sc:FieldRenderer ID="CarouselImage" FieldName="Image" runat="server" Parameters="MaxWidth=950" />
     <div class="container">
     <div class="carousel-caption" id="carouselcaption" runat="server"><sc:EditFrame ID="LinkFrame" runat="server" >
      <h1><sc:FieldRenderer ID="Title" FieldName="Title" runat="server" /></h1>
      <sc:FieldRenderer ID="Caption" FieldName="Caption" runat="server" />
      <p class="btn-wrapper"><asp:HyperLink ID="TextLink" runat="server" CssClass="btn btn-large btn-primary"><sc:FieldRenderer ID="LinkText" FieldName="Link Text" runat="server" /> »</asp:HyperLink></p>
     </sc:EditFrame></div></div>
   </ItemTemplate>
   <SeparatorTemplate></div><div class="item"></SeparatorTemplate>
   <FooterTemplate></div></FooterTemplate>
  </asp:Repeater>
 </div> 
 <a class="carousel-control left" href="#enhanced-carousel" data-slide="prev">‹</a>
 <a class="carousel-control right" href="#enhanced-carousel" data-slide="next">›</a>
</div>