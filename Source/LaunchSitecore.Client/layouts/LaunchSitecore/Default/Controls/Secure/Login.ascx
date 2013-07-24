<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure.Login" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="LoginPanel" runat="server" defaultbutton="btnLogin">
 <div class="securityform">	
	 <h1><asp:Literal ID="litHeading" runat="server" /></h1>
	 <p class="required"><asp:Literal ID="lblMessage" runat="server" EnableViewState="false" /></p>
	 <p>
		 <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" />
		 <asp:TextBox ID="txtUsername" runat="server" />
		 <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtUsername" CssClass="required" ValidationGroup="LoginGroup" />
	 </p>
	 <p>
		 <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" />
		 <asp:TextBox ID="txtPassword" runat="server" TextMode="password" />
		 <asp:RequiredFieldValidator ID="valPass" runat="server" ControlToValidate="txtPassword" CssClass="required" ValidationGroup="LoginGroup" />
	 </p>
	 <p><asp:CheckBox ID="chkPersist" runat="server" /></p>	
	 <p><asp:Button ID="btnLogin" runat="server" onclick="btnGo_Click" ValidationGroup="LoginGroup" UseSubmitBehavior="true" /></p>	
 </div>
</asp:Panel>