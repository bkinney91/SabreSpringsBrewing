<template>
<div style="margin-left:15%;margin-right:15%">
     <h1> Beers</h1>
     <DxDataGrid
        :data-source="beers"
        :show-borders="true"
        key-expre="id"
        :selection="{mode: 'single'}"
        :hover-state-enabled="true"
     >
     <DxHeaderFilter :visible="true"/>
     <DxSearchPanel :visible="true"/>
     <DxEditing :allow-updating="true" :allow-deleting="false" :allow-adding="true" mode="popup">
         <DxForm>
            <DxItem data-field="name"/>
        <DxItem data-field="style"/>
        <DxItem data-field="suggestedGlassType"/>
        <DxItem data-field="logo"/>
        </DxForm>
        </DxEditing>
        <DxColumn data-field="name">
            <DxRequiredRule message="Name is required"/>
        </DxColumn>
          <DxColumn data-field="style">
            <DxRequiredRule message="Style is required"/>
        </DxColumn>
          <DxColumn data-field="suggestedGlassType">            
        </DxColumn>        
     </DxDataGrid>
     </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { BeerApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BeerDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import {
    DxDataGrid,
    DxColumn,
    DxEditing,
    DxRequiredRule,
    DxPopup,
    DxForm,
    DxHeaderFilter,
    DxSearchPanel,
    DxPosition,
} from "devextreme-vue/data-grid";
import { DxItem } from "devextreme-vue/form";


@Component({
  components: {
       DxDataGrid,
    DxColumn,
    DxEditing,
    DxRequiredRule,
    DxPopup,
    DxForm,
    DxHeaderFilter,
    DxSearchPanel,
    DxPosition,
DxItem,
   
  }
})
export default class BaeerTableComponent extends Vue {
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  private newBeer: BeerDto = <BeerDto>{};
  private beers: BeerDto[] =[];
  constructor() {
    super();
  }

  created(): void {
    this.getBeers();
  }

  private getBeers(){
    this.beerApiService
      .getAll()
      .then(response => {
        this.beers = response;
      })
      .catch(error => {
        NotifyHelper.displayError(error);
      });
  }





}
</script>