<template>

        <div>
            <v-content>
                <v-layout ma-2 column style="height: 700px;">


                    <v-toolbar flat color="Sogyogroen" dark>
                        <v-toolbar-title>
                            Bestelling

                        </v-toolbar-title>

                    </v-toolbar>
                    <v-toolbar flat color="Sogyogroen" dark>
                    </v-toolbar>
                    <v-dialog v-model="dialog" max-width="500px">


                        <v-card>
                            <v-card-text>
                                <v-container grid-list-md>
                                    <v-layout wrap>
                                        <v-text-field v-model="notitie" color="Sogyogroen" type="text" label="Notitie toevoegen" placeholder="Notitie"></v-text-field>

                                    </v-layout>
                                </v-container>
                            </v-card-text>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="Sogyogroen" flat @click="dialog = false">Cancel</v-btn>
                                <v-btn color="Sogyogroen" flat @click="notitieToevoegen(notitie)">Voeg toe</v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                    <v-flex md6 style="overflow: auto">
                        <v-card>
                            <v-data-table :headers="headers"
                                          :items="producten"
                                          height="inherit"
                                          hide-actions>
                                <template v-slot:items="props">
                                    <td>{{ props.item.productnaam }}</td>
                                    <td>{{ props.item.aantal }}</td>
                                    <td>{{ '€ ' + prijsGeformatteerd(props.item.prijs) }}</td>
                                    <td>{{ '€ ' + prijsGeformatteerd(props.item.prijs * props.item.aantal)  }}</td>

                                    <td>
                                        <v-btn icon class="mx-0" @click="deleteProduct(props.item)">
                                            <v-icon style=" font-size: 22px" color="Sogyogroen">delete</v-icon>
                                        </v-btn>
                                    </td>
                                    <td>
                                        <v-btn icon @click="addNotitie(props.item)" class="mx-0">
                                            <v-icon style=" font-size: 22px" color="Sogyogroen">add_comment</v-icon>
                                        </v-btn>


                                    </td>
                                    <td> {{ props.item.notitie }}</td>
                                </template>
                                <template slot="no-data">
                                    <v-alert :value="true" color="Sogyogroen" icon="warning">
                                        Nog geen bestelling geplaatst.
                                    </v-alert>
                                </template>
                                <template v-slot:footer>
                                    <td><strong>Totaal voor deze bestelling:</strong></td>
                                    <td></td>
                                    <td></td>
                                    <td><strong>{{ '€ ' + prijsGeformatteerd(totaalprijsBestelling())}}</strong></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </template>

                            </v-data-table>
                        </v-card>
                    </v-flex>


                    <v-footer dark color="Sogyogroen">
                    </v-footer>
                </v-layout>
            </v-content>
        </div>

</template>

<script src="./Bestelling.component.js">

</script>
