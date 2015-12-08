module app.models {

    export class DatePickerStatus {

        constructor(public opened: boolean,
            public format: string) {

            this.opened = opened;
            this.format = format;

        }

        public open($event: any) {
            this.opened = true;
        }
    }

}