<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Abstract Box.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Abstract_Box" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="pnlAbstract" runat="server">
 <div class="grey-box abstract-box">
   <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Title" /></h2>
    <p><sc:FieldRenderer ID="frIcon" runat="server" FieldName="Icon" Parameters="MaxWidth=32" /></p>
    <sc:FieldRenderer ID="frAbstract" runat="server" FieldName="Abstract" />     
    <asp:HyperLink ID="LinkTo" runat="server" class="btn btn-primary" />
  </div>
</asp:Panel>



 
