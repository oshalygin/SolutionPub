((): void=> {

    angular.module("app.contact")
        .config(configuration);

    configuration.$inject = ["$stateProvider", "$urlRouterProvider"];

    configuration.$inject = ["$stateProvider"]
    function configuration($stateProvider: angular.ui.IStateProvider) {

        $stateProvider
            .state({
                name: "about",
                url: "/about",
                data: {
                    title: "About Me"
                },
                templateUrl: "./application/contact/about.html",
                controller: "app.contact.AboutController",
                controllerAs: "vm"
            });

    }

})();