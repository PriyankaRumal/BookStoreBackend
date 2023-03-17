create procedure spAddBook(
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
as begin 
insert into BookTable values(@Book_Name,@Author_Name,@Book_Count,@Price,@Discount_Price,@Description,@Rating,@Rating_Count,@Book_Image)
end

exec spAddBook "C programming" ,"Balguruswami",50,3000,2000,"Its a very useful book","4.3",20,"abcede"