--CREATE DATABASE NewEasy100 
--USE NewEasy100

--CREATE TABLE Cart
--(
--  CourseID VARCHAR(20) NOT NULL,
--  EnrollmentDate DATE NOT NULL,
--  StudentID VARCHAR(20) NOT NULL,
--  CartID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (CartID)
--);

--CREATE TABLE [User]
--(
--  Password VARCHAR(20) NOT NULL,
--  Name VARCHAR(50) NOT NULL,
--  Email VARCHAR(50) NOT NULL,
--  UserID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID)
--);

--CREATE TABLE Teacher
--(
--  UserID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID),
--  FOREIGN KEY (UserID) REFERENCES [User](UserID),
--  UNIQUE (UserID)
--);

--CREATE TABLE Admin
--(
--  UserID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID),
--  FOREIGN KEY (UserID) REFERENCES [User](UserID),
--  UNIQUE (UserID)
--);

--CREATE TABLE Parent
--(
--  UserID VARCHAR(20) NOT NULL,
--  childID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID),
--  FOREIGN KEY (UserID) REFERENCES [User](UserID),
--  UNIQUE (UserID)
--);

--CREATE TABLE Course
--(
--  CourseName VARCHAR(50) NOT NULL,
--  Quiz INT NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  CourseDate DATE NOT NULL,
--  CartID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (CourseID),
--  FOREIGN KEY (CartID) REFERENCES Cart(CartID)
--);

--CREATE TABLE Student
--(
--  Score INT NOT NULL,
--  Age INT NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  UserID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID),
--  FOREIGN KEY (UserID) REFERENCES [User](UserID),
--  FOREIGN KEY (UserID) REFERENCES Parent(UserID),
--  UNIQUE (UserID)
--);

--CREATE TABLE Register
--(
--  UserID VARCHAR(20) NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID, CourseID),
--  FOREIGN KEY (UserID) REFERENCES Student(UserID),
--  FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
--);

--CREATE TABLE Teach
--(
--  UserID VARCHAR(20) NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (UserID, CourseID),
--  FOREIGN KEY (UserID) REFERENCES Teacher(UserID),
--  FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
--);

--CREATE TABLE Course_Assignment
--(
--  Assignment INT NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (Assignment, CourseID),
--  FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
--);

--CREATE TABLE Payment
--(
--  StudentID VARCHAR(20) NOT NULL,
--  Amount INT NOT NULL,
--  PaymentID VARCHAR(20) NOT NULL,
--  PaymentDate INT NOT NULL,
--  CourseID VARCHAR(20) NOT NULL,
--  UserID VARCHAR(20) NOT NULL,
--  PRIMARY KEY (PaymentID),
--  FOREIGN KEY (UserID) REFERENCES Student(UserID)
--);

USE NewEasy100

-- [User] table
INSERT INTO [User] ([Email], [Name], [Password], [UserID])
VALUES
    ('farah@gmail.com', 'Farah', 'pass1', 's-1'),
    ('dareen@gmail.com', 'Dareen', 'pass2', 's-2'),
    ('john.doe@gmail.com', 'John Doe', 'pass3', 'p-1'),
    ('mona@gmail.com', 'Mona', 'pass4', 'p-2'),
    ('ahmed.foda@gmail.com', 'Foda', 'pass5', 'a-1'),
    ('tasneem@gmail.com', 'Miss/Tasneem', 'pass6', 't-1'),
    ('nada@gmail.com', 'Miss/Nada', 'pass7', 't-2');

-- [Admin] [Teacher], [Parent] tables:
INSERT INTO [Admin]([UserID]) VALUES('a-1');

INSERT INTO [Teacher]([UserID]) VALUES('t-1');
INSERT INTO [Teacher]([UserID]) VALUES('t-2');

INSERT INTO [Parent]([UserID], [childID]) VALUES('p-1','s-1');
INSERT INTO [Parent]([UserID], [childID]) VALUES('p-2','s-2');

-- [Student] table:
INSERT INTO [Student] ([Score], Age, CourseID, [UserID]) VALUES(95, 5, 'Math101', 's-1');
INSERT INTO [Student] ([Score], Age, CourseID, [UserID]) VALUES(100, 4, 'Engl101', 's-2');

-- [Course] table:
INSERT INTO [Course] ([CourseName], [Quiz], [CourseID], [CourseDate], CartID)
VALUES 
    ('Math', 1, 'Math101', '2023-01-01', 'c-1'),
    ('Engl', 1, 'Engl101', '2023-01-01', 'c-2'),
    ('Shapes', 1, 'shapes101', '2023-01-01', 'c-3');

-- [Cart] table:
INSERT INTO [Cart]([CourseID], [EnrollmentDate], [StudentID], [CartID]) VALUES('Math101', '2023-01-01', 's-1', 'c-1');
INSERT INTO [Cart]([CourseID], [EnrollmentDate], [StudentID], [CartID]) VALUES('Engl101', '2023-01-01', 's-2', 'c-2');
INSERT INTO [Cart]([CourseID], [EnrollmentDate], [StudentID], [CartID]) VALUES('shapes101', '2023-01-01', 's-2', 'c-3');

