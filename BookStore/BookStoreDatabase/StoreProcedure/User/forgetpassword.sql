create procedure SpForgetPassword
@Email_Id varchar(50)
as
begin
	SELECT * from UserTable where Email_Id=@Email_Id
end