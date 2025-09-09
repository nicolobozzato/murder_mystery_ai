import {
  AdminCasesApi,
  Configuration,
  type CreateCaseRequest,
} from "../../api/generated";
import { BaseRepositoryService } from "../services/base-repository-service";

export class CaseRepositoryService extends BaseRepositoryService {
  protected api: AdminCasesApi;

  constructor(baseUrl: string) {
    super(baseUrl);
    this.api = new AdminCasesApi(this.apiConfiguration);
  }

  public static get Instance(): CaseRepositoryService {
    if (!CaseRepositoryService.instance) {
      CaseRepositoryService.instance = new CaseRepositoryService(
        import.meta.env.VITE_BASEURL
      );
    }
    return CaseRepositoryService.instance as CaseRepositoryService;
  }

  public async getCaseById(id: string) {
    const response = await this.api.apiAdminCasesCaseIdGet(id);
    return response.data;
  }

  public async getAllCases() {
    const response = await this.api.apiAdminCasesGet();
    return response.data;
  }

  public async createCase(createCaseRequest?: CreateCaseRequest) {
    const response = await this.api.apiAdminCasesPost(createCaseRequest);
    return response.data;
  }
}
