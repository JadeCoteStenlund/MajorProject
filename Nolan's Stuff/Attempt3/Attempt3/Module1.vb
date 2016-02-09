Imports Attempt3.FWFCSchedulerDataSetTableAdapters
Imports System.Data
Imports System.Data.SqlClient
'NolanWood
'FWFC Sheduler
Module Module1

    Dim alreadyChecked As Boolean = False     'To flag a day as already checked
    Dim FWFCconnect As New SqlConnection
    Dim phDate As Date = #2/1/2016#     'inital date of the month
    Sub Main()
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

        Dim shiftType As String = "O"   'placeholder shift type
        Dim lowestDW As Integer     'lowest DaysWorked variable
        Dim returnedDate As String  'holds the returned date from the Datareader
        Dim returnedDW As Integer   'holds the returned daysworked from the Datareader
        Dim canWork As Boolean

        'finds the Unavailable days for the current EmpID
        Dim foundDate
        Try
            Dim sqlCmdDate As New SqlCommand()
            sqlCmdDate.Connection = FWFCconnect
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

        If (canWork And returnedDW <= lowestDW And alreadyChecked = False) Then 'Checks to see if the Employee can work on dayToCheck on the Loop 

            Dim sqlCmdSched As New SqlCommand()
            sqlCmdSched.Connection = FWFCconnect
            sqlCmdSched.CommandText = "INSERT INTO Schedule (EmployeeID, Day, ShiftType) VALUES(@EmployeeID, @Day, @ShiftType)"
            sqlCmdSched.Parameters.AddWithValue("@EmployeeID", empID)
            sqlCmdSched.Parameters.AddWithValue("@Day", daytoCheck)
            sqlCmdSched.Parameters.AddWithValue("@ShiftType", shiftType)

            Dim rowsaffect = sqlCmdSched.ExecuteNonQuery()

            sqlCmdSched.CommandText = "UPDATE PreviousWork SET TotalDaysWorked = @TotalDaysWorked WHERE EmployeeID = @EmployeeID2"
            sqlCmdSched.Parameters.AddWithValue("@EmployeeID2", empID)
            sqlCmdSched.Parameters.AddWithValue("@TotalDaysWorked", returnedDW + 1)

            Dim rowaffect2 = sqlCmdSched.ExecuteNonQuery()


            alreadyChecked = True   'flags the day as checked

            Console.WriteLine("DB Written to for Emp:" + CType(empID, String) + "on" + phDate + "Rows Affect: " + CType(rowsaffect, String) + "-" + CType(rowaffect2, String))

        End If


        Console.WriteLine(returnedDate)
        Console.WriteLine(returnedDW)
        Console.ReadKey()

        FWFCconnect.Close()
    End Sub
End Module
