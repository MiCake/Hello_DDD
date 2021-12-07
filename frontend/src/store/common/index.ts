import { Module, VuexModule, Mutation, getModule } from "vuex-module-decorators";
import store from "@/store";

@Module({
    dynamic: true,
    name: 'common',
    namespaced: true,
    store
})
export class CommonModule extends VuexModule {

    public needRefreshPage: boolean = false;

    @Mutation
    setNeedRefreshPage(need: boolean) {
        this.needRefreshPage = need;
    }

}

export default getModule(CommonModule);