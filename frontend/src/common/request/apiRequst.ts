import { ApiResponse } from '@/models/commonModel';
import { DelayHelper } from '../utils/dealyHelper';
import { HttpRequestOptions } from './core';
import request from "./request";

export default class ApiRequst {

    /**
     *
     * 发起一个API请求
     * @static
     * @template T 返回类型
     * @param {string} url url地址
     * @param {ApiRequestMethod} method 请求类型
     * @param {*} [data=undefined] 请求参数
     * @param {*} [config=undefined] Axios的配置
     * @returns
     * @memberof ApiRequst
     */
    public async request<T>(url: string, method: ApiRequestMethod, data?: any, config?: any) {
        let result;

        const options: HttpRequestOptions = {
            method: ApiRequestMethod[method] as any,
            data,
            ...config
        };

        result = request.request(url, options);
        const apiResponse = await result;

        const apiRes = (apiResponse).data;
        const successData = apiRes as ApiResponse<T>;
        
        if (successData) {
            if (successData.isError) {
                uni.showToast({
                    title: successData.message || '请求出错,稍后重试',
                    icon: 'none',
                    duration: 1000,
                    mask: true
                });
            }
            return successData.result;
        }
    }

    public async delayRequest<T>(url: string, method: ApiRequestMethod, data?: any, config?: any, delay: number = 1000) {
        await DelayHelper.delay(delay);
        return this.request<T>(url, method, data, config);
    }
}

export enum ApiRequestMethod {
    Get = "Get",
    Post = "Post",
    Put = "Put",
    Delete = "Delete",
}