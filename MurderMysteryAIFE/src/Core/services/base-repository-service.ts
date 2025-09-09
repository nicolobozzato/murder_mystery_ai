import type {
  AxiosHeaders,
  AxiosInstance,
  AxiosResponse,
  Method,
  RawAxiosRequestHeaders,
} from "axios";
import { Configuration } from "../../api/generated";

export abstract class BaseRepositoryService {
  protected static instance: BaseRepositoryService;
  protected apiConfiguration: Configuration;

  constructor(private baseUrl: string) {
    this.apiConfiguration = new Configuration({ basePath: this.baseUrl });
  }

  static get Instance(): BaseRepositoryService {
    return this.instance;
  }
}
