import Vue from "vue";
import Router from "vue-router";
import HomeComponent from "./modules/home/home.component.vue";
import UserComponent from "./modules/home/user.component.vue";
import CallbackComponent from "./modules/home/callback.component.vue";
import NotFoundComponent from "./modules/home/not-found.component.vue";
import ProcessingComponent from "./modules/home/processing.component.vue";
import AdminComponent from "./modules/main/admin.component.vue";
import TemplateComponent from "./modules/main/template.component.vue";
import BatchTableComponent from "./modules/batch/batch-table.component.vue";
import BatchDetailsComponent from "./modules/batch/batch-details.component.vue";
import OnTapComponent from "./modules/tap/on-tap.component.vue";
import FermentationLandingComponent from "./modules/fermentation/fermentation-landing.component.vue";
import BatchEditorComponent from "./modules/batch/batch-editor.component.vue";
import BeerTableComponent from "./modules/beer/beer-table.component.vue";
Vue.use(Router);

export default new Router({
	mode: "history",
	base: process.env.BASE_URL,
	routes: [
		{
			path: "/home",
			name: "home",
			component: HomeComponent
		},
		{
			path: "/callback",
			name: "callback",
			component: CallbackComponent
		},
		{
			path: "/admin",
			name: "admin",
			meta: {
				requiresAdminRoles: true
			},
			// route level code-splitting
			// this generates a separate chunk (about.[hash].js) for this route
			// which is lazy-loaded when the route is visited.
			component: () => import(/* webpackChunkName: "admin-component" */ "./modules/main/admin.component.vue")
		},
		// Template Route - Copy this block and change 'template' to your component name to get started.
		{
			path: "/template",
			name: "template",
			meta: {
				requiresAdminRoles: true
			},
			// route level code-splitting
			// this generates a separate chunk (about.[hash].js) for this route
			// which is lazy-loaded when the route is visited.
			component: () => import(/* webpackChunkName: "template-component" */ "./modules/main/template.component.vue")
		},
		{
			path: "/processing",
			name: "processing",
			component: ProcessingComponent
		},
		{
			path: "/batches",
			name: "batches",
			component: BatchTableComponent
		},
		{
			path: "/beers",
			name: "beers",
			component: BeerTableComponent
		},
		{
			path: "/batch/details",
			name: "batch/details",
			component: BatchDetailsComponent
		},
		{
			path: "/batch/editor",
			name: "batch/editor",
			component: BatchEditorComponent
		},
		{
			path: "/taproom/ontap",
			name: "Taproom/OnTap",
			component: OnTapComponent
		},
		{
			path: "/fermentation",
			name: "Fermentation",
			component: FermentationLandingComponent
		},
		{
			path: "/",
			redirect: { name: "home" }
		},
		{
			path: "*",
			component: NotFoundComponent
		}
	]
});
