USE [FWFCScheduler]
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Active] [char](1) NOT NULL CONSTRAINT [DF_Employee_Active]  DEFAULT ('Y'),
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreviousDaysOff]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreviousDaysOff](
	[EmployeeID] [int] NOT NULL,
	[DayOff] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule](
	[EmployeeID] [int] NOT NULL,
	[WorkDate] [date] NOT NULL,
	[ShiftType] [char](1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpecialDates]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpecialDates](
	[SpecialDate] [date] NOT NULL,
	[DateType] [char](1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnavailableDays]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnavailableDays](
	[EmployeeID] [int] NOT NULL,
	[UnavailableDay] [date] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Active]) VALUES (1, N'Jordan', N'Crago', N'Y')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Active]) VALUES (2, N'Sasha', N'Dorval', N'Y')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Active]) VALUES (3, N'Nolan', N'Wood', N'Y')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Active]) VALUES (4, N'Patrick', N'Marcino', N'Y')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName], [Active]) VALUES (5, N'Johnny', N'Otherguy', N'Y')
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-01' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-02' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-03' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (4, CAST(N'2016-02-04' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-05' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-06' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-07' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-08' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (4, CAST(N'2016-02-09' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-10' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-11' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-12' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-13' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-14' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (4, CAST(N'2016-02-15' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-16' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-17' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-18' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (4, CAST(N'2016-02-19' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-20' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-21' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-22' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-23' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (4, CAST(N'2016-02-24' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-25' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (1, CAST(N'2016-02-26' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (2, CAST(N'2016-02-27' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (3, CAST(N'2016-02-28' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [WorkDate], [ShiftType]) VALUES (5, CAST(N'2016-02-29' AS Date), N'O')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-06' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-07' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-13' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-14' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-15' AS Date), N'H')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-20' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-21' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-27' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([SpecialDate], [DateType]) VALUES (CAST(N'2016-02-28' AS Date), N'W')
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (2, CAST(N'2016-02-14' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (3, CAST(N'2016-02-13' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (4, CAST(N'2016-02-29' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (4, CAST(N'2016-02-13' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (5, CAST(N'2016-02-01' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (1, CAST(N'2016-02-14' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (2, CAST(N'2016-02-29' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDay]) VALUES (3, CAST(N'2016-02-19' AS Date))
ALTER TABLE [dbo].[PreviousDaysOff]  WITH CHECK ADD  CONSTRAINT [FK_PreviousDaysOff_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PreviousDaysOff] CHECK CONSTRAINT [FK_PreviousDaysOff_Employee]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Employee]
GO
ALTER TABLE [dbo].[UnavailableDays]  WITH CHECK ADD  CONSTRAINT [FK_UnavailableDays_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[UnavailableDays] CHECK CONSTRAINT [FK_UnavailableDays_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK_Employee] CHECK  (([Active]='Y' OR [Active]='N'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_Employee]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [CK_Schedule] CHECK  (([ShiftType]='O' OR [ShiftType]='A' OR [ShiftType]='B'))
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [CK_Schedule]
GO
ALTER TABLE [dbo].[SpecialDates]  WITH CHECK ADD  CONSTRAINT [CK_SpecialDates] CHECK  (([DateType]='H' OR [DateType]='W' OR [DateType]='B'))
GO
ALTER TABLE [dbo].[SpecialDates] CHECK CONSTRAINT [CK_SpecialDates]
GO
/****** Object:  StoredProcedure [dbo].[getHolidaysByYear]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getHolidaysByYear]
	-- Add the parameters for the stored procedure here
	@EmpID int,
	@Year int
	
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS numOfHolidays
	 FROM Schedule
	 WHERE EmployeeID = @EmpID 
	 AND YEAR(WorkDate) = @Year 
	 AND WorkDate IN
	 (
	  SELECT SpecialDate 
	  FROM SpecialDates 
	  WHERE DateType = 'H'
	 )
END


GO
/****** Object:  StoredProcedure [dbo].[getMaxEmployeeID]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getMaxEmployeeID]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 ID FROM Employee ORDER BY ID DESC
END

GO
/****** Object:  StoredProcedure [dbo].[getWeekendsByYear]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getWeekendsByYear]
	-- Add the parameters for the stored procedure here
	@EmpID int,
	@Year int
	
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS numOfWeekends
	 FROM Schedule
	 WHERE EmployeeID = @EmpID 
	 AND YEAR(WorkDate) = @Year 
	 AND WorkDate IN
	 (
	  SELECT SpecialDate 
	  FROM SpecialDates 
	  WHERE DateType = 'W'
	 )
END

GO
/****** Object:  StoredProcedure [dbo].[getWorkByYear]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getWorkByYear]
	-- Add the parameters for the stored procedure here
	@EmpID int,
	@Year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS numOfDays FROM dbo.Schedule WHERE EmployeeID = @EmpID AND YEAR(WorkDate) = @Year
END

GO
/****** Object:  StoredProcedure [dbo].[insertIntoSchedule]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertIntoSchedule] 
	-- Add the parameters for the stored procedure here
	@EmpID int,
	@Date date,
	@ShiftType char
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Schedule]
           ([EmployeeID]
           ,[WorkDate]
           ,[ShiftType])
     VALUES
           (@EmpID
           ,@Date
           ,@ShiftType)
END

GO
/****** Object:  StoredProcedure [dbo].[minDaysWorked]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[minDaysWorked] 
	-- Add the parameters for the stored procedure here
	@RowOffset int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS minDaysWorked
	  FROM Schedule
	  GROUP BY EmployeeID
	  ORDER BY COUNT(*) ASC
	  OFFSET @RowOffset ROWS 
	  FETCH NEXT 1 ROW ONLY; 
END


GO
/****** Object:  StoredProcedure [dbo].[minHolidaysWorked]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[minHolidaysWorked] 
	-- Add the parameters for the stored procedure here
	@RowOffset int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS minHolidaysWorked
	  FROM Schedule
	  WHERE WorkDate IN 
		(
		 SELECT SpecialDate 
		 FROM SpecialDates 
		 WHERE DateType = 'H'
		)
	  GROUP BY EmployeeID
	  ORDER BY COUNT(*) ASC
	  OFFSET @RowOffset ROWS 
	  FETCH NEXT 1 ROW ONLY; 
END


GO
/****** Object:  StoredProcedure [dbo].[minWeekendsWorked]    Script Date: 2/16/2016 4:12:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[minWeekendsWorked] 
	-- Add the parameters for the stored procedure here
	@RowOffset int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) AS minWeekendsWorked
	  FROM Schedule
	  WHERE WorkDate IN 
		(
		 SELECT SpecialDate 
		 FROM SpecialDates 
		 WHERE DateType = 'W'
		)
	  GROUP BY EmployeeID
	  ORDER BY COUNT(*) ASC
	  OFFSET @RowOffset ROWS 
	  FETCH NEXT 1 ROW ONLY; 
END

GO
USE [master]
GO
ALTER DATABASE [FWFCScheduler] SET  READ_WRITE 
GO
