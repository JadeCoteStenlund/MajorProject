USE [FWFCScheduler]
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PreviousWork]    Script Date: 2/2/2016 4:08:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreviousWork](
	[EmployeeID] [int] NOT NULL,
	[Holidays] [int] NOT NULL,
	[Weekends] [int] NOT NULL,
	[DaysOff] [int] NOT NULL,
	[TotalDaysWorked] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 2/2/2016 4:08:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Schedule](
	[EmployeeID] [int] NOT NULL,
	[Day] [date] NOT NULL,
	[ShiftType] [char](1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SpecialDates]    Script Date: 2/2/2016 4:08:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SpecialDates](
	[Date] [date] NOT NULL,
	[DateType] [char](1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UnavailableDays]    Script Date: 2/2/2016 4:08:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnavailableDays](
	[EmployeeID] [int] NOT NULL,
	[UnavailableDays] [date] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [FirstName], [LastName]) VALUES (1, N'Jordan', N'Crago')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName]) VALUES (2, N'Sasha', N'Dorval')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName]) VALUES (3, N'Nolan', N'Wood')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName]) VALUES (4, N'Patrick', N'Marcino')
INSERT [dbo].[Employee] ([ID], [FirstName], [LastName]) VALUES (5, N'Johnny', N'Otherguy')
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[PreviousWork] ([EmployeeID], [Holidays], [Weekends], [DaysOff], [TotalDaysWorked]) VALUES (1, 0, 0, 0, 0)
INSERT [dbo].[PreviousWork] ([EmployeeID], [Holidays], [Weekends], [DaysOff], [TotalDaysWorked]) VALUES (2, 0, 0, 0, 0)
INSERT [dbo].[PreviousWork] ([EmployeeID], [Holidays], [Weekends], [DaysOff], [TotalDaysWorked]) VALUES (3, 0, 0, 0, 0)
INSERT [dbo].[PreviousWork] ([EmployeeID], [Holidays], [Weekends], [DaysOff], [TotalDaysWorked]) VALUES (4, 0, 0, 0, 0)
INSERT [dbo].[PreviousWork] ([EmployeeID], [Holidays], [Weekends], [DaysOff], [TotalDaysWorked]) VALUES (5, 0, 0, 0, 0)
INSERT [dbo].[Schedule] ([EmployeeID], [Day], [ShiftType]) VALUES (1, CAST(N'2016-02-01' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [Day], [ShiftType]) VALUES (2, CAST(N'2016-02-24' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [Day], [ShiftType]) VALUES (3, CAST(N'2016-02-15' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [Day], [ShiftType]) VALUES (4, CAST(N'2016-02-03' AS Date), N'O')
INSERT [dbo].[Schedule] ([EmployeeID], [Day], [ShiftType]) VALUES (5, CAST(N'2016-02-13' AS Date), N'O')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-06' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-07' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-13' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-14' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-15' AS Date), N'H')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-20' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-21' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-27' AS Date), N'W')
INSERT [dbo].[SpecialDates] ([Date], [DateType]) VALUES (CAST(N'2016-02-28' AS Date), N'W')
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDays]) VALUES (2, CAST(N'2016-02-14' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDays]) VALUES (3, CAST(N'2016-02-13' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDays]) VALUES (4, CAST(N'2016-02-29' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDays]) VALUES (4, CAST(N'2016-02-13' AS Date))
INSERT [dbo].[UnavailableDays] ([EmployeeID], [UnavailableDays]) VALUES (5, CAST(N'2016-02-01' AS Date))
ALTER TABLE [dbo].[PreviousWork]  WITH CHECK ADD  CONSTRAINT [FK_TotalDaysOff_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[PreviousWork] CHECK CONSTRAINT [FK_TotalDaysOff_Employee]
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
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [CK_Schedule] CHECK  (([ShiftType]='O' OR [ShiftType]='A' OR [ShiftType]='B'))
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [CK_Schedule]
GO
ALTER TABLE [dbo].[SpecialDates]  WITH CHECK ADD  CONSTRAINT [CK_SpecialDates] CHECK  (([DateType]='H' OR [DateType]='W' OR [DateType]='B'))
GO
ALTER TABLE [dbo].[SpecialDates] CHECK CONSTRAINT [CK_SpecialDates]
GO
USE [master]
GO
ALTER DATABASE [FWFCScheduler] SET  READ_WRITE 
GO
