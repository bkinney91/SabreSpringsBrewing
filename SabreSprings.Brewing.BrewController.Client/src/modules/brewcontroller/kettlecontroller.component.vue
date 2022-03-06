<template>
  <div class="card" style="height: 100%">
    <div class="card-body">
      <div class="row">
        <div class="col-lg-10"><h2>Kettle</h2></div>
        <div class="col-lg-2">
          <div class="row">
            <div class="col-md-6">
              <button
                v-on:click="deccrementTemperature"
                class="btn btn-secondary"
                style="height: 50px; width: 100px; padding:10px"
              >
                <span class="fa fa-minus"></span>
              </button>
            </div>
            <div class="col-md-6">
              <button
                v-on:click="incrementTemperature"
                class="btn btn-secondary"
                style="height: 50px; width: 100px; padding:10px"
              >
                <span class="fa fa-plus"></span>
              </button>
            </div>
          </div>
        </div>
      </div>
      <hr />
      <div class="row">
        <div class="col-lg-10">
          <h4>Current Temperature</h4>
          <DxLinearGauge :value.sync="currentTemperature">
            <DxScale :start-value="0" :end-value="220" :tick-interval="20">
            </DxScale>
            <DxValueIndicator type="textCloud" color="#734F96" />
          </DxLinearGauge>
        </div>

        <div class="col-lg-2">
          <br />
          <h3 class="float-right">{{ this.currentTemperature }}&deg;F</h3>
        </div>
      </div>
      <div class="row">
        <div class="col-lg-10">
          <h4>Target Temperature</h4>
          <br />
          <DxSlider
            style="margin-left: 4%"
            width="92%"
            v-model:value="targetTemperature"
            :min="0"
            :max="220"
            :tooltip="{ enabled: true }"
          />
        </div>
        <div class="col-lg-2">
          <br />
          <h3 class="float-right">{{ this.targetTemperature }}&deg;F</h3>
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
import { KettleHubService } from "@/core/services";
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
export default class KettleControllerComponent extends Vue {
  @Inject(ServiceTypes.KettleHubService)
  private kettleHubService!: KettleHubService;
  private targetTemperature: number = 0;
  private pidTargetTemperature: number = 0;
  private currentTemperature: number = 0;

  constructor() {
    super();
    this.kettleHubService.StartConnection();
  }

  created(): void {
    this.kettleHubService.SetTargetTemperatureCallback(
      this.updateTargetTemperature
    );
    this.kettleHubService.SetCurrentTemperatureCallback(
      this.updateCurrentTemperature
    );
  }

  private updateTargetTemperature(temperature: number) {
    if (temperature != this.pidTargetTemperature) {
      //store new value from PID
      this.pidTargetTemperature = temperature;
      this.targetTemperature = temperature;
    } else if (
      temperature != this.targetTemperature &&
      this.targetTemperature != 0
    ) {
      this.setTemperature(this.targetTemperature);
    }
  }

  private updateCurrentTemperature(temperature: number) {
    this.currentTemperature = temperature;
  }

  private setTemperature(e: any) {
    this.kettleHubService.SetTemperature(e);
    NotifyHelper.displayMessage("Temperature has been set to " + e + "°F");
  }

  private incrementTemperature() {
    this.kettleHubService.IncrementTemperature();
    {
      NotifyHelper.displayMessage("Temperature incremented.");
    }
  }

  private deccrementTemperature() {
    this.kettleHubService.DecrementTemperature();
    {
      NotifyHelper.displayMessage("Temperature decremented.");
    }
  }
}
</script>