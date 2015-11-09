module app.models {

    export interface IImage {

        id: number;
        uploadDate: Date;
        imagePath: string;
        imageDescription: string;

    }
    
    export class Image implements IImage {

        id: number;
        uploadDate: Date;
        imagePath: string;
        imageDescription: string;

    }

}