Create  alter Procedure spAddFeedBack
(
 @Rating varchar(100),
@Comment varchar(max),
@UserId bigint,
@BookId bigint)
as 
begin try
   insert into FeedbackTable (Rating,Comment,UserId,BookId) Values (@Rating,@Comment,@UserId,@BookId)
end try
begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch
