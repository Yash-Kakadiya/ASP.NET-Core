-- CREATE DATABASE CRUDRevision

USE CRUDRevision

CREATE TABLE Department (
    DeptID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(100) NOT NULL
);

CREATE TABLE Employee (
    EmpID INT PRIMARY KEY IDENTITY(1,1),
    EmpName VARCHAR(100) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    JoiningDate DATETIME NOT NULL,
    City VARCHAR(100) NOT NULL,
    DeptID INT NOT NULL FOREIGN KEY REFERENCES Department(DeptID)
);

CREATE PROCEDURE PR_Department_SelectAll
AS
BEGIN
    SELECT DeptID, DepartmentName
    FROM Department;
END
GO

CREATE PROCEDURE PR_Department_SelectByPK
    @DeptID INT
AS
BEGIN
    SELECT DeptID, DepartmentName
    FROM Department
    WHERE DeptID = @DeptID;
END
GO

CREATE PROCEDURE PR_Department_Insert
    @DepartmentName VARCHAR(100)
AS
BEGIN
    INSERT INTO Department(DepartmentName)
    VALUES(@DepartmentName);
END
GO

CREATE PROCEDURE PR_Department_Update
    @DeptID INT,
    @DepartmentName VARCHAR(100)
AS
BEGIN
    UPDATE Department
    SET DepartmentName = @DepartmentName
    WHERE DeptID = @DeptID;
END
GO

CREATE PROCEDURE PR_Department_Delete
    @DeptID INT
AS
BEGIN
    DELETE FROM Department WHERE DeptID = @DeptID;
END
GO

CREATE PROCEDURE PR_Employee_SelectAll
AS
BEGIN
    SELECT 
        E.EmpID,
        E.EmpName,
        E.Salary,
        E.JoiningDate,
        E.City,
        E.DeptID,
        D.DepartmentName
    FROM Employee E
    LEFT JOIN Department D ON D.DeptID = E.DeptID;
END
GO

CREATE PROCEDURE PR_Employee_SelectByPK
    @EmpID INT
AS
BEGIN
    SELECT 
        EmpID,
        EmpName,
        Salary,
        JoiningDate,
        City,
        DeptID
    FROM Employee
    WHERE EmpID = @EmpID;
END
GO

CREATE PROCEDURE PR_Employee_Insert
    @EmpName VARCHAR(100),
    @Salary DECIMAL(10,2),
    @JoiningDate DATETIME,
    @City VARCHAR(100),
    @DeptID INT
AS
BEGIN
    INSERT INTO Employee (EmpName, Salary, JoiningDate, City, DeptID)
    VALUES (@EmpName, @Salary, @JoiningDate, @City, @DeptID);
END
GO

CREATE PROCEDURE PR_Employee_Update
    @EmpID INT,
    @EmpName VARCHAR(100),
    @Salary DECIMAL(10,2),
    @JoiningDate DATETIME,
    @City VARCHAR(100),
    @DeptID INT
AS
BEGIN
    UPDATE Employee
    SET 
        EmpName = @EmpName,
        Salary = @Salary,
        JoiningDate = @JoiningDate,
        City = @City,
        DeptID = @DeptID
    WHERE EmpID = @EmpID;
END
GO

CREATE PROCEDURE PR_Employee_Delete
    @EmpID INT
AS
BEGIN
    DELETE FROM Employee WHERE EmpID = @EmpID;
END
GO
