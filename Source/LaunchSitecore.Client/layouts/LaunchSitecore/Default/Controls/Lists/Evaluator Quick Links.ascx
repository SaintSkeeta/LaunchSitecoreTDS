<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Evaluator Quick Links.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Evaluator_Quick_Links" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="featuredarticles">
 <div class="promospot">
  <h2>   
   <sc:fieldrenderer id="SectionTitle" runat="server" fieldname="Quick Links Title" />
  </h2>
  <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
   <HeaderTemplate><ul></HeaderTemplate>
   <ItemTemplate>
    <li>
     <asp:HyperLink ID="ItemLink" runat="server" CssClass="featuredlink">
      <sc:fieldrenderer id="ItemName" runat="server" fieldname="Title" />
     </asp:HyperLink>
     <sc:fieldrenderer id="ItemAbstract" runat="server" fieldname="Abstract" />
    </li>
   </ItemTemplate>
   <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
 </div>
</div>
