<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
   
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">

    // IMPORTS ----------------------------------
    import { Component, Vue } from "vue-property-decorator";
    import { ApplicationSettings } from "@/core/models";
    import { AppSettingsHelper } from "../../core/helpers";
    import NavHeaderComponent from "./nav-header.component.vue";
    import NavControlsComponent from "./nav-controls.component.vue";

    @Component({
        components: {
            NavHeaderComponent, NavControlsComponent
        }
    })

    // NAV CONTAINER COMPONENT ------------------
    export default class NavContainerComponent extends Vue {
        private applicationSettings: ApplicationSettings;

        constructor() {
            super();
            this.applicationSettings = AppSettingsHelper.getSettings();
        }

        public created(): void {
            document.addEventListener("click", this.documentClick);
        }

        public destroyed(): void {
            document.removeEventListener("click", this.documentClick);
        }

        public documentClick(event: any) {
            if (!this.$el.contains(event.target) && this.show) {
                this.toggle();
            }
        }

        public show: boolean = false;

        public get appAbbreviation(): string {
            return this.applicationSettings.appAbbreviation;
        }

        public toggle(): void {
            this.show = !this.show;
        }
    }
</script>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- STYLES ----------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<style scoped>
</style>