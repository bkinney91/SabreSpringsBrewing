<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div class="container-xl center-xy">
        <h3 class="text-center">
            <span>This is your new template component</span>
        </h3>
    </div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">

    // IMPORTS ----------------------------------
    import Vue from "vue";
    import { Component, Inject } from "vue-property-decorator";
    import { Subscription } from "rxjs";
    import { ServiceTypes } from "../../core/symbols";

    @Component({})

    // TEMPLATE COMPONENT -----------------------
    export default class AdminComponent extends Vue {
       
        private subscription: Subscription;

        constructor() {
            super();
            this.subscription = new Subscription();
        }

        public created(): void {
            this.initializeSubscription();
        }

        public beforeDestroy(): void {
            this.subscription.unsubscribe();
        }

        private initializeSubscription(): void {
            
        }
    }
</script>
