/// <reference path="angular.references.spec.js" />

(function() {

    describe("TweetsControllerTests", function() {

        var $rootScope;
        var $controller;
        var scope;
        var state;
        var vm;

        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function(_$controller_, _$rootScope_, $state) {
            $rootScope = _$rootScope_;
            scope = $rootScope.$new();
            state = $state;

            $controller = _$controller_("app.tweets.TweetsController",
            { $scope: scope });
            vm = $controller;
            state.expectTransitionTo("posts");

        }));

        it("number of tweets to display is 4", function () {
            var expected = 4;
            var actual = vm.tweetsToDisplay;

            expect(actual).toEqual(expected);
        });

    });
})();