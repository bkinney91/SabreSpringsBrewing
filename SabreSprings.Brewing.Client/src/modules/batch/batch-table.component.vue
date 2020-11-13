<template>
 <div style="margin-left:15%;margin-right:15%">
   <button class="btn btn-primary" v-on:click="launchEditor">Add Batch</button>
   <hr/>
   <div v-for="batch in batchTableRows" v-bind:key="batch">
     <BatchTableRowComponent :batch="batch"/>
     </div>
 </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow, BatchDto } from "@/core/models";
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
  private batch: BatchDto | null = null;
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

  private launchEditor(batchId: number) {
    this.$router.push("/batch/editor?id=0&");
  }



}
</script>