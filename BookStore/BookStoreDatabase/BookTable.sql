create table BookTable(
   BookId bigint primary key identity(1,1),
   Book_Name varchar(100),
   Author_Name varchar(100),
   Book_Count bigint,
   Price bigint,
   Discount_Price bigint,
   Description varchar(100),
   Rating varchar(100),
   Rating_Count bigint
)
select *from BookTable

alter table BookTable add Book_Image varchar(max);