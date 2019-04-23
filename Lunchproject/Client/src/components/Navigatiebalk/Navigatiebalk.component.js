import { types as authTypes } from '../../store/auth'
import { mapActions } from 'vuex';


export default {
    name: 'Navigatiebalk',

    data() {
        return {
            user: JSON.parse(sessionStorage.getItem("user"))
        }
    },

    methods: {
        ...mapActions(authTypes.name, {
            onLogout: authTypes.actions.onLogout
        }),
        logout () {
            this.onLogout().then(() => {
                this.$router.push({
                    name: 'login',
                    params: {
                        redirectUrl: this.$route.path
                    }
                })
            })
        }
    }
};
