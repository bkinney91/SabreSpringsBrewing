
const ServiceTypes =
{
	BaseApiService: Symbol.for("BaseApiService"),
	BaseAxiosInstance: Symbol.for("BaseAxiosInstance"),
	BatchApiService: Symbol.for("BatchApiService"),
	TapHubService: Symbol.for("TapHubService"),
	TapApiService: Symbol.for("TapApiService"),
	FermentabuoyApiService: Symbol.for("FermentabuoyApiService"),
	FermentabuoyAssignmentApiService: Symbol.for("FermentabuoyAssignmentApiService"),
	Container: Symbol.for("Container")
};

export { ServiceTypes };