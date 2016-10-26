<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:ResourceLinks ID="resourcesLinks" runat="server">
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.AngularJS.angular-1.2.16.min.js" Static="True" />
    <sf:ResourceFile Name="Styles/Ajax.css" />
    <sf:ResourceFile Name="Styles/Grid.css" />
</sf:ResourceLinks>

<h1 class="sfBreadCrumb">
    <asp:Literal ID="Literal1" runat="server" Text="Amp Pages"></asp:Literal>
</h1>

<div class="sfMain sfClearfix" ng-app="AmpModule" ng-cloak>
    <div ng-controller="AmpController" class="sfContent">
        <div class="sfWorkArea">
            <div ng-show="loading" class="k-loading-mask">
                <div class="k-loading-text"><asp:Literal ID="Literal7" runat="server" Text="Loading"></asp:Literal></div>
                <div class="k-loading-color"></div>
            </div>

            <div ng-show="!loading && ampPages.length == 0" class="sfEmptyList">
                <div class="sfMessage sfMsgNeutral sfMsgVisible">
                    <asp:Literal ID="Literal8" runat="server" Text="You have no amp pages yet."></asp:Literal>
                </div>                

                <ol class="sfWhatsNext">
	                <li class="sfCreateItem sfDisabled">
		                <span class="sfDecisionIcon"></span>
	                </li>
                    <li class="sfCreateSubsequentItem">
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Text="Create an amp page" NavigateUrl="/Sitefinity/Administration/AMP-AmpPages/Details"></asp:HyperLink>
                    </li>
                </ol>
            </div>

            <div class="k-grid k-widget rgTopOffset" ng-if="ampPages && ampPages.length">
                <table>
                    <thead class="k-grid-header">
                        <tr>
                            <th scope="col" class="k-header sfTitleCol">
                                <asp:Literal ID="Literal2" runat="server" Text='Title'></asp:Literal>
                            </th>
                            <th scope="col" class="k-header sfLarge">                        
                                <asp:Literal ID="Literal3" runat="server" Text='Module'></asp:Literal>
                            </th>
                        </tr>
                    </thead>

                    <script type="text/ng-template" id="ampPagesTree">
                              
                        <td class="sfLarge"><a href="#">{{ampPage.Title}}</a></td>            
                        <td class="sfShort">{{ampPage.Module}}</td>            
            
                                
                    </script>
                    <tbody>
                        <tr ng-repeat="ampPage in ampPages" ng-include="'ampPagesTree'"></tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<script>
		angular.module("AmpModule").value("ampServiceUrl", "<%= hdfAmpServiceUrl.Value%>");
</script>

<asp:HiddenField runat="server" ID="hdfAmpServiceUrl" />

<script>
		$(document).ready(function () {
				$('body').addClass("sfNoSidebar");
		});
</script>