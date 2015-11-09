module app.posts {

    "use strict";

    interface IPostController {
        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;
        //todo: create a class for totals
        totals: any;
        // posts: app.models.IPost[];
    }

    class PostController implements IPostController {

        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;
        totals: any;
        posts: any;
        // posts: app.models.IPost[];

        static $inject = ["app.post.services"]
        constructor(postService: app.services.PostService) {
            var vm = this;

            vm.title = "Solution Pub";
            vm.page = 1;
            vm.pageSize = 5;

            postService.getTotals()
                .then((data: any) => {
                    vm.totals = data;
                });

            postService.getPosts(vm.page)
                .then((data: any) => {
                    vm.posts = data;
                });

        }
    }

    angular.module("app.posts")
        .controller("app.posts.PostController", PostController);

}