<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Quick Search.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Search.Quick_Search" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="row show-grid">
 <div class="span12">
  <asp:UpdatePanel ID="branchUpdatePanel" runat="server">
 <ContentTemplate>
  <div class="row show-grid clear-both">
   <div id="left-sidebar" class="span3 sidebar">
    <div class="side-nav sidebar-block">
     <h2><asp:Literal id="litRefineResults" runat="server" /></h2>
     <h3><asp:Literal id="litType" runat="server" /></h3>
     <asp:CheckBoxList ID="TypeFacetCheckList" runat="server" DataTextField="Name" DataValueField="Name" RepeatLayout="UnorderedList" CssClass="css-checkboxes" AutoPostBack="true" OnSelectedIndexChanged="TypeFacets_SelectedIndexChanged"></asp:CheckBoxList>
     <h3><asp:Literal id="litTags" runat="server" /></h3>
     <asp:CheckBoxList ID="TagsFacetCheckList" runat="server" DataTextField="Name" DataValueField="Name" RepeatLayout="UnorderedList" CssClass="css-checkboxes" AutoPostBack="true" OnSelectedIndexChanged="TagFacets_SelectedIndexChanged"></asp:CheckBoxList>    
     <sc:placeholder id="contenttertiary" runat="server" key="content-tertiary" />
    </div>
   </div>
   <div class="span9 main-column two-columns-left">
    <h1><asp:Literal id="litSearchResultsFor" runat="server" /> <asp:Literal ID="searchString" runat="server" /></h1>
    <asp:Repeater ID="rptSearchResults" runat="server" OnItemDataBound="rptSearchResults_ItemDataBound">
     <ItemTemplate>
      <div>
       <h3><asp:HyperLink ID="ItemLink" runat="server" /></h3>
       <p><asp:Literal ID="ItemDescription" runat="server" /></p>
      </div>
     </ItemTemplate>
     <SeparatorTemplate><a class="text-divider4" href="#top">back to top</a></SeparatorTemplate>
    </asp:Repeater>
   </div>
  </div>
  </ContentTemplate>
   </asp:UpdatePanel>
 </div>
</div>
