<template>
    <div>
        <button @click="incrementValues">Увеличить значения</button>
        <button @click="incrementInput">Увеличить родителя</button>
        <button @mouseup="notifyParent">Отожми меня</button>
        <table>
            <tr>
                <th v-for="num in numbers" :key="num">
                    {{ num }}
                </th>
            </tr>
            <tr>
                <td v-for="num in numbers" :key="num">
                    {{num * inputNumber}}
                </td>
            </tr>
        </table>
    </div>
</template>

<script>

export default {
    name: "table-component",
    data(){
        return{
            numbers: [1,2,3,4,5,6,7,8,9,10]
        }
    },

    props: {
        inputNumber: {
            type: Number,
            default: () => 0
        }
    },

    methods: {
        notifyParent(){
            this.$emit("noteisview", "меня отжали!");
        },
        incrementValues(){
            for(let i = 0; i < 10; i++){
                this.numbers[i]++;
            }
        },
        incrementInput(){
            this.$emit("propIncrement", this.inputNumber + 1)
        }
    }
}
</script>

<style scoped>
    th {
        width: 50px;
        height: 50px;
        border: 2px solid black;
    }
    td {
        width: 50px;
        height: 50px;
        border: 2px solid black;
    }
</style>