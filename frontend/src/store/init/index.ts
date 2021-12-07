import { Module, VuexModule, getModule } from "vuex-module-decorators";
import store from "@/store";
import { IBannerItem, IMenuItem, ITabBarInfo } from './types';
import { defalutBanners, defaultMenus, defaultTabBars } from './default';

@Module({
    dynamic: true,
    name: 'init',
    namespaced: true,
    store
})
export class InitModule extends VuexModule {

    /**
     * 底部导航
     *
     * @type {ITabBarInfo}
     * @memberof InitModule
     */
    public tabBarState: ITabBarInfo = { bgColor: '#fff', items: defaultTabBars };

    /**
     *
     * 首页快捷菜单
     * @type {IMenuItem[]}
     * @memberof InitModule
     */
    public meunState: IMenuItem[] = defaultMenus;


    /**
     * 默认banner图片
     *
     * @type {IBannerItem[]}
     * @memberof InitModule
     */
    public bannerState: IBannerItem[] = defalutBanners;
}

export default getModule(InitModule);