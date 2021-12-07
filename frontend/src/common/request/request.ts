import {
	HttpRequestOptions,
	IRequestCompletedInterceptor,
	IRequestBeforeInterceptor,
	IRequestFailedInterceptor,
	IHttpReponseInfo,
	IHttpRequestFailedInfo
} from './core';

const defaultHttpOptions: HttpRequestOptions = {
	header: { 'content-type': 'application/json' },
	method: 'GET',
	dataType: 'json',
	withCredentials: true,
	timeout: 30000,
	sslVerify: true
};

export class Request {

	private config: HttpRequestOptions = defaultHttpOptions;

	intercepstors: IRequestInterceptors = {
		beforeInterceptors: [],
		afterInterceptors: [],
		failedInterceptors: [],
	};

	static posUrl(url: string) { /* 判断url是否为绝对路径 */
		return /(http|https):\/\/([\w.]+\/?)\S*/.test(url);
	}

	async request(url: string, options?: HttpRequestOptions) {
		let currentConfig = options ?? this.config;

		for (const interceptor of this.intercepstors.beforeInterceptors) {
			await interceptor.handle(currentConfig);
		}

		const uniRequestOptions: UniApp.RequestOptions = { url, ...currentConfig };
		var data = await this.waitingUniRequestResult(uniRequestOptions);

		if ((<UniApp.RequestSuccessCallbackResult>data).statusCode) {
			await this.uniRequestCompleteCallback(<UniApp.RequestSuccessCallbackResult>data);
		} else {
			const errorData = <UniApp.GeneralCallbackResult>data;
			await this.uniRequestFailedCallback(errorData);
			throw new Error(errorData.errMsg);
		}

		return (<UniApp.RequestSuccessCallbackResult>data) as IHttpReponseInfo;
	}

	private waitingUniRequestResult(options: UniApp.RequestOptions): Promise<UniApp.RequestSuccessCallbackResult | UniApp.GeneralCallbackResult> {
		return new Promise((resolve, reject) => {
			uni.request({
				...options, success: (data) => resolve({ ...data }),
				fail: (data) => resolve(data),
			});
		});
	}

	private async uniRequestCompleteCallback(result: UniApp.RequestSuccessCallbackResult) {
		const res: IHttpReponseInfo = { ...result };
		for (const interceptor of this.intercepstors.afterInterceptors) {
			await interceptor.handle(res);
		}
	}

	private async uniRequestFailedCallback(result: UniApp.GeneralCallbackResult) {
		const res: IHttpRequestFailedInfo = { ...result };
		for (const interceptor of this.intercepstors.failedInterceptors) {
			await interceptor.handle(res);
		}
	}

	/**
	 *
	 *
	 * @param {HttpRequestOptions} config
	 * @memberof Request
	 */
	public setConfig(config: HttpRequestOptions) {
		this.config = config;
	}
}

export interface IRequestInterceptors {

	beforeInterceptors: IRequestBeforeInterceptor[];

	afterInterceptors: IRequestCompletedInterceptor[];

	failedInterceptors: IRequestFailedInterceptor[];
}

// 全局单例
const request = new Request();
export default request;
