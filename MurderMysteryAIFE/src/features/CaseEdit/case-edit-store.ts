import type { Evidence } from "@/api/generated";
import { defineStore } from "pinia";
import { ref } from "vue";

export const useCaseEditStore = defineStore("caseEdit", () => {
  const npcToEdit = ref<any | null>(null);
  const evidenceToEdit = ref<Evidence | null>(null);

  return {
    npcToEdit,
    evidenceToEdit,
  };
});
