<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Main" CodeBehind="Main.aspx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><sc:Sublayout id="title" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/Title.ascx" /></title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<sc:Sublayout id="meta" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/Metadata.ascx" /> 
	<link href="/default.css" rel="stylesheet" type='text/css' />
	<link href="/_css/main.css" rel="stylesheet" type="text/css" />
	<sc:Sublayout id="csstheme" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Meta/CssTheme.ascx" />					
	<link href="/_css/colorbox.css" rel="stylesheet" type="text/css" /> 
	<script type="text/javascript" src="/_js/jquery-1.7.1.min.js"></script>
	<script type="text/javascript" src="/_js/jqueryslidemenu.js"></script> 
	<script type="text/javascript" src="/_js/jquery-ui.min.js"></script>
	<script type="text/javascript" src="/_js/PeelingEdge/turn.js"></script>    
	<script type="text/javascript" src="/_js/ColorBox/jquery.colorbox-min.js"></script>
	<script type='text/javascript' src='/_js/jquery.hoverIntent.minified.js'></script>
	<script type='text/javascript' src='/_js/jquery.dcmegamenu.1.3.3.js'></script>
	<sc:visitoridentification runat="server" /> 
</head>
<body>
	<form method="post" runat="server" id="mainform">
	<div id="SectionWrapper">
		<div id="wrapper">
			<!-- BEGIN: HEADER -->
			<div id="headerwrapper" lang="en">
				<h3 id="logo"><a href="/"><sc:Image id="Logo" Field="Site Logo" runat="server" MaxHeight="46"></sc:Image></a></h3>				
				<sc:Sublayout id="siteselector" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Site Selector.ascx" />
				<div id="globalnav">     
					<sc:Sublayout id="loginbuttons" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Secure/Security Buttons.ascx" />					
					<sc:Sublayout id="searchbox" runat="server" path="/layouts/LuceneSearch/Controls/LuceneSearchBox.ascx" /> 
				</div>    
			</div>
			<div class="floatClear"></div>
			<!-- BEGIN: Top Nav -->
			<sc:Sublayout id="mainmenu" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Main Navigation.ascx" />		   
			<!-- END: Top Nav -->
			<div id="container">
				<sc:Sublayout id="breadcrumbs" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Breadcrumbs.ascx" />
				<sc:Sublayout id="Sublayout1" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Secure/Add To Favorites.ascx" />
				<div class="floatClear"></div>
				<!-- BEGIN: Main Content Area -->
				<div id="contentwrapper">
					<sc:placeholder id="maincontent" runat="server" key="main-content" />
				</div>
				<!-- END:  Main Content Area -->
				<div class="floatClear">
				</div>
			</div>    
			<div id="footerwrapper">
				<sc:Sublayout id="footermenu" runat="server" path="/layouts/LaunchSitecore/Default/Controls/Navigation/Footer Navigation.ascx" />   
				<sc:XslFile ID="footer" runat="server" Path="/xsl/launchsitecore/default/footer.xslt" Cacheable="true"></sc:XslFile>
				<sc:Sublayout id="VersionInfo" Path="/layouts/LaunchSitecore/Default/Controls/Content/Version Information.ascx" runat="server" />   
			</div>
		</div>
	</div>
	<sc:Sublayout id="DMSViewer" Path="/layouts/LaunchSitecore/Default/Controls/Analytics/Current Session Info.ascx" runat="server" /> 
	</form>
</body>
</html>
