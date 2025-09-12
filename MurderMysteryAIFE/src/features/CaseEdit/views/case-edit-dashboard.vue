<script setup lang="ts">
import { onMounted, ref } from "vue";
import { CaseRepositoryService } from "@/Core/repositories/case-repository-service";
import { useRoute } from "vue-router";
import EvidenceModal from "../components/evidence-modal.vue";
import NpcModal from "../components/npc-modal.vue";
import { useCaseEditStore } from "../case-edit-store";
import type { CaseAdminDTO } from "@/api/generated";
const route = useRoute();

const caseToEdit = ref<CaseAdminDTO | undefined>();

onMounted(async () => {
  caseToEdit.value = await CaseRepositoryService.Instance.getCaseById(
    route.params.id as string
  );
});

const store = useCaseEditStore();
</script>

<template>
  <index-loader></index-loader>
  <layout-header></layout-header>
  <layout-sidebar></layout-sidebar>

  <!-- Page Wrapper -->
  <div class="page-wrapper" v-if="caseToEdit">
    <div class="content">
      <!-- Page Header -->
      <div
        class="d-md-flex d-block align-items-center justify-content-between mb-3"
      >
        <div class="my-auto mb-2">
          <h3 class="page-title mb-1">{{ caseToEdit.title }}</h3>
          <nav>
            <ol class="breadcrumb mb-0">
              <li class="breadcrumb-item">
                <router-link to="/dashboard/">Cases</router-link>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                {{ caseToEdit.title }}
              </li>
            </ol>
          </nav>
        </div>
        <div
          class="d-flex my-xl-auto right-content align-items-center flex-wrap"
        >
          <div class="mb-2">
            <div class="mb-2">
              <a
                href="javascript:void(0);"
                data-bs-toggle="modal"
                data-bs-target="#add_case"
                class="btn btn-primary"
                >Save</a
              >
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container m-2">
      <div class="row">
        <div class="col-xl-4">
          <h2 class="mb-2">Case Image</h2>
          <img src="@/assets/img/img-01.jpg" class="card-img-top" alt="..." />
        </div>
        <div class="col-xl-8">
          <h2 class="mb-2">NPC</h2>
          <span
            v-for="npc in caseToEdit.npcs"
            :key="npc.id"
            class="avatar avatar-xxl me-2 avatar-rounded ms-1"
            data-bs-toggle="modal"
            data-bs-target="#add_npc"
            @click="() => (store.npcToEdit = npc)"
          >
            <img
              src="@/assets/img/profiles/avatar-03.jpg"
              alt="img"
              data-bs-toggle="tooltip"
              data-bs-placement="top"
              title="NPC avatar"
            />
          </span>
          <span
            class="avatar avatar-xxl me-2 avatar-rounded ms-1 border border-blue-2 d-flex align-items-center justify-content-center"
            style="background-color: #f0f4ff"
            href="javascript:void(0);"
            data-bs-toggle="modal"
            data-bs-target="#add_npc"
            title="Add NPC"
            @click="() => (store.npcToEdit = undefined)"
          >
            <i class="fas fa-plus fs-24 text-blue"></i>
          </span>
        </div>
      </div>
      <div class="row mt-1">
        <div class="col-xl-4">
          <h2 class="mb-2">Case Synopsis</h2>
          <div class="card-body p-2">
            <p class="card-text mb-3 text-muted">
              {{ caseToEdit.synopsis }}
            </p>
          </div>
        </div>
        <div class="col-xl-8">
          <h2 class="mb-2">Evidence</h2>
          <span
            v-for="evidence in caseToEdit.evidences"
            :key="evidence.id"
            class="avatar avatar-xxxl ms-1 me-2"
            href="javascript:void(0);"
            data-bs-toggle="modal"
            data-bs-target="#add_evidence"
            @click="() => (store.evidenceToEdit = evidence)"
          >
            <img src="@/assets/img/profiles/avatar-02.jpg" alt="img" />
          </span>
          <span
            class="avatar avatar-xxxl ms-1 me-2 border border-blue-2 d-flex align-items-center justify-content-center"
            style="background-color: #f0f4ff"
            href="javascript:void(0);"
            data-bs-toggle="modal"
            data-bs-target="#add_evidence"
            @click="() => (store.evidenceToEdit = undefined)"
          >
            <i class="fas fa-plus fs-32 text-blue"></i>
          </span>
        </div>
      </div>
    </div>
  </div>
  <!-- /Page Wrapper -->
  <EvidenceModal :evidence="store.evidenceToEdit"></EvidenceModal>
  <NpcModal :npc="store.npcToEdit"></NpcModal>
</template>
