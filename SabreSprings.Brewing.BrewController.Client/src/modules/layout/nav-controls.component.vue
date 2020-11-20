<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div id="navigationBarControlsContainer">
        <ul class="navbar-nav">
              
            
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
