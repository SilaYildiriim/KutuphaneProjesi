import React, { useContext, useState, useEffect } from "react";
import "../assets/style/Card.scss";
import { DataContext } from "../context/DataContext";
import defaultImage from "../assets/img/DefaultBook.jpg";

const DetailsBook = () => {
  const { book } = useContext(DataContext);
  const [selectedBook, setSelectedBook] = useState(null);

  useEffect(() => {
    const storedBook = sessionStorage.getItem("selectedBook");
    if (storedBook) {
      setSelectedBook(JSON.parse(storedBook));
    }
  }, []);

  return (
    <div className="card">
      <img
        src={
          book?.image
            ? `data:image/*;base64,${book.image}`
            : selectedBook?.image
            ? `data:image/*;base64,${selectedBook.image}`
            : defaultImage
        }
        alt="BookImage"
      />
      <div className="information">
        <p>
          <span>Book Name :</span>
          {book?.name || selectedBook?.name || "No book name available."}
        </p>
        <p>
          <span>Author Name :</span>
          {book?.authorName ||
            selectedBook?.authorName ||
            "No author name available."}
        </p>
        <p>
          <span>Publisher :</span>
          {book?.publisher ||
            selectedBook?.publisher ||
            "No publisher available."}
        </p>
        <p>
          <span>Price :</span>
          {book?.price || selectedBook?.price || "No price available."}
        </p>
      </div>
    </div>
  );
};

export default DetailsBook;
