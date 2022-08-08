import Vue from 'vue'
import VueRouter from 'vue-router'
import TableView from '../Views/TableView.vue'

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Table',
        component: TableView

    },
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.base,
    routes
})

export default router
