import { useState, useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { TextField, Button, Box, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const { login } = useContext(AuthContext);
  const navigate = useNavigate();

  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    login(username, password, navigate);
  };

  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        width: 300,
        margin: "100px auto",
      }}
    >
      <Typography variant="h5" sx={{ mb: 2 }}>
        Giriş Yap
      </Typography>

      <TextField
        label="Kullanıcı Adı"
        variant="outlined"
        sx={{ mb: 2 }}
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />

      <TextField
        label="Şifre"
        type="password"
        variant="outlined"
        sx={{ mb: 2 }}
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <Button variant="contained" onClick={handleSubmit}>
        GİRİŞ YAP
      </Button>

      <Button
        variant="text"
        onClick={() => navigate("/register")}
        sx={{ mt: 2 }}
      >
        Hesabın yok mu? Kayıt Ol
      </Button>
    </Box>
  );
}
