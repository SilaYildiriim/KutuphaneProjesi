import React, { useContext, useEffect, useState } from "react";
import { DataContext } from "../context/DataContext";
import "../assets/style/Search.scss";
import { useNavigate } from "react-router-dom";
import defaultImage from "../assets/img/DefaultBook.jpg";

const Search = () => {
  const { setBook, books, fetchBooks } = useContext(DataContext);
  const [options, setOptions] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    fetchBooks();
  }, []);

  const handleOnChange = (event) => {
    const value = event.target.value;
    setSearchTerm(value);

    if (value.length < 3) {
      setOptions([]);
    } else {
      if (Array.isArray(books)) {
        const filteredOptions = books.filter((book) =>
          book.name.toLowerCase().startsWith(value.toLowerCase())
        );
        setOptions(filteredOptions);
      } else {
        setOptions([]);
      }
    }
  };

  const handleOnSelect = (item) => {
    sessionStorage.setItem("selectedBook", JSON.stringify(item));
    setBook(item);
    navigate("/detailsBook");
  };

  return (
    <div className="search-bar-container">
      <input
        type="text"
        value={searchTerm}
        onChange={handleOnChange}
        placeholder="Search Book"
        className="search-input"
      />
      {options.length > 0 ? (
        <div className="dropdown">
          <ul className="suggestions">
            {options.map((item) => (
              <li key={item.id} onClick={() => handleOnSelect(item)}>
                <div className="search-item">
                  <img
                    src={
                      item.image
                        ? `data:image/*;base64,${item.image}`
                        : defaultImage
                    }
                    alt="BookImage"
                  />
                  <span>{item.name}</span>
                </div>
              </li>
            ))}
          </ul>
        </div>
      ) : null}
    </div>
  );
};

export default Search;
