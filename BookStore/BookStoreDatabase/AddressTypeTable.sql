CREATE TABLE AddTypeTable
(
	TypeId bigint identity(1,1) primary key,
	Type varchar(200)
)
insert into AddTypeTable values('Home');
insert into AddTypeTable values('Office');
insert into AddTypeTable values('Other');
select *from AddTypeTable;