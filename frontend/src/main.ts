import Vue from 'vue';
import App from './App.vue';
import { router, RouterMount } from './common/router';
import store from "@/store";
import * as filters from "@/common/filters";

import request from "./common/request/request";
import { JwtRequestInterceptor } from "./common/jwt/jwtRequestInterceptor";

import cuCustom from '@/static/colorui/components/cu-custom.vue';

//引入全局uView
import uView from 'uview-ui';

Vue.use(uView);
Vue.use(router);

Vue.component('cu-custom', cuCustom);

Vue.filter('adjustEmpty', filters.adjustEmpty);
Vue.filter('dateformat', filters.dateformat);
Vue.filter('resizeImage', filters.resizeImage);

//引入Request
request.intercepstors.beforeInterceptors.push(new JwtRequestInterceptor());

Vue.config.productionTip = false;
const app = new Vue({
    ...App,
    store
});

// #ifdef H5
RouterMount(app, router, '#app');
// #endif

// #ifndef H5
app.$mount(); //为了兼容小程序及app端必须这样写才有效果
// #endif
