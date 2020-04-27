create database Multiple_Choice_test_system
go
use Multiple_Choice_test_system
go
create table TB_TYPES (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Descriptions nvarchar(max)
)

create table TB_GROUP_QUESTIONS (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Score int
)

create table TB_QUESTIONS (
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	LevelOfDificult float,
	Distinctiveness float,
	ScoreBonus int,
	IdType int,
	IdGroup int,
	foreign key (IdType) references TB_TYPES (Id),
	foreign key (IdGroup) references TB_GROUP_QUESTIONS (Id)
)

create table TB_ANSWERS (
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	Statuss bit,
	JammingLevel float,
	IdQuestion int,
	foreign key (IdQuestion) references TB_QUESTIONS (Id),
)
create table TB_USERS (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Passwords nvarchar(max),
	Descriptions nvarchar(max),
	Statuss bit,
)
create table TB_EXAMS (
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	CreateAt nvarchar(50),
	CreateBy int,
	ApproveBy int,
	TimeLimit nvarchar(50),
	Reliability float,
	LevelOfDificult float,
	foreign key (CreateBy) references TB_USERS (Id),
	foreign key (ApproveBy) references TB_USERS (Id)
)

create table TB_QUESTION_OF_EXAMS (
	Id int identity(1,1) primary key,
	IdExam int,
	IdQuestion int,
	foreign key (IdExam) references TB_EXAMS (Id),
	foreign key (IdQuestion) references TB_QUESTIONS (Id)
)

create table TB_PEOTRY (
	Id int identity(1,1) primary key,
	ExamDate nvarchar(100),
	StartTime nvarchar(50),
	EndTime nvarchar(50),
	Statuss bit
)

create table TB_CODE_OF_EXAMS (
	Id int identity(1,1) primary key,
	Code nvarchar(50),
	IdExam int,
	IdPeotry int,
	foreign key (IdExam) references TB_EXAMS (Id),
	foreign key (IdPeotry) references TB_Peotry (Id)
)

create table TB_ANSWER_OF_CODE_EXAMS (
	Id int identity(1,1) primary key,
	AnswerTrue nvarchar(max),
	AnswerJamming nvarchar(max),
	IdCode int,
	IdQuestionOfExam int,
	foreign key (IdCode) references TB_CODE_OF_EXAMS (Id),
	foreign key (IdQuestionOfExam) references TB_QUESTION_OF_EXAMS (Id)
)

create table TB_CANDIDATES (
	Id int identity(1,1) primary key,
	Name nvarchar(max),
	DateOfBirth nvarchar(max),
	Phone nvarchar(max),
	Address nvarchar(max),
	Email nvarchar(max),
	Image nvarchar(max),
)

create table TB_RESULT (
	Id int identity(1,1) primary key,
	TotalScore float,
	IdCandidate int,
	IdCode int,
	foreign key (IdCode) references TB_CODE_OF_EXAMS (Id),
	foreign key (IdCandidate) references TB_CANDIDATES (Id)
)

create table TB_DETAILS_RESULT (
	Id int identity(1,1) primary key,
	Status bit,
	AnswerOfCandidate nvarchar(max),
	Score float,
	IdAnswerOfCodeExam int,
	IdResult int,
	foreign key (IdResult) references TB_RESULT (Id),
	foreign key (IdAnswerOfCodeExam) references TB_ANSWER_OF_CODE_EXAMS (Id)
)