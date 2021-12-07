<template>
	<view class="shade" v-show="showShade" @tap="hidePop">
		<view class="pop" :style="popStyle" :class="{'show':showPop}">
			<view class="pop-item">
				<slot></slot>
			</view>
		</view>
	</view>
</template>

<script lang="ts">
import isNil from 'lodash/isNil';
import { Vue, Component, Prop, Watch } from "vue-property-decorator";

@Component
export default class A extends Vue {
	@Prop() readonly pressEvent!: any;

	showShade: boolean = false;
	showPop: boolean = false;

	popStyle: any = {};
	winSize: any = {};

	getWindowSize() {
		uni.getSystemInfo({
			success: (res) => {
				this.winSize = {
					"witdh": res.windowWidth,
					"height": res.windowHeight
				};
			}
		});
	}

	@Watch('pressEvent')
	onLongPressWatcher(e: any) {
		if (isNil(e)) {
			return;
		}

		let [touches, style, index] = [e.touches[0], "", e.currentTarget.dataset.index];

		/* 因 非H5端不兼容 style 属性绑定 Object ，所以拼接字符 */
		if (touches.clientY > (this.winSize.height / 2)) {
			style = `bottom:${this.winSize.height - touches.clientY}px;`;
		} else {
			style = `top:${touches.clientY}px;`;
		}
		if (touches.clientX > (this.winSize.witdh / 2)) {
			style += `right:${this.winSize.witdh - touches.clientX}px`;
		} else {
			style += `left:${touches.clientX}px`;
		}

		this.popStyle = style;
		this.showShade = true;
		this.$nextTick(() => {
			setTimeout(() => {
				this.showPop = true;
			}, 10);
		});
	}

	hidePop() {
		this.showPop = false;
		setTimeout(() => {
			this.showShade = false;
		}, 250);
	}
}
</script>

<style lang="scss" scoped>
/* 遮罩 */
.shade {
	position: fixed;
	z-index: 100;
	top: 0;
	right: 0;
	bottom: 0;
	left: 0;
	-webkit-touch-callout: none;

	.pop {
		position: fixed;
		z-index: 101;
		width: 200upx;
		box-sizing: border-box;
		font-size: 28upx;
		text-align: left;
		color: #333;
		background-color: #fff;
		box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
		line-height: 80upx;
		transition: transform 0.15s ease-in-out 0s;
		user-select: none;
		-webkit-touch-callout: none;
		transform: scale(0, 0);

		&.show {
			transform: scale(1, 1);
		}

		& > .pop-item {
			padding: 0 20upx;
			overflow: hidden;
			text-overflow: ellipsis;
			white-space: nowrap;
			user-select: none;
			-webkit-touch-callout: none;
		}
	}
}
</style>