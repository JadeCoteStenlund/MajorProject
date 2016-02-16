'Import ProjectName.DataSetNameTableAdapters
Imports System.Data
Imports System.Data.SqlClient

'NolanWood
'FWFC Sheduler

' TO DO:
' Sql Commands can be replaced with Stored Procedures 
' Import table adapters for the dataset
' Replace the current Dataset with the updated one with store procedures from Jordan Crago
' Initialise TableAdapters for each Table in InitTableAdapters()
Module Module1

    Dim alreadyChecked As Boolean = False     'To flag a day as already checked
    Dim FWFCconnect As New SqlConnection
    Dim phDate As Date = #2/1/2016#     'inital date of the month  to be changed with a way to pull the current month
    Sub Main()
        'Connection string for Sql Commands
        FWFCconnect.ConnectionString = "Data Source=(localdb)\Projects;Initial Catalog=FWFCScheduler;Integrated Security=True"

        Dim inputID As Integer = 1   'Inital EmpID of 1
        Dim maxIDs As Integer = 6    'Placeholder Total EMPID
        Dim maxDays = 29             'Placeholder Total days of Month
        Dim startDay = 1             'start of every month is the 1st day

        Do While (startDay <= maxDays)   'Loops through the days of the month

            Do While (inputID <= maxIDs + 1)    'Loops through the empID's until all are checked
                CheckAvailability(inputID, phDate, startDay)
                inputID = inputID + 1
                Console.WriteLine("Inner Loop: " + CType(inputID, String) + " " + CType(alreadyChecked, String))
            Loop
            alreadyChecked = False  'Unflags the day being checked
            Console.WriteLine("Outer loop: " + CType(startDay, String))
            startDay = startDay + 1
            inputID = 1 'resets the inner loop to cycle to the next day to allow the entire list of EmpID's to be checked
            phDate = DateAdd(DateInterval.Day, 1, phDate) 'Adds 1 day to the inital date
        Loop


        Console.ReadKey()
    End Sub

    Public Sub CheckAvailability(empID As Integer, daytoCheck As Date, dayCount As Integer)

        Dim dataReader As SqlDataReader 'allows data to be read from the DB
        FWFCconnect.ConnectionString = "Data Source=(localdb)\Projects;Initial Catalog=FWFCScheduler;Integrated Security=True"
        FWFCconnect.Open()

        Dim shiftType As String = "O"   'placeholder shift type         A = After Hours, O = Oncall  B= Both
        Dim lowestDW As Integer     'lowest DaysWorked variable
        Dim lowestHoliday As Integer 'lowest HolidaysWorked variable
        Dim lowestWeekend As Integer 'lowest WeekendsWorked variable
        Dim returnedDate As String  'holds the returned date from the Datareader
        Dim returnedHoliday As Integer 'holds the returned total Holidays worked by an employee
        Dim returnedWeekend As Integer 'holds the returned total weekends worked by an employee
        Dim returnedDW As Integer   'holds the returned daysworked from the Datareader
        Dim canWork As Boolean      'holds the bool value if an employee can work
        Dim iterateDW As Boolean    'holds the bool value to see if the DaysWorked(lowestDW) was iterated to the next highest value
        Dim iterateHoliday As Boolean   'holds the bool value to see if the Holidays(lowestHoliday) worked was iterated to the next highest value
        Dim iterateWeekend As Boolean   'holds the bool value to see if the Weekends(lowestWeekend) worked was iterated to the next highest value

        'finds the Unavailable days for the current EmpID
        Dim foundDate
        Try
            Dim sqlCmdDate As New SqlCommand()
            sqlCmdDate.Connection = FWFCconnect                                                                         '\/ Change to UnavailableDay with new dataset
            sqlCmdDate.CommandText = "SELECT UnavailableDays FROM dbo.UnavailableDays WHERE EmployeeID = @EmployeeID AND UnavailableDays = @UADays "
            sqlCmdDate.Parameters.AddWithValue("@EmployeeID", empID)
            sqlCmdDate.Parameters.AddWithValue("@UADays", daytoCheck)

            dataReader = sqlCmdDate.ExecuteReader()    'One dataread, can be set to muliple commnads
            While dataReader.Read
                foundDate = dataReader(0)   ' 0 = first column 1 = 2nd column and so on
            End While
            dataReader.Close()   'Always close your reader
            returnedDate = CType(foundDate, String).Substring(0, 10)
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        Finally
            If (String.IsNullOrEmpty(returnedDate)) Then
                'no unavailable days
                returnedDate = "No UA"
                canWork = True
            Else
                'has unavailable day
                canWork = False
            End If

        End Try

        'finds the DaysWorked value for the current EmpID
        Dim findDaysWorked
        Try
            Dim sqlCmdDW As New SqlCommand()
            sqlCmdDW.Connection = FWFCconnect
            sqlCmdDW.CommandText = "SELECT TotalDaysWorked FROM dbo.PreviousWork WHERE EmployeeID = @EmployeeID"
            sqlCmdDW.Parameters.AddWithValue("@EmployeeID", empID)

            dataReader = sqlCmdDW.ExecuteReader()                            'One dataread, can be set to muliple commnads

            While dataReader.Read
                findDaysWorked = dataReader(0)  ' 0 = first column 1 = 2nd column and so on
            End While
            dataReader.Close()  'Always close your reader

            returnedDW = findDaysWorked
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest DaysWorked value for the Table
        'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
        Try
            Dim sqlCmdLowDW As New SqlCommand()
            sqlCmdLowDW.Connection = FWFCconnect
            sqlCmdLowDW.CommandText = "SELECT Min(TotalDaysWorked) FROM dbo.PreviousWork"

            dataReader = sqlCmdLowDW.ExecuteReader()                        'One dataread, can be set to muliple commnads

            While dataReader.Read
                lowestDW = dataReader(0)
            End While
            dataReader.Close()
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest Holidays worked for the Table
        Try
            'lowestHoliday = Storedprocedure to pull the lowestHolidays in the table
            'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
            'temp holder
            lowestHoliday = 0
        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest Weekends worked for the Table
        Try
            'lowestWeekend = Storeprocedure to pull the lowestWeekends in the table
            'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
            'temp holder
            lowestWeekend = 0


        Catch ex As System.NullReferenceException

        End Try

        'Finds the return for the current employees Hoidays worked
        Try
            'returnedHoliday = Storedprocedyre to pull the total holidays worked in the table for the current employee
            'temp holder
            returnedHoliday = 0
        Catch ex As System.NullReferenceException

        End Try

        'Finds the return for the current employees Weekends worked
        Try
            'returnedWeekend = Storedprocedure to pull the total holidays worked in the table for the current employee
            'temp holder
            returnedWeekend = 0
        Catch ex As System.NullReferenceException

        End Try

        iterateDW = True        'Resets values of the iterates
        iterateHoliday = True   '""
        iterateWeekend = True   '""
        Dim checkIterator As Boolean = True


        'Ideas to fix loop
        'DO While canWork to skip over if the employee cant work to make more efficient

        Do While (checkIterator)    'Iterates over the lowest Daysworked and holidays and weekends to find an available employee

            If (canWork And returnedDW <= lowestDW And returnedHoliday <= lowestHoliday And returnedWeekend <= lowestWeekend And alreadyChecked = False) Then 'Checks to see if the Employee can work on dayToCheck on the Loop 

                'This is where you write to the schedule

                Dim sqlCmdSched As New SqlCommand()
                sqlCmdSched.Connection = FWFCconnect
                sqlCmdSched.CommandText = "INSERT INTO Schedule (EmployeeID, Day, ShiftType) VALUES(@EmployeeID, @Day, @ShiftType)"
                sqlCmdSched.Parameters.AddWithValue("@EmployeeID", empID)
                sqlCmdSched.Parameters.AddWithValue("@Day", daytoCheck)
                sqlCmdSched.Parameters.AddWithValue("@ShiftType", shiftType)

                Dim rowsaffect = sqlCmdSched.ExecuteNonQuery()
                'CHanged logic to no longer holder integervalues but to check the entire previous month with storedprocedure
                sqlCmdSched.CommandText = "UPDATE PreviousWork SET TotalDaysWorked = @TotalDaysWorked WHERE EmployeeID = @EmployeeID2"
                sqlCmdSched.Parameters.AddWithValue("@EmployeeID2", empID)
                sqlCmdSched.Parameters.AddWithValue("@TotalDaysWorked", returnedDW + 1)

                Dim rowaffect2 = sqlCmdSched.ExecuteNonQuery()

                alreadyChecked = True   'flags the day as checked

                'Test output, to be removed at end
                Console.WriteLine("DB Written to for Emp:" + CType(empID, String) + "on" + phDate + "Rows Affect: " + CType(rowsaffect, String) + "-" + CType(rowaffect2, String))



                checkIterator = False 'Employee found with availablility flag to end loop

            Else
                Exit Do 'to stop current infinite looping

                'This is where you iterate to the next value to check if there hasnt been an Employee found "alreadyChecked = False"
                If (iterateHoliday And alreadyChecked = False) Then
                    'iterates to the next lowest holiday value to check
                    'Possible to have a stored procedure to pull 2nd lowest value?
                    'Implement the Offset and redefine variable?
                    lowestHoliday = lowestHoliday + 1
                    iterateHoliday = False
                ElseIf (iterateWeekend And alreadyChecked = False) Then
                    'iterates to the next lowest weekend value to check
                    'Possible to have a stored procedure to pull 2nd lowest value?
                    'Implement the Offset and redefine variable?
                    lowestWeekend = lowestWeekend + 1
                    iterateWeekend = False
                ElseIf (iterateDW And alreadyChecked = False) Then
                    'iterates to the next lowest daysworked value to check
                    'Possible to have a stored procedure to pull 2nd lowest value?
                    'Implement the Offset and redefine variable?
                    lowestDW = lowestDW + 1
                    iterateDW = False
                End If
            End If

        Loop
        FWFCconnect.Close()
    End Sub
End Module
