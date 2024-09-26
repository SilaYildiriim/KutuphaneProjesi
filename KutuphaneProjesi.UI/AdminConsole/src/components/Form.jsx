import React, { useContext, useState } from "react";
import { DataContext } from "../context/DataContext";
import "../assets/style/Form.scss";

const Form = () => {
  const { addBook, isLoading } = useContext(DataContext);

  const [file, setFile] = useState("");
  const [image, setImage] = useState("");

  const [error, setError] = useState({
    title: false,
    image: false,
    description: false,
  });

  const handleSubmit = (event) => {
    event.preventDefault();

    if (file) {
      addBook({
        file: file,
        image: image,
      });
      setError({
        file: false,
        image: false,
      });
      setFile(null);
      setImage(null);
      document.getElementById("file").value = "";
      document.getElementById("image").value = "";
    } else {
      setError({
        file: !file,
        image: !image,
      });
    }
  };

  return (
    <div className="container">
      <form onSubmit={handleSubmit} className="formAddBook">
        <h3>ADD BOOK</h3>
        <div>
          <label>Select File:</label>
          <input
            id="file"
            type="file"
            accept=".xlsx, .txt, .pdf"
            onChange={(event) => setFile(event.target.files[0])}
          />
          <label>Select Image:</label>
          <input
            id="image"
            type="file"
            accept=".jpg, .jpeg, .png"
            onChange={(event) => setImage(event.target.files[0])}
          />
        </div>
        <button type="submit">
          {isLoading.add ? "Loading" : "Upload File"}
        </button>
      </form>

      {file && (
        <section className="fileDetails">
          <h4>File details:</h4>
          <ul>
            <li>Name: {file.name}</li>
            <li>Type: {file.type}</li>
            <li>Size: {file.size} bytes</li>
          </ul>
        </section>
      )}
    </div>
  );
};

export default Form;
