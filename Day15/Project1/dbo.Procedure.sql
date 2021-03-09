CREATE PROCEDURE [dbo].[Insert]
	@Id int,
	@EmpNo varchar(10),
	@EmpName varchar(10)
AS
	INSERT INTO Employee VALUES (@Id, @EmpNo, @EmpName)
RETURN 0
