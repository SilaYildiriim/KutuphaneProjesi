import React, { useContext } from "react";
import "../assets/style/Navi.scss";
import { NavLink, Outlet, useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";
import { DataContext } from "../context/DataContext";

const Navi = () => {
  const { isAuthenticated, logout } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogin = () => {
    navigate("/login");
  };

  const handleLogout = () => {
    logout();
    navigate("/login");
  };

  return (
    <>
      <nav>
        <div className="logo-baslik">
          <h3>Admın Console</h3>
        </div>
        <ul>
          <li>
            <NavLink to="bookList">Books</NavLink>
          </li>
          <li>
            <NavLink to="addBook">Add Book</NavLink>
          </li>
          <button
            className="button"
            onClick={isAuthenticated ? handleLogout : handleLogin}
          >
            {isAuthenticated ? "Logout" : "Logın"}
          </button>
        </ul>
      </nav>
      <Outlet />
    </>
  );
};

export default Navi;
