# Launch Sitecore TDS - ZeroDeploy #

For use with:

| Name | Version |
|-------|----|
| Sitecore | 8.2 Update 2 (rev. 161221) |
| TDS Classic | 5.6.0.15 - copy NuGet packages in a local NGget repo |
| ZeroDeploy | 1.0.0.18 - copy NuGet packages in a local NGget repo |

Zero Deploy is a productivity tool from Hedgehog that allows the developer to make back end code changes, and immediately see their work on a Sitecore website, WITHOUT needing to wait for an App Pool recycle.

Sign up for the Beta Trial here:
[https://www.teamdevelopmentforsitecore.com/Zero-Deploy-Beta]([https://www.teamdevelopmentforsitecore.com/Zero-Deploy-Beta)

## To get up and running ##
### Setup Guide ###
- Install the `Hedgehog.ZeroDeploy.VSAddin.vsix` into your Visual Studio (VS 2015 and 2017 are supported).
- Install a blank instance of Sitecore using SIM.
- Within the folder that the MVC sln file exists, setup your local TDS settings for both `Debug` and `ZeroDeploy` configurations, either by changing the `TdsGlobal.config` file, or by duplicating it with the name `TdsGlobal.config.user`
- Within the folder that the MVC sln file exists, setup your local ZeroDeploy settings, either by changing the `ZeroDeploy.props` file, or by duplicating it with the name `ZeroDeploy.props.user`. If you duplicate it and do the `.user` file option, open that up, and remove the line `<Import Project=".\ZeroDeploy.props.user" Condition="Exists('.\ZeroDeploy.props.user')" />` from the `ZeroDeploy.props.user` file.
- Restore all NuGet packages (note: the TDS and ZeroDeploy packages should be copied from their downloaded zips to your private NuGet repo).
- Deploy the solution to your site in the 'Debug' configuration, so code and items are deployed to your local instance. Publish the site to the web database as well, or run the site in Live Mode.
- Install the ZeroDeploy `.update` package into your Sitecore site. This comes with the download of ZeroDeploy.
- In Visual Studio, switch to the `ZeroDeploy` solution configuration. Run a Rebuild on the solution.
- Reload Sitecore. You are now running ZeroDeploy!
- Test it out!
- Note: You still need to copy any content files that are changed (like cshtml files) to your website. For this, you can use TDS Classic's [Content File Sync](https://hedgehogdevelopment.github.io/tds/chapter4.html#general-options) feature, [CopySauce](http://www.seanholmesby.com/copysauce-a-file-copying-utility-for-sitecore-development/) or your own [Gulp Scripts](https://github.com/SaintSkeeta/LaunchSitecoreTDS/blob/feature-feydra/Source/LaunchSitecoreMvc/gulpfile.js).


 ### Advanced ZeroDepoy ###
 If you want to go deeper with ZeroDeploy, open up both the `GettingStarted.pdf` and `AdvancedZeroDeploy.pdf` files within the downloaded zip for more information about the intricacies of how ZeroDeploy works.



