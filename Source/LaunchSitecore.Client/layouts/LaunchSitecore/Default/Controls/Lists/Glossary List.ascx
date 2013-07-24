<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Glossary List.ascx.cs"
 Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Lists.Glossary_List" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<asp:Repeater ID="rptTerms" runat="server" OnItemDataBound="rptTerms_ItemDataBound">
 <HeaderTemplate><dl></HeaderTemplate>
 <ItemTemplate>
  <dd>   
   <asp:HyperLink ID="TermLink" runat="server">
    <sc:FieldRenderer id="Icon" runat="server" fieldname="Icon" Parameters="h=24&w=24&as=1" />
    <sc:FieldRenderer id="Term" runat="server" fieldname="Title" />
   </asp:HyperLink>
  </dd>
  <dt><sc:FieldRenderer id="Definition" runat="server" fieldname="Definition" /></dt>
  </li>
 </ItemTemplate>
 <FooterTemplate></dl></FooterTemplate>
</asp:Repeater>
