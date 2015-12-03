module app.services {

    export interface IPostStateParams extends angular.ui.IStateParamsService {
        postUrlTitle: string;
    }

    export class PostService extends HttpFactory {

        endpoint: string;

        static $inject = ["$http"];
        constructor($http: angular.IHttpService) {
            this.endpoint = ApiEndpoints.post;
            super($http, this.endpoint);
        }

        //TODO: refector this out of postservice
        getTotals(): ng.IPromise<any> {
            var emptyObject: any = {}
            return this.Get(emptyObject);
        }

        getPosts(page: number): ng.IPromise<any> {
            var config: any = {
                params: {
                    page: 1
                }
            };
            return this.Get(config);
        }
        //TODO: This needs work.
        getPost(postUrlTitle: string): ng.IPromise<any> {
            var config: any = {
                params: {
                    postUrlTitle: postUrlTitle
                }
            };
            return this.Get(config);
        }

    }



    angular.module("app.services")
        .service("postService", PostService);
}