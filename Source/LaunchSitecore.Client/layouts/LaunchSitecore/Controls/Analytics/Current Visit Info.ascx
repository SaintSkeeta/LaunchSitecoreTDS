<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Current Visit Info.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Analytics.Current_Visit_Info" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="pnlDetails" runat="server">
<asp:Literal ID="DMSTitle" runat="server" />
<h3 class="center-title">
 <asp:Literal ID="litVisitDetails" runat="server" />
 <span class="pagecounts">
  <img src="/assets/img/page.png" alt="Pages" title="Pages Viewed" /><asp:Literal ID="PageCount" runat="server" />
  <img src="/assets/img/value.png" alt="Value" title=" Engagement Value" /><asp:Literal ID="EngagementValue" runat="server" />
 </span>
</h3>
<div style="clear: both"></div>
<div id="accordion" class="accordion in collapse">
  <div class="accordion-group">
  <div class="accordion-heading">
   <a href="#collapseZero" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle collapsed">
    <asp:Literal ID="litPattern" runat="server" />
   </a>
  </div>
  <div class="accordion-body collapse" id="collapseZero">
   <div class="accordion-inner">
    <div class="patternwrapper">
     <asp:Repeater ID="rptPatternList" runat="server" OnItemDataBound="rptPatternList_ItemDataBound">
      <ItemTemplate>
       <sc:Sublayout ID="currentPattern" runat="server" Path="/layouts/LaunchSitecore/Controls/Analytics/Current Pattern.ascx" DataSource="/sitecore/system/Marketing Center/Profiles/Job Function" />     
      </ItemTemplate> 
      </asp:Repeater>     
    </div>
   </div>
  </div>
 </div>
 <div class="accordion-group">
  <div class="accordion-heading">
   <a href="#collapseOne" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle collapsed">
    <asp:Literal ID="litCampaign" runat="server" />
   </a>
  </div>
  <div class="accordion-body collapse" id="collapseOne">
   <div class="accordion-inner">
    <ul>
     <li><asp:Literal ID="litCurrentCampaign" runat="server" /></li>
    </ul>
   </div>
  </div>
 </div>
 <div class="accordion-group">
  <div class="accordion-heading">
   <a href="#collapseTwo" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle collapsed">
    <asp:Literal ID="litLocation" runat="server" />
   </a>
  </div>
  <div class="accordion-body collapse" id="collapseTwo">
   <div class="accordion-inner">
    <ul>
     <li>
      <asp:Literal ID="litCityLabel" runat="server" />:
      <asp:Literal ID="litCity" runat="server" /></li>
     <li>
      <asp:Literal ID="litPostalCodeLabel" runat="server" />:
      <asp:Literal ID="litZip" runat="server" /></li>
    </ul>
   </div>
  </div>
 </div>
 <div class="accordion-group">
  <div class="accordion-heading">
   <a href="#collapseThree" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle e collapsed">
    <asp:Literal ID="litPages" runat="server" />
   </a>
  </div>
  <div class="accordion-body collapse" id="collapseThree" >
   <div class="accordion-inner">
    <asp:Repeater ID="PagesVisited" runat="server" OnItemDataBound="PagesVisited_ItemDataBound">
     <HeaderTemplate>
      <ul>
     </HeaderTemplate>
     <ItemTemplate>
      <li>
       <asp:Literal ID="litPage" runat="server" /></li>
     </ItemTemplate>
     <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
   </div>
  </div>
 </div>
 <div class="accordion-group">
  <div class="accordion-heading">
   <a href="#collapseFour" data-parent="#accordion" data-toggle="collapse" class="accordion-toggle e collapsed">
    <asp:Literal ID="litGoals" runat="server" />
   </a>
  </div>
  <div class="accordion-body collapse" id="collapseFour">
   <div class="accordion-inner">
    <asp:Repeater ID="GoalsAcheived" runat="server" OnItemDataBound="GoalsAchieved_ItemDataBound">
     <HeaderTemplate><ul></HeaderTemplate>
     <ItemTemplate><li><asp:Literal ID="litConversion" runat="server" /></li></ItemTemplate>
     <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
    <asp:Panel id="GoalsEmpty" runat="server">
     <ul><li>No goal conversions</li></ul>
    </asp:Panel>
   </div>
  </div>
 </div>
</div>
</asp:Panel>