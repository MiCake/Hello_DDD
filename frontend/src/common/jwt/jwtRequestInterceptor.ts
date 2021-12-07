import { HttpRequestOptions, IRequestBeforeInterceptor } from '../request/core';
import accountStore from "@/store/account";

export class JwtRequestInterceptor implements IRequestBeforeInterceptor {
    async handle(options: HttpRequestOptions): Promise<any> {
        if (accountStore.loginState?.isLogin) {
            var token = accountStore.loginState.token?.accessToken;
            options.header = { ...options.header, 'authorization': `Bearer ${token}` };
        }
    }
}