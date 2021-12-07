/* tslint:disable */
/* eslint-disable */

/**
 * 通用的分页List模型
 *
 * @export
 * @interface PagingListModel
 * @template T 列表项模型
 */
export interface PagingListModel<T> {
    totalCount: number;
    detail: T[];
}

/**
 * Api通用返回模型
 *
 * @export
 * @interface ApiResponse
 * @template T
 */
export interface ApiResponse<T> {
    result: T;
    statusCode: number;
    isError: boolean;
    errorCode: string;
    message: string;
}

/**
 * api请求分页时候的模型
 *
 * @export
 * @interface ApiPagingModel
 */
export class ApiPagingModel {
    public page: number = 1;
    public pageNum?: number = 10;

    constructor(page: number, pageNum?: number) {
        this.page = page;
        this.pageNum = pageNum || 10;
    }
}

/**
 * 简单化的dto对象，方便基元类型参数转换为json结构
 *
 * @export
 * @class SimpleDto
 * @template T
 */
export class SimpleDto<T> {
    public data?: T;

    constructor(data: T) {
        this.data = data;
    }
}


/**
 * 通用的经纬度模型
 *
 * @export
 * @interface IMapPoint
 */
export interface IMapPoint {
    lng: number;
    lat: number;
}