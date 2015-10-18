module app.models {

    export interface IPost {

        id: number;
        title: string;
        urlTitle: string;
        photoPath: string;
        postedDate: Date;
        dateEdited: Date;
        body: string;
        preview: string;
        views: number;
        inactive: boolean;
        
        tags: app.models.ITag[];
        comments: app.models.IComment[];

    }

    export class Post {

        id: number;
        title: string;
        urlTitle: string;
        photoPath: string;
        postedDate: Date;
        dateEdited: Date;
        body: string;
        preview: string;
        views: number;
        inactive: boolean;

        tags: app.models.ITag[];
        comments: app.models.IComment[];

    }

}