module.exports = function () {

    var deploymentPath = "./wwwroot/";
    var devPath = "./application";
    var appJsDev = devPath + "**/*.js";
    var bowerJson = require("./bower.json");
    var layout = "./Views/Shared/";
    var layoutInjector = "./Views/Shared/_Layout.cshtml";

    var config = {
        appJavaScriptFiles:
        [
            //Gulp Files
            "./gulp.config.js", "./gulpfile.js",
            //Angular Files
            appJsDev
        ],

        tsTypingDefinitions: "./typings/**/*.d.ts",

        appTypeScriptFiles: [
            devPath + "**/*.ts"
        ],

        bowerFiles: "lib/**",
        wwwrootBower: deploymentPath + "lib",

        appTsDev: devPath + "/**/*.ts",
        appHtmlFiles: "application/**/*.html",
        appJsDev: appJsDev,
        appJsDepolyment: deploymentPath + "**/*.js",

        appDeployFolder: deploymentPath,
        appDevFolder: devPath,
        wwwrootApplication: deploymentPath + "application",

        bower: {
            json: bowerJson,
            directory: "lib/",
            ignorePath: "../.."

        },


        js: [
            devPath + "**/*.model.js",
            devPath + "**/*.module.js",
            devPath + "**/*.core.js",
            devPath + "**/app.js",
            devPath + "**/app.run.js",
            devPath + "**/*.config.js",
            devPath + "**/*.services.js",
            devPath + "**/*.routes.js",
            devPath + "**/*.directive.js",
            devPath + "**/*.widget.js",
            devPath + "**/*.filter.js",
            devPath + "**/*.controller.js",
            devPath + "**/*.js"
        ],

        layoutPage: layout,
        layoutInjector: layoutInjector

    };

    config.getWiredepDefaultOptions = function () {


        var options = {
            bowerJson: config.bower.json,
            directory: config.bower.directory,
            ignorePath: config.bower.ignorePath,
              fileTypes: {
                html: {
                replace: {
                    js: '<script src="~{{filePath}}"></script>', // jshint ignore:line
                    css: '<link rel="stylesheet" href="~{{filePath}}" />' // jshint ignore:line
                    }
                }
            }


        };

        return options;
    };

    return config;
};
