create procedure spUpdateBook(
@BookId bigint,
@Book_Name varchar(100),
@Author_Name varchar(100),
@Book_Count bigint,
@Price bigint,
@Discount_Price bigint,
@Description varchar(100),
@Rating varchar(100),
@Rating_Count bigint,
@Book_Image varchar(max)
)
as
update BookTable set 
Book_Name=@Book_Name,
Author_Name=@Author_Name,
Book_Count=@Book_Count,
Price=@Price,
Discount_Price=@Discount_Price,
Description=@Description,
Rating=@Rating,
Rating_Count=@Rating_Count,
Book_Image=@Book_Image where BookId=@BookId
go
