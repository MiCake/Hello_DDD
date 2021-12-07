
const ENV_BASE_URL = {
	development: 'http://localhost:5000', //开发环境
	production: 'http://localhost:5000', //生产环境
};
const ENV_API_URL = {
	development: `${ENV_BASE_URL.development}/api/v1`, //开发环境
	production: `${ENV_BASE_URL.production}/api/v1`, //生产环境
};

const env = (process.env.NODE_ENV as "development" | "production") || 'development';

export const BASE_URL = ENV_BASE_URL[env]; //后台根域名
export const API_URL = ENV_API_URL[env]; //后台接口域名
