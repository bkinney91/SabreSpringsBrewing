<template>
 <div style="margin-left:15%;margin-right:15%">
   <div v-for="batch in batchTableRows">
     <BatchTableRowComponent :batch="batch"/>
     </div>
 </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import BatchTableRowComponent from "./batch-table-row.component.vue";
@Component({
  components: {
    BatchTableRowComponent
   
  }
})
export default class BatchTableComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private batchApiService!: BatchApiService;
  private batchTableRows: BatchTableRow[] = [];
  constructor() {
    super();
  }

  created(): void {
    this.getTableRows();
  }

  private getTableRows(){
    this.batchApiService
      .getBatchTableRows()
      .then(response => {
        this.batchTableRows = response;
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }



}
</script>