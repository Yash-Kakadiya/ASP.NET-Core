-- Stored Procedures for [User] Table

-- Insert
-- EXEC PR_User_Insert @UserName = 'Yash',
--                     @Password = 'password123',
--                     @Email = 'abc@google.com'
--                     @MobileNo = '1234567890',
--                     @Modified = '2000-01-20',
--                     @IsActive = 0;
CREATE OR ALTER PROC PR_User_Insert
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @MobileNo NVARCHAR(100),
    @Modified DATETIME,
    @IsActive BIT
AS
BEGIN
    INSERT INTO [User]
        (UserName, Password, Email, MobileNo, IsActive, Modified)
    VALUES
        (@UserName, @Password, @Email, @MobileNo, @IsActive, @Modified);
END

-- Update
-- EXEC PR_User_Update @UserID = 1,
--                     @UserName = 'Yash',
--                     @Password = 'newpassword123',
--                     @Email = 'abc@google.com',
--                     @MobileNo = '0987654321',
--                     @Modified = '2000-01-20',
--                     @IsActive = 1;
CREATE OR ALTER PROC PR_User_Update
    @UserID INT,
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100),
    @Email NVARCHAR(100),
    @MobileNo NVARCHAR(100),
    @Modified DATETIME,
    @IsActive BIT
AS
BEGIN
    UPDATE [User]
    SET UserName = @UserName,
        Password = @Password,
        Email = @Email,
        MobileNo = @MobileNo,
        Modified = @Modified,
        IsActive = @IsActive
    WHERE UserID = @UserID;
END

-- Delete
-- EXEC PR_User_Delete @UserID = 1;
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
    SELECT U.UserName, U.Password, U.Email, U.MobileNo, U.IsActive, U.Created, U.Modified
    FROM [User];
END

-- Select By ID
-- EXEC PR_User_SelectByID @UserID = 1;
CREATE OR ALTER PROC PR_User_SelectByID
    @UserID INT
AS
BEGIN
    SELECT U.UserName, U.Password, U.Email, U.MobileNo, U.IsActive, U.Created, U.Modified
    FROM [User] AS U
    WHERE UserID = @UserID;
END

-- Stored Procedures for Department Table

-- Insert
-- EXEC PR_Department_Insert @DepartmentName = 'abc',
--                           @Description = 'asd',
--                           @IsActive = 1,
--                           @Created = '2000-01-20',
--                           @Modified = '2000-01-20',
--                           @UserID = 1;      
CREATE OR ALTER PROC PR_Department_Insert
    @DepartmentName NVARCHAR(100),
    @Description NVARCHAR(250),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    INSERT INTO Department
        (DepartmentName, Description, IsActive, @Created, Modified, UserID)
    VALUES
        (@DepartmentName, @Description, @IsActive, @Created, @Modified, @UserID);
END

-- Update
-- EXEC PR_Department_Update @DepartmentID = 1,
--                           @DepartmentName = 'xyz',
--                           @Description = 'qwe',
--                           @IsActive = 0,
--                           @Created = '2000-01-20',
--                           @Modified = '2000-01-20',
--                           @UserID = 1;
CREATE OR ALTER PROC PR_Department_Update
    @DepartmentID INT,
    @DepartmentName NVARCHAR(100),
    @Description NVARCHAR(250),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    UPDATE Department
    SET DepartmentName = @DepartmentName,
        Description = @Description,
        IsActive = @IsActive,
        Created = @Created,
        Modified = @Modified,
        UserID = @UserID
    WHERE DepartmentID = @DepartmentID;
END

-- Delete
-- EXEC PR_Department_Delete @DepartmentID = 1;
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
    SELECT D.DepartmentID, D.DepartmentName, D.Description, D.IsActive, D.Created, D.Modified
    FROM Department;
END

-- Select By ID
-- EXEC PR_Department_SelectByID @DepartmentID = 1;
CREATE OR ALTER PROC PR_Department_SelectByID
    @DepartmentID INT
AS
BEGIN
    SELECT D.DepartmentID, D.DepartmentName, D.Description, D.IsActive, D.Created, D.Modified
    FROM Department AS D
    WHERE DepartmentID = @DepartmentID;
END

-- Stored Procedures for Doctor Table

-- Insert
-- EXEC PR_Doctor_Insert @Name = 'abc',
--                       @Phone = '1234567890',
--                       @Email = 'abc@google.com',
--                       @Qualification = 'zxc',
--                       @Specialization = 'asdf',
--                       @IsActive = 1,
--                       @Created = '2000-01-20',
--                       @Modified = '2000-01-20',
--                       @UserID = 1;
CREATE OR ALTER PROC PR_Doctor_Insert
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Qualification NVARCHAR(100),
    @Specialization NVARCHAR(100),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    INSERT INTO Doctor
        (Name, Phone, Email, Qualification, Specialization, IsActive, Created, Modified, UserID)
    VALUES
        (@Name, @Phone, @Email, @Qualification, @Specialization, @IsActive, @Created, @Modified, @UserID);
