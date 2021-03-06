USE [Multiple_choice_test_system]
GO
SET IDENTITY_INSERT [dbo].[TB_TYPES] ON 

INSERT [dbo].[TB_TYPES] ([Id], [Name], [Descriptions]) VALUES (1, N'ListenPicture', N'Have a picture in listening test')
INSERT [dbo].[TB_TYPES] ([Id], [Name], [Descriptions]) VALUES (2, N'ReadingParagraph', N'One Paragraph have many question')
SET IDENTITY_INSERT [dbo].[TB_TYPES] OFF
SET IDENTITY_INSERT [dbo].[TB_GROUP_QUESTIONS] ON 

INSERT [dbo].[TB_GROUP_QUESTIONS] ([Id], [Name], [Score]) VALUES (1, N'Listening', 2)
INSERT [dbo].[TB_GROUP_QUESTIONS] ([Id], [Name], [Score]) VALUES (2, N'Reading', 1)
SET IDENTITY_INSERT [dbo].[TB_GROUP_QUESTIONS] OFF
SET IDENTITY_INSERT [dbo].[TB_QUESTIONS] ON 

INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType], [IdGroup]) VALUES (1, N'What''s your name ?', NULL, NULL, 1, NULL, 2)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType], [IdGroup]) VALUES (2, N'Do you like Gym ?', NULL, NULL, 0, 2, 2)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType], [IdGroup]) VALUES (3, N'Abc and Xyz', NULL, NULL, 0, 2, 2)
INSERT [dbo].[TB_QUESTIONS] ([Id], [Descriptions], [LevelOfDificult], [Distinctiveness], [ScoreBonus], [IdType], [IdGroup]) VALUES (4, N'Khang is a dog', NULL, NULL, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[TB_QUESTIONS] OFF
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
SET IDENTITY_INSERT [dbo].[TB_USERS] ON 

INSERT [dbo].[TB_USERS] ([Id], [Name], [Passwords], [Descriptions], [Statuss]) VALUES (1, N'PhamHuuNgoc', N'123', N'abc', 1)
SET IDENTITY_INSERT [dbo].[TB_USERS] OFF
SET IDENTITY_INSERT [dbo].[TB_EXAMS] ON 

INSERT [dbo].[TB_EXAMS] ([Id], [Descriptions], [CreateAt], [CreateBy], [ApproveBy], [TimeLimit], [Reliability], [LevelOfDificult]) VALUES (1, N'Thi Hk2', N'19/04/2020', 1, 1, N'90', NULL, NULL)
SET IDENTITY_INSERT [dbo].[TB_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_QUESTION_OF_EXAMS] ON 

INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (1, 1, 1)
INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (2, 1, 2)
INSERT [dbo].[TB_QUESTION_OF_EXAMS] ([Id], [IdExam], [IdQuestion]) VALUES (3, 1, 4)
SET IDENTITY_INSERT [dbo].[TB_QUESTION_OF_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_PEOTRY] ON 

INSERT [dbo].[TB_PEOTRY] ([Id], [ExamDate], [StartTime], [EndTime], [Statuss]) VALUES (1, N'20/04/2020', N'13:00', N'14:30', 0)
INSERT [dbo].[TB_PEOTRY] ([Id], [ExamDate], [StartTime], [EndTime], [Statuss]) VALUES (2, N'22/04/2020', N'14:00', N'15:30', 0)
SET IDENTITY_INSERT [dbo].[TB_PEOTRY] OFF
SET IDENTITY_INSERT [dbo].[TB_CODE_OF_EXAMS] ON 

INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (1, N'MD1', 1, 1)
INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (2, N'MD2', 1, 1)
INSERT [dbo].[TB_CODE_OF_EXAMS] ([Id], [Code], [IdExam], [IdPeotry]) VALUES (3, N'MD3', 1, 1)
SET IDENTITY_INSERT [dbo].[TB_CODE_OF_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ON 

INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (1, N'Nam', N'Dog:Cat:Fat', 1, 1)
INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (2, N'Yes, I do', N'Yes, I am:No,I am', 1, 2)
INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (4, N'That''s right', N'No, I don''t think so:Crazy:Haha:I''m Angry', 1, 3)
INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (5, N'Nam', N'Fat:Dog:Cat', 2, 1)
INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (6, N'Yes, I do', N'No,I am:Yes, I am', 2, 2)
INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] ([Id], [AnswerTrue], [AnswerJamming], [IdCode], [IdQuestionOfExam]) VALUES (7, N'That''s right', N'I''m Angry:No, I don''t think so:Crazy:Haha', 2, 3)
SET IDENTITY_INSERT [dbo].[TB_ANSWER_OF_CODE_EXAMS] OFF
SET IDENTITY_INSERT [dbo].[TB_CANDIDATES] ON 

INSERT [dbo].[TB_CANDIDATES] ([Id], [Name], [DateOfBirth], [Phone], [Address], [Email], [Image]) VALUES (1, N'Phạm Hữu Ngọc', N'05/07/1998', N'123456', N'140 Lê trọng tấn', N'phamhuungoc@gmail.com', NULL)
INSERT [dbo].[TB_CANDIDATES] ([Id], [Name], [DateOfBirth], [Phone], [Address], [Email], [Image]) VALUES (2, N'Nguyễn Xuân Khang', N'29/02/1998', N'4321421', N'140 Lê trọng tấn', N'khangnguyen@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[TB_CANDIDATES] OFF
SET IDENTITY_INSERT [dbo].[TB_RESULT] ON 

INSERT [dbo].[TB_RESULT] ([Id], [TotalScore], [IdCandidate], [IdCode]) VALUES (1, NULL, 1, 1)
INSERT [dbo].[TB_RESULT] ([Id], [TotalScore], [IdCandidate], [IdCode]) VALUES (2, NULL, 2, 2)
SET IDENTITY_INSERT [dbo].[TB_RESULT] OFF
SET IDENTITY_INSERT [dbo].[TB_DETAILS_RESULT] ON 

INSERT [dbo].[TB_DETAILS_RESULT] ([Id], [Status], [AnswerOfCandidate], [Score], [IdAnswerOfCodeExam], [IdResult]) VALUES (1, 1, N'Nam', 1, 1, 1)
INSERT [dbo].[TB_DETAILS_RESULT] ([Id], [Status], [AnswerOfCandidate], [Score], [IdAnswerOfCodeExam], [IdResult]) VALUES (2, 0, N'Yes, I am', 0, 2, 1)
INSERT [dbo].[TB_DETAILS_RESULT] ([Id], [Status], [AnswerOfCandidate], [Score], [IdAnswerOfCodeExam], [IdResult]) VALUES (4, 0, N'I''m Angry', 0, 4, 1)
INSERT [dbo].[TB_DETAILS_RESULT] ([Id], [Status], [AnswerOfCandidate], [Score], [IdAnswerOfCodeExam], [IdResult]) VALUES (5, 0, N'Dog', 0, 5, 2)
INSERT [dbo].[TB_DETAILS_RESULT] ([Id], [Status], [AnswerOfCandidate], [Score], [IdAnswerOfCodeExam], [IdResult]) VALUES (6, 1, N'Yes, I do', 1, 6, 2)
SET IDENTITY_INSERT [dbo].[TB_DETAILS_RESULT] OFF
