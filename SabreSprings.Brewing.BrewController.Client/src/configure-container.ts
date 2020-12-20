import { Container } from "inversify";
import {
	ContainerService,
	BaseApiService,
	KettleHubService,
	PumpHubService,
	MashHubService,

} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper } from "@/core/helpers";
import Axios, { AxiosInstance } from "axios";

export function configureContainer(): Container {
	const container = ContainerService.instance.getContainer();

	// Core Services

	container
		.bind<AxiosInstance>(ServiceTypes.BaseAxiosInstance)
		.toDynamicValue(c => {
			let client = Axios.create({
				baseURL: AppSettingsHelper.apiUrl()
			});
			return client;
		})
		.inSingletonScope();
	container
		.bind<BaseApiService>(ServiceTypes.BaseApiService)
		.to(BaseApiService)
		.inSingletonScope();
	container
		.bind<PumpHubService>(ServiceTypes.PumpHubService)
		.to(PumpHubService)
		.inSingletonScope();
	container
		.bind<KettleHubService>(ServiceTypes.KettleHubService)
		.to(KettleHubService)
		.inSingletonScope();
	container
		.bind<MashHubService>(ServiceTypes.MashHubService)
		.to(MashHubService)
		.inSingletonScope();
	return container;
}
