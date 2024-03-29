<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProblEisprakseis
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
        Me.VilesRdb = New System.Windows.Forms.RadioButton
        Me.PraktRdb = New System.Windows.Forms.RadioButton
        Me.apoPck = New System.Windows.Forms.DateTimePicker
        Me.mexriPck = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProblEisprBtn = New System.Windows.Forms.Button
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
        Me.pswdTbx = New System.Windows.Forms.TextBox
        Me.domisichk = New System.Windows.Forms.CheckBox
        Me.Label159 = New System.Windows.Forms.Label
        Me.ParastCbx = New System.Windows.Forms.ComboBox
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VilesRdb
        '
        Me.VilesRdb.AutoSize = True
        Me.VilesRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.VilesRdb.Checked = True
        Me.VilesRdb.Location = New System.Drawing.Point(75, 91)
        Me.VilesRdb.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.VilesRdb.Name = "VilesRdb"
        Me.VilesRdb.Size = New System.Drawing.Size(59, 19)
        Me.VilesRdb.TabIndex = 0
        Me.VilesRdb.TabStop = True
        Me.VilesRdb.Text = "Βίλες"
        Me.VilesRdb.UseVisualStyleBackColor = True
        '
        'PraktRdb
        '
        Me.PraktRdb.AutoSize = True
        Me.PraktRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PraktRdb.Location = New System.Drawing.Point(158, 91)
        Me.PraktRdb.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PraktRdb.Name = "PraktRdb"
        Me.PraktRdb.Size = New System.Drawing.Size(99, 19)
        Me.PraktRdb.TabIndex = 1
        Me.PraktRdb.Text = "Πρακτορεία"
        Me.PraktRdb.UseVisualStyleBackColor = True
        '
        'apoPck
        '
        Me.apoPck.CustomFormat = "dd/MM/yy"
        Me.apoPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.apoPck.Location = New System.Drawing.Point(33, 136)
        Me.apoPck.Name = "apoPck"
        Me.apoPck.Size = New System.Drawing.Size(122, 21)
        Me.apoPck.TabIndex = 2
        '
        'mexriPck
        '
        Me.mexriPck.CustomFormat = "dd/MM/yy"
        Me.mexriPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mexriPck.Location = New System.Drawing.Point(184, 136)
        Me.mexriPck.Name = "mexriPck"
        Me.mexriPck.Size = New System.Drawing.Size(122, 21)
        Me.mexriPck.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "απο:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "μέχρι:"
        '
        'ProblEisprBtn
        '
        Me.ProblEisprBtn.Image = Global.winhotel.My.Resources.Resources.P21
        Me.ProblEisprBtn.Location = New System.Drawing.Point(130, 212)
        Me.ProblEisprBtn.Name = "ProblEisprBtn"
        Me.ProblEisprBtn.Size = New System.Drawing.Size(56, 36)
        Me.ProblEisprBtn.TabIndex = 6
        Me.ProblEisprBtn.UseVisualStyleBackColor = True
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
        'pswdTbx
        '
        Me.pswdTbx.Location = New System.Drawing.Point(120, 171)
        Me.pswdTbx.MaxLength = 9
        Me.pswdTbx.Name = "pswdTbx"
        Me.pswdTbx.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pswdTbx.Size = New System.Drawing.Size(81, 21)
        Me.pswdTbx.TabIndex = 7
        '
        'domisichk
        '
        Me.domisichk.AutoSize = True
        Me.domisichk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.domisichk.Checked = True
        Me.domisichk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.domisichk.Location = New System.Drawing.Point(112, 62)
        Me.domisichk.Name = "domisichk"
        Me.domisichk.Size = New System.Drawing.Size(74, 19)
        Me.domisichk.TabIndex = 8
        Me.domisichk.Text = "Δόμηση"
        Me.domisichk.UseVisualStyleBackColor = True
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Location = New System.Drawing.Point(30, 24)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(65, 15)
        Me.Label159.TabIndex = 43
        Me.Label159.Text = "Εταιρεία:"
        '
        'ParastCbx
        '
        Me.ParastCbx.ForeColor = System.Drawing.Color.Maroon
        Me.ParastCbx.FormattingEnabled = True
        Me.ParastCbx.Location = New System.Drawing.Point(114, 21)
        Me.ParastCbx.Name = "ParastCbx"
        Me.ParastCbx.Size = New System.Drawing.Size(162, 23)
        Me.ParastCbx.TabIndex = 42
        '
        'ProblEisprakseis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(343, 265)
        Me.Controls.Add(Me.Label159)
        Me.Controls.Add(Me.ParastCbx)
        Me.Controls.Add(Me.domisichk)
        Me.Controls.Add(Me.pswdTbx)
        Me.Controls.Add(Me.ProblEisprBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mexriPck)
        Me.Controls.Add(Me.apoPck)
        Me.Controls.Add(Me.PraktRdb)
        Me.Controls.Add(Me.VilesRdb)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "ProblEisprakseis"
        Me.Text = "Πρόβλεψη Εισπράξεων"
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VilesRdb As System.Windows.Forms.RadioButton
    Friend WithEvents PraktRdb As System.Windows.Forms.RadioButton
    Friend WithEvents apoPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents mexriPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProblEisprBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents pswdTbx As System.Windows.Forms.TextBox
    Friend WithEvents domisichk As System.Windows.Forms.CheckBox
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents ParastCbx As System.Windows.Forms.ComboBox
End Class
