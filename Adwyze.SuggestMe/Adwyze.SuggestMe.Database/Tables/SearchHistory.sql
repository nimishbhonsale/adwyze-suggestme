CREATE TABLE [dbo].[SearchHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [nvarchar](100) NULL,
	[UserId] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)
