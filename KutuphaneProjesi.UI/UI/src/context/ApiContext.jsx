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

export const getBooksByTermRequest = async (term) => {
  const response = await axios.get(
    `https://localhost:44310/api/Book/GetBooksByTerm/${term}`,
    {
      headers: {
        Authorization: `Bearer ${sessionStorage.getItem("token")}`,
      },
    }
  );
  return response.data;
};
