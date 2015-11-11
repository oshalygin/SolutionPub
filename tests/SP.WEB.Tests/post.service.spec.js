(function () {
    "use strict";

    describe("postService", function () {

        var postService;
        var httpBackend;
        var hostName = "http://localhost:15523";
        var apiEndpoint = hostName + "/api/Post";
        var defaultApiEndPoint = hostName + "/api/Post/?page=1";

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

        it("when calling getPosts() the service returns back 5 loans", function () {

            httpBackend.expectGET(defaultApiEndPoint)
                .respond(Mother.getPosts());

            var promiseFromService = postService.getPosts();

            promiseFromService.then(function (response) {
                expect(response.data.value.length).toEqual(5);
            });

            httpBackend.flush();

        });


    });


})();