<template>

    <v-app>
        <Navigatiebalk v-if="authenticated"></Navigatiebalk>
        <v-content>
            <v-layout align-center justify-center column fill-height>
                    <v-alert dismissible dense
                        v-if="message"
                        v-on:input="onClearMessage"
                        v-bind:type="message.status"
                        v-bind:value="message">
                            {{ message.message }}
                    </v-alert>
                    <v-container fluid>
                        <router-view id="view"></router-view>
                    </v-container>
            </v-layout>
        </v-content>
    </v-app>
</template>
<script src="./app.view.js">

</script>
