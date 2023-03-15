create table AddressTable(
  AddressId bigint identity(1,1) primary key,
  Adress varchar(max),
  City varchar(50),
  State varchar(50),
   UserId bigint foreign key (UserId) references UserTable(UserId),
)

select *from AddressTable