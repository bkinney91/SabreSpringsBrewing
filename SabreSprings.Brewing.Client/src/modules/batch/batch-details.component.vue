<template>
  <div  v-if="batchDetails != null">
    <div style="margin-left:15%;margin-right:15%" id="attributes">
      <h1 id="header" :style="'color:' + getColor(batchDetails.status)">{{batchDetails.beer}}</h1>
      <ul>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Batch Number:</b>
          {{batchDetails.batchNumber}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Style:</b>
          {{batchDetails.style}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Brewers:</b>
          {{batchDetails.brewers}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Recipe:</b>
          {{batchDetails.recipe}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Yeast:</b>
          {{batchDetails.yeast}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Pre-boil Gravity:</b>
          {{batchDetails.preboilGravity}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Original Gravity:</b>
          {{batchDetails.OriginalGravity}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Final Gravity:</b>
          {{batchDetails.finalGravity}}
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">ABV:</b>
          {{batchDetails.abv}}%
        </li>
        <li>
          <b :style="'color:' + getColor(batchDetails.status)">Date Brewed:</b>
          {{new Date(batchDetails.dateBrewed).toLocaleDateString('en-US')}}
        </li>
        <li v-if="new Date(batchDetails.datePackaged).toLocaleDateString('en-US') !== '12/31/1969'">
          <b :style="'color:' + getColor(batchDetails.status)">Date Packaged:</b>
          {{new Date(batchDetails.datePackaged).toLocaleDateString('en-US')}}
        </li>
        <li v-if="new Date(batchDetails.dateTapped).toLocaleDateString('en-US') !== '12/31/1969'">
          <b :style="'color:' + getColor(batchDetails.status)">Date Tapped:</b>
          {{new Date(batchDetails.dateTapped).toLocaleDateString('en-US')}}
        </li>
      </ul>
      <div>
        <h3 :style="'color:' + getColor(batchDetails.status)">Brewing Notes</h3>
        <p style="padding-left:30px;white-space:pre-line">{{batchDetails.brewingNotes}}</p>
      </div>
       <div>
        <h3 :style="'color:' + getColor(batchDetails.status)">Tasting Notes</h3>
        <p style="padding-left:30px;white-space:pre-line">{{batchDetails.tastingNotes}}</p>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchDetailsDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {}
})
export default class BatchDetailsComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  private batchDetails!: BatchDetailsDto | null;
  constructor() {
    super();
    this.batchDetails = null;
  }

  created(): void {
    this.getBatchDetails(+this.$route.query.id);
  }

  private getBatchDetails(id: number) {
    this.batchApiService
      .getBatchDetails(id)
      .then(response => {
        this.batchDetails = response;
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }

  private getColor(statusText: string) {
    let color: string = "";
    if (statusText != null && statusText.includes("On Tap")) {
      color = "green";
    } else if (statusText === "Fermenting") {
      color = "red";
    } else if (statusText === "Conditioning") {
      color = "#D2D545";
    } else if (statusText === "Archived") {
      color = "#1369B1";
    } else if (statusText === "Planned") {
      color = "#B11313";
    }
    return color;
  }
}
</script>