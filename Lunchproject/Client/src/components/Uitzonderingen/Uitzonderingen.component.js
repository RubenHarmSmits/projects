
import GeneralFunctionsMixin from '../mixin';


export default {
    mixins: [GeneralFunctionsMixin],

    Naam: "uitzonderingen",
    data() {
        return {
            uitzonderingen: [],
            datum: null,            
            datumVandaag: new Date().toISOString().substr(0, 10),
            verwijderDatum: null,
            datumLijst: [],
            legeDatumLijst: [],
            winkelId: null,
            deadlineDag: null,
            deadlineTijd: "11:00",
            bestelDeadline: null,
            winkels: [],
            winkelsGefilterd: [],
            typeUitzondering: null,
            popup: false,


            headers: [
                {
                    text: 'Datum',
                    align: 'left',
                    sortable: true,
                    value: 'date'
                },
                {
                    text: 'Winkel',
                    value: 'winkelNaam'
                },
                {
                    text: 'Deadline dag',
                    value: 'deadlineDag'
                },
                {
                    text: 'Deadline',
                    value: 'deadlineTijd'
                },
                {
                    text: 'Verwijderen',
                    value: 'name',
                    sortable: false
                },
            ],

            rules: {
                tijdRule: value => value.length == 5 || "De deadline moet in het formaat uu:mm",
                required: value => !!value || "Verplicht veld.",
            },
        }
    },

    async mounted() {
        await this.fetchWinkels()
        this.fetchWinkelUitzonderingenPerBezorgdag()
    },

    computed: {    

        computedDatum() {            
            return this.datum ? this.datumGeformatteerd(this.datum) : ''
        },

        computedVerwijderDatum() {
            return this.verwijderDatum ? this.datumGeformatteerd(this.verwijderDatum) : ''
        },

        computedDeadlineDag() {
            return this.deadlineDag ? this.datumGeformatteerd(this.deadlineDag) : ''
        },
    },

    
    methods: {

        resetWaardes() {
            this.winkelId = null;
            this.deadlineDag = null;
            this.datum = null;
            this.verwijderDatum = null;            
            this.fetchDatums(50);
            this.fetchLegeDatums(50);
        },

      

      

        getWinkelnaam(winkel) {
            if (winkel) {
                return winkel.winkelnaam;
            }
            else {
                return " ";
            }
        },

        getDeadlineDag(uitzondering) {
            if (uitzondering.winkel) {
                return this.datumGeformatteerd(uitzondering.bestelDeadline.substring(0, 10));
            }
            else {
                return "";
            }
        },

        getDeadlineTijd(uitzondering) {
            if (uitzondering.winkel) {
                return uitzondering.bestelDeadline.substring(11, 16);
            }
            else {
                return "";
            }
        },

        setDeadline() {
            this.bestelDeadline = this.deadlineDag + "T" + this.deadlineTijd;
        },

        wijzigBezorgdatum() {
            this.addVerwijderUitzondering();
            this.addUitzondering();
        },

        veranderWinkel() {
            this.verwijderDatum = this.datum;
            this.verwijderBestellingen();
            this.addUitzondering();
        },

        setWinkelsGefilterd() {
            this.$http.get('winkel/' + this.datum)
                .then(res => {
                    this.winkelsGefilterd = [];                   
                    let winkelId = res.data.winkelId
                    for (var i = 0; i < this.winkels.length; i++) {
                        if (winkelId != this.winkels[i].winkelId) this.winkelsGefilterd.push(this.winkels[i]);
                    }
                })             
        },

        verwijderBestellingen() {
            this.popup = true;                    
            this.$http.delete(`bestelling?datum=${this.verwijderDatum}`)                  
        },

        async getWinkelIdPerDatum(datum) {
            this.$http.get(`winkel/` + datum)
                .then(res => {
                    this.winkelId = res.data.winkelId
                })
        },
        


        async deleteUitzondering(datum) {
            this.$http.delete(`winkeluitzonderingenperbezorgdag?datum=${datum}`)
                .then(res => {
                    this.fetchWinkelUitzonderingenPerBezorgdag();
                })                            
        },

        async fetchWinkelUitzonderingenPerBezorgdag() {
            this.uitzonderingen = [];
            this.$http.get(`winkeluitzonderingenperbezorgdag`)
                .then( res => {
                    this.uitzonderingen = res.data;
                })           
        },

        async addUitzondering() {
            this.setDeadline();
            this.$http.post(`winkeluitzonderingenperbezorgdag`, {
                Date: this.datum,
                WinkelId: this.winkelId,
                BestelDeadline: this.bestelDeadline,
            }).then(res => {
                this.fetchWinkelUitzonderingenPerBezorgdag();
            })        
        },

        async addVerwijderUitzondering() {            
            await this.verwijderBestellingen();
            this.$http.post(`winkeluitzonderingenperbezorgdag`, {
                Date: this.verwijderDatum,
                WinkelId: null,
                BestelDeadline : null,
            }).then(res => {
                this.fetchWinkelUitzonderingenPerBezorgdag();
            })            
        },      

        fetchLegeDatums(aantalDagen) {
            this.$http.get("bezorgdag/geen?aantalDagen=" + aantalDagen)
                .then(res => {
                    this.legeDatumLijst = [];
                    res.data.forEach(entry => {
                    this.legeDatumLijst.push(entry.substr(0, 10));
                    })
                })                  
            
        },
          

        fetchDatums(aantalDagen) {
            this.$http.get("bezorgdag?aantalDagen=" + aantalDagen)
                .then(res => {
                    this.datumLijst = [];
                    res.data.forEach(entry => {
                        this.datumLijst.push(entry.substr(0, 10));
                    })
                })
        },

    }
}
