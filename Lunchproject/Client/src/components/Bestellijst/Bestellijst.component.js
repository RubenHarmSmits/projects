import GeneralFunctionsMixin from '../mixin';
import jsPDF from 'jspdf';
import 'jspdf-autotable'

export default {
    name: 'Winkels',
    mixins: [GeneralFunctionsMixin],
    data() {
        return {
            headers: [
                {
                    text: 'Product',
                    align: 'left',
                    value: 'productnaam'
                },
                {
                    text: 'Aantal',
                    value: 'aantal',
                    sortable: false
                },
                {
                    text: 'Gebruiker',
                    value: 'gebruikerId',
                    sortable: false
                },

            ],
            toggle: 0,
            selected: '',
            dagpicker: '',
            bestellingen: [],
            producten: [],
            datum: null,
            search: '',
            
        };
    },

    computed: {
        computedDatum() {
            return this.datumGeformatteerd(this.datum);
        },

    },

    methods: {

        async fetchBestellingenPerDatum(datum) {

            this.datum = datum;
            this.$http.get(`bestelling/${datum}`)
                .then(res => {
                    this.bestellingen = res.data

                    this.productenUitBestellingen();
                })
        },

        bestellijstNaarPdf() {

            var doc = new jsPDF('p', 'pt', 'letter')
            doc.fromHTML(document.getElementById('my-table'));
            var string = doc.output('datauristring');
            var iframe = "<iframe width='100%' height='100%' src='" + string + "'></iframe>"
            var x = window.open();
            x.document.open();
            x.document.write(iframe);
            x.document.close();
        },
    }
};
