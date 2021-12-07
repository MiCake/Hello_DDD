export class DelayHelper {
    /**
     *
     * 延迟异步执行ms毫秒
     * @static
     * @param {number} ms
     * @returns
     * @memberof CommonHelper
     */
    public static delay(ms: number) {
        return new Promise<boolean>(resolve => {
            setTimeout(() => {
                resolve(true);
            }, ms);
        });
    }
}