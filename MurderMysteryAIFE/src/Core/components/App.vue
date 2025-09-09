<script lang="ts" setup>
import { useTheme } from '@CoreDesign/utilities/use-theme';
import { useCoreStore } from '../core-store';
import WashoutLoaderDialog from '@CoreDesign/components/WashoutLoaderDialog.vue';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { useFavicon, useTitle } from '@vueuse/core';
import { ElConfigProvider } from 'element-plus';
import { useI18n } from 'vue-i18n';
import { I18nService } from '@Core/services/i18n-service';
import useCoreUserStore from '../../CoreUser/core-user-store';

useTheme();
const { locale } = useI18n();
const favicon = useFavicon();

setEnvironmentFavicon();

const title = useTitle();

setEnvironmentTitle();

const coreStore = useCoreStore();
const coreUserStore = useCoreUserStore();
const route = useRoute();
const layout = computed(() => {
  if (!route.meta.layout) {
    return 'div';
  }

  return route.meta.layout;
});

function setEnvironmentFavicon() {
  const env = import.meta.env.MODE;

  if (env === 'production') {
    return;
  }

  favicon.value = `./${env}-favicon.ico`;
}

function setEnvironmentTitle() {
  const env = import.meta.env.MODE;

  if (env === 'production') {
    return;
  }

  title.value = `${title.value} | ${import.meta.env.VITE_ENVIRONMENT_SHORT_NAME?.toUpperCase() ?? env.toUpperCase()}`;
}

onMounted(() => {
  coreUserStore.setUserLocale();
});

const elementLocale = computed(() => {
  return I18nService.Instance.setDayjsConfig(locale.value);
});
</script>

<template>
  <el-config-provider :locale="elementLocale">
    <component :is="layout">
      <RouterView></RouterView>
      <WashoutLoaderDialog :visible="coreStore.loaderVisible" />
    </component>
  </el-config-provider>
</template>
