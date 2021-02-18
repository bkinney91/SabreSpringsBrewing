import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { AxiosInstance } from "axios";
import { injectable, inject } from "inversify";

@injectable()
export class RecipeApiService extends BaseApiService
{
    constructor(@inject(ServiceTypes.BaseAxiosInstance) protected client: AxiosInstance)
    {
        super(client, "Recipe");
    }


    public getFromBeer(id: number): Promise<any> {
		return this.client
			.get(`${this.apiUrl}/Get/?id=${id}`)
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
					// console.log(error.request);
				} else {
					// something happened in setting up the request that triggered an Error
					message = error.message;
				}
				throw new Error(message);
			});
	}

}