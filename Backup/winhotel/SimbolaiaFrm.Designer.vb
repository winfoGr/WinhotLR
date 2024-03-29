<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimbolaiaFrm
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
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.PraktoreiaDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.xrewsi = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PraktoreiaBindingSource
        '
        Me.PraktoreiaBindingSource.DataMember = "praktoreia"
        Me.PraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiaTableAdapter
        '
        Me.PraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiaDataGridView
        '
        Me.PraktoreiaDataGridView.AutoGenerateColumns = False
        Me.PraktoreiaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.xrewsi})
        Me.PraktoreiaDataGridView.DataSource = Me.PraktoreiaBindingSource
        Me.PraktoreiaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PraktoreiaDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.PraktoreiaDataGridView.Name = "PraktoreiaDataGridView"
        Me.PraktoreiaDataGridView.Size = New System.Drawing.Size(494, 366)
        Me.PraktoreiaDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ΚΩΔ."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "eponimia"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ΕΠΩΝΥΜΙΑ"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'xrewsi
        '
        Me.xrewsi.DataPropertyName = "xrewsi"
        Me.xrewsi.HeaderText = "xrewsi"
        Me.xrewsi.Name = "xrewsi"
        Me.xrewsi.Visible = False
        '
        'SimbolaiaFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 366)
        Me.Controls.Add(Me.PraktoreiaDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Name = "SimbolaiaFrm"
        Me.Text = "Επιλογή Πρακτορείου (διπλό κλίκ)"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents PraktoreiaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xrewsi As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
