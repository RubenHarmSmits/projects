<template>
    <v-layout row>
        <v-flex xs12 sm6 offset-sm3 mt-4>
            <v-btn-toggle v-model="toggle" mandatory>
                <v-btn v-for="winkel in winkels">{{ winkel.winkelnaam }}</v-btn>
            </v-btn-toggle>
            <v-card>
                <v-toolbar color="Sogyogroen" dark>
                    <v-toolbar-side-icon></v-toolbar-side-icon>
                    <v-toolbar-title>{{ winkel.winkelnaam }} - Producten</v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-text-field
                        color="Sogyolichtgroen"
                        v-model="search"
                        append-icon="search"
                        label="Zoek product"
                        single-line
                        hide-details>
                    </v-text-field>
                </v-toolbar>

                <v-data-table id="tabel"
                              :headers="headers"
                              :items="producten"
                              :search="search"
                              :items-per-page="-1"
                              rows-per-page-text="Aantal per pagina"
                              class="elevation-1"
                              rows-per-page-color="Sogyogroen">
                    <template v-slot:items="props">
                        <td>{{ props.item.naam }}</td>
                        <td>{{ '€' + prijsGeformatteerd(props.item.prijs) }}</td>
                    </template>
                    <v-alert v-slot:no-results :value="true" color="error" icon="warning">
                        Your search for "{{ search }}" found no results.
                    </v-alert>
                    <template v-slot:pageText="props">
                        {{props.pageStart}} - {{props.pageStop}} van {{props.itemsLength}}
                        </template>
                </v-data-table>
            </v-card>
        </v-flex>
    </v-layout>
</template>

<script src="./Winkeloverzicht.component.js"></script>