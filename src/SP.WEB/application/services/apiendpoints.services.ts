module app.services {
    export class ApiEndpoints{

        public static local: boolean = true;
        public static get baseUrl(): string {

            if (this.local) {
                return "http://localhost:51869/api/";
            }
            else {
                return "http://www.solutionpub.com/api/";
            }

        }

        public static get post(): string {
            return this.baseUrl + "Post/";
        }

        public static get postDetail(): string {
            return this.baseUrl + "PostDetail/";
        }

        public static get tag(): string {
            return this.baseUrl + "Tag/";
        }
        public static get twitter(): string {
            return this.baseUrl + "Twitter/";
        }

    }
}