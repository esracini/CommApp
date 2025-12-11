import { useState } from "react";
import api from "../api/axiosClient";
import { Box, TextField, Button, Typography, MenuItem } from "@mui/material";
import { useParams, useNavigate } from "react-router-dom";

export default function AddContact() {
  const { personId } = useParams();
  const navigate = useNavigate();

  const [type, setType] = useState(0);
  const [value, setValue] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    api.post("/Contacts", {
      personId: Number(personId),
      type: Number(type),
      value
    })
      .then(() => {
        alert("İletişim bilgisi eklendi!");
        navigate("/employees");
      })
      .catch(err => {
        console.error(err);
        alert("Bir hata oluştu.");
      });
  };

  return (
    <Box sx={{ p: 4, maxWidth: 500, mx: "auto" }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        İletişim Bilgisi Ekle
      </Typography>

      <form onSubmit={handleSubmit}>
        <TextField
          select
          label="İletişim Tipi"
          fullWidth
          required
          value={type}
          onChange={(e) => setType(e.target.value)}
          sx={{ mb: 3 }}
        >
          <MenuItem value={0}>Email</MenuItem>
          <MenuItem value={1}>Telefon</MenuItem>
          <MenuItem value={2}>LinkedIn</MenuItem>
        </TextField>

        <TextField
          label="Değer"
          fullWidth
          required
          value={value}
          onChange={(e) => setValue(e.target.value)}
          sx={{ mb: 3 }}
        />

        <Button type="submit" variant="contained" fullWidth>
          Kaydet
        </Button>
      </form>
    </Box>
  );
}
