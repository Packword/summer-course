<template>
    <input type="number" v-model="number"/>
    <tableComponent :inputNumber="number" @noteisview="logEmit" @propIncrement="changeNumber"/>
    <router-link to="/home">Домой</router-link>
    <router-view />

    <div>Актуальное число в родителе: {{ number }}</div>
</template>

<script>
import tableComponent from "@/components/table"

export default {
  name: 'App',
  components:{
    tableComponent
  },
  data(){
    return {
      number: 0,
    }
  },
  beforeCreate(){
    console.log("beforeCreate")
  },

  
  beforeUpdate(){
    console.log("beforeUpdate")
  },

  updated(){
    console.log("updated")
  },

  unmounted(){
    console.log("unmounted")
  },

  methods:{
    logEmit(message){
      alert(message);
    },
    changeNumber(number){
      this.number = number;
    }
  }
}
</script>

<style>
</style>
