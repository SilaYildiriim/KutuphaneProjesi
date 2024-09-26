import "./App.css";
import Navi from "./components/Navi";
import CardList from "./components/CardList";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import { DataContextProvider } from "./context/DataContext";
import { ToastContainer } from "react-toastify";
import Form from "./components/Form";
import { AuthContextProvider } from "./context/AuthContext";
import PrivateRoute from "./services/PrivateRoute";
import Home from "./components/Home";

function App() {
  return (
    <BrowserRouter>
      <AuthContextProvider>
        <ToastContainer autoClose={3000} />
        <DataContextProvider>
          <Navi />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="login" element={<Login />} />
            <Route
              path="addBook"
              element={<PrivateRoute element={<Form />} />}
            />
            <Route
              path="bookList"
              element={<PrivateRoute element={<CardList />} />}
            />
          </Routes>
        </DataContextProvider>
      </AuthContextProvider>
    </BrowserRouter>
  );
}

export default App;
