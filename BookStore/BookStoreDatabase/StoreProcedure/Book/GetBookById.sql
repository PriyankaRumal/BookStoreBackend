create procedure spGetBookById
@BookId bigint
as
select *from BookTable where BookId=@BookId
go

exec spGetBookById 1