<template>
 <div style="margin-left:15%;margin-right:15%">
   
     <KettleController :batch="batch"/>
     
 </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import BatchTableRowComponent from "./batch-table-row.component.vue";
@Component({
  components: {
    BatchTableRowComponent
   
  }
})
export default class BrewControllerComponent extends Vue {

  constructor() {
    super();
  }

  created(): void {    
  }
}
</script>