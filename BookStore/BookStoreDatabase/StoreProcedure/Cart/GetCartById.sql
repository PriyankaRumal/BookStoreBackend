create procedure spGetAllCartById
@UserId bigint,
@CartId bigint
as
begin 
begin try
		if exists(select *from CartTable where UserId=@UserId)
		begin
		   select *from CartTable where (CartId=@CartId)
		end
		else
			THROW 51002, 'Not a Valid UserId', 1
 end try
  begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch
 end
 exec spGetAllCartById 1,1