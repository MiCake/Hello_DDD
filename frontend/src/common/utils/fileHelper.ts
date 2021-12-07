export class FileHelper {


    /**
     *
     * 转换base64为blob对象
     * @static
     * @param {string} b64Data
     * @param {string} [contentType='']
     * @param {number} [sliceSize=512]
     * @returns
     * @memberof FileHelper
     */
    public static b64toBlob(b64Data: string, contentType: string = '', sliceSize: number = 512) {
        contentType = contentType || '';
        sliceSize = sliceSize || 512;

        const byteCharacters = atob(b64Data.replace(/^data:image\/(png|jpeg|jpg);base64,/, ''));
        const byteArrays = [];

        for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            const slice = byteCharacters.slice(offset, offset + sliceSize);

            const byteNumbers = new Array(slice.length);
            for (let i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            const byteArray = new Uint8Array(byteNumbers);

            byteArrays.push(byteArray);
        }

        const blob = new Blob(byteArrays, { type: contentType });
        return blob;
    };


    /**
     *
     * 获取文件后缀名
     * @static
     * @param {*} filename
     * @returns
     * @memberof FileHelper
     */
    public static get_suffix(filename: string) {
        const pos = filename.lastIndexOf('.');
        let suffix = '';
        if (pos !== -1) {
            suffix = filename.substring(pos);
        }
        return suffix;
    }
}