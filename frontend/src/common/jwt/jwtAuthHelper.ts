import accountStore from "@/store/account";
import { TimeHelper } from '../utils/timeHelper';

export class JwtAuthHelper {

    public static getCurrentState(): JwtCurrentState {
        if (accountStore.loginState?.isLogin) {
            var loginInfo = accountStore.loginState.token;

            var accessTokenExpired = TimeHelper.isBefore(new Date(), loginInfo?.expireTime!);
            var refreshTokenExpired = TimeHelper.isBefore(new Date(), loginInfo?.refreshExpireTime!);

            if (accessTokenExpired && refreshTokenExpired) {
                return JwtCurrentState.TokenExpired;
            } else if (accessTokenExpired && !refreshTokenExpired) {
                return JwtCurrentState.NeedRefreshToken;
            } else {
                return JwtCurrentState.HasLogin;
            }
        } else {
            return JwtCurrentState.NoLogin;
        }
    }
}


export enum JwtCurrentState {
    /**
     * 没有登录
     */
    NoLogin,

    /**
     * 已经登录 且状态正常
     */
    HasLogin,

    /**
     * 需要通过refreshToken来刷新token
     */
    NeedRefreshToken,

    /**
     * token都已经过期
     */
    TokenExpired,
}