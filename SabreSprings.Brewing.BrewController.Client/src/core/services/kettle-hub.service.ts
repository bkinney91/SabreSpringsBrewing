import { BaseApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import * as SignalR from "@microsoft/signalr";
import { AppSettingsHelper } from "@/core/helpers"; 
import { injectable, inject } from "inversify";

@injectable()
export class KettleHubService
{
    private hubName: string = "kettleHub";
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

    public SetCurrentTemperatureCallback(receiveFunc: Function){
        this.hubConnection.on("CurrentTemperature", function(data: any){
            receiveFunc(data);
        });
    }

    public SetTargetTemperatureCallback(receiveFunc: Function){
        this.hubConnection.on("TargetTemperature", function(data: any){
            receiveFunc(data);
        });
    }

    public SetTemperature(temperature: number){
        this.hubConnection.invoke("SetTemperature", temperature);
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