<template>
    <div>
        <v-content>
            <v-layout ma5 column style="height: 1000px">


                <v-toolbar flat color="Sogyogroen" dark>
                    <v-toolbar-title>
                        Bestelhistorie

                    </v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-flex xs12 sm6 md3>

                        <v-text-field v-model="search"
                                      append-icon="search"
                                      label="Zoek product"
                                      single-line
                                      hide-details
                                      color="Sogyolichtgroen">

                        </v-text-field>

                    </v-flex>
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
                                       v-on:change="fetchBestellingPerDagVoorGebruiker">

                        </v-date-picker>

                    </v-menu>
                    <v-menu lazy
                            transition="scale-transition"
                            :close-on-content-click="true">
                        
                        <v-text-field slot="activator"
                                      prepend-icon="event"
                                      label="Kies een maand"
                                      v-model="computedMaand"
                                      readonly
                                      color="Sogyogroen">


                        </v-text-field>

                        <v-date-picker color="Sogyogroen"
                                       v-model="maandpicker"
                                       locale="nl-NL"
                                       type="month"
                                       v-on:change="fetchBestellingenPerMaandVoorGebruiker">
                        </v-date-picker>
                    </v-menu>
                       
                        <v-card>

                            <v-data-table :headers="headers"
                                          :items="producten"
                                          :search="search"
                                          hide-actions>
                                <template v-slot:items="props">
                                    <td>{{ props.item.productnaam }}</td>
                                    <td>{{ props.item.aantal }}</td>
                                    <td>{{ '€' + prijsGeformatteerd(props.item.prijs * props.item.aantal) }}</td>
                                    <td>{{ datumGeformatteerd(props.item.datum.substring(0,10)) }}</td>

                                </template>
                                <template slot="no-data">
                                    <v-alert :value="true" color="Sogyogroen" icon="warning">
                                        Geen bestellingen gevonden.
                                    </v-alert>
                                </template>
                                <template v-slot:footer>
                                    <td><strong>Totaalbedrag:</strong>
                                    <td />
                                   
                                    <td>
                                        <strong>{{ '€ ' + prijsGeformatteerd(totaalprijsBestelling())}}</strong>
                                    </td>
                                    <td />
                                </template>
                            </v-data-table>
                        </v-card>
                </v-flex>


                <v-footer dark color="Sogyogroen"></v-footer>
            </v-layout>
        </v-content>
    </div>

</template>

<script src="./Bestelhistorie.component.js">

</script>
