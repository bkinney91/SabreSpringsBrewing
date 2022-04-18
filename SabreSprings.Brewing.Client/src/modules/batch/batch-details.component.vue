<template>
  <div style="margin-right: 10%; margin-left: 10%">
    <ul class="nav nav-tabs" id="myTab" role="tablist">
      <li class="nav-item">
        <a
          class="nav-link active"
          id="details-tab"
          data-toggle="tab"
          href="#details"
          role="tab"
          aria-controls="details"
          aria-selected="true"
          >Details</a
        >
      </li>
      <li class="nav-item">
        <a
          class="nav-link"
          id="fermentation-tab"
          data-toggle="tab"
          href="#fermentation"
          role="tab"
          aria-controls="fermentation"
          aria-selected="false"
          >Fermentation</a
        >
      </li>
    </ul>
    <div class="tab-content" id="myTabContent">
      <div
        class="tab-pane fade show active"
        id="details"
        role="tabpanel"
        aria-labelledby="details-tab"
      >
        <div v-if="batchDetails != null">
          <div id="attributes">
            <h1 id="header" :style="'color:' + getColor(batchDetails.status)" >
              {{ beerDto.name }} - {{ beerDto.style }}
            </h1>
            <ul>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Status:</b
                >
                {{ batchDetails.status }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Batch Number:</b
                >
                {{ batchDetails.batchNumber }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)">Style:</b>
                {{ batchDetails.style }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Brewers:</b
                >
                {{ batchDetails.brewers }}
              </li>             
              <li>
                <b :style="'color:' + getColor(batchDetails.status)">Yeast:</b>
                {{ batchDetails.yeast }}
              </li>
              <li v-if="(batchDetails.status == 'Fermenting' || batchDetails.status == 'Souring' || batchDetails.status == 'Conditioning') && fermentationTankDto" >
                <b :style="'color:' + getColor(batchDetails.status)">Fermentation Tank:</b>
                {{ fermentationTankDto.volume }} gal {{fermentationTankDto.type}} #{{fermentationTankDto.tankNumber}}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Pre-boil Gravity:</b
                >
                {{ batchDetails.preBoilGravity }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Original Gravity:</b
                >
                {{ batchDetails.originalGravity }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Final Gravity:</b
                >
                {{ batchDetails.finalGravity }}
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)">ABV:</b>
                {{ batchDetails.abv }}%
              </li>
              <li>
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Date Brewed:</b
                >
                {{
                  new Date(batchDetails.dateBrewed).toLocaleDateString("en-US")
                }}
              </li>
              <li
                v-if="
                  new Date(batchDetails.datePackaged).toLocaleDateString(
                    'en-US'
                  ) !== '12/31/1969'
                "
              >
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Date Packaged:</b
                >
                {{
                  new Date(batchDetails.datePackaged).toLocaleDateString(
                    "en-US"
                  )
                }}
              </li>
              <li
                v-if="
                  new Date(batchDetails.dateTapped).toLocaleDateString(
                    'en-US'
                  ) !== '12/31/1969'
                "
              >
                <b :style="'color:' + getColor(batchDetails.status)"
                  >Date Tapped:</b
                >
                {{
                  new Date(batchDetails.dateTapped).toLocaleDateString("en-US")
                }}
              </li>
            </ul>
            <div>
              <h3 :style="'color:' + getColor(batchDetails.status)">
                Brewing Notes
              </h3>
              <p style="padding-left: 30px; white-space: pre-line">
                {{ batchDetails.brewingNotes }}
              </p>
            </div>
            <div>
              <h3 :style="'color:' + getColor(batchDetails.status)">
                Tasting Notes
              </h3>
              <p style="padding-left: 30px; white-space: pre-line">
                {{ batchDetails.tastingNotes }}
              </p>
            </div>
            <div class="row">
              <br />
              <a
                :href="'/batch/editor?id=' + batchDetails.id"
                class="btn btn-primary"
                onclick="goToEditor(batchDetails.id)"
                >Edit</a
              >
            </div>
          </div>
        </div>
      </div>
      <div
        class="tab-pane fade"
        id="fermentation"
        role="tabpanel"
        aria-labelledby="fermentation-tab"
      >
        <FermentationGraphComponent :batch="batchDetails.id" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject } from "vue-property-decorator";
import {
  BatchApiService,
  FermentationTankApiService,
  BeerApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchDto, BeerDto, FermentationTankDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import FermentationGraphComponent from "../fermentation/fermentation-graph.component.vue";
@Component({
  components: { FermentationGraphComponent },
})
export default class BatchDetailsComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  @Inject(ServiceTypes.FermentationTankApiService)
  private fermentationTankApiService!: FermentationTankApiService;
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  private batchDetails!: BatchDto | null;
  private fermentationTankDto!: FermentationTankDto | null;
  private beerDto!: BeerDto | null;

  constructor() {
    super();
    this.batchDetails = null;
    this.beerDto = null;
    this.fermentationTankDto = null;
  }

  created(): void {
    this.getBatchDetails(+this.$route.query.id);    
  }

  private getBatchDetails(id: number) {
    this.batchApiService
      .getBatchDetails(id)
      .then((response) => {
        this.batchDetails = response;
        this.getBeer(response.beer);
        if (response.style == "Fermenting") {
          this.getFermentationTank(response.fermentationTank);
      }
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
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

  private getBeer(id: number){
    this.beerApiService
      .get(id)
      .then((response) => {
        this.beerDto = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getColor(statusText: string) {
    return AppSettingsHelper.getStatusColor(statusText);
  }

  private goToEditor(batchId: number) {
    this.$router.push("/batch/editor?id=" + batchId);
  }
}
</script>