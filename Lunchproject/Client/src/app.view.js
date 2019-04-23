
import Navigatiebalk from './components/Navigatiebalk/Navigatiebalk.vue';
import Producten from './components/Producten/Producten.vue';

import { mapState, mapMutations, mapActions } from 'vuex';

import {  types as messageTypes  } from './store/message'



export default {
    name: 'App',
    components: {
        Navigatiebalk,
        Producten,
    },

    computed: mapState({
        authenticated: state => state.auth.authenticated,
        message: function (state) { return state.message.messages[this.$route.name] },
    }),

    methods: {
        ...mapActions(messageTypes.name, {
            onClearMessage: messageTypes.actions.onClearMessage
        })
    },

    data() {
        return {
            
        };
    }
};
