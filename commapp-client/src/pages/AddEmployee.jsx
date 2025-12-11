import { useState } from "react";
import api from "../api/axiosClient";
import { Box, TextField, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function AddEmployee() {
  const [firstName, setfirstName] = useState("");
  const [lastName, setlastName] = useState("");
  const [companyId, setcompanyId] = useState("");

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    // API'ye gönderilecek model
    const newPerson = {
      firstName,
      lastName,
      companyId: Number(companyId) // backend int beklediği için
    };

    api.post("/Persons", newPerson)
      .then(() => {
        alert("Personel başarıyla eklendi!");
        navigate("/persons"); // listeye dönüş
      })
      .catch(err => {
        console.error(err);
        alert("Personel eklenirken bir hata oluştu.");
      });
  };

  return (
    <Box sx={{ p: 4, maxWidth: 500, mx: "auto" }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Yeni Personel Ekle
      </Typography>

      {/* Form alanları */}
      <form onSubmit={handleSubmit}>

        <TextField
          label="Personel Adı"
          fullWidth
          required
          value={firstName}
          onChange={(e) => setfirstName(e.target.value)}
          sx={{ mb: 3 }}
        />

        <TextField
          label="Personel Soyadı"
          fullWidth
          required
          value={lastName}
          onChange={(e) => setlastName(e.target.value)}
          sx={{ mb: 3 }}
        />

        {/* Şirket seçimi için ID */}
        <TextField
          label="Şirket ID"
          type="number"
          fullWidth
          required
          value={companyId}
          onChange={(e) => setcompanyId(e.target.value)}
          sx={{ mb: 3 }}
        />

        <Button type="submit" variant="contained" fullWidth>
          Kaydet
        </Button>
      </form>
    </Box>
  );
}
