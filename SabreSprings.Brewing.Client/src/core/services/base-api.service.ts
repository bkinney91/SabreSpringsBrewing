import { AxiosInstance } from "axios";
import { ServiceTypes } from "../symbols";
import { injectable, unmanaged } from "inversify";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers"; 

@injectable()
export class BaseApiService {
	protected apiUrl!: string;

	constructor(protected client: AxiosInstance, @unmanaged() apiPath: string) {
		this.apiUrl = `${AppSettingsHelper.apiUrl()}/${apiPath}`;
	}
	
	public get(id: number): Promise<any> {
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

	public put(body: any): Promise<any> {
		return this.client
			.put(`${this.apiUrl}/Put`, body)
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
					message = "The request was made but no response was received.";
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

	public post(body: any): Promise<any> {
		return this.client
			.post(`${this.apiUrl}/Post`, body)
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

	public delete(body?: any): Promise<any> {
		return this.client
			.post(`${this.apiUrl}/Delete`, body)
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

	public getAll(): Promise<any> {
		return this.client
			.get(`${this.apiUrl}/getAll`)
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