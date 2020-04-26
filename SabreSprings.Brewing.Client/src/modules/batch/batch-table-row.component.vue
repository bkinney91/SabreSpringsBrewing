<template>
  <div
    class="card"
    style="border-color:{{color}};border-top-width:5px;border-width:5px"
    :onclick="openBatchDetails()"
  >
    <div
      class="card-header"
      style="border-color:{{color}};border-bottom-width: 10px"
    >{{batch.statusText}}</div>
    <div class="card-body">
      <h5 class="card-title">{{batch.beerName}} Batch #{{batch.batchNumber}}</h5>
      <h6 class="card-subtitle mb-2 text-muted">{{batch.style}}</h6>
      <p class="card-text">
        Date Brewed: {{batch.dateBrewed}}
        <br />
        Date Packaged: {{batch.datePackaged}}
        <br />
      </p>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Prop } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BatchTableRow } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {}
})
export default class BatchTableComponent extends Vue {
  @Prop() private batch!: BatchTableRow;
  constructor() {
    super();
  }

  created(): void {}
}
</script>