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
      <hr/>
      <h1 v-if="this.batchId == false">Add new batch</h1>
     
      <div class="row">
        <div class="col-lg-6" v-if="this.batchId == false">
           <h5>Select a beer</h5>
          <DxSelectBox
            v-if="beers"
            :items="beers"
            :value.sync="batch.beer"
            value-expr="id"
            display-expr="name"
          />
        </div>
        <div class="col-lg-6" v-if="this.batchId">
          <h5>Status</h5>
          <DxSelectBox            
            :items="['Planned', 'Fermenting', 'Conditioning', 'On Tap', 'Archived']"
            :value.sync="batch.status"
          
          />
        </div>
        <div class="col-lg-6" v-if="this.batchId">
          <h5>Substatus</h5>
          <DxTextBox            
           :value.sync="batch.subStatus"         
          />
        </div>
      </div>
      <hr />
      <h5>Details</h5>
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
import { BatchApiService, BeerApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchDto, BeerDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import { DxForm, DxItem, DxGroupItem } from "devextreme-vue/form";
import { DxTextArea } from "devextreme-vue/text-area";
import DxSelectBox from "devextreme-vue/select-box";
import DxTextBox from 'devextreme-vue/text-box';
@Component({
  components: {
    DxForm,
    DxItem,
    DxTextArea,
    DxGroupItem,
    DxSelectBox,
    DxTextBox
  },
})
export default class BatchEditorComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  private beers: BeerDto[] = [];
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
    } else {
      this.getBeers();
    }
  }

  private getBeers() {
    this.beerApiService
      .getAll()
      .then((response) => {
        this.beers = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
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