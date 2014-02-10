<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Team List.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Lists.Team_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
 <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
  <ItemTemplate>
   <div class="row show-grid team-member">
    <div class="span2 photo">
     <div class="bordered-img"><asp:HyperLink ID="LinkTo1" runat="server"><sc:FieldRenderer ID="Image" runat="server" FieldName="Image" Parameters="MaxWidth=150" /></asp:HyperLink></div>
    </div>
    <div class="span7">
     <h2><asp:HyperLink ID="LinkTo2" runat="server"><sc:FieldRenderer ID="FullName" runat="server" FieldName="Title" /></asp:HyperLink></h2>
     <h4><sc:FieldRenderer ID="Title" runat="server" FieldName="Job Title" /></h4>
     <p class="experience"><em><sc:FieldRenderer ID="Quote" runat="server" FieldName="Quote" /></em></p>
     <sc:FieldRenderer ID="Abstract" runat="server" FieldName="Abstract" />
    </div>
   </div>
  </ItemTemplate>
  <SeparatorTemplate><div class="member-divider"></div></SeparatorTemplate>
 </asp:Repeater>
</div>
