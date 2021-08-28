<template>
  <div style="height: 100%">
    <div v-if="tap != null" style="height: 100%">
      <div class="card" style="height: 100%">
        <div class="row">
          <div class="col-lg-4">
            <img
              v-if="tap.logo"
              class="card-img-left"
              style="height: 400px; width: 400px"
              :src="'/Content/images' + tap.logo"
              alt="Card image cap"
            />
            <div v-if="!tap.logo" style="min-height: 400px"></div>
          </div>
          <div class="col-lg-8">
            <div class="card-body">
              <div class="row" style="height: 90%">
                <div class="col-md-6">
                  <h1 class="card-title">
                    <b>Tap #{{ tap.tapNumber }}</b>
                  </h1>
                  <h2>
                    {{ tap.beerDisplayName }}
                  </h2>
                  <i>
                    <h3>{{ tap.style }}</h3>
                  </i>
                  <h5>
                    <b>Batch #{{ tap.batchNumber }}</b>
                  </h5>
                  <h5>ABV: {{ tap.abv }}%</h5>
                  <h5 id="tap1PintsRemaining">
                    Approx. Pints Remaining:
                    {{ Math.round(tap.pintsRemaining * 10) / 10 }}
                  </h5>
                    <hr/>
                  <button
                    href="#"
                    class="btn btn-primary"
                    v-on:click="launchBatchDetails(tap.batchId)"
                  >
                    View Batch Details
                  </button>                
                </div>
                <div class="col-md-6" >
                  <div style="margin:10%">
                  <h3>Notes</h3>
                  <div style="min-height: 120px;">
                    <p class="card-text">{{ tap.tastingNotes }}</p>
                  </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
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
  components: {},
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