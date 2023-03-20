create procedure spDeleteWishlist
@WishListId bigint,
@UserId bigint
as
begin try
    Delete from WishListTable where WishListId=@WishListId and UserId=@UserId;
end try
begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch