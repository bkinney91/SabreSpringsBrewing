<template>
  <div style="margin-top: 5%" class="card">
    <div class="card-body">
      <div class="row">
        <div class="col-lg-10"><h2>Mash Tank</h2></div>
      </div>

      <div class="row">
        <div class="col-lg-12">
          <DxCircularGauge id="gauge" v-model:value="mashTemperature">
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
import { defineComponent } from "vue";
import { ServiceTypes } from "@/core/symbols";
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
import { configureContainer } from "@/configure-container";

const mashHubService = configureContainer().get<MashHubService>(ServiceTypes.MashHubService);

export default defineComponent({
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
  data() {
    return { mashTemperature: 0 };
  },
  async created() {
    await mashHubService.StartConnection();
    mashHubService.SetTemperatureCallback((temperature: number) => this.updateTemperature(temperature));
  },
  methods: {
    updateTemperature(temperature: number) {
      if (temperature < 0 || temperature > 1000) {
        this.mashTemperature = 0;
        return;
      }
      this.mashTemperature = this.roundToOne(temperature);
    },
    roundToOne(value: number): number {
      return Number(value.toFixed(1));
    }
  }
});
</script>