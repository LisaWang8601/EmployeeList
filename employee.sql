USE [Apr02ThinkLP]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 2019-04-07 8:54:53 AM ******/
DROP TABLE [dbo].[Employee]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 2019-04-07 8:54:53 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[deptId] [int] NOT NULL,
	[empName] [nvarchar](50) NOT NULL,
	[position] [nvarchar](30) NOT NULL,
	[hireDate] [datetime] NOT NULL,
	[terminationDate] [datetime] NULL,
 CONSTRAINT [pk_Employees] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


