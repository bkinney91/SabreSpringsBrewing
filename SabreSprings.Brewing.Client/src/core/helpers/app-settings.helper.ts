import { ApplicationSettings } from "../models";
import { BaseUrlHelper } from ".";

export class AppSettingsHelper {
	public static baseUrl: string;

	
	public static getSettings(): ApplicationSettings {
		AppSettingsHelper.baseUrl = BaseUrlHelper.getBaseUrl();
		let settings: ApplicationSettings = {
			environment: AppSettingsHelper.environment(),
			baseUrl: AppSettingsHelper.baseUrl,
			appName: "SabreSprings.Brewing.Client",
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
		if (AppSettingsHelper.baseUrl.indexOf("localhost") >= 0) {
			return "https://localhost:XXX/api";
		}
		return "http:/10.0.0.2/api";
	}
}
