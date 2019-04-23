<template>
    <div>
        <br />
        <br />
        <v-toolbar>
            <v-btn-toggle v-model="typeUitzondering" class="transparent" v-on:change="resetWaardes">
                <v-btn value="bezorgdagWijzigen" color="Sogyolichtgroen" class="Sogyogroen--text" depressed> Bezorgdag wijzigen </v-btn>

                <v-btn value="bezorgdagToevoegen" color="Sogyolichtgroen" class="Sogyogroen--text" depressed> Bezorgdag toevoegen </v-btn>

                <v-btn value="bezorgdagVerwijderen" color="Sogyolichtgroen" class="Sogyogroen--text" depressed> Bezorgdag verwijderen </v-btn>

                <v-btn value="winkelVeranderen" color="Sogyolichtgroen" class="Sogyogroen--text" depressed> Winkel veranderen </v-btn>

                <v-btn value="deadlineVerplaatsen" color="Sogyolichtgroen" class="Sogyogroen--text" depressed> Deadline verplaatsen </v-btn>
            </v-btn-toggle>
        </v-toolbar>

        <br />
        <v-flex xs12 sm12>
            <div name="bezorgdagWijzigen" v-if="typeUitzondering == 'bezorgdagWijzigen'">
                <v-toolbar>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="typeUitzondering== null" slot="activator" label="Kies de huidige bezorgdag" v-model="computedVerwijderDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable locale="nl-NL" first-day-of-week="1" v-model="verwijderDatum" :allowed-dates="filterDatums"></v-date-picker>
                    </v-menu>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="verwijderDatum== null" slot="activator" label="Kies een nieuwe bezorgdag" v-model= "computedDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable locale="nl-NL" first-day-of-week="1" v-model="datum" :allowed-dates="filterLegeDatums"></v-date-picker>
                    </v-menu>
                    <v-select :disabled="datum == null" :items="winkels" color="Sogyogroen" label="Kies de nieuwe winkel" item-text="winkelnaam" item-value="winkelId" v-on:change="setWinkelId" full-width></v-select>
                    <v-menu lazy :disabled="winkelId == null" transition="scale-transition" :close-on-content-click="true">
                        <v-text-field slot="activator" color="Sogyogroen" :disabled="winkelId == null" prepend-icon="event" label="Kies de deadlinedag" v-model="computedDeadlineDag" readonly> </v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable :disabled="winkelId == null" locale="nl-NL" v-model="deadlineDag" :min="datumVandaag" :max="datum" first-day-of-week="1"></v-date-picker>
                    </v-menu>
                    <v-text-field v-model="deadlineTijd" color="Sogyogroen" :rules="[rules.required, rules.tijdRule]" :disabled="winkelId == null" prepend-icon="watch" full-width label="Kies de deadline tijd"></v-text-field>
                    <v-btn @click="wijzigBezorgdatum" color="Sogyogroen" small :disabled="deadlineDag==null">
                        <v-icon color="white">edit</v-icon> <font color="white">Wijzig Bezorgdag</font>
                    </v-btn>
                </v-toolbar>
            </div>
            <div name="bezorgdagToevoegen" v-if="typeUitzondering == 'bezorgdagToevoegen'">
                <v-toolbar>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="typeUitzondering== null" slot="activator" label="Kies een bezorgdag" v-model="computedDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" v-model="datum" scrollable locale="nl-NL" first-day-of-week="1" :allowed-dates="filterLegeDatums"></v-date-picker>
                    </v-menu>
                    <v-select :disabled="datum == null" :items="winkels" color="Sogyogroen" label="Kies een winkel" item-text="winkelnaam" item-value="winkelId" v-on:change="setWinkelId" full-width></v-select>
                    <v-menu lazy :disabled="winkelId == null" transition="scale-transition" :close-on-content-click="true">
                        <v-text-field slot="activator" color="Sogyogroen" :disabled="winkelId == null" prepend-icon="event" label="Kies een deadlinedag" v-model="computedDeadlineDag" readonly> </v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable :disabled="winkelId == null" locale="nl-NL" :min="datumVandaag" :max="datum" first-day-of-week="1" v-model="deadlineDag"></v-date-picker>
                    </v-menu>
                    <v-text-field v-model="deadlineTijd" color="Sogyogroen" :rules="[rules.required, rules.tijdRule]" :disabled="winkelId == null" prepend-icon="watch" full-width label="Kies de deadline tijd"></v-text-field>
                    <v-btn @click="addUitzondering" color="Sogyogroen" small :disabled="deadlineDag==null"><v-icon color="white">add</v-icon> <font color="white">voeg Bezorgdag toe</font></v-btn>
                </v-toolbar>
            </div>
            <div name="bezordagVerwijderen" v-if="typeUitzondering == 'bezorgdagVerwijderen'">
                <v-toolbar>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="typeUitzondering== null" slot="activator" label="Kies een bezorgdag" v-model="computedVerwijderDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable locale="nl-NL" first-day-of-week="1" :allowed-dates="filterDatums" v-model="verwijderDatum"></v-date-picker>
                    </v-menu>
                    <v-btn @click="addVerwijderUitzondering" color="Sogyogroen" small :disabled="verwijderDatum==null"> <v-icon color="white">delete</v-icon> <font color="white">verwijder Bezorgdag</font></v-btn>
                </v-toolbar>
            </div>
            <div name="winkelVeranderen" v-if="typeUitzondering == 'winkelVeranderen'">
                <v-toolbar>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="typeUitzondering== null" slot="activator" label="Kies een bezorgdag" v-model="computedDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" v-model="datum" scrollable locale="nl-NL" first-day-of-week="1" :allowed-dates="filterDatums" v-on:change="setWinkelsGefilterd"></v-date-picker>
                    </v-menu>
                    <v-select :disabled="datum == null" :items="winkelsGefilterd" color="Sogyogroen" label="Kies de nieuwe winkel" item-text="winkelnaam" item-value="winkelId" v-on:change="setWinkelId" full-width></v-select>
                    <v-menu lazy :disabled="winkelId == null" transition="scale-transition" :close-on-content-click="true">
                        <v-text-field slot="activator" color="Sogyogroen" :disabled="winkelId == null" prepend-icon="event" label="Kies een deadlinedag" v-model="computedDeadlineDag" readonly> </v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable :disabled="winkelId == null" locale="nl-NL" :min="datumVandaag" :max="datum" v-model="deadlineDag" first-day-of-week="1"></v-date-picker>
                    </v-menu>
                    <v-text-field v-model="deadlineTijd" color="Sogyogroen" :rules="[rules.required, rules.tijdRule]" :disabled="winkelId == null" prepend-icon="watch" full-width label="Kies de deadline tijd"></v-text-field>
                    <v-btn @click="veranderWinkel" color="Sogyogroen" small :disabled="deadlineDag==null"> <v-icon color="white">edit</v-icon> <font color="white">verander Winkel</font></v-btn>
                </v-toolbar>
            </div>
            <div name="deadlineVerplaatsen" v-if="typeUitzondering == 'deadlineVerplaatsen'">
                <v-toolbar>
                    <v-menu lazy :close-on-content-click="true" transition="scale-transition">
                        <v-text-field color="Sogyogroen" :disabled="typeUitzondering== null" slot="activator" label="Kies een bezorgdag" v-model= "computedDatum" prepend-icon="event" readonly></v-text-field>
                        <v-date-picker color="Sogyogroen" v-model="datum" scrollable locale="nl-NL" first-day-of-week="1" :allowed-dates="filterDatums" v-on:change="getWinkelIdPerDatum"></v-date-picker>
                    </v-menu>
                    <v-menu lazy :disabled="datum == null" transition="scale-transition" :close-on-content-click="true">
                        <v-text-field slot="activator" color="Sogyogroen" :disabled="datum == null" prepend-icon="event" label="Kies een deadlinedag" v-model="computedDeadlineDag" readonly> </v-text-field>
                        <v-date-picker color="Sogyogroen" scrollable :disabled="datum == null" locale="nl-NL" :min="datumVandaag" :max="datum" v-model="deadlineDag" first-day-of-week="1"></v-date-picker>
                    </v-menu>
                    <v-text-field v-model="deadlineTijd" color="Sogyogroen" :rules="[rules.required, rules.tijdRule]" :disabled="deadlineDag == null" prepend-icon="watch" full-width label="Kies de deadline tijd"></v-text-field>
                    <v-btn @click="addUitzondering" color="Sogyogroen" small :disabled="deadlineDag==null"> <v-icon color="white">edit</v-icon> <font color="white">verplaats Deadline</font></v-btn>
                </v-toolbar>
            </div>
        </v-flex>
        <v-dialog v-model="popup" max-width="290">
            <v-card>
                <v-card-text>Let op! Door het toevoegen van deze uitzondering worden mogelijk oude bestellingen op deze dag verwijderd.</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn @click="popup = false">OK</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
        <br /><br /><br />
        <v-card>
            <v-data-table :headers="headers"
                          :items="uitzonderingen"
                          hide-actions>
                <template v-slot:items="props">
                    <td>{{ datumGeformatteerd(props.item.date.substring(0,10)) }}</td>
                    <td>{{ getWinkelnaam(props.item.winkel)}}</td>
                    <td>{{ getDeadlineDag(props.item)}}</td>
                    <td>{{ getDeadlineTijd(props.item)}}</td>
                    <td>
                        <v-btn icon class="mx-0" @click="deleteUitzondering(props.item.date)">
                            <v-icon color="Sogyogroen">delete</v-icon>
                        </v-btn>
                    </td>
                </template>
                <template slot="no-data">
                    <v-alert :value="true" color="Sogyogroen" icon="warning">
                        Nog geen uitzonderingen toegevoegd.
                    </v-alert>
                </template>
            </v-data-table>
        </v-card>
    </div>
</template>
<script src="./Uitzonderingen.component.js"></script>
