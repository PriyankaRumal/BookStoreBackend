Create alter procedure spAddToCart
@UserId bigint,
@BookId bigint,
@Book_Count bigint
as 
begin
if(EXISTS(select * from BookTable Where BookId=@BookId))
begin
		insert into CartTable(UserId,BookId,Book_Count)
		values (@UserId,@BookId,@Book_Count)
	end
	else
	begin 
		select 2
	end
set nocount on;
end