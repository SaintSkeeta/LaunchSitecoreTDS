<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Error Details.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Controls.Single_Item.Error_Details" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h1><asp:Literal ID="ErrorHeading" runat="server"></asp:Literal></h1>

<h2><asp:Literal ID="ExceptionMessageHeading" runat="server"></asp:Literal></h2>
<p><asp:Literal ID="ExceptionMessage" runat="server"></asp:Literal></p>

<h2><asp:Literal ID="StackTraceHeading" runat="server"></asp:Literal></h2>
<p><asp:Literal ID="StackTrace" runat="server"></asp:Literal></p>

<asp:Panel ID="InnerExceptionPanel" runat="server" Visible="false">
<h2><asp:Literal ID="InnerExceptionHeading" runat="server"></asp:Literal></h2>

<h3><asp:Literal ID="InnerExceptionMessageHeading" runat="server"></asp:Literal></h3>
<p><asp:Literal ID="InnerExceptionMessage" runat="server"></asp:Literal></p>

<h3><asp:Literal ID="InnerStackTraceHeading" runat="server"></asp:Literal></h3>
<p><asp:Literal ID="InnerStackTrace" runat="server"></asp:Literal></p>
</asp:Panel>
