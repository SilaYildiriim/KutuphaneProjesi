import { createContext, useState } from "react";
import {
  addBookRequest,
  deleteBookRequest,
  updateBookRequest,
  getBooksRequest,
} from "./ApiContext";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export const DataContext = createContext();

export const DataContextProvider = ({ children }) => {
  const [books, setBooks] = useState([]);
  const [editBook, setEditBook] = useState("");

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

  const addBook = async (newBook) => {
    setIsLoading((prev) => ({ ...prev, add: true }));
    try {
      const formData = new FormData();
      formData.append("File", newBook.file);
      formData.append("Image", newBook.image);
      const addedBook = await addBookRequest(formData);
      setBooks((prev) => [...prev, addedBook]);
      toast.success("Book added successfully!");
    } catch (error) {
      toast.error(
        "Failed to add book! Please check the file format and try again."
      );
    } finally {
      setIsLoading((prev) => ({ ...prev, add: false }));
    }
  };

  const deleteBook = async (id) => {
    setIsLoading((prev) => ({ ...prev, delete: [...prev.delete, id] }));
    try {
      await deleteBookRequest(id);
      setBooks((prev) => prev.filter((deleted) => deleted.id !== id));
      toast.success("Book deleted successfully!");
    } catch (error) {
      toast.error("Failed to delete book! Please try again.");
    } finally {
      setIsLoading((prev) => ({
        ...prev,
        delete: prev.delete.filter((deleted) => deleted !== id),
      }));
    }
  };

  const updateBook = async (id, updateData, image) => {
    setIsLoading((prev) => ({ ...prev, update: true }));
    try {
      const formData = new FormData();
      if (!image.newImage) formData.append("Image", image.newImage);
      formData.append("Name", updateData.name);
      formData.append("AuthorName", updateData.authorName);
      formData.append("Publisher", updateData.publisher);
      formData.append("Price", updateData.price);

      const updatedBook = await updateBookRequest(id, formData);
      setBooks((prev) =>
        prev.map((book) => (book.id === id ? updatedBook : book))
      );
      toast.success("Book updated successfully!");
    } catch (error) {
      toast.error(
        "Failed to update book! Please check the entered information."
      );
    } finally {
      setIsLoading((prev) => ({ ...prev, update: false }));
      setEditBook("");
    }
  };

  return (
    <DataContext.Provider
      value={{
        books,
        isLoading,
        addBook,
        deleteBook,
        updateBook,
        getBooks,
        fetchBooks,
      }}
    >
      {children}
    </DataContext.Provider>
  );
};
