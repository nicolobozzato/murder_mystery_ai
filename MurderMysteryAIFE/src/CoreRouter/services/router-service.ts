import type { RouteRecordRaw, Router } from 'vue-router';

/**
 * This class have some methods to help access to router, and other methods (e.g. addNewRoute, addNewRoutes)
 */
export class RouterService {
  private static instance: RouterService;

  constructor(private router: Router) {
    if (RouterService.instance) {
      throw new Error('RouterService is already initialized');
    }
    RouterService.instance = this;
  }
  static get Instance() {
    if (!this.instance) {
      throw new Error('RouterService is not initialized. Call the constructor to initialize it');
    }
    return this.instance;
  }

  get Router() {
    return this.router;
  }

  addNewRoute(route: RouteRecordRaw): void {
    if (!this.router) {
      throw new Error('Router is not initialized');
    }
    this.router?.addRoute(route);
  }

  addNewRoutes(routes: RouteRecordRaw[]): void {
    if (!this.router) {
      throw new Error('Router is not initialized');
    }

    routes.forEach((route) => {
      this.router?.addRoute(route);
    });
  }
}
