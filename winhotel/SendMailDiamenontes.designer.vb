<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendMailDiamenontes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendMailDiamenontes))
        Me.emailagPnl = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ImeromPck = New System.Windows.Forms.DateTimePicker()
        Me.attachTbx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.bodyagRTbx = New System.Windows.Forms.RichTextBox()
        Me.subjectagTbx = New System.Windows.Forms.TextBox()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.MailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MailTableAdapter = New winhotel.dbhotelDataSetTableAdapters.MailTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter()
        Me.AfixeisAnaxwriseis2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AfixeisAnaxwriseis2TableAdapter = New winhotel.dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter()
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet()
        Me.DbhotelDataSet11 = New winhotel.dbhotelDataSet1()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.sendBtn = New System.Windows.Forms.Button()
        Me.emailagBtn = New System.Windows.Forms.Button()
        Me.path1Lbl = New System.Windows.Forms.Label()
        Me.path2Lbl = New System.Windows.Forms.Label()
        Me.path3Lbl = New System.Windows.Forms.Label()
        Me.emailagPnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AfixeisAnaxwriseis2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'emailagPnl
        '
        Me.emailagPnl.BackColor = System.Drawing.Color.LightGray
        Me.emailagPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.emailagPnl.Controls.Add(Me.path3Lbl)
        Me.emailagPnl.Controls.Add(Me.path2Lbl)
        Me.emailagPnl.Controls.Add(Me.path1Lbl)
        Me.emailagPnl.Controls.Add(Me.Button1)
        Me.emailagPnl.Controls.Add(Me.CheckBox1)
        Me.emailagPnl.Controls.Add(Me.ImeromPck)
        Me.emailagPnl.Controls.Add(Me.sendBtn)
        Me.emailagPnl.Controls.Add(Me.attachTbx)
        Me.emailagPnl.Controls.Add(Me.Label1)
        Me.emailagPnl.Controls.Add(Me.emailagBtn)
        Me.emailagPnl.Controls.Add(Me.Label26)
        Me.emailagPnl.Controls.Add(Me.Label31)
        Me.emailagPnl.Controls.Add(Me.bodyagRTbx)
        Me.emailagPnl.Controls.Add(Me.subjectagTbx)
        Me.emailagPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.emailagPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.emailagPnl.Location = New System.Drawing.Point(0, 0)
        Me.emailagPnl.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.emailagPnl.Name = "emailagPnl"
        Me.emailagPnl.Size = New System.Drawing.Size(594, 387)
        Me.emailagPnl.TabIndex = 11
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(34, 290)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(110, 19)
        Me.CheckBox1.TabIndex = 51
        Me.CheckBox1.Text = "Αναμενόμενοι"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ImeromPck
        '
        Me.ImeromPck.Location = New System.Drawing.Point(22, 325)
        Me.ImeromPck.Name = "ImeromPck"
        Me.ImeromPck.Size = New System.Drawing.Size(200, 21)
        Me.ImeromPck.TabIndex = 50
        '
        'attachTbx
        '
        Me.attachTbx.Location = New System.Drawing.Point(116, 188)
        Me.attachTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.attachTbx.Multiline = True
        Me.attachTbx.Name = "attachTbx"
        Me.attachTbx.ReadOnly = True
        Me.attachTbx.Size = New System.Drawing.Size(380, 19)
        Me.attachTbx.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 191)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Attachment:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(63, 53)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 15)
        Me.Label26.TabIndex = 14
        Me.Label26.Text = "Body:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(48, 15)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(57, 15)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "subject:"
        '
        'bodyagRTbx
        '
        Me.bodyagRTbx.Location = New System.Drawing.Point(113, 51)
        Me.bodyagRTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bodyagRTbx.MaxLength = 10000
        Me.bodyagRTbx.Name = "bodyagRTbx"
        Me.bodyagRTbx.Size = New System.Drawing.Size(383, 121)
        Me.bodyagRTbx.TabIndex = 4
        Me.bodyagRTbx.Text = ""
        '
        'subjectagTbx
        '
        Me.subjectagTbx.Location = New System.Drawing.Point(116, 12)
        Me.subjectagTbx.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.subjectagTbx.MaxLength = 50
        Me.subjectagTbx.Name = "subjectagTbx"
        Me.subjectagTbx.Size = New System.Drawing.Size(380, 21)
        Me.subjectagTbx.TabIndex = 1
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MailBindingSource
        '
        Me.MailBindingSource.DataMember = "Mail"
        Me.MailBindingSource.DataSource = Me.DbhotelDataSet
        '
        'MailTableAdapter
        '
        Me.MailTableAdapter.ClearBeforeFill = True
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
        'DwmatiaBindingSource
        '
        Me.DwmatiaBindingSource.DataMember = "dwmatia"
        Me.DwmatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DwmatiaTableAdapter
        '
        Me.DwmatiaTableAdapter.ClearBeforeFill = True
        '
        'AfixeisAnaxwriseis2BindingSource
        '
        Me.AfixeisAnaxwriseis2BindingSource.DataMember = "AfixeisAnaxwriseis2"
        Me.AfixeisAnaxwriseis2BindingSource.DataSource = Me.DbhotelDataSet
        '
        'AfixeisAnaxwriseis2TableAdapter
        '
        Me.AfixeisAnaxwriseis2TableAdapter.ClearBeforeFill = True
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DbhotelDataSet11
        '
        Me.DbhotelDataSet11.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet11.EnforceConstraints = False
        Me.DbhotelDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet11
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.aliasTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.dwmatiastatusTableAdapter = Nothing
        Me.TableAdapterManager.dwmatiaTableAdapter = Nothing
        Me.TableAdapterManager.etaireiaTableAdapter = Nothing
        Me.TableAdapterManager.forosdiamonisTableAdapter = Nothing
        Me.TableAdapterManager.katigoriesTableAdapter = Nothing
        Me.TableAdapterManager.klinesTableAdapter = Nothing
        Me.TableAdapterManager.kratiseisTableAdapter = Me.KratiseisTableAdapter
        Me.TableAdapterManager.praktoreiaTableAdapter = Nothing
        Me.TableAdapterManager.tipoiTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.vilapraktoreia1TableAdapter = Nothing
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Image = Global.winhotel.My.Resources.Resources.folder
        Me.Button1.Location = New System.Drawing.Point(503, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 47)
        Me.Button1.TabIndex = 52
        Me.Button1.UseVisualStyleBackColor = True
        '
        'sendBtn
        '
        Me.sendBtn.BackColor = System.Drawing.Color.White
        Me.sendBtn.Image = Global.winhotel.My.Resources.Resources.PEG08
        Me.sendBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sendBtn.Location = New System.Drawing.Point(257, 341)
        Me.sendBtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.sendBtn.Name = "sendBtn"
        Me.sendBtn.Size = New System.Drawing.Size(144, 27)
        Me.sendBtn.TabIndex = 49
        Me.sendBtn.Text = "SEND"
        Me.sendBtn.UseVisualStyleBackColor = False
        '
        'emailagBtn
        '
        Me.emailagBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.emailagBtn.Image = CType(resources.GetObject("emailagBtn.Image"), System.Drawing.Image)
        Me.emailagBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.emailagBtn.Location = New System.Drawing.Point(257, 301)
        Me.emailagBtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.emailagBtn.Name = "emailagBtn"
        Me.emailagBtn.Size = New System.Drawing.Size(144, 27)
        Me.emailagBtn.TabIndex = 48
        Me.emailagBtn.Text = "Save"
        Me.emailagBtn.UseVisualStyleBackColor = True
        '
        'path1Lbl
        '
        Me.path1Lbl.AutoSize = True
        Me.path1Lbl.Location = New System.Drawing.Point(126, 221)
        Me.path1Lbl.Name = "path1Lbl"
        Me.path1Lbl.Size = New System.Drawing.Size(101, 15)
        Me.path1Lbl.TabIndex = 53
        Me.path1Lbl.Text = "selected path1"
        '
        'path2Lbl
        '
        Me.path2Lbl.AutoSize = True
        Me.path2Lbl.Location = New System.Drawing.Point(126, 244)
        Me.path2Lbl.Name = "path2Lbl"
        Me.path2Lbl.Size = New System.Drawing.Size(101, 15)
        Me.path2Lbl.TabIndex = 54
        Me.path2Lbl.Text = "selected path2"
        '
        'path3Lbl
        '
        Me.path3Lbl.AutoSize = True
        Me.path3Lbl.Location = New System.Drawing.Point(126, 269)
        Me.path3Lbl.Name = "path3Lbl"
        Me.path3Lbl.Size = New System.Drawing.Size(101, 15)
        Me.path3Lbl.TabIndex = 55
        Me.path3Lbl.Text = "selected path3"
        '
        'SendMailDiamenontes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 387)
        Me.Controls.Add(Me.emailagPnl)
        Me.Name = "SendMailDiamenontes"
        Me.Text = "SendMailDiamenontes"
        Me.emailagPnl.ResumeLayout(False)
        Me.emailagPnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AfixeisAnaxwriseis2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents emailagPnl As System.Windows.Forms.Panel
    Friend WithEvents attachTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents emailagBtn As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents bodyagRTbx As System.Windows.Forms.RichTextBox
    Friend WithEvents subjectagTbx As System.Windows.Forms.TextBox
    Friend WithEvents sendBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents MailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MailTableAdapter As winhotel.dbhotelDataSetTableAdapters.MailTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
    Friend WithEvents AfixeisAnaxwriseis2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AfixeisAnaxwriseis2TableAdapter As winhotel.dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ImeromPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents DbhotelDataSet11 As winhotel.dbhotelDataSet1
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents path3Lbl As System.Windows.Forms.Label
    Friend WithEvents path2Lbl As System.Windows.Forms.Label
    Friend WithEvents path1Lbl As System.Windows.Forms.Label
End Class
