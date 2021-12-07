import { Module, VuexModule, Mutation, getModule, MutationAction } from "vuex-module-decorators";
import store from "@/store";
import { IUserInfo, LoginState, LoginStateKey, UserInfoStoreKey, DefaultTokenLife } from './types';
import { TimeHelper } from '@/common/utils/timeHelper';
import { ObjectHelper } from '@/common/utils/objectHelper';

@Module({
    dynamic: true,
    name: 'account',
    namespaced: true,
    store
})
export class AccountModule extends VuexModule {
    // public loginState: LoginState | null = { isLogin: true };       // only for test
    // public userState: IUserInfo | null = { avatar: null, nickName: 'DNF超哥', gender: 1 }; // only for test

    public loginState: LoginState | null = uni.getStorageSync(LoginStateKey);
    public userState: IUserInfo | null = uni.getStorageSync(UserInfoStoreKey);

    public beforeLoginPage: string | null = null;

    @Mutation
    setLoginInfo(data: { accessToken: string, refreshToken: string, userInfo: IUserInfo; }) {
        var result = {
            isLogin: true,
            token: {
                accessToken: data.accessToken,
                expireTime: TimeHelper.addDays(new Date(), DefaultTokenLife.accessLifeDay),
                refreshToken: data.refreshToken,
                refreshExpireTime: TimeHelper.addDays(new Date(), DefaultTokenLife.refreshLifeDay),
            }
        };
        this.userState = data.userInfo;
        this.loginState = result;

        uni.setStorageSync(UserInfoStoreKey, data.userInfo);
        uni.setStorageSync(LoginStateKey, result);
    }

    @Mutation
    removeLoginInfo() {
        this.loginState = null;
        uni.removeStorageSync(LoginStateKey);
    }

    @Mutation
    setBeforeLoginPage(pagePath: string) {
        this.beforeLoginPage = pagePath;
    }

    @MutationAction({ mutate: ['loginState', 'userState'] })
    async loginOut() {
        // 服务端退出
        var apiResult = await '';

        uni.removeStorageSync(LoginStateKey);
        uni.removeStorageSync(UserInfoStoreKey);

        return {
            loginState: null,
            userState: null
        };
    }
}

export default getModule(AccountModule);