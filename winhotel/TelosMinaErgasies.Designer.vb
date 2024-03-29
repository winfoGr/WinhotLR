<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TelosMinaErgasies
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Πληρότητα Δωματίων")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ανά Πρακτορείο")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ανά Εθνικότητα")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ανά Επάγγελμα")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("ανά Ηλικίες")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Διανυκτερεύσεις", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Λίστα Over")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κατανομή ανά Πρακτορείο")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Μήνα (Α' Ανάλυση)")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Μήνα (B' Ανάλυση)")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εσοδα", New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτυπώσεις", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode6, TreeNode7, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Διορθώσεις Στοιχείων")
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TelosMinaTree = New System.Windows.Forms.TreeView
        Me.OverPnl = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.OverBtn = New System.Windows.Forms.Button
        Me.overPck = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.ZentralPnl = New System.Windows.Forms.Panel
        Me.DiorthoseisPnl = New System.Windows.Forms.Panel
        Me.Diorthoseis4Pnl = New System.Windows.Forms.Panel
        Me.Diorthoseis3Pnl = New System.Windows.Forms.Panel
        Me.Diorthoseis2Pnl = New System.Windows.Forms.Panel
        Me.Diorthoseis1Pnl = New System.Windows.Forms.Panel
        Me.Diorthoseis4Rdb = New System.Windows.Forms.RadioButton
        Me.Diorthoseis3Rdb = New System.Windows.Forms.RadioButton
        Me.Diorthoseis2Rdb = New System.Windows.Forms.RadioButton
        Me.Diorthoseis1Rdb = New System.Windows.Forms.RadioButton
        Me.EsodaAnalBPnl = New System.Windows.Forms.Panel
        Me.EsodaAnalB2Pnl = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.EsodaAnalBTbx = New System.Windows.Forms.TextBox
        Me.EsodaAnalBtn = New System.Windows.Forms.Button
        Me.EsodaAnalBPck = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.EsodaAnalAPnl = New System.Windows.Forms.Panel
        Me.EsodaAnalA2Pnl = New System.Windows.Forms.Panel
        Me.EsodaAnalABtn = New System.Windows.Forms.Button
        Me.EsodaAnalAPck = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.HlikiesPnl = New System.Windows.Forms.Panel
        Me.DianiktereuseisPnl = New System.Windows.Forms.Panel
        Me.Dianiktereuseis1Pnl = New System.Windows.Forms.Panel
        Me.DianiktereuseisBtn = New System.Windows.Forms.Button
        Me.MinasPck = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Hlikies2Pnl = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.IlikiaTbx8 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx7 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx6 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx5 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx4 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx3 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx2 = New System.Windows.Forms.TextBox
        Me.IlikiaTbx1 = New System.Windows.Forms.TextBox
        Me.HlikiesBtn = New System.Windows.Forms.Button
        Me.HlikiesPck = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.EtiketaPnl = New System.Windows.Forms.Panel
        Me.EtiketaLbl = New System.Windows.Forms.Label
        Me.PraktEsodaPnl = New System.Windows.Forms.Panel
        Me.PraktEsoda2Pnl = New System.Windows.Forms.Panel
        Me.MinasRdb = New System.Windows.Forms.RadioButton
        Me.ImerisRdb = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PraktEsodaBtn = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.PraktEsodaCbx = New System.Windows.Forms.ComboBox
        Me.PraktEsodaTbx = New System.Windows.Forms.TextBox
        Me.Label138 = New System.Windows.Forms.Label
        Me.MexriPck = New System.Windows.Forms.DateTimePicker
        Me.ApoPck = New System.Windows.Forms.DateTimePicker
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet
        Me.Dianiktereuseis_minaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Dianiktereuseis_minaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dianiktereuseis_minaTableAdapter
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
        Me.EthnikotitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikotitesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
        Me.Allotment_praktoreouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Allotment_praktoreouTableAdapter = New winhotel.dbhotelDataSetTableAdapters.allotment_praktoreouTableAdapter
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
        Me.SimbolaiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimbolaiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
        Me.Esoda_praktoreiwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Esoda_praktoreiwnTableAdapter = New winhotel.dbhotelDataSetTableAdapters.esoda_praktoreiwnTableAdapter
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        Me.XrewseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
        Me.Analysi_esodwn_tmimatwn_minosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Analysi_esodwn_tmimatwn_minosTableAdapter = New winhotel.dbhotelDataSetTableAdapters.analysi_esodwn_tmimatwn_minosTableAdapter
        Me.TmimataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TmimataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
        Me.EisprakseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EisprakseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
        Me.EthnikdiorthoseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikdiorthoseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikdiorthoseisTableAdapter
        Me.OverBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OverTableAdapter = New winhotel.dbhotelDataSetTableAdapters.overTableAdapter
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.OverPnl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ZentralPnl.SuspendLayout()
        Me.DiorthoseisPnl.SuspendLayout()
        Me.Diorthoseis1Pnl.SuspendLayout()
        Me.EsodaAnalBPnl.SuspendLayout()
        Me.EsodaAnalB2Pnl.SuspendLayout()
        Me.EsodaAnalAPnl.SuspendLayout()
        Me.EsodaAnalA2Pnl.SuspendLayout()
        Me.HlikiesPnl.SuspendLayout()
        Me.DianiktereuseisPnl.SuspendLayout()
        Me.Dianiktereuseis1Pnl.SuspendLayout()
        Me.Hlikies2Pnl.SuspendLayout()
        Me.EtiketaPnl.SuspendLayout()
        Me.PraktEsodaPnl.SuspendLayout()
        Me.PraktEsoda2Pnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dianiktereuseis_minaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Allotment_praktoreouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Esoda_praktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Analysi_esodwn_tmimatwn_minosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikdiorthoseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TelosMinaTree)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AccessibleName = "SplitContaner1.panel2"
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.OverPnl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ZentralPnl)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PraktEsodaPnl)
        Me.SplitContainer1.Size = New System.Drawing.Size(837, 355)
        Me.SplitContainer1.SplitterDistance = 219
        Me.SplitContainer1.TabIndex = 0
        '
        'TelosMinaTree
        '
        Me.TelosMinaTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TelosMinaTree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TelosMinaTree.Location = New System.Drawing.Point(0, 0)
        Me.TelosMinaTree.Name = "TelosMinaTree"
        TreeNode1.Name = "plirotita"
        TreeNode1.Text = "Πληρότητα Δωματίων"
        TreeNode2.Name = "dianiktereuseis"
        TreeNode2.Text = "ανά Πρακτορείο"
        TreeNode3.Name = "ethnikotita"
        TreeNode3.Text = "ανά Εθνικότητα"
        TreeNode4.Name = "epaggelma"
        TreeNode4.Text = "ανά Επάγγελμα"
        TreeNode5.Name = "Hlikies"
        TreeNode5.Text = "ανά Ηλικίες"
        TreeNode6.Name = "Node0"
        TreeNode6.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode6.Text = "Διανυκτερεύσεις"
        TreeNode7.Name = "lista_over"
        TreeNode7.Text = "Λίστα Over"
        TreeNode8.Name = "esoda_prakt"
        TreeNode8.Text = "Κατανομή ανά Πρακτορείο"
        TreeNode9.Name = "analysi_a_esodwn"
        TreeNode9.Text = "Μήνα (Α' Ανάλυση)"
        TreeNode10.Name = "analysi_b_esodwn"
        TreeNode10.Text = "Μήνα (B' Ανάλυση)"
        TreeNode11.Name = "Node0"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode11.Text = "Εσοδα"
        TreeNode12.Name = "Node0"
        TreeNode12.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode12.Text = "Εκτυπώσεις"
        TreeNode13.Name = "diorthoseis"
        TreeNode13.Text = "Διορθώσεις Στοιχείων"
        Me.TelosMinaTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Me.TelosMinaTree.Size = New System.Drawing.Size(219, 355)
        Me.TelosMinaTree.TabIndex = 0
        '
        'OverPnl
        '
        Me.OverPnl.Controls.Add(Me.Panel2)
        Me.OverPnl.Location = New System.Drawing.Point(98, 117)
        Me.OverPnl.Name = "OverPnl"
        Me.OverPnl.Size = New System.Drawing.Size(418, 120)
        Me.OverPnl.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.OverBtn)
        Me.Panel2.Controls.Add(Me.overPck)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Panel2.Location = New System.Drawing.Point(15, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(344, 100)
        Me.Panel2.TabIndex = 0
        '
        'OverBtn
        '
        Me.OverBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OverBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.OverBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OverBtn.Location = New System.Drawing.Point(71, 65)
        Me.OverBtn.Name = "OverBtn"
        Me.OverBtn.Size = New System.Drawing.Size(193, 23)
        Me.OverBtn.TabIndex = 50
        Me.OverBtn.Text = "Προεπισκόπηση"
        Me.OverBtn.UseVisualStyleBackColor = True
        '
        'overPck
        '
        Me.overPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.overPck.Location = New System.Drawing.Point(122, 28)
        Me.overPck.Name = "overPck"
        Me.overPck.Size = New System.Drawing.Size(101, 21)
        Me.overPck.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Επιλογή μήνα:"
        '
        'ZentralPnl
        '
        Me.ZentralPnl.Controls.Add(Me.DiorthoseisPnl)
        Me.ZentralPnl.Controls.Add(Me.EsodaAnalBPnl)
        Me.ZentralPnl.Controls.Add(Me.EsodaAnalAPnl)
        Me.ZentralPnl.Controls.Add(Me.HlikiesPnl)
        Me.ZentralPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.ZentralPnl.Controls.Add(Me.EtiketaPnl)
        Me.ZentralPnl.Location = New System.Drawing.Point(3, 12)
        Me.ZentralPnl.Name = "ZentralPnl"
        Me.ZentralPnl.Size = New System.Drawing.Size(559, 14)
        Me.ZentralPnl.TabIndex = 0
        '
        'DiorthoseisPnl
        '
        Me.DiorthoseisPnl.Controls.Add(Me.Diorthoseis4Pnl)
        Me.DiorthoseisPnl.Controls.Add(Me.Diorthoseis3Pnl)
        Me.DiorthoseisPnl.Controls.Add(Me.Diorthoseis2Pnl)
        Me.DiorthoseisPnl.Controls.Add(Me.Diorthoseis1Pnl)
        Me.DiorthoseisPnl.Location = New System.Drawing.Point(21, 253)
        Me.DiorthoseisPnl.Name = "DiorthoseisPnl"
        Me.DiorthoseisPnl.Size = New System.Drawing.Size(594, 10)
        Me.DiorthoseisPnl.TabIndex = 7
        '
        'Diorthoseis4Pnl
        '
        Me.Diorthoseis4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Diorthoseis4Pnl.Location = New System.Drawing.Point(9, 228)
        Me.Diorthoseis4Pnl.Name = "Diorthoseis4Pnl"
        Me.Diorthoseis4Pnl.Size = New System.Drawing.Size(565, 42)
        Me.Diorthoseis4Pnl.TabIndex = 3
        '
        'Diorthoseis3Pnl
        '
        Me.Diorthoseis3Pnl.AutoScroll = True
        Me.Diorthoseis3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Diorthoseis3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Diorthoseis3Pnl.Location = New System.Drawing.Point(9, 133)
        Me.Diorthoseis3Pnl.Name = "Diorthoseis3Pnl"
        Me.Diorthoseis3Pnl.Size = New System.Drawing.Size(565, 90)
        Me.Diorthoseis3Pnl.TabIndex = 2
        '
        'Diorthoseis2Pnl
        '
        Me.Diorthoseis2Pnl.BackColor = System.Drawing.Color.Silver
        Me.Diorthoseis2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Diorthoseis2Pnl.Location = New System.Drawing.Point(9, 52)
        Me.Diorthoseis2Pnl.Name = "Diorthoseis2Pnl"
        Me.Diorthoseis2Pnl.Size = New System.Drawing.Size(565, 75)
        Me.Diorthoseis2Pnl.TabIndex = 1
        '
        'Diorthoseis1Pnl
        '
        Me.Diorthoseis1Pnl.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Diorthoseis1Pnl.Controls.Add(Me.Diorthoseis4Rdb)
        Me.Diorthoseis1Pnl.Controls.Add(Me.Diorthoseis3Rdb)
        Me.Diorthoseis1Pnl.Controls.Add(Me.Diorthoseis2Rdb)
        Me.Diorthoseis1Pnl.Controls.Add(Me.Diorthoseis1Rdb)
        Me.Diorthoseis1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Diorthoseis1Pnl.Location = New System.Drawing.Point(9, 3)
        Me.Diorthoseis1Pnl.Name = "Diorthoseis1Pnl"
        Me.Diorthoseis1Pnl.Size = New System.Drawing.Size(565, 46)
        Me.Diorthoseis1Pnl.TabIndex = 0
        '
        'Diorthoseis4Rdb
        '
        Me.Diorthoseis4Rdb.AutoSize = True
        Me.Diorthoseis4Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Diorthoseis4Rdb.Location = New System.Drawing.Point(413, 14)
        Me.Diorthoseis4Rdb.Name = "Diorthoseis4Rdb"
        Me.Diorthoseis4Rdb.Size = New System.Drawing.Size(93, 17)
        Me.Diorthoseis4Rdb.TabIndex = 3
        Me.Diorthoseis4Rdb.TabStop = True
        Me.Diorthoseis4Rdb.Text = "Δωμ.Κατηγ."
        Me.Diorthoseis4Rdb.UseVisualStyleBackColor = True
        '
        'Diorthoseis3Rdb
        '
        Me.Diorthoseis3Rdb.AutoSize = True
        Me.Diorthoseis3Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Diorthoseis3Rdb.Location = New System.Drawing.Point(280, 14)
        Me.Diorthoseis3Rdb.Name = "Diorthoseis3Rdb"
        Me.Diorthoseis3Rdb.Size = New System.Drawing.Size(98, 17)
        Me.Diorthoseis3Rdb.TabIndex = 2
        Me.Diorthoseis3Rdb.TabStop = True
        Me.Diorthoseis3Rdb.Text = "Πρακτ.Ατομ."
        Me.Diorthoseis3Rdb.UseVisualStyleBackColor = True
        '
        'Diorthoseis2Rdb
        '
        Me.Diorthoseis2Rdb.AutoSize = True
        Me.Diorthoseis2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Diorthoseis2Rdb.Location = New System.Drawing.Point(147, 14)
        Me.Diorthoseis2Rdb.Name = "Diorthoseis2Rdb"
        Me.Diorthoseis2Rdb.Size = New System.Drawing.Size(93, 17)
        Me.Diorthoseis2Rdb.TabIndex = 1
        Me.Diorthoseis2Rdb.TabStop = True
        Me.Diorthoseis2Rdb.Text = "Πρακτ.Δωμ."
        Me.Diorthoseis2Rdb.UseVisualStyleBackColor = True
        '
        'Diorthoseis1Rdb
        '
        Me.Diorthoseis1Rdb.AutoSize = True
        Me.Diorthoseis1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Diorthoseis1Rdb.Location = New System.Drawing.Point(18, 14)
        Me.Diorthoseis1Rdb.Name = "Diorthoseis1Rdb"
        Me.Diorthoseis1Rdb.Size = New System.Drawing.Size(98, 17)
        Me.Diorthoseis1Rdb.TabIndex = 0
        Me.Diorthoseis1Rdb.TabStop = True
        Me.Diorthoseis1Rdb.Text = "Εθνικότητες"
        Me.Diorthoseis1Rdb.UseVisualStyleBackColor = True
        '
        'EsodaAnalBPnl
        '
        Me.EsodaAnalBPnl.Controls.Add(Me.EsodaAnalB2Pnl)
        Me.EsodaAnalBPnl.Location = New System.Drawing.Point(38, 12)
        Me.EsodaAnalBPnl.Name = "EsodaAnalBPnl"
        Me.EsodaAnalBPnl.Size = New System.Drawing.Size(418, 17)
        Me.EsodaAnalBPnl.TabIndex = 6
        '
        'EsodaAnalB2Pnl
        '
        Me.EsodaAnalB2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EsodaAnalB2Pnl.Controls.Add(Me.Label9)
        Me.EsodaAnalB2Pnl.Controls.Add(Me.EsodaAnalBTbx)
        Me.EsodaAnalB2Pnl.Controls.Add(Me.EsodaAnalBtn)
        Me.EsodaAnalB2Pnl.Controls.Add(Me.EsodaAnalBPck)
        Me.EsodaAnalB2Pnl.Controls.Add(Me.Label8)
        Me.EsodaAnalB2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EsodaAnalB2Pnl.Location = New System.Drawing.Point(18, 5)
        Me.EsodaAnalB2Pnl.Name = "EsodaAnalB2Pnl"
        Me.EsodaAnalB2Pnl.Size = New System.Drawing.Size(344, 149)
        Me.EsodaAnalB2Pnl.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 15)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Ποσό από Μεταφορά:"
        '
        'EsodaAnalBTbx
        '
        Me.EsodaAnalBTbx.Location = New System.Drawing.Point(195, 66)
        Me.EsodaAnalBTbx.MaxLength = 9
        Me.EsodaAnalBTbx.Name = "EsodaAnalBTbx"
        Me.EsodaAnalBTbx.Size = New System.Drawing.Size(90, 21)
        Me.EsodaAnalBTbx.TabIndex = 51
        Me.EsodaAnalBTbx.Text = "0,00"
        Me.EsodaAnalBTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EsodaAnalBtn
        '
        Me.EsodaAnalBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EsodaAnalBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EsodaAnalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EsodaAnalBtn.Location = New System.Drawing.Point(74, 108)
        Me.EsodaAnalBtn.Name = "EsodaAnalBtn"
        Me.EsodaAnalBtn.Size = New System.Drawing.Size(193, 23)
        Me.EsodaAnalBtn.TabIndex = 50
        Me.EsodaAnalBtn.Text = "Προεπισκόπηση"
        Me.EsodaAnalBtn.UseVisualStyleBackColor = True
        '
        'EsodaAnalBPck
        '
        Me.EsodaAnalBPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EsodaAnalBPck.Location = New System.Drawing.Point(195, 24)
        Me.EsodaAnalBPck.Name = "EsodaAnalBPck"
        Me.EsodaAnalBPck.Size = New System.Drawing.Size(91, 21)
        Me.EsodaAnalBPck.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(83, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Επιλογή μήνα:"
        '
        'EsodaAnalAPnl
        '
        Me.EsodaAnalAPnl.Controls.Add(Me.EsodaAnalA2Pnl)
        Me.EsodaAnalAPnl.Location = New System.Drawing.Point(89, 35)
        Me.EsodaAnalAPnl.Name = "EsodaAnalAPnl"
        Me.EsodaAnalAPnl.Size = New System.Drawing.Size(418, 120)
        Me.EsodaAnalAPnl.TabIndex = 5
        '
        'EsodaAnalA2Pnl
        '
        Me.EsodaAnalA2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EsodaAnalA2Pnl.Controls.Add(Me.EsodaAnalABtn)
        Me.EsodaAnalA2Pnl.Controls.Add(Me.EsodaAnalAPck)
        Me.EsodaAnalA2Pnl.Controls.Add(Me.Label7)
        Me.EsodaAnalA2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EsodaAnalA2Pnl.Location = New System.Drawing.Point(15, 6)
        Me.EsodaAnalA2Pnl.Name = "EsodaAnalA2Pnl"
        Me.EsodaAnalA2Pnl.Size = New System.Drawing.Size(344, 100)
        Me.EsodaAnalA2Pnl.TabIndex = 0
        '
        'EsodaAnalABtn
        '
        Me.EsodaAnalABtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EsodaAnalABtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.EsodaAnalABtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EsodaAnalABtn.Location = New System.Drawing.Point(71, 65)
        Me.EsodaAnalABtn.Name = "EsodaAnalABtn"
        Me.EsodaAnalABtn.Size = New System.Drawing.Size(193, 23)
        Me.EsodaAnalABtn.TabIndex = 50
        Me.EsodaAnalABtn.Text = "Προεπισκόπηση"
        Me.EsodaAnalABtn.UseVisualStyleBackColor = True
        '
        'EsodaAnalAPck
        '
        Me.EsodaAnalAPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EsodaAnalAPck.Location = New System.Drawing.Point(122, 28)
        Me.EsodaAnalAPck.Name = "EsodaAnalAPck"
        Me.EsodaAnalAPck.Size = New System.Drawing.Size(101, 21)
        Me.EsodaAnalAPck.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Επιλογή μήνα:"
        '
        'HlikiesPnl
        '
        Me.HlikiesPnl.Controls.Add(Me.DianiktereuseisPnl)
        Me.HlikiesPnl.Controls.Add(Me.Hlikies2Pnl)
        Me.HlikiesPnl.Location = New System.Drawing.Point(29, 74)
        Me.HlikiesPnl.Name = "HlikiesPnl"
        Me.HlikiesPnl.Size = New System.Drawing.Size(418, 10)
        Me.HlikiesPnl.TabIndex = 3
        '
        'DianiktereuseisPnl
        '
        Me.DianiktereuseisPnl.Controls.Add(Me.Dianiktereuseis1Pnl)
        Me.DianiktereuseisPnl.Location = New System.Drawing.Point(39, 9)
        Me.DianiktereuseisPnl.Name = "DianiktereuseisPnl"
        Me.DianiktereuseisPnl.Size = New System.Drawing.Size(418, 10)
        Me.DianiktereuseisPnl.TabIndex = 0
        '
        'Dianiktereuseis1Pnl
        '
        Me.Dianiktereuseis1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Dianiktereuseis1Pnl.Controls.Add(Me.DianiktereuseisBtn)
        Me.Dianiktereuseis1Pnl.Controls.Add(Me.MinasPck)
        Me.Dianiktereuseis1Pnl.Controls.Add(Me.Label2)
        Me.Dianiktereuseis1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Dianiktereuseis1Pnl.Location = New System.Drawing.Point(19, 10)
        Me.Dianiktereuseis1Pnl.Name = "Dianiktereuseis1Pnl"
        Me.Dianiktereuseis1Pnl.Size = New System.Drawing.Size(344, 100)
        Me.Dianiktereuseis1Pnl.TabIndex = 0
        '
        'DianiktereuseisBtn
        '
        Me.DianiktereuseisBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DianiktereuseisBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.DianiktereuseisBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DianiktereuseisBtn.Location = New System.Drawing.Point(71, 65)
        Me.DianiktereuseisBtn.Name = "DianiktereuseisBtn"
        Me.DianiktereuseisBtn.Size = New System.Drawing.Size(193, 23)
        Me.DianiktereuseisBtn.TabIndex = 50
        Me.DianiktereuseisBtn.Text = "Προεπισκόπηση"
        Me.DianiktereuseisBtn.UseVisualStyleBackColor = True
        '
        'MinasPck
        '
        Me.MinasPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.MinasPck.Location = New System.Drawing.Point(122, 28)
        Me.MinasPck.Name = "MinasPck"
        Me.MinasPck.Size = New System.Drawing.Size(108, 21)
        Me.MinasPck.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Επιλογή μήνα:"
        '
        'Hlikies2Pnl
        '
        Me.Hlikies2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Hlikies2Pnl.Controls.Add(Me.Label3)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx8)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx7)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx6)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx5)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx4)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx3)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx2)
        Me.Hlikies2Pnl.Controls.Add(Me.IlikiaTbx1)
        Me.Hlikies2Pnl.Controls.Add(Me.HlikiesBtn)
        Me.Hlikies2Pnl.Controls.Add(Me.HlikiesPck)
        Me.Hlikies2Pnl.Controls.Add(Me.Label1)
        Me.Hlikies2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Hlikies2Pnl.Location = New System.Drawing.Point(39, 22)
        Me.Hlikies2Pnl.Name = "Hlikies2Pnl"
        Me.Hlikies2Pnl.Size = New System.Drawing.Size(360, 134)
        Me.Hlikies2Pnl.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(3, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Ηλικίες έως:"
        '
        'IlikiaTbx8
        '
        Me.IlikiaTbx8.Location = New System.Drawing.Point(292, 62)
        Me.IlikiaTbx8.MaxLength = 2
        Me.IlikiaTbx8.Name = "IlikiaTbx8"
        Me.IlikiaTbx8.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx8.TabIndex = 58
        Me.IlikiaTbx8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx7
        '
        Me.IlikiaTbx7.Location = New System.Drawing.Point(256, 62)
        Me.IlikiaTbx7.MaxLength = 2
        Me.IlikiaTbx7.Name = "IlikiaTbx7"
        Me.IlikiaTbx7.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx7.TabIndex = 57
        Me.IlikiaTbx7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx6
        '
        Me.IlikiaTbx6.Location = New System.Drawing.Point(220, 62)
        Me.IlikiaTbx6.MaxLength = 2
        Me.IlikiaTbx6.Name = "IlikiaTbx6"
        Me.IlikiaTbx6.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx6.TabIndex = 56
        Me.IlikiaTbx6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx5
        '
        Me.IlikiaTbx5.Location = New System.Drawing.Point(184, 62)
        Me.IlikiaTbx5.MaxLength = 2
        Me.IlikiaTbx5.Name = "IlikiaTbx5"
        Me.IlikiaTbx5.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx5.TabIndex = 55
        Me.IlikiaTbx5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx4
        '
        Me.IlikiaTbx4.Location = New System.Drawing.Point(148, 62)
        Me.IlikiaTbx4.MaxLength = 2
        Me.IlikiaTbx4.Name = "IlikiaTbx4"
        Me.IlikiaTbx4.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx4.TabIndex = 54
        Me.IlikiaTbx4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx3
        '
        Me.IlikiaTbx3.Location = New System.Drawing.Point(111, 62)
        Me.IlikiaTbx3.MaxLength = 2
        Me.IlikiaTbx3.Name = "IlikiaTbx3"
        Me.IlikiaTbx3.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx3.TabIndex = 53
        Me.IlikiaTbx3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx2
        '
        Me.IlikiaTbx2.Location = New System.Drawing.Point(75, 62)
        Me.IlikiaTbx2.MaxLength = 2
        Me.IlikiaTbx2.Name = "IlikiaTbx2"
        Me.IlikiaTbx2.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx2.TabIndex = 52
        Me.IlikiaTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IlikiaTbx1
        '
        Me.IlikiaTbx1.Location = New System.Drawing.Point(39, 62)
        Me.IlikiaTbx1.MaxLength = 2
        Me.IlikiaTbx1.Name = "IlikiaTbx1"
        Me.IlikiaTbx1.Size = New System.Drawing.Size(30, 21)
        Me.IlikiaTbx1.TabIndex = 51
        Me.IlikiaTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'HlikiesBtn
        '
        Me.HlikiesBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HlikiesBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.HlikiesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HlikiesBtn.Location = New System.Drawing.Point(91, 97)
        Me.HlikiesBtn.Name = "HlikiesBtn"
        Me.HlikiesBtn.Size = New System.Drawing.Size(173, 23)
        Me.HlikiesBtn.TabIndex = 50
        Me.HlikiesBtn.Text = "Προεπισκόπηση"
        Me.HlikiesBtn.UseVisualStyleBackColor = True
        '
        'HlikiesPck
        '
        Me.HlikiesPck.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.HlikiesPck.Location = New System.Drawing.Point(122, 16)
        Me.HlikiesPck.Name = "HlikiesPck"
        Me.HlikiesPck.Size = New System.Drawing.Size(103, 21)
        Me.HlikiesPck.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Επιλογή μήνα:"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(318, 181)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(150, 10)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'EtiketaPnl
        '
        Me.EtiketaPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPnl.Location = New System.Drawing.Point(56, 167)
        Me.EtiketaPnl.Name = "EtiketaPnl"
        Me.EtiketaPnl.Size = New System.Drawing.Size(200, 58)
        Me.EtiketaPnl.TabIndex = 1
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaLbl.Location = New System.Drawing.Point(36, 9)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(117, 25)
        Me.EtiketaLbl.TabIndex = 0
        Me.EtiketaLbl.Text = "EtiketaLbl"
        '
        'PraktEsodaPnl
        '
        Me.PraktEsodaPnl.Controls.Add(Me.PraktEsoda2Pnl)
        Me.PraktEsodaPnl.Location = New System.Drawing.Point(41, 70)
        Me.PraktEsodaPnl.Name = "PraktEsodaPnl"
        Me.PraktEsodaPnl.Size = New System.Drawing.Size(501, 25)
        Me.PraktEsodaPnl.TabIndex = 4
        '
        'PraktEsoda2Pnl
        '
        Me.PraktEsoda2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PraktEsoda2Pnl.Controls.Add(Me.MinasRdb)
        Me.PraktEsoda2Pnl.Controls.Add(Me.ImerisRdb)
        Me.PraktEsoda2Pnl.Controls.Add(Me.Label6)
        Me.PraktEsoda2Pnl.Controls.Add(Me.Label5)
        Me.PraktEsoda2Pnl.Controls.Add(Me.PraktEsodaBtn)
        Me.PraktEsoda2Pnl.Controls.Add(Me.Label4)
        Me.PraktEsoda2Pnl.Controls.Add(Me.PraktEsodaCbx)
        Me.PraktEsoda2Pnl.Controls.Add(Me.PraktEsodaTbx)
        Me.PraktEsoda2Pnl.Controls.Add(Me.Label138)
        Me.PraktEsoda2Pnl.Controls.Add(Me.MexriPck)
        Me.PraktEsoda2Pnl.Controls.Add(Me.ApoPck)
        Me.PraktEsoda2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PraktEsoda2Pnl.Location = New System.Drawing.Point(18, 8)
        Me.PraktEsoda2Pnl.Name = "PraktEsoda2Pnl"
        Me.PraktEsoda2Pnl.Size = New System.Drawing.Size(395, 232)
        Me.PraktEsoda2Pnl.TabIndex = 0
        '
        'MinasRdb
        '
        Me.MinasRdb.AutoSize = True
        Me.MinasRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MinasRdb.Location = New System.Drawing.Point(195, 142)
        Me.MinasRdb.Name = "MinasRdb"
        Me.MinasRdb.Size = New System.Drawing.Size(78, 20)
        Me.MinasRdb.TabIndex = 55
        Me.MinasRdb.Text = "Μηνιαία"
        Me.MinasRdb.UseVisualStyleBackColor = True
        '
        'ImerisRdb
        '
        Me.ImerisRdb.AutoSize = True
        Me.ImerisRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ImerisRdb.Checked = True
        Me.ImerisRdb.Location = New System.Drawing.Point(74, 142)
        Me.ImerisRdb.Name = "ImerisRdb"
        Me.ImerisRdb.Size = New System.Drawing.Size(91, 20)
        Me.ImerisRdb.TabIndex = 54
        Me.ImerisRdb.TabStop = True
        Me.ImerisRdb.Text = "Ημερήσια"
        Me.ImerisRdb.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(211, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "μέχρι:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 15)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "από:"
        '
        'PraktEsodaBtn
        '
        Me.PraktEsodaBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PraktEsodaBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.PraktEsodaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PraktEsodaBtn.Location = New System.Drawing.Point(89, 183)
        Me.PraktEsodaBtn.Name = "PraktEsodaBtn"
        Me.PraktEsodaBtn.Size = New System.Drawing.Size(193, 23)
        Me.PraktEsodaBtn.TabIndex = 51
        Me.PraktEsodaBtn.Text = "Προεπισκόπηση"
        Me.PraktEsodaBtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Συμβόλαιο:"
        '
        'PraktEsodaCbx
        '
        Me.PraktEsodaCbx.FormattingEnabled = True
        Me.PraktEsodaCbx.Location = New System.Drawing.Point(148, 108)
        Me.PraktEsodaCbx.Name = "PraktEsodaCbx"
        Me.PraktEsodaCbx.Size = New System.Drawing.Size(75, 24)
        Me.PraktEsodaCbx.TabIndex = 31
        '
        'PraktEsodaTbx
        '
        Me.PraktEsodaTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktEsodaTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktEsodaTbx.Location = New System.Drawing.Point(148, 69)
        Me.PraktEsodaTbx.Name = "PraktEsodaTbx"
        Me.PraktEsodaTbx.ReadOnly = True
        Me.PraktEsodaTbx.Size = New System.Drawing.Size(161, 22)
        Me.PraktEsodaTbx.TabIndex = 29
        Me.PraktEsodaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label138
        '
        Me.Label138.AutoSize = True
        Me.Label138.Location = New System.Drawing.Point(44, 71)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(95, 16)
        Me.Label138.TabIndex = 30
        Me.Label138.Text = "Πρακτορείο:"
        '
        'MexriPck
        '
        Me.MexriPck.Location = New System.Drawing.Point(212, 31)
        Me.MexriPck.Name = "MexriPck"
        Me.MexriPck.Size = New System.Drawing.Size(167, 22)
        Me.MexriPck.TabIndex = 1
        '
        'ApoPck
        '
        Me.ApoPck.Location = New System.Drawing.Point(23, 31)
        Me.ApoPck.Name = "ApoPck"
        Me.ApoPck.Size = New System.Drawing.Size(146, 22)
        Me.ApoPck.TabIndex = 0
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
        'Allotment_praktoreouBindingSource
        '
        Me.Allotment_praktoreouBindingSource.DataMember = "allotment_praktoreou"
        Me.Allotment_praktoreouBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Allotment_praktoreouTableAdapter
        '
        Me.Allotment_praktoreouTableAdapter.ClearBeforeFill = True
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
        'SimbolaiaBindingSource
        '
        Me.SimbolaiaBindingSource.DataMember = "simbolaia"
        Me.SimbolaiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'SimbolaiaTableAdapter
        '
        Me.SimbolaiaTableAdapter.ClearBeforeFill = True
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
        'PraktoreiaBindingSource
        '
        Me.PraktoreiaBindingSource.DataMember = "praktoreia"
        Me.PraktoreiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PraktoreiaTableAdapter
        '
        Me.PraktoreiaTableAdapter.ClearBeforeFill = True
        '
        'XrewseisBindingSource
        '
        Me.XrewseisBindingSource.DataMember = "xrewseis"
        Me.XrewseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'XrewseisTableAdapter
        '
        Me.XrewseisTableAdapter.ClearBeforeFill = True
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
        'TmimataBindingSource
        '
        Me.TmimataBindingSource.DataMember = "tmimata"
        Me.TmimataBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TmimataTableAdapter
        '
        Me.TmimataTableAdapter.ClearBeforeFill = True
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
        'EthnikdiorthoseisBindingSource
        '
        Me.EthnikdiorthoseisBindingSource.DataMember = "ethnikdiorthoseis"
        Me.EthnikdiorthoseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EthnikdiorthoseisTableAdapter
        '
        Me.EthnikdiorthoseisTableAdapter.ClearBeforeFill = True
        '
        'OverBindingSource
        '
        Me.OverBindingSource.DataMember = "over"
        Me.OverBindingSource.DataSource = Me.DbhotelDataSet
        '
        'OverTableAdapter
        '
        Me.OverTableAdapter.ClearBeforeFill = True
        '
        'TelosMinaErgasies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 358)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "TelosMinaErgasies"
        Me.Text = "Εργασίες στο τέλος του Μήνα"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.OverPnl.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ZentralPnl.ResumeLayout(False)
        Me.DiorthoseisPnl.ResumeLayout(False)
        Me.Diorthoseis1Pnl.ResumeLayout(False)
        Me.Diorthoseis1Pnl.PerformLayout()
        Me.EsodaAnalBPnl.ResumeLayout(False)
        Me.EsodaAnalB2Pnl.ResumeLayout(False)
        Me.EsodaAnalB2Pnl.PerformLayout()
        Me.EsodaAnalAPnl.ResumeLayout(False)
        Me.EsodaAnalA2Pnl.ResumeLayout(False)
        Me.EsodaAnalA2Pnl.PerformLayout()
        Me.HlikiesPnl.ResumeLayout(False)
        Me.DianiktereuseisPnl.ResumeLayout(False)
        Me.Dianiktereuseis1Pnl.ResumeLayout(False)
        Me.Dianiktereuseis1Pnl.PerformLayout()
        Me.Hlikies2Pnl.ResumeLayout(False)
        Me.Hlikies2Pnl.PerformLayout()
        Me.EtiketaPnl.ResumeLayout(False)
        Me.EtiketaPnl.PerformLayout()
        Me.PraktEsodaPnl.ResumeLayout(False)
        Me.PraktEsoda2Pnl.ResumeLayout(False)
        Me.PraktEsoda2Pnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dianiktereuseis_minaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Allotment_praktoreouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Esoda_praktoreiwnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Analysi_esodwn_tmimatwn_minosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EisprakseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikdiorthoseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TelosMinaTree As System.Windows.Forms.TreeView
    Friend WithEvents ZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents DianiktereuseisPnl As System.Windows.Forms.Panel
    Friend WithEvents Dianiktereuseis1Pnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaLbl As System.Windows.Forms.Label
    Friend WithEvents MinasPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DianiktereuseisBtn As System.Windows.Forms.Button
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents Dianiktereuseis_minaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Dianiktereuseis_minaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dianiktereuseis_minaTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents EthnikotitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikotitesTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
    Friend WithEvents HlikiesPnl As System.Windows.Forms.Panel
    Friend WithEvents Hlikies2Pnl As System.Windows.Forms.Panel
    Friend WithEvents HlikiesBtn As System.Windows.Forms.Button
    Friend WithEvents HlikiesPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IlikiaTbx8 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx7 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx6 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx5 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx4 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx3 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents IlikiaTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents Allotment_praktoreouBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Allotment_praktoreouTableAdapter As winhotel.dbhotelDataSetTableAdapters.allotment_praktoreouTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
    Friend WithEvents PraktEsodaPnl As System.Windows.Forms.Panel
    Friend WithEvents PraktEsoda2Pnl As System.Windows.Forms.Panel
    Friend WithEvents MexriPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents ApoPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents PraktEsodaBtn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PraktEsodaCbx As System.Windows.Forms.ComboBox
    Friend WithEvents PraktEsodaTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SimbolaiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimbolaiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
    Friend WithEvents Esoda_praktoreiwnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Esoda_praktoreiwnTableAdapter As winhotel.dbhotelDataSetTableAdapters.esoda_praktoreiwnTableAdapter
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents XrewseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
    Friend WithEvents MinasRdb As System.Windows.Forms.RadioButton
    Friend WithEvents ImerisRdb As System.Windows.Forms.RadioButton
    Friend WithEvents EsodaAnalAPnl As System.Windows.Forms.Panel
    Friend WithEvents EsodaAnalA2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EsodaAnalABtn As System.Windows.Forms.Button
    Friend WithEvents EsodaAnalAPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Analysi_esodwn_tmimatwn_minosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Analysi_esodwn_tmimatwn_minosTableAdapter As winhotel.dbhotelDataSetTableAdapters.analysi_esodwn_tmimatwn_minosTableAdapter
    Friend WithEvents TmimataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TmimataTableAdapter As winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
    Friend WithEvents EsodaAnalBPnl As System.Windows.Forms.Panel
    Friend WithEvents EsodaAnalB2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EsodaAnalBTbx As System.Windows.Forms.TextBox
    Friend WithEvents EsodaAnalBtn As System.Windows.Forms.Button
    Friend WithEvents EsodaAnalBPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents XrewseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
    Friend WithEvents EisprakseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EisprakseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.eisprakseispraktoreiaTableAdapter
    Friend WithEvents DiorthoseisPnl As System.Windows.Forms.Panel
    Friend WithEvents Diorthoseis1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Diorthoseis4Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Diorthoseis3Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Diorthoseis2Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Diorthoseis1Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Diorthoseis2Pnl As System.Windows.Forms.Panel
    Friend WithEvents Diorthoseis3Pnl As System.Windows.Forms.Panel
    Friend WithEvents EthnikdiorthoseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikdiorthoseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikdiorthoseisTableAdapter
    Friend WithEvents Diorthoseis4Pnl As System.Windows.Forms.Panel
    Friend WithEvents OverPnl As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents OverBtn As System.Windows.Forms.Button
    Friend WithEvents overPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OverBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OverTableAdapter As winhotel.dbhotelDataSetTableAdapters.overTableAdapter
End Class
