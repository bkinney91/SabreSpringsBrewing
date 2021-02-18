<template>
<div style="margin-left:5%;margin-right:5%">
  <h2>{{beer.name}} Recipe</h2>
  </div>
</template>

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
        this.beer = response;
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