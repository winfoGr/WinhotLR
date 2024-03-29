<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Problepsi
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
        Me.ProblepsiZentralPnl = New System.Windows.Forms.Panel
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.grid = New System.Windows.Forms.DataGridView
        Me.PreviousBtn = New System.Windows.Forms.Button
        Me.NextBtn = New System.Windows.Forms.Button
        Me.Problepsi3Pnl = New System.Windows.Forms.Panel
        Me.Problepsi1Pnl = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.EkdosiPck = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.MexriPck = New System.Windows.Forms.DateTimePicker
        Me.EktiposBtn = New System.Windows.Forms.Button
        Me.ProblepsiTbx = New System.Windows.Forms.TextBox
        Me.PraktLbl = New System.Windows.Forms.Label
        Me.EisprRdb = New System.Windows.Forms.RadioButton
        Me.StatusRdb = New System.Windows.Forms.RadioButton
        Me.KinisiEmfBtn = New System.Windows.Forms.Button
        Me.ProblepsiPck = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Problepsi2Pnl = New System.Windows.Forms.Panel
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.Main_curanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Main_curanteTableAdapter = New winhotel.dbhotelDataSetTableAdapters.main_curanteTableAdapter
        Me.ProblepsiZentralPnl.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Problepsi1Pnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Main_curanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProblepsiZentralPnl
        '
        Me.ProblepsiZentralPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.ProblepsiZentralPnl.Controls.Add(Me.grid)
        Me.ProblepsiZentralPnl.Controls.Add(Me.PreviousBtn)
        Me.ProblepsiZentralPnl.Controls.Add(Me.NextBtn)
        Me.ProblepsiZentralPnl.Controls.Add(Me.Problepsi3Pnl)
        Me.ProblepsiZentralPnl.Controls.Add(Me.Problepsi1Pnl)
        Me.ProblepsiZentralPnl.Controls.Add(Me.Problepsi2Pnl)
        Me.ProblepsiZentralPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ProblepsiZentralPnl.Location = New System.Drawing.Point(0, 0)
        Me.ProblepsiZentralPnl.Name = "ProblepsiZentralPnl"
        Me.ProblepsiZentralPnl.Size = New System.Drawing.Size(958, 567)
        Me.ProblepsiZentralPnl.TabIndex = 0
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(936, 228)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(10, 150)
        Me.CrystalReportViewer1.TabIndex = 13
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(706, 516)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(240, 15)
        Me.grid.TabIndex = 12
        Me.grid.Visible = False
        '
        'PreviousBtn
        '
        Me.PreviousBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PreviousBtn.ForeColor = System.Drawing.Color.Maroon
        Me.PreviousBtn.Image = Global.winhotel.My.Resources.Resources.LAST
        Me.PreviousBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PreviousBtn.Location = New System.Drawing.Point(311, 492)
        Me.PreviousBtn.Name = "PreviousBtn"
        Me.PreviousBtn.Size = New System.Drawing.Size(124, 39)
        Me.PreviousBtn.TabIndex = 11
        Me.PreviousBtn.Text = "Προηγούμενο Τριήμερο"
        Me.PreviousBtn.UseVisualStyleBackColor = True
        '
        'NextBtn
        '
        Me.NextBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NextBtn.ForeColor = System.Drawing.Color.Maroon
        Me.NextBtn.Image = Global.winhotel.My.Resources.Resources._NEXT
        Me.NextBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.NextBtn.Location = New System.Drawing.Point(470, 494)
        Me.NextBtn.Name = "NextBtn"
        Me.NextBtn.Size = New System.Drawing.Size(117, 37)
        Me.NextBtn.TabIndex = 10
        Me.NextBtn.Text = "Επόμενο Τριήμερο"
        Me.NextBtn.UseVisualStyleBackColor = True
        '
        'Problepsi3Pnl
        '
        Me.Problepsi3Pnl.AutoScroll = True
        Me.Problepsi3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Problepsi3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Problepsi3Pnl.Location = New System.Drawing.Point(23, 182)
        Me.Problepsi3Pnl.Name = "Problepsi3Pnl"
        Me.Problepsi3Pnl.Size = New System.Drawing.Size(899, 288)
        Me.Problepsi3Pnl.TabIndex = 2
        '
        'Problepsi1Pnl
        '
        Me.Problepsi1Pnl.BackColor = System.Drawing.Color.Silver
        Me.Problepsi1Pnl.Controls.Add(Me.Label3)
        Me.Problepsi1Pnl.Controls.Add(Me.EkdosiPck)
        Me.Problepsi1Pnl.Controls.Add(Me.Label2)
        Me.Problepsi1Pnl.Controls.Add(Me.MexriPck)
        Me.Problepsi1Pnl.Controls.Add(Me.EktiposBtn)
        Me.Problepsi1Pnl.Controls.Add(Me.ProblepsiTbx)
        Me.Problepsi1Pnl.Controls.Add(Me.PraktLbl)
        Me.Problepsi1Pnl.Controls.Add(Me.EisprRdb)
        Me.Problepsi1Pnl.Controls.Add(Me.StatusRdb)
        Me.Problepsi1Pnl.Controls.Add(Me.KinisiEmfBtn)
        Me.Problepsi1Pnl.Controls.Add(Me.ProblepsiPck)
        Me.Problepsi1Pnl.Controls.Add(Me.Label1)
        Me.Problepsi1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Problepsi1Pnl.Location = New System.Drawing.Point(23, 12)
        Me.Problepsi1Pnl.Name = "Problepsi1Pnl"
        Me.Problepsi1Pnl.Size = New System.Drawing.Size(899, 122)
        Me.Problepsi1Pnl.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(564, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 16)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Ημερομηνία Έκδοσης:"
        '
        'EkdosiPck
        '
        Me.EkdosiPck.Location = New System.Drawing.Point(603, 94)
        Me.EkdosiPck.Name = "EkdosiPck"
        Me.EkdosiPck.Size = New System.Drawing.Size(200, 22)
        Me.EkdosiPck.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(564, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 16)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "εκτύπωση μέχρι:"
        '
        'MexriPck
        '
        Me.MexriPck.Location = New System.Drawing.Point(603, 48)
        Me.MexriPck.Name = "MexriPck"
        Me.MexriPck.Size = New System.Drawing.Size(200, 22)
        Me.MexriPck.TabIndex = 51
        '
        'EktiposBtn
        '
        Me.EktiposBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktiposBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktiposBtn.Location = New System.Drawing.Point(809, 46)
        Me.EktiposBtn.Name = "EktiposBtn"
        Me.EktiposBtn.Size = New System.Drawing.Size(35, 31)
        Me.EktiposBtn.TabIndex = 50
        Me.EktiposBtn.UseVisualStyleBackColor = True
        '
        'ProblepsiTbx
        '
        Me.ProblepsiTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProblepsiTbx.ForeColor = System.Drawing.Color.Blue
        Me.ProblepsiTbx.Location = New System.Drawing.Point(382, 46)
        Me.ProblepsiTbx.Name = "ProblepsiTbx"
        Me.ProblepsiTbx.ReadOnly = True
        Me.ProblepsiTbx.Size = New System.Drawing.Size(169, 22)
        Me.ProblepsiTbx.TabIndex = 48
        Me.ProblepsiTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PraktLbl
        '
        Me.PraktLbl.AutoSize = True
        Me.PraktLbl.Location = New System.Drawing.Point(278, 48)
        Me.PraktLbl.Name = "PraktLbl"
        Me.PraktLbl.Size = New System.Drawing.Size(95, 16)
        Me.PraktLbl.TabIndex = 49
        Me.PraktLbl.Text = "Πρακτορείο:"
        '
        'EisprRdb
        '
        Me.EisprRdb.AutoSize = True
        Me.EisprRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EisprRdb.Location = New System.Drawing.Point(447, 3)
        Me.EisprRdb.Name = "EisprRdb"
        Me.EisprRdb.Size = New System.Drawing.Size(104, 20)
        Me.EisprRdb.TabIndex = 47
        Me.EisprRdb.Text = "Εισπράξεις"
        Me.EisprRdb.UseVisualStyleBackColor = True
        '
        'StatusRdb
        '
        Me.StatusRdb.AutoSize = True
        Me.StatusRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.StatusRdb.Checked = True
        Me.StatusRdb.Location = New System.Drawing.Point(343, 3)
        Me.StatusRdb.Name = "StatusRdb"
        Me.StatusRdb.Size = New System.Drawing.Size(69, 20)
        Me.StatusRdb.TabIndex = 46
        Me.StatusRdb.TabStop = True
        Me.StatusRdb.Text = "Status"
        Me.StatusRdb.UseVisualStyleBackColor = True
        '
        'KinisiEmfBtn
        '
        Me.KinisiEmfBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KinisiEmfBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.KinisiEmfBtn.Location = New System.Drawing.Point(406, 82)
        Me.KinisiEmfBtn.Name = "KinisiEmfBtn"
        Me.KinisiEmfBtn.Size = New System.Drawing.Size(45, 26)
        Me.KinisiEmfBtn.TabIndex = 45
        Me.KinisiEmfBtn.UseVisualStyleBackColor = True
        '
        'ProblepsiPck
        '
        Me.ProblepsiPck.Location = New System.Drawing.Point(51, 46)
        Me.ProblepsiPck.Name = "ProblepsiPck"
        Me.ProblepsiPck.Size = New System.Drawing.Size(200, 22)
        Me.ProblepsiPck.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = " από:"
        '
        'Problepsi2Pnl
        '
        Me.Problepsi2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Problepsi2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Problepsi2Pnl.Location = New System.Drawing.Point(23, 140)
        Me.Problepsi2Pnl.Name = "Problepsi2Pnl"
        Me.Problepsi2Pnl.Size = New System.Drawing.Size(899, 39)
        Me.Problepsi2Pnl.TabIndex = 1
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'EtaireiaBindingSource
        '
        Me.EtaireiaBindingSource.DataMember = "etaireia"
        Me.EtaireiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EtaireiaTableAdapter
        '
        Me.EtaireiaTableAdapter.ClearBeforeFill = True
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
        'Main_curanteBindingSource
        '
        Me.Main_curanteBindingSource.DataMember = "main_curante"
        Me.Main_curanteBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Main_curanteTableAdapter
        '
        Me.Main_curanteTableAdapter.ClearBeforeFill = True
        '
        'Problepsi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 567)
        Me.Controls.Add(Me.ProblepsiZentralPnl)
        Me.KeyPreview = True
        Me.Name = "Problepsi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Πρόβλεψη Κίνησης"
        Me.ProblepsiZentralPnl.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Problepsi1Pnl.ResumeLayout(False)
        Me.Problepsi1Pnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Main_curanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProblepsiZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents Problepsi3Pnl As System.Windows.Forms.Panel
    Friend WithEvents Problepsi1Pnl As System.Windows.Forms.Panel
    Friend WithEvents StatusRdb As System.Windows.Forms.RadioButton
    Friend WithEvents KinisiEmfBtn As System.Windows.Forms.Button
    Friend WithEvents ProblepsiPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Problepsi2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EisprRdb As System.Windows.Forms.RadioButton
    Friend WithEvents ProblepsiTbx As System.Windows.Forms.TextBox
    Friend WithEvents PraktLbl As System.Windows.Forms.Label
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents PreviousBtn As System.Windows.Forms.Button
    Friend WithEvents NextBtn As System.Windows.Forms.Button
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents EktiposBtn As System.Windows.Forms.Button
    Friend WithEvents MexriPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents EkdosiPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents Main_curanteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Main_curanteTableAdapter As winhotel.dbhotelDataSetTableAdapters.main_curanteTableAdapter
End Class
