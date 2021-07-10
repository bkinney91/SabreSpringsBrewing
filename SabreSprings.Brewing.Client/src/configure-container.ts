import { Container } from "inversify";
import {
	ContainerService,
	BaseApiService,
	BatchApiService,
	BeerApiService,
	TapHubService,
	TapApiService,
	MaterialApiService,
	FermentabuoyApiService,
	RecipeApiService,
	RecipeStepsApiService,
	FermentabuoyAssignmentApiService,
	FermentabuoyLogApiService,

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
		.bind<MaterialApiService>(ServiceTypes.MaterialApiService)
		.to(MaterialApiService)
		.inSingletonScope();
		container
		.bind<RecipeApiService>(ServiceTypes.RecipeApiService)
		.to(RecipeApiService)
		.inSingletonScope();
		container
		.bind<RecipeStepsApiService>(ServiceTypes.RecipeStepsApiService)
		.to(RecipeStepsApiService)
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
	return container;
}
