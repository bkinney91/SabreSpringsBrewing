<template>
  <div style="margin-top: 5%" class="card">
    <div class="card-body">
      <div class="row">
        <div class="col-lg-10"><h2>Mash Tank</h2></div>
      </div>

      <div class="row">
        <div class="col-lg-12">
          <DxCircularGauge id="gauge" :value.sync="mashTemperature">
            <DxScale :start-value="120" :end-value="180" :tick-interval="10">
              <DxLabel :use-range-colors="true" />
            </DxScale>
            <DxRangeContainer palette="Pastel">
              <DxRange :start-value="0" :end-value="140" />
              <DxRange :start-value="140" :end-value="160" />
              <DxRange :start-value="160" :end-value="180" />
            </DxRangeContainer>
            <DxTitle :text="mashTemperature + '°F'">
              <DxFont :size="28" />
            </DxTitle>
          </DxCircularGauge>
        </div>
      </div>
    </div>
  </div>
</template>


<!--Style generated from https://proto.io/freebies/onoff/-->


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
import {
  DxCircularGauge,
  DxRangeContainer,
  DxRange,
  DxTitle,
  DxFont,
} from "devextreme-vue/circular-gauge";
import { MashHubService } from "@/core/services";
@Component({
  components: {
    DxSlider,
    DxNumberBox,
    DxLinearGauge,
    DxScale,
    DxLabel,
    DxValueIndicator,
    DxCircularGauge,
    DxRangeContainer,
    DxRange,
    DxTitle,
    DxFont
  },
})
export default class MashMonitorComponent extends Vue {
  @Inject(ServiceTypes.MashHubService)
  private mashHubService!: MashHubService;
  private mashTemperature: number = 0;
  constructor() {
    super();
    this.mashHubService.StartConnection();
  }

  created(): void {
    this.mashHubService.SetTemperatureCallback(this.updateTemperature);
   
    }

    private updateTemperature(temperature: number){
      this.mashTemperature  = temperature;
    }
}
</script>