import { createContext, useState } from "react";
import { AuthService } from "../services/AuthService";
import { ToastContainer, toast } from "react-toastify";

export const AuthContext = createContext();

export const AuthContextProvider = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState(() => {
    const token = sessionStorage.getItem("token");
    return !!token;
  });

  const login = async (username, password) => {
    try {
      const response = await AuthService.loginService(username, password);
      console.log(response);
      if (
        response.data &&
        response.data.user.userName &&
        response.data.user.role == "user"
      ) {
        sessionStorage.setItem("user", JSON.stringify(response.data));
        sessionStorage.setItem("token", response.data.token);
        setIsAuthenticated(true);
      } else {
        toast.error("User login failed. Please check your information.");
      }
    } catch (error) {
      setIsAuthenticated(false);
      console.log(error.message);
      throw new Error(error.message);
    }
  };

  const logout = async () => {
    try {
      const response = await AuthService.logoutService();
      setIsAuthenticated(false);

      if (response.status == 200) {
        sessionStorage.removeItem("user");
        sessionStorage.removeItem("token");
        setIsAuthenticated(false);
      }
    } catch (error) {}
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
      {children}
      <ToastContainer />
    </AuthContext.Provider>
  );
};
