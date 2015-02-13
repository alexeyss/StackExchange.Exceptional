--set transaction isolation level read uncommitted

--select * from Exceptions


select * from Info

insert into Info(ApplicationName, MachineName, CreationDate, Message)
values (@ApplicationName, @MachineName, @CreationDate, @Message)

CREATE TABLE [dbo].[Info](
	[Id] [bigint] NOT NULL IDENTITY,
	[ApplicationName] [nvarchar](50) NOT NULL,
	[MachineName] [nvarchar](50) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[Message] [nvarchar](1000) NULL,
	
 CONSTRAINT [PK_Info] PRIMARY KEY CLUSTERED ([Id] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)

CREATE UNIQUE NONCLUSTERED INDEX [IX_Info_ApplicationName_CreationDate] ON [dbo].[Info] 
(
	[ApplicationName] ASC,
	[CreationDate] DESC
)