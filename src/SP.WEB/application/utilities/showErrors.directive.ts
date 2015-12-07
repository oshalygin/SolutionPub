((): void => {
    angular.module("app.utilities")
        .directive("showErrors", () => {
            return {
                restrict: "A",
                require: "^form",
                link(scope: any, el: any, attrs: any, formCtrl: any) {
                    // find the text box element, which has the 'name' attribute
                    var inputEl = el[0].querySelector("[name]");
                    // convert the native text box element to an angular element
                    var inputNgEl = angular.element(inputEl);
                    // get the name on the text box so we know the property to check
                    // on the form controller
                    var inputName = inputNgEl.attr("name");

                    // only apply the has-error class after the user leaves the text box
                    inputNgEl.bind("blur", () => {
                        el.toggleClass("has-error", formCtrl[inputName].$invalid);
                    });

                    scope.$on('show-errors-check-validity', () => {
                        el.toggleClass('has-error', formCtrl[inputName].$invalid);
                    });
                }
            }
        });

})();
