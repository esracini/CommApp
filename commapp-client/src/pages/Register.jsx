import { useState, useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { TextField, Button, Box, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("User");

  const { register } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleRegister = () => {
    register(username, password, role, navigate);
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
        Kayıt Ol
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
        variant="outlined"
        type="password"
        sx={{ mb: 2 }}
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <TextField
        label="Rol"
        variant="outlined"
        sx={{ mb: 2 }}
        value={role}
        onChange={(e) => setRole(e.target.value)}
      />

      <Button variant="contained" onClick={handleRegister}>
        KAYIT OL
      </Button>
    </Box>
  );
}
