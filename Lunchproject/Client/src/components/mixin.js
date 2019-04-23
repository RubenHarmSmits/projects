var GeneralFunctionsMixin = {
    methods: {


        datumGeformatteerd(datum) {
            if (!datum) return null;
            const [year, month, day] = datum.split("-");
            return `${day}-${month}-${year}`;

        },

        async fetchWinkels() {
            this.$http.get(`winkel`)
                .then(res => {
                    this.winkels = res.data
                })
        },

        async fetchCategorien() {
            this.$http.get(`categorie`)
                .then(res => this.categorien = res.data)
        },

        async fetchCategorienPerWinkel(winkelId) {            
            this.$http.get(`categorie/winkel?winkelId=` + winkelId)
                .then(res => this.categorien = res.data)
        },

        prijsGeformatteerd(prijs) {
            prijs = prijs.toString();
            while (prijs.length < 3) {
                prijs = "0" + prijs;
            }
            return prijs.substring(0, prijs.length - 2) + "." + prijs.substring(prijs.length - 2);
        },

        productenUitBestellingen() {
            this.producten = [];

            for (let bestelling of this.bestellingen) {

                for (let product of bestelling.productenPerBestellingen) {
                    this.producten.push({ "productId": product.product.productId, "datum": bestelling.bezorgdatum, "productnaam": product.product.naam, "aantal": product.aantal, "prijs": product.prijs, "gebruiker": bestelling.gebruikerId, "notitie": product.notitie })
                }
            }
        },

        productenUitBestellingGebruiker() {
            this.producten = [];
            if (this.bestelling.length > 0) {
                for (let product of this.bestelling[0].productenPerBestellingen) {
                    this.producten.push({ "productId": product.productId, "datum": this.bestelling[0].bezorgdatum, "productnaam": product.product.naam, "aantal": product.aantal, "prijs": product.prijs, "bestellingId": this.bestelling[0].bestellingId, "notitie": product.notitie })
                }
            }
        },

        totaalprijsBestelling() {
            let totaalprijs = 0;

            for (var i = 0; i < this.producten.length; i++) {
                totaalprijs += this.producten[i].prijs * this.producten[i].aantal;
            }
            return totaalprijs;
        },

        filterDatums(datum) {
            return this.datumLijst.indexOf(datum) !== -1;
        },

        filterLegeDatums(datum) {
           
            return this.legeDatumLijst.indexOf(datum) !== -1;
        },  

        setWinkelId(winkelId) {
            this.winkelId = winkelId
        },


    }
};
export default GeneralFunctionsMixin;