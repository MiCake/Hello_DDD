<template>
	<view class="home">
		<!-- 导航栏 -->
		<dream-lx-calendar :dot_lists="calenderDots" @change="calendarSelectHandler"></dream-lx-calendar>

		<view>
			<view class="cu-bar justify-start bg-white">
				<view class="action sub-title">
					<text class="text-xl text-bold text-green">当日排班</text>
					<text class="bg-green" style="width:2rem"></text>
					<!-- last-child选择器-->
				</view>
			</view>
			<view>
				<view class="padding">
					当前选择技师：
					<view class="cu-avatar md round margin-left" style="background-image:url(https://ossweb-img.qq.com/images/lol/web201310/skin/big99008.jpg);"></view>
					<text class="avatar-text margin-left">王小虎</text>
				</view>
				<view style="height:calc(100vh - 515upx)">
					<view class="cu-list bg-white">
						<u-empty style="height:calc(100vh - 515upx)" v-if="viewData.length === 0" text="暂无排班" mode="list"></u-empty>
						<view v-else class="cu-item flex padding-sm solid x-bc" v-for="(item,index) in viewData" :key="index" @tap="goDetail(item)">
							<view class="content_box margin-left-sm">
								<view class="text-black text-bold">{{item.startTime | dateformat('HH:MM')}} - {{item.endTime | dateformat('HH:MM')}}</view>
								<view class="padding-top-x text-gray text-xs">
									<view class="text-cut">当前状态：{{item.state === 0 ?'可预约':'不可预约'}}</view>
								</view>
							</view>
							<view class="cu-btn bg-green round sm" v-if="item.state===0" @tap="reserveHandler(item)">预约</view>
						</view>
					</view>
				</view>
			</view>
		</view>

		<dream-tabbar></dream-tabbar>
	</view>
</template>

<script lang="ts">
import { Component } from "vue-property-decorator";

import HasTabBarVuePage from '../base/hasTabBarVuePage';
import moment from "moment";
import { delay, isNil } from 'lodash';
import { MassageScheduleDto } from '@/models/apiModels';
import MassageScheduleServices from "@/serivces/reserver/massageSchedule";

@Component({
	components: {
	}
})
export default class A extends HasTabBarVuePage {
	services = new MassageScheduleServices();

	isNil = isNil;

	viewData: MassageScheduleDto[] = [];
	tabCurId: number = -1;

	currentDay: Date = moment().startOf('day').toDate();
	calenderDots: string[] = [this.$u.timeFormat(new Date().toString())];

	mounted() {
		this.loadData(this.currentDay);
	}

	public onLoad(): void {
	}

	protected async getDataFormService(data?: any): Promise<any> {
		var result = await this.services.getTodaySchedules(data) ?? [];

		this.viewData = result;
		this.tabCurId = -1;
	}

	goDetail(item: MassageScheduleDto) {
		if (isNil(item.id)) {
			this.showToast('数据错误');
			return;
		}
	}

	async reserveHandler(item: MassageScheduleDto) {
		var reserveResult = await this.doThing(async () => {
			var result = await this.services.reserveCurrentSchedule(item.id!, item.startTime!);
			return result;
		});

		if (reserveResult) {
			this.showToast('预约成功');
			delay(() => { this.loadData(this.currentDay); }, 1000);
		} else {
			this.showToast('预约失败');
		}
	}


	calendarSelectHandler(time: any) {
		this.loadData(moment(time.fulldate).toDate());
	}
}
</script>

<style lang="scss" scoped>
.VerticalNav.nav {
	width: 200upx;
	white-space: initial;
}

.VerticalNav.nav .cu-item {
	width: 100%;
	text-align: center;
	background-color: #fff;
	margin: 0;
	border: none;
	height: 50px;
	position: relative;
}

.VerticalNav.nav .cu-item.cur {
	background-color: #f1f1f1;
}

.VerticalNav.nav .cu-item.cur::after {
	content: "";
	width: 8upx;
	height: 30upx;
	border-radius: 10upx 0 0 10upx;
	position: absolute;
	background-color: currentColor;
	top: 0;
	right: 0upx;
	bottom: 0;
	margin: auto;
}

.VerticalBox {
	display: flex;
}

.VerticalMain {
	background-color: #f1f1f1;
	flex: 1;
	overflow: scroll;
}

.lesson-img {
	width: 182rpx;
}

.lesson-time {
	color: $primary-color;
}

.cu-tag.badge {
	top: 10rpx;
	right: 0;
}
</style>
