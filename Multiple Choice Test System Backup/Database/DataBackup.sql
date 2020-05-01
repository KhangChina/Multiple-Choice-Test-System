Create DataBase MCTS
go
use MCTS
--Group nghe hoặc viết
create table TB_GROUP (
	Id int identity(1,1) primary key,
	Names nvarchar(50),
	Score int,
	Statuss NVARCHAR(50)
)
--Cấu trúc đề thi gồm 8 phần mõi phần thuộc 1 group
create table TB_PART (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	IdGroup int,
	Descriptions nvarchar(max),
	Statuss NVARCHAR(50),
	foreign key (IdGroup) references TB_GROUP (Id)
)
--Trong đề có nhiều loại câu
create table TB_TYPE_QUESTIONS
(
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Descriptions nvarchar(max),
	Statuss NVARCHAR(50)
)
--Mõi Câu hỏi chỉ nằm trong 1 phần
Create table QUESTIONS
(
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	LevelOfDificult float,
	Distinctiveness float,
	IdPart int,
	foreign key (IdPart) references TB_PART (Id)
)
CREATE TABLE TB_QUESTIONS_GROUP
(
	Id int identity(1,1) primary key,

)
--Mõi câu hỏi thuộc 1 loai : TB_TYPE_QUESTIONS --- QUESTIONS
CREATE TABLE TB_TYPE_QUESTIONS_QUESTIONS
(
	Id int identity(1,1) primary key,	
	Statuss NVARCHAR(50),
	DESCRIPTION NVARCHAR(max),
	IdQuestionGroup int,
)

-- mõi câu hỏi có nhiều đáp án
create table TB_ANSWERS (
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	Statuss bit,
	JammingLevel float,
	IdQuestion int,
	foreign key (IdQuestion) references TB_QUESTIONS (Id)
)
-- Câu hỏi của đề
create table TB_QUESTION_OF_EXAMS (
	Id int identity(1,1) primary key,
	IdExam int,
	IdQuestion int,
	foreign key (IdExam) references TB_EXAMS (Id),
	foreign key (IdQuestion) references TB_QUESTIONS (Id)
)
--Người dùng---------------------------------
create table TB_USERS (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Passwords nvarchar(max),
	Descriptions nvarchar(max),
	Statuss nvarchar(50)
)
----------------------------------------------------------------------------
-------------Đề thi---------------------------------------------------------
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
---------------------Bộ đề gồm câu hỏi và đề----------------------------
create table TB_QUESTION_OF_EXAMS (
	Id int identity(1,1) primary key,
	IdExam int,
	IdType_Question_Question int,
	foreign key (IdExam) references TB_EXAMS (Id),
	foreign key (IdTYPE_QUESTIONS_QUESTIONS) references TB_TYPE_QUESTIONS_QUESTIONS (Id)
)
--------------------Ca thi------------------------------------------------
create table TB_Session (
	Id int identity(1,1) primary key,
	ExamDate nvarchar(100),
	StartTime nvarchar(50),
	EndTime nvarchar(50),
	Statuss nvarchar(20)
)
--------------------------------------------------------------------------





-----------------------------------------------------------------------------------------------Data-----------------------------------------------------------------------------------------------
insert into TB_GROUP
values ('Listen','5'),
	   ('Reading,','5')
insert into TB_PART --(TB_TYPE)
values  ('Type 1',1,'Picture Description'),
		('Type 2',1,'You will hear a question or statement and three responses spoken in English. They will not be printed in your test book and will be spoken only one time. Select the best response to the question or statement and mark the letter (A), (B), or (C) on your answer sheet. '),
		('Type 3',1,'You will hear some conversations between two or more people. You will be asked to answer three questions about what the speakers say in each conversation. Select the best response to each question and mark the letter (A), (B), (C), or (D) on your answer sheet. The conversations will not be printed in your test book and will be spoken only one time. '),
		('Type 4',1,'You will hear some talks given by a single speaker. You will be asked to answer three questions about what the speaker says in each talk. Select the best response to each question and mark the letter (A), (B), (C), or (D) on your answer sheet. The talks will not be printed in your test book and will be spoken only one time.'),
		('Type 5',2,'A word or phrase is missing in each of the sentences below. Four answer choices are given below each sentence. Select the best answer to complete the sentence. Then mark the letter (A), (B), (C), or (D) on your answer sheet. '),
		('Type 6',2,'Read the texts that follow. A word, phrase, or sentence is missing in parts of each text. Four answer choices for each question are given below the text. Select the best answer to complete the text. Then mark the letter (A), (B), (C), or (D) on your answer sheet. '),
		('Type 7',2,'Read the texts that follow. A word, phrase, or sentence is missing in parts of each text. Four answer choices for each question are given below the text. Select the best answer to complete the text. Then mark the letter (A), (B), (C), or (D) on your answer sheet. '),
		('Type 8',2,'In this part you will read a selection of texts, such as magazine and newspaper articles, e-mails, and instant messages. Each text or set of texts is followed by several questions. Select the best answer for each question and mark the letter (A), (B), (C), or (D) on your answer sheet. ')
insert into TB_TYPE_QUESTION ()
values  ('Listen Full','7=>31'),
		('Listen Group','32=>61'),
		('listen Group Image','62=>67'),
		('Single Question','101=>130'),
		('Group Question','131 => 146')
		
