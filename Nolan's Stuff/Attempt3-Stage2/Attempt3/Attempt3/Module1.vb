'Import ProjectName.DataSetNameTableAdapters
Imports System.Data
Imports System.Data.SqlClient

'NolanWood
'FWFC Sheduler

' TO DO:
' Ask input for a way to toggle an employee as active
' A way to check if an employee is Actively working and not on Leave
' Sql Commands can be updated with Sql Command Stored Procedures 
' Import table adapters for the dataset
' Replace the current Dataset with the updated one with store procedures from Jordan Crago
' Sql Commmand --- CommandType = CommandType.StoredProcedure to be used where stored procedures are to be used
Module Module1

    Dim alreadyChecked As Boolean = False     'To flag a day as already checked
    Dim FWFCconnect As New SqlConnection
    Dim phDate As Date = #2/1/2016#     'inital date of the month  to be changed with a way to pull the current month
    'DateTime.Now.Month to retrieve the current month the program is being run in as Integer
    Sub Main()
        FWFCconnect.ConnectionString = "Data Source=(localdb)\Projects;Initial Catalog=FWFCScheduler;Integrated Security=True"
        'Connection string for Sql Commands
        Dim inputID As Integer = 1   'Inital EmpID of 1
        FWFCconnect.Open()
        Dim maxIDs As Integer = maxEmployeeID() 'Placeholder Total EMPID       Max Active EmployeeID's
        FWFCconnect.Close()
        Dim maxDays = DateTime.DaysInMonth(phDate.Year, phDate.Month)            'DateTime.DaysInMonth to retrieeve the maximum days in the month
        Dim startDay = 1             'start of every month is the 1st day

        Do While (startDay <= maxDays)   'Loops through the days of the month

            Do While (inputID <= maxIDs + 1)    'Loops through the empID's until all are checked
                CheckAvailability(inputID, phDate, startDay)
                inputID = inputID + 1
                Console.WriteLine("Inner Loop: " + CType(inputID, String) + " " + CType(alreadyChecked, String))
            Loop
            alreadyChecked = False  'Unflags the day being checked
            Console.WriteLine("Outer loop: " + CType(startDay, String))
            startDay += 1
            inputID = 1 'resets the inner loop to cycle to the next day to allow the entire list of EmpID's to be checked
            phDate = DateAdd(DateInterval.Day, 1, phDate) 'Adds 1 day to the inital date
        Loop


        Console.ReadKey()
    End Sub

    Public Sub CheckAvailability(empID As Integer, daytoCheck As Date, dayCount As Integer)

        Dim dataReader As SqlDataReader 'allows data to be read from the DB
        FWFCconnect.ConnectionString = "Data Source=(localdb)\Projects;Initial Catalog=FWFCScheduler;Integrated Security=True"
        FWFCconnect.Open()

        Dim offset As Integer = 0
        Dim shiftType As String = "O"   'placeholder shift type         A = After Hours, O = Oncall  B= Both
        Dim lowestDW As Integer = -1     'lowest DaysWorked variable
        Dim ableToWork As Boolean
        Dim lowestHoliday As Integer = -1 'lowest HolidaysWorked variable
        Dim lowestWeekend As Integer = -1 'lowest WeekendsWorked variable
        Dim returnedHoliday As Integer 'holds the returned total Holidays worked by an employee
        Dim returnedWeekend As Integer 'holds the returned total weekends worked by an employee
        Dim returnedDW As Integer   'holds the returned daysworked from the Datareader
        Dim iterateDW As Boolean    'holds the bool value to see if the DaysWorked(lowestDW) was iterated to the next highest value
        Dim offsetting As Boolean = True
        Dim iterateHoliday As Boolean   'holds the bool value to see if the Holidays(lowestHoliday) worked was iterated to the next highest value
        Dim iterateWeekend As Boolean   'holds the bool value to see if the Weekends(lowestWeekend) worked was iterated to the next highest value
        Dim returnedActive As String 'Holds the value of the Active in the Employee Table 
        ableToWork = canWork(empID, daytoCheck)
        Try
            
            returnedDW = getWorkByYear(empID, 2016)
            Exit Try

        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest DaysWorked value for the Table
        'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
        Try
            
            For i = 1 To maxEmployeeID()
                If (getWorkByYear(i, 2016) = 0) Then
                    lowestDW = 0
                    Exit For
                End If
            Next
            If (lowestDW = -1) Then
                Do While (offsetting)
                    Dim checkerID = getIDOfMinWeekendsWorked(offset)
                    If (Not canWork(checkerID, daytoCheck)) Then
                        offset += 1
                    Else
                        offsetting = False
                    End If
                Loop
                lowestDW = getMinDaysWorked(offset)
                offset = 0
                offsetting = True
            End If
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest Holidays worked for the Table
        Try
            'lowestHoliday = Storedprocedure to pull the lowestHolidays in the table
            'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
            'temp holder
            For i = 1 To maxEmployeeID()
                If (getHolidaysByYear(i, 2016) = 0) Then
                    lowestHoliday = 0
                    Exit For
                End If
            Next
            If (lowestHoliday = -1) Then
                Do While (offsetting)
                    Dim checkerID = getIDOfMinHolidaysWorked(offset)
                    If (Not canWork(checkerID, daytoCheck)) Then
                        offset += 1
                    Else
                        offsetting = False
                    End If
                Loop
                lowestHoliday = getMinHolidaysWorked(offset)
                offset = 0
                offsetting = True
            End If
        Catch ex As System.NullReferenceException
            Exit Try
        End Try

        'Finds the lowest Weekends worked for the Table
        Try
            'lowestWeekend = Storeprocedure to pull the lowestWeekends in the table
            'Has a @RowOffset  0 = lowest, 1 = 2nd lowest and so on
            'temp holder
            For i = 1 To maxEmployeeID()
                If (getWeekendsByYear(i, 2016) = 0) Then
                    lowestWeekend = 0
                    Exit For
                End If
            Next
            If (lowestWeekend = -1) Then
                Do While (offsetting)
                    Dim checkerID = getIDOfMinWeekendsWorked(offset)
                    If (Not canWork(checkerID, daytoCheck)) Then
                        offset += 1
                    Else
                        offsetting = False
                    End If
                Loop
                lowestWeekend = getMinWeekendsWorked(offset)
                offset = 0
                offsetting = True
            End If


        Catch ex As System.NullReferenceException

        End Try

        'Finds the return for the current employees Hoidays worked
        Try
            'returnedHoliday = Storedprocedyre to pull the total holidays worked in the table for the current employee
            'temp holder
            returnedHoliday = getHolidaysByYear(empID, 2016)
        Catch ex As System.NullReferenceException

        End Try

        'Finds the return for the current employees Weekends worked
        Try
            'returnedWeekend = Storedprocedure to pull the total holidays worked in the table for the current employee
            'temp holder
            returnedWeekend = getWeekendsByYear(empID, 2016)
        Catch ex As System.NullReferenceException

        End Try

        Try
            'returnedActive = storedprocedure to pull the value of Active from dbo.Employee
            'temp holder
            Dim getReturnedActive As New SqlCommand()
            getReturnedActive.Connection = FWFCconnect
            getReturnedActive.CommandText = "SELECT Active FROM Employee WHERE ID = @empID"
            getReturnedActive.Parameters.AddWithValue("@empID", empID)
            dataReader = getReturnedActive.ExecuteReader()
            While dataReader.Read
                returnedActive = dataReader(0)
            End While
            dataReader.Close()
        Catch ex As System.NullReferenceException

        End Try

        iterateDW = True        'Resets values of the iterates
        iterateHoliday = True   '""
        iterateWeekend = True   '""
        Dim checkIterator As Boolean = True


        'Ideas to fix loop
        'DO While canWork to skip over if the employee cant work to make more efficient

        Do While (checkIterator)    'Iterates over the lowest Daysworked and holidays and weekends to find an available employee

            'Add condition that an Employee must be Active and not on leave to be able to be assigned work      Options= "Y" or "N"
            If (ableToWork And returnedDW <= lowestDW And Not isHoliday(daytoCheck) And Not isWeekend(daytoCheck) And returnedActive = "Y" And alreadyChecked = False Or ableToWork And returnedHoliday <= lowestHoliday And isHoliday(daytoCheck) And returnedActive = "Y" And alreadyChecked = False Or ableToWork And returnedWeekend <= lowestWeekend And isWeekend(daytoCheck) And returnedActive = "Y" And alreadyChecked = False) Then 'Checks to see if the Employee can work on dayToCheck on the Loop 

                'This is where you write to the schedule

                Dim sqlCmdSched As New SqlCommand()
                sqlCmdSched.Connection = FWFCconnect
                sqlCmdSched.CommandText = "INSERT INTO Schedule (EmployeeID, WorkDate, ShiftType) VALUES(@EmployeeID, @Day, @ShiftType)"
                sqlCmdSched.Parameters.AddWithValue("@EmployeeID", empID)
                sqlCmdSched.Parameters.AddWithValue("@Day", daytoCheck)
                sqlCmdSched.Parameters.AddWithValue("@ShiftType", shiftType)

                Dim rowsaffect = sqlCmdSched.ExecuteNonQuery()

                alreadyChecked = True   'flags the day as checked

                'Test output, to be removed at end
                Console.WriteLine("DB Written to for Emp:" + CType(empID, String) + "on" + phDate + "Rows Affect: " + CType(rowsaffect, String))



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

    Public Function getWorkByYear(ID As Integer, Year As Integer)


        Dim cmd = New SqlCommand("getWorkByYear", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim empID As SqlParameter = cmd.Parameters.Add("@EmpID", SqlDbType.Int)
        Dim chosenYear As SqlParameter = cmd.Parameters.Add("@Year", SqlDbType.Int)

        empID.Value = ID
        chosenYear.Value = Year

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getWeekendsByYear(ID As Integer, Year As Integer)


        Dim cmd = New SqlCommand("getWeekendsByYear", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim empID As SqlParameter = cmd.Parameters.Add("@EmpID", SqlDbType.Int)
        Dim chosenYear As SqlParameter = cmd.Parameters.Add("@Year", SqlDbType.Int)

        empID.Value = ID
        chosenYear.Value = Year

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getHolidaysByYear(ID As Integer, Year As Integer)


        Dim cmd = New SqlCommand("getHolidaysByYear", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim empID As SqlParameter = cmd.Parameters.Add("@EmpID", SqlDbType.Int)
        Dim chosenYear As SqlParameter = cmd.Parameters.Add("@Year", SqlDbType.Int)

        empID.Value = ID
        chosenYear.Value = Year

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function maxEmployeeID()


        Dim cmd = New SqlCommand("getMaxEmployeeID", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getMinDaysWorked(offset As Integer)

        Dim cmd = New SqlCommand("minDaysWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(1)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getMinWeekendsWorked(offset As Integer)


        Dim cmd = New SqlCommand("minWeekendsWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(1)
        End While
        dataReader.Close()
        Return retvalue
    End Function
    Public Function getMinHolidaysWorked(offset As Integer)


        Dim cmd = New SqlCommand("minHolidaysWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(1)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getIDOfMinDaysWorked(offset As Integer)


        Dim cmd = New SqlCommand("minDaysWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function

    Public Function getIDOfMinWeekendsWorked(offset As Integer)


        Dim cmd = New SqlCommand("minWeekendsWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function
    Public Function getIDOfMinHolidaysWorked(offset As Integer)


        Dim cmd = New SqlCommand("minHolidaysWorked", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim rowOffset As SqlParameter = cmd.Parameters.Add("@RowOffset", SqlDbType.Int)

        rowOffset.Value = offset

        Dim dataReader As SqlDataReader = cmd.ExecuteReader
        Dim retvalue As Integer
        While dataReader.Read
            retvalue = dataReader(0)
        End While
        dataReader.Close()
        Return retvalue
    End Function
    Public Sub insertIntoSchedule(ID As Integer, WorkingDate As Date, ShiftyType As Char)


        Dim cmd = New SqlCommand("insertIntoSchedule", FWFCconnect)
        cmd.CommandType = CommandType.StoredProcedure
        Dim empID As SqlParameter = cmd.Parameters.Add("@EmpID", SqlDbType.Int)
        Dim workDate As SqlParameter = cmd.Parameters.Add("@Date", SqlDbType.Date)
        Dim shiftType As SqlParameter = cmd.Parameters.Add("@ShiftType", SqlDbType.Char, 1)

        empID.Value = ID
        workDate.Value = WorkingDate
        shiftType.Value = ShiftyType

        cmd.ExecuteNonQuery()

    End Sub

    Public Function canWork(empID As Integer, daytoCheck As Date)
        Dim workable As Boolean
        Dim foundDate
        Dim returnedDate As String
        Try
            Dim sqlCmdDate As New SqlCommand()
            Dim dataReader As SqlDataReader
            sqlCmdDate.Connection = FWFCconnect                                                                         '\/ Change to UnavailableDay with new dataset
            sqlCmdDate.CommandText = "SELECT UnavailableDay FROM dbo.UnavailableDays WHERE EmployeeID = @EmployeeID AND UnavailableDay = @UADays "
            sqlCmdDate.Parameters.AddWithValue("@EmployeeID", empID)
            sqlCmdDate.Parameters.AddWithValue("@UADays", daytoCheck)

            dataReader = sqlCmdDate.ExecuteReader()    'One dataread, can be set to muliple commnads
            While dataReader.Read
                foundDate = dataReader(0)   ' 0 = first column 1 = 2nd column and so on
            End While
            dataReader.Close()   'Always close your reader
            returnedDate = CType(foundDate, String)
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        Finally
            If (String.IsNullOrEmpty(returnedDate)) Then
                'no unavailable days
                returnedDate = "No UA"
                workable = True
            Else
                'has unavailable day
                workable = False
            End If

        End Try
        Return workable
    End Function

    Public Function checkIfOffset(offsetter As Integer, daytoCheck As Date)
        Dim foundID As Integer = 0
        Try
            Dim offsetchecker As New SqlCommand()
            Dim dataReader As SqlDataReader
            offsetchecker.Connection = FWFCconnect
            offsetchecker.CommandText = "SELECT EmployeeID FROM UnavailableDays WHERE UnavailableDay = @UADays OFFSET @offset ROWS FETCH NEXT 1 ROW ONLY"

            offsetchecker.Parameters.AddWithValue("@UADays", daytoCheck)
            offsetchecker.Parameters.AddWithValue("@offset", offsetter)

            dataReader = offsetchecker.ExecuteReader()    'One dataread, can be set to muliple commnads
            While dataReader.Read
                foundID = dataReader(0)   ' 0 = first column 1 = 2nd column and so on
            End While
            dataReader.Close()   'Always close your reader
            Exit Try
        Catch ex As System.NullReferenceException
            Exit Try
        End Try
        Return foundID
    End Function

    Public Function isHoliday(dateToCheck As Date)
        Dim holidays As New List(Of Date)
        Try
            Dim checkDate As New SqlCommand()
            Dim dataReader As SqlDataReader
            checkDate.Connection = FWFCconnect
            checkDate.CommandText = "SELECT SpecialDate FROM SpecialDates WHERE DateType = 'H'"
            dataReader = checkDate.ExecuteReader()

            While dataReader.Read
                holidays.Add(dataReader(0))
            End While
            dataReader.Close()
            If (holidays.Contains(dateToCheck)) Then
                Return True
            End If
            Return False
        Catch ex As NullReferenceException
            Return False
        End Try
    End Function

    Public Function isWeekend(dateToCheck As Date)
        Dim weekends As New List(Of Date)
        Try
            Dim checkDate As New SqlCommand()
            Dim dataReader As SqlDataReader
            checkDate.Connection = FWFCconnect
            checkDate.CommandText = "SELECT SpecialDate FROM SpecialDates WHERE DateType = 'W'"
            dataReader = checkDate.ExecuteReader()

            While dataReader.Read
                weekends.Add(dataReader(0))
            End While

            dataReader.Close()

            If (weekends.Contains(dateToCheck)) Then
                Return True
            End If
            Return False
        Catch ex As NullReferenceException
            Return False
        End Try
    End Function
End Module
