<template>
	<view class="page-container">
		<!-- 导航栏 -->
		<dream-navbar :title="title" :bgColor="bgColor"></dream-navbar>

		<dm-banner :detail="viewData.banners" @getbgcolor="getBgColorHandler"></dm-banner>
		<dm-menu :detail="viewData.menus"></dm-menu>
		<my-today-lesson></my-today-lesson>

		<dream-tabbar></dream-tabbar>
	</view>
</template>

<script lang="ts">
import { Component } from "vue-property-decorator";
import dmBanner from "@/pages/common/components/dm-banner.vue";
import dmMenu from "@/pages/common/components/dm-meun.vue";

import initStore from "@/store/init";

import * as Models from "@/store/init/types";
import HasTabBarVuePage from '../base/hasTabBarVuePage';
import HomeAdv, { IHomeAdvModel } from "./components/home-adv.vue";
import MyTodayLesson from "./components/my-today-lesson.vue";

@Component({
	components: {
		dmBanner,
		dmMenu,
		HomeAdv,
		MyTodayLesson
	}
})
export default class A extends HasTabBarVuePage {
	title: string = "内居·绝卷";
	bgColor: string = '';
	viewData: CurrentViewModel = new CurrentViewModel();

	advs: IHomeAdvModel[] = [];

	protected getDataFormService(data?: any): Promise<any> {
		throw new Error('Method not implemented.');
	}

	public onLoad(): void {
		this.viewData.banners = initStore.bannerState;
		this.viewData.menus = initStore.meunState;
	}

	getBgColorHandler(bg: string) {
		this.bgColor = bg;
	}
}

class CurrentViewModel {
	banners: Models.IBannerItem[] = [];
	menus: Models.IMenuItem[] = [];
}
</script>

<style lang="scss" scoped>
</style>
