/// <binding Clean='clean' />

var gulp = require("gulp");
var config = require("./gulp.config")();
var $ = require("gulp-load-plugins")({ lazy: true });
var del = require("del");
var wiredepModule = require("wiredep");
var rimraf = require("rimraf");


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

    var options = config.getWiredepDefaultOptions();
    var wiredep = require("wiredep").stream;

    return gulp
        .src(config.layoutInjector)
        .pipe(wiredep(options))
        .pipe($.inject(gulp.src(config.js)))
        .pipe(gulp.dest(config.layoutPage));

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

//todo: wiredep-testing file

gulp.task("transpile", function () {

    cleanApplicationInWwwRoot();
    log("** Transpiling TypeScript Files **");

    var typescriptOptions = {
        removeComments: true,
        target: "ES5",
        noImplicitAny: true
    };
    //todo: fix sourcemaps destination
    return gulp
        .src([config.appTsDev, config.tsTypingDefinitions])
    //.pipe($.sourcemaps.init({loadMaps: true}))
        .pipe($.typescript(typescriptOptions))
    //.pipe($.sourcemaps.write({includeContent: false}))
        .pipe(gulp.dest(config.wwwrootApplication));
});

gulp.task("tsc-watch", function () {
    log("*** Watching TypeScript files for changes **");

    gulp.watch([config.appTsDev], ["transpile"])
        .on("change", function (event) {
            changedEvent(event);
        });

});

//TODO: Minify HTML whitespace
gulp.task("move-html", ["transpile"], function () {

    log("*** Moving HTML Files to Deployment wwww folder ****");

    gulp.src([config.appHtmlFiles], { base: "application" })
        .pipe($.debug({ title: "DEPLOYED" }))
        .pipe(gulp.dest(config.wwwrootApplication));

});



function log(msg) {
    if (typeof (msg) === "object") {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.blue(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.blue(msg));
    }
}

function cleanApplicationInWwwRoot() {
    var deployedApplicationFolder = config.wwwrootApplication;
    log("Cleaning " + $.util.colors.red(deployedApplicationFolder));
    del(deployedApplicationFolder);
    log("*** Cleaning Complete ***");
}

function changedEvent(event) {
    var srcPattern = new RegExp("/.*(?=/" + config.source + ")/");
    var message = "File: " + event.path.replace(srcPattern, "") + " was " + event.type;
    $.util.log($.util.colors.green(message));
}