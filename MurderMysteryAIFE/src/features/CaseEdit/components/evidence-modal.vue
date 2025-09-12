<script setup lang="ts">
import { ref, watch } from "vue";
import type { AddEvidenceRequest, EvidenceAdminDto } from "@/api/generated";
import { useRoute } from "vue-router";
import { EvidenceRepositoryService } from "@/Core/repositories/evidence-repository-service copy";
const route = useRoute();

const props = defineProps<{
  evidence: EvidenceAdminDto | null;
}>();

const emits = defineEmits<{
  (e: "submitted", payload: EvidenceAdminDto): void;
}>();

const evidenceRequest = ref<AddEvidenceRequest>({} as AddEvidenceRequest);
const caseId = route.params.id as string;

watch(
  () => props.evidence,
  (newVal) => {
    if (newVal) {
      evidenceRequest.value.title = newVal!.title ?? "";
      evidenceRequest.value.text = newVal!.text ?? "";
    } else {
      evidenceRequest.value.title = "";
      evidenceRequest.value.text = "";
    }
  },
  { immediate: true }
);

async function handleSubmit(e: Event) {
  e.preventDefault();
  const response = await EvidenceRepositoryService.Instance.addEvidence(
    caseId,
    evidenceRequest.value
  );
  emits("submitted", response);
}
</script>

<template>
  <!-- Add Guardian -->
  <div class="modal fade" id="add_evidence">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title" v-if="evidence">Edit Evidence</h4>
          <h4 class="modal-title" v-else>Add Evidence</h4>
          <button
            type="button"
            class="btn-close custom-btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          >
            <i class="ti ti-x"></i>
          </button>
        </div>
        <form>
          <div class="modal-body">
            <div class="row">
              <div class="col-md-12">
                <div
                  class="d-flex align-items-center upload-pic flex-wrap row-gap-3 mb-3"
                >
                  <div
                    class="d-flex align-items-center justify-content-center avatar avatar-xxl border border-dashed me-2 flex-shrink-0 text-dark frames"
                  >
                    <i class="ti ti-photo-plus fs-16"></i>
                  </div>
                  <div class="profile-upload">
                    <div class="profile-uploader d-flex align-items-center">
                      <div class="drag-upload-btn mb-3">
                        Upload
                        <input
                          type="file"
                          class="form-control image-sign"
                          multiple
                        />
                      </div>
                      <a href="javascript:void(0);" class="btn btn-primary mb-3"
                        >Remove</a
                      >
                    </div>
                    <p>Upload image size 4MB, Format JPG, PNG, SVG</p>
                  </div>
                </div>
                <div class="mb-3">
                  <label class="form-label">Name</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="evidenceRequest.title"
                  />
                </div>
                <div class="mb-3">
                  <label for="text-area" class="form-label">Description</label>
                  <textarea
                    class="form-control"
                    id="text-area"
                    rows="4"
                    v-model="evidenceRequest.text"
                  ></textarea>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <a href="#" class="btn btn-light me-2" data-bs-dismiss="modal"
              >Cancel</a
            >
            <button @click="handleSubmit" class="btn btn-primary">
              {{ evidence ? "Edit Evidence" : "Add Evidence" }}
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
  <!-- /Add Guardian -->
</template>
