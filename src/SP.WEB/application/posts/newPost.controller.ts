module app.posts {

    interface INewPostController {
        title: string;
        post: app.models.IPost;
        imageUrl: string;
        postForm: angular.IFormController;

        savePost(): void;
    }

    class NewPostController implements INewPostController {

        title: string;
        post: app.models.IPost;
        imageUrl: string;
        postForm: angular.IFormController;

        static $inject = ["postDetailService", "$state", "$scope"]

        constructor(private postDetailService: app.services.PostDetailService,
            private $state: angular.ui.IStateService,
            $scope: angular.IScope,
            private form: app.models.IPostForm) {

            var vm = this;
            vm.title = "New Post";
            vm.post = new app.models.Post();

            //TODO: datepicker stuff
            //TODO: progress bar stuff


        }

        public savePost(): void {
            if (this.form.postForm.$invalid) {
                toastr.error("Fix the validation errors!");
                return;
            }

            this.savePostToDatabase();
        }

        private savePostToDatabase(): void {

            this.postDetailService
                .save(this.post)
                .then(() => {
                    toastr.success("Successfully posted" + this.post.title);
                    //TODO:  This will actually need to route to the postDetail with urlTitle, will configure later
                    this.$state.go("posts");
                },
                (error: any) => {
                    toastr.error("Message:" + error);
                });
        }

    }

    angular.module("app.posts")
        .controller("NewPostController", NewPostController);
}