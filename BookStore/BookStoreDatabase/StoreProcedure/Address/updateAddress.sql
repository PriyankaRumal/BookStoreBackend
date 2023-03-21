create procedure SpUpdateAddress
@AddressId int,
@Address varchar(Max),
@City varchar(100),
@State varchar(100)
as
begin try
    update AddressTable set Address=@Address,City = @City, State = @State
    where AddressId = @AddressId
end try
begin catch
  select ERROR_MESSAGE() AS ERROR
end catch