<template>
  <div v-if="batch != null" style="padding: 30px">
    <div
      class="card"
      :style="
        'border-color:' + getColor() + ';border-top-width:5px;border-width:5px'
      "
      v-on:click="openBatchDetails(batch.batchId)"
    >
      <div
        class="card-header"
        :style="'border-color:' + getColor() + ';border-bottom-width: 10px'"
      >
        <h3>{{ batch.statusText }}</h3>

        <div v-if="fermentationTankDto">
          <h4 style="padding: 5px">
            {{ fermentationTankDto.volume }} gal
            {{ fermentationTankDto.type }} #{{ fermentationTankDto.tankNumber }}
          </h4>
        </div>
      </div>

      <div class="card-body">
        <div class="row">
          <div class="col-lg-2">
            <img
              v-if="batch.logo"
              style="max-height: 100px; max-width: 100px"
              :src="'/Content/images' + batch.logo"
              alt="Card image cap"
            />
          </div>
          <div class="col-lg-10">
            <h5 class="card-title">
              {{ batch.beerName }} Batch #{{ batch.batchNumber }}
            </h5>
            <h6 class="card-subtitle mb-2 text-muted">{{ batch.style }}</h6>
            <div
              class="card-text"
              v-if="
                batch.dateBrewed !== null ||
                new Date(batch.dateBrewed).toLocaleDateString('en-US') !==
                  '12/31/1969'
              "
            >
              <table class="table">
                <tr>
                  <th>Date Brewed:</th>
                  <th v-if="showYeastDump()">Yeast Dump</th>
                  <th v-if="showDryHop()">Dry Hop</th>
                  <th v-if="showColdCrash()">Cold Crash</th>
                  <th v-if="showForceCarbonation()">Force Carb</th>
                  <th>Package Date</th>
                </tr>
                <tr>
                  <td>
                    {{ new Date(batch.dateBrewed).toLocaleDateString("en-US") }}
                  </td>
                  <td v-if="showYeastDump()">
                    {{
                      this.brewEventService.getScheduledYeastDump(
                        batch.dateBrewed
                      )
                    }}
                  </td>
                  <td v-if="showDryHop()">
                    {{
                      this.brewEventService.getScheduledDryHop(batch.dateBrewed)
                    }}
                  </td>
                  <td v-if="showColdCrash()">
                    {{
                      this.brewEventService.getScheduledColdCrash(
                        batch.dateBrewed,
                        batch.style
                      )
                    }}
                  </td>
                  <td v-if="showForceCarbonation()">
                    {{
                      this.brewEventService.getScheduledForceCarbonation(
                        batch.dateBrewed,
                        batch.style
                      )
                    }}
                  </td>
                  <td
                    v-if="
                      batch.datePackaged !== null ||
                      new Date(batch.datePackaged).toLocaleDateString(
                        'en-US'
                      ) !== '12/31/1969'
                    "
                  >
                    {{
                      new Date(batch.datePackaged).toLocaleDateString("en-US")
                    }}
                  </td>
                  <td
                    v-if="
                      batch.datePackaged == null ||
                      new Date(batch.datePackaged).toLocaleDateString(
                        'en-US'
                      ) == '12/31/1969'
                    "
                  >
                    {{
                      this.brewEventService.getScheduledPackage(
                        batch.dateBrewed,
                        batch.style
                      )
                    }}
                  </td>
                </tr>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Prop, Inject } from "vue-property-decorator";
import {
  BatchApiService,
  BrewEventService,
  FermentationTankApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow, FermentationTankDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {},
})
export default class BatchTableRowComponent extends Vue {
  @Inject(ServiceTypes.BrewEventService)
  private brewEventService!: BrewEventService;
  @Inject(ServiceTypes.FermentationTankApiService)
  private fermentationTankApiService!: FermentationTankApiService;
  @Prop() private batch!: BatchTableRow;
  private fermentationTankDto!: FermentationTankDto | null;
  constructor() {
    super();
    this.fermentationTankDto = null;
  }

  created(): void {
    if (this.batch.fermentationTank != 0) {
      if (
        this.batch.statusText == "Fermenting" ||
        this.batch.statusText == "Conditioning" ||
        this.batch.statusText == "Souring"
      ) {
        this.getFermentationTank(this.batch.fermentationTank);
      }
    }
  }

  private getFermentationTank(id: number) {
    this.fermentationTankApiService
      .get(id)
      .then((response) => {
        this.fermentationTankDto = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

   private getColor(statusText: string) {
    return AppSettingsHelper.getStatusColor(statusText);
  }

  private openBatchDetails(batchId: number) {
    this.$router.push("/batch/details?id=" + batchId);
  }

  private showYeastDump() {
    return (
      new Date(this.batch.dateBrewed).toLocaleDateString("en-US") !==
        "12/31/1969" &&
      this.brewEventService.getYeastDumpDateEnd(this.batch.dateBrewed) >
        new Date()
    );
  }

  private showColdCrash() {
    return (
      new Date(this.batch.dateBrewed).toLocaleDateString("en-US") !==
        "12/31/1969" &&
      this.brewEventService.getColdCrashDateEnd(
        this.batch.dateBrewed,
        this.batch.style
      ) > new Date()
    );
  }

  private showForceCarbonation() {
    return (
      new Date(this.batch.dateBrewed).toLocaleDateString("en-US") !==
        "12/31/1969" &&
      this.brewEventService.getForceCarbonationDateEnd(
        this.batch.dateBrewed,
        this.batch.style
      ) > new Date()
    );
  }

  private showDryHop() {
    return (
      this.batch.style.includes("IPA") &&
      new Date(this.batch.dateBrewed).toLocaleDateString("en-US") !==
        "12/31/1969" &&
      this.brewEventService.getDryHopDateEnd(this.batch.dateBrewed) > new Date()
    );
  }
}
</script>
