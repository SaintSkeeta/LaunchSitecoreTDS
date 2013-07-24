<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Abstract List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Abstract_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
 <ItemTemplate>  
   <div class="abstract_item">
    <h3><sc:FieldRenderer ID="Title" runat="server" FieldName="Title" /></h3>
    <sc:FieldRenderer ID="Abstract" runat="server" FieldName="Abstract" />
    <asp:Hyperlink ID="LinkTo" runat="server" class="readmore" />
   </div>
 </ItemTemplate> 
</asp:Repeater>
<asp:Panel ID="showIfEmpty" runat="server" Visible="false">
<em class="PageEditorNote">This Abstract List is empty.  Please provide a valid datasource or remove this component.</em>
</asp:Panel>