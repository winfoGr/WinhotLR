<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PraktoreioFrm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.PraktoreioPnl = New System.Windows.Forms.Panel
        Me.SelfCheck3 = New System.Windows.Forms.CheckBox
        Me.kwdTbx = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBox14 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox13 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.XrewseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.XrewseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
        Me.PraktoreioPnl.SuspendLayout()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Επωνυμία:"
        '
        'TextBox1
        '
        Me.TextBox1.ForeColor = System.Drawing.Color.Blue
        Me.TextBox1.Location = New System.Drawing.Point(126, 60)
        Me.TextBox1.MaxLength = 49
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(279, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Τίτλος Τιμολογ:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(126, 97)
        Me.TextBox2.MaxLength = 49
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(404, 20)
        Me.TextBox2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Υπεύθυνος:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(126, 134)
        Me.TextBox3.MaxLength = 49
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(279, 20)
        Me.TextBox3.TabIndex = 5
        '
        'PraktoreioPnl
        '
        Me.PraktoreioPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PraktoreioPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PraktoreioPnl.Controls.Add(Me.SelfCheck3)
        Me.PraktoreioPnl.Controls.Add(Me.kwdTbx)
        Me.PraktoreioPnl.Controls.Add(Me.Label19)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox15)
        Me.PraktoreioPnl.Controls.Add(Me.Label18)
        Me.PraktoreioPnl.Controls.Add(Me.Label17)
        Me.PraktoreioPnl.Controls.Add(Me.Button1)
        Me.PraktoreioPnl.Controls.Add(Me.Label16)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox14)
        Me.PraktoreioPnl.Controls.Add(Me.Label15)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox13)
        Me.PraktoreioPnl.Controls.Add(Me.Label14)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox12)
        Me.PraktoreioPnl.Controls.Add(Me.Label13)
        Me.PraktoreioPnl.Controls.Add(Me.CheckBox2)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox11)
        Me.PraktoreioPnl.Controls.Add(Me.Label12)
        Me.PraktoreioPnl.Controls.Add(Me.Label11)
        Me.PraktoreioPnl.Controls.Add(Me.ComboBox1)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox10)
        Me.PraktoreioPnl.Controls.Add(Me.Label10)
        Me.PraktoreioPnl.Controls.Add(Me.CheckBox1)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox9)
        Me.PraktoreioPnl.Controls.Add(Me.Label9)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox8)
        Me.PraktoreioPnl.Controls.Add(Me.Label8)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox7)
        Me.PraktoreioPnl.Controls.Add(Me.Label7)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox6)
        Me.PraktoreioPnl.Controls.Add(Me.Label6)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox5)
        Me.PraktoreioPnl.Controls.Add(Me.Label5)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox4)
        Me.PraktoreioPnl.Controls.Add(Me.Label4)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox3)
        Me.PraktoreioPnl.Controls.Add(Me.Label3)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox2)
        Me.PraktoreioPnl.Controls.Add(Me.Label2)
        Me.PraktoreioPnl.Controls.Add(Me.TextBox1)
        Me.PraktoreioPnl.Controls.Add(Me.Label1)
        Me.PraktoreioPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PraktoreioPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PraktoreioPnl.Location = New System.Drawing.Point(0, 0)
        Me.PraktoreioPnl.Name = "PraktoreioPnl"
        Me.PraktoreioPnl.Size = New System.Drawing.Size(592, 560)
        Me.PraktoreioPnl.TabIndex = 0
        '
        'SelfCheck3
        '
        Me.SelfCheck3.AutoSize = True
        Me.SelfCheck3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SelfCheck3.Location = New System.Drawing.Point(435, 485)
        Me.SelfCheck3.Name = "SelfCheck3"
        Me.SelfCheck3.Size = New System.Drawing.Size(48, 17)
        Me.SelfCheck3.TabIndex = 39
        Me.SelfCheck3.Text = "Self"
        Me.SelfCheck3.UseVisualStyleBackColor = True
        '
        'kwdTbx
        '
        Me.kwdTbx.ForeColor = System.Drawing.Color.Blue
        Me.kwdTbx.Location = New System.Drawing.Point(126, 30)
        Me.kwdTbx.MaxLength = 4
        Me.kwdTbx.Name = "kwdTbx"
        Me.kwdTbx.Size = New System.Drawing.Size(58, 20)
        Me.kwdTbx.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(47, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 13)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Κωδικός:"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(353, 245)
        Me.TextBox15.MaxLength = 40
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(193, 20)
        Me.TextBox15.TabIndex = 36
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(301, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "e-mail:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label17.Location = New System.Drawing.Point(288, 380)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(278, 13)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "(10-ψήφιος Αριθμός χωρίς παύλες ενδιάμεσα)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(204, 526)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Αποθήκευση"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(200, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(142, 24)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "ΠΡΑΚΤΟΡΕΙΟ"
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(325, 482)
        Me.TextBox14.MaxLength = 2
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(58, 20)
        Me.TextBox14.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(232, 485)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Μπουρνούζια:"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(125, 486)
        Me.TextBox13.MaxLength = 2
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(58, 20)
        Me.TextBox13.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(42, 489)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Πετσέτες:"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(325, 447)
        Me.TextBox12.MaxLength = 2
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(58, 20)
        Me.TextBox12.TabIndex = 27
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(253, 450)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Ταπέτα:"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.Location = New System.Drawing.Point(260, 414)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox2.TabIndex = 25
        Me.CheckBox2.Text = "Guarantee"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(126, 447)
        Me.TextBox11.MaxLength = 2
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(58, 20)
        Me.TextBox11.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(43, 450)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Σεντόνια:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 415)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Τύπος Χρέωσης:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.XrewseisBindingSource
        Me.ComboBox1.DisplayMember = "xrewsi"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(126, 412)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(80, 21)
        Me.ComboBox1.TabIndex = 21
        '
        'XrewseisBindingSource
        '
        Me.XrewseisBindingSource.DataMember = "xrewseis"
        Me.XrewseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(126, 377)
        Me.TextBox10.MaxLength = 10
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(156, 20)
        Me.TextBox10.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(43, 380)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Κ.Λ/σμού:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(50, 340)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(172, 17)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "Ημερήσια Τιμή Δωματίου"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(353, 296)
        Me.TextBox9.MaxLength = 40
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(177, 20)
        Me.TextBox9.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(297, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Δ.Ο.Υ.:"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(126, 296)
        Me.TextBox8.MaxLength = 9
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(156, 20)
        Me.TextBox8.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(57, 299)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Α.Φ.Μ.:"
        '
        'TextBox7
        '
        Me.TextBox7.ForeColor = System.Drawing.Color.Maroon
        Me.TextBox7.Location = New System.Drawing.Point(126, 245)
        Me.TextBox7.MaxLength = 40
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(96, 20)
        Me.TextBox7.TabIndex = 13
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 248)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Προμήθεια:"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(353, 208)
        Me.TextBox6.MaxLength = 40
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(95, 20)
        Me.TextBox6.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(311, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Fax:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(126, 208)
        Me.TextBox5.MaxLength = 40
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(156, 20)
        Me.TextBox5.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 211)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Τηλέφωνο:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(126, 171)
        Me.TextBox4.MaxLength = 49
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(279, 20)
        Me.TextBox4.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Διεύθυνση:"
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
        'XrewseisTableAdapter
        '
        Me.XrewseisTableAdapter.ClearBeforeFill = True
        '
        'PraktoreioFrm
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 560)
        Me.Controls.Add(Me.PraktoreioPnl)
        Me.KeyPreview = True
        Me.Name = "PraktoreioFrm"
        Me.Text = "Πρακτορειο"
        Me.PraktoreioPnl.ResumeLayout(False)
        Me.PraktoreioPnl.PerformLayout()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents PraktoreioPnl As System.Windows.Forms.Panel
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents XrewseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents kwdTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents SelfCheck3 As System.Windows.Forms.CheckBox

End Class
