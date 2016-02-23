Public Class StartForm

    Private Sub AsNameShiftDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsNameShiftDateToolStripMenuItem.Click
        ' Create an instance of the NameShiftDateForm
        Dim frmNameShiftDate As New NameShiftDateForm

        'Display the form in modal style
        frmNameShiftDate.ShowDialog()

    End Sub

    Private Sub EditAvailabilityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditAvailabilityToolStripMenuItem.Click
        ' Create an instance of the EditorForm
        Dim frmEditor As New EditorForm

        'Display the form in modal style
        frmEditor.ShowDialog()

    End Sub

    Private Sub AutoGenerateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoGenerateToolStripMenuItem.Click
        'Run the module on call to generate the oncall schedule
        'output viewable in the debug output window
        ModuleOncall.Main()
    End Sub

    Private Sub AddHolidaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddHolidaysToolStripMenuItem.Click
        'Run the module on call to generate the holidays 
        'output viewable in the debug output window
        ModuleHolidays.GenerateHolidays()

    End Sub
End Class
