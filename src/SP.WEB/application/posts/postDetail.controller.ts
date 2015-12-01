module app.posts {

    interface IPostDetailController {
        title: string;
        post: app.models.IPost;
        postId: number;
        imageUrl: string;
        editingMode: boolean;


    }

    class PostDetailController implements IPostDetailController {

        title: string;
        post: app.models.IPost;
        postId: number;
        imageUrl: string;
        editingMode: boolean;

        static $inject = ["postService", "$stateParams"];
        constructor(private postService: app.services.PostService,
        private $stateParams: app.services.IPostStateParams) {

            var vm = this;
            vm.editingMode = false;
            vm.postId = $stateParams.id;

            vm.getPostById(vm.postId);

        }

        public getPostById(postId: number): void {
            this.postService
                .Get(postId)
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