<script>
import Vue from 'vue'
export default {
	mpType: 'app',
	mounted: function () {
		// 隐藏默认导航栏
		uni.hideTabBar();
	},
	onLaunch: function () {
		console.log('App Launch');
		this.setCuCostom();
	},
	onLoad: function () {
		this.setCuCostom();
	},
	onShow: function () {
		console.log('App Show');
	},
	onHide: function () {
		console.log('App Hide');
	},
	methods: {
		setCuCostom: function () {
			uni.getSystemInfo({
				success: function (e) {
					// #ifndef H5
					// 获取手机系统版本
					const system = e.system.toLowerCase()
					const platform = e.platform.toLowerCase()
					// 判断是否为ios设备
					if (platform.indexOf('ios') != -1 && (system.indexOf('ios') != -1 || system.indexOf('macos') != -1)) {
						Vue.prototype.SystemPlatform = 'apple'
					} else if (platform.indexOf('android') != -1 && (system.indexOf('android') != -1)) {
						Vue.prototype.SystemPlatform = 'android'
					} else {
						Vue.prototype.SystemPlatform = 'devtools'
					}
					// #endif
					// #ifndef MP
					Vue.prototype.StatusBar = e.statusBarHeight;
					if (e.platform == 'android') {
						Vue.prototype.CustomBar = e.statusBarHeight + 50;
					} else {
						Vue.prototype.CustomBar = e.statusBarHeight + 45;
					};
					// #endif

					// #ifdef MP-WEIXIN
					Vue.prototype.StatusBar = e.statusBarHeight;
					let custom = wx.getMenuButtonBoundingClientRect();
					Vue.prototype.Custom = custom;
					Vue.prototype.CustomBar = custom.bottom + custom.top - e.statusBarHeight;
					// #endif		

					// #ifdef MP-ALIPAY
					Vue.prototype.StatusBar = e.statusBarHeight;
					Vue.prototype.CustomBar = e.statusBarHeight + e.titleBarHeight;
					// #endif
				}
			})
		}
	}
}
</script>

<style lang="scss">
/* 注意要写在第一行，同时给style标签加入lang="scss"属性 */
@import "uview-ui/index.scss";
@import "static/colorui/main.css";
@import "static/colorui/icon.css";
@import "static/style/_theme.scss";
@import url("static/css/nav.css");
@import url("static/css/dream.scss");
@import url("static/css/label.css");

// 其他scss集成在uni.scss,(变量,class,minix)

page {
	background-color: #ffffff;
}

.cu-bar {
	.text-color {
		// 默认字体颜色
		color: #aaaaaa;
	}

	.text-select-color {
		// 被选中时颜色
		color: #fbbd12;
	}

	.icon-bg {
		// icon的默认配色（不是图片icon）
		background-color: #fbbd12;
		color: #ffffff;
	}
}

::-webkit-scrollbar {
	width: 0;
	height: 0;
	color: transparent;
	display: none;
}

uni-page-body {
	background: none !important;
}

.page-container {
	background-color: #f1f1f1;
	min-height: 100vh;
	height: auto;
}

.full {
	height: 100vh;
	width: 100vw;
}

.link-top {
	width: 100%;
	height: 1px;
	border-top: solid #f0f0f0 1px;
}

.pop-menu-content {
	:active {
		background-color: #f3f3f3;
	}
}

.cu-list {
	.cu-item {
		&.active {
			&:active {
				background-color: #f3f3f3;
			}
		}
	}
}
</style>
