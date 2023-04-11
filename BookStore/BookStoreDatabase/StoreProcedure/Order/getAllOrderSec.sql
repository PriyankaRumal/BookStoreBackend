create or alter procedure spGetAllOrderSec
@UserId bigint
as
begin try
select OrderId,UserId,OrderDate,AddressId,TotalPrice,BookQuantity,b.BookId,b.Book_Name,b.Author_Name,b.Price, b.Discount_Price, b.Book_Image from OrderTable
c join BookTable b on c.BookId=b.BookId 
WHERE UserId=@UserId;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ERROR
END CATCH
Exec spGetAllOrderSec 1