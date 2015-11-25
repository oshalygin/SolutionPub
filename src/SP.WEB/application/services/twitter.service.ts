module app.services {

    export class TwitterService extends HttpFactory {

        endpoint: string;

        static $inject = ["$http"];
        constructor($http: angular.IHttpService) {
            this.endpoint = ApiEndpoints.twitter;
            super($http, this.endpoint);
        }


        getTweets(): ng.IPromise<any> {
            //TODO: Get around not passing an empty object
            var emptyObject: any = {}
            return this.Get(emptyObject);
        }

    }



    angular.module("app.services")
        .service("twitterService", TwitterService);
}