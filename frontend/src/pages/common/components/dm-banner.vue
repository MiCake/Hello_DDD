<template>
	<!-- 轮播 -->
	<view class="banner-swiper-box mb10" v-if="detail && detail.length > 0">
		<swiper class="banner-carousel shopro-selector-rect" circular @change="swiperChange" :autoplay="true">
			<swiper-item v-for="(item, index) in detail" :key="index" class="carousel-item" @tap="goDetail(item)">
				<image class="swiper-image" :src="item.image" mode="widthFix" lazy-load />
			</swiper-item>
		</swiper>
		<view class="banner-swiper-dots">
			<text :class="swiperCurrent === index ? 'banner-dot-active' : 'banner-dot'" v-for="(dot, index) in detail.length" :key="index"></text>
		</view>
	</view>
</template>

<script lang="ts">
import { Vue, Component, Prop } from "vue-property-decorator";

@Component({})
export default class A extends Vue {
	@Prop() readonly detail!: any[];

	swiperCurrent: number = 0; //轮播下标

	goDetail(e: any) {
		var currentItem = e;
		if (!currentItem.isLink) {
			return;
		}

		this.$Router.push(currentItem.linkPath);
	}

	mounted() {
		this.initBgColor();
	}

	initBgColor() {
		this.$nextTick(() => {
			let bgcolor = this.detail[this.swiperCurrent]?.bgcolor ?? '';
			this.$emit('getbgcolor', bgcolor);
		});
	}

	swiperChange(e: any) {
		this.swiperCurrent = e.detail.current;
		this.initBgColor();
	}
}
</script>

<style lang="scss">
// 轮播
.banner-swiper-box {
	background: #fff;
}

.banner-swiper-box,
.banner-carousel {
	width: 750rpx;
	height: 350rpx;
	position: relative;

	.carousel-item {
		width: 100%;
		height: 100%;
		// padding: 0 28upx;
		overflow: hidden;
	}

	.swiper-image {
		width: 100%;
		height: 100%;
		// border-radius: 10upx;
		// background: #ccc;
	}
}

.banner-swiper-dots {
	display: flex;
	position: absolute;
	left: 50%;
	transform: translateX(-50%);
	bottom: 20rpx;
	z-index: 66;

	.banner-dot {
		width: 14rpx;
		height: 14rpx;
		background: rgba(255, 255, 255, 1);
		border-radius: 50%;
		margin-right: 10rpx;
	}

	.banner-dot-active {
		width: 14rpx;
		height: 14rpx;
		background: #a8700d;
		border-radius: 50%;
		margin-right: 10rpx;
	}
}
</style>
