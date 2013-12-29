Readme

Tag 1.0 is from Sitecore 6.5 Update XXX
Tag 2.0 is from Sitecore 7.0 Update 3 (rev. 131127)

To get up and running:-
Install a blank instance of Sitecore using the Sitecore Instance Manager.
Ensure that you install Analytics from the second step. You must have the DMS version available to you.
Click Open folder when installation is complete.

Navigate to the App_Config/Include folder.
Change the name of DataFolder.config.example to DataFolder.config.
Open the file, and change the value to that used by your site. Save and Exit.

Copy the zz_developer.config file in {GitRootDirectory}/Installers over to In App_Config/Include. This config file will make your site run in live mode.

Open the solution in Visual Studio, right click on TDS.Core and select 'Properties'.
On the Build tab, select 'Edit user specific configuration (.user file), and fill out Sitecore Web Url and Sitecore Deploy Folder with your settings.
Save the settings.

Follow the above steps for the TDS.Master project.

Build the entire solution.

Right click on TDS.Core and select Deploy.
Right click on TDS.Master and select Deploy.

Your site should now be completely setup.