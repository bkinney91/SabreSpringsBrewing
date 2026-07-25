<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
   <div>
       </div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">
    import { defineComponent } from "vue";
    import { AppSettingsHelper } from "../../core/helpers";
    import NavHeaderComponent from "./nav-header.component.vue";
    import NavControlsComponent from "./nav-controls.component.vue";

    export default defineComponent({
        components: {
            NavHeaderComponent, NavControlsComponent
        },
        data() {
            return {
                applicationSettings: AppSettingsHelper.getSettings(),
                show: false
            };
        },
        mounted() {
            document.addEventListener("click", this.documentClick);
        },
        beforeUnmount() {
            document.removeEventListener("click", this.documentClick);
        },
        methods: {
          documentClick(event: MouseEvent) {
            if (!this.$el.contains(event.target) && this.show) {
                this.toggle();
            }
          },
          toggle() {
            this.show = !this.show;
          }
        }
    });
</script>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- STYLES ----------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<style scoped>
</style>