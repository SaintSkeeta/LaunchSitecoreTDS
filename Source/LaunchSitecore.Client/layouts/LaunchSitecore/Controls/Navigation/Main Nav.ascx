<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Main Nav.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Navigation.Main_Nav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="navbar" id="navbar" runat="server">
 <div class="navbar-inner">
  <div class="container">
   <a class="btn btn-navbar collapsed" data-toggle="collapse" data-target=".nav-collapse">
    <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
   </a>
   <asp:HyperLink CssClass="brand" ID="BrandLink" runat="server">
    <sc:Image ID="Logo" Field="Site Logo" runat="server" MaxHeight="29" MaxWidth="120"></sc:Image>
   </asp:HyperLink>  
   <div class="nav-collapse collapse">
    <ul class="nav">
     <asp:Repeater ID="rptDropDownMenu" runat="server" OnItemDataBound="rptDropDownMenu_ItemDataBound">
      <ItemTemplate>
       <li id="MenuLi" runat="server">
        <asp:HyperLink ID="MenuLink" runat="server"><asp:Literal ID="MenuText" runat="server" /></asp:HyperLink>
        <asp:PlaceHolder ID="phSubMenu" runat="server" />
       </li>
      </ItemTemplate>
     </asp:Repeater>
    </ul>
    <div class="navbar-search pull-right">
     <asp:TextBox class="search-query span2" placeholder="Search" runat="server" ID="txtSearch" AutoPostBack="true" OnTextChanged="txt_Search_OnTextChanged" ClientIDMode="Static" />
    </div>
   </div>
  </div>
 </div>
</div>
