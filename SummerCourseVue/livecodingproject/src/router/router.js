import {createRouter, createWebHistory} from "vue-router"
import home from "@/components/home.vue"
import info from "@/components/info.vue"

const routes = [
    {
        path: "/home",
        component: home
    },
    {
        path: "/info",
        component: info
    }
];

const router = createRouter({
    routes: routes,
    history: createWebHistory()
});

export default router;