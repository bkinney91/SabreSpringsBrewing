<template>
  <div style="margin-left:15%;margin-right:15%">
    <h1>Fermentation</h1>
    <div>
      <button v-on:click="showAddAssignmentModal = true">Add Assignment</button>
      <DxPopup
        :visible.sync="showAddAssignmentModal"
        :drag-enabled="false"
        :close-on-outside-click="true"
        :show-title="true"
        :width="600"
        :height="350"
        title="Add Fermentabuoy Assignment"
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
                <DxNumberBox v-model="newBuoy.macAddress" />
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
              >Yes</button>
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

      <FermentabuoyTableComponent />
    </div>
  </div>
</template>


<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { FermentabuoyApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { FermentabuoyDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import FermentabuoyTableComponent from "./fermentabuoy-table.component.vue";
import DxTextBox from "devextreme-vue/text-box";
import DxNumberBox from "devextreme-vue/number-box";
import { DxPopup } from "devextreme-vue/popup";

@Component({
  components: {
    FermentabuoyTableComponent,
    DxTextBox,
    DxNumberBox,
    DxPopup,
  },
})
export default class FermentabuoyLandingComponent extends Vue {
  private showAddAssignmentModal: boolean = false;
  private newBuoy: FermentabuoyDto | {} = {};
  constructor() {
    super();
  }

  created(): void {}
}
</script>