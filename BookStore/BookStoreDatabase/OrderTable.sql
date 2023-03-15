create table OrderTable(
OrderId bigint identity(1,1) not null primary key,
UserId bigint FOREIGN KEY (UserId) REFERENCES UserTable(UserId),
BookId bigint foreign key (BookId) references BookTable(BookId),
AddressId bigint FOREIGN KEY (AddressId) REFERENCES AddressTable(AddressId),
TotalPrice bigint,
BookQuantity bigint,
OrderDate Date
);
select *from OrderTable