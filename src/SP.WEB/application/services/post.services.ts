module app.services {

    export class PostService {

        static $inject = ["$http"];
        constructor($http: angular.IHttpService) {
            
        }
    }


    angular.module("app.services")
        .service("app.post.services", PostService);
}