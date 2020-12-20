<template>
 <div class="card" style="height:100%; margin-top: 5%" >
  <div class="card-body">
    <div class="row" >
      <div class="col-lg-10">
        <h2>Pumps</h2>
      </div>
    </div>
    <hr />
    <div style="height:30%" class="row">
      <div class="col-lg-6">
        <h3>Kettle</h3>
      </div>
      <div class="col-lg-6">      
        <div class="onoffswitch">
          <input
          v-on:click="setPump1PowerState"
            type="checkbox"
            name="kettlePumpSwitch"
            class="onoffswitch-checkbox"
            id="kettlePumpSwitch"
            tabindex="0"
            v-model="pump1PowerEnabled"
          />
          <label class="onoffswitch-label" for="kettlePumpSwitch">
            <span class="onoffswitch-inner"></span>
            <span class="onoffswitch-switch"></span>
          </label>
        </div>
      </div>
    </div>
    <br />   
      <div class="row">
        <div class="col-lg-6">
          <h3>Mash</h3>
        </div>
        <div class="col-lg-6">
          <div class="onoffswitch">
            <input
            v-on:click="setPump2PowerState"
              type="checkbox"
              name="mashPumpSwitch"
              class="onoffswitch-checkbox"
              id="mashPumpSwitch"
              tabindex="0"
              v-model="pump2PowerEnabled"
            />
            <label class="onoffswitch-label" for="mashPumpSwitch">
              <span class="onoffswitch-inner"></span>
              <span class="onoffswitch-switch"></span>
            </label>
          </div>
        </div>
      </div>
  </div>
  </div>
</template>
<!--Style generated from https://proto.io/freebies/onoff/-->
<style>
.onoffswitch {
  position: relative;
  width: 185px;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
}
.onoffswitch-checkbox {
  position: absolute;
  opacity: 0;
  pointer-events: none;
}
.onoffswitch-label {
  display: block;
  overflow: hidden;
  cursor: pointer;
  border: 2px solid #999999;
  border-radius: 20px;
}
.onoffswitch-inner {
  display: block;
  width: 200%;
  margin-left: -100%;
  transition: margin 0.3s ease-in 0s;
}
.onoffswitch-inner:before,
.onoffswitch-inner:after {
  display: block;
  float: left;
  width: 50%;
  height: 49px;
  padding: 0;
  line-height: 49px;
  font-size: 26px;
  color: white;
  font-family: Trebuchet, Arial, sans-serif;
  font-weight: bold;
  box-sizing: border-box;
}
.onoffswitch-inner:before {
  content: "ON";
  padding-left: 10px;
  background-color: #ff001e;
  color: #ffffff;
}
.onoffswitch-inner:after {
  content: "OFF";
  padding-right: 10px;
  background-color: #eeeeee;
  color: #999999;
  text-align: right;
}
.onoffswitch-switch {
  display: block;
  width: 21px;
  margin: 14px;
  background: #ffffff;
  position: absolute;
  top: 0;
  bottom: 0;
  right: 132px;
  border: 2px solid #999999;
  border-radius: 20px;
  transition: all 0.3s ease-in 0s;
}
.onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-inner {
  margin-left: 0;
}
.onoffswitch-checkbox:checked + .onoffswitch-label .onoffswitch-switch {
  right: 0px;
}
</style>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop, Watch } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import { PumpHubService } from "@/core/services"
import { DxSlider } from "devextreme-vue/slider";
import { DxNumberBox } from "devextreme-vue/number-box";
import {
  DxLinearGauge,
  DxScale,
  DxLabel,
  DxValueIndicator,
} from "devextreme-vue/linear-gauge";
@Component({
  components: {
    DxSlider,
    DxNumberBox,
    DxLinearGauge,
    DxScale,
    DxLabel,
    DxValueIndicator,
  },
})
export default class PumpControllerComponent extends Vue {
  @Inject(ServiceTypes.PumpHubService)
  private pumpHubService!: PumpHubService;
  private pump1PowerEnabled: boolean = false;
  private pump2PowerEnabled: boolean = false;
  constructor() {
    super();
    this.pumpHubService.StartConnection();
  }

  created(): void {
    this.pumpHubService.SetPump1PowerStateCallback(this.receivePump1);
    this.pumpHubService.SetPump2PowerStateCallback(this.receivePump2);
  }



  private receivePump1(data: any){
    this.pump1PowerEnabled = data;
  }

  private receivePump2(data: any){
    this.pump2PowerEnabled = data;
  }

  private setPump1PowerState(){
    this.pumpHubService.SetPump1PowerState(this.pump1PowerEnabled == false);
  }

  private setPump2PowerState(){
    this.pumpHubService.SetPump2PowerState(this.pump2PowerEnabled == false);
  }
}
</script>