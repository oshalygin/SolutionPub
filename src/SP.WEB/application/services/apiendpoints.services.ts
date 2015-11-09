module app.services {
    export class ApiEndpoints{

        public static local: boolean = true;
        public static get baseUrl(): string {

            if (this.local) {
                return "http://localhost:15523/api/";
            }
            else {
                return "http://www.solutionpub.com/api/";
            }

        }

        public static get post(): string {
            return this.baseUrl + "Post/";
        }

        public static get tag(): string {
            return this.baseUrl + "Tag/";
        }

    }
}