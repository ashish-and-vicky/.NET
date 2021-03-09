CREATE PROCEDURE [dbo].[InsertEmployee]
	@EmpNo int,
	@EmpName varchar(50)
AS
	insert into Employee values (@EmpNo, @EmpName)
RETURN 0
