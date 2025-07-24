-- Stored Procedures for [User] Table

-- Insert
/*
EXEC PR_User_Insert @UserName = 'Yash3',
                    @Password = 'password12345',
                    @Email = 'abcde@google.com',
                    @MobileNo = '1234567890',
                    @IsActive = 0;
*/
CREATE OR ALTER PROC PR_User_Insert
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @MobileNo NVARCHAR(100),
    @IsActive BIT
AS
BEGIN
    INSERT INTO [User]
        (UserName, Password, Email, MobileNo, IsActive, Modified)
    VALUES
        (@UserName, @Password, @Email, @MobileNo, @IsActive, GETDATE());
END

-- Update
/*
EXEC PR_User_Update @UserID = 2,
                    @UserName = 'Yash',
                    @Password = 'newpassword123',
                    @Email = 'abc@google.com',
                    @MobileNo = '0987654321',
                    @IsActive = 1;
*/
CREATE OR ALTER PROC PR_User_Update
    @UserID INT,
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @MobileNo NVARCHAR(100),
    @IsActive BIT
AS
BEGIN
    UPDATE [User]
    SET UserName = @UserName,
        Password = @Password,
        Email = @Email,
        MobileNo = @MobileNo,
        Modified = GETDATE(),
        IsActive = @IsActive
    WHERE UserID = @UserID;
END

-- Delete
-- EXEC PR_User_Delete @UserID = 2;
CREATE OR ALTER PROC PR_User_Delete
    @UserID INT
AS
BEGIN
    DELETE FROM [User] WHERE UserID = @UserID;
END

-- Select All
-- EXEC PR_User_SelectAll;
CREATE OR ALTER PROC PR_User_SelectAll
AS
BEGIN
    SELECT U.UserID, U.UserName, U.Password, U.Email, U.MobileNo, U.IsActive, U.Created, U.Modified
    FROM [User] AS U;
END

-- Select By ID
-- EXEC PR_User_SelectByID @UserID = 2;
CREATE OR ALTER PROC PR_User_SelectByID
    @UserID INT
AS
BEGIN
    SELECT U.UserID, U.UserName, U.Password, U.Email, U.MobileNo, U.IsActive, U.Created, U.Modified
    FROM [User] AS U
    WHERE UserID = @UserID;
END

-- Stored Procedures for Department Table

-- Insert
/*
EXEC PR_Department_Insert @DepartmentName = 'abc',
                          @Description = 'asd',
                          @IsActive = 1,
                          @UserID = 2;
*/
CREATE OR ALTER PROC PR_Department_Insert
    @DepartmentName NVARCHAR(100),
    @Description NVARCHAR(250),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    INSERT INTO Department
        (DepartmentName, Description, IsActive, Created, Modified, UserID)
    VALUES
        (@DepartmentName, @Description, @IsActive, GETDATE(), GETDATE(), @UserID);
END

-- Update
/* EXEC PR_Department_Update @DepartmentID = 3,
                          @DepartmentName = 'xyz',
                          @Description = 'qwe',
                          @IsActive = 0,
                          @UserID = 2;
*/
CREATE OR ALTER PROC PR_Department_Update
    @DepartmentID INT,
    @DepartmentName NVARCHAR(100),
    @Description NVARCHAR(250),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    UPDATE Department
    SET DepartmentName = @DepartmentName,
        Description = @Description,
        IsActive = @IsActive,
        Modified = GETDATE(),
        UserID = @UserID
    WHERE DepartmentID = @DepartmentID;
END

-- Delete
-- EXEC PR_Department_Delete @DepartmentID = 3;
CREATE OR ALTER PROC PR_Department_Delete
    @DepartmentID INT
AS
BEGIN
    DELETE FROM Department WHERE DepartmentID = @DepartmentID;
END

-- Select All
-- EXEC PR_Department_SelectAll;
CREATE OR ALTER PROC PR_Department_SelectAll
AS
BEGIN
    SELECT D.DepartmentID, D.DepartmentName, D.Description, D.IsActive, D.Created, D.Modified, U.UserName, U.Email, U.MobileNo
    FROM Department AS D JOIN [User] AS U
        ON D.UserID = U.UserID;
END

-- Select By ID
-- EXEC PR_Department_SelectByID @DepartmentID = 3;
CREATE OR ALTER PROC PR_Department_SelectByID
    @DepartmentID INT
AS
BEGIN
    SELECT D.DepartmentID, D.DepartmentName, D.Description, D.IsActive, D.Created, D.Modified, U.UserID, U.UserName, U.Email, U.MobileNo
    FROM Department AS D JOIN [User] AS U
        ON D.UserID = U.UserID
    WHERE DepartmentID = @DepartmentID;
END

-- Stored Procedures for Doctor Table

