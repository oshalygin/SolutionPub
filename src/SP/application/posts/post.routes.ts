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
                    title: "Solution Pub",
                    templateUrl: "./wwwroot/application/posts/posts.html",
                    controller: "app.posts.PostController",
                    controllerAs: "vm"
                });

        }

})();