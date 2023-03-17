create procedure spAdminLogin(
@Email varchar(50),
@Password varchar(20)
)
as 
begin
select Email,Password from AdminTable where Email=@Email and Password=@Password
end