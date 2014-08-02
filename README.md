# Launch Sitecore TDS #

- Use Tag 1.0 with Sitecore 6.5 Service Pack 2 (rev. 121009) - Launch Sitecore Classic version
- Use Tag 1.1 with Sitecore 7.0 Update 3 (rev. 131127) - Launch Sitecore Classic version
- Use Tag 2.0.0.1 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore New Themed version
- Use Tag 2.0.1.0 with Sitecore 7.1 Update 1 (rev. 140130) - Launch Sitecore - both WebForms and MVC versions
- Use Tag 2.1.0.0 with Sitecore 7.2 Update 2 (rev. 140526) - Launch Sitecore - both WebForms and MVC versions

Launch Sitecore is a site found at [www.launchsitecore.net](www.launchsitecore.net). It is a great, shared source site that shows the power of Sitecore through Page Editor and DMS. The site comes complete with content, components, engagement plans and much more. A Sitecore package for the complete site can be downloaded from the above link after registering.

This repository is that package converted to a Visual Studio solution with items in Team Development for Sitecore. It's intended to serve as a platform for helping developers understand TDS, Glass Mapper, and Code Generation with TDS. It also allows developers to quickly setup a site with content, so that other additional features can be tested on a complete site.


## To get up and running ##
### Install a blank Sitecore Version ###
- Install a blank instance of Sitecore using the Sitecore Instance Manager.
- Ensure that you install Analytics from the second step. You must have the DMS version available to you.
- Click Open folder when installation is complete.

### Update your local settings ###
- Navigate to the App_Config/Include folder.
- Change the name of DataFolder.config.example to DataFolder.config.
- Open the file, and change the value to that used by your site. Save and Exit.
- Copy the `zz_developer.config` file in {GitRootDirectory}/Installers over to In App_Config/Include. This config file will make your site run in live mode.

### Place Sitecore DLLs in the Installers folder ###
- Follow the steps in the {GitRootDirectory}/Installers/Sitecore/README.txt file, which tells you which Sitecore DLLs need to be referenced in code.

### Open the solution you wish to use ###
Open `LaunchSitecore.sln` for the WebForms version of the site.<br />
Open `LaunchSitecoreMvc.sln` for the MVC version of the site.

The two solutions share some projects, but can be built and deployed irrespective of each other.
*Note:* You should only use one solution per Sitecore Instance. You cannot deploy both solutions to the same Sitecore instance.

### Set your TDS Deployment Settings ###
- Open the solution in Visual Studio, Open the .tds/TdsGlobal.config file.
- For your configuration (most likely Debug) uncomment the nodes `SitecoreWebUrl`, `SitecoreDeployFolder`, `InstallSitecoreConnector`, `SitecoreAccessGuid`.
 - For each of these nodes, add in your unique website information. e.g:- <br />
   `<SitecoreWebUrl>http://launch.local</SitecoreWebUrl>`<br />
   `<SitecoreDeployFolder>D:\Sites\Launch\Website</SitecoreDeployFolder>`<br />
   `<InstallSitecoreConnector>True</InstallSitecoreConnector>`<br />
   `<SitecoreAccessGuid>900c37ae-5fe5-48c2-bccd-2eab2dafea31</SitecoreAccessGuid>`
- Save the file. This will tell TDS to use these settings for all TDS projects.

### Build and Deploy ###
- Right click on the solution and select 'Deploy Solution'.

### Rebuild Search Indexes ###
When using a Sitecore 7 version, you will need to rebuild the indexes for the site to work correctly. (Noticeable with the carousel on the homepage in the new themed version).<br />
To rebuild the indexes:-

 - Open the Sitecore Client, and login to *Desktop* mode.
 - From the Sitecore Start menu, Open the *Control Panel*.
 - Click on *Indexing*.
 - Click on *Indexing Manager*
 - Follow the Wizard, selecting all of the local instances and clicking on the *Rebuild* button.

### Optional: Deploy the Example Campaign ###
In order to push your campaigns to the Analytics database and be active on the site, you will need to re-deploy them.

 - In the Sitecore Content Editor, turn on Standard Fields (`View -> View -> Standard Fields`)
 - Navigate to the Example Campaign (`/sitecore/system/Marketing Center/Campaigns/Example Campaign`).
 - Change the Workflow State to Draft. (`Worflow section -> Field: State` set to `Analytics Workflow -> Draft`). Save the item.
 - Deploy the campaign. (`Review` ribbon -> `Workflow` chunk, `Deploy`)
 

### Optional: Rebuild the Link Database ###
For better navigation around the site, it is recommended that you rebuild the link database after the deployment.

 - Open the Sitecore Client, and login to *Desktop* mode.
 - From the Sitecore Start menu, Open the *Control Panel*.
 - Click on *Database*.
 - Click on *Rebuild the Link Database*
 - Follow the Wizard, selecting *core* and *master* databases and clicking on the *Rebuild* button.

Your site should now be completely setup.