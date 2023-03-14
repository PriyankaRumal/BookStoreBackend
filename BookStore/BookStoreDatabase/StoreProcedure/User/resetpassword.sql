create procedure SpResetPassword
@Email_Id varchar(50),
@Password varchar(100)
as
begin
	Update UserTable Set Password=@Password where Email_Id=@Email_Id
end