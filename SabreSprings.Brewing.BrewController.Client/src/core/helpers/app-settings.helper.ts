import { ApplicationSettings } from "../models";
import { BaseUrlHelper } from ".";

export class AppSettingsHelper {
	public static baseUrl: string;

	
	public static getSettings(): ApplicationSettings {
		AppSettingsHelper.baseUrl = BaseUrlHelper.getBaseUrl();
		let settings: ApplicationSettings = {
			environment: AppSettingsHelper.environment(),
			baseUrl: AppSettingsHelper.baseUrl,
			appName: "Brew Controller",
			appDescription: "Client for Brewing Manager",
			appAbbreviation: "SS B&E",
			appIcon: "fa-beer"		
		};
		return settings;
	}


	public static environment(): string {
		if (AppSettingsHelper.baseUrl.indexOf("localhost") >= 0) {
			return "Debug";
		}		
		return "Release";
	}



	public static apiUrl(): string {		
		if (BaseUrlHelper.getBaseUrl().indexOf("localhost") >= 0) {
			return "http://localhost:8090/api";
		}
		return "http://10.0.0.2:8080/api";
	}

	public static hubUrl(): string {		
		if (BaseUrlHelper.getBaseUrl().indexOf("localhost") >= 0) {
			return "http://localhost:8090/";
		}
		return "http://10.0.0.2:8080/";
	}

	
}
