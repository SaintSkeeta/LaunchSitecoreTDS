<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Job Function Grid.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Analytics.Job_Function_Grid" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
 <HeaderTemplate><div id="evaluators"></HeaderTemplate>
 <ItemTemplate>
  <asp:HyperLink ID="LinkTo" runat="server" CssClass="tab left">
   <div class="picturewrapper"><sc:Image ID="Image" runat="server" CssClass="picture" Field="Image" /></div>
   <div class="eval_text">
    <h3><sc:FieldRenderer ID="Title" runat="server" FieldName="Home Title" /></h3>
    <sc:FieldRenderer ID="Abstract" runat="server" FieldName="Home Abstract" />   
   </div>
  </asp:HyperLink>
 </ItemTemplate>
 <AlternatingItemTemplate>  
  <asp:HyperLink ID="LinkTo" runat="server" CssClass="tab right">
   <div class="picturewrapper"><sc:Image ID="Image" runat="server" CssClass="picture" Field="Image" /></div>
   <div class="eval_text">
    <h3><sc:FieldRenderer ID="Title" runat="server" FieldName="Home Title" /></h3>
    <sc:FieldRenderer ID="Abstract" runat="server" FieldName="Home Abstract" />   
   </div>
  </asp:HyperLink>  
 </AlternatingItemTemplate>
 <FooterTemplate><div class="floatClear"></div></div></FooterTemplate>
</asp:Repeater>