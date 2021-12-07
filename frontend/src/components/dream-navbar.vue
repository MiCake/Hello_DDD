<template>
	<view>
		<u-navbar :is-back="false" :title="title" :title-color="titleColor" :border-bottom="false" :background="{backgroundColor:bgColor}"></u-navbar>
	</view>
</template>

<script lang="ts">

import { Vue, Component, Prop } from "vue-property-decorator";

@Component
export default class A extends Vue {
	@Prop() readonly title!: string;
	@Prop({ default: 'white' }) readonly titleColor!: string;
	@Prop() readonly bgColor!: string;

	onLoad() {

	}
}

</script>

<style lang="scss">
</style>
