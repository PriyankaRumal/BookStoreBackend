Create procedure spBookImage
@BookId bigint,
@Book_Image varchar(max)
as
begin
update BookTable set Book_Image=@Book_Image where BookId=@BookId
end