export class BaseUrlHelper {
	public static getBaseUrl(): string {
		return window.location.protocol + "//" + window.location.host;
	}
}