<template>
	<!-- 产品分类导航 -->
	<view class="menu-category-box mb10" v-if="carousel.length" :style="detail.length <= menu ? `height:200rpx` : `height:360rpx`">
		<swiper
			class="menu-swiper-box"
			:style="detail.length <= menu ? `height:160rpx` : `height:320rpx`"
			@change="onSwiper"
			circular
			:autoplay="false"
			:interval="3000"
			:duration="1000"
		>
			<swiper-item class="menu-swiper-item" v-for="(itemList, index) in carousel" :key="index" :style="detail.length <= menu ? `height:200rpx` : `height:340rpx`">
				<view class="menu-tab-box">
					<view class="tab-list y-f" :style="{ width: 690 / menu + 'rpx' }" v-for="(item,indext) in itemList.items" :key="indext" @tap="routerTo(item)">
						<image class="tab-img shopro-selector-circular" :style="{ width: imgW + 'rpx', height: imgW + 'rpx' }" :src="item.image" />
						<text class="shopro-selector-rect">{{ item.name }}</text>
					</view>
				</view>
			</swiper-item>
		</swiper>
		<view class="menu-category-dots" v-if="carousel.length > 1">
			<text :class="categoryCurrent === index ? 'category-dot-active' : 'category-dot'" v-for="(dot, index) in carousel.length" :key="index"></text>
		</view>
	</view>
</template>

<script lang="ts">
import { IMenuItem } from '@/store/init/types';
import isEmpty from 'lodash/isEmpty';
import { Vue, Component, Prop } from "vue-property-decorator";

@Component({
})
export default class A extends Vue {
	@Prop() readonly detail!: IMenuItem[];
	@Prop({ default: 5 }) readonly menu!: number;
	@Prop({ default: 88 }) readonly imgW!: number;

	categoryCurrent: number = 0;

	public get carousel(): CurrentViewModel[] {
		if (isEmpty(this.detail)) {
			return [];
		}

		let data = this.sortData(this.detail, this.menu * 2);
		return data;
	}

	private sortData(oArr: IMenuItem[], length: number) {
		let arr: CurrentViewModel[] = [];
		let minArr: IMenuItem[] = [];
		oArr.forEach(c => {
			if (minArr.length === length) {
				minArr = [];
			}
			if (minArr.length === 0) {
				arr.push({ items: minArr });
			}
			minArr.push(c);
		});

		return arr;
	}

	onSwiper(e: any) {
		this.categoryCurrent = e.detail.current;
	}

	routerTo(item: IMenuItem) {
		this.$Router.push(item.path);
	}
}

class CurrentViewModel {
	items: IMenuItem[] = [];
}
</script>

<style lang="scss">
// 产品分类
.menu-category-box {
	padding: 30rpx 30rpx 0 30rpx;
	background: #fff;
}
.menu-category-box,
.menu-swiper-box {
	position: relative;
	background: #fff;
	.menu-swiper-item {
		background: #fff;
		height: 100%;
		width: 100%;
	}
	.menu-tab-box {
		display: flex;
		flex-wrap: wrap;
		.tab-list {
			font-size: 22rpx;
			font-family: PingFang SC;
			font-weight: 500;
			color: rgba(51, 51, 51, 1);
			padding-bottom: 30rpx;

			.tab-img {
				border-radius: 25rpx;
				margin-bottom: 10rpx;
			}
		}
	}

	.menu-category-dots {
		display: flex;
		position: absolute;
		left: 50%;
		transform: translateX(-50%);
		bottom: 20rpx;

		.category-dot {
			width: 40rpx;
			height: 3rpx;
			background: #eeeeee;
			margin-right: 10rpx;
		}

		.category-dot-active {
			width: 40rpx;
			height: 3rpx;
			background: #a8700d;
			margin-right: 10rpx;
		}
	}
}
</style>
