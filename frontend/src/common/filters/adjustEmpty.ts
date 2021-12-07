import isEmpty from 'lodash/isEmpty';

// 内容为空的时候，需要显示某些信息的过滤器
export function adjustEmpty(value: any, showContent: any) {
    if (isEmpty(value)) {
        return isEmpty(showContent) ? '暂无数据' : showContent;
    }
    return value;
}
