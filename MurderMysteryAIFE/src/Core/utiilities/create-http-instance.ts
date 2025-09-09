import axios, { type AxiosInstance } from 'axios';
import qs from 'qs';

export function createHttpInstance(baseUrl: string): AxiosInstance {
  const axiosInstance = axios.create({
    baseURL: baseUrl,
    headers: {
      'Content-Type': 'application/json',
    },
    paramsSerializer: (params) => qs.stringify(params, { arrayFormat: 'repeat', encode: false }),
  });
  return axiosInstance;
}
