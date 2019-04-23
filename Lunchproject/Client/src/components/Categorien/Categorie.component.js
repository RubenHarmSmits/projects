import GeneralFunctionsMixin from "../mixin.js"

export default {
    data: () => ({        
        dialog: false,        
        dialogNieuw: false,
        defaultSelected: {
            

        },
        headers: [
            {
                text: 'CategorieNaam',
                align: 'left',
                sortable: true,
                value: 'categorieId'
            },
            {
                text: 'Winkel',
                sortable: true,
                value: 'winkelId'
            },
            {
                text: 'Volgordenummer',
                value: 'volgordeNummer'
            },
            
        ],

        gewijzigdeCategorie: {
            categorieId: null,
            categorieNaam: null,
            winkelId: null,
            volgordeNummer: null
        },
        nieuweCategorie: {            
            categorieNaam: null,
            winkelId: null,
            volgordeNummer: null,
        },
    
        categorien: [],
        winkels: [],       
    }),

    mixins: [GeneralFunctionsMixin],

    created() {
        this.fetchCategorien()
        this.fetchWinkels()
    },

    methods: {
        setNieuwWinkelId(winkelId) {
            this.nieuweCategorie.winkelId = winkelId
        },

        setGewijzigdeWinkelId(winkelId) {
            this.gewijzigdeCategorie.winkelId = winkelId
        },

        editItem(item) { 
            this.defaultSelected = item.winkel
            this.gewijzigdeCategorie = item          
            this.dialog = true
        },

        close() {
            this.dialog = false
            this.dialogNieuw = false           
        },

        async createCategorie() {
            this.$http.post(`categorie`, {
                CategorieNaam: this.nieuweCategorie.categorieNaam,
                WinkelId: this.nieuweCategorie.winkelId,
                VolgordeNummer: this.nieuweCategorie.volgordeNummer,
            })
                .then(res => {

                    this.fetchCategorien();
                    this.dialogNieuw = false;
                    this.nieuweCategorie.categorieNaam = null;
                    this.nieuweCategorie.volgordeNummer = null;
                    this.nieuweCategorie.winkelId = null;
                })
        },

        async fetchCategorien() {
            this.$http.get(`categorie`)
                .then(res => this.categorien = res.data)
        },

        async deleteCategorie(props) {
            this.$http.delete(`categorie?CategorieId=` + props.categorieId)
                .then(res => {
                    this.fetchCategorien();
                })
        },
     
        async wijzigCategorie() {
            console.log(this.gewijzigdeCategorie)
            this.close()

            this.$http.put(`categorie`, {
                CategorieId: this.gewijzigdeCategorie.categorieId,
                CategorieNaam: this.gewijzigdeCategorie.categorieNaam,
                WinkelId: this.gewijzigdeCategorie.winkelId,
                VolgordeNummer: this.gewijzigdeCategorie.volgordeNummer,
            }).then(res => {
                this.fetchCategorien();
            })
        },
    }
}