import { defineStore } from 'pinia';
import { ref } from 'vue';

export const useCoreStore = defineStore('core', () => {
  const numberOfPendingHttpCalls = ref(0);

  const loaderVisible = ref(false);
  const showLoaderOnHttpRequest = ref(true);

  const showLoader = () => {
    loaderVisible.value = true;
  };

  const hideLoader = () => {
    loaderVisible.value = false;
    showLoaderOnHttpRequest.value = true;
  };

  return {
    numberOfPendingHttpCalls,
    loaderVisible,
    showLoaderOnHttpRequest,
    showLoader,
    hideLoader,
  };
});
