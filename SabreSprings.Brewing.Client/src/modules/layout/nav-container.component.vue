<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div>
        <div id="navContainer">
            <!-- NavBar Navigation Start -->
            <nav class="navbar navbar-expand-lg">
                <div id="navBarBrandContainer">
                    <a href="#"
                       class="hamburger-menu"
                       id="sidebarToggle"
                       v-on:click="toggle"
                       v-bind:class="{ 'active': show}">
                        <i class="fa fa-bars"></i>
                        <i class="fal fa-times"></i>
                    </a>
                    <router-link to="/"
                                 class="navbar-brand"
                                 id="homePageLink"
                                 data-toggle="tooltip"
                                 v-bind:title="appAbbreviation">{{ appAbbreviation }}</router-link>
                </div>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <div class="mr-auto">
                        <NavHeaderComponent></NavHeaderComponent>
                    </div>
                    <div>
                        <NavControlsComponent></NavControlsComponent>
                    </div>
                </div>
            </nav>
            <!-- NavBar Navigation End -->
        </div>
        <div id="sidebarContainer" ref="sidebarContainer" v-bind:class="{ 'active': show }">
            <!-- SideNav Navigation Start -->

            <div id="sideNav" class="panel-group sidebar-nav">
                
              
                <div class="d-xs-block d-md-block d-lg-none">
                    <NavHeaderComponent></NavHeaderComponent>
                </div>
                <div class="d-xs-block d-md-block d-lg-none">
                    <NavControlsComponent></NavControlsComponent>
                </div>
            </div>
            <!-- SideNav Navigation End -->
        </div>
    </div>
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