create table AddressTable(
    AddressId bigint identity(1,1) primary key,
	Address varchar(Max),
	City varchar(100),
	State varchar(100),
	TypeId bigint foreign key (TypeId) references AddTypeTable(TypeId),
	UserId bigint foreign key (UserId) references UserTable(UserId)
)

select *from AddressTable
drop table AddressTable