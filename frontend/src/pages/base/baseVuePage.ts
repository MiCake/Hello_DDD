import { Vue } from "vue-property-decorator";
import { isEmpty, isNil } from 'lodash';
import commonState from "@/store/common";

export default abstract class BaseVuePage extends Vue {

    protected isLoading: boolean = false;
    protected hasSubmitted: boolean = false;

    protected pageHasLoaded: boolean = false;

    public get CustomBar(): string {
        return Vue.prototype.CustomBar;
    }

    public get PageNeedRefresh(): boolean {
        return commonState.needRefreshPage ?? false;
    }

    protected async loadData(data?: number | any) {
        try {
            this.pageHasLoaded = true;
            this.isLoading = true;
            uni.showLoading({ title: '加载中' });

            await this.getDataFormService(data);

        } catch (ex) {
            console.error(ex);
            this.$u.toast('请求出错');
        } finally {
            this.isLoading = false;
            uni.hideLoading();
        }
    }

    protected abstract getDataFormService(data?: number | any): Promise<any>;

    protected async doThing<T>(thing: () => Promise<T>, loadingContent: string = '') {
        var content = isEmpty(loadingContent) ? '请稍后' : loadingContent;
        let result: T | null = null;
        try {
            uni.showLoading({ title: content, mask: true });
            result = await thing();
        } catch {
            this.$u.toast('操作失败');
        } finally {
            uni.hideLoading();
        }
        return result;
    }

    protected showToast(msg: string, duration: number = 1000) {
        this.$u.toast(msg, duration);
    }

    protected nextPageRefresh() {
        commonState.setNeedRefreshPage(true);
    }

    protected nextPageNotRefresh() {
        commonState.setNeedRefreshPage(false);
    }

    protected doRefresh(refreshAction: null | (() => void) = null) {
        if (this.PageNeedRefresh && this.pageHasLoaded) {
            if (refreshAction) {
                refreshAction();
            } else {
                this.loadData();
            };
        }
    }
}
