import { isEmpty } from 'lodash';

// 调整图片大小
export function resizeImage(value: string, width?: number, height?: number) {
    if (isEmpty(value)) {
        return value;
    }

    const processSteps: string[] = [];

    if (width && height) {
        processSteps.push('m_fixed');
        processSteps.push(`w_${width}`);
        processSteps.push(`h_${height}`);
    } else if (width || height) {
        processSteps.push(width ? `w_${width}` : `h_${height}`);
    }

    if (processSteps.length > 0) {
        return `${value}?x-oss-process=image/resize,${processSteps.join(',')}`;
    }

    return value;
}