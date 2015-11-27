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



    });

})();