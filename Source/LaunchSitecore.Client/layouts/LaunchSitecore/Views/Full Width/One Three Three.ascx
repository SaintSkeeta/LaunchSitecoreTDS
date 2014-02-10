<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="One Three Three.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Views.Full_Width.One_Three_Three" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="row main-block topmargin">
 <div class="span12">
  <sc:Placeholder ID="fullrow1" runat="server" Key="full-row1" />
 </div>
</div>

<div class="row main-block">
 <div class="span12"> 
  <div class="row show-grid hero-list features-list">
   <div class="span4">
    <sc:Placeholder ID="fullrow2a" runat="server" Key="full-row2a" />
   </div>
   <div class="span4">
    <sc:Placeholder ID="fullrow2b" runat="server" Key="full-row2b" />
   </div>
   <div class="span4">
    <sc:Placeholder ID="fullrow2c" runat="server" Key="full-row2c" />
   </div>   
  </div>
 </div>
</div>

<div class="row show-grid features-block mini-blocks">
 <div class="span4 block1">
  <div class="mini-wrapper"><sc:placeholder id="fullrow3a" runat="server" key="full-row3a" /></div>
 </div>
 <div class="span4 block2">
  <div class="mini-wrapper"><sc:placeholder id="fullrow3b" runat="server" key="full-row3b" /></div>
 </div>
 <div class="span4 block3">
  <div class="mini-wrapper"><sc:placeholder id="fullrow3c" runat="server" key="full-row3c" /></div>
 </div>
</div>
