<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div id="app">
        <NavigationComponent></NavigationComponent>
        <!--Main Outlet-->
        <div id="bodyComponent">
            <router-view></router-view>
        </div>
      
    </div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">

    // IMPORTS ----------------------------------
    import Router from "./router";
    import
    {
       BatchApiService
    } from "@/core/services";
    import { ServiceTypes } from "@/core/symbols";
    import NavigationComponent from "@/modules/layout/nav-container.component.vue";
    import { configureContainer } from "@/configure-container";
    import { Inject, Component, Vue } from "vue-property-decorator";
import { Template } from 'devextreme/core/templates/template';

    // VARIABLES --------------------------------
    let container = configureContainer();

    @Component({
        components:
        {
            NavigationComponent,
            
        },
        provide:
        {
            [ServiceTypes.Container]: container,
            [ServiceTypes.BatchApiService]: container.get<BatchApiService>(ServiceTypes.BatchApiService),
            
        }
    })

    // APP --------------------------------------
    export default class App extends Vue {

        constructor()
        {
            super();
        }

    }
</script>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- STYLES ----------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<style lang="scss">
    

    #bodyComponent {
        padding-top: 70px;
        padding-bottom: 70px;
    }

    .container-lg,
    .container-xl {
        width: 100%;
        padding-right: 15px;
        padding-left: 15px;
        margin-right: auto;
        margin-left: auto;
    }

    @media (min-width: 992px) {
        .container-lg {
            max-width: 960px;
        }
    }

    @media (min-width: 1200px) {
        .container-lg,
        .container-xl {
            max-width: 1140px;
        }
    }

    @media (min-width: 1440px) {
        .d-laptop-lg-none {
            display: none !important;
        }

        .d-laptop-lg-inline {
            display: inline !important;
        }

        .d-laptop-lg-inline-block {
            display: inline-block !important;
        }

        .d-laptop-lg-block {
            display: block !important;
        }

        .d-laptop-lg-table {
            display: table !important;
        }

        .d-laptop-lg-table-row {
            display: table-row !important;
        }

        .d-laptop-lg-table-cell {
            display: table-cell !important;
        }

        .d-laptop-lg-flex {
            display: -ms-flexbox !important;
            display: flex !important;
        }

        .d-laptop-lg-inline-flex {
            display: -ms-inline-flexbox !important;
            display: inline-flex !important;
        }
    }

    #browserBanner {
        position: absolute;
        left: 50%;
        -webkit-transform: translateX(-50%);
        -ms-transform: translateX(-50%);
        transform: translate(-50%);
        background-color: rgb(255, 239, 193);
        position: fixed;
        top: 50px;
        z-index: 1000;
        padding: 0.35rem 0.75rem;
    }

    /* Errors for Jquery validation
    .form-group label.error {
        color: $color-danger;
    }
    */
    /* Scroll to top button */
    button.app-root.scroll-to-top-command {
        //z-index: calc(#{$z-index-layout} - 1);
        display: none;
        position: fixed;
        //bottom: calc(#{$footer-height} + 10px);
        left: 10px;
        //background: $color-bg-light;
    }

    /* Form validator color fix */
    .form-control.is-invalid {
       // border-color: $color-danger;
    }

    .input-invalid {
        //border-color: $color-danger !important;
        outline: 0 !important;
        -webkit-box-shadow: none !important;
        box-shadow: none !important;
    }

    .input-required {
       // color: $color-danger !important;
        padding-left: 0.25rem;
    }

    /* Tooltip flickering issue fix */
    .tooltip {
        pointer-events: none;
    }
</style>
