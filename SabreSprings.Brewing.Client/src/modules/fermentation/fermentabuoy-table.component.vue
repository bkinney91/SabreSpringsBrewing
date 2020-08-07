<template>
 <div style="margin-left:15%;margin-right:15%">

    <DxDataGrid
      :data-source="dataSource"
      :show-borders="true"
      key-expr="ID"
    >
      <DxEditing
        :allow-updating="true"
        mode="form"
      />
      <DxPaging :enabled="false"/>
      <DxColumn
        :width="70"
        data-field="Prefix"
        caption="Title"
      />
      <DxColumn
        data-field="FirstName"
      />
      <DxColumn
        data-field="LastName"
      />
      <DxColumn
        :width="170"
        data-field="Position"
      />
      <DxColumn
        :width="125"
        data-field="StateID"
        caption="State"
      >
        <DxLookup
          :data-source="states"
          value-expr="ID"
          display-expr="Name"
        />
      </DxColumn>
      <DxColumn
        data-field="BirthDate"
        data-type="date"
      />
      <DxColumn
        :visible="false"
        data-field="Notes"
      >
        <DxFormItem
          :col-span="2"
          :editor-options="{ height: 100 }"
          editor-type="dxTextArea"
        />
      </DxColumn>
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
import BatchTableRowComponent from "./batch-table-row.component.vue";
@Component({
  components: {
    BatchTableRowComponent
   
  }
})
export default class BatchTableComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private buoyApiService!: FermentabuoyApiService;
  private summaryRows: FermentabuoySummaryDto[] = [];
  constructor() {
    super();
  }

  created(): void {
    this.getSummary();
  }

  private getSummary(){
    this.buoyApiService
      .getSummary()
      .then(response => {
        this.summaryRows = response;
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }



}
</script>