# TDS Item Deployment Settings #

Within this solution we have some item deployment settings that may not match what would be typically used on a project. For example, we have the Home item's deployment setting as 'AlwaysUpdate', whereas it would normally be 'DeployOnce'.

The reason for this is because we want the entire solution to build and deploy as a full website with a first time build.

Obviously, if this were a proper client project, we would not want the Home item to be stomped on every deployment, so it would be set to 'DeployOnce'.

## The Items with Purposely Incorrect Deployment Settings ##

 - master:/sitecore/content/Home
 - master:/sitecore/system/Market Control Panel/Goals/Login
 - master:/sitecore/system/Market Control Panel/Goals/Register

