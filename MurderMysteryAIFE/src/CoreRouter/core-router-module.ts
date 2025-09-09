import { createRouter, createWebHashHistory, type Router } from 'vue-router';
import { type WashoutConsoleModule } from 'washout-console-module';
import { useBeforeEachGuard } from '@CoreRouter/utilities/before-each-guard';
import { RouterService } from './services/router-service';

export class CoreRouterModule implements WashoutConsoleModule {
  readonly name: string = 'core-router-module';
  private router?: Router;

  install() {
    this.router = createRouter({
      history: createWebHashHistory(import.meta.env.BASE_URL),
      routes: [
        {
          path: '/',
          name: 'Home',
          redirect: '/bookings',
        },
      ],
    });

    new RouterService(this.router);

    useBeforeEachGuard(this.router);
  }
}
