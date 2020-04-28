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
        this.SetReceiveMessage();
    }

    public GetState(){
        return this.hubConnection.state;
    }

    public SetTapDataCallback(receiveFunc: Function){
        this.hubConnection.on("TapData", function(data: any){
            receiveFunc(data);
        });
    }

    public SendMessage(message: string){
        console.log("service");
        this.hubConnection.invoke("SendMessage", message).catch(function(error) {
            console.log("CANT INVOKE");
            return console.error(error);
          });
    }

    public SetReceiveMessage(){
       
        this.hubConnection.on("ReceiveMessage", function(data: string){
           
            console.log("The data:" + data);
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