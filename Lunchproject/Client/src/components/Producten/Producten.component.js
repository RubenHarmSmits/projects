
import EventBus from '../EventBus.js';
import DatumSelectie from '../Datumselectie/DatumSelectie.vue'
import GeneralFunctionsMixin from '../mixin';

import { types as authTypes } from '../../store/auth'
import { mapGetters } from 'vuex';

export default {
    name: 'Producten',

    mixins: [GeneralFunctionsMixin],

    data() {
        return {
            deadlineTijd: null,
            deadlineDag: null,
            dialog: false,
            search: '',
            headers: [
                {
                    text: 'Product',
                    align: 'left',
                    sortable: true,
                    value: 'naam'
                },
                {
                    text: 'Categorie',
                    align: 'left',
                    sortable: true,
                    value: 'categorieId'
                },
                {
                    text: 'Prijs',
                    value: 'prijs'
                },
                {
                    text: 'Kies aantal',
                    value: '',
                    sortable: false,
                },


            ],
            producten: [],
            categorien: [],
            categorienFilter: [],
            winkel: {
                Winkelnaam: null,
            },
            toegevoegdeProducten: [],
            nieuwProduct: "",
            nieuwProductNaam: "",
            nieuwProductPrijs: "",
            nieuwProductCategorieId: "",
            datum: null,
            rules: {
                prijsRule: value => {
                    return this.testPrijs(value) || "Foutief formaat.";
                },
                required: value => !!value || "Verplicht veld.",
                hogerDanNul: value => !(parseInt(value) < 0) || 'Kan niet negatief zijn.',
            },
            popup: false,
            forceer: false,
            forceerProduct: {
                product: null,
                aantal: null,
            },
            rowsPerPageItems: [10, 20, 30, { "text": "All", "value": -1 }],


        };


    },


    components: {
        DatumSelectie,
        EventBus
    },

    created() {

        EventBus.$on('Datum_update', (datum) => {
            this.fetchData(datum);
        });

    },


    methods: {
        ...mapGetters(authTypes.name, {
            getUser: authTypes.getters.getUser
        }),


        fetchCategorienPerWinkel(winkelId) {
            return this.$http.get(`categorie/winkel?winkelId=` + winkelId)
                .then(res => res.data)                                    
                
        },

        parsePrijs(prijs) {
            var index = prijs.indexOf('.');
            if (index < 0) return prijs + "00";

            if (prijs.length - index < 3) prijs = prijs + "0";
            return prijs.slice(0, index) + prijs.slice(index + 1);
        },

        testPrijs(prijs) {
            const pattern = /^[0-9]+(\.[0-9]{1,2})?$/;
            return pattern.test(prijs);
        },


        async plaatsBestellingDatumGebruiker(product, aantal) {
            let user = this.getUser()
            if (parseInt(aantal) > 10 && !this.forceer) {
                this.forceerProduct.product = product;
                this.forceerProduct.aantal = aantal;
                this.popup = true;
                return;
            }
            this.$http.post(`bestelling`, {
                GebruikerId: user.apiId,
                Bezorgdatum: this.datum,
                ProductenPerBestellingen: [{
                    ProductId: product.productId,
                    Prijs: product.prijs,
                    Aantal: aantal
                }]
            }).then(res => {
                this.emitProductToegevoegd();
                this.forceer = false;
            })
        },


        forceerBestelling() {
            this.forceer = true;
            this.plaatsBestellingDatumGebruiker(this.forceerProduct.product, this.forceerProduct.aantal);
            this.popup = false;
        },

        close() {
            this.dialog = false
        },

        emitProductToegevoegd() {
            EventBus.$emit('Product_toegevoegd', this.datum);
        },

        filterOpCategorie(categorieId) {
            if (categorieId == -1) this.fetchProducten(this.datum)
                           
            else {
                this.$http.get(`product/categorie?categorieId=${categorieId}`)
                    .then(res => {
                        this.producten = res.data;
                    })
            }
            
        },

        async fetchCategorieen() {
            this.categorien = await this.fetchCategorienPerWinkel(this.winkel.winkelId);
            this.categorienFilter = await this.fetchCategorienPerWinkel(this.winkel.winkelId);
            this.categorienFilter.push({ categorieId: -1, categorieNaam: "Alle Categorien" });
            this.categorien.push({ categorieId: null, categorieNaam: "Geen categorie" });
        },
        

        async fetchWinkel(datum) {            
            return this.$http.get(`winkel/${datum}`)
                .then(res => {                
                   let winkel = res.data;
                   return winkel
                })            
        },

        async fetchData(datum) {
            this.datum = datum;
            this.winkel = await this.fetchWinkel(datum);
            this.fetchProducten(datum);
            this.fetchDeadline(datum);
            this.fetchCategorieen();           
            
        },


        async fetchProducten(datum) {
            this.$http.get(`product/${datum}`)
                .then(res => {
                    this.producten = res.data.map(p => Object.assign(p, { aantal: 1 }))
                })
        },

        async fetchDeadline(datum) {

            this.$http.get(`deadline/${datum}`)
                .then(res => {
                    this.deadlineTijd = res.data.substring(11, 16);
                    this.deadlineDag = res.data.substring(0, 10);
                })
        },


        async createProduct(productNaam, productPrijs, categorieId) {
            
            productPrijs = this.parsePrijs(productPrijs);
            this.$http.post(`product`, {
                Naam: productNaam,
                categorieId: categorieId,
                Prijs: productPrijs,
                winkelId: this.winkel.winkelId
            }).then(res => {
                this.fetchProducten(this.datum);
                this.dialog = false    
            })
        },

    }
};
