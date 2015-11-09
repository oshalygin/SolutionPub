module app.posts {

    "use strict";

    interface IPostController {
        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;
    }

    class PostController implements IPostController {

        title: string;
        pageSize: number;
        page: number;
        totalNumberOfPosts: number;
        maxPagesToDisplay: number;
        posts: any;

        static $inject = ["app.post.services"]
        constructor(postService: app.services.PostService) {
            var vm = this;

            vm.title = "Solution Pub";
            vm.page = 1;
            vm.pageSize = 5;

            postService.getPosts()
                .then((data: any) => {
                    vm.posts = data;
                });

        }
    }

    angular.module("app.posts")
        .controller("app.posts.PostController", PostController);

}