import type { RouteRecordRaw } from "vue-router";
import MmLayoutSidebar from "@/views/layouts/mm-layout-sidebar.vue";

export const coreRouter: RouteRecordRaw[] = [
  {
    name: "NotFound",
    path: "/:pathMatch(.*)*",
    component: () => import("@/views/pages/pages/error/404-error.vue"),
    meta: {
      layout: MmLayoutSidebar,
    },
  },
];
