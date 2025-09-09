import type { Router } from 'vue-router';
import { Permission } from '@CoreUser/models/permission';
import { userHasPermission } from '@CoreUser/utilities/user-has-permission';
import { Roles } from '@CoreUser/models/roles';

interface RouteHistoryEntry {
  fullPath: string;
  query: any;
}

const routeHistory: RouteHistoryEntry[] = [];

export const useBeforeEachGuard = (router: Router) => {
  router.beforeEach((to, from, next) => {
    const token = localStorage.getItem('token');
    const user = JSON.parse(localStorage.getItem('user') ?? 'null');

    const isBreadcrumbNavigation = to.query.breadcrumb === 'true';

    if (isBreadcrumbNavigation) {
      delete to.query.breadcrumb;
      const savedRoute = routeHistory.find(
        (entry) => entry.fullPath.split('?')[0] === to.fullPath.split('?')[0],
      );
      if (savedRoute) {
        const mergedQuery = { ...to.query, ...savedRoute.query };

        if (JSON.stringify(to.query) !== JSON.stringify(mergedQuery)) {
          next({ path: to.path, query: mergedQuery, replace: true });
          return;
        }
      }
    }

    if (!token && to.name !== 'login') {
      localStorage.setItem('postLoginRedirectUrl', to.fullPath);
      next({ name: 'login' });
    } else if (to.name === 'login' && token) {
      next({ path: '/' });
    } else if (to.meta.permission) {
      const permission = to.meta.permission as Permission;

      if (user && userHasPermission(user, permission)) {
        next();
      } else if (
        to.name === 'BookingList' &&
        user?.roleName !== Roles.Admin &&
        user?.roleName !== Roles.ControlRoom
      ) {
        next({ name: 'B2BReports' });
      } else {
        next({ name: 'NotFound' });
      }
    } else {
      next();
    }
  });

  router.afterEach((to) => {
    const existingEntryIndex = routeHistory.findIndex(
      (entry) => entry.fullPath.split('?')[0] === to.fullPath.split('?')[0],
    );
    const newEntry = { fullPath: to.fullPath, query: to.query };

    if (existingEntryIndex !== -1) {
      routeHistory[existingEntryIndex] = newEntry;
    } else {
      routeHistory.push(newEntry);
    }
  });
};
