<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.CalenderDataSet = New Calendar.CalenderDataSet()
        Me.TableTableAdapter = New Calendar.CalenderDataSetTableAdapters.TableTableAdapter()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TableBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.TableBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalenderDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TableBindingSource
        '
        Me.TableBindingSource.DataMember = "Table"
        Me.TableBindingSource.DataSource = Me.CalenderDataSet
        '
        'CalenderDataSet
        '
        Me.CalenderDataSet.DataSetName = "CalenderDataSet"
        Me.CalenderDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableTableAdapter
        '
        Me.TableTableAdapter.ClearBeforeFill = True
        '
        'ListBox1
        '
        Me.ListBox1.DataSource = Me.TableBindingSource1
        Me.ListBox1.DisplayMember = "Name"
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(164, 48)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(70, 228)
        Me.ListBox1.TabIndex = 4
        Me.ListBox1.ValueMember = "Time"
        '
        'TableBindingSource1
        '
        Me.TableBindingSource1.DataMember = "Table"
        Me.TableBindingSource1.DataSource = Me.CalenderDataSet
        '
        'ListBox2
        '
        Me.ListBox2.DataSource = Me.TableBindingSource2
        Me.ListBox2.DisplayMember = "Time"
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(231, 48)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(59, 228)
        Me.ListBox2.TabIndex = 5
        Me.ListBox2.ValueMember = "Time"
        '
        'TableBindingSource2
        '
        Me.TableBindingSource2.DataMember = "Table"
        Me.TableBindingSource2.DataSource = Me.CalenderDataSet
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Shift(Date)"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 507)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalenderDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CalenderDataSet As Calendar.CalenderDataSet
    Friend WithEvents TableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableTableAdapter As Calendar.CalenderDataSetTableAdapters.TableTableAdapter
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TableBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TableBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
