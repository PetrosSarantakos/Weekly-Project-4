USE [WeeklyProject4]
GO

/****** Object:  Table [dbo].[Workers]    Script Date: 5/11/2018 1:51:45 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Workers](
	[workerId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[dailyWorkingHours] [int] NOT NULL,
	[weeklySalary] [int] NOT NULL,
 CONSTRAINT [PK_Wokrers] PRIMARY KEY CLUSTERED 
(
	[workerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO