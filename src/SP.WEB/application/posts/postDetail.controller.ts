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

        static $inject = ["postService", "$stateParams"];
        constructor(private postService: app.services.PostService,
        private $stateParams: app.services.IPostStateParams) {

            var vm = this;
            vm.editingMode = false;
            vm.postUrlTitle = $stateParams.postUrlTitle;

            vm.getPostById(vm.postUrlTitle);

        }

        public getPostById(postUrlTitle: string): void {
            this.postService
                .getPost(postUrlTitle)
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