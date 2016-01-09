/// <binding Clean='clean' />
"use strict";

let gulp = require("gulp");
let config = require("./gulp.config")();
let $ = require("gulp-load-plugins")({ lazy: true });
let del = require("del");
let wiredepModule = require("wiredep");
let rimraf = require("rimraf");
let Server = require("karma").Server;
let wiredep = require("wiredep").stream;


let typescriptOptions = {

    removeComments: true,
    target: "ES5",
    noImplicitAny: true

};

gulp.task("help", $.taskListing);
gulp.task("default", ["help"]);

gulp.task("jshint", function () {
    log("** JSHint Check **");
    return gulp
        .src(config.appJavaScriptFiles)
        .pipe($.jshint())
        .pipe($.jshint.reporter("jshint-stylish", { verbose: true }))
        .pipe($.jshint.reporter("fail"));
});

gulp.task("tslint", function () {
    log("** TSLint Check **");

    return gulp
        .src(config.appTsDev)
        .pipe($.tslint())
        .pipe($.tslint.report("verbose"));

});

gulp.task("wiredep-app", ["populate-webroot-lib"], function () {
    log("*** Wiring up bower css, js and application into html page");

    let options = config.getWiredepDefaultOptions();

    return gulp
        .src(config.layoutInjector)
        .pipe(wiredep(options))
        .pipe($.inject(gulp.src(config.js,
            { read: false }), {
                transform: function (filepath) {
                    // ReSharper disable once StringLiteralWrongQuotes
                    return '<script src="~' + filepath + '"></script>'; // jshint ignore:line
                }
            }
            ))
        .pipe(gulp.dest(config.layoutPage));

});

gulp.task("wiredep-test-files", function () {
    log("*** Wiring up angular.references.spec.js file ***");

    let options = config.getWiredepTestOptions();

    return gulp
        .src(config.testScriptInjector)
        .pipe(wiredep(options))
        .pipe($.inject(gulp.src(config.testJs,
            { read: false }),
            {
                transform: function (filepath) {
                    // ReSharper disable once StringLiteralWrongQuotes
                    return '///<reference path="../../src/SP.WEB' + filepath + '" />'; //jshint ignore: line
                }
            }))
        .pipe(gulp.dest(config.testScriptInjectorDestination));

});

gulp.task("delete-webroot-lib", function (cb) {

    log("*** Deleting Current webroot/lib folder ****");
    rimraf("./wwwroot/lib", cb);

});

gulp.task("populate-webroot-lib", ["delete-webroot-lib"], function () {

    log("*** Moving Bower Files to WWWROOT ****");

    gulp.src([config.bowerFiles], { base: "lib" })
        .pipe(gulp.dest(config.wwwrootBower));
});



gulp.task("transpile", ["transpile-in-dev"], function () {

    cleanApplicationInWwwRoot();

    log("** Transpiling to WWWROOT Folder **");

    return gulp
        .src([config.appTsDev, config.tsTypingDefinitions])
        .pipe($.sourcemaps.init())
        .pipe($.typescript(typescriptOptions))
        .pipe($.sourcemaps.write())
        .pipe(gulp.dest(config.wwwrootApplication));
});

gulp.task("transpile-in-dev", function () {

    log("** Transpiling Dev Folder **");

    return gulp
        .src([config.appTsDev, config.tsTypingDefinitions])
        .pipe($.sourcemaps.init())
        .pipe($.typescript(typescriptOptions))
        .pipe($.sourcemaps.write())
        .pipe(gulp.dest(config.appDevFolder));
});


gulp.task("tsc-watch", function () {
    log("*** Watching TypeScript files for changes **");

    gulp.watch([config.appTsDev], ["transpile"])
        .on("change", function (event) {
            changedEvent(event);
        });

});

gulp.task("run-jtests", ["wiredep-test-files"], function (done) {
    new Server({
        configFile: config.karmaConfiguration,
        singleRun: true
    }, done).start();
});


gulp.task("run-csharp-tests",["run-jtests"], function () {

    let exec = require('child_process').execSync;
    let process = require('process');

    console.log("Starting directory" + process.cwd());
    //SP.WEB.Tests
    process.chdir("../../tests/SP.WEB.Tests");
    exec("dnu restore", { stdio: "inherit" });
    exec("dnx run-csharp-web-tests -parallel none", { stdio: "inherit" });
    //SP.BLL.Tests
    process.chdir("../SP.BLL.Tests");
    exec("dnu restore", { stdio: "inherit" });
    exec("dnx run-csharp-bll-tests -parallel none", { stdio: "inherit" });
    //SP.Utilities.Tests
    process.chdir("../SP.Utilities.Tests");
    exec("dnu restore", { stdio: "inherit" });
    exec("dnx run-csharp-utilities-tests -parallel none", { stdio: "inherit" });

});

gulp.task("run-tests", ["run-csharp-tests"], function () {
    log("*** Finished running JavaScript and C# Tests ***");
});

//TODO: Minify HTML whitespace
gulp.task("move-html", ["transpile"], function () {

    log("*** Moving HTML Files to Deployment wwww folder ****");

    return gulp.src([config.appHtmlFiles], { base: "application" })
        .pipe($.debug({ title: "DEPLOYED" }))
        .pipe(gulp.dest(config.wwwrootApplication));

});

gulp.task("deploy", ["wiredep-app", "move-html"], function () {
    log("*** Deploying bower files, HTML files, and Transpiling *** ");


});





function log(msg) {
    if (typeof (msg) === "object") {
        for (let item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}

function cleanApplicationInWwwRoot() {
    let deployedApplicationFolder = config.wwwrootApplication;
    log("Cleaning " + $.util.colors.red(deployedApplicationFolder));
    del(deployedApplicationFolder);
    log("*** Cleaning Complete ***");
}

function changedEvent(event) {
    let srcPattern = new RegExp("/.*(?=/" + config.source + ")/");
    let message = "File: " + event.path.replace(srcPattern, "") + " was " + event.type;
    $.util.log($.util.colors.green(message));
}