-- [Course_Assignment] table:
INSERT INTO [Course_Assignment] (Assignment, CourseID) VALUES(1, 'Engl101');
INSERT INTO [Course_Assignment] (Assignment, CourseID) VALUES(1, 'Math101');
INSERT INTO [Course_Assignment] (Assignment, CourseID) VALUES(2, 'shapes101');

-- [Payment] table:
INSERT INTO [Payment]([StudentID], [Amount], [PaymentID], [PaymentDate], [CourseID], [UserID])
VALUES
    ('s-1', 100, 'pay-1', 20230101, 'Math101', 'p-1'),
    ('s-1', 300, 'pay-2', 20230102, 'Engl101', 'p-1'),
    ('s-2', 300, 'pay-3', 20230102, 'Engl101', 'p-2'),
    ('s-2', 100, 'pay-4', 20230102, 'Math101', 'p-2');

-- [Register] table:
INSERT INTO [Register]([UserID], [CourseID]) VALUES('s-1', 'Math101');
INSERT INTO [Register]([UserID], [CourseID]) VALUES('s-1', 'Engl101');
INSERT INTO [Register]([UserID], [CourseID]) VALUES('s-2', 'Math101');
INSERT INTO [Register]([UserID], [CourseID]) VALUES('s-2', 'Engl101');

-- [Teach] table:
INSERT INTO [Teach]([UserID], [CourseID]) VALUES('t-1', 'Engl101');
INSERT INTO [Teach]([UserID], [CourseID]) VALUES('t-2', 'Math101');

-----------------------------------------------
-- test queries (Kont basala7 7agat hena) :
SELECT
    Parent.UserID AS ParentID,
    Parent.childID AS ChildID,
    ParentUser.[Name] AS ParentName,
    ChildUser.[Name] AS ChildName
FROM
    Parent
INNER JOIN
    [User] AS ParentUser ON Parent.UserID = ParentUser.UserID
INNER JOIN
    [User] AS ChildUser ON Parent.childID = ChildUser.UserID;

SELECT *
FROM Student
WHERE UserID = 's-1' OR UserID = 's-2'

---- Drop the existing foreign key constraint if it exists
--IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_Student_User')
--BEGIN
--    ALTER TABLE [Student] DROP CONSTRAINT FK_Student_User;
--END;

---- Add a new foreign key constraint with a different name
--ALTER TABLE [Student]
--ADD CONSTRAINT FK_Student_User_New FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]);

--SELECT * FROM dbo.Student WHERE UserID IN ('s-1', 's-2');
--SELECT 
--    CONSTRAINT_NAME, 
--    TABLE_NAME, 
--    COLUMN_NAME
--FROM 
--    INFORMATION_SCHEMA.KEY_COLUMN_USAGE
--WHERE 
--    TABLE_NAME = 'Payment' AND COLUMN_NAME = 'UserID';

--ALTER TABLE [Payment] DROP CONSTRAINT FK_Payment_Student;

----------------------------------------------------------------
SELECT [Name], Password, Email
FROM [User] AS U, Student
Where U.UserId = Student.UserID
---------------------------------
ALTER TABLE [Student] DROP CONSTRAINT FK__Student__UserID__4BAC3F29;
ALTER TABLE [Student]
ADD CONSTRAINT FK_Student_User_New2 FOREIGN KEY ([UserID]) REFERENCES [User]([UserID]);
------------------------------------
ALTER TABLE [Course_Assignment] DROP CONSTRAINT FK__Course_As__Cours__5629CD9C;
ALTER TABLE [Course_Assignment]
ADD CONSTRAINT FK_Course_Assignment_Course_New2 FOREIGN KEY (CourseID) REFERENCES Course(CourseID);

ALTER TABLE [Payment] DROP CONSTRAINT FK__Payment__UserID__59063A47;
ALTER TABLE [Payment]
ADD CONSTRAINT FK_Payment_Student_New2 FOREIGN KEY (UserID) REFERENCES Student(UserID);

ALTER TABLE [Register] DROP CONSTRAINT FK__Register__UserID__4E88ABD4;
ALTER TABLE [Register]
ADD CONSTRAINT FK_Register_Student_New2 FOREIGN KEY (UserID) REFERENCES Student(UserID);

ALTER TABLE [Teach] DROP CONSTRAINT FK__Teach__CourseID__534D60F1;
ALTER TABLE [Teach]
ADD CONSTRAINT FK_Teach_Course_New2 FOREIGN KEY (CourseID) REFERENCES Course(CourseID);


-- Show the structure of the Student table
EXEC sp_columns 'Student';

-- Show the structure of the Payment table
EXEC sp_columns 'Payment';

-- Check existing values in the Student table
SELECT * FROM Student;
