USE [Multiple_choice_test_system]
GO
/****** Object:  Table [dbo].[TB_ANSWERS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ANSWERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](max) NULL,
	[Statuss] [bit] NULL,
	[JammingLevel] [float] NULL,
	[IdQuestion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_CANDIDATES]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CANDIDATES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_CODE_OF_EXAMS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CODE_OF_EXAMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[IdExam] [int] NULL,
	[IdPeotry] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_EXAMS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_EXAMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](max) NULL,
	[CreateAt] [nvarchar](50) NULL,
	[CreateBy] [int] NULL,
	[ApproveBy] [int] NULL,
	[TimeLimit] [nvarchar](50) NULL,
	[Reliability] [float] NULL,
	[LevelOfDificult] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_GROUP_QUESTIONS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_GROUP_QUESTIONS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Score] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_PEOTRY]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PEOTRY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamDate] [nvarchar](100) NULL,
	[StartTime] [nvarchar](50) NULL,
	[EndTime] [nvarchar](50) NULL,
	[Statuss] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_QUESTION_OF_EXAMS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_QUESTION_OF_EXAMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdExam] [int] NULL,
	[IdQuestion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_QUESTIONS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_QUESTIONS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descriptions] [nvarchar](max) NULL,
	[LevelOfDificult] [float] NULL,
	[Distinctiveness] [float] NULL,
	[ScoreBonus] [int] NULL,
	[IdType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_RESULT]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_RESULT](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalScore] [float] NULL,
	[IdCandidate] [int] NULL,
	[IdCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_TYPES]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TYPES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IdGroup] [int] NULL,
	[Descriptions] [nvarchar](max) NULL,
 CONSTRAINT [PK__TB_TYPES__3214EC077FE699E4] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TB_USERS]    Script Date: 4/22/2020 8:55:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Passwords] [nvarchar](max) NULL,
	[Descriptions] [nvarchar](max) NULL,
	[Statuss] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TB_ANSWERS] ON 

INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (2, N'Nam', 1, NULL, 1)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (3, N'Dog', 0, NULL, 1)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (4, N'Cat', 0, NULL, 1)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (5, N'Fat', 0, NULL, 1)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (6, N'Yes, I am', 0, NULL, 2)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (7, N'Yes, I do', 1, NULL, 2)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (8, N'No, I am', 0, NULL, 2)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (9, N'Ahihi', 1, NULL, 3)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (10, N'Ahuhu', 0, NULL, 3)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (11, N'That''s right', 1, NULL, 4)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (12, N'No, I don''t think so', 0, NULL, 4)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (13, N'Crazy', 0, NULL, 4)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (14, N'Haha', 0, NULL, 4)
INSERT [dbo].[TB_ANSWERS] ([Id], [Descriptions], [Statuss], [JammingLevel], [IdQuestion]) VALUES (15, N'I''m Angry', 0, NULL, 4)
SET IDENTITY_INSERT [dbo].[TB_ANSWERS] OFF
SET IDENTITY_INSERT [dbo].[TB_CANDIDATES] ON 

INSERT [dbo].[TB_CANDIDATES] ([Id], [Name], [DateOfBirth], [Phone], [Address], [Email], [Image]) VALUES (1, N'Phạm Hữu Ngọc', N'05/07/1998', N'123456', N'140 Lê trọng tấn', N'phamhuungoc@gmail.com', NULL)
INSERT [dbo].[TB_CANDIDATES] ([Id], [Name], [DateOfBirth], [Phone], [Address], [Email], [Image]) VALUES (2, N'Nguyễn Xuân Khang', N'29/02/1998', N'4321421', N'140 Lê trọng tấn', N'khangnguyen@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[TB_CANDIDATES] OFF
SET IDENTITY_INSERT [dbo].[TB_CODE_OF_EXAMS] ON 

INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (1, N'MD1', 1, 1)
INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (2, N'MD2', 1, 1)
INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (3, N'MD3', 1, 1)
SET IDENTITY_INSERT [dbo].[TB_CODE_OF_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_EXAMS] ON 

INSERT [dbo].[TB_EXAMS] ([Id], [Descriptions], [CreateAt], [CreateBy], [ApproveBy], [TimeLimit], [Reliability], [LevelOfDificult]) VALUES (1, N'Thi Hk2', N'19/04/2020', 1, 1, N'90', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TB_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_GROUP_QUESTIONS] ON 

INSERT [dbo].[TB_GROUP_QUESTIONS] ([Id], [Name], [Score]) VALUES (1, N'Listening', 2)
INSERT [dbo].[TB_GROUP_QUESTIONS] ([Id], [Name], [Score]) VALUES (2, N'Reading', 1)
SET IDENTITY_INSERT [dbo].[TB_GROUP_QUESTIONS] OFF
SET IDENTITY_INSERT [dbo].[TB_PEOTRY] ON 

INSERT [dbo].[TB_PEOTRY] ([Id], [ExamDate], [StartTime], [EndTime], [Statuss]) VALUES (1, N'20/04/2020', N'13:00', N'14:30', 0)
INSERT [dbo].[TB_PEOTRY] ([Id], [ExamDate], [StartTime], [EndTime], [Statuss]) VALUES (2, N'22/04/2020', N'14:00', N'15:30', 0)
SET IDENTITY_INSERT [dbo].[TB_PEOTRY] OFF
SET IDENTITY_INSERT [dbo].[TB_QUESTION_OF_EXAMS] ON 

INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (1, 1, 1)
INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (2, 1, 2)
INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (3, 1, 4)
SET IDENTITY_INSERT [dbo].[TB_QUESTION_OF_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_QUESTIONS] ON 

INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType]) VALUES (1, N'What''s your name ?', NULL, NULL, 1, NULL)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType]) VALUES (2, N'Do you like Gym ?', NULL, NULL, 0, 2)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType]) VALUES (3, N'Abc and Xyz', NULL, NULL, 0, 2)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType]) VALUES (4, N'Khang is a dog', NULL, NULL, 0, 1)
SET IDENTITY_INSERT [dbo].[TB_QUESTIONS] OFF
SET IDENTITY_INSERT [dbo].[TB_RESULT] ON 

INSERT [dbo].[TB_RESULT] ([Id], [TotalScore], [IdCandidate], [IdCode]) VALUES (1, NULL, 1, 1)
INSERT [dbo].[TB_RESULT] ([Id], [TotalScore], [IdCandidate], [IdCode]) VALUES (2, NULL, 2, 2)
SET IDENTITY_INSERT [dbo].[TB_RESULT] OFF
SET IDENTITY_INSERT [dbo].[TB_TYPES] ON 

INSERT [dbo].[TB_TYPES] ([Id], [Name], [IdGroup], [Descriptions]) VALUES (1, N'ListenPicture', NULL, N'Have a picture in listening test')
INSERT [dbo].[TB_TYPES] ([Id], [Name], [IdGroup], [Descriptions]) VALUES (2, N'ReadingParagraph', NULL, N'One Paragraph have many question')
SET IDENTITY_INSERT [dbo].[TB_TYPES] OFF
SET IDENTITY_INSERT [dbo].[TB_USERS] ON 

INSERT [dbo].[TB_USERS] ([Id], [Name], [Passwords], [Descriptions], [Statuss]) VALUES (1, N'PhamHuuNgoc', N'123', N'abc', 1)
SET IDENTITY_INSERT [dbo].[TB_USERS] OFF
ALTER TABLE [dbo].[TB_ANSWERS]  WITH CHECK ADD FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[TB_QUESTIONS] ([Id])
GO
ALTER TABLE [dbo].[TB_CODE_OF_EXAMS]  WITH CHECK ADD FOREIGN KEY([IdExam])
REFERENCES [dbo].[TB_EXAMS] ([Id])
GO
ALTER TABLE [dbo].[TB_CODE_OF_EXAMS]  WITH CHECK ADD FOREIGN KEY([IdPeotry])
REFERENCES [dbo].[TB_PEOTRY] ([Id])
GO
ALTER TABLE [dbo].[TB_EXAMS]  WITH CHECK ADD FOREIGN KEY([ApproveBy])
REFERENCES [dbo].[TB_USERS] ([Id])
GO
ALTER TABLE [dbo].[TB_EXAMS]  WITH CHECK ADD FOREIGN KEY([CreateBy])
REFERENCES [dbo].[TB_USERS] ([Id])
GO
ALTER TABLE [dbo].[TB_QUESTION_OF_EXAMS]  WITH CHECK ADD FOREIGN KEY([IdExam])
REFERENCES [dbo].[TB_EXAMS] ([Id])
GO
ALTER TABLE [dbo].[TB_QUESTION_OF_EXAMS]  WITH CHECK ADD FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[TB_QUESTIONS] ([Id])
GO
ALTER TABLE [dbo].[TB_QUESTIONS]  WITH CHECK ADD  CONSTRAINT [FK__TB_QUESTI__IdTyp__145C0A3F] FOREIGN KEY([IdType])
REFERENCES [dbo].[TB_TYPES] ([Id])
GO
ALTER TABLE [dbo].[TB_QUESTIONS] CHECK CONSTRAINT [FK__TB_QUESTI__IdTyp__145C0A3F]
GO
ALTER TABLE [dbo].[TB_RESULT]  WITH CHECK ADD FOREIGN KEY([IdCandidate])
REFERENCES [dbo].[TB_CANDIDATES] ([Id])
GO
ALTER TABLE [dbo].[TB_RESULT]  WITH CHECK ADD FOREIGN KEY([IdCode])
REFERENCES [dbo].[TB_CODE_OF_EXAMS] ([Id])
GO
ALTER TABLE [dbo].[TB_TYPES]  WITH CHECK ADD  CONSTRAINT [FK_TB_TYPES_TB_GROUP_QUESTIONS] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[TB_GROUP_QUESTIONS] ([Id])
GO
ALTER TABLE [dbo].[TB_TYPES] CHECK CONSTRAINT [FK_TB_TYPES_TB_GROUP_QUESTIONS]
GO
