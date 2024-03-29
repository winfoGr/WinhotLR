<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlirotitaXenodFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlirotitaXenodFrm))
        Me.ZentralPnl = New System.Windows.Forms.Panel()
        Me.DwmPlirotitaPnl = New System.Windows.Forms.Panel()
        Me.DwmPlirot3Pnl = New System.Windows.Forms.Panel()
        Me.BtnsPnl = New System.Windows.Forms.Panel()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.SendMialBtn = New System.Windows.Forms.Button()
        Me.EktStatusDwmBtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.EpomDwmBtn = New System.Windows.Forms.Button()
        Me.PrDwmBtn = New System.Windows.Forms.Button()
        Me.DwmPlirot2Pnl = New System.Windows.Forms.Panel()
        Me.DwmPlirot1Pnl = New System.Windows.Forms.Panel()
        Me.HAChk = New System.Windows.Forms.CheckBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.XenodStatusTiposCbx = New System.Windows.Forms.ComboBox()
        Me.XenodStatusKlinesCbx = New System.Windows.Forms.ComboBox()
        Me.PlirDwmPlithImerTbx = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.PlirDwmEwsTbx = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.PlirDwmApoTbx = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.ImeromPlirotDwm = New System.Windows.Forms.DateTimePicker()
        Me.DwmPlirotBtn = New System.Windows.Forms.Button()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.AfixeisAnaxwriseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AfixeisAnaxwriseisTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.AfixeisAnaxwriseisTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.KatigoriesTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.katigoriesTableAdapter()
        Me.TipoiTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.tipoiTableAdapter()
        Me.KatigoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter()
        Me.DwmatiastatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiastatusTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.dwmatiastatusTableAdapter()
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.dwmatiaTableAdapter()
        Me.KlinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlinesTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.klinesTableAdapter()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.MailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MailTableAdapter = New winhotel.dbhotelDataSetTableAdapters.MailTableAdapter()
        Me.ZentralPnl.SuspendLayout()
        Me.DwmPlirotitaPnl.SuspendLayout()
        Me.BtnsPnl.SuspendLayout()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DwmPlirot1Pnl.SuspendLayout()
        CType(Me.AfixeisAnaxwriseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiastatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ZentralPnl
        '
        Me.ZentralPnl.AutoScroll = True
        Me.ZentralPnl.Controls.Add(Me.DwmPlirotitaPnl)
        Me.ZentralPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ZentralPnl.Location = New System.Drawing.Point(2, 3)
        Me.ZentralPnl.Name = "ZentralPnl"
        Me.ZentralPnl.Size = New System.Drawing.Size(1243, 807)
        Me.ZentralPnl.TabIndex = 36
        '
        'DwmPlirotitaPnl
        '
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot3Pnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.BtnsPnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot2Pnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot1Pnl)
        Me.DwmPlirotitaPnl.Location = New System.Drawing.Point(3, 3)
        Me.DwmPlirotitaPnl.Name = "DwmPlirotitaPnl"
        Me.DwmPlirotitaPnl.Size = New System.Drawing.Size(1240, 798)
        Me.DwmPlirotitaPnl.TabIndex = 34
        '
        'DwmPlirot3Pnl
        '
        Me.DwmPlirot3Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DwmPlirot3Pnl.Location = New System.Drawing.Point(9, 96)
        Me.DwmPlirot3Pnl.Name = "DwmPlirot3Pnl"
        Me.DwmPlirot3Pnl.Size = New System.Drawing.Size(63, 399)
        Me.DwmPlirot3Pnl.TabIndex = 34
        '
        'BtnsPnl
        '
        Me.BtnsPnl.Controls.Add(Me.SendMialBtn)
        Me.BtnsPnl.Controls.Add(Me.EktStatusDwmBtn)
        Me.BtnsPnl.Controls.Add(Me.ProgressBar1)
        Me.BtnsPnl.Controls.Add(Me.EpomDwmBtn)
        Me.BtnsPnl.Controls.Add(Me.PrDwmBtn)
        Me.BtnsPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnsPnl.Location = New System.Drawing.Point(7, 503)
        Me.BtnsPnl.Name = "BtnsPnl"
        Me.BtnsPnl.Size = New System.Drawing.Size(1233, 295)
        Me.BtnsPnl.TabIndex = 33
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.EnforceConstraints = False
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SendMialBtn
        '
        Me.SendMialBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SendMialBtn.Image = Global.winhotel.My.Resources.Resources.PROPAR
        Me.SendMialBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SendMialBtn.Location = New System.Drawing.Point(669, 54)
        Me.SendMialBtn.Name = "SendMialBtn"
        Me.SendMialBtn.Size = New System.Drawing.Size(171, 31)
        Me.SendMialBtn.TabIndex = 36
        Me.SendMialBtn.Text = "Αποστολή Mail"
        Me.SendMialBtn.UseVisualStyleBackColor = True
        '
        'EktStatusDwmBtn
        '
        Me.EktStatusDwmBtn.AllowDrop = True
        Me.EktStatusDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktStatusDwmBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EktStatusDwmBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktStatusDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EktStatusDwmBtn.Location = New System.Drawing.Point(460, 83)
        Me.EktStatusDwmBtn.Name = "EktStatusDwmBtn"
        Me.EktStatusDwmBtn.Size = New System.Drawing.Size(157, 23)
        Me.EktStatusDwmBtn.TabIndex = 33
        Me.EktStatusDwmBtn.Text = "Προεπισκόπηση"
        Me.EktStatusDwmBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(397, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(294, 10)
        Me.ProgressBar1.TabIndex = 0
        '
        'EpomDwmBtn
        '
        Me.EpomDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EpomDwmBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.EpomDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpomDwmBtn.Location = New System.Drawing.Point(460, 54)
        Me.EpomDwmBtn.Name = "EpomDwmBtn"
        Me.EpomDwmBtn.Size = New System.Drawing.Size(157, 23)
        Me.EpomDwmBtn.TabIndex = 24
        Me.EpomDwmBtn.Text = "Επόμενα Δωμ."
        Me.EpomDwmBtn.UseVisualStyleBackColor = True
        '
        'PrDwmBtn
        '
        Me.PrDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PrDwmBtn.Image = Global.winhotel.My.Resources.Resources.DOIT
        Me.PrDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrDwmBtn.Location = New System.Drawing.Point(460, 25)
        Me.PrDwmBtn.Name = "PrDwmBtn"
        Me.PrDwmBtn.Size = New System.Drawing.Size(157, 23)
        Me.PrDwmBtn.TabIndex = 23
        Me.PrDwmBtn.Text = "Προηγούμ. Δωμ."
        Me.PrDwmBtn.UseVisualStyleBackColor = True
        '
        'DwmPlirot2Pnl
        '
        Me.DwmPlirot2Pnl.AutoScroll = True
        Me.DwmPlirot2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DwmPlirot2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmPlirot2Pnl.Location = New System.Drawing.Point(74, 96)
        Me.DwmPlirot2Pnl.Name = "DwmPlirot2Pnl"
        Me.DwmPlirot2Pnl.Size = New System.Drawing.Size(1042, 399)
        Me.DwmPlirot2Pnl.TabIndex = 32
        '
        'DwmPlirot1Pnl
        '
        Me.DwmPlirot1Pnl.BackColor = System.Drawing.SystemColors.Menu
        Me.DwmPlirot1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DwmPlirot1Pnl.Controls.Add(Me.HAChk)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label78)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label71)
        Me.DwmPlirot1Pnl.Controls.Add(Me.XenodStatusTiposCbx)
        Me.DwmPlirot1Pnl.Controls.Add(Me.XenodStatusKlinesCbx)
        Me.DwmPlirot1Pnl.Controls.Add(Me.PlirDwmPlithImerTbx)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label67)
        Me.DwmPlirot1Pnl.Controls.Add(Me.PlirDwmEwsTbx)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label68)
        Me.DwmPlirot1Pnl.Controls.Add(Me.PlirDwmApoTbx)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label69)
        Me.DwmPlirot1Pnl.Controls.Add(Me.ImeromPlirotDwm)
        Me.DwmPlirot1Pnl.Controls.Add(Me.DwmPlirotBtn)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label72)
        Me.DwmPlirot1Pnl.Controls.Add(Me.Label73)
        Me.DwmPlirot1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmPlirot1Pnl.Location = New System.Drawing.Point(9, 5)
        Me.DwmPlirot1Pnl.Name = "DwmPlirot1Pnl"
        Me.DwmPlirot1Pnl.Size = New System.Drawing.Size(1107, 89)
        Me.DwmPlirot1Pnl.TabIndex = 31
        '
        'HAChk
        '
        Me.HAChk.AutoSize = True
        Me.HAChk.BackColor = System.Drawing.Color.Yellow
        Me.HAChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HAChk.Checked = True
        Me.HAChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HAChk.Location = New System.Drawing.Point(813, 30)
        Me.HAChk.Name = "HAChk"
        Me.HAChk.Size = New System.Drawing.Size(235, 20)
        Me.HAChk.TabIndex = 26
        Me.HAChk.Text = "Ενημέρωση HotelAvailabilities"
        Me.HAChk.UseVisualStyleBackColor = False
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(202, 47)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(56, 16)
        Me.Label78.TabIndex = 25
        Me.Label78.Text = "Τύπος:"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(27, 44)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(58, 16)
        Me.Label71.TabIndex = 24
        Me.Label71.Text = "Κλίνες:"
        '
        'XenodStatusTiposCbx
        '
        Me.XenodStatusTiposCbx.ForeColor = System.Drawing.Color.Maroon
        Me.XenodStatusTiposCbx.FormattingEnabled = True
        Me.XenodStatusTiposCbx.Location = New System.Drawing.Point(264, 41)
        Me.XenodStatusTiposCbx.Name = "XenodStatusTiposCbx"
        Me.XenodStatusTiposCbx.Size = New System.Drawing.Size(97, 24)
        Me.XenodStatusTiposCbx.TabIndex = 23
        '
        'XenodStatusKlinesCbx
        '
        Me.XenodStatusKlinesCbx.ForeColor = System.Drawing.Color.Maroon
        Me.XenodStatusKlinesCbx.FormattingEnabled = True
        Me.XenodStatusKlinesCbx.Location = New System.Drawing.Point(92, 41)
        Me.XenodStatusKlinesCbx.Name = "XenodStatusKlinesCbx"
        Me.XenodStatusKlinesCbx.Size = New System.Drawing.Size(92, 24)
        Me.XenodStatusKlinesCbx.TabIndex = 22
        '
        'PlirDwmPlithImerTbx
        '
        Me.PlirDwmPlithImerTbx.Location = New System.Drawing.Point(591, 6)
        Me.PlirDwmPlithImerTbx.MaxLength = 2
        Me.PlirDwmPlithImerTbx.Name = "PlirDwmPlithImerTbx"
        Me.PlirDwmPlithImerTbx.Size = New System.Drawing.Size(40, 22)
        Me.PlirDwmPlithImerTbx.TabIndex = 21
        Me.PlirDwmPlithImerTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(466, 9)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(122, 16)
        Me.Label67.TabIndex = 20
        Me.Label67.Text = "Πλήθος Ημερών:"
        '
        'PlirDwmEwsTbx
        '
        Me.PlirDwmEwsTbx.Location = New System.Drawing.Point(703, 52)
        Me.PlirDwmEwsTbx.Name = "PlirDwmEwsTbx"
        Me.PlirDwmEwsTbx.Size = New System.Drawing.Size(70, 22)
        Me.PlirDwmEwsTbx.TabIndex = 19
        Me.PlirDwmEwsTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(662, 56)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(41, 16)
        Me.Label68.TabIndex = 18
        Me.Label68.Text = " έως:"
        '
        'PlirDwmApoTbx
        '
        Me.PlirDwmApoTbx.Location = New System.Drawing.Point(703, 31)
        Me.PlirDwmApoTbx.Name = "PlirDwmApoTbx"
        Me.PlirDwmApoTbx.Size = New System.Drawing.Size(70, 22)
        Me.PlirDwmApoTbx.TabIndex = 17
        Me.PlirDwmApoTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(599, 34)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(98, 16)
        Me.Label69.TabIndex = 16
        Me.Label69.Text = "Δωμάτιο από:"
        '
        'ImeromPlirotDwm
        '
        Me.ImeromPlirotDwm.Location = New System.Drawing.Point(221, 6)
        Me.ImeromPlirotDwm.Name = "ImeromPlirotDwm"
        Me.ImeromPlirotDwm.Size = New System.Drawing.Size(239, 22)
        Me.ImeromPlirotDwm.TabIndex = 10
        '
        'DwmPlirotBtn
        '
        Me.DwmPlirotBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmPlirotBtn.Image = CType(resources.GetObject("DwmPlirotBtn.Image"), System.Drawing.Image)
        Me.DwmPlirotBtn.Location = New System.Drawing.Point(429, 36)
        Me.DwmPlirotBtn.Name = "DwmPlirotBtn"
        Me.DwmPlirotBtn.Size = New System.Drawing.Size(40, 38)
        Me.DwmPlirotBtn.TabIndex = 9
        Me.DwmPlirotBtn.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(89, 9)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(123, 16)
        Me.Label72.TabIndex = 1
        Me.Label72.Text = "από Ημερομηνία:"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.Location = New System.Drawing.Point(8, 9)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(75, 16)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "επιλογές:"
        '
        'AfixeisAnaxwriseisBindingSource
        '
        Me.AfixeisAnaxwriseisBindingSource.DataMember = "AfixeisAnaxwriseis"
        Me.AfixeisAnaxwriseisBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'AfixeisAnaxwriseisTableAdapter
        '
        Me.AfixeisAnaxwriseisTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.aliasTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.dwmatiastatusTableAdapter = Nothing
        Me.TableAdapterManager.dwmatiaTableAdapter = Nothing
        Me.TableAdapterManager.etaireiaTableAdapter = Nothing
        Me.TableAdapterManager.forosdiamonisTableAdapter = Nothing
        Me.TableAdapterManager.katigoriesTableAdapter = Me.KatigoriesTableAdapter
        Me.TableAdapterManager.klinesTableAdapter = Nothing
        Me.TableAdapterManager.kratiseisTableAdapter = Nothing
        Me.TableAdapterManager.praktoreiaTableAdapter = Nothing
        Me.TableAdapterManager.tipoiTableAdapter = Me.TipoiTableAdapter
        Me.TableAdapterManager.UpdateOrder = winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.vilapraktoreia1TableAdapter = Nothing
        '
        'KatigoriesTableAdapter
        '
        Me.KatigoriesTableAdapter.ClearBeforeFill = True
        '
        'TipoiTableAdapter
        '
        Me.TipoiTableAdapter.ClearBeforeFill = True
        '
        'KatigoriesBindingSource
        '
        Me.KatigoriesBindingSource.DataMember = "katigories"
        Me.KatigoriesBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'TipoiBindingSource
        '
        Me.TipoiBindingSource.DataMember = "tipoi"
        Me.TipoiBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'DwmatiastatusBindingSource
        '
        Me.DwmatiastatusBindingSource.DataMember = "dwmatiastatus"
        Me.DwmatiastatusBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'DwmatiastatusTableAdapter
        '
        Me.DwmatiastatusTableAdapter.ClearBeforeFill = True
        '
        'DwmatiaBindingSource
        '
        Me.DwmatiaBindingSource.DataMember = "dwmatia"
        Me.DwmatiaBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'DwmatiaTableAdapter
        '
        Me.DwmatiaTableAdapter.ClearBeforeFill = True
        '
        'KlinesBindingSource
        '
        Me.KlinesBindingSource.DataMember = "klines"
        Me.KlinesBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'KlinesTableAdapter
        '
        Me.KlinesTableAdapter.ClearBeforeFill = True
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
        'PlirotitaXenodFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 631)
        Me.Controls.Add(Me.ZentralPnl)
        Me.Name = "PlirotitaXenodFrm"
        Me.Text = "OLD TOWN Πληρότητες Δωματίων"
        Me.ZentralPnl.ResumeLayout(False)
        Me.DwmPlirotitaPnl.ResumeLayout(False)
        Me.BtnsPnl.ResumeLayout(False)
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DwmPlirot1Pnl.ResumeLayout(False)
        Me.DwmPlirot1Pnl.PerformLayout()
        CType(Me.AfixeisAnaxwriseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiastatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents DwmPlirotitaPnl As System.Windows.Forms.Panel
    Friend WithEvents DwmPlirot3Pnl As System.Windows.Forms.Panel
    Friend WithEvents BtnsPnl As System.Windows.Forms.Panel
    Friend WithEvents EktStatusDwmBtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents EpomDwmBtn As System.Windows.Forms.Button
    Friend WithEvents PrDwmBtn As System.Windows.Forms.Button
    Friend WithEvents DwmPlirot2Pnl As System.Windows.Forms.Panel
    Friend WithEvents DwmPlirot1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents XenodStatusTiposCbx As System.Windows.Forms.ComboBox
    Friend WithEvents XenodStatusKlinesCbx As System.Windows.Forms.ComboBox
    Friend WithEvents PlirDwmPlithImerTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents PlirDwmEwsTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents PlirDwmApoTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents ImeromPlirotDwm As System.Windows.Forms.DateTimePicker
    Friend WithEvents DwmPlirotBtn As System.Windows.Forms.Button
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents AfixeisAnaxwriseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AfixeisAnaxwriseisTableAdapter As winhotel.dbhotelDataSet1TableAdapters.AfixeisAnaxwriseisTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents KatigoriesTableAdapter As winhotel.dbhotelDataSet1TableAdapters.katigoriesTableAdapter
    Friend WithEvents KatigoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipoiTableAdapter As winhotel.dbhotelDataSet1TableAdapters.tipoiTableAdapter
    Friend WithEvents TipoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Friend WithEvents DwmatiastatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiastatusTableAdapter As winhotel.dbhotelDataSet1TableAdapters.dwmatiastatusTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSet1TableAdapters.dwmatiaTableAdapter
    Friend WithEvents KlinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KlinesTableAdapter As winhotel.dbhotelDataSet1TableAdapters.klinesTableAdapter
    Friend WithEvents SendMialBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents MailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MailTableAdapter As winhotel.dbhotelDataSetTableAdapters.MailTableAdapter
    Friend WithEvents HAChk As System.Windows.Forms.CheckBox
End Class
