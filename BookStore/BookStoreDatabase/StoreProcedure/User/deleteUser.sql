
create procedure spdelete
@UserId bigint
 as 
 begin
 delete from UserTable 
 where UserId=@UserId
 end