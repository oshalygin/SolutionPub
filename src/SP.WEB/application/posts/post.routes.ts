((): void => {

    angular.module("app.posts")
        .config(configuration);


    configuration.$inject = ["$stateProvider", "$urlRouterProvider"];
    function configuration($stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider) {

        $urlRouterProvider.otherwise("/");

        $stateProvider
            .state("posts", {
                url: "/",
                views: {
                    "mainContent@": {
                        templateUrl: "./application/posts/posts.html",
                        controller: "PostController",
                        controllerAs: "vm",
                        data: {
                            title: "SolutionPub"
                        }
                    },
                    "rightSidebar@": {
                        templateUrl: "./application/sidebar/sidebar.html"
                    }
                }
            })
            .state("postDetail", {
                url: "/Post/:postUrlTitle",
                views: {
                    "mainContent@": {
                        templateUrl: "./application/posts/postDetail.html",
                        controller: "PostDetailController",
                        controllerAs: "vm",
                        data: {
                            title: "Post Detail"
                        }
                    },
                    "rightSidebar@": {
                        templateUrl: "./application/sidebar/sidebar.html"
                    }
                }
            });
    }

})();
