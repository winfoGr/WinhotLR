<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XoresFrm
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
        Me.components = New System.ComponentModel.Container
        Me.XoresDtGrd = New System.Windows.Forms.DataGridView
        Me.KwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SintomeusiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XoraDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.XoresTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xoresTableAdapter
        CType(Me.XoresDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XoresDtGrd
        '
        Me.XoresDtGrd.AllowUserToAddRows = False
        Me.XoresDtGrd.AllowUserToDeleteRows = False
        Me.XoresDtGrd.AutoGenerateColumns = False
        Me.XoresDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.XoresDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KwdDataGridViewTextBoxColumn, Me.SintomeusiDataGridViewTextBoxColumn, Me.XoraDataGridViewTextBoxColumn})
        Me.XoresDtGrd.DataSource = Me.XoresBindingSource
        Me.XoresDtGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XoresDtGrd.Location = New System.Drawing.Point(0, 0)
        Me.XoresDtGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.XoresDtGrd.Name = "XoresDtGrd"
        Me.XoresDtGrd.ReadOnly = True
        Me.XoresDtGrd.Size = New System.Drawing.Size(354, 327)
        Me.XoresDtGrd.TabIndex = 0
        '
        'KwdDataGridViewTextBoxColumn
        '
        Me.KwdDataGridViewTextBoxColumn.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn.HeaderText = "kwd"
        Me.KwdDataGridViewTextBoxColumn.Name = "KwdDataGridViewTextBoxColumn"
        Me.KwdDataGridViewTextBoxColumn.ReadOnly = True
        Me.KwdDataGridViewTextBoxColumn.Visible = False
        Me.KwdDataGridViewTextBoxColumn.Width = 30
        '
        'SintomeusiDataGridViewTextBoxColumn
        '
        Me.SintomeusiDataGridViewTextBoxColumn.DataPropertyName = "sintomeusi"
        Me.SintomeusiDataGridViewTextBoxColumn.HeaderText = "Συντόμευση"
        Me.SintomeusiDataGridViewTextBoxColumn.Name = "SintomeusiDataGridViewTextBoxColumn"
        Me.SintomeusiDataGridViewTextBoxColumn.ReadOnly = True
        '
        'XoraDataGridViewTextBoxColumn
        '
        Me.XoraDataGridViewTextBoxColumn.DataPropertyName = "xora"
        Me.XoraDataGridViewTextBoxColumn.HeaderText = "Χώρα"
        Me.XoraDataGridViewTextBoxColumn.Name = "XoraDataGridViewTextBoxColumn"
        Me.XoraDataGridViewTextBoxColumn.ReadOnly = True
        Me.XoraDataGridViewTextBoxColumn.Width = 200
        '
        'XoresBindingSource
        '
        Me.XoresBindingSource.DataMember = "xores"
        Me.XoresBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'XoresTableAdapter
        '
        Me.XoresTableAdapter.ClearBeforeFill = True
        '
        'XoresFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 327)
        Me.Controls.Add(Me.XoresDtGrd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "XoresFrm"
        Me.Text = "Χώρες"
        CType(Me.XoresDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XoresDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents XoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XoresTableAdapter As winhotel.dbhotelDataSetTableAdapters.xoresTableAdapter
    Friend WithEvents KwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SintomeusiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XoraDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
