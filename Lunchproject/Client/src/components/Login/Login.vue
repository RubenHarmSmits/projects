<template>
    <v-layout align-center justify-center fill-height column>
        <v-card>
            <v-card-actions class="justify-center">
                <v-btn v-bind:loading="loading" v-bind:disabled="!googleAuth" flat id="google-button" ref="google_button">
                    <v-icon>account_circle</v-icon> Google
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-layout>
</template>

<script src="./Login.component.js">

</script>


