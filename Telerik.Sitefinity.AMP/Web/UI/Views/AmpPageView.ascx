<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:ResourceLinks ID="resourcesLinks" runat="server">
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.AngularJS.angular-1.2.16.min.js" Static="True" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.kendo.web.min.js" Static="True" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.kendo.angular.min.js" Static="True" />
    <sf:ResourceFile Name="Styles/Ajax.css" />
    <sf:ResourceFile Name="Styles/Grid.css" />
    <sf:ResourceFile Name="Styles/Window.css" />
</sf:ResourceLinks>
<sf:ResourceLinks ID="ResourceLinks1" runat="server" UseEmbeddedThemes="true" UseBackendTheme="True">
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="true" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_default_min.css" Static="true" />
</sf:ResourceLinks>

<link href="/Frontend-Assembly/Telerik.Sitefinity.Frontend/assets/dist/css/sitefinity-backend.min.css" rel="stylesheet" type="text/css">

<div class="sfMain sfClearfix" ng-app="AmpPageModule" ng-cloak>
    <div ng-controller="AmpPageController" class="sfContent">
        <div class="sfWorkArea">
			<div ng-show="loading" class="k-loading-mask">
                <div class="k-loading-text"><asp:Literal ID="Literal7" runat="server" Text="Loading"></asp:Literal></div>
                <div class="k-loading-color"></div>
            </div>

			<h1 class="sfBreadCrumb sfBreadCrumbWithBack">{{ampPage.Title}}
				<span class="sfBreadCrumbBack">
					<a href="{{ampGroupPageUrl}}">Back to all AMP pages</a>
				</span>
			</h1>

			<ul class="sfForm">
                <li>
					<div style="float: left;">
						<label for="ampPageTitle" class="sfTxtLbl">Title</label>
						<input id="ampPageTitle" type="text" ng-model="ampPage.Title" class="sfTxt" ng-change="updateUrlName(ampPage.Title)" />
					</div>
					<div style="float: left; padding-left: 50px;">
						<label class="sfTxtLbl">AMP Page URL</label>
						<label>/amp/{{ampPage.UrlName}}/[item URL]</label>
					</div>
					<div style="clear: both;"></div>
                </li>
				<li>
                    <label for="ampPageItemType" class="sfTxtLbl">Item Type</label>
					<select ng-model="ampPage.ItemType" ng-options="module for module in ampConfig.EnabledBuiltInModules">
					</select>
                </li>
				<li>
					<div style="float: left;">
						<label for="ampPageId" class="sfTxtLbl">PageId</label>
						<input id="ampPageId" type="text" ng-model="ampPage.Id" class="sfTxt" />
					</div>
					<div style="float: left; padding-left: 50px;">
						<label class="sfTxtLbl">Canonical URL in AMP page (original item URL)</label>
						<label>/page-url/[item URL]</label>
					</div>
					<div style="clear: both;"></div>
                </li>
            </ul>

			<ul class="sfForm">
				<li>
					<h3>Fields</h3>
					<div class="sfButtonArea">
						<input type="button" value="Select" class="sfLinkBtn sfSelect" ng-click="selectFields()" />
					</div>
				</li>
                <li>
					<div class="sf-backend-wrp" style="float: left; width: 50%;">
						<div class="list-group list-group-endless" kendo-sortable k-options="sortableOptions" k-on-change="sortFieldListItems(kendoEvent)" style="padding-right: 30px; margin-top: 20px;">
							<div class="list-group-item list-group-item-multiselect" ng-class="{active: selectedField==field}" ng-click="fieldItemClicked(field)" ng-repeat="field in ampPage.Fields">
								<span class="handler list-group-item-drag"></span>
								<div><span sf-max-length="60">{{field.FieldName}}</span></div>
							</div>
						</div>
					</div>
					<div style="float: right; width: 50%;" ng-show="selectedField">
						<ul style="padding-left: 30px; border-left: 1px solid #eee;">
							<li>
								<div style="float: left;">
									<label for="selectedFieldTagName" class="sfTxtLbl">Wrapper Tag</label>
									<input style="width: 200px;" id="selectedFieldTagName" type="text" ng-model="selectedField.WrapperTag.TagName" class="sfTxt" />
								</div>
								<div style="float: left; padding-left: 30px;">
									<label for="selectedFieldTagName" class="sfTxtLbl">Tag CssClass</label>
									<input style="width: 200px;" id="Text1" type="text" ng-model="selectedField.WrapperTag.CssClass" class="sfTxt" />
								</div>
								<div style="clear: both;"></div>
							</li>
							<li>
								<div style="float: left;">
									<label for="selectedFieldComponentType" class="sfTxtLbl">AMP Component Type</label>
									<select ng-model="selectedField.AmpComponent.ComponentType" ng-options="obj.value as obj.key for obj in componentTypes">
									</select>
								</div>
								<div style="float: left; padding-left: 30px;">
									<label for="selectedFieldTagName" class="sfTxtLbl">Component CssClass</label>
									<input style="width: 200px;" id="Text3" type="text" ng-model="selectedField.AmpComponent.CssClass" class="sfTxt" />
								</div>
								<div style="clear: both;"></div>
							</li>
						</ul>
					</div>
					<div style="clear: both;"></div>
                </li>
            </ul>

			<div class="sfButtonArea">
                <input type="button" value="Save" class="sfLinkBtn sfSave" ng-click="save()" />
            </div>
		</div>
	</div>
</div>

<script>
	angular.module("AmpPageModule").value("ampServiceUrl", "<%= hdfAmpServiceUrl.Value%>");
	angular.module("AmpPageModule").value("ampConfigServiceUrl", "<%= hdfAmpConfigServiceUrl.Value%>");
	angular.module("AmpPageModule").value("ampPageId", "<%= hdfAmpPageId.Value%>");
	angular.module("AmpPageModule").value("isCreateMode", "<%= hdfIsCreateMode.Value%>");
	angular.module("AmpPageModule").value("ampGroupPageUrl", "<%= hdfAmpGroupPageUrl.Value%>");
</script>

<asp:HiddenField runat="server" ID="hdfAmpServiceUrl" />
<asp:HiddenField runat="server" ID="hdfAmpConfigServiceUrl" />
<asp:HiddenField runat="server" ID="hdfAmpPageId" />
<asp:HiddenField runat="server" ID="hdfIsCreateMode" />
<asp:HiddenField runat="server" ID="hdfAmpGroupPageUrl" />

<script>
	$(document).ready(function () {
		$('body').addClass("sfNoSidebar");
	});
</script>