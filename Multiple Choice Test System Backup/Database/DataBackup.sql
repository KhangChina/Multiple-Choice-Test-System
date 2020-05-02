Create DataBase MCTS
go
use MCTS
go
--Group nghe hoặc viết
create table TB_GROUP (
	Id int identity(1,1) primary key,
	Names nvarchar(50),
	AudioName nvarchar(max),
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
-- 1 loại sẽ có nhiều nhóm câu hỏi
create table TB_GROUP_TYPE_QUESTIONS
(
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Descriptions nvarchar(max),
	Images nvarchar(max),
	Statuss NVARCHAR(50),
	IdTypeQuestion int,
	foreign key (IdTypeQuestion) references TB_TYPE_QUESTIONS (Id)
)
--Mõi Câu hỏi chỉ nằm trong 1 phần
Create table TB_QUESTIONS
(
	Id int identity(1,1) primary key,
	Descriptions nvarchar(max),
	LevelOfDificult float,
	Distinctiveness float,
	Images nvarchar(max),
	IdPart int,
	IdGroupTypeQuestions int,
	foreign key (IdPart) references TB_PART (Id),
	foreign key (IdGroupTypeQuestions) references TB_GROUP_TYPE_QUESTIONS (Id)
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
--Người dùng---------------------------------
create table TB_USERS (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	Passwords nvarchar(max),
	Descriptions nvarchar(max),
	Statuss nvarchar(50)
)

-------------Đề thi---------------------------------------------------------
create table TB_EXAMS (
	Id int identity(1,1) primary key,
	Name nvarchar(max),
	Descriptions nvarchar(max),
	CreateAt nvarchar(50),
	CreateBy int,
	ApproveBy int,
	TimeLimit nvarchar(50),
	Reliability float,
	LevelOfDificult float, 
	ExamDate nvarchar(100),
	StartTime nvarchar(50),
	EndTime nvarchar(50),
	Statuss nvarchar(20),
	foreign key (CreateBy) references TB_USERS (Id),
	foreign key (ApproveBy) references TB_USERS (Id)
)
------------------------------------------------------------------------
-- Câu hỏi của đề
create table TB_QUESTION_OF_EXAMS (
	Id int identity(1,1) primary key,
	IdExam int,
	IdQuestion int,
	foreign key (IdExam) references TB_EXAMS (Id),
	foreign key (IdQuestion) references TB_QUESTIONS (Id)
)
--------------------Ca thi------------------------------------------------
-- Một đề thi chia làm nhiều ca thi
create table TB_EXAM_CODES (
	Id int identity(1,1) primary key,
	Code nvarchar(50),
	IdExam int,
	foreign key (IdExam) references TB_EXAMS (Id)
)
-- Thí sinh
create table TB_CANDIDATES (
	Id int identity(1,1) primary key,
	Name nvarchar(50),
	DateOfBirth nvarchar(50),
	Phone nvarchar(20),
	Address nvarchar(max),
	Email nvarchar(max),
	Image nvarchar(max),
)
-- Một thí sinh có nhiều kết quả thi , 1 đề thi do nhiều thí sinh thi
create table TB_RESULT (
	Id int identity(1,1) primary key,
	TotalScore int,
	IdExamCode int,
	IdCandidate int,
	foreign key (IdExamCode) references TB_EXAM_CODES (Id),
	foreign key (IdCandidate) references TB_CANDIDATES (Id)
)
CREATE TABLE TB_PermissionGroup 
(
    Id int IDENTITY PRIMARY KEY,
    NAMES NVARCHAR(max),
    Code NVARCHAR,
    Statuss NVARCHAR(50)
)
CREATE TABLE TB_Permission
(
     Id int IDENTITY PRIMARY KEY,
     Names NVARCHAR(max),
     IdPermissionGroup int,
     Statuss NVARCHAR(50),
     FOREIGN KEY (IdPermissionGroup) REFERENCES TB_PermissionGroup (Id)
)
CREATE TABLE TB_Permission_Detail
(
    Id int IDENTITY PRIMARY KEY,
    Names NVARCHAR(50),
    IdPermission int,
    Statuss NVARCHAR(50),
    FOREIGN KEY (IdPermission) REFERENCES TB_Permission(Id),
)
CREATE TABLE TB_Roles
(
    Id int IDENTITY PRIMARY KEY,
    Names NVARCHAR(50)
)
CREATE TABLE TB_Roles_Detail
(
   Id int IDENTITY PRIMARY KEY,
   IdRoles int,
   IdPermissionDetail int,
   FOREIGN KEY (IdRoles) REFERENCES TB_Roles (Id),
   FOREIGN KEY (IdPermissionDetail) REFERENCES TB_Permission_Detail(Id)
)
Create TABLE TB_User_Role_Detail
(
    Id int IDENTITY PRIMARY KEY,
    IdUser int,
    IdRoles int,
    FOREIGN KEY (IdUser) REFERENCES TB_USERS,
    FOREIGN KEY(IdRoles) REFERENCES TB_Roles
)
create TABLE TB_USERS_Permission_Detail
(
    Id int IDENTITY PRIMARY KEY,
    IdUser int,
    IdPermissionDetail int,
    FOREIGN KEY (IdUser) REFERENCES TB_USERS,
    FOREIGN KEY(IdPermissionDetail) REFERENCES TB_Permission_Detail(Id)
)


-----------------------------------------------------------------------------------------------Data-----------------------------------------------------------------------------------------------
insert into TB_GROUP
values ('Listen','','Active'),
	   ('Reading,','','Active')
insert into TB_PART --(TB_TYPE)
values  ('Type 1',1,'Picture Description','Active'),
		('Type 2',1,'You will hear a question or statement and three responses spoken in English. They will not be printed in your test book and will be spoken only one time. Select the best response to the question or statement and mark the letter (A), (B), or (C) on your answer sheet. ','Active'),
		('Type 3',1,'You will hear some conversations between two or more people. You will be asked to answer three questions about what the speakers say in each conversation. Select the best response to each question and mark the letter (A), (B), (C), or (D) on your answer sheet. The conversations will not be printed in your test book and will be spoken only one time. ','Active'),
		('Type 4',1,'You will hear some talks given by a single speaker. You will be asked to answer three questions about what the speaker says in each talk. Select the best response to each question and mark the letter (A), (B), (C), or (D) on your answer sheet. The talks will not be printed in your test book and will be spoken only one time.','Active'),
		('Type 5',2,'A word or phrase is missing in each of the sentences below. Four answer choices are given below each sentence. Select the best answer to complete the sentence. Then mark the letter (A), (B), (C), or (D) on your answer sheet. ','Active'),
		('Type 6',2,'Read the texts that follow. A word, phrase, or sentence is missing in parts of each text. Four answer choices for each question are given below the text. Select the best answer to complete the text. Then mark the letter (A), (B), (C), or (D) on your answer sheet. ','Active'),
		('Type 7',2,'Read the texts that follow. A word, phrase, or sentence is missing in parts of each text. Four answer choices for each question are given below the text. Select the best answer to complete the text. Then mark the letter (A), (B), (C), or (D) on your answer sheet. ','Active'),
		('Type 8',2,'In this part you will read a selection of texts, such as magazine and newspaper articles, e-mails, and instant messages. Each text or set of texts is followed by several questions. Select the best answer for each question and mark the letter (A), (B), (C), or (D) on your answer sheet. ','Active')
insert into TB_TYPE_QUESTIONS
values  ('Listen Full','7=>31','Active'),
		('Listen Group','32=>61','Active'),
		('listen Group Image','62=>67','Active'),
		('Single Question','101=>130','Active'),
		('Group Question','131 => 146','Active')
insert into TB_GROUP_TYPE_QUESTIONS
values	('Group1_Part6','(3 September)-Five years ago, Brian Trang signed a five-year lease to open his restaurant, 
Trang''s Bistro, at 30 Luray Place. Mr. Trang admits that the first two years of operation were quite ----- r . "We offer spicy food from Vietnam''s central region," he explains. "We didn''t do well at first---- : the cuisine is based on unfamiliar herbs and hot flavors. It took a while to catch on with customers." But Mr. Trang was confident the food would gain in popularity, and he was correct. 
----- . Mr. Trang has just signed another five-year lease, and he is planning ------- the space . ----. next year.','','Active',5),
		('NoneGroup','','','Active',4),
		('Group2_Part7','','Application_Form.jpg','Active',5)
insert into TB_QUESTIONS
values	('At which event is the announcement being made? ','','','',4,2),
		('Who most likely is the speaker? ','','','',4,2),
		('','','','',6,1),
		('','','','',6,1),
		('Why did Ms. Constantini fill out the form?','','','',7,3),
		(' What instructions are included?','','','',7,3)
		
insert into TB_ANSWERS
values  ('A book fair ','true','',1),
		('A product launch ','false','',1),
		('A technology conference ','false','',1),
		('A charity fundraiser ','false','',1),
		('An investment banker ','false','',2),
		('A city official','false','',2),
		('A food scientist','true','',2),
		('A restaurant manager','false','',2),
		('Competitive','false','',3),
		('Potential','false','',3),
		('Challenging','true','',3),
		('Rewarding','false','',3),
		('Renovate','false','',4),
		('Being renovated','false','',4),
		('Renovates','true','',4),
		('To renovate','false','',4),
		('To authorize a charge to her credit card','false','',5),
		('To be assigned to a new company division','false','',5),
		('To request a document renewal','true','',5),
		('To report lost equipment','false','',5),
		('Where to send the form','false','',6),
		('How to complete the form','false','',6),
		('When to submit the application','true','',6),
		('What documentation to attach','false','',6)

insert into TB_USERS
values  ('ngocph','123','','Active'),
		('KhangNX','321','','Active')

insert into TB_EXAMS
values ('Toeic Tuần 3 tháng 7','','28/04/2020',1,2,'120','','','23/07/2020','13:00','15:00','ready'),
		('Toeic Tuần 4 tháng 8','','28/05/2020',1,2,'120','','','12/08/2020','13:00','15:00','ready')

insert into TB_QUESTION_OF_EXAMS
values	(1,1),
		(1,2),
		(1,3),
		(1,4),
		(1,5),
		(1,6)

insert into TB_CANDIDATES
values	('Pham Huu Ngoc', '05/05/1995', '0909090909', '140 Le Trong Tan', 'ngoc@example.com', 'avatar_ngocph.jpg'),
		('Nguyen Xuan Khang', '07/10/1995', '0808080808', '140 Phan Van Hon', 'khang@example.com', 'avatar_khangnx.jpg'),
		('Nguyen Van Lan', '15/05/1995', '09493456430', '30/12 Tan Ky Tan Quy', 'lan@example.com', 'avatar_lannv.jpg')

insert into TB_EXAM_CODES
values	('453',1),
		('324',1),
		('421',1)

insert into TB_RESULT
values	('',1,1),
		('',2,2),
		('',1,3)