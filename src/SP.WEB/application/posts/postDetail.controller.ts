module app.posts {

    interface IPostDetailController {
        title: string;
        post: app.models.IPost;
        postUrlTitle: string;
        imageUrl: string;
        editingMode: boolean;


    }

    class PostDetailController implements IPostDetailController {

        title: string;
        post: app.models.IPost;
        postUrlTitle: string;
        imageUrl: string;
        editingMode: boolean;

        static $inject = ["postDetailService", "$stateParams"];
        constructor(private postDetailService: app.services.PostDetailService,
            private $stateParams: app.services.IPostStateParams) {

            var vm = this;
            vm.editingMode = false;
            vm.postUrlTitle = $stateParams.postUrlTitle;

            postDetailService
                .getPost(vm.postUrlTitle)
                .then((data: any) => {
                    this.post = data;
                });


        }

        public toggleEditingMode(): void {
            this.editingMode = !this.editingMode;
        }
    }


    angular.module("app.posts")
        .controller("PostDetailController", PostDetailController);
}