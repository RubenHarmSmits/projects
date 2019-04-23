<template>
    <div>

            <v-layout row>
                <v-flex lg6 justify-self-space-around>
                        <router-view class="us__content" />
                </v-flex>
               
                <v-flex lg6>
                    <router-view name="helper" class="us__content us__content--helper" />
                </v-flex>
            </v-layout>

    </div>
</template>

<script>
   
    import Bestelling from './components/Bestelling/Bestelling.vue';
    import Producten from './components/Producten/Producten.vue';


    export default {
        name: 'Home',
        components: {
            Producten,
            Bestelling
        }
    }
</script>