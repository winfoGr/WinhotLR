<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlirotitaDwmFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlirotitaDwmFrm))
        Me.DwmPlirotitaPnl = New System.Windows.Forms.Panel()
        Me.BtnsPnl = New System.Windows.Forms.Panel()
        Me.EktStatusDwmBtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.EpomDwmBtn = New System.Windows.Forms.Button()
        Me.PrDwmBtn = New System.Windows.Forms.Button()
        Me.DwmPlirot3Pnl = New System.Windows.Forms.Panel()
        Me.DwmPlirot2Pnl = New System.Windows.Forms.Panel()
        Me.DwmPlirot1Pnl = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.sortkatichk = New System.Windows.Forms.CheckBox()
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
        Me.ZentralPnl = New System.Windows.Forms.Panel()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter()
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter()
        Me.DwmatiastatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiastatusTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiastatusTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        Me.AfixeisAnaxwriseis2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AfixeisAnaxwriseis2TableAdapter = New winhotel.dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter()
        Me.KatigoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatigoriesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter()
        Me.KlinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlinesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter()
        Me.TipoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter()
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.TimokatDiathesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimokatDiathesTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.TimokatDiathesTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.DwmPlirotitaPnl.SuspendLayout()
        Me.BtnsPnl.SuspendLayout()
        Me.DwmPlirot1Pnl.SuspendLayout()
        Me.ZentralPnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiastatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AfixeisAnaxwriseis2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimokatDiathesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DwmPlirotitaPnl
        '
        Me.DwmPlirotitaPnl.Controls.Add(Me.BtnsPnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot3Pnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot2Pnl)
        Me.DwmPlirotitaPnl.Controls.Add(Me.DwmPlirot1Pnl)
        Me.DwmPlirotitaPnl.Location = New System.Drawing.Point(0, 4)
        Me.DwmPlirotitaPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DwmPlirotitaPnl.Name = "DwmPlirotitaPnl"
        Me.DwmPlirotitaPnl.Size = New System.Drawing.Size(1489, 1196)
        Me.DwmPlirotitaPnl.TabIndex = 34
        '
        'BtnsPnl
        '
        Me.BtnsPnl.Controls.Add(Me.EktStatusDwmBtn)
        Me.BtnsPnl.Controls.Add(Me.ProgressBar1)
        Me.BtnsPnl.Controls.Add(Me.EpomDwmBtn)
        Me.BtnsPnl.Controls.Add(Me.PrDwmBtn)
        Me.BtnsPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnsPnl.Location = New System.Drawing.Point(15, 1088)
        Me.BtnsPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnsPnl.Name = "BtnsPnl"
        Me.BtnsPnl.Size = New System.Drawing.Size(1467, 105)
        Me.BtnsPnl.TabIndex = 33
        '
        'EktStatusDwmBtn
        '
        Me.EktStatusDwmBtn.AllowDrop = True
        Me.EktStatusDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktStatusDwmBtn.Enabled = False
        Me.EktStatusDwmBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EktStatusDwmBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktStatusDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EktStatusDwmBtn.Location = New System.Drawing.Point(384, 58)
        Me.EktStatusDwmBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EktStatusDwmBtn.Name = "EktStatusDwmBtn"
        Me.EktStatusDwmBtn.Size = New System.Drawing.Size(209, 28)
        Me.EktStatusDwmBtn.TabIndex = 33
        Me.EktStatusDwmBtn.Text = "Προεπισκόπηση"
        Me.EktStatusDwmBtn.UseVisualStyleBackColor = True
        Me.EktStatusDwmBtn.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(553, 16)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(392, 12)
        Me.ProgressBar1.TabIndex = 0
        '
        'EpomDwmBtn
        '
        Me.EpomDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EpomDwmBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.EpomDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EpomDwmBtn.Location = New System.Drawing.Point(636, 66)
        Me.EpomDwmBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EpomDwmBtn.Name = "EpomDwmBtn"
        Me.EpomDwmBtn.Size = New System.Drawing.Size(209, 28)
        Me.EpomDwmBtn.TabIndex = 24
        Me.EpomDwmBtn.Text = "Επόμενα Δωμ."
        Me.EpomDwmBtn.UseVisualStyleBackColor = True
        '
        'PrDwmBtn
        '
        Me.PrDwmBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PrDwmBtn.Image = Global.winhotel.My.Resources.Resources.DOIT
        Me.PrDwmBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrDwmBtn.Location = New System.Drawing.Point(636, 32)
        Me.PrDwmBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PrDwmBtn.Name = "PrDwmBtn"
        Me.PrDwmBtn.Size = New System.Drawing.Size(209, 28)
        Me.PrDwmBtn.TabIndex = 23
        Me.PrDwmBtn.Text = "Προηγούμ. Δωμ."
        Me.PrDwmBtn.UseVisualStyleBackColor = True
        '
        'DwmPlirot3Pnl
        '
        Me.DwmPlirot3Pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DwmPlirot3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmPlirot3Pnl.Location = New System.Drawing.Point(12, 95)
        Me.DwmPlirot3Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DwmPlirot3Pnl.Name = "DwmPlirot3Pnl"
        Me.DwmPlirot3Pnl.Size = New System.Drawing.Size(84, 986)
        Me.DwmPlirot3Pnl.TabIndex = 34
        '
        'DwmPlirot2Pnl
        '
        Me.DwmPlirot2Pnl.AutoScroll = True
        Me.DwmPlirot2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DwmPlirot2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmPlirot2Pnl.Location = New System.Drawing.Point(99, 95)
        Me.DwmPlirot2Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DwmPlirot2Pnl.Name = "DwmPlirot2Pnl"
        Me.DwmPlirot2Pnl.Size = New System.Drawing.Size(1383, 986)
        Me.DwmPlirot2Pnl.TabIndex = 32
        '
        'DwmPlirot1Pnl
        '
        Me.DwmPlirot1Pnl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.DwmPlirot1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DwmPlirot1Pnl.Controls.Add(Me.RadioButton3)
        Me.DwmPlirot1Pnl.Controls.Add(Me.RadioButton2)
        Me.DwmPlirot1Pnl.Controls.Add(Me.RadioButton1)
        Me.DwmPlirot1Pnl.Controls.Add(Me.sortkatichk)
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
        Me.DwmPlirot1Pnl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DwmPlirot1Pnl.Location = New System.Drawing.Point(12, 6)
        Me.DwmPlirot1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DwmPlirot1Pnl.Name = "DwmPlirot1Pnl"
        Me.DwmPlirot1Pnl.Size = New System.Drawing.Size(1472, 91)
        Me.DwmPlirot1Pnl.TabIndex = 31
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton3.Location = New System.Drawing.Point(380, 54)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(56, 24)
        Me.RadioButton3.TabIndex = 29
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "net"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton2.Location = New System.Drawing.Point(203, 54)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(109, 24)
        Me.RadioButton2.TabIndex = 28
        Me.RadioButton2.Text = "individual"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(60, 54)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(94, 24)
        Me.RadioButton1.TabIndex = 27
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "booking"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'sortkatichk
        '
        Me.sortkatichk.AutoSize = True
        Me.sortkatichk.Checked = True
        Me.sortkatichk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sortkatichk.Enabled = False
        Me.sortkatichk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.sortkatichk.Location = New System.Drawing.Point(632, 11)
        Me.sortkatichk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.sortkatichk.Name = "sortkatichk"
        Me.sortkatichk.Size = New System.Drawing.Size(170, 24)
        Me.sortkatichk.TabIndex = 26
        Me.sortkatichk.Text = "ταξιν. κατηγορία"
        Me.sortkatichk.UseVisualStyleBackColor = True
        '
        'PlirDwmPlithImerTbx
        '
        Me.PlirDwmPlithImerTbx.Location = New System.Drawing.Point(1013, 4)
        Me.PlirDwmPlithImerTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PlirDwmPlithImerTbx.MaxLength = 2
        Me.PlirDwmPlithImerTbx.Name = "PlirDwmPlithImerTbx"
        Me.PlirDwmPlithImerTbx.Size = New System.Drawing.Size(52, 26)
        Me.PlirDwmPlithImerTbx.TabIndex = 21
        Me.PlirDwmPlithImerTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(847, 7)
        Me.Label67.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(149, 20)
        Me.Label67.TabIndex = 20
        Me.Label67.Text = "Πλήθος Ημερών:"
        '
        'PlirDwmEwsTbx
        '
        Me.PlirDwmEwsTbx.Location = New System.Drawing.Point(1167, 42)
        Me.PlirDwmEwsTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PlirDwmEwsTbx.Name = "PlirDwmEwsTbx"
        Me.PlirDwmEwsTbx.Size = New System.Drawing.Size(92, 26)
        Me.PlirDwmEwsTbx.TabIndex = 19
        Me.PlirDwmEwsTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label68.Location = New System.Drawing.Point(1112, 47)
        Me.Label68.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(54, 20)
        Me.Label68.TabIndex = 18
        Me.Label68.Text = " έως:"
        '
        'PlirDwmApoTbx
        '
        Me.PlirDwmApoTbx.Location = New System.Drawing.Point(1011, 43)
        Me.PlirDwmApoTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PlirDwmApoTbx.Name = "PlirDwmApoTbx"
        Me.PlirDwmApoTbx.Size = New System.Drawing.Size(92, 26)
        Me.PlirDwmApoTbx.TabIndex = 17
        Me.PlirDwmApoTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label69.Location = New System.Drawing.Point(872, 47)
        Me.Label69.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(120, 20)
        Me.Label69.TabIndex = 16
        Me.Label69.Text = "Δωμάτιο από:"
        '
        'ImeromPlirotDwm
        '
        Me.ImeromPlirotDwm.Location = New System.Drawing.Point(295, 7)
        Me.ImeromPlirotDwm.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ImeromPlirotDwm.Name = "ImeromPlirotDwm"
        Me.ImeromPlirotDwm.Size = New System.Drawing.Size(317, 26)
        Me.ImeromPlirotDwm.TabIndex = 10
        '
        'DwmPlirotBtn
        '
        Me.DwmPlirotBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmPlirotBtn.Image = CType(resources.GetObject("DwmPlirotBtn.Image"), System.Drawing.Image)
        Me.DwmPlirotBtn.Location = New System.Drawing.Point(656, 42)
        Me.DwmPlirotBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DwmPlirotBtn.Name = "DwmPlirotBtn"
        Me.DwmPlirotBtn.Size = New System.Drawing.Size(53, 37)
        Me.DwmPlirotBtn.TabIndex = 9
        Me.DwmPlirotBtn.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label72.Location = New System.Drawing.Point(119, 11)
        Me.Label72.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(151, 20)
        Me.Label72.TabIndex = 1
        Me.Label72.Text = "από Ημερομηνία:"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.Location = New System.Drawing.Point(11, 11)
        Me.Label73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(90, 20)
        Me.Label73.TabIndex = 0
        Me.Label73.Text = "επιλογές:"
        '
        'ZentralPnl
        '
        Me.ZentralPnl.AutoScroll = True
        Me.ZentralPnl.Controls.Add(Me.DwmPlirotitaPnl)
        Me.ZentralPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ZentralPnl.Location = New System.Drawing.Point(3, 10)
        Me.ZentralPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ZentralPnl.Name = "ZentralPnl"
        Me.ZentralPnl.Size = New System.Drawing.Size(1495, 1204)
        Me.ZentralPnl.TabIndex = 35
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.EnforceConstraints = False
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
        'DwmatiaBindingSource
        '
        Me.DwmatiaBindingSource.DataMember = "dwmatia"
        Me.DwmatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DwmatiaTableAdapter
        '
        Me.DwmatiaTableAdapter.ClearBeforeFill = True
        '
        'DwmatiastatusBindingSource
        '
        Me.DwmatiastatusBindingSource.DataMember = "dwmatiastatus"
        Me.DwmatiastatusBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DwmatiastatusTableAdapter
        '
        Me.DwmatiastatusTableAdapter.ClearBeforeFill = True
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
        'AfixeisAnaxwriseis2BindingSource
        '
        Me.AfixeisAnaxwriseis2BindingSource.DataMember = "AfixeisAnaxwriseis2"
        Me.AfixeisAnaxwriseis2BindingSource.DataSource = Me.DbhotelDataSet
        '
        'AfixeisAnaxwriseis2TableAdapter
        '
        Me.AfixeisAnaxwriseis2TableAdapter.ClearBeforeFill = True
        '
        'KatigoriesBindingSource
        '
        Me.KatigoriesBindingSource.DataMember = "katigories"
        Me.KatigoriesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatigoriesTableAdapter
        '
        Me.KatigoriesTableAdapter.ClearBeforeFill = True
        '
        'KlinesBindingSource
        '
        Me.KlinesBindingSource.DataMember = "klines"
        Me.KlinesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KlinesTableAdapter
        '
        Me.KlinesTableAdapter.ClearBeforeFill = True
        '
        'TipoiBindingSource
        '
        Me.TipoiBindingSource.DataMember = "tipoi"
        Me.TipoiBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TipoiTableAdapter
        '
        Me.TipoiTableAdapter.ClearBeforeFill = True
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.EnforceConstraints = False
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TimokatDiathesBindingSource
        '
        Me.TimokatDiathesBindingSource.DataMember = "TimokatDiathes"
        Me.TimokatDiathesBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'TimokatDiathesTableAdapter
        '
        Me.TimokatDiathesTableAdapter.ClearBeforeFill = True
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
        'PlirotitaDwmFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1516, 1228)
        Me.Controls.Add(Me.ZentralPnl)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "PlirotitaDwmFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PlirotitaDwmFrm"
        Me.DwmPlirotitaPnl.ResumeLayout(False)
        Me.BtnsPnl.ResumeLayout(False)
        Me.DwmPlirot1Pnl.ResumeLayout(False)
        Me.DwmPlirot1Pnl.PerformLayout()
        Me.ZentralPnl.ResumeLayout(False)
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiastatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AfixeisAnaxwriseis2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimokatDiathesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DwmPlirotitaPnl As System.Windows.Forms.Panel
    Friend WithEvents BtnsPnl As System.Windows.Forms.Panel
    Friend WithEvents EktStatusDwmBtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents EpomDwmBtn As System.Windows.Forms.Button
    Friend WithEvents PrDwmBtn As System.Windows.Forms.Button
    Friend WithEvents DwmPlirot2Pnl As System.Windows.Forms.Panel
    Friend WithEvents DwmPlirot1Pnl As System.Windows.Forms.Panel
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
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
    Friend WithEvents ZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents DwmatiastatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiastatusTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiastatusTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents DwmPlirot3Pnl As System.Windows.Forms.Panel
    Friend WithEvents AfixeisAnaxwriseis2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AfixeisAnaxwriseis2TableAdapter As winhotel.dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
    Friend WithEvents KatigoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatigoriesTableAdapter As winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter
    Friend WithEvents KlinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KlinesTableAdapter As winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter
    Friend WithEvents TipoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter
    Friend WithEvents sortkatichk As System.Windows.Forms.CheckBox
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents TimokatDiathesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimokatDiathesTableAdapter As winhotel.dbhotelDataSet1TableAdapters.TimokatDiathesTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
