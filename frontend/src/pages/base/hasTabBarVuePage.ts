import BaseVuePage from './baseVuePage';
import initStore from "@/store/init";
import { ITabBarInfo } from '@/store/init/types';

export default abstract class HasTabBarVuePage extends BaseVuePage {

    /**
     * TabBars的数据，来源于vuex
     *
     * @protected
     * @type {ITabBarItem[]}
     * @memberof HasTabBarVuePage
     */
    protected tabbar: ITabBarInfo = initStore.tabBarState;

    // 必须要有该方法，避免simple-router导致页面路由无效
    public abstract onLoad(): void;
}