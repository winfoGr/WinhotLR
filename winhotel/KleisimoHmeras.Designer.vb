<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KleisimoHmeras
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κατάστ. Ελέγχου Παρ.")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Επανέκδοση")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Συγκ/τική Τιμολ.")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Φόροι Διαμονής")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τιμολόγια", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκτύπωση extra Παρ/κών")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκδοση extra Παρ/κών")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Extra Παραστατικά", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7})
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κατάσταση")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Εκδοση Γ.Ε.")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Λογαριασμοί Πελατών", New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode10})
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ελεγχος Αφίξεων")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κουτσ/κη")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("House Europe")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Γενικό")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Αθεώρ. Παρ/τικά")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Βιβλία Πόρτας", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κλείσιμο Ημέρας")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ακύρωση κλεισίματος")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Αναλυτική (Εμφ.)")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Συγκεντρ.  (Εκτ.)")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("αναλ. Κίνηση (Λογιστήριο)")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Αλλαγές Κινήσεων")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Τμήματα - Κίνηση", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21, TreeNode22, TreeNode23})
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Main Courante")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Daily Report")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Κατάστ. Αστυνομίας")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KleisimoHmeras))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.KleimoImerasTreeView = New System.Windows.Forms.TreeView()
        Me.KleisimoZentralPnl = New System.Windows.Forms.Panel()
        Me.KoutsPnl = New System.Windows.Forms.Panel()
        Me.KoutsBtn = New System.Windows.Forms.Button()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.KleisimoPnl = New System.Windows.Forms.Panel()
        Me.blinkLbl2 = New System.Windows.Forms.Label()
        Me.sendresidentsOK = New System.Windows.Forms.CheckBox()
        Me.kenaCkb = New System.Windows.Forms.CheckBox()
        Me.arrivalLbl = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.daysbeforeTbx = New System.Windows.Forms.TextBox()
        Me.questChk = New System.Windows.Forms.CheckBox()
        Me.directChk = New System.Windows.Forms.CheckBox()
        Me.KleisImerErgLbl = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.KleisimoPck1 = New System.Windows.Forms.DateTimePicker()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.KleisimoBtn = New System.Windows.Forms.Button()
        Me.HouseEuropePnl = New System.Windows.Forms.Panel()
        Me.HouseEuropeBtn = New System.Windows.Forms.Button()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.ForoiPnl = New System.Windows.Forms.Panel()
        Me.pistosiRdb = New System.Windows.Forms.RadioButton()
        Me.KartesRdb = New System.Windows.Forms.RadioButton()
        Me.MetrRdb = New System.Windows.Forms.RadioButton()
        Me.OloiRdb = New System.Windows.Forms.RadioButton()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.ForoiCbx = New System.Windows.Forms.ComboBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.ForoiPicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.ForoiPicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ForoiBtn = New System.Windows.Forms.Button()
        Me.SigkPnl = New System.Windows.Forms.Panel()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.sigkEkdCbx = New System.Windows.Forms.ComboBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.SigkPck2 = New System.Windows.Forms.DateTimePicker()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.SigkPck1 = New System.Windows.Forms.DateTimePicker()
        Me.SigkBtn = New System.Windows.Forms.Button()
        Me.ExtraParEktPnl = New System.Windows.Forms.Panel()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.ExtraParEktPck2 = New System.Windows.Forms.DateTimePicker()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.ExtraParEktPck1 = New System.Windows.Forms.DateTimePicker()
        Me.ExtraParEktBtn = New System.Windows.Forms.Button()
        Me.EkdosiApyPnl = New System.Windows.Forms.Panel()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.apyEkdCbx = New System.Windows.Forms.ComboBox()
        Me.EkdosiApy2Pnl = New System.Windows.Forms.Panel()
        Me.ForosChk = New System.Windows.Forms.CheckBox()
        Me.TimologioChk = New System.Windows.Forms.CheckBox()
        Me.EkdosiApy3Btn = New System.Windows.Forms.Button()
        Me.EkdosiApyTbx = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.WaitLbl = New System.Windows.Forms.Label()
        Me.EkdosiApy2Btn = New System.Windows.Forms.Button()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.EkdosiApy1Btn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.EkdosiApyPck = New System.Windows.Forms.DateTimePicker()
        Me.ZentralPnl = New System.Windows.Forms.Panel()
        Me.ButtonsPnl = New System.Windows.Forms.Panel()
        Me.SynolPnl = New System.Windows.Forms.Panel()
        Me.EkptosiLbl = New System.Windows.Forms.Label()
        Me.EkptosiBtn = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.PliromCbx = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.SynolLbl = New System.Windows.Forms.Label()
        Me.Kratiseis4Pnl = New System.Windows.Forms.Panel()
        Me.Kratiseis3Pnl = New System.Windows.Forms.Panel()
        Me.SimbLbl = New System.Windows.Forms.Label()
        Me.DwmSucheImeromBtn = New System.Windows.Forms.Button()
        Me.DwmatiaKratisisBtn = New System.Windows.Forms.Button()
        Me.NonShowLbl = New System.Windows.Forms.Label()
        Me.TimesBtn = New System.Windows.Forms.Button()
        Me.TipiCbx = New System.Windows.Forms.ComboBox()
        Me.KlinesCbx = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DwmatFreeBtn = New System.Windows.Forms.Button()
        Me.DwmTbx = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SimbCbx = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Kratiseis2Pnl = New System.Windows.Forms.Panel()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label155 = New System.Windows.Forms.Label()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.kwdEthnik2 = New System.Windows.Forms.TextBox()
        Me.kwdEthnik1 = New System.Windows.Forms.TextBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.PaidiTbx3 = New System.Windows.Forms.TextBox()
        Me.CotTbx3 = New System.Windows.Forms.TextBox()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EthnKwd2 = New System.Windows.Forms.TextBox()
        Me.EthnKwd1 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SimetTbx = New System.Windows.Forms.TextBox()
        Me.ApyBtn = New System.Windows.Forms.Button()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ProkatTbx = New System.Windows.Forms.TextBox()
        Me.EpithimTbx = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TilefTbx = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.EthnikTbx2 = New System.Windows.Forms.TextBox()
        Me.EthnAnzTbx2 = New System.Windows.Forms.TextBox()
        Me.EthnikTbx1 = New System.Windows.Forms.TextBox()
        Me.EthnAnzTbx1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PaidiTbx2 = New System.Windows.Forms.TextBox()
        Me.CotTbx2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PaidiTbx1 = New System.Windows.Forms.TextBox()
        Me.CotTbx1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OnomTbx3 = New System.Windows.Forms.TextBox()
        Me.OnomTbx2 = New System.Windows.Forms.TextBox()
        Me.OnomTbx1 = New System.Windows.Forms.TextBox()
        Me.EnilikTbx = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Kratiseis1Pnl = New System.Windows.Forms.Panel()
        Me.KwdPraktTbx2 = New System.Windows.Forms.TextBox()
        Me.KwdPraktTbx1 = New System.Windows.Forms.TextBox()
        Me.ImeromKratTbx = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.VoucherTbx = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.PraktTimolTbx = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PraktTbx = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.KratisiTbx = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.EtiketaErgHmPnl = New System.Windows.Forms.Panel()
        Me.EtikLbl = New System.Windows.Forms.Label()
        Me.AstyKatPnl = New System.Windows.Forms.Panel()
        Me.AstyKatRdb3 = New System.Windows.Forms.RadioButton()
        Me.AstyKatRdb1 = New System.Windows.Forms.RadioButton()
        Me.AstyKatRdb2 = New System.Windows.Forms.RadioButton()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.AstyKatBtn = New System.Windows.Forms.Button()
        Me.AstyKatPck = New System.Windows.Forms.DateTimePicker()
        Me.KatastElegxouPnl = New System.Windows.Forms.Panel()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.ApyCbx = New System.Windows.Forms.ComboBox()
        Me.KatastElegxouBtn = New System.Windows.Forms.Button()
        Me.KatastChkBoxPnl = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.KatastElegxPck = New System.Windows.Forms.DateTimePicker()
        Me.MetritoisPnl = New System.Windows.Forms.Panel()
        Me.MetritisSpeichPnl = New System.Windows.Forms.Panel()
        Me.DecoPnl = New System.Windows.Forms.Panel()
        Me.XPnl = New System.Windows.Forms.Panel()
        Me.Metritis1Pnl = New System.Windows.Forms.Panel()
        Me.PlirCbx = New System.Windows.Forms.ComboBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.EggrafiCbx = New System.Windows.Forms.ComboBox()
        Me.AitiaTbx = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TmimaTbx = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.KefalidaPnl = New System.Windows.Forms.Panel()
        Me.MaisonLbl = New System.Windows.Forms.Label()
        Me.PosoLbl = New System.Windows.Forms.Label()
        Me.FpaLbl = New System.Windows.Forms.Label()
        Me.FpaPnl = New System.Windows.Forms.Panel()
        Me.PosaPnl = New System.Windows.Forms.Panel()
        Me.EkdosiParastPnl = New System.Windows.Forms.Panel()
        Me.EkdosiParast2Pnl = New System.Windows.Forms.Panel()
        Me.EkdosiParastYpnosChk = New System.Windows.Forms.CheckBox()
        Me.EkdosiParastNeoBtn = New System.Windows.Forms.Button()
        Me.EkdosiParastKataxBtn = New System.Windows.Forms.Button()
        Me.EkdosiParastTrPliromCbx = New System.Windows.Forms.ComboBox()
        Me.EkdosiParastProkatabTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastEktBtn = New System.Windows.Forms.Button()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.EkdosiParastSynolaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastAllFpaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastDeipnoFpaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastGeumaFpaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastPrwinoFpaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastYpnosFpaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastAllTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastDeipnoTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastGeumaTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastPrwinoTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastYpnosTbx = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.EkdosiParast1Pnl = New System.Windows.Forms.Panel()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.ParastCbx = New System.Windows.Forms.ComboBox()
        Me.EkdosiParastParastFindeBtn = New System.Windows.Forms.Button()
        Me.EkdosiParastPraktTbx = New System.Windows.Forms.TextBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.EkdosiParastParastAitTbx = New System.Windows.Forms.TextBox()
        Me.EkdosiParastAATbx = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.EkdosiParastParastCbx = New System.Windows.Forms.ComboBox()
        Me.EkdosiParastPck = New System.Windows.Forms.DateTimePicker()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.BiblPortasPnl = New System.Windows.Forms.Panel()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ProxeirRdb = New System.Windows.Forms.RadioButton()
        Me.TheorimRdb = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MorfiRdb1 = New System.Windows.Forms.RadioButton()
        Me.MorfiRdb2 = New System.Windows.Forms.RadioButton()
        Me.BiblPortasBtn = New System.Windows.Forms.Button()
        Me.DailyReportPnl = New System.Windows.Forms.Panel()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.DailyReportTbx = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.DialyReportBtn = New System.Windows.Forms.Button()
        Me.DailyReportPck = New System.Windows.Forms.DateTimePicker()
        Me.MainCourantePnl = New System.Windows.Forms.Panel()
        Me.MainCouranteRdb1 = New System.Windows.Forms.RadioButton()
        Me.MainCouranteRdb2 = New System.Windows.Forms.RadioButton()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.MainCouranteBtn = New System.Windows.Forms.Button()
        Me.MainCourantePck = New System.Windows.Forms.DateTimePicker()
        Me.EkdosiGEMazikiPnl = New System.Windows.Forms.Panel()
        Me.EkdosiGEMazikiRdb1 = New System.Windows.Forms.RadioButton()
        Me.EkdosiGEMazikiRdb2 = New System.Windows.Forms.RadioButton()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.EkdosiGEMazikiBtn = New System.Windows.Forms.Button()
        Me.EkdosiGEMazikiPck = New System.Windows.Forms.DateTimePicker()
        Me.AkyrosiPnl = New System.Windows.Forms.Panel()
        Me.AkyrosiChk = New System.Windows.Forms.CheckBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.AkyrosiPck2 = New System.Windows.Forms.DateTimePicker()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.AkyrosiPck1 = New System.Windows.Forms.DateTimePicker()
        Me.AkyrosiBtn = New System.Windows.Forms.Button()
        Me.LogarAnaxPnl = New System.Windows.Forms.Panel()
        Me.LogRdb1 = New System.Windows.Forms.RadioButton()
        Me.LogRdb2 = New System.Windows.Forms.RadioButton()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.LogarAnaxBtn = New System.Windows.Forms.Button()
        Me.LogarAnaxPck = New System.Windows.Forms.DateTimePicker()
        Me.BiblPortApyPnl = New System.Windows.Forms.Panel()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.BiblPortApyPck = New System.Windows.Forms.DateTimePicker()
        Me.BiblPortApyBtn = New System.Windows.Forms.Button()
        Me.TmimSigkentrPnl = New System.Windows.Forms.Panel()
        Me.TmimSigkentr2Pnl = New System.Windows.Forms.Panel()
        Me.TmimSigkentrPnlerCbx = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TmimSigkentrBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TmimSigkentrPnlerPck = New System.Windows.Forms.DateTimePicker()
        Me.LogistirioEktPnl = New System.Windows.Forms.Panel()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.LogistirioEkt1Pnl = New System.Windows.Forms.Panel()
        Me.LogistirioEktBtn = New System.Windows.Forms.Button()
        Me.Logistirio4Rdb = New System.Windows.Forms.RadioButton()
        Me.Logistirio3Rdb = New System.Windows.Forms.RadioButton()
        Me.Logistirio2Rdb = New System.Windows.Forms.RadioButton()
        Me.Logistirio1Rdb = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Logistirio2Pck = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Logistirio1Pck = New System.Windows.Forms.DateTimePicker()
        Me.TmimataKnsPnl = New System.Windows.Forms.Panel()
        Me.TmimataKns2Pnl = New System.Windows.Forms.Panel()
        Me.TmimataKns1Pnl = New System.Windows.Forms.Panel()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TmimKnsImerom = New System.Windows.Forms.DateTimePicker()
        Me.TmimataTmTbx = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.EtiketaPnl = New System.Windows.Forms.Panel()
        Me.EtiketaLbl = New System.Windows.Forms.Label()
        Me.DbhotelDataSet = New winhotel.dbhotelDataSet()
        Me.KratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter()
        Me.DbhotelDataSet1 = New winhotel.dbhotelDataSet1()
        Me.KratiseisBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisTableAdapter1 = New winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter()
        Me.TableAdapterManager = New winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager()
        Me.Vilapraktoreia1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Vilapraktoreia1TableAdapter = New winhotel.dbhotelDataSet1TableAdapters.vilapraktoreia1TableAdapter()
        Me.LogariasmoianaxwrountwnBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TipoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter()
        Me.KlinesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KlinesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter()
        Me.EthnikotitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EthnikotitesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter()
        Me.KatigoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatigoriesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter()
        Me.DwmatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DwmatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter()
        Me.ParastatikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ParastatikaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter()
        Me.XrewseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter()
        Me.PistwtikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PistwtikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.pistwtikesTableAdapter()
        Me.PraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter()
        Me.EtaireiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EtaireiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter()
        Me.BiblioportasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BiblioportasTableAdapter = New winhotel.dbhotelDataSetTableAdapters.biblioportasTableAdapter()
        Me.KatastasiapyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KatastasiapyTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katastasiapyTableAdapter()
        Me.KratiseisenilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KratiseisenilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter()
        Me.LogariasmoianaxwrountwnTableAdapter = New winhotel.dbhotelDataSetTableAdapters.logariasmoianaxwrountwnTableAdapter()
        Me.EpanekdositimologiouBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EpanekdositimologiouTableAdapter = New winhotel.dbhotelDataSetTableAdapters.epanekdositimologiouTableAdapter()
        Me.TimologiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter()
        Me.TimologioanalysisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimologioanalysisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timologioanalysisTableAdapter()
        Me.KratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XrewseispraktoreiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter()
        Me.TmimataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TmimataTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter()
        Me.SimbolaiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimbolaiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter()
        Me.PaidiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PaidiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.paidiaTableAdapter()
        Me.EnilikesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EnilikesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.enilikesTableAdapter()
        Me.TouristperiodoiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TouristperiodoiTableAdapter = New winhotel.dbhotelDataSetTableAdapters.touristperiodoiTableAdapter()
        Me.AllotmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AllotmentTableAdapter = New winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter()
        Me.TimeskratisisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimeskratisisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timeskratisisTableAdapter()
        Me.TimesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.timesTableAdapter()
        Me.SimfoniesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimfoniesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.simfoniesTableAdapter()
        Me.StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StatusTableAdapter = New winhotel.dbhotelDataSetTableAdapters.statusTableAdapter()
        Me.OverBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OverTableAdapter = New winhotel.dbhotelDataSetTableAdapters.overTableAdapter()
        Me.OverunterkuenfteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OverunterkuenfteTableAdapter = New winhotel.dbhotelDataSetTableAdapters.overunterkuenfteTableAdapter()
        Me.TmimataegrafesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TmimataegrafesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.tmimataegrafesTableAdapter()
        Me.ApyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ApyTableAdapter = New winhotel.dbhotelDataSetTableAdapters.apyTableAdapter()
        Me.EggrafitakiniseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EggrafitakiniseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.eggrafitakiniseisTableAdapter()
        Me.KiniseisjoineggrafesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KiniseisjoineggrafesTableAdapter = New winhotel.dbhotelDataSetTableAdapters.kiniseisjoineggrafesTableAdapter()
        Me.GramatiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GramatiaTableAdapter = New winhotel.dbhotelDataSetTableAdapters.gramatiaTableAdapter()
        Me.LogariasmoidiamBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LogariasmoidiamTableAdapter = New winhotel.dbhotelDataSetTableAdapters.logariasmoidiamTableAdapter()
        Me.Main_curanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Main_curanteTableAdapter = New winhotel.dbhotelDataSetTableAdapters.main_curanteTableAdapter()
        Me.Katastasi_astynomiasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Katastasi_astynomiasTableAdapter = New winhotel.dbhotelDataSetTableAdapters.katastasi_astynomiasTableAdapter()
        Me.NonshowkratiseisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NonshowkratiseisTableAdapter = New winhotel.dbhotelDataSetTableAdapters.nonshowkratiseisTableAdapter()
        Me.CalendarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CalendarTableAdapter = New winhotel.dbhotelDataSetTableAdapters.calendarTableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.KleisimoZentralPnl.SuspendLayout()
        Me.KoutsPnl.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.KleisimoPnl.SuspendLayout()
        Me.HouseEuropePnl.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.ForoiPnl.SuspendLayout()
        Me.SigkPnl.SuspendLayout()
        Me.ExtraParEktPnl.SuspendLayout()
        Me.EkdosiApyPnl.SuspendLayout()
        Me.EkdosiApy2Pnl.SuspendLayout()
        Me.ZentralPnl.SuspendLayout()
        Me.SynolPnl.SuspendLayout()
        Me.Kratiseis3Pnl.SuspendLayout()
        Me.Kratiseis2Pnl.SuspendLayout()
        Me.Kratiseis1Pnl.SuspendLayout()
        Me.EtiketaErgHmPnl.SuspendLayout()
        Me.AstyKatPnl.SuspendLayout()
        Me.KatastElegxouPnl.SuspendLayout()
        Me.MetritoisPnl.SuspendLayout()
        Me.Metritis1Pnl.SuspendLayout()
        Me.KefalidaPnl.SuspendLayout()
        Me.EkdosiParastPnl.SuspendLayout()
        Me.EkdosiParast2Pnl.SuspendLayout()
        Me.EkdosiParast1Pnl.SuspendLayout()
        Me.BiblPortasPnl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.DailyReportPnl.SuspendLayout()
        Me.MainCourantePnl.SuspendLayout()
        Me.EkdosiGEMazikiPnl.SuspendLayout()
        Me.AkyrosiPnl.SuspendLayout()
        Me.LogarAnaxPnl.SuspendLayout()
        Me.BiblPortApyPnl.SuspendLayout()
        Me.TmimSigkentrPnl.SuspendLayout()
        Me.TmimSigkentr2Pnl.SuspendLayout()
        Me.LogistirioEktPnl.SuspendLayout()
        Me.LogistirioEkt1Pnl.SuspendLayout()
        Me.TmimataKnsPnl.SuspendLayout()
        Me.TmimataKns1Pnl.SuspendLayout()
        Me.EtiketaPnl.SuspendLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vilapraktoreia1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogariasmoianaxwrountwnBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PistwtikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BiblioportasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KatastasiapyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EpanekdositimologiouBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimologioanalysisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaidiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnilikesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TouristperiodoiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeskratisisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimfoniesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OverunterkuenfteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TmimataegrafesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EggrafitakiniseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KiniseisjoineggrafesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GramatiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogariasmoidiamBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Main_curanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Katastasi_astynomiasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NonshowkratiseisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalendarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.KleimoImerasTreeView)
        Me.SplitContainer1.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.KleisimoZentralPnl)
        Me.SplitContainer1.Size = New System.Drawing.Size(1429, 965)
        Me.SplitContainer1.SplitterDistance = 249
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'KleimoImerasTreeView
        '
        Me.KleimoImerasTreeView.BackColor = System.Drawing.SystemColors.Control
        Me.KleimoImerasTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KleimoImerasTreeView.Location = New System.Drawing.Point(0, 0)
        Me.KleimoImerasTreeView.Margin = New System.Windows.Forms.Padding(4)
        Me.KleimoImerasTreeView.Name = "KleimoImerasTreeView"
        TreeNode1.BackColor = System.Drawing.SystemColors.Control
        TreeNode1.Name = "katast_elegxou"
        TreeNode1.Text = "Κατάστ. Ελέγχου Παρ."
        TreeNode2.BackColor = System.Drawing.Color.Yellow
        TreeNode2.ForeColor = System.Drawing.Color.Maroon
        TreeNode2.Name = "ekdosi_apy"
        TreeNode2.Text = "Επανέκδοση"
        TreeNode3.BackColor = System.Drawing.Color.Yellow
        TreeNode3.ForeColor = System.Drawing.Color.Blue
        TreeNode3.Name = "Sigkentrotiki"
        TreeNode3.Text = "Συγκ/τική Τιμολ."
        TreeNode4.BackColor = System.Drawing.Color.Yellow
        TreeNode4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        TreeNode4.Name = "Foroi"
        TreeNode4.Text = "Φόροι Διαμονής"
        TreeNode5.BackColor = System.Drawing.Color.Yellow
        TreeNode5.Name = "Node0"
        TreeNode5.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode5.Text = "Τιμολόγια"
        TreeNode6.Name = "ektiposi_extra_par"
        TreeNode6.Text = "Εκτύπωση extra Παρ/κών"
        TreeNode7.Name = "ekdosi_extra_parastatikwn"
        TreeNode7.Text = "Εκδοση extra Παρ/κών"
        TreeNode8.BackColor = System.Drawing.Color.Transparent
        TreeNode8.Name = "extra_node"
        TreeNode8.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode8.Text = "Extra Παραστατικά"
        TreeNode9.Name = "logariasmoi_pelatwn"
        TreeNode9.Text = "Κατάσταση"
        TreeNode10.Name = "ekdosi_ge"
        TreeNode10.Text = "Εκδοση Γ.Ε."
        TreeNode11.BackColor = System.Drawing.Color.Transparent
        TreeNode11.Name = "Node0"
        TreeNode11.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode11.Text = "Λογαριασμοί Πελατών"
        TreeNode12.BackColor = System.Drawing.Color.Yellow
        TreeNode12.Name = "elegxos_afixewn"
        TreeNode12.Text = "Ελεγχος Αφίξεων"
        TreeNode13.BackColor = System.Drawing.Color.Yellow
        TreeNode13.Name = "koutsour"
        TreeNode13.Text = "Κουτσ/κη"
        TreeNode14.BackColor = System.Drawing.Color.Yellow
        TreeNode14.Name = "europe"
        TreeNode14.Text = "House Europe"
        TreeNode15.BackColor = System.Drawing.Color.Yellow
        TreeNode15.Name = "ekt_biblio_portas"
        TreeNode15.Text = "Γενικό"
        TreeNode16.BackColor = System.Drawing.SystemColors.Control
        TreeNode16.Name = "ekt_atheorita_apy"
        TreeNode16.Text = "Αθεώρ. Παρ/τικά"
        TreeNode17.BackColor = System.Drawing.Color.Yellow
        TreeNode17.Name = "biblio_portas"
        TreeNode17.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode17.Text = "Βιβλία Πόρτας"
        TreeNode18.BackColor = System.Drawing.Color.Yellow
        TreeNode18.Name = "kleisimo_imeras"
        TreeNode18.Text = "Κλείσιμο Ημέρας"
        TreeNode19.Name = "akyrosi_kleisimatos"
        TreeNode19.Text = "Ακύρωση κλεισίματος"
        TreeNode20.Name = "emf_anal_kin_imeras"
        TreeNode20.Text = "Αναλυτική (Εμφ.)"
        TreeNode21.Name = "ekt_sigkentr_kin_imeras"
        TreeNode21.Text = "Συγκεντρ.  (Εκτ.)"
        TreeNode22.Name = "ekt_logistirio"
        TreeNode22.Text = "αναλ. Κίνηση (Λογιστήριο)"
        TreeNode23.Name = "allages_kinisi_tmimatwn"
        TreeNode23.Text = "Αλλαγές Κινήσεων"
        TreeNode24.Name = "tmimata_kinisi"
        TreeNode24.NodeFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        TreeNode24.Text = "Τμήματα - Κίνηση"
        TreeNode25.BackColor = System.Drawing.Color.Transparent
        TreeNode25.Name = "main_courante"
        TreeNode25.Text = "Main Courante"
        TreeNode26.BackColor = System.Drawing.Color.Transparent
        TreeNode26.Name = "daily_report"
        TreeNode26.Text = "Daily Report"
        TreeNode27.BackColor = System.Drawing.Color.Yellow
        TreeNode27.Name = "asty_kat"
        TreeNode27.Text = "Κατάστ. Αστυνομίας"
        Me.KleimoImerasTreeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode8, TreeNode11, TreeNode12, TreeNode17, TreeNode18, TreeNode19, TreeNode24, TreeNode25, TreeNode26, TreeNode27})
        Me.KleimoImerasTreeView.Size = New System.Drawing.Size(245, 961)
        Me.KleimoImerasTreeView.TabIndex = 0
        '
        'KleisimoZentralPnl
        '
        Me.KleisimoZentralPnl.AutoScroll = True
        Me.KleisimoZentralPnl.BackColor = System.Drawing.SystemColors.Control
        Me.KleisimoZentralPnl.Controls.Add(Me.KoutsPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.KleisimoPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.HouseEuropePnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.ForoiPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.SigkPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.ExtraParEktPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.EkdosiApyPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.ZentralPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.AstyKatPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.KatastElegxouPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.MetritoisPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.EkdosiParastPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.BiblPortasPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.DailyReportPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.MainCourantePnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.EkdosiGEMazikiPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.AkyrosiPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.LogarAnaxPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.BiblPortApyPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.TmimSigkentrPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.LogistirioEktPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.TmimataKnsPnl)
        Me.KleisimoZentralPnl.Controls.Add(Me.EtiketaPnl)
        Me.KleisimoZentralPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KleisimoZentralPnl.Location = New System.Drawing.Point(16, 946)
        Me.KleisimoZentralPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KleisimoZentralPnl.Name = "KleisimoZentralPnl"
        Me.KleisimoZentralPnl.Size = New System.Drawing.Size(1120, 10)
        Me.KleisimoZentralPnl.TabIndex = 0
        '
        'KoutsPnl
        '
        Me.KoutsPnl.BackColor = System.Drawing.SystemColors.ControlLight
        Me.KoutsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KoutsPnl.Controls.Add(Me.KoutsBtn)
        Me.KoutsPnl.Controls.Add(Me.Label66)
        Me.KoutsPnl.Controls.Add(Me.Panel4)
        Me.KoutsPnl.Location = New System.Drawing.Point(93, 340)
        Me.KoutsPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KoutsPnl.Name = "KoutsPnl"
        Me.KoutsPnl.Size = New System.Drawing.Size(447, 12)
        Me.KoutsPnl.TabIndex = 44
        '
        'KoutsBtn
        '
        Me.KoutsBtn.BackColor = System.Drawing.Color.Gainsboro
        Me.KoutsBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KoutsBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KoutsBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.KoutsBtn.Image = Global.winhotel.My.Resources.Resources.B06
        Me.KoutsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KoutsBtn.Location = New System.Drawing.Point(117, 110)
        Me.KoutsBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.KoutsBtn.Name = "KoutsBtn"
        Me.KoutsBtn.Size = New System.Drawing.Size(175, 39)
        Me.KoutsBtn.TabIndex = 58
        Me.KoutsBtn.Text = "Βιβλίο Πόρτας"
        Me.KoutsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KoutsBtn.UseVisualStyleBackColor = False
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label66.Location = New System.Drawing.Point(16, 18)
        Me.Label66.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(124, 20)
        Me.Label66.TabIndex = 57
        Me.Label66.Text = "Koutsourakis:"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.RadioButton5)
        Me.Panel4.Controls.Add(Me.RadioButton6)
        Me.Panel4.Location = New System.Drawing.Point(45, 43)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(339, 38)
        Me.Panel4.TabIndex = 55
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton5.Checked = True
        Me.RadioButton5.ForeColor = System.Drawing.Color.Navy
        Me.RadioButton5.Location = New System.Drawing.Point(11, 7)
        Me.RadioButton5.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(105, 24)
        Me.RadioButton5.TabIndex = 53
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Με τιμές"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton6.ForeColor = System.Drawing.Color.Navy
        Me.RadioButton6.Location = New System.Drawing.Point(164, 7)
        Me.RadioButton6.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(134, 24)
        Me.RadioButton6.TabIndex = 54
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Χωρίς Τιμές"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'KleisimoPnl
        '
        Me.KleisimoPnl.BackColor = System.Drawing.Color.Silver
        Me.KleisimoPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.KleisimoPnl.Controls.Add(Me.blinkLbl2)
        Me.KleisimoPnl.Controls.Add(Me.sendresidentsOK)
        Me.KleisimoPnl.Controls.Add(Me.kenaCkb)
        Me.KleisimoPnl.Controls.Add(Me.arrivalLbl)
        Me.KleisimoPnl.Controls.Add(Me.Label57)
        Me.KleisimoPnl.Controls.Add(Me.Label56)
        Me.KleisimoPnl.Controls.Add(Me.daysbeforeTbx)
        Me.KleisimoPnl.Controls.Add(Me.questChk)
        Me.KleisimoPnl.Controls.Add(Me.directChk)
        Me.KleisimoPnl.Controls.Add(Me.KleisImerErgLbl)
        Me.KleisimoPnl.Controls.Add(Me.Label42)
        Me.KleisimoPnl.Controls.Add(Me.KleisimoPck1)
        Me.KleisimoPnl.Controls.Add(Me.Label41)
        Me.KleisimoPnl.Controls.Add(Me.KleisimoBtn)
        Me.KleisimoPnl.Location = New System.Drawing.Point(108, 18)
        Me.KleisimoPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KleisimoPnl.Name = "KleisimoPnl"
        Me.KleisimoPnl.Size = New System.Drawing.Size(581, 10)
        Me.KleisimoPnl.TabIndex = 44
        '
        'blinkLbl2
        '
        Me.blinkLbl2.AutoSize = True
        Me.blinkLbl2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.blinkLbl2.Location = New System.Drawing.Point(35, 9)
        Me.blinkLbl2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.blinkLbl2.Name = "blinkLbl2"
        Me.blinkLbl2.Size = New System.Drawing.Size(0, 20)
        Me.blinkLbl2.TabIndex = 71
        '
        'sendresidentsOK
        '
        Me.sendresidentsOK.AutoSize = True
        Me.sendresidentsOK.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.sendresidentsOK.Enabled = False
        Me.sendresidentsOK.Location = New System.Drawing.Point(241, 197)
        Me.sendresidentsOK.Margin = New System.Windows.Forms.Padding(4)
        Me.sendresidentsOK.Name = "sendresidentsOK"
        Me.sendresidentsOK.Size = New System.Drawing.Size(183, 24)
        Me.sendresidentsOK.TabIndex = 70
        Me.sendresidentsOK.Text = "send to Residents"
        Me.sendresidentsOK.UseVisualStyleBackColor = True
        '
        'kenaCkb
        '
        Me.kenaCkb.AutoSize = True
        Me.kenaCkb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.kenaCkb.Location = New System.Drawing.Point(31, 197)
        Me.kenaCkb.Margin = New System.Windows.Forms.Padding(4)
        Me.kenaCkb.Name = "kenaCkb"
        Me.kenaCkb.Size = New System.Drawing.Size(162, 24)
        Me.kenaCkb.TabIndex = 69
        Me.kenaCkb.Text = "έλεγχος κενών "
        Me.kenaCkb.UseVisualStyleBackColor = True
        '
        'arrivalLbl
        '
        Me.arrivalLbl.AutoSize = True
        Me.arrivalLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.arrivalLbl.ForeColor = System.Drawing.Color.Maroon
        Me.arrivalLbl.Location = New System.Drawing.Point(379, 156)
        Me.arrivalLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.arrivalLbl.Name = "arrivalLbl"
        Me.arrivalLbl.Size = New System.Drawing.Size(0, 17)
        Me.arrivalLbl.TabIndex = 68
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.Transparent
        Me.Label57.Location = New System.Drawing.Point(372, 132)
        Me.Label57.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(82, 18)
        Me.Label57.TabIndex = 67
        Me.Label57.Text = "σε Αφίξεις:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.ForeColor = System.Drawing.Color.Black
        Me.Label56.Location = New System.Drawing.Point(219, 155)
        Me.Label56.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(113, 20)
        Me.Label56.TabIndex = 66
        Me.Label56.Text = "days before:"
        '
        'daysbeforeTbx
        '
        Me.daysbeforeTbx.Enabled = False
        Me.daysbeforeTbx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.daysbeforeTbx.Location = New System.Drawing.Point(348, 151)
        Me.daysbeforeTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.daysbeforeTbx.MaxLength = 2
        Me.daysbeforeTbx.Name = "daysbeforeTbx"
        Me.daysbeforeTbx.Size = New System.Drawing.Size(29, 26)
        Me.daysbeforeTbx.TabIndex = 66
        Me.daysbeforeTbx.Text = "15"
        '
        'questChk
        '
        Me.questChk.AutoSize = True
        Me.questChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.questChk.Enabled = False
        Me.questChk.Location = New System.Drawing.Point(7, 114)
        Me.questChk.Margin = New System.Windows.Forms.Padding(4)
        Me.questChk.Name = "questChk"
        Me.questChk.Size = New System.Drawing.Size(190, 24)
        Me.questChk.TabIndex = 64
        Me.questChk.Text = "send questionnaire"
        Me.questChk.UseVisualStyleBackColor = True
        '
        'directChk
        '
        Me.directChk.AutoSize = True
        Me.directChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.directChk.Enabled = False
        Me.directChk.Location = New System.Drawing.Point(31, 154)
        Me.directChk.Margin = New System.Windows.Forms.Padding(4)
        Me.directChk.Name = "directChk"
        Me.directChk.Size = New System.Drawing.Size(160, 24)
        Me.directChk.TabIndex = 65
        Me.directChk.Text = "send directions"
        Me.directChk.UseVisualStyleBackColor = True
        '
        'KleisImerErgLbl
        '
        Me.KleisImerErgLbl.AutoSize = True
        Me.KleisImerErgLbl.ForeColor = System.Drawing.Color.Brown
        Me.KleisImerErgLbl.Location = New System.Drawing.Point(247, 28)
        Me.KleisImerErgLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.KleisImerErgLbl.Name = "KleisImerErgLbl"
        Me.KleisImerErgLbl.Size = New System.Drawing.Size(143, 20)
        Me.KleisImerErgLbl.TabIndex = 62
        Me.KleisImerErgLbl.Text = "KleisImerErgLbl"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(27, 73)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(154, 20)
        Me.Label42.TabIndex = 61
        Me.Label42.Text = "Νέα Ημερομηνία:"
        '
        'KleisimoPck1
        '
        Me.KleisimoPck1.CustomFormat = "dd/MM/YYYY"
        Me.KleisimoPck1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.KleisimoPck1.Location = New System.Drawing.Point(204, 69)
        Me.KleisimoPck1.Margin = New System.Windows.Forms.Padding(4)
        Me.KleisimoPck1.Name = "KleisimoPck1"
        Me.KleisimoPck1.Size = New System.Drawing.Size(180, 26)
        Me.KleisimoPck1.TabIndex = 60
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(8, 28)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(216, 20)
        Me.Label41.TabIndex = 59
        Me.Label41.Text = "Ημερομηνία πού κλείνει:"
        '
        'KleisimoBtn
        '
        Me.KleisimoBtn.BackColor = System.Drawing.Color.White
        Me.KleisimoBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KleisimoBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KleisimoBtn.ForeColor = System.Drawing.Color.Maroon
        Me.KleisimoBtn.Image = Global.winhotel.My.Resources.Resources.OK
        Me.KleisimoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KleisimoBtn.Location = New System.Drawing.Point(200, 251)
        Me.KleisimoBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.KleisimoBtn.Name = "KleisimoBtn"
        Me.KleisimoBtn.Size = New System.Drawing.Size(71, 39)
        Me.KleisimoBtn.TabIndex = 67
        Me.KleisimoBtn.Text = "ΟΚ"
        Me.KleisimoBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.KleisimoBtn.UseVisualStyleBackColor = False
        '
        'HouseEuropePnl
        '
        Me.HouseEuropePnl.BackColor = System.Drawing.SystemColors.Control
        Me.HouseEuropePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HouseEuropePnl.Controls.Add(Me.HouseEuropeBtn)
        Me.HouseEuropePnl.Controls.Add(Me.Label67)
        Me.HouseEuropePnl.Controls.Add(Me.Panel5)
        Me.HouseEuropePnl.Location = New System.Drawing.Point(535, 250)
        Me.HouseEuropePnl.Margin = New System.Windows.Forms.Padding(4)
        Me.HouseEuropePnl.Name = "HouseEuropePnl"
        Me.HouseEuropePnl.Size = New System.Drawing.Size(447, 12)
        Me.HouseEuropePnl.TabIndex = 43
        '
        'HouseEuropeBtn
        '
        Me.HouseEuropeBtn.BackColor = System.Drawing.Color.Silver
        Me.HouseEuropeBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HouseEuropeBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.HouseEuropeBtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HouseEuropeBtn.Image = Global.winhotel.My.Resources.Resources.B06
        Me.HouseEuropeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HouseEuropeBtn.Location = New System.Drawing.Point(119, 126)
        Me.HouseEuropeBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.HouseEuropeBtn.Name = "HouseEuropeBtn"
        Me.HouseEuropeBtn.Size = New System.Drawing.Size(175, 39)
        Me.HouseEuropeBtn.TabIndex = 58
        Me.HouseEuropeBtn.Text = "Βιβλίο Πόρτας"
        Me.HouseEuropeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.HouseEuropeBtn.UseVisualStyleBackColor = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label67.Location = New System.Drawing.Point(16, 28)
        Me.Label67.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(156, 20)
        Me.Label67.TabIndex = 57
        Me.Label67.Text = "House of Europe:"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.RadioButton7)
        Me.Panel5.Controls.Add(Me.RadioButton8)
        Me.Panel5.Location = New System.Drawing.Point(45, 53)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(339, 38)
        Me.Panel5.TabIndex = 55
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton7.Checked = True
        Me.RadioButton7.ForeColor = System.Drawing.Color.Navy
        Me.RadioButton7.Location = New System.Drawing.Point(11, 7)
        Me.RadioButton7.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(105, 24)
        Me.RadioButton7.TabIndex = 53
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "Με τιμές"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton8.ForeColor = System.Drawing.Color.Navy
        Me.RadioButton8.Location = New System.Drawing.Point(164, 7)
        Me.RadioButton8.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(134, 24)
        Me.RadioButton8.TabIndex = 54
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "Χωρίς Τιμές"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'ForoiPnl
        '
        Me.ForoiPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ForoiPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ForoiPnl.Controls.Add(Me.pistosiRdb)
        Me.ForoiPnl.Controls.Add(Me.KartesRdb)
        Me.ForoiPnl.Controls.Add(Me.MetrRdb)
        Me.ForoiPnl.Controls.Add(Me.OloiRdb)
        Me.ForoiPnl.Controls.Add(Me.Label65)
        Me.ForoiPnl.Controls.Add(Me.ForoiCbx)
        Me.ForoiPnl.Controls.Add(Me.Label63)
        Me.ForoiPnl.Controls.Add(Me.ForoiPicker2)
        Me.ForoiPnl.Controls.Add(Me.Label64)
        Me.ForoiPnl.Controls.Add(Me.ForoiPicker1)
        Me.ForoiPnl.Controls.Add(Me.ForoiBtn)
        Me.ForoiPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ForoiPnl.Location = New System.Drawing.Point(517, 73)
        Me.ForoiPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ForoiPnl.Name = "ForoiPnl"
        Me.ForoiPnl.Size = New System.Drawing.Size(467, 10)
        Me.ForoiPnl.TabIndex = 55
        '
        'pistosiRdb
        '
        Me.pistosiRdb.AutoSize = True
        Me.pistosiRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.pistosiRdb.Location = New System.Drawing.Point(319, 135)
        Me.pistosiRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.pistosiRdb.Name = "pistosiRdb"
        Me.pistosiRdb.Size = New System.Drawing.Size(115, 21)
        Me.pistosiRdb.TabIndex = 72
        Me.pistosiRdb.Text = "επί Πιστώση"
        Me.pistosiRdb.UseVisualStyleBackColor = True
        '
        'KartesRdb
        '
        Me.KartesRdb.AutoSize = True
        Me.KartesRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KartesRdb.Location = New System.Drawing.Point(213, 135)
        Me.KartesRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.KartesRdb.Name = "KartesRdb"
        Me.KartesRdb.Size = New System.Drawing.Size(82, 21)
        Me.KartesRdb.TabIndex = 71
        Me.KartesRdb.Text = "Κάρτες"
        Me.KartesRdb.UseVisualStyleBackColor = True
        '
        'MetrRdb
        '
        Me.MetrRdb.AutoSize = True
        Me.MetrRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MetrRdb.Location = New System.Drawing.Point(85, 135)
        Me.MetrRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.MetrRdb.Name = "MetrRdb"
        Me.MetrRdb.Size = New System.Drawing.Size(105, 21)
        Me.MetrRdb.TabIndex = 70
        Me.MetrRdb.Text = "Μετρητοίς"
        Me.MetrRdb.UseVisualStyleBackColor = True
        '
        'OloiRdb
        '
        Me.OloiRdb.AutoSize = True
        Me.OloiRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OloiRdb.Checked = True
        Me.OloiRdb.Location = New System.Drawing.Point(12, 135)
        Me.OloiRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.OloiRdb.Name = "OloiRdb"
        Me.OloiRdb.Size = New System.Drawing.Size(62, 21)
        Me.OloiRdb.TabIndex = 69
        Me.OloiRdb.TabStop = True
        Me.OloiRdb.Text = "Ολοι"
        Me.OloiRdb.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(47, 18)
        Me.Label65.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(74, 17)
        Me.Label65.TabIndex = 66
        Me.Label65.Text = "Εταιρεία:"
        '
        'ForoiCbx
        '
        Me.ForoiCbx.ForeColor = System.Drawing.Color.Maroon
        Me.ForoiCbx.FormattingEnabled = True
        Me.ForoiCbx.Location = New System.Drawing.Point(137, 15)
        Me.ForoiCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.ForoiCbx.Name = "ForoiCbx"
        Me.ForoiCbx.Size = New System.Drawing.Size(215, 25)
        Me.ForoiCbx.TabIndex = 65
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.ForeColor = System.Drawing.Color.Black
        Me.Label63.Location = New System.Drawing.Point(36, 108)
        Me.Label63.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(50, 17)
        Me.Label63.TabIndex = 64
        Me.Label63.Text = "μέχρι:"
        '
        'ForoiPicker2
        '
        Me.ForoiPicker2.CustomFormat = "dd/MM/yy"
        Me.ForoiPicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ForoiPicker2.Location = New System.Drawing.Point(129, 98)
        Me.ForoiPicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.ForoiPicker2.Name = "ForoiPicker2"
        Me.ForoiPicker2.Size = New System.Drawing.Size(188, 23)
        Me.ForoiPicker2.TabIndex = 63
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Location = New System.Drawing.Point(44, 68)
        Me.Label64.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(45, 17)
        Me.Label64.TabIndex = 61
        Me.Label64.Text = "από :"
        '
        'ForoiPicker1
        '
        Me.ForoiPicker1.CustomFormat = "dd/MM/yy"
        Me.ForoiPicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ForoiPicker1.Location = New System.Drawing.Point(131, 58)
        Me.ForoiPicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.ForoiPicker1.Name = "ForoiPicker1"
        Me.ForoiPicker1.Size = New System.Drawing.Size(188, 23)
        Me.ForoiPicker1.TabIndex = 60
        '
        'ForoiBtn
        '
        Me.ForoiBtn.BackColor = System.Drawing.Color.White
        Me.ForoiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ForoiBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ForoiBtn.ForeColor = System.Drawing.Color.Black
        Me.ForoiBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.ForoiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ForoiBtn.Location = New System.Drawing.Point(113, 174)
        Me.ForoiBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.ForoiBtn.Name = "ForoiBtn"
        Me.ForoiBtn.Size = New System.Drawing.Size(197, 39)
        Me.ForoiBtn.TabIndex = 50
        Me.ForoiBtn.Text = "Προεπισκόπηση"
        Me.ForoiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ForoiBtn.UseVisualStyleBackColor = False
        '
        'SigkPnl
        '
        Me.SigkPnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SigkPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SigkPnl.Controls.Add(Me.Label62)
        Me.SigkPnl.Controls.Add(Me.sigkEkdCbx)
        Me.SigkPnl.Controls.Add(Me.Label60)
        Me.SigkPnl.Controls.Add(Me.SigkPck2)
        Me.SigkPnl.Controls.Add(Me.Label61)
        Me.SigkPnl.Controls.Add(Me.SigkPck1)
        Me.SigkPnl.Controls.Add(Me.SigkBtn)
        Me.SigkPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SigkPnl.Location = New System.Drawing.Point(28, 139)
        Me.SigkPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.SigkPnl.Name = "SigkPnl"
        Me.SigkPnl.Size = New System.Drawing.Size(467, 10)
        Me.SigkPnl.TabIndex = 54
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(69, 22)
        Me.Label62.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(74, 17)
        Me.Label62.TabIndex = 66
        Me.Label62.Text = "Εταιρεία:"
        '
        'sigkEkdCbx
        '
        Me.sigkEkdCbx.FormattingEnabled = True
        Me.sigkEkdCbx.Location = New System.Drawing.Point(172, 17)
        Me.sigkEkdCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.sigkEkdCbx.Name = "sigkEkdCbx"
        Me.sigkEkdCbx.Size = New System.Drawing.Size(160, 25)
        Me.sigkEkdCbx.TabIndex = 65
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(39, 138)
        Me.Label60.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(50, 17)
        Me.Label60.TabIndex = 64
        Me.Label60.Text = "μέχρι:"
        '
        'SigkPck2
        '
        Me.SigkPck2.CustomFormat = "dd/MM/yy"
        Me.SigkPck2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.SigkPck2.Location = New System.Drawing.Point(132, 128)
        Me.SigkPck2.Margin = New System.Windows.Forms.Padding(4)
        Me.SigkPck2.Name = "SigkPck2"
        Me.SigkPck2.Size = New System.Drawing.Size(188, 23)
        Me.SigkPck2.TabIndex = 63
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.ForeColor = System.Drawing.Color.Black
        Me.Label61.Location = New System.Drawing.Point(47, 91)
        Me.Label61.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(45, 17)
        Me.Label61.TabIndex = 61
        Me.Label61.Text = "από :"
        '
        'SigkPck1
        '
        Me.SigkPck1.CustomFormat = "dd/MM/yy"
        Me.SigkPck1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.SigkPck1.Location = New System.Drawing.Point(132, 82)
        Me.SigkPck1.Margin = New System.Windows.Forms.Padding(4)
        Me.SigkPck1.Name = "SigkPck1"
        Me.SigkPck1.Size = New System.Drawing.Size(188, 23)
        Me.SigkPck1.TabIndex = 60
        '
        'SigkBtn
        '
        Me.SigkBtn.BackColor = System.Drawing.Color.White
        Me.SigkBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SigkBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SigkBtn.ForeColor = System.Drawing.Color.Black
        Me.SigkBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.SigkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SigkBtn.Location = New System.Drawing.Point(117, 190)
        Me.SigkBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.SigkBtn.Name = "SigkBtn"
        Me.SigkBtn.Size = New System.Drawing.Size(197, 39)
        Me.SigkBtn.TabIndex = 50
        Me.SigkBtn.Text = "Προεπισκόπηση"
        Me.SigkBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SigkBtn.UseVisualStyleBackColor = False
        '
        'ExtraParEktPnl
        '
        Me.ExtraParEktPnl.BackColor = System.Drawing.Color.DarkGray
        Me.ExtraParEktPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ExtraParEktPnl.Controls.Add(Me.Label53)
        Me.ExtraParEktPnl.Controls.Add(Me.ExtraParEktPck2)
        Me.ExtraParEktPnl.Controls.Add(Me.Label54)
        Me.ExtraParEktPnl.Controls.Add(Me.ExtraParEktPck1)
        Me.ExtraParEktPnl.Controls.Add(Me.ExtraParEktBtn)
        Me.ExtraParEktPnl.Location = New System.Drawing.Point(41, 101)
        Me.ExtraParEktPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ExtraParEktPnl.Name = "ExtraParEktPnl"
        Me.ExtraParEktPnl.Size = New System.Drawing.Size(467, 14)
        Me.ExtraParEktPnl.TabIndex = 52
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(24, 94)
        Me.Label53.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(59, 20)
        Me.Label53.TabIndex = 64
        Me.Label53.Text = "μέχρι:"
        '
        'ExtraParEktPck2
        '
        Me.ExtraParEktPck2.Location = New System.Drawing.Point(117, 84)
        Me.ExtraParEktPck2.Margin = New System.Windows.Forms.Padding(4)
        Me.ExtraParEktPck2.Name = "ExtraParEktPck2"
        Me.ExtraParEktPck2.Size = New System.Drawing.Size(265, 26)
        Me.ExtraParEktPck2.TabIndex = 63
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(32, 39)
        Me.Label54.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(51, 20)
        Me.Label54.TabIndex = 61
        Me.Label54.Text = "από :"
        '
        'ExtraParEktPck1
        '
        Me.ExtraParEktPck1.Location = New System.Drawing.Point(119, 30)
        Me.ExtraParEktPck1.Margin = New System.Windows.Forms.Padding(4)
        Me.ExtraParEktPck1.Name = "ExtraParEktPck1"
        Me.ExtraParEktPck1.Size = New System.Drawing.Size(265, 26)
        Me.ExtraParEktPck1.TabIndex = 60
        '
        'ExtraParEktBtn
        '
        Me.ExtraParEktBtn.BackColor = System.Drawing.Color.White
        Me.ExtraParEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ExtraParEktBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ExtraParEktBtn.ForeColor = System.Drawing.Color.Black
        Me.ExtraParEktBtn.Image = Global.winhotel.My.Resources.Resources.REPORT
        Me.ExtraParEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ExtraParEktBtn.Location = New System.Drawing.Point(117, 154)
        Me.ExtraParEktBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.ExtraParEktBtn.Name = "ExtraParEktBtn"
        Me.ExtraParEktBtn.Size = New System.Drawing.Size(197, 39)
        Me.ExtraParEktBtn.TabIndex = 50
        Me.ExtraParEktBtn.Text = "Προεπισκόπηση"
        Me.ExtraParEktBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ExtraParEktBtn.UseVisualStyleBackColor = False
        '
        'EkdosiApyPnl
        '
        Me.EkdosiApyPnl.BackColor = System.Drawing.Color.Silver
        Me.EkdosiApyPnl.Controls.Add(Me.Label44)
        Me.EkdosiApyPnl.Controls.Add(Me.apyEkdCbx)
        Me.EkdosiApyPnl.Controls.Add(Me.EkdosiApy2Pnl)
        Me.EkdosiApyPnl.Controls.Add(Me.WaitLbl)
        Me.EkdosiApyPnl.Controls.Add(Me.EkdosiApy2Btn)
        Me.EkdosiApyPnl.Controls.Add(Me.RadioButton2)
        Me.EkdosiApyPnl.Controls.Add(Me.RadioButton1)
        Me.EkdosiApyPnl.Controls.Add(Me.EkdosiApy1Btn)
        Me.EkdosiApyPnl.Controls.Add(Me.Label6)
        Me.EkdosiApyPnl.Controls.Add(Me.EkdosiApyPck)
        Me.EkdosiApyPnl.Location = New System.Drawing.Point(91, 497)
        Me.EkdosiApyPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApyPnl.Name = "EkdosiApyPnl"
        Me.EkdosiApyPnl.Size = New System.Drawing.Size(909, 10)
        Me.EkdosiApyPnl.TabIndex = 37
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(256, 15)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(88, 20)
        Me.Label44.TabIndex = 57
        Me.Label44.Text = "Εταιρεία:"
        '
        'apyEkdCbx
        '
        Me.apyEkdCbx.FormattingEnabled = True
        Me.apyEkdCbx.Location = New System.Drawing.Point(359, 10)
        Me.apyEkdCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.apyEkdCbx.Name = "apyEkdCbx"
        Me.apyEkdCbx.Size = New System.Drawing.Size(160, 28)
        Me.apyEkdCbx.TabIndex = 56
        '
        'EkdosiApy2Pnl
        '
        Me.EkdosiApy2Pnl.AutoScroll = True
        Me.EkdosiApy2Pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EkdosiApy2Pnl.Controls.Add(Me.ForosChk)
        Me.EkdosiApy2Pnl.Controls.Add(Me.TimologioChk)
        Me.EkdosiApy2Pnl.Controls.Add(Me.EkdosiApy3Btn)
        Me.EkdosiApy2Pnl.Controls.Add(Me.EkdosiApyTbx)
        Me.EkdosiApy2Pnl.Controls.Add(Me.Label8)
        Me.EkdosiApy2Pnl.Controls.Add(Me.Label7)
        Me.EkdosiApy2Pnl.Location = New System.Drawing.Point(5, 217)
        Me.EkdosiApy2Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApy2Pnl.Name = "EkdosiApy2Pnl"
        Me.EkdosiApy2Pnl.Size = New System.Drawing.Size(880, 91)
        Me.EkdosiApy2Pnl.TabIndex = 55
        '
        'ForosChk
        '
        Me.ForosChk.AutoSize = True
        Me.ForosChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ForosChk.Location = New System.Drawing.Point(656, 43)
        Me.ForosChk.Margin = New System.Windows.Forms.Padding(4)
        Me.ForosChk.Name = "ForosChk"
        Me.ForosChk.Size = New System.Drawing.Size(168, 24)
        Me.ForosChk.TabIndex = 61
        Me.ForosChk.Text = "Φόρος Διαμονής"
        Me.ForosChk.UseVisualStyleBackColor = True
        '
        'TimologioChk
        '
        Me.TimologioChk.AutoSize = True
        Me.TimologioChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TimologioChk.Checked = True
        Me.TimologioChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TimologioChk.Location = New System.Drawing.Point(29, 43)
        Me.TimologioChk.Margin = New System.Windows.Forms.Padding(4)
        Me.TimologioChk.Name = "TimologioChk"
        Me.TimologioChk.Size = New System.Drawing.Size(112, 24)
        Me.TimologioChk.TabIndex = 59
        Me.TimologioChk.Text = "Τιμολογιο"
        Me.TimologioChk.UseVisualStyleBackColor = True
        '
        'EkdosiApy3Btn
        '
        Me.EkdosiApy3Btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiApy3Btn.ForeColor = System.Drawing.Color.Blue
        Me.EkdosiApy3Btn.Image = CType(resources.GetObject("EkdosiApy3Btn.Image"), System.Drawing.Image)
        Me.EkdosiApy3Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiApy3Btn.Location = New System.Drawing.Point(412, 44)
        Me.EkdosiApy3Btn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApy3Btn.Name = "EkdosiApy3Btn"
        Me.EkdosiApy3Btn.Size = New System.Drawing.Size(216, 28)
        Me.EkdosiApy3Btn.TabIndex = 58
        Me.EkdosiApy3Btn.Text = "Επανέκδοση"
        Me.EkdosiApy3Btn.UseVisualStyleBackColor = True
        '
        'EkdosiApyTbx
        '
        Me.EkdosiApyTbx.Location = New System.Drawing.Point(249, 44)
        Me.EkdosiApyTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApyTbx.MaxLength = 5
        Me.EkdosiApyTbx.Name = "EkdosiApyTbx"
        Me.EkdosiApyTbx.Size = New System.Drawing.Size(115, 26)
        Me.EkdosiApyTbx.TabIndex = 57
        Me.EkdosiApyTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(192, 48)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 20)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Α/Α:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(5, 5)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(291, 20)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Επανέκδοση Α.Π.Υ.-ΤΙΜΟΛΟΓΙΟΥ:"
        '
        'WaitLbl
        '
        Me.WaitLbl.AutoSize = True
        Me.WaitLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.WaitLbl.ForeColor = System.Drawing.Color.Red
        Me.WaitLbl.Location = New System.Drawing.Point(16, 11)
        Me.WaitLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.WaitLbl.Name = "WaitLbl"
        Me.WaitLbl.Size = New System.Drawing.Size(0, 20)
        Me.WaitLbl.TabIndex = 54
        '
        'EkdosiApy2Btn
        '
        Me.EkdosiApy2Btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiApy2Btn.Enabled = False
        Me.EkdosiApy2Btn.ForeColor = System.Drawing.Color.Blue
        Me.EkdosiApy2Btn.Image = CType(resources.GetObject("EkdosiApy2Btn.Image"), System.Drawing.Image)
        Me.EkdosiApy2Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiApy2Btn.Location = New System.Drawing.Point(473, 165)
        Me.EkdosiApy2Btn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApy2Btn.Name = "EkdosiApy2Btn"
        Me.EkdosiApy2Btn.Size = New System.Drawing.Size(304, 28)
        Me.EkdosiApy2Btn.TabIndex = 53
        Me.EkdosiApy2Btn.Text = "Εκρεμή (Stop ανά ΑΠΥ)"
        Me.EkdosiApy2Btn.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton2.Location = New System.Drawing.Point(420, 63)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(144, 24)
        Me.RadioButton2.TabIndex = 52
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Προτυπωμένο"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(264, 63)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(71, 24)
        Me.RadioButton1.TabIndex = 51
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Απλό"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'EkdosiApy1Btn
        '
        Me.EkdosiApy1Btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiApy1Btn.Enabled = False
        Me.EkdosiApy1Btn.ForeColor = System.Drawing.Color.Blue
        Me.EkdosiApy1Btn.Image = CType(resources.GetObject("EkdosiApy1Btn.Image"), System.Drawing.Image)
        Me.EkdosiApy1Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiApy1Btn.Location = New System.Drawing.Point(88, 165)
        Me.EkdosiApy1Btn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApy1Btn.Name = "EkdosiApy1Btn"
        Me.EkdosiApy1Btn.Size = New System.Drawing.Size(304, 28)
        Me.EkdosiApy1Btn.TabIndex = 50
        Me.EkdosiApy1Btn.Text = "Εκρεμή (Μαζικά)"
        Me.EkdosiApy1Btn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(200, 116)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ημερομηνία:"
        '
        'EkdosiApyPck
        '
        Me.EkdosiApyPck.Location = New System.Drawing.Point(343, 108)
        Me.EkdosiApyPck.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiApyPck.Name = "EkdosiApyPck"
        Me.EkdosiApyPck.Size = New System.Drawing.Size(265, 26)
        Me.EkdosiApyPck.TabIndex = 0
        '
        'ZentralPnl
        '
        Me.ZentralPnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ZentralPnl.Controls.Add(Me.ButtonsPnl)
        Me.ZentralPnl.Controls.Add(Me.SynolPnl)
        Me.ZentralPnl.Controls.Add(Me.Kratiseis4Pnl)
        Me.ZentralPnl.Controls.Add(Me.Kratiseis3Pnl)
        Me.ZentralPnl.Controls.Add(Me.Kratiseis2Pnl)
        Me.ZentralPnl.Controls.Add(Me.Kratiseis1Pnl)
        Me.ZentralPnl.Controls.Add(Me.EtiketaErgHmPnl)
        Me.ZentralPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ZentralPnl.Location = New System.Drawing.Point(41, 609)
        Me.ZentralPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ZentralPnl.Name = "ZentralPnl"
        Me.ZentralPnl.Size = New System.Drawing.Size(1021, 10)
        Me.ZentralPnl.TabIndex = 41
        '
        'ButtonsPnl
        '
        Me.ButtonsPnl.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonsPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ButtonsPnl.Location = New System.Drawing.Point(24, 762)
        Me.ButtonsPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonsPnl.Name = "ButtonsPnl"
        Me.ButtonsPnl.Size = New System.Drawing.Size(968, 122)
        Me.ButtonsPnl.TabIndex = 7
        '
        'SynolPnl
        '
        Me.SynolPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SynolPnl.Controls.Add(Me.EkptosiLbl)
        Me.SynolPnl.Controls.Add(Me.EkptosiBtn)
        Me.SynolPnl.Controls.Add(Me.Label23)
        Me.SynolPnl.Controls.Add(Me.PliromCbx)
        Me.SynolPnl.Controls.Add(Me.Label22)
        Me.SynolPnl.Controls.Add(Me.SynolLbl)
        Me.SynolPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SynolPnl.Location = New System.Drawing.Point(24, 695)
        Me.SynolPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.SynolPnl.Name = "SynolPnl"
        Me.SynolPnl.Size = New System.Drawing.Size(968, 63)
        Me.SynolPnl.TabIndex = 6
        '
        'EkptosiLbl
        '
        Me.EkptosiLbl.AutoSize = True
        Me.EkptosiLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EkptosiLbl.ForeColor = System.Drawing.Color.Green
        Me.EkptosiLbl.Location = New System.Drawing.Point(604, 31)
        Me.EkptosiLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EkptosiLbl.Name = "EkptosiLbl"
        Me.EkptosiLbl.Size = New System.Drawing.Size(0, 20)
        Me.EkptosiLbl.TabIndex = 48
        '
        'EkptosiBtn
        '
        Me.EkptosiBtn.BackColor = System.Drawing.Color.Silver
        Me.EkptosiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkptosiBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EkptosiBtn.ForeColor = System.Drawing.Color.Green
        Me.EkptosiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkptosiBtn.Location = New System.Drawing.Point(869, 33)
        Me.EkptosiBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkptosiBtn.Name = "EkptosiBtn"
        Me.EkptosiBtn.Size = New System.Drawing.Size(92, 27)
        Me.EkptosiBtn.TabIndex = 47
        Me.EkptosiBtn.Text = "Εκπτωση"
        Me.EkptosiBtn.UseVisualStyleBackColor = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Maroon
        Me.Label23.Location = New System.Drawing.Point(623, 2)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(141, 30)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Σύνολο:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PliromCbx
        '
        Me.PliromCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PliromCbx.ForeColor = System.Drawing.Color.Blue
        Me.PliromCbx.FormattingEnabled = True
        Me.PliromCbx.Items.AddRange(New Object() {"Πίστωση", "Μετρητοίς"})
        Me.PliromCbx.Location = New System.Drawing.Point(188, 18)
        Me.PliromCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PliromCbx.Name = "PliromCbx"
        Me.PliromCbx.Size = New System.Drawing.Size(169, 26)
        Me.PliromCbx.TabIndex = 21
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label22.Location = New System.Drawing.Point(1, 22)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(162, 20)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Τρόποι Πληρωμής:"
        '
        'SynolLbl
        '
        Me.SynolLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SynolLbl.ForeColor = System.Drawing.Color.Maroon
        Me.SynolLbl.Location = New System.Drawing.Point(765, 2)
        Me.SynolLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SynolLbl.Name = "SynolLbl"
        Me.SynolLbl.Size = New System.Drawing.Size(189, 30)
        Me.SynolLbl.TabIndex = 0
        Me.SynolLbl.Text = "0,00"
        Me.SynolLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Kratiseis4Pnl
        '
        Me.Kratiseis4Pnl.AutoScroll = True
        Me.Kratiseis4Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Kratiseis4Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Kratiseis4Pnl.Location = New System.Drawing.Point(24, 478)
        Me.Kratiseis4Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Kratiseis4Pnl.Name = "Kratiseis4Pnl"
        Me.Kratiseis4Pnl.Size = New System.Drawing.Size(968, 217)
        Me.Kratiseis4Pnl.TabIndex = 5
        '
        'Kratiseis3Pnl
        '
        Me.Kratiseis3Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Kratiseis3Pnl.Controls.Add(Me.SimbLbl)
        Me.Kratiseis3Pnl.Controls.Add(Me.DwmSucheImeromBtn)
        Me.Kratiseis3Pnl.Controls.Add(Me.DwmatiaKratisisBtn)
        Me.Kratiseis3Pnl.Controls.Add(Me.NonShowLbl)
        Me.Kratiseis3Pnl.Controls.Add(Me.TimesBtn)
        Me.Kratiseis3Pnl.Controls.Add(Me.TipiCbx)
        Me.Kratiseis3Pnl.Controls.Add(Me.KlinesCbx)
        Me.Kratiseis3Pnl.Controls.Add(Me.CheckBox1)
        Me.Kratiseis3Pnl.Controls.Add(Me.DwmatFreeBtn)
        Me.Kratiseis3Pnl.Controls.Add(Me.DwmTbx)
        Me.Kratiseis3Pnl.Controls.Add(Me.Label20)
        Me.Kratiseis3Pnl.Controls.Add(Me.Label18)
        Me.Kratiseis3Pnl.Controls.Add(Me.SimbCbx)
        Me.Kratiseis3Pnl.Controls.Add(Me.Label21)
        Me.Kratiseis3Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Kratiseis3Pnl.Location = New System.Drawing.Point(24, 295)
        Me.Kratiseis3Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Kratiseis3Pnl.Name = "Kratiseis3Pnl"
        Me.Kratiseis3Pnl.Size = New System.Drawing.Size(580, 180)
        Me.Kratiseis3Pnl.TabIndex = 4
        '
        'SimbLbl
        '
        Me.SimbLbl.AutoSize = True
        Me.SimbLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimbLbl.ForeColor = System.Drawing.Color.Blue
        Me.SimbLbl.Location = New System.Drawing.Point(383, 106)
        Me.SimbLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SimbLbl.Name = "SimbLbl"
        Me.SimbLbl.Size = New System.Drawing.Size(0, 17)
        Me.SimbLbl.TabIndex = 120
        '
        'DwmSucheImeromBtn
        '
        Me.DwmSucheImeromBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmSucheImeromBtn.Image = CType(resources.GetObject("DwmSucheImeromBtn.Image"), System.Drawing.Image)
        Me.DwmSucheImeromBtn.Location = New System.Drawing.Point(301, 48)
        Me.DwmSucheImeromBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.DwmSucheImeromBtn.Name = "DwmSucheImeromBtn"
        Me.DwmSucheImeromBtn.Size = New System.Drawing.Size(43, 44)
        Me.DwmSucheImeromBtn.TabIndex = 37
        Me.DwmSucheImeromBtn.UseVisualStyleBackColor = True
        '
        'DwmatiaKratisisBtn
        '
        Me.DwmatiaKratisisBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmatiaKratisisBtn.Image = CType(resources.GetObject("DwmatiaKratisisBtn.Image"), System.Drawing.Image)
        Me.DwmatiaKratisisBtn.Location = New System.Drawing.Point(5, 47)
        Me.DwmatiaKratisisBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.DwmatiaKratisisBtn.Name = "DwmatiaKratisisBtn"
        Me.DwmatiaKratisisBtn.Size = New System.Drawing.Size(43, 44)
        Me.DwmatiaKratisisBtn.TabIndex = 36
        Me.DwmatiaKratisisBtn.UseVisualStyleBackColor = True
        '
        'NonShowLbl
        '
        Me.NonShowLbl.AutoSize = True
        Me.NonShowLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.NonShowLbl.ForeColor = System.Drawing.Color.Red
        Me.NonShowLbl.Location = New System.Drawing.Point(395, 126)
        Me.NonShowLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NonShowLbl.Name = "NonShowLbl"
        Me.NonShowLbl.Size = New System.Drawing.Size(0, 29)
        Me.NonShowLbl.TabIndex = 35
        '
        'TimesBtn
        '
        Me.TimesBtn.BackColor = System.Drawing.Color.White
        Me.TimesBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TimesBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TimesBtn.ForeColor = System.Drawing.Color.Maroon
        Me.TimesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TimesBtn.Location = New System.Drawing.Point(200, 135)
        Me.TimesBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.TimesBtn.Name = "TimesBtn"
        Me.TimesBtn.Size = New System.Drawing.Size(131, 36)
        Me.TimesBtn.TabIndex = 34
        Me.TimesBtn.Text = "τιμές  €"
        Me.TimesBtn.UseVisualStyleBackColor = False
        '
        'TipiCbx
        '
        Me.TipiCbx.ForeColor = System.Drawing.Color.Blue
        Me.TipiCbx.FormattingEnabled = True
        Me.TipiCbx.Location = New System.Drawing.Point(132, 11)
        Me.TipiCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.TipiCbx.Name = "TipiCbx"
        Me.TipiCbx.Size = New System.Drawing.Size(209, 28)
        Me.TipiCbx.TabIndex = 33
        '
        'KlinesCbx
        '
        Me.KlinesCbx.Enabled = False
        Me.KlinesCbx.ForeColor = System.Drawing.Color.Blue
        Me.KlinesCbx.FormattingEnabled = True
        Me.KlinesCbx.Location = New System.Drawing.Point(351, 11)
        Me.KlinesCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.KlinesCbx.Name = "KlinesCbx"
        Me.KlinesCbx.Size = New System.Drawing.Size(212, 28)
        Me.KlinesCbx.TabIndex = 32
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(376, 59)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(118, 24)
        Me.CheckBox1.TabIndex = 31
        Me.CheckBox1.Text = "Guarantee"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DwmatFreeBtn
        '
        Me.DwmatFreeBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DwmatFreeBtn.Image = CType(resources.GetObject("DwmatFreeBtn.Image"), System.Drawing.Image)
        Me.DwmatFreeBtn.Location = New System.Drawing.Point(248, 48)
        Me.DwmatFreeBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.DwmatFreeBtn.Name = "DwmatFreeBtn"
        Me.DwmatFreeBtn.Size = New System.Drawing.Size(43, 44)
        Me.DwmatFreeBtn.TabIndex = 30
        Me.DwmatFreeBtn.UseVisualStyleBackColor = True
        '
        'DwmTbx
        '
        Me.DwmTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DwmTbx.ForeColor = System.Drawing.Color.Maroon
        Me.DwmTbx.Location = New System.Drawing.Point(143, 57)
        Me.DwmTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.DwmTbx.MaxLength = 7
        Me.DwmTbx.Name = "DwmTbx"
        Me.DwmTbx.Size = New System.Drawing.Size(89, 26)
        Me.DwmTbx.TabIndex = 29
        Me.DwmTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(76, 60)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 20)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Βίλα:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label18.Location = New System.Drawing.Point(13, 15)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 20)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Κατηγορία:"
        '
        'SimbCbx
        '
        Me.SimbCbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimbCbx.ForeColor = System.Drawing.Color.Blue
        Me.SimbCbx.FormattingEnabled = True
        Me.SimbCbx.Location = New System.Drawing.Point(183, 98)
        Me.SimbCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.SimbCbx.Name = "SimbCbx"
        Me.SimbCbx.Size = New System.Drawing.Size(192, 28)
        Me.SimbCbx.TabIndex = 19
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label21.Location = New System.Drawing.Point(61, 102)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 20)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "Συμβόλαιο:"
        '
        'Kratiseis2Pnl
        '
        Me.Kratiseis2Pnl.BackColor = System.Drawing.Color.Silver
        Me.Kratiseis2Pnl.Controls.Add(Me.Label55)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label155)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label152)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label148)
        Me.Kratiseis2Pnl.Controls.Add(Me.kwdEthnik2)
        Me.Kratiseis2Pnl.Controls.Add(Me.kwdEthnik1)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label90)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label91)
        Me.Kratiseis2Pnl.Controls.Add(Me.PaidiTbx3)
        Me.Kratiseis2Pnl.Controls.Add(Me.CotTbx3)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label89)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label10)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnKwd2)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnKwd1)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label27)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label26)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label25)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label24)
        Me.Kratiseis2Pnl.Controls.Add(Me.DateTimePicker5)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label19)
        Me.Kratiseis2Pnl.Controls.Add(Me.Button4)
        Me.Kratiseis2Pnl.Controls.Add(Me.SimetTbx)
        Me.Kratiseis2Pnl.Controls.Add(Me.ApyBtn)
        Me.Kratiseis2Pnl.Controls.Add(Me.DateTimePicker4)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label17)
        Me.Kratiseis2Pnl.Controls.Add(Me.ProkatTbx)
        Me.Kratiseis2Pnl.Controls.Add(Me.EpithimTbx)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label16)
        Me.Kratiseis2Pnl.Controls.Add(Me.TilefTbx)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label15)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnikTbx2)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnAnzTbx2)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnikTbx1)
        Me.Kratiseis2Pnl.Controls.Add(Me.EthnAnzTbx1)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label14)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label12)
        Me.Kratiseis2Pnl.Controls.Add(Me.PaidiTbx2)
        Me.Kratiseis2Pnl.Controls.Add(Me.CotTbx2)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label11)
        Me.Kratiseis2Pnl.Controls.Add(Me.PaidiTbx1)
        Me.Kratiseis2Pnl.Controls.Add(Me.CotTbx1)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label9)
        Me.Kratiseis2Pnl.Controls.Add(Me.OnomTbx3)
        Me.Kratiseis2Pnl.Controls.Add(Me.OnomTbx2)
        Me.Kratiseis2Pnl.Controls.Add(Me.OnomTbx1)
        Me.Kratiseis2Pnl.Controls.Add(Me.EnilikTbx)
        Me.Kratiseis2Pnl.Controls.Add(Me.Label13)
        Me.Kratiseis2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Kratiseis2Pnl.ForeColor = System.Drawing.Color.Black
        Me.Kratiseis2Pnl.Location = New System.Drawing.Point(608, 27)
        Me.Kratiseis2Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Kratiseis2Pnl.Name = "Kratiseis2Pnl"
        Me.Kratiseis2Pnl.Size = New System.Drawing.Size(384, 449)
        Me.Kratiseis2Pnl.TabIndex = 3
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.Blue
        Me.Label55.Location = New System.Drawing.Point(177, 11)
        Me.Label55.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(134, 17)
        Me.Label55.TabIndex = 119
        Me.Label55.Text = "Στοιχεία Α.Π.Υ-->"
        '
        'Label155
        '
        Me.Label155.AutoSize = True
        Me.Label155.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label155.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label155.Location = New System.Drawing.Point(245, 231)
        Me.Label155.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(70, 17)
        Me.Label155.TabIndex = 118
        Me.Label155.Text = "συντόμ.:"
        '
        'Label152
        '
        Me.Label152.AutoSize = True
        Me.Label152.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label152.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label152.Location = New System.Drawing.Point(185, 231)
        Me.Label152.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(45, 17)
        Me.Label152.TabIndex = 117
        Me.Label152.Text = "κωδ.:"
        '
        'Label148
        '
        Me.Label148.AutoSize = True
        Me.Label148.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label148.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label148.Location = New System.Drawing.Point(100, 231)
        Me.Label148.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(71, 17)
        Me.Label148.TabIndex = 116
        Me.Label148.Text = "αριθμός:"
        '
        'kwdEthnik2
        '
        Me.kwdEthnik2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.kwdEthnik2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.kwdEthnik2.ForeColor = System.Drawing.Color.Maroon
        Me.kwdEthnik2.Location = New System.Drawing.Point(197, 279)
        Me.kwdEthnik2.Margin = New System.Windows.Forms.Padding(4)
        Me.kwdEthnik2.MaxLength = 3
        Me.kwdEthnik2.Name = "kwdEthnik2"
        Me.kwdEthnik2.Size = New System.Drawing.Size(43, 23)
        Me.kwdEthnik2.TabIndex = 115
        Me.kwdEthnik2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'kwdEthnik1
        '
        Me.kwdEthnik1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.kwdEthnik1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.kwdEthnik1.ForeColor = System.Drawing.Color.Maroon
        Me.kwdEthnik1.Location = New System.Drawing.Point(197, 252)
        Me.kwdEthnik1.Margin = New System.Windows.Forms.Padding(4)
        Me.kwdEthnik1.MaxLength = 3
        Me.kwdEthnik1.Name = "kwdEthnik1"
        Me.kwdEthnik1.Size = New System.Drawing.Size(43, 23)
        Me.kwdEthnik1.TabIndex = 114
        Me.kwdEthnik1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label90.ForeColor = System.Drawing.Color.Black
        Me.Label90.Location = New System.Drawing.Point(104, 209)
        Me.Label90.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(57, 17)
        Me.Label90.TabIndex = 47
        Me.Label90.Text = "Ηλικία:"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label91.Location = New System.Drawing.Point(227, 209)
        Me.Label91.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(37, 17)
        Me.Label91.TabIndex = 45
        Me.Label91.Text = "Cot:"
        '
        'PaidiTbx3
        '
        Me.PaidiTbx3.ForeColor = System.Drawing.Color.Maroon
        Me.PaidiTbx3.Location = New System.Drawing.Point(175, 202)
        Me.PaidiTbx3.Margin = New System.Windows.Forms.Padding(4)
        Me.PaidiTbx3.MaxLength = 2
        Me.PaidiTbx3.Name = "PaidiTbx3"
        Me.PaidiTbx3.Size = New System.Drawing.Size(47, 24)
        Me.PaidiTbx3.TabIndex = 14
        Me.PaidiTbx3.Text = "0"
        Me.PaidiTbx3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CotTbx3
        '
        Me.CotTbx3.ForeColor = System.Drawing.Color.Black
        Me.CotTbx3.Location = New System.Drawing.Point(275, 202)
        Me.CotTbx3.Margin = New System.Windows.Forms.Padding(4)
        Me.CotTbx3.MaxLength = 20
        Me.CotTbx3.Name = "CotTbx3"
        Me.CotTbx3.Size = New System.Drawing.Size(96, 24)
        Me.CotTbx3.TabIndex = 15
        Me.CotTbx3.Text = "0"
        Me.CotTbx3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label89.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label89.Location = New System.Drawing.Point(32, 146)
        Me.Label89.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(59, 17)
        Me.Label89.TabIndex = 43
        Me.Label89.Text = "Παιδιά/"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(104, 182)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 17)
        Me.Label10.TabIndex = 42
        Me.Label10.Text = "Ηλικία:"
        '
        'EthnKwd2
        '
        Me.EthnKwd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EthnKwd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnKwd2.ForeColor = System.Drawing.Color.Maroon
        Me.EthnKwd2.Location = New System.Drawing.Point(49, 276)
        Me.EthnKwd2.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnKwd2.MaxLength = 40
        Me.EthnKwd2.Name = "EthnKwd2"
        Me.EthnKwd2.ReadOnly = True
        Me.EthnKwd2.Size = New System.Drawing.Size(33, 26)
        Me.EthnKwd2.TabIndex = 40
        Me.EthnKwd2.TabStop = False
        Me.EthnKwd2.Text = "0"
        Me.EthnKwd2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EthnKwd2.Visible = False
        '
        'EthnKwd1
        '
        Me.EthnKwd1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EthnKwd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnKwd1.ForeColor = System.Drawing.Color.Maroon
        Me.EthnKwd1.Location = New System.Drawing.Point(8, 276)
        Me.EthnKwd1.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnKwd1.MaxLength = 40
        Me.EthnKwd1.Name = "EthnKwd1"
        Me.EthnKwd1.ReadOnly = True
        Me.EthnKwd1.Size = New System.Drawing.Size(32, 26)
        Me.EthnKwd1.TabIndex = 39
        Me.EthnKwd1.TabStop = False
        Me.EthnKwd1.Text = "0"
        Me.EthnKwd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EthnKwd1.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 123)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 17)
        Me.Label27.TabIndex = 38
        Me.Label27.Text = "3.Ενήλ:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label26.Location = New System.Drawing.Point(3, 94)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(62, 17)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = "2.Ενήλ:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label25.Location = New System.Drawing.Point(4, 64)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 17)
        Me.Label25.TabIndex = 36
        Me.Label25.Text = "1.Ενήλ:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label24.Location = New System.Drawing.Point(17, 41)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(130, 17)
        Me.Label24.TabIndex = 35
        Me.Label24.Text = "Ονοματεπώνυμα/"
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker5.Location = New System.Drawing.Point(256, 414)
        Me.DateTimePicker5.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(117, 24)
        Me.DateTimePicker5.TabIndex = 34
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label19.Location = New System.Drawing.Point(4, 394)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 17)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Συμετ. Ενοίκου:"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(41, 176)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 33)
        Me.Button4.TabIndex = 32
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'SimetTbx
        '
        Me.SimetTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.SimetTbx.ForeColor = System.Drawing.Color.Maroon
        Me.SimetTbx.Location = New System.Drawing.Point(36, 414)
        Me.SimetTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.SimetTbx.MaxLength = 9
        Me.SimetTbx.Name = "SimetTbx"
        Me.SimetTbx.Size = New System.Drawing.Size(100, 26)
        Me.SimetTbx.TabIndex = 25
        Me.SimetTbx.Text = "0,00"
        Me.SimetTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ApyBtn
        '
        Me.ApyBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ApyBtn.Image = CType(resources.GetObject("ApyBtn.Image"), System.Drawing.Image)
        Me.ApyBtn.Location = New System.Drawing.Point(325, 10)
        Me.ApyBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.ApyBtn.Name = "ApyBtn"
        Me.ApyBtn.Size = New System.Drawing.Size(44, 37)
        Me.ApyBtn.TabIndex = 31
        Me.ApyBtn.UseVisualStyleBackColor = True
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(164, 337)
        Me.DateTimePicker4.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(136, 24)
        Me.DateTimePicker4.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label17.Location = New System.Drawing.Point(145, 394)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 17)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Προκ/βολή:"
        '
        'ProkatTbx
        '
        Me.ProkatTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ProkatTbx.ForeColor = System.Drawing.Color.Maroon
        Me.ProkatTbx.Location = New System.Drawing.Point(149, 414)
        Me.ProkatTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.ProkatTbx.MaxLength = 9
        Me.ProkatTbx.Name = "ProkatTbx"
        Me.ProkatTbx.Size = New System.Drawing.Size(97, 26)
        Me.ProkatTbx.TabIndex = 28
        Me.ProkatTbx.Text = "0,00"
        Me.ProkatTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EpithimTbx
        '
        Me.EpithimTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EpithimTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EpithimTbx.Location = New System.Drawing.Point(8, 366)
        Me.EpithimTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EpithimTbx.MaxLength = 100
        Me.EpithimTbx.Name = "EpithimTbx"
        Me.EpithimTbx.Size = New System.Drawing.Size(360, 23)
        Me.EpithimTbx.TabIndex = 27
        Me.EpithimTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 343)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(134, 17)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Επιθυμία Πελάτη:"
        '
        'TilefTbx
        '
        Me.TilefTbx.Location = New System.Drawing.Point(163, 309)
        Me.TilefTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.TilefTbx.MaxLength = 40
        Me.TilefTbx.Name = "TilefTbx"
        Me.TilefTbx.Size = New System.Drawing.Size(205, 24)
        Me.TilefTbx.TabIndex = 23
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 314)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(135, 17)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Επικ/νία Μεμ/νου:"
        '
        'EthnikTbx2
        '
        Me.EthnikTbx2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EthnikTbx2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnikTbx2.ForeColor = System.Drawing.Color.Maroon
        Me.EthnikTbx2.Location = New System.Drawing.Point(243, 278)
        Me.EthnikTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnikTbx2.MaxLength = 40
        Me.EthnikTbx2.Name = "EthnikTbx2"
        Me.EthnikTbx2.ReadOnly = True
        Me.EthnikTbx2.Size = New System.Drawing.Size(125, 26)
        Me.EthnikTbx2.TabIndex = 21
        Me.EthnikTbx2.TabStop = False
        Me.EthnikTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EthnAnzTbx2
        '
        Me.EthnAnzTbx2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnAnzTbx2.ForeColor = System.Drawing.Color.Maroon
        Me.EthnAnzTbx2.Location = New System.Drawing.Point(148, 277)
        Me.EthnAnzTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnAnzTbx2.MaxLength = 1
        Me.EthnAnzTbx2.Name = "EthnAnzTbx2"
        Me.EthnAnzTbx2.Size = New System.Drawing.Size(43, 26)
        Me.EthnAnzTbx2.TabIndex = 20
        Me.EthnAnzTbx2.Text = "0"
        Me.EthnAnzTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EthnikTbx1
        '
        Me.EthnikTbx1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EthnikTbx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnikTbx1.ForeColor = System.Drawing.Color.Maroon
        Me.EthnikTbx1.Location = New System.Drawing.Point(243, 250)
        Me.EthnikTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnikTbx1.MaxLength = 40
        Me.EthnikTbx1.Name = "EthnikTbx1"
        Me.EthnikTbx1.ReadOnly = True
        Me.EthnikTbx1.Size = New System.Drawing.Size(125, 26)
        Me.EthnikTbx1.TabIndex = 19
        Me.EthnikTbx1.TabStop = False
        Me.EthnikTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EthnAnzTbx1
        '
        Me.EthnAnzTbx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EthnAnzTbx1.ForeColor = System.Drawing.Color.Maroon
        Me.EthnAnzTbx1.Location = New System.Drawing.Point(148, 249)
        Me.EthnAnzTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.EthnAnzTbx1.MaxLength = 1
        Me.EthnAnzTbx1.Name = "EthnAnzTbx1"
        Me.EthnAnzTbx1.Size = New System.Drawing.Size(43, 26)
        Me.EthnAnzTbx1.TabIndex = 18
        Me.EthnAnzTbx1.Text = "0"
        Me.EthnAnzTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label14.Location = New System.Drawing.Point(28, 251)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 17)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Εθνικότητες:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label12.Location = New System.Drawing.Point(228, 182)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 17)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Cot:"
        '
        'PaidiTbx2
        '
        Me.PaidiTbx2.ForeColor = System.Drawing.Color.Maroon
        Me.PaidiTbx2.Location = New System.Drawing.Point(175, 175)
        Me.PaidiTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.PaidiTbx2.MaxLength = 2
        Me.PaidiTbx2.Name = "PaidiTbx2"
        Me.PaidiTbx2.Size = New System.Drawing.Size(47, 24)
        Me.PaidiTbx2.TabIndex = 11
        Me.PaidiTbx2.Text = "0"
        Me.PaidiTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CotTbx2
        '
        Me.CotTbx2.ForeColor = System.Drawing.Color.Black
        Me.CotTbx2.Location = New System.Drawing.Point(275, 175)
        Me.CotTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.CotTbx2.MaxLength = 20
        Me.CotTbx2.Name = "CotTbx2"
        Me.CotTbx2.Size = New System.Drawing.Size(96, 24)
        Me.CotTbx2.TabIndex = 13
        Me.CotTbx2.Text = "0"
        Me.CotTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.Location = New System.Drawing.Point(228, 154)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Cot:"
        '
        'PaidiTbx1
        '
        Me.PaidiTbx1.ForeColor = System.Drawing.Color.Maroon
        Me.PaidiTbx1.Location = New System.Drawing.Point(175, 148)
        Me.PaidiTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.PaidiTbx1.MaxLength = 2
        Me.PaidiTbx1.Name = "PaidiTbx1"
        Me.PaidiTbx1.Size = New System.Drawing.Size(47, 24)
        Me.PaidiTbx1.TabIndex = 9
        Me.PaidiTbx1.Text = "0"
        Me.PaidiTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CotTbx1
        '
        Me.CotTbx1.ForeColor = System.Drawing.Color.Black
        Me.CotTbx1.Location = New System.Drawing.Point(275, 148)
        Me.CotTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.CotTbx1.MaxLength = 20
        Me.CotTbx1.Name = "CotTbx1"
        Me.CotTbx1.Size = New System.Drawing.Size(96, 24)
        Me.CotTbx1.TabIndex = 110
        Me.CotTbx1.Text = "0"
        Me.CotTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(104, 154)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Ηλικία:"
        '
        'OnomTbx3
        '
        Me.OnomTbx3.Location = New System.Drawing.Point(69, 116)
        Me.OnomTbx3.Margin = New System.Windows.Forms.Padding(4)
        Me.OnomTbx3.MaxLength = 30
        Me.OnomTbx3.Multiline = True
        Me.OnomTbx3.Name = "OnomTbx3"
        Me.OnomTbx3.ReadOnly = True
        Me.OnomTbx3.Size = New System.Drawing.Size(305, 25)
        Me.OnomTbx3.TabIndex = 7
        '
        'OnomTbx2
        '
        Me.OnomTbx2.Location = New System.Drawing.Point(69, 86)
        Me.OnomTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.OnomTbx2.MaxLength = 30
        Me.OnomTbx2.Name = "OnomTbx2"
        Me.OnomTbx2.ReadOnly = True
        Me.OnomTbx2.Size = New System.Drawing.Size(305, 24)
        Me.OnomTbx2.TabIndex = 6
        '
        'OnomTbx1
        '
        Me.OnomTbx1.Location = New System.Drawing.Point(69, 58)
        Me.OnomTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.OnomTbx1.MaxLength = 30
        Me.OnomTbx1.Name = "OnomTbx1"
        Me.OnomTbx1.ReadOnly = True
        Me.OnomTbx1.Size = New System.Drawing.Size(305, 24)
        Me.OnomTbx1.TabIndex = 5
        '
        'EnilikTbx
        '
        Me.EnilikTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EnilikTbx.ForeColor = System.Drawing.Color.Maroon
        Me.EnilikTbx.Location = New System.Drawing.Point(125, 10)
        Me.EnilikTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EnilikTbx.MaxLength = 1
        Me.EnilikTbx.Name = "EnilikTbx"
        Me.EnilikTbx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EnilikTbx.Size = New System.Drawing.Size(43, 26)
        Me.EnilikTbx.TabIndex = 4
        Me.EnilikTbx.Text = "0"
        Me.EnilikTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 16)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 17)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Αρ. Ενηλίκων:"
        '
        'Kratiseis1Pnl
        '
        Me.Kratiseis1Pnl.BackColor = System.Drawing.Color.Silver
        Me.Kratiseis1Pnl.Controls.Add(Me.KwdPraktTbx2)
        Me.Kratiseis1Pnl.Controls.Add(Me.KwdPraktTbx1)
        Me.Kratiseis1Pnl.Controls.Add(Me.ImeromKratTbx)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label28)
        Me.Kratiseis1Pnl.Controls.Add(Me.DateTimePicker3)
        Me.Kratiseis1Pnl.Controls.Add(Me.DateTimePicker2)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label29)
        Me.Kratiseis1Pnl.Controls.Add(Me.VoucherTbx)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label30)
        Me.Kratiseis1Pnl.Controls.Add(Me.PraktTimolTbx)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label31)
        Me.Kratiseis1Pnl.Controls.Add(Me.PraktTbx)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label34)
        Me.Kratiseis1Pnl.Controls.Add(Me.KratisiTbx)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label35)
        Me.Kratiseis1Pnl.Controls.Add(Me.Label36)
        Me.Kratiseis1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Kratiseis1Pnl.Location = New System.Drawing.Point(21, 26)
        Me.Kratiseis1Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Kratiseis1Pnl.Name = "Kratiseis1Pnl"
        Me.Kratiseis1Pnl.Size = New System.Drawing.Size(583, 268)
        Me.Kratiseis1Pnl.TabIndex = 2
        '
        'KwdPraktTbx2
        '
        Me.KwdPraktTbx2.Location = New System.Drawing.Point(193, 97)
        Me.KwdPraktTbx2.Margin = New System.Windows.Forms.Padding(4)
        Me.KwdPraktTbx2.MaxLength = 4
        Me.KwdPraktTbx2.Name = "KwdPraktTbx2"
        Me.KwdPraktTbx2.Size = New System.Drawing.Size(67, 24)
        Me.KwdPraktTbx2.TabIndex = 6
        Me.KwdPraktTbx2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KwdPraktTbx1
        '
        Me.KwdPraktTbx1.Location = New System.Drawing.Point(193, 59)
        Me.KwdPraktTbx1.Margin = New System.Windows.Forms.Padding(4)
        Me.KwdPraktTbx1.MaxLength = 4
        Me.KwdPraktTbx1.Name = "KwdPraktTbx1"
        Me.KwdPraktTbx1.Size = New System.Drawing.Size(67, 24)
        Me.KwdPraktTbx1.TabIndex = 4
        Me.KwdPraktTbx1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ImeromKratTbx
        '
        Me.ImeromKratTbx.Location = New System.Drawing.Point(156, 22)
        Me.ImeromKratTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.ImeromKratTbx.Name = "ImeromKratTbx"
        Me.ImeromKratTbx.ReadOnly = True
        Me.ImeromKratTbx.Size = New System.Drawing.Size(136, 24)
        Me.ImeromKratTbx.TabIndex = 32
        Me.ImeromKratTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(76, 220)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 18)
        Me.Label28.TabIndex = 16
        Me.Label28.Text = "Αναχώριση:"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(193, 215)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(220, 26)
        Me.DateTimePicker3.TabIndex = 15
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DateTimePicker2.Location = New System.Drawing.Point(193, 176)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(220, 26)
        Me.DateTimePicker2.TabIndex = 13
        Me.DateTimePicker2.Value = New Date(2007, 12, 31, 0, 0, 0, 0)
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(116, 181)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(55, 18)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "Άφιξη:"
        '
        'VoucherTbx
        '
        Me.VoucherTbx.ForeColor = System.Drawing.Color.Black
        Me.VoucherTbx.Location = New System.Drawing.Point(193, 137)
        Me.VoucherTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.VoucherTbx.MaxLength = 50
        Me.VoucherTbx.Name = "VoucherTbx"
        Me.VoucherTbx.Size = New System.Drawing.Size(293, 24)
        Me.VoucherTbx.TabIndex = 9
        Me.VoucherTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(5, 142)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(154, 18)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "e-mail \ VoucherNr:"
        '
        'PraktTimolTbx
        '
        Me.PraktTimolTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktTimolTbx.Location = New System.Drawing.Point(269, 97)
        Me.PraktTimolTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PraktTimolTbx.Name = "PraktTimolTbx"
        Me.PraktTimolTbx.Size = New System.Drawing.Size(220, 24)
        Me.PraktTimolTbx.TabIndex = 7
        Me.PraktTimolTbx.TabStop = False
        Me.PraktTimolTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(51, 101)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 18)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Πρακτ. Τιμολ.:"
        '
        'PraktTbx
        '
        Me.PraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PraktTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PraktTbx.ForeColor = System.Drawing.Color.Blue
        Me.PraktTbx.Location = New System.Drawing.Point(269, 58)
        Me.PraktTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PraktTbx.Name = "PraktTbx"
        Me.PraktTbx.ReadOnly = True
        Me.PraktTbx.Size = New System.Drawing.Size(220, 26)
        Me.PraktTbx.TabIndex = 5
        Me.PraktTbx.TabStop = False
        Me.PraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(67, 63)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(106, 18)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Πρακτορείο:"
        '
        'KratisiTbx
        '
        Me.KratisiTbx.BackColor = System.Drawing.Color.White
        Me.KratisiTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KratisiTbx.ForeColor = System.Drawing.Color.Maroon
        Me.KratisiTbx.Location = New System.Drawing.Point(403, 18)
        Me.KratisiTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.KratisiTbx.MaxLength = 5
        Me.KratisiTbx.Name = "KratisiTbx"
        Me.KratisiTbx.Size = New System.Drawing.Size(109, 30)
        Me.KratisiTbx.TabIndex = 3
        Me.KratisiTbx.TabStop = False
        Me.KratisiTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(301, 25)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(87, 18)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Αρ. Κράτ.:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(12, 25)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(130, 18)
        Me.Label36.TabIndex = 0
        Me.Label36.Text = "Ημερ/νία Κράτ.:"
        '
        'EtiketaErgHmPnl
        '
        Me.EtiketaErgHmPnl.Controls.Add(Me.EtikLbl)
        Me.EtiketaErgHmPnl.Location = New System.Drawing.Point(21, 6)
        Me.EtiketaErgHmPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EtiketaErgHmPnl.Name = "EtiketaErgHmPnl"
        Me.EtiketaErgHmPnl.Size = New System.Drawing.Size(267, 15)
        Me.EtiketaErgHmPnl.TabIndex = 1
        '
        'EtikLbl
        '
        Me.EtikLbl.AutoSize = True
        Me.EtikLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtikLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtikLbl.Location = New System.Drawing.Point(35, 12)
        Me.EtikLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EtikLbl.Name = "EtikLbl"
        Me.EtikLbl.Size = New System.Drawing.Size(111, 36)
        Me.EtikLbl.TabIndex = 0
        Me.EtikLbl.Text = "Label1"
        '
        'AstyKatPnl
        '
        Me.AstyKatPnl.BackColor = System.Drawing.Color.Silver
        Me.AstyKatPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AstyKatPnl.Controls.Add(Me.AstyKatRdb3)
        Me.AstyKatPnl.Controls.Add(Me.AstyKatRdb1)
        Me.AstyKatPnl.Controls.Add(Me.AstyKatRdb2)
        Me.AstyKatPnl.Controls.Add(Me.Label52)
        Me.AstyKatPnl.Controls.Add(Me.AstyKatBtn)
        Me.AstyKatPnl.Controls.Add(Me.AstyKatPck)
        Me.AstyKatPnl.Location = New System.Drawing.Point(116, 261)
        Me.AstyKatPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatPnl.Name = "AstyKatPnl"
        Me.AstyKatPnl.Size = New System.Drawing.Size(472, 11)
        Me.AstyKatPnl.TabIndex = 51
        '
        'AstyKatRdb3
        '
        Me.AstyKatRdb3.AutoSize = True
        Me.AstyKatRdb3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AstyKatRdb3.Location = New System.Drawing.Point(200, 150)
        Me.AstyKatRdb3.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatRdb3.Name = "AstyKatRdb3"
        Me.AstyKatRdb3.Size = New System.Drawing.Size(63, 24)
        Me.AstyKatRdb3.TabIndex = 69
        Me.AstyKatRdb3.Text = "Ολα"
        Me.AstyKatRdb3.UseVisualStyleBackColor = True
        '
        'AstyKatRdb1
        '
        Me.AstyKatRdb1.AutoSize = True
        Me.AstyKatRdb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AstyKatRdb1.Checked = True
        Me.AstyKatRdb1.Location = New System.Drawing.Point(167, 79)
        Me.AstyKatRdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatRdb1.Name = "AstyKatRdb1"
        Me.AstyKatRdb1.Size = New System.Drawing.Size(96, 24)
        Me.AstyKatRdb1.TabIndex = 68
        Me.AstyKatRdb1.TabStop = True
        Me.AstyKatRdb1.Text = "Αφίξεις"
        Me.AstyKatRdb1.UseVisualStyleBackColor = True
        '
        'AstyKatRdb2
        '
        Me.AstyKatRdb2.AutoSize = True
        Me.AstyKatRdb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AstyKatRdb2.Location = New System.Drawing.Point(120, 114)
        Me.AstyKatRdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatRdb2.Name = "AstyKatRdb2"
        Me.AstyKatRdb2.Size = New System.Drawing.Size(138, 24)
        Me.AstyKatRdb2.TabIndex = 67
        Me.AstyKatRdb2.Text = "Αναχωρήσεις"
        Me.AstyKatRdb2.UseVisualStyleBackColor = True
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(0, 32)
        Me.Label52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(115, 20)
        Me.Label52.TabIndex = 59
        Me.Label52.Text = "Ημερομηνία:"
        '
        'AstyKatBtn
        '
        Me.AstyKatBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AstyKatBtn.Image = CType(resources.GetObject("AstyKatBtn.Image"), System.Drawing.Image)
        Me.AstyKatBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AstyKatBtn.Location = New System.Drawing.Point(84, 206)
        Me.AstyKatBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatBtn.Name = "AstyKatBtn"
        Me.AstyKatBtn.Size = New System.Drawing.Size(263, 28)
        Me.AstyKatBtn.TabIndex = 45
        Me.AstyKatBtn.Text = "Προεπισκόπηση"
        Me.AstyKatBtn.UseVisualStyleBackColor = True
        '
        'AstyKatPck
        '
        Me.AstyKatPck.Location = New System.Drawing.Point(136, 27)
        Me.AstyKatPck.Margin = New System.Windows.Forms.Padding(4)
        Me.AstyKatPck.Name = "AstyKatPck"
        Me.AstyKatPck.Size = New System.Drawing.Size(265, 26)
        Me.AstyKatPck.TabIndex = 58
        '
        'KatastElegxouPnl
        '
        Me.KatastElegxouPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.KatastElegxouPnl.Controls.Add(Me.Label158)
        Me.KatastElegxouPnl.Controls.Add(Me.ApyCbx)
        Me.KatastElegxouPnl.Controls.Add(Me.KatastElegxouBtn)
        Me.KatastElegxouPnl.Controls.Add(Me.KatastChkBoxPnl)
        Me.KatastElegxouPnl.Controls.Add(Me.Label5)
        Me.KatastElegxouPnl.Controls.Add(Me.KatastElegxPck)
        Me.KatastElegxouPnl.Location = New System.Drawing.Point(64, 164)
        Me.KatastElegxouPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KatastElegxouPnl.Name = "KatastElegxouPnl"
        Me.KatastElegxouPnl.Size = New System.Drawing.Size(912, 10)
        Me.KatastElegxouPnl.TabIndex = 36
        '
        'Label158
        '
        Me.Label158.AutoSize = True
        Me.Label158.Location = New System.Drawing.Point(48, 48)
        Me.Label158.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(88, 20)
        Me.Label158.TabIndex = 52
        Me.Label158.Text = "Εταιρεία:"
        '
        'ApyCbx
        '
        Me.ApyCbx.FormattingEnabled = True
        Me.ApyCbx.Location = New System.Drawing.Point(151, 43)
        Me.ApyCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.ApyCbx.Name = "ApyCbx"
        Me.ApyCbx.Size = New System.Drawing.Size(160, 28)
        Me.ApyCbx.TabIndex = 51
        '
        'KatastElegxouBtn
        '
        Me.KatastElegxouBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.KatastElegxouBtn.Image = CType(resources.GetObject("KatastElegxouBtn.Image"), System.Drawing.Image)
        Me.KatastElegxouBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.KatastElegxouBtn.Location = New System.Drawing.Point(308, 217)
        Me.KatastElegxouBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.KatastElegxouBtn.Name = "KatastElegxouBtn"
        Me.KatastElegxouBtn.Size = New System.Drawing.Size(304, 28)
        Me.KatastElegxouBtn.TabIndex = 50
        Me.KatastElegxouBtn.Text = "Προεπισκόπηση"
        Me.KatastElegxouBtn.UseVisualStyleBackColor = True
        '
        'KatastChkBoxPnl
        '
        Me.KatastChkBoxPnl.AutoScroll = True
        Me.KatastChkBoxPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.KatastChkBoxPnl.Location = New System.Drawing.Point(11, 105)
        Me.KatastChkBoxPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KatastChkBoxPnl.Name = "KatastChkBoxPnl"
        Me.KatastChkBoxPnl.Size = New System.Drawing.Size(880, 86)
        Me.KatastChkBoxPnl.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(385, 48)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Ημερομηνία:"
        '
        'KatastElegxPck
        '
        Me.KatastElegxPck.Location = New System.Drawing.Point(517, 44)
        Me.KatastElegxPck.Margin = New System.Windows.Forms.Padding(4)
        Me.KatastElegxPck.Name = "KatastElegxPck"
        Me.KatastElegxPck.Size = New System.Drawing.Size(265, 26)
        Me.KatastElegxPck.TabIndex = 0
        '
        'MetritoisPnl
        '
        Me.MetritoisPnl.Controls.Add(Me.MetritisSpeichPnl)
        Me.MetritoisPnl.Controls.Add(Me.DecoPnl)
        Me.MetritoisPnl.Controls.Add(Me.XPnl)
        Me.MetritoisPnl.Controls.Add(Me.Metritis1Pnl)
        Me.MetritoisPnl.Controls.Add(Me.KefalidaPnl)
        Me.MetritoisPnl.Controls.Add(Me.FpaPnl)
        Me.MetritoisPnl.Controls.Add(Me.PosaPnl)
        Me.MetritoisPnl.Location = New System.Drawing.Point(31, 430)
        Me.MetritoisPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.MetritoisPnl.Name = "MetritoisPnl"
        Me.MetritoisPnl.Size = New System.Drawing.Size(1049, 10)
        Me.MetritoisPnl.TabIndex = 35
        '
        'MetritisSpeichPnl
        '
        Me.MetritisSpeichPnl.Location = New System.Drawing.Point(8, 400)
        Me.MetritisSpeichPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.MetritisSpeichPnl.Name = "MetritisSpeichPnl"
        Me.MetritisSpeichPnl.Size = New System.Drawing.Size(1015, 85)
        Me.MetritisSpeichPnl.TabIndex = 26
        '
        'DecoPnl
        '
        Me.DecoPnl.AutoScroll = True
        Me.DecoPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.DecoPnl.Enabled = False
        Me.DecoPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DecoPnl.Location = New System.Drawing.Point(720, 212)
        Me.DecoPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.DecoPnl.Name = "DecoPnl"
        Me.DecoPnl.Size = New System.Drawing.Size(303, 180)
        Me.DecoPnl.TabIndex = 25
        '
        'XPnl
        '
        Me.XPnl.AutoScroll = True
        Me.XPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.XPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.XPnl.ForeColor = System.Drawing.Color.Maroon
        Me.XPnl.Location = New System.Drawing.Point(143, 212)
        Me.XPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.XPnl.Name = "XPnl"
        Me.XPnl.Size = New System.Drawing.Size(113, 180)
        Me.XPnl.TabIndex = 24
        '
        'Metritis1Pnl
        '
        Me.Metritis1Pnl.AutoScroll = True
        Me.Metritis1Pnl.BackColor = System.Drawing.Color.Silver
        Me.Metritis1Pnl.Controls.Add(Me.PlirCbx)
        Me.Metritis1Pnl.Controls.Add(Me.Label127)
        Me.Metritis1Pnl.Controls.Add(Me.EggrafiCbx)
        Me.Metritis1Pnl.Controls.Add(Me.AitiaTbx)
        Me.Metritis1Pnl.Controls.Add(Me.Label33)
        Me.Metritis1Pnl.Controls.Add(Me.DateTimePicker1)
        Me.Metritis1Pnl.Controls.Add(Me.TmimaTbx)
        Me.Metritis1Pnl.Controls.Add(Me.Label32)
        Me.Metritis1Pnl.Controls.Add(Me.Label43)
        Me.Metritis1Pnl.Controls.Add(Me.Label38)
        Me.Metritis1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Metritis1Pnl.Location = New System.Drawing.Point(8, 4)
        Me.Metritis1Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.Metritis1Pnl.Name = "Metritis1Pnl"
        Me.Metritis1Pnl.Size = New System.Drawing.Size(1015, 158)
        Me.Metritis1Pnl.TabIndex = 20
        '
        'PlirCbx
        '
        Me.PlirCbx.FormattingEnabled = True
        Me.PlirCbx.Location = New System.Drawing.Point(255, 116)
        Me.PlirCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.PlirCbx.Name = "PlirCbx"
        Me.PlirCbx.Size = New System.Drawing.Size(203, 28)
        Me.PlirCbx.TabIndex = 48
        '
        'Label127
        '
        Me.Label127.AutoSize = True
        Me.Label127.Location = New System.Drawing.Point(56, 119)
        Me.Label127.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(167, 20)
        Me.Label127.TabIndex = 47
        Me.Label127.Text = "Τρόπος Πληρωμής:"
        '
        'EggrafiCbx
        '
        Me.EggrafiCbx.FormattingEnabled = True
        Me.EggrafiCbx.Location = New System.Drawing.Point(645, 71)
        Me.EggrafiCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EggrafiCbx.Name = "EggrafiCbx"
        Me.EggrafiCbx.Size = New System.Drawing.Size(124, 28)
        Me.EggrafiCbx.TabIndex = 15
        '
        'AitiaTbx
        '
        Me.AitiaTbx.ForeColor = System.Drawing.Color.Blue
        Me.AitiaTbx.Location = New System.Drawing.Point(645, 116)
        Me.AitiaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.AitiaTbx.MaxLength = 99
        Me.AitiaTbx.Name = "AitiaTbx"
        Me.AitiaTbx.Size = New System.Drawing.Size(335, 26)
        Me.AitiaTbx.TabIndex = 18
        Me.AitiaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(223, 18)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(115, 20)
        Me.Label33.TabIndex = 16
        Me.Label33.Text = "Ημερομηνία:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(351, 15)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(265, 26)
        Me.DateTimePicker1.TabIndex = 5
        '
        'TmimaTbx
        '
        Me.TmimaTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TmimaTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TmimaTbx.ForeColor = System.Drawing.Color.Maroon
        Me.TmimaTbx.Location = New System.Drawing.Point(255, 69)
        Me.TmimaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimaTbx.Name = "TmimaTbx"
        Me.TmimaTbx.Size = New System.Drawing.Size(203, 29)
        Me.TmimaTbx.TabIndex = 10
        Me.TmimaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(179, 75)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(66, 20)
        Me.Label32.TabIndex = 14
        Me.Label32.Text = "Τμήμα:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(524, 119)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(103, 20)
        Me.Label43.TabIndex = 3
        Me.Label43.Text = "Αιτιολογία:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(472, 73)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(151, 20)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "A/A Κατάστασης:"
        '
        'KefalidaPnl
        '
        Me.KefalidaPnl.BackColor = System.Drawing.Color.DarkKhaki
        Me.KefalidaPnl.Controls.Add(Me.MaisonLbl)
        Me.KefalidaPnl.Controls.Add(Me.PosoLbl)
        Me.KefalidaPnl.Controls.Add(Me.FpaLbl)
        Me.KefalidaPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KefalidaPnl.Location = New System.Drawing.Point(8, 166)
        Me.KefalidaPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.KefalidaPnl.Name = "KefalidaPnl"
        Me.KefalidaPnl.Size = New System.Drawing.Size(1015, 42)
        Me.KefalidaPnl.TabIndex = 23
        '
        'MaisonLbl
        '
        Me.MaisonLbl.AutoSize = True
        Me.MaisonLbl.ForeColor = System.Drawing.Color.Blue
        Me.MaisonLbl.Location = New System.Drawing.Point(491, 12)
        Me.MaisonLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MaisonLbl.Name = "MaisonLbl"
        Me.MaisonLbl.Size = New System.Drawing.Size(64, 20)
        Me.MaisonLbl.TabIndex = 17
        Me.MaisonLbl.Text = "Φ.Π.Α."
        '
        'PosoLbl
        '
        Me.PosoLbl.AutoSize = True
        Me.PosoLbl.ForeColor = System.Drawing.Color.Blue
        Me.PosoLbl.Location = New System.Drawing.Point(328, 12)
        Me.PosoLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PosoLbl.Name = "PosoLbl"
        Me.PosoLbl.Size = New System.Drawing.Size(52, 20)
        Me.PosoLbl.TabIndex = 16
        Me.PosoLbl.Text = "Ποσό"
        '
        'FpaLbl
        '
        Me.FpaLbl.AutoSize = True
        Me.FpaLbl.ForeColor = System.Drawing.Color.Blue
        Me.FpaLbl.Location = New System.Drawing.Point(17, 12)
        Me.FpaLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FpaLbl.Name = "FpaLbl"
        Me.FpaLbl.Size = New System.Drawing.Size(80, 20)
        Me.FpaLbl.TabIndex = 15
        Me.FpaLbl.Text = "%Φ.Π.Α."
        '
        'FpaPnl
        '
        Me.FpaPnl.AutoScroll = True
        Me.FpaPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.FpaPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.FpaPnl.ForeColor = System.Drawing.Color.Maroon
        Me.FpaPnl.Location = New System.Drawing.Point(8, 212)
        Me.FpaPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.FpaPnl.Name = "FpaPnl"
        Me.FpaPnl.Size = New System.Drawing.Size(129, 180)
        Me.FpaPnl.TabIndex = 21
        '
        'PosaPnl
        '
        Me.PosaPnl.AutoScroll = True
        Me.PosaPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PosaPnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.PosaPnl.Location = New System.Drawing.Point(261, 212)
        Me.PosaPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.PosaPnl.Name = "PosaPnl"
        Me.PosaPnl.Size = New System.Drawing.Size(453, 180)
        Me.PosaPnl.TabIndex = 22
        '
        'EkdosiParastPnl
        '
        Me.EkdosiParastPnl.Controls.Add(Me.EkdosiParast2Pnl)
        Me.EkdosiParastPnl.Controls.Add(Me.EkdosiParast1Pnl)
        Me.EkdosiParastPnl.Location = New System.Drawing.Point(37, 36)
        Me.EkdosiParastPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastPnl.Name = "EkdosiParastPnl"
        Me.EkdosiParastPnl.Size = New System.Drawing.Size(1060, 10)
        Me.EkdosiParastPnl.TabIndex = 40
        '
        'EkdosiParast2Pnl
        '
        Me.EkdosiParast2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastYpnosChk)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastNeoBtn)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastKataxBtn)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastTrPliromCbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastProkatabTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastEktBtn)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label108)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label107)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label106)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label105)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label104)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label103)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label102)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label101)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label100)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label99)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastSynolaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastAllFpaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastDeipnoFpaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastGeumaFpaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastPrwinoFpaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastYpnosFpaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastAllTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastDeipnoTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastGeumaTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastPrwinoTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.EkdosiParastYpnosTbx)
        Me.EkdosiParast2Pnl.Controls.Add(Me.Label98)
        Me.EkdosiParast2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EkdosiParast2Pnl.Location = New System.Drawing.Point(15, 287)
        Me.EkdosiParast2Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParast2Pnl.Name = "EkdosiParast2Pnl"
        Me.EkdosiParast2Pnl.Size = New System.Drawing.Size(1005, 330)
        Me.EkdosiParast2Pnl.TabIndex = 32
        '
        'EkdosiParastYpnosChk
        '
        Me.EkdosiParastYpnosChk.AutoSize = True
        Me.EkdosiParastYpnosChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiParastYpnosChk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EkdosiParastYpnosChk.Location = New System.Drawing.Point(28, 71)
        Me.EkdosiParastYpnosChk.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastYpnosChk.Name = "EkdosiParastYpnosChk"
        Me.EkdosiParastYpnosChk.Size = New System.Drawing.Size(145, 21)
        Me.EkdosiParastYpnosChk.TabIndex = 49
        Me.EkdosiParastYpnosChk.Text = "Εσωτ.Υφαίρεση "
        Me.EkdosiParastYpnosChk.UseVisualStyleBackColor = True
        '
        'EkdosiParastNeoBtn
        '
        Me.EkdosiParastNeoBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiParastNeoBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiParastNeoBtn.Location = New System.Drawing.Point(641, 267)
        Me.EkdosiParastNeoBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastNeoBtn.Name = "EkdosiParastNeoBtn"
        Me.EkdosiParastNeoBtn.Size = New System.Drawing.Size(263, 28)
        Me.EkdosiParastNeoBtn.TabIndex = 48
        Me.EkdosiParastNeoBtn.Text = "Εκδοση νέου"
        Me.EkdosiParastNeoBtn.UseVisualStyleBackColor = True
        '
        'EkdosiParastKataxBtn
        '
        Me.EkdosiParastKataxBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiParastKataxBtn.Image = CType(resources.GetObject("EkdosiParastKataxBtn.Image"), System.Drawing.Image)
        Me.EkdosiParastKataxBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiParastKataxBtn.Location = New System.Drawing.Point(52, 267)
        Me.EkdosiParastKataxBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastKataxBtn.Name = "EkdosiParastKataxBtn"
        Me.EkdosiParastKataxBtn.Size = New System.Drawing.Size(231, 28)
        Me.EkdosiParastKataxBtn.TabIndex = 47
        Me.EkdosiParastKataxBtn.Text = "Καταχώριση"
        Me.EkdosiParastKataxBtn.UseVisualStyleBackColor = True
        '
        'EkdosiParastTrPliromCbx
        '
        Me.EkdosiParastTrPliromCbx.FormattingEnabled = True
        Me.EkdosiParastTrPliromCbx.Location = New System.Drawing.Point(331, 182)
        Me.EkdosiParastTrPliromCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastTrPliromCbx.Name = "EkdosiParastTrPliromCbx"
        Me.EkdosiParastTrPliromCbx.Size = New System.Drawing.Size(189, 28)
        Me.EkdosiParastTrPliromCbx.TabIndex = 46
        '
        'EkdosiParastProkatabTbx
        '
        Me.EkdosiParastProkatabTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastProkatabTbx.Location = New System.Drawing.Point(329, 138)
        Me.EkdosiParastProkatabTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastProkatabTbx.MaxLength = 9
        Me.EkdosiParastProkatabTbx.Name = "EkdosiParastProkatabTbx"
        Me.EkdosiParastProkatabTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastProkatabTbx.TabIndex = 45
        Me.EkdosiParastProkatabTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastEktBtn
        '
        Me.EkdosiParastEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiParastEktBtn.Image = CType(resources.GetObject("EkdosiParastEktBtn.Image"), System.Drawing.Image)
        Me.EkdosiParastEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiParastEktBtn.Location = New System.Drawing.Point(331, 267)
        Me.EkdosiParastEktBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastEktBtn.Name = "EkdosiParastEktBtn"
        Me.EkdosiParastEktBtn.Size = New System.Drawing.Size(263, 28)
        Me.EkdosiParastEktBtn.TabIndex = 9
        Me.EkdosiParastEktBtn.Text = "Καταχ/ση-Προεπισκ."
        Me.EkdosiParastEktBtn.UseVisualStyleBackColor = True
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(97, 182)
        Me.Label108.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(167, 20)
        Me.Label108.TabIndex = 44
        Me.Label108.Text = "Τρόπος Πληρωμής:"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(93, 142)
        Me.Label107.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(181, 20)
        Me.Label107.TabIndex = 43
        Me.Label107.Text = "Ληφθ. Προκαταβολή:"
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(208, 105)
        Me.Label106.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(73, 20)
        Me.Label106.TabIndex = 42
        Me.Label106.Text = "Σύνολα:"
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(219, 73)
        Me.Label105.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(70, 20)
        Me.Label105.TabIndex = 41
        Me.Label105.Text = "Φ.Π.Α.:"
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(97, 41)
        Me.Label104.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(179, 20)
        Me.Label104.TabIndex = 40
        Me.Label104.Text = "Ποσό Παραστατικού:"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label103.ForeColor = System.Drawing.Color.Maroon
        Me.Label103.Location = New System.Drawing.Point(829, 14)
        Me.Label103.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(105, 20)
        Me.Label103.TabIndex = 39
        Me.Label103.Text = "AllInclusive"
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label102.ForeColor = System.Drawing.Color.Maroon
        Me.Label102.Location = New System.Drawing.Point(715, 14)
        Me.Label102.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(67, 20)
        Me.Label102.TabIndex = 38
        Me.Label102.Text = "Δείπνο"
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Maroon
        Me.Label101.Location = New System.Drawing.Point(591, 14)
        Me.Label101.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(60, 20)
        Me.Label101.TabIndex = 37
        Me.Label101.Text = "Γεύμα"
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label100.ForeColor = System.Drawing.Color.Maroon
        Me.Label100.Location = New System.Drawing.Point(460, 14)
        Me.Label100.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(71, 20)
        Me.Label100.TabIndex = 36
        Me.Label100.Text = "Πρωϊνό"
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.Maroon
        Me.Label99.Location = New System.Drawing.Point(333, 14)
        Me.Label99.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(59, 20)
        Me.Label99.TabIndex = 35
        Me.Label99.Text = "Υπνος"
        '
        'EkdosiParastSynolaTbx
        '
        Me.EkdosiParastSynolaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastSynolaTbx.Location = New System.Drawing.Point(329, 103)
        Me.EkdosiParastSynolaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastSynolaTbx.MaxLength = 9
        Me.EkdosiParastSynolaTbx.Name = "EkdosiParastSynolaTbx"
        Me.EkdosiParastSynolaTbx.ReadOnly = True
        Me.EkdosiParastSynolaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastSynolaTbx.TabIndex = 30
        Me.EkdosiParastSynolaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastAllFpaTbx
        '
        Me.EkdosiParastAllFpaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastAllFpaTbx.Location = New System.Drawing.Point(825, 69)
        Me.EkdosiParastAllFpaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastAllFpaTbx.MaxLength = 9
        Me.EkdosiParastAllFpaTbx.Name = "EkdosiParastAllFpaTbx"
        Me.EkdosiParastAllFpaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastAllFpaTbx.TabIndex = 29
        Me.EkdosiParastAllFpaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastDeipnoFpaTbx
        '
        Me.EkdosiParastDeipnoFpaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastDeipnoFpaTbx.Location = New System.Drawing.Point(701, 69)
        Me.EkdosiParastDeipnoFpaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastDeipnoFpaTbx.MaxLength = 9
        Me.EkdosiParastDeipnoFpaTbx.Name = "EkdosiParastDeipnoFpaTbx"
        Me.EkdosiParastDeipnoFpaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastDeipnoFpaTbx.TabIndex = 28
        Me.EkdosiParastDeipnoFpaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastGeumaFpaTbx
        '
        Me.EkdosiParastGeumaFpaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastGeumaFpaTbx.Location = New System.Drawing.Point(577, 69)
        Me.EkdosiParastGeumaFpaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastGeumaFpaTbx.MaxLength = 9
        Me.EkdosiParastGeumaFpaTbx.Name = "EkdosiParastGeumaFpaTbx"
        Me.EkdosiParastGeumaFpaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastGeumaFpaTbx.TabIndex = 27
        Me.EkdosiParastGeumaFpaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastPrwinoFpaTbx
        '
        Me.EkdosiParastPrwinoFpaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastPrwinoFpaTbx.Location = New System.Drawing.Point(453, 69)
        Me.EkdosiParastPrwinoFpaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastPrwinoFpaTbx.MaxLength = 9
        Me.EkdosiParastPrwinoFpaTbx.Name = "EkdosiParastPrwinoFpaTbx"
        Me.EkdosiParastPrwinoFpaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastPrwinoFpaTbx.TabIndex = 26
        Me.EkdosiParastPrwinoFpaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastYpnosFpaTbx
        '
        Me.EkdosiParastYpnosFpaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastYpnosFpaTbx.Location = New System.Drawing.Point(329, 69)
        Me.EkdosiParastYpnosFpaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastYpnosFpaTbx.MaxLength = 9
        Me.EkdosiParastYpnosFpaTbx.Name = "EkdosiParastYpnosFpaTbx"
        Me.EkdosiParastYpnosFpaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastYpnosFpaTbx.TabIndex = 25
        Me.EkdosiParastYpnosFpaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastAllTbx
        '
        Me.EkdosiParastAllTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastAllTbx.Location = New System.Drawing.Point(825, 37)
        Me.EkdosiParastAllTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastAllTbx.MaxLength = 9
        Me.EkdosiParastAllTbx.Name = "EkdosiParastAllTbx"
        Me.EkdosiParastAllTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastAllTbx.TabIndex = 24
        Me.EkdosiParastAllTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastDeipnoTbx
        '
        Me.EkdosiParastDeipnoTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastDeipnoTbx.Location = New System.Drawing.Point(701, 37)
        Me.EkdosiParastDeipnoTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastDeipnoTbx.MaxLength = 9
        Me.EkdosiParastDeipnoTbx.Name = "EkdosiParastDeipnoTbx"
        Me.EkdosiParastDeipnoTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastDeipnoTbx.TabIndex = 23
        Me.EkdosiParastDeipnoTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastGeumaTbx
        '
        Me.EkdosiParastGeumaTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastGeumaTbx.Location = New System.Drawing.Point(577, 37)
        Me.EkdosiParastGeumaTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastGeumaTbx.MaxLength = 9
        Me.EkdosiParastGeumaTbx.Name = "EkdosiParastGeumaTbx"
        Me.EkdosiParastGeumaTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastGeumaTbx.TabIndex = 22
        Me.EkdosiParastGeumaTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastPrwinoTbx
        '
        Me.EkdosiParastPrwinoTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastPrwinoTbx.Location = New System.Drawing.Point(453, 37)
        Me.EkdosiParastPrwinoTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastPrwinoTbx.MaxLength = 9
        Me.EkdosiParastPrwinoTbx.Name = "EkdosiParastPrwinoTbx"
        Me.EkdosiParastPrwinoTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastPrwinoTbx.TabIndex = 21
        Me.EkdosiParastPrwinoTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'EkdosiParastYpnosTbx
        '
        Me.EkdosiParastYpnosTbx.ForeColor = System.Drawing.Color.Black
        Me.EkdosiParastYpnosTbx.Location = New System.Drawing.Point(329, 37)
        Me.EkdosiParastYpnosTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastYpnosTbx.MaxLength = 9
        Me.EkdosiParastYpnosTbx.Name = "EkdosiParastYpnosTbx"
        Me.EkdosiParastYpnosTbx.Size = New System.Drawing.Size(112, 26)
        Me.EkdosiParastYpnosTbx.TabIndex = 20
        Me.EkdosiParastYpnosTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label98.ForeColor = System.Drawing.Color.Blue
        Me.Label98.Location = New System.Drawing.Point(9, 7)
        Me.Label98.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(52, 20)
        Me.Label98.TabIndex = 1
        Me.Label98.Text = "Ποσά"
        '
        'EkdosiParast1Pnl
        '
        Me.EkdosiParast1Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label159)
        Me.EkdosiParast1Pnl.Controls.Add(Me.ParastCbx)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastParastFindeBtn)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastPraktTbx)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label109)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label97)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastParastAitTbx)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastAATbx)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label92)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label96)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastParastCbx)
        Me.EkdosiParast1Pnl.Controls.Add(Me.EkdosiParastPck)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label94)
        Me.EkdosiParast1Pnl.Controls.Add(Me.RadioButton3)
        Me.EkdosiParast1Pnl.Controls.Add(Me.RadioButton4)
        Me.EkdosiParast1Pnl.Controls.Add(Me.Label95)
        Me.EkdosiParast1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EkdosiParast1Pnl.Location = New System.Drawing.Point(13, 6)
        Me.EkdosiParast1Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParast1Pnl.Name = "EkdosiParast1Pnl"
        Me.EkdosiParast1Pnl.Size = New System.Drawing.Size(1005, 277)
        Me.EkdosiParast1Pnl.TabIndex = 31
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Location = New System.Drawing.Point(144, 31)
        Me.Label159.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(88, 20)
        Me.Label159.TabIndex = 43
        Me.Label159.Text = "Εταιρεία:"
        '
        'ParastCbx
        '
        Me.ParastCbx.ForeColor = System.Drawing.Color.Maroon
        Me.ParastCbx.FormattingEnabled = True
        Me.ParastCbx.Location = New System.Drawing.Point(271, 26)
        Me.ParastCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.ParastCbx.Name = "ParastCbx"
        Me.ParastCbx.Size = New System.Drawing.Size(215, 28)
        Me.ParastCbx.TabIndex = 42
        '
        'EkdosiParastParastFindeBtn
        '
        Me.EkdosiParastParastFindeBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiParastParastFindeBtn.Image = CType(resources.GetObject("EkdosiParastParastFindeBtn.Image"), System.Drawing.Image)
        Me.EkdosiParastParastFindeBtn.Location = New System.Drawing.Point(777, 107)
        Me.EkdosiParastParastFindeBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastParastFindeBtn.Name = "EkdosiParastParastFindeBtn"
        Me.EkdosiParastParastFindeBtn.Size = New System.Drawing.Size(43, 44)
        Me.EkdosiParastParastFindeBtn.TabIndex = 32
        Me.EkdosiParastParastFindeBtn.UseVisualStyleBackColor = True
        '
        'EkdosiParastPraktTbx
        '
        Me.EkdosiParastPraktTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EkdosiParastPraktTbx.Location = New System.Drawing.Point(275, 153)
        Me.EkdosiParastPraktTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastPraktTbx.Name = "EkdosiParastPraktTbx"
        Me.EkdosiParastPraktTbx.ReadOnly = True
        Me.EkdosiParastPraktTbx.Size = New System.Drawing.Size(224, 26)
        Me.EkdosiParastPraktTbx.TabIndex = 29
        Me.EkdosiParastPraktTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(112, 153)
        Me.Label109.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(113, 20)
        Me.Label109.TabIndex = 28
        Me.Label109.Text = "Πρακτορείο:"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(119, 202)
        Me.Label97.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(103, 20)
        Me.Label97.TabIndex = 27
        Me.Label97.Text = "Αιτιολογία:"
        '
        'EkdosiParastParastAitTbx
        '
        Me.EkdosiParastParastAitTbx.Location = New System.Drawing.Point(275, 198)
        Me.EkdosiParastParastAitTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastParastAitTbx.MaxLength = 99
        Me.EkdosiParastParastAitTbx.Multiline = True
        Me.EkdosiParastParastAitTbx.Name = "EkdosiParastParastAitTbx"
        Me.EkdosiParastParastAitTbx.Size = New System.Drawing.Size(653, 63)
        Me.EkdosiParastParastAitTbx.TabIndex = 26
        '
        'EkdosiParastAATbx
        '
        Me.EkdosiParastAATbx.ForeColor = System.Drawing.Color.Maroon
        Me.EkdosiParastAATbx.Location = New System.Drawing.Point(665, 116)
        Me.EkdosiParastAATbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastAATbx.MaxLength = 5
        Me.EkdosiParastAATbx.Name = "EkdosiParastAATbx"
        Me.EkdosiParastAATbx.Size = New System.Drawing.Size(92, 26)
        Me.EkdosiParastAATbx.TabIndex = 19
        Me.EkdosiParastAATbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Location = New System.Drawing.Point(605, 121)
        Me.Label92.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(45, 20)
        Me.Label92.TabIndex = 18
        Me.Label92.Text = "Α/Α:"
        '
        'Label96
        '
        Me.Label96.AutoSize = True
        Me.Label96.Location = New System.Drawing.Point(107, 82)
        Me.Label96.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(120, 20)
        Me.Label96.TabIndex = 23
        Me.Label96.Text = "Παραστατικό:"
        '
        'EkdosiParastParastCbx
        '
        Me.EkdosiParastParastCbx.ForeColor = System.Drawing.Color.Blue
        Me.EkdosiParastParastCbx.FormattingEnabled = True
        Me.EkdosiParastParastCbx.Location = New System.Drawing.Point(273, 74)
        Me.EkdosiParastParastCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastParastCbx.Name = "EkdosiParastParastCbx"
        Me.EkdosiParastParastCbx.Size = New System.Drawing.Size(241, 28)
        Me.EkdosiParastParastCbx.TabIndex = 22
        '
        'EkdosiParastPck
        '
        Me.EkdosiParastPck.Location = New System.Drawing.Point(665, 75)
        Me.EkdosiParastPck.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiParastPck.Name = "EkdosiParastPck"
        Me.EkdosiParastPck.Size = New System.Drawing.Size(265, 26)
        Me.EkdosiParastPck.TabIndex = 10
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(525, 79)
        Me.Label94.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(121, 20)
        Me.Label94.TabIndex = 1
        Me.Label94.Text = " Ημερομηνία:"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton3.Location = New System.Drawing.Point(289, 112)
        Me.RadioButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(144, 24)
        Me.RadioButton3.TabIndex = 21
        Me.RadioButton3.Text = "Προτυπωμένο"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(139, 114)
        Me.RadioButton4.Margin = New System.Windows.Forms.Padding(4)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(71, 24)
        Me.RadioButton4.TabIndex = 20
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Απλό"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.Blue
        Me.Label95.Location = New System.Drawing.Point(9, 7)
        Me.Label95.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(249, 20)
        Me.Label95.TabIndex = 0
        Me.Label95.Text = "Εκδοση Extra Παραστατικών "
        '
        'BiblPortasPnl
        '
        Me.BiblPortasPnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BiblPortasPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BiblPortasPnl.Controls.Add(Me.Label39)
        Me.BiblPortasPnl.Controls.Add(Me.Label37)
        Me.BiblPortasPnl.Controls.Add(Me.Panel2)
        Me.BiblPortasPnl.Controls.Add(Me.Panel1)
        Me.BiblPortasPnl.Controls.Add(Me.BiblPortasBtn)
        Me.BiblPortasPnl.Location = New System.Drawing.Point(113, 261)
        Me.BiblPortasPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.BiblPortasPnl.Name = "BiblPortasPnl"
        Me.BiblPortasPnl.Size = New System.Drawing.Size(447, 36)
        Me.BiblPortasPnl.TabIndex = 42
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label39.Location = New System.Drawing.Point(5, 92)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(162, 20)
        Me.Label39.TabIndex = 58
        Me.Label39.Text = "Χαρτί Εκτύπωσης:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label37.Location = New System.Drawing.Point(16, 7)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(73, 20)
        Me.Label37.TabIndex = 57
        Me.Label37.Text = "Μορφή:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ProxeirRdb)
        Me.Panel2.Controls.Add(Me.TheorimRdb)
        Me.Panel2.Location = New System.Drawing.Point(45, 114)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(339, 38)
        Me.Panel2.TabIndex = 56
        '
        'ProxeirRdb
        '
        Me.ProxeirRdb.AutoSize = True
        Me.ProxeirRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ProxeirRdb.ForeColor = System.Drawing.Color.Navy
        Me.ProxeirRdb.Location = New System.Drawing.Point(4, 7)
        Me.ProxeirRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.ProxeirRdb.Name = "ProxeirRdb"
        Me.ProxeirRdb.Size = New System.Drawing.Size(107, 24)
        Me.ProxeirRdb.TabIndex = 53
        Me.ProxeirRdb.Text = "Πρόχειρη"
        Me.ProxeirRdb.UseVisualStyleBackColor = True
        '
        'TheorimRdb
        '
        Me.TheorimRdb.AutoSize = True
        Me.TheorimRdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TheorimRdb.Checked = True
        Me.TheorimRdb.ForeColor = System.Drawing.Color.Navy
        Me.TheorimRdb.Location = New System.Drawing.Point(168, 7)
        Me.TheorimRdb.Margin = New System.Windows.Forms.Padding(4)
        Me.TheorimRdb.Name = "TheorimRdb"
        Me.TheorimRdb.Size = New System.Drawing.Size(126, 24)
        Me.TheorimRdb.TabIndex = 54
        Me.TheorimRdb.TabStop = True
        Me.TheorimRdb.Text = "Θεωρημένη"
        Me.TheorimRdb.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.MorfiRdb1)
        Me.Panel1.Controls.Add(Me.MorfiRdb2)
        Me.Panel1.Location = New System.Drawing.Point(45, 32)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(339, 38)
        Me.Panel1.TabIndex = 55
        '
        'MorfiRdb1
        '
        Me.MorfiRdb1.AutoSize = True
        Me.MorfiRdb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MorfiRdb1.Checked = True
        Me.MorfiRdb1.ForeColor = System.Drawing.Color.Navy
        Me.MorfiRdb1.Location = New System.Drawing.Point(11, 7)
        Me.MorfiRdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.MorfiRdb1.Name = "MorfiRdb1"
        Me.MorfiRdb1.Size = New System.Drawing.Size(105, 24)
        Me.MorfiRdb1.TabIndex = 53
        Me.MorfiRdb1.TabStop = True
        Me.MorfiRdb1.Text = "Με τιμές"
        Me.MorfiRdb1.UseVisualStyleBackColor = True
        '
        'MorfiRdb2
        '
        Me.MorfiRdb2.AutoSize = True
        Me.MorfiRdb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MorfiRdb2.ForeColor = System.Drawing.Color.Navy
        Me.MorfiRdb2.Location = New System.Drawing.Point(164, 7)
        Me.MorfiRdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.MorfiRdb2.Name = "MorfiRdb2"
        Me.MorfiRdb2.Size = New System.Drawing.Size(134, 24)
        Me.MorfiRdb2.TabIndex = 54
        Me.MorfiRdb2.TabStop = True
        Me.MorfiRdb2.Text = "Χωρίς Τιμές"
        Me.MorfiRdb2.UseVisualStyleBackColor = True
        '
        'BiblPortasBtn
        '
        Me.BiblPortasBtn.BackColor = System.Drawing.Color.Silver
        Me.BiblPortasBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BiblPortasBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BiblPortasBtn.ForeColor = System.Drawing.Color.Green
        Me.BiblPortasBtn.Image = Global.winhotel.My.Resources.Resources.B06
        Me.BiblPortasBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BiblPortasBtn.Location = New System.Drawing.Point(112, 197)
        Me.BiblPortasBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.BiblPortasBtn.Name = "BiblPortasBtn"
        Me.BiblPortasBtn.Size = New System.Drawing.Size(175, 39)
        Me.BiblPortasBtn.TabIndex = 50
        Me.BiblPortasBtn.Text = "Βιβλίο Πόρτας"
        Me.BiblPortasBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BiblPortasBtn.UseVisualStyleBackColor = False
        '
        'DailyReportPnl
        '
        Me.DailyReportPnl.BackColor = System.Drawing.Color.Gray
        Me.DailyReportPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DailyReportPnl.Controls.Add(Me.Label51)
        Me.DailyReportPnl.Controls.Add(Me.DailyReportTbx)
        Me.DailyReportPnl.Controls.Add(Me.Label50)
        Me.DailyReportPnl.Controls.Add(Me.DialyReportBtn)
        Me.DailyReportPnl.Controls.Add(Me.DailyReportPck)
        Me.DailyReportPnl.Location = New System.Drawing.Point(707, 287)
        Me.DailyReportPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.DailyReportPnl.Name = "DailyReportPnl"
        Me.DailyReportPnl.Size = New System.Drawing.Size(447, 47)
        Me.DailyReportPnl.TabIndex = 50
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.ForeColor = System.Drawing.Color.Black
        Me.Label51.Location = New System.Drawing.Point(24, 98)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(175, 20)
        Me.Label51.TabIndex = 61
        Me.Label51.Text = "Προηγούμενο Ετος:"
        '
        'DailyReportTbx
        '
        Me.DailyReportTbx.Location = New System.Drawing.Point(232, 95)
        Me.DailyReportTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.DailyReportTbx.MaxLength = 4
        Me.DailyReportTbx.Name = "DailyReportTbx"
        Me.DailyReportTbx.Size = New System.Drawing.Size(125, 26)
        Me.DailyReportTbx.TabIndex = 60
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(8, 44)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(115, 20)
        Me.Label50.TabIndex = 59
        Me.Label50.Text = "Ημερομηνία:"
        '
        'DialyReportBtn
        '
        Me.DialyReportBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DialyReportBtn.Image = CType(resources.GetObject("DialyReportBtn.Image"), System.Drawing.Image)
        Me.DialyReportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DialyReportBtn.Location = New System.Drawing.Point(85, 180)
        Me.DialyReportBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.DialyReportBtn.Name = "DialyReportBtn"
        Me.DialyReportBtn.Size = New System.Drawing.Size(263, 28)
        Me.DialyReportBtn.TabIndex = 45
        Me.DialyReportBtn.Text = "Προεπισκόπηση"
        Me.DialyReportBtn.UseVisualStyleBackColor = True
        '
        'DailyReportPck
        '
        Me.DailyReportPck.Location = New System.Drawing.Point(144, 39)
        Me.DailyReportPck.Margin = New System.Windows.Forms.Padding(4)
        Me.DailyReportPck.Name = "DailyReportPck"
        Me.DailyReportPck.Size = New System.Drawing.Size(265, 26)
        Me.DailyReportPck.TabIndex = 58
        '
        'MainCourantePnl
        '
        Me.MainCourantePnl.BackColor = System.Drawing.Color.DarkGray
        Me.MainCourantePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MainCourantePnl.Controls.Add(Me.MainCouranteRdb1)
        Me.MainCourantePnl.Controls.Add(Me.MainCouranteRdb2)
        Me.MainCourantePnl.Controls.Add(Me.Label48)
        Me.MainCourantePnl.Controls.Add(Me.MainCouranteBtn)
        Me.MainCourantePnl.Controls.Add(Me.MainCourantePck)
        Me.MainCourantePnl.Location = New System.Drawing.Point(28, 313)
        Me.MainCourantePnl.Margin = New System.Windows.Forms.Padding(4)
        Me.MainCourantePnl.Name = "MainCourantePnl"
        Me.MainCourantePnl.Size = New System.Drawing.Size(472, 11)
        Me.MainCourantePnl.TabIndex = 49
        '
        'MainCouranteRdb1
        '
        Me.MainCouranteRdb1.AutoSize = True
        Me.MainCouranteRdb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MainCouranteRdb1.Checked = True
        Me.MainCouranteRdb1.Location = New System.Drawing.Point(4, 110)
        Me.MainCouranteRdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.MainCouranteRdb1.Name = "MainCouranteRdb1"
        Me.MainCouranteRdb1.Size = New System.Drawing.Size(204, 24)
        Me.MainCouranteRdb1.TabIndex = 68
        Me.MainCouranteRdb1.TabStop = True
        Me.MainCouranteRdb1.Text = "αναλυτική  εκτύπωση"
        Me.MainCouranteRdb1.UseVisualStyleBackColor = True
        '
        'MainCouranteRdb2
        '
        Me.MainCouranteRdb2.AutoSize = True
        Me.MainCouranteRdb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MainCouranteRdb2.Location = New System.Drawing.Point(255, 110)
        Me.MainCouranteRdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.MainCouranteRdb2.Name = "MainCouranteRdb2"
        Me.MainCouranteRdb2.Size = New System.Drawing.Size(176, 24)
        Me.MainCouranteRdb2.TabIndex = 67
        Me.MainCouranteRdb2.Text = "τελευταία σελίδα"
        Me.MainCouranteRdb2.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(8, 54)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(115, 20)
        Me.Label48.TabIndex = 59
        Me.Label48.Text = "Ημερομηνία:"
        '
        'MainCouranteBtn
        '
        Me.MainCouranteBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MainCouranteBtn.Image = CType(resources.GetObject("MainCouranteBtn.Image"), System.Drawing.Image)
        Me.MainCouranteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.MainCouranteBtn.Location = New System.Drawing.Point(85, 180)
        Me.MainCouranteBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.MainCouranteBtn.Name = "MainCouranteBtn"
        Me.MainCouranteBtn.Size = New System.Drawing.Size(263, 28)
        Me.MainCouranteBtn.TabIndex = 45
        Me.MainCouranteBtn.Text = "Προεπισκόπηση"
        Me.MainCouranteBtn.UseVisualStyleBackColor = True
        '
        'MainCourantePck
        '
        Me.MainCourantePck.Location = New System.Drawing.Point(144, 49)
        Me.MainCourantePck.Margin = New System.Windows.Forms.Padding(4)
        Me.MainCourantePck.Name = "MainCourantePck"
        Me.MainCourantePck.Size = New System.Drawing.Size(265, 26)
        Me.MainCourantePck.TabIndex = 58
        '
        'EkdosiGEMazikiPnl
        '
        Me.EkdosiGEMazikiPnl.BackColor = System.Drawing.Color.Silver
        Me.EkdosiGEMazikiPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.EkdosiGEMazikiPnl.Controls.Add(Me.EkdosiGEMazikiRdb1)
        Me.EkdosiGEMazikiPnl.Controls.Add(Me.EkdosiGEMazikiRdb2)
        Me.EkdosiGEMazikiPnl.Controls.Add(Me.Label46)
        Me.EkdosiGEMazikiPnl.Controls.Add(Me.EkdosiGEMazikiBtn)
        Me.EkdosiGEMazikiPnl.Controls.Add(Me.EkdosiGEMazikiPck)
        Me.EkdosiGEMazikiPnl.Location = New System.Drawing.Point(247, 228)
        Me.EkdosiGEMazikiPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiGEMazikiPnl.Name = "EkdosiGEMazikiPnl"
        Me.EkdosiGEMazikiPnl.Size = New System.Drawing.Size(447, 11)
        Me.EkdosiGEMazikiPnl.TabIndex = 48
        '
        'EkdosiGEMazikiRdb1
        '
        Me.EkdosiGEMazikiRdb1.AutoSize = True
        Me.EkdosiGEMazikiRdb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiGEMazikiRdb1.Checked = True
        Me.EkdosiGEMazikiRdb1.Location = New System.Drawing.Point(31, 110)
        Me.EkdosiGEMazikiRdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiGEMazikiRdb1.Name = "EkdosiGEMazikiRdb1"
        Me.EkdosiGEMazikiRdb1.Size = New System.Drawing.Size(148, 24)
        Me.EkdosiGEMazikiRdb1.TabIndex = 68
        Me.EkdosiGEMazikiRdb1.TabStop = True
        Me.EkdosiGEMazikiRdb1.Text = "συνεπτυγμένα"
        Me.EkdosiGEMazikiRdb1.UseVisualStyleBackColor = True
        '
        'EkdosiGEMazikiRdb2
        '
        Me.EkdosiGEMazikiRdb2.AutoSize = True
        Me.EkdosiGEMazikiRdb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiGEMazikiRdb2.Location = New System.Drawing.Point(224, 110)
        Me.EkdosiGEMazikiRdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiGEMazikiRdb2.Name = "EkdosiGEMazikiRdb2"
        Me.EkdosiGEMazikiRdb2.Size = New System.Drawing.Size(156, 24)
        Me.EkdosiGEMazikiRdb2.TabIndex = 67
        Me.EkdosiGEMazikiRdb2.Text = "ένα ανά σελίδα"
        Me.EkdosiGEMazikiRdb2.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(8, 54)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(115, 20)
        Me.Label46.TabIndex = 59
        Me.Label46.Text = "Ημερομηνία:"
        '
        'EkdosiGEMazikiBtn
        '
        Me.EkdosiGEMazikiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EkdosiGEMazikiBtn.Image = CType(resources.GetObject("EkdosiGEMazikiBtn.Image"), System.Drawing.Image)
        Me.EkdosiGEMazikiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EkdosiGEMazikiBtn.Location = New System.Drawing.Point(85, 180)
        Me.EkdosiGEMazikiBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiGEMazikiBtn.Name = "EkdosiGEMazikiBtn"
        Me.EkdosiGEMazikiBtn.Size = New System.Drawing.Size(263, 28)
        Me.EkdosiGEMazikiBtn.TabIndex = 45
        Me.EkdosiGEMazikiBtn.Text = "Προεπισκόπηση"
        Me.EkdosiGEMazikiBtn.UseVisualStyleBackColor = True
        '
        'EkdosiGEMazikiPck
        '
        Me.EkdosiGEMazikiPck.Location = New System.Drawing.Point(144, 49)
        Me.EkdosiGEMazikiPck.Margin = New System.Windows.Forms.Padding(4)
        Me.EkdosiGEMazikiPck.Name = "EkdosiGEMazikiPck"
        Me.EkdosiGEMazikiPck.Size = New System.Drawing.Size(265, 26)
        Me.EkdosiGEMazikiPck.TabIndex = 58
        '
        'AkyrosiPnl
        '
        Me.AkyrosiPnl.BackColor = System.Drawing.Color.DarkGray
        Me.AkyrosiPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AkyrosiPnl.Controls.Add(Me.AkyrosiChk)
        Me.AkyrosiPnl.Controls.Add(Me.Label49)
        Me.AkyrosiPnl.Controls.Add(Me.AkyrosiPck2)
        Me.AkyrosiPnl.Controls.Add(Me.Label47)
        Me.AkyrosiPnl.Controls.Add(Me.AkyrosiPck1)
        Me.AkyrosiPnl.Controls.Add(Me.AkyrosiBtn)
        Me.AkyrosiPnl.Location = New System.Drawing.Point(35, 540)
        Me.AkyrosiPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.AkyrosiPnl.Name = "AkyrosiPnl"
        Me.AkyrosiPnl.Size = New System.Drawing.Size(592, 16)
        Me.AkyrosiPnl.TabIndex = 47
        '
        'AkyrosiChk
        '
        Me.AkyrosiChk.AutoSize = True
        Me.AkyrosiChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AkyrosiChk.Checked = True
        Me.AkyrosiChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AkyrosiChk.Location = New System.Drawing.Point(53, 134)
        Me.AkyrosiChk.Margin = New System.Windows.Forms.Padding(4)
        Me.AkyrosiChk.Name = "AkyrosiChk"
        Me.AkyrosiChk.Size = New System.Drawing.Size(394, 24)
        Me.AkyrosiChk.TabIndex = 65
        Me.AkyrosiChk.Text = "Ακύρωση Αφίξεων τρέχουσας Ημερομηνίας"
        Me.AkyrosiChk.UseVisualStyleBackColor = True
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(17, 87)
        Me.Label49.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(231, 20)
        Me.Label49.TabIndex = 64
        Me.Label49.Text = "Ακύρωση από Ημερομηνία:"
        '
        'AkyrosiPck2
        '
        Me.AkyrosiPck2.Location = New System.Drawing.Point(281, 84)
        Me.AkyrosiPck2.Margin = New System.Windows.Forms.Padding(4)
        Me.AkyrosiPck2.Name = "AkyrosiPck2"
        Me.AkyrosiPck2.Size = New System.Drawing.Size(265, 26)
        Me.AkyrosiPck2.TabIndex = 63
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(45, 33)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(206, 20)
        Me.Label47.TabIndex = 61
        Me.Label47.Text = "Κλεισμένη Ημερομηνία:"
        '
        'AkyrosiPck1
        '
        Me.AkyrosiPck1.Location = New System.Drawing.Point(283, 30)
        Me.AkyrosiPck1.Margin = New System.Windows.Forms.Padding(4)
        Me.AkyrosiPck1.Name = "AkyrosiPck1"
        Me.AkyrosiPck1.Size = New System.Drawing.Size(265, 26)
        Me.AkyrosiPck1.TabIndex = 60
        '
        'AkyrosiBtn
        '
        Me.AkyrosiBtn.BackColor = System.Drawing.Color.White
        Me.AkyrosiBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AkyrosiBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.AkyrosiBtn.ForeColor = System.Drawing.Color.Maroon
        Me.AkyrosiBtn.Image = Global.winhotel.My.Resources.Resources.OK
        Me.AkyrosiBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AkyrosiBtn.Location = New System.Drawing.Point(251, 176)
        Me.AkyrosiBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.AkyrosiBtn.Name = "AkyrosiBtn"
        Me.AkyrosiBtn.Size = New System.Drawing.Size(71, 39)
        Me.AkyrosiBtn.TabIndex = 50
        Me.AkyrosiBtn.Text = "ΟΚ"
        Me.AkyrosiBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AkyrosiBtn.UseVisualStyleBackColor = False
        '
        'LogarAnaxPnl
        '
        Me.LogarAnaxPnl.BackColor = System.Drawing.Color.LightGray
        Me.LogarAnaxPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LogarAnaxPnl.Controls.Add(Me.LogRdb1)
        Me.LogarAnaxPnl.Controls.Add(Me.LogRdb2)
        Me.LogarAnaxPnl.Controls.Add(Me.Label45)
        Me.LogarAnaxPnl.Controls.Add(Me.LogarAnaxBtn)
        Me.LogarAnaxPnl.Controls.Add(Me.LogarAnaxPck)
        Me.LogarAnaxPnl.Location = New System.Drawing.Point(599, 197)
        Me.LogarAnaxPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.LogarAnaxPnl.Name = "LogarAnaxPnl"
        Me.LogarAnaxPnl.Size = New System.Drawing.Size(447, 11)
        Me.LogarAnaxPnl.TabIndex = 46
        '
        'LogRdb1
        '
        Me.LogRdb1.AutoSize = True
        Me.LogRdb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogRdb1.Checked = True
        Me.LogRdb1.Location = New System.Drawing.Point(52, 110)
        Me.LogRdb1.Margin = New System.Windows.Forms.Padding(4)
        Me.LogRdb1.Name = "LogRdb1"
        Me.LogRdb1.Size = New System.Drawing.Size(136, 24)
        Me.LogRdb1.TabIndex = 68
        Me.LogRdb1.TabStop = True
        Me.LogRdb1.Text = "Ανεξόφλητοι"
        Me.LogRdb1.UseVisualStyleBackColor = True
        '
        'LogRdb2
        '
        Me.LogRdb2.AutoSize = True
        Me.LogRdb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogRdb2.Location = New System.Drawing.Point(253, 110)
        Me.LogRdb2.Margin = New System.Windows.Forms.Padding(4)
        Me.LogRdb2.Name = "LogRdb2"
        Me.LogRdb2.Size = New System.Drawing.Size(68, 24)
        Me.LogRdb2.TabIndex = 67
        Me.LogRdb2.Text = "Ολοι"
        Me.LogRdb2.UseVisualStyleBackColor = True
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.Color.Black
        Me.Label45.Location = New System.Drawing.Point(8, 54)
        Me.Label45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(115, 20)
        Me.Label45.TabIndex = 59
        Me.Label45.Text = "Ημερομηνία:"
        '
        'LogarAnaxBtn
        '
        Me.LogarAnaxBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogarAnaxBtn.Image = CType(resources.GetObject("LogarAnaxBtn.Image"), System.Drawing.Image)
        Me.LogarAnaxBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogarAnaxBtn.Location = New System.Drawing.Point(85, 180)
        Me.LogarAnaxBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.LogarAnaxBtn.Name = "LogarAnaxBtn"
        Me.LogarAnaxBtn.Size = New System.Drawing.Size(263, 28)
        Me.LogarAnaxBtn.TabIndex = 45
        Me.LogarAnaxBtn.Text = "Προεπισκόπηση"
        Me.LogarAnaxBtn.UseVisualStyleBackColor = True
        '
        'LogarAnaxPck
        '
        Me.LogarAnaxPck.Location = New System.Drawing.Point(144, 49)
        Me.LogarAnaxPck.Margin = New System.Windows.Forms.Padding(4)
        Me.LogarAnaxPck.Name = "LogarAnaxPck"
        Me.LogarAnaxPck.Size = New System.Drawing.Size(265, 26)
        Me.LogarAnaxPck.TabIndex = 58
        '
        'BiblPortApyPnl
        '
        Me.BiblPortApyPnl.BackColor = System.Drawing.Color.LightGray
        Me.BiblPortApyPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BiblPortApyPnl.Controls.Add(Me.Label40)
        Me.BiblPortApyPnl.Controls.Add(Me.BiblPortApyPck)
        Me.BiblPortApyPnl.Controls.Add(Me.BiblPortApyBtn)
        Me.BiblPortApyPnl.Location = New System.Drawing.Point(351, 143)
        Me.BiblPortApyPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.BiblPortApyPnl.Name = "BiblPortApyPnl"
        Me.BiblPortApyPnl.Size = New System.Drawing.Size(447, 10)
        Me.BiblPortApyPnl.TabIndex = 43
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(13, 37)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(115, 20)
        Me.Label40.TabIndex = 59
        Me.Label40.Text = "Ημερομηνία:"
        '
        'BiblPortApyPck
        '
        Me.BiblPortApyPck.Location = New System.Drawing.Point(149, 32)
        Me.BiblPortApyPck.Margin = New System.Windows.Forms.Padding(4)
        Me.BiblPortApyPck.Name = "BiblPortApyPck"
        Me.BiblPortApyPck.Size = New System.Drawing.Size(265, 26)
        Me.BiblPortApyPck.TabIndex = 58
        '
        'BiblPortApyBtn
        '
        Me.BiblPortApyBtn.BackColor = System.Drawing.Color.Silver
        Me.BiblPortApyBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BiblPortApyBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BiblPortApyBtn.ForeColor = System.Drawing.Color.Maroon
        Me.BiblPortApyBtn.Image = Global.winhotel.My.Resources.Resources.B06
        Me.BiblPortApyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BiblPortApyBtn.Location = New System.Drawing.Point(143, 135)
        Me.BiblPortApyBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.BiblPortApyBtn.Name = "BiblPortApyBtn"
        Me.BiblPortApyBtn.Size = New System.Drawing.Size(175, 39)
        Me.BiblPortApyBtn.TabIndex = 50
        Me.BiblPortApyBtn.Text = "Βιβλίο Πόρτας"
        Me.BiblPortApyBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BiblPortApyBtn.UseVisualStyleBackColor = False
        '
        'TmimSigkentrPnl
        '
        Me.TmimSigkentrPnl.Controls.Add(Me.TmimSigkentr2Pnl)
        Me.TmimSigkentrPnl.Location = New System.Drawing.Point(24, 366)
        Me.TmimSigkentrPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimSigkentrPnl.Name = "TmimSigkentrPnl"
        Me.TmimSigkentrPnl.Size = New System.Drawing.Size(1053, 12)
        Me.TmimSigkentrPnl.TabIndex = 34
        '
        'TmimSigkentr2Pnl
        '
        Me.TmimSigkentr2Pnl.AutoScroll = True
        Me.TmimSigkentr2Pnl.BackColor = System.Drawing.Color.Silver
        Me.TmimSigkentr2Pnl.Controls.Add(Me.TmimSigkentrPnlerCbx)
        Me.TmimSigkentr2Pnl.Controls.Add(Me.Label4)
        Me.TmimSigkentr2Pnl.Controls.Add(Me.TmimSigkentrBtn)
        Me.TmimSigkentr2Pnl.Controls.Add(Me.Label3)
        Me.TmimSigkentr2Pnl.Controls.Add(Me.TmimSigkentrPnlerPck)
        Me.TmimSigkentr2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TmimSigkentr2Pnl.Location = New System.Drawing.Point(7, 14)
        Me.TmimSigkentr2Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimSigkentr2Pnl.Name = "TmimSigkentr2Pnl"
        Me.TmimSigkentr2Pnl.Size = New System.Drawing.Size(1020, 207)
        Me.TmimSigkentr2Pnl.TabIndex = 22
        '
        'TmimSigkentrPnlerCbx
        '
        Me.TmimSigkentrPnlerCbx.FormattingEnabled = True
        Me.TmimSigkentrPnlerCbx.Location = New System.Drawing.Point(724, 50)
        Me.TmimSigkentrPnlerCbx.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimSigkentrPnlerCbx.Name = "TmimSigkentrPnlerCbx"
        Me.TmimSigkentrPnlerCbx.Size = New System.Drawing.Size(203, 28)
        Me.TmimSigkentrPnlerCbx.TabIndex = 53
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(525, 54)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 20)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Τρόπος Πληρωμής:"
        '
        'TmimSigkentrBtn
        '
        Me.TmimSigkentrBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TmimSigkentrBtn.Image = CType(resources.GetObject("TmimSigkentrBtn.Image"), System.Drawing.Image)
        Me.TmimSigkentrBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TmimSigkentrBtn.Location = New System.Drawing.Point(379, 132)
        Me.TmimSigkentrBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimSigkentrBtn.Name = "TmimSigkentrBtn"
        Me.TmimSigkentrBtn.Size = New System.Drawing.Size(233, 28)
        Me.TmimSigkentrBtn.TabIndex = 51
        Me.TmimSigkentrBtn.Text = "Προεπισκόπηση"
        Me.TmimSigkentrBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(59, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Ημερομηνία:"
        '
        'TmimSigkentrPnlerPck
        '
        Me.TmimSigkentrPnlerPck.Location = New System.Drawing.Point(191, 47)
        Me.TmimSigkentrPnlerPck.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimSigkentrPnlerPck.Name = "TmimSigkentrPnlerPck"
        Me.TmimSigkentrPnlerPck.Size = New System.Drawing.Size(265, 26)
        Me.TmimSigkentrPnlerPck.TabIndex = 5
        '
        'LogistirioEktPnl
        '
        Me.LogistirioEktPnl.Controls.Add(Me.CrystalReportViewer1)
        Me.LogistirioEktPnl.Controls.Add(Me.LogistirioEkt1Pnl)
        Me.LogistirioEktPnl.Location = New System.Drawing.Point(33, 461)
        Me.LogistirioEktPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.LogistirioEktPnl.Name = "LogistirioEktPnl"
        Me.LogistirioEktPnl.Size = New System.Drawing.Size(1045, 10)
        Me.LogistirioEktPnl.TabIndex = 33
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(1008, 153)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(13, 184)
        Me.CrystalReportViewer1.TabIndex = 22
        Me.CrystalReportViewer1.ToolPanelWidth = 267
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'LogistirioEkt1Pnl
        '
        Me.LogistirioEkt1Pnl.AutoScroll = True
        Me.LogistirioEkt1Pnl.BackColor = System.Drawing.Color.Silver
        Me.LogistirioEkt1Pnl.Controls.Add(Me.LogistirioEktBtn)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio4Rdb)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio3Rdb)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio2Rdb)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio1Rdb)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Label2)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio2Pck)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Label1)
        Me.LogistirioEkt1Pnl.Controls.Add(Me.Logistirio1Pck)
        Me.LogistirioEkt1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LogistirioEkt1Pnl.Location = New System.Drawing.Point(5, 11)
        Me.LogistirioEkt1Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.LogistirioEkt1Pnl.Name = "LogistirioEkt1Pnl"
        Me.LogistirioEkt1Pnl.Size = New System.Drawing.Size(1020, 209)
        Me.LogistirioEkt1Pnl.TabIndex = 21
        '
        'LogistirioEktBtn
        '
        Me.LogistirioEktBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogistirioEktBtn.Image = CType(resources.GetObject("LogistirioEktBtn.Image"), System.Drawing.Image)
        Me.LogistirioEktBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogistirioEktBtn.Location = New System.Drawing.Point(373, 145)
        Me.LogistirioEktBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.LogistirioEktBtn.Name = "LogistirioEktBtn"
        Me.LogistirioEktBtn.Size = New System.Drawing.Size(233, 28)
        Me.LogistirioEktBtn.TabIndex = 50
        Me.LogistirioEktBtn.Text = "Προεπισκόπηση"
        Me.LogistirioEktBtn.UseVisualStyleBackColor = True
        '
        'Logistirio4Rdb
        '
        Me.Logistirio4Rdb.AutoSize = True
        Me.Logistirio4Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Logistirio4Rdb.Location = New System.Drawing.Point(735, 96)
        Me.Logistirio4Rdb.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio4Rdb.Name = "Logistirio4Rdb"
        Me.Logistirio4Rdb.Size = New System.Drawing.Size(81, 24)
        Me.Logistirio4Rdb.TabIndex = 22
        Me.Logistirio4Rdb.Text = "Κάρτα"
        Me.Logistirio4Rdb.UseVisualStyleBackColor = True
        '
        'Logistirio3Rdb
        '
        Me.Logistirio3Rdb.AutoSize = True
        Me.Logistirio3Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Logistirio3Rdb.Location = New System.Drawing.Point(505, 96)
        Me.Logistirio3Rdb.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio3Rdb.Name = "Logistirio3Rdb"
        Me.Logistirio3Rdb.Size = New System.Drawing.Size(120, 24)
        Me.Logistirio3Rdb.TabIndex = 21
        Me.Logistirio3Rdb.Text = "Μετρητοίς"
        Me.Logistirio3Rdb.UseVisualStyleBackColor = True
        '
        'Logistirio2Rdb
        '
        Me.Logistirio2Rdb.AutoSize = True
        Me.Logistirio2Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Logistirio2Rdb.Location = New System.Drawing.Point(297, 96)
        Me.Logistirio2Rdb.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio2Rdb.Name = "Logistirio2Rdb"
        Me.Logistirio2Rdb.Size = New System.Drawing.Size(102, 24)
        Me.Logistirio2Rdb.TabIndex = 20
        Me.Logistirio2Rdb.Text = "Πίστωση"
        Me.Logistirio2Rdb.UseVisualStyleBackColor = True
        '
        'Logistirio1Rdb
        '
        Me.Logistirio1Rdb.AutoSize = True
        Me.Logistirio1Rdb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Logistirio1Rdb.Checked = True
        Me.Logistirio1Rdb.Location = New System.Drawing.Point(129, 96)
        Me.Logistirio1Rdb.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio1Rdb.Name = "Logistirio1Rdb"
        Me.Logistirio1Rdb.Size = New System.Drawing.Size(63, 24)
        Me.Logistirio1Rdb.TabIndex = 19
        Me.Logistirio1Rdb.TabStop = True
        Me.Logistirio1Rdb.Text = "Ολα"
        Me.Logistirio1Rdb.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(511, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 20)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "έως Ημερομηνία:"
        '
        'Logistirio2Pck
        '
        Me.Logistirio2Pck.Location = New System.Drawing.Point(700, 17)
        Me.Logistirio2Pck.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio2Pck.Name = "Logistirio2Pck"
        Me.Logistirio2Pck.Size = New System.Drawing.Size(265, 26)
        Me.Logistirio2Pck.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "από Ημερομηνία:"
        '
        'Logistirio1Pck
        '
        Me.Logistirio1Pck.Location = New System.Drawing.Point(217, 17)
        Me.Logistirio1Pck.Margin = New System.Windows.Forms.Padding(4)
        Me.Logistirio1Pck.Name = "Logistirio1Pck"
        Me.Logistirio1Pck.Size = New System.Drawing.Size(265, 26)
        Me.Logistirio1Pck.TabIndex = 5
        '
        'TmimataKnsPnl
        '
        Me.TmimataKnsPnl.Controls.Add(Me.TmimataKns2Pnl)
        Me.TmimataKnsPnl.Controls.Add(Me.TmimataKns1Pnl)
        Me.TmimataKnsPnl.Location = New System.Drawing.Point(4, 658)
        Me.TmimataKnsPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimataKnsPnl.Name = "TmimataKnsPnl"
        Me.TmimataKnsPnl.Size = New System.Drawing.Size(1067, 10)
        Me.TmimataKnsPnl.TabIndex = 32
        '
        'TmimataKns2Pnl
        '
        Me.TmimataKns2Pnl.AutoScroll = True
        Me.TmimataKns2Pnl.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TmimataKns2Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TmimataKns2Pnl.Location = New System.Drawing.Point(5, 85)
        Me.TmimataKns2Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimataKns2Pnl.Name = "TmimataKns2Pnl"
        Me.TmimataKns2Pnl.Size = New System.Drawing.Size(1055, 697)
        Me.TmimataKns2Pnl.TabIndex = 22
        '
        'TmimataKns1Pnl
        '
        Me.TmimataKns1Pnl.AutoScroll = True
        Me.TmimataKns1Pnl.BackColor = System.Drawing.Color.Silver
        Me.TmimataKns1Pnl.Controls.Add(Me.Label58)
        Me.TmimataKns1Pnl.Controls.Add(Me.TmimKnsImerom)
        Me.TmimataKns1Pnl.Controls.Add(Me.TmimataTmTbx)
        Me.TmimataKns1Pnl.Controls.Add(Me.Label59)
        Me.TmimataKns1Pnl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TmimataKns1Pnl.Location = New System.Drawing.Point(5, 11)
        Me.TmimataKns1Pnl.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimataKns1Pnl.Name = "TmimataKns1Pnl"
        Me.TmimataKns1Pnl.Size = New System.Drawing.Size(1055, 68)
        Me.TmimataKns1Pnl.TabIndex = 21
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.ForeColor = System.Drawing.Color.Blue
        Me.Label58.Location = New System.Drawing.Point(64, 21)
        Me.Label58.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(115, 20)
        Me.Label58.TabIndex = 16
        Me.Label58.Text = "Ημερομηνία:"
        '
        'TmimKnsImerom
        '
        Me.TmimKnsImerom.Location = New System.Drawing.Point(192, 17)
        Me.TmimKnsImerom.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimKnsImerom.Name = "TmimKnsImerom"
        Me.TmimKnsImerom.Size = New System.Drawing.Size(265, 26)
        Me.TmimKnsImerom.TabIndex = 5
        '
        'TmimataTmTbx
        '
        Me.TmimataTmTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TmimataTmTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TmimataTmTbx.ForeColor = System.Drawing.Color.Maroon
        Me.TmimataTmTbx.Location = New System.Drawing.Point(629, 15)
        Me.TmimataTmTbx.Margin = New System.Windows.Forms.Padding(4)
        Me.TmimataTmTbx.Name = "TmimataTmTbx"
        Me.TmimataTmTbx.Size = New System.Drawing.Size(203, 29)
        Me.TmimataTmTbx.TabIndex = 10
        Me.TmimataTmTbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.ForeColor = System.Drawing.Color.Blue
        Me.Label59.Location = New System.Drawing.Point(553, 21)
        Me.Label59.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(66, 20)
        Me.Label59.TabIndex = 14
        Me.Label59.Text = "Τμήμα:"
        '
        'EtiketaPnl
        '
        Me.EtiketaPnl.Controls.Add(Me.EtiketaLbl)
        Me.EtiketaPnl.Location = New System.Drawing.Point(31, 845)
        Me.EtiketaPnl.Margin = New System.Windows.Forms.Padding(4)
        Me.EtiketaPnl.Name = "EtiketaPnl"
        Me.EtiketaPnl.Size = New System.Drawing.Size(393, 11)
        Me.EtiketaPnl.TabIndex = 0
        '
        'EtiketaLbl
        '
        Me.EtiketaLbl.AutoSize = True
        Me.EtiketaLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.EtiketaLbl.ForeColor = System.Drawing.Color.Maroon
        Me.EtiketaLbl.Location = New System.Drawing.Point(59, 22)
        Me.EtiketaLbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EtiketaLbl.Name = "EtiketaLbl"
        Me.EtiketaLbl.Size = New System.Drawing.Size(111, 36)
        Me.EtiketaLbl.TabIndex = 0
        Me.EtiketaLbl.Text = "Label1"
        '
        'DbhotelDataSet
        '
        Me.DbhotelDataSet.DataSetName = "dbhotelDataSet"
        Me.DbhotelDataSet.EnforceConstraints = False
        Me.DbhotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisTableAdapter
        '
        Me.KratiseisTableAdapter.ClearBeforeFill = True
        '
        'DbhotelDataSet1
        '
        Me.DbhotelDataSet1.DataSetName = "dbhotelDataSet1"
        Me.DbhotelDataSet1.EnforceConstraints = False
        Me.DbhotelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KratiseisBindingSource1
        '
        Me.KratiseisBindingSource1.DataMember = "kratiseis"
        Me.KratiseisBindingSource1.DataSource = Me.DbhotelDataSet1
        '
        'KratiseisTableAdapter1
        '
        Me.KratiseisTableAdapter1.ClearBeforeFill = True
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
        Me.TableAdapterManager.kratiseisTableAdapter = Me.KratiseisTableAdapter1
        Me.TableAdapterManager.praktoreiaTableAdapter = Nothing
        Me.TableAdapterManager.tipoiTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.vilapraktoreia1TableAdapter = Nothing
        '
        'Vilapraktoreia1BindingSource
        '
        Me.Vilapraktoreia1BindingSource.DataMember = "vilapraktoreia1"
        Me.Vilapraktoreia1BindingSource.DataSource = Me.DbhotelDataSet1
        '
        'Vilapraktoreia1TableAdapter
        '
        Me.Vilapraktoreia1TableAdapter.ClearBeforeFill = True
        '
        'LogariasmoianaxwrountwnBindingSource
        '
        Me.LogariasmoianaxwrountwnBindingSource.DataMember = "logariasmoianaxwrountwn"
        Me.LogariasmoianaxwrountwnBindingSource.DataSource = Me.DbhotelDataSet
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
        'KlinesBindingSource
        '
        Me.KlinesBindingSource.DataMember = "klines"
        Me.KlinesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KlinesTableAdapter
        '
        Me.KlinesTableAdapter.ClearBeforeFill = True
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
        'KatigoriesBindingSource
        '
        Me.KatigoriesBindingSource.DataMember = "katigories"
        Me.KatigoriesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatigoriesTableAdapter
        '
        Me.KatigoriesTableAdapter.ClearBeforeFill = True
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
        'ParastatikaBindingSource
        '
        Me.ParastatikaBindingSource.DataMember = "parastatika"
        Me.ParastatikaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'ParastatikaTableAdapter
        '
        Me.ParastatikaTableAdapter.ClearBeforeFill = True
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
        'PistwtikesBindingSource
        '
        Me.PistwtikesBindingSource.DataMember = "pistwtikes"
        Me.PistwtikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PistwtikesTableAdapter
        '
        Me.PistwtikesTableAdapter.ClearBeforeFill = True
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
        'BiblioportasBindingSource
        '
        Me.BiblioportasBindingSource.DataMember = "biblioportas"
        Me.BiblioportasBindingSource.DataSource = Me.DbhotelDataSet
        '
        'BiblioportasTableAdapter
        '
        Me.BiblioportasTableAdapter.ClearBeforeFill = True
        '
        'KatastasiapyBindingSource
        '
        Me.KatastasiapyBindingSource.DataMember = "katastasiapy"
        Me.KatastasiapyBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KatastasiapyTableAdapter
        '
        Me.KatastasiapyTableAdapter.ClearBeforeFill = True
        '
        'KratiseisenilikesBindingSource
        '
        Me.KratiseisenilikesBindingSource.DataMember = "kratiseisenilikes"
        Me.KratiseisenilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KratiseisenilikesTableAdapter
        '
        Me.KratiseisenilikesTableAdapter.ClearBeforeFill = True
        '
        'LogariasmoianaxwrountwnTableAdapter
        '
        Me.LogariasmoianaxwrountwnTableAdapter.ClearBeforeFill = True
        '
        'EpanekdositimologiouBindingSource
        '
        Me.EpanekdositimologiouBindingSource.DataMember = "epanekdositimologiou"
        Me.EpanekdositimologiouBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EpanekdositimologiouTableAdapter
        '
        Me.EpanekdositimologiouTableAdapter.ClearBeforeFill = True
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
        'TimologioanalysisBindingSource
        '
        Me.TimologioanalysisBindingSource.DataMember = "timologioanalysis"
        Me.TimologioanalysisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimologioanalysisTableAdapter
        '
        Me.TimologioanalysisTableAdapter.ClearBeforeFill = True
        '
        'KratiseisBindingSource
        '
        Me.KratiseisBindingSource.DataMember = "kratiseis"
        Me.KratiseisBindingSource.DataSource = Me.DbhotelDataSet
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
        'TmimataBindingSource
        '
        Me.TmimataBindingSource.DataMember = "tmimata"
        Me.TmimataBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TmimataTableAdapter
        '
        Me.TmimataTableAdapter.ClearBeforeFill = True
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
        'PaidiaBindingSource
        '
        Me.PaidiaBindingSource.DataMember = "paidia"
        Me.PaidiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'PaidiaTableAdapter
        '
        Me.PaidiaTableAdapter.ClearBeforeFill = True
        '
        'EnilikesBindingSource
        '
        Me.EnilikesBindingSource.DataMember = "enilikes"
        Me.EnilikesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EnilikesTableAdapter
        '
        Me.EnilikesTableAdapter.ClearBeforeFill = True
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
        'AllotmentBindingSource
        '
        Me.AllotmentBindingSource.DataMember = "allotment"
        Me.AllotmentBindingSource.DataSource = Me.DbhotelDataSet
        '
        'AllotmentTableAdapter
        '
        Me.AllotmentTableAdapter.ClearBeforeFill = True
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
        'TimesBindingSource
        '
        Me.TimesBindingSource.DataMember = "times"
        Me.TimesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TimesTableAdapter
        '
        Me.TimesTableAdapter.ClearBeforeFill = True
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
        'StatusBindingSource
        '
        Me.StatusBindingSource.DataMember = "status"
        Me.StatusBindingSource.DataSource = Me.DbhotelDataSet
        '
        'StatusTableAdapter
        '
        Me.StatusTableAdapter.ClearBeforeFill = True
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
        'OverunterkuenfteBindingSource
        '
        Me.OverunterkuenfteBindingSource.DataMember = "overunterkuenfte"
        Me.OverunterkuenfteBindingSource.DataSource = Me.DbhotelDataSet
        '
        'OverunterkuenfteTableAdapter
        '
        Me.OverunterkuenfteTableAdapter.ClearBeforeFill = True
        '
        'TmimataegrafesBindingSource
        '
        Me.TmimataegrafesBindingSource.DataMember = "tmimataegrafes"
        Me.TmimataegrafesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'TmimataegrafesTableAdapter
        '
        Me.TmimataegrafesTableAdapter.ClearBeforeFill = True
        '
        'ApyBindingSource
        '
        Me.ApyBindingSource.DataMember = "apy"
        Me.ApyBindingSource.DataSource = Me.DbhotelDataSet
        '
        'ApyTableAdapter
        '
        Me.ApyTableAdapter.ClearBeforeFill = True
        '
        'EggrafitakiniseisBindingSource
        '
        Me.EggrafitakiniseisBindingSource.DataMember = "eggrafitakiniseis"
        Me.EggrafitakiniseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'EggrafitakiniseisTableAdapter
        '
        Me.EggrafitakiniseisTableAdapter.ClearBeforeFill = True
        '
        'KiniseisjoineggrafesBindingSource
        '
        Me.KiniseisjoineggrafesBindingSource.DataMember = "kiniseisjoineggrafes"
        Me.KiniseisjoineggrafesBindingSource.DataSource = Me.DbhotelDataSet
        '
        'KiniseisjoineggrafesTableAdapter
        '
        Me.KiniseisjoineggrafesTableAdapter.ClearBeforeFill = True
        '
        'GramatiaBindingSource
        '
        Me.GramatiaBindingSource.DataMember = "gramatia"
        Me.GramatiaBindingSource.DataSource = Me.DbhotelDataSet
        '
        'GramatiaTableAdapter
        '
        Me.GramatiaTableAdapter.ClearBeforeFill = True
        '
        'LogariasmoidiamBindingSource
        '
        Me.LogariasmoidiamBindingSource.DataMember = "logariasmoidiam"
        Me.LogariasmoidiamBindingSource.DataSource = Me.DbhotelDataSet
        '
        'LogariasmoidiamTableAdapter
        '
        Me.LogariasmoidiamTableAdapter.ClearBeforeFill = True
        '
        'Main_curanteBindingSource
        '
        Me.Main_curanteBindingSource.DataMember = "main_curante"
        Me.Main_curanteBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Main_curanteTableAdapter
        '
        Me.Main_curanteTableAdapter.ClearBeforeFill = True
        '
        'Katastasi_astynomiasBindingSource
        '
        Me.Katastasi_astynomiasBindingSource.DataMember = "katastasi_astynomias"
        Me.Katastasi_astynomiasBindingSource.DataSource = Me.DbhotelDataSet
        '
        'Katastasi_astynomiasTableAdapter
        '
        Me.Katastasi_astynomiasTableAdapter.ClearBeforeFill = True
        '
        'NonshowkratiseisBindingSource
        '
        Me.NonshowkratiseisBindingSource.DataMember = "nonshowkratiseis"
        Me.NonshowkratiseisBindingSource.DataSource = Me.DbhotelDataSet
        '
        'NonshowkratiseisTableAdapter
        '
        Me.NonshowkratiseisTableAdapter.ClearBeforeFill = True
        '
        'CalendarBindingSource
        '
        Me.CalendarBindingSource.DataMember = "calendar"
        Me.CalendarBindingSource.DataSource = Me.DbhotelDataSet
        '
        'CalendarTableAdapter
        '
        Me.CalendarTableAdapter.ClearBeforeFill = True
        '
        'KleisimoHmeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1429, 978)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "KleisimoHmeras"
        Me.Text = "Κλείσιμο Ημέρας"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.KleisimoZentralPnl.ResumeLayout(False)
        Me.KoutsPnl.ResumeLayout(False)
        Me.KoutsPnl.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.KleisimoPnl.ResumeLayout(False)
        Me.KleisimoPnl.PerformLayout()
        Me.HouseEuropePnl.ResumeLayout(False)
        Me.HouseEuropePnl.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ForoiPnl.ResumeLayout(False)
        Me.ForoiPnl.PerformLayout()
        Me.SigkPnl.ResumeLayout(False)
        Me.SigkPnl.PerformLayout()
        Me.ExtraParEktPnl.ResumeLayout(False)
        Me.ExtraParEktPnl.PerformLayout()
        Me.EkdosiApyPnl.ResumeLayout(False)
        Me.EkdosiApyPnl.PerformLayout()
        Me.EkdosiApy2Pnl.ResumeLayout(False)
        Me.EkdosiApy2Pnl.PerformLayout()
        Me.ZentralPnl.ResumeLayout(False)
        Me.SynolPnl.ResumeLayout(False)
        Me.SynolPnl.PerformLayout()
        Me.Kratiseis3Pnl.ResumeLayout(False)
        Me.Kratiseis3Pnl.PerformLayout()
        Me.Kratiseis2Pnl.ResumeLayout(False)
        Me.Kratiseis2Pnl.PerformLayout()
        Me.Kratiseis1Pnl.ResumeLayout(False)
        Me.Kratiseis1Pnl.PerformLayout()
        Me.EtiketaErgHmPnl.ResumeLayout(False)
        Me.EtiketaErgHmPnl.PerformLayout()
        Me.AstyKatPnl.ResumeLayout(False)
        Me.AstyKatPnl.PerformLayout()
        Me.KatastElegxouPnl.ResumeLayout(False)
        Me.KatastElegxouPnl.PerformLayout()
        Me.MetritoisPnl.ResumeLayout(False)
        Me.Metritis1Pnl.ResumeLayout(False)
        Me.Metritis1Pnl.PerformLayout()
        Me.KefalidaPnl.ResumeLayout(False)
        Me.KefalidaPnl.PerformLayout()
        Me.EkdosiParastPnl.ResumeLayout(False)
        Me.EkdosiParast2Pnl.ResumeLayout(False)
        Me.EkdosiParast2Pnl.PerformLayout()
        Me.EkdosiParast1Pnl.ResumeLayout(False)
        Me.EkdosiParast1Pnl.PerformLayout()
        Me.BiblPortasPnl.ResumeLayout(False)
        Me.BiblPortasPnl.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.DailyReportPnl.ResumeLayout(False)
        Me.DailyReportPnl.PerformLayout()
        Me.MainCourantePnl.ResumeLayout(False)
        Me.MainCourantePnl.PerformLayout()
        Me.EkdosiGEMazikiPnl.ResumeLayout(False)
        Me.EkdosiGEMazikiPnl.PerformLayout()
        Me.AkyrosiPnl.ResumeLayout(False)
        Me.AkyrosiPnl.PerformLayout()
        Me.LogarAnaxPnl.ResumeLayout(False)
        Me.LogarAnaxPnl.PerformLayout()
        Me.BiblPortApyPnl.ResumeLayout(False)
        Me.BiblPortApyPnl.PerformLayout()
        Me.TmimSigkentrPnl.ResumeLayout(False)
        Me.TmimSigkentr2Pnl.ResumeLayout(False)
        Me.TmimSigkentr2Pnl.PerformLayout()
        Me.LogistirioEktPnl.ResumeLayout(False)
        Me.LogistirioEkt1Pnl.ResumeLayout(False)
        Me.LogistirioEkt1Pnl.PerformLayout()
        Me.TmimataKnsPnl.ResumeLayout(False)
        Me.TmimataKns1Pnl.ResumeLayout(False)
        Me.TmimataKns1Pnl.PerformLayout()
        Me.EtiketaPnl.ResumeLayout(False)
        Me.EtiketaPnl.PerformLayout()
        CType(Me.DbhotelDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbhotelDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vilapraktoreia1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogariasmoianaxwrountwnBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TipoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KlinesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EthnikotitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatigoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DwmatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParastatikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PistwtikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EtaireiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BiblioportasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KatastasiapyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisenilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EpanekdositimologiouBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimologioanalysisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrewseispraktoreiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimbolaiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaidiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnilikesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TouristperiodoiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllotmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeskratisisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimfoniesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OverunterkuenfteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TmimataegrafesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EggrafitakiniseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KiniseisjoineggrafesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GramatiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogariasmoidiamBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Main_curanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Katastasi_astynomiasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NonshowkratiseisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalendarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents KleimoImerasTreeView As System.Windows.Forms.TreeView
    Friend WithEvents KleisimoZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaPnl As System.Windows.Forms.Panel
    Friend WithEvents EtiketaLbl As System.Windows.Forms.Label
    Friend WithEvents TmimataKnsPnl As System.Windows.Forms.Panel
    Friend WithEvents TmimataKns2Pnl As System.Windows.Forms.Panel
    Friend WithEvents TmimataKns1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TmimKnsImerom As System.Windows.Forms.DateTimePicker
    Friend WithEvents TmimataTmTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents LogistirioEktPnl As System.Windows.Forms.Panel
    Friend WithEvents LogistirioEkt1Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Logistirio2Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Logistirio1Pck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Logistirio3Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Logistirio2Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Logistirio1Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents Logistirio4Rdb As System.Windows.Forms.RadioButton
    Friend WithEvents LogistirioEktBtn As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TmimSigkentrPnl As System.Windows.Forms.Panel
    Friend WithEvents TmimSigkentr2Pnl As System.Windows.Forms.Panel
    Friend WithEvents TmimSigkentrBtn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TmimSigkentrPnlerPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents MetritoisPnl As System.Windows.Forms.Panel
    Friend WithEvents Metritis1Pnl As System.Windows.Forms.Panel
    Friend WithEvents EggrafiCbx As System.Windows.Forms.ComboBox
    Friend WithEvents AitiaTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TmimaTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents KefalidaPnl As System.Windows.Forms.Panel
    Friend WithEvents MaisonLbl As System.Windows.Forms.Label
    Friend WithEvents PosoLbl As System.Windows.Forms.Label
    Friend WithEvents FpaLbl As System.Windows.Forms.Label
    Friend WithEvents FpaPnl As System.Windows.Forms.Panel
    Friend WithEvents PosaPnl As System.Windows.Forms.Panel
    Friend WithEvents DecoPnl As System.Windows.Forms.Panel
    Friend WithEvents XPnl As System.Windows.Forms.Panel
    Friend WithEvents PlirCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents MetritisSpeichPnl As System.Windows.Forms.Panel
    Friend WithEvents TmimSigkentrPnlerCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents KatastElegxouPnl As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents KatastElegxPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents KatastChkBoxPnl As System.Windows.Forms.Panel
    Friend WithEvents KatastElegxouBtn As System.Windows.Forms.Button
    Friend WithEvents EkdosiApyPnl As System.Windows.Forms.Panel
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents EkdosiApy1Btn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents EkdosiApyPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents EkdosiApy2Btn As System.Windows.Forms.Button
    Friend WithEvents WaitLbl As System.Windows.Forms.Label
    Friend WithEvents EkdosiApy2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiApy3Btn As System.Windows.Forms.Button
    Friend WithEvents EkdosiApyTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EkdosiParastPnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiParast2Pnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiParastYpnosChk As System.Windows.Forms.CheckBox
    Friend WithEvents EkdosiParastNeoBtn As System.Windows.Forms.Button
    Friend WithEvents EkdosiParastKataxBtn As System.Windows.Forms.Button
    Friend WithEvents EkdosiParastTrPliromCbx As System.Windows.Forms.ComboBox
    Friend WithEvents EkdosiParastProkatabTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastEktBtn As System.Windows.Forms.Button
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label100 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents EkdosiParastSynolaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastAllFpaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastDeipnoFpaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastGeumaFpaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastPrwinoFpaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastYpnosFpaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastAllTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastDeipnoTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastGeumaTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastPrwinoTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastYpnosTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents EkdosiParast1Pnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiParastParastFindeBtn As System.Windows.Forms.Button
    Friend WithEvents EkdosiParastPraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents EkdosiParastParastAitTbx As System.Windows.Forms.TextBox
    Friend WithEvents EkdosiParastAATbx As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents EkdosiParastParastCbx As System.Windows.Forms.ComboBox
    Friend WithEvents EkdosiParastPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents ZentralPnl As System.Windows.Forms.Panel
    Friend WithEvents ButtonsPnl As System.Windows.Forms.Panel
    Friend WithEvents SynolPnl As System.Windows.Forms.Panel
    Friend WithEvents EkptosiLbl As System.Windows.Forms.Label
    Friend WithEvents EkptosiBtn As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents PliromCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents SynolLbl As System.Windows.Forms.Label
    Friend WithEvents Kratiseis4Pnl As System.Windows.Forms.Panel
    Friend WithEvents Kratiseis3Pnl As System.Windows.Forms.Panel
    Friend WithEvents DwmSucheImeromBtn As System.Windows.Forms.Button
    Friend WithEvents DwmatiaKratisisBtn As System.Windows.Forms.Button
    Friend WithEvents NonShowLbl As System.Windows.Forms.Label
    Friend WithEvents TimesBtn As System.Windows.Forms.Button
    Friend WithEvents TipiCbx As System.Windows.Forms.ComboBox
    Friend WithEvents KlinesCbx As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DwmatFreeBtn As System.Windows.Forms.Button
    Friend WithEvents DwmTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SimbCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Kratiseis2Pnl As System.Windows.Forms.Panel
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents PaidiTbx3 As System.Windows.Forms.TextBox
    Friend WithEvents CotTbx3 As System.Windows.Forms.TextBox
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents EthnKwd2 As System.Windows.Forms.TextBox
    Friend WithEvents EthnKwd1 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents SimetTbx As System.Windows.Forms.TextBox
    Friend WithEvents ApyBtn As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ProkatTbx As System.Windows.Forms.TextBox
    Friend WithEvents EpithimTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TilefTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents EthnikTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents EthnAnzTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents EthnikTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents EthnAnzTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PaidiTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents CotTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PaidiTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents CotTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OnomTbx3 As System.Windows.Forms.TextBox
    Friend WithEvents OnomTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents OnomTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents EnilikTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents EtiketaErgHmPnl As System.Windows.Forms.Panel
    Friend WithEvents EtikLbl As System.Windows.Forms.Label
    Friend WithEvents BiblPortasPnl As System.Windows.Forms.Panel
    Friend WithEvents BiblPortasBtn As System.Windows.Forms.Button
    Friend WithEvents MorfiRdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents MorfiRdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ProxeirRdb As System.Windows.Forms.RadioButton
    Friend WithEvents TheorimRdb As System.Windows.Forms.RadioButton
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents BiblPortApyPnl As System.Windows.Forms.Panel
    Friend WithEvents BiblPortApyBtn As System.Windows.Forms.Button
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents BiblPortApyPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents KleisimoPnl As System.Windows.Forms.Panel
    Friend WithEvents KleisImerErgLbl As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents KleisimoPck1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents KleisimoBtn As System.Windows.Forms.Button
    Friend WithEvents LogarAnaxPnl As System.Windows.Forms.Panel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents LogarAnaxBtn As System.Windows.Forms.Button
    Friend WithEvents LogarAnaxPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents DbhotelDataSet As winhotel.dbhotelDataSet
    Friend WithEvents TipoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TipoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.tipoiTableAdapter
    Friend WithEvents KlinesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KlinesTableAdapter As winhotel.dbhotelDataSetTableAdapters.klinesTableAdapter
    Friend WithEvents EthnikotitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EthnikotitesTableAdapter As winhotel.dbhotelDataSetTableAdapters.ethnikotitesTableAdapter
    Friend WithEvents KatigoriesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatigoriesTableAdapter As winhotel.dbhotelDataSetTableAdapters.katigoriesTableAdapter
    Friend WithEvents DwmatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DwmatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.dwmatiaTableAdapter
    Friend WithEvents ParastatikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ParastatikaTableAdapter As winhotel.dbhotelDataSetTableAdapters.parastatikaTableAdapter
    Friend WithEvents XrewseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseisTableAdapter
    Friend WithEvents PistwtikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PistwtikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.pistwtikesTableAdapter
    Friend WithEvents PraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.praktoreiaTableAdapter
    Friend WithEvents EtaireiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EtaireiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.etaireiaTableAdapter
    Friend WithEvents BiblioportasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BiblioportasTableAdapter As winhotel.dbhotelDataSetTableAdapters.biblioportasTableAdapter
    Friend WithEvents KatastasiapyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KatastasiapyTableAdapter As winhotel.dbhotelDataSetTableAdapters.katastasiapyTableAdapter
    Friend WithEvents KratiseisenilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisenilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisenilikesTableAdapter
    Friend WithEvents LogariasmoianaxwrountwnBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LogariasmoianaxwrountwnTableAdapter As winhotel.dbhotelDataSetTableAdapters.logariasmoianaxwrountwnTableAdapter
    Friend WithEvents EpanekdositimologiouBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EpanekdositimologiouTableAdapter As winhotel.dbhotelDataSetTableAdapters.epanekdositimologiouTableAdapter
    Friend WithEvents TimologiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologiaTableAdapter
    Friend WithEvents TimologioanalysisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimologioanalysisTableAdapter As winhotel.dbhotelDataSetTableAdapters.timologioanalysisTableAdapter
    Friend WithEvents KratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.kratiseisTableAdapter
    Friend WithEvents XrewseispraktoreiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XrewseispraktoreiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.xrewseispraktoreiaTableAdapter
    Friend WithEvents TmimataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TmimataTableAdapter As winhotel.dbhotelDataSetTableAdapters.tmimataTableAdapter
    Friend WithEvents SimbolaiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimbolaiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.simbolaiaTableAdapter
    Friend WithEvents PaidiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PaidiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.paidiaTableAdapter
    Friend WithEvents EnilikesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EnilikesTableAdapter As winhotel.dbhotelDataSetTableAdapters.enilikesTableAdapter
    Friend WithEvents TouristperiodoiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TouristperiodoiTableAdapter As winhotel.dbhotelDataSetTableAdapters.touristperiodoiTableAdapter
    Friend WithEvents AllotmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AllotmentTableAdapter As winhotel.dbhotelDataSetTableAdapters.allotmentTableAdapter
    Friend WithEvents TimeskratisisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimeskratisisTableAdapter As winhotel.dbhotelDataSetTableAdapters.timeskratisisTableAdapter
    Friend WithEvents TimesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TimesTableAdapter As winhotel.dbhotelDataSetTableAdapters.timesTableAdapter
    Friend WithEvents SimfoniesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SimfoniesTableAdapter As winhotel.dbhotelDataSetTableAdapters.simfoniesTableAdapter
    Friend WithEvents StatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusTableAdapter As winhotel.dbhotelDataSetTableAdapters.statusTableAdapter
    Friend WithEvents OverBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OverTableAdapter As winhotel.dbhotelDataSetTableAdapters.overTableAdapter
    Friend WithEvents OverunterkuenfteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OverunterkuenfteTableAdapter As winhotel.dbhotelDataSetTableAdapters.overunterkuenfteTableAdapter
    Friend WithEvents TmimataegrafesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TmimataegrafesTableAdapter As winhotel.dbhotelDataSetTableAdapters.tmimataegrafesTableAdapter
    Friend WithEvents ApyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ApyTableAdapter As winhotel.dbhotelDataSetTableAdapters.apyTableAdapter
    Friend WithEvents EggrafitakiniseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EggrafitakiniseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.eggrafitakiniseisTableAdapter
    Friend WithEvents KiniseisjoineggrafesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KiniseisjoineggrafesTableAdapter As winhotel.dbhotelDataSetTableAdapters.kiniseisjoineggrafesTableAdapter
    Friend WithEvents AkyrosiPnl As System.Windows.Forms.Panel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents AkyrosiPck1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents AkyrosiBtn As System.Windows.Forms.Button
    Friend WithEvents AkyrosiChk As System.Windows.Forms.CheckBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents AkyrosiPck2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LogRdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents LogRdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents GramatiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GramatiaTableAdapter As winhotel.dbhotelDataSetTableAdapters.gramatiaTableAdapter
    Friend WithEvents EkdosiGEMazikiPnl As System.Windows.Forms.Panel
    Friend WithEvents EkdosiGEMazikiRdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents EkdosiGEMazikiRdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents EkdosiGEMazikiBtn As System.Windows.Forms.Button
    Friend WithEvents EkdosiGEMazikiPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents LogariasmoidiamBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LogariasmoidiamTableAdapter As winhotel.dbhotelDataSetTableAdapters.logariasmoidiamTableAdapter
    Friend WithEvents MainCourantePnl As System.Windows.Forms.Panel
    Friend WithEvents MainCouranteRdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents MainCouranteRdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents MainCouranteBtn As System.Windows.Forms.Button
    Friend WithEvents MainCourantePck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Main_curanteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Main_curanteTableAdapter As winhotel.dbhotelDataSetTableAdapters.main_curanteTableAdapter
    Friend WithEvents DailyReportPnl As System.Windows.Forms.Panel
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents DailyReportTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents DialyReportBtn As System.Windows.Forms.Button
    Friend WithEvents DailyReportPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents AstyKatPnl As System.Windows.Forms.Panel
    Friend WithEvents AstyKatRdb3 As System.Windows.Forms.RadioButton
    Friend WithEvents AstyKatRdb1 As System.Windows.Forms.RadioButton
    Friend WithEvents AstyKatRdb2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents AstyKatBtn As System.Windows.Forms.Button
    Friend WithEvents AstyKatPck As System.Windows.Forms.DateTimePicker
    Friend WithEvents Katastasi_astynomiasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Katastasi_astynomiasTableAdapter As winhotel.dbhotelDataSetTableAdapters.katastasi_astynomiasTableAdapter
    Friend WithEvents ExtraParEktPnl As System.Windows.Forms.Panel
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents ExtraParEktPck2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents ExtraParEktPck1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ExtraParEktBtn As System.Windows.Forms.Button
    Friend WithEvents NonshowkratiseisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NonshowkratiseisTableAdapter As winhotel.dbhotelDataSetTableAdapters.nonshowkratiseisTableAdapter
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents kwdEthnik2 As System.Windows.Forms.TextBox
    Friend WithEvents kwdEthnik1 As System.Windows.Forms.TextBox
    Friend WithEvents SimbLbl As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Kratiseis1Pnl As System.Windows.Forms.Panel
    Friend WithEvents KwdPraktTbx2 As System.Windows.Forms.TextBox
    Friend WithEvents KwdPraktTbx1 As System.Windows.Forms.TextBox
    Friend WithEvents ImeromKratTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents VoucherTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PraktTimolTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PraktTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents KratisiTbx As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TimologioChk As System.Windows.Forms.CheckBox
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents ApyCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents apyEkdCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents ParastCbx As System.Windows.Forms.ComboBox
    Friend WithEvents questChk As System.Windows.Forms.CheckBox
    Friend WithEvents directChk As System.Windows.Forms.CheckBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents daysbeforeTbx As System.Windows.Forms.TextBox
    Friend WithEvents arrivalLbl As System.Windows.Forms.Label
    Friend WithEvents CalendarBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CalendarTableAdapter As winhotel.dbhotelDataSetTableAdapters.calendarTableAdapter
    Friend WithEvents SigkPnl As System.Windows.Forms.Panel
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents SigkPck2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents SigkPck1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents SigkBtn As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents sigkEkdCbx As System.Windows.Forms.ComboBox
    Friend WithEvents kenaCkb As System.Windows.Forms.CheckBox
    Friend WithEvents DbhotelDataSet1 As winhotel.dbhotelDataSet1
    Friend WithEvents KratiseisBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents KratiseisTableAdapter1 As winhotel.dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Friend WithEvents TableAdapterManager As winhotel.dbhotelDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents sendresidentsOK As System.Windows.Forms.CheckBox
    Friend WithEvents blinkLbl2 As System.Windows.Forms.Label
    Friend WithEvents ForosChk As System.Windows.Forms.CheckBox
    Friend WithEvents ForoiPnl As System.Windows.Forms.Panel
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents ForoiCbx As System.Windows.Forms.ComboBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents ForoiPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents ForoiPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ForoiBtn As System.Windows.Forms.Button
    Friend WithEvents pistosiRdb As System.Windows.Forms.RadioButton
    Friend WithEvents KartesRdb As System.Windows.Forms.RadioButton
    Friend WithEvents MetrRdb As System.Windows.Forms.RadioButton
    Friend WithEvents OloiRdb As System.Windows.Forms.RadioButton
    Friend WithEvents HouseEuropePnl As System.Windows.Forms.Panel
    Friend WithEvents HouseEuropeBtn As System.Windows.Forms.Button
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents KoutsPnl As System.Windows.Forms.Panel
    Friend WithEvents KoutsBtn As System.Windows.Forms.Button
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Vilapraktoreia1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Vilapraktoreia1TableAdapter As winhotel.dbhotelDataSet1TableAdapters.vilapraktoreia1TableAdapter
End Class
