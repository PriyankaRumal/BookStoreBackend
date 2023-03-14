Create database BookStoreDB;


Create Table UserTable (
  UserId bigint IDENTITY(1,1) PRIMARY KEY ,
  FullName varchar(100), 
  Email_Id varchar(50), 
  Password varchar(100),
  Mobile_Number varchar(100)
  )

select *from UserTable

drop table UserTable


