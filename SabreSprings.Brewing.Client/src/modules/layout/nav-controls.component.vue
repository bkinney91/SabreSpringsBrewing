<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div id="navigationBarControlsContainer">
        <ul class="navbar-nav">
            <li class="nav-item dropdown" v-if="isLoggedIn">
                <a id="customShortcutButton1" class="nav-link dropdown-toggle nav-bar-button" href="#" data-toggle="dropdown">
                    <i class="fab fa-buffer"></i>
                </a>
                
            </li>
            <NavUserComponent></NavUserComponent>
        </ul>
    </div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">

    // IMPORTS ----------------------------------
    import { Component, Vue, Inject } from "vue-property-decorator";
    import { ServiceTypes } from "@/core/symbols";
    import { Subscription } from "rxjs";
    import { AppSettingsHelper } from "../../core/helpers";

    @Component({
        components: {
            
        }
    })

    // NAV CONTROLS CONTAINER COMPONENT ---------
    export default class NavControlsContainerComponent extends Vue {
       
       
       

        constructor() {
            super();
          
        }

        public created(): void {
           
            let settings = AppSettingsHelper.getSettings();
           
        }

        public destroyed(): void {
            
        }

        public isLoggedIn: boolean = false;
    }
</script>
