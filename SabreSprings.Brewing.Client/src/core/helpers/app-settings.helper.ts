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

	public static getStatusColor(statusText: string) {
		let color: string = "";
		if (statusText != null && statusText.includes("On Tap")) {
			color = "green";
		} else if (statusText === "Fermenting") {
			color = "red";
		} else if (statusText === "Conditioning") {
			color = "#D2D545";
		} else if (statusText === "Archived") {
			color = "#1369B1";
		} else if (statusText === "Planned") {
			color = "#B11313";
		} else if (statusText === "Souring") {
			color = "#3d004f";
		}
		return color;
	}
}
