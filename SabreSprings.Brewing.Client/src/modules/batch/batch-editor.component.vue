<template>
  <div v-if="batch != null">
    <div style="margin-left: 15%; margin-right: 15%" id="attributes">
      <h1
        v-if="this.batchId"
        id="header"
        :style="'color:' + getColor(batch.status)"
      >
        {{ beerName }} Batch #{{ batch.batchNumber }}
      </h1>
      <h1 v-if="this.batchId == false">Add new batch</h1>
      <DxForm id="form" :form-data="batch" label-location="top" col-count="3">
        <DxItem data-field="brewers" name="Brewers" />
        <DxItem data-field="yeast" />
        <DxItem data-field="abv" editor-type="dxNumberBox" />
        <DxItem data-field="preBoilGravity" editor-type="dxNumberBox" />
        <DxItem data-field="originalGravity" editor-type="dxNumberBox" />
        <DxItem data-field="finalGravity" editor-type="dxNumberBox" />
        <DxItem data-field="dateBrewed" editor-type="dxDateBox" />
        <DxItem data-field="datePackaged" editor-type="dxDateBox" />
        <DxItem data-field="dateTapped" editor-type="dxDateBox" />
        <DxGroupItem col-span="3" caption="Notes">
          <DxItem
            data-field="brewingNotes"
            editor-type="dxTextArea"
            :col-span="3"
          />
          <DxItem
            data-field="tastingNotes"
            editor-type="dxTextArea"
            :col-span="3"
          />
        </DxGroupItem>
      </DxForm>
      <button class="btn btn-danger" v-on:click="cancel()">Cancel</button>
      <button
        v-if="batchId"
        style="margin: 10px; width: 75px"
        class="btn btn-success float-right"
        v-on:click="updateBatch()"
      >
        Update
      </button>
      <button
        v-if="this.batchId == false"
        style="margin: 10px; width: 75px"
        class="btn btn-success float-right"
        v-on:click="addBatch()"
      >
        Add
      </button>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import { DxForm, DxItem, DxGroupItem } from "devextreme-vue/form";
import { DxTextArea } from "devextreme-vue/text-area";

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
  private batch: BatchDto = <BatchDto>{};
  private batchId: number | null = null;
  private beerName: string = "";
  
  constructor() {
    super();
  }

  created(): void {
    this.batchId = +this.$route.query.id;
    if (this.batchId != 0) {
      this.getBatch(this.batchId);
    }
  }

  private getBatch(id: number) {
    this.batchApiService
      .get(id)
      .then((response) => {
        this.batch = response;
        this.getBatchDetails(id);
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getBatchDetails(id: number) {
    this.batchApiService
      .getBatchDetails(id)
      .then((response) => {
        this.beerName = response.beer;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private updateBatch() {
    this.batchApiService
      .put(this.batch)
      .then((response) => {
        NotifyHelper.displayMessage("Updated batch");
        this.$router.go(-1);
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private addBatch() {
    this.batchApiService
      .post(this.batch)
      .then((response) => {
        NotifyHelper.displayMessage("Added batch");
        this.$router.go(-1);
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getColor(status: string): string {
    return AppSettingsHelper.getStatusColor(status);
  }

  private cancel() {
    this.$router.push("/batch/details?id=" + this.batchId);
  }
}
</script>