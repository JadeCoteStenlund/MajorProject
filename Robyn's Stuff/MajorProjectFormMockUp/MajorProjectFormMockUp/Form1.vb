Imports System.Data.SqlClient

Public Class InputForm
    Dim connectionString = "Data Source=(localdb)\ProjectsV12;Initial Catalog=MajorProjMockUP;Integrated Security=true"
    Dim EnteredStart
    Dim EnteredEnd
    Dim EnteredName
    Private Sub InputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MajorProjMockUPDataSet2.Name' table. You can move, or remove it, as needed.
        Me.NameTableAdapter.Fill(Me.MajorProjMockUPDataSet2.Name)

    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        UpdateDates()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        ConfirmDelete()
    End Sub


#Region "Custom Subs"
    Private Sub UpdateDates()

        EnteredStart = StartDatePicker.Value
        EnteredEnd = EndDatePicker.Value
        EnteredName = ClinicianNameCombo.SelectedValue

        Dim insertQuery = "INSERT INTO ScheduleDate (ClinicianName, StartDate, EndDate) VALUES (@ClinicianName, @StartDate, @EndDate)"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(insertQuery, connection)
            command.Parameters.AddWithValue("@StartDate", EnteredStart)
            command.Parameters.AddWithValue("@EndDate", EnteredEnd)
            command.Parameters.AddWithValue("@ClinicianName", EnteredName)
            Try
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("Successfully entered in time off")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using

    End Sub

    Private Sub ConfirmDelete()
        Dim Confirm As DialogResult
        Dim Message As String = "Are you sure you want to delete previous scheduled dates? It's best to do this before making a new schedule."
        Dim Buttons As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim Caption As String = "Confirm Delete"

        Confirm = MessageBox.Show(Message, Caption, Buttons)

        If Confirm = System.Windows.Forms.DialogResult.Yes Then
            DeleteRecords()
        Else

        End If
    End Sub

    Private Sub DeleteRecords()
        Dim deleteResultsString = "DELETE FROM dbo.ScheduleDate"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(deleteResultsString, connection)
            Try
                connection.Open()
                command.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Using

    End Sub

#End Region
    
End Class