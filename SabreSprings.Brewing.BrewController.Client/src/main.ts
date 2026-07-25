import 'reflect-metadata';
import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import { configureContainer } from './configure-container';

configureContainer();
createApp(App).use(router).use(store).mount('#app');
