import { createApp } from "vue";
import App from "./App.vue";
import { router } from "./router";
import VueApexCharts from "vue3-apexcharts";
import Antd from "ant-design-vue";
import Vue3Select from "vue3-select-component";
import Vue3Autocounter from "vue3-autocounter";
import VueFeather from "vue-feather";
import FlagIcon from "vue-flag-icon";
import DatePicker from "vue3-datepicker";
import StarRating from "vue3-star-ratings";
import VueEasyLightbox from "vue-easy-lightbox";

/*************Layout *****************/
import Layout_Header from "@/CoreDesign/layouts/layout-header.vue";
import Layout_Sidebar from "@/CoreDesign/layouts/layout-sidebar.vue";
import VerticalSidebar from "@/CoreDesign/layouts/vertical-sidebar.vue";
import Index_Loader from "@/CoreDesign/layouts/index-loader.vue";
import ThemeSettings from "@/CoreDesign/layouts/theme-settings.vue";

/************Breadcrumb********************/
import Breadcrumb_Index from "@/CoreDesign/components/breadcrumb/breadcrumb-index.vue";

import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "@fortawesome/fontawesome-free/css/fontawesome.min.css";
import "@fortawesome/fontawesome-free/css/all.min.css";
import "boxicons/css/boxicons.min.css";
import "ionicons-npm/css/ionicons.css";
import "material-icons/css/material-icons.min.css";
import "material-icons/css/material-icons.css";
import "pe7-icon/dist/dist/pe-icon-7-stroke.css";
import "typicons.font/src/font/typicons.css";
import "weathericons/css/weather-icons.css";
import "@/assets/css/feather.css";
import "@/assets/css/sticky.css";
import "@/assets/css/tabler-icons.css";
import "@/assets/css/feather.css";
import "@/assets/scss/main.scss";

const app = createApp(App);

/*************Layout *****************/
app.component("layout-header", Layout_Header);
app.component("layout-sidebar", Layout_Sidebar);
app.component("vertical-sidebar", VerticalSidebar);
app.component("layout-sidebar", Layout_Sidebar);
app.component("vertical-sidebar", VerticalSidebar);
app.component("index-loader", Index_Loader);
app.component("theme-settings", ThemeSettings);

/*************Breadcrumb *****************/
app.component("breadcrumb-index", Breadcrumb_Index);

app.use(Antd).use(VueEasyLightbox);
app.use(FlagIcon);
app.component("vue3-select", Vue3Select);
app.component("star-rating", StarRating);
app.component("date-picker", DatePicker);
app.component(VueFeather.name, VueFeather);
app.component("vue3-autocounter", Vue3Autocounter);
app.use(router).mount("#app");
