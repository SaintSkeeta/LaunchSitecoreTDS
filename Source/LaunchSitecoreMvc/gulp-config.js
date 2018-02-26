module.exports = function () {
  var instanceRoot = "D:\\Sites\\Launch.QA";
  var config = {
    websiteRoot: instanceRoot + "\\Website",
    FeydraUser: "FED_King",
    solutionName: "Fedyra",
    buildConfiguration: "Debug",
    runCleanBuilds: false,
    azureHost: 'waws-prod-blu-055.ftp.azurewebsites.windows.net',
    azureUser: 'launchsitecore901-single\\$launchsitecore901-single',
    azurePass: 'n36azNCzGmDcY0tqf08tqzzcePj1Tl74id6w2JdYCuibuQfX4uB10Qjd51p6',
  };
  return config;
}