import "./App.css";
import Navi from "./components/Navi";
import Search from "./components/Search";
import Home from "./components/Home";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import { DataContextProvider } from "./context/DataContext";
import { ToastContainer } from "react-toastify";
import { AuthContextProvider } from "./context/AuthContext";
import PrivateRoute from "./services/PrivateRoute";
import DetailsBook from "./components/DetailsBook";

function App() {
  return (
    <BrowserRouter>
      <AuthContextProvider>
        <ToastContainer autoClose={3000} />
        <Navi />
        <DataContextProvider>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="login" element={<Login />} />
            <Route
              path="detailsBook"
              element={<PrivateRoute element={<DetailsBook />} />}
            />
            <Route
              path="search"
              element={<PrivateRoute element={<Search />} />}
            />
          </Routes>
        </DataContextProvider>
      </AuthContextProvider>
    </BrowserRouter>
  );
}

export default App;
