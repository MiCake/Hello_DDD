<template>
	<view class="my">
		<image :src="bgImage" mode="widthFix" class="tn-bg" />

		<navigator hover-class="none" @click="hideAnimalHanlder" v-if="showAnimal">
			<view class="dong">
				<view class="monster">
					<view class="monster__face">
						<view class="monster__eye avatar-eye avatar-eye--green eye--left">
							<view class="avatar-eye-pupil pupil--green">
								<span class="avatar-eye-pupil-blackThing">
									<span class="avatar-eye-pupil-lightReflection"></span>
								</span>
							</view>
						</view>
						<view class="monster__eye avatar-eye avatar-eye--violet eye--right">
							<view class="avatar-eye-pupil pupil--pink">
								<span class="avatar-eye-pupil-blackThing">
									<span class="avatar-eye-pupil-lightReflection"></span>
								</span>
							</view>
						</view>
						<view class="monster__noses">
							<view class="monster__nose"></view>
							<view class="monster__nose"></view>
						</view>
						<view class="monster__mouth">
							<view class="monster__top"></view>
							<view class="monster__bottom"></view>
						</view>
					</view>
				</view>
			</view>
		</navigator>

		<view :style="'padding-top:' + customBar + 'px;'">
			<view class="cu-list menu my_logo">
				<view class="cu-item" @click="goLoginOrDetailHandler">
					<view class="cu-avatar round xl margin-right-sm shadow-blur-lg bg-img open-data">
						<img :src="userAvatar" mode="widthFix" />
					</view>
					<view class="content flex-sub">
						<view class="padding-left-sm text-white text-xxl text-shadow-a padding-top-sm">{{isLogin ? userInfo.nickName:'请登录' }}</view>
						<view class="text-lg flex justify-between padding-left-sm padding-top-sm text-white text-shadow-a">欢迎访问</view>
					</view>
				</view>
			</view>
		</view>

		<view class="cu-list menu card-menu margin-top-xl shadow-shop text-black my-radius sm-border margin-bottom">
			<view class="cu-item">
				<button class="content cu-btn" @click="navTokenTest">
					<image src="/static/images/faxian.png" class="png" mode="aspectFit" />
					<text class="text-lg margin-sm">测试Token</text>
				</button>
			</view>
			<view class="cu-item">
				<button class="content cu-btn" open-type="contact">
					<image src="/static/images/fenxiang.png" class="png" mode="aspectFit" />
					<text class="text-lg margin-sm">合作勾搭</text>
				</button>
			</view>
		</view>

		<dream-tabbar></dream-tabbar>
	</view>
</template>

<script lang="ts">
import { Component } from "vue-property-decorator";
import accountStore from "@/store/account";
import { DefaultAvatar } from '../common/constants';
import HasTabBarVuePage from '../base/hasTabBarVuePage';

@Component({
	components: {
	}
})
export default class A extends HasTabBarVuePage {

	bgImage: string = 'https://oss.tnkjapp.com/website/atlas_images/20210701/65cb49497cc16e193792cd3e7151f5.png';
	customBar: string = this.CustomBar;
	showAnimal: boolean = true;

	public get isLogin(): boolean {
		return accountStore.loginState?.isLogin ?? false;
	}

	public get userInfo() {
		return accountStore.userState;
	}

	public get userAvatar(): string {
		return this.isLogin ? (this.userInfo?.avatar ?? DefaultAvatar) : DefaultAvatar;
	}

	public onLoad(): void {

	}

	protected getDataFormService(data?: any): Promise<any> {
		throw new Error('Method not implemented.');
	}

	goLoginOrDetailHandler() {
		if (this.isLogin) {
			this.$Router.push('/pages/user/info');
		} else {
			this.$Router.push('/pages/public/login');
		}
	}

	navTokenTest() {
		this.$Router.push('/pages/testpages/testlogin');
	}

	hideAnimalHanlder() {
		this.showAnimal = false;
	}
}
</script>

<style lang="scss" scoped>
@import url("@/static/animals/cat.css");
@import url("@/static/animals/bird.css");

uni-page-body {
	background: none !important;
}

.cu-list.menu > .cu-item {
	background-color: rgba(0, 0, 0, 0);
}

.cu-modal .cu-dialog > .cu-bar:first-child .action {
	margin-right: 30rpx;
}

.bg-green {
	background-color: #7fd02b;
}

.my_logo {
	background: none;
	padding: 50rpx 0 30rpx 0;
}

.open-data {
	overflow: hidden;
	display: block;
	box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
}

.my-radius {
	border-radius: 12rpx;
	overflow: hidden;
}

.my-icon image {
	width: 100rpx;
	height: 100rpx;
	display: inline-block;
	margin: 0 auto;
}

.my-iconcolor {
	background: rgba(255, 255, 255, 0.96);
}

.shadow-shop {
	box-shadow: 0rpx 0rpx 90rpx 0rpx rgba(0, 0, 0, 0.1);
}

.qrcode-img {
	position: fixed;
	width: 80rpx;
	height: 80rpx;
	bottom: 350rpx;
	right: 30rpx;
	z-index: 1024;
	opacity: 0.8;
	box-shadow: 0rpx 8rpx 30rpx 0rpx rgba(0, 0, 0, 0.3);
	border: none;
}

.text-my {
	color: #aaa !important;
}

uni-image > img {
	-webkit-touch-callout: none;
	-webkit-user-select: none;
	-moz-user-select: none;
	display: block;
	position: absolute;
	top: 0;
	left: 0;
	opacity: 0;
}
</style>
