
const ServiceTypes =
{
	BaseApiService: Symbol.for("BaseApiService"),
	BaseAxiosInstance: Symbol.for("BaseAxiosInstance"),
	BatchApiService: Symbol.for("BatchApiService"),
	BrewEventService: Symbol.for("BrewEventService"),
	BeerApiService: Symbol.for("BeerApiService"),
	TapHubService: Symbol.for("TapHubService"),
	TapApiService: Symbol.for("TapApiService"),
	FermentabuoyApiService: Symbol.for("FermentabuoyApiService"),
	FermentabuoyAssignmentApiService: Symbol.for("FermentabuoyAssignmentApiService"),
	FermentabuoyLogApiService: Symbol.for("FermentabuoyLogApiService"),
	FermentationTankApiService: Symbol.for("FermentationTankApiService"),
	Container: Symbol.for("Container")
};

export { ServiceTypes };