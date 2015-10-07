((): void => {

    angular.module("app.posts")
        .config(configuration);


    configuration.$inject = ["$stateProvider", "$urlRouterProvider"];
    function configuration($stateProvider: angular.ui.IStateProvider,
        $urlRouterProvider: angular.ui.IUrlRouterProvider) {

        $urlRouterProvider.otherwise("/");


        $stateProvider
            .state({
                name: "posts",
                url: "/",
                templateUrl: "./application/posts/posts.html",
                controller: "app.posts.PostController",
                controllerAs: "vm",
                data: {
                    title: "SolutionPub"
                }
            });

    }

})();
