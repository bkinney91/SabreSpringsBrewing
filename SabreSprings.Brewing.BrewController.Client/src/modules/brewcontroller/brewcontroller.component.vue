<template>
  <div style="height:100%;overflow:hidden;margin:1%;">
    <h1>SSB&E Automated Brewing Control Center</h1>
    <hr/>
    <div class="row">
      <div class="col-lg-12">
      <KettleController />
      </div>
      </div>
      <div class="row">
      <div class="col-lg-6">
        <MashMonitor/>
      </div>
      <div class="col-lg-6">
        <PumpController/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import KettleController from "./kettlecontroller.component.vue";
import PumpController from "./pumpcontroller.component.vue";
import MashMonitor from "./mashmonitor.component.vue";

export default defineComponent({
  components: {
    KettleController,
    MashMonitor,
    PumpController,
  }
});
</script>