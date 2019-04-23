import EventBus from '../EventBus.js';
import GeneralFunctionsMixin from '../mixin';

export default {
    data() {
        return {
            datum: null,            
            menu: false,
            sluitingsDatum: null,
            datumLijst: [],
            
        };
    },

    mixins: [GeneralFunctionsMixin],

    mounted() {
        
        this.initialize();        
        this.datum = this.datumLijst[0];
    },

    computed: {
        computedDatum() {
            return this.datumGeformatteerd(this.datum);
        },

    },

    methods: {
        filterDatums(datum) {
            return this.datumLijst.indexOf(datum) !== -1;
        },

        emitDatumUpdate() {            
            EventBus.$emit('Datum_update', this.datum);
        },

        async initialize() { 
            await this.fetchDatums(40);             
        },

        fetchDatums(aantalDagen) {
            this.$http.get("bezorgdag?aantalDagen=" + aantalDagen)
                .then(res => {
                    this.datumLijst = [];
                    res.data.forEach(entry => {
                        this.datumLijst.push(entry.substr(0, 10));
                    })

                    this.datum = this.datumLijst[0];
                    this.emitDatumUpdate();
                })
        },

    },
}