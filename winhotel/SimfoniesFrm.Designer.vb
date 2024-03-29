<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimfoniesFrm
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τύποι χρέωσης")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πρακτορεία")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τουριστικές Περίοδοι για Πρακτορεία")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A' Τρόπος")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Β' Τρόπος")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Allotment Πρακτορείων", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("A' Τρόπος")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Β' Τρόπος")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Booking Position Πρακτορείων", New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Συμφωνίες(Τιμοκατάλογοι)")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Λήψη από βάση")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ενημέρωση βάσης")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Φόρτωση τιμών", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Συμφωνίες-B.Positions Πρακτορείων", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode6, TreeNode9, TreeNode10, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εθνικότητες")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πρακτορεία")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τουριστ. Περίοδοι")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Allotments")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Booking Positions")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τιμοκατάλογοι")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτυπώσεις", New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimfoniesFrm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.HauptPnl = New System.Windows.Forms.Panel()
        Me.BookingBPnl = New System.Windows.Forms.Panel()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.SimbBPbPnl = New System.Windows.Forms.Panel()
        Me.BookPos2Pnl = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.AllotmRBbPnl = New System.Windows.Forms.Panel()
        Me.PraktorBTbx = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.EtiketaPnl = New System.Windows.Forms.Panel()
        Me.ForoiPnl = New System.Windows.Forms.Panel()
        Me.EtiketaLbl = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SxedioPnl = New System.Windows.Forms.Panel()
        Me.TmimaPnl = New System.Windows.Forms.Panel()
        Me.EkdosiPnl = New System.Windows.Forms.Panel()
        Me.BookingAPnl = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ImeromEkdoDtp = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BPSimbPnl = New System.Windows.Forms.Panel()
        Me.AllotmSichtPnl = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.AllotmRBPnl = New System.Windows.Forms.Panel()
        Me.PraktorTbx = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.BookPos1Pnl = New System.Windows.Forms.Panel()
        Me.Allotm1Pnl = New System.Windows.Forms.Panel()
        Me.InfoPnl = New System.Windows.Forms.Panel()
        Me.ArxiTbx = New System.Windows.Forms.TextBox()
        Me.AASimbPnl = New System.Windows.Forms.Panel()
        Me.Allotm3Pnl = New System.Windows.Forms.Panel()
        Me.Allotm2Pnl = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KlinsCbx = New System.Windows.Forms.ComboBox()
        Me.SimbTxb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TipiCbx = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GuaraRB = New System.Windows.Forms.RadioButton()
        Me.AllotmRB = New System.Windows.Forms.RadioButton()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.PraktTbx = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PeriodoiPnl = New System.Windows.Forms.Panel()
        Me.SimbolaioPnl = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.PraktoreioTbx = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.SimbolaioTbx = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.NameLbl = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PraktoreiaPnl = New System.Windows.Forms.Panel()
        Me.PraktoreiaDataGridView = New System.Windows.Forms.DataGridView()
        Me.KwdDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eponimia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.BindingNavigator5 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton25 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox4 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton()
        Me.EktTimokPnl = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.EktTimokTbx = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.EktTimokBtn = New System.Windows.Forms.Button()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.EktBookPnl = New System.Windows.Forms.Panel()
        Me.EktBook2Pnl = New System.Windows.Forms.Panel()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.EktBookTbx = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.EktBookBtn = New System.Windows.Forms.Button()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.EktAllotmentPnl = New System.Windows.Forms.Panel()
        Me.EktAllotment1Pnl = New System.Windows.Forms.Panel()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.EktAllotmentTbx = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.EktAllotment1Btn = New System.Windows.Forms.Button()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.EuretirioPeriodoiPnl = New System.Windows.Forms.Panel()
        Me.PeriodoiDtGrd = New System.Windows.Forms.DataGridView()
        Me.PinakasDwm1Pnl = New System.Windows.Forms.Panel()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.OrderKwdRdb = New System.Windows.Forms.RadioButton()
        Me.OrderPraktRdb = New System.Windows.Forms.RadioButton()
        Me.EuretirioPeriodoiBtn = New System.Windows.Forms.Button()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SimfoniesPnl = New System.Windows.Forms.Panel()
        Me.TimiAtomoPnl = New System.Windows.Forms.Panel()
        Me.TimiAtomoTbx = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.SimfTipoiXrewsPnl = New System.Windows.Forms.Panel()
        Me.SimfPososPnl = New System.Windows.Forms.Panel()
        Me.TimesCBoxenPnl = New System.Windows.Forms.Panel()
        Me.TipoiXrewsisPnl = New System.Windows.Forms.Panel()
        Me.TXrewsisDataGridView = New System.Windows.Forms.DataGridView()
        Me.KwdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xrewsi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.perigrafi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ypnos = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.prwino = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.geuma = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.deipno = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.XrewseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator4 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
        Me.DeipnTbx = New System.Windows.Forms.TextBox()
        Me.GeumTbx = New System.Windows.Forms.TextBox()
        Me.PrwinTbx = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.SimfPaidiaPnl = New System.Windows.Forms.Panel()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.SimfAAPnl = New System.Windows.Forms.Panel()
        Me.SimfPnlPnl = New System.Windows.Forms.Panel()
        Me.InfSinfLbl = New System.Windows.Forms.Label()
        Me.AddTimesBtn = New System.Windows.Forms.Button()
        Me.SimfParamPnl = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.SimfSimbAAPnl = New System.Windows.Forms.Panel()
        Me.SimfPraktTbx = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.AllotmBPnl = New System.Windows.Forms.Panel()
        Me.AASimbolPnl = New System.Windows.Forms.Panel()
        Me.SeasonPnl = New System.Windows.Forms.Panel()
        Me.SeasonsDataGridView = New System.Windows.Forms.DataGridView()
        Me.BindingNavigator6 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripButton29 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton30 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton31 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton32 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox5 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton33 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton34 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton35 = New System.Windows.Forms.ToolStripButton()
        Me.XrewseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter()
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter()
        Me.SeasonsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SeasonsTableAdapter = New winhotel.dbhotelDataSetTableAdapters.seasonsTableAdapter()
        Me.SimbolaiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimbolaiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter()
        Me.TouristperiodoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TouristperiodoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.touristperiodoiTableAdapter()
        Me.KatigoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatigoriesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter()
        Me.AllotmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AllotmentTableAdapter = New winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter()
        Me.KlinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlinesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter()
        Me.TipoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter()
        Me.BookingposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BookingposTableAdapter = New winhotel.dbhotelDataSetTableAdapters.bookingposTableAdapter()
        Me.SimfoniesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimfoniesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simfoniesTableAdapter()
        Me.TimesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timesTableAdapter()
        Me.TimeskratisisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimeskratisisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timeskratisisTableAdapter()
        Me.Touristperiodoi1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Touristperiodoi1TableAdapter = New winhotel.dbhotelDataSetTableAdapters.touristperiodoi1TableAdapter()
        Me.Times_ekt_joinBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Times_ekt_joinTableAdapter = New winhotel.dbhotelDataSetTableAdapters.times_ekt_joinTableAdapter()
        Me.EthnikotitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikotitesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter()
        Me.XoresBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XoresTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xoresTableAdapter()
        Me.PistwtikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PistwtikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.pistwtikesTableAdapter()
        Me.ParastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.HauptPnl.SuspendLayout()
        Me.BookingBPnl.SuspendLayout()
        Me.EtiketaPnl.SuspendLayout()
        Me.BookingAPnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Allotm1Pnl.SuspendLayout()
        Me.Allotm2Pnl.SuspendLayout()
        Me.SimbolaioPnl.SuspendLayout()
        Me.PraktoreiaPnl.SuspendLayout()
        CType(Me.PraktoreiaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator5.SuspendLayout()
        Me.EktTimokPnl.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.EktBookPnl.SuspendLayout()
        Me.EktBook2Pnl.SuspendLayout()
        Me.EktAllotmentPnl.SuspendLayout()
        Me.EktAllotment1Pnl.SuspendLayout()
        Me.EuretirioPeriodoiPnl.SuspendLayout()
        CType(Me.PeriodoiDtGrd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PinakasDwm1Pnl.SuspendLayout()
        Me.SimfoniesPnl.SuspendLayout()
        Me.TimiAtomoPnl.SuspendLayout()
        Me.SimfPososPnl.SuspendLayout()
        Me.TimesCBoxenPnl.SuspendLayout()
        Me.TipoiXrewsisPnl.SuspendLayout()
        CType(Me.TXrewsisDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator4.SuspendLayout()
        Me.SimfPaidiaPnl.SuspendLayout()
        Me.SimfPnlPnl.SuspendLayout()
        Me.SeasonPnl.SuspendLayout()
        CType(Me.SeasonsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator6.SuspendLayout()
        CType(Me.SeasonsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TouristperiodoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BookingposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimfoniesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeskratisisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Touristperiodoi1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Times_ekt_joinBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XoresBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PistwtikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.HauptPnl)
        Me.SplitContainer1.Size = New System.Drawing.Size(1023, 722)
        Me.SplitContainer1.SplitterDistance = 167
        Me.SplitContainer1.TabIndex = 0
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.LightGray
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Nina", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TreeView1.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Node20"
        TreeNode1.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode1.Text = "Τύποι χρέωσης"
        TreeNode2.Name = "Node22"
        TreeNode2.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode2.Text = "Πρακτορεία"
        TreeNode3.Name = "Node23"
        TreeNode3.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode3.Text = "Τουριστικές Περίοδοι για Πρακτορεία"
        TreeNode4.Name = "Node241"
        TreeNode4.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode4.Text = "A' Τρόπος"
        TreeNode5.Name = "Node242"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode5.Text = "Β' Τρόπος"
        TreeNode6.ForeColor = System.Drawing.Color.Black
        TreeNode6.Name = "Node24"
        TreeNode6.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode6.Text = "Allotment Πρακτορείων"
        TreeNode7.Name = "Node251"
        TreeNode7.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode7.Text = "A' Τρόπος"
        TreeNode8.Name = "Node252"
        TreeNode8.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode8.Text = "Β' Τρόπος"
        TreeNode9.ForeColor = System.Drawing.Color.Black
        TreeNode9.Name = "Node25"
        TreeNode9.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode9.Text = "Booking Position Πρακτορείων"
        TreeNode10.Name = "Node26"
        TreeNode10.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode10.Text = "Συμφωνίες(Τιμοκατάλογοι)"
        TreeNode11.Name = "fortosi"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        TreeNode11.Text = "Λήψη από βάση"
        TreeNode12.BackColor = System.Drawing.Color.Yellow
        TreeNode12.Name = "enimerosi"
        TreeNode12.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        TreeNode12.Text = "Ενημέρωση βάσης"
        TreeNode13.ForeColor = System.Drawing.Color.Green
        TreeNode13.Name = "Node0"
        TreeNode13.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode13.Text = "Φόρτωση τιμών"
        TreeNode14.ForeColor = System.Drawing.Color.Blue
        TreeNode14.Name = "Node10"
        TreeNode14.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode14.Text = "Συμφωνίες-B.Positions Πρακτορείων"
        TreeNode15.Name = "ekt_ethnikotites"
        TreeNode15.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode15.Text = "Εθνικότητες"
        TreeNode16.Name = "praktoreia"
        TreeNode16.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode16.Text = "Πρακτορεία"
        TreeNode17.Name = "ektiposi_periodoi"
        TreeNode17.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode17.Text = "Τουριστ. Περίοδοι"
        TreeNode18.Name = "ektiposiallotment"
        TreeNode18.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode18.Text = "Allotments"
        TreeNode19.Name = "ektiposibookpos"
        TreeNode19.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode19.Text = "Booking Positions"
        TreeNode20.Name = "ekttimokatalog"
        TreeNode20.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode20.Text = "Τιμοκατάλογοι"
        TreeNode21.ForeColor = System.Drawing.Color.Blue
        TreeNode21.Name = "ektiposeis"
        TreeNode21.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode21.Text = "Εκτυπώσεις"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode21})
        Me.TreeView1.Size = New System.Drawing.Size(167, 722)
        Me.TreeView1.TabIndex = 1
        '
        'HauptPnl
        '
        Me.HauptPnl.AutoScroll = True
        Me.HauptPnl.Controls.Add(Me.BookingBPnl)
        Me.HauptPnl.Controls.Add(Me.EtiketaPnl)
        Me.HauptPnl.Controls.Add(Me.BookingAPnl)
        Me.HauptPnl.Controls.Add(Me.Allotm1Pnl)
        Me.HauptPnl.Controls.Add(Me.PeriodoiPnl)
        Me.HauptPnl.Controls.Add(Me.SimbolaioPnl)
        Me.HauptPnl.Controls.Add(Me.PraktoreiaPnl)
        Me.HauptPnl.Controls.Add(Me.EktTimokPnl)
        Me.HauptPnl.Controls.Add(Me.EktBookPnl)
        Me.HauptPnl.Controls.Add(Me.EktAllotmentPnl)
        Me.HauptPnl.Controls.Add(Me.EuretirioPeriodoiPnl)
        Me.HauptPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.HauptPnl.Controls.Add(Me.SimfoniesPnl)
        Me.HauptPnl.Controls.Add(Me.AllotmBPnl)
        Me.HauptPnl.Controls.Add(Me.AASimbolPnl)
        Me.HauptPnl.Controls.Add(Me.SeasonPnl)
        Me.HauptPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HauptPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.HauptPnl.Location = New System.Drawing.Point(0, 0)
        Me.HauptPnl.Name = "HauptPnl"
        Me.HauptPnl.Size = New System.Drawing.Size(852, 722)
        Me.HauptPnl.TabIndex = 0
        '
        'BookingBPnl
        '
        Me.BookingBPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BookingBPnl.Controls.Add(Me.Label37)
        Me.BookingBPnl.Controls.Add(Me.SimbBPbPnl)
        Me.BookingBPnl.Controls.Add(Me.BookPos2Pnl)
        Me.BookingBPnl.Controls.Add(Me.Label39)
        Me.BookingBPnl.Controls.Add(Me.AllotmRBbPnl)
        Me.BookingBPnl.Controls.Add(Me.PraktorBTbx)
        Me.BookingBPnl.Controls.Add(Me.Label40)
        Me.BookingBPnl.Controls.Add(Me.Label41)
        Me.BookingBPnl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BookingBPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BookingBPnl.Location = New System.Drawing.Point(33, 94)
        Me.BookingBPnl.Name = "BookingBPnl"
        Me.BookingBPnl.Size = New System.Drawing.Size(771, 11)
        Me.BookingBPnl.TabIndex = 49
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(5, 105)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(112, 13)
        Me.Label37.TabIndex = 22
        Me.Label37.Text = "Α/Α Συμβολαίου->"
        '
        'SimbBPbPnl
        '
        Me.SimbBPbPnl.AutoScroll = True
        Me.SimbBPbPnl.BackColor = System.Drawing.SystemColors.Control
        Me.SimbBPbPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SimbBPbPnl.Location = New System.Drawing.Point(125, 94)
        Me.SimbBPbPnl.Name = "SimbBPbPnl"
        Me.SimbBPbPnl.Size = New System.Drawing.Size(291, 61)
        Me.SimbBPbPnl.TabIndex = 21
        '
        'BookPos2Pnl
        '
        Me.BookPos2Pnl.AutoScroll = True
        Me.BookPos2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BookPos2Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BookPos2Pnl.Location = New System.Drawing.Point(19, 190)
        Me.BookPos2Pnl.Name = "BookPos2Pnl"
        Me.BookPos2Pnl.Size = New System.Drawing.Size(735, 312)
        Me.BookPos2Pnl.TabIndex = 17
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(457, 32)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(77, 13)
        Me.Label39.TabIndex = 13
        Me.Label39.Text = "Κατηγορία: "
        '
        'AllotmRBbPnl
        '
        Me.AllotmRBbPnl.AutoScroll = True
        Me.AllotmRBbPnl.BackColor = System.Drawing.SystemColors.Control
        Me.AllotmRBbPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AllotmRBbPnl.Location = New System.Drawing.Point(460, 52)
        Me.AllotmRBbPnl.Name = "AllotmRBbPnl"
        Me.AllotmRBbPnl.Size = New System.Drawing.Size(293, 121)
        Me.AllotmRBbPnl.TabIndex = 12
        '
        'PraktorBTbx
        '
        Me.PraktorBTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktorBTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktorBTbx.Location = New System.Drawing.Point(129, 68)
        Me.PraktorBTbx.Name = "PraktorBTbx"
        Me.PraktorBTbx.ReadOnly = True
        Me.PraktorBTbx.Size = New System.Drawing.Size(200, 20)
        Me.PraktorBTbx.TabIndex = 2
        Me.PraktorBTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(24, 71)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(79, 13)
        Me.Label40.TabIndex = 1
        Me.Label40.Text = "Πρακτορείο:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Blue
        Me.Label41.Location = New System.Drawing.Point(16, 25)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(394, 15)
        Me.Label41.TabIndex = 0
        Me.Label41.Text = "επιλογή κατά σειρά Πρακτορείου - Συμβολαίου - Κατηγορίας:"
        '
        'EtiketaPnl
        '
        Me.EtiketaPnl.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.EtiketaPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EtiketaPnl.Controls.Add(Me.ForoiPnl)
        Me.EtiketaPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPnl.Controls.Add(Me.Panel3)
        Me.EtiketaPnl.Controls.Add(Me.SxedioPnl)
        Me.EtiketaPnl.Controls.Add(Me.TmimaPnl)
        Me.EtiketaPnl.Controls.Add(Me.EkdosiPnl)
        Me.EtiketaPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaPnl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaPnl.Location = New System.Drawing.Point(656, 5)
        Me.EtiketaPnl.Name = "EtiketaPnl"
        Me.EtiketaPnl.Size = New System.Drawing.Size(134, 20)
        Me.EtiketaPnl.TabIndex = 48
        '
        'ForoiPnl
        '
        Me.ForoiPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ForoiPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ForoiPnl.Location = New System.Drawing.Point(565, 90)
        Me.ForoiPnl.Name = "ForoiPnl"
        Me.ForoiPnl.Size = New System.Drawing.Size(57, 100)
        Me.ForoiPnl.TabIndex = 11
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Location = New System.Drawing.Point(4, 17)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(72, 24)
        Me.EtiketaLbl.TabIndex = 0
        Me.EtiketaLbl.Text = "Label1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel3.Location = New System.Drawing.Point(195, 90)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(65, 100)
        Me.Panel3.TabIndex = 6
        '
        'SxedioPnl
        '
        Me.SxedioPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SxedioPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SxedioPnl.Location = New System.Drawing.Point(479, 90)
        Me.SxedioPnl.Name = "SxedioPnl"
        Me.SxedioPnl.Size = New System.Drawing.Size(57, 100)
        Me.SxedioPnl.TabIndex = 10
        '
        'TmimaPnl
        '
        Me.TmimaPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TmimaPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TmimaPnl.Location = New System.Drawing.Point(230, 90)
        Me.TmimaPnl.Name = "TmimaPnl"
        Me.TmimaPnl.Size = New System.Drawing.Size(57, 100)
        Me.TmimaPnl.TabIndex = 7
        '
        'EkdosiPnl
        '
        Me.EkdosiPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EkdosiPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EkdosiPnl.Location = New System.Drawing.Point(321, 90)
        Me.EkdosiPnl.Name = "EkdosiPnl"
        Me.EkdosiPnl.Size = New System.Drawing.Size(57, 100)
        Me.EkdosiPnl.TabIndex = 8
        '
        'BookingAPnl
        '
        Me.BookingAPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BookingAPnl.Controls.Add(Me.Label32)
        Me.BookingAPnl.Controls.Add(Me.Panel1)
        Me.BookingAPnl.Controls.Add(Me.Label31)
        Me.BookingAPnl.Controls.Add(Me.Label28)
        Me.BookingAPnl.Controls.Add(Me.BPSimbPnl)
        Me.BookingAPnl.Controls.Add(Me.AllotmSichtPnl)
        Me.BookingAPnl.Controls.Add(Me.Label33)
        Me.BookingAPnl.Controls.Add(Me.AllotmRBPnl)
        Me.BookingAPnl.Controls.Add(Me.PraktorTbx)
        Me.BookingAPnl.Controls.Add(Me.Label35)
        Me.BookingAPnl.Controls.Add(Me.Label36)
        Me.BookingAPnl.Controls.Add(Me.BookPos1Pnl)
        Me.BookingAPnl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BookingAPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BookingAPnl.Location = New System.Drawing.Point(24, 42)
        Me.BookingAPnl.Name = "BookingAPnl"
        Me.BookingAPnl.Size = New System.Drawing.Size(771, 17)
        Me.BookingAPnl.TabIndex = 47
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(52, 360)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(63, 13)
        Me.Label32.TabIndex = 25
        Me.Label32.Text = "Allotment:"
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.ImeromEkdoDtp)
        Me.Panel1.Location = New System.Drawing.Point(123, 298)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(332, 39)
        Me.Panel1.TabIndex = 24
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Image = Global.winhotel.My.Resources.Resources.DOIT
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(214, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(108, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Ανανέωση"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ImeromEkdoDtp
        '
        Me.ImeromEkdoDtp.Location = New System.Drawing.Point(10, 8)
        Me.ImeromEkdoDtp.Name = "ImeromEkdoDtp"
        Me.ImeromEkdoDtp.Size = New System.Drawing.Size(200, 20)
        Me.ImeromEkdoDtp.TabIndex = 19
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(5, 105)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 13)
        Me.Label31.TabIndex = 22
        Me.Label31.Text = "Α/Α Συμβολαίου->"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(5, 312)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(118, 13)
        Me.Label28.TabIndex = 18
        Me.Label28.Text = "Ημερ/νία έκδοσης:"
        '
        'BPSimbPnl
        '
        Me.BPSimbPnl.AutoScroll = True
        Me.BPSimbPnl.BackColor = System.Drawing.SystemColors.Control
        Me.BPSimbPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BPSimbPnl.Location = New System.Drawing.Point(125, 94)
        Me.BPSimbPnl.Name = "BPSimbPnl"
        Me.BPSimbPnl.Size = New System.Drawing.Size(291, 61)
        Me.BPSimbPnl.TabIndex = 21
        '
        'AllotmSichtPnl
        '
        Me.AllotmSichtPnl.AutoScroll = True
        Me.AllotmSichtPnl.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.AllotmSichtPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AllotmSichtPnl.Location = New System.Drawing.Point(121, 356)
        Me.AllotmSichtPnl.Name = "AllotmSichtPnl"
        Me.AllotmSichtPnl.Size = New System.Drawing.Size(295, 245)
        Me.AllotmSichtPnl.TabIndex = 20
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(3, 172)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 13)
        Me.Label33.TabIndex = 13
        Me.Label33.Text = "Κατηγορία αρχής->"
        '
        'AllotmRBPnl
        '
        Me.AllotmRBPnl.AutoScroll = True
        Me.AllotmRBPnl.BackColor = System.Drawing.SystemColors.Control
        Me.AllotmRBPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AllotmRBPnl.Location = New System.Drawing.Point(123, 161)
        Me.AllotmRBPnl.Name = "AllotmRBPnl"
        Me.AllotmRBPnl.Size = New System.Drawing.Size(293, 122)
        Me.AllotmRBPnl.TabIndex = 12
        '
        'PraktorTbx
        '
        Me.PraktorTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktorTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktorTbx.Location = New System.Drawing.Point(129, 68)
        Me.PraktorTbx.Name = "PraktorTbx"
        Me.PraktorTbx.ReadOnly = True
        Me.PraktorTbx.Size = New System.Drawing.Size(200, 20)
        Me.PraktorTbx.TabIndex = 2
        Me.PraktorTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(24, 71)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(79, 13)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Πρακτορείο:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(7, 25)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(394, 15)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "επιλογή κατά σειρά Πρακτορείου - Συμβολαίου - Κατηγορίας:"
        '
        'BookPos1Pnl
        '
        Me.BookPos1Pnl.AutoScroll = True
        Me.BookPos1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BookPos1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BookPos1Pnl.Location = New System.Drawing.Point(728, 23)
        Me.BookPos1Pnl.Name = "BookPos1Pnl"
        Me.BookPos1Pnl.Size = New System.Drawing.Size(15, 476)
        Me.BookPos1Pnl.TabIndex = 30
        '
        'Allotm1Pnl
        '
        Me.Allotm1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Allotm1Pnl.Controls.Add(Me.InfoPnl)
        Me.Allotm1Pnl.Controls.Add(Me.ArxiTbx)
        Me.Allotm1Pnl.Controls.Add(Me.AASimbPnl)
        Me.Allotm1Pnl.Controls.Add(Me.Allotm3Pnl)
        Me.Allotm1Pnl.Controls.Add(Me.Allotm2Pnl)
        Me.Allotm1Pnl.Controls.Add(Me.Label29)
        Me.Allotm1Pnl.Controls.Add(Me.Label25)
        Me.Allotm1Pnl.Controls.Add(Me.PraktTbx)
        Me.Allotm1Pnl.Controls.Add(Me.Label24)
        Me.Allotm1Pnl.Controls.Add(Me.Label23)
        Me.Allotm1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Allotm1Pnl.Location = New System.Drawing.Point(24, 31)
        Me.Allotm1Pnl.Name = "Allotm1Pnl"
        Me.Allotm1Pnl.Size = New System.Drawing.Size(757, 10)
        Me.Allotm1Pnl.TabIndex = 46
        '
        'InfoPnl
        '
        Me.InfoPnl.Location = New System.Drawing.Point(7, 371)
        Me.InfoPnl.Name = "InfoPnl"
        Me.InfoPnl.Size = New System.Drawing.Size(409, 224)
        Me.InfoPnl.TabIndex = 19
        '
        'ArxiTbx
        '
        Me.ArxiTbx.Location = New System.Drawing.Point(116, 112)
        Me.ArxiTbx.Name = "ArxiTbx"
        Me.ArxiTbx.ReadOnly = True
        Me.ArxiTbx.Size = New System.Drawing.Size(200, 20)
        Me.ArxiTbx.TabIndex = 18
        Me.ArxiTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AASimbPnl
        '
        Me.AASimbPnl.AutoScroll = True
        Me.AASimbPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AASimbPnl.Location = New System.Drawing.Point(116, 153)
        Me.AASimbPnl.Name = "AASimbPnl"
        Me.AASimbPnl.Size = New System.Drawing.Size(296, 75)
        Me.AASimbPnl.TabIndex = 45
        '
        'Allotm3Pnl
        '
        Me.Allotm3Pnl.AutoScroll = True
        Me.Allotm3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Allotm3Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Allotm3Pnl.Location = New System.Drawing.Point(735, 9)
        Me.Allotm3Pnl.Name = "Allotm3Pnl"
        Me.Allotm3Pnl.Size = New System.Drawing.Size(14, 436)
        Me.Allotm3Pnl.TabIndex = 17
        '
        'Allotm2Pnl
        '
        Me.Allotm2Pnl.BackColor = System.Drawing.SystemColors.Control
        Me.Allotm2Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Allotm2Pnl.Controls.Add(Me.Label1)
        Me.Allotm2Pnl.Controls.Add(Me.KlinsCbx)
        Me.Allotm2Pnl.Controls.Add(Me.SimbTxb)
        Me.Allotm2Pnl.Controls.Add(Me.Label2)
        Me.Allotm2Pnl.Controls.Add(Me.TipiCbx)
        Me.Allotm2Pnl.Controls.Add(Me.Label3)
        Me.Allotm2Pnl.Controls.Add(Me.GuaraRB)
        Me.Allotm2Pnl.Controls.Add(Me.AllotmRB)
        Me.Allotm2Pnl.Location = New System.Drawing.Point(7, 244)
        Me.Allotm2Pnl.Name = "Allotm2Pnl"
        Me.Allotm2Pnl.Size = New System.Drawing.Size(409, 126)
        Me.Allotm2Pnl.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Συμβόλαιο:"
        '
        'KlinsCbx
        '
        Me.KlinsCbx.ForeColor = System.Drawing.Color.Maroon
        Me.KlinsCbx.FormattingEnabled = True
        Me.KlinsCbx.Location = New System.Drawing.Point(39, 61)
        Me.KlinsCbx.Name = "KlinsCbx"
        Me.KlinsCbx.Size = New System.Drawing.Size(120, 21)
        Me.KlinsCbx.TabIndex = 5
        '
        'SimbTxb
        '
        Me.SimbTxb.BackColor = System.Drawing.Color.White
        Me.SimbTxb.ForeColor = System.Drawing.Color.Blue
        Me.SimbTxb.Location = New System.Drawing.Point(110, 15)
        Me.SimbTxb.MaxLength = 40
        Me.SimbTxb.Name = "SimbTxb"
        Me.SimbTxb.ReadOnly = True
        Me.SimbTxb.Size = New System.Drawing.Size(273, 20)
        Me.SimbTxb.TabIndex = 14
        Me.SimbTxb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Κλίνες:"
        '
        'TipiCbx
        '
        Me.TipiCbx.ForeColor = System.Drawing.Color.Maroon
        Me.TipiCbx.FormattingEnabled = True
        Me.TipiCbx.Location = New System.Drawing.Point(234, 61)
        Me.TipiCbx.Name = "TipiCbx"
        Me.TipiCbx.Size = New System.Drawing.Size(120, 21)
        Me.TipiCbx.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Τύπος (Θέα):"
        '
        'GuaraRB
        '
        Me.GuaraRB.AutoSize = True
        Me.GuaraRB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.GuaraRB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GuaraRB.Enabled = False
        Me.GuaraRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.GuaraRB.ForeColor = System.Drawing.Color.Maroon
        Me.GuaraRB.Location = New System.Drawing.Point(80, 103)
        Me.GuaraRB.Name = "GuaraRB"
        Me.GuaraRB.Size = New System.Drawing.Size(98, 20)
        Me.GuaraRB.TabIndex = 9
        Me.GuaraRB.TabStop = True
        Me.GuaraRB.Text = "Guarantee"
        Me.GuaraRB.UseVisualStyleBackColor = True
        '
        'AllotmRB
        '
        Me.AllotmRB.AutoSize = True
        Me.AllotmRB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AllotmRB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AllotmRB.Enabled = False
        Me.AllotmRB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.AllotmRB.ForeColor = System.Drawing.Color.Maroon
        Me.AllotmRB.Location = New System.Drawing.Point(209, 103)
        Me.AllotmRB.Name = "AllotmRB"
        Me.AllotmRB.Size = New System.Drawing.Size(90, 20)
        Me.AllotmRB.TabIndex = 10
        Me.AllotmRB.TabStop = True
        Me.AllotmRB.Text = "Allotment"
        Me.AllotmRB.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(3, 164)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 13)
        Me.Label29.TabIndex = 13
        Me.Label29.Text = "Α/Α Συμβολαίου->"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(17, 115)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 13)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "Αρχή Season:"
        '
        'PraktTbx
        '
        Me.PraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktTbx.Location = New System.Drawing.Point(116, 68)
        Me.PraktTbx.Name = "PraktTbx"
        Me.PraktTbx.ReadOnly = True
        Me.PraktTbx.Size = New System.Drawing.Size(200, 20)
        Me.PraktTbx.TabIndex = 2
        Me.PraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(24, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Πρακτορείο:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(16, 25)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(258, 16)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Επιλογή Πρακτορείου - Συμβολαίου:"
        '
        'PeriodoiPnl
        '
        Me.PeriodoiPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PeriodoiPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PeriodoiPnl.Location = New System.Drawing.Point(16, 140)
        Me.PeriodoiPnl.Name = "PeriodoiPnl"
        Me.PeriodoiPnl.Size = New System.Drawing.Size(739, 10)
        Me.PeriodoiPnl.TabIndex = 15
        '
        'SimbolaioPnl
        '
        Me.SimbolaioPnl.BackColor = System.Drawing.Color.LightGray
        Me.SimbolaioPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SimbolaioPnl.Controls.Add(Me.RadioButton1)
        Me.SimbolaioPnl.Controls.Add(Me.PraktoreioTbx)
        Me.SimbolaioPnl.Controls.Add(Me.Label22)
        Me.SimbolaioPnl.Controls.Add(Me.SimbolaioTbx)
        Me.SimbolaioPnl.Controls.Add(Me.Label21)
        Me.SimbolaioPnl.Controls.Add(Me.NameLbl)
        Me.SimbolaioPnl.Controls.Add(Me.Label20)
        Me.SimbolaioPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimbolaioPnl.Location = New System.Drawing.Point(20, 362)
        Me.SimbolaioPnl.Name = "SimbolaioPnl"
        Me.SimbolaioPnl.Size = New System.Drawing.Size(743, 14)
        Me.SimbolaioPnl.TabIndex = 44
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(534, 22)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(102, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'PraktoreioTbx
        '
        Me.PraktoreioTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktoreioTbx.ForeColor = System.Drawing.Color.Maroon
        Me.PraktoreioTbx.Location = New System.Drawing.Point(143, 50)
        Me.PraktoreioTbx.Name = "PraktoreioTbx"
        Me.PraktoreioTbx.ReadOnly = True
        Me.PraktoreioTbx.Size = New System.Drawing.Size(273, 20)
        Me.PraktoreioTbx.TabIndex = 6
        Me.PraktoreioTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(46, 136)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Συμβόλαιο:"
        '
        'SimbolaioTbx
        '
        Me.SimbolaioTbx.ForeColor = System.Drawing.Color.Maroon
        Me.SimbolaioTbx.Location = New System.Drawing.Point(143, 133)
        Me.SimbolaioTbx.MaxLength = 49
        Me.SimbolaioTbx.Name = "SimbolaioTbx"
        Me.SimbolaioTbx.Size = New System.Drawing.Size(273, 20)
        Me.SimbolaioTbx.TabIndex = 4
        Me.SimbolaioTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 91)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 13)
        Me.Label21.TabIndex = 3
        Me.Label21.Text = "Α/Α Συμβολαίου->"
        '
        'NameLbl
        '
        Me.NameLbl.AutoSize = True
        Me.NameLbl.Location = New System.Drawing.Point(39, 53)
        Me.NameLbl.Name = "NameLbl"
        Me.NameLbl.Size = New System.Drawing.Size(79, 13)
        Me.NameLbl.TabIndex = 2
        Me.NameLbl.Text = "Πρακτορείο:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(17, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(258, 16)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Επιλογή Πρακτορείου - Συμβολαίου:"
        '
        'PraktoreiaPnl
        '
        Me.PraktoreiaPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PraktoreiaPnl.Controls.Add(Me.PraktoreiaDataGridView)
        Me.PraktoreiaPnl.Controls.Add(Me.BindingNavigator5)
        Me.PraktoreiaPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PraktoreiaPnl.Location = New System.Drawing.Point(121, 399)
        Me.PraktoreiaPnl.Name = "PraktoreiaPnl"
        Me.PraktoreiaPnl.Size = New System.Drawing.Size(526, 74)
        Me.PraktoreiaPnl.TabIndex = 42
        '
        'PraktoreiaDataGridView
        '
        Me.PraktoreiaDataGridView.AutoGenerateColumns = False
        Me.PraktoreiaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KwdDataGridViewTextBoxColumn2, Me.eponimia})
        Me.PraktoreiaDataGridView.DataSource = Me.PraktoreiaBindingSource
        Me.PraktoreiaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PraktoreiaDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PraktoreiaDataGridView.Name = "PraktoreiaDataGridView"
        Me.PraktoreiaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PraktoreiaDataGridView.Size = New System.Drawing.Size(526, 49)
        Me.PraktoreiaDataGridView.TabIndex = 0
        '
        'KwdDataGridViewTextBoxColumn2
        '
        Me.KwdDataGridViewTextBoxColumn2.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn2.HeaderText = "ΚΩΔ."
        Me.KwdDataGridViewTextBoxColumn2.Name = "KwdDataGridViewTextBoxColumn2"
        '
        'eponimia
        '
        Me.eponimia.DataPropertyName = "eponimia"
        Me.eponimia.HeaderText = "ΕΠΩΝΥΜΙΑ"
        Me.eponimia.MaxInputLength = 40
        Me.eponimia.Name = "eponimia"
        Me.eponimia.Width = 350
        '
        'PraktoreiaBindingSource
        '
        Me.PraktoreiaBindingSource.DataMember = "praktoreia"
        Me.PraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BindingNavigator5
        '
        Me.BindingNavigator5.AddNewItem = Me.ToolStripButton22
        Me.BindingNavigator5.BindingSource = Me.PraktoreiaBindingSource
        Me.BindingNavigator5.CountItem = Me.ToolStripLabel4
        Me.BindingNavigator5.DeleteItem = Me.ToolStripButton23
        Me.BindingNavigator5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton24, Me.ToolStripButton25, Me.ToolStripSeparator10, Me.ToolStripTextBox4, Me.ToolStripLabel4, Me.ToolStripSeparator11, Me.ToolStripButton26, Me.ToolStripButton27, Me.ToolStripSeparator12, Me.ToolStripButton22, Me.ToolStripButton23, Me.ToolStripButton28})
        Me.BindingNavigator5.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator5.MoveFirstItem = Me.ToolStripButton24
        Me.BindingNavigator5.MoveLastItem = Me.ToolStripButton27
        Me.BindingNavigator5.MoveNextItem = Me.ToolStripButton26
        Me.BindingNavigator5.MovePreviousItem = Me.ToolStripButton25
        Me.BindingNavigator5.Name = "BindingNavigator5"
        Me.BindingNavigator5.PositionItem = Me.ToolStripTextBox4
        Me.BindingNavigator5.Size = New System.Drawing.Size(526, 25)
        Me.BindingNavigator5.TabIndex = 1
        Me.BindingNavigator5.Text = "BindingNavigator5"
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"), System.Drawing.Image)
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton22.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton22.Text = "Add new"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel4.Text = "of {0}"
        Me.ToolStripLabel4.ToolTipText = "Total number of items"
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton23.Image = CType(resources.GetObject("ToolStripButton23.Image"), System.Drawing.Image)
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton23.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton23.Text = "Delete"
        '
        'ToolStripButton24
        '
        Me.ToolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton24.Image = CType(resources.GetObject("ToolStripButton24.Image"), System.Drawing.Image)
        Me.ToolStripButton24.Name = "ToolStripButton24"
        Me.ToolStripButton24.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton24.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton24.Text = "Move first"
        '
        'ToolStripButton25
        '
        Me.ToolStripButton25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton25.Image = CType(resources.GetObject("ToolStripButton25.Image"), System.Drawing.Image)
        Me.ToolStripButton25.Name = "ToolStripButton25"
        Me.ToolStripButton25.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton25.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton25.Text = "Move previous"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox4
        '
        Me.ToolStripTextBox4.AccessibleName = "Position"
        Me.ToolStripTextBox4.AutoSize = False
        Me.ToolStripTextBox4.Name = "ToolStripTextBox4"
        Me.ToolStripTextBox4.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox4.Text = "0"
        Me.ToolStripTextBox4.ToolTipText = "Current position"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton26.Image = CType(resources.GetObject("ToolStripButton26.Image"), System.Drawing.Image)
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton26.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton26.Text = "Move next"
        '
        'ToolStripButton27
        '
        Me.ToolStripButton27.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton27.Image = CType(resources.GetObject("ToolStripButton27.Image"), System.Drawing.Image)
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton27.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton27.Text = "Move last"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"), System.Drawing.Image)
        Me.ToolStripButton28.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton28.Text = "&Save"
        '
        'EktTimokPnl
        '
        Me.EktTimokPnl.Controls.Add(Me.Panel4)
        Me.EktTimokPnl.Location = New System.Drawing.Point(613, 534)
        Me.EktTimokPnl.Name = "EktTimokPnl"
        Me.EktTimokPnl.Size = New System.Drawing.Size(49, 224)
        Me.EktTimokPnl.TabIndex = 41
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label75)
        Me.Panel4.Controls.Add(Me.EktTimokTbx)
        Me.Panel4.Controls.Add(Me.Label76)
        Me.Panel4.Controls.Add(Me.EktTimokBtn)
        Me.Panel4.Controls.Add(Me.Label77)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel4.Location = New System.Drawing.Point(33, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(687, 155)
        Me.Panel4.TabIndex = 33
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label75.Location = New System.Drawing.Point(192, 63)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(269, 16)
        Me.Label75.TabIndex = 12
        Me.Label75.Text = "(κενό για εκτύπωση όλων των Πρακτορείων)"
        '
        'EktTimokTbx
        '
        Me.EktTimokTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EktTimokTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EktTimokTbx.Location = New System.Drawing.Point(248, 41)
        Me.EktTimokTbx.Name = "EktTimokTbx"
        Me.EktTimokTbx.ReadOnly = True
        Me.EktTimokTbx.Size = New System.Drawing.Size(160, 22)
        Me.EktTimokTbx.TabIndex = 11
        Me.EktTimokTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(144, 44)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(95, 16)
        Me.Label76.TabIndex = 10
        Me.Label76.Text = "Πρακτορείο:"
        '
        'EktTimokBtn
        '
        Me.EktTimokBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktTimokBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktTimokBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EktTimokBtn.Location = New System.Drawing.Point(241, 103)
        Me.EktTimokBtn.Name = "EktTimokBtn"
        Me.EktTimokBtn.Size = New System.Drawing.Size(180, 23)
        Me.EktTimokBtn.TabIndex = 9
        Me.EktTimokBtn.Text = "Προεπισκόπηση"
        Me.EktTimokBtn.UseVisualStyleBackColor = True
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label77.ForeColor = System.Drawing.Color.Maroon
        Me.Label77.Location = New System.Drawing.Point(7, 11)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(160, 16)
        Me.Label77.TabIndex = 0
        Me.Label77.Text = "Επιλογή Πρακτορείου"
        '
        'EktBookPnl
        '
        Me.EktBookPnl.Controls.Add(Me.EktBook2Pnl)
        Me.EktBookPnl.Location = New System.Drawing.Point(748, 526)
        Me.EktBookPnl.Name = "EktBookPnl"
        Me.EktBookPnl.Size = New System.Drawing.Size(76, 209)
        Me.EktBookPnl.TabIndex = 40
        '
        'EktBook2Pnl
        '
        Me.EktBook2Pnl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.EktBook2Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EktBook2Pnl.Controls.Add(Me.Label72)
        Me.EktBook2Pnl.Controls.Add(Me.EktBookTbx)
        Me.EktBook2Pnl.Controls.Add(Me.Label73)
        Me.EktBook2Pnl.Controls.Add(Me.EktBookBtn)
        Me.EktBook2Pnl.Controls.Add(Me.Label74)
        Me.EktBook2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EktBook2Pnl.Location = New System.Drawing.Point(33, 28)
        Me.EktBook2Pnl.Name = "EktBook2Pnl"
        Me.EktBook2Pnl.Size = New System.Drawing.Size(687, 155)
        Me.EktBook2Pnl.TabIndex = 33
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label72.Location = New System.Drawing.Point(192, 63)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(269, 16)
        Me.Label72.TabIndex = 12
        Me.Label72.Text = "(κενό για εκτύπωση όλων των Πρακτορείων)"
        '
        'EktBookTbx
        '
        Me.EktBookTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EktBookTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EktBookTbx.Location = New System.Drawing.Point(248, 41)
        Me.EktBookTbx.Name = "EktBookTbx"
        Me.EktBookTbx.ReadOnly = True
        Me.EktBookTbx.Size = New System.Drawing.Size(160, 22)
        Me.EktBookTbx.TabIndex = 11
        Me.EktBookTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(144, 44)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(95, 16)
        Me.Label73.TabIndex = 10
        Me.Label73.Text = "Πρακτορείο:"
        '
        'EktBookBtn
        '
        Me.EktBookBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktBookBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktBookBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EktBookBtn.Location = New System.Drawing.Point(241, 103)
        Me.EktBookBtn.Name = "EktBookBtn"
        Me.EktBookBtn.Size = New System.Drawing.Size(180, 23)
        Me.EktBookBtn.TabIndex = 9
        Me.EktBookBtn.Text = "Προεπισκόπηση"
        Me.EktBookBtn.UseVisualStyleBackColor = True
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label74.ForeColor = System.Drawing.Color.Maroon
        Me.Label74.Location = New System.Drawing.Point(7, 11)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(160, 16)
        Me.Label74.TabIndex = 0
        Me.Label74.Text = "Επιλογή Πρακτορείου"
        '
        'EktAllotmentPnl
        '
        Me.EktAllotmentPnl.Controls.Add(Me.EktAllotment1Pnl)
        Me.EktAllotmentPnl.Location = New System.Drawing.Point(673, 529)
        Me.EktAllotmentPnl.Name = "EktAllotmentPnl"
        Me.EktAllotmentPnl.Size = New System.Drawing.Size(50, 209)
        Me.EktAllotmentPnl.TabIndex = 39
        '
        'EktAllotment1Pnl
        '
        Me.EktAllotment1Pnl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.EktAllotment1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EktAllotment1Pnl.Controls.Add(Me.Label71)
        Me.EktAllotment1Pnl.Controls.Add(Me.EktAllotmentTbx)
        Me.EktAllotment1Pnl.Controls.Add(Me.Label69)
        Me.EktAllotment1Pnl.Controls.Add(Me.EktAllotment1Btn)
        Me.EktAllotment1Pnl.Controls.Add(Me.Label70)
        Me.EktAllotment1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EktAllotment1Pnl.Location = New System.Drawing.Point(33, 28)
        Me.EktAllotment1Pnl.Name = "EktAllotment1Pnl"
        Me.EktAllotment1Pnl.Size = New System.Drawing.Size(687, 155)
        Me.EktAllotment1Pnl.TabIndex = 33
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label71.Location = New System.Drawing.Point(192, 63)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(269, 16)
        Me.Label71.TabIndex = 12
        Me.Label71.Text = "(κενό για εκτύπωση όλων των Πρακτορείων)"
        '
        'EktAllotmentTbx
        '
        Me.EktAllotmentTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EktAllotmentTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EktAllotmentTbx.Location = New System.Drawing.Point(248, 41)
        Me.EktAllotmentTbx.Name = "EktAllotmentTbx"
        Me.EktAllotmentTbx.ReadOnly = True
        Me.EktAllotmentTbx.Size = New System.Drawing.Size(160, 22)
        Me.EktAllotmentTbx.TabIndex = 11
        Me.EktAllotmentTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(144, 44)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(95, 16)
        Me.Label69.TabIndex = 10
        Me.Label69.Text = "Πρακτορείο:"
        '
        'EktAllotment1Btn
        '
        Me.EktAllotment1Btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EktAllotment1Btn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EktAllotment1Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EktAllotment1Btn.Location = New System.Drawing.Point(241, 103)
        Me.EktAllotment1Btn.Name = "EktAllotment1Btn"
        Me.EktAllotment1Btn.Size = New System.Drawing.Size(180, 23)
        Me.EktAllotment1Btn.TabIndex = 9
        Me.EktAllotment1Btn.Text = "Προεπισκόπηση"
        Me.EktAllotment1Btn.UseVisualStyleBackColor = True
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Maroon
        Me.Label70.Location = New System.Drawing.Point(7, 11)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(160, 16)
        Me.Label70.TabIndex = 0
        Me.Label70.Text = "Επιλογή Πρακτορείου"
        '
        'EuretirioPeriodoiPnl
        '
        Me.EuretirioPeriodoiPnl.Controls.Add(Me.PeriodoiDtGrd)
        Me.EuretirioPeriodoiPnl.Controls.Add(Me.PinakasDwm1Pnl)
        Me.EuretirioPeriodoiPnl.Location = New System.Drawing.Point(781, 301)
        Me.EuretirioPeriodoiPnl.Name = "EuretirioPeriodoiPnl"
        Me.EuretirioPeriodoiPnl.Size = New System.Drawing.Size(14, 209)
        Me.EuretirioPeriodoiPnl.TabIndex = 38
        '
        'PeriodoiDtGrd
        '
        Me.PeriodoiDtGrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PeriodoiDtGrd.Location = New System.Drawing.Point(607, 204)
        Me.PeriodoiDtGrd.Name = "PeriodoiDtGrd"
        Me.PeriodoiDtGrd.Size = New System.Drawing.Size(46, 87)
        Me.PeriodoiDtGrd.TabIndex = 33
        Me.PeriodoiDtGrd.Visible = False
        '
        'PinakasDwm1Pnl
        '
        Me.PinakasDwm1Pnl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PinakasDwm1Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PinakasDwm1Pnl.Controls.Add(Me.Label68)
        Me.PinakasDwm1Pnl.Controls.Add(Me.OrderKwdRdb)
        Me.PinakasDwm1Pnl.Controls.Add(Me.OrderPraktRdb)
        Me.PinakasDwm1Pnl.Controls.Add(Me.EuretirioPeriodoiBtn)
        Me.PinakasDwm1Pnl.Controls.Add(Me.Label88)
        Me.PinakasDwm1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PinakasDwm1Pnl.Location = New System.Drawing.Point(11, 26)
        Me.PinakasDwm1Pnl.Name = "PinakasDwm1Pnl"
        Me.PinakasDwm1Pnl.Size = New System.Drawing.Size(687, 155)
        Me.PinakasDwm1Pnl.TabIndex = 32
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label68.Location = New System.Drawing.Point(234, 37)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(125, 16)
        Me.Label68.TabIndex = 22
        Me.Label68.Text = "Ταξινόμηση κατά"
        '
        'OrderKwdRdb
        '
        Me.OrderKwdRdb.AutoSize = True
        Me.OrderKwdRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OrderKwdRdb.Location = New System.Drawing.Point(343, 60)
        Me.OrderKwdRdb.Name = "OrderKwdRdb"
        Me.OrderKwdRdb.Size = New System.Drawing.Size(72, 20)
        Me.OrderKwdRdb.TabIndex = 21
        Me.OrderKwdRdb.Text = "κωδικό"
        Me.OrderKwdRdb.UseVisualStyleBackColor = True
        '
        'OrderPraktRdb
        '
        Me.OrderPraktRdb.AutoSize = True
        Me.OrderPraktRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OrderPraktRdb.Checked = True
        Me.OrderPraktRdb.Location = New System.Drawing.Point(208, 60)
        Me.OrderPraktRdb.Name = "OrderPraktRdb"
        Me.OrderPraktRdb.Size = New System.Drawing.Size(105, 20)
        Me.OrderPraktRdb.TabIndex = 20
        Me.OrderPraktRdb.TabStop = True
        Me.OrderPraktRdb.Text = "αλφαβητικά"
        Me.OrderPraktRdb.UseVisualStyleBackColor = True
        '
        'EuretirioPeriodoiBtn
        '
        Me.EuretirioPeriodoiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EuretirioPeriodoiBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EuretirioPeriodoiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EuretirioPeriodoiBtn.Location = New System.Drawing.Point(237, 109)
        Me.EuretirioPeriodoiBtn.Name = "EuretirioPeriodoiBtn"
        Me.EuretirioPeriodoiBtn.Size = New System.Drawing.Size(180, 23)
        Me.EuretirioPeriodoiBtn.TabIndex = 9
        Me.EuretirioPeriodoiBtn.Text = "Προεπισκόπηση"
        Me.EuretirioPeriodoiBtn.UseVisualStyleBackColor = True
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label88.ForeColor = System.Drawing.Color.Maroon
        Me.Label88.Location = New System.Drawing.Point(7, 11)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(243, 16)
        Me.Label88.TabIndex = 0
        Me.Label88.Text = "Κατάσταση Τουριστικών Περιόδων"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(743, 597)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(91, 93)
        Me.CrystalReportViewer1.TabIndex = 37
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'SimfoniesPnl
        '
        Me.SimfoniesPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimfoniesPnl.Controls.Add(Me.TimiAtomoPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfTipoiXrewsPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfPososPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfPaidiaPnl)
        Me.SimfoniesPnl.Controls.Add(Me.Label44)
        Me.SimfoniesPnl.Controls.Add(Me.SimfAAPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfPnlPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfParamPnl)
        Me.SimfoniesPnl.Controls.Add(Me.Label43)
        Me.SimfoniesPnl.Controls.Add(Me.SimfSimbAAPnl)
        Me.SimfoniesPnl.Controls.Add(Me.SimfPraktTbx)
        Me.SimfoniesPnl.Controls.Add(Me.Label45)
        Me.SimfoniesPnl.Controls.Add(Me.Label46)
        Me.SimfoniesPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimfoniesPnl.Location = New System.Drawing.Point(13, 120)
        Me.SimfoniesPnl.Name = "SimfoniesPnl"
        Me.SimfoniesPnl.Size = New System.Drawing.Size(802, 11)
        Me.SimfoniesPnl.TabIndex = 36
        '
        'TimiAtomoPnl
        '
        Me.TimiAtomoPnl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TimiAtomoPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimiAtomoPnl.Controls.Add(Me.TimiAtomoTbx)
        Me.TimiAtomoPnl.Controls.Add(Me.Label34)
        Me.TimiAtomoPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TimiAtomoPnl.Location = New System.Drawing.Point(586, 354)
        Me.TimiAtomoPnl.Name = "TimiAtomoPnl"
        Me.TimiAtomoPnl.Size = New System.Drawing.Size(211, 35)
        Me.TimiAtomoPnl.TabIndex = 29
        '
        'TimiAtomoTbx
        '
        Me.TimiAtomoTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimiAtomoTbx.ForeColor = System.Drawing.Color.Maroon
        Me.TimiAtomoTbx.Location = New System.Drawing.Point(143, 5)
        Me.TimiAtomoTbx.MaxLength = 6
        Me.TimiAtomoTbx.Name = "TimiAtomoTbx"
        Me.TimiAtomoTbx.Size = New System.Drawing.Size(62, 22)
        Me.TimiAtomoTbx.TabIndex = 23
        Me.TimiAtomoTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(4, 8)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(142, 16)
        Me.Label34.TabIndex = 22
        Me.Label34.Text = "TIMH ANA ATOMO:"
        '
        'SimfTipoiXrewsPnl
        '
        Me.SimfTipoiXrewsPnl.AutoScroll = True
        Me.SimfTipoiXrewsPnl.BackColor = System.Drawing.Color.Silver
        Me.SimfTipoiXrewsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimfTipoiXrewsPnl.Location = New System.Drawing.Point(12, 354)
        Me.SimfTipoiXrewsPnl.Name = "SimfTipoiXrewsPnl"
        Me.SimfTipoiXrewsPnl.Size = New System.Drawing.Size(572, 35)
        Me.SimfTipoiXrewsPnl.TabIndex = 27
        Me.SimfTipoiXrewsPnl.TabStop = True
        '
        'SimfPososPnl
        '
        Me.SimfPososPnl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SimfPososPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimfPososPnl.Controls.Add(Me.TimesCBoxenPnl)
        Me.SimfPososPnl.Controls.Add(Me.DeipnTbx)
        Me.SimfPososPnl.Controls.Add(Me.GeumTbx)
        Me.SimfPososPnl.Controls.Add(Me.PrwinTbx)
        Me.SimfPososPnl.Controls.Add(Me.Label67)
        Me.SimfPososPnl.Controls.Add(Me.Label66)
        Me.SimfPososPnl.Controls.Add(Me.Label65)
        Me.SimfPososPnl.Location = New System.Drawing.Point(520, 203)
        Me.SimfPososPnl.Name = "SimfPososPnl"
        Me.SimfPososPnl.Size = New System.Drawing.Size(277, 148)
        Me.SimfPososPnl.TabIndex = 21
        '
        'TimesCBoxenPnl
        '
        Me.TimesCBoxenPnl.Controls.Add(Me.TipoiXrewsisPnl)
        Me.TimesCBoxenPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TimesCBoxenPnl.ForeColor = System.Drawing.Color.Black
        Me.TimesCBoxenPnl.Location = New System.Drawing.Point(143, 0)
        Me.TimesCBoxenPnl.Name = "TimesCBoxenPnl"
        Me.TimesCBoxenPnl.Size = New System.Drawing.Size(128, 147)
        Me.TimesCBoxenPnl.TabIndex = 24
        '
        'TipoiXrewsisPnl
        '
        Me.TipoiXrewsisPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TipoiXrewsisPnl.Controls.Add(Me.TXrewsisDataGridView)
        Me.TipoiXrewsisPnl.Controls.Add(Me.BindingNavigator4)
        Me.TipoiXrewsisPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TipoiXrewsisPnl.Location = New System.Drawing.Point(67, 26)
        Me.TipoiXrewsisPnl.Name = "TipoiXrewsisPnl"
        Me.TipoiXrewsisPnl.Size = New System.Drawing.Size(61, 149)
        Me.TipoiXrewsisPnl.TabIndex = 43
        '
        'TXrewsisDataGridView
        '
        Me.TXrewsisDataGridView.AutoGenerateColumns = False
        Me.TXrewsisDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KwdDataGridViewTextBoxColumn1, Me.xrewsi, Me.perigrafi, Me.ypnos, Me.prwino, Me.geuma, Me.deipno})
        Me.TXrewsisDataGridView.DataSource = Me.XrewseisBindingSource
        Me.TXrewsisDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXrewsisDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.TXrewsisDataGridView.Name = "TXrewsisDataGridView"
        Me.TXrewsisDataGridView.Size = New System.Drawing.Size(61, 124)
        Me.TXrewsisDataGridView.TabIndex = 0
        '
        'KwdDataGridViewTextBoxColumn1
        '
        Me.KwdDataGridViewTextBoxColumn1.DataPropertyName = "kwd"
        Me.KwdDataGridViewTextBoxColumn1.HeaderText = "ΚΩΔ."
        Me.KwdDataGridViewTextBoxColumn1.MaxInputLength = 0
        Me.KwdDataGridViewTextBoxColumn1.Name = "KwdDataGridViewTextBoxColumn1"
        Me.KwdDataGridViewTextBoxColumn1.Visible = False
        Me.KwdDataGridViewTextBoxColumn1.Width = 5
        '
        'xrewsi
        '
        Me.xrewsi.DataPropertyName = "xrewsi"
        Me.xrewsi.HeaderText = "ΤΥΠΟΣ ΧΡΕΩΣΗΣ"
        Me.xrewsi.MaxInputLength = 20
        Me.xrewsi.Name = "xrewsi"
        Me.xrewsi.Width = 130
        '
        'perigrafi
        '
        Me.perigrafi.DataPropertyName = "perigrafi"
        Me.perigrafi.HeaderText = "ΠΕΡΙΓΡΑΦΗ"
        Me.perigrafi.MaxInputLength = 49
        Me.perigrafi.Name = "perigrafi"
        Me.perigrafi.Width = 200
        '
        'ypnos
        '
        Me.ypnos.DataPropertyName = "ypnos"
        Me.ypnos.HeaderText = "ΥΠΝΟΣ"
        Me.ypnos.Name = "ypnos"
        Me.ypnos.Width = 80
        '
        'prwino
        '
        Me.prwino.DataPropertyName = "prwino"
        Me.prwino.HeaderText = "ΠΡΩΪΝΟ"
        Me.prwino.Name = "prwino"
        Me.prwino.Width = 80
        '
        'geuma
        '
        Me.geuma.DataPropertyName = "geuma"
        Me.geuma.HeaderText = "ΓΕΥΜΑ"
        Me.geuma.Name = "geuma"
        Me.geuma.Width = 80
        '
        'deipno
        '
        Me.deipno.DataPropertyName = "deipno"
        Me.deipno.HeaderText = "ΔΕΙΠΝΟ"
        Me.deipno.Name = "deipno"
        Me.deipno.Width = 80
        '
        'XrewseisBindingSource
        '
        Me.XrewseisBindingSource.DataMember = "xrewseis"
        Me.XrewseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'BindingNavigator4
        '
        Me.BindingNavigator4.AddNewItem = Me.ToolStripButton15
        Me.BindingNavigator4.BindingSource = Me.XrewseisBindingSource
        Me.BindingNavigator4.CountItem = Me.ToolStripLabel3
        Me.BindingNavigator4.DeleteItem = Me.ToolStripButton16
        Me.BindingNavigator4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripSeparator7, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator8, Me.ToolStripButton19, Me.ToolStripButton20, Me.ToolStripSeparator9, Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripButton21})
        Me.BindingNavigator4.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator4.MoveFirstItem = Me.ToolStripButton17
        Me.BindingNavigator4.MoveLastItem = Me.ToolStripButton20
        Me.BindingNavigator4.MoveNextItem = Me.ToolStripButton19
        Me.BindingNavigator4.MovePreviousItem = Me.ToolStripButton18
        Me.BindingNavigator4.Name = "BindingNavigator4"
        Me.BindingNavigator4.PositionItem = Me.ToolStripTextBox3
        Me.BindingNavigator4.Size = New System.Drawing.Size(61, 25)
        Me.BindingNavigator4.TabIndex = 1
        Me.BindingNavigator4.Text = "BindingNavigator4"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton15.Text = "Add new"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 15)
        Me.ToolStripLabel3.Text = "of {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton16.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton16.Text = "Delete"
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"), System.Drawing.Image)
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton17.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton17.Text = "Move first"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton18.Text = "Move previous"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Position"
        Me.ToolStripTextBox3.AutoSize = False
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.ToolTipText = "Current position"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton19.Image = CType(resources.GetObject("ToolStripButton19.Image"), System.Drawing.Image)
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton19.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton19.Text = "Move next"
        '
        'ToolStripButton20
        '
        Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton20.Image = CType(resources.GetObject("ToolStripButton20.Image"), System.Drawing.Image)
        Me.ToolStripButton20.Name = "ToolStripButton20"
        Me.ToolStripButton20.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton20.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton20.Text = "Move last"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"), System.Drawing.Image)
        Me.ToolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton21.Text = "&Save"
        '
        'DeipnTbx
        '
        Me.DeipnTbx.ForeColor = System.Drawing.Color.Maroon
        Me.DeipnTbx.Location = New System.Drawing.Point(68, 93)
        Me.DeipnTbx.MaxLength = 6
        Me.DeipnTbx.Name = "DeipnTbx"
        Me.DeipnTbx.Size = New System.Drawing.Size(72, 20)
        Me.DeipnTbx.TabIndex = 23
        Me.DeipnTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GeumTbx
        '
        Me.GeumTbx.ForeColor = System.Drawing.Color.Maroon
        Me.GeumTbx.Location = New System.Drawing.Point(67, 60)
        Me.GeumTbx.MaxLength = 6
        Me.GeumTbx.Name = "GeumTbx"
        Me.GeumTbx.Size = New System.Drawing.Size(72, 20)
        Me.GeumTbx.TabIndex = 22
        Me.GeumTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrwinTbx
        '
        Me.PrwinTbx.ForeColor = System.Drawing.Color.Maroon
        Me.PrwinTbx.Location = New System.Drawing.Point(67, 29)
        Me.PrwinTbx.MaxLength = 6
        Me.PrwinTbx.Name = "PrwinTbx"
        Me.PrwinTbx.Size = New System.Drawing.Size(72, 20)
        Me.PrwinTbx.TabIndex = 21
        Me.PrwinTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.ForeColor = System.Drawing.Color.Blue
        Me.Label67.Location = New System.Drawing.Point(10, 96)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(51, 13)
        Me.Label67.TabIndex = 20
        Me.Label67.Text = "Δείπνο:"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.ForeColor = System.Drawing.Color.Blue
        Me.Label66.Location = New System.Drawing.Point(10, 63)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(47, 13)
        Me.Label66.TabIndex = 19
        Me.Label66.Text = "Γεύμα:"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.ForeColor = System.Drawing.Color.Blue
        Me.Label65.Location = New System.Drawing.Point(10, 32)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(54, 13)
        Me.Label65.TabIndex = 18
        Me.Label65.Text = "Πρωϊνό:"
        '
        'SimfPaidiaPnl
        '
        Me.SimfPaidiaPnl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SimfPaidiaPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox23)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label61)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label62)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox24)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label63)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label64)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox25)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox20)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label57)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label58)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox21)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label59)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label60)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox22)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox17)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label53)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label54)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox18)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label55)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label56)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox19)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox16)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label52)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label51)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox15)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label50)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label49)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox14)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label48)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox13)
        Me.SimfPaidiaPnl.Controls.Add(Me.Label47)
        Me.SimfPaidiaPnl.Controls.Add(Me.TextBox10)
        Me.SimfPaidiaPnl.Location = New System.Drawing.Point(12, 203)
        Me.SimfPaidiaPnl.Name = "SimfPaidiaPnl"
        Me.SimfPaidiaPnl.Size = New System.Drawing.Size(518, 148)
        Me.SimfPaidiaPnl.TabIndex = 20
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(451, 122)
        Me.TextBox23.MaxLength = 2
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(43, 20)
        Me.TextBox23.TabIndex = 39
        Me.TextBox23.Text = "0"
        Me.TextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(366, 125)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(79, 13)
        Me.Label61.TabIndex = 38
        Me.Label61.Text = " έκπτωση(%)"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(277, 125)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(34, 13)
        Me.Label62.TabIndex = 37
        Me.Label62.Text = " έως"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(317, 121)
        Me.TextBox24.MaxLength = 2
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(43, 20)
        Me.TextBox24.TabIndex = 36
        Me.TextBox24.Text = "0"
        Me.TextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(238, 125)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(33, 13)
        Me.Label63.TabIndex = 35
        Me.Label63.Text = "free,"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(14, 126)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(156, 13)
        Me.Label64.TabIndex = 34
        Me.Label64.Text = "2 Παιδιά το Δεύτερο έως"
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(186, 123)
        Me.TextBox25.MaxLength = 2
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(43, 20)
        Me.TextBox25.TabIndex = 33
        Me.TextBox25.Text = "0"
        Me.TextBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(451, 93)
        Me.TextBox20.MaxLength = 2
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(43, 20)
        Me.TextBox20.TabIndex = 32
        Me.TextBox20.Text = "0"
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(366, 96)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(79, 13)
        Me.Label57.TabIndex = 31
        Me.Label57.Text = " έκπτωση(%)"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(277, 96)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(34, 13)
        Me.Label58.TabIndex = 30
        Me.Label58.Text = " έως"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(317, 92)
        Me.TextBox21.MaxLength = 2
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(43, 20)
        Me.TextBox21.TabIndex = 29
        Me.TextBox21.Text = "0"
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(238, 96)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(33, 13)
        Me.Label59.TabIndex = 28
        Me.Label59.Text = "free,"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(27, 97)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(144, 13)
        Me.Label60.TabIndex = 27
        Me.Label60.Text = "2 Παιδιά το Πρώτο έως"
        '
        'TextBox22
        '
        Me.TextBox22.Location = New System.Drawing.Point(186, 94)
        Me.TextBox22.MaxLength = 2
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(43, 20)
        Me.TextBox22.TabIndex = 26
        Me.TextBox22.Text = "0"
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(451, 66)
        Me.TextBox17.MaxLength = 2
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(43, 20)
        Me.TextBox17.TabIndex = 25
        Me.TextBox17.Text = "0"
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(366, 69)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(79, 13)
        Me.Label53.TabIndex = 24
        Me.Label53.Text = " έκπτωση(%)"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(277, 69)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(34, 13)
        Me.Label54.TabIndex = 23
        Me.Label54.Text = " έως"
        '
        'TextBox18
        '
        Me.TextBox18.Location = New System.Drawing.Point(317, 65)
        Me.TextBox18.MaxLength = 2
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(43, 20)
        Me.TextBox18.TabIndex = 22
        Me.TextBox18.Text = "0"
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(238, 69)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(33, 13)
        Me.Label55.TabIndex = 21
        Me.Label55.Text = "free,"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(42, 71)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(130, 13)
        Me.Label56.TabIndex = 20
        Me.Label56.Text = "Παιδί σε Δίκλινο έως"
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(186, 67)
        Me.TextBox19.MaxLength = 2
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(43, 20)
        Me.TextBox19.TabIndex = 19
        Me.TextBox19.Text = "0"
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(451, 38)
        Me.TextBox16.MaxLength = 2
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(43, 20)
        Me.TextBox16.TabIndex = 18
        Me.TextBox16.Text = "0"
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(366, 41)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(79, 13)
        Me.Label52.TabIndex = 17
        Me.Label52.Text = " έκπτωση(%)"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(277, 41)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(34, 13)
        Me.Label51.TabIndex = 16
        Me.Label51.Text = " έως"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(317, 37)
        Me.TextBox15.MaxLength = 2
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(43, 20)
        Me.TextBox15.TabIndex = 15
        Me.TextBox15.Text = "0"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(238, 41)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(33, 13)
        Me.Label50.TabIndex = 14
        Me.Label50.Text = "free,"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(28, 43)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(148, 13)
        Me.Label49.TabIndex = 13
        Me.Label49.Text = "Παιδί σε Μονόκλινο έως"
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(186, 39)
        Me.TextBox14.MaxLength = 2
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(43, 20)
        Me.TextBox14.TabIndex = 12
        Me.TextBox14.Text = "0"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(279, 15)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(166, 13)
        Me.Label48.TabIndex = 11
        Me.Label48.Text = "Έκπτωση για 3ο Άτομο (%):"
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(451, 12)
        Me.TextBox13.MaxLength = 2
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(43, 20)
        Me.TextBox13.TabIndex = 10
        Me.TextBox13.Text = "0"
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(9, 15)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(176, 13)
        Me.Label47.TabIndex = 9
        Me.Label47.Text = "Προσαύξηση Μονόκλινου (%):"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(186, 12)
        Me.TextBox10.MaxLength = 2
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(43, 20)
        Me.TextBox10.TabIndex = 0
        Me.TextBox10.Text = "0"
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.Blue
        Me.Label44.Location = New System.Drawing.Point(9, 150)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(255, 13)
        Me.Label44.TabIndex = 19
        Me.Label44.Text = "επιλογή αύξωντα Αριθμού Τιμοκαταλόγου:"
        '
        'SimfAAPnl
        '
        Me.SimfAAPnl.AutoScroll = True
        Me.SimfAAPnl.BackColor = System.Drawing.Color.Silver
        Me.SimfAAPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SimfAAPnl.Location = New System.Drawing.Point(12, 167)
        Me.SimfAAPnl.Name = "SimfAAPnl"
        Me.SimfAAPnl.Size = New System.Drawing.Size(785, 32)
        Me.SimfAAPnl.TabIndex = 18
        '
        'SimfPnlPnl
        '
        Me.SimfPnlPnl.AutoScroll = True
        Me.SimfPnlPnl.BackColor = System.Drawing.SystemColors.Control
        Me.SimfPnlPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SimfPnlPnl.Controls.Add(Me.InfSinfLbl)
        Me.SimfPnlPnl.Controls.Add(Me.AddTimesBtn)
        Me.SimfPnlPnl.Location = New System.Drawing.Point(12, 391)
        Me.SimfPnlPnl.Name = "SimfPnlPnl"
        Me.SimfPnlPnl.Size = New System.Drawing.Size(785, 243)
        Me.SimfPnlPnl.TabIndex = 32
        '
        'InfSinfLbl
        '
        Me.InfSinfLbl.Location = New System.Drawing.Point(278, 29)
        Me.InfSinfLbl.Name = "InfSinfLbl"
        Me.InfSinfLbl.Size = New System.Drawing.Size(45, 13)
        Me.InfSinfLbl.TabIndex = 1
        Me.InfSinfLbl.Text = "Label38"
        '
        'AddTimesBtn
        '
        Me.AddTimesBtn.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.AddTimesBtn.Cursor = System.Windows.Forms.Cursors.PanEast
        Me.AddTimesBtn.ForeColor = System.Drawing.Color.Maroon
        Me.AddTimesBtn.Image = Global.winhotel.My.Resources.Resources._NEXT
        Me.AddTimesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddTimesBtn.Location = New System.Drawing.Point(233, 63)
        Me.AddTimesBtn.Name = "AddTimesBtn"
        Me.AddTimesBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddTimesBtn.Size = New System.Drawing.Size(38, 145)
        Me.AddTimesBtn.TabIndex = 0
        Me.AddTimesBtn.Text = "ΑΠΟΘΗΚΕΥΣΗ  "
        Me.AddTimesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.AddTimesBtn.UseVisualStyleBackColor = False
        '
        'SimfParamPnl
        '
        Me.SimfParamPnl.BackColor = System.Drawing.SystemColors.Control
        Me.SimfParamPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SimfParamPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimfParamPnl.Location = New System.Drawing.Point(12, 67)
        Me.SimfParamPnl.Name = "SimfParamPnl"
        Me.SimfParamPnl.Size = New System.Drawing.Size(785, 80)
        Me.SimfParamPnl.TabIndex = 16
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(333, 13)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(105, 13)
        Me.Label43.TabIndex = 13
        Me.Label43.Text = "Α/Α Συμβολαίου:"
        '
        'SimfSimbAAPnl
        '
        Me.SimfSimbAAPnl.AutoScroll = True
        Me.SimfSimbAAPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SimfSimbAAPnl.Location = New System.Drawing.Point(336, 33)
        Me.SimfSimbAAPnl.Name = "SimfSimbAAPnl"
        Me.SimfSimbAAPnl.Size = New System.Drawing.Size(461, 28)
        Me.SimfSimbAAPnl.TabIndex = 12
        '
        'SimfPraktTbx
        '
        Me.SimfPraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SimfPraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.SimfPraktTbx.Location = New System.Drawing.Point(95, 32)
        Me.SimfPraktTbx.Name = "SimfPraktTbx"
        Me.SimfPraktTbx.ReadOnly = True
        Me.SimfPraktTbx.Size = New System.Drawing.Size(200, 20)
        Me.SimfPraktTbx.TabIndex = 2
        Me.SimfPraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(3, 35)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(79, 13)
        Me.Label45.TabIndex = 1
        Me.Label45.Text = "Πρακτορείο:"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Blue
        Me.Label46.Location = New System.Drawing.Point(16, 6)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(296, 13)
        Me.Label46.TabIndex = 0
        Me.Label46.Text = "επιλογή Πρακτορείου - Συμβολαίου - Κατηγορίας:"
        '
        'AllotmBPnl
        '
        Me.AllotmBPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.AllotmBPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AllotmBPnl.Location = New System.Drawing.Point(32, 577)
        Me.AllotmBPnl.Name = "AllotmBPnl"
        Me.AllotmBPnl.Size = New System.Drawing.Size(326, 47)
        Me.AllotmBPnl.TabIndex = 24
        '
        'AASimbolPnl
        '
        Me.AASimbolPnl.Location = New System.Drawing.Point(43, 644)
        Me.AASimbolPnl.Name = "AASimbolPnl"
        Me.AASimbolPnl.Size = New System.Drawing.Size(400, 46)
        Me.AASimbolPnl.TabIndex = 16
        '
        'SeasonPnl
        '
        Me.SeasonPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SeasonPnl.Controls.Add(Me.SeasonsDataGridView)
        Me.SeasonPnl.Controls.Add(Me.BindingNavigator6)
        Me.SeasonPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SeasonPnl.Location = New System.Drawing.Point(703, 42)
        Me.SeasonPnl.Name = "SeasonPnl"
        Me.SeasonPnl.Size = New System.Drawing.Size(95, 95)
        Me.SeasonPnl.TabIndex = 14
        '
        'SeasonsDataGridView
        '
        Me.SeasonsDataGridView.AllowDrop = True
        Me.SeasonsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SeasonsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.SeasonsDataGridView.Name = "SeasonsDataGridView"
        Me.SeasonsDataGridView.Size = New System.Drawing.Size(95, 70)
        Me.SeasonsDataGridView.TabIndex = 0
        '
        'BindingNavigator6
        '
        Me.BindingNavigator6.AddNewItem = Me.ToolStripButton29
        Me.BindingNavigator6.CountItem = Me.ToolStripLabel5
        Me.BindingNavigator6.DeleteItem = Me.ToolStripButton30
        Me.BindingNavigator6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton31, Me.ToolStripButton32, Me.ToolStripSeparator13, Me.ToolStripTextBox5, Me.ToolStripLabel5, Me.ToolStripSeparator14, Me.ToolStripButton33, Me.ToolStripButton34, Me.ToolStripSeparator15, Me.ToolStripButton29, Me.ToolStripButton30, Me.ToolStripButton35})
        Me.BindingNavigator6.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator6.MoveFirstItem = Me.ToolStripButton31
        Me.BindingNavigator6.MoveLastItem = Me.ToolStripButton34
        Me.BindingNavigator6.MoveNextItem = Me.ToolStripButton33
        Me.BindingNavigator6.MovePreviousItem = Me.ToolStripButton32
        Me.BindingNavigator6.Name = "BindingNavigator6"
        Me.BindingNavigator6.PositionItem = Me.ToolStripTextBox5
        Me.BindingNavigator6.Size = New System.Drawing.Size(95, 25)
        Me.BindingNavigator6.TabIndex = 1
        Me.BindingNavigator6.Text = "BindingNavigator6"
        '
        'ToolStripButton29
        '
        Me.ToolStripButton29.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton29.Image = CType(resources.GetObject("ToolStripButton29.Image"), System.Drawing.Image)
        Me.ToolStripButton29.Name = "ToolStripButton29"
        Me.ToolStripButton29.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton29.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton29.Text = "Add new"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(35, 15)
        Me.ToolStripLabel5.Text = "of {0}"
        Me.ToolStripLabel5.ToolTipText = "Total number of items"
        '
        'ToolStripButton30
        '
        Me.ToolStripButton30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton30.Image = CType(resources.GetObject("ToolStripButton30.Image"), System.Drawing.Image)
        Me.ToolStripButton30.Name = "ToolStripButton30"
        Me.ToolStripButton30.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton30.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton30.Text = "Delete"
        '
        'ToolStripButton31
        '
        Me.ToolStripButton31.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton31.Image = CType(resources.GetObject("ToolStripButton31.Image"), System.Drawing.Image)
        Me.ToolStripButton31.Name = "ToolStripButton31"
        Me.ToolStripButton31.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton31.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton31.Text = "Move first"
        '
        'ToolStripButton32
        '
        Me.ToolStripButton32.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton32.Image = CType(resources.GetObject("ToolStripButton32.Image"), System.Drawing.Image)
        Me.ToolStripButton32.Name = "ToolStripButton32"
        Me.ToolStripButton32.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton32.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton32.Text = "Move previous"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox5
        '
        Me.ToolStripTextBox5.AccessibleName = "Position"
        Me.ToolStripTextBox5.AutoSize = False
        Me.ToolStripTextBox5.Name = "ToolStripTextBox5"
        Me.ToolStripTextBox5.Size = New System.Drawing.Size(50, 21)
        Me.ToolStripTextBox5.Text = "0"
        Me.ToolStripTextBox5.ToolTipText = "Current position"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton33
        '
        Me.ToolStripButton33.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton33.Image = CType(resources.GetObject("ToolStripButton33.Image"), System.Drawing.Image)
        Me.ToolStripButton33.Name = "ToolStripButton33"
        Me.ToolStripButton33.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton33.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton33.Text = "Move next"
        '
        'ToolStripButton34
        '
        Me.ToolStripButton34.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton34.Image = CType(resources.GetObject("ToolStripButton34.Image"), System.Drawing.Image)
        Me.ToolStripButton34.Name = "ToolStripButton34"
        Me.ToolStripButton34.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton34.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton34.Text = "Move last"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton35
        '
        Me.ToolStripButton35.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton35.Image = CType(resources.GetObject("ToolStripButton35.Image"), System.Drawing.Image)
        Me.ToolStripButton35.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton35.Name = "ToolStripButton35"
        Me.ToolStripButton35.Size = New System.Drawing.Size(23, 20)
        Me.ToolStripButton35.Text = "&Save"
        '
        'XrewseisTableAdapter
        '
        Me.XrewseisTableAdapter.ClearBeforeFill = True
        '
        'PraktoreiaTableAdapter
        '
        Me.PraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'SeasonsBindingSource
        '
        Me.SeasonsBindingSource.DataMember = "seasons"
        Me.SeasonsBindingSource.DataSource = Me.DbhotelDataSet
        '
        'SeasonsTableAdapter
        '
        Me.SeasonsTableAdapter.ClearBeforeFill = True
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
        'TouristperiodoiBindingSource
        '
        Me.TouristperiodoiBindingSource.DataMember = "touristperiodoi"
        Me.TouristperiodoiBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TouristperiodoiTableAdapter
        '
        Me.TouristperiodoiTableAdapter.ClearBeforeFill = True
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
        'AllotmentBindingSource
        '
        Me.AllotmentBindingSource.DataMember = "allotment"
        Me.AllotmentBindingSource.DataSource = Me.DbhotelDataSet
        '
        'AllotmentTableAdapter
        '
        Me.AllotmentTableAdapter.ClearBeforeFill = True
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
        'BookingposBindingSource
        '
        Me.BookingposBindingSource.DataMember = "bookingpos"
        Me.BookingposBindingSource.DataSource = Me.DbhotelDataSet
        '
        'BookingposTableAdapter
        '
        Me.BookingposTableAdapter.ClearBeforeFill = True
        '
        'SimfoniesBindingSource
        '
        Me.SimfoniesBindingSource.DataMember = "simfonies"
        Me.SimfoniesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'SimfoniesTableAdapter
        '
        Me.SimfoniesTableAdapter.ClearBeforeFill = True
        '
        'TimesBindingSource
        '
        Me.TimesBindingSource.DataMember = "times"
        Me.TimesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimesTableAdapter
        '
        Me.TimesTableAdapter.ClearBeforeFill = True
        '
        'TimeskratisisBindingSource
        '
        Me.TimeskratisisBindingSource.DataMember = "timeskratisis"
        Me.TimeskratisisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimeskratisisTableAdapter
        '
        Me.TimeskratisisTableAdapter.ClearBeforeFill = True
        '
        'Touristperiodoi1BindingSource
        '
        Me.Touristperiodoi1BindingSource.DataMember = "touristperiodoi1"
        Me.Touristperiodoi1BindingSource.DataSource = Me.DbhotelDataSet
        '
        'Touristperiodoi1TableAdapter
        '
        Me.Touristperiodoi1TableAdapter.ClearBeforeFill = True
        '
        'Times_ekt_joinBindingSource
        '
        Me.Times_ekt_joinBindingSource.DataMember = "times_ekt_join"
        Me.Times_ekt_joinBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Times_ekt_joinTableAdapter
        '
        Me.Times_ekt_joinTableAdapter.ClearBeforeFill = True
        '
        'EthnikotitesBindingSource
        '
        Me.EthnikotitesBindingSource.DataMember = "ethnikotites"
        Me.EthnikotitesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EthnikotitesTableAdapter
        '
        Me.EthnikotitesTableAdapter.ClearBeforeFill = True
        '
        'XoresBindingSource
        '
        Me.XoresBindingSource.DataMember = "xores"
        Me.XoresBindingSource.DataSource = Me.DbhotelDataSet
        '
        'XoresTableAdapter
        '
        Me.XoresTableAdapter.ClearBeforeFill = True
        '
        'PistwtikesBindingSource
        '
        Me.PistwtikesBindingSource.DataMember = "pistwtikes"
        Me.PistwtikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PistwtikesTableAdapter
        '
        Me.PistwtikesTableAdapter.ClearBeforeFill = True
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
        'EtaireiaBindingSource
        '
        Me.EtaireiaBindingSource.DataMember = "etaireia"
        Me.EtaireiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EtaireiaTableAdapter
        '
        Me.EtaireiaTableAdapter.ClearBeforeFill = True
        '
        'SimfoniesFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 722)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "SimfoniesFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ΣΥΜΦΩΝΙΕΣ - BOOKING POSITIONS ΠΡΑΚΤΟΡΕΙΩΝ"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.HauptPnl.ResumeLayout(False)
        Me.BookingBPnl.ResumeLayout(False)
        Me.BookingBPnl.PerformLayout()
        Me.EtiketaPnl.ResumeLayout(False)
        Me.EtiketaPnl.PerformLayout()
        Me.BookingAPnl.ResumeLayout(False)
        Me.BookingAPnl.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Allotm1Pnl.ResumeLayout(False)
        Me.Allotm1Pnl.PerformLayout()
        Me.Allotm2Pnl.ResumeLayout(False)
        Me.Allotm2Pnl.PerformLayout()
        Me.SimbolaioPnl.ResumeLayout(False)
        Me.SimbolaioPnl.PerformLayout()
        Me.PraktoreiaPnl.ResumeLayout(False)
        Me.PraktoreiaPnl.PerformLayout()
        CType(Me.PraktoreiaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator5.ResumeLayout(False)
        Me.BindingNavigator5.PerformLayout()
        Me.EktTimokPnl.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.EktBookPnl.ResumeLayout(False)
        Me.EktBook2Pnl.ResumeLayout(False)
        Me.EktBook2Pnl.PerformLayout()
        Me.EktAllotmentPnl.ResumeLayout(False)
        Me.EktAllotment1Pnl.ResumeLayout(False)
        Me.EktAllotment1Pnl.PerformLayout()
        Me.EuretirioPeriodoiPnl.ResumeLayout(False)
        CType(Me.PeriodoiDtGrd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PinakasDwm1Pnl.ResumeLayout(False)
        Me.PinakasDwm1Pnl.PerformLayout()
        Me.SimfoniesPnl.ResumeLayout(False)
        Me.SimfoniesPnl.PerformLayout()
        Me.TimiAtomoPnl.ResumeLayout(False)
        Me.TimiAtomoPnl.PerformLayout()
        Me.SimfPososPnl.ResumeLayout(False)
        Me.SimfPososPnl.PerformLayout()
        Me.TimesCBoxenPnl.ResumeLayout(False)
        Me.TipoiXrewsisPnl.ResumeLayout(False)
        Me.TipoiXrewsisPnl.PerformLayout()
        CType(Me.TXrewsisDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator4.ResumeLayout(False)
        Me.BindingNavigator4.PerformLayout()
        Me.SimfPaidiaPnl.ResumeLayout(False)
        Me.SimfPaidiaPnl.PerformLayout()
        Me.SimfPnlPnl.ResumeLayout(False)
        Me.SeasonPnl.ResumeLayout(False)
        Me.SeasonPnl.PerformLayout()
        CType(Me.SeasonsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator6.ResumeLayout(False)
        Me.BindingNavigator6.PerformLayout()
        CType(Me.SeasonsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TouristperiodoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BookingposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimfoniesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeskratisisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Touristperiodoi1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Times_ekt_joinBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XoresBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PistwtikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents HauptPnl As System.Windows.Forms.Panel
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents XrewseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents SeasonPnl As System.Windows.Forms.Panel
    Friend WithEvents SeasonsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BindingNavigator6 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton29 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton30 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton31 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton32 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox5 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton33 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton34 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton35 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeasonsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SeasonsTableAdapter As winhotel.dbhotelDataSetTableAdapters.seasonsTableAdapter
    Friend WithEvents PeriodoiPnl As System.Windows.Forms.Panel
    Friend WithEvents AASimbolPnl As System.Windows.Forms.Panel
    Friend WithEvents SimbolaiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimbolaiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
    Friend WithEvents TouristperiodoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TouristperiodoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.touristperiodoiTableAdapter
    Friend WithEvents AllotmBPnl As System.Windows.Forms.Panel
    Friend WithEvents KatigoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatigoriesTableAdapter As winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter
    Friend WithEvents AllotmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AllotmentTableAdapter As winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter
    Friend WithEvents KlinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KlinesTableAdapter As winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter
    Friend WithEvents TipoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter
    Friend WithEvents BookPos1Pnl As System.Windows.Forms.Panel
    Friend WithEvents BookingposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BookingposTableAdapter As winhotel.dbhotelDataSetTableAdapters.bookingposTableAdapter
    Friend WithEvents SimfoniesPnl As System.Windows.Forms.Panel
    Friend WithEvents TimiAtomoPnl As System.Windows.Forms.Panel
    Friend WithEvents TimiAtomoTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents SimfTipoiXrewsPnl As System.Windows.Forms.Panel
    Friend WithEvents SimfPososPnl As System.Windows.Forms.Panel
    Friend WithEvents TimesCBoxenPnl As System.Windows.Forms.Panel
    Friend WithEvents DeipnTbx As System.Windows.Forms.TextBox
    Friend WithEvents GeumTbx As System.Windows.Forms.TextBox
    Friend WithEvents PrwinTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents SimfPaidiaPnl As System.Windows.Forms.Panel
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents SimfAAPnl As System.Windows.Forms.Panel
    Friend WithEvents SimfPnlPnl As System.Windows.Forms.Panel
    Friend WithEvents InfSinfLbl As System.Windows.Forms.Label
    Friend WithEvents AddTimesBtn As System.Windows.Forms.Button
    Friend WithEvents SimfParamPnl As System.Windows.Forms.Panel
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents SimfSimbAAPnl As System.Windows.Forms.Panel
    Friend WithEvents SimfPraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents SimfoniesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimfoniesTableAdapter As winhotel.dbhotelDataSetTableAdapters.simfoniesTableAdapter
    Friend WithEvents TimesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimesTableAdapter As winhotel.dbhotelDataSetTableAdapters.timesTableAdapter
    Friend WithEvents TimeskratisisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimeskratisisTableAdapter As winhotel.dbhotelDataSetTableAdapters.timeskratisisTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EuretirioPeriodoiPnl As System.Windows.Forms.Panel
    Friend WithEvents PeriodoiDtGrd As System.Windows.Forms.DataGridView
    Friend WithEvents PinakasDwm1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents OrderKwdRdb As System.Windows.Forms.RadioButton
    Friend WithEvents OrderPraktRdb As System.Windows.Forms.RadioButton
    Friend WithEvents EuretirioPeriodoiBtn As System.Windows.Forms.Button
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Touristperiodoi1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Touristperiodoi1TableAdapter As winhotel.dbhotelDataSetTableAdapters.touristperiodoi1TableAdapter
    Friend WithEvents EktAllotmentPnl As System.Windows.Forms.Panel
    Friend WithEvents EktAllotment1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents EktAllotmentTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents EktAllotment1Btn As System.Windows.Forms.Button
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents EktBookPnl As System.Windows.Forms.Panel
    Friend WithEvents EktBook2Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents EktBookTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents EktBookBtn As System.Windows.Forms.Button
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents EktTimokPnl As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents EktTimokTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents EktTimokBtn As System.Windows.Forms.Button
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Times_ekt_joinBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Times_ekt_joinTableAdapter As winhotel.dbhotelDataSetTableAdapters.times_ekt_joinTableAdapter
    Friend WithEvents EthnikotitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikotitesTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
    Friend WithEvents XoresBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XoresTableAdapter As winhotel.dbhotelDataSetTableAdapters.xoresTableAdapter
    Friend WithEvents PraktoreiaPnl As System.Windows.Forms.Panel
    Friend WithEvents PraktoreiaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents KwdDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents eponimia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BindingNavigator5 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton24 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton25 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox4 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton26 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton27 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton28 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PistwtikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PistwtikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.pistwtikesTableAdapter
    Friend WithEvents ParastatikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParastatikaTableAdapter As winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents TipoiXrewsisPnl As System.Windows.Forms.Panel
    Friend WithEvents TXrewsisDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents KwdDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xrewsi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents perigrafi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ypnos As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents prwino As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents geuma As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents deipno As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BindingNavigator4 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton20 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton21 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SimbolaioPnl As System.Windows.Forms.Panel
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents PraktoreioTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents SimbolaioTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents NameLbl As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents AASimbPnl As System.Windows.Forms.Panel
    Friend WithEvents Allotm1Pnl As System.Windows.Forms.Panel
    Friend WithEvents InfoPnl As System.Windows.Forms.Panel
    Friend WithEvents ArxiTbx As System.Windows.Forms.TextBox
    Friend WithEvents Allotm3Pnl As System.Windows.Forms.Panel
    Friend WithEvents Allotm2Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KlinsCbx As System.Windows.Forms.ComboBox
    Friend WithEvents SimbTxb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TipiCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GuaraRB As System.Windows.Forms.RadioButton
    Friend WithEvents AllotmRB As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents PraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents BookingAPnl As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ImeromEkdoDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents BPSimbPnl As System.Windows.Forms.Panel
    Friend WithEvents AllotmSichtPnl As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents AllotmRBPnl As System.Windows.Forms.Panel
    Friend WithEvents PraktorTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents EtiketaPnl As System.Windows.Forms.Panel
    Friend WithEvents ForoiPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaLbl As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SxedioPnl As System.Windows.Forms.Panel
    Friend WithEvents TmimaPnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiPnl As System.Windows.Forms.Panel
    Friend WithEvents BookingBPnl As System.Windows.Forms.Panel
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents SimbBPbPnl As System.Windows.Forms.Panel
    Friend WithEvents BookPos2Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents AllotmRBbPnl As System.Windows.Forms.Panel
    Friend WithEvents PraktorBTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
End Class
