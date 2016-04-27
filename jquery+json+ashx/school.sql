if exists (select * from sysobjects where id = OBJECT_ID('[Admin]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Admin]

CREATE TABLE [Admin] (
[adminID] [int]  IDENTITY (1, 1)  NOT NULL,
[LoginID] [varchar]  (20) NULL,
[LoginPWD] [varchar]  (20) NULL,
[AdminName] [varchar]  (20) NULL,
[sex] [bit]  NULL,
[creatDate] [datetime] NULL)

SET IDENTITY_INSERT [Admin] ON

INSERT [Admin] ([adminID],[LoginID],[LoginPWD],[AdminName],[sex]) VALUES ( 1,N'admin',N'admin',N'管理员甲',1)

SET IDENTITY_INSERT [Admin] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Class]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Class]

CREATE TABLE [Class] (
[classID] [int]  IDENTITY (1, 1)  NOT NULL,
[className] [varchar]  (20) NULL,
[gradeID] [int]  NULL)

SET IDENTITY_INSERT [Class] ON

INSERT [Class] ([classID],[className],[gradeID]) VALUES ( 1,N'14软件1',1)
INSERT [Class] ([classID],[className],[gradeID]) VALUES ( 2,N'15软件1',2)

SET IDENTITY_INSERT [Class] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[Grade]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Grade]

CREATE TABLE [Grade] (
[GradeID] [int]  IDENTITY (1, 1)  NOT NULL,
[GradeName] [varchar]  (20) NULL)

SET IDENTITY_INSERT [Grade] ON

INSERT [Grade] ([GradeID],[GradeName]) VALUES ( 1,N'2014')
INSERT [Grade] ([GradeID],[GradeName]) VALUES ( 2,N'2015')

SET IDENTITY_INSERT [Grade] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[student]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [student]

CREATE TABLE [student] (
[stuID] [int]  IDENTITY (1, 1)  NOT NULL,
[stuLoginName] [varchar]  (20) NULL,
[stuLoginPWD] [varchar]  (20) NULL,
[stuState] [bit]  NULL,
[stuRealName] [varchar]  (20) NULL,
[stuNo] [varchar]  (20) NULL,
[stuSex] [bit]  NULL,
[gradeID] [int]  NULL,
[classID] [int]  NULL)

SET IDENTITY_INSERT [student] ON

INSERT [student] ([stuID],[stuLoginName],[stuLoginPWD],[stuState],[stuRealName],[stuNo],[stuSex],[gradeID],[classID]) VALUES ( 1,N'test1',N'test1',1,N'张三',N'20140101',1,1,1)
INSERT [student] ([stuID],[stuLoginName],[stuLoginPWD],[stuState],[stuRealName],[stuNo],[stuSex],[gradeID],[classID]) VALUES ( 2,N'test2',N'test2',1,N'李四',N'20150101',0,2,2)

SET IDENTITY_INSERT [student] OFF
