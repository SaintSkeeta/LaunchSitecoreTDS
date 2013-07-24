<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Current Session Info.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Analytics.Current_Session_Info" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="foldtarget">
 <div id="sessiondetailswrapper">
  <sc:Image id="Logo" MaxHeight="46" Field="Peel Back Image" runat="server" Cssclass="dmslogo"></sc:Image>  
  <div class="thickhrlessmargin">
  </div>
  <div id="dmsheading">
   <div class="closed" onclick="DMSToggle(); return false;" id="dmsBtn">
    <h4><asp:Literal ID="DMSTitle" runat="server" /></h4>
   </div>
  </div>
  <div id="dmsdetails">
   <p><asp:Literal ID="DMSInstructions" runat="server" /></p>
   <asp:Panel ID="DMSNote" runat="server" Visible="false">
    <div class="grayborder">
     <em class="PageEditorNote">Analytics is not enabled. Please install DMS.</em>
    </div>
   </asp:Panel>
   <asp:Panel ID="DMSEnabled" runat="server" Visible="true">
    <div class="grayborder">
     <asp:Panel ID="PatternMatchPanel" runat="server" Visible="false">
      <h4><sc:FieldRenderer ID="Name" runat="server" FieldName="Name" /></h4>
      <div class="content">
       <sc:FieldRenderer ID="Image" runat="server" FieldName="Image" Parameters="MaxHeight=120&MaxWidth=140" />
       <sc:FieldRenderer ID="Description" runat="server" FieldName="Description" />
      </div>
      <div class="floatClear"></div>
     </asp:Panel>
     <asp:Panel ID="PatternMatchPanelNoMatch" runat="server">
      <h4><asp:Literal ID="DMSNoPatternMatchName" runat="server" /></h4>
      <div class="content">
       <img src="/images/common/question_mark_head.jpg" alt="Unknown" />
       <em><asp:Literal ID="DMSNoPatternMatch" runat="server" /></em>
      </div>
      <div class="floatClear"></div>
     </asp:Panel>
    </div>
    <div class="grayborder">
     <asp:Panel ID="ProfileKeyValues" runat="server" Visible="false">
      <h4><asp:Literal ID="litProfileKey" runat="server" /></h4>
      <div class="thickhrlessmargin">
      </div>
      <asp:Repeater ID="ProfileValues" runat="server">
       <HeaderTemplate><table cellpadding="2" cellspacing="0"></HeaderTemplate>
       <ItemTemplate>
        <tr>
         <td><%# Eval("key")%></td>
         <td><%# Eval("value")%></td>
        </tr>
       </ItemTemplate>
       <AlternatingItemTemplate>
        <tr>
         <td class="alternate"><%# Eval("key")%></td>
         <td class="alternate"><%# Eval("value")%></td>
        </tr>
       </AlternatingItemTemplate>
       <FooterTemplate></table></FooterTemplate>
      </asp:Repeater>
     </asp:Panel>
     <asp:Panel ID="ProfileKeyNoValues" runat="server">
      <em><asp:Literal ID="DMSNoProfileValues" runat="server" /></em>
     </asp:Panel>
    </div>
   </asp:Panel>
  </div>
 </div>
</div>
