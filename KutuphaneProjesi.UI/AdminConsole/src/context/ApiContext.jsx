import axios from "axios";

export const getBooksRequest = async () => {
  const response = await axios.get(
    "https://localhost:44310/api/Book/GetAllBooks",
    {
      headers: {
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      },
    }
  );
  return response.data;
};

export const addBookRequest = async (newBook) => {
  const response = await axios.post(
    "https://localhost:44310/api/Book/AddBook",
    newBook,
    {
      headers: {
        "Content-Type": "multipart/form-data",
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      },
    }
  );
  return response.data;
};

export const deleteBookRequest = async (id) => {
  const response = await axios.delete(
    `https://localhost:44310/api/Book/DeleteBook/${id}`,
    {
      headers: {
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      },
    }
  );
};

export const updateBookRequest = async (id, formData) => {
  const response = await axios.patch(
    `https://localhost:44310/api/Book/UpdateBook/${id}`,
    formData,
    {
      headers: {
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      },
    }
  );
  return response.data;
};
