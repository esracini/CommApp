import { useState, useEffect } from "react";
import axios from "../api/axiosClient";
import { Box, Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function Companies() {

  const navigate = useNavigate();  
  const [list, setList] = useState([]);

  // Şirket listesini çekiyorum
  useEffect(() => {
    axios
      .get("Companies")
      .then((res) => {
        console.log("API Yanıtı:", res.data);
        setList(res.data);
      })
      .catch((err) => {
        console.error("API Hatası:", err);
      });
  }, []);

  //şirket silme
  const deleteCompany = (companyId) => {
    if (!window.confirm("Bu şirketi silmek istediğine emin misin?")) return;
  
    axios.delete(`Companies/${companyId}`)
      .then(() => {
        setList(list.filter(x => x.id !== companyId));
        alert("Şirket silindi!");
      })
      .catch(err => console.log(err));
  };

  return (
    <Box sx={{ p: 4 }}>
      
      {/* Üst başlık + Yeni Şirket Ekle butonu */}
      <Box 
        sx={{ 
          display: "flex", 
          justifyContent: "space-between", 
          alignItems: "center", 
          mb: 3 
        }}
      >
        <Typography variant="h4">Şirketler</Typography>

        <Button 
          variant="contained" 
          onClick={() => navigate("/add-company")}
        >
          Yeni Şirket Ekle
        </Button>
      </Box>

      {list.map((item) => (
        <Box
          key={item.id}
          sx={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            border: "1px solid #ddd",
            p: 2,
            mb: 2,
            borderRadius: 2
          }}
        >
        
          <span
            style={{ cursor: "pointer" }}
            onClick={() => navigate(`/companies/${item.id}`)}
          >
            {item.name}
          </span>

          <Button
            variant="outlined"
            color="error"
            onClick={() => deleteCompany(item.id)}
          >
            Sil
          </Button>

        </Box>
      ))}

    </Box>
  );
}
