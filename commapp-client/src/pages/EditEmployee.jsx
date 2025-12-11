import { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";
import api from "../api/axiosClient";
import { Box, TextField, Button, MenuItem, Typography } from "@mui/material";

export default function EditEmployee() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [person, setPerson] = useState(null);
  const [companies, setCompanies] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    Promise.all([
      api.get(`/persons/with-relations/${id}`),
      api.get("/companies")
    ])
      .then(([personRes, companyRes]) => {
        setPerson(personRes.data);
        setCompanies(companyRes.data);
        setLoading(false);
      })
      .catch(err => console.error(err));
  }, [id]);

  if (loading) return <h2>Yükleniyor...</h2>;

 
  const handleChange = (field, value) => {
    setPerson({ ...person, [field]: value });
  };

  const updateContact = (index, field, value) => {
    const updated = [...person.contacts];
    updated[index][field] = value;
    setPerson({ ...person, contacts: updated });
  };

 // İletişim bilgisini silme
  const deleteContact = (index) => {
    if (!window.confirm("Bu iletişim bilgisini silmek istiyor musun?")) return;

    const updated = [...person.contacts];
    updated.splice(index, 1);
    setPerson({ ...person, contacts: updated });
  };

  const savePerson = () => {
    const dto = {
      firstName: person.firstName,
      lastName: person.lastName,
      companyId: person.company.id,
      contacts: person.contacts.map(c => ({
        id: c.id,
        type: Number(c.type),
        value: c.value,
        personId: person.id
      }))
    };

    api.put(`/persons/${id}`, dto)
      .then(() => {
        alert("Personel güncellendi!");
        navigate("/employees");
      })
      .catch(err => {
        console.error(err);
        alert("Bir hata oluştu!");
      });
  };

  return (
    <Box sx={{ maxWidth: 600, mx: "auto", mt: 4 }}>
      <Typography variant="h4" sx={{ mb: 3 }}>
        Personel Düzenle
      </Typography>

      <TextField
        label="Ad"
        fullWidth
        sx={{ mb: 2 }}
        value={person.firstName}
        onChange={(e) => handleChange("firstName", e.target.value)}
      />


      <TextField
        label="Soyad"
        fullWidth
        sx={{ mb: 2 }}
        value={person.lastName}
        onChange={(e) => handleChange("lastName", e.target.value)}
      />


      <TextField
        label="Şirket"
        select
        fullWidth
        sx={{ mb: 3 }}
        value={person.company.id}
        onChange={(e) =>
          setPerson({ ...person, company: { id: Number(e.target.value) } })
        }
      >
        {companies.map((c) => (
          <MenuItem key={c.id} value={c.id}>
            {c.name}
          </MenuItem>
        ))}
      </TextField>

      <Typography variant="h6" sx={{ mt: 3 }}>
        İletişim Bilgileri
      </Typography>

      {person.contacts.map((contact, index) => (
        <Box
          key={index}
          sx={{
            p: 2,
            border: "1px solid #ccc",
            borderRadius: 2,
            mt: 2
          }}
        >

          <TextField
            label="Tür"
            select
            fullWidth
            sx={{ mb: 2 }}
            value={contact.type}
            onChange={(e) => updateContact(index, "type", e.target.value)}
          >
            <MenuItem value={0}>Email</MenuItem>
            <MenuItem value={1}>Telefon</MenuItem>
            <MenuItem value={2}>LinkedIn</MenuItem>
          </TextField>


          <TextField
            label="Değer"
            fullWidth
            value={contact.value}
            onChange={(e) => updateContact(index, "value", e.target.value)}
          />

          <Button
            color="error"
            variant="outlined"
            sx={{ mt: 1 }}
            onClick={() => deleteContact(index)}
          >
            Sil
          </Button>
        </Box>
      ))}

      <Button
        variant="contained"
        color="success"
        fullWidth
        sx={{ mt: 3 }}
        onClick={savePerson}
      >
        Kaydet
      </Button>
    </Box>
  );
}
