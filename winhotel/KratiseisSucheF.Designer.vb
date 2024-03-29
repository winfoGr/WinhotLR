<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KratiseisSucheF
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.KratiseisenilikesDataGridView = New System.Windows.Forms.DataGridView()
        Me.kwd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.afixi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anaxwrisi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KratiseisenilikesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.KratiseisenilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.KratiseisenilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter()
        Me.KratiseisenilikesTableAdapter1 = New winhotel.dbhotelDataSet1TableAdapters.kratiseisenilikesTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.olaRdb = New System.Windows.Forms.RadioButton()
        Me.villasRdb = New System.Windows.Forms.RadioButton()
        Me.hotelRdb = New System.Windows.Forms.RadioButton()
        CType(Me.KratiseisenilikesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KratiseisenilikesDataGridView
        '
        Me.KratiseisenilikesDataGridView.AllowUserToAddRows = False
        Me.KratiseisenilikesDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KratiseisenilikesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.KratiseisenilikesDataGridView.AutoGenerateColumns = False
        Me.KratiseisenilikesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kwd, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.afixi, Me.anaxwrisi})
        Me.KratiseisenilikesDataGridView.DataSource = Me.KratiseisenilikesBindingSource1
        Me.KratiseisenilikesDataGridView.Location = New System.Drawing.Point(4, 110)
        Me.KratiseisenilikesDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.KratiseisenilikesDataGridView.Name = "KratiseisenilikesDataGridView"
        Me.KratiseisenilikesDataGridView.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.KratiseisenilikesDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.KratiseisenilikesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.KratiseisenilikesDataGridView.Size = New System.Drawing.Size(631, 328)
        Me.KratiseisenilikesDataGridView.TabIndex = 1
        '
        'kwd
        '
        Me.kwd.DataPropertyName = "kwd"
        Me.kwd.HeaderText = "kwd"
        Me.kwd.Name = "kwd"
        Me.kwd.ReadOnly = True
        Me.kwd.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "arithmos"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.HeaderText = "Αρ. Κρ."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "dwmatio"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "Αρ. Δωμ."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "onomateponimo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ονοματεπώνυμο"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 200
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "voucher"
        Me.DataGridViewTextBoxColumn4.HeaderText = "No Voucher"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'afixi
        '
        Me.afixi.DataPropertyName = "afixi"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Maroon
        Me.afixi.DefaultCellStyle = DataGridViewCellStyle4
        Me.afixi.HeaderText = "Άφιξη"
        Me.afixi.Name = "afixi"
        Me.afixi.ReadOnly = True
        '
        'anaxwrisi
        '
        Me.anaxwrisi.DataPropertyName = "anaxwrisi"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.anaxwrisi.DefaultCellStyle = DataGridViewCellStyle5
        Me.anaxwrisi.HeaderText = "Αναχώρηση"
        Me.anaxwrisi.Name = "anaxwrisi"
        Me.anaxwrisi.ReadOnly = True
        '
        'KratiseisenilikesBindingSource1
        '
        Me.KratiseisenilikesBindingSource1.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource1.DataSource = Me.DbhotelDataSet1
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.EnforceConstraints = False
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisenilikesBindingSource
        '
        Me.KratiseisenilikesBindingSource.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(29, 27)
        Me.TextBox1.MaxLength = 6
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(90, 22)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteCustomSource.AddRange(New String() {"arithmos", "ARCH", "IKR", "ALE", "MIC", "IRI", "AFR", "IPER", "SF6", "PERS", "MAIL", "EEAN", "THOI", "UB4C", "BLUE", "UB3C", "UB1Y", "GRY", "GRE", "WHI", "SAN", "COC", "MARU", "MAVI", "E21", "E22", "K1", "K6", "K7", "E1", "E10", "E13", "E14", "E2", "E3", "E11", "E12", "E15", "K2", "K5", "K4", "K3"})
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox2.Location = New System.Drawing.Point(226, 30)
        Me.TextBox2.MaxLength = 8
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(86, 22)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(100, 81)
        Me.TextBox3.MaxLength = 15
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(181, 22)
        Me.TextBox3.TabIndex = 4
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(305, 81)
        Me.TextBox4.MaxLength = 10
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(128, 22)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Α/Α Κράτησης:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(182, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Αρ.Δωματίου:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(73, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ονοματεπώνυμο:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(287, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "No. Voucher:"
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button13.ForeColor = System.Drawing.Color.Black
        Me.Button13.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.Location = New System.Drawing.Point(125, 27)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(28, 28)
        Me.Button13.TabIndex = 13
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.Button2.Location = New System.Drawing.Point(465, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 34)
        Me.Button2.TabIndex = 11
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(318, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 14
        Me.Button1.UseVisualStyleBackColor = False
        '
        'KratiseisenilikesTableAdapter
        '
        Me.KratiseisenilikesTableAdapter.ClearBeforeFill = True
        '
        'KratiseisenilikesTableAdapter1
        '
        Me.KratiseisenilikesTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.aliasTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.dwmatiastatusTableAdapter = Nothing
        Me.TableAdapterManager.dwmatiaTableAdapter = Nothing
        Me.TableAdapterManager.etaireiaTableAdapter = Nothing
        Me.TableAdapterManager.forosdiamonisTableAdapter = Nothing
        Me.TableAdapterManager.katigoriesTableAdapter = Nothing
        Me.TableAdapterManager.klinesTableAdapter = Nothing
        Me.TableAdapterManager.kratiseisTableAdapter = Nothing
        Me.TableAdapterManager.praktoreiaTableAdapter = Nothing
        Me.TableAdapterManager.tipoiTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.vilapraktoreia1TableAdapter = Nothing
        '
        'olaRdb
        '
        Me.olaRdb.AutoSize = True
        Me.olaRdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.olaRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.olaRdb.Checked = True
        Me.olaRdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.olaRdb.ForeColor = System.Drawing.Color.Maroon
        Me.olaRdb.Location = New System.Drawing.Point(419, 31)
        Me.olaRdb.Name = "olaRdb"
        Me.olaRdb.Size = New System.Drawing.Size(45, 24)
        Me.olaRdb.TabIndex = 15
        Me.olaRdb.TabStop = True
        Me.olaRdb.Text = "all"
        Me.olaRdb.UseVisualStyleBackColor = False
        '
        'villasRdb
        '
        Me.villasRdb.AutoSize = True
        Me.villasRdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.villasRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.villasRdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.villasRdb.ForeColor = System.Drawing.Color.Maroon
        Me.villasRdb.Location = New System.Drawing.Point(465, 31)
        Me.villasRdb.Name = "villasRdb"
        Me.villasRdb.Size = New System.Drawing.Size(66, 24)
        Me.villasRdb.TabIndex = 16
        Me.villasRdb.Text = "villas"
        Me.villasRdb.UseVisualStyleBackColor = False
        '
        'hotelRdb
        '
        Me.hotelRdb.AutoSize = True
        Me.hotelRdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.hotelRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.hotelRdb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.hotelRdb.ForeColor = System.Drawing.Color.Maroon
        Me.hotelRdb.Location = New System.Drawing.Point(532, 31)
        Me.hotelRdb.Name = "hotelRdb"
        Me.hotelRdb.Size = New System.Drawing.Size(67, 24)
        Me.hotelRdb.TabIndex = 17
        Me.hotelRdb.Text = "hotel"
        Me.hotelRdb.UseVisualStyleBackColor = False
        '
        'KratiseisSucheF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 458)
        Me.Controls.Add(Me.hotelRdb)
        Me.Controls.Add(Me.villasRdb)
        Me.Controls.Add(Me.olaRdb)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.KratiseisenilikesDataGridView)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "KratiseisSucheF"
        Me.Text = "Επιλογή Κράτησης"
        CType(Me.KratiseisenilikesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KratiseisenilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents KratiseisenilikesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents kwd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents afixi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anaxwrisi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents KratiseisenilikesBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter1 As winhotel.dbhotelDataSet1TableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents olaRdb As System.Windows.Forms.RadioButton
    Friend WithEvents villasRdb As System.Windows.Forms.RadioButton
    Friend WithEvents hotelRdb As System.Windows.Forms.RadioButton
End Class
