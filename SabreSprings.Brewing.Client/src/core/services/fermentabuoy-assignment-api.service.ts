import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { AxiosInstance } from "axios";
import { injectable, inject } from "inversify";

@injectable()
export class FermentabuoyAssignmentApiService extends BaseApiService
{
    constructor(@inject(ServiceTypes.BaseAxiosInstance) protected client: AxiosInstance)
    {
        super(client, "FermentabuoyAssignment");
    }

}