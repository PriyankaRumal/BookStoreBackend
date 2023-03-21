create procedure spAdOrder
@UserId bigint,
@AddressId bigint,
@BookId bigint,
@BookQuantity bigint
as 
  Declare @ToPrice int
begin
select @ToPrice=Discount_Price from BookTable where BookId=@BookId;
       if(exists (select * from BookTable where BookId=@BookId))
	   begin
			if(exists(select * from UserTable where UserId=@UserId))
			begin
			begin try
				begin transaction 
						insert into OrderTable(UserId,BookId,AddressId,TotalPrice,BookQuantity,OrderDate)
						values(@UserId,@BookId,@AddressId,@BookQuantity*@ToPrice,@BookQuantity,GETDATE());
						update BookTable set Book_Count=Book_Count-@BookQuantity
						delete from CartTable where BookId=@BookId and UserId=@UserId
						select * from OrderTable
				commit transaction
			end try
			begin catch 
				Rollback transaction
			end catch
			end
			else
			begin
					select 1
			end
	end
	else
	begin
	       select 2
	end
end

exec spAdOrder 1,2,1,10