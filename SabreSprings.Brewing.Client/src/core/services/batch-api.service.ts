import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { AxiosInstance } from "axios";
import { injectable, inject } from "inversify";

@injectable()
export class BatchApiService extends BaseApiService
{
    constructor(@inject(ServiceTypes.BaseAxiosInstance) protected client: AxiosInstance)
    {
        super(client, "Batch");
    }


    public getBatchTableRows(): Promise<any>
    {
        return this.client.get(`${this.apiUrl}/getBatchTable`)
            .then(response => { return response.data })
            .catch(error =>
            {
                console.log(error);
                let message = "Error.";

                if (error.reponse) {
                    message = error.response.data ? `${error.response.status}: ${error.response.data}` : `${error.response.status}: An error occured.`;
                }
                else if (error.request) {
                    message = "The request was made but no response was received";
                }
                else {
                    message = error.message;
                }

                throw new Error(message);
            });
    }


    public getBatchDetails(batchId: number): Promise<any>
    {
        return this.client.get(`${this.apiUrl}/getBatchDetails?id=`+ batchId)
            .then(response => { return response.data })
            .catch(error =>
            {
                let message = "Error.";

                if (error.reponse) {
                    message = error.response.data ? `${error.response.status}: ${error.response.data}` : `${error.response.status}: An error occured.`;
                }
                else if (error.request) {
                    message = "The request was made but no response was received";
                }
                else {
                    message = error.message;
                }

                throw new Error(message);
            });
    }   
}