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
        Me.components = New System.ComponentModel.Container()
        Me.VilesRdb = New System.Windows.Forms.RadioButton()
        Me.PraktRdb = New System.Windows.Forms.RadioButton()
        Me.apoPck = New System.Windows.Forms.DateTimePicker()
        Me.mexriPck = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProblEisprBtn = New System.Windows.Forms.Button()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter()
        Me.pswdTbx = New System.Windows.Forms.TextBox()
        Me.domisichk = New System.Windows.Forms.CheckBox()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.ParastCbx = New System.Windows.Forms.ComboBox()
        Me.Prokataboles = New System.Windows.Forms.Label()
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.AfmBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AfmTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.afmTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.ThalassRdb = New System.Windows.Forms.RadioButton()
        Me.UrbanRdb = New System.Windows.Forms.RadioButton()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AfmBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VilesRdb
        '
        Me.VilesRdb.AutoSize = True
        Me.VilesRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.VilesRdb.Checked = True
        Me.VilesRdb.Location = New System.Drawing.Point(22, 91)
        Me.VilesRdb.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.VilesRdb.Name = "VilesRdb"
        Me.VilesRdb.Size = New System.Drawing.Size(56, 19)
        Me.VilesRdb.TabIndex = 0
        Me.VilesRdb.TabStop = True
        Me.VilesRdb.Text = "Ολες"
        Me.VilesRdb.UseVisualStyleBackColor = True
        '
        'PraktRdb
        '
        Me.PraktRdb.AutoSize = True
        Me.PraktRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PraktRdb.Location = New System.Drawing.Point(262, 91)
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
        Me.ProblEisprBtn.Location = New System.Drawing.Point(130, 198)
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
        'Prokataboles
        '
        Me.Prokataboles.AutoSize = True
        Me.Prokataboles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Prokataboles.ForeColor = System.Drawing.Color.Blue
        Me.Prokataboles.Location = New System.Drawing.Point(3, 241)
        Me.Prokataboles.Name = "Prokataboles"
        Me.Prokataboles.Size = New System.Drawing.Size(45, 13)
        Me.Prokataboles.TabIndex = 44
        Me.Prokataboles.Text = "Label3"
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.EnforceConstraints = False
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AfmBindingSource
        '
        Me.AfmBindingSource.DataMember = "afm"
        Me.AfmBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'AfmTableAdapter
        '
        Me.AfmTableAdapter.ClearBeforeFill = True
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
        'ThalassRdb
        '
        Me.ThalassRdb.AutoSize = True
        Me.ThalassRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ThalassRdb.Location = New System.Drawing.Point(84, 91)
        Me.ThalassRdb.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ThalassRdb.Name = "ThalassRdb"
        Me.ThalassRdb.Size = New System.Drawing.Size(90, 19)
        Me.ThalassRdb.TabIndex = 45
        Me.ThalassRdb.Text = "Thalasses"
        Me.ThalassRdb.UseVisualStyleBackColor = True
        '
        'UrbanRdb
        '
        Me.UrbanRdb.AutoSize = True
        Me.UrbanRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.UrbanRdb.Location = New System.Drawing.Point(190, 91)
        Me.UrbanRdb.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UrbanRdb.Name = "UrbanRdb"
        Me.UrbanRdb.Size = New System.Drawing.Size(64, 19)
        Me.UrbanRdb.TabIndex = 46
        Me.UrbanRdb.Text = "Urban"
        Me.UrbanRdb.UseVisualStyleBackColor = True
        '
        'ProblEisprakseis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(374, 346)
        Me.Controls.Add(Me.UrbanRdb)
        Me.Controls.Add(Me.ThalassRdb)
        Me.Controls.Add(Me.Prokataboles)
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
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AfmBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Prokataboles As System.Windows.Forms.Label
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents AfmBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AfmTableAdapter As winhotel.dbhotelDataSet1TableAdapters.afmTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents ThalassRdb As System.Windows.Forms.RadioButton
    Friend WithEvents UrbanRdb As System.Windows.Forms.RadioButton
End Class
