export interface ITabBarInfo {
    // 导航条颜色
    bgColor: string;

    items: ITabBarItem[];
}

export interface ITabBarItem {
    image?: string;
    activeImage?: string;
    color?: string;
    activeColor?: string;
    text: string;
    showCount?: boolean;
    count?: number;
    showDot?: boolean;
    pagePath: string;
    pathAlias?: string;
    midButton?: boolean;
    isCustom?: boolean;
}

export interface IMenuItem {
    image: string;
    path: string;
    name: string;
    type?: number;
}

export interface IBannerItem {
    image: string;
    title?: string;
    bgcolor?: string;
    isLink?: boolean;
    linkPath?: string;
    type?: number;
}