-- Insert
/*
EXEC PR_Doctor_Insert @DoctorName = 'abc',
                      @Phone = '1234567890',
                      @Email = 'abc@google.com',
                      @Qualification = 'zxc',
                      @Specialization = 'asdf',
                      @IsActive = 1,
                      @UserID = 2;
*/
CREATE OR ALTER PROC PR_Doctor_Insert
    @DoctorName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Qualification NVARCHAR(100),
    @Specialization NVARCHAR(100),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    INSERT INTO Doctor
        (DoctorName, Phone, Email, Qualification, Specialization, IsActive, Created, Modified, UserID)
    VALUES
        (@DoctorName, @Phone, @Email, @Qualification, @Specialization, @IsActive, GETDATE(), GETDATE(), @UserID);
END

-- Update
/*
EXEC PR_Doctor_Update @DoctorID = 1,
                      @DoctorName = 'xyz',
                      @Phone = '0987654321',
                      @Email = 'abc@google.com',
                      @Qualification = 'zxc',
                      @Specialization = 'asdf',
                      @IsActive = 1,
                      @UserID = 2;
*/
CREATE OR ALTER PROC PR_Doctor_Update
    @DoctorID INT,
    @DoctorName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Qualification NVARCHAR(100),
    @Specialization NVARCHAR(100),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    UPDATE Doctor
    SET DoctorName = @DoctorName,
        Phone = @Phone,
        Email = @Email,
        Qualification = @Qualification,
        Specialization = @Specialization,
        IsActive = @IsActive,
        Modified = GETDATE(),
        UserID = @UserID
    WHERE DoctorID = @DoctorID;
END

-- Delete
-- EXEC PR_Doctor_Delete @DoctorID = 1;
CREATE OR ALTER PROC PR_Doctor_Delete
    @DoctorID INT
AS
BEGIN
    DELETE FROM Doctor WHERE DoctorID = @DoctorID;
END

-- Select All
-- EXEC PR_Doctor_SelectAll;
CREATE OR ALTER PROC PR_Doctor_SelectAll
AS
BEGIN
    SELECT D.DoctorID, D.DoctorName, D.Phone, D.Email, D.Qualification, D.Specialization, D.IsActive, D.Created, D.Modified, U.UserName, U.Email, U.MobileNo
    FROM Doctor AS D JOIN [User] AS U
        ON D.UserID = U.UserID;
END

-- Select By ID
-- EXEC PR_Doctor_SelectByID @DoctorID = 1;
CREATE OR ALTER PROC PR_Doctor_SelectByID
    @DoctorID INT
AS
BEGIN
    SELECT D.DoctorID, D.DoctorName, D.Phone, D.Email, D.Qualification, D.Specialization, D.IsActive, D.Created, D.Modified, U.UserName, U.Email, U.MobileNo, U.UserID
    FROM Doctor AS D JOIN [User] AS U
        ON D.UserID = U.UserID
    WHERE DoctorID = @DoctorID;
END

-- Stored Procedures for DoctorDepartment Table

-- Insert
/*
EXEC PR_DoctorDepartment_Insert @DoctorID = 1,
                                 @DepartmentID = 3,
                                 @UserID = 2;
*/
CREATE OR ALTER PROC PR_DoctorDepartment_Insert
    @DoctorID INT,
    @DepartmentID INT,
    @UserID INT
AS
BEGIN
    INSERT INTO DoctorDepartment
        (DoctorID, DepartmentID, Created, Modified, UserID)
    VALUES
        (@DoctorID, @DepartmentID, GETDATE(), GETDATE(), @UserID);
END

-- Update
/*
EXEC PR_DoctorDepartment_Update @DoctorDepartmentID = 1,
                                 @DoctorID = 1,
                                 @DepartmentID = 3,
                                 @UserID = 2;
*/
CREATE OR ALTER PROC PR_DoctorDepartment_Update
    @DoctorDepartmentID INT,
    @DoctorID INT,
    @DepartmentID INT,
    @UserID INT
AS
BEGIN
    UPDATE DoctorDepartment
    SET DoctorID = @DoctorID,
        DepartmentID = @DepartmentID,
        Modified = GETDATE(),
        UserID = @UserID
    WHERE DoctorDepartmentID = @DoctorDepartmentID;
END

-- Delete
-- EXEC PR_DoctorDepartment_Delete @DoctorDepartmentID = 1;
CREATE OR ALTER PROC PR_DoctorDepartment_Delete
    @DoctorDepartmentID INT
AS
BEGIN
    DELETE FROM DoctorDepartment WHERE DoctorDepartmentID = @DoctorDepartmentID;
END

-- Select All
-- EXEC PR_DoctorDepartment_SelectAll;
CREATE OR ALTER PROC PR_DoctorDepartment_SelectAll
AS
BEGIN
    SELECT DD.DoctorDepartmentID, DD.DoctorID, DD.DepartmentID, DD.Created, DD.Modified,
        D.DoctorName AS DoctorName, Dept.DepartmentName AS DepartmentName, U.UserName AS UserName
    FROM DoctorDepartment AS DD JOIN Doctor AS D
        ON DD.DoctorID = D.DoctorID JOIN Department AS Dept
        ON DD.DepartmentID = Dept.DepartmentID JOIN [User] AS U
        ON DD.UserID = U.UserID;
END

-- Select By ID
-- EXEC PR_DoctorDepartment_SelectByID @DoctorDepartmentID = 1;
CREATE OR ALTER PROC PR_DoctorDepartment_SelectByID
    @DoctorDepartmentID INT
AS
BEGIN
    SELECT DD.DoctorDepartmentID, DD.DoctorID, DD.DepartmentID,DD.UserID, DD.Created, DD.Modified,
        D.DoctorName AS DoctorName, Dept.DepartmentName AS DepartmentName, U.UserName AS UserName
    FROM DoctorDepartment AS DD JOIN Doctor AS D
        ON DD.DoctorID = D.DoctorID JOIN Department AS Dept
        ON DD.DepartmentID = Dept.DepartmentID JOIN [User] AS U
        ON DD.UserID = U.UserID
    WHERE DoctorDepartmentID = @DoctorDepartmentID;
END

-- Stored Procedures for Patient Table

-- Insert
/*
EXEC PR_Patient_Insert @PatientName = 'Yash',
                       @Phone = '1234567890',
                       @Email = 'ab@google.com',
                       @Address = '123 Street',
                       @DateOfBirth = '1900-01-20',
                       @Gender = 'Male',
                       @City = 'Rajkot',
                       @State = 'Gujarat',
                       @IsActive = 1,
                       @UserID = 2;
*/
CREATE OR ALTER PROC PR_Patient_Insert
    @PatientName NVARCHAR(100),
    @Phone NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(250),
    @DateOfBirth DATETIME,
    @Gender NVARCHAR(10),
    @City NVARCHAR(100),
    @State NVARCHAR(100),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    INSERT INTO Patient
        (PatientName, Phone, Email, Address, DateOfBirth, Gender, City, State, IsActive, Created, Modified, UserID)
    VALUES
        (@PatientName, @Phone, @Email, @Address, @DateOfBirth, @Gender, @City, @State, @IsActive, GETDATE(), GETDATE(), @UserID);
END

-- Update
/*
EXEC PR_Patient_Update @PatientID = 1,
                       @PatientName = 'Yash',
                       @Phone = '0987654321',
                       @Email = 'yash@google.com',
                       @Address = '123 Street',
                       @DateOfBirth = '1900-01-20',
                       @Gender = 'Male',
                       @City = 'Rajkot',
                       @State = 'Gujarat',
                       @IsActive = 1,
                       @UserID = 2;
*/
CREATE OR ALTER PROC PR_Patient_Update
    @PatientID INT,
    @PatientName NVARCHAR(100),
    @Phone NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(250),
    @DateOfBirth DATETIME,
    @Gender NVARCHAR(10),
    @City NVARCHAR(100),
    @State NVARCHAR(100),
    @IsActive BIT,
    @UserID INT
AS
BEGIN
    UPDATE Patient
    SET PatientName = @PatientName,
        Phone = @Phone,
        Email = @Email,
        Address = @Address,
        DateOfBirth = @DateOfBirth,
        Gender = @Gender,
        City = @City,
        State= @State,
        IsActive = @IsActive,
        Modified = GETDATE(),
        UserID = @UserID
    WHERE PatientID = @PatientID;
END

-- Delete
-- EXEC PR_Patient_Delete @PatientID = 1;
CREATE OR ALTER PROC PR_Patient_Delete
    @PatientID INT
AS
BEGIN
    DELETE FROM Patient WHERE PatientID = @PatientID;
END

-- Select All
-- EXEC PR_Patient_SelectAll;
CREATE OR ALTER PROC PR_Patient_SelectAll
AS
BEGIN
    SELECT P.PatientID, P.PatientName, P.Phone, P.Email, P.Address, P.DateOfBirth, P.Gender, P.City, P.State, P.IsActive, P.Created, P.Modified,U.UserId, U.UserName, U.Email, U.MobileNo
    FROM Patient AS P JOIN [User] AS U
        ON P.UserID = U.UserID;
END

-- Select By ID
-- EXEC PR_Patient_SelectByID @PatientID = 1;
CREATE OR ALTER PROC PR_Patient_SelectByID
    @PatientID INT
