
export const types = {
    name: "message",

    actions: {
        onSetMessage: "onSetMessage",
        onClearMessage: "onClearMessage"
    },
    mutations: {
        setMessage: "setMessage",
        clearMessage: "clearMessage"
    },
    status: {
        success: "success",
        warning: "warning",
        error: "error",
        info: "info"
    }
}

export default {
    state: {
        messages: { }
    },
    mutations: {
        [types.mutations.setMessage] (state, { target, message, status }) {
            state.messages = Object.assign({}, state.messages,
                { [target]: { message, status }})
        },
        [types.mutations.clearMessage] (state) {
            state.messages = { }
        }
    },
    actions: {
        [types.actions.onSetMessage]({ commit }, { target, status, message, timeout }) {
            commit(types.mutations.setMessage, { target, status, message })
            if (timeout && timeout > 0) {
                setTimeout(() => commit(types.mutations.clearMessage), timeout * 1000)
            }
        },
        [types.actions.onClearMessage]({ commit }) {
            commit(types.mutations.clearMessage)
        }
    }
}