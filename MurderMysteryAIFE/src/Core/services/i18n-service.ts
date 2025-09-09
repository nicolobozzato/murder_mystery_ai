import { createI18n, type I18n } from "vue-i18n";
import moment from "moment";
import type { Ref, WritableComputedRef } from "vue";
import "moment/dist/locale/it";
import "moment/dist/locale/fr";

export type MurderMysteryAiLocales = "it" | "en" | "fr";

export class I18nService {
  private static instance: I18nService;
  private readonly locales: MurderMysteryAiLocales[] = ["it", "en", "fr"];
  private readonly i18n: I18n;

  private constructor() {
    type I18nMessages = Record<MurderMysteryAiLocales, any>;
    this.i18n = createI18n<
      [I18nMessages],
      MurderMysteryAiLocales,
      any,
      any,
      any
    >({
      locale: navigator.language,
      messages: this.locales,
      fallbackLocale: "en",
      fallbackWarn: false,
      missingWarn: false,
      availableLocales: this.locales,
      legacy: false,
    });
    moment.locale((this.i18n.global.locale as WritableComputedRef<any>).value);
  }

  static get Instance(): I18nService {
    if (!I18nService.instance) {
      I18nService.instance = new I18nService();
    }

    return I18nService.instance;
  }

  get I18n() {
    return this.i18n;
  }

  addMoreMessages<T>(messages: Record<MurderMysteryAiLocales, T>) {
    for (const locale of this.locales) {
      this.i18n.global.mergeLocaleMessage(locale, messages[locale]);
    }
  }

  public setLocale(newLocale: string) {
    (this.I18n.global.locale as Ref).value = newLocale;
    moment.locale(newLocale);
  }
}
