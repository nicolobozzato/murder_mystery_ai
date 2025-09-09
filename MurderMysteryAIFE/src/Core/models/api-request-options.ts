import type { AxiosHeaders, RawAxiosRequestHeaders, ResponseType } from "axios";
import type { AuthorizationMode } from "./authorization-mode";

//write a documentation comment here

/**
 * @param {string} params
 * @param {string} recaptchaToken
 * @param {ResponseType} responseType
 * @param {string} headers
 * @param {string} body
 */
export interface ApiRequestOptions {
  params?: any;
  body?: any;
  headers?: RawAxiosRequestHeaders | AxiosHeaders;
  /**
   * @type {AuthorizationMode[]}
   * @default ['jwt']
   * @description The authorization modes to use for the request
   */
  authorizationModes?: AuthorizationMode[];
  responseType?: ResponseType | undefined;
  /**
   * @description The recaptcha token to use for the request, it will be used if the authorizationModes includes 'recaptcha'
   */
  recaptchaToken?: string;
}
