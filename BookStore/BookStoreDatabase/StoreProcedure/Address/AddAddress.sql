create procedure spAddAddress
@Address varchar(max),
@City varchar(100),
@State varchar(100),
@TypeId bigint,
@UserId bigint
as 
begin try
 insert into AddressTable(Address,City,State,TypeId,UserId) values(@Address,@City,@State,@TypeId,@UserId)
end try
begin catch 
   select ERROR_MESSAGE() as ERROR
 end catch