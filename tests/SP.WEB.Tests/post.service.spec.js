(function () {
    "use strict";

    describe("postService", function () {

        var postService;
        var httpBackend;
        var apiEndpoint = "/api/post";
        var defaultApiEndPoint = "/api/post?page=0";

        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function ($httpBackend, $rootScope, _postService_) {
            httpBackend = $httpBackend;
            postService = _postService_;
        }));

        afterEach(function () {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });

        it("postService is registered with Angular", function () {
            expect(postService).not.toEqual(null);
        });


    });


})();