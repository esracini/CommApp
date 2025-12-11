import React from "react";
import { BrowserRouter, Routes, Route, Navigate, useLocation } from "react-router-dom";

import Login from "./pages/Login";
import Register from "./pages/Register";
import Companies from "./pages/Companies";
import Navbar from "./components/Navbar";
import CompanyDetails from "./pages/CompanyDetails";

import { AuthProvider, AuthContext } from "./context/AuthContext";
import Employees from "./pages/Employees";
import AddCompany from "./pages/AddCompany";
import AddEmployee from "./pages/AddEmployee";
import AddContact from "./pages/AddContact";
import EditCompany from "./pages/EditCompany";
import EditEmployee from "./pages/EditEmployee";



function ProtectedRoute({ children }) {
  const { token } = React.useContext(AuthContext);

  if (!token) {
    return <Navigate to="/login" replace />;
  }

  return children;
}

function Layout({ children }) {
  const location = useLocation();
  const hideNavbarOn = ["/login", "/register"];
  const hide = hideNavbarOn.includes(location.pathname);

  return (
    <>
      {!hide && <Navbar />}
      {children}
    </>
  );
}

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Layout>
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />

            <Route
              path="/companies"
              element={
                <ProtectedRoute>
                  <Companies/>
                </ProtectedRoute>
              }
            />
            <Route
            path="/companies/:id"
            element={
              <ProtectedRoute>
                <CompanyDetails/>
              </ProtectedRoute>
              }
            />
            <Route
            path="add-company"
            element={
              <ProtectedRoute>
                <AddCompany/>
              </ProtectedRoute>
            }
            
            />
            <Route
            path="/edit-company/:id"
            element={
              <ProtectedRoute>
                <EditCompany/>
              </ProtectedRoute>
            }
            />


            <Route
            path="/employees"
            element={
              <ProtectedRoute>
                <Employees/>
              </ProtectedRoute>
            }
            />

            <Route
            path="/add-employee"
            element={
              <ProtectedRoute>
                <AddEmployee />
              </ProtectedRoute>
            }
            />
            <Route
            path="/edit-employee/:id"
            element={
              <ProtectedRoute>
                <EditEmployee/>
              </ProtectedRoute>
            }
            />

            <Route
            path="/add-contact/:personId"
            element={
              <ProtectedRoute>
                <AddContact />
             </ProtectedRoute>
           }
          />



            {/* Default yönlendirme */}
            <Route path="/" element={<Navigate to="/login" replace />} />
          </Routes>
        </Layout>
      </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
