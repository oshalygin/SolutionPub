/// <reference path="angular.references.spec.js" />

(function () {
    "use strict";

    describe("twitterServiceTests", function () {

        var twitterService;
        var httpBackend;
        var hostName = "http://localhost:51869";
        var apiEndpoint = hostName + "/api/Twitter/";

        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function ($httpBackend, $rootScope, _twitterService_) {
            httpBackend = $httpBackend;
            twitterService = _twitterService_;
        }));

        afterEach(function () {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });

        it("twitterService is registered with the framework", function () {
            expect(twitterService).not.toEqual(null);
        });

        it("Calling twitterService returns back 3 tweets", function () {
            httpBackend.expectGET(apiEndpoint)
                .respond(Mother.getTweets());

            var expected = 3;

            var promiseFromService = twitterService.getTweets();
            promiseFromService.then(function (response) {
                expect(response.length).toEqual(expected);
            });

            httpBackend.flush();

        });

        it("Calling getTweets() body of the tweet is not empty", function () {
            httpBackend.expectGET(apiEndpoint)
                .respond(Mother.getTweets());

            var promiseFromService = twitterService.getTweets();
            promiseFromService.then(function (response) {
                expect(response[0].body).not.toBeUndefined();
            });

            httpBackend.flush();

        });



    });

})();