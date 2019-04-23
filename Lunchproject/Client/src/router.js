import Vue from "vue";
import Router from "vue-router";
import Producten from "./components/Producten/Producten";
import Winkeloverzicht from "./components/Winkeloverzicht/Winkeloverzicht";
import Bestelling from './components/Bestelling/Bestelling.vue';
import Bestelhistorie from './components/Bestelhistorie/Bestelhistorie.vue';
import Bestellijst from './components/Bestellijst/Bestellijst.vue';
import Login from './components/Login/Login.vue'
import Uitzonderingen from './components/Uitzonderingen/Uitzonderingen.vue';
import Home from './Home.vue'
import Categorien from './components/Categorien/Categorie.vue'
import LoginComponent from "./components/Login/Login.component";

import store from './store'
import { types as authTypes } from "./store/auth"
import { types as messageTypes } from "./store/message"

Vue.use(Router);

var router = new Router({
  mode: 'history',
  routes : [
    { path: '/producten', name:"Producten", component: Producten },
    { path: '/bestelling', component: Bestelling },
    { path: '/bestelhistorie', component: Bestelhistorie },
    { path: '/bestellijst', component: Bestellijst },
    { path: '/winkeloverzicht', component: Winkeloverzicht, meta: { allowedRoles: ["Admin"]} },
    { name: 'login', path: '/login', component: Login, meta: { guest: true }, props: true },
    { path: '/uitzonderingen', component: Uitzonderingen },
    { path: '/categorien', component: Categorien },
    {
        path: '/', component: Home,
        children: [
            {
                path: '/',
                components: {
                    default: Producten,
                    helper: Bestelling
                }
            }]
    },
    { path: '*', redirect: '/' }

]
});

router.beforeEach(async (to, from, next) => {
    // If the user is not logged in and the page doesnt allow 
    // guest access, redirect to the login page
    if (!store.state.auth.authenticated && !to.matched.some(rec => rec.meta.guest)) {
        if (to.path !== "/") {
            store.dispatch(`${messageTypes.name}/${messageTypes.actions.onSetMessage}`, {
                target: 'login',
                message: "Om dit te doen moet je ingelogd zijn",
                status: messageTypes.status.warning
            })
        }
        next({
            name: 'login',
            params: {
                redirectUrl: to.path
            }
        });
        return;
    }

    var user = store.getters[`${authTypes.name}/${authTypes.getters.getUser}`]

    // Redirect to the homepage when the user doesnt have a required role
    if (to.matched.some(rec => rec.meta.roles 
        && !rec.meta.roles.some(role => user.roles.includes(role)))) 
        {
            next({
                path: '/'
            })
            return;
        }
    
    next();
});

router.afterEach((to, from) => {
    // clear any pending messages
    if (from.name && store.state.message.messages[from.name]) {
        store.dispatch(`${messageTypes.name}/${messageTypes.actions.onClearMessage}`)
    }
})

export default router;