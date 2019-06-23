IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Student]') AND type in (N'U'))
BEGIN
CREATE TABLE [Student](
	Id int IDENTITY(1,1),
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	FatherInitials nvarchar(10) NULL,
	DateOfBirth date,
	Email nvarchar(255),
	PhoneNumber nvarchar(255),
	[Address] nvarchar(255),
	RegistrationNumber nvarchar(255) NOT NULL,
	IsDeleted bit NOT NULL Default(0),
	CreatedDate datetime NOT NULL,
	UpdatedDate datetime,
	UserId int,
	NationalityId int,
	CitizenshipId int,

	CONSTRAINT PK_Student_Id PRIMARY KEY(Id),
	CONSTRAINT FK_Student_User FOREIGN KEY(UserId) REFERENCES [User](Id),
	CONSTRAINT FK_Student_Nationality FOREIGN KEY(NationalityId) REFERENCES Nationality(Id),
	CONSTRAINT FK_Student_Citizenship FOREIGN KEY(CitizenshipId) REFERENCES Citizenship(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [User](
	Id int IDENTITY(1,1),
	Username nvarchar(255),
	[Password] nvarchar(255),
	[Role] nvarchar(255),
	UserGuid nvarchar(255),
	CONSTRAINT PK_User_Id PRIMARY KEY(Id)
	)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Teacher]') AND type in (N'U'))
BEGIN
CREATE TABLE [Teacher](
	Id int IDENTITY(1,1),
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	DateOfBirth date,
	Email nvarchar(255),
	PhoneNumber nvarchar(255),
	IsDeleted bit NOT NULL Default(0),
	Office nvarchar(255),
	[Rank] nvarchar(255),
	WebAddress nvarchar(255),
	AreasOfInterest nvarchar(255),
	CreatedDate datetime NOT NULL,
	UpdatedDate datetime,

	CONSTRAINT PK_TeacherId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[CourseStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [CourseStatus](
	Id int IDENTITY(1,1),
	[Status] nvarchar(30) NOT NULL,
	Abbreviation nvarchar(10) NOT NULL,

	CONSTRAINT PK_CourseStatusId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
BEGIN
CREATE TABLE [Course](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,
	NumberOfCredits int NOT NULL check (NumberOfCredits > 0),
	StudyYear int NOT NULL check (StudyYear > 0),
	Semester int NOT NULL check (Semester > 0),
	StatusId int NOT NULL,

	CONSTRAINT PK_CourseId PRIMARY KEY(Id),
	CONSTRAINT FK_Course_CourseStatus FOREIGN KEY(StatusId) REFERENCES CourseStatus(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[EvaluationType]') AND type in (N'U'))
BEGIN
CREATE TABLE [EvaluationType](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,
	Abbreviation nvarchar(10),

	CONSTRAINT PK_EvaluationTypeId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Evaluation]') AND type in (N'U'))
BEGIN
CREATE TABLE [Evaluation](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,
	MaxScore decimal(18,5),
	CourseId int NOT NULL,
	TypeId int,

	CONSTRAINT PK_EvaluationId PRIMARY KEY(Id),
	CONSTRAINT FK_Evaluation_Course FOREIGN KEY(CourseId) REFERENCES Course(Id),
	CONSTRAINT FK_Evaluation_EvaluationType FOREIGN KEY(TypeId) REFERENCES EvaluationType(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Nationality]') AND type in (N'U'))
BEGIN
CREATE TABLE [Nationality](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,

	CONSTRAINT PK_NationalityId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Citizenship]') AND type in (N'U'))
BEGIN
CREATE TABLE [Citizenship](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,

	CONSTRAINT PK_CitizenshipId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Class]') AND type in (N'U'))
BEGIN
CREATE TABLE [Class](
	Id int IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,

	CONSTRAINT PK_ClassId PRIMARY KEY(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[StudentToClass]') AND type in (N'U'))
BEGIN
CREATE TABLE [StudentToClass](
	Id int IDENTITY(1,1),
	StudentId int NOT NULL,
	ClassId int NOT NULL,
	AcademicYear int NOT NULL check (AcademicYear > 0), --current academic year -> ex: 2019
	EnrollmentYear int NOT NULL check(EnrollmentYear > 0),
	StudyYear int NOT NULL check(StudyYear > 0), --current study year -> ex: 1, 2 or 3

	CONSTRAINT PK_StudentToClassId PRIMARY KEY(Id),
	CONSTRAINT FK_StudentToClass_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
	CONSTRAINT FK_StudentToClass_Class FOREIGN KEY(ClassId) REFERENCES Class(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[TeacherToCourse]') AND type in (N'U'))
BEGIN
CREATE TABLE [TeacherToCourse](
	Id int IDENTITY(1,1),
	TeacherId int NOT NULL,
	CourseId int NOT NULL,

	CONSTRAINT PK_TeacherToCourseId PRIMARY KEY(Id),
	CONSTRAINT FK_TeacherToCourse_Teacher FOREIGN KEY(TeacherId) REFERENCES Teacher(Id),
	CONSTRAINT FK_TeacherToCourse_Course FOREIGN KEY(CourseId) REFERENCES Course(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[Grade]') AND type in (N'U'))
BEGIN
CREATE TABLE [Grade](
	Id int IDENTITY(1,1),
	StudentId int NOT NULL,
	TeacherId int NOT NULL,
	EvaluationId int NOT NULL,
	Score decimal(18,5),
	GradeValue decimal(18, 5),
	EvalDate date,

	CONSTRAINT PK_GradeId PRIMARY KEY(Id),
	CONSTRAINT FK_Grade_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
	CONSTRAINT FK_Grade_Teacher FOREIGN KEY(TeacherId) REFERENCES Teacher(Id),
	CONSTRAINT FK_Grade_Evaluation FOREIGN KEY(EvaluationId) REFERENCES Evaluation(Id)
)
END


IF NOT EXISTS (SELECT * FROM sys.objects
Where object_id = OBJECT_ID(N'[dbo].[FinalGrade]') AND type in (N'U'))
BEGIN
CREATE TABLE [FinalGrade](
	Id int IDENTITY(1,1),
	StudentId int NOT NULL,
	CourseId int NOT NULL,
	AcademicYear int NOT NULL check (AcademicYear > 0), --current academic year -> ex: 2019
	Grade decimal(18, 5),
	[Date] date,

	CONSTRAINT PK_FinalGradeId PRIMARY KEY(Id),
	CONSTRAINT FK_FinalGrade_Student FOREIGN KEY(StudentId) REFERENCES Student(Id),
	CONSTRAINT FK_FinalGrade_Course FOREIGN KEY(CourseId) REFERENCES Course(Id)
)
END

