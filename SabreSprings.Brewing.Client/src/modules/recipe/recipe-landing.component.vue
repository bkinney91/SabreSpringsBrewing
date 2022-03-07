<template>
  <div style="margin-left:5%;margin-right:5%">
    <h1>Recipes</h1>
    <div>
      <div class="row">
        <div class="col-md-8"></div>
        <div class="col-md-3">
         
          &nbsp;
          <button
            v-on:click="showAddRecipeModal = true"
            class="btn btn-primary"
          >Add Recipe</button>
        </div>
      </div>
      <DxPopup
        :visible.sync="showAddRecipeModal"
        :drag-enabled="false"
        :close-on-outside-click="true"
        :show-title="true"
        :width="600"
        :height="200"
        title="Add Recipe"
      >
        <div style="margin-left:5%;margin-right:5%">
          
          <div class="column">
            <div class="field">
              <div class="label">
                <b>Recipe Name</b>
              </div>
              <div class="value">
                <DxTextBox v-model="newRecipe.name" >
                  
                    </DxTextBox>
              </div>
            </div>
          </div>

          <div class="row">
            <div class="col-md-7">&nbsp;</div>
            <div class="col-md-5">
              <button
                style="margin:10px;width:75px"
                class="btn btn-success"
                v-on:click="addRecipe()"
              >Add</button>
              <button
                v-if="showAddRecipeModal != null"
                style="margin:10px;width:75px"
                class="btn btn-danger"
                v-on:click="showAddRecipeModal = false"
              >Cancel</button>
            </div>
          </div>
        </div>
      </DxPopup>
        

      
          

      <RecipeTableComponent v-if="recipes != null" :recipes="recipes" />
    </div>
  </div>
</template>


<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { RecipeApiService, BatchApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { RecipeDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import FermentabuoyTableComponent from "./fermentabuoy-table.component.vue";
import { DxTextBox } from "devextreme-vue/text-box";
import DxNumberBox from "devextreme-vue/number-box";
import { DxPopup } from "devextreme-vue/popup";
import DxSelectBox from "devextreme-vue/select-box";
import { DxPatternRule } from "devextreme-vue/validator";

@Component({
  components: {
    DxTextBox,
    DxNumberBox,
    DxPopup,
    DxSelectBox,
    DxPatternRule,
  },
})
export default class RecipeLandingComponent extends Vue {
  @Inject(ServiceTypes.RecipeApiService)
  private recipeApiService!: RecipeApiService;
  private recipes: RecipeDto[] = [];
  private newRecipe: RecipeDto | {} = {};
    private showAddRecipeModal: boolean = false;
  constructor() {
    super();
  }

  mounted(): void {
    this.getRecipes();
  }

  private getRecipes(): void {
    this.recipeApiService
      .getRecipes()
      .then((response) => {
        this.recipes = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private addRecipe(): void {
    this.recipeApiService
      .post(this.newRecipe)
      .then((response) => {
        NotifyHelper.displayMessage("Successfully added fermentabuoy");
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }
}
</script>