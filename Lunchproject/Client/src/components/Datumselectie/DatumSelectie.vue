<template>
    <v-flex mt-3 pt-1>
        <v-menu lazy
                v-model="menu"
                transition="scale-transition"
                :close-on-content-click="true">
            <v-text-field slot="activator"
                          label="Kies een datum"
                          prepend-icon="event"
                          v-model="computedDatum"                          
                          readonly
                          color="Sogyolichtgroen">
            </v-text-field>
            <v-date-picker v-model="datum"
                           color="Sogyogroen"
                           scrollable
                           locale="nl-NL"
                           first-day-of-week="1"
                           :allowed-dates="filterDatums"
                           v-on:change="emitDatumUpdate"></v-date-picker>
        </v-menu>
       
    </v-flex>
</template>

<script src="./DatumSelectie.component.js"></script>