import { useEffect, useState } from "react";
import axios from "../api/axiosClient";
import { Box, Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function Persons() {
  const [list, setList] = useState([]);
  const navigate = useNavigate();

  // Person + ilişkili veriler
  useEffect(() => {
    axios.get("/Persons/with-relations")
      .then((res) => {
        console.log("API Yanıtı:", res.data);
        setList(res.data);
      })
      .catch((err) => console.error("API Hatası:", err));
  }, []);

  // Silme işlemi 
  const deleteEmployee = (personId) => {
    if (!window.confirm("Bu personeli silmek istediğine emin misin?")) return;
  
    axios.delete(`Persons/${personId}`)
      .then(() => {
        setList(list.filter(x => x.id !== personId));
        alert("Personel silindi!");
      })
      .catch(err => console.log(err));
  };

  return (
    <Box sx={{ p: 4 }}>

      {/* Başlık + yeni personel butonu */}
      <Box 
        sx={{ 
          display: "flex", 
          justifyContent: "space-between",
          alignItems: "center",
          mb: 3 
        }}
      >
        <Typography variant="h4">Personeller</Typography>

        <Button 
          variant="contained" 
          onClick={() => navigate("/add-employee")}
        >
          Personel Ekle
        </Button>
      </Box>

      {/* Personel listesi */}
      {list.map((item) => (
        <Box
          key={item.id}
          sx={{
            border: "1px solid #ddd",
            p: 2,
            mb: 2,
            borderRadius: 2,
            position: "relative"
          }}
        >
          <b>{item.firstName} {item.lastName}</b>

          {/* Şirket bilgisi */}
          {item.company && (
            <Box sx={{ mt: 1, color: "#555" }}>
              <b>Şirket:</b> {item.company.name}
            </Box>
          )}

          {/* İletişim bilgileri */}
          {item.contacts?.length > 0 && (
            <Box sx={{ mt: 1 }}>
              <b>İletişim:</b>
              {item.contacts.map((c) => (
                <div key={c.id}>
                  {{
                    0: "Email: ",
                    1: "Telefon: ",
                    2: "LinkedIn: "
                  }[c.type]}
                  
                  {c.value}
                </div>
              ))}
            </Box>
          )}

          <Box sx={{ display: "flex", gap: 1, mt: 2 }}>
            <Button
              variant="contained"
              color="primary"
              onClick={() => navigate(`/add-contact/${item.id}`)}
            >
              İletişim Bilgisi Ekle
            </Button>

            <Button
              variant="outlined"
              color="secondary"
              onClick={() => navigate(`/edit-employee/${item.id}`)}
            >
              Düzenle
            </Button>

            <Button
              variant="outlined"
              color="error"
              onClick={() => deleteEmployee(item.id)}
            >
              Sil
            </Button>
          </Box>
        </Box>
      ))}
    </Box>
  );
}
