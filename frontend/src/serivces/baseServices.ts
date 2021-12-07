import ApiRequst from '@/common/request';
import { API_URL } from "@/env";

const apiRequestInstance = new ApiRequst();

/**
 * Api请求服务的基类
 *
 * @export
 * @abstract
 * @class BaseServices
 */
export abstract class BaseServices {

    public get baseUrl(): string {
        return API_URL as string;
    }


    /**
     *
     * 聚合服务的url
     * @readonly
     * @abstract
     * @type {string}
     * @memberof BaseServices
     */
    public abstract get url(): string;


    /**
     *
     * 该服务的url
     * @readonly
     * @abstract
     * @type {string}
     * @memberof BaseServices
     */
    public abstract get subUrl(): string;

    protected request: ApiRequst = apiRequestInstance;
}
