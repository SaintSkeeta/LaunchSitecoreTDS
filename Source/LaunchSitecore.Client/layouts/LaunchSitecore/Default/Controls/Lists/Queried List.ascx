<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Queried List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Queried_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="featuredarticles">
 <asp:Repeater ID="rptItems" runat="server" OnItemDataBound="rptItems_ItemDataBound">  
  <ItemTemplate>
   <div class="abstract_item">
    <h3><sc:FieldRenderer id="ItemName" runat="server" fieldname="Title" /></h3>
    <sc:FieldRenderer id="ItemAbstract" runat="server" fieldname="Abstract" />
    <asp:HyperLink ID="LinkTo" runat="server" class="readmore" />    
   </div>
  </ItemTemplate>
 </asp:Repeater>
 <asp:Panel ID="showIfEmpty" runat="server" Visible="false">
  <em class="PageEditorNote">This List is empty. Please update the inputs or remove this component.</em>
 </asp:Panel>
</div>
