<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Praktoreia
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
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Καταχώριση Εισπράξεων")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εμφάνιση")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτύπωση")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ημερήσια Κίνηση", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Καρτέλα Πρακτορείου")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εμφάνιση")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτύπ. Υπολοίπων")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ισοζύγιο Πρακτορείων", New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Μεταφορά Υπολοίπων")
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PraktoreiaTreeView = New System.Windows.Forms.TreeView
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.PraktZentralPnl = New System.Windows.Forms.Panel
        Me.MetafYpolPnl = New System.Windows.Forms.Panel
        Me.MetafYpol1Pnl = New System.Windows.Forms.Panel
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.MetafYpolPck = New System.Windows.Forms.DateTimePicker
        Me.MetafYpol2Tbx = New System.Windows.Forms.TextBox
        Me.MetafYpol1Tbx = New System.Windows.Forms.TextBox
        Me.MetafYpolBtn = New System.Windows.Forms.Button
        Me.IsozigioEktPnl = New System.Windows.Forms.Panel
        Me.IsozigEktDtGrd = New System.Windows.Forms.DataGridView
        Me.IsozigioEkt1fPnl = New System.Windows.Forms.Panel
        Me.Isozigio3Tbx = New System.Windows.Forms.TextBox
        Me.Isozigio2Tbx = New System.Windows.Forms.TextBox
        Me.Isozigio1Tbx = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Isozigio2Pck = New System.Windows.Forms.DateTimePicker
        Me.Isozigio1Pck = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.IsozEkt2Rdb = New System.Windows.Forms.RadioButton
        Me.IsozEkt1Rdb = New System.Windows.Forms.RadioButton
        Me.IsozEktBtn = New System.Windows.Forms.Button
        Me.KinisiEmfPnl = New System.Windows.Forms.Panel
        Me.KinisiEmf4Pnl = New System.Windows.Forms.Panel
        Me.KinisiEmf3Pnl = New System.Windows.Forms.Panel
        Me.KinisiEmf2Pnl = New System.Windows.Forms.Panel
        Me.KinisiEmf1Pnl = New System.Windows.Forms.Panel
        Me.KinisiEmfBtn = New System.Windows.Forms.Button
        Me.EmfHmerKiniPraktPck = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.IsozigioEmfPnl = New System.Windows.Forms.Panel
        Me.IsozigioEmf3Pnl = New System.Windows.Forms.Panel
        Me.IsozigioDtGrd = New System.Windows.Forms.DataGridView
        Me.AaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PraktoreioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.XrewseisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EisprakseisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.YpoloipoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsozigiopraktoreiwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.IsozigioEmf1Pnl = New System.Windows.Forms.Panel
        Me.IsozigioImeromErg = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Isozigio2Rdb = New System.Windows.Forms.RadioButton
        Me.Isozigio1Rdb = New System.Windows.Forms.RadioButton
        Me.IsozigioEmfBtn = New System.Windows.Forms.Button
        Me.KartelaPraktPnl = New System.Windows.Forms.Panel
        Me.KartelaPraktΕktBtn = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.KartelaPrakt4Pnl = New System.Windows.Forms.Panel
        Me.KartelaPrakt3Pnl = New System.Windows.Forms.Panel
        Me.KartelaPrakt2Pnl = New System.Windows.Forms.Panel
        Me.KartelaPrakt1Pnl = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ParastCbx = New System.Windows.Forms.ComboBox
        Me.EisprRdb = New System.Windows.Forms.RadioButton
        Me.OlaRdb = New System.Windows.Forms.RadioButton
        Me.ImeromKartelaPrakt2Pck = New System.Windows.Forms.DateTimePicker
        Me.KartelaPraktBtn = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TelousTbx = New System.Windows.Forms.TextBox
        Me.ArxiTbx = New System.Windows.Forms.TextBox
        Me.SimbolCbx = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.PraktTbx = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ImeromKartelaPraktPck = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.EispraxeisKataxPnl = New System.Windows.Forms.Panel
        Me.EispKataxParClearBtn = New System.Windows.Forms.Button
        Me.EispKataxParKataxBtn = New System.Windows.Forms.Button
        Me.EispraxeisKatax3Pnl = New System.Windows.Forms.Panel
        Me.EispKataxParProkTbx = New System.Windows.Forms.TextBox
        Me.Label130 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.EispKataxParTrPlirCbx = New System.Windows.Forms.ComboBox
        Me.Label127 = New System.Windows.Forms.Label
        Me.EispKataxParXrewsiTbx = New System.Windows.Forms.TextBox
        Me.Label131 = New System.Windows.Forms.Label
        Me.EispraxeisKatax2Pnl = New System.Windows.Forms.Panel
        Me.EispKataxParSinPlinTbx = New System.Windows.Forms.TextBox
        Me.Label129 = New System.Windows.Forms.Label
        Me.Button6 = New System.Windows.Forms.Button
        Me.EispKataxParEisprTbx = New System.Windows.Forms.TextBox
        Me.Label128 = New System.Windows.Forms.Label
        Me.EispraxeisKatax1Pnl = New System.Windows.Forms.Panel
        Me.KwdPrktTbx = New System.Windows.Forms.TextBox
        Me.EispKataxParSucheBtn = New System.Windows.Forms.Button
        Me.EispKataxParXrewsRdb = New System.Windows.Forms.RadioButton
        Me.EispKataxParEispRdb = New System.Windows.Forms.RadioButton
        Me.Label144 = New System.Windows.Forms.Label
        Me.Label140 = New System.Windows.Forms.Label
        Me.EispKataxPar3Tbx = New System.Windows.Forms.TextBox
        Me.EispraxeisKataxAitTbx = New System.Windows.Forms.TextBox
        Me.Label139 = New System.Windows.Forms.Label
        Me.EispKataxPar2Tbx = New System.Windows.Forms.TextBox
        Me.EispKataxPar1Tbx = New System.Windows.Forms.TextBox
        Me.EispraxeisKataxPraktTbx = New System.Windows.Forms.TextBox
        Me.Label138 = New System.Windows.Forms.Label
        Me.Label141 = New System.Windows.Forms.Label
        Me.EispraxeisKataxPck = New System.Windows.Forms.DateTimePicker
        Me.Label142 = New System.Windows.Forms.Label
        Me.Label143 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.KinisiPraktEktPnl = New System.Windows.Forms.Panel
        Me.KinisiPraktEkt1Pnl = New System.Windows.Forms.Panel
        Me.pBar1 = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.KinisiPraktEkt2Pck = New System.Windows.Forms.DateTimePicker
        Me.KinisiPraktEktBtn = New System.Windows.Forms.Button
        Me.KinisiPraktEkt1Pck = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.EtiketaPraktPnl = New System.Windows.Forms.Panel
        Me.EtiketaLbl = New System.Windows.Forms.Label
        Me.EisprakseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EisprakseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.SimbolaiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimbolaiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
        Me.EktpraktimerkinisiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter
        Me.PraktoreiametimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiametimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiametimologiaTableAdapter
        Me.PraktoreiameeisprakseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiameeisprakseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiameeisprakseisTableAdapter
        Me.PraktoreiameparastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiameparastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiameparastatikaTableAdapter
        Me.MetaforaypoloipwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MetaforaypoloipwnTableAdapter = New winhotel.dbhotelDataSetTableAdapters.metaforaypoloipwnTableAdapter
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PraktZentralPnl.SuspendLayout()
        Me.MetafYpolPnl.SuspendLayout()
        Me.MetafYpol1Pnl.SuspendLayout()
        Me.IsozigioEktPnl.SuspendLayout()
        CType(Me.IsozigEktDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IsozigioEkt1fPnl.SuspendLayout()
        Me.KinisiEmfPnl.SuspendLayout()
        Me.KinisiEmf1Pnl.SuspendLayout()
        Me.IsozigioEmfPnl.SuspendLayout()
        Me.IsozigioEmf3Pnl.SuspendLayout()
        CType(Me.IsozigioDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IsozigiopraktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.IsozigioEmf1Pnl.SuspendLayout()
        Me.KartelaPraktPnl.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KartelaPrakt1Pnl.SuspendLayout()
        Me.EispraxeisKataxPnl.SuspendLayout()
        Me.EispraxeisKatax3Pnl.SuspendLayout()
        Me.EispraxeisKatax2Pnl.SuspendLayout()
        Me.EispraxeisKatax1Pnl.SuspendLayout()
        Me.KinisiPraktEktPnl.SuspendLayout()
        Me.KinisiPraktEkt1Pnl.SuspendLayout()
        Me.EtiketaPraktPnl.SuspendLayout()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EktpraktimerkinisiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiametimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiameeisprakseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiameparastatikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MetaforaypoloipwnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PraktoreiaTreeView
        '
        Me.PraktoreiaTreeView.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PraktoreiaTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PraktoreiaTreeView.Location = New System.Drawing.Point(0, 0)
        Me.PraktoreiaTreeView.Name = "PraktoreiaTreeView"
        TreeNode10.Name = "Eispraxeis"
        TreeNode10.Text = "Καταχώριση Εισπράξεων"
        TreeNode11.Name = "EmfHmerKin"
        TreeNode11.Text = "Εμφάνιση"
        TreeNode12.Name = "EktHmerKin"
        TreeNode12.Text = "Εκτύπωση"
        TreeNode13.Name = "Node0"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode13.Text = "Ημερήσια Κίνηση"
        TreeNode14.Name = "emf_kart_prakt"
        TreeNode14.Text = "Καρτέλα Πρακτορείου"
        TreeNode15.Name = "emf_isozig_prakt"
        TreeNode15.Text = "Εμφάνιση"
        TreeNode16.Name = "ekt_isozig_prakt"
        TreeNode16.Text = "Εκτύπ. Υπολοίπων"
        TreeNode17.Name = "Node0"
        TreeNode17.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode17.Text = "Ισοζύγιο Πρακτορείων"
        TreeNode18.Name = "metafora_ypoloipwn"
        TreeNode18.Text = "Μεταφορά Υπολοίπων"
        Me.PraktoreiaTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode13, TreeNode14, TreeNode17, TreeNode18})
        Me.PraktoreiaTreeView.Size = New System.Drawing.Size(180, 766)
        Me.PraktoreiaTreeView.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PraktoreiaTreeView)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PraktZentralPnl)
        Me.SplitContainer1.Size = New System.Drawing.Size(1059, 766)
        Me.SplitContainer1.SplitterDistance = 180
        Me.SplitContainer1.TabIndex = 1
        '
        'PraktZentralPnl
        '
        Me.PraktZentralPnl.Controls.Add(Me.MetafYpolPnl)
        Me.PraktZentralPnl.Controls.Add(Me.IsozigioEktPnl)
        Me.PraktZentralPnl.Controls.Add(Me.KinisiEmfPnl)
        Me.PraktZentralPnl.Controls.Add(Me.IsozigioEmfPnl)
        Me.PraktZentralPnl.Controls.Add(Me.KartelaPraktPnl)
        Me.PraktZentralPnl.Controls.Add(Me.EispraxeisKataxPnl)
        Me.PraktZentralPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.PraktZentralPnl.Controls.Add(Me.KinisiPraktEktPnl)
        Me.PraktZentralPnl.Controls.Add(Me.EtiketaPraktPnl)
        Me.PraktZentralPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PraktZentralPnl.Location = New System.Drawing.Point(0, 0)
        Me.PraktZentralPnl.Name = "PraktZentralPnl"
        Me.PraktZentralPnl.Size = New System.Drawing.Size(875, 766)
        Me.PraktZentralPnl.TabIndex = 0
        '
        'MetafYpolPnl
        '
        Me.MetafYpolPnl.Controls.Add(Me.MetafYpol1Pnl)
        Me.MetafYpolPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.MetafYpolPnl.Location = New System.Drawing.Point(25, 672)
        Me.MetafYpolPnl.Name = "MetafYpolPnl"
        Me.MetafYpolPnl.Size = New System.Drawing.Size(815, 10)
        Me.MetafYpolPnl.TabIndex = 49
        '
        'MetafYpol1Pnl
        '
        Me.MetafYpol1Pnl.BackColor = System.Drawing.Color.Silver
        Me.MetafYpol1Pnl.Controls.Add(Me.Label16)
        Me.MetafYpol1Pnl.Controls.Add(Me.Label15)
        Me.MetafYpol1Pnl.Controls.Add(Me.Label14)
        Me.MetafYpol1Pnl.Controls.Add(Me.MetafYpolPck)
        Me.MetafYpol1Pnl.Controls.Add(Me.MetafYpol2Tbx)
        Me.MetafYpol1Pnl.Controls.Add(Me.MetafYpol1Tbx)
        Me.MetafYpol1Pnl.Controls.Add(Me.MetafYpolBtn)
        Me.MetafYpol1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.MetafYpol1Pnl.Location = New System.Drawing.Point(10, 23)
        Me.MetafYpol1Pnl.Name = "MetafYpol1Pnl"
        Me.MetafYpol1Pnl.Size = New System.Drawing.Size(763, 202)
        Me.MetafYpol1Pnl.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(95, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(237, 16)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Ημερ/νία Μεταφοράς Υπολοίπων:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(252, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 16)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Νέα Χρήση:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(185, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(153, 16)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Προηγούμενη Χρήση:"
        '
        'MetafYpolPck
        '
        Me.MetafYpolPck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetafYpolPck.Location = New System.Drawing.Point(344, 112)
        Me.MetafYpolPck.Name = "MetafYpolPck"
        Me.MetafYpolPck.Size = New System.Drawing.Size(105, 22)
        Me.MetafYpolPck.TabIndex = 57
        '
        'MetafYpol2Tbx
        '
        Me.MetafYpol2Tbx.Location = New System.Drawing.Point(344, 69)
        Me.MetafYpol2Tbx.MaxLength = 4
        Me.MetafYpol2Tbx.Name = "MetafYpol2Tbx"
        Me.MetafYpol2Tbx.Size = New System.Drawing.Size(100, 22)
        Me.MetafYpol2Tbx.TabIndex = 56
        Me.MetafYpol2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MetafYpol1Tbx
        '
        Me.MetafYpol1Tbx.Location = New System.Drawing.Point(344, 19)
        Me.MetafYpol1Tbx.MaxLength = 4
        Me.MetafYpol1Tbx.Name = "MetafYpol1Tbx"
        Me.MetafYpol1Tbx.ReadOnly = True
        Me.MetafYpol1Tbx.Size = New System.Drawing.Size(100, 22)
        Me.MetafYpol1Tbx.TabIndex = 55
        Me.MetafYpol1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MetafYpolBtn
        '
        Me.MetafYpolBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.MetafYpolBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetafYpolBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MetafYpolBtn.Location = New System.Drawing.Point(293, 154)
        Me.MetafYpolBtn.Name = "MetafYpolBtn"
        Me.MetafYpolBtn.Size = New System.Drawing.Size(174, 24)
        Me.MetafYpolBtn.TabIndex = 54
        Me.MetafYpolBtn.Text = "Μεταφορά"
        Me.MetafYpolBtn.UseVisualStyleBackColor = True
        '
        'IsozigioEktPnl
        '
        Me.IsozigioEktPnl.Controls.Add(Me.IsozigEktDtGrd)
        Me.IsozigioEktPnl.Controls.Add(Me.IsozigioEkt1fPnl)
        Me.IsozigioEktPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEktPnl.Location = New System.Drawing.Point(50, 649)
        Me.IsozigioEktPnl.Name = "IsozigioEktPnl"
        Me.IsozigioEktPnl.Size = New System.Drawing.Size(815, 10)
        Me.IsozigioEktPnl.TabIndex = 48
        '
        'IsozigEktDtGrd
        '
        Me.IsozigEktDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IsozigEktDtGrd.Location = New System.Drawing.Point(594, 232)
        Me.IsozigEktDtGrd.Name = "IsozigEktDtGrd"
        Me.IsozigEktDtGrd.Size = New System.Drawing.Size(19, 150)
        Me.IsozigEktDtGrd.TabIndex = 2
        Me.IsozigEktDtGrd.Visible = False
        '
        'IsozigioEkt1fPnl
        '
        Me.IsozigioEkt1fPnl.BackColor = System.Drawing.Color.Silver
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Isozigio3Tbx)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Isozigio2Tbx)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Isozigio1Tbx)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Label13)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Label11)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Isozigio2Pck)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Isozigio1Pck)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.Label12)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.IsozEkt2Rdb)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.IsozEkt1Rdb)
        Me.IsozigioEkt1fPnl.Controls.Add(Me.IsozEktBtn)
        Me.IsozigioEkt1fPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEkt1fPnl.Location = New System.Drawing.Point(10, 23)
        Me.IsozigioEkt1fPnl.Name = "IsozigioEkt1fPnl"
        Me.IsozigioEkt1fPnl.Size = New System.Drawing.Size(763, 202)
        Me.IsozigioEkt1fPnl.TabIndex = 1
        '
        'Isozigio3Tbx
        '
        Me.Isozigio3Tbx.Location = New System.Drawing.Point(409, 70)
        Me.Isozigio3Tbx.MaxLength = 3
        Me.Isozigio3Tbx.Name = "Isozigio3Tbx"
        Me.Isozigio3Tbx.Size = New System.Drawing.Size(37, 22)
        Me.Isozigio3Tbx.TabIndex = 65
        Me.Isozigio3Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Isozigio2Tbx
        '
        Me.Isozigio2Tbx.Location = New System.Drawing.Point(348, 70)
        Me.Isozigio2Tbx.MaxLength = 3
        Me.Isozigio2Tbx.Name = "Isozigio2Tbx"
        Me.Isozigio2Tbx.Size = New System.Drawing.Size(37, 22)
        Me.Isozigio2Tbx.TabIndex = 64
        Me.Isozigio2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Isozigio1Tbx
        '
        Me.Isozigio1Tbx.Location = New System.Drawing.Point(285, 70)
        Me.Isozigio1Tbx.MaxLength = 3
        Me.Isozigio1Tbx.Name = "Isozigio1Tbx"
        Me.Isozigio1Tbx.Size = New System.Drawing.Size(37, 22)
        Me.Isozigio1Tbx.TabIndex = 63
        Me.Isozigio1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(132, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 16)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = " Ηλικία Υπολοίπου:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(397, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 16)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "μέχρι Ημερομηνία:"
        '
        'Isozigio2Pck
        '
        Me.Isozigio2Pck.Location = New System.Drawing.Point(536, 29)
        Me.Isozigio2Pck.Name = "Isozigio2Pck"
        Me.Isozigio2Pck.Size = New System.Drawing.Size(200, 22)
        Me.Isozigio2Pck.TabIndex = 60
        '
        'Isozigio1Pck
        '
        Me.Isozigio1Pck.Location = New System.Drawing.Point(155, 26)
        Me.Isozigio1Pck.Name = "Isozigio1Pck"
        Me.Isozigio1Pck.Size = New System.Drawing.Size(200, 22)
        Me.Isozigio1Pck.TabIndex = 59
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 16)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = " από Ημερομηνία:"
        '
        'IsozEkt2Rdb
        '
        Me.IsozEkt2Rdb.AutoSize = True
        Me.IsozEkt2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozEkt2Rdb.Location = New System.Drawing.Point(400, 111)
        Me.IsozEkt2Rdb.Name = "IsozEkt2Rdb"
        Me.IsozEkt2Rdb.Size = New System.Drawing.Size(54, 20)
        Me.IsozEkt2Rdb.TabIndex = 57
        Me.IsozEkt2Rdb.TabStop = True
        Me.IsozEkt2Rdb.Text = "Ολα"
        Me.IsozEkt2Rdb.UseVisualStyleBackColor = True
        '
        'IsozEkt1Rdb
        '
        Me.IsozEkt1Rdb.AutoSize = True
        Me.IsozEkt1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozEkt1Rdb.Location = New System.Drawing.Point(266, 111)
        Me.IsozEkt1Rdb.Name = "IsozEkt1Rdb"
        Me.IsozEkt1Rdb.Size = New System.Drawing.Size(96, 20)
        Me.IsozEkt1Rdb.TabIndex = 56
        Me.IsozEkt1Rdb.TabStop = True
        Me.IsozEkt1Rdb.Text = " με Κίνηση"
        Me.IsozEkt1Rdb.UseVisualStyleBackColor = True
        '
        'IsozEktBtn
        '
        Me.IsozEktBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.IsozEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IsozEktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.IsozEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozEktBtn.Location = New System.Drawing.Point(279, 153)
        Me.IsozEktBtn.Name = "IsozEktBtn"
        Me.IsozEktBtn.Size = New System.Drawing.Size(174, 24)
        Me.IsozEktBtn.TabIndex = 54
        Me.IsozEktBtn.Text = "Προεπισκόπηση"
        Me.IsozEktBtn.UseVisualStyleBackColor = True
        '
        'KinisiEmfPnl
        '
        Me.KinisiEmfPnl.Controls.Add(Me.KinisiEmf4Pnl)
        Me.KinisiEmfPnl.Controls.Add(Me.KinisiEmf3Pnl)
        Me.KinisiEmfPnl.Controls.Add(Me.KinisiEmf2Pnl)
        Me.KinisiEmfPnl.Controls.Add(Me.KinisiEmf1Pnl)
        Me.KinisiEmfPnl.Location = New System.Drawing.Point(21, 94)
        Me.KinisiEmfPnl.Name = "KinisiEmfPnl"
        Me.KinisiEmfPnl.Size = New System.Drawing.Size(806, 10)
        Me.KinisiEmfPnl.TabIndex = 43
        '
        'KinisiEmf4Pnl
        '
        Me.KinisiEmf4Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf4Pnl.Location = New System.Drawing.Point(17, 473)
        Me.KinisiEmf4Pnl.Name = "KinisiEmf4Pnl"
        Me.KinisiEmf4Pnl.Size = New System.Drawing.Size(777, 47)
        Me.KinisiEmf4Pnl.TabIndex = 3
        '
        'KinisiEmf3Pnl
        '
        Me.KinisiEmf3Pnl.AutoScroll = True
        Me.KinisiEmf3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf3Pnl.Location = New System.Drawing.Point(17, 128)
        Me.KinisiEmf3Pnl.Name = "KinisiEmf3Pnl"
        Me.KinisiEmf3Pnl.Size = New System.Drawing.Size(777, 341)
        Me.KinisiEmf3Pnl.TabIndex = 2
        '
        'KinisiEmf2Pnl
        '
        Me.KinisiEmf2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf2Pnl.Location = New System.Drawing.Point(17, 86)
        Me.KinisiEmf2Pnl.Name = "KinisiEmf2Pnl"
        Me.KinisiEmf2Pnl.Size = New System.Drawing.Size(777, 39)
        Me.KinisiEmf2Pnl.TabIndex = 1
        '
        'KinisiEmf1Pnl
        '
        Me.KinisiEmf1Pnl.BackColor = System.Drawing.Color.Silver
        Me.KinisiEmf1Pnl.Controls.Add(Me.KinisiEmfBtn)
        Me.KinisiEmf1Pnl.Controls.Add(Me.EmfHmerKiniPraktPck)
        Me.KinisiEmf1Pnl.Controls.Add(Me.Label1)
        Me.KinisiEmf1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf1Pnl.Location = New System.Drawing.Point(17, 28)
        Me.KinisiEmf1Pnl.Name = "KinisiEmf1Pnl"
        Me.KinisiEmf1Pnl.Size = New System.Drawing.Size(777, 55)
        Me.KinisiEmf1Pnl.TabIndex = 0
        '
        'KinisiEmfBtn
        '
        Me.KinisiEmfBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KinisiEmfBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.KinisiEmfBtn.Location = New System.Drawing.Point(463, 20)
        Me.KinisiEmfBtn.Name = "KinisiEmfBtn"
        Me.KinisiEmfBtn.Size = New System.Drawing.Size(57, 21)
        Me.KinisiEmfBtn.TabIndex = 45
        Me.KinisiEmfBtn.UseVisualStyleBackColor = True
        '
        'EmfHmerKiniPraktPck
        '
        Me.EmfHmerKiniPraktPck.Location = New System.Drawing.Point(248, 17)
        Me.EmfHmerKiniPraktPck.Name = "EmfHmerKiniPraktPck"
        Me.EmfHmerKiniPraktPck.Size = New System.Drawing.Size(200, 22)
        Me.EmfHmerKiniPraktPck.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(140, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = " Ημερομηνία:"
        '
        'IsozigioEmfPnl
        '
        Me.IsozigioEmfPnl.Controls.Add(Me.IsozigioEmf3Pnl)
        Me.IsozigioEmfPnl.Controls.Add(Me.IsozigioEmf1Pnl)
        Me.IsozigioEmfPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEmfPnl.Location = New System.Drawing.Point(10, 139)
        Me.IsozigioEmfPnl.Name = "IsozigioEmfPnl"
        Me.IsozigioEmfPnl.Size = New System.Drawing.Size(818, 12)
        Me.IsozigioEmfPnl.TabIndex = 47
        '
        'IsozigioEmf3Pnl
        '
        Me.IsozigioEmf3Pnl.AutoScroll = True
        Me.IsozigioEmf3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.IsozigioEmf3Pnl.Controls.Add(Me.IsozigioDtGrd)
        Me.IsozigioEmf3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEmf3Pnl.Location = New System.Drawing.Point(10, 128)
        Me.IsozigioEmf3Pnl.Name = "IsozigioEmf3Pnl"
        Me.IsozigioEmf3Pnl.Size = New System.Drawing.Size(763, 524)
        Me.IsozigioEmf3Pnl.TabIndex = 4
        '
        'IsozigioDtGrd
        '
        Me.IsozigioDtGrd.AllowUserToAddRows = False
        Me.IsozigioDtGrd.AllowUserToDeleteRows = False
        Me.IsozigioDtGrd.AutoGenerateColumns = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsozigioDtGrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.IsozigioDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IsozigioDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AaDataGridViewTextBoxColumn, Me.PraktoreioDataGridViewTextBoxColumn, Me.XrewseisDataGridViewTextBoxColumn, Me.EisprakseisDataGridViewTextBoxColumn, Me.YpoloipoDataGridViewTextBoxColumn})
        Me.IsozigioDtGrd.DataSource = Me.IsozigiopraktoreiwnBindingSource
        Me.IsozigioDtGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IsozigioDtGrd.Location = New System.Drawing.Point(0, 0)
        Me.IsozigioDtGrd.Name = "IsozigioDtGrd"
        Me.IsozigioDtGrd.Size = New System.Drawing.Size(763, 524)
        Me.IsozigioDtGrd.TabIndex = 48
        '
        'AaDataGridViewTextBoxColumn
        '
        Me.AaDataGridViewTextBoxColumn.DataPropertyName = "aa"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.AaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.AaDataGridViewTextBoxColumn.HeaderText = "A/A"
        Me.AaDataGridViewTextBoxColumn.Name = "AaDataGridViewTextBoxColumn"
        Me.AaDataGridViewTextBoxColumn.ReadOnly = True
        Me.AaDataGridViewTextBoxColumn.Width = 50
        '
        'PraktoreioDataGridViewTextBoxColumn
        '
        Me.PraktoreioDataGridViewTextBoxColumn.DataPropertyName = "praktoreio"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PraktoreioDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.PraktoreioDataGridViewTextBoxColumn.HeaderText = "Επωνυμία Πρακτορείου"
        Me.PraktoreioDataGridViewTextBoxColumn.Name = "PraktoreioDataGridViewTextBoxColumn"
        Me.PraktoreioDataGridViewTextBoxColumn.ReadOnly = True
        Me.PraktoreioDataGridViewTextBoxColumn.Width = 300
        '
        'XrewseisDataGridViewTextBoxColumn
        '
        Me.XrewseisDataGridViewTextBoxColumn.DataPropertyName = "xrewseis"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0,00"
        Me.XrewseisDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.XrewseisDataGridViewTextBoxColumn.HeaderText = "Χρεώσεις"
        Me.XrewseisDataGridViewTextBoxColumn.Name = "XrewseisDataGridViewTextBoxColumn"
        Me.XrewseisDataGridViewTextBoxColumn.ReadOnly = True
        Me.XrewseisDataGridViewTextBoxColumn.Width = 110
        '
        'EisprakseisDataGridViewTextBoxColumn
        '
        Me.EisprakseisDataGridViewTextBoxColumn.DataPropertyName = "eisprakseis"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0,00"
        Me.EisprakseisDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.EisprakseisDataGridViewTextBoxColumn.HeaderText = "Εισπράξεις"
        Me.EisprakseisDataGridViewTextBoxColumn.Name = "EisprakseisDataGridViewTextBoxColumn"
        Me.EisprakseisDataGridViewTextBoxColumn.ReadOnly = True
        Me.EisprakseisDataGridViewTextBoxColumn.Width = 110
        '
        'YpoloipoDataGridViewTextBoxColumn
        '
        Me.YpoloipoDataGridViewTextBoxColumn.DataPropertyName = "ypoloipo"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0,00"
        Me.YpoloipoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle12
        Me.YpoloipoDataGridViewTextBoxColumn.HeaderText = "Υπόλοιπο"
        Me.YpoloipoDataGridViewTextBoxColumn.Name = "YpoloipoDataGridViewTextBoxColumn"
        Me.YpoloipoDataGridViewTextBoxColumn.ReadOnly = True
        Me.YpoloipoDataGridViewTextBoxColumn.Width = 110
        '
        'IsozigiopraktoreiwnBindingSource
        '
        Me.IsozigiopraktoreiwnBindingSource.DataMember = "isozigio_praktoreiwn"
        Me.IsozigiopraktoreiwnBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IsozigioEmf1Pnl
        '
        Me.IsozigioEmf1Pnl.BackColor = System.Drawing.Color.Silver
        Me.IsozigioEmf1Pnl.Controls.Add(Me.IsozigioImeromErg)
        Me.IsozigioEmf1Pnl.Controls.Add(Me.Label10)
        Me.IsozigioEmf1Pnl.Controls.Add(Me.Isozigio2Rdb)
        Me.IsozigioEmf1Pnl.Controls.Add(Me.Isozigio1Rdb)
        Me.IsozigioEmf1Pnl.Controls.Add(Me.IsozigioEmfBtn)
        Me.IsozigioEmf1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEmf1Pnl.Location = New System.Drawing.Point(10, 23)
        Me.IsozigioEmf1Pnl.Name = "IsozigioEmf1Pnl"
        Me.IsozigioEmf1Pnl.Size = New System.Drawing.Size(763, 103)
        Me.IsozigioEmf1Pnl.TabIndex = 1
        '
        'IsozigioImeromErg
        '
        Me.IsozigioImeromErg.AutoSize = True
        Me.IsozigioImeromErg.ForeColor = System.Drawing.Color.Maroon
        Me.IsozigioImeromErg.Location = New System.Drawing.Point(174, 10)
        Me.IsozigioImeromErg.Name = "IsozigioImeromErg"
        Me.IsozigioImeromErg.Size = New System.Drawing.Size(165, 16)
        Me.IsozigioImeromErg.TabIndex = 59
        Me.IsozigioImeromErg.Text = "Τρέχουσα Ημερομηνία:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(165, 16)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Τρέχουσα Ημερομηνία:"
        '
        'Isozigio2Rdb
        '
        Me.Isozigio2Rdb.AutoSize = True
        Me.Isozigio2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Isozigio2Rdb.Location = New System.Drawing.Point(420, 26)
        Me.Isozigio2Rdb.Name = "Isozigio2Rdb"
        Me.Isozigio2Rdb.Size = New System.Drawing.Size(54, 20)
        Me.Isozigio2Rdb.TabIndex = 57
        Me.Isozigio2Rdb.TabStop = True
        Me.Isozigio2Rdb.Text = "Ολα"
        Me.Isozigio2Rdb.UseVisualStyleBackColor = True
        '
        'Isozigio1Rdb
        '
        Me.Isozigio1Rdb.AutoSize = True
        Me.Isozigio1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Isozigio1Rdb.Location = New System.Drawing.Point(286, 26)
        Me.Isozigio1Rdb.Name = "Isozigio1Rdb"
        Me.Isozigio1Rdb.Size = New System.Drawing.Size(96, 20)
        Me.Isozigio1Rdb.TabIndex = 56
        Me.Isozigio1Rdb.TabStop = True
        Me.Isozigio1Rdb.Text = " με Κίνηση"
        Me.Isozigio1Rdb.UseVisualStyleBackColor = True
        '
        'IsozigioEmfBtn
        '
        Me.IsozigioEmfBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.IsozigioEmfBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.IsozigioEmfBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.IsozigioEmfBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozigioEmfBtn.Location = New System.Drawing.Point(323, 64)
        Me.IsozigioEmfBtn.Name = "IsozigioEmfBtn"
        Me.IsozigioEmfBtn.Size = New System.Drawing.Size(127, 24)
        Me.IsozigioEmfBtn.TabIndex = 54
        Me.IsozigioEmfBtn.Text = "Εμφάνιση"
        Me.IsozigioEmfBtn.UseVisualStyleBackColor = True
        '
        'KartelaPraktPnl
        '
        Me.KartelaPraktPnl.Controls.Add(Me.KartelaPraktΕktBtn)
        Me.KartelaPraktPnl.Controls.Add(Me.DataGridView1)
        Me.KartelaPraktPnl.Controls.Add(Me.KartelaPrakt4Pnl)
        Me.KartelaPraktPnl.Controls.Add(Me.KartelaPrakt3Pnl)
        Me.KartelaPraktPnl.Controls.Add(Me.KartelaPrakt2Pnl)
        Me.KartelaPraktPnl.Controls.Add(Me.KartelaPrakt1Pnl)
        Me.KartelaPraktPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPraktPnl.Location = New System.Drawing.Point(17, 121)
        Me.KartelaPraktPnl.Name = "KartelaPraktPnl"
        Me.KartelaPraktPnl.Size = New System.Drawing.Size(848, 11)
        Me.KartelaPraktPnl.TabIndex = 46
        '
        'KartelaPraktΕktBtn
        '
        Me.KartelaPraktΕktBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.KartelaPraktΕktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KartelaPraktΕktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.KartelaPraktΕktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KartelaPraktΕktBtn.Location = New System.Drawing.Point(318, 634)
        Me.KartelaPraktΕktBtn.Name = "KartelaPraktΕktBtn"
        Me.KartelaPraktΕktBtn.Size = New System.Drawing.Size(166, 24)
        Me.KartelaPraktΕktBtn.TabIndex = 55
        Me.KartelaPraktΕktBtn.Text = "Προεπισκόπηση"
        Me.KartelaPraktΕktBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(834, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(10, 150)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.Visible = False
        '
        'KartelaPrakt4Pnl
        '
        Me.KartelaPrakt4Pnl.AutoScroll = True
        Me.KartelaPrakt4Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt4Pnl.Location = New System.Drawing.Point(10, 555)
        Me.KartelaPrakt4Pnl.Name = "KartelaPrakt4Pnl"
        Me.KartelaPrakt4Pnl.Size = New System.Drawing.Size(804, 67)
        Me.KartelaPrakt4Pnl.TabIndex = 5
        '
        'KartelaPrakt3Pnl
        '
        Me.KartelaPrakt3Pnl.AutoScroll = True
        Me.KartelaPrakt3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt3Pnl.Location = New System.Drawing.Point(10, 235)
        Me.KartelaPrakt3Pnl.Name = "KartelaPrakt3Pnl"
        Me.KartelaPrakt3Pnl.Size = New System.Drawing.Size(804, 317)
        Me.KartelaPrakt3Pnl.TabIndex = 4
        '
        'KartelaPrakt2Pnl
        '
        Me.KartelaPrakt2Pnl.AutoScroll = True
        Me.KartelaPrakt2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt2Pnl.Location = New System.Drawing.Point(10, 191)
        Me.KartelaPrakt2Pnl.Name = "KartelaPrakt2Pnl"
        Me.KartelaPrakt2Pnl.Size = New System.Drawing.Size(804, 41)
        Me.KartelaPrakt2Pnl.TabIndex = 3
        '
        'KartelaPrakt1Pnl
        '
        Me.KartelaPrakt1Pnl.BackColor = System.Drawing.Color.Silver
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label9)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label8)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.ParastCbx)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.EisprRdb)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.OlaRdb)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.ImeromKartelaPrakt2Pck)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.KartelaPraktBtn)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label7)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label6)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.TelousTbx)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.ArxiTbx)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.SimbolCbx)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label21)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.PraktTbx)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label4)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.ImeromKartelaPraktPck)
        Me.KartelaPrakt1Pnl.Controls.Add(Me.Label5)
        Me.KartelaPrakt1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt1Pnl.Location = New System.Drawing.Point(10, 23)
        Me.KartelaPrakt1Pnl.Name = "KartelaPrakt1Pnl"
        Me.KartelaPrakt1Pnl.Size = New System.Drawing.Size(804, 164)
        Me.KartelaPrakt1Pnl.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(390, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "μέχρι:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label8.Location = New System.Drawing.Point(189, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Παραστατικά:"
        '
        'ParastCbx
        '
        Me.ParastCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ParastCbx.ForeColor = System.Drawing.Color.Blue
        Me.ParastCbx.FormattingEnabled = True
        Me.ParastCbx.Location = New System.Drawing.Point(294, 84)
        Me.ParastCbx.Name = "ParastCbx"
        Me.ParastCbx.Size = New System.Drawing.Size(171, 24)
        Me.ParastCbx.TabIndex = 58
        '
        'EisprRdb
        '
        Me.EisprRdb.AutoSize = True
        Me.EisprRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EisprRdb.Location = New System.Drawing.Point(77, 85)
        Me.EisprRdb.Name = "EisprRdb"
        Me.EisprRdb.Size = New System.Drawing.Size(104, 20)
        Me.EisprRdb.TabIndex = 57
        Me.EisprRdb.TabStop = True
        Me.EisprRdb.Text = "Εισπράξεις"
        Me.EisprRdb.UseVisualStyleBackColor = True
        '
        'OlaRdb
        '
        Me.OlaRdb.AutoSize = True
        Me.OlaRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OlaRdb.Location = New System.Drawing.Point(17, 85)
        Me.OlaRdb.Name = "OlaRdb"
        Me.OlaRdb.Size = New System.Drawing.Size(54, 20)
        Me.OlaRdb.TabIndex = 56
        Me.OlaRdb.TabStop = True
        Me.OlaRdb.Text = "Ολα"
        Me.OlaRdb.UseVisualStyleBackColor = True
        '
        'ImeromKartelaPrakt2Pck
        '
        Me.ImeromKartelaPrakt2Pck.Location = New System.Drawing.Point(444, 43)
        Me.ImeromKartelaPrakt2Pck.Name = "ImeromKartelaPrakt2Pck"
        Me.ImeromKartelaPrakt2Pck.Size = New System.Drawing.Size(200, 22)
        Me.ImeromKartelaPrakt2Pck.TabIndex = 55
        '
        'KartelaPraktBtn
        '
        Me.KartelaPraktBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.KartelaPraktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KartelaPraktBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.KartelaPraktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KartelaPraktBtn.Location = New System.Drawing.Point(321, 126)
        Me.KartelaPraktBtn.Name = "KartelaPraktBtn"
        Me.KartelaPraktBtn.Size = New System.Drawing.Size(127, 24)
        Me.KartelaPraktBtn.TabIndex = 54
        Me.KartelaPraktBtn.Text = "Εμφάνιση"
        Me.KartelaPraktBtn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.Location = New System.Drawing.Point(623, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "A/A τέλους:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(469, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "A/A αρχής:"
        '
        'TelousTbx
        '
        Me.TelousTbx.Location = New System.Drawing.Point(720, 84)
        Me.TelousTbx.MaxLength = 6
        Me.TelousTbx.Name = "TelousTbx"
        Me.TelousTbx.Size = New System.Drawing.Size(61, 22)
        Me.TelousTbx.TabIndex = 51
        '
        'ArxiTbx
        '
        Me.ArxiTbx.Location = New System.Drawing.Point(556, 83)
        Me.ArxiTbx.MaxLength = 6
        Me.ArxiTbx.Name = "ArxiTbx"
        Me.ArxiTbx.Size = New System.Drawing.Size(61, 22)
        Me.ArxiTbx.TabIndex = 50
        '
        'SimbolCbx
        '
        Me.SimbolCbx.Enabled = False
        Me.SimbolCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimbolCbx.ForeColor = System.Drawing.Color.Blue
        Me.SimbolCbx.FormattingEnabled = True
        Me.SimbolCbx.Location = New System.Drawing.Point(532, 10)
        Me.SimbolCbx.Name = "SimbolCbx"
        Me.SimbolCbx.Size = New System.Drawing.Size(94, 24)
        Me.SimbolCbx.TabIndex = 48
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label21.Location = New System.Drawing.Point(443, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(85, 16)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Συμβόλαιο:"
        '
        'PraktTbx
        '
        Me.PraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktTbx.Location = New System.Drawing.Point(244, 10)
        Me.PraktTbx.Name = "PraktTbx"
        Me.PraktTbx.ReadOnly = True
        Me.PraktTbx.Size = New System.Drawing.Size(169, 22)
        Me.PraktTbx.TabIndex = 46
        Me.PraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(143, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 16)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Πρακτορείο:"
        '
        'ImeromKartelaPraktPck
        '
        Me.ImeromKartelaPraktPck.Location = New System.Drawing.Point(161, 43)
        Me.ImeromKartelaPraktPck.Name = "ImeromKartelaPraktPck"
        Me.ImeromKartelaPraktPck.Size = New System.Drawing.Size(200, 22)
        Me.ImeromKartelaPraktPck.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Περίοδος από:"
        '
        'EispraxeisKataxPnl
        '
        Me.EispraxeisKataxPnl.Controls.Add(Me.EispKataxParClearBtn)
        Me.EispraxeisKataxPnl.Controls.Add(Me.EispKataxParKataxBtn)
        Me.EispraxeisKataxPnl.Controls.Add(Me.EispraxeisKatax3Pnl)
        Me.EispraxeisKataxPnl.Controls.Add(Me.EispraxeisKatax2Pnl)
        Me.EispraxeisKataxPnl.Controls.Add(Me.EispraxeisKatax1Pnl)
        Me.EispraxeisKataxPnl.Location = New System.Drawing.Point(13, 165)
        Me.EispraxeisKataxPnl.Name = "EispraxeisKataxPnl"
        Me.EispraxeisKataxPnl.Size = New System.Drawing.Size(795, 10)
        Me.EispraxeisKataxPnl.TabIndex = 42
        '
        'EispKataxParClearBtn
        '
        Me.EispKataxParClearBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EispKataxParClearBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispKataxParClearBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.EispKataxParClearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParClearBtn.Location = New System.Drawing.Point(416, 297)
        Me.EispKataxParClearBtn.Name = "EispKataxParClearBtn"
        Me.EispKataxParClearBtn.Size = New System.Drawing.Size(158, 23)
        Me.EispKataxParClearBtn.TabIndex = 49
        Me.EispKataxParClearBtn.Text = "Καθαρισμός"
        Me.EispKataxParClearBtn.UseVisualStyleBackColor = True
        '
        'EispKataxParKataxBtn
        '
        Me.EispKataxParKataxBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EispKataxParKataxBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispKataxParKataxBtn.Image = Global.winhotel.My.Resources.Resources.SSAVE
        Me.EispKataxParKataxBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParKataxBtn.Location = New System.Drawing.Point(199, 297)
        Me.EispKataxParKataxBtn.Name = "EispKataxParKataxBtn"
        Me.EispKataxParKataxBtn.Size = New System.Drawing.Size(139, 23)
        Me.EispKataxParKataxBtn.TabIndex = 48
        Me.EispKataxParKataxBtn.Text = "Καταχώριση"
        Me.EispKataxParKataxBtn.UseVisualStyleBackColor = True
        '
        'EispraxeisKatax3Pnl
        '
        Me.EispraxeisKatax3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.EispKataxParProkTbx)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.Label130)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.Button1)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.EispKataxParTrPlirCbx)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.Label127)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.EispKataxParXrewsiTbx)
        Me.EispraxeisKatax3Pnl.Controls.Add(Me.Label131)
        Me.EispraxeisKatax3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispraxeisKatax3Pnl.Location = New System.Drawing.Point(10, 362)
        Me.EispraxeisKatax3Pnl.Name = "EispraxeisKatax3Pnl"
        Me.EispraxeisKatax3Pnl.Size = New System.Drawing.Size(754, 75)
        Me.EispraxeisKatax3Pnl.TabIndex = 47
        '
        'EispKataxParProkTbx
        '
        Me.EispKataxParProkTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParProkTbx.Location = New System.Drawing.Point(194, 39)
        Me.EispKataxParProkTbx.MaxLength = 9
        Me.EispKataxParProkTbx.Name = "EispKataxParProkTbx"
        Me.EispKataxParProkTbx.Size = New System.Drawing.Size(85, 22)
        Me.EispKataxParProkTbx.TabIndex = 49
        Me.EispKataxParProkTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.Location = New System.Drawing.Point(32, 39)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(138, 16)
        Me.Label130.TabIndex = 48
        Me.Label130.Text = "Ληφθείσα Προκατ.:"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = Global.winhotel.My.Resources.Resources.SSAVE
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(39, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 23)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "Καταχώριση"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EispKataxParTrPlirCbx
        '
        Me.EispKataxParTrPlirCbx.FormattingEnabled = True
        Me.EispKataxParTrPlirCbx.Location = New System.Drawing.Point(462, 6)
        Me.EispKataxParTrPlirCbx.Name = "EispKataxParTrPlirCbx"
        Me.EispKataxParTrPlirCbx.Size = New System.Drawing.Size(143, 24)
        Me.EispKataxParTrPlirCbx.TabIndex = 46
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.Location = New System.Drawing.Point(317, 6)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(140, 16)
        Me.Label127.TabIndex = 44
        Me.Label127.Text = "Τρόπος Πληρωμής:"
        '
        'EispKataxParXrewsiTbx
        '
        Me.EispKataxParXrewsiTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParXrewsiTbx.Location = New System.Drawing.Point(194, 6)
        Me.EispKataxParXrewsiTbx.MaxLength = 9
        Me.EispKataxParXrewsiTbx.Name = "EispKataxParXrewsiTbx"
        Me.EispKataxParXrewsiTbx.Size = New System.Drawing.Size(85, 22)
        Me.EispKataxParXrewsiTbx.TabIndex = 45
        Me.EispKataxParXrewsiTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label131
        '
        Me.Label131.AutoSize = True
        Me.Label131.Location = New System.Drawing.Point(56, 9)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(116, 16)
        Me.Label131.TabIndex = 43
        Me.Label131.Text = "Χρέωση Πρακτ.:"
        '
        'EispraxeisKatax2Pnl
        '
        Me.EispraxeisKatax2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EispraxeisKatax2Pnl.Controls.Add(Me.EispKataxParSinPlinTbx)
        Me.EispraxeisKatax2Pnl.Controls.Add(Me.Label129)
        Me.EispraxeisKatax2Pnl.Controls.Add(Me.Button6)
        Me.EispraxeisKatax2Pnl.Controls.Add(Me.EispKataxParEisprTbx)
        Me.EispraxeisKatax2Pnl.Controls.Add(Me.Label128)
        Me.EispraxeisKatax2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispraxeisKatax2Pnl.Location = New System.Drawing.Point(10, 205)
        Me.EispraxeisKatax2Pnl.Name = "EispraxeisKatax2Pnl"
        Me.EispraxeisKatax2Pnl.Size = New System.Drawing.Size(754, 75)
        Me.EispraxeisKatax2Pnl.TabIndex = 22
        '
        'EispKataxParSinPlinTbx
        '
        Me.EispKataxParSinPlinTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParSinPlinTbx.Location = New System.Drawing.Point(194, 39)
        Me.EispKataxParSinPlinTbx.MaxLength = 9
        Me.EispKataxParSinPlinTbx.Name = "EispKataxParSinPlinTbx"
        Me.EispKataxParSinPlinTbx.Size = New System.Drawing.Size(85, 22)
        Me.EispKataxParSinPlinTbx.TabIndex = 49
        Me.EispKataxParSinPlinTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.Location = New System.Drawing.Point(51, 39)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(119, 16)
        Me.Label129.TabIndex = 48
        Me.Label129.Text = "Σύν-Πλήν ποσό:"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Image = Global.winhotel.My.Resources.Resources.SSAVE
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(39, 217)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(173, 23)
        Me.Button6.TabIndex = 47
        Me.Button6.Text = "Καταχώριση"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'EispKataxParEisprTbx
        '
        Me.EispKataxParEisprTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParEisprTbx.Location = New System.Drawing.Point(194, 6)
        Me.EispKataxParEisprTbx.MaxLength = 9
        Me.EispKataxParEisprTbx.Name = "EispKataxParEisprTbx"
        Me.EispKataxParEisprTbx.Size = New System.Drawing.Size(85, 22)
        Me.EispKataxParEisprTbx.TabIndex = 45
        Me.EispKataxParEisprTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Location = New System.Drawing.Point(92, 9)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(78, 16)
        Me.Label128.TabIndex = 43
        Me.Label128.Text = "Είσπραξη:"
        '
        'EispraxeisKatax1Pnl
        '
        Me.EispraxeisKatax1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.KwdPrktTbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxParSucheBtn)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxParXrewsRdb)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxParEispRdb)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label144)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label140)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxPar3Tbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispraxeisKataxAitTbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label139)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxPar2Tbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispKataxPar1Tbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispraxeisKataxPraktTbx)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label138)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label141)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.EispraxeisKataxPck)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label142)
        Me.EispraxeisKatax1Pnl.Controls.Add(Me.Label143)
        Me.EispraxeisKatax1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispraxeisKatax1Pnl.Location = New System.Drawing.Point(10, 20)
        Me.EispraxeisKatax1Pnl.Name = "EispraxeisKatax1Pnl"
        Me.EispraxeisKatax1Pnl.Size = New System.Drawing.Size(754, 183)
        Me.EispraxeisKatax1Pnl.TabIndex = 2
        '
        'KwdPrktTbx
        '
        Me.KwdPrktTbx.Location = New System.Drawing.Point(189, 97)
        Me.KwdPrktTbx.MaxLength = 4
        Me.KwdPrktTbx.Name = "KwdPrktTbx"
        Me.KwdPrktTbx.Size = New System.Drawing.Size(51, 22)
        Me.KwdPrktTbx.TabIndex = 13
        Me.KwdPrktTbx.TabStop = False
        Me.KwdPrktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispKataxParSucheBtn
        '
        Me.EispKataxParSucheBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EispKataxParSucheBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.EispKataxParSucheBtn.Location = New System.Drawing.Point(408, 128)
        Me.EispKataxParSucheBtn.Name = "EispKataxParSucheBtn"
        Me.EispKataxParSucheBtn.Size = New System.Drawing.Size(37, 21)
        Me.EispKataxParSucheBtn.TabIndex = 44
        Me.EispKataxParSucheBtn.UseVisualStyleBackColor = True
        '
        'EispKataxParXrewsRdb
        '
        Me.EispKataxParXrewsRdb.AutoSize = True
        Me.EispKataxParXrewsRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParXrewsRdb.Location = New System.Drawing.Point(260, 44)
        Me.EispKataxParXrewsRdb.Name = "EispKataxParXrewsRdb"
        Me.EispKataxParXrewsRdb.Size = New System.Drawing.Size(78, 20)
        Me.EispKataxParXrewsRdb.TabIndex = 9
        Me.EispKataxParXrewsRdb.Text = "Χρέωση"
        Me.EispKataxParXrewsRdb.UseVisualStyleBackColor = True
        '
        'EispKataxParEispRdb
        '
        Me.EispKataxParEispRdb.AutoSize = True
        Me.EispKataxParEispRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParEispRdb.Location = New System.Drawing.Point(141, 44)
        Me.EispKataxParEispRdb.Name = "EispKataxParEispRdb"
        Me.EispKataxParEispRdb.Size = New System.Drawing.Size(92, 20)
        Me.EispKataxParEispRdb.TabIndex = 5
        Me.EispKataxParEispRdb.Text = "Είσπραξη"
        Me.EispKataxParEispRdb.UseVisualStyleBackColor = True
        '
        'Label144
        '
        Me.Label144.AutoSize = True
        Me.Label144.Location = New System.Drawing.Point(302, 133)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(18, 16)
        Me.Label144.TabIndex = 43
        Me.Label144.Text = "--"
        '
        'Label140
        '
        Me.Label140.AutoSize = True
        Me.Label140.Location = New System.Drawing.Point(264, 133)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(18, 16)
        Me.Label140.TabIndex = 42
        Me.Label140.Text = "--"
        '
        'EispKataxPar3Tbx
        '
        Me.EispKataxPar3Tbx.Location = New System.Drawing.Point(320, 127)
        Me.EispKataxPar3Tbx.MaxLength = 5
        Me.EispKataxPar3Tbx.Name = "EispKataxPar3Tbx"
        Me.EispKataxPar3Tbx.Size = New System.Drawing.Size(75, 22)
        Me.EispKataxPar3Tbx.TabIndex = 19
        Me.EispKataxPar3Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispraxeisKataxAitTbx
        '
        Me.EispraxeisKataxAitTbx.Location = New System.Drawing.Point(190, 156)
        Me.EispraxeisKataxAitTbx.MaxLength = 99
        Me.EispraxeisKataxAitTbx.Multiline = True
        Me.EispraxeisKataxAitTbx.Name = "EispraxeisKataxAitTbx"
        Me.EispraxeisKataxAitTbx.Size = New System.Drawing.Size(413, 21)
        Me.EispraxeisKataxAitTbx.TabIndex = 26
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Location = New System.Drawing.Point(85, 161)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(85, 16)
        Me.Label139.TabIndex = 27
        Me.Label139.Text = "Αιτιολογία:"
        '
        'EispKataxPar2Tbx
        '
        Me.EispKataxPar2Tbx.Location = New System.Drawing.Point(283, 127)
        Me.EispKataxPar2Tbx.MaxLength = 1
        Me.EispKataxPar2Tbx.Name = "EispKataxPar2Tbx"
        Me.EispKataxPar2Tbx.Size = New System.Drawing.Size(17, 22)
        Me.EispKataxPar2Tbx.TabIndex = 17
        Me.EispKataxPar2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispKataxPar1Tbx
        '
        Me.EispKataxPar1Tbx.Location = New System.Drawing.Point(190, 127)
        Me.EispKataxPar1Tbx.MaxLength = 5
        Me.EispKataxPar1Tbx.Name = "EispKataxPar1Tbx"
        Me.EispKataxPar1Tbx.Size = New System.Drawing.Size(75, 22)
        Me.EispKataxPar1Tbx.TabIndex = 15
        Me.EispKataxPar1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispraxeisKataxPraktTbx
        '
        Me.EispraxeisKataxPraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EispraxeisKataxPraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.EispraxeisKataxPraktTbx.Location = New System.Drawing.Point(246, 97)
        Me.EispraxeisKataxPraktTbx.Name = "EispraxeisKataxPraktTbx"
        Me.EispraxeisKataxPraktTbx.ReadOnly = True
        Me.EispraxeisKataxPraktTbx.Size = New System.Drawing.Size(169, 22)
        Me.EispraxeisKataxPraktTbx.TabIndex = 18
        Me.EispraxeisKataxPraktTbx.TabStop = False
        Me.EispraxeisKataxPraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label138
        '
        Me.Label138.AutoSize = True
        Me.Label138.Location = New System.Drawing.Point(85, 100)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(95, 16)
        Me.Label138.TabIndex = 28
        Me.Label138.Text = "Πρακτορείο:"
        '
        'Label141
        '
        Me.Label141.AutoSize = True
        Me.Label141.Location = New System.Drawing.Point(78, 130)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(102, 16)
        Me.Label141.TabIndex = 23
        Me.Label141.Text = "Παραστατικό:"
        '
        'EispraxeisKataxPck
        '
        Me.EispraxeisKataxPck.Location = New System.Drawing.Point(190, 69)
        Me.EispraxeisKataxPck.Name = "EispraxeisKataxPck"
        Me.EispraxeisKataxPck.Size = New System.Drawing.Size(200, 22)
        Me.EispraxeisKataxPck.TabIndex = 11
        '
        'Label142
        '
        Me.Label142.AutoSize = True
        Me.Label142.Location = New System.Drawing.Point(82, 72)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(97, 16)
        Me.Label142.TabIndex = 1
        Me.Label142.Text = " Ημερομηνία:"
        '
        'Label143
        '
        Me.Label143.AutoSize = True
        Me.Label143.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label143.ForeColor = System.Drawing.Color.Blue
        Me.Label143.Location = New System.Drawing.Point(7, 11)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(252, 16)
        Me.Label143.TabIndex = 0
        Me.Label143.Text = "Καταχώρηση Εισπράξεων-Χρεώσεων"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(369, 722)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(435, 10)
        Me.CrystalReportViewer1.TabIndex = 45
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'KinisiPraktEktPnl
        '
        Me.KinisiPraktEktPnl.Controls.Add(Me.KinisiPraktEkt1Pnl)
        Me.KinisiPraktEktPnl.Location = New System.Drawing.Point(23, 44)
        Me.KinisiPraktEktPnl.Name = "KinisiPraktEktPnl"
        Me.KinisiPraktEktPnl.Size = New System.Drawing.Size(795, 16)
        Me.KinisiPraktEktPnl.TabIndex = 44
        '
        'KinisiPraktEkt1Pnl
        '
        Me.KinisiPraktEkt1Pnl.BackColor = System.Drawing.Color.Silver
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.pBar1)
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.Label3)
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.KinisiPraktEkt2Pck)
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.KinisiPraktEktBtn)
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.KinisiPraktEkt1Pck)
        Me.KinisiPraktEkt1Pnl.Controls.Add(Me.Label2)
        Me.KinisiPraktEkt1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiPraktEkt1Pnl.Location = New System.Drawing.Point(10, 23)
        Me.KinisiPraktEkt1Pnl.Name = "KinisiPraktEkt1Pnl"
        Me.KinisiPraktEkt1Pnl.Size = New System.Drawing.Size(760, 148)
        Me.KinisiPraktEkt1Pnl.TabIndex = 1
        '
        'pBar1
        '
        Me.pBar1.Location = New System.Drawing.Point(249, 132)
        Me.pBar1.Name = "pBar1"
        Me.pBar1.Size = New System.Drawing.Size(247, 13)
        Me.pBar1.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(390, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 16)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "μέχρι Ημερομηνία:"
        '
        'KinisiPraktEkt2Pck
        '
        Me.KinisiPraktEkt2Pck.Location = New System.Drawing.Point(529, 22)
        Me.KinisiPraktEkt2Pck.Name = "KinisiPraktEkt2Pck"
        Me.KinisiPraktEkt2Pck.Size = New System.Drawing.Size(200, 22)
        Me.KinisiPraktEkt2Pck.TabIndex = 46
        '
        'KinisiPraktEktBtn
        '
        Me.KinisiPraktEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KinisiPraktEktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.KinisiPraktEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KinisiPraktEktBtn.Location = New System.Drawing.Point(286, 89)
        Me.KinisiPraktEktBtn.Name = "KinisiPraktEktBtn"
        Me.KinisiPraktEktBtn.Size = New System.Drawing.Size(163, 25)
        Me.KinisiPraktEktBtn.TabIndex = 45
        Me.KinisiPraktEktBtn.Text = "Προεπισκόπηση"
        Me.KinisiPraktEktBtn.UseVisualStyleBackColor = True
        '
        'KinisiPraktEkt1Pck
        '
        Me.KinisiPraktEkt1Pck.Location = New System.Drawing.Point(148, 19)
        Me.KinisiPraktEkt1Pck.Name = "KinisiPraktEkt1Pck"
        Me.KinisiPraktEkt1Pck.Size = New System.Drawing.Size(200, 22)
        Me.KinisiPraktEkt1Pck.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = " από Ημερομηνία:"
        '
        'EtiketaPraktPnl
        '
        Me.EtiketaPraktPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPraktPnl.Location = New System.Drawing.Point(15, 699)
        Me.EtiketaPraktPnl.Name = "EtiketaPraktPnl"
        Me.EtiketaPraktPnl.Size = New System.Drawing.Size(200, 10)
        Me.EtiketaPraktPnl.TabIndex = 0
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaLbl.Location = New System.Drawing.Point(22, 24)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(92, 29)
        Me.EtiketaLbl.TabIndex = 0
        Me.EtiketaLbl.Text = "Label1"
        '
        'EisprakseispraktoreiaBindingSource
        '
        Me.EisprakseispraktoreiaBindingSource.DataMember = "eisprakseispraktoreia"
        Me.EisprakseispraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EisprakseispraktoreiaTableAdapter
        '
        Me.EisprakseispraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'TimologiaBindingSource
        '
        Me.TimologiaBindingSource.DataMember = "timologia"
        Me.TimologiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimologiaTableAdapter
        '
        Me.TimologiaTableAdapter.ClearBeforeFill = True
        '
        'XrewseispraktoreiaBindingSource
        '
        Me.XrewseispraktoreiaBindingSource.DataMember = "xrewseispraktoreia"
        Me.XrewseispraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'XrewseispraktoreiaTableAdapter
        '
        Me.XrewseispraktoreiaTableAdapter.ClearBeforeFill = True
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
        'EtaireiaBindingSource
        '
        Me.EtaireiaBindingSource.DataMember = "etaireia"
        Me.EtaireiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EtaireiaTableAdapter
        '
        Me.EtaireiaTableAdapter.ClearBeforeFill = True
        '
        'SimbolaiaBindingSource
        '
        Me.SimbolaiaBindingSource.DataMember = "simbolaia"
        Me.SimbolaiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'SimbolaiaTableAdapter
        '
        Me.SimbolaiaTableAdapter.ClearBeforeFill = True
        '
        'EktpraktimerkinisiBindingSource
        '
        Me.EktpraktimerkinisiBindingSource.DataMember = "ekt_prakt_imer_kinisi"
        Me.EktpraktimerkinisiBindingSource.DataSource = Me.DbhotelDataSet
        '
        'ParastatikaBindingSource
        '
        Me.ParastatikaBindingSource.DataMember = "parastatika"
        Me.ParastatikaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'ParastatikaTableAdapter
        '
        Me.ParastatikaTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiametimologiaBindingSource
        '
        Me.PraktoreiametimologiaBindingSource.DataMember = "praktoreiametimologia"
        Me.PraktoreiametimologiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiametimologiaTableAdapter
        '
        Me.PraktoreiametimologiaTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiameeisprakseisBindingSource
        '
        Me.PraktoreiameeisprakseisBindingSource.DataMember = "praktoreiameeisprakseis"
        Me.PraktoreiameeisprakseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiameeisprakseisTableAdapter
        '
        Me.PraktoreiameeisprakseisTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiameparastatikaBindingSource
        '
        Me.PraktoreiameparastatikaBindingSource.DataMember = "praktoreiameparastatika"
        Me.PraktoreiameparastatikaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiameparastatikaTableAdapter
        '
        Me.PraktoreiameparastatikaTableAdapter.ClearBeforeFill = True
        '
        'MetaforaypoloipwnBindingSource
        '
        Me.MetaforaypoloipwnBindingSource.DataMember = "metaforaypoloipwn"
        Me.MetaforaypoloipwnBindingSource.DataSource = Me.DbhotelDataSet
        '
        'MetaforaypoloipwnTableAdapter
        '
        Me.MetaforaypoloipwnTableAdapter.ClearBeforeFill = True
        '
        'Praktoreia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 766)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Praktoreia"
        Me.Text = "Κίνηση Λογαριασμών Πρακτορείων"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.PraktZentralPnl.ResumeLayout(False)
        Me.MetafYpolPnl.ResumeLayout(False)
        Me.MetafYpol1Pnl.ResumeLayout(False)
        Me.MetafYpol1Pnl.PerformLayout()
        Me.IsozigioEktPnl.ResumeLayout(False)
        CType(Me.IsozigEktDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IsozigioEkt1fPnl.ResumeLayout(False)
        Me.IsozigioEkt1fPnl.PerformLayout()
        Me.KinisiEmfPnl.ResumeLayout(False)
        Me.KinisiEmf1Pnl.ResumeLayout(False)
        Me.KinisiEmf1Pnl.PerformLayout()
        Me.IsozigioEmfPnl.ResumeLayout(False)
        Me.IsozigioEmf3Pnl.ResumeLayout(False)
        CType(Me.IsozigioDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IsozigiopraktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.IsozigioEmf1Pnl.ResumeLayout(False)
        Me.IsozigioEmf1Pnl.PerformLayout()
        Me.KartelaPraktPnl.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KartelaPrakt1Pnl.ResumeLayout(False)
        Me.KartelaPrakt1Pnl.PerformLayout()
        Me.EispraxeisKataxPnl.ResumeLayout(False)
        Me.EispraxeisKatax3Pnl.ResumeLayout(False)
        Me.EispraxeisKatax3Pnl.PerformLayout()
        Me.EispraxeisKatax2Pnl.ResumeLayout(False)
        Me.EispraxeisKatax2Pnl.PerformLayout()
        Me.EispraxeisKatax1Pnl.ResumeLayout(False)
        Me.EispraxeisKatax1Pnl.PerformLayout()
        Me.KinisiPraktEktPnl.ResumeLayout(False)
        Me.KinisiPraktEkt1Pnl.ResumeLayout(False)
        Me.KinisiPraktEkt1Pnl.PerformLayout()
        Me.EtiketaPraktPnl.ResumeLayout(False)
        Me.EtiketaPraktPnl.PerformLayout()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EktpraktimerkinisiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiametimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiameeisprakseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiameparastatikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MetaforaypoloipwnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PraktoreiaTreeView As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PraktZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaPraktPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaLbl As System.Windows.Forms.Label
    Friend WithEvents EispraxeisKataxPnl As System.Windows.Forms.Panel
    Friend WithEvents EispKataxParClearBtn As System.Windows.Forms.Button
    Friend WithEvents EispKataxParKataxBtn As System.Windows.Forms.Button
    Friend WithEvents EispraxeisKatax3Pnl As System.Windows.Forms.Panel
    Friend WithEvents EispKataxParProkTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents EispKataxParTrPlirCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents EispKataxParXrewsiTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents EispraxeisKatax2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EispKataxParSinPlinTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents EispKataxParEisprTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents EispraxeisKatax1Pnl As System.Windows.Forms.Panel
    Friend WithEvents EispKataxParSucheBtn As System.Windows.Forms.Button
    Friend WithEvents EispKataxParXrewsRdb As System.Windows.Forms.RadioButton
    Friend WithEvents EispKataxParEispRdb As System.Windows.Forms.RadioButton
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents EispKataxPar3Tbx As System.Windows.Forms.TextBox
    Friend WithEvents EispraxeisKataxAitTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents EispKataxPar2Tbx As System.Windows.Forms.TextBox
    Friend WithEvents EispKataxPar1Tbx As System.Windows.Forms.TextBox
    Friend WithEvents EispraxeisKataxPraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents EispraxeisKataxPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents EisprakseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EisprakseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents XrewseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
    Friend WithEvents KinisiEmfPnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiEmf4Pnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiEmf3Pnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiEmf2Pnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiEmf1Pnl As System.Windows.Forms.Panel
    Friend WithEvents EmfHmerKiniPraktPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KinisiEmfBtn As System.Windows.Forms.Button
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents KinisiPraktEktPnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiPraktEkt1Pnl As System.Windows.Forms.Panel
    Friend WithEvents KinisiPraktEktBtn As System.Windows.Forms.Button
    Friend WithEvents KinisiPraktEkt1Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents KinisiPraktEkt2Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents KartelaPraktPnl As System.Windows.Forms.Panel
    Friend WithEvents KartelaPrakt1Pnl As System.Windows.Forms.Panel
    Friend WithEvents PraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ImeromKartelaPraktPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SimbolCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents KartelaPrakt4Pnl As System.Windows.Forms.Panel
    Friend WithEvents KartelaPrakt3Pnl As System.Windows.Forms.Panel
    Friend WithEvents KartelaPrakt2Pnl As System.Windows.Forms.Panel
    Friend WithEvents TelousTbx As System.Windows.Forms.TextBox
    Friend WithEvents ArxiTbx As System.Windows.Forms.TextBox
    Friend WithEvents KartelaPraktBtn As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SimbolaiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimbolaiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
    Friend WithEvents EktpraktimerkinisiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents EisprRdb As System.Windows.Forms.RadioButton
    Friend WithEvents OlaRdb As System.Windows.Forms.RadioButton
    Friend WithEvents ImeromKartelaPrakt2Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ParastCbx As System.Windows.Forms.ComboBox
    Friend WithEvents ParastatikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParastatikaTableAdapter As winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter
    Friend WithEvents KartelaPraktΕktBtn As System.Windows.Forms.Button
    Friend WithEvents IsozigioEmfPnl As System.Windows.Forms.Panel
    Friend WithEvents IsozigioEmf3Pnl As System.Windows.Forms.Panel
    Friend WithEvents IsozigioEmf1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Isozigio2Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Isozigio1Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents IsozigioEmfBtn As System.Windows.Forms.Button
    Friend WithEvents IsozigioImeromErg As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PraktoreiametimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiametimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiametimologiaTableAdapter
    Friend WithEvents IsozigioDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents IsozigiopraktoreiwnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiameeisprakseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiameeisprakseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiameeisprakseisTableAdapter
    Friend WithEvents PraktoreiameparastatikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiameparastatikaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiameparastatikaTableAdapter
    Friend WithEvents AaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PraktoreioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XrewseisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EisprakseisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents YpoloipoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsozigioEktPnl As System.Windows.Forms.Panel
    Friend WithEvents IsozigioEkt1fPnl As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Isozigio2Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Isozigio1Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents IsozEkt2Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents IsozEkt1Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents IsozEktBtn As System.Windows.Forms.Button
    Friend WithEvents Isozigio3Tbx As System.Windows.Forms.TextBox
    Friend WithEvents Isozigio2Tbx As System.Windows.Forms.TextBox
    Friend WithEvents Isozigio1Tbx As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents IsozigEktDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents MetafYpolPnl As System.Windows.Forms.Panel
    Friend WithEvents MetafYpol1Pnl As System.Windows.Forms.Panel
    Friend WithEvents MetafYpolBtn As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents MetafYpolPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents MetafYpol2Tbx As System.Windows.Forms.TextBox
    Friend WithEvents MetafYpol1Tbx As System.Windows.Forms.TextBox
    Friend WithEvents MetaforaypoloipwnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MetaforaypoloipwnTableAdapter As winhotel.dbhotelDataSetTableAdapters.metaforaypoloipwnTableAdapter
    Friend WithEvents KwdPrktTbx As System.Windows.Forms.TextBox
    Friend WithEvents pBar1 As System.Windows.Forms.ProgressBar
End Class
