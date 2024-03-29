<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OnomataKratisisFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OnomataKratisisFrm))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EnilikesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.EnilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.EnilikesDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.genisi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ilikia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diabatirio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.palaios = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EnilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.enilikesTableAdapter()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.KratiseisenilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisenilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter()
        Me.onomateponimo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.voucher = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.afixi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anaxwrisi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dwmatio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.EnilikesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EnilikesBindingNavigator.SuspendLayout()
        CType(Me.EnilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnilikesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EnilikesBindingNavigator
        '
        Me.EnilikesBindingNavigator.AddNewItem = Nothing
        Me.EnilikesBindingNavigator.BindingSource = Me.EnilikesBindingSource
        Me.EnilikesBindingNavigator.CountItem = Nothing
        Me.EnilikesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.EnilikesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripButton, Me.BindingNavigatorDeleteItem})
        Me.EnilikesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.EnilikesBindingNavigator.MoveFirstItem = Nothing
        Me.EnilikesBindingNavigator.MoveLastItem = Nothing
        Me.EnilikesBindingNavigator.MoveNextItem = Nothing
        Me.EnilikesBindingNavigator.MovePreviousItem = Nothing
        Me.EnilikesBindingNavigator.Name = "EnilikesBindingNavigator"
        Me.EnilikesBindingNavigator.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.EnilikesBindingNavigator.PositionItem = Nothing
        Me.EnilikesBindingNavigator.Size = New System.Drawing.Size(680, 25)
        Me.EnilikesBindingNavigator.TabIndex = 0
        Me.EnilikesBindingNavigator.Text = "BindingNavigator1"
        '
        'EnilikesBindingSource
        '
        Me.EnilikesBindingSource.DataMember = "enilikes"
        Me.EnilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.AutoSize = False
        Me.BindingNavigatorDeleteItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(103, 22)
        Me.BindingNavigatorDeleteItem.Text = "Διαγραφή"
        Me.BindingNavigatorDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BindingNavigatorDeleteItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.AutoSize = False
        Me.SaveToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripButton.Text = "Αποθήκευση"
        Me.SaveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'EnilikesDataGridView
        '
        Me.EnilikesDataGridView.AutoGenerateColumns = False
        Me.EnilikesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.genisi, Me.Ilikia, Me.diabatirio, Me.palaios})
        Me.EnilikesDataGridView.DataSource = Me.EnilikesBindingSource
        Me.EnilikesDataGridView.Location = New System.Drawing.Point(0, 29)
        Me.EnilikesDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.EnilikesDataGridView.Name = "EnilikesDataGridView"
        Me.EnilikesDataGridView.Size = New System.Drawing.Size(680, 126)
        Me.EnilikesDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.DataGridViewTextBoxColumn1.HeaderText = "kwd"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 70
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "kratisi"
        Me.DataGridViewTextBoxColumn2.HeaderText = "kratisi"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "onomateponimo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ονοματεπώνυμο"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 30
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'genisi
        '
        Me.genisi.DataPropertyName = "genisi"
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.genisi.DefaultCellStyle = DataGridViewCellStyle5
        Me.genisi.HeaderText = "Ημερ.Γέννησ."
        Me.genisi.Name = "genisi"
        Me.genisi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.genisi.ToolTipText = "HH/MM/XX"
        Me.genisi.Width = 113
        '
        'Ilikia
        '
        Me.Ilikia.HeaderText = "Ηλικία"
        Me.Ilikia.MaxInputLength = 2
        Me.Ilikia.Name = "Ilikia"
        Me.Ilikia.ReadOnly = True
        Me.Ilikia.Width = 55
        '
        'diabatirio
        '
        Me.diabatirio.DataPropertyName = "diabatirio"
        Me.diabatirio.HeaderText = "email"
        Me.diabatirio.MaxInputLength = 20
        Me.diabatirio.Name = "diabatirio"
        Me.diabatirio.Width = 150
        '
        'palaios
        '
        Me.palaios.DataPropertyName = "palaios"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.NullValue = "0"
        Me.palaios.DefaultCellStyle = DataGridViewCellStyle6
        Me.palaios.HeaderText = "Repeater"
        Me.palaios.Name = "palaios"
        '
        'EnilikesTableAdapter
        '
        Me.EnilikesTableAdapter.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.onomateponimo, Me.voucher, Me.afixi, Me.anaxwrisi, Me.dwmatio})
        Me.DataGridView1.DataSource = Me.KratiseisenilikesBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(0, 156)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(680, 105)
        Me.DataGridView1.TabIndex = 2
        '
        'KratiseisenilikesBindingSource
        '
        Me.KratiseisenilikesBindingSource.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KratiseisenilikesTableAdapter
        '
        Me.KratiseisenilikesTableAdapter.ClearBeforeFill = True
        '
        'onomateponimo
        '
        Me.onomateponimo.DataPropertyName = "onomateponimo"
        Me.onomateponimo.HeaderText = "search..."
        Me.onomateponimo.Name = "onomateponimo"
        Me.onomateponimo.Width = 200
        '
        'voucher
        '
        Me.voucher.DataPropertyName = "voucher"
        Me.voucher.HeaderText = "email"
        Me.voucher.Name = "voucher"
        Me.voucher.Width = 200
        '
        'afixi
        '
        Me.afixi.DataPropertyName = "afixi"
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.afixi.DefaultCellStyle = DataGridViewCellStyle7
        Me.afixi.HeaderText = "from"
        Me.afixi.Name = "afixi"
        Me.afixi.Width = 80
        '
        'anaxwrisi
        '
        Me.anaxwrisi.DataPropertyName = "anaxwrisi"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.anaxwrisi.DefaultCellStyle = DataGridViewCellStyle8
        Me.anaxwrisi.HeaderText = "until"
        Me.anaxwrisi.Name = "anaxwrisi"
        Me.anaxwrisi.Width = 80
        '
        'dwmatio
        '
        Me.dwmatio.DataPropertyName = "dwmatio"
        Me.dwmatio.HeaderText = "villa"
        Me.dwmatio.Name = "dwmatio"
        Me.dwmatio.Width = 60
        '
        'OnomataKratisisFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 264)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.EnilikesDataGridView)
        Me.Controls.Add(Me.EnilikesBindingNavigator)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "OnomataKratisisFrm"
        Me.Text = "Ενήλικες - Στοιχεία για βιβλίο Αστυνομίας"
        CType(Me.EnilikesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EnilikesBindingNavigator.ResumeLayout(False)
        Me.EnilikesBindingNavigator.PerformLayout()
        CType(Me.EnilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnilikesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EnilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EnilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.enilikesTableAdapter
    Friend WithEvents EnilikesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents EnilikesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents genisi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ilikia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diabatirio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents palaios As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents KratiseisenilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents onomateponimo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents voucher As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents afixi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anaxwrisi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dwmatio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
