import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import * as SignalR from "@microsoft/signalr";
import { AppSettingsHelper } from "@/core/helpers"; 
import { injectable, inject } from "inversify";

@injectable()
export class MashHubService
{
    private hubName: string = "mashHub";
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

    public SetTemperatureCallback(receiveFunc: Function){
        this.hubConnection.on("MashTemperature", function(data: any){
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