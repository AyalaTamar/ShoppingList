CREATE TABLE CustomersItems (
    CustomerID INT,
    ItemID INT,
    Quantity INT,
	PRIMARY KEY (CustomerID, ItemID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(customerID),
    FOREIGN KEY (ItemID) REFERENCES Items(id)
);
