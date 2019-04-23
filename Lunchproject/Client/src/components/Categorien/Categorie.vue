<template>
    <div>
        <v-toolbar flat color="white">
            <v-toolbar-title>Categorien</v-toolbar-title>
            
            <v-spacer></v-spacer>
            <v-dialog v-model="dialog" max-width="500px">
                <v-card>
                    <v-card-title>
                        <span class="headline">Wijzig Categorie</span>
                    </v-card-title>

                    <v-card-text>
                        <v-container grid-list-md>
                            <v-layout wrap>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="gewijzigdeCategorie.categorieNaam" label="Categorie naam"></v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-select v-model="defaultSelected" :items="winkels" color="Sogyogroen" label="Winkel" item-text="winkelnaam" item-value="winkelId" v-on:change="setGewijzigdeWinkelId" full-width></v-select>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="gewijzigdeCategorie.volgordeNummer" label="Volgorde nummer(optioneel)"></v-text-field>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" flat @click="close">Cancel</v-btn>
                        <v-btn color="blue darken-1" flat @click="wijzigCategorie">Wijzig</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>



            <v-dialog v-model="dialogNieuw" max-width="500px">
                <template v-slot:activator="{ on }">
                    <v-btn color="Sogyogroen" class="mb-2" v-on="on"><font color="white">Nieuwe Categorie</font></v-btn>
                </template>
                <v-card>
                    <v-card-title>
                        <span class="headline">Nieuwe Categorie</span>
                    </v-card-title>

                    <v-card-text>
                        <v-container grid-list-md>
                            <v-layout wrap>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="nieuweCategorie.categorieNaam" label="Naam"></v-text-field>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-select  :items="winkels" color="Sogyogroen" label="Winkel" item-text="winkelnaam" item-value="winkelId" v-on:change="setNieuwWinkelId" full-width></v-select>
                                </v-flex>
                                <v-flex xs12 sm6 md4>
                                    <v-text-field v-model="nieuweCategorie.volgordeNummer" label="Volgordenummer"></v-text-field>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-card-text>

                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" flat @click="close">Cancel</v-btn>
                        <v-btn color="blue darken-1" flat @click="createCategorie">Voeg toe</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>



        </v-toolbar>
        <v-data-table :headers="headers"
                      :items="categorien">
            <template v-slot:items="props">
                <td class="text-xs-left">{{ props.item.categorieNaam }}</td>
                <td class="text-xs-left">{{ props.item.winkel.winkelnaam }}</td>
                <td class="text-xs-left">{{ props.item.volgordeNummer }}</td>
                
                <td class="justify-center layout px-0">
                    <v-icon small
                            class="mr-2"
                            @click="editItem(props.item)">
                        edit
                    </v-icon>
                    <v-icon small
                            @click="deleteCategorie(props.item)">
                        delete
                    </v-icon>
                </td>
            </template>
            
        </v-data-table>
    </div>
</template>

<script src="./Categorie.component.js"></script>