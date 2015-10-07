module app.contact {

    interface IAboutController {
        title: string;

    }


    class AboutController implements IAboutController {
        title: string;

        constructor() {
            var vm = this;
            vm.title = "About Me";
        }
    }

    angular.module("app.contact")
        .controller("app.contact.AboutController", AboutController);
}