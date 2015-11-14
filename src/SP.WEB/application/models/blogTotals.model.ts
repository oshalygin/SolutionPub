module app.models {

    export interface IBlogTotals {

        totalNumberOfPosts: number;
        totalNumberOfComments: number;
        totalNumberOfViews: number;
        totalNumberOfTags: number;

    }

    export class BlogTotals implements IBlogTotals {

        totalNumberOfPosts: number;
        totalNumberOfComments: number;
        totalNumberOfViews: number;
        totalNumberOfTags: number;

    }
}