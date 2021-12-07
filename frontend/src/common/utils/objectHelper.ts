import isEmpty from 'lodash/isEmpty';

export class ObjectHelper {

    /**
     *
     * 确保将字符串转换为json，如果字符串不符合规则则返回为null
     * @static
     * @template T
     * @returns {(T | null)}
     * @memberof ObjectHelper
     */
    public static marksureJsonParse<T>(value: string): T | null {
        if (isEmpty(value)) {
            return null;
        }

        try {
            var parseObj = JSON.parse(value) as T;

            return parseObj;
        } catch {
            return null;
        }
    }
}