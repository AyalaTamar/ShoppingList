CREATE TABLE Items(
 id INT IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(255),
  category_id INT,
    FOREIGN KEY (category_id) REFERENCES [dbo].[Categories](id)
)