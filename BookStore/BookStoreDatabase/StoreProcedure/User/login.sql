Create procedure spUserLogin
@Email_Id varchar(50), @Password varchar(100)
as
begin 
select * from UserTable where Email_Id=@Email_Id and Password=@Password
END

exec spUserLogin @Email_Id ='priya@123', @Password ='priya123'