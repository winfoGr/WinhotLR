<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XrewseisPrakt
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
        Me.XrewseisPraktDtGrd = New System.Windows.Forms.DataGridView
        Me.kwdTimol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.kwdXrewsPrakt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parast1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parast2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.parast3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.imerom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.xrewsi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KwdTimolDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KwdXrewsPraktDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parast1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parast2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Parast3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImeromDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XrewsiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XrewseistimologiapraktoreiouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
        CType(Me.XrewseisPraktDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseistimologiapraktoreiouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XrewseisPraktDtGrd
        '
        Me.XrewseisPraktDtGrd.AllowUserToAddRows = False
        Me.XrewseisPraktDtGrd.AllowUserToDeleteRows = False
        Me.XrewseisPraktDtGrd.AutoGenerateColumns = False
        Me.XrewseisPraktDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.XrewseisPraktDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kwdTimol, Me.kwdXrewsPrakt, Me.parast1, Me.parast2, Me.parast3, Me.imerom, Me.xrewsi, Me.KwdTimolDataGridViewTextBoxColumn, Me.KwdXrewsPraktDataGridViewTextBoxColumn, Me.Parast1DataGridViewTextBoxColumn, Me.Parast2DataGridViewTextBoxColumn, Me.Parast3DataGridViewTextBoxColumn, Me.ImeromDataGridViewTextBoxColumn, Me.XrewsiDataGridViewTextBoxColumn})
        Me.XrewseisPraktDtGrd.DataSource = Me.XrewseistimologiapraktoreiouBindingSource
        Me.XrewseisPraktDtGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XrewseisPraktDtGrd.Location = New System.Drawing.Point(0, 0)
        Me.XrewseisPraktDtGrd.Margin = New System.Windows.Forms.Padding(4)
        Me.XrewseisPraktDtGrd.Name = "XrewseisPraktDtGrd"
        Me.XrewseisPraktDtGrd.Size = New System.Drawing.Size(394, 199)
        Me.XrewseisPraktDtGrd.TabIndex = 0
        '
        'kwdTimol
        '
        Me.kwdTimol.DataPropertyName = "kwdTimol"
        Me.kwdTimol.HeaderText = "kwdTimol"
        Me.kwdTimol.Name = "kwdTimol"
        Me.kwdTimol.Visible = False
        '
        'kwdXrewsPrakt
        '
        Me.kwdXrewsPrakt.DataPropertyName = "kwdXrewsPrakt"
        Me.kwdXrewsPrakt.HeaderText = "kwdXrewsPrakt"
        Me.kwdXrewsPrakt.Name = "kwdXrewsPrakt"
        Me.kwdXrewsPrakt.Visible = False
        '
        'parast1
        '
        Me.parast1.DataPropertyName = "parast1"
        Me.parast1.HeaderText = "parast1"
        Me.parast1.Name = "parast1"
        Me.parast1.Visible = False
        '
        'parast2
        '
        Me.parast2.DataPropertyName = "parast2"
        Me.parast2.HeaderText = ""
        Me.parast2.Name = "parast2"
        Me.parast2.ReadOnly = True
        Me.parast2.Width = 20
        '
        'parast3
        '
        Me.parast3.DataPropertyName = "parast3"
        Me.parast3.HeaderText = "Παραστ."
        Me.parast3.Name = "parast3"
        Me.parast3.ReadOnly = True
        '
        'imerom
        '
        Me.imerom.DataPropertyName = "imerom"
        Me.imerom.HeaderText = "Ημερομηνία"
        Me.imerom.Name = "imerom"
        Me.imerom.ReadOnly = True
        '
        'xrewsi
        '
        Me.xrewsi.DataPropertyName = "xrewsi"
        Me.xrewsi.HeaderText = "Χρέωση"
        Me.xrewsi.Name = "xrewsi"
        Me.xrewsi.ReadOnly = True
        '
        'KwdTimolDataGridViewTextBoxColumn
        '
        Me.KwdTimolDataGridViewTextBoxColumn.DataPropertyName = "kwdTimol"
        Me.KwdTimolDataGridViewTextBoxColumn.HeaderText = "kwdTimol"
        Me.KwdTimolDataGridViewTextBoxColumn.Name = "KwdTimolDataGridViewTextBoxColumn"
        Me.KwdTimolDataGridViewTextBoxColumn.Visible = False
        '
        'KwdXrewsPraktDataGridViewTextBoxColumn
        '
        Me.KwdXrewsPraktDataGridViewTextBoxColumn.DataPropertyName = "kwdXrewsPrakt"
        Me.KwdXrewsPraktDataGridViewTextBoxColumn.HeaderText = "kwdXrewsPrakt"
        Me.KwdXrewsPraktDataGridViewTextBoxColumn.Name = "KwdXrewsPraktDataGridViewTextBoxColumn"
        Me.KwdXrewsPraktDataGridViewTextBoxColumn.Visible = False
        '
        'Parast1DataGridViewTextBoxColumn
        '
        Me.Parast1DataGridViewTextBoxColumn.DataPropertyName = "parast1"
        Me.Parast1DataGridViewTextBoxColumn.HeaderText = "parast1"
        Me.Parast1DataGridViewTextBoxColumn.Name = "Parast1DataGridViewTextBoxColumn"
        Me.Parast1DataGridViewTextBoxColumn.Visible = False
        '
        'Parast2DataGridViewTextBoxColumn
        '
        Me.Parast2DataGridViewTextBoxColumn.DataPropertyName = "parast2"
        Me.Parast2DataGridViewTextBoxColumn.HeaderText = "parast2"
        Me.Parast2DataGridViewTextBoxColumn.Name = "Parast2DataGridViewTextBoxColumn"
        Me.Parast2DataGridViewTextBoxColumn.Visible = False
        '
        'Parast3DataGridViewTextBoxColumn
        '
        Me.Parast3DataGridViewTextBoxColumn.DataPropertyName = "parast3"
        Me.Parast3DataGridViewTextBoxColumn.HeaderText = "parast3"
        Me.Parast3DataGridViewTextBoxColumn.Name = "Parast3DataGridViewTextBoxColumn"
        Me.Parast3DataGridViewTextBoxColumn.Visible = False
        '
        'ImeromDataGridViewTextBoxColumn
        '
        Me.ImeromDataGridViewTextBoxColumn.DataPropertyName = "imerom"
        Me.ImeromDataGridViewTextBoxColumn.HeaderText = "imerom"
        Me.ImeromDataGridViewTextBoxColumn.Name = "ImeromDataGridViewTextBoxColumn"
        Me.ImeromDataGridViewTextBoxColumn.Visible = False
        '
        'XrewsiDataGridViewTextBoxColumn
        '
        Me.XrewsiDataGridViewTextBoxColumn.DataPropertyName = "xrewsi"
        Me.XrewsiDataGridViewTextBoxColumn.HeaderText = "xrewsi"
        Me.XrewsiDataGridViewTextBoxColumn.Name = "XrewsiDataGridViewTextBoxColumn"
        Me.XrewsiDataGridViewTextBoxColumn.Visible = False
        '
        'XrewseistimologiapraktoreiouBindingSource
        '
        Me.XrewseistimologiapraktoreiouBindingSource.DataMember = "xrewseis_timologia_praktoreiou"
        Me.XrewseistimologiapraktoreiouBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'XrewseispraktoreiaBindingSource
        '
        Me.XrewseispraktoreiaBindingSource.DataMember = "xrewseispraktoreia"
        Me.XrewseispraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'XrewseispraktoreiaTableAdapter
        '
        Me.XrewseispraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'TimologiaBindingSource
        '
        Me.TimologiaBindingSource.DataMember = "timologia"
        Me.TimologiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimologiaTableAdapter
        '
        Me.TimologiaTableAdapter.ClearBeforeFill = True
        '
        'XrewseisPrakt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 199)
        Me.Controls.Add(Me.XrewseisPraktDtGrd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "XrewseisPrakt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Χρεώσεις Πρακτορείου"
        CType(Me.XrewseisPraktDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseistimologiapraktoreiouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents XrewseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
    Friend WithEvents XrewseisPraktDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents XrewseistimologiapraktoreiouBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents kwdTimol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kwdXrewsPrakt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parast1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parast2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parast3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents imerom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xrewsi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KwdTimolDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KwdXrewsPraktDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parast1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parast2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parast3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImeromDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XrewsiDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
