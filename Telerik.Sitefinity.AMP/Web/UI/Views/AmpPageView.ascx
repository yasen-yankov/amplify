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
					<div ng-show="ampPage.Title" style="float: left; padding-left: 50px;">
						<label class="sfTxtLbl">AMP Page URL</label>
						<label>/amp/{{ampPage.UrlName}}/[item URL]</label>
					</div>
					<div style="clear: both;"></div>
                </li>
				<li>
                    <label for="ampPageItemType" class="sfTxtLbl">Item Type</label>
					<select style="width: 412px;" ng-model="ampPage.ItemType" ng-options="module for module in ampConfig.EnabledBuiltInModules">
					</select>
                </li>
                <li>
                    <div style="float: left;">
						<label for="ampPageUrl" class="sfTxtLbl">Original Item Page Url</label>
						<input id="ampPageUrl" type="text" ng-model="ampPage.PageUrl" class="sfTxt" />
					</div>
                    <div style="float: left; padding-left: 50px;">
						<label class="sfTxtLbl">Canonical URL in AMP page (original item URL)</label>
						<label>{{ampPage.PageUrl}}/[item URL]</label>
					</div>
                    <div style="clear: both;"></div>
                </li>
            </ul>

			<ul class="sfForm" ng-show="ampPage.ItemType">
				<li>
					<h3>AMP Page Builder</h3>
					<h4>Select Fields</h4>
					<div class="sfButtonArea">
						<input type="button" value="Select" class="sfLinkBtn sfSelect" ng-click="selectFields()" />
					</div>
				</li>
                <li>
					<div class="sf-backend-wrp" style="float: left; width: 50%;">
						<div class="list-group list-group-endless" kendo-sortable k-options="sortableOptions" k-on-change="sortFieldListItems(kendoEvent)" style="padding-right: 30px; margin-top: 20px; border-right: 1px solid #eee;">
							<div class="list-group-item list-group-item-multiselect" ng-class="{active: selectedField==field}" ng-click="fieldItemClicked(field)" ng-repeat="field in ampPage.Fields">
								<span class="handler list-group-item-drag"></span>
								<div><span sf-max-length="60">{{field.FieldName}}</span></div>
							</div>
						</div>
					</div>
					<div style="float: right; width: 50%;" ng-show="!selectedField && ampPage.Fields">
						<ul style="padding-left: 30px; margin-top: 20px;">
							<li>
								<label class="sfTxtLbl">Click an a field to edit its properties</label>
							</li>
						</ul>
					</div>
					<div style="float: right; width: 50%;" ng-show="selectedField">
						<ul style="padding-left: 30px;">
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
									<select style="width: 212px;" ng-model="selectedField.AmpComponent.ComponentType" ng-options="obj.value as obj.key for obj in componentTypes">
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
                <li>
                    <input id="cbUseCustomLayout" type="checkbox" ng-model="useCustomLayout" />
                    <label for="cbUseCustomLayout">Use custom layout</label>
                </li>
                <li ng-show="useCustomLayout">
					<label for="ampPageLayoutTemplatePath" class="sfTxtLbl">LayoutTemplatePath</label>
					<input id="ampPageLayoutTemplatePath" type="text" ng-model="ampPage.LayoutTemplatePath" class="sfTxt" />
                </li>
                <li ng-show="useCustomLayout">
					<label for="ampPageTemplatePath" class="sfTxtLbl">TemplatePath</label>
					<input id="ampPageTemplatePath" type="text" ng-model="ampPage.TemplatePath" class="sfTxt" />
                </li>
            </ul>

			<div class="sfButtonArea">
                <input ng-hide="isCreateMode" type="button" value="Save" class="sfLinkBtn sfSave" ng-click="save()" />
				<input ng-show="isCreateMode" type="button" value="Create" class="sfLinkBtn sfSave" ng-click="create()" />
            </div>
		</div>

		<div kendo-window="selectFieldsDialog" k-modal="true" k-title="'Select fields'" k-width="425" k-animation="false"
			k-resizable="false" k-actions="[]" k-visible="false" k-on-open="includeContent = false">
			<div class="sfSelectorDialog">
				<h1>Select fields</h1>
				<div class="sfBasicDim">
					<div class="sfContentViews">
						<p>
							Select fields to be included in the AMP page builder.
						</p>
						<div class="sf-backend-wrp">
							<div class="list-group list-group-endless" kendo-sortable k-options="sortableOptions" k-on-change="sortFieldListItems(kendoEvent)" style="padding-right: 30px; margin-top: 20px; border-right: 1px solid #eee;">
								<div class="list-group-item list-group-item-multiselect"
									ng-click="fieldItemSelectionClicked(field.Name)"
									ng-class="{active: selectedField==field}"
									ng-repeat="field in itemTypeFields">
									<input type="checkbox" ng-checked="isFieldItemSelected(field.Name)">
									<div><span sf-max-length="60">{{field.Name}}</span></div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="sfButtonArea">
					<a class="sfLinkBtn sfSave" ng-click="confirmFieldSelection()"><span class="sfLinkBtnIn">
						<asp:Literal ID="Literal4" runat="server" Text='<%$Resources:Labels, Save%>'></asp:Literal></span></a>
					<a class="sfCancel activate-cancel" ng-click="cancelFieldSelection()">
						<asp:Literal ID="Literal5" runat="server" Text="<%$Resources:Labels, Cancel %>"></asp:Literal>
					</a>
				</div>
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
	angular.module("AmpPageModule").value("staticModuleMetaDataServiceUrl", "<%= hdfStaticModuleMetaDataServiceUrl.Value%>");
</script>

<asp:HiddenField runat="server" ID="hdfAmpServiceUrl" />
<asp:HiddenField runat="server" ID="hdfAmpConfigServiceUrl" />
<asp:HiddenField runat="server" ID="hdfStaticModuleMetaDataServiceUrl" />
<asp:HiddenField runat="server" ID="hdfAmpPageId" />
<asp:HiddenField runat="server" ID="hdfIsCreateMode" />
<asp:HiddenField runat="server" ID="hdfAmpGroupPageUrl" />

<script>
	$(document).ready(function () {
		$('body').addClass("sfNoSidebar");
	});
</script>