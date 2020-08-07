<template>
  <DxChart
    id="chart"
    :data-source="dataSource"
    palette="Harmony Light"
    title="Fermentation  Chart"
  >
    <DxCommonSeriesSettings argument-field="created" type="line" />
    <DxSeries
      name="Temperature"
      value-field="temperature"
      type="line"
      color="#fac29a"
    />
    <DxSeries
      name="Gravity"
      value-field="gravity"
      type="line"
      color="red"
    />

    <DxSeries
      name="Battery"
      value-field="battery"
      type="line"
      color="green"
    />

    <DxArgumentAxis>
      
    </DxArgumentAxis>


    
    <DxLegend
      vertical-alignment="top"
      horizontal-alignment="center"
    />
  </DxChart>
</template>

<script lang="ts">
import { Vue, Component, Inject } from "vue-property-decorator";
import { TapHubService, TapApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { TapDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import DxChart, {
  DxArgumentAxis,
  DxCommonSeriesSettings,
  DxLabel,
  DxLegend,
  DxSeries,
  DxTooltip,
  DxValueAxis,
  DxConstantLine
} from 'devextreme-vue/chart';


export default class FermentationGraphComponent extends Vue {
    
 constructor() {
    super();

  }

  created(): void {

  }
}
</script>