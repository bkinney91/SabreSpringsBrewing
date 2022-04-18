<template>
  <div style="margin-left:15%;margin-right:15%">
    <h1>Fermentation Tanks</h1>
   
     
  </div>
</template>


<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import {
  BatchApiService,
  FermentationTankApiService,
} from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import {
  FermentationTankDto,
 } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import {DxTextBox } from "devextreme-vue/text-box";
import DxNumberBox from "devextreme-vue/number-box";
import { DxPopup } from "devextreme-vue/popup";
import DxSelectBox from "devextreme-vue/select-box";
import {
  DxPatternRule, 
} from 'devextreme-vue/validator';

@Component({
  components: {
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
  @Inject(ServiceTypes.FermentationTankApiService)
  private fermentationTankApiService !: FermentationTankApiService;


  constructor() {
    super();
  }

  mounted(): void {
  
  }

}
</script>