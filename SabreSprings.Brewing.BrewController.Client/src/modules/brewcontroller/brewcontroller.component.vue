<template>
  <div>
    <h1>SSB&E Automated Brewing Control Center</h1>
    <hr/>
    <div class="row">
      <div class="col-md-6">
        <KettleController />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import KettleController from "./kettlecontroller.component.vue";
@Component({
  components: {
    KettleController,
  },
})
export default class BrewControllerComponent extends Vue {
  constructor() {
    super();
  }

  created(): void {}
}
</script>