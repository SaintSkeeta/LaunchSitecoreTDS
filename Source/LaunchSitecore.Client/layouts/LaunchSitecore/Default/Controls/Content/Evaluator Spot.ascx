<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Evaluator_Spot.ascx.cs" Inherits="LaunchSitecore.layouts.LaunchSitecore.Default.Controls.Content.Evaluator_Spot" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Image DataSource='<%#((Sitecore.Web.UI.WebControls.Sublayout)this.Parent).DataSource %>' Field="Media" />
