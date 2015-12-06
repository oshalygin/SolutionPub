module app.services {

    export class HttpFactory {

        httpService: angular.IHttpService;
        endpoint: string;

        static $inject = ["$http"];
        constructor($http: ng.IHttpService, apiEndpoint: string) {
            this.httpService = $http;
            this.endpoint = apiEndpoint;
        }

        Get(params: any): ng.IPromise<any> {
            var result: ng.IPromise<any> = this.httpService.get(this.endpoint, params)
                .then((response: any): ng.IPromise<any> => {
                    return this.EndpointResponse(response, params);
                });

            return result;
        }

        Post(data: any, config?: any): ng.IPromise<any> {
            var result: ng.IPromise<any> = this.httpService.post(this.endpoint, data)
                .then((response: any): ng.IPromise<any> => {
                    return this.EndpointResponse(response, data);
                });

            return result;
        }

        Put(data: any, config?: any): ng.IPromise<any> {
            var result: ng.IPromise<any> = this.httpService.put(this.endpoint, data)
                .then((response: any): ng.IPromise<any> => {
                    return this.EndpointResponse(response, data);
                });
            return result;
        }

        Delete(params: any): ng.IPromise<any> {
            var result: ng.IPromise<any> = this.httpService.delete(this.endpoint, params)
                .then((response: any): ng.IPromise<any> => {
                    return this.EndpointResponse(response, params);
                });

            return result;
        }

        EndpointResponse(response: any, params: any): any {
            response.data.requestParams = params;
            return response.data;
        }
    }

}