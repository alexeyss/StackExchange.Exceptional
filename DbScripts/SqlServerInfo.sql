--set transaction isolation level read uncommitted

--select * from Exceptions


select * from Info

insert into Info(ApplicationName, MachineName, CreationDate, Message)
values (@ApplicationName, @MachineName, @CreationDate, @Message)

CREATE TABLE [dbo].[Info](
	[Id] [bigint] NOT NULL IDENTITY,
	[GUID] [uniqueidentifier] NOT NULL,
	[ApplicationName] [nvarchar](50) NOT NULL,
	[MachineName] [nvarchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NULL,
	[Message] [nvarchar](1000) NULL,
	[IsProtected] [bit] NOT NULL default(0),
	[ItemHash] [int] NULL,
	[DuplicateCount] [int] NOT NULL default(1),
 CONSTRAINT [PK_Info] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)

CREATE UNIQUE NONCLUSTERED INDEX [IX_Info_GUID_ApplicationName_DeletionDate_CreationDate] ON [dbo].[Info]
(
	[GUID] ASC,
	[ApplicationName] ASC,
	[DeletionDate] ASC,
	[CreationDate] DESC
)

CREATE NONCLUSTERED INDEX [IX_Info_ItemHash_ApplicationName_CreationDate_DeletionDate] ON [dbo].[Info] 
(
	[ItemHash] ASC,
	[ApplicationName] ASC,
	[CreationDate] DESC,
	[DeletionDate] ASC
);

CREATE NONCLUSTERED INDEX [IX_Info_ApplicationName_DeletionDate_CreationDate_Filtered] ON [dbo].[Info] 
(
	[ApplicationName] ASC,
	[DeletionDate] ASC,
	[CreationDate] DESC
)
WHERE DeletionDate Is Null;


/****** Script for SelectTopNRows command from SSMS  ******/
use [LoggingDB]