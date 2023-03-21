create procedure spCancelOrder
@OrderId bigint
as
begin
     Declare @OrderCount bigint =(select BookQuantity from OrderTable where OrderId=@OrderId)
	 Declare @BookId bigint =(select BookId from OrderTable where OrderId=@OrderId )
		begin
			update CartTable set Book_Count= Book_Count + @OrderCount
			where BookId=@BookId
		end
		begin
			delete from OrderTable
			where OrderId=@OrderId
		end
end

exec spCancelOrder 2