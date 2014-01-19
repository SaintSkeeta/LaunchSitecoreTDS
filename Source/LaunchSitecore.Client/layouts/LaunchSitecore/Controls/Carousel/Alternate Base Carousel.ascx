<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Alternate Base Carousel.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Carousel.Alternate_Base_Carousel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="base-carousel" class="carousel slide">
 <div class="carousel-inner">
  <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
   <HeaderTemplate><div class="item active"></HeaderTemplate>
   <ItemTemplate>
     <asp:HyperLink ID="ImgLink" runat="server"><sc:FieldRenderer ID="CarouselImage" FieldName="Image" runat="server" /></asp:HyperLink>
     <div class="carousel-caption">
      <h4><sc:FieldRenderer ID="Title" FieldName="Title" runat="server" /></h4>
      <sc:FieldRenderer ID="Caption" FieldName="Caption" runat="server" />
      <p><sc:EditFrame ID="LinkFrame" runat="server" ><asp:HyperLink ID="TextLink" runat="server"><sc:FieldRenderer ID="LinkText" FieldName="Link Text" runat="server" /> »</asp:HyperLink></sc:EditFrame></p>
     </div>
   </ItemTemplate>
   <SeparatorTemplate></div><div class="item"></SeparatorTemplate>
   <FooterTemplate></div></FooterTemplate>
  </asp:Repeater>
 </div> 
 <a class="carousel-control left" href="#base-carousel" data-slide="prev">‹</a>
 <a class="carousel-control right" href="#base-carousel" data-slide="next">›</a>
</div>