create procedure spGetOrderDetails
as
begin
Select * from OrderTable
end

exec spGetOrderDetails