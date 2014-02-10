<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Icon and Title List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Icon_and_Title_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
 <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
  <ItemTemplate>
   <div class="row show-grid">
    <div class="span1 photo"><asp:HyperLink ID="LinkTo1" runat="server"><sc:FieldRenderer ID="Icon" runat="server" FieldName="Icon" Parameters="MaxWidth=64" /></asp:HyperLink></div>
    <div class="span8">
     <h2><asp:HyperLink ID="LinkTo2" runat="server"><sc:FieldRenderer ID="Title" runat="server" FieldName="Title" /></asp:HyperLink></h2>
     <sc:FieldRenderer ID="Abstract" runat="server" />
    </div>
   </div>
  </ItemTemplate>
  <SeparatorTemplate><div class="text-divider3"></div></SeparatorTemplate>
 </asp:Repeater>
</div>
