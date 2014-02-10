<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Current Pattern.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Analytics.Current_Pattern" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="DMSEnabled" runat="server" Visible="true">
 <asp:Panel ID="PatternMatchPanel" runat="server" Visible="false">  
  <div class="image-wrapper"><sc:FieldRenderer ID="Image" runat="server" FieldName="Image" /></div>
  <h4><asp:Literal ID="DMSTitle" runat="server" /></h4>  
  <h5><sc:FieldRenderer ID="Name" runat="server" FieldName="Name" /></h5>  
 </asp:Panel>
 <asp:Panel ID="PatternMatchPanelNoMatch" runat="server">
  <div class="image-wrapper"><img src="/assets/img/nope.png" alt="Unknown" /></div>
   <h4><asp:Literal ID="DMSTitle2" runat="server" /></h4>    
  <h5><asp:Literal ID="DMSNoPatternMatchName" runat="server" /></h5>  
 </asp:Panel>
</asp:Panel>
<div style="clear:both"></div>