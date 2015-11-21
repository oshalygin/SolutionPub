module app.models {

    export interface ITweet {

        id: number;
        originalPostedDate: Date;
        weeksFromPostedDate: number;
        daysFromPostedDate: number;
        hoursFromPostedDate: number;
        minutesFromPostedDate: number;
        secondsFromPostedDate: number;
        body: string;
    }

    export class Tweet implements ITweet {

        id: number;
        originalPostedDate: Date;
        weeksFromPostedDate: number;
        daysFromPostedDate: number;
        hoursFromPostedDate: number;
        minutesFromPostedDate: number;
        secondsFromPostedDate: number;
        body: string;
    }
}