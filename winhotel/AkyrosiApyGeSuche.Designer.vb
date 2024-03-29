<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AkyrosiApyGeSuche
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.EpanekdosiDgrdView = New System.Windows.Forms.DataGridView
        Me.EpanekdositimologiouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.KratiseisenilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EpanekdositimologiouTableAdapter = New winhotel.dbhotelDataSetTableAdapters.epanekdositimologiouTableAdapter
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
        Me.KratiseisenilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
        Me.GramatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GramatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.gramatiaTableAdapter
        Me.KwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GEAkyrosiDgrdView = New System.Windows.Forms.DataGridView
        Me.GramatiaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.KwdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImerominiaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnomaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PosoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimkwdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImerominiaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EponimiaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AfmDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SynolaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.EpanekdosiDgrdView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EpanekdositimologiouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GramatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GEAkyrosiDgrdView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GramatiaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EpanekdosiDgrdView
        '
        Me.EpanekdosiDgrdView.AllowUserToAddRows = False
        Me.EpanekdosiDgrdView.AllowUserToDeleteRows = False
        Me.EpanekdosiDgrdView.AutoGenerateColumns = False
        Me.EpanekdosiDgrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EpanekdosiDgrdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TimkwdDataGridViewTextBoxColumn, Me.AaDataGridViewTextBoxColumn, Me.ImerominiaDataGridViewTextBoxColumn, Me.EponimiaDataGridViewTextBoxColumn, Me.AfmDataGridViewTextBoxColumn, Me.SynolaDataGridViewTextBoxColumn})
        Me.EpanekdosiDgrdView.DataSource = Me.EpanekdositimologiouBindingSource
        Me.EpanekdosiDgrdView.Location = New System.Drawing.Point(0, 146)
        Me.EpanekdosiDgrdView.Name = "EpanekdosiDgrdView"
        Me.EpanekdosiDgrdView.ReadOnly = True
        Me.EpanekdosiDgrdView.Size = New System.Drawing.Size(612, 95)
        Me.EpanekdosiDgrdView.TabIndex = 0
        '
        'EpanekdositimologiouBindingSource
        '
        Me.EpanekdositimologiouBindingSource.DataMember = "epanekdositimologiou"
        Me.EpanekdositimologiouBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisenilikesBindingSource
        '
        Me.KratiseisenilikesBindingSource.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EpanekdositimologiouTableAdapter
        '
        Me.EpanekdositimologiouTableAdapter.ClearBeforeFill = True
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
        'KratiseisenilikesTableAdapter
        '
        Me.KratiseisenilikesTableAdapter.ClearBeforeFill = True
        '
        'GramatiaBindingSource
        '
        Me.GramatiaBindingSource.DataMember = "gramatia"
        Me.GramatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'GramatiaTableAdapter
        '
        Me.GramatiaTableAdapter.ClearBeforeFill = True
        '
        'KwdDataGridViewTextBoxColumn
        '
        Me.KwdDataGridViewTextBoxColumn.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn.HeaderText = "kwd"
        Me.KwdDataGridViewTextBoxColumn.Name = "KwdDataGridViewTextBoxColumn"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "kwd"
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'GEAkyrosiDgrdView
        '
        Me.GEAkyrosiDgrdView.AllowUserToAddRows = False
        Me.GEAkyrosiDgrdView.AllowUserToDeleteRows = False
        Me.GEAkyrosiDgrdView.AutoGenerateColumns = False
        Me.GEAkyrosiDgrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GEAkyrosiDgrdView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KwdDataGridViewTextBoxColumn1, Me.AaDataGridViewTextBoxColumn1, Me.ImerominiaDataGridViewTextBoxColumn1, Me.OnomaDataGridViewTextBoxColumn, Me.PosoDataGridViewTextBoxColumn})
        Me.GEAkyrosiDgrdView.DataSource = Me.GramatiaBindingSource1
        Me.GEAkyrosiDgrdView.Location = New System.Drawing.Point(85, 2)
        Me.GEAkyrosiDgrdView.Name = "GEAkyrosiDgrdView"
        Me.GEAkyrosiDgrdView.ReadOnly = True
        Me.GEAkyrosiDgrdView.Size = New System.Drawing.Size(527, 150)
        Me.GEAkyrosiDgrdView.TabIndex = 1
        '
        'GramatiaBindingSource1
        '
        Me.GramatiaBindingSource1.DataMember = "gramatia"
        Me.GramatiaBindingSource1.DataSource = Me.DbhotelDataSet
        '
        'KwdDataGridViewTextBoxColumn1
        '
        Me.KwdDataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn1.HeaderText = "kwd"
        Me.KwdDataGridViewTextBoxColumn1.Name = "KwdDataGridViewTextBoxColumn1"
        Me.KwdDataGridViewTextBoxColumn1.ReadOnly = True
        Me.KwdDataGridViewTextBoxColumn1.Visible = False
        '
        'AaDataGridViewTextBoxColumn1
        '
        Me.AaDataGridViewTextBoxColumn1.DataPropertyName = "aa"
        Me.AaDataGridViewTextBoxColumn1.HeaderText = "A/A"
        Me.AaDataGridViewTextBoxColumn1.Name = "AaDataGridViewTextBoxColumn1"
        Me.AaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.AaDataGridViewTextBoxColumn1.Width = 70
        '
        'ImerominiaDataGridViewTextBoxColumn1
        '
        Me.ImerominiaDataGridViewTextBoxColumn1.DataPropertyName = "imerominia"
        Me.ImerominiaDataGridViewTextBoxColumn1.HeaderText = "Ημερ/νία"
        Me.ImerominiaDataGridViewTextBoxColumn1.Name = "ImerominiaDataGridViewTextBoxColumn1"
        Me.ImerominiaDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'OnomaDataGridViewTextBoxColumn
        '
        Me.OnomaDataGridViewTextBoxColumn.DataPropertyName = "onoma"
        Me.OnomaDataGridViewTextBoxColumn.HeaderText = "Πελάτης"
        Me.OnomaDataGridViewTextBoxColumn.Name = "OnomaDataGridViewTextBoxColumn"
        Me.OnomaDataGridViewTextBoxColumn.ReadOnly = True
        Me.OnomaDataGridViewTextBoxColumn.Width = 180
        '
        'PosoDataGridViewTextBoxColumn
        '
        Me.PosoDataGridViewTextBoxColumn.DataPropertyName = "poso"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PosoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PosoDataGridViewTextBoxColumn.HeaderText = "Ποσό"
        Me.PosoDataGridViewTextBoxColumn.Name = "PosoDataGridViewTextBoxColumn"
        Me.PosoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TimkwdDataGridViewTextBoxColumn
        '
        Me.TimkwdDataGridViewTextBoxColumn.DataPropertyName = "timkwd"
        Me.TimkwdDataGridViewTextBoxColumn.HeaderText = "timkwd"
        Me.TimkwdDataGridViewTextBoxColumn.Name = "TimkwdDataGridViewTextBoxColumn"
        Me.TimkwdDataGridViewTextBoxColumn.ReadOnly = True
        Me.TimkwdDataGridViewTextBoxColumn.Visible = False
        '
        'AaDataGridViewTextBoxColumn
        '
        Me.AaDataGridViewTextBoxColumn.DataPropertyName = "aa"
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        Me.AaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.AaDataGridViewTextBoxColumn.HeaderText = "Α/Α"
        Me.AaDataGridViewTextBoxColumn.Name = "AaDataGridViewTextBoxColumn"
        Me.AaDataGridViewTextBoxColumn.ReadOnly = True
        Me.AaDataGridViewTextBoxColumn.Width = 80
        '
        'ImerominiaDataGridViewTextBoxColumn
        '
        Me.ImerominiaDataGridViewTextBoxColumn.DataPropertyName = "imerominia"
        Me.ImerominiaDataGridViewTextBoxColumn.HeaderText = "Ημερ/νία"
        Me.ImerominiaDataGridViewTextBoxColumn.Name = "ImerominiaDataGridViewTextBoxColumn"
        Me.ImerominiaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ImerominiaDataGridViewTextBoxColumn.Width = 80
        '
        'EponimiaDataGridViewTextBoxColumn
        '
        Me.EponimiaDataGridViewTextBoxColumn.DataPropertyName = "eponimia"
        Me.EponimiaDataGridViewTextBoxColumn.HeaderText = "Πελάτης"
        Me.EponimiaDataGridViewTextBoxColumn.Name = "EponimiaDataGridViewTextBoxColumn"
        Me.EponimiaDataGridViewTextBoxColumn.ReadOnly = True
        Me.EponimiaDataGridViewTextBoxColumn.Width = 180
        '
        'AfmDataGridViewTextBoxColumn
        '
        Me.AfmDataGridViewTextBoxColumn.DataPropertyName = "afm"
        Me.AfmDataGridViewTextBoxColumn.HeaderText = "ΑΦΜ"
        Me.AfmDataGridViewTextBoxColumn.Name = "AfmDataGridViewTextBoxColumn"
        Me.AfmDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SynolaDataGridViewTextBoxColumn
        '
        Me.SynolaDataGridViewTextBoxColumn.DataPropertyName = "synola"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SynolaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.SynolaDataGridViewTextBoxColumn.HeaderText = "Συν.Ποσό"
        Me.SynolaDataGridViewTextBoxColumn.Name = "SynolaDataGridViewTextBoxColumn"
        Me.SynolaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AkyrosiApyGeSuche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 241)
        Me.Controls.Add(Me.GEAkyrosiDgrdView)
        Me.Controls.Add(Me.EpanekdosiDgrdView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AkyrosiApyGeSuche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AkyrosiApyGeSuche"
        CType(Me.EpanekdosiDgrdView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EpanekdositimologiouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GramatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GEAkyrosiDgrdView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GramatiaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EpanekdosiDgrdView As System.Windows.Forms.DataGridView
    Friend WithEvents EpanekdositimologiouBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EpanekdositimologiouTableAdapter As winhotel.dbhotelDataSetTableAdapters.epanekdositimologiouTableAdapter
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents KratiseisenilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents GramatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GramatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.gramatiaTableAdapter
    Friend WithEvents KwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GEAkyrosiDgrdView As System.Windows.Forms.DataGridView
    Friend WithEvents GramatiaBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TimkwdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImerominiaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EponimiaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AfmDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SynolaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KwdDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImerominiaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnomaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PosoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
