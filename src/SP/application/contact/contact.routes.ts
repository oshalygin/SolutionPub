((): void=> {

    angular.module("app.contact")
        .config(configuration);

    configuration.$inject = ["$stateProvider", "$urlRouterProvider"];

    configuration.$inject = ["$stateProvider"]
    function configuration($stateProvider: angular.ui.IStateProvider) {

        $stateProvider
            .state("about", {
                url: "/about",
                views: {
                    "mainContent@": {
                        templateUrl: "./application/contact/about.html",
                        controller: "app.contact.AboutController",
                        controllerAs: "vm",
                        data: {
                            title: "About Me"
                        }
                    }
                }
            });

    }

})();