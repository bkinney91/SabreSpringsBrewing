import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import * as SignalR from "@microsoft/signalr";
import { AppSettingsHelper } from "@/core/helpers"; 
import { injectable, inject } from "inversify";

@injectable()
export class PumpHubService
{
    private hubName: string = "pumpHub";
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

    public SetPump1PowerStateCallback(receiveFunc: Function){
        this.hubConnection.on("Pump1PowerState", function(data: any){
            receiveFunc(data);
        });
    }

    public SetPump2PowerStateCallback(receiveFunc: Function){
        this.hubConnection.on("Pump2PowerState", function(data: any){
            receiveFunc(data);
        });
    }

    public SetPump1PowerState(powerEnabled: boolean){
        this.hubConnection.invoke("SetPump1PowerState", powerEnabled);
    }

    public SetPump2PowerState(powerEnabled: boolean){
        this.hubConnection.invoke("SetPump2PowerState", powerEnabled);
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