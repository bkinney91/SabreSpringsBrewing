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
                <ul class="navbar-nav">
                    <li class="nav-item dropdown d-sm-none d-md-none d-lg-block d-xl-block">
                        <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Example
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <router-link class="dropdown-item" to="/organization">Manage Organizations</router-link>
                        </div>
                    </li>
                     <li class="nav-item dropdown d-sm-none d-md-none d-lg-block d-xl-block">
                        <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Stuff
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <router-link class="dropdown-item" to="/Project">Manage Projects</router-link>
                        </div>
                    </li>
                    <li class="nav-item dropdown d-sm-none d-md-none d-lg-block d-xl-block" >
                        <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Here
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                            <router-link class="dropdown-item" to="/Vendor">Manage Vendors</router-link>
                        </div>
                    </li>
                </ul>   
              
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