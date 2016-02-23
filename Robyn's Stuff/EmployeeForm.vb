Imports System.Data.SqlClient

Public Class EmployeeForm
    Dim connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Data\dbFWFCScheduler.mdf;Integrated Security=True"
    Dim enteredFirst
    Dim enteredLast
    Dim clickedEmp

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbFWFCSchedulerDataSet1.Employee' table. You can move, or remove it, as needed.
        Me.EmployeeTableAdapter.Fill(Me.DbFWFCSchedulerDataSet1.Employee)

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        SaveNewEmp()
    End Sub
    Private Sub currentEmpList_Click(sender As Object, e As EventArgs) Handles currentEmpList.Click
        clickedEmp = currentEmpList.ValueMember

    End Sub
    Private Sub removeButton_Click(sender As Object, e As EventArgs) Handles removeButton.Click
        DeleteEmp()
    End Sub

#Region "Custom Subs"

    Private Sub SaveNewEmp()

        enteredFirst = FirstNameText.Text
        enteredLast = LastNameText.Text

        Dim insertQuery = "INSERT INTO Employee (FirstName, LastName) VALUES (@FirstName, @LastName)"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(insertQuery, connection)
            command.Parameters.AddWithValue("@FirstName", enteredFirst)
            command.Parameters.AddWithValue("@LastName", enteredLast)

            Try
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("Successfully entered employee")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using

    End Sub

    Private Sub DeleteEmp()

        Dim deleteQuery = "DELETE FROM Employee WHERE Id = @ epmId"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(deleteQuery, connection)
            command.Parameters.AddWithValue("@empId", clickedEmp)
            Try
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("Successfully removed employee")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub


#End Region

End Class