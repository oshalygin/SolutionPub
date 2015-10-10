/// <reference path="angulartestreferences.js" />


(function () {
    describe("PostControllerTests", function () {

        var $rootScope;
        var $controller;
        var scope;
        var state;
        var vm;

        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

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