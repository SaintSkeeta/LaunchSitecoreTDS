# Launch Sitecore TDS #

[![Build status](https://ci.appveyor.com/api/projects/status/taxr71bl03mev0vc?svg=true)](https://ci.appveyor.com/project/SeanHolmesby/launchsitecoretds/branch/master)

- Use Tag v3.1.0.0 with Sitecore 8.1 Update 2 (rev. 160302) - Launch Sitecore - MVC Bootstrap3 version.
- Use Tag 3.0.0.0 with Sitecore 8.0 Update 5 (rev. 150812) - Launch Sitecore - MVC Bootstrap3 version.
- Use Tag 2.3.0.0 with Sitecore 8.0 Update 4 (rev. 150621) - Launch Sitecore - both WebForms and MVC versions.
- Use Tag 2.2.0.0 with Sitecore 7.5 Initial Release (rev. 141003) - Launch Sitecore - both WebForms and MVC versions.
- Use Tag 2.1.0.0 with Sitecore 7.2 Update 2 (rev. 140526) - Launch Sitecore - both WebForms and MVC versions
- Use Tag 2.0.1.0 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore - both WebForms and MVC versions
- Use Tag 2.0.0.1 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore New Themed version
- Use Tag 1.1 with Sitecore 7.0 Update 3 (rev. 131127) - Launch Sitecore Classic version
- Use Tag 1.0 with Sitecore 6.5 Service Pack 2 (rev. 121009) - Launch Sitecore Classic version


Launch Sitecore is a site found at [www.launchsitecore.net](www.launchsitecore.net). It is a fantastic, shared source site that shows the power of Sitecore through Page Editor and DMS. The site comes complete with content, components, engagement plans and much more. A Sitecore package for the complete site can be downloaded from the above link after registering.

This repository is that package converted to a Visual Studio solution with items in Team Development for Sitecore. It's intended to serve as a platform for helping developers understand TDS, Glass Mapper, NuGet, and Code Generation with TDS. It also allows developers to quickly setup a site with content, so that other additional features can be tested on a complete site.


## To get up and running ##
### Quick Guide ###
- Install a blank instance of Sitecore using SIM.
- Within the folder that the MVC sln file exists, setup your local TDS settings, either by changing the `TdsGlobal.config` file, or by duplicating it with the name `TdsGlobal.config.user`
- Restore all NuGet packages (note: TDS and Sitecore NuGet packages should exist in your private NuGet repo).
- Deploy the solution, so code and items are deployed to your local instance.

### Detailed Guide ###

#### Install a blank Sitecore Instance ####
- Install a blank instance of Sitecore using the Sitecore Instance Manager.
	- You can use whatever settings you like, however the Project Defaults for this repository are `Site Name: Launch` and `Host Name: launch.local`.
	 
- Ensure the version of Sitecore you install matches the version of the branch/tag you are using for this repository.

#### Set your TDS Deployment Settings ####
The default settings in the solution are to built to `D:\Sites\Launch\Website` and `http://launch.local`. You can choose something else for your site and easily configure the project by performing the following:-

- In the root directory of the solution, duplicate the `TdsGlobal.config` file, naming it `TdsGlobal.config.user`.
- Open the new file, and for your configuration (most likely Debug) uncomment the nodes `SitecoreWebUrl`, `SitecoreDeployFolder`.
 - For each of these nodes, add in your unique website information. e.g:- <br />
   `<SitecoreWebUrl>http://mysite.local</SitecoreWebUrl>`<br />
   `<SitecoreDeployFolder>D:\Sites\MySite\Website</SitecoreDeployFolder>`<br />
- Save the file. This will tell TDS to use these settings for all TDS projects.

#### Restore all NuGet packages ####
Sitecore NuGet Packages should be generated using the [Sitecore NuGet Package Generator](https://bitbucket.org/seanholmesby/sitecore-nuget-packages-generator) tool. Setup a custom NuGet Package Source, either by creating it as a local NuGet folder, or follow [these steps](http://blog.alen.pw/2014/10/internal-sitecore-nuget-server.html) to setup a private Proget NuGet repostory, where you can upload the generated Sitecore packages.
Note: The updated generator tool creates single DLL NuGet paackages for only Sitecore.*.DLLs, as well as package groupings for easy consumption.

Either explicitly restore all of the NuGet packages, or [make Visual Studio will restore them during your build](http://www.codeproject.com/Articles/680678/Keep-Nuget-Packages-Out-of-Source-Control-with-Nug).

Also the [HedgehogDevelopment.TDS NuGet package from your TDS install zip](http://hedgehogdevelopment.github.io/tds/chapter5.html#tds-builds-using-cloud-servers) should be added to your local repository as well. 

#### Build and Deploy ####
- Right click on the solution and select 'Deploy Solution'.

This will build and deploy the code, deploy the items, and run the post-deploy steps to save, link, and publish the items.

After this you will have a fully built, completely updated site.


## Differences with LaunchSitecore.net package ##
### Code differences ###
Some custom code has been added to flush the contact data to the xDB. We do this in the following file:-

 - AccountController.cs

### Item differences ###

 - master: /sitecore/templates/Launch Sitecore/Article Group
  - in package it inherits from GeneralFields, but also SiteSection, which inherits from GeneralFields... so they creates a duplicate dependency and breaks code generation.
 - master: /sitecore/system/Marketing Control Panel/Goals
  - some items were originally PageEvents. These have been changed to Goals to allow for analytics aggregration to proceed.
 



