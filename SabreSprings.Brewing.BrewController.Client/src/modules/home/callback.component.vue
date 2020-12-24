<!-- ------------------------------------------------------------------------------------------ -->
<!-- TEMPLATE --------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<template>
    <div class="container-xl">Processing authorization. Please wait.</div>
</template>


<!-- ------------------------------------------------------------------------------------------ -->
<!-- SCRIPTS ---------------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------------------------ -->
<script lang="ts">

    // IMPORTS ----------------------------------
    import { Component, Inject, Vue } from "vue-property-decorator";
    import Router from "@/router";
    import { ServiceTypes } from "../../core/symbols";
    import { NotifyHelper } from "@/core/helpers";

    @Component({})

    // CALLBACK COMPONENT -----------------------
    export default class CallbackComponent extends Vue {
        public created(): void {
            
        }
    }
</script>
