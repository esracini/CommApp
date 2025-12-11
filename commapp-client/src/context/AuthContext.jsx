import { createContext, useState } from "react";
import axios from "../api/axiosClient";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(localStorage.getItem("token") || null);

  // LOGIN
  const login = async (username, password, navigate) => {
    try {
      const response = await axios.post("/Auth/login", {
        Username: username,
        Password: password,
      });

      const token = response.data.token;
      setToken(token);
      localStorage.setItem("token", token);

      navigate("/companies", { replace: true });
    } catch (err) {
      console.error("Login Hatası:", err);
      alert("Giriş hatalı!");
    }
  };

  // REGISTER
  const register = async (username, password, role, navigate) => {
    try {
      await axios.post("/Auth/register", {
        Username: username,
        Password: password,
        Role: role,
      });

      alert("Kayıt başarılı! Giriş yapabilirsiniz.");
      navigate("/login", { replace: true });
    } catch (err) {
      alert("Kayıt sırasında bir hata oluştu!");
    }
  };

  const logout = (navigate) => {
    localStorage.removeItem("token");
    setToken(null);
    navigate("/login", { replace: true });
  };

  return (
    <AuthContext.Provider value={{ token, login, register, logout }}>
      {children}
    </AuthContext.Provider>
  );
};
