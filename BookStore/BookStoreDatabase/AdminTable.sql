create table AdminTable(
 AdminId bigint identity(1,1) primary key,
 AdminName varchar(50),
 Email varchar(50),
 Password varchar(20),
 PhoneNo bigint
)

select *from AdminTable

insert into AdminTable (AdminName,Email,Password,PhoneNo) values('Priyanka','Priyanka@gmail.com','priyanka@123','123456')