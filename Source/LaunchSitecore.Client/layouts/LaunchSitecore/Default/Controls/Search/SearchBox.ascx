<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Search.SearchBox" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<script type="text/javascript">
 function doClear(inputField) {
  if (inputField.value == inputField.defaultValue) {
   inputField.value = "";
   inputField.style.color = "black";
  }
 }
</script>
<asp:Panel ID="SearchPanel" runat="server" DefaultButton="btnSearch" CssClass="searchwrapper">
 <asp:TextBox onfocus="doClear(this)" runat="server" ID="txtCriteria" OnTextChanged="txtCriteria_TextChanged" />
 <asp:Button runat="server" ID="btnSearch" CssClass="invisible" OnClick="btnSearch_Click" /> 
</asp:Panel>
