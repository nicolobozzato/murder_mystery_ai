import {
  AdminCasesApi,
  AdminEvidencesApi,
  AdminNpcsApi,
  Configuration,
  type AddEvidenceRequest,
  type AddNpcRequest,
  type CreateCaseRequest,
} from "../../api/generated";
import { BaseRepositoryService } from "../services/base-repository-service";

export class NpcRepositoryService extends BaseRepositoryService {
  protected api: AdminNpcsApi;

  constructor(baseUrl: string) {
    super(baseUrl);
    this.api = new AdminNpcsApi(this.apiConfiguration);
  }

  public static get Instance(): NpcRepositoryService {
    if (!NpcRepositoryService.instance) {
      NpcRepositoryService.instance = new NpcRepositoryService(
        import.meta.env.VITE_BASEURL
      );
    }
    return NpcRepositoryService.instance as NpcRepositoryService;
  }

  public async addNpc(caseId: string, npc?: AddNpcRequest) {
    const response = await this.api.apiAdminCasesCaseIdNpcsPost(caseId, npc);
    return response.data;
  }
}
