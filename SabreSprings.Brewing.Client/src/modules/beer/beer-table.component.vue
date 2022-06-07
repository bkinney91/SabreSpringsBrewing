<template>
  <div style="margin-left: 15%; margin-right: 15%">
    <h1>Beers</h1>
    <DxDataGrid
      :data-source="beers"
      :show-borders="true"
      @row-inserting="addBeer"
      @row-updating="updateBeer"
      key-expr="id"
      :selection="{ mode: 'single' }"
      :hover-state-enabled="true"
    >
      <DxHeaderFilter :visible="true" />
      <DxSearchPanel :visible="true" />
      <DxEditing
        :allow-updating="true"
        :allow-deleting="false"
        :allow-adding="true"
        mode="form"
      >
        <DxForm>
          <DxItem data-field="name" />
          <DxItem data-field="style" />
          <DxItem data-field="suggestedGlassType" />
          <DxItem data-field="logo" />
        </DxForm>
      </DxEditing>
      <DxColumn data-field="name">
        <DxRequiredRule message="Name is required" />
      </DxColumn>
      <DxColumn data-field="style">
        <DxRequiredRule message="Style is required" />
      </DxColumn>
      <DxColumn data-field="suggestedGlassType"> </DxColumn>
      <DxColumn data-field="logo"/>
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
import notify from 'devextreme/ui/notify';

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
  },
})
export default class BaeerTableComponent extends Vue {
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  private newBeer: BeerDto = <BeerDto>{};
  private beers: BeerDto[] = [];
  constructor() {
    super();
  }

  created(): void {
    this.getBeers();
  }

  private getBeers() {
    this.beerApiService
      .getAll()
      .then((response) => {
        this.beers = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private addBeer(e: any) {
    this.beerApiService
      .post(e.data)
      .then((response) => {
        NotifyHelper.displayMessage("Sucessfully added beer.")
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private updateBeer(e: any) {
    console.log("beer", e.oldData);
    const model = <BeerDto>({
      id : e.oldData.id,
    name: e.newData.name ? e.newData.name : e.oldData.name,
    style: e.newData.style ? e.newData.style :  e.oldData.style,
    logo: e.newData.logo ? e.newData.logo : e.oldData.logo,
    suggestedGlassType: e.newData.suggestedGlassType ? e.newData.suggestedGlassType : e.oldData.suggestedGlassType
    
 });
 console.log("model", model);
    this.beerApiService
      .put(model)
      .then((response) => {
        NotifyHelper.displayMessage("Sucessfully updated beer.")
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }
}
</script>