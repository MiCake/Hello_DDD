import { RouterMount, createRouter } from 'uni-simple-router';

//初始化
const router = createRouter({
    APP: {
        animation: {
            animationType: 'pop-in',
            animationDuration: 300
        }
    },
    platform: process.env.VUE_APP_PLATFORM,
    encodeURI: false,
    routes: [...ROUTES] //路由表
});

//全局路由前置守卫
router.beforeEach((to, from, next) => {
    // 有两个个判断条件,一个是token,还有一个路由元信息
    // let userInfo = Boolean(uni.getStorageSync('userInfo'));
    // 权限控制登录
    // if (to.meta && to.meta.auth && !userInfo) {
    //     store.commit('LOGIN_TIP', true);
    // } else {
    // }

    next();
});

export {
    router,
    RouterMount
};
