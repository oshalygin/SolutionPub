((): void=> {

    angular.module("app.core", [
    //Core Angular
        "ngRoute",
        , "ngResource"
        , "ngAnimate"
        , "ngSanitize"

    //Third Party
        , "ui.router"
        , "ui.bootstrap"
        , "ui.bootstrap.pagination"

    //TODO: confirm if necessary
        , "ui.bootstrap.showErrors"

    ]);

})();