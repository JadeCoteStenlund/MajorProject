Imports System.Collections.Generic

Public Class EditorForm

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.UnavailableDaysTableAdapter.Fill(Me.SchedulerDataSet.UnavailableDays)
        Me.ScheduleTableAdapter.Fill(Me.SchedulerDataSet.Schedule)
        Me.EmployeeTableAdapter.Fill(Me.SchedulerDataSet.Employee)

        'YYYY-MM-DD'
        'H' for holiday
        'W' for weekend 
        'B' for both

        'populate combobox text values with names where Schedule EmployeeID == Employee EmployeeID
        CBTextManipulation()  '**must be modified to order based on date

        'populate with data
        CBCollectionManipulation(1)

    End Sub

    Sub CBCollectionManipulation(Process As Integer)
        'Process: 1 = combobox collection population from database, 2 = clear current comboboxes

        CollectionManipulator(OC1, Process)
        CollectionManipulator(OC2, Process)
        CollectionManipulator(OC3, Process)
        CollectionManipulator(OC4, Process)
        CollectionManipulator(OC5, Process)
        CollectionManipulator(OC6, Process)
        CollectionManipulator(OC7, Process)
        CollectionManipulator(OC8, Process)
        CollectionManipulator(OC9, Process)
        CollectionManipulator(OC10, Process)
        CollectionManipulator(OC11, Process)
        CollectionManipulator(OC12, Process)
        CollectionManipulator(OC13, Process)
        CollectionManipulator(OC14, Process)
        CollectionManipulator(OC15, Process)
        CollectionManipulator(OC16, Process)
        CollectionManipulator(OC17, Process)
        CollectionManipulator(OC18, Process)
        CollectionManipulator(OC19, Process)
        CollectionManipulator(OC20, Process)
        CollectionManipulator(OC21, Process)
        CollectionManipulator(OC22, Process)
        CollectionManipulator(OC23, Process)
        CollectionManipulator(OC24, Process)
        CollectionManipulator(OC25, Process)
        CollectionManipulator(OC26, Process)
        CollectionManipulator(OC27, Process)
        CollectionManipulator(OC28, Process)
        CollectionManipulator(OC29, Process)
        CollectionManipulator(OC30, Process)
        CollectionManipulator(OC31, Process)

    End Sub

    Sub CollectionManipulator(CB As ComboBox, Process As Integer) 'Optional Selected As String = ""

        If Process = 1 Then  'populate collections with current database data

            For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1
                CB.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
            Next

        ElseIf Process = 2 Then  'clear all combobox collections

            For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1
                CB.Items.Clear()
                CB.Text = ""
            Next

        End If

    End Sub

    Sub CBTextManipulation()

        'populate dropdowns with names where Schedule EmployeeID == Employee EmployeeID
        Dim Ctrl As Control
        Dim Ctrltype As String = "ComboBox"
        Dim Row As Integer = 0

        For Each Ctrl In Me.EditorGB.Controls

            If Row >= SchedulerDataSet.Employee.Rows.Count And TypeName(Ctrl) = "ComboBox" Then
                'Exit For
                'rather than exit, hide the control!
                Ctrl.Visible = False
            ElseIf TypeName(Ctrl) = "ComboBox" Then
                Ctrl.Text = SchedulerDataSet.Employee.Item(Row).Item(1)
                Row += 1
            End If

        Next

    End Sub

    Private Sub SaveChanges_Click(sender As Object, e As EventArgs) Handles SaveChanges.Click

        'update 
        'Dim ScheduleDate As New Date(SchedulerDataSet.Schedule.Item(0).Item(1)) 'Year, Month, Day as Integers
        Dim Ctrl As Control
        Dim Ctrltype As String = "ComboBox"
        Dim Row As Integer = 0

        EmployeeBS.EndEdit()
        ScheduleBS.EndEdit()

        For Each Ctrl In Me.EditorGB.Controls

            If Row >= SchedulerDataSet.Employee.Rows.Count Then
                Exit For
            ElseIf TypeName(Ctrl) = "ComboBox" Then

                'modify schedule dataset table to hold new employee ID corresponding to combobox text  
                'ScheduleTableAdapter.Insert(

                'Dim newDate As New Date(ScheduleDate.Year, ScheduleDate.Month, (Row + 1)) 'Year, Month, Day as Integers
                'SchedulerDataSet.Schedule.Item(Row).Item(1) =


                Ctrl.Text = SchedulerDataSet.Employee.Item(Row).Item(1)
                Row += 1
            End If

        Next

        MessageBox.Show("Schedule changes have been saved.")

    End Sub

    Private Sub ClearChanges_Click(sender As Object, e As EventArgs) Handles ClearChanges.Click

        'clear CB collections
        CBCollectionManipulation(2)
        'repopulate CB collections
        CBCollectionManipulation(1)
        'repopulate CB text
        CBTextManipulation()

    End Sub

    'Private Sub OC1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OC1.SelectedIndexChanged

    '    Dim Selected = OC1.SelectedItem
    '    Dim Exists = False

    '    'add Employee that doesn't exist
    '    For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1  'loop through each employee
    '        For Each Item In OC1.Items  'loop through each item in combobox list
    '            If SchedulerDataSet.Employee.Item(Emp).Item(1) = Item Then
    '                Exists = True
    '            End If
    '        Next
    '        If Exists = False Then  'Employee was not found in list, add to combobox list
    '            OC1.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
    '        End If
    '        Exists = False
    '    Next


    '    'remove employee in ComboBox.Text
    '    'MessageBox.Show(OC1.Text)
    '    'OC1.Items.Remove(OC1.Text)
    '    'MessageBox.Show(OC1.Text)
    '    'OC1.Text = Selected

    '    'For Each Item In OC1.Items  'loop through each item in combobox list
    '    '    If SchedulerDataSet.Employee.Item(Emp).Item(1) = Item Then
    '    '        Exists = True
    '    '    End If
    '    'Next


    '    'For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1
    '    '    If OC1.Items(Emp).Text <> SchedulerDataSet.Employee.Item(Emp).Item(1) Then
    '    '        CB.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
    '    '    End If
    '    'Next
    '    'OC1.Items.Clear()  'here be the issue
    '    'InitialCBListPopulation(OC1, Selected)

    'End Sub

End Class
