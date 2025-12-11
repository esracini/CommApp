import { useState } from "react";
import api from "../api/axiosClient";
import { Box, TextField, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function AddCompany() {
  const [name, setName] = useState("");
  const [address, setAddress] = useState("");

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    const newCompany = { name, address };

    api.post("/Companies", newCompany)
      .then(() => {
        alert("Şirket başarıyla eklendi!");
        navigate("/companies");
      })
      .catch(err => {
        console.error(err);
        alert("Şirket eklenirken bir hata oluştu.");
      });
  };

  return (
    <Box sx={{ p: 4, maxWidth: 500, mx: "auto" }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Yeni Şirket Ekle
      </Typography>

      <form onSubmit={handleSubmit}>

        <TextField
          label="Şirket Adı"
          fullWidth
          required
          value={name}
          onChange={(e) => setName(e.target.value)}
          sx={{ mb: 3 }}
        />

        <TextField
          label="Adres"
          fullWidth
          required
          value={address}
          onChange={(e) => setAddress(e.target.value)}
          sx={{ mb: 3 }}
        />

        <Button type="submit" variant="contained" fullWidth>
          Kaydet
        </Button>
      </form>
    </Box>
  );
}
