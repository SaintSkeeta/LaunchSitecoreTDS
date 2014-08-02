<%@ Page Language="c#" CodePage="65001" AutoEventWireup="true" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Main" CodeBehind="Main.aspx.cs" %>
<%@ Register Src="~/layouts/LaunchSitecore/Controls/Navigation/Tertiary Nav.ascx" TagPrefix="uc1" TagName="TertiaryNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Analytics" %>
<!DOCTYPE html>
<html>
<head> 
 <title><sc:Sublayout ID="title" runat="server" Path="/layouts/LaunchSitecore/Controls/Meta/Title.ascx" /></title>
 <sc:Sublayout ID="meta" runat="server" Path="/layouts/LaunchSitecore/Controls/Meta/Metadata.ascx" />
 <meta name="robots" content="follow, index" />
 <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />
 <link rel="stylesheet" href="/assets/css/bootstrap.css" />
 <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,400italic,600,600italic,700,700italic" rel="stylesheet" type="text/css" />
 <link rel="stylesheet" href="/assets/css/font-awesome.css" />
 <link rel="stylesheet" href="/assets/css/font-awesome-ie7.css" />
 <link rel="stylesheet" href="/assets/css/custom_base.css" />
 <link rel="stylesheet" href="/assets/css/custom_nav.css" />
 <link rel="stylesheet" href="/assets/css/custom_modules.css" />
 <sc:Sublayout ID="csstheme" runat="server" Path="/layouts/LaunchSitecore/Controls/Meta/CssTheme.ascx" />
 <sc:VisitorIdentification runat="server" />
 <!--[if lte IE 8]>
 <link rel="stylesheet" type="text/css" href="/assets/css/IE-fix.css" />
 <![endif]-->
</head> 
<body id="mainbody" runat="server">
 <form method="post" runat="server" id="mainform">
  <asp:ScriptManager ID="singleScriptManager" runat="server"></asp:ScriptManager>
  <div id="over">
   <div id="out_container" clientidmode="Static" runat="server">
    <!-- THE LINE AT THE VERY TOP OF THE PAGE -->
    <div class="top_line" id="topline" runat="server"></div>
    <!-- HEADER AREA -->
    <header>
     <div class="container">
      <div class="row">
       <!-- HEADER: LOGO AREA -->
       <div class="span4 logo" id="logospan" runat="server"><a class="logo" href="/"><sc:Image ID="Logo" Field="Site Logo" runat="server" MaxHeight="72" MaxWidth="250"></sc:Image></a></div>
       <div class="span4 offset4" id="tertiarynavspan" runat="server"><sc:Sublayout ID="tertiaryNav" runat="server" Path="/layouts/LaunchSitecore/Controls/Navigation/Tertiary Nav.ascx" /></div>
      </div>
     </div>
     <!-- HEADER: PRIMARY SITE NAVIGATION -->
     <div class="container"><sc:Sublayout ID="MainNav" runat="server" Path="/layouts/LaunchSitecore/Controls/Navigation/Main Nav.ascx" /></div>
    </header>
    <!-- MAIN CONTENT AREA -->
    <div class="main-content">
     <div class="container"><sc:Placeholder ID="maincontent" runat="server" Key="main-content" /></div>
    </div>
    <footer id="footer">
     <div class="footer-top"></div>
     <div class="footer-wrapper">
      <div class="container">
       <div class="row show-grid">
        <div class="span12">
         <div class="row show-grid">
          <div class="span4"><sc:Placeholder ID="footerleft" runat="server" Key="footer-left" /></div>
          <div class="span4 footer-center"><sc:Placeholder ID="footercenter" runat="server" Key="footer-center" /></div>
          <div class="span4 footer-right"><sc:Placeholder ID="footerright" runat="server" Key="footer-right" /></div>
         </div>
        </div>
       </div>
      </div>
     </div>
     <div class="footer-bottom">
      <div class="container">
       <div class="row show-grid">        
        <div class="span12"><p><sc:FieldRenderer ID="Copyright" runat="server" FieldName="Copyright" /></p>
        </div>
       </div>
      </div>
     </div>
    </footer>
   </div>  
    <div id="mtp-toggle">
     <i class="moon-droplet"></i>
    </div>
    <div id="mtp-wrapper">     
     <div id="mtp-content">
      <sc:Placeholder ID="visitdetails" runat="server" Key="visit-details" />
     </div>
    </div>
  </div>
  <!-- Placed at the end of the document so the pages load faster -->
  <script src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
  <script>window.jQuery || document.write("<script src='/assets/js/jquery-1.7.2.min.js'><\/script>")</script>
  <script type="text/javascript" src="/assets/js/bootstrap.min.js"></script>
  <script type="text/javascript" src="/assets/js/custom.js"></script>
 </form>
</body>
</html>
