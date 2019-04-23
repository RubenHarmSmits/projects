<template>
    <div>
        <v-content>
            <v-layout ma5 column style="height: 1000px">


                <v-toolbar flat color="Sogyogroen" dark>
                    <v-toolbar-title>
                        Bestellijst

                    </v-toolbar-title>
                    <v-spacer></v-spacer>
                   
                </v-toolbar>

                <v-toolbar flat color="Sogyogroen" dark>
                </v-toolbar>

                <v-flex md6 style="overflow: auto">

                    <v-menu lazy
                            transition="scale-transition"
                            :close-on-content-click="true">
                        <v-text-field slot="activator"
                                      prepend-icon="event"
                                      label="Kies een datum"
                                      v-model="computedDatum"
                                      readonly
                                      color="Sogyogroen">

                        </v-text-field>
                        <v-date-picker color="Sogyogroen"
                                       v-model="dagpicker"
                                       scrollable
                                       locale="nl-NL"
                                       first-day-of-week="1"
                                       v-on:change="fetchBestellingenPerDatum">

                        </v-date-picker>
                        
                    </v-menu>


                        <v-data-table id="my-table" :headers="headers"
                                      :items="producten"
                                      :search="search"
                                      hide-actions
                                      sort ascending>
                            <template v-slot:items="props">
                                <td>{{ props.item.productnaam }}</td>
                                <td>{{ props.item.aantal }}</td>
                                <td> {{ props.item.gebruiker }}</td>

                            </template>
                            <template slot="no-data">
                                <v-alert :value="true" color="Sogyogroen" icon="warning">
                                    Geen bestellingen gevonden.
                                </v-alert>
                            </template>
                        </v-data-table>

                </v-flex>


                <v-footer dark color="Sogyogroen"><v-btn depressed color="Sogyogroen" @click="bestellijstNaarPdf">Maak PDF</v-btn></v-footer>
            </v-layout>
        </v-content>
    </div>
</template>

<script src="./Bestellijst.component.js">

</script>