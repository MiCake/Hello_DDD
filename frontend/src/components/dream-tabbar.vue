<template>
	<view v-if="isReady && tabbarList.length && showTabbar">
		<view class="cu-tabbar-height"></view>
		<view class="cu-bar tabbar bg-white shadow foot">
			<view v-for="(tab, index) in tabbarList" :key="tab.pagePath" class="action" @click="switchTabbar(tab)">
				<view class="cuIcon-cu-image">
					<image :src="currentPath == tab.pagePath ? tab.activeImage : tab.image" />
				</view>
				<view :class="currentPath == tab.pagePath?'text-select-color':'text-color'">{{tab.text}}</view>
			</view>
		</view>
	</view>
</template>

<script lang="ts">

import { Vue, Component, Model, Emit } from "vue-property-decorator";
import initStore from "@/store/init";
import { ITabBarItem } from '@/store/init/types';

@Component
export default class A extends Vue {
	@Model('change') readonly current!: ITabbarCurrentPath;

	isReady: boolean = false;

	public get tabbarList(): ITabBarItem[] {
		return initStore.tabBarState.items ?? [];
	}

	public get tabbarBgColor(): string {
		return initStore.tabBarState.bgColor;
	}

	public get showTabbar(): boolean {
		return this.tabbarList.map(s => s.pagePath).includes(this.currentPath);
	}

	public get currentPath() {
		if (!this.isReady)
			return '';

		let query = this.$Route.query;
		let currPage = this.$Route.path;
		if (Object.keys(query).length && currPage !== '/pages/index/index') {
			let params = '';
			for (let key in query) {
				params += '?' + key + '=' + query[key] + '&';
			}
			params = params.substring(0, params.length - 1);
			return currPage + params;
		}
		return currPage;
	}

	@Emit('change')
	switchTabbar(tab: ITabBarItem): ITabbarCurrentPath {
		if (tab.isCustom) {
			this.$Router.replace(tab.pagePath);
		} else {
			this.$Router.pushTab(tab.pagePath);
		}
		return { path: tab.pagePath, pathAlias: tab.pathAlias };
	}

	created() {
		(this as any).$AppReady?.then(() => {
			this.isReady = true;
		});
	}

	onLoad() {

	}
}

export interface ITabbarCurrentPath {
	path: string;
	pathAlias?: string;
}

</script>

<style lang="scss">
</style>
