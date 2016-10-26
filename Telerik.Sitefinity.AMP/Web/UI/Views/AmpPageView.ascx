<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:ResourceLinks ID="resourcesLinks" runat="server">
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.AngularJS.angular-1.2.16.min.js" Static="True" />
    <sf:ResourceFile Name="Styles/Ajax.css" />
    <sf:ResourceFile Name="Styles/Grid.css" />
</sf:ResourceLinks>

<h1 class="sfBreadCrumb">
    <asp:Literal ID="Literal1" runat="server" Text="Details"></asp:Literal>
</h1>
<div>Create/Details page</div>