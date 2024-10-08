import axios from "axios";

export const AuthService = {
  loginService: async (username, password) => {
    const response = await axios.post("YourBackendApiUrl/api/Login/Login", {
      userName: username,
      password: password,
    });

    if (response.data) {
      const token = response.data.token;
      sessionStorage.setItem("token", token);
      sessionStorage.setItem("user", JSON.stringify(response.data));
    }

    return response;
  },

  logoutService: async () => {
    const response = await axios.get("YourBackendApiUrl/api/Login/Logout");
    return response;
  },
};
