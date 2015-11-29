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

        static $inject = ["postService"];
        constructor(postService: app.services.PostService) {
            var vm = this;
            vm.editingMode = false;


        }

        public getPostById(postId: number): void {
            //TODO: Service work
        }

        public toggleEditingMode(): void {
            this.editingMode = !this.editingMode;
        }
    }


    angular.module("app.posts")
        .controller("PostDetailController", PostDetailController);
}