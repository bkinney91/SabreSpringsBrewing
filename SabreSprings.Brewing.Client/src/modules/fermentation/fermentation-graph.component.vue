<template>
  <div class="row">
    <div class="col-lg-6">
      <DxChart
        id="chart"
        :data-source="logs"
        palette="Harmony Light"
        title="Gravity"
      >
        <DxCommonSeriesSettings argument-field="created" type="line" />

        <DxSeries
          name="Gravity"
          value-field="gravity"
          argument-field="created"
          type="line"
          color="red"
        />

        <DxArgumentAxis> </DxArgumentAxis>
      </DxChart>
    </div>
    <div class="col-lg-6">
      <DxChart
        id="chart"
        :data-source="logs"
        palette="Harmony Light"
        title="Temperature"
      >
        <DxCommonSeriesSettings argument-field="created" type="line" />
        <DxSeries
          name="Temperature"
          value-field="temperature"
          type="line"
          color="green"
        />

        <DxArgumentAxis> </DxArgumentAxis>
      </DxChart>
    </div>
  </div>
</template>

<script lang="ts">
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import {
  TapHubService,
  TapApiService,
  FermentabuoyLogApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { FermentabuoyLogDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import {
  DxChart,
  DxArgumentAxis,
  DxCommonSeriesSettings,
  DxLabel,
  DxLegend,
  DxSeries,
  DxTooltip,
  DxValueAxis,
  DxConstantLine,
} from "devextreme-vue/chart";
@Component({
  components: {
    DxChart,
    DxArgumentAxis,
    DxCommonSeriesSettings,
    DxLabel,
    DxLegend,
    DxSeries,
    DxTooltip,
    DxValueAxis,
    DxConstantLine,
  },
})
export default class FermentationGraphComponent extends Vue {
  @Prop() private batch!: number;
  @Inject(ServiceTypes.FermentabuoyLogApiService)
  private logApiService!: FermentabuoyLogApiService;
  private logs: FermentabuoyLogDto[] = [];
  constructor() {
    super();
  }

  created(): void {
    this.getLogs();
  }

  private getLogs() {
    this.logApiService
      .getByBatch(this.batch)
      .then((response) => {
        this.logs = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }
}
</script>