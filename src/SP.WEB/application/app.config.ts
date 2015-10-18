((): void => {

    angular.module("app")
        .config(configuration);

    function configuration($locationProvider: ng.ILocationProvider): void {
        //todo: need .net server url rewrite to get rid of #'s, otherwise I won't be able to hit the URL directly(failure)
        // $locationProvider.html5Mode({
        //     enabled: true,
        //     requireBase: false
        // });
    }

})();