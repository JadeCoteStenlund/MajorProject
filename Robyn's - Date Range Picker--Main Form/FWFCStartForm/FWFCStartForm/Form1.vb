Public Class StartForm

    Private Sub AsCalendarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AsCalendarToolStripMenuItem1.Click
        PrintDialog1.Document = PrintDocument1
        PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        PrintDialog1.AllowSomePages = True
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

End Class
