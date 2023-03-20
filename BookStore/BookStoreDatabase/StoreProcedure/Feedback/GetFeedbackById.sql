create or alter procedure spGetFeedbackById
@FeedbackId bigint
as
begin try
  select 
		FeedbackTable.FeedbackId,FeedbackTable.UserId,FeedbackTable.BookId,FeedbackTable.Comment,FeedbackTable.Rating,
		UserTable.FullName
		FROM UserTable
		inner join FeedbackTable
		on FeedbackTable.UserId=UserTable.UserId
		where FeedbackId=@FeedbackId
end try
begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch

 exec spGetFeedbackById 1