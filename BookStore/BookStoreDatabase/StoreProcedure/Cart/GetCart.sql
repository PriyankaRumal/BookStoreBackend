create or alter procedure spgetcart
@UserId bigint
as
begin
 begin try
		if exists(select *from CartTable where @UserId=@UserId)
		begin
		   select *from CartTable where (@UserId=@UserId)
		end
		else
			THROW 51002, 'Not a Valid UserId', 1
 end try
 begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch
 end

 exec spgetcart 3

 drop procedure getcart

 -------------GetAllCart-------------------

 create alter procedure spGetAllCart
 @UserId bigint
 as
 begin try
    select p.Book_Name,p.Author_Name,p.Price,p.Discount_Price,p.Book_Image,p.bookId,
	s.Book_Count,s.CartId,s.UserId
	from BookTable as p inner join CartTable as s on p.bookId=s.BookId
	where UserId=@UserId;
	set NOCOUNT on;
 end try
 begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch

 exec spGetAllCart 1