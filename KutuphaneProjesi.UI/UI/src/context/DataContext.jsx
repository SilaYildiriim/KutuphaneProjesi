import { createContext, useState } from "react";
import { getBooksByTermRequest, getBooksRequest } from "./ApiContext";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export const DataContext = createContext();

export const DataContextProvider = ({ children }) => {
  const [book, setBook] = useState("");
  const [books, setBooks] = useState([]);

  const [isLoading, setIsLoading] = useState({
    allBook: false,
    add: false,
    delete: [],
    update: false,
  });

  const getBooks = async () => {
    setIsLoading((prev) => ({ ...prev, read: true }));
    try {
      const data = await getBooksRequest();
      sessionStorage.setItem("books", JSON.stringify(data));
    } catch (error) {
      console.log("Failed to load books: " + error.message);
    } finally {
      setIsLoading((prev) => ({ ...prev, read: false }));
    }
  };
  const fetchBooks = async () => {
    const bookList = sessionStorage.getItem("books");
    if (!bookList) {
      await getBooks();
      const updatedList = sessionStorage.getItem("books");
      setBooks(JSON.parse(updatedList) || []);
    } else {
      setBooks(JSON.parse(bookList) || []);
    }
  };
  const getBooksByTerm = async (term) => {
    setIsLoading((prev) => ({ ...prev, read: true }));
    try {
      const data = await getBooksByTermRequest(term);
      console.log(data);
      return data;
    } catch (error) {
      toast.error("Failed to load book: ");
    } finally {
      setIsLoading((prev) => ({ ...prev, read: false }));
    }
  };

  return (
    <DataContext.Provider
      value={{
        book,
        books,
        fetchBooks,
        setBook,
        getBooksByTerm,
        getBooks,
      }}
    >
      {children}
    </DataContext.Provider>
  );
};
