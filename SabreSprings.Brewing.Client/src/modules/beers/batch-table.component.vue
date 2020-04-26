<template>
 
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {
   
  }
})
export default class BatchTableComponent extends Vue {
  @Inject(ServiceTypes.BatchApiService)
  private componentApiService!: BatchApiService;
  constructor() {
    super();
  }

  created(): void {
    
  }

  



}
</script>