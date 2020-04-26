<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div class="container-xl center-xy">
        <h3 class="text-center">
            <span>Admin functionality can go here</span>
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

    // ADMIN COMPONENT --------------------------
    export default class AdminComponent extends Vue {
        

        constructor() {
            super();
          
        }

        public created(): void {
            this.initializeSubscription();
        }

        public beforeDestroy(): void {
            
        }

        private initializeSubscription(): void {
           
        }
    }</script>
