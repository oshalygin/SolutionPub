/// <reference path="angular.references.spec.js" />


(function () {
    describe("PostControllerTests", function () {

        var $rootScope;
        var $controller;
        var scope;
        var mockPostService;
        var state;
        var vm;

        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function (_$controller_, _$rootScope_, $state, $q) {
            $rootScope = _$rootScope_;
            scope = $rootScope.$new();
            state = $state;

            mockPostService = {
                getTotals : function () {
                    var defer = $q.defer();
                    return defer.promise;
                },
                getPosts : function (page) {
                    var defer = $q.defer();
                    return defer.promise;
                }
            };

            spyOn(mockPostService, "getPosts").and.callThrough();
            spyOn(mockPostService, "getTotals").and.callThrough();




            $controller = _$controller_("PostController",
                { $scope: scope,
                  postService: mockPostService});

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

        it("page size is set to 5", function () {
            var expected = 5;
            var actual = vm.pageSize;

            expect(actual).toEqual(expected);
        });


    });
})();