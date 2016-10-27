# AMP-lify
Google AMP support for Sitefinity CMS.

## Install AMP-lify Add-On##
1. Install AMP-lify NuGet package in your WebApp project
2. Change WebApp .Net version to 4.5.1
3. Add AMP module in SystemConfig.config
Add the following into the "applicationModules" section of the SystemConfig.config file:
```xml
<add title="AMP" type="Telerik.Sitefinity.AMP.AMPModule, Telerik.Sitefinity.AMP" startupType="OnApplicationStart" name="AMP" />
```
