<template>
  <div>
    <div class="card">
      <img
        class="card-img-top"
        style="max-height:400px;width:auto"
        :src="'/Content/images' + tap.logo"
        alt="Card image cap"
      />
      <div class="card-body">
        <h4 class="card-title">{{tap.beerDisplayName}}</h4>
        <i>
          <h5>{{tap.style}}</h5>
        </i>
        <h6>
          <b>
            <i>Batch #{{tap.batchNumber}}</i>
          </b>
        </h6>
        <h6>ABV: {{tap.abv}}%</h6>
        <h6
          id="tap1PintsRemaining"
        >Approx. Pints Remaining: {{Math.round(tap.pintsRemaining *10) / 10}}</h6>
        <div style="min-height:120px">
          <p class="card-text">{{tap.tastingNotes}}</p>
        </div>
        <button
          href="#"
          class="btn btn-primary"
          v-on:click="launchBatchDetails(tap.batchId)"
        >View Batch Details</button>
      </div>
    </div>
  </div>
</template>



<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { TapHubService, TapApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { TapDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import * as SignalR from "@microsoft/signalr";
@Component({
  components: {}
})
export default class TapCardComponent extends Vue {
  @Prop() public tap!: TapDto;
  constructor() {
    super();
  }

  created(): void {}

  private launchBatchDetails(id: number) {
    this.$router.push("/batch/details?id=" + id);
  }
}
</script>