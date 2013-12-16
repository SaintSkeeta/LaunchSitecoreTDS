<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Search.SearchResults" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div id="contentblock">
 <p>
  <asp:Label ID="lblSearchString" runat="server" Text="Label" />
  <asp:Panel ID="pnResultsPanel" runat="server"></asp:Panel>
 </p>

 <asp:Repeater id="rptSearchResults" runat="server" OnItemDataBound="rptSearchResults_ItemDataBound">
  <ItemTemplate>
   <div class='search-results-hit'>
    <p>
     <asp:Image ID="ItemImage" runat="server" Width="13" Height="13" AlternateText="icon" />
     <asp:HyperLink ID="ItemLink" runat="server"></asp:HyperLink><br />
     <asp:Literal ID="ShortDescription" runat="server"></asp:Literal>
     <em><strong><asp:Literal ID="LastUpdatedText" runat="server"></asp:Literal></strong><asp:Literal ID="LastUpdatedDate" runat="server"></asp:Literal></em>
    </p>
   </div>
  </ItemTemplate>
 </asp:Repeater>

 <p><asp:Literal id="lblCurrentPage" runat="server" /></p>
 <p>
  <asp:LinkButton id="cmdPrev" runat="server" onclick="cmdPrev_Click" />
  <asp:LinkButton id="cmdNext" runat="server" onclick="cmdNext_Click" />
 </p>
</div>