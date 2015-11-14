module app.models {

    export interface ITweet {

        id: number;
        postedDated: Date;
        body: string;
    }

    export class Tweet implements ITweet {

        id: number;
        postedDated: Date;
        body: string;
    }
}