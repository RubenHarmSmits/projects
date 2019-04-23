import { externalLogin, logout } from './actions/auth'
import { types as messageTypes } from './message'

const messageModule = {
    setMessage: `${messageTypes.name}/${messageTypes.actions.onSetMessage}`
}

export const types = {
    name: "auth",

    getters: {
        getUser: 'getUser'
    },
    actions: {
        onInitGoogleAuth: "onInitGoogleAuth",
        onAutoLogin: "onAutoLogin",
        onExternalLogin: "onExternalLogin",
        onLogout: "onLogout"
    },
    mutations: {
        setGoogleAuth: "setGoogleAuth",
        setAuthStart: "setAuthStart",
        setAuthError: "setAuthError",
        setAuthSuccess: "setAuthSuccess"
    }
}

export default {
    state: {
        googleAuth: null,
        pending: false,
        authenticated: false
    },
    getters: {
        [types.getters.getUser]: state => {
            return state.authenticated
                ? JSON.parse(sessionStorage.getItem("user"))
                : null
        }
    },
    mutations: {
        [types.mutations.setGoogleAuth](state, googleAuth) {
            state.googleAuth = googleAuth
        },
        [types.mutations.setAuthStart](state) {
            state.pending = true
        },
        [types.mutations.setAuthSuccess](state, login) {
            state.pending = false
            state.authenticated = login
        },
        [types.mutations.setAuthError](state, login) {
            state.pending = false
            state.authenticated = login
        }
    },
    actions: {
        [types.actions.onInitGoogleAuth]({ commit, dispatch }) {
            return new Promise(resolve => {
                gapi.load('auth2', () => {
                    gapi.auth2.init({
                        client_id: '1052492048864-bae100u8h2h3rh1obk3fdpcaumem0e3t.apps.googleusercontent.com'
                    })
                    .then(res => {
                        commit(types.mutations.setGoogleAuth, res)
                        resolve()
                    })
                    .catch(err => {
                        console.log(err)
                        commit(types.mutations.setAuthError, false)
                        dispatch(messageModule.setMessage, {
                            target: 'login',
                            status: messageTypes.status.error,
                            message: `Er is iets misgegaan tijdens het laden van de Google API`
                        }, { root: true })
                        resolve()
                    })
                })
            })
        },
        [types.actions.onAutoLogin]({ commit }) {
            //commit(types.mutations.setAuthStart)
            return new Promise(resolve => {
                let user = sessionStorage.getItem("user")
                if (user) {
                    commit(types.mutations.setAuthSuccess, true)
                }
                resolve()
            })
        },
        [types.actions.onExternalLogin]({ commit, dispatch }, { provider, token, profile }) {
            commit(types.mutations.setAuthStart)
            return new Promise(resolve => {
                externalLogin(provider, token, profile)
                    .then(user => {
                        sessionStorage.setItem("user", JSON.stringify(user))
                        commit(types.mutations.setAuthSuccess, true)
                        resolve()
                    })
                    .catch(err => {
                        console.log(err)
                        commit(types.mutations.setAuthError, false)
                        dispatch(messageModule.setMessage, {
                            target: 'login',
                            status: messageTypes.status.error,
                            message: `Er is iets misgegaan tijdens het inloggen`
                        }, { root: true })
                        resolve()
                    })
            })
        },
        [types.actions.onLogout]({ commit, dispatch }) {
            commit(types.mutations.setAuthStart)
            return new Promise(resolve => {
                logout()
                    .then(() => {
                        localStorage.removeItem("user")
                        commit(types.mutations.setAuthSuccess, false)
                        dispatch(messageModule.setMessage, {
                            target: 'login',
                            status: messageTypes.status.success,
                            message: "Je bent uitgelogd"
                        }, { root: true })
                        resolve()
                    })
                    .catch(err => {
                        console.log(err)
                        localStorage.removeItem("user")
                        commit(types.mutations.setAuthError, false)
                        dispatch(messageModule.setMessage, {
                            target: 'login',
                            status: messageTypes.status.error,
                            message: `Er is iets misgegaan tijdens het uitloggen`
                        }, { root: true })
                        resolve()
                    })
            })
        }
    }
}