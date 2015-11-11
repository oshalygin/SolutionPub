/// <reference path="angular.references.spec.js" />


(function () {
    describe("PostControllerTests", function () {

        var $rootScope;
        var $controller;
        var $q;
        var scope;
        var mockPostService;
        var state;
        var vm;


        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function (_$controller_, _$rootScope_, $state, _$q_) {
            $rootScope = _$rootScope_;
            scope = $rootScope.$new();
            state = $state;
            $q = _$q_;


            mockPostService = {
                getTotals : function () {
                    return $q.when(Mother.getTotals());
                },
                getPosts : function (page) {
                    return $q.when(Mother.getPosts());
                }
            };

            spyOn(mockPostService, "getPosts").and.callThrough();
            spyOn(mockPostService, "getTotals").and.callThrough();




            $controller = _$controller_("PostController",
                { $scope: scope,
                  postService: mockPostService});

            vm = $controller;
            state.expectTransitionTo("posts");
            scope.$apply();

        }));

        it("controller was successfully created", function () {
            expect($controller).toBeDefined();
        });

        it("initial page is set to 1", function () {
            var expected = 1;
            var actual = vm.page;

            expect(actual).toEqual(expected);
        });

        it("retrieved 5 posts", function () {
            var expected = 5;
            var actual = vm.posts;
             expect(actual.length).toEqual(expected);
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