import { mapState, mapMutations, mapActions } from 'vuex';


import { types as authTypes } from '../../store/auth'

export default {
    name: 'Login',

    props: {
        redirectUrl: {
            type: String,
            default: "/"
        }
    },

    mounted() {
        this.addGoogle()
    },

    computed: mapState(authTypes.name, {
        googleAuth: state => state.googleAuth,
        authenticated: state => state.authenticated,
        googleAuth: state => state.googleAuth,
        loading: state => state.pending
    }),

    watch: {
        authenticated(authenticated) {
            if (authenticated) {
                this.$router.push({
                    path: this.redirectUrl
                })
            }
        }
    },

    methods: {
        async addGoogle() {
            await this.onInitGoogleAuth()
            if (this.googleAuth) {
                this.googleAuth.attachClickHandler(this.$refs.google_button.$el, null,
                    (user) => {
                        this.externalLogin({
                            provider: "Google",
                            token: user.getAuthResponse().id_token,
                            profile: user.getBasicProfile()
                        })
                    },
                    (err) => this.authError(err)
                );
            }
        },
        ...mapMutations(authTypes.name, {
            authError: authTypes.mutations.setAuthError
        }),
        ...mapActions(authTypes.name, {
            onInitGoogleAuth: authTypes.actions.onInitGoogleAuth,
            externalLogin: authTypes.actions.onExternalLogin
        })
    }
};