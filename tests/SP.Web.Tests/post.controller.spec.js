/// <reference path="../../src/sp/wwwroot/app.js" />



(function () {
    describe("PostController:", function () {

        var $controller;
        var scope = {};
        var $rootScope;

        beforeEach(module("app"));
        //  beforeEach(module("app.post"));

        beforeEach(inject(function (_$controller_) {
            $controller = _$controller_;
        }));





        it("Sanity Check", function () {
            expect(true).toBeTruthy();
        });

        it("page title is Solution Pub", function () {
            var controller = $controller('PasswordController', { $scope: $scope });
            expect($scope.title).is.equal.to("Solution Pub");
        });


    });
})();