Imports System.Collections.Generic

Public Class Editor

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'YYYY-MM-DD'
        'H' for holiday
        'W' for weekend 
        'B' for both

        Me.ScheduleTableAdapter.Fill(Me.SchedulerDataSet.Schedule)
        Me.EmployeeTableAdapter.Fill(Me.SchedulerDataSet.Employee)

        'populate dropdowns with names where Schedule EmployeeID == Employee EmployeeID
        Dim Ctrl As Control
        Dim Ctrltype As String = "ComboBox"
        Dim Row As Integer = 0

        For Each Ctrl In Me.EditorGB.Controls

            If Row >= SchedulerDataSet.Employee.Rows.Count Then
                Exit For
            ElseIf TypeName(Ctrl) = "ComboBox" Then
                Ctrl.Text = SchedulerDataSet.Employee.Item(Row).Item(1)
                Row += 1
            End If

        Next

        InitialCBListPopulation(OC1)
        InitialCBListPopulation(OC2)
        InitialCBListPopulation(OC3)
        InitialCBListPopulation(OC4)
        InitialCBListPopulation(OC5)
        InitialCBListPopulation(OC6)
        InitialCBListPopulation(OC7)
        InitialCBListPopulation(OC8)
        InitialCBListPopulation(OC9)
        InitialCBListPopulation(OC10)
        InitialCBListPopulation(OC11)
        InitialCBListPopulation(OC12)
        InitialCBListPopulation(OC13)
        InitialCBListPopulation(OC14)
        InitialCBListPopulation(OC15)
        InitialCBListPopulation(OC16)
        InitialCBListPopulation(OC17)
        InitialCBListPopulation(OC18)
        InitialCBListPopulation(OC19)
        InitialCBListPopulation(OC20)
        InitialCBListPopulation(OC21)
        InitialCBListPopulation(OC22)
        InitialCBListPopulation(OC23)
        InitialCBListPopulation(OC24)
        InitialCBListPopulation(OC25)
        InitialCBListPopulation(OC26)
        InitialCBListPopulation(OC27)
        InitialCBListPopulation(OC28)
        InitialCBListPopulation(OC29)
        InitialCBListPopulation(OC30)
        InitialCBListPopulation(OC31)

    End Sub

    Sub InitialCBListPopulation(CB As ComboBox, Optional Selected As String = "")

        For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1
            If CB.Text <> SchedulerDataSet.Employee.Item(Emp).Item(1) Then
                CB.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
            End If
        Next

        'The name is set in the combobox here.. what happens???
        'MessageBox.Show(Selected)

    End Sub

    Private Sub OC1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OC1.SelectedIndexChanged

        Dim Selected = OC1.SelectedItem
        Dim Exists = False

        'add Employee that doesn't exist
        For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1  'loop through each employee
            For Each Item In OC1.Items  'loop through each item in combobox list
                If SchedulerDataSet.Employee.Item(Emp).Item(1) = Item Then
                    Exists = True
                End If
            Next
            If Exists = False Then  'Employee was not found in list, add to combobox list
                OC1.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
            End If
            Exists = False
        Next


        'remove employee in ComboBox.Text
        'MessageBox.Show(OC1.Text)
        'OC1.Items.Remove(OC1.Text)
        'MessageBox.Show(OC1.Text)
        'OC1.Text = Selected

        'For Each Item In OC1.Items  'loop through each item in combobox list
        '    If SchedulerDataSet.Employee.Item(Emp).Item(1) = Item Then
        '        Exists = True
        '    End If
        'Next


        'For Emp As Integer = 0 To SchedulerDataSet.Employee.Rows.Count - 1
        '    If OC1.Items(Emp).Text <> SchedulerDataSet.Employee.Item(Emp).Item(1) Then
        '        CB.Items.Add(SchedulerDataSet.Employee.Item(Emp).Item(1))
        '    End If
        'Next
        'OC1.Items.Clear()  'here be the issue
        'InitialCBListPopulation(OC1, Selected)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MessageBox.Show("Schedule changes have been saved.")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



    End Sub
End Class
