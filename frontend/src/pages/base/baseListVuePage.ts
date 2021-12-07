import { DefaulPageNumber } from '../common/constants';
import BaseVuePage from './baseVuePage';

export default abstract class BaseListVuePage<T> extends BaseVuePage {

    protected currentPage: number = 1;
    protected pageSize: number = DefaulPageNumber;
    protected totalCount: number = 0;

    protected selectedRows: T[] | null = [];
    protected listData: T[] | null = [];

    protected status: string = '';

    protected getCurrentItemIndex(index: number) {
        return this.pageSize * (this.currentPage - 1) + index + 1;
    }

    protected abstract goDetail(data: T): void;

    protected async loadMore() {
        if (this.hasNoMore) {
            this.status = 'nomore';
            return;
        }

        this.status = 'loading';
        this.currentPage = ++this.currentPage;

        try {
            await this.getDataFormService(this.currentPage);
        } finally {
            this.status = this.hasNoMore ? 'nomore' : '';
        }
    }

    public get hasNoMore(): boolean {
        return this.listData!.length >= this.totalCount;
    }


    public get showLoadMore(): boolean {
        return !(this.currentPage == 1 && this.hasNoMore);
    }
}
