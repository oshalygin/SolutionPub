module app.posts {

    "use strict";

    interface IPostController{
        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;
    }

    class PostController implements IPostController{

        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;

        constructor() {
            var vm = this;

            vm.title = "Solution Pub";
            vm.page = 1;
            vm.pageSize = 5;

        }
    }

    angular.module("app.posts")
        .controller("app.posts.PostController", PostController);

}