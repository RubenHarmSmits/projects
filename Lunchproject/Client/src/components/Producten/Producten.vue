<template>
    <div>
        <v-content>
            <v-layout ma-2 column style="height: 700px;">


                <v-toolbar flat short color="Sogyogroen" dark>
                    De deadline voor deze bezorgdag is: <br /> {{deadlineTijd + ' , ' + datumGeformatteerd(deadlineDag)}}
                    <v-spacer></v-spacer>
                    <DatumSelectie v-on:datumUpdate="fetchData"></DatumSelectie>

                </v-toolbar>
                <v-toolbar flat color="Sogyogroen" dark>
                    <v-toolbar-title>{{ winkel.winkelnaam }}</v-toolbar-title>
                    <v-flex class="text-xs-right">
                        <v-dialog v-model="dialog" max-width="500px">
                            <template v-slot:activator="{ on }">
                                <v-btn depressed color="Sogyogroen" dark v-on="on">Nieuw product</v-btn>
                            </template>
                            <v-card>
                                <v-card-text>
                                    <v-container grid-list-md>
                                        <v-layout wrap>
                                            <v-text-field color="Sogyogroen" type="text" label="Product toevoegen" v-model="nieuwProductNaam" :rules="[rules.required]" placeholder="Naam product"></v-text-field>
                                            <v-text-field color="Sogyogroen" type="text" label="Prijs €" v-model="nieuwProductPrijs" placeholder="0.00" :rules="[rules.required, rules.prijsRule]"></v-text-field>
                                            <v-select color="Sogyogroen" :items="categorien" label="Kies een categorie" item-text="categorieNaam" item-value="categorieId" v-model="nieuwProductCategorieId" full-width></v-select>
                                        </v-layout>
                                    </v-container>
                                </v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="Sogyogroen" flat @click="close">Cancel</v-btn>
                                    <v-btn color="Sogyogroen" flat :disabled="!testPrijs(nieuwProductPrijs) || !nieuwProductNaam || !nieuwProductPrijs" @click="createProduct(nieuwProductNaam, nieuwProductPrijs, nieuwProductCategorieId)">Voeg toe</v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-flex>
                </v-toolbar>
                <v-flex md6 style="overflow:auto; text-overflow:ellipsis">
                    <v-card>
                        <v-data-table :headers="headers"
                                      :items="producten"
                                      must-sort
                                      class="elevation-1"
                                      :search="search"
                                      hide-actions>
                            <template slot="items" slot-scope="props">
                                <td>{{ props.item.naam }}</td>
                                <td v-if="props.item.categorie!== null">{{ props.item.categorie.categorieNaam }}</td>
                                <td v-else></td>
                                <td>{{ '€ '+ prijsGeformatteerd(props.item.prijs) }}</td>

                                <td>
                                    <v-text-field v-model="props.item.aantal"
                                                  type="number"
                                                  label="Aantal"
                                                  :rules="[rules.hogerDanNul]"
                                                  color="Sogyogroen">
                                    </v-text-field>
                                </td>
                                <v-btn icon class="mx-0" :disabled="parseInt(props.item.aantal) <= 0 || !parseInt(props.item.aantal)" @click="plaatsBestellingDatumGebruiker(props.item, props.item.aantal)">
                                    <v-icon color="Sogyogroen">playlist_add</v-icon>
                                </v-btn>


                            </template>
                            <template slot="no-data">
                                <v-alert :value="true" color="Sogyogroen" icon="warning">
                                    Geen producten beschikbaar.
                                </v-alert>
                            </template>
                            <v-alert v-slot:no-results :value="true" color="error" icon="warning">
                                Your search for "{{ search }}" found no results.
                            </v-alert>
                        </v-data-table>
                    </v-card>
                </v-flex>
                <v-toolbar>
                    <v-text-field v-model="search"
                                  append-icon="search"
                                  label="Zoek product"
                                  single-line
                                  hide-details
                                  color="Sogyolichtgroen">
                    </v-text-field>

                    <v-select color="Sogyogroen" :items="categorienFilter" label="Filter op categorie" item-text="categorieNaam" item-value="categorieId" v-on:change="filterOpCategorie"></v-select>



                </v-toolbar>
                <v-dialog v-model="popup" max-width="290">
                    <v-card>
                        <v-card-title>Grote hoeveelheid</v-card-title>
                        <v-card-text>Weet u zeker dat u zoveel producten wilt bestellen?</v-card-text>
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn @click="popup = false">Nee</v-btn>
                            <v-btn @click="forceerBestelling">Ja</v-btn>
                        </v-card-actions>
                    </v-card>
                </v-dialog>


                <v-footer dark color="Sogyogroen"></v-footer>

            </v-layout>
        </v-content>

    </div>
</template>

<script src="./Producten.component.js">

</script>


