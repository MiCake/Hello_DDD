import { isEmpty } from 'lodash';

// 根据传入值将日期进行格式化
export function dateformat(value: any, formatStr: string = 'yyyy/MM/dd HH:mm:ss') {
    if (isEmpty(value)) {
        return '';
    }
    return dateFormat(formatStr, new Date(value));
}
const dateFormat = (fmt: any, date: Date) => {
    let ret;
    const opt: any = {
        "Y+": date.getFullYear().toString(), // 年
        "m+": (date.getMonth() + 1).toString(), // 月
        "d+": date.getDate().toString(), // 日
        "H+": date.getHours().toString(), // 时
        "M+": date.getMinutes().toString(), // 分
        "S+": date.getSeconds().toString() // 秒
        // 有其他格式化字符需求可以继续添加，必须转化成字符串
    };
    for (let k in opt) {
        ret = new RegExp("(" + k + ")").exec(fmt);
        if (ret) {
            fmt = fmt.replace(ret[1], (ret[1].length == 1) ? (opt[k]) : (opt[k].padStart(ret[1].length, "0")));
        };
    };
    return fmt;
};
