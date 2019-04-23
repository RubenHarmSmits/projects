import EventBus from '../EventBus.js';
import GeneralFunctionsMixin from '../mixin';
import { isNullOrUndefined } from 'util';

import { mapGetters } from 'vuex';

import { types as authTypes } from '../../store/auth'



export default {
    name: 'Bestelling',
    mixins: [GeneralFunctionsMixin],
    data() {
        return {
            dialog: false,
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
                    text: 'Prijs',
                    value: 'prijs'
                },

                {
                    text: 'Totaalprijs',
                    value: 'prijs'
                },

                {
                    text: 'Verwijderen',
                    value: 'name',
                    sortable: false
                },
                {
                    text: 'Notitie toevoegen',
                    value: 'notitie',
                    sortable: false
                },
                {
                text: 'Notitie',
                value: 'notitie'
                },

            ],

            nieuweNotitie: {
                bestellingId: null,
                productId: null,
                prijs: null,
                aantal: null,
            },

            bestelling: [],

            producten: [],
            notitie: null,

            rowsPerPageItems: [50, 20, 30, { "text": "All", "value": -1 }],
        };
       
    },

    created() {

        EventBus.$on('Product_toegevoegd', (datum) => {
            this.fetchBestellingenPerDatumVoorGebruiker(datum);
            this.datum = datum;
        });

        EventBus.$on('Datum_update', (datum) => {
            this.fetchBestellingenPerDatumVoorGebruiker(datum);
            this.datum = datum;
        });
    },

 
    methods: {
        ...mapGetters(authTypes.name, {
            getUser: authTypes.getters.getUser
        }),

        addNotitie(props) {
            this.nieuweNotitie = props
            this.dialog = true
        },

        async fetchBestellingenPerDatumVoorGebruiker(datum) {
            let user = this.getUser()
            this.producten = [];            
            this.$http.get(`bestelling/${datum}/${user.apiId}`)
                .then(res => {
                    this.bestelling = res.data

                    this.productenUitBestellingGebruiker();
                })                 
        },

        async deleteProduct(props) {
            this.$http.put(`bestelling`, {
                BestellingId: props.bestellingId,                                          
                ProductId: props.productId,
                Prijs: props.prijs,
                Aantal: props.aantal                    
            }).then(res => {
                this.fetchBestellingenPerDatumVoorGebruiker(this.datum);
            })
        },

        async notitieToevoegen(notitie) {
            this.$http.put(`bestelling/notitie`, {
                BestellingId: this.nieuweNotitie.bestellingId,
                ProductId: this.nieuweNotitie.productId,
                Prijs: this.nieuweNotitie.prijs,
                Aantal: this.nieuweNotitie.aantal,
                Notitie: notitie
            }).then(res => { this.fetchBestellingenPerDatumVoorGebruiker(this.datum) })
                this.notitie = ""
                this.dialog = false
        },
    }
};