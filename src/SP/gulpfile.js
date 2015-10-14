/// <binding Clean='clean' />

var gulp = require("gulp");
var config = require("./gulp.config")();
var $ = require("gulp-load-plugins")({ lazy: true });
var del = require("del");
var wiredepModule = require("wiredep");
var rimraf = require("rimraf");
var Server = require("karma").Server;

var typescriptOptions = {

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

    var options = config.getWiredepDefaultOptions();
    var wiredep = require("wiredep").stream;


    return gulp
        .src(config.layoutInjector)
        .pipe(wiredep(options))
        .pipe($.inject(gulp.src(config.js,
            { read: false }), {
                transform: function (filepath) {
                    return '<script src="~' + filepath + '"></script>'; // jshint ignore:line
                }
            }
            ))
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

gulp.task("run-jtests", function (done) {
    new Server({
        configFile: config.karmaConfiguration,
        basePath: "../../..",
        singleRun: true
    }, done).start();
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