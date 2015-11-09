module app.models {

    export interface ITag {

        id: number;
        name: string;
        timesUsed: number;

        posts: app.models.IPost[];

    }

    export class Tag implements ITag {

        id: number;
        name: string;
        timesUsed: number;
        
        posts: app.models.IPost[];

    }

}