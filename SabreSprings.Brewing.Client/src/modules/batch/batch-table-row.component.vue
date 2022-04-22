<template>
  <div v-if="batch != null">
    <div
      class="card"
      :style="'border-color:' + getColor() + ';border-top-width:5px;border-width:5px'"
      v-on:click="openBatchDetails(batch.batchId)"
    >
      <div
        class="card-header"
        :style="'border-color:' + getColor() + ';border-bottom-width: 10px'"
      >
        <h3>{{ batch.statusText }}</h3>

        <div v-if="fermentationTankDto">
          <h4 style="padding: 5px">
            {{ fermentationTankDto.volume }} gal {{ fermentationTankDto.type }} #{{
              fermentationTankDto.tankNumber
            }}
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
                new Date(batch.dateBrewed).toLocaleDateString('en-US') !== '12/31/1969'
              "
            >
              <div class="row">
                <div class="col-md-4">
                  Date Brewed:
                  {{ new Date(batch.dateBrewed).toLocaleDateString("en-US") }}
                </div>

                <div class="col-md-4"
                  v-if="
                    new Date(batch.dateBrewed).toLocaleDateString('en-US') !==
                      '12/31/1969' &&
                    brewEventService.getYeastDumpDateEnd(new Date(batch.dateBrewed)) >
                      new Date()
                  "
                >
                  Yeast Dump:
                  {{ this.brewEventService.getScheduledYeastDump(batch.dateBrewed) }}
                </div>

                <div class="col-md-4"
                  v-if="
                    new Date(batch.dateBrewed).toLocaleDateString('en-US') !==
                      '12/31/1969' &&
                    brewEventService.getColdCrashDateEnd(
                      new Date(batch.dateBrewed),
                      batch.style
                    ) > new Date()
                  "
                >
                  Cold Crash:
                  {{
                    this.brewEventService.getScheduledColdCrash(
                      batch.dateBrewed,
                      batch.style
                    )
                  }}
                </div>
              </div>
              <div class="row">
                <div class="col-md-4"
                  v-if="
                    new Date(batch.dateBrewed).toLocaleDateString('en-US') !==
                      '12/31/1969' &&
                    this.brewEventService.getForceCarbonationDateEnd(
                      new Date(batch.dateBrewed),
                      batch.style
                    ) > new Date()
                  "
                >
                  Force Carb:
                  {{
                    this.brewEventService.getScheduledForceCarbonation(
                      batch.dateBrewed,
                      batch.style
                    )
                  }}
                </div>
                <div class="col-md-4"
                  v-if="
                    batch.datePackaged !== null ||
                    new Date(batch.datePackaged).toLocaleDateString('en-US') !==
                      '12/31/1969'
                  "
                >
                  Date Packaged:
                  {{ new Date(batch.datePackaged).toLocaleDateString("en-US") }}
                </div>
                <div class="col-md-4" v-else>
                  Scheduled Package Date:
                  {{
                    this.brewEventService.getScheduledPackage(
                      batch.dateBrewed,
                      batch.style
                    )
                  }}
                </div>
              </div>
            </div>
            <div v-else>Planned</div>
          </div>
        </div>
      </div>
    </div>
    <br />
    <br />
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Prop, Inject } from "vue-property-decorator";
import {
  BatchApiService,
  BrewEventService,
  FermentationTankService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow } from "@/core/models";
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

  private getColor() {
    let color: string = "";
    if (this.batch.statusText.includes("On Tap")) {
      color = "green";
    } else if (this.batch.statusText === "Fermenting") {
      color = "red";
    } else if (this.batch.statusText === "Conditioning") {
      color = "#D2D545";
    } else if (this.batch.statusText === "Archived") {
      color = "#1369B1";
    } else if (this.batch.statusText === "Planned") {
      color = "#B11313";
    } else if (this.batch.statusText === "Souring") {
      color = "#3d004f";
    }
    return color;
  }

  private openBatchDetails(batchId: number) {
    this.$router.push("/batch/details?id=" + batchId);
  }
}
</script>
