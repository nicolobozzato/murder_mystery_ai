import { createRouter, createWebHistory } from "vue-router";

const routes = [
  {
    path: "/",
    name: "dashboard",
    component: () =>
      import("@/features/CasesDashboard/views/cases-dashboard.vue"),
  },
];
export const router = createRouter({
  history: createWebHistory("/"),
  linkActiveClass: "active",
  routes,
});

router.afterEach((to) => {});

router.beforeEach((to, from, next) => {
  // Scroll to the top of the page
  window.scrollTo({ top: 0, behavior: "smooth" });

  // Continue with the navigation
  next();
});

export default router;
