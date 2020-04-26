<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div id="navMenuContainer">
        <ul class="navbar-nav">            
            <li class="nav-item dropdown d-sm-none d-md-none d-lg-block d-xl-block">
                <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Automation
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    <router-link class="dropdown-item" to="/material/master">On Tap</router-link>
                </div>
            </li>
                        
            <li class="nav-item dropdown d-sm-none d-md-none d-lg-block d-xl-block">
                <a class="nav-link dropdown-toggle" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Beers
                </a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                    <router-link class="dropdown-item" to="/template/master">Batches</router-link>
                    <router-link class="dropdown-item" to="/template/master">Fermentation Log</router-link>
                </div>
            </li>           
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
