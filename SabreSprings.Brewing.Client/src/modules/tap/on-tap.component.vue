<template>
  <div style="margin-left:10%;margin-right:10%">
    <META http-equiv="refresh" content="3600"></META>
    <h1>On Tap</h1>
    <div class="row">
      <div v-for="tap in taps" class="col-md-4" v-bind:key="tap">
        <TapCardComponent :tap="tap"></TapCardComponent>
      </div>
    </div>
  </div>
</template>

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
    TapCardComponent
  }
})
export default class OnTapComponent extends Vue {
  @Inject(ServiceTypes.TapHubService)
  private tapHubService!: TapHubService;
  @Inject(ServiceTypes.TapApiService)
  private tapApiService!: TapApiService;
  private taps: TapDto[] = [];

  constructor() {
    super();
    this.tapHubService.StartConnection();
  }

  created(): void {
    this.tapHubService.SetTapDataCallback(this.updateTapCards);
    this.getOnTap();
  }

  private updateTapCards(data: any) {
    this.taps = data;
  }

  private getOnTap() {
    this.tapApiService
      .getOnTap()
      .then(response => {
        this.updateTapCards(response);
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }

  private launchBatchDetails(id: number) {
    this.$router.push("/batch/details?id=" + id);
  }
}
</script>