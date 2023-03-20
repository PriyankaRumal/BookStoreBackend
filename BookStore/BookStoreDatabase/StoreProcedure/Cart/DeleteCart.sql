create procedure spDeleteCart
@CartId bigint
as
begin
delete from CartTable where CartId=@CartId
end