END

-- Update
-- EXEC PR_Doctor_Update @DoctorID = 1,
--                       @Name = 'xyz',
--                       @Phone = '0987654321',
--                       @Email = 'abc@google.com',
--                       @Qualification = 'zxc',
--                       @Specialization = 'asdf',
--                       @IsActive = 1,
--                       @Created = '2000-01-20',
--                       @Modified = '2000-01-20',
--                       @UserID = 1;
CREATE OR ALTER PROC PR_Doctor_Update
    @DoctorID INT,
    @Name NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(100),
    @Qualification NVARCHAR(100),
    @Specialization NVARCHAR(100),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    UPDATE Doctor
    SET Name = @Name,
        Phone = @Phone,
        Email = @Email,
        Qualification = @Qualification,
        Specialization = @Specialization,
        IsActive = @IsActive,
        Created = @Created,
        Modified = @Modified,
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
    SELECT D.Name, D.Phone, D.Email, D.Qualification, D.Specialization, D.IsActive, D.Created, D.Modified
    FROM Doctor AS D;
END

-- Select By ID
-- EXEC PR_Doctor_SelectByID @DoctorID = 1;
CREATE OR ALTER PROC PR_Doctor_SelectByID
    @DoctorID INT
AS
BEGIN
    SELECT D.DoctorID, D.Name, D.Phone, D.Email, D.Qualification, D.Specialization, D.IsActive, D.Created, D.Modified
    FROM Doctor AS D
    WHERE DoctorID = @DoctorID;
END

-- Stored Procedures for DoctorDepartment Table

-- Insert
-- EXEC PR_DoctorDepartment_Insert @DoctorID = 1,
--                                  @DepartmentID = 1,
--                                  @Created = '2000-01-20',
--                                  @Modified = '2000-01-20',
--                                  @UserID = 1;
CREATE OR ALTER PROC PR_DoctorDepartment_Insert
    @DoctorID INT,
    @DepartmentID INT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    INSERT INTO DoctorDepartment
        (DoctorID, DepartmentID, Created, Modified, UserID)
    VALUES
        (@DoctorID, @DepartmentID, @Created, @Modified, @UserID);
END

-- Update
-- EXEC PR_DoctorDepartment_Update @DoctorDepartmentID = 1,
--                                  @DoctorID = 1,
--                                  @DepartmentID = 1,
--                                  @Created = '2000-01-20',
--                                  @Modified = '2000-01-21',
--                                  @UserID = 1;
CREATE OR ALTER PROC PR_DoctorDepartment_Update
    @DoctorDepartmentID INT,
    @DoctorID INT,
    @DepartmentID INT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    UPDATE DoctorDepartment
    SET DoctorID = @DoctorID,
        DepartmentID = @DepartmentID,
        Created = @Created,
        Modified = @Modified,
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
    SELECT DD.DoctorDepartmentID, DD.DoctorID, DD.DepartmentID, DD.Created, DD.Modified
    FROM DoctorDepartment AS DD
END

-- Select By ID
-- EXEC PR_DoctorDepartment_SelectByID @DoctorDepartmentID = 1;
CREATE OR ALTER PROC PR_DoctorDepartment_SelectByID
    @DoctorDepartmentID INT
AS
BEGIN
    SELECT DD.DoctorDepartmentID, DD.DoctorID, DD.DepartmentID, DD.Created, DD.Modified
    FROM DoctorDepartment AS DD
    WHERE DoctorDepartmentID = @DoctorDepartmentID;
END

-- Stored Procedures for Patient Table

-- Insert
-- EXEC PR_Patient_Insert @Name = 'Yash',
--                        @Phone = '1234567890',
--                        @Email = 'ab@google.com',
--                        @Address = '123 Street',
--                        @DateOfBirth = '1900-01-20',
--                        @Gender = 'Male',
--                        @City = 'Rajkot',
--                        @State = 'Gujarat',
--                        @IsActive = 1,
--                        @Created = '2000-01-20',
--                        @Modified = '2000-01-20',
--                        @UserID = 1;
CREATE OR ALTER PROC PR_Patient_Insert
    @Name NVARCHAR(100),
    @Phone NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(250),
    @DateOfBirth DATETIME,
    @Gender NVARCHAR(10),
    @City NVARCHAR(100),
    @State NVARCHAR(100),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    INSERT INTO Patient
        (Name, Phone, Email, Address, DateOfBirth, Gender, City, State, IsActive, Created, Modified, UserID)
    VALUES
        (@Name, @Phone, @Email, @Address, @DateOfBirth, @Gender, @City, @State, @IsActive, @Created, @Modified, @UserID);
END

