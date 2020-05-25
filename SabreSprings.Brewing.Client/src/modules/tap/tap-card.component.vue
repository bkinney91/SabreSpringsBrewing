<template>
<div class="col-lg-6">
        <div id="tap1">
          <div style="min-height:700px;max-height:710px;" class="card">
            <img
              class="card-img-top"
              style="max-height:400px;width:auto"
              id="tap1Logo"
              :src="'/Content/images' + tap1.logo"
              alt="Card image cap"
            />
            <div class="card-body">
              <h4 class="card-title" id="tap1BeerDisplayName">{{tap1.beerDisplayName}}</h4>
              <i>
                <h5 id="tap1Style">{{tap1.style}}</h5>
              </i>
              <h6><b><i>Batch #{{tap1.batchNumber}}</i></b></h6>
              <h6 id="tap1ABV">ABV: {{tap1.abv}}%</h6>
              <h6
                id="tap1PintsRemaining"
              >Approx. Pints Remaining: {{Math.round(tap1.pintsRemaining *10) / 10}}</h6>
              <div style="min-height:120px">
                <p id="tap1TastingNotes" class="card-text">{{tap1.tastingNotes}}</p>
              </div>
              <button
                href="#"
                id="tap1Details"
                class="btn btn-primary"
                v-on:click="launchBatchDetails(tap1.batchId)"
              >View Batch Details</button>
            </div>
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
@Component({
  components: {}
})
export default class OnTapComponent extends Vue {
  @Inject(ServiceTypes.TapHubService)
  private tapHubService!: TapHubService;
  @Inject(ServiceTypes.TapApiService)
  private tapApiService!: TapApiService;
  private tap: TapDto[] = [];
  constructor() {
    super();
  }

  created(): void {
    this.tapHubService.SetTapDataCallback(this.showTapCards);
    this.getOnTap();
  }

  private showTapCards(data: any) {
    this.taps = data;
    this.tap1 = this.taps.find(x => x.tapNumber === 1);
    this.tap2 = this.taps.find(x => x.tapNumber === 2);
  }

  private getOnTap() {
    this.tapApiService
      .getOnTap()
      .then(response => {
        this.showTapCards(response);
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