<template>
  <div style="margin-left: 10%; margin-right: 10%">
    <!--<META http-equiv="refresh" content="3600"></META> -->
    <div class="row">
      <div class="col-lg-10"><h1>On Tap</h1></div>
      <div class="col-lg-2">
        <button class="btn btn-primary float float-right" v-on:click="getOnTap()">
          Refresh
        </button>
      </div>
    </div>
    <div class="tapCard">
      <TapCardComponent
        v-if="this.taps"
        :tap="this.taps.find((x) => x.tapNumber === 1)"
      ></TapCardComponent>
    </div>
    <div class="tapCard">
      <TapCardComponent
        v-if="this.taps"
        :tap="this.taps.find((x) => x.tapNumber === 2)"
      ></TapCardComponent>
    </div>
    <div class="tapCard">
      <TapCardComponent
        v-if="this.taps"
        :tap="this.taps.find((x) => x.tapNumber === 3)"
      ></TapCardComponent>
    </div>
  </div>
</template>
<style>
.tapCard {
  height: auto;
  width: auto;
}
</style>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject } from "vue-property-decorator";
import { TapHubService, TapApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { TapDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import * as SignalR from "@microsoft/signalr";
import TapCardComponent from "./tap-card.component.vue";

@Component({
  components: {
    TapCardComponent,
  },
})
export default class OnTapComponent extends Vue {
  @Inject(ServiceTypes.TapHubService)
  private tapHubService!: TapHubService;
  @Inject(ServiceTypes.TapApiService)
  private tapApiService!: TapApiService;
  private taps: TapDto[] = [];

  constructor() {
    super();
  }

  created(): void {
    this.tapHubService.StartConnection();
    this.tapHubService.SetTapDataCallback(this.updateTapCards);
    this.getOnTap();
  }

  private updateTapCards(data: any) {
    this.taps = data;
  }

  public getOnTap() {
    this.tapApiService
      .getOnTap()
      .then((response) => {
        this.updateTapCards(response);
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private launchBatchDetails(id: number) {
    this.$router.push("/batch/details?id=" + id);
  }
}
</script>