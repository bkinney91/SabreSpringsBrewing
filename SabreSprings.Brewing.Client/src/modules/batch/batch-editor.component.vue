<template>
  <div  v-if="batchDetails != null">
    <div style="margin-left:15%;margin-right:15%" id="attributes">
      <h1 id="header" :style="'color:' + getColor(batchDetails.status)">{{batchDetails.beer}}</h1>
      <DxForm
        id="form"
        :form-data="batchDetails"
        :read-only="batchDetails.status !== 'Archived'"        
        label-location="top"        
        col-count="3"
        >
        <DxItem data-field="brewers" name="Brewers"/>
        </DxForm>
        
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
import { DxForm, DxItem } from 'devextreme-vue/form';

@Component({
  components: {
      DxForm,
      DxItem
  }
})
export default class BatchEditorComponent extends Vue {
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