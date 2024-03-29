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
        Me.components = New System.ComponentModel.Container
        Me.planoBtn = New System.Windows.Forms.Button
        Me.FirstDateMonthPck = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LastColumnTbx = New System.Windows.Forms.TextBox
        Me.FirstColumnTbx = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.resultColumnTbx = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SentBtn = New System.Windows.Forms.Button
        Me.mexriKathPck = New System.Windows.Forms.DateTimePicker
        Me.apoKathPck = New System.Windows.Forms.DateTimePicker
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.wresLastTbx = New System.Windows.Forms.TextBox
        Me.wresFirstTbx = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.KatharBtn = New System.Windows.Forms.Button
        Me.bisKahPck = New System.Windows.Forms.DateTimePicker
        Me.vomKathPck = New System.Windows.Forms.DateTimePicker
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.KatharismataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatharismataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katharismataTableAdapter
        Me.Label7 = New System.Windows.Forms.Label
        Me.excelTbx = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatharismataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'planoBtn
        '
        Me.planoBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.planoBtn.Location = New System.Drawing.Point(156, 79)
        Me.planoBtn.Name = "planoBtn"
        Me.planoBtn.Size = New System.Drawing.Size(40, 23)
        Me.planoBtn.TabIndex = 0
        Me.planoBtn.UseVisualStyleBackColor = True
        '
        'FirstDateMonthPck
        '
        Me.FirstDateMonthPck.CustomFormat = "dd/MM/yy"
        Me.FirstDateMonthPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FirstDateMonthPck.Location = New System.Drawing.Point(138, 38)
        Me.FirstDateMonthPck.Name = "FirstDateMonthPck"
        Me.FirstDateMonthPck.Size = New System.Drawing.Size(93, 21)
        Me.FirstDateMonthPck.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.FirstDateMonthPck)
        Me.Panel1.Controls.Add(Me.planoBtn)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 110)
        Me.Panel1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(90, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "από:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Πλάνο Μήνα"
        '
        'LastColumnTbx
        '
        Me.LastColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LastColumnTbx.Location = New System.Drawing.Point(367, 61)
        Me.LastColumnTbx.MaxLength = 2
        Me.LastColumnTbx.Name = "LastColumnTbx"
        Me.LastColumnTbx.Size = New System.Drawing.Size(32, 20)
        Me.LastColumnTbx.TabIndex = 3
        Me.LastColumnTbx.TabStop = False
        Me.LastColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FirstColumnTbx
        '
        Me.FirstColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FirstColumnTbx.Location = New System.Drawing.Point(321, 61)
        Me.FirstColumnTbx.MaxLength = 1
        Me.FirstColumnTbx.Name = "FirstColumnTbx"
        Me.FirstColumnTbx.Size = New System.Drawing.Size(32, 20)
        Me.FirstColumnTbx.TabIndex = 2
        Me.FirstColumnTbx.TabStop = False
        Me.FirstColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.resultColumnTbx)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.SentBtn)
        Me.Panel2.Controls.Add(Me.mexriKathPck)
        Me.Panel2.Controls.Add(Me.apoKathPck)
        Me.Panel2.Controls.Add(Me.LastColumnTbx)
        Me.Panel2.Controls.Add(Me.FirstColumnTbx)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel2.Location = New System.Drawing.Point(12, 170)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(407, 113)
        Me.Panel2.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label12.Location = New System.Drawing.Point(312, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "results:"
        '
        'resultColumnTbx
        '
        Me.resultColumnTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.resultColumnTbx.Location = New System.Drawing.Point(367, 87)
        Me.resultColumnTbx.MaxLength = 2
        Me.resultColumnTbx.Name = "resultColumnTbx"
        Me.resultColumnTbx.Size = New System.Drawing.Size(32, 20)
        Me.resultColumnTbx.TabIndex = 10
        Me.resultColumnTbx.TabStop = False
        Me.resultColumnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(268, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "columns:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(202, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "μέχρι:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "από:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Σεντόνια - Πετσέτες - αριθμ. Καθαριστριών"
        '
        'SentBtn
        '
        Me.SentBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.SentBtn.Location = New System.Drawing.Point(156, 82)
        Me.SentBtn.Name = "SentBtn"
        Me.SentBtn.Size = New System.Drawing.Size(40, 23)
        Me.SentBtn.TabIndex = 6
        Me.SentBtn.UseVisualStyleBackColor = True
        '
        'mexriKathPck
        '
        Me.mexriKathPck.CustomFormat = "dd/MM/yy"
        Me.mexriKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mexriKathPck.Location = New System.Drawing.Point(247, 34)
        Me.mexriKathPck.Name = "mexriKathPck"
        Me.mexriKathPck.Size = New System.Drawing.Size(93, 20)
        Me.mexriKathPck.TabIndex = 5
        '
        'apoKathPck
        '
        Me.apoKathPck.CustomFormat = "dd/MM/yy"
        Me.apoKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.apoKathPck.Location = New System.Drawing.Point(71, 35)
        Me.apoKathPck.Name = "apoKathPck"
        Me.apoKathPck.Size = New System.Drawing.Size(93, 20)
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
        Me.Panel3.Location = New System.Drawing.Point(12, 287)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(407, 113)
        Me.Panel3.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.Location = New System.Drawing.Point(268, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "columns:"
        '
        'wresLastTbx
        '
        Me.wresLastTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.wresLastTbx.Location = New System.Drawing.Point(367, 5)
        Me.wresLastTbx.MaxLength = 2
        Me.wresLastTbx.Name = "wresLastTbx"
        Me.wresLastTbx.Size = New System.Drawing.Size(32, 20)
        Me.wresLastTbx.TabIndex = 11
        Me.wresLastTbx.TabStop = False
        Me.wresLastTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'wresFirstTbx
        '
        Me.wresFirstTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.wresFirstTbx.Location = New System.Drawing.Point(321, 5)
        Me.wresFirstTbx.MaxLength = 1
        Me.wresFirstTbx.Name = "wresFirstTbx"
        Me.wresFirstTbx.Size = New System.Drawing.Size(32, 20)
        Me.wresFirstTbx.TabIndex = 10
        Me.wresFirstTbx.TabStop = False
        Me.wresFirstTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(202, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "μέχρι:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "από:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(13, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Καθαρίστριες (ώρες)"
        '
        'KatharBtn
        '
        Me.KatharBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.KatharBtn.Location = New System.Drawing.Point(156, 82)
        Me.KatharBtn.Name = "KatharBtn"
        Me.KatharBtn.Size = New System.Drawing.Size(40, 23)
        Me.KatharBtn.TabIndex = 6
        Me.KatharBtn.UseVisualStyleBackColor = True
        '
        'bisKahPck
        '
        Me.bisKahPck.CustomFormat = "dd/MM/yy"
        Me.bisKahPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.bisKahPck.Location = New System.Drawing.Point(247, 34)
        Me.bisKahPck.Name = "bisKahPck"
        Me.bisKahPck.Size = New System.Drawing.Size(93, 20)
        Me.bisKahPck.TabIndex = 5
        '
        'vomKathPck
        '
        Me.vomKathPck.CustomFormat = "dd/MM/yy"
        Me.vomKathPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.vomKathPck.Location = New System.Drawing.Point(71, 35)
        Me.vomKathPck.Name = "vomKathPck"
        Me.vomKathPck.Size = New System.Drawing.Size(93, 20)
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
        Me.Label7.Location = New System.Drawing.Point(25, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Excel Αρχείο:"
        '
        'excelTbx
        '
        Me.excelTbx.Location = New System.Drawing.Point(133, 18)
        Me.excelTbx.Name = "excelTbx"
        Me.excelTbx.Size = New System.Drawing.Size(258, 20)
        Me.excelTbx.TabIndex = 6
        '
        'katharismata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 448)
        Me.Controls.Add(Me.excelTbx)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
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
End Class
