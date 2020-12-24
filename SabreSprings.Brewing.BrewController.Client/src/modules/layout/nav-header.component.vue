<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div id="navMenuContainer">
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

    @Component({})

    // NAV HEADER COMPONENT ---------------------
    export default class NavHeaderComponent extends Vue {
       

        private subscription: Subscription;

        constructor() {
            super();
            this.subscription = new Subscription();
        }

        public created(): void {
            
        }

        public destroyed(): void {
            this.subscription.unsubscribe();
        }

    }
</script>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- STYLES ----------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<style lang="scss">

    #navMenuContainer {
        .nav-item.dropdown {
            a: not([href]):not([tabindex]):hover, a:not([href]):not([tabindex]):focus {
                text-decoration: none;
            }
        }
    }

</style>
