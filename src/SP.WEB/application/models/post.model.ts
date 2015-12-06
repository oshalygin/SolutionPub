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

        tagString: string;
        tags: app.models.ITag[];
        comments: app.models.IComment[];

    }

    export class Post implements IPost {

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

        tagString: string;
        tags: app.models.ITag[];
        comments: app.models.IComment[];

    }

}