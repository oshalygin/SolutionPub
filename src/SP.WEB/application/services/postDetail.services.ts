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

        save(post: app.models.IPost): ng.IPromise<any> {

            var parsedUrlTitle: string = post.title
                .split("$").join("")
                .split("&").join("")
                .split("+").join("")
                .split(",").join("")
                .split("/").join("")
                .split(":").join("")
                .split(";").join("")
                .split("=").join("")
                .split("?").join("")
                .split("@").join("")
                .split(".").join("")
            //Unsafe characters
                .split("<").join("")
                .split(">").join("")
                .split("#").join("")
                .split("%").join("")
                .split("{").join("")
                .split("}").join("")
                .split("|").join("")
                .split("\\").join("")
                .split("^").join("")
                .split("~").join("")
                .split("[").join("")
                .split("]").join("")
                .split("`").join("")
            //Personal choice
                .split("*").join("")
                .split("(").join("")
                .split(")").join("")
                .split(";").join("")
                .split("!").join("")
                .split(":").join("")
                .split("_").join("")
                .split("\"").join("")
                .split("'").join("")
                .split(" - ").join("-")
                .split(" ").join("-");

            post.urlTitle = parsedUrlTitle;

            return this.Post(post);
        }
    }


    angular.module("app.services")
        .service("postDetailService", PostDetailService);
}