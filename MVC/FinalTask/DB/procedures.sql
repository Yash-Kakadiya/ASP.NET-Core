
CREATE OR ALTER PROCEDURE PR_Student_Insert
    @EnrollmentNo NVARCHAR(50),
    @Name NVARCHAR(100),
    @MobileNo NVARCHAR(20),
    @Address NVARCHAR(255),
    @Email NVARCHAR(255),
    @Gender NVARCHAR(10),
    @IsPlayingCricket BIT,
    @Password NVARCHAR(100),
    @TwelfthPercentage FLOAT,
    @LiveInRajkot BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Students (EnrollmentNo, [Name], MobileNo, [Address], Email, Gender, IsPlayingCricket, [Password], TwelfthPercentage, LiveInRajkot)
    VALUES (@EnrollmentNo, @Name, @MobileNo, @Address, @Email, @Gender, @IsPlayingCricket, @Password, @TwelfthPercentage, @LiveInRajkot);
END


CREATE OR ALTER PROCEDURE PR_Student_SelectAll
AS
BEGIN
    SELECT Id, EnrollmentNo, [Name], MobileNo, [Address], Email, Gender, IsPlayingCricket, Password, TwelfthPercentage, LiveInRajkot
    FROM dbo.Students;
END


CREATE OR ALTER PROCEDURE PR_Student_SelectByID
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, EnrollmentNo, [Name], MobileNo, [Address], Email, Gender, IsPlayingCricket, Password, TwelfthPercentage, LiveInRajkot
    FROM dbo.Students
    WHERE Id = @Id;
END


CREATE OR ALTER PROCEDURE PR_Student_Update
    @Id INT,
    @EnrollmentNo NVARCHAR(50),
    @Name NVARCHAR(100),
    @MobileNo NVARCHAR(20),
    @Address NVARCHAR(255),
    @Email NVARCHAR(255),
    @Gender NVARCHAR(10),
    @IsPlayingCricket BIT,
    @Password NVARCHAR(100),
    @TwelfthPercentage FLOAT,
    @LiveInRajkot BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Students
    SET
        EnrollmentNo = @EnrollmentNo,
        [Name] = @Name,
        MobileNo = @MobileNo,
        [Address] = @Address,
        Email = @Email,
        Gender = @Gender,
        IsPlayingCricket = @IsPlayingCricket,
        [Password] = @Password,
        TwelfthPercentage = @TwelfthPercentage,
        LiveInRajkot = @LiveInRajkot
    WHERE
        Id = @Id;
END


CREATE OR ALTER OR ALTER PROCEDURE PR_Student_Delete
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Students
    WHERE Id = @Id;
END
