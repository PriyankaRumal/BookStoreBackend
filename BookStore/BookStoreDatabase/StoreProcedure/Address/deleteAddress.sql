create procedure spDeleteAddress
(
	 @AddressId bigint 

)
as begin
	begin try
		if exists(select *from AddressTable where(AddressId= @AddressId))
		begin
			delete from  AddressTable where (AddressId= @AddressId)
		end
	end try
	begin catch
		select ERROR_MESSAGE() AS ERROR
	end catch
end