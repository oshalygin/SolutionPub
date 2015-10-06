((): void => {

    angular.module("app")
        .config(configuration);

    function configuration($locationProvider: ng.ILocationProvider): void {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        })
    }

})();