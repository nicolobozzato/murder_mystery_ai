import { type App as _App, createApp } from "vue";
import dayjs from "dayjs";
import utc from "dayjs/plugin/utc";
import type { BaseModule } from "base-module";
import { createPinia, type Pinia } from "pinia";
import type { I18n } from "vue-i18n";
import { I18nService } from "./services/i18n-service";
import { RouterService } from "@/CoreRouter/services/router-service";
import { coreRouter } from "./router/core-router";
import App from "@/App.vue";

export class CoreModule implements BaseModule {
  readonly name = "core";
  private app?: _App;
  private store?: Pinia;
  private i18n?: I18n;

  constructor() {}

  get App(): _App | undefined {
    return this.app;
  }

  get Store(): Pinia | undefined {
    return this.store;
  }

  install() {
    RouterService.Instance.addNewRoutes(coreRouter);

    this.app = createApp(App);
    this.store = createPinia();

    this.i18n = I18nService.Instance.I18n;

    dayjs.extend(utc);

    this.app.use(RouterService.Instance.Router);
    this.app.use(this.store);
    this.app.use(this.i18n);

    this.app.mount("#app");
  }
}
