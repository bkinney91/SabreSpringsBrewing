<template>
  <div v-if="batch != null">
    <div style="margin-left: 15%; margin-right: 15%" id="attributes">
      <h1
        v-if="this.batchId"
        id="header"
        :style="'color:' + getColor(batch.status)"
      >
        {{ this.beer.name }} Batch #{{ batch.batchNumber }}
      </h1>
      <hr />
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
            :items="[
              'Planned',
              'Fermenting',
              'Souring',
              'Conditioning',
              'On Tap',
              'Archived',
            ]"
            :value.sync="batch.status"
          />
        </div>
        <div
          class="col-lg-6"
          v-if="
            this.batch.status == 'Fermenting' ||
            this.batch.status == 'Conditioning' ||
            this.batch.status == 'Souring'
          "
        >
          <h5>Fermentation Tank</h5>
          <DxSelectBox
            v-if="fermentationTanks != null"
            v-model="batch.fermentationTank"
            :items="fermentationTanks"
            :display-expr="showTankForSelectBox"
            value-expr="id"
          />
        </div>
      </div>
      <hr />
      <h5>Details</h5>
      <DxForm id="form" :form-data="this.batch" label-location="top" col-count="3">      
        <DxItem data-field="brewers" name="Brewers" />
        <DxItem data-field="yeast" />
        <DxItem data-field="abv" editor-type="dxNumberBox" />
        <DxItem data-field="preBoilGravity" editor-type="dxNumberBox" />
        <DxItem data-field="originalGravity" editor-type="dxNumberBox" />
        <DxItem data-field="finalGravity" editor-type="dxNumberBox" />
        <DxItem data-field="dateBrewed" editor-type="dxDateBox" />
        <DxItem data-field="datePackaged" editor-type="dxDateBox" />
        <DxItem data-field="dateTapped" editor-type="dxDateBox" />
        <DxItem
          v-if="this.batch.status == 'On Tap'"
          data-field="tapNumber"
          editor-type="dxNumberBox"         
        />
      
        <DxGroupItem :col-span="3" caption="Notes">
          <DxItem
            data-field="brewingNotes"
            editor-type="dxTextArea"
            :editor-options="{ height: 300}"
          />
          <DxItem
            data-field="tastingNotes"
            editor-type="dxTextArea"
            :editor-options="{ height: 300 }"
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
import {
  BatchApiService,
  BeerApiService,
  FermentationTankApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchDto, BeerDto, FermentationTankDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import { DxForm, DxItem, DxGroupItem } from "devextreme-vue/form";
import { DxTextArea } from "devextreme-vue/text-area";
import DxSelectBox from "devextreme-vue/select-box";
import DxTextBox from "devextreme-vue/text-box";
@Component({
  components: {
    DxForm,
    DxItem,
    DxTextArea,
    DxGroupItem,
    DxSelectBox,
    DxTextBox,
  },
})
export default class BatchEditorComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  @Inject(ServiceTypes.FermentationTankApiService)
  private fermentationTankApiService!: FermentationTankApiService;
  private beers: BeerDto[] = [];
  private batch: BatchDto = <BatchDto>{};
  private beer: BeerDto = <BeerDto>{};
  private fermentationTanks: FermentationTankDto[] = [];
  private fermentationTankDto!: FermentationTankDto | null;
  private batchId: number | null = null;


  constructor() {
    super();
  }


  created(): void {
    this.getFermentationTanks();
    this.batchId = +this.$route.query.id;
    if (this.batchId != 0) {
      this.getBatch(this.batchId);

    } else {
      this.getBeers();
    
    }
  }

 private getBeer(id: number) {
    this.beerApiService
      .get(id)
      .then((response) => {
        this.beer = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
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
        this.getBeer(this.batch.beer);
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getFermentationTanks() {
    this.fermentationTankApiService
      .getAll()
      .then((response) => {
        this.fermentationTanks = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private updateBatch() {
    console.log("dis batch", this.batch);
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

  private showTankForSelectBox(item: any): string {
    return item ? `${item.volume} gal ${item.type} #${item.tankNumber}` : "";
  }

  private getColor(status: string): string {
    return AppSettingsHelper.getStatusColor(status);
  }

  private cancel() {
    this.$router.push("/batch/details?id=" + this.batchId);
  }
}
</script>