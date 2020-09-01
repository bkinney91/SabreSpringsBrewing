<template>
  <div v-if="batchDetails != null">
    <div style="margin-left:15%;margin-right:15%" id="attributes">
      <h1 id="header" :style="'color:' + getColor(batchDetails.status)">{{batchDetails.beer}}</h1>
      <DxForm id="form" :form-data="batchDetails" label-location="top" col-count="3">
        <DxItem data-field="brewers" name="Brewers" />
        <DxItem data-field="yeast" />
        <DxItem data-field="ABV" editor-type="dxNumberBox" />
        <DxItem data-field="preBoilGravity" editor-type="dxNumberBox" />
        <DxItem data-field="originalGravity" editor-type="dxNumberBox" />
        <DxItem data-field="finalGravity" editor-type="dxNumberBox" />        
        <DxItem data-field="dateBrewed" editor-type="dxDateBox" />
        <DxItem data-field="datePackaged" editor-type="dxDateBox" />
        <DxItem data-field="dateTapped" editor-type="dxDateBox" />
        <DxGroupItem col-span="3" caption= "Notes">
        <DxItem data-field="brewingNotes" editor-type="dxTextArea" :col-span="3" />
        <DxItem data-field="tastingNotes" editor-type="dxTextArea" :col-span="3" />
        </DxGroupItem>
      </DxForm>
      <button class="btn btn-danger"
                    v-on:click="cancel()"
                    >Cancel</button>
      <button
                style="margin:10px;width:75px"
                class="btn btn-success float-right"
                v-on:click="updateBatch()"
              >Update</button>
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
import { DxForm, DxItem, DxGroupItem } from "devextreme-vue/form";
import { DxTextArea } from 'devextreme-vue/text-area';

@Component({
  components: {
    DxForm,
    DxItem,
    DxTextArea,
    DxGroupItem,
  },
})
export default class BatchEditorComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  private batchDetails!: BatchDetailsDto | null;
  private batchId!: number;
  constructor() {
    super();
    this.batchDetails = null;
  }

  created(): void {
    this.batchId = +this.$route.query.id;
    this.getBatchDetails(this.batchId);
  }

  private getBatchDetails(id: number) {
    this.batchApiService
      .getBatchDetails(id)
      .then((response) => {
        this.batchDetails = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private updateBatch(){
    this.batchApiService
      .put(this.batchDetails)
      .then((response) => {
        this.batchDetails = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getColor(status: string): string{
    return AppSettingsHelper.getStatusColor(status);
  }

  private cancel(){
    this.$router.push("/batch/details?id=" + this.batchId);
  }
}
</script>