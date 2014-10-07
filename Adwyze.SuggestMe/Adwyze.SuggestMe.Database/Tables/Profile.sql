CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
)