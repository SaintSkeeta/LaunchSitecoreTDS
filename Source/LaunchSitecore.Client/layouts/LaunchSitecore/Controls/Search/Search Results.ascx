<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search Results.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Search.Search_Results" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="row show-grid">
 <div class="span12">
  <div class="row show-grid clear-both">
   <div id="left-sidebar" class="span3 sidebar">
    <div class="side-nav sidebar-block">
     <h2>Refine Results</h2>
     <asp:Repeater runat="server" ID="FacetGroups" OnItemDataBound="FacetGroup_ItemDataBound">
      <ItemTemplate>
       <div>
        <h3><%# Eval("Name") %></h3>
        <asp:CheckBoxList ID="FacetsCheckList" runat="server" DataTextField="Name" DataValueField="Name" RepeatLayout="UnorderedList" CssClass="css-checkboxes" AutoPostBack="true"></asp:CheckBoxList>
       </div>
      </ItemTemplate>
     </asp:Repeater>
    </div>
   </div>



   <div class="span9 main-column two-columns-left">
    <h1>Search Results for: <asp:Literal ID="searchString" runat="server" /></h1>
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
 </div>
</div>
















