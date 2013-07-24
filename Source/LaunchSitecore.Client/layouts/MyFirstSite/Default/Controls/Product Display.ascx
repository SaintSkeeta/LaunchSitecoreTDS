<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product Display.ascx.cs" Inherits="LaunchSitecore.layouts.MyFirstSite.Controls.Product_Display" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h1><sc:FieldRenderer ID="TitleFieldRenderer" runat="server" FieldName="Title" /></h1>
<sc:FieldRenderer ID="DescFieldRenderer" runat="server" FieldName="Description" />
<p>Price: <sc:FieldRenderer ID="PriceFieldRenderer" runat="server" FieldName="Price" /></p>