<script setup lang="ts">
import { onMounted, ref } from "vue";
import type { Case } from "@/api/generated";
import { CaseRepositoryService } from "@/Core/repositories/case-repository-service";

const cases = ref<Case[]>([]);

onMounted(async () => {
  const response = await CaseRepositoryService.Instance.getAllCases();
  cases.value = response;
});
</script>

<template>
  <index-loader></index-loader>
  <layout-header></layout-header>
  <mm-layout-sidebar></mm-layout-sidebar>

  <!-- Page Wrapper -->
  <div class="page-wrapper">
    <div class="content">
      <!-- Page Header -->
      <div
        class="d-md-flex d-block align-items-center justify-content-between mb-3"
      >
        <div class="my-auto mb-2">
          <h3 class="page-title mb-1">Case Dashboard</h3>
          <nav>
            <ol class="breadcrumb mb-0">
              <li class="breadcrumb-item">
                <router-link to="/dashboard/">Dashboard</router-link>
              </li>
              <li class="breadcrumb-item active" aria-current="page">
                Case Dashboard
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
                ><i class="ti ti-square-rounded-plus me-2"></i>Add Case</a
              >
            </div>
          </div>
        </div>
      </div>
    </div>
    <div>
      <div class="col-xl-4" v-for="item in cases" :key="item.id">
        <div class="card">
          <img src="@/assets/img/img-01.jpg" class="card-img-top" alt="..." />
          <div class="card-body">
            <h6 class="card-title fw-semibold">
              {{ item.title }}
            </h6>
            <p class="card-text mb-3 text-muted">
              {{ item.synopsis }}
            </p>
            <p class="card-text mb-0"><small>Last updated 3 mins ago</small></p>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- /Page Wrapper -->
</template>