-- Update
-- EXEC PR_Patient_Update @PatientID = 1,
--                        @Name = 'Yash',
--                        @Phone = '0987654321',
--                        @Email = 'yash@google.com',
--                        @Address = '123 Street',
--                        @DateOfBirth = '1900-01-20',
--                        @Gender = 'Male',
--                        @City = 'Rajkot',
--                        @State = 'Gujarat',
--                        @IsActive = 1,
--                        @Created = '2000-01-20',
--                        @Modified = '2000-01-20',
--                        @UserID = 1;
CREATE OR ALTER PROC PR_Patient_Update
    @PatientID INT,
    @Name NVARCHAR(100),
    @Phone NVARCHAR(100),
    @Email NVARCHAR(100),
    @Address NVARCHAR(250),
    @DateOfBirth DATETIME,
    @Gender NVARCHAR(10),
    @City NVARCHAR(100),
    @State NVARCHAR(100),
    @IsActive BIT,
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT
AS
BEGIN
    UPDATE Patient
    SET Name = @Name,
        Phone = @Phone,
        Email = @Email,
        Address = @Address,
        DateOfBirth = @DateOfBirth
        Gender = @Gender,
        City
    = @City,
        State= @State,
        IsActive = @IsActive,
        Created = @Created,
        Modified = @Modified,
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
    SELECT P.PatientID, P.Name, P.Phone, P.Email, P.Address, P.DateOfBirth, P.Gender, P.City, P.State, P.IsActive, P.Created, P.Modified
    FROM Patient AS P;
END

-- Select By ID
-- EXEC PR_Patient_SelectByID @PatientID = 1;
CREATE OR ALTER PROC PR_Patient_SelectByID
    @PatientID INT
AS
BEGIN
    SELECT P.PatientID, P.Name, P.Phone, P.Email, P.Address, P.DateOfBirth, P.Gender, P.City, P.State, P.IsActive, P.Created, P.Modified
    FROM Patient AS P;
    WHERE PatientID = @PatientID;
END

-- Stored Procedures for Appointment Table

-- Insert
-- EXEC PR_Appointment_Insert @DoctorID = 1,
--                            @PatientID = 1,
--                            @AppointmentDate = '2000-01-20',
--                            @AppointmentStatus = 'done',
--                            @Description = 'asd',
--                            @SpecialRemarks = 'N/A',
--                            @Created = '2000-01-20',
--                            @Modified = '2000-01-20',
--                            @UserID = 1,
--                            @TotalConsultedAmount = 100.00;
CREATE OR ALTER PROC PR_Appointment_Insert
    @DoctorID INT,
    @PatientID INT,
    @AppointmentDate DATETIME,
    @AppointmentStatus NVARCHAR(20),
    @Description NVARCHAR(250),
    @SpecialRemarks NVARCHAR(100),
    @Created DATETIME,
    @Modified DATETIME,
    @UserID INT,
    @TotalConsultedAmount DECIMAL(5,2) NULL
AS
BEGIN
    INSERT INTO Appointment
        (DoctorID, PatientID, AppointmentDate, AppointmentStatus, Description, SpecialRemarks, Created, Modified, UserID, TotalConsultedAmount)
    VALUES
        (@DoctorID, @PatientID, @AppointmentDate, @AppointmentStatus, @Description, @SpecialRemarks, @Created, @Modified, @UserID, @TotalConsultedAmount);
END

-- Update
-- EXEC PR_Appointment_Update @AppointmentID = 1,
--                            @DoctorID = 1,
--                            @PatientID = 1,
--                            @AppointmentDate = '2000-01-21',
--                            @AppointmentStatus = 'done',
--                            @Description = 'asd',
--                            @SpecialRemarks = 'N/A',
--                            @Created = '2000-01-20',
--                            @Modified = '2000-01-20',
--                            @UserID = 1,
--                            @TotalConsultedAmount = 100.00;
CREATE OR ALTER PROC PR_Appointment_Update
    @AppointmentID INT,
    @DoctorID INT,
    @PatientID INT,
    @AppointmentDate DATETIME,
    @AppointmentStatus NVARCHAR(20),
    @Description NVARCHAR(250),
    @SpecialRemarks NVARCHAR(100),
    @Created DATETIME,
    @Modified DATETIME,
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
        Created = @Created,
        Modified = @Modified,
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
    SELECT A.AppointmentID, A.DoctorID, A.PatientID, A.AppointmentDate, A.AppointmentStatus, A.Description, A.SpecialRemarks, A.Created, A.Modified, A.UserID, A.TotalConsultedAmount
    FROM Appointment AS A;
END

-- Select By ID
-- EXEC PR_Appointment_SelectByID @AppointmentID = 1;
CREATE OR ALTER PROC PR_Appointment_SelectByID
    @AppointmentID INT
AS
BEGIN
    SELECT A.AppointmentID, A.DoctorID, A.PatientID, A.AppointmentDate, A.AppointmentStatus, A.Description, A.SpecialRemarks, A.Created, A.Modified, A.UserID, A.TotalConsultedAmount
    FROM Appointment AS A;
    WHERE AppointmentID = @AppointmentID;
END