<script setup lang="ts">
import { ref, watch } from "vue";
import type {
  AddNpcRequest,
  CreateCaseRequest,
  NpcAdminDto,
} from "@/api/generated";
import { CaseRepositoryService } from "@/Core/repositories/case-repository-service";
import { useRoute } from "vue-router";
import { NpcRepositoryService } from "@/Core/repositories/npc-repository-service";

const route = useRoute();

const props = defineProps<{
  npc: NpcAdminDto | null;
}>();

const emits = defineEmits<{
  (e: "submitted", payload: NpcAdminDto): void;
}>();

const npcRequest = ref<AddNpcRequest>({} as AddNpcRequest);
const caseId = route.params.id as string;

watch(
  () => props.npc,
  (newVal) => {
    npcRequest.value.name = newVal?.name ?? "";
    npcRequest.value.persona = newVal?.persona ?? "";
    npcRequest.value.memoryJson = newVal?.traitsJson ?? "";
  },
  { immediate: true }
);

async function handleSubmit(e: Event) {
  e.preventDefault();
  const response = await NpcRepositoryService.Instance.addNpc(
    caseId,
    npcRequest.value
  );
  emits("submitted", response);
}
</script>

<template>
  <!-- Add Guardian -->
  <div class="modal fade" id="add_npc">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">Add Npc</h4>
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
                    v-model="npcRequest.name"
                  />
                </div>
                <div class="mb-3">
                  <label for="text-area" class="form-label">Description</label>
                  <textarea
                    class="form-control"
                    id="text-area"
                    rows="4"
                    v-model="npcRequest.persona"
                  ></textarea>
                </div>
                <div class="mb-3">
                  <label for="text-area" class="form-label"
                    >Where he was during the crime</label
                  >
                  <textarea
                    class="form-control"
                    id="text-area"
                    rows="4"
                    v-model="npcRequest.memoryJson"
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
              {{ npc ? "Edit NPC" : "Add NPC" }}
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
  <!-- /Add Guardian -->
</template>
