import {
  AdminCasesApi,
  AdminEvidencesApi,
  Configuration,
  type AddEvidenceRequest,
  type CreateCaseRequest,
} from "../../api/generated";
import { BaseRepositoryService } from "../services/base-repository-service";

export class EvidenceRepositoryService extends BaseRepositoryService {
  protected api: AdminEvidencesApi;

  constructor(baseUrl: string) {
    super(baseUrl);
    this.api = new AdminEvidencesApi(this.apiConfiguration);
  }

  public static get Instance(): EvidenceRepositoryService {
    if (!EvidenceRepositoryService.instance) {
      EvidenceRepositoryService.instance = new EvidenceRepositoryService(
        import.meta.env.VITE_BASEURL
      );
    }
    return EvidenceRepositoryService.instance as EvidenceRepositoryService;
  }

  public async addEvidence(caseId: string, evidence?: AddEvidenceRequest) {
    const response = await this.api.apiAdminCasesCaseIdEvidencesPost(
      caseId,
      evidence
    );
    return response.data;
  }
}
