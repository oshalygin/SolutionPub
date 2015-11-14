module.exports = function (config) {
    config.set({
        basePath: "",
        browsers: ["PhantomJS"],
        // browsers: ["Chrome"],
        frameworks: ["jasmine"],
        files: [
            "lib/angular/angular.min.js",
            "lib/angular-sanitize/angular-sanitize.min.js",
            "lib/angular-animate/angular-animate.min.js",
            "lib/angular-resource/angular-resource.min.js",
            "lib/angular-route/angular-route.min.js",
            "lib/angular-ui-router/release/angular-ui-router.min.js",
            "lib/angular-mocks/angular-mocks.js",
            "lib/angular-bootstrap/ui-bootstrap-tpls.min.js",
            "lib/toastr/toastr.min.js", "application/**/*.model.js",
            "application/app.core.js", "application/**/*.module.js",
            "application/app.js", "application/app.config.js",
            "application/app.run.js",
            "application/**/*.routes.js", "application/**/*.services.js", "application/**/*.controller.js",
        //Test Files
            "../../tests/SP.WEB.Tests/stateMock.js",
            "../../tests/SP.WEB.Tests/Mother.js",
            "../../tests/SP.WEB.Tests/*.service.spec.js",
            "../../tests/SP.WEB.Tests/*.controller.spec.js"
        ],
        reporters: ["mocha"],
        logLevel: config.LOG_INFO

    });
};
