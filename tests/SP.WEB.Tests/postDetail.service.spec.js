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


        it("calling getPost with a valid urlTitle returns back the post", function () {

            var urlTitle = "A-New-Post-About-JavaScript";
            var endpoint = apiEndpoint + "?postUrlTitle=" + urlTitle;

            httpBackend.expectGET(endpoint)
                .respond(Mother.getValidPost());

            var promiseFromGetPost = postDetailService
                .getPost(urlTitle);

            promiseFromGetPost.then(function (response) {
                expect(response.urlTitle).toEqual(urlTitle);
            });

            httpBackend.flush();

        });

        it("posting a new post successfully makes a POST request when calling save(post)", function () {

            var post = Mother.getPostWithoutUrlTitle();
            httpBackend.expectPOST(apiEndpoint, post).respond(200, post);

            postDetailService.save(post);
            httpBackend.flush();

        });

        it("urlTitle removes whitespace and replaces it with dashes", function () {

            var post = Mother.getPostWithoutUrlTitle();
            post.title = "New Post About JavaScript";
            var expected = "New-Post-About-JavaScript";

            httpBackend.expectPOST(apiEndpoint, post).respond(200, post);
            var promiseFromPost = postDetailService.save(post);

            promiseFromPost.then(function (response) {
                expect(response.urlTitle).toEqual(expected);
            });

            httpBackend.flush();

        });

        it("urlTitle removes quotes from post title", function () {

            var post = Mother.getPostWithoutUrlTitle();
            post.title = "Post With \"Quotes\"";
            var expected = "Post-With-Quotes";

            httpBackend.expectPOST(apiEndpoint, post).respond(200, post);
            var promiseFromPost = postDetailService.save(post);

            promiseFromPost.then(function (response) {
                expect(response.urlTitle).toEqual(expected);
            });

            httpBackend.flush();

        });

        it("urlTitle removes special characters from post title", function () {

            var post = Mother.getPostWithoutUrlTitle();
            post.title = "Post! W!ith Strange&* Stuff-Ok";
            var expected = "Post-With-Strange-Stuff-Ok";

            httpBackend.expectPOST(apiEndpoint, post).respond(200, post);
            var promiseFromPost = postDetailService.save(post);

            promiseFromPost.then(function (response) {
                expect(response.urlTitle).toEqual(expected);
            });

            httpBackend.flush();

        });


        it("urlTitle removes whitespace from both sides of a dash when alone", function () {

            var post = Mother.getPostWithoutUrlTitle();
            post.title = "Post Title - JavaScript";
            var expected = "Post-Title-JavaScript";

            httpBackend.expectPOST(apiEndpoint, post).respond(200, post);
            var promiseFromPost = postDetailService.save(post);

            promiseFromPost.then(function (response) {
                expect(response.urlTitle).toEqual(expected);
            });

            httpBackend.flush();

        });

    });


})();