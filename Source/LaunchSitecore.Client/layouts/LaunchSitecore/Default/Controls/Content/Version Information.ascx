<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Version Information.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Version_Information" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<span class="version-text"><sc:FieldRenderer ID="LS_VersionRO" runat="server" FieldName="Launch Sitecore Version" /></span>
<asp:Panel id="InNormalMode" runat="server">
	<a class='version' href="#version_content"><sc:FieldRenderer ID="LS_Version" runat="server" FieldName="Launch Sitecore Version" /></a>	
 <!-- modal content -->
 <div style='display:none'>
  <div id="version_content">
   <h2><sc:FieldRenderer ID="Title" runat="server" FieldName="Version Title" /></h2>	 
		  <div class="versioncontent">				 
				 <sc:Image ID="Image" runat="server" Field="Sitecore Version Image" MaxWidth="170" />
				 <p><em><sc:FieldRenderer ID="Version" runat="server" FieldName="Launch Sitecore Version" /></em></p>
				 <sc:FieldRenderer ID="Body" runat="server" FieldName="Version Details" />			 		 
	  </div>
  </div>
 </div>
</asp:Panel>
