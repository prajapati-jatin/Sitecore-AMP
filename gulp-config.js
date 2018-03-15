// JavaScript source code
module.exports = function () {
    var instanceRoot = "C:\\inetpub\\wwwroot\\amp.sc.local";
    var config = {
        websiteRoot: instanceRoot + "\\website",
        sitecoreLibraries: instanceRoot,
        licensePath: instanceRoot + "\\Data\\license.xml",
        solutionName: "Sitecore AMP",
        buildConfiguration: "Debug",
        buildToolsVersion: 15.0,
        buildMaxCpuCount: 0,
        buildVerbosity: "minimal",
        buildPlatform: "Any CPU",
        publishPlatform: "AnyCpu",
        runCleanBuilds: false
    };
    return config;
}
