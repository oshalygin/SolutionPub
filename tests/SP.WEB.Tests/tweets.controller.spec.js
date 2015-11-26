/// <reference path="angular.references.spec.js" />

(function() {

    describe("TweetsControllerTests", function() {

        var $rootScope;
        var $controller;
        var $q;
        var scope;
        var state;
        var vm;
        var mockTwitterService;

        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function(_$controller_, _$rootScope_, $state, _$q_) {
            $rootScope = _$rootScope_;
            scope = $rootScope.$new();
            state = $state;
            $q = _$q_;

            mockTwitterService = {
                getTweets: function () {
                    return $q.when({});
                }
            };

            spyOn(mockTwitterService, "getTweets").and.callThrough();

            $controller = _$controller_("app.tweets.TweetsController",
                {
                    $scope: scope,
                    twitterService: mockTwitterService
               });
            vm = $controller;
            state.expectTransitionTo("posts");
            scope.$apply();

        }));

        it("number of tweets to display is 3", function () {
            var expected = 3;
            var actual = vm.tweetsToDisplay;

            expect(actual).toEqual(expected);
        });

    });
})();