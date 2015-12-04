module app.services {

    export interface IPostStateParams extends angular.ui.IStateParamsService {
        postUrlTitle: string;
    }

    export class PostDetailService extends HttpFactory {

        endpoint: string;

        static $inject = ["$http"];
        constructor($http: angular.IHttpService) {
            this.endpoint = ApiEndpoints.postDetail;
            super($http, this.endpoint);
        }

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
        .service("postDetailService", PostDetailService);
}