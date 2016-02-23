<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FirstNameText = New System.Windows.Forms.TextBox()
        Me.LastNameText = New System.Windows.Forms.TextBox()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.currentEmpList = New System.Windows.Forms.ListBox()
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbFWFCSchedulerDataSet1 = New FWFC_Oncall_After_Hours_Scheduler.dbFWFCSchedulerDataSet1()
        Me.removeButton = New System.Windows.Forms.Button()
        Me.EmployeeTableAdapter = New FWFC_Oncall_After_Hours_Scheduler.dbFWFCSchedulerDataSet1TableAdapters.EmployeeTableAdapter()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbFWFCSchedulerDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Add Employee"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(401, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Current Employees"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "First Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Last Name"
        '
        'FirstNameText
        '
        Me.FirstNameText.Location = New System.Drawing.Point(128, 204)
        Me.FirstNameText.Name = "FirstNameText"
        Me.FirstNameText.Size = New System.Drawing.Size(116, 22)
        Me.FirstNameText.TabIndex = 15
        '
        'LastNameText
        '
        Me.LastNameText.Location = New System.Drawing.Point(128, 249)
        Me.LastNameText.Name = "LastNameText"
        Me.LastNameText.Size = New System.Drawing.Size(116, 22)
        Me.LastNameText.TabIndex = 16
        '
        'saveButton
        '
        Me.saveButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.saveButton.Location = New System.Drawing.Point(268, 228)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 33)
        Me.saveButton.TabIndex = 17
        Me.saveButton.Text = ">"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'currentEmpList
        '
        Me.currentEmpList.DataSource = Me.EmployeeBindingSource
        Me.currentEmpList.DisplayMember = "FirstName"
        Me.currentEmpList.FormattingEnabled = True
        Me.currentEmpList.ItemHeight = 16
        Me.currentEmpList.Location = New System.Drawing.Point(370, 140)
        Me.currentEmpList.Name = "currentEmpList"
        Me.currentEmpList.Size = New System.Drawing.Size(225, 228)
        Me.currentEmpList.TabIndex = 18
        Me.currentEmpList.ValueMember = "ID"
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataMember = "Employee"
        Me.EmployeeBindingSource.DataSource = Me.DbFWFCSchedulerDataSet1
        '
        'DbFWFCSchedulerDataSet1
        '
        Me.DbFWFCSchedulerDataSet1.DataSetName = "dbFWFCSchedulerDataSet1"
        Me.DbFWFCSchedulerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'removeButton
        '
        Me.removeButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.removeButton.Location = New System.Drawing.Point(439, 384)
        Me.removeButton.Name = "removeButton"
        Me.removeButton.Size = New System.Drawing.Size(94, 30)
        Me.removeButton.TabIndex = 19
        Me.removeButton.Text = "Remove"
        Me.removeButton.UseVisualStyleBackColor = True
        '
        'EmployeeTableAdapter
        '
        Me.EmployeeTableAdapter.ClearBeforeFill = True
        '
        'EmployeeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 613)
        Me.Controls.Add(Me.removeButton)
        Me.Controls.Add(Me.currentEmpList)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.LastNameText)
        Me.Controls.Add(Me.FirstNameText)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EmployeeForm"
        Me.Text = "Employee Mangement"
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbFWFCSchedulerDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FirstNameText As System.Windows.Forms.TextBox
    Friend WithEvents LastNameText As System.Windows.Forms.TextBox
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents currentEmpList As System.Windows.Forms.ListBox
    Friend WithEvents removeButton As System.Windows.Forms.Button
    Friend WithEvents DbFWFCSchedulerDataSet1 As FWFC_Oncall_After_Hours_Scheduler.dbFWFCSchedulerDataSet1
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeTableAdapter As FWFC_Oncall_After_Hours_Scheduler.dbFWFCSchedulerDataSet1TableAdapters.EmployeeTableAdapter
End Class
