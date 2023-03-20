create procedure spAddToWishList
@UserId bigint,
@BookId bigint
as
begin try
   insert into WishListTable (UserId,BookId) Values (@UserId,@BookId);
end try
begin catch 
   select ERROR_MESSAGE() as ERROR
end catch
   
exec spAddToWishList 1,1;