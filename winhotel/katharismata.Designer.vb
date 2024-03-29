<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class katharismata
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
        Me.planoBtn = New System.Windows.Forms.Button()
        Me.FirstDateMonthPck = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DaysClean = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.SentWra = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.HomeLbl = New System.Windows.Forms.Label()
        Me.FoundChk = New System.Windows.Forms.CheckBox()
        Me.GrafeioForesCbx = New System.Windows.Forms.ComboBox()
        Me.HomeDayCbx = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.resultColumnTbx = New System.Windows.Forms.TextBox()
        Me.mexriDPck = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FirstColumnTbx = New System.Windows.Forms.TextBox()
        Me.LastColumnTbx = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SentBtn = New System.Windows.Forms.Button()
        Me.mexriKathPck = New System.Windows.Forms.DateTimePicker()
        Me.apoKathPck = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.wresLastTbx = New System.Windows.Forms.TextBox()
        Me.wresFirstTbx = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.KatharBtn = New System.Windows.Forms.Button()
        Me.bisKahPck = New System.Windows.Forms.DateTimePicker()
        Me.vomKathPck = New System.Windows.Forms.DateTimePicker()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.KatharismataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatharismataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katharismataTableAdapter()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.excelTbx = New System.Windows.Forms.TextBox()
        Me.StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusTableAdapter = New winhotel.dbhotelDataSetTableAdapters.statusTableAdapter()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatharismataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'planoBtn
        '
        Me.planoBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.planoBtn.Location = New System.Drawing.Point(208, 89)
        Me.planoBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.planoBtn.Name = "planoBtn"
        Me.planoBtn.Size = New System.Drawing.Size(53, 39)
        Me.planoBtn.TabIndex = 0
        Me.planoBtn.UseVisualStyleBackColor = True
        '
        'FirstDateMonthPck
        '
        Me.FirstDateMonthPck.CustomFormat = "dd/MM/yy"
        Me.FirstDateMonthPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FirstDateMonthPck.Location = New System.Drawing.Point(91, 36)
        Me.FirstDateMonthPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FirstDateMonthPck.Name = "FirstDateMonthPck"
        Me.FirstDateMonthPck.Size = New System.Drawing.Size(123, 24)
        Me.FirstDateMonthPck.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.DaysClean)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.SentWra)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.HomeLbl)
        Me.Panel1.Controls.Add(Me.FoundChk)
        Me.Panel1.Controls.Add(Me.GrafeioForesCbx)
        Me.Panel1.Controls.Add(Me.HomeDayCbx)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.resultColumnTbx)
        Me.Panel1.Controls.Add(Me.mexriDPck)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.FirstDateMonthPck)
        Me.Panel1.Controls.Add(Me.planoBtn)
        Me.Panel1.Controls.Add(Me.FirstColumnTbx)
        Me.Panel1.Controls.Add(Me.LastColumnTbx)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel1.Location = New System.Drawing.Point(16, 71)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 222)
        Me.Panel1.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(209, 191)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(237, 20)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "days clean after check out:"
        '
        'DaysClean
        '
        Me.DaysClean.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DaysClean.ForeColor = System.Drawing.Color.Blue
        Me.DaysClean.Location = New System.Drawing.Point(475, 190)
        Me.DaysClean.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DaysClean.MaxLength = 2
        Me.DaysClean.Name = "DaysClean"
        Me.DaysClean.Size = New System.Drawing.Size(41, 23)
        Me.DaysClean.TabIndex = 19
        Me.DaysClean.TabStop = False
        Me.DaysClean.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(405, 134)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 20)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "σεντ./ωρα:"
        '
        'SentWra
        '
        Me.SentWra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SentWra.ForeColor = System.Drawing.Color.Blue
        Me.SentWra.Location = New System.Drawing.Point(475, 158)
        Me.SentWra.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SentWra.MaxLength = 2
        Me.SentWra.Name = "SentWra"
        Me.SentWra.Size = New System.Drawing.Size(41, 23)
        Me.SentWra.TabIndex = 17
        Me.SentWra.TabStop = False
        Me.SentWra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(140, 130)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(145, 20)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "γραφείο φορές:"
        '
        'HomeLbl
        '
        Me.HomeLbl.AutoSize = True
        Me.HomeLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.HomeLbl.ForeColor = System.Drawing.Color.White
        Me.HomeLbl.Location = New System.Drawing.Point(5, 130)
        Me.HomeLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.HomeLbl.Name = "HomeLbl"
        Me.HomeLbl.Size = New System.Drawing.Size(116, 20)
        Me.HomeLbl.TabIndex = 15
        Me.HomeLbl.Text = "home ημέρα:"
        '
        'FoundChk
        '
        Me.FoundChk.AutoSize = True
        Me.FoundChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FoundChk.Checked = True
        Me.FoundChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FoundChk.ForeColor = System.Drawing.Color.White
        Me.FoundChk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.FoundChk.Location = New System.Drawing.Point(313, 159)
        Me.FoundChk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FoundChk.Name = "FoundChk"
        Me.FoundChk.Size = New System.Drawing.Size(110, 22)
        Me.FoundChk.TabIndex = 14
        Me.FoundChk.Text = "Φουντουλ."
        Me.FoundChk.UseVisualStyleBackColor = True
        '
        'GrafeioForesCbx
        '
        Me.GrafeioForesCbx.ForeColor = System.Drawing.Color.Blue
        Me.GrafeioForesCbx.FormattingEnabled = True
        Me.GrafeioForesCbx.Location = New System.Drawing.Point(248, 154)
        Me.GrafeioForesCbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GrafeioForesCbx.Name = "GrafeioForesCbx"
        Me.GrafeioForesCbx.Size = New System.Drawing.Size(52, 26)
        Me.GrafeioForesCbx.TabIndex = 13
        '
        'HomeDayCbx
        '
        Me.HomeDayCbx.ForeColor = System.Drawing.Color.Blue
        Me.HomeDayCbx.FormattingEnabled = True
        Me.HomeDayCbx.Location = New System.Drawing.Point(80, 154)
        Me.HomeDayCbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.HomeDayCbx.Name = "HomeDayCbx"
        Me.HomeDayCbx.Size = New System.Drawing.Size(71, 26)
        Me.HomeDayCbx.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(416, 108)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 17)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "results:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(249, 39)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 18)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "μέχρι:"
        '
        'resultColumnTbx
        '
        Me.resultColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.resultColumnTbx.Location = New System.Drawing.Point(489, 102)
        Me.resultColumnTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.resultColumnTbx.MaxLength = 2
        Me.resultColumnTbx.Name = "resultColumnTbx"
        Me.resultColumnTbx.Size = New System.Drawing.Size(41, 23)
        Me.resultColumnTbx.TabIndex = 10
        Me.resultColumnTbx.TabStop = False
        Me.resultColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mexriDPck
        '
        Me.mexriDPck.CustomFormat = "dd/MM/yy"
        Me.mexriDPck.Enabled = False
        Me.mexriDPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mexriDPck.Location = New System.Drawing.Point(313, 36)
        Me.mexriDPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mexriDPck.Name = "mexriDPck"
        Me.mexriDPck.Size = New System.Drawing.Size(123, 24)
        Me.mexriDPck.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(357, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "columns:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(27, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "από:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(19, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Πλάνο Εβδομάδας"
        '
        'FirstColumnTbx
        '
        Me.FirstColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FirstColumnTbx.Location = New System.Drawing.Point(428, 70)
        Me.FirstColumnTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FirstColumnTbx.MaxLength = 1
        Me.FirstColumnTbx.Name = "FirstColumnTbx"
        Me.FirstColumnTbx.Size = New System.Drawing.Size(41, 23)
        Me.FirstColumnTbx.TabIndex = 2
        Me.FirstColumnTbx.TabStop = False
        Me.FirstColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LastColumnTbx
        '
        Me.LastColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LastColumnTbx.Location = New System.Drawing.Point(489, 70)
        Me.LastColumnTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LastColumnTbx.MaxLength = 2
        Me.LastColumnTbx.Name = "LastColumnTbx"
        Me.LastColumnTbx.Size = New System.Drawing.Size(41, 23)
        Me.LastColumnTbx.TabIndex = 3
        Me.LastColumnTbx.TabStop = False
        Me.LastColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.SentBtn)
        Me.Panel2.Controls.Add(Me.mexriKathPck)
        Me.Panel2.Controls.Add(Me.apoKathPck)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel2.Location = New System.Drawing.Point(16, 300)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(543, 48)
        Me.Panel2.TabIndex = 3
        Me.Panel2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(269, 47)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "μέχρι:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "από:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(17, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(369, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Σεντόνια - Πετσέτες - αριθμ. Καθαριστριών"
        '
        'SentBtn
        '
        Me.SentBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.SentBtn.Location = New System.Drawing.Point(208, 101)
        Me.SentBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SentBtn.Name = "SentBtn"
        Me.SentBtn.Size = New System.Drawing.Size(53, 28)
        Me.SentBtn.TabIndex = 6
        Me.SentBtn.UseVisualStyleBackColor = True
        '
        'mexriKathPck
        '
        Me.mexriKathPck.CustomFormat = "dd/MM/yy"
        Me.mexriKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mexriKathPck.Location = New System.Drawing.Point(329, 42)
        Me.mexriKathPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mexriKathPck.Name = "mexriKathPck"
        Me.mexriKathPck.Size = New System.Drawing.Size(123, 23)
        Me.mexriKathPck.TabIndex = 5
        '
        'apoKathPck
        '
        Me.apoKathPck.CustomFormat = "dd/MM/yy"
        Me.apoKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.apoKathPck.Location = New System.Drawing.Point(95, 43)
        Me.apoKathPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.apoKathPck.Name = "apoKathPck"
        Me.apoKathPck.Size = New System.Drawing.Size(123, 23)
        Me.apoKathPck.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.wresLastTbx)
        Me.Panel3.Controls.Add(Me.wresFirstTbx)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.KatharBtn)
        Me.Panel3.Controls.Add(Me.bisKahPck)
        Me.Panel3.Controls.Add(Me.vomKathPck)
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel3.Location = New System.Drawing.Point(16, 298)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(543, 142)
        Me.Panel3.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.Location = New System.Drawing.Point(357, 11)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "columns:"
        '
        'wresLastTbx
        '
        Me.wresLastTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.wresLastTbx.Location = New System.Drawing.Point(489, 6)
        Me.wresLastTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.wresLastTbx.MaxLength = 2
        Me.wresLastTbx.Name = "wresLastTbx"
        Me.wresLastTbx.Size = New System.Drawing.Size(41, 23)
        Me.wresLastTbx.TabIndex = 11
        Me.wresLastTbx.TabStop = False
        Me.wresLastTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'wresFirstTbx
        '
        Me.wresFirstTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.wresFirstTbx.Location = New System.Drawing.Point(428, 6)
        Me.wresFirstTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.wresFirstTbx.MaxLength = 1
        Me.wresFirstTbx.Name = "wresFirstTbx"
        Me.wresFirstTbx.Size = New System.Drawing.Size(41, 23)
        Me.wresFirstTbx.TabIndex = 10
        Me.wresFirstTbx.TabStop = False
        Me.wresFirstTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(269, 47)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "μέχρι:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(48, 47)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "από:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(17, 11)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 20)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Καθαρίστριες (ώρες)"
        '
        'KatharBtn
        '
        Me.KatharBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.KatharBtn.Location = New System.Drawing.Point(208, 101)
        Me.KatharBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KatharBtn.Name = "KatharBtn"
        Me.KatharBtn.Size = New System.Drawing.Size(53, 28)
        Me.KatharBtn.TabIndex = 6
        Me.KatharBtn.UseVisualStyleBackColor = True
        '
        'bisKahPck
        '
        Me.bisKahPck.CustomFormat = "dd/MM/yy"
        Me.bisKahPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.bisKahPck.Location = New System.Drawing.Point(329, 42)
        Me.bisKahPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.bisKahPck.Name = "bisKahPck"
        Me.bisKahPck.Size = New System.Drawing.Size(123, 23)
        Me.bisKahPck.TabIndex = 5
        '
        'vomKathPck
        '
        Me.vomKathPck.CustomFormat = "dd/MM/yy"
        Me.vomKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.vomKathPck.Location = New System.Drawing.Point(95, 43)
        Me.vomKathPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.vomKathPck.Name = "vomKathPck"
        Me.vomKathPck.Size = New System.Drawing.Size(123, 23)
        Me.vomKathPck.TabIndex = 4
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KatharismataBindingSource
        '
        Me.KatharismataBindingSource.DataMember = "katharismata"
        Me.KatharismataBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatharismataTableAdapter
        '
        Me.KatharismataTableAdapter.ClearBeforeFill = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(33, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Excel Αρχείο:"
        '
        'excelTbx
        '
        Me.excelTbx.Location = New System.Drawing.Point(177, 22)
        Me.excelTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.excelTbx.Name = "excelTbx"
        Me.excelTbx.Size = New System.Drawing.Size(343, 22)
        Me.excelTbx.TabIndex = 6
        '
        'StatusBindingSource
        '
        Me.StatusBindingSource.DataMember = "status"
        Me.StatusBindingSource.DataSource = Me.DbhotelDataSet
        '
        'StatusTableAdapter
        '
        Me.StatusTableAdapter.ClearBeforeFill = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(16, 448)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar1.Maximum = 110
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(543, 28)
        Me.ProgressBar1.TabIndex = 7
        '
        'katharismata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 476)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.excelTbx)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "katharismata"
        Me.Text = "Καθαρίσματα DOMISI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatharismataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents planoBtn As System.Windows.Forms.Button
    Friend WithEvents FirstDateMonthPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LastColumnTbx As System.Windows.Forms.TextBox
    Friend WithEvents FirstColumnTbx As System.Windows.Forms.TextBox
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KatharismataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatharismataTableAdapter As winhotel.dbhotelDataSetTableAdapters.katharismataTableAdapter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SentBtn As System.Windows.Forms.Button
    Friend WithEvents mexriKathPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents apoKathPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents KatharBtn As System.Windows.Forms.Button
    Friend WithEvents bisKahPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents vomKathPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents excelTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents resultColumnTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents wresLastTbx As System.Windows.Forms.TextBox
    Friend WithEvents wresFirstTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mexriDPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusTableAdapter As winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
    Friend WithEvents HomeDayCbx As System.Windows.Forms.ComboBox
    Friend WithEvents GrafeioForesCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents HomeLbl As System.Windows.Forms.Label
    Friend WithEvents FoundChk As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SentWra As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DaysClean As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
