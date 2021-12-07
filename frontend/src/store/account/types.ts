export interface LoginState {
    isLogin: boolean;
    token?: TokenStateInfo | null;
}

export interface TokenStateInfo {
    accessToken: string;
    expireTime: Date;
    refreshToken: string;
    refreshExpireTime: Date;
}

export interface IUserInfo {
    id?: number;
    avatar?: string | null;
    nickName?: string | null;
    gender?: number;
    state?: number;
}

const LoginStateKey: string = 'login-token';
const UserInfoStoreKey: string = 'user-info';

const DefaultTokenLife: { accessLifeDay: number; refreshLifeDay: number; } = { accessLifeDay: 15, refreshLifeDay: 30 };

export { LoginStateKey, UserInfoStoreKey ,DefaultTokenLife};