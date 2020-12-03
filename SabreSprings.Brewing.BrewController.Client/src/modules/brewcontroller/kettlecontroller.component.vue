<template>
  <div>
    <h2>Kettle</h2>
    <div class="row">
      <div class="col-lg-7">
        <h4>Current Temperature</h4>
        <DxLinearGauge :value.sync="currentTemperature">
          <DxScale :start-value="0" :end-value="220" :tick-interval="20">
            <DxLabel :customize-text="customizeText" />
          </DxScale>
          <DxValueIndicator type="textCloud" color="#734F96" />
        </DxLinearGauge>
      </div>
    
   <div class="col-lg-2">
        <h3>{{ this.currentTemperature }}&deg;F</h3>
      </div>
</div>
    <div class="row">
      <div class="col-lg-7">
        <h4>PID Value</h4>
        <br>
        <DxSlider
        style="margin-left:6%"
        width="95%"
          v-model:value="temperatureGoal"
          :min="0"
          :max="220"
          :tooltip="{ enabled: true }"
        />
      </div>
      <div class="col-lg-4">
        <h3>{{ this.temperatureGoal }}&deg;F</h3>
      </div>
    </div>
    <div class="row">HUD</div>
  </div>
</template>



<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

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
  private temperatureGoal: number = 0;
  private currentTemperature: number = 220;
  constructor() {
    super();
  }

  created(): void {}
}
</script>