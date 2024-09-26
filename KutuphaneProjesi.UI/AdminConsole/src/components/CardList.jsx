import React, { useContext, useEffect } from "react";
import Card from "./Card";
import "../assets/style/CardList.scss";
import { DataContext } from "../context/DataContext";

const CardList = () => {
  const { books, fetchBooks } = useContext(DataContext);

  useEffect(() => {
    fetchBooks();
  }, []);

  return (
    <div className="card-list">
      {books.map((book) => (
        <Card key={book.id} {...book} />
      ))}
    </div>
  );
};

export default CardList;
