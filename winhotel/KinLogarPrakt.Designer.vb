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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Καταχώριση Εισπράξεων")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εμφάνιση")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτύπωση")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ημερήσια Κίνηση", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Καρτέλα Πρακτορείου")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εμφάνιση")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτύπ. Υπολοίπων")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ισοζύγιο Πρακτορείων", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Μεταφορά Υπολοίπων")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PraktoreiaTreeView = New System.Windows.Forms.TreeView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PraktZentralPnl = New System.Windows.Forms.Panel()
        Me.MetafYpolPnl = New System.Windows.Forms.Panel()
        Me.MetafYpol1Pnl = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.MetafYpolPck = New System.Windows.Forms.DateTimePicker()
        Me.MetafYpol2Tbx = New System.Windows.Forms.TextBox()
        Me.MetafYpol1Tbx = New System.Windows.Forms.TextBox()
        Me.MetafYpolBtn = New System.Windows.Forms.Button()
        Me.IsozigioEktPnl = New System.Windows.Forms.Panel()
        Me.IsozigEktDtGrd = New System.Windows.Forms.DataGridView()
        Me.IsozigioEkt1fPnl = New System.Windows.Forms.Panel()
        Me.Isozigio3Tbx = New System.Windows.Forms.TextBox()
        Me.Isozigio2Tbx = New System.Windows.Forms.TextBox()
        Me.Isozigio1Tbx = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Isozigio2Pck = New System.Windows.Forms.DateTimePicker()
        Me.Isozigio1Pck = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.IsozEkt2Rdb = New System.Windows.Forms.RadioButton()
        Me.IsozEkt1Rdb = New System.Windows.Forms.RadioButton()
        Me.IsozEktBtn = New System.Windows.Forms.Button()
        Me.KinisiEmfPnl = New System.Windows.Forms.Panel()
        Me.KinisiEmf4Pnl = New System.Windows.Forms.Panel()
        Me.KinisiEmf3Pnl = New System.Windows.Forms.Panel()
        Me.KinisiEmf2Pnl = New System.Windows.Forms.Panel()
        Me.KinisiEmf1Pnl = New System.Windows.Forms.Panel()
        Me.KinisiEmfBtn = New System.Windows.Forms.Button()
        Me.EmfHmerKiniPraktPck = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IsozigioEmfPnl = New System.Windows.Forms.Panel()
        Me.IsozigioEmf3Pnl = New System.Windows.Forms.Panel()
        Me.IsozigioDtGrd = New System.Windows.Forms.DataGridView()
        Me.AaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PraktoreioDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XrewseisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EisprakseisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.YpoloipoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsozigiopraktoreiwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.IsozigioEmf1Pnl = New System.Windows.Forms.Panel()
        Me.IsozigioImeromErg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Isozigio2Rdb = New System.Windows.Forms.RadioButton()
        Me.Isozigio1Rdb = New System.Windows.Forms.RadioButton()
        Me.IsozigioEmfBtn = New System.Windows.Forms.Button()
        Me.KartelaPraktPnl = New System.Windows.Forms.Panel()
        Me.KartelaPraktΕktBtn = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.KartelaPrakt4Pnl = New System.Windows.Forms.Panel()
        Me.KartelaPrakt3Pnl = New System.Windows.Forms.Panel()
        Me.KartelaPrakt2Pnl = New System.Windows.Forms.Panel()
        Me.KartelaPrakt1Pnl = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ParastCbx = New System.Windows.Forms.ComboBox()
        Me.EisprRdb = New System.Windows.Forms.RadioButton()
        Me.OlaRdb = New System.Windows.Forms.RadioButton()
        Me.ImeromKartelaPrakt2Pck = New System.Windows.Forms.DateTimePicker()
        Me.KartelaPraktBtn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TelousTbx = New System.Windows.Forms.TextBox()
        Me.ArxiTbx = New System.Windows.Forms.TextBox()
        Me.SimbolCbx = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PraktTbx = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ImeromKartelaPraktPck = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EispraxeisKataxPnl = New System.Windows.Forms.Panel()
        Me.EispKataxParClearBtn = New System.Windows.Forms.Button()
        Me.EispKataxParKataxBtn = New System.Windows.Forms.Button()
        Me.EispraxeisKatax3Pnl = New System.Windows.Forms.Panel()
        Me.EispKataxParProkTbx = New System.Windows.Forms.TextBox()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.EispKataxParTrPlirCbx = New System.Windows.Forms.ComboBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.EispKataxParXrewsiTbx = New System.Windows.Forms.TextBox()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.EispraxeisKatax2Pnl = New System.Windows.Forms.Panel()
        Me.EispKataxParSinPlinTbx = New System.Windows.Forms.TextBox()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.EispKataxParEisprTbx = New System.Windows.Forms.TextBox()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.EispraxeisKatax1Pnl = New System.Windows.Forms.Panel()
        Me.KwdPrktTbx = New System.Windows.Forms.TextBox()
        Me.EispKataxParSucheBtn = New System.Windows.Forms.Button()
        Me.EispKataxParXrewsRdb = New System.Windows.Forms.RadioButton()
        Me.EispKataxParEispRdb = New System.Windows.Forms.RadioButton()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.EispKataxPar3Tbx = New System.Windows.Forms.TextBox()
        Me.EispraxeisKataxAitTbx = New System.Windows.Forms.TextBox()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.EispKataxPar2Tbx = New System.Windows.Forms.TextBox()
        Me.EispKataxPar1Tbx = New System.Windows.Forms.TextBox()
        Me.EispraxeisKataxPraktTbx = New System.Windows.Forms.TextBox()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.EispraxeisKataxPck = New System.Windows.Forms.DateTimePicker()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.KinisiPraktEktPnl = New System.Windows.Forms.Panel()
        Me.KinisiPraktEkt1Pnl = New System.Windows.Forms.Panel()
        Me.pBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.KinisiPraktEkt2Pck = New System.Windows.Forms.DateTimePicker()
        Me.KinisiPraktEktBtn = New System.Windows.Forms.Button()
        Me.KinisiPraktEkt1Pck = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EtiketaPraktPnl = New System.Windows.Forms.Panel()
        Me.EtiketaLbl = New System.Windows.Forms.Label()
        Me.EisprakseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EisprakseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter()
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter()
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter()
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        Me.SimbolaiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimbolaiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter()
        Me.EktpraktimerkinisiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter()
        Me.PraktoreiametimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiametimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiametimologiaTableAdapter()
        Me.PraktoreiameeisprakseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiameeisprakseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiameeisprakseisTableAdapter()
        Me.PraktoreiameparastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiameparastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiameparastatikaTableAdapter()
        Me.MetaforaypoloipwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MetaforaypoloipwnTableAdapter = New winhotel.dbhotelDataSetTableAdapters.metaforaypoloipwnTableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PraktoreiaTreeView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PraktoreiaTreeView.Name = "PraktoreiaTreeView"
        TreeNode1.Name = "Eispraxeis"
        TreeNode1.Text = "Καταχώριση Εισπράξεων"
        TreeNode2.Name = "EmfHmerKin"
        TreeNode2.Text = "Εμφάνιση"
        TreeNode3.Name = "EktHmerKin"
        TreeNode3.Text = "Εκτύπωση"
        TreeNode4.Name = "Node0"
        TreeNode4.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode4.Text = "Ημερήσια Κίνηση"
        TreeNode5.Name = "emf_kart_prakt"
        TreeNode5.Text = "Καρτέλα Πρακτορείου"
        TreeNode6.Name = "emf_isozig_prakt"
        TreeNode6.Text = "Εμφάνιση"
        TreeNode7.Name = "ekt_isozig_prakt"
        TreeNode7.Text = "Εκτύπ. Υπολοίπων"
        TreeNode8.Name = "Node0"
        TreeNode8.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode8.Text = "Ισοζύγιο Πρακτορείων"
        TreeNode9.Name = "metafora_ypoloipwn"
        TreeNode9.Text = "Μεταφορά Υπολοίπων"
        Me.PraktoreiaTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode4, TreeNode5, TreeNode8, TreeNode9})
        Me.PraktoreiaTreeView.Size = New System.Drawing.Size(239, 943)
        Me.PraktoreiaTreeView.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1412, 943)
        Me.SplitContainer1.SplitterDistance = 239
        Me.SplitContainer1.SplitterWidth = 5
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
        Me.PraktZentralPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PraktZentralPnl.Name = "PraktZentralPnl"
        Me.PraktZentralPnl.Size = New System.Drawing.Size(1168, 943)
        Me.PraktZentralPnl.TabIndex = 0
        '
        'MetafYpolPnl
        '
        Me.MetafYpolPnl.Controls.Add(Me.MetafYpol1Pnl)
        Me.MetafYpolPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.MetafYpolPnl.Location = New System.Drawing.Point(33, 827)
        Me.MetafYpolPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpolPnl.Name = "MetafYpolPnl"
        Me.MetafYpolPnl.Size = New System.Drawing.Size(1087, 12)
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
        Me.MetafYpol1Pnl.Location = New System.Drawing.Point(13, 28)
        Me.MetafYpol1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpol1Pnl.Name = "MetafYpol1Pnl"
        Me.MetafYpol1Pnl.Size = New System.Drawing.Size(1017, 249)
        Me.MetafYpol1Pnl.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(127, 142)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(289, 20)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Ημερ/νία Μεταφοράς Υπολοίπων:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(336, 89)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 20)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Νέα Χρήση:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(247, 27)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(186, 20)
        Me.Label14.TabIndex = 58
        Me.Label14.Text = "Προηγούμενη Χρήση:"
        '
        'MetafYpolPck
        '
        Me.MetafYpolPck.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MetafYpolPck.Location = New System.Drawing.Point(459, 138)
        Me.MetafYpolPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpolPck.Name = "MetafYpolPck"
        Me.MetafYpolPck.Size = New System.Drawing.Size(139, 26)
        Me.MetafYpolPck.TabIndex = 57
        '
        'MetafYpol2Tbx
        '
        Me.MetafYpol2Tbx.Location = New System.Drawing.Point(459, 85)
        Me.MetafYpol2Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpol2Tbx.MaxLength = 4
        Me.MetafYpol2Tbx.Name = "MetafYpol2Tbx"
        Me.MetafYpol2Tbx.Size = New System.Drawing.Size(132, 26)
        Me.MetafYpol2Tbx.TabIndex = 56
        Me.MetafYpol2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MetafYpol1Tbx
        '
        Me.MetafYpol1Tbx.Location = New System.Drawing.Point(459, 23)
        Me.MetafYpol1Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpol1Tbx.MaxLength = 4
        Me.MetafYpol1Tbx.Name = "MetafYpol1Tbx"
        Me.MetafYpol1Tbx.ReadOnly = True
        Me.MetafYpol1Tbx.Size = New System.Drawing.Size(132, 26)
        Me.MetafYpol1Tbx.TabIndex = 55
        Me.MetafYpol1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MetafYpolBtn
        '
        Me.MetafYpolBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.MetafYpolBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MetafYpolBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MetafYpolBtn.Location = New System.Drawing.Point(391, 190)
        Me.MetafYpolBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MetafYpolBtn.Name = "MetafYpolBtn"
        Me.MetafYpolBtn.Size = New System.Drawing.Size(232, 30)
        Me.MetafYpolBtn.TabIndex = 54
        Me.MetafYpolBtn.Text = "Μεταφορά"
        Me.MetafYpolBtn.UseVisualStyleBackColor = True
        '
        'IsozigioEktPnl
        '
        Me.IsozigioEktPnl.Controls.Add(Me.IsozigEktDtGrd)
        Me.IsozigioEktPnl.Controls.Add(Me.IsozigioEkt1fPnl)
        Me.IsozigioEktPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEktPnl.Location = New System.Drawing.Point(67, 799)
        Me.IsozigioEktPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEktPnl.Name = "IsozigioEktPnl"
        Me.IsozigioEktPnl.Size = New System.Drawing.Size(1087, 12)
        Me.IsozigioEktPnl.TabIndex = 48
        '
        'IsozigEktDtGrd
        '
        Me.IsozigEktDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IsozigEktDtGrd.Location = New System.Drawing.Point(792, 286)
        Me.IsozigEktDtGrd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigEktDtGrd.Name = "IsozigEktDtGrd"
        Me.IsozigEktDtGrd.RowHeadersWidth = 51
        Me.IsozigEktDtGrd.Size = New System.Drawing.Size(25, 185)
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
        Me.IsozigioEkt1fPnl.Location = New System.Drawing.Point(13, 28)
        Me.IsozigioEkt1fPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEkt1fPnl.Name = "IsozigioEkt1fPnl"
        Me.IsozigioEkt1fPnl.Size = New System.Drawing.Size(1017, 249)
        Me.IsozigioEkt1fPnl.TabIndex = 1
        '
        'Isozigio3Tbx
        '
        Me.Isozigio3Tbx.Location = New System.Drawing.Point(545, 86)
        Me.Isozigio3Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio3Tbx.MaxLength = 3
        Me.Isozigio3Tbx.Name = "Isozigio3Tbx"
        Me.Isozigio3Tbx.Size = New System.Drawing.Size(48, 26)
        Me.Isozigio3Tbx.TabIndex = 65
        Me.Isozigio3Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Isozigio2Tbx
        '
        Me.Isozigio2Tbx.Location = New System.Drawing.Point(464, 86)
        Me.Isozigio2Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio2Tbx.MaxLength = 3
        Me.Isozigio2Tbx.Name = "Isozigio2Tbx"
        Me.Isozigio2Tbx.Size = New System.Drawing.Size(48, 26)
        Me.Isozigio2Tbx.TabIndex = 64
        Me.Isozigio2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Isozigio1Tbx
        '
        Me.Isozigio1Tbx.Location = New System.Drawing.Point(380, 86)
        Me.Isozigio1Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio1Tbx.MaxLength = 3
        Me.Isozigio1Tbx.Name = "Isozigio1Tbx"
        Me.Isozigio1Tbx.Size = New System.Drawing.Size(48, 26)
        Me.Isozigio1Tbx.TabIndex = 63
        Me.Isozigio1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(176, 90)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(168, 20)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = " Ηλικία Υπολοίπου:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(529, 39)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 20)
        Me.Label11.TabIndex = 61
        Me.Label11.Text = "μέχρι Ημερομηνία:"
        '
        'Isozigio2Pck
        '
        Me.Isozigio2Pck.Location = New System.Drawing.Point(715, 36)
        Me.Isozigio2Pck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio2Pck.Name = "Isozigio2Pck"
        Me.Isozigio2Pck.Size = New System.Drawing.Size(265, 26)
        Me.Isozigio2Pck.TabIndex = 60
        '
        'Isozigio1Pck
        '
        Me.Isozigio1Pck.Location = New System.Drawing.Point(207, 32)
        Me.Isozigio1Pck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio1Pck.Name = "Isozigio1Pck"
        Me.Isozigio1Pck.Size = New System.Drawing.Size(265, 26)
        Me.Isozigio1Pck.TabIndex = 59
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(29, 36)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(157, 20)
        Me.Label12.TabIndex = 58
        Me.Label12.Text = " από Ημερομηνία:"
        '
        'IsozEkt2Rdb
        '
        Me.IsozEkt2Rdb.AutoSize = True
        Me.IsozEkt2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozEkt2Rdb.Location = New System.Drawing.Point(533, 137)
        Me.IsozEkt2Rdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozEkt2Rdb.Name = "IsozEkt2Rdb"
        Me.IsozEkt2Rdb.Size = New System.Drawing.Size(63, 24)
        Me.IsozEkt2Rdb.TabIndex = 57
        Me.IsozEkt2Rdb.TabStop = True
        Me.IsozEkt2Rdb.Text = "Ολα"
        Me.IsozEkt2Rdb.UseVisualStyleBackColor = True
        '
        'IsozEkt1Rdb
        '
        Me.IsozEkt1Rdb.AutoSize = True
        Me.IsozEkt1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IsozEkt1Rdb.Location = New System.Drawing.Point(355, 137)
        Me.IsozEkt1Rdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozEkt1Rdb.Name = "IsozEkt1Rdb"
        Me.IsozEkt1Rdb.Size = New System.Drawing.Size(120, 24)
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
        Me.IsozEktBtn.Location = New System.Drawing.Point(372, 188)
        Me.IsozEktBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozEktBtn.Name = "IsozEktBtn"
        Me.IsozEktBtn.Size = New System.Drawing.Size(232, 30)
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
        Me.KinisiEmfPnl.Location = New System.Drawing.Point(28, 116)
        Me.KinisiEmfPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmfPnl.Name = "KinisiEmfPnl"
        Me.KinisiEmfPnl.Size = New System.Drawing.Size(1075, 12)
        Me.KinisiEmfPnl.TabIndex = 43
        '
        'KinisiEmf4Pnl
        '
        Me.KinisiEmf4Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf4Pnl.Location = New System.Drawing.Point(23, 582)
        Me.KinisiEmf4Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmf4Pnl.Name = "KinisiEmf4Pnl"
        Me.KinisiEmf4Pnl.Size = New System.Drawing.Size(1036, 58)
        Me.KinisiEmf4Pnl.TabIndex = 3
        '
        'KinisiEmf3Pnl
        '
        Me.KinisiEmf3Pnl.AutoScroll = True
        Me.KinisiEmf3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf3Pnl.Location = New System.Drawing.Point(23, 158)
        Me.KinisiEmf3Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmf3Pnl.Name = "KinisiEmf3Pnl"
        Me.KinisiEmf3Pnl.Size = New System.Drawing.Size(1036, 420)
        Me.KinisiEmf3Pnl.TabIndex = 2
        '
        'KinisiEmf2Pnl
        '
        Me.KinisiEmf2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KinisiEmf2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf2Pnl.Location = New System.Drawing.Point(23, 106)
        Me.KinisiEmf2Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmf2Pnl.Name = "KinisiEmf2Pnl"
        Me.KinisiEmf2Pnl.Size = New System.Drawing.Size(1036, 48)
        Me.KinisiEmf2Pnl.TabIndex = 1
        '
        'KinisiEmf1Pnl
        '
        Me.KinisiEmf1Pnl.BackColor = System.Drawing.Color.Silver
        Me.KinisiEmf1Pnl.Controls.Add(Me.KinisiEmfBtn)
        Me.KinisiEmf1Pnl.Controls.Add(Me.EmfHmerKiniPraktPck)
        Me.KinisiEmf1Pnl.Controls.Add(Me.Label1)
        Me.KinisiEmf1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KinisiEmf1Pnl.Location = New System.Drawing.Point(23, 34)
        Me.KinisiEmf1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmf1Pnl.Name = "KinisiEmf1Pnl"
        Me.KinisiEmf1Pnl.Size = New System.Drawing.Size(1036, 68)
        Me.KinisiEmf1Pnl.TabIndex = 0
        '
        'KinisiEmfBtn
        '
        Me.KinisiEmfBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KinisiEmfBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.KinisiEmfBtn.Location = New System.Drawing.Point(617, 25)
        Me.KinisiEmfBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiEmfBtn.Name = "KinisiEmfBtn"
        Me.KinisiEmfBtn.Size = New System.Drawing.Size(76, 26)
        Me.KinisiEmfBtn.TabIndex = 45
        Me.KinisiEmfBtn.UseVisualStyleBackColor = True
        '
        'EmfHmerKiniPraktPck
        '
        Me.EmfHmerKiniPraktPck.Location = New System.Drawing.Point(331, 21)
        Me.EmfHmerKiniPraktPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EmfHmerKiniPraktPck.Name = "EmfHmerKiniPraktPck"
        Me.EmfHmerKiniPraktPck.Size = New System.Drawing.Size(265, 26)
        Me.EmfHmerKiniPraktPck.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(187, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = " Ημερομηνία:"
        '
        'IsozigioEmfPnl
        '
        Me.IsozigioEmfPnl.Controls.Add(Me.IsozigioEmf3Pnl)
        Me.IsozigioEmfPnl.Controls.Add(Me.IsozigioEmf1Pnl)
        Me.IsozigioEmfPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEmfPnl.Location = New System.Drawing.Point(13, 171)
        Me.IsozigioEmfPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEmfPnl.Name = "IsozigioEmfPnl"
        Me.IsozigioEmfPnl.Size = New System.Drawing.Size(1091, 15)
        Me.IsozigioEmfPnl.TabIndex = 47
        '
        'IsozigioEmf3Pnl
        '
        Me.IsozigioEmf3Pnl.AutoScroll = True
        Me.IsozigioEmf3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.IsozigioEmf3Pnl.Controls.Add(Me.IsozigioDtGrd)
        Me.IsozigioEmf3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.IsozigioEmf3Pnl.Location = New System.Drawing.Point(13, 158)
        Me.IsozigioEmf3Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEmf3Pnl.Name = "IsozigioEmf3Pnl"
        Me.IsozigioEmf3Pnl.Size = New System.Drawing.Size(1017, 645)
        Me.IsozigioEmf3Pnl.TabIndex = 4
        '
        'IsozigioDtGrd
        '
        Me.IsozigioDtGrd.AllowUserToAddRows = False
        Me.IsozigioDtGrd.AllowUserToDeleteRows = False
        Me.IsozigioDtGrd.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsozigioDtGrd.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.IsozigioDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.IsozigioDtGrd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AaDataGridViewTextBoxColumn, Me.PraktoreioDataGridViewTextBoxColumn, Me.XrewseisDataGridViewTextBoxColumn, Me.EisprakseisDataGridViewTextBoxColumn, Me.YpoloipoDataGridViewTextBoxColumn})
        Me.IsozigioDtGrd.DataSource = Me.IsozigiopraktoreiwnBindingSource
        Me.IsozigioDtGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IsozigioDtGrd.Location = New System.Drawing.Point(0, 0)
        Me.IsozigioDtGrd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioDtGrd.Name = "IsozigioDtGrd"
        Me.IsozigioDtGrd.RowHeadersWidth = 51
        Me.IsozigioDtGrd.Size = New System.Drawing.Size(1017, 645)
        Me.IsozigioDtGrd.TabIndex = 48
        '
        'AaDataGridViewTextBoxColumn
        '
        Me.AaDataGridViewTextBoxColumn.DataPropertyName = "aa"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.AaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AaDataGridViewTextBoxColumn.HeaderText = "A/A"
        Me.AaDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.AaDataGridViewTextBoxColumn.Name = "AaDataGridViewTextBoxColumn"
        Me.AaDataGridViewTextBoxColumn.ReadOnly = True
        Me.AaDataGridViewTextBoxColumn.Width = 50
        '
        'PraktoreioDataGridViewTextBoxColumn
        '
        Me.PraktoreioDataGridViewTextBoxColumn.DataPropertyName = "praktoreio"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PraktoreioDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PraktoreioDataGridViewTextBoxColumn.HeaderText = "Επωνυμία Πρακτορείου"
        Me.PraktoreioDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.PraktoreioDataGridViewTextBoxColumn.Name = "PraktoreioDataGridViewTextBoxColumn"
        Me.PraktoreioDataGridViewTextBoxColumn.ReadOnly = True
        Me.PraktoreioDataGridViewTextBoxColumn.Width = 300
        '
        'XrewseisDataGridViewTextBoxColumn
        '
        Me.XrewseisDataGridViewTextBoxColumn.DataPropertyName = "xrewseis"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0,00"
        Me.XrewseisDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.XrewseisDataGridViewTextBoxColumn.HeaderText = "Χρεώσεις"
        Me.XrewseisDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.XrewseisDataGridViewTextBoxColumn.Name = "XrewseisDataGridViewTextBoxColumn"
        Me.XrewseisDataGridViewTextBoxColumn.ReadOnly = True
        Me.XrewseisDataGridViewTextBoxColumn.Width = 110
        '
        'EisprakseisDataGridViewTextBoxColumn
        '
        Me.EisprakseisDataGridViewTextBoxColumn.DataPropertyName = "eisprakseis"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0,00"
        Me.EisprakseisDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.EisprakseisDataGridViewTextBoxColumn.HeaderText = "Εισπράξεις"
        Me.EisprakseisDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.EisprakseisDataGridViewTextBoxColumn.Name = "EisprakseisDataGridViewTextBoxColumn"
        Me.EisprakseisDataGridViewTextBoxColumn.ReadOnly = True
        Me.EisprakseisDataGridViewTextBoxColumn.Width = 110
        '
        'YpoloipoDataGridViewTextBoxColumn
        '
        Me.YpoloipoDataGridViewTextBoxColumn.DataPropertyName = "ypoloipo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0,00"
        Me.YpoloipoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.YpoloipoDataGridViewTextBoxColumn.HeaderText = "Υπόλοιπο"
        Me.YpoloipoDataGridViewTextBoxColumn.MinimumWidth = 6
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
        Me.IsozigioEmf1Pnl.Location = New System.Drawing.Point(13, 28)
        Me.IsozigioEmf1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEmf1Pnl.Name = "IsozigioEmf1Pnl"
        Me.IsozigioEmf1Pnl.Size = New System.Drawing.Size(1017, 127)
        Me.IsozigioEmf1Pnl.TabIndex = 1
        '
        'IsozigioImeromErg
        '
        Me.IsozigioImeromErg.AutoSize = True
        Me.IsozigioImeromErg.ForeColor = System.Drawing.Color.Maroon
        Me.IsozigioImeromErg.Location = New System.Drawing.Point(232, 12)
        Me.IsozigioImeromErg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.IsozigioImeromErg.Name = "IsozigioImeromErg"
        Me.IsozigioImeromErg.Size = New System.Drawing.Size(201, 20)
        Me.IsozigioImeromErg.TabIndex = 59
        Me.IsozigioImeromErg.Text = "Τρέχουσα Ημερομηνία:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 12)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(201, 20)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Τρέχουσα Ημερομηνία:"
        '
        'Isozigio2Rdb
        '
        Me.Isozigio2Rdb.AutoSize = True
        Me.Isozigio2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Isozigio2Rdb.Location = New System.Drawing.Point(560, 32)
        Me.Isozigio2Rdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio2Rdb.Name = "Isozigio2Rdb"
        Me.Isozigio2Rdb.Size = New System.Drawing.Size(63, 24)
        Me.Isozigio2Rdb.TabIndex = 57
        Me.Isozigio2Rdb.TabStop = True
        Me.Isozigio2Rdb.Text = "Ολα"
        Me.Isozigio2Rdb.UseVisualStyleBackColor = True
        '
        'Isozigio1Rdb
        '
        Me.Isozigio1Rdb.AutoSize = True
        Me.Isozigio1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Isozigio1Rdb.Location = New System.Drawing.Point(381, 32)
        Me.Isozigio1Rdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Isozigio1Rdb.Name = "Isozigio1Rdb"
        Me.Isozigio1Rdb.Size = New System.Drawing.Size(120, 24)
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
        Me.IsozigioEmfBtn.Location = New System.Drawing.Point(431, 79)
        Me.IsozigioEmfBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IsozigioEmfBtn.Name = "IsozigioEmfBtn"
        Me.IsozigioEmfBtn.Size = New System.Drawing.Size(169, 30)
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
        Me.KartelaPraktPnl.Location = New System.Drawing.Point(4, 231)
        Me.KartelaPraktPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPraktPnl.Name = "KartelaPraktPnl"
        Me.KartelaPraktPnl.Size = New System.Drawing.Size(1131, 12)
        Me.KartelaPraktPnl.TabIndex = 46
        '
        'KartelaPraktΕktBtn
        '
        Me.KartelaPraktΕktBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.KartelaPraktΕktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KartelaPraktΕktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.KartelaPraktΕktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KartelaPraktΕktBtn.Location = New System.Drawing.Point(424, 780)
        Me.KartelaPraktΕktBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPraktΕktBtn.Name = "KartelaPraktΕktBtn"
        Me.KartelaPraktΕktBtn.Size = New System.Drawing.Size(221, 30)
        Me.KartelaPraktΕktBtn.TabIndex = 55
        Me.KartelaPraktΕktBtn.Text = "Προεπισκόπηση"
        Me.KartelaPraktΕktBtn.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1112, 68)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(13, 185)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.Visible = False
        '
        'KartelaPrakt4Pnl
        '
        Me.KartelaPrakt4Pnl.AutoScroll = True
        Me.KartelaPrakt4Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt4Pnl.Location = New System.Drawing.Point(13, 683)
        Me.KartelaPrakt4Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPrakt4Pnl.Name = "KartelaPrakt4Pnl"
        Me.KartelaPrakt4Pnl.Size = New System.Drawing.Size(1072, 82)
        Me.KartelaPrakt4Pnl.TabIndex = 5
        '
        'KartelaPrakt3Pnl
        '
        Me.KartelaPrakt3Pnl.AutoScroll = True
        Me.KartelaPrakt3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt3Pnl.Location = New System.Drawing.Point(13, 289)
        Me.KartelaPrakt3Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPrakt3Pnl.Name = "KartelaPrakt3Pnl"
        Me.KartelaPrakt3Pnl.Size = New System.Drawing.Size(1072, 390)
        Me.KartelaPrakt3Pnl.TabIndex = 4
        '
        'KartelaPrakt2Pnl
        '
        Me.KartelaPrakt2Pnl.AutoScroll = True
        Me.KartelaPrakt2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KartelaPrakt2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KartelaPrakt2Pnl.Location = New System.Drawing.Point(13, 235)
        Me.KartelaPrakt2Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPrakt2Pnl.Name = "KartelaPrakt2Pnl"
        Me.KartelaPrakt2Pnl.Size = New System.Drawing.Size(1072, 50)
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
        Me.KartelaPrakt1Pnl.Location = New System.Drawing.Point(13, 28)
        Me.KartelaPrakt1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPrakt1Pnl.Name = "KartelaPrakt1Pnl"
        Me.KartelaPrakt1Pnl.Size = New System.Drawing.Size(1072, 202)
        Me.KartelaPrakt1Pnl.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(440, 59)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 20)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "μέχρι:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label8.Location = New System.Drawing.Point(252, 107)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Παραστατικά:"
        '
        'ParastCbx
        '
        Me.ParastCbx.Enabled = False
        Me.ParastCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ParastCbx.ForeColor = System.Drawing.Color.Blue
        Me.ParastCbx.FormattingEnabled = True
        Me.ParastCbx.Location = New System.Drawing.Point(392, 103)
        Me.ParastCbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ParastCbx.Name = "ParastCbx"
        Me.ParastCbx.Size = New System.Drawing.Size(227, 28)
        Me.ParastCbx.TabIndex = 58
        '
        'EisprRdb
        '
        Me.EisprRdb.AutoSize = True
        Me.EisprRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EisprRdb.Location = New System.Drawing.Point(103, 105)
        Me.EisprRdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EisprRdb.Name = "EisprRdb"
        Me.EisprRdb.Size = New System.Drawing.Size(121, 24)
        Me.EisprRdb.TabIndex = 57
        Me.EisprRdb.TabStop = True
        Me.EisprRdb.Text = "Εισπράξεις"
        Me.EisprRdb.UseVisualStyleBackColor = True
        '
        'OlaRdb
        '
        Me.OlaRdb.AutoSize = True
        Me.OlaRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OlaRdb.Location = New System.Drawing.Point(23, 105)
        Me.OlaRdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OlaRdb.Name = "OlaRdb"
        Me.OlaRdb.Size = New System.Drawing.Size(63, 24)
        Me.OlaRdb.TabIndex = 56
        Me.OlaRdb.TabStop = True
        Me.OlaRdb.Text = "Ολα"
        Me.OlaRdb.UseVisualStyleBackColor = True
        '
        'ImeromKartelaPrakt2Pck
        '
        Me.ImeromKartelaPrakt2Pck.CustomFormat = "dd/MM/yy"
        Me.ImeromKartelaPrakt2Pck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ImeromKartelaPrakt2Pck.Location = New System.Drawing.Point(512, 55)
        Me.ImeromKartelaPrakt2Pck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ImeromKartelaPrakt2Pck.Name = "ImeromKartelaPrakt2Pck"
        Me.ImeromKartelaPrakt2Pck.Size = New System.Drawing.Size(191, 26)
        Me.ImeromKartelaPrakt2Pck.TabIndex = 55
        '
        'KartelaPraktBtn
        '
        Me.KartelaPraktBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.KartelaPraktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KartelaPraktBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.KartelaPraktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KartelaPraktBtn.Location = New System.Drawing.Point(428, 155)
        Me.KartelaPraktBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KartelaPraktBtn.Name = "KartelaPraktBtn"
        Me.KartelaPraktBtn.Size = New System.Drawing.Size(169, 30)
        Me.KartelaPraktBtn.TabIndex = 54
        Me.KartelaPraktBtn.Text = "Εμφάνιση"
        Me.KartelaPraktBtn.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.Location = New System.Drawing.Point(831, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 20)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "A/A τέλους:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(625, 107)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "A/A αρχής:"
        '
        'TelousTbx
        '
        Me.TelousTbx.Location = New System.Drawing.Point(960, 103)
        Me.TelousTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TelousTbx.MaxLength = 6
        Me.TelousTbx.Name = "TelousTbx"
        Me.TelousTbx.Size = New System.Drawing.Size(80, 26)
        Me.TelousTbx.TabIndex = 51
        '
        'ArxiTbx
        '
        Me.ArxiTbx.Location = New System.Drawing.Point(741, 102)
        Me.ArxiTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ArxiTbx.MaxLength = 6
        Me.ArxiTbx.Name = "ArxiTbx"
        Me.ArxiTbx.Size = New System.Drawing.Size(80, 26)
        Me.ArxiTbx.TabIndex = 50
        '
        'SimbolCbx
        '
        Me.SimbolCbx.Enabled = False
        Me.SimbolCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimbolCbx.ForeColor = System.Drawing.Color.Blue
        Me.SimbolCbx.FormattingEnabled = True
        Me.SimbolCbx.Location = New System.Drawing.Point(709, 12)
        Me.SimbolCbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimbolCbx.Name = "SimbolCbx"
        Me.SimbolCbx.Size = New System.Drawing.Size(124, 28)
        Me.SimbolCbx.TabIndex = 48
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label21.Location = New System.Drawing.Point(591, 16)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 20)
        Me.Label21.TabIndex = 49
        Me.Label21.Text = "Συμβόλαιο:"
        '
        'PraktTbx
        '
        Me.PraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktTbx.Location = New System.Drawing.Point(325, 12)
        Me.PraktTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PraktTbx.Name = "PraktTbx"
        Me.PraktTbx.ReadOnly = True
        Me.PraktTbx.Size = New System.Drawing.Size(224, 26)
        Me.PraktTbx.TabIndex = 46
        Me.PraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Πρακτορείο:"
        '
        'ImeromKartelaPraktPck
        '
        Me.ImeromKartelaPraktPck.CustomFormat = "dd/MM/yy"
        Me.ImeromKartelaPraktPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ImeromKartelaPraktPck.Location = New System.Drawing.Point(215, 53)
        Me.ImeromKartelaPraktPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ImeromKartelaPraktPck.Name = "ImeromKartelaPraktPck"
        Me.ImeromKartelaPraktPck.Size = New System.Drawing.Size(173, 26)
        Me.ImeromKartelaPraktPck.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 57)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 20)
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
        Me.EispraxeisKataxPnl.Location = New System.Drawing.Point(17, 203)
        Me.EispraxeisKataxPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKataxPnl.Name = "EispraxeisKataxPnl"
        Me.EispraxeisKataxPnl.Size = New System.Drawing.Size(1060, 12)
        Me.EispraxeisKataxPnl.TabIndex = 42
        '
        'EispKataxParClearBtn
        '
        Me.EispKataxParClearBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EispKataxParClearBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EispKataxParClearBtn.Image = Global.winhotel.My.Resources.Resources.REDOLD
        Me.EispKataxParClearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParClearBtn.Location = New System.Drawing.Point(555, 366)
        Me.EispKataxParClearBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParClearBtn.Name = "EispKataxParClearBtn"
        Me.EispKataxParClearBtn.Size = New System.Drawing.Size(211, 28)
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
        Me.EispKataxParKataxBtn.Location = New System.Drawing.Point(265, 366)
        Me.EispKataxParKataxBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParKataxBtn.Name = "EispKataxParKataxBtn"
        Me.EispKataxParKataxBtn.Size = New System.Drawing.Size(185, 28)
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
        Me.EispraxeisKatax3Pnl.Location = New System.Drawing.Point(13, 446)
        Me.EispraxeisKatax3Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKatax3Pnl.Name = "EispraxeisKatax3Pnl"
        Me.EispraxeisKatax3Pnl.Size = New System.Drawing.Size(1005, 92)
        Me.EispraxeisKatax3Pnl.TabIndex = 47
        '
        'EispKataxParProkTbx
        '
        Me.EispKataxParProkTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParProkTbx.Location = New System.Drawing.Point(259, 48)
        Me.EispKataxParProkTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParProkTbx.MaxLength = 9
        Me.EispKataxParProkTbx.Name = "EispKataxParProkTbx"
        Me.EispKataxParProkTbx.Size = New System.Drawing.Size(112, 26)
        Me.EispKataxParProkTbx.TabIndex = 49
        Me.EispKataxParProkTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.Location = New System.Drawing.Point(43, 48)
        Me.Label130.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(169, 20)
        Me.Label130.TabIndex = 48
        Me.Label130.Text = "Ληφθείσα Προκατ.:"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = Global.winhotel.My.Resources.Resources.SSAVE
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(52, 267)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 28)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "Καταχώριση"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EispKataxParTrPlirCbx
        '
        Me.EispKataxParTrPlirCbx.FormattingEnabled = True
        Me.EispKataxParTrPlirCbx.Location = New System.Drawing.Point(616, 7)
        Me.EispKataxParTrPlirCbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParTrPlirCbx.Name = "EispKataxParTrPlirCbx"
        Me.EispKataxParTrPlirCbx.Size = New System.Drawing.Size(189, 28)
        Me.EispKataxParTrPlirCbx.TabIndex = 46
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.Location = New System.Drawing.Point(423, 7)
        Me.Label127.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(167, 20)
        Me.Label127.TabIndex = 44
        Me.Label127.Text = "Τρόπος Πληρωμής:"
        '
        'EispKataxParXrewsiTbx
        '
        Me.EispKataxParXrewsiTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParXrewsiTbx.Location = New System.Drawing.Point(259, 7)
        Me.EispKataxParXrewsiTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParXrewsiTbx.MaxLength = 9
        Me.EispKataxParXrewsiTbx.Name = "EispKataxParXrewsiTbx"
        Me.EispKataxParXrewsiTbx.Size = New System.Drawing.Size(112, 26)
        Me.EispKataxParXrewsiTbx.TabIndex = 45
        Me.EispKataxParXrewsiTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label131
        '
        Me.Label131.AutoSize = True
        Me.Label131.Location = New System.Drawing.Point(75, 11)
        Me.Label131.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(142, 20)
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
        Me.EispraxeisKatax2Pnl.Location = New System.Drawing.Point(13, 252)
        Me.EispraxeisKatax2Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKatax2Pnl.Name = "EispraxeisKatax2Pnl"
        Me.EispraxeisKatax2Pnl.Size = New System.Drawing.Size(1005, 92)
        Me.EispraxeisKatax2Pnl.TabIndex = 22
        '
        'EispKataxParSinPlinTbx
        '
        Me.EispKataxParSinPlinTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParSinPlinTbx.Location = New System.Drawing.Point(259, 48)
        Me.EispKataxParSinPlinTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParSinPlinTbx.MaxLength = 9
        Me.EispKataxParSinPlinTbx.Name = "EispKataxParSinPlinTbx"
        Me.EispKataxParSinPlinTbx.Size = New System.Drawing.Size(112, 26)
        Me.EispKataxParSinPlinTbx.TabIndex = 49
        Me.EispKataxParSinPlinTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.Location = New System.Drawing.Point(68, 48)
        Me.Label129.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(138, 20)
        Me.Label129.TabIndex = 48
        Me.Label129.Text = "Σύν-Πλήν ποσό:"
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Image = Global.winhotel.My.Resources.Resources.SSAVE
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.Location = New System.Drawing.Point(52, 267)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(231, 28)
        Me.Button6.TabIndex = 47
        Me.Button6.Text = "Καταχώριση"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'EispKataxParEisprTbx
        '
        Me.EispKataxParEisprTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EispKataxParEisprTbx.Location = New System.Drawing.Point(259, 7)
        Me.EispKataxParEisprTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParEisprTbx.MaxLength = 9
        Me.EispKataxParEisprTbx.Name = "EispKataxParEisprTbx"
        Me.EispKataxParEisprTbx.Size = New System.Drawing.Size(112, 26)
        Me.EispKataxParEisprTbx.TabIndex = 45
        Me.EispKataxParEisprTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Location = New System.Drawing.Point(123, 11)
        Me.Label128.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(93, 20)
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
        Me.EispraxeisKatax1Pnl.Location = New System.Drawing.Point(13, 25)
        Me.EispraxeisKatax1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKatax1Pnl.Name = "EispraxeisKatax1Pnl"
        Me.EispraxeisKatax1Pnl.Size = New System.Drawing.Size(1005, 225)
        Me.EispraxeisKatax1Pnl.TabIndex = 2
        '
        'KwdPrktTbx
        '
        Me.KwdPrktTbx.Location = New System.Drawing.Point(252, 119)
        Me.KwdPrktTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KwdPrktTbx.MaxLength = 4
        Me.KwdPrktTbx.Name = "KwdPrktTbx"
        Me.KwdPrktTbx.Size = New System.Drawing.Size(67, 26)
        Me.KwdPrktTbx.TabIndex = 13
        Me.KwdPrktTbx.TabStop = False
        Me.KwdPrktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispKataxParSucheBtn
        '
        Me.EispKataxParSucheBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EispKataxParSucheBtn.Image = Global.winhotel.My.Resources.Resources.SEARCH2
        Me.EispKataxParSucheBtn.Location = New System.Drawing.Point(544, 158)
        Me.EispKataxParSucheBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParSucheBtn.Name = "EispKataxParSucheBtn"
        Me.EispKataxParSucheBtn.Size = New System.Drawing.Size(49, 26)
        Me.EispKataxParSucheBtn.TabIndex = 44
        Me.EispKataxParSucheBtn.UseVisualStyleBackColor = True
        '
        'EispKataxParXrewsRdb
        '
        Me.EispKataxParXrewsRdb.AutoSize = True
        Me.EispKataxParXrewsRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParXrewsRdb.Location = New System.Drawing.Point(347, 54)
        Me.EispKataxParXrewsRdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParXrewsRdb.Name = "EispKataxParXrewsRdb"
        Me.EispKataxParXrewsRdb.Size = New System.Drawing.Size(95, 24)
        Me.EispKataxParXrewsRdb.TabIndex = 9
        Me.EispKataxParXrewsRdb.Text = "Χρέωση"
        Me.EispKataxParXrewsRdb.UseVisualStyleBackColor = True
        '
        'EispKataxParEispRdb
        '
        Me.EispKataxParEispRdb.AutoSize = True
        Me.EispKataxParEispRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EispKataxParEispRdb.Location = New System.Drawing.Point(188, 54)
        Me.EispKataxParEispRdb.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxParEispRdb.Name = "EispKataxParEispRdb"
        Me.EispKataxParEispRdb.Size = New System.Drawing.Size(108, 24)
        Me.EispKataxParEispRdb.TabIndex = 5
        Me.EispKataxParEispRdb.Text = "Είσπραξη"
        Me.EispKataxParEispRdb.UseVisualStyleBackColor = True
        '
        'Label144
        '
        Me.Label144.AutoSize = True
        Me.Label144.Location = New System.Drawing.Point(403, 164)
        Me.Label144.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(23, 20)
        Me.Label144.TabIndex = 43
        Me.Label144.Text = "--"
        '
        'Label140
        '
        Me.Label140.AutoSize = True
        Me.Label140.Location = New System.Drawing.Point(352, 164)
        Me.Label140.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(23, 20)
        Me.Label140.TabIndex = 42
        Me.Label140.Text = "--"
        '
        'EispKataxPar3Tbx
        '
        Me.EispKataxPar3Tbx.Location = New System.Drawing.Point(427, 156)
        Me.EispKataxPar3Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxPar3Tbx.MaxLength = 5
        Me.EispKataxPar3Tbx.Name = "EispKataxPar3Tbx"
        Me.EispKataxPar3Tbx.Size = New System.Drawing.Size(99, 26)
        Me.EispKataxPar3Tbx.TabIndex = 19
        Me.EispKataxPar3Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispraxeisKataxAitTbx
        '
        Me.EispraxeisKataxAitTbx.Location = New System.Drawing.Point(253, 192)
        Me.EispraxeisKataxAitTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKataxAitTbx.MaxLength = 99
        Me.EispraxeisKataxAitTbx.Multiline = True
        Me.EispraxeisKataxAitTbx.Name = "EispraxeisKataxAitTbx"
        Me.EispraxeisKataxAitTbx.Size = New System.Drawing.Size(549, 25)
        Me.EispraxeisKataxAitTbx.TabIndex = 26
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Location = New System.Drawing.Point(113, 198)
        Me.Label139.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(103, 20)
        Me.Label139.TabIndex = 27
        Me.Label139.Text = "Αιτιολογία:"
        '
        'EispKataxPar2Tbx
        '
        Me.EispKataxPar2Tbx.Location = New System.Drawing.Point(377, 156)
        Me.EispKataxPar2Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxPar2Tbx.MaxLength = 1
        Me.EispKataxPar2Tbx.Name = "EispKataxPar2Tbx"
        Me.EispKataxPar2Tbx.Size = New System.Drawing.Size(21, 26)
        Me.EispKataxPar2Tbx.TabIndex = 17
        Me.EispKataxPar2Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispKataxPar1Tbx
        '
        Me.EispKataxPar1Tbx.Location = New System.Drawing.Point(253, 156)
        Me.EispKataxPar1Tbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispKataxPar1Tbx.MaxLength = 5
        Me.EispKataxPar1Tbx.Name = "EispKataxPar1Tbx"
        Me.EispKataxPar1Tbx.Size = New System.Drawing.Size(99, 26)
        Me.EispKataxPar1Tbx.TabIndex = 15
        Me.EispKataxPar1Tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EispraxeisKataxPraktTbx
        '
        Me.EispraxeisKataxPraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EispraxeisKataxPraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.EispraxeisKataxPraktTbx.Location = New System.Drawing.Point(328, 119)
        Me.EispraxeisKataxPraktTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKataxPraktTbx.Name = "EispraxeisKataxPraktTbx"
        Me.EispraxeisKataxPraktTbx.ReadOnly = True
        Me.EispraxeisKataxPraktTbx.Size = New System.Drawing.Size(224, 26)
        Me.EispraxeisKataxPraktTbx.TabIndex = 18
        Me.EispraxeisKataxPraktTbx.TabStop = False
        Me.EispraxeisKataxPraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label138
        '
        Me.Label138.AutoSize = True
        Me.Label138.Location = New System.Drawing.Point(113, 123)
        Me.Label138.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(113, 20)
        Me.Label138.TabIndex = 28
        Me.Label138.Text = "Πρακτορείο:"
        '
        'Label141
        '
        Me.Label141.AutoSize = True
        Me.Label141.Location = New System.Drawing.Point(104, 160)
        Me.Label141.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(120, 20)
        Me.Label141.TabIndex = 23
        Me.Label141.Text = "Παραστατικό:"
        '
        'EispraxeisKataxPck
        '
        Me.EispraxeisKataxPck.Location = New System.Drawing.Point(253, 85)
        Me.EispraxeisKataxPck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EispraxeisKataxPck.Name = "EispraxeisKataxPck"
        Me.EispraxeisKataxPck.Size = New System.Drawing.Size(265, 26)
        Me.EispraxeisKataxPck.TabIndex = 11
        '
        'Label142
        '
        Me.Label142.AutoSize = True
        Me.Label142.Location = New System.Drawing.Point(109, 89)
        Me.Label142.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(121, 20)
        Me.Label142.TabIndex = 1
        Me.Label142.Text = " Ημερομηνία:"
        '
        'Label143
        '
        Me.Label143.AutoSize = True
        Me.Label143.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label143.ForeColor = System.Drawing.Color.Blue
        Me.Label143.Location = New System.Drawing.Point(9, 14)
        Me.Label143.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(310, 20)
        Me.Label143.TabIndex = 0
        Me.Label143.Text = "Καταχώρηση Εισπράξεων-Χρεώσεων"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(492, 889)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(579, 12)
        Me.CrystalReportViewer1.TabIndex = 45
        Me.CrystalReportViewer1.ToolPanelWidth = 267
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'KinisiPraktEktPnl
        '
        Me.KinisiPraktEktPnl.Controls.Add(Me.KinisiPraktEkt1Pnl)
        Me.KinisiPraktEktPnl.Location = New System.Drawing.Point(31, 54)
        Me.KinisiPraktEktPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiPraktEktPnl.Name = "KinisiPraktEktPnl"
        Me.KinisiPraktEktPnl.Size = New System.Drawing.Size(1060, 12)
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
        Me.KinisiPraktEkt1Pnl.Location = New System.Drawing.Point(13, 28)
        Me.KinisiPraktEkt1Pnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiPraktEkt1Pnl.Name = "KinisiPraktEkt1Pnl"
        Me.KinisiPraktEkt1Pnl.Size = New System.Drawing.Size(1013, 182)
        Me.KinisiPraktEkt1Pnl.TabIndex = 1
        '
        'pBar1
        '
        Me.pBar1.Location = New System.Drawing.Point(332, 162)
        Me.pBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pBar1.Name = "pBar1"
        Me.pBar1.Size = New System.Drawing.Size(329, 16)
        Me.pBar1.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(520, 31)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 20)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "μέχρι Ημερομηνία:"
        '
        'KinisiPraktEkt2Pck
        '
        Me.KinisiPraktEkt2Pck.Location = New System.Drawing.Point(705, 27)
        Me.KinisiPraktEkt2Pck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiPraktEkt2Pck.Name = "KinisiPraktEkt2Pck"
        Me.KinisiPraktEkt2Pck.Size = New System.Drawing.Size(265, 26)
        Me.KinisiPraktEkt2Pck.TabIndex = 46
        '
        'KinisiPraktEktBtn
        '
        Me.KinisiPraktEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KinisiPraktEktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.KinisiPraktEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KinisiPraktEktBtn.Location = New System.Drawing.Point(381, 110)
        Me.KinisiPraktEktBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiPraktEktBtn.Name = "KinisiPraktEktBtn"
        Me.KinisiPraktEktBtn.Size = New System.Drawing.Size(217, 31)
        Me.KinisiPraktEktBtn.TabIndex = 45
        Me.KinisiPraktEktBtn.Text = "Προεπισκόπηση"
        Me.KinisiPraktEktBtn.UseVisualStyleBackColor = True
        '
        'KinisiPraktEkt1Pck
        '
        Me.KinisiPraktEkt1Pck.Location = New System.Drawing.Point(197, 23)
        Me.KinisiPraktEkt1Pck.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.KinisiPraktEkt1Pck.Name = "KinisiPraktEkt1Pck"
        Me.KinisiPraktEkt1Pck.Size = New System.Drawing.Size(265, 26)
        Me.KinisiPraktEkt1Pck.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 20)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = " από Ημερομηνία:"
        '
        'EtiketaPraktPnl
        '
        Me.EtiketaPraktPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPraktPnl.Location = New System.Drawing.Point(20, 860)
        Me.EtiketaPraktPnl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EtiketaPraktPnl.Name = "EtiketaPraktPnl"
        Me.EtiketaPraktPnl.Size = New System.Drawing.Size(267, 12)
        Me.EtiketaPraktPnl.TabIndex = 0
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaLbl.Location = New System.Drawing.Point(29, 30)
        Me.EtiketaLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(111, 36)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1412, 943)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Praktoreia"
        Me.Text = "Κίνηση Λογαριασμών Πρακτορείων"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
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
