# Launch Sitecore TDS #

- Use Tag 1.0 with Sitecore 6.5 Service Pack 2 (rev. 121009) - Launch Sitecore Classic version
- Use Tag 1.1 is from Sitecore 7.0 Update 3 (rev. 131127) - Launch Sitecore Classic version

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
- Copy the zz_developer.config file in {GitRootDirectory}/Installers over to In App_Config/Include. This config file will make your site run in live mode.

### Place Sitecore DLLs in the Installers folder ###
- Follow the steps in the {GitRootDirectory}/Installers/Sitecore/README.txt file, which tells you which Sitecore DLLs need to be referenced in code.

### Set your TDS Deployment Settings ###
- Open the solution in Visual Studio, right click on TDS.Core and select 'Properties'.
- On the Build tab, select 'Edit user specific configuration (.user file), and fill out Sitecore Web Url and Sitecore Deploy Folder with your settings.
- Save the settings.
- Follow the above steps for the TDS.Master project.

### Build and Deploy ###
- Build the entire solution.
- Right click on TDS.Core and select Deploy.
- Right click on TDS.Master and select Deploy.

Your site should now be completely setup.