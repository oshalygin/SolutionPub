module app.services {

    export class PostService extends HttpFactory {

        endpoint: string;

        static $inject = ["$http"];
        constructor($http: angular.IHttpService) {
            this.endpoint = ApiEndpoints.post;
            super($http, this.endpoint);
        }

        getPosts(): ng.IPromise<any> {
            //TODO: Get around not passing an empty object
            var emptyObject: any = {}
            return this.Get(emptyObject);
        }

    }



    angular.module("app.services")
        .service("app.post.services", PostService);
}