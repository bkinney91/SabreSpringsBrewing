<template>
  <div style="margin-left: 15%; margin-right: 15%">
    WHAT WHAT
    <KettleController :batch="batch" />
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