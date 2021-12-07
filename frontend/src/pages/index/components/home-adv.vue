<template>
	<view class="margin-lr-xs adv-box">
		<!-- 模板1-->
		<view class="x-f type0" v-if="advs.length === 1">
			<view class="type0-img x-ac" v-for="(item,index) in advs" :key="index" @tap="goPathHandler(item)">
				<view class="padding-sm more-t">
					<view class="text-black text-lg">
						<text>{{item.title}}</text>
					</view>
					<view class="text-gray text-xs margin-top-xs">
						<text>{{item.subtitle}}</text>
					</view>
				</view>
				<image class="padding-sm" @tap="goPathHandler(item)" :src="item.image" mode="aspectFill" />
			</view>
		</view>
		<!-- 模板2-->
		<view class="type1 x-f" v-else-if="advs.length === 2">
			<view v-for="(item,index) in advs" :key="index" @tap="goPathHandler(item)" class="type1-img">
				<view class="padding-sm more-t">
					<view class="text-black text-bold text-md">
						<text>{{item.title}}</text>
					</view>
					<view class="text-gray text-xs margin-top-xs">
						<text>{{item.subtitle}}</text>
					</view>
				</view>
				<image class="padding-lr-sm" :src="item.image" mode="aspectFill" />
			</view>
		</view>
		<!-- 模板3-->
		<view class="type2 x-bc" v-else-if="advs.length === 3">
			<view class="type2-img1" @tap="goPathHandler(advs[0])">
				<view class="padding-sm">
					<view class="text-black text-bold text-md">
						<text>{{advs[0].title}}</text>
					</view>
					<view class="text-gray text-xs margin-top-xs">
						<text>{{advs[0].subtitle}}</text>
					</view>
				</view>
				<image class="padding-sm" :src="advs[0].image" mode="aspectFill" />
			</view>

			<view class="y-f type2-box">
				<view class="type2-img2 x-bc padding-sm" @tap="goPathHandler(advs[1])" style="border-bottom:1rpx solid #f6f6f6">
					<view class="more-t">
						<view class="text-black text-bold text-md">
							<text>{{advs[1].title}}</text>
						</view>
						<view class="text-gray text-xs margin-top-xs">
							<text>{{advs[1].subtitle}}</text>
						</view>
					</view>
					<image class="padding-sm" :src="advs[1].image" mode="aspectFill" />
				</view>
				<view class="type2-img2 x-bc padding-sm" @tap="goPathHandler(advs[2])">
					<view class="more-t">
						<view class="text-black text-bold text-md">
							<text>{{advs[2].title}}</text>
						</view>
						<view class="text-gray text-xs margin-top-xs">
							<text>{{advs[2].subtitle}}</text>
						</view>
					</view>
					<image class="padding-sm" :src="advs[2].image" mode="aspectFill" />
				</view>
			</view>
		</view>
	</view>
</template>

<script lang="ts">
import isEmpty from 'lodash/isEmpty';
import { Vue, Component, Prop } from "vue-property-decorator";

@Component
export default class A extends Vue {
	@Prop() readonly advs!: IHomeAdvModel[];

	goPathHandler(item: IHomeAdvModel) {
		if (isEmpty(item.path)) {
			return;
		}

		this.$Router.push(item.path);
	}
}

export interface IHomeAdvModel {
	title?: string;
	subtitle?: string;
	image?: string;
	path: string;
}

</script>

<style lang="scss">
.adv-box {
	background-color: #fff;
	border-radius: 20rpx;
	overflow: hidden;
	.type0 {
		.type0-img {
			flex: 1;
			height: 220rpx;

			image {
				width: 400rpx;
				height: 200rpx;
				flex-shrink: 0;
			}
		}
	}

	.type1 {
		.type1-img {
			flex: 1;
			height: 220rpx;
			width: 50%;

			image {
				width: (710rpx/2);
				height: 120rpx;
				flex-shrink: 0;
			}

			&:first-child {
				border-right: 1rpx solid #f6f6f6;
			}
		}
	}

	.type2 {
		.type2-img1 {
			border-right: 1rpx solid #f6f6f6;

			image {
				width: 400rpx;
				height: 200rpx;
				flex-shrink: 0;
			}
		}

		.type2-box {
			flex: 1;
			height: 340rpx;
			width: 50%;

			.type2-img2 {
				flex-direction: row;
				height: (340rpx/2);

				image {
					width: 120rpx;
					height: 120rpx;
					flex-shrink: 0;
				}
			}
		}
	}
}
</style>
