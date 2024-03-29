<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErgasiesTelosEtous
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πληρότητα Δωματίων ")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πρακτορεία")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εθνικότητες")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Διανυκτερεύσεις", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πίνακας Εσόδων")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τιμολ/κή πολιτική")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτυπώσεις", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode4, TreeNode5, TreeNode6})
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TelosEtousTree = New System.Windows.Forms.TreeView()
        Me.ZentralPnl = New System.Windows.Forms.Panel()
        Me.TimpolPnl = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.StatistChk = New System.Windows.Forms.CheckBox()
        Me.etosTbx = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimpolBtn = New System.Windows.Forms.Button()
        Me.PinakEsodPnl = New System.Windows.Forms.Panel()
        Me.PinakEsod1Pnl = New System.Windows.Forms.Panel()
        Me.PinakEsodTbx = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PinakEsodBtn = New System.Windows.Forms.Button()
        Me.KatastasiPnl = New System.Windows.Forms.Panel()
        Me.Katastasi1Pnl = New System.Windows.Forms.Panel()
        Me.KatastLbl = New System.Windows.Forms.Label()
        Me.KatastasiBtn = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.EtiketaPnl = New System.Windows.Forms.Panel()
        Me.EtiketaLbl = New System.Windows.Forms.Label()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.Dianiktereuseis_minaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Dianiktereuseis_minaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dianiktereuseis_minaTableAdapter()
        Me.Allotment_praktoreouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Allotment_praktoreouTableAdapter = New winhotel.dbhotelDataSetTableAdapters.allotment_praktoreouTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        Me.EthnikotitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikotitesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter()
        Me.Esoda_praktoreiwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Esoda_praktoreiwnTableAdapter = New winhotel.dbhotelDataSetTableAdapters.esoda_praktoreiwnTableAdapter()
        Me.Analysi_esodwn_tmimatwn_minosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Analysi_esodwn_tmimatwn_minosTableAdapter = New winhotel.dbhotelDataSetTableAdapters.analysi_esodwn_tmimatwn_minosTableAdapter()
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter()
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter()
        Me.EisprakseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EisprakseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter()
        Me.TmimataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TmimataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter()
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ZentralPnl.SuspendLayout()
        Me.TimpolPnl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PinakEsodPnl.SuspendLayout()
        Me.PinakEsod1Pnl.SuspendLayout()
        Me.KatastasiPnl.SuspendLayout()
        Me.Katastasi1Pnl.SuspendLayout()
        Me.EtiketaPnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dianiktereuseis_minaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Allotment_praktoreouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Esoda_praktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Analysi_esodwn_tmimatwn_minosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TelosEtousTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ZentralPnl)
        Me.SplitContainer1.Size = New System.Drawing.Size(821, 355)
        Me.SplitContainer1.SplitterDistance = 219
        Me.SplitContainer1.TabIndex = 0
        '
        'TelosEtousTree
        '
        Me.TelosEtousTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelosEtousTree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TelosEtousTree.Location = New System.Drawing.Point(0, 0)
        Me.TelosEtousTree.Name = "TelosEtousTree"
        TreeNode1.Name = "plirotita_dwmatiwn"
        TreeNode1.Text = "Πληρότητα Δωματίων "
        TreeNode2.Name = "praktoreia"
        TreeNode2.Text = "Πρακτορεία"
        TreeNode3.Name = "ethnikotites"
        TreeNode3.Text = "Εθνικότητες"
        TreeNode4.Name = "Node0"
        TreeNode4.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode4.Text = "Διανυκτερεύσεις"
        TreeNode5.Name = "pinakas_esodwn"
        TreeNode5.Text = "Πίνακας Εσόδων"
        TreeNode6.ForeColor = System.Drawing.Color.DarkRed
        TreeNode6.Name = "tim_politiki"
        TreeNode6.Text = "Τιμολ/κή πολιτική"
        TreeNode7.Name = "Node0"
        TreeNode7.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode7.Text = "Εκτυπώσεις"
        Me.TelosEtousTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7})
        Me.TelosEtousTree.Size = New System.Drawing.Size(219, 355)
        Me.TelosEtousTree.TabIndex = 0
        '
        'ZentralPnl
        '
        Me.ZentralPnl.AutoScroll = True
        Me.ZentralPnl.Controls.Add(Me.TimpolPnl)
        Me.ZentralPnl.Controls.Add(Me.PinakEsodPnl)
        Me.ZentralPnl.Controls.Add(Me.KatastasiPnl)
        Me.ZentralPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.ZentralPnl.Controls.Add(Me.EtiketaPnl)
        Me.ZentralPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ZentralPnl.Location = New System.Drawing.Point(0, 0)
        Me.ZentralPnl.Name = "ZentralPnl"
        Me.ZentralPnl.Size = New System.Drawing.Size(598, 355)
        Me.ZentralPnl.TabIndex = 0
        '
        'TimpolPnl
        '
        Me.TimpolPnl.Controls.Add(Me.Panel2)
        Me.TimpolPnl.Location = New System.Drawing.Point(54, 121)
        Me.TimpolPnl.Name = "TimpolPnl"
        Me.TimpolPnl.Size = New System.Drawing.Size(488, 144)
        Me.TimpolPnl.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.StatistChk)
        Me.Panel2.Controls.Add(Me.etosTbx)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TimpolBtn)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel2.Location = New System.Drawing.Point(17, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(437, 138)
        Me.Panel2.TabIndex = 0
        '
        'StatistChk
        '
        Me.StatistChk.AutoSize = True
        Me.StatistChk.Location = New System.Drawing.Point(97, 55)
        Me.StatistChk.Name = "StatistChk"
        Me.StatistChk.Size = New System.Drawing.Size(175, 19)
        Me.StatistChk.TabIndex = 53
        Me.StatistChk.Text = "Στατιστικά πρακτορείων"
        Me.StatistChk.UseVisualStyleBackColor = True
        '
        'etosTbx
        '
        Me.etosTbx.Location = New System.Drawing.Point(134, 21)
        Me.etosTbx.MaxLength = 4
        Me.etosTbx.Name = "etosTbx"
        Me.etosTbx.Size = New System.Drawing.Size(100, 21)
        Me.etosTbx.TabIndex = 52
        Me.etosTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(86, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Έτος:"
        '
        'TimpolBtn
        '
        Me.TimpolBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimpolBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.TimpolBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TimpolBtn.Location = New System.Drawing.Point(79, 85)
        Me.TimpolBtn.Name = "TimpolBtn"
        Me.TimpolBtn.Size = New System.Drawing.Size(193, 23)
        Me.TimpolBtn.TabIndex = 50
        Me.TimpolBtn.Text = "Προεπισκόπηση"
        Me.TimpolBtn.UseVisualStyleBackColor = True
        '
        'PinakEsodPnl
        '
        Me.PinakEsodPnl.Controls.Add(Me.PinakEsod1Pnl)
        Me.PinakEsodPnl.Location = New System.Drawing.Point(49, 92)
        Me.PinakEsodPnl.Name = "PinakEsodPnl"
        Me.PinakEsodPnl.Size = New System.Drawing.Size(492, 10)
        Me.PinakEsodPnl.TabIndex = 5
        '
        'PinakEsod1Pnl
        '
        Me.PinakEsod1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PinakEsod1Pnl.Controls.Add(Me.PinakEsodTbx)
        Me.PinakEsod1Pnl.Controls.Add(Me.Label1)
        Me.PinakEsod1Pnl.Controls.Add(Me.PinakEsodBtn)
        Me.PinakEsod1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PinakEsod1Pnl.Location = New System.Drawing.Point(17, 13)
        Me.PinakEsod1Pnl.Name = "PinakEsod1Pnl"
        Me.PinakEsod1Pnl.Size = New System.Drawing.Size(344, 124)
        Me.PinakEsod1Pnl.TabIndex = 0
        '
        'PinakEsodTbx
        '
        Me.PinakEsodTbx.Location = New System.Drawing.Point(151, 21)
        Me.PinakEsodTbx.MaxLength = 4
        Me.PinakEsodTbx.Name = "PinakEsodTbx"
        Me.PinakEsodTbx.Size = New System.Drawing.Size(100, 21)
        Me.PinakEsodTbx.TabIndex = 52
        Me.PinakEsodTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Προηγούμενο Έτος:"
        '
        'PinakEsodBtn
        '
        Me.PinakEsodBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PinakEsodBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.PinakEsodBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PinakEsodBtn.Location = New System.Drawing.Point(70, 72)
        Me.PinakEsodBtn.Name = "PinakEsodBtn"
        Me.PinakEsodBtn.Size = New System.Drawing.Size(193, 23)
        Me.PinakEsodBtn.TabIndex = 50
        Me.PinakEsodBtn.Text = "Προεπισκόπηση"
        Me.PinakEsodBtn.UseVisualStyleBackColor = True
        '
        'KatastasiPnl
        '
        Me.KatastasiPnl.Controls.Add(Me.Katastasi1Pnl)
        Me.KatastasiPnl.Location = New System.Drawing.Point(28, 61)
        Me.KatastasiPnl.Name = "KatastasiPnl"
        Me.KatastasiPnl.Size = New System.Drawing.Size(390, 11)
        Me.KatastasiPnl.TabIndex = 3
        '
        'Katastasi1Pnl
        '
        Me.Katastasi1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Katastasi1Pnl.Controls.Add(Me.KatastLbl)
        Me.Katastasi1Pnl.Controls.Add(Me.KatastasiBtn)
        Me.Katastasi1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Katastasi1Pnl.Location = New System.Drawing.Point(21, 9)
        Me.Katastasi1Pnl.Name = "Katastasi1Pnl"
        Me.Katastasi1Pnl.Size = New System.Drawing.Size(344, 100)
        Me.Katastasi1Pnl.TabIndex = 0
        '
        'KatastLbl
        '
        Me.KatastLbl.AutoSize = True
        Me.KatastLbl.ForeColor = System.Drawing.Color.Blue
        Me.KatastLbl.Location = New System.Drawing.Point(14, 10)
        Me.KatastLbl.Name = "KatastLbl"
        Me.KatastLbl.Size = New System.Drawing.Size(43, 15)
        Me.KatastLbl.TabIndex = 51
        Me.KatastLbl.Text = "Label"
        '
        'KatastasiBtn
        '
        Me.KatastasiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KatastasiBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.KatastasiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KatastasiBtn.Location = New System.Drawing.Point(70, 51)
        Me.KatastasiBtn.Name = "KatastasiBtn"
        Me.KatastasiBtn.Size = New System.Drawing.Size(193, 23)
        Me.KatastasiBtn.TabIndex = 50
        Me.KatastasiBtn.Text = "Προεπισκόπηση"
        Me.KatastasiBtn.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(548, 152)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(10, 150)
        Me.CrystalReportViewer1.TabIndex = 4
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'EtiketaPnl
        '
        Me.EtiketaPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPnl.Location = New System.Drawing.Point(17, 280)
        Me.EtiketaPnl.Name = "EtiketaPnl"
        Me.EtiketaPnl.Size = New System.Drawing.Size(200, 48)
        Me.EtiketaPnl.TabIndex = 2
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaLbl.Location = New System.Drawing.Point(21, 11)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(117, 25)
        Me.EtiketaLbl.TabIndex = 0
        Me.EtiketaLbl.Text = "EtiketaLbl"
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Dianiktereuseis_minaBindingSource
        '
        Me.Dianiktereuseis_minaBindingSource.DataMember = "dianiktereuseis_mina"
        Me.Dianiktereuseis_minaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Dianiktereuseis_minaTableAdapter
        '
        Me.Dianiktereuseis_minaTableAdapter.ClearBeforeFill = True
        '
        'Allotment_praktoreouBindingSource
        '
        Me.Allotment_praktoreouBindingSource.DataMember = "allotment_praktoreou"
        Me.Allotment_praktoreouBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Allotment_praktoreouTableAdapter
        '
        Me.Allotment_praktoreouTableAdapter.ClearBeforeFill = True
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
        'EthnikotitesBindingSource
        '
        Me.EthnikotitesBindingSource.DataMember = "ethnikotites"
        Me.EthnikotitesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EthnikotitesTableAdapter
        '
        Me.EthnikotitesTableAdapter.ClearBeforeFill = True
        '
        'Esoda_praktoreiwnBindingSource
        '
        Me.Esoda_praktoreiwnBindingSource.DataMember = "esoda_praktoreiwn"
        Me.Esoda_praktoreiwnBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Esoda_praktoreiwnTableAdapter
        '
        Me.Esoda_praktoreiwnTableAdapter.ClearBeforeFill = True
        '
        'Analysi_esodwn_tmimatwn_minosBindingSource
        '
        Me.Analysi_esodwn_tmimatwn_minosBindingSource.DataMember = "analysi_esodwn_tmimatwn_minos"
        Me.Analysi_esodwn_tmimatwn_minosBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Analysi_esodwn_tmimatwn_minosTableAdapter
        '
        Me.Analysi_esodwn_tmimatwn_minosTableAdapter.ClearBeforeFill = True
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
        'EisprakseispraktoreiaBindingSource
        '
        Me.EisprakseispraktoreiaBindingSource.DataMember = "eisprakseispraktoreia"
        Me.EisprakseispraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EisprakseispraktoreiaTableAdapter
        '
        Me.EisprakseispraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'TmimataBindingSource
        '
        Me.TmimataBindingSource.DataMember = "tmimata"
        Me.TmimataBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TmimataTableAdapter
        '
        Me.TmimataTableAdapter.ClearBeforeFill = True
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet1
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.kratiseisTableAdapter = Me.KratiseisTableAdapter
        Me.TableAdapterManager.praktoreiaTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.vilapraktoreia1TableAdapter = Nothing
        '
        'ErgasiesTelosEtous
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 355)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ErgasiesTelosEtous"
        Me.Text = "Εργασίες Τέλος-Αρχής Season"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ZentralPnl.ResumeLayout(False)
        Me.TimpolPnl.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PinakEsodPnl.ResumeLayout(False)
        Me.PinakEsod1Pnl.ResumeLayout(False)
        Me.PinakEsod1Pnl.PerformLayout()
        Me.KatastasiPnl.ResumeLayout(False)
        Me.Katastasi1Pnl.ResumeLayout(False)
        Me.Katastasi1Pnl.PerformLayout()
        Me.EtiketaPnl.ResumeLayout(False)
        Me.EtiketaPnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dianiktereuseis_minaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Allotment_praktoreouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Esoda_praktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Analysi_esodwn_tmimatwn_minosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TelosEtousTree As System.Windows.Forms.TreeView
    Friend WithEvents ZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaLbl As System.Windows.Forms.Label
    Friend WithEvents KatastasiPnl As System.Windows.Forms.Panel
    Friend WithEvents Katastasi1Pnl As System.Windows.Forms.Panel
    Friend WithEvents KatastLbl As System.Windows.Forms.Label
    Friend WithEvents KatastasiBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents Dianiktereuseis_minaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Dianiktereuseis_minaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dianiktereuseis_minaTableAdapter
    Friend WithEvents Allotment_praktoreouBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Allotment_praktoreouTableAdapter As winhotel.dbhotelDataSetTableAdapters.allotment_praktoreouTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EthnikotitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikotitesTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
    Friend WithEvents PinakEsodPnl As System.Windows.Forms.Panel
    Friend WithEvents PinakEsod1Pnl As System.Windows.Forms.Panel
    Friend WithEvents PinakEsodTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PinakEsodBtn As System.Windows.Forms.Button
    Friend WithEvents Esoda_praktoreiwnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Esoda_praktoreiwnTableAdapter As winhotel.dbhotelDataSetTableAdapters.esoda_praktoreiwnTableAdapter
    Friend WithEvents Analysi_esodwn_tmimatwn_minosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Analysi_esodwn_tmimatwn_minosTableAdapter As winhotel.dbhotelDataSetTableAdapters.analysi_esodwn_tmimatwn_minosTableAdapter
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents XrewseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
    Friend WithEvents EisprakseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EisprakseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
    Friend WithEvents TmimataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TmimataTableAdapter As winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
    Friend WithEvents TimpolPnl As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents etosTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TimpolBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents StatistChk As System.Windows.Forms.CheckBox
End Class
