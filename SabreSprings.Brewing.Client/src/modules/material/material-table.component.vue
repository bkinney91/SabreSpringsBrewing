<template>
  <div style="margin-left: 15%; margin-right: 15%">
    <h1>Materials</h1>
    <DxDataGrid
      :data-source="materials"
      :show-borders="true"
      @row-inserting="add"
      @row-updating="update"
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
          <DxItem data-field="type" />
          <DxItem data-field="description" />
          <DxItem data-field="unitOfMeasure" />
        </DxForm>
      </DxEditing>
      <DxColumn data-field="description">
        <DxRequiredRule message="Description is required" />
      </DxColumn>
      <DxColumn data-field="unitOfMeasure">
        <DxRequiredRule message="Unit of Measure is required" />
      </DxColumn>
      <DxColumn data-field="type">
        <DxLookup
          :data-source="materialTypes"
          display-expr="type"
          value-expr="id"
        />
      </DxColumn>
    </DxDataGrid>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { MaterialApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { MaterialDto, MaterialTypeDto } from "@/core/models";
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
  DxLookup,
  DxPosition,
} from "devextreme-vue/data-grid";
import { DxItem } from "devextreme-vue/form";
import notify from "devextreme/ui/notify";

@Component({
  components: {
    DxDataGrid,
    DxColumn,
    DxLookup,
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
export default class MaterialTableComponent extends Vue {
  @Inject(ServiceTypes.MaterialApiService)
  private materialApiService!: MaterialApiService;

  private materials: MaterialDto[] = [];
  private materialTypes: MaterialTypeDto[] = [];

  constructor() {
    super();
  }

  created(): void {
    this.getMaterials();
    this.getMaterialTypes();
  }

  private getMaterials() {
    this.materialApiService
      .getAll()
      .then((response) => {
        this.materials = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getMaterialTypes() {
    this.materialApiService
      .getMaterialTypes()
      .then((response) => {
        this.materialTypes = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private add(e: any) {
    this.materialApiService
      .post(e.data)
      .then((response) => {
        NotifyHelper.displayMessage("Sucessfully added material.");
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private update(e: any) {
    this.materialApiService
      .put(e.oldData)
      .then((response) => {
        NotifyHelper.displayMessage("Sucessfully updated material.");
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

}
</script>