module.exports = function(config) {
    config.set({
        browsers: ["PhantomJS"],
        // browsers: ["Chrome"],
        frameworks: ["jasmine"],
        files: [
            "src/sp/wwwroot/assets/plugins/jquery/jquery.min.js",
            "src/sp/wwwroot/assets/plugins/jquery/jquery-migrate.min.js", "src/sp/wwwroot/assets/plugins/bootstrap/js/bootstrap.min.js", "src/sp/wwwroot/assets/plugins/back-to-top.js", "src/sp/wwwroot/assets/plugins/smoothscroll.js", "src/sp/wwwroot/assets/plugins/jquery.parallax.js", "src/sp/wwwroot/assets/plugins/fancybox/source/jquery.fancybox.pack.js", "src/sp/wwwroot/assets/plugins/fancybox/source/jquery.fancybox.js", "src/sp/wwwroot/assets/js/custom.js", "src/sp/wwwroot/assets/js/app.js", "src/sp/wwwroot/assets/js/plugins/fancy-box.js", "src/sp/wwwroot/lib/angular/angular.min.js", "src/sp/wwwroot/lib/angular-sanitize/angular-sanitize.min.js", "src/sp/wwwroot/lib/angular-animate/angular-animate.min.js", "src/sp/wwwroot/lib/angular-resource/angular-resource.min.js", "src/sp/wwwroot/lib/angular-route/angular-route.min.js", "src/sp/wwwroot/lib/angular-ui-router/release/angular-ui-router.min.js", "src/sp/wwwroot/lib/angular-mocks/angular-mocks.js", "src/sp/wwwroot/lib/angular-bootstrap/ui-bootstrap-tpls.min.js", "src/sp/wwwroot/lib/toastr/toastr.min.js", "src/sp/wwwroot/application/**/*.model.js", "src/sp/wwwroot/application/app.core.js", "src/sp/wwwroot/application/**/*.module.js", "src/sp/wwwroot/application/app.js", "src/sp/wwwroot/application/app.config.js", "src/sp/wwwroot/application/app.run.js",
            "src/sp/wwwroot/application/**/*.routes.js","src/sp/wwwroot/application/**/*.controller.js",
            //Test Files
            "tests/SP.WEB.Tests/statemock.js",
            "tests/SP.WEB.Tests/*.controller.spec.js"

        ]
    });
};