AS
BEGIN
    SELECT P.PatientID, P.PatientName, P.Phone, P.Email, P.Address, P.DateOfBirth, P.Gender, P.City, P.State, P.IsActive, P.Created, P.Modified, U.UserID, U.UserName, U.Email, U.MobileNo
    FROM Patient AS P JOIN [User] AS U
        ON P.UserID = U.UserID
    WHERE PatientID = @PatientID;
END

-- Stored Procedures for Appointment Table

-- Insert
/*
EXEC PR_Appointment_Insert @DoctorID = 1,
                           @PatientID = 1,
                           @AppointmentDate = '2000-01-20',
                           @AppointmentStatus = 'done',
                           @Description = 'asd',
                           @SpecialRemarks = 'N/A',
                           @UserID = 2,
                           @TotalConsultedAmount = 100.00;
*/
CREATE OR ALTER PROC PR_Appointment_Insert
    @DoctorID INT,
    @PatientID INT,
    @AppointmentDate DATETIME,
    @AppointmentStatus NVARCHAR(20),
    @Description NVARCHAR(250),
    @SpecialRemarks NVARCHAR(100),
    @UserID INT,
    @TotalConsultedAmount DECIMAL(5,2) NULL
AS
BEGIN
    INSERT INTO Appointment
        (DoctorID, PatientID, AppointmentDate, AppointmentStatus, Description, SpecialRemarks, Created, Modified, UserID, TotalConsultedAmount)
    VALUES
        (@DoctorID, @PatientID, @AppointmentDate, @AppointmentStatus, @Description, @SpecialRemarks, GETDATE(), GETDATE(), @UserID, @TotalConsultedAmount);
END

-- Update
/*
EXEC PR_Appointment_Update @AppointmentID = 1,
                           @DoctorID = 1,
                           @PatientID = 1,
                           @AppointmentDate = '2000-01-21',
                           @AppointmentStatus = 'done',
                           @Description = 'asd',
                           @SpecialRemarks = 'N/A',
                           @UserID = 2,
                           @TotalConsultedAmount = 100.00;
*/
CREATE OR ALTER PROC PR_Appointment_Update
    @AppointmentID INT,
    @DoctorID INT,
    @PatientID INT,
    @AppointmentDate DATETIME,
    @AppointmentStatus NVARCHAR(20),
    @Description NVARCHAR(250),
    @SpecialRemarks NVARCHAR(100),
    @UserID INT,
    @TotalConsultedAmount DECIMAL(5,2) NULL
AS
BEGIN
    UPDATE Appointment
    SET DoctorID = @DoctorID,
        PatientID = @PatientID,
        AppointmentDate = @AppointmentDate,
        AppointmentStatus = @AppointmentStatus,
        Description = @Description,
        SpecialRemarks = @SpecialRemarks,
        Modified = GETDATE(),
        UserID = @UserID,
        TotalConsultedAmount = @TotalConsultedAmount
    WHERE AppointmentID = @AppointmentID;
END

-- Delete
-- EXEC PR_Appointment_Delete @AppointmentID = 1;
CREATE OR ALTER PROC PR_Appointment_Delete
    @AppointmentID INT
AS
BEGIN
    DELETE FROM Appointment WHERE AppointmentID = @AppointmentID;
END

-- Select All
-- EXEC PR_Appointment_SelectAll;
CREATE OR ALTER PROC PR_Appointment_SelectAll
AS
BEGIN
    SELECT A.AppointmentID, A.DoctorID, A.PatientID, A.AppointmentDate, A.AppointmentStatus, A.Description, A.SpecialRemarks, A.Created, A.Modified, A.UserID, A.TotalConsultedAmount,
        D.DoctorName AS DoctorName, P.PatientName AS PatientName, U.UserName AS UserName
    FROM Appointment AS A JOIN Doctor AS D
        ON A.DoctorID = D.DoctorID JOIN Patient AS P
        ON A.PatientID = P.PatientID JOIN [User] AS U
        ON A.UserID = U.UserID;
END

-- Select By ID
-- EXEC PR_Appointment_SelectByID @AppointmentID = 1;
CREATE OR ALTER PROC PR_Appointment_SelectByID
    @AppointmentID INT
AS
BEGIN
    SELECT A.AppointmentID, A.DoctorID, A.PatientID, A.AppointmentDate, A.AppointmentStatus, A.Description, A.SpecialRemarks, A.Created, A.Modified, A.UserID, A.TotalConsultedAmount,
        D.DoctorName AS DoctorName, P.PatientName AS PatientName, U.UserName AS UserName
    FROM Appointment AS A JOIN Doctor AS D
        ON A.DoctorID = D.DoctorID JOIN Patient AS P
        ON A.PatientID = P.PatientID JOIN [User] AS U
        ON A.UserID = U.UserID
    WHERE AppointmentID = @AppointmentID;
END