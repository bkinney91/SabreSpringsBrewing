
const ServiceTypes =
{
	BaseApiService: Symbol.for("BaseApiService"),
	BaseAxiosInstance: Symbol.for("BaseAxiosInstance"),
	KettleHubService: Symbol.for("KettleHubService"),
	MashHubService: Symbol.for("MashHubSerivce"),
	PumpApiService: Symbol.for("PumpApiService"),
	KettleApiService: Symbol.for("KettleApiService"),
	Container: Symbol.for("Container")
};

export { ServiceTypes };