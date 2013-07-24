<%@ Page language="c#" Codepage="65001" AutoEventWireup="true" Inherits="LaunchSitecore.layouts.MyFirstSite.Default" CodeBehind="Main.aspx.cs" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ OutputCache Location="None" VaryByParam="none" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en" xml:lang="en" xmlns="http://www.w3.org/1999/xhtml">                  
  <head>
    <title>My First Site</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="/default.css" rel="stylesheet" />
    <link href="/_css/myfirstsite.css" rel="stylesheet" />
    <sc:VisitorIdentification runat="server" />
  </head>
  <body>
  <form method="post" runat="server" id="mainform">
  <div id="container">
<div id="header">
<h3 id="logo">
     <a href="/">Home</a>
    </h3>
</div>
<div id="hr" />
<div id="sidebar">
 <!-- Statically bound side menu -->
 <sc:Sublayout runat="server" path="/layouts/MyFirstSite/Default/Controls/Side Menu.ascx" />
</div>
<div id="main">
 <!-- Placeholder to support dynamically binding the main part of the page. -->
 <sc:Placeholder ID="MainPlaceholder" runat="server" key="myfirstsite-content" />
</div>
<div id="footer">
<p>Copyright &copy; 2012 - My First Site</p>
</div>
</div>
  </form>
  </body>
</html>
