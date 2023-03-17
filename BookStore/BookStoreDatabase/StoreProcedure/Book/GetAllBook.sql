create procedure spGetAllBook
as
select *from BookTable
go

exec spGetAllBook