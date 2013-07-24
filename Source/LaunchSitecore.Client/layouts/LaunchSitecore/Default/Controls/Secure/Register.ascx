<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Secure.Register" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Panel ID="LoginPanel" runat="server" defaultbutton="btnRegister">
 <div class="securityform">
  <h1><asp:Literal ID="litHeading" runat="server" /></h1>
  <p class="required"><asp:Literal ID="lblMessage" runat="server" EnableViewState="false" /></p>
  <p>
   <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" />  
   <asp:TextBox ID="txtName" runat="server" />
   <asp:RequiredFieldValidator ID="valName" runat="server" ControlToValidate="txtName" CssClass="required" ValidationGroup="Registration" Display="Dynamic" />
  </p>
  <p>
   <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" />
   <asp:TextBox ID="txtEmail" runat="server" />
   <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" CssClass="required" ValidationGroup="Registration" Display="Dynamic" />
   <asp:RegularExpressionValidator ID="valEmailFormat" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="required" ValidationGroup="Registration" Display="Dynamic" />
  </p>
  <p>
   <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" />
   <asp:TextBox ID="txtPassword" TextMode="password" runat="server" />
   <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" CssClass="required" ValidationGroup="Registration" Display="Dynamic" />
  </p>
  <p>
   <asp:Label ID="lblConfirm" runat="server" AssociatedControlID="txtPasswordConfirm" />
   <asp:TextBox ID="txtPasswordConfirm" TextMode="password" runat="server" />
   <asp:RequiredFieldValidator ID="valPasswordConfirm" runat="server" ControlToValidate="txtPasswordConfirm" CssClass="required" ValidationGroup="Registration" Display="Dynamic" />
  </p>
  <p><asp:Button ID="btnRegister" runat="server" ValidationGroup="Registration" onclick="btnGo_Click" /></p>
 </div>
</asp:Panel>
