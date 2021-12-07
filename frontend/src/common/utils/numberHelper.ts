export default class NumberHelper {
    // 获取指定范围的随机整数
    public static getRandomNumInt(min: number, max: number) {
        const Range = max - min;
        const Rand = Math.random(); // 获取[0-1）的随机数
        return (min + Math.round(Rand * Range)); // 放大取整
    }

    // 数字位数不够，进行前补零
    public static prefixZero(num: number, n: number) {
        return (Array(n).join('0') + num).slice(-n);
    }


    /**
     *
     * 获取数组的随机一项
     * @static
     * @template T
     * @param {Array<T>} items
     * @returns {T}
     * @memberof NumberHelper
     */
    public static getRandomArrayItem<T>(items: T[]): T {
        const index = NumberHelper.getRandomNumInt(0, items.length - 1);
        return items[index];
    }
}
