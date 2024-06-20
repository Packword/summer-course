<template>
    <div>
        <table>
            <tr>
                <th v-for="num in numbers" :key="num">
                    {{ num }}
                </th>
            </tr>
            <tr>
                <td v-for="num in numbers" :key="num">
                    {{ num * number }}
                </td>
            </tr>
        </table>
    </div>
</template>
<script>
export default {
    name: "table-component",
    data(){
        return {
            numbers: [1,2,3,4,5,6,7,8,9,10]
        }
    },
    props: {
        number: Number
    }
}
</script>
<style>
    th {
        width: 50px;
        height: 50px;
        border: 2px solid black;
    }
    td {
        text-align: center;
        width: 50px;
        height: 50px;
        border: 2px solid black;
    }
</style>