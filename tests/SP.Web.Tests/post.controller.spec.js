/// <reference path="../../src/sp/wwwroot/assets/plugins/jquery/jquery.min.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/jquery/jquery-migrate.min.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/bootstrap/js/bootstrap.min.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/back-to-top.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/smoothscroll.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/jquery.parallax.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/fancybox/source/jquery.fancybox.pack.js" />
/// <reference path="../../src/sp/wwwroot/assets/plugins/fancybox/source/jquery.fancybox.js" />
/// <reference path="../../src/sp/wwwroot/assets/js/custom.js" />
/// <reference path="../../src/sp/wwwroot/assets/js/app.js" />
/// <reference path="../../src/sp/wwwroot/assets/js/plugins/fancy-box.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular/angular.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-sanitize/angular-sanitize.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-animate/angular-animate.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-resource/angular-resource.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-route/angular-route.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-ui-router/release/angular-ui-router.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-mocks/angular-mocks.js" />
/// <reference path="../../src/sp/wwwroot/lib/angular-bootstrap/ui-bootstrap-tpls.min.js" />
/// <reference path="../../src/sp/wwwroot/lib/toastr/toastr.min.js" />
/// <reference path="statemock.js" />
/// <reference path="../../src/sp/wwwroot/application/models/comment.model.js" />
/// <reference path="../../src/sp/wwwroot/application/models/post.model.js" />
/// <reference path="../../src/sp/wwwroot/application/models/tag.model.js" />
/// <reference path="../../src/sp/wwwroot/application/models/image.model.js" />
/// <reference path="../../src/sp/wwwroot/application/app.core.js" />
/// <reference path="../../src/sp/wwwroot/application/services/services.module.js" />
/// <reference path="../../src/sp/wwwroot/application/contact/contact.module.js" />
/// <reference path="../../src/sp/wwwroot/application/posts/posts.module.js" />
/// <reference path="../../src/sp/wwwroot/application/tags/tags.module.js" />
/// <reference path="../../src/sp/wwwroot/application/images/images.module.js" />
/// <reference path="../../src/sp/wwwroot/application/comments/comments.module.js" />
/// <reference path="../../src/sp/wwwroot/application/tweets/tweets.module.js" />
/// <reference path="../../src/sp/wwwroot/application/sidebar/sidebar.module.js" />
/// <reference path="../../src/sp/wwwroot/application/app.js" />
/// <reference path="../../src/sp/wwwroot/application/app.config.js" />
/// <reference path="../../src/sp/wwwroot/application/app.run.js" />
/// <reference path="../../src/sp/wwwroot/application/posts/post.routes.js" />
/// <reference path="../../src/sp/wwwroot/application/contact/contact.routes.js" />
/// <reference path="../../src/sp/wwwroot/application/posts/post.controller.js" />
/// <reference path="../../src/sp/wwwroot/application/contact/about.controller.js" />
/// <reference path="../../src/sp/wwwroot/application/tweets/tweets.controller.js" />
/// <reference path="../../src/sp/wwwroot/application/tags/tags.controller.js" />


(function () {
    describe("PostControllerTests", function () {

        var $rootScope;
        var $controller;
        var scope;
        var state;
        var vm;

        beforeEach(module("app"));
        beforeEach(module("stateMock"));

        beforeEach(inject(function (_$controller_, _$rootScope_, $state) {
            $rootScope = _$rootScope_;
            scope = $rootScope.$new();
            state = $state;

            $controller = _$controller_("app.posts.PostController",
                { $scope: scope });
            vm = $controller;
            state.expectTransitionTo("posts");

        }));

        it("initial page is set to 1", function () {
            var expected = 1;
            var actual = vm.page;

            expect(actual).toEqual(expected);
        });

        it("page title is set to Solution Pub", function () {
            var expected = "Solution Pub";
            var actual = vm.title;

            expect(actual).toEqual(expected);
        });

         it("page size is set t5", function () {
            var expected = 5;
            var actual = vm.pageSize;

            expect(actual).toEqual(expected);
        });


    });
})();