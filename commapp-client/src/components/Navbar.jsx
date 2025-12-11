import { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";
import { AppBar, Toolbar, Button } from "@mui/material";

export default function Navbar() {
  const { logout } = useContext(AuthContext);
  const navigate = useNavigate();

  return (
    <AppBar position="static">
      <Toolbar>

        <Button color="inherit" component={Link} to="/companies">
          Şirketler
        </Button>

        <Button color="inherit" component={Link} to="/employees">
          Personeller
        </Button>

        <Button color="inherit" onClick={() => logout(navigate)}>
          Çıkış Yap
        </Button>

      </Toolbar>
    </AppBar>
  );
}
