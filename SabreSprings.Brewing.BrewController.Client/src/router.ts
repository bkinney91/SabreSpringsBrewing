import { createRouter, createWebHashHistory } from "vue-router";
import HomeComponent from "./modules/home/home.component.vue";
import CallbackComponent from "./modules/home/callback.component.vue";
import NotFoundComponent from "./modules/home/not-found.component.vue";
import ProcessingComponent from "./modules/home/processing.component.vue";
import AdminComponent from "./modules/main/admin.component.vue";
import TemplateComponent from "./modules/main/template.component.vue";
import BrewControllerComponent from "./modules/brewcontroller/brewcontroller.component.vue";

export default createRouter({
	history: createWebHashHistory(import.meta.env.BASE_URL),
	routes: [
		{
			path: "/",
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
			path: "/brewcontroller",
			name: "brewcontroller",
			component: BrewControllerComponent
		},
		{ path: "/:pathMatch(.*)*", name: "not-found", component: NotFoundComponent }
	]
});
