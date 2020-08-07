<template>
    <div style="margin-left:15%;margin-right:15%">
        <h1>Fermentation</h1>
        <div>
            <FermentabuoyTableComponent />
        </div>
    </div>
</template>


<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { FermentabuoyApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { FermentabuoySummaryDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import FermentabuoyTableComponent from "./fermentabuoy-table.component.vue";
@Component({
  components: {
    FermentabuoyTableComponent
   
  }
})
export default class FermentabuoyLandingComponent extends Vue {


  constructor() {
    super();
  }

  created(): void {
 
  }
}
</script>