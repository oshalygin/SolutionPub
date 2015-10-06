module app.models{

    export interface IComment {

        id: number;
        body: string;
        dateOfComment: Date;
        name: string;
        email: string;
        isAnonymous: boolean;
        
        post: app.models.IPost;

    }

    export class Comment {

        id: number;
        body: string;
        dateOfComment: Date;
        name: string;
        email: string;
        isAnonymous: boolean;

        post: app.models.IPost;

    }
}