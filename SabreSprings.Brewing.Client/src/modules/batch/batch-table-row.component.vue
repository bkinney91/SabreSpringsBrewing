<template>
  <div v-if="batch != null">
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
        {{ batch.statusText }}
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
          <div class="colg-log-10">
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
              <div>
                Date Brewed:
                {{ new Date(batch.dateBrewed).toLocaleDateString("en-US") }}
              </div>
             
              <div
                v-if="
                  batch.datePackaged !== null ||
                  new Date(batch.datePackaged).toLocaleDateString('en-US') !==
                    '12/31/1969'
                "
              >
                Date Packaged:
                {{ new Date(batch.datePackaged).toLocaleDateString("en-US") }}
              </div>
              <div v-else>
                Scheduled Package Date:
                {{
                  getScheduledPackageDate(batch.dateBrewed).toLocaleDateString(
                    "en-US"
                  )
                }}
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
import { Vue, Component, Prop } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {},
})
export default class BatchTableRowComponent extends Vue {
  @Prop() private batch!: BatchTableRow;
  constructor() {
    super();
  }

  created(): void {}

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
    }
    return color;
  }

  private getScheduledPackageDate(dateBrewed: Date): Date | null {
    let scheduledPackageDate: Date;
    scheduledPackageDate = new Date(dateBrewed);
    scheduledPackageDate.setDate(scheduledPackageDate.getDate() + 28);
    return scheduledPackageDate;
  }

  private openBatchDetails(batchId: number) {
    this.$router.push("/batch/details?id=" + batchId);
  }
}
</script>