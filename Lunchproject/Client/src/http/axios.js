import constants from '../constants'

import store from '../store'
import { types as authTypes } from '../store/auth'
import { types as messageTypes } from '../store/message'

import router from "../router"

export const configureAxios = (axios) => {
    axios.interceptors.request.use(
        config => {
            if (config.baseURL !== constants.API_URL || config.headers.Authorization) {
                return config;
            }
            if (store.state.auth.authenticated) {
                let user = store.getters[`${authTypes.name}/${authTypes.getters.getUser}`]
                config.headers.Authorization = `Bearer ${user.accessToken}`
            }
            return config;
        },
        error => Promise.reject(error)
    );

    axios.interceptors.response.use(
        response => response,
        error => {
            if (error.response && error.response.status === 401) {
                store.commit(`${authTypes.name}/${authTypes.mutations.setAuthError}`, false)
                store.dispatch(`${messageTypes.name}/${messageTypes.actions.onSetMessage}`, {
                    target: 'login',
                    message: "De sessie is verlopen. Je moet opnieuw inloggen",
                    status: messageTypes.status.warning
                })
                router.push({
                    name: 'login'
                })
            } else {
                return Promise.reject(error)
            }
        }
    )
}