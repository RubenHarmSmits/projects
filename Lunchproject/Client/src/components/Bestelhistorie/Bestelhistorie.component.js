import GeneralFunctionsMixin from '../mixin';
import { mapGetters } from 'vuex';

import { types as authTypes } from '../../store/auth'

export default {
    name: 'Bestelhistorie',
    mixins: [GeneralFunctionsMixin],

    data() {
        return {
            headers: [
                {
                    text: 'Product',
                    align: 'left',
                    sortable: true,
                    value: 'productnaam'
                },
                {
                    text: 'Aantal',
                    value: 'aantal'
                },
                {
                    text: 'Totaalprijs',
                    value: 'prijs'
                },
                {
                    text: 'Bezorgdatum',
                    value: 'datum'
                },

            ],
            toggle: 0,
            search: '',
            maandpicker: '',
            dagpicker: '',
            bestellingen: [],
            bestelling: null,
            producten: [],
            datum: null,

            maand: null,
            rowsPerPageItems: [50, 20, 30, { "text": "All", "value": -1 }],
        };
    },

    computed: {
        computedDatum() {
            return this.datum ? this.datumGeformatteerd(this.datum) : ''
        },

        computedMaand() {
            return this.maand ? this.maandGeformatteerd(this.maand) : ''
        },
    },


    
    methods: {
        ...mapGetters(authTypes.name, {
            getUser: authTypes.getters.getUser
        }),

        maandGeformatteerd(maand) {
            const [year, month] = maand.split("-");
            return `${month}-${year}`;
        },

        async fetchBestellingPerDagVoorGebruiker(datum) {
            this.datum = datum;
            this.maand = null;
            let user = this.getUser()
            this.$http.get(`bestelling/${datum}/${user.apiId}`)
                .then(res => {
                    this.bestelling = res.data

                    this.productenUitBestellingGebruiker();
                })

        },

        async fetchBestellingenPerMaandVoorGebruiker(datum) {
            this.maand = datum;
            this.datum = null;
            let user = this.getUser()
            this.$http.get(`bestelling/maand/${datum}/${user.apiId}`)
                .then(res => {
                    this.bestellingen = res.data

                    this.productenUitBestellingen();
                })

        },
        
    }
};


