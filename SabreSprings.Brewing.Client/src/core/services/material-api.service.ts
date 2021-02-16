import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { AxiosInstance } from "axios";
import { injectable, inject } from "inversify";

@injectable()
export class MaterialApiService extends BaseApiService
{
    constructor(@inject(ServiceTypes.BaseAxiosInstance) protected client: AxiosInstance)
    {
        super(client, "Material");
    }

    public getMaterialTypes(): Promise<any> {
		return this.client
			.get(`${this.apiUrl}/getMaterialTypes`)
			.then(response => {
				return response.data;
			})
			.catch(error => {
				let message = "Error.";
				if (error.response) {
					// the request was made and the server responded with a status code
					// that falls out of the range of 2xx
					if (error.response.data) {
						message = `${error.response.status}: ${error.response.data}`;
					} else {
						message = `${error.response.status}: An error occured.`;
					}
				} else if (error.request) {
					message = "The request was made but no response was received";
					// `error.request` is an instance of XMLHttpRequest in the browser and an instance of
					// http.ClientRequest in node.js
				} else {
					// something happened in setting up the request that triggered an Error
					message = error.message;
				}
				throw new Error(message);
			});
	}
}