<!-- 登录 -->
<template>
	<view class="padding">
		<view class="title">Access Token</view>
		<view class="cu-form-group margin-top">
			<textarea maxlength="-1" placeholder="请输入Access Token" @input="textareaInput">{{accessToken}}</textarea>
		</view>
		<view class="title">UserId</view>
		<view class="cu-form-group margin-top">
			<input placeholder="请输入UserId" v-model="userId" />
		</view>
		<view class="padding flex flex-direction">
			<button class="cu-btn bg-red margin-tb-sm lg" @click="setTokenHandler">提交</button>
		</view>
	</view>
</template>

<script lang="ts">
import { delay, isEmpty, isNil } from 'lodash';
import { Component } from "vue-property-decorator";
import BaseVuePage from '../base/baseVuePage';
import accountStore from '@/store/account';
import { PageHelper } from '../utils/PageHelper';

@Component
export default class A extends BaseVuePage {

	accessToken: string = '';
	userId: number = 1;

	protected getDataFormService(data?: any): Promise<any> {
		throw new Error('Method not implemented.');
	}

	textareaInput(e: any) {
		this.accessToken = e.detail.value;
	}

	setTokenHandler() {
		if (isEmpty(this.accessToken) || isNil(this.userId)) {
			this.$u.toast('Token 不能为空');
			return;
		}

		accountStore.setLoginInfo({
			accessToken: this.accessToken,
			refreshToken: '',
			userInfo: { id: this.userId, avatar: null, nickName: '测试用户', gender: 1 }
		});
		this.$u.toast('设置成功');

		delay(() => {
			PageHelper.naviToBeforeLoginPath(this.$Router);
		}, 1000);
	}
}
</script>

<style lang="scss">
</style>
