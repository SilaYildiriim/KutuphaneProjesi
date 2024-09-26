import React, { useContext, useState } from "react";
import "../assets/style/Card.scss";
import { DataContext } from "../context/DataContext";
import defaultImage from "../assets/img/DefaultBook.jpg";

const Card = ({ id, name, authorName, publisher, price, image }) => {
  const { deleteBook, updateBook, isLoading } = useContext(DataContext);
  const [isUpdate, setIsUpdate] = useState(false);
  const [newImage, setNewImage] = useState("");
  const [updateData, setUpdateData] = useState({
    name,
    authorName,
    publisher,
    price,
  });

  const handleUpdateChange = (e) => {
    setUpdateData({ ...updateData, [e.target.name]: e.target.value });
  };

  const handleUpdate = async () => {
    await updateBook(id, updateData, { newImage: newImage });
    setIsUpdate(false);
  };

  return (
    <div className="card">
      {isUpdate ? (
        <div className="updateform">
          <label>
            <strong>Book Name</strong>
            <input
              type="text"
              name="name"
              value={updateData.name}
              onChange={handleUpdateChange}
            />
          </label>
          <label>
            <strong>Author Name</strong>
            <input
              type="text"
              name="authorName"
              value={updateData.authorName}
              onChange={handleUpdateChange}
            />
          </label>
          <label>
            <strong>Publisher</strong>
            <input
              type="text"
              name="publisher"
              value={updateData.publisher}
              onChange={handleUpdateChange}
            />
          </label>
          <label>
            <strong>Price</strong>
            <input
              type="text"
              name="price"
              value={updateData.price}
              onChange={handleUpdateChange}
            />
          </label>
          <label>
            <strong>Image</strong>
            <input
              id="newImage"
              type="file"
              name="newImage"
              onChange={(event) => setNewImage(event.target.files[0])}
            />
          </label>
          <button onClick={handleUpdate} className="formUpdate">
            Update
          </button>
          <button onClick={() => setIsUpdate(false)} className="formCancel">
            Cancel
          </button>
        </div>
      ) : (
        <div className="card-body">
          <button onClick={() => deleteBook(id)} className="delete">
            {isLoading.delete.some((deleted) => deleted === id)
              ? "Loading"
              : "Delete"}
          </button>
          <button onClick={() => setIsUpdate(true)} className="update">
            Update
          </button>
          <p>
            <strong>Book Name:</strong> {name}
          </p>
          <p>
            <strong>Author Name:</strong> {authorName}
          </p>
          <p>
            <strong>Publisher:</strong> {publisher}
          </p>
          <p>
            <strong>Price:</strong> {price}
          </p>
          <img
            src={image ? `data:image/png;base64,${image}` : defaultImage}
            alt="BookImage"
          />
        </div>
      )}
    </div>
  );
};

export default Card;
