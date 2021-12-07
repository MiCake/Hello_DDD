<template>
	<view class="bg-white margin-xs radius-md">
		<view class="cu-bar justify-start">
			<view class="action sub-title">
				<text class="text-xl text-bold text-green">今日上班技师</text>
				<text class="bg-green" style="width:2rem"></text>
				<!-- last-child选择器-->
			</view>
		</view>

		<view class="cu-list menu-avatar" v-if="listData.length > 0">
			<view class="cu-item flex padding-sm solid x-bc" v-for="(item,index) in listData" :key="index">
				<view class="cu-avatar lg round" :style="{'background-image':`url(${defaultAvatar})`}"></view>
				<view class="content">
					<view class="text-grey">{{getDisplayName(index)}}</view>
				</view>
				<view class="action">
					<view class="cu-tag radius bg-pink">专业</view>
				</view>
			</view>
		</view>
		<view v-else class="margin-top-lg">
			<u-empty text="暂无参课信息" mode="list"></u-empty>
		</view>
	</view>
</template>

<script lang="ts">
import BaseListVuePage from '@/pages/base/baseListVuePage';
import { DefaultAvatar } from '@/pages/common/constants';
import { Component } from "vue-property-decorator";

@Component
export default class A extends BaseListVuePage<CurrentViewModel> {
	defaultAvatar = DefaultAvatar;

	mounted() {
		this.listData = ['', '', '', '', '', ''];
	}

	protected goDetail(data: CurrentViewModel): void {
		throw new Error('Method not implemented.');
	}
	protected getDataFormService(data?: any): Promise<any> {
		throw new Error('Method not implemented.');
	}

	getDisplayName(index: number) {
		const candidateNames = ['王小虎', '王大虎', '石小虎', '石大虎'];

		return candidateNames[index % 4];
	}
}

class CurrentViewModel {

}
</script>

<style lang="scss" scoped>
.lesson-img {
	width: 182rpx;
}

.cu-tag.badge {
	top: 10rpx;
	right: 10rpx;
}
</style>