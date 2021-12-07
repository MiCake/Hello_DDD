import { IBannerItem, IMenuItem, ITabBarItem } from './types';

export const defaultTabBars: ITabBarItem[] = [{
    image: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/c4591c74c27a49bda021257d3c889225.png",
    activeImage: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/558feb98726495d17128d07694d7ff47.png",
    text: '首页',
    pathAlias: 'home',
    pagePath: "/pages/index/index"
},
{
    image: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/c4591c74c27a49bda021257d3c889225.png",
    activeImage: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/558feb98726495d17128d07694d7ff47.png",
    text: '排班列表',
    pathAlias: 'center',
    pagePath: "/pages/index/timetable"
},
{
    image: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/c4591c74c27a49bda021257d3c889225.png",
    activeImage: "https://shopro-1253949872.file.myqcloud.com/uploads/20200704/558feb98726495d17128d07694d7ff47.png",
    text: '我的',
    pathAlias: 'my',
    pagePath: "/pages/index/my"
}];

export const defaultMenus: IMenuItem[] = [{
    "name": "SPA",
    "image": "https://api.7wpp.com/uploads/20210419/dabd1cb2673324f19117701e0cf6af59.png",
    "path": "",
    "type": 1
},
{
    "image": "https://api.7wpp.com/uploads/20210419/b0e12f28e8b72730f6d77a4ffddeb2c6.png",
    "path": "",
    "name": "泰式按摩",
    "type": 1
},
{
    "image": "https://api.7wpp.com/uploads/20210419/e229004fb40f9ea6294fb8d009132a5d.png",
    "path": "",
    "name": "颈椎放松",
    "type": 1
},
{
    "image": "https://api.7wpp.com/uploads/20210419/b1cd29b741fccc921208ff660c9b009b.png",
    "path": "",
    "name": "刮痧拔罐",
    "type": 1
},
{
    "image": "https://api.7wpp.com/uploads/20210419/cb1ab669aa1783b9e10337652f8b4604.png",
    "path": "",
    "name": "随机一套",
    "type": 1
}];

export const defalutBanners: IBannerItem[] = [{
    image: 'https://up.enterdesk.com/edpic/c8/69/9e/c8699e76c46adf7ad6f45fa4371fdc65.jpg',
    title: '昨夜星辰昨夜风，画楼西畔桂堂东',
    bgcolor: '#76a1d8'
},
{
    image: 'https://up.enterdesk.com/edpic/70/1e/86/701e8620fc4953530b38b08a6990a153.jpg',
    title: '身无彩凤双飞翼，心有灵犀一点通',
    bgcolor: '#64b6ce'
},
{
    image: 'https://up.enterdesk.com/edpic/99/3a/5d/993a5d34fb7f7f63d8212dcd7c7d59e8.jpg',
    title: '谁念西风独自凉，萧萧黄叶闭疏窗，沉思往事立残阳',
    bgcolor: '#839ebc'
}];