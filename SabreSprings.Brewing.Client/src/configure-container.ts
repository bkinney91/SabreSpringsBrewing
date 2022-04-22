import { Container } from "inversify";
import {
	ContainerService,
	BaseApiService,
	BatchApiService,
	BrewEventService,
	BeerApiService,
	TapHubService,
	TapApiService,
	FermentabuoyApiService,
	FermentabuoyAssignmentApiService,
	FermentabuoyLogApiService,
	FermentationTankApiService,

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
		.bind<BatchApiService>(ServiceTypes.BatchApiService)
		.to(BatchApiService)
		.inSingletonScope();
	container
		.bind<BeerApiService>(ServiceTypes.BeerApiService)
		.to(BeerApiService)
		.inSingletonScope();
	container
		.bind<TapHubService>(ServiceTypes.TapHubService)
		.to(TapHubService)
		.inSingletonScope();
	container
		.bind<TapApiService>(ServiceTypes.TapApiService)
		.to(TapApiService)
		.inSingletonScope();
	container
		.bind<FermentabuoyApiService>(ServiceTypes.FermentabuoyApiService)
		.to(FermentabuoyApiService)
		.inSingletonScope();
	container
		.bind<FermentabuoyAssignmentApiService>(ServiceTypes.FermentabuoyAssignmentApiService)
		.to(FermentabuoyAssignmentApiService)
		.inSingletonScope();
	container
		.bind<FermentabuoyLogApiService>(ServiceTypes.FermentabuoyLogApiService)
		.to(FermentabuoyLogApiService)
		.inSingletonScope();
	container
		.bind<FermentationTankApiService>(ServiceTypes.FermentationTankApiService)
		.to(FermentationTankApiService)
		.inSingletonScope();
	container
		.bind<BrewEventService>(ServiceTypes.BrewEventService)
		.to(BrewEventService)
		.inSingletonScope();
	return container;
}
