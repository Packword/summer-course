<template>
  <label>Введите число:</label>
  <input type="number" v-model="number">
  <TableComponent :number="number"/>
  <!--
  <div>123</div>
  <router-view/>
  -->
</template>

<script>
import TableComponent from "@/components/table"
export default {
  name: 'App',
  components : 
  {
    TableComponent
  },
  data(){
    return {
      number: 0
    }
  }
}
</script>

<style>
</style>
