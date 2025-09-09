declare module "base-module" {
  export interface BaseModule {
    readonly name: string;

    install();
  }
}
