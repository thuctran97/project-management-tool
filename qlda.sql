CREATE DATABASE QLDA2
GO
USE QLDA2
GO
CREATE TABLE [dbo].[UserLogin]
(
	[Id] [nvarchar](10) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	constraint pk_ul primary key(Id)
)
insert into UserLogin values('U001','abc','12345')
insert into UserLogin values('U002','trancongthuc','12345')
insert into UserLogin values('U003','sieunhangao','12345')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_account_login]
	@Account nvarchar(50),
	@Password nvarchar(20)
as
begin
	declare @count int
	declare @res bit
	select @count= count(*) from UserLogin where Account=@Account and Password=@Password
	if @count>0 set @res=1 
	else set @res=0
	select @res
end