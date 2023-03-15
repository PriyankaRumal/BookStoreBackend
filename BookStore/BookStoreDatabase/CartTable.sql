create table CartTable(
 CartId bigint identity(1,1) primary key,
 Book_Count bigint default 1,
 UserId bigint foreign key (UserId) references UserTable(UserId),
 BookId bigint foreign key (BookId) references BookTable(BookId),
 )
 select *from CartTable