import GeneralFunctionsMixin from '../mixin';

export default {
    mixins: [GeneralFunctionsMixin],

    data() {
        return {
            winkel: {
                Winkelnaam: null,
            },
            winkels: [],
            producten: [],
            toggle: 0,
            search:'',
            headers: [
                {
                    text: 'Product',
                    align: 'left',
                    sortable: true,
                    value: 'naam'
                },

                {
                    text: 'Prijs',
                    value: 'prijs'
                }
              ],
        }
    },

    async mounted() {
        await this.fetchWinkels();
        this.winkel = this.winkels[0];
        this.fetchProducten();
    },

    watch: {
        toggle: function (val) {
            this.winkel = this.winkels[val];
            this.fetchProducten();
        },
    },

    methods: {
        prijsGeformatteerd(prijs) {
            prijs = prijs.toString();
            while (prijs.length < 3) {
                prijs = "0" + prijs;
            }
            return prijs.substring(0, prijs.length - 2) + "." + prijs.substring(prijs.length - 2);
        },

        async fetchWinkels() {
            return this.$http.get("winkel")
                .then(res => {
                    this.winkels = res.data
                    //this.winkel = this.winkels[0]
                    //this.fetchProducten()
                })
        },

        async fetchProducten() {
            this.$http.get(`product/winkel/${this.winkel.winkelnaam}`)
                .then(res => {
                    this.producten = res.data
                })
        }
    }
}