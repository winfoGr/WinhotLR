<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TmimataFrm
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
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.TmimataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TmimataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
        Me.TmimataDataGridView = New System.Windows.Forms.DataGridView
        Me.kwd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TmimataBindingSource
        '
        Me.TmimataBindingSource.DataMember = "tmimata"
        Me.TmimataBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TmimataTableAdapter
        '
        Me.TmimataTableAdapter.ClearBeforeFill = True
        '
        'TmimataDataGridView
        '
        Me.TmimataDataGridView.AllowUserToAddRows = False
        Me.TmimataDataGridView.AllowUserToDeleteRows = False
        Me.TmimataDataGridView.AutoGenerateColumns = False
        Me.TmimataDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kwd, Me.DataGridViewTextBoxColumn2})
        Me.TmimataDataGridView.DataSource = Me.TmimataBindingSource
        Me.TmimataDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TmimataDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.TmimataDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimataDataGridView.Name = "TmimataDataGridView"
        Me.TmimataDataGridView.ReadOnly = True
        Me.TmimataDataGridView.Size = New System.Drawing.Size(363, 260)
        Me.TmimataDataGridView.TabIndex = 1
        '
        'kwd
        '
        Me.kwd.DataPropertyName = "kwd"
        Me.kwd.HeaderText = "kwd"
        Me.kwd.Name = "kwd"
        Me.kwd.ReadOnly = True
        Me.kwd.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "tmima"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TMHMA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'TmimataFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 260)
        Me.Controls.Add(Me.TmimataDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "TmimataFrm"
        Me.Text = "Επιλογή Τμήματος (διπλό κλίκ)"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents TmimataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TmimataTableAdapter As winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
    Friend WithEvents TmimataDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents kwd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
