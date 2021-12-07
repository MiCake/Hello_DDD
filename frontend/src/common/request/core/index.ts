export interface HttpRequestOptions {
    /**
    * 请求的参数
    */
    data?: string | AnyObject | ArrayBuffer;

    /**
     * 设置请求的 header，header 中不能设置 Referer。
     */
    header?: any;

    /**
     * 默认为 GET
     * 可以是：OPTIONS，GET，HEAD，POST，PUT，DELETE，TRACE，CONNECT
     */
    method?: 'OPTIONS' | 'GET' | 'HEAD' | 'POST' | 'PUT' | 'DELETE' | 'TRACE' | 'CONNECT';

    /**
     * 超时时间
     */
    timeout?: number;

    /**
     * 如果设为json，会尝试对返回的数据做一次 JSON.parse
     */
    dataType?: string;

    /**
     * 设置响应的数据类型。合法值：text、arraybuffer
     */
    responseType?: string;

    /**
     * 验证 ssl 证书
     */
    sslVerify?: boolean;

    /**
     * 跨域请求时是否携带凭证
     */
    withCredentials?: boolean;
}

export interface IHttpReponseInfo {
    /**
     * 开发者服务器返回的数据
     */
    data: string | AnyObject | ArrayBuffer;
    /**
     * 开发者服务器返回的 HTTP 状态码
     */
    statusCode: number;
    /**
     * 开发者服务器返回的 HTTP Response Header
     */
    header: any;
    /**
     * 开发者服务器返回的 cookies，格式为字符串数组
     */
    cookies: string[];
}

export interface IHttpRequestFailedInfo {
    /**
     * 错误信息
     */
    errMsg: string;
}

export interface IHttpInterceptor {

}


/**
 * http请求开始之前的拦截器
 *
 * @export
 * @extends {IHttpInterceptor}
 */
export interface IRequestBeforeInterceptor extends IHttpInterceptor {
    handle(options: HttpRequestOptions): Promise<any>;
}

/**
 * http请求完成之后的拦截器
 *
 * @export
 * @extends {IHttpInterceptor}
 */
export interface IRequestCompletedInterceptor extends IHttpInterceptor {
    handle(res: IHttpReponseInfo): Promise<any>;
}

/**
 * http请求错误的拦截器
 *
 * @export
 * @extends {IHttpInterceptor}
 */
export interface IRequestFailedInterceptor extends IHttpInterceptor {
    handle(data: IHttpRequestFailedInfo): Promise<any>;
}