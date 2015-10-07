module app.tags {

    interface ITagsController {
        numberOfTags: number;
    }

    class TagController {
        numberOfTags: number;
        constructor() {
            var vm = this;
            vm.numberOfTags = 5;
        };
    }


    angular.module("app.tags")
        .controller("app.tags.TagsController");
}