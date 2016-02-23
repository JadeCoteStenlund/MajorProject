Public Class NameShiftDateForm

    Private Sub NameShiftDateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSetNameShfitDate.ShiftDate' table. You can move, or remove it, as needed.
        Me.ShiftDateTableAdapter.Fill(Me.DataSetNameShfitDate.ShiftDate)
        'TODO: This line of code loads data into a dataset. You can move, or remove it, as needed. R. Leblanc
        'Note, this should be fed from the database 'Schedule' table, obtaining Employee Name, Date and Type of Shift, T. Mangatal 22 February 2016.

    End Sub
End Class