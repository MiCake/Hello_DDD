/**
 * 自定义Modal类型组件的操作接口
 *
 * @export
 * @interface IPageModal
 */
export interface IPageModal {
    visible: boolean;

    /**
     * 显示Modal
     *
     * @param {boolean} forceFresh 是否强制刷新
     * @memberof IPageModal
     */
    showModal(data?: PageModalTransmitModel): void;

    /**
     * 隐藏显示该Modal
     *
     * @memberof IPageModal
     */
    hideModal(): void;
}


/**
 * 在Modal显示的时候，传递给Modal组件的数据
 *
 * @export
 * @interface PageModalTransmitModel
 */
export interface PageModalTransmitModel {
    forceRefresh?: boolean;
    content?: any;
}

/**
 * 将类型转换为 @interface IPageModal
 *
 * @export
 * @class PageMdalConventer
 */
export class PageModalConverter {
    public static convert(type: any): IPageModal {
        return type as IPageModal;
    }
}

import BaseVuePage from './baseVuePage';

export default abstract class BaseModalVuePage extends BaseVuePage implements IPageModal {
    visible: boolean = false;
    transmitData?: PageModalTransmitModel;

    async getDataFormService(): Promise<any> {

    }

    showModal(data?: PageModalTransmitModel): void {
        this.visible = true;
        this.transmitData = data;
    }

    hideModal(): void {
        this.visible = false;
    }
}
