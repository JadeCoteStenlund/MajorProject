USE [D735329123B1DB1E508F494E75B7F617_TS\FWFC ONCALL AFTER HOURS SCHEDULER\FWFC ONCALL AFTER HOURS SCHEDULER\DATA\DBFWFCSCHEDULER.MDF]
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
ALTER DATABASE [D735329123B1DB1E508F494E75B7F617_TS\FWFC ONCALL AFTER HOURS SCHEDULER\FWFC ONCALL AFTER HOURS SCHEDULER\DATA\DBFWFCSCHEDULER.MDF] SET  READ_WRITE 
GO
