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
            });


    }

})();
