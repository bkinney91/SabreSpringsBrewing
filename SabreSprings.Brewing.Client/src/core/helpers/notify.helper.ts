import notify from "devextreme/ui/notify";

export class NotifyHelper {
	constructor() {}

	public static displayMessage(message: string, timeout: number = 3000) {
		notify(message, "success", timeout);
	}

	public static displayError(message: string, timeout: number = 3000) {
		notify(message, "error", timeout);
	}

	public static displayInfo(message: string, timeout: number = 3000) {
		notify(message, "info", timeout);
	}
}