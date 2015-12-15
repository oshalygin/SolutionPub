/// <reference path="angular.references.spec.js" />

(function () {
    "use strict";

    describe("postDetailServiceTests", function () {

        var postDetailService;
        var httpBackend;
        var hostName = "http://localhost:51869";
        var apiEndpoint = hostName + "/api/PostDetail/";
        var rootScope;


        beforeEach(angular.mock.module("app.services"));
        beforeEach(angular.mock.module("app"));
        beforeEach(angular.mock.module("stateMock"));

        beforeEach(inject(function ($httpBackend, $rootScope, _postDetailService_) {
            httpBackend = $httpBackend;
            postDetailService = _postDetailService_;
            rootScope = $rootScope;
        }));

        afterEach(function () {
            httpBackend.verifyNoOutstandingExpectation();
            httpBackend.verifyNoOutstandingRequest();
        });

        it("postDetailService is registered with Angular", function () {
            expect(postDetailService).not.toEqual(null);
        });

        it("posting a new post successfully makes a POST request when calling save(post)", function () {

            var post = Mother.getValidPost();
            httpBackend.expectPOST(apiEndpoint,post).respond(200, post);

            var promiseFromPost = postDetailService.save(post);
            console.log(promiseFromPost);
            httpBackend.flush();

        });

    });


})();