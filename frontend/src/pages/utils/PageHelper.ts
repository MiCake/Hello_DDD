import isEmpty from 'lodash/isEmpty';
import accountStore from "@/store/account";
import { Router } from 'uni-simple-router';

export class PageHelper {
    /**
     *
     * 跳转到登录之前的页面
     * @public
     * @param {Router} router
     * @memberof PageHelper
     */
    public static naviToBeforeLoginPath(router: Router) {
        if (isEmpty(accountStore.beforeLoginPage)) {
            router.push('/pages/index/index');
        } else {
            router.push(accountStore.beforeLoginPage!);
        }
    }
}