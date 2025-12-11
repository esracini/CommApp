import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import api from "../api/axiosClient";
import { Box, TextField, Button, Typography } from "@mui/material";

export default function EditCompany() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [name, setName] = useState("");
  const [address, setAddress] = useState("");

  useEffect(() => {
    api.get(`/companies/${id}`)
      .then(res => {
        setName(res.data.name);
        setAddress(res.data.address);
      })
      .catch(err => console.log(err));
  }, [id]);

  const handleUpdate = (e) => {
    e.preventDefault();

    const updatedCompany = { id, name, address };

    api.put(`/companies/${id}`, updatedCompany)
      .then(() => {
        alert("Şirket başarıyla güncellendi!");
        navigate(`/companies/${id}`);
      })
      .catch(err => console.log(err));
  };

  return (
    <Box sx={{ p: 4, maxWidth: 500, mx: "auto" }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Şirketi Düzenle
      </Typography>

      <form onSubmit={handleUpdate}>
        <TextField
          label="Şirket Adı"
          fullWidth
          value={name}
          onChange={(e) => setName(e.target.value)}
          sx={{ mb: 3 }}
        />

        <TextField
          label="Adres"
          fullWidth
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
