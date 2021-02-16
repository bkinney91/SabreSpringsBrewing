
const ServiceTypes =
{
	BaseApiService: Symbol.for("BaseApiService"),
	BaseAxiosInstance: Symbol.for("BaseAxiosInstance"),
	BatchApiService: Symbol.for("BatchApiService"),
	BeerApiService: Symbol.for("BeerApiService"),
	TapHubService: Symbol.for("TapHubService"),
	TapApiService: Symbol.for("TapApiService"),
	FermentabuoyApiService: Symbol.for("FermentabuoyApiService"),
	FermentabuoyAssignmentApiService: Symbol.for("FermentabuoyAssignmentApiService"),
	MaterialApiService: Symbol.for("MaterialApiService"),
	RecipeApiService: Symbol.for("RecipeApiService"),
	RecipeStepsApiService: Symbol.for("RecipeStepsApiService"),
	Container: Symbol.for("Container")
};

export { ServiceTypes };