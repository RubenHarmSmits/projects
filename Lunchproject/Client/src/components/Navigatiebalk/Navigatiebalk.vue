<template>

    <v-toolbar app color="Sogyogroen" dark>
        <router-link to="/">
        <v-toolbar-title>
            <v-avatar tile>
                <img :src="require('../../images/Sogyologo.jpg')" />
            </v-avatar>
            </v-toolbar-title>
        </router-link>
        <v-spacer></v-spacer>
        <v-toolbar-items>

            <v-btn depressed color="Sogyogroen" to="/"><span>Bestellen </span></v-btn>

            <v-btn depressed color="Sogyogroen" to="/bestelhistorie"><span>Bestelhistorie</span></v-btn>

            <v-btn depressed color="Sogyogroen" to="/bestellijst"><span>Bestellijst</span></v-btn>

            <v-btn depressed color="Sogyogroen" to="/winkeloverzicht"><span>Winkels</span></v-btn>

            <v-btn depressed color="Sogyogroen" to="/uitzonderingen"><span>Uitzonderingen</span></v-btn>

            <v-btn depressed color="Sogyogroen" to="/categorien"><span>Categorieën</span></v-btn>


                <v-divider vertical />
                <v-menu offset-y>
                    <template v-slot:activator="{ on }">
                        <v-btn depressed color="Sogyogroen" v-on="on">
                            <span style="margin: 10px">
                                {{ user.name }}
                            </span>
                            <v-spacer />
                            <v-avatar size="45">
                                <img :src="user.image" />
                            </v-avatar>
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-tile v-on:click="logout">
                            <v-list-tile-title>Logout</v-list-tile-title>
                        </v-list-tile>
                    </v-list>
                </v-menu>
        </v-toolbar-items>
    </v-toolbar>
</template>

<script src="./Navigatiebalk.component.js"></script>

