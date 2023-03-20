create  table FeedbackTable(
FeedbackId bigint identity(1,1) primary key,  Rating varchar(100), Comment varchar(max), 
UserId bigint foreign key (UserId) references UserTable(UserId),
BookId bigint foreign key (BookId) references BookTable(BookId)
)

alter table 
select *from FeedbackTable
drop  table FeedbackTable