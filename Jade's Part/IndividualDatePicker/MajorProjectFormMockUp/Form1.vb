Imports System.Data.SqlClient

Public Class InputForm
    Dim connectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\testDB.mdf;Integrated Security=True"
    'Dim objWriter As New IO.StreamWriter("c:\test.txt", False)

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim date1 As Date = MonthCalendar1.SelectionEnd()
        TextBox1.Text &= date1 & Environment.NewLine
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        'Dim datearray As Array = TextBox1.Text.ToArray()
        'objWriter.Write(ClinicianName.Text)
        'objWriter.Write(TextBox1.Text)
        'objWriter.Close()
        Add()

    End Sub

    Private Sub Add()
        Dim xName = ClinicianName.Text.ToString()
        Dim xDates = TextBox1.Text.ToString()

        Dim insertQuery = "INSERT INTO dbo.test1 (name, date) VALUES (@name, @date) "

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(insertQuery, connection)
            command.Parameters.AddWithValue("@name", xName)
            command.Parameters.AddWithValue("@date", xDates)
            Try
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("ADDED!")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ScrollBars = ScrollBars.Vertical
    End Sub
End Class