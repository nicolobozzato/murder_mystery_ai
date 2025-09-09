<script setup lang="ts">
import { ref } from "vue";
import type { CreateCaseRequest } from "@/api/generated";
import { CaseRepositoryService } from "@/Core/repositories/case-repository-service";

const payload = ref<CreateCaseRequest>({} as CreateCaseRequest);

async function handleSubmit(e: Event) {
  e.preventDefault();
  const response = await CaseRepositoryService.Instance.createCase(
    payload.value
  );
  console.log(response);
}
</script>

<template>
  <!-- Add Guardian -->
  <div class="modal fade" id="add_case">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">Add Case</h4>
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
                    <p>Upload markdown files only</p>
                  </div>
                </div>
                <div class="mb-3">
                  <label class="form-label">Title</label>
                  <input
                    type="text"
                    class="form-control"
                    v-model="payload.title"
                  />
                </div>
                <div class="mb-3">
                  <label for="text-area" class="form-label">Synopsis</label>
                  <textarea
                    class="form-control"
                    id="text-area"
                    rows="4"
                    v-model="payload.synopsis"
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
              Add Case
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
  <!-- /Add Guardian -->
</template>
