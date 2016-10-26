<%@ Control Language="C#" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="AMP" Assembly="Telerik.Sitefinity.AMP" Namespace="Telerik.Sitefinity.AMP.Web.UI.AmpPageses" %>
<%@ Import Namespace="Telerik.Sitefinity.AMP" %>

<h1 class="sfBreadCrumb">
    <asp:Literal ID="sampleModule2" runat="server" Text='AMP'></asp:Literal>
</h1>
<div class="sfMain sfClearfix">
    <div class="sfContent sfWorkArea">
        <h2><asp:Literal ID="message" runat="server" Text='<%$Resources:AMPResources, AmpPagesEmptyPageMessage %>'></asp:Literal></h2>
    </div>
</div>