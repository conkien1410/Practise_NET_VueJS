//import Vue from 'vue'

import { createApp } from 'vue';
import { createPinia } from 'pinia'


import App from './App.vue'

// Import Bootstrap and BootstrapVue CSS files (order is important)
// import 'bootstrap/dist/css/bootstrap.css'
// import 'bootstrap-vue/dist/bootstrap-vue.css'


import './assets/main.css'

// Make BootstrapVue available throughout your project
//Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
//Vue.use(IconsPlugin)

// import { BNav } from 'bootstrap-vue'
// Vue.component('b-nav', BNav)

const app = createApp(App)
const pinia = createPinia()
app.use(pinia)

app.mount('#app')



