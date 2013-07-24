<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Mobile"
 CodeBehind="Mobile.aspx.cs" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
 <meta content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0" name="viewport" />
 <title><sc:Sublayout id="title" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/Title.ascx" /></title>
 <sc:Sublayout id="meta" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/Metadata.ascx" />
 <link rel="stylesheet" type="text/css" href="/_css/mobile.css" />
 <sc:Sublayout id="csstheme" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/CssTheme.ascx" />
 <script type="text/javascript" src="/_js/jquery-1.7.1.min.js"></script>
 <script src="/_js/mobile.js" type="text/javascript"></script>
 <script type="text/javascript">  jQuery(document).ready(function () { resizeImages('#contentblock img'); });</script>
</head>
<body>
 <form runat="server" id="mainForm">
 <div class="header">
  <a href="/" class="logo"><sc:Image id="Logo" Field="Mobile Logo" runat="server" MaxHeight="33"></sc:Image></a>
  <div class="buttons">
   <a class="button search" href="#" id="search_btn" onclick="TopMenuToggle('search'); return false;">
    <span class="left"></span>
    <span class="inn"><img src="/images/mobile/search.png" /></span>
    <span class="right"></span>
   </a>&nbsp;
   <a class="button" href="#" id="menu_btn" onclick="TopMenuToggle('menu'); return false;">
   <span class="left"></span>
   <span class="inn"><asp:Literal ID="litMenu" runat="server" /></span>
   <span class="right"></span>
   </a>
   <div class="clear"></div>
  </div>
  <div class="clear"></div>
 </div>
 <!-- the pull downs - main menu and search -->
 <div class="dropdowns">
  <div class="dropdown menu" id="menu">
   <h4>
    <a href="#" onclick="CloseMenu(); return false;"><asp:Literal ID="litClose" runat="server" /></a></h4>
   <sc:sublayout id="mainmenu" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Mobile Menu.ascx" />
   <div class="hr">
   </div>
  </div>
 </div>
 <div class="dropdowns">
  <div class="search" name="search" id="search">
   <div class="form"><sc:sublayout id="searchbox" runat="server" path="/layouts/LuceneSearch/Controls/MobileSearchBox.ascx" /></div>
  </div>
 </div>
 <!-- the body content and secondary navigation -->
 <div class="content">
  <div class="block">
   <sc:placeholder id="mobilecontenttop" runat="server" key="mobile-content-top" />
   <sc:placeholder id="mobilecontent" runat="server" key="mobile-content" />
   <div class="clear">
   </div>
  </div>
  <div class="menu_section">
   <div class="site_menu">
    <sc:sublayout id="submenu" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Tree Menu.ascx" />
   </div>
  </div>
 </div>
 <!-- footer -->
 <div class="footer">
  <sc:xslfile id="footer" runat="server" path="/xsl/launchsitecore/default/footer.xslt"
   cacheable="true">
  </sc:xslfile>
 </div>
 <!-- DMS Viewer -->
 <div class="content">
  <sc:Sublayout id="DMSViewer" Path="/layouts/LaunchSitecore/Default/Controls/Analytics/Current Session Info.ascx"
   runat="server" />
 </div>
 </form>
</body>
</html>
