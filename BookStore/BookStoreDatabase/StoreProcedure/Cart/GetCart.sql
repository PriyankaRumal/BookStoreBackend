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
 