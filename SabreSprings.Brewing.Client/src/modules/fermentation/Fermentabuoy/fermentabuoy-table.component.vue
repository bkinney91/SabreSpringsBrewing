<template>
  <div style="margin-left:15%;margin-right:15%">
    <h3>Fermentabuoys</h3>
    <DxDataGrid
      id="grid-container"
      :data-source="summaryRows"
      :column-auto-width="true"
      :show-borders="true"
      key-expr="id"
      @row-updating="updateFermentabuoy"
      @editor-preparing="editingStartCheck"
    >
      <DxEditing :allow-updating="true" mode="form">
        <DxPosition my="top" at="top" of="window" />
        <DxForm>
          <DxItem data-field="deviceNumber" />
          <DxItem data-field="deviceId" />
          <DxItem data-field="macAddress" />
        </DxForm>
      </DxEditing>
      <DxColumn data-field="deviceNumber" caption="Device Number" />
      <DxColumn data-field="deviceId" caption="Device ID" />
      <DxColumn data-field="macAddress" />
      <DxColumn data-field="assignedBeerName" caption="Current Assignment" />
      <DxColumn
        data-type="date"
        display-format="short"
        data-field="assignmentDate"
        caption="Date Assigned"
      />
    </DxDataGrid>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { FermentabuoyApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { FermentabuoySummaryDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import { DxItem } from 'devextreme-vue/form';
import {
  DxDataGrid,
  DxColumn,
  DxPaging,
  DxEditing,
  DxPosition,
  DxForm
} from "devextreme-vue/data-grid";
@Component({
  components: {
    DxDataGrid,
    DxColumn,
    DxPaging,
    DxEditing,
    DxPosition,
    DxForm,
    DxItem
  }
})
export default class FermentabuoyTableComponent extends Vue {
  @Inject(ServiceTypes.FermentabuoyApiService)
  private buoyApiService!: FermentabuoyApiService;
  @Prop() private summaryRows!: FermentabuoySummaryDto[];

  constructor() {
    super();
  }

  created(): void {
    
  }



  private editingStartCheck(e: any): void {
    if (
      (e.dataField === "assignmentDate" ||
        e.dataField === "assignedBeerName") &&
      e.parentType === "dataRow"
    ) {
      e.editorOptions.disabled = true;
    }
  }

  private updateFermentabuoy(data: any): void { 
    this.buoyApiService
      .put(data.oldData)
      .then(Response => {
        NotifyHelper.displayMessage("Successfully updated Fermentabuoy");
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }
}
</script>