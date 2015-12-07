module app.models {

    export class DatePickerStatus {
        public opened: boolean;
        public format: string;

        //TODO:  Convert to private initializers
        constructor(){
            this.opened = false;
            this.format = "MM/dd/yyyy";
        }

        public open($event: any): void {
            this.opened = true;
        }
    }

}