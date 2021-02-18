<template>
  <div style="margin-left: 5%; margin-right: 5%">
    <h2>{{ beer.name }} Recipe</h2>
    <hr />
    <div class="row">
      <table class="table" style="border-color: grey; border: 1px">
        <colgroup>
          <col style="width: 33%" />
          <col style="width: 33%" />
          <col style="width: 33%" />
        </colgroup>
        <tbody>
          <tr>
            <td>Yeast: {{ recipe.yeast }}</td>
            <td>Boil Time: {{ recipe.boilTime }}</td>
            <td>ABV: {{ recipe.abv }}</td>
          </tr>
          <tr>
            <td>Preboil Gravity: {{ recipe.preBoilGravity }}</td>
            <td>Original Gravity: {{ recipe.originalGravity }}</td>
            <td>Final Gravity: {{ recipe.finalGravity }}</td>
          </tr>
          <tr>
            <td>IBU: {{ recipe.ibu }}</td>
            <td>SRM: {{ recipe.srm }}</td>
            <td>Mash PH: {{ recipe.mashPh }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="row">
      <nav>
        <div class="nav nav-tabs" id="nav-tab" role="tablist">
          <a
            class="nav-item nav-link active"
            id="nav-home-tab"
            data-toggle="tab"
            href="#nav-home"
            role="tab"
            aria-controls="nav-home"
            aria-selected="true"
            >Home</a
          >
          <a
            class="nav-item nav-link"
            id="nav-profile-tab"
            data-toggle="tab"
            href="#nav-profile"
            role="tab"
            aria-controls="nav-profile"
            aria-selected="false"
            >Profile</a
          >
          <a
            class="nav-item nav-link"
            id="nav-contact-tab"
            data-toggle="tab"
            href="#nav-contact"
            role="tab"
            aria-controls="nav-contact"
            aria-selected="false"
            >Contact</a
          >
        </div>
      </nav>
      <div class="tab-content" id="nav-tabContent">
        <div
          class="tab-pane fade show active"
          id="nav-home"
          role="tabpanel"
          aria-labelledby="nav-home-tab"
        >
          ...
        </div>
        <div
          class="tab-pane fade"
          id="nav-profile"
          role="tabpanel"
          aria-labelledby="nav-profile-tab"
        >
          ...
        </div>
        <div
          class="tab-pane fade"
          id="nav-contact"
          role="tabpanel"
          aria-labelledby="nav-contact-tab"
        >
          ...
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
table td {
  font-weight: bold;
  text-align: center;
}
</style>
<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject } from "vue-property-decorator";
import { BeerApiService, RecipeApiService } from "@/core/services";
import { ServiceTypes } from "@/core/symbols";
import { BeerDto, RecipeDto } from "@/core/models";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {},
})
export default class BatchDetailsComponent extends Vue {
  @Inject(ServiceTypes.BeerApiService)
  private beerApiService!: BeerApiService;
  @Inject(ServiceTypes.RecipeApiService)
  private recipeApiService!: RecipeApiService;
  private beer!: BeerDto | null;
  private recipe!: RecipeDto | null;
  constructor() {
    super();
    this.beer = null;
    this.recipe = null;
  }

  created(): void {
    this.getBeer(+this.$route.query.id);
    this.getRecipeFromBeer(+this.$route.query.id);
  }

  private getBeer(id: number) {
    this.beerApiService
      .get(id)
      .then((response) => {
        this.beer = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private getRecipeFromBeer(id: number) {
    this.recipeApiService
      .getFromBeer(id)
      .then((response) => {
        this.recipe = response;
      })
      .catch((error) => {
        NotifyHelper.displayError(error);
      });
  }

  private goToEditor(batchId: number) {
    this.$router.push("/batch/editor?id=" + batchId);
  }
}
</script>