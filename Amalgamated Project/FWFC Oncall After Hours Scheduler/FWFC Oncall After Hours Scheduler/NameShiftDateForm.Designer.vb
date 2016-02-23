<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NameShiftDateForm
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.TableBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataSetNameShfitDate = New FWFC_Oncall_After_Hours_Scheduler.DataSetNameShfitDate()
        Me.DataSetNameShfitDateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShiftDateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShiftDateTableAdapter = New FWFC_Oncall_After_Hours_Scheduler.DataSetNameShfitDateTableAdapters.ShiftDateTableAdapter()
        Me.ShiftDateBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetNameShfitDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetNameShfitDateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShiftDateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShiftDateBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TableBindingSource
        '
        Me.TableBindingSource.DataMember = "Table"
        '
        'ListBox1
        '
        Me.ListBox1.DataSource = Me.ShiftDateBindingSource1
        Me.ListBox1.DisplayMember = "LastName"
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(35, 33)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(54, 186)
        Me.ListBox1.TabIndex = 8
        Me.ListBox1.ValueMember = "Time"
        '
        'TableBindingSource1
        '
        Me.TableBindingSource1.DataMember = "Table"
        '
        'ListBox2
        '
        Me.ListBox2.DataSource = Me.ShiftDateBindingSource
        Me.ListBox2.DisplayMember = "WorkDate"
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(85, 33)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(45, 186)
        Me.ListBox2.TabIndex = 9
        Me.ListBox2.ValueMember = "Time"
        '
        'TableBindingSource2
        '
        Me.TableBindingSource2.DataMember = "Table"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Shift(Date)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Name"
        '
        'DataSetNameShfitDate
        '
        Me.DataSetNameShfitDate.DataSetName = "DataSetNameShfitDate"
        Me.DataSetNameShfitDate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSetNameShfitDateBindingSource
        '
        Me.DataSetNameShfitDateBindingSource.DataSource = Me.DataSetNameShfitDate
        Me.DataSetNameShfitDateBindingSource.Position = 0
        '
        'ShiftDateBindingSource
        '
        Me.ShiftDateBindingSource.DataMember = "ShiftDate"
        Me.ShiftDateBindingSource.DataSource = Me.DataSetNameShfitDateBindingSource
        '
        'ShiftDateTableAdapter
        '
        Me.ShiftDateTableAdapter.ClearBeforeFill = True
        '
        'ShiftDateBindingSource1
        '
        Me.ShiftDateBindingSource1.DataMember = "ShiftDate"
        Me.ShiftDateBindingSource1.DataSource = Me.DataSetNameShfitDateBindingSource
        '
        'NameShiftDateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NameShiftDateForm"
        Me.Text = "NameShiftDateForm"
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetNameShfitDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetNameShfitDateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShiftDateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShiftDateBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TableBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataSetNameShfitDateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSetNameShfitDate As FWFC_Oncall_After_Hours_Scheduler.DataSetNameShfitDate
    Friend WithEvents ShiftDateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShiftDateTableAdapter As FWFC_Oncall_After_Hours_Scheduler.DataSetNameShfitDateTableAdapters.ShiftDateTableAdapter
    Friend WithEvents ShiftDateBindingSource1 As System.Windows.Forms.BindingSource
End Class
