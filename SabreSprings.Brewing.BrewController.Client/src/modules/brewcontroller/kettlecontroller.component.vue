<template>
 <div >
   
     <KettleController :batch="batch"/>
     
 </div>
</template>
<style scoped>
body {
	background-color: #CCCCCC;
}

#thermostat {
	width: 50vmin;
	height: 50vmin;
	margin: 0 auto;
	-webkit-tap-highlight-color: rgba(0,0,0,0);
}

.dial {
	user-select: none;
	&.away {
		.dial {
			&__ico__leaf {
				visibility: hidden;
			}
			&__lbl--target {
				visibility: hidden;
				&--half {
					visibility: hidden;
				}
			}
			&__lbl--away {
				opacity: 1;
			}
		}
	}
	.dial__shape {
		transition: fill 0.5s;
	}
	&__ico__leaf {
		fill : #13EB13;
		opacity: 0;
		transition: opacity 0.5s;
		pointer-events: none;
	}
	&.has-leaf {
		.dial__ico__leaf {
			display: block;
			opacity: 1;
			pointer-events: initial;
		}
	}
	&__editableIndicator {
		fill: white;
		fill-rule: evenodd;
		opacity: 0;
		transition: opacity 0.5s;
	}
	&--edit {
		.dial__editableIndicator {
			opacity: 1;
		}
	}
	&--state {
		&--off {
			.dial__shape {
				fill: #222;
			}
		}
		&--heating {
			.dial__shape {
				fill: #E36304;
			}
		}
		&--cooling {
			.dial__shape {
				fill: #007AF1;
			}
		}
	}
	&__ticks {
		path {
			fill: rgba(255,255,255,0.3);
			&.active {
				fill: rgba(255,255,255,0.8);
			}
		}
	}
	text {
		fill: white;
		text-anchor: middle;
		font-family: Helvetica,sans-serif;
		alignment-baseline: central;
	}
	&__lbl {
		&--target {
			font-size: 120px;
			font-weight: bold;
			&--half {
				font-size: 40px;
				font-weight: bold;
				opacity: 0;
				transition: opacity 0.1s;
				&.shown {
					opacity: 1;
					transition: opacity 0s;
				}
			}
		}
		&--ambient {
			font-size: 22px;
			font-weight: bold;
		}
		&--away {
			font-size: 72px;
			font-weight: bold;
			opacity: 0;
			pointer-events: none;
		}
	}
}


#controls {
	font-family: Open Sans;
	label {
		text-align: left;
		display: block;
		span {
			display: inline-block;
			width: 200px;
			text-align: right;
			font-size: 0.8em;
			text-transform: uppercase;
		}
	}
	p {
		margin: 0;
		margin-bottom: 1em;
		padding-bottom: 1em;
		border-bottom: 2px solid #ccc;
	}
	background-color: rgba(255,255,255,0.25);
	padding: 20px;
	border-radius: 5px;
	position: absolute;
	left: 50%;
	transform: translatex(-50%);
	margin-top: 20px;
}
</style>

<script lang="ts">
// IMPORTS ----------------------------------
import { Vue, Component, Inject, Prop } from "vue-property-decorator";
import { ServiceTypes } from "@/core/symbols";
import { AppSettingsHelper, NotifyHelper } from "@/core/helpers";
import BatchTableRowComponent from "./batch-table-row.component.vue";
@Component({
  components: {
    BatchTableRowComponent
   
  }
})
export default class BrewControllerComponent extends Vue {

  constructor() {
    super();
  }

  created(): void {    
  }
}
</script>