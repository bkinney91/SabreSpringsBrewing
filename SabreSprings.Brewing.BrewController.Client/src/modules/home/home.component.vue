<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
  <div style="margin-left:5%; margin-right:5%">

   <BrewControllerComponent></BrewControllerComponent>
  </div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">
// IMPORTS ----------------------------------
import { Component, Inject, Vue } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { ApplicationConstants } from "@/core/services";
import { Subscription } from "rxjs";
import { ApplicationSettings } from "@/core/models";
import { NotifyHelper, AppSettingsHelper } from "@/core/helpers";
import BrewControllerComponent from "../brewcontroller/brewcontroller.component.vue";

@Component({
  components: {
    BrewControllerComponent
   
  }
})

// HOME COMPONENT ---------------------------
export default class HomeComponent extends Vue {
  private subscription: Subscription;
  private ticket: string = "";
  private appSettings!: ApplicationSettings;

  public isLoggedIn: boolean = false;
  public hasPermission: boolean = false;
  public name: string = "";

  constructor() {
    super();
    this.subscription = new Subscription();
  }

  created(): void {
    this.appSettings = AppSettingsHelper.getSettings();
  }

  beforeDestroy(): void {
    this.subscription.unsubscribe();
  }

  get appDescription(): string {
    return this.appSettings.appDescription;
  }

  get appName(): string {
    return this.appSettings.appName;
  }

  get appIcon(): string {
    return "fas " + this.appSettings.appIcon;
  }
}
</script>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- STYLES ----------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<style lang="scss" scoped>
.jumbotron {
  /* Permalink - use to edit and share this gradient: https://colorzilla.com/gradient-editor/#484b50+1,565a5e+61,484b50+88 */
  background: #484b50; /* Old browsers */
  background: -moz-linear-gradient(
    left,
    #484b50 1%,
    #565a5e 61%,
    #484b50 88%
  ); /* FF3.6-15 */
  background: -webkit-linear-gradient(
    left,
    #484b50 1%,
    #565a5e 61%,
    #484b50 88%
  ); /* Chrome10-25,Safari5.1-6 */
  background: linear-gradient(
    to right,
    #484b50 1%,
    #565a5e 61%,
    #484b50 88%
  ); /* W3C, IE10+, FF16+, Chrome26+, Opera12+, Safari7+ */
  filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#484b50', endColorstr='#484b50',GradientType=1 ); /* IE6-9 */
  color: #fff;
  box-shadow: 0px 3px 8px #ccc;
  border-radius: 0.5rem;
  padding: 9rem 2rem;

  h1 {
    padding-right: 5rem;
    border-right: 1px solid #fff;
  }

  .action-container {
    padding-left: 5rem;

    #applicationName {
      font-size: 1.5rem;
      font-style: italic;
      font-weight: bold;
    }

    #userContainer {
      position: absolute;
      top: 0.5rem;
      right: 2rem;
      text-align: right;

      a {
        color: #4faeff;
      }
    }

    .btn-group {
      margin-left: 6rem;
      &.show {
        .btn-outline-light {
        }
      }
    }
  }
}
</style>
