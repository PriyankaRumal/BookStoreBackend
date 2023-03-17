create procedure spDeleteBook
@BookId bigint
as
delete from BookTable where BookId=@BookId
go