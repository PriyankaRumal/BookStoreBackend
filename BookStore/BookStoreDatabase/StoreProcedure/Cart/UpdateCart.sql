create procedure spUpdateCart
@CartId bigint,
@Book_Count bigint
as
begin
 Update CartTable set Book_Count=@Book_Count where CartId=@CartId
 end