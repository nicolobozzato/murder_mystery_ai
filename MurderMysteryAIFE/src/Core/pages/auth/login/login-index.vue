<template>
  <div class="account-page">
    <div class="container-fuild">
      <div
        class="w-100 overflow-hidden position-relative flex-wrap d-block vh-100"
      >
        <div class="row">
          <div class="col-lg-6">
            <div
              class="login-background position-relative d-lg-flex align-items-center justify-content-center d-lg-block d-none flex-wrap vh-100 overflowy-auto"
            >
              <div>
                <img
                  src="@/assets/img/authentication/authentication-02.jpg"
                  alt="Img"
                />
              </div>
              <div class="authen-overlay-item w-100 p-4">
                <h4 class="text-white mb-3">What's New on Preskool !!!</h4>
                <div
                  class="d-flex align-items-center flex-row mb-3 justify-content-between p-3 br-5 gap-3 card"
                >
                  <div>
                    <h6>Summer Vacation Holiday Homework</h6>
                    <p class="mb-0 text-truncate">
                      The school will remain closed from April 20th to June...
                    </p>
                  </div>
                  <a href="javascript:void(0);"
                    ><i class="ti ti-chevrons-right"></i
                  ></a>
                </div>
                <div
                  class="d-flex align-items-center flex-row mb-3 justify-content-between p-3 br-5 gap-3 card"
                >
                  <div>
                    <h6>New Academic Session Admission Start(2024-25)</h6>
                    <p class="mb-0 text-truncate">
                      An academic term is a portion of an academic year, the
                      time ....
                    </p>
                  </div>
                  <a href="javascript:void(0);"
                    ><i class="ti ti-chevrons-right"></i
                  ></a>
                </div>
                <div
                  class="d-flex align-items-center flex-row mb-3 justify-content-between p-3 br-5 gap-3 card"
                >
                  <div>
                    <h6>Date sheet Final Exam Nursery to Sr.Kg</h6>
                    <p class="mb-0 text-truncate">
                      Dear Parents, As the final examination for the session
                      2024-25 is ...
                    </p>
                  </div>
                  <a href="javascript:void(0);"
                    ><i class="ti ti-chevrons-right"></i
                  ></a>
                </div>
                <div
                  class="d-flex align-items-center flex-row mb-3 justify-content-between p-3 br-5 gap-3 card"
                >
                  <div>
                    <h6>Annual Day Function</h6>
                    <p class="mb-0 text-truncate">
                      Annual functions provide a platform for students to
                      showcase their...
                    </p>
                  </div>
                  <a href="javascript:void(0);"
                    ><i class="ti ti-chevrons-right"></i
                  ></a>
                </div>
                <div
                  class="d-flex align-items-center flex-row mb-0 justify-content-between p-3 br-5 gap-3 card"
                >
                  <div>
                    <h6>Summer Vacation Holiday Homework</h6>
                    <p class="mb-0 text-truncate">
                      The school will remain closed from April 20th to June
                      15th for summer...
                    </p>
                  </div>
                  <a href="javascript:void(0);"
                    ><i class="ti ti-chevrons-right"></i
                  ></a>
                </div>
              </div>
            </div>
          </div>
          <div class="col-lg-6 col-md-12 col-sm-12">
            <div
              class="row justify-content-center align-items-center vh-100 overflow-auto flex-wrap"
            >
              <div class="col-md-8 mx-auto p-4">
                <Form
                  @submit="onSubmit"
                  :validation-schema="schema"
                  v-slot="{ errors }"
                >
                  <div>
                    <div class="mx-auto mb-5 text-center">
                      <img
                        src="@/assets/img/authentication/authentication-logo.svg"
                        class="img-fluid"
                        alt="Logo"
                      />
                    </div>
                    <div class="card">
                      <div class="card-body">
                        <div class="mb-4">
                          <h2 class="mb-2">Welcome</h2>
                          <p class="mb-0">
                            Please enter your details to sign in
                          </p>
                        </div>
                        <div class="mt-4">
                          <div
                            class="d-flex align-items-center justify-content-center flex-wrap"
                          >
                            <div class="text-center me-2 flex-fill">
                              <a
                                href="javascript:void(0);"
                                class="bg-primary br-10 p-2 btn btn-primary d-flex align-items-center justify-content-center"
                              >
                                <img
                                  class="img-fluid m-1"
                                  src="@/assets/img/icons/facebook-logo.svg"
                                  alt="Facebook"
                                />
                              </a>
                            </div>
                            <div class="text-center me-2 flex-fill">
                              <a
                                href="javascript:void(0);"
                                class="br-10 p-2 btn btn-outline-light d-flex align-items-center justify-content-center"
                              >
                                <img
                                  class="img-fluid m-1"
                                  src="@/assets/img/icons/google-logo.svg"
                                  alt="Facebook"
                                />
                              </a>
                            </div>
                            <div class="text-center flex-fill">
                              <a
                                href="javascript:void(0);"
                                class="bg-dark br-10 p-2 btn btn-dark d-flex align-items-center justify-content-center"
                              >
                                <img
                                  class="img-fluid m-1"
                                  src="@/assets/img/icons/apple-logo.svg"
                                  alt="Apple"
                                />
                              </a>
                            </div>
                          </div>
                        </div>
                        <div class="login-or">
                          <span class="span-or">Or</span>
                        </div>
                        <div class="mb-3">
                          <label class="form-label">Email Address</label>
                          <div class="input-icon mb-3 position-relative">
                            <span class="input-icon-addon">
                              <i class="ti ti-mail"></i>
                            </span>
                            <Field
                              name="email"
                              type="text"
                              value="example@dreamstechnologies.com"
                              class="form-control"
                              :class="{ 'is-invalid': errors.email }"
                            />
                          </div>
                          <label class="form-label">Password</label>
                          <div class="pass-group">
                            <Field
                              name="password"
                              :type="showPassword ? 'text' : 'password'"
                              value="123456"
                              class="form-control pass-input mt-2"
                              :class="{ 'is-invalid': errors.password }"
                            />
                            <span @click="toggleShow" class="toggle-password">
                              <i
                                :class="{
                                  'ti ti-eye': showPassword,
                                  'ti ti-eye-off': !showPassword,
                                }"
                              ></i>
                            </span>
                            <div class="invalid-feedback">
                              {{ errors.password }}
                            </div>
                            <div
                              class="emailshow text-danger"
                              id="password"
                            ></div>
                          </div>
                        </div>

                        <div class="form-wrap form-wrap-checkbox mb-3">
                          <div class="d-flex align-items-center">
                            <div class="form-check form-check-md mb-0">
                              <input
                                class="form-check-input mt-0"
                                type="checkbox"
                              />
                            </div>
                            <p class="ms-1 mb-0">Remember Me</p>
                          </div>
                          <div class="text-end">
                            <router-link
                              to="/forgot-password"
                              class="link-danger"
                              >Forgot Password?</router-link
                            >
                          </div>
                        </div>
                        <div class="mb-3">
                          <button type="submit" class="btn btn-primary w-100">
                            Sign In
                          </button>
                        </div>
                        <div class="text-center">
                          <h6 class="fw-normal text-dark mb-0">
                            Don’t have an account?
                            <router-link to="/register" class="hover-a">
                              Create Account</router-link
                            >
                          </h6>
                        </div>
                      </div>
                    </div>
                    <div class="mt-5 text-center">
                      <p>
                        Copyright &copy; {{ new Date().getFullYear() }} -
                        Preskool
                      </p>
                    </div>
                  </div>
                </Form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
import { router } from "@/router";
import { Form, Field } from "vee-validate";
import * as Yup from "yup";
export default {
  components: {
    /* eslint-disable vue/no-reserved-component-names */
    Form,
    Field,
  },
  data() {
    return {
      showPassword: false,
      password: null,
      emailError: "",
      passwordError: "",
    };
  },
  computed: {
    buttonLabel() {
      return this.showPassword ? "Hide" : "Show";
    },
  },
  methods: {
    toggleShow() {
      this.showPassword = !this.showPassword;
    },
  },
  setup() {
    let users = localStorage.getItem("storedData");
    if (users === null) {
      let password = [
        {
          email: "example@dreamstechnologies.com",
          password: "123456",
        },
      ];
      const jsonData = JSON.stringify(password);
      localStorage.setItem("storedData", jsonData);
    }
    const schema = Yup.object().shape({
      email: Yup.string()
        .required("Email is required")
        .email("Email is invalid"),
      password: Yup.string()
        .min(6, "Password must be at least 6 characters")
        .required("Password is required"),
    });
    const onSubmit = (values) => {
      // document.getElementById("email").innerHTML = "";
      // document.getElementById("password").innerHTML = "";
      let data = localStorage.getItem("storedData");
      var Pdata = JSON.parse(data);
      const Eresult = Pdata.find(({ email }) => email === values.email);
      if (Eresult) {
        if (Eresult.password === values.password) {
          router.push("/dashboard");
        } else {
          document.getElementById("password").innerHTML = "Incorrect password";
        }
      } else {
        document.getElementById("email").innerHTML = "Email is not valid";
      }
    };
    return {
      schema,
      onSubmit,
      checked: ref(false),
    };
  },
};
</script>
