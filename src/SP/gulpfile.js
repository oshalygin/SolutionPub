/// <binding Clean='clean' />

var gulp = require("gulp");
var config = require("./gulp.config")();
var $ = require("gulp-load-plugins")({ lazy: true });
var del = require("del");
var wiredepModule = require("wiredep");


///SolutionPub Gulp Tasks

gulp.task("help", $.taskListing);

gulp.task("jshint", function () {
    log("** JSHint Check **");
    return gulp
        .src(config.appJavaScriptFiles)
        .pipe($.jshint())
        .pipe($.jshint.reporter("jshint-stylish", { verbose: true }))
    //todo:  Step necessary to stop the build process in case of JSHint blows up
        .pipe($.jshint.reporter("fail"));
});

gulp.task("tslint", function () {
    log("** TSLint Check **");

    return gulp
        .src(config.appTsDev)
        .pipe($.tslint())
        .pipe($.tslint.report("verbose"));

});

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

gulp.task("move-html", function () {

    log("*** Moving HTML Files to Deployment wwww folder ****");

    gulp.src(config.devPath, { base: "." })
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