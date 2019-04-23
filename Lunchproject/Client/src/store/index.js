import Vue from 'vue'
import Vuex from 'vuex'

import authStore, { types as authTypes } from './auth'
import messageStore, { types as messageTypes } from './message'

Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
        [authTypes.name]: Object.assign(authStore, { namespaced: true }),
        [messageTypes.name]: Object.assign(messageStore, { namespaced: true })
    }
})