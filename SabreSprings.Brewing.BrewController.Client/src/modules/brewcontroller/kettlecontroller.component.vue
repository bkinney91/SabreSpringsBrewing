<template>
 <div >
   hey hey
     
     
 </div>
</template>



<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";

@Component({
  components: {
  }
})
export default class KettleControllerComponent extends Vue {

  constructor() {
    super();
  }

  created(): void {    
  }
}
</script>