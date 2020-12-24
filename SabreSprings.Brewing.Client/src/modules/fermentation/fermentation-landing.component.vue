<template>
  <div style="margin-left:15%;margin-right:15%">
    <h1>Fermentation</h1>
    <div>
      <div class="row">
        <div class="col-md-8"></div>
        <div class="col-md-3">
          <button v-on:click="showAddBuoyModal = true" class="btn btn-primary">Add Fermentabuoy</button>
          &nbsp;
          <button
            v-on:click="showAddAssignmentModal = true"
            class="btn btn-primary"
          >Add Assignment</button>
        </div>
      </div>
      <DxPopup
        :visible.sync="showAddAssignmentModal"
        :drag-enabled="false"
        :close-on-outside-click="true"
        :show-title="true"
        :width="600"
        :height="250"
        title="Add Fermentabuoy Assignment"
      >
        <div style="margin-left:5%;margin-right:5%">
          <div class="column">
            <div class="field">
              <div class="label">
                <b>Fermentabuoy</b>
              </div>
              <div class="value">
                <DxSelectBox
                  v-if="batches != null"
                  v-model="assignment.Fermentabuoy"
                  :items="summaryRows"
                  display-expr="deviceId"
                  value-expr="id"
                />
              </div>
            </div>
          </div>
          <br />
          <div class="column">
            <div class="field">
              <div class="label">
                <b>Batch</b>
              </div>
              <div class="value">
                <DxSelectBox
                  v-if="batches != null"
                  v-model="assignment.Batch"
                  :items="batches"
                  :display-expr="showBatchForSelectBox"
                  value-expr="batchId"
                />
              </div>
            </div>
          </div>
          <div class="row">
            <div class="col-md-7">&nbsp;</div>
            <div class="col-md-5">
              <button
                style="margin:10px;width:75px"
                class="btn btn-success"
                v-on:click="addAssignment()"
              >Add</button>
              <button
                v-if="showAddAssignmentModal != null"
                style="margin:10px;width:75px"
                class="btn btn-danger"
                v-on:click="showAddAssignmentModal = false"
              >Cancel</button>
            </div>
          </div>
        </div>
      </DxPopup>

      <DxPopup
        :visible.sync="showAddBuoyModal"
        :drag-enabled="false"
        :close-on-outside-click="true"
        :show-title="true"
        :width="600"
        :height="350"
        title="Add Fermentabuoy"
      >
        <div style="margin-left:5%;margin-right:5%">
          <div class="column">
            <div class="field">
              <div class="label">
                <b>Device Number</b>
              </div>
              <div class="value">
                <DxNumberBox v-model="newBuoy.deviceNumber" />
              </div>
            </div>
          </div>
          <br />
          <div class="column">
            <div class="field">
              <div class="label">
                <b>Device Id</b>
              </div>
              <div class="value">
                <DxNumberBox v-model="newBuoy.deviceId" />
              </div>
            </div>
          </div>
          <br />
          <div class="column">
            <div class="field">
              <div class="label">
                <b>MAC Address</b>
              </div>
              <div class="value">
                <DxTextBox v-model="newBuoy.macAddress" >
                  <DxPatternRule :pattern ="macAddressRegex" message="Use valid MAC Address format"/>
                    </DxTextBox>
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-md-7">&nbsp;</div>
            <div class="col-md-5">
              <button
                style="margin:10px;width:75px"
                class="btn btn-success"
                v-on:click="addFermentabuoy()"
              >Add</button>
              <button
                v-if="showAddBuoyModal != null"
                style="margin:10px;width:75px"
                class="btn btn-danger"
                v-on:click="showAddBuoyModal = false"
              >Cancel</button>
            </div>
          </div>
        </div>
      </DxPopup>
      <FermentabuoyTableComponent v-if="summaryRows != null" :summaryRows="summaryRows" />
    </div>
  </div>
</template>


<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import {
  FermentabuoyApiService,
  BatchApiService,
  FermentabuoyAssignmentApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import {
  FermentabuoyDto,
  BatchTableRow,
  FermentabuoySummaryDto,
  FermentabuoyAssignmentDto,
} from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import FermentabuoyTableComponent from "./fermentabuoy-table.component.vue";
import {DxTextBox } from "devextreme-vue/text-box";
import DxNumberBox from "devextreme-vue/number-box";
import { DxPopup } from "devextreme-vue/popup";
import DxSelectBox from "devextreme-vue/select-box";
import {
  DxPatternRule, 
} from 'devextreme-vue/validator';

@Component({
  components: {
    FermentabuoyTableComponent,
    DxTextBox,
    DxNumberBox,
    DxPopup,
    DxSelectBox,
    DxPatternRule,
  },
})
export default class FermentabuoyLandingComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  @Inject(ServiceTypes.FermentabuoyApiService)
  private buoyApiService!: FermentabuoyApiService;
  @Inject(ServiceTypes.FermentabuoyAssignmentApiService)
  private assignmentApiService!: FermentabuoyAssignmentApiService;
  private showAddAssignmentModal: boolean = false;
  private showAddBuoyModal: boolean = false;
  private newBuoy: FermentabuoyDto | {} = {};
  private batches: BatchTableRow[] = [];
  private batch: number = 0;
  private summaryRows: FermentabuoySummaryDto[] = [];
  private assignment: FermentabuoyAssignmentDto | {} = {};
  public macAddressRegex: string = '^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$';

  constructor() {
    super();
  }

  mounted(): void {
    this.getBatches();
    this.getSummary();
  }

  private getBatches(): void {
    this.batchApiService
      .getBatchTableRows()
      .then((response) => {
        this.batches = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private addFermentabuoy(): void {
    this.buoyApiService
      .post(this.newBuoy)
      .then((response) => {
        NotifyHelper.displayMessage("Successfully added fermentabuoy");
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private addAssignment(): void {
    this.assignmentApiService
      .post(this.assignment)
      .then((response) => {
        NotifyHelper.displayMessage("Successfully added assignment");
        this.showAddAssignmentModal = false;
        this.getBatches();
        this.getSummary();
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getSummary(): void {
    this.buoyApiService
      .getSummary()
      .then((response) => {
        this.summaryRows = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private showBatchForSelectBox(item: any): string {
    return item ? `${item.beerName} Batch #${item.batchNumber}` : "";
  }
}
</script>