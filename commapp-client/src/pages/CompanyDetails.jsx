import { useEffect, useState } from "react";
import api from "../api/axiosClient";
import { useParams } from "react-router-dom";
import { Box, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

export default function CompanyDetails() {
  const { id } = useParams();
  const [company, setCompany] = useState(null);
  const navigate = useNavigate();

  // Şirket + çalışan verisi
  useEffect(() => {
    api.get(`/companies/with-persons/${id}`).then(res => {
      setCompany(res.data);
    });
  }, [id]);
  

  if (!company) return <div>Loading...</div>;


  

  return (
    <Box sx={{ p: 3 }}>
      <h2>{company.name}</h2>
      <div style={{marginTop:10, fontsize:18}}>
        <b>Adres:</b> {company.address}
        </div>
    
        <Button 
          variant="contained" 
          sx={{ mr: 2 }}
          onClick={() => navigate(`/edit-company/${company.id}`)}
        >
          Düzenle
        </Button>


      <h3 style={{ marginTop: 40 }}>Çalışanlar</h3>
      {company.persons?.map(per => (
        <Box key={per.id} sx={{ border: "1px solid #ddd", p: 2, mt: 2, borderRadius: 2 }}>
          <b>{per.firstName} {per.lastName}</b>
          {per.company?.map(c=>(

            <div key={c.id}>
              <div><b> İletişim Tipi:</b>{c.type}</div>
              <div><b> Bilgi:<b/>{c.value}</b></div>
            </div>
          ))}
       
        </Box>
      ))}
    </Box>
  );
}
