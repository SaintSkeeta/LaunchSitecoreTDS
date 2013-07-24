<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Featured Articles.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Featured_Articles" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="featuredarticles">
 <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
  <HeaderTemplate>
   <div class="promospot">
    <h2 class="promoheaderwithbackground">     
     <asp:Literal id="SectionTitle" runat="server" />
    </h2>
    <ul>
  </HeaderTemplate>
  <ItemTemplate>
   <li>
    <asp:HyperLink ID="ItemLink" runat="server" CssClass="featuredlink">
     <sc:FieldRenderer id="ItemName" runat="server" fieldname="Title" />
    </asp:HyperLink>
    <sc:FieldRenderer id="ItemAbstract" runat="server" fieldname="Abstract" />
   </li>
  </ItemTemplate>
  <FooterTemplate>
   </ul></div></FooterTemplate>
 </asp:Repeater>
 <asp:Panel ID="showIfEmpty" runat="server" Visible="false">
  <em class="PageEditorNote">This List is empty. Please specify the featured articles.</em>
 </asp:Panel>
</div>
