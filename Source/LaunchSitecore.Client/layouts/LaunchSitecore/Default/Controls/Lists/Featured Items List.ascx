<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Featured Items List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Featured_Item_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="featuredarticles">
 <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">
  <HeaderTemplate>
   <div class="promospot">
    <h2>
     <sc:Image id="Thumbnail" runat="server" field="Image" maxwidth="30" maxheight="26" />
     <sc:FieldRenderer id="SectionTitle" runat="server" fieldname="Title" />
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
  <em class="PageEditorNote">This List is empty. Please update the inputs or remove
   this component.</em>
 </asp:Panel>
</div>
