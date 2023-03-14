create procedure spCreateUser (
 @FullName varchar(100), 
 @Email_Id varchar(50), 
 @Password varchar(100),
  @Mobile_Number varchar(100)
  ) as
  begin
  Insert into UserTable (FullName,Email_Id,Password, Mobile_Number)         
    Values (@FullName,@Email_Id,@Password, @Mobile_Number) 
  end 

  exec spCreateUser @FullName='priyanka',@Email_Id='priyanka@gmail.com',@Password='123@123', @Mobile_Number='123456'




