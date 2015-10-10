/// <reference path="../../src/sp/wwwroot/app.js" />



(function () {
    describe("PostController:", function () {

        var $controller;
        var scope = {};
        var rootScope;

        beforeEach(module("app"));


        beforeEach(inject(function (_$controller_, _$rootScope_) {
            rootScope = _$rootScope_;
            scope = rootScope.$new();
            $controller = _$controller_("app.posts.PostController", { $scope: scope });

        }));

        it("Sanity Check", function () {
            expect(true).toBeTruthy();
        });

        it("page title is Solution Pub", function () {
            scope.$apply();
            expect(scope.title).is.equal.to("Solution Pub");
        });


    });
})();