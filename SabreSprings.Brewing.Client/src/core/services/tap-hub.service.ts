import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import * as SignalR from "@microsoft/signalr";
import { AppSettingsHelper } from "@/core/helpers"; 
import { injectable, inject } from "inversify";

@injectable()
export class TapHubService
{
    private hubName: string = "tapHub";
    private hubConnection!: SignalR.HubConnection;
    constructor()
    {
        
    }

    public async StartConnection(){
        await this.InitializeConnection();
    }

    public GetState(){
        return this.hubConnection.state;
    }

    public SetTapDataCallback(receiveFunc: Function){
        this.hubConnection.on("TapData", function(data: any){
            receiveFunc(data);
        });
    }
    

    private async InitializeConnection(){
        if(!this.hubConnection)
        this.hubConnection = this.BuildConnection();
        await this.hubConnection.start();
    }


    private BuildConnection() : signalR.HubConnection
    {
        let connection =  new SignalR.HubConnectionBuilder()
                                .withUrl(AppSettingsHelper.hubUrl() + this.hubName)
                                .build();       
        
        return connection;
    }

}