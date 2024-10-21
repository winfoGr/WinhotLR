Imports System.Net
Imports System.Net.Mail
Imports Google.GData.Calendar
Imports Google.GData.Extensions
Imports Google.GData.Client
'Imports Google.AccessControl
Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports MessagingToolkit.QRCode
Imports MessagingToolkit.QRCode.Codec
Public Class KleisimoHmeras
    Dim connectionString As String
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim rechte As Byte

    'edw globale Variable fuer Katastasi Elegxou APY
    Dim sumYpnos, sumAllincl, sumPrwino, sumGeumata, sumExtra As Single 'sumSumNeto, sumSumFpa
    Dim sumsumYpnos, sumsumAllincl, sumsumPrwino, sumsumGeumata, sumsumExtra, sumsumPistosi, sumSynKrat As Single
    Dim sumsumFpaAllincl, sumsumFpaYpnos, sumsumFpaPrwino, sumsumFpaGeumata, sumsumFpaExtra, sumSynola As Single
    Dim indexPrakt As Int16
    Dim rR, bB, hB, fB, aI As Boolean
    Dim xrewsXr() As String ' edw anagrafw poies xrewseis 'paizoun' z.B. (ai,rr)
    Dim kwdApyAfm, kwdSigkAfm, kwdForoiAfm As Integer
    '***************EKDOSI APY*****
    'ACHTUNG->isxuoun kai oi glob variablen fuer katsstasi Elegxou:sumYpnos, sumPrwino, sumGeumata, sumExtra
    Dim timolID, simbKrat As Integer 'identification
    Dim sumKratPosa, sumKratFpa As Single
    Dim sumSumPosa, sumYpnosFpa, sumPrwinoFpa, sumGeumataFpa, sumExtraFpa, sumSimet, sumProkat As Single ' sumsumPosa->athroisma KATHARWN poswn tou timologiou

    '**********************EKDOSI EXTRA  PARASTATIKWN**************************

    Dim synolFpa, synolKathPosa As Single
    Dim aktWerte(4) As Single ' gia tin YFAIRESI parakolouthw ta werte tou ypnou,geumatoa ktl, ean exoyn alaksei
    Dim praktParastKwd As Integer
    Dim parastParastKwd As Integer
    Dim parastCboxKwd() As Integer
    Dim aaParast As Integer ', maxAAParast
    Dim arxiEtous, telosEtous As Date '->gia na kanw abfrage gia max AA sto table Timologia(opou DEN iparxei Attribute Etos)->apo atribute imerominia!
    '(gia tin periptosi pou se kathe neo etos exoume NEA arithmisi AA gia timologia!)
    'Dim minParastDate As Date 'H Imerominia tou teleytaiou parastatikou->den epitrepetai na kopei neo me PROGENESTERI imerominia!
    Dim statusParast As Byte ' 1=Insert 2=Update timologio
    Dim kwdParastAfm As Integer
    '***************************ELEGXOS KRATISEIS***************
    Dim flagKr As Byte
    Dim kwdKratAnam() As Integer ' kwdikoi kratiseis anamenwntwn
    Dim sesionID As Integer
    Dim ekptPoso, ekptPososto, ekptFree, ekptCFee As Single

    Dim status As Byte '1=Kratiseis-Afixeis 2=Diamenwntes allagi stoixeiwn
    Dim anaxSperre As Boolean = False 'H Hmerominia Anaxwrisews einai mikroterh tis trexousas->PREPEI NA ALLAKSEI APARAITHTws (stou diamenvntes)
    Dim currentAfixi, currentAnaxwrisi As Date 'gia na parakolouthw allages imerominias->(to event valuechenged mou dimiourgouse problimata efoson exw masboxex na diksw)
    'Dim firstLoadDBEintrag As Boolean
    Dim isDBEintrag As Boolean = False
    Dim kwdikoKratisisDB As Integer = -1
    Dim timokatalog() As Timokatalogos
    Dim praktoreiokwd, praktortimolkwd, currentklines, currenttipos, currentsimbolaio, praktXrewsKwd, praktoreiokwdValue As Integer ' apoimeres
    Dim maxklines As Int16 'maxklines gia na foulara to klines Cbox stis kratiseis->SIMPIPTEI ma to DB kwdiko!!
    Dim currentimerom As Date ' Einai i trexousa Hmerominia apo Parametrous Etaireias (arxika to kanw san globale Vrble->meta parametros stin AUfruf tis ErgasiesHmerasF) 
    'Dim showLblText As Boolean = True
    'Friend WithEvents myTimer2 As New Timer
    Dim availPath As String = "c:\winfo\availabilities.txt"
    Structure Timokatalogos ' APothikeuei (kai) tous DB kwdikouws kathe Tomokatalogou->(enas Timokatalogos gia kathe tousristiki periodo tou simbolaiou)
        'Dim status As Byte '1=insert 2=update 3=delete
        Dim kwdDB As Integer
        Dim tourist As Integer
        Dim simfonia As Integer
        Dim xrewsiDB As Integer 'apothikeusi arxikis xrewsis stous diamenwntes->gia parakolouthisi alaghs xrewsis
        Dim xrewsi As Integer
        Dim timi As Integer
        Dim paroxiDB As Single
        Dim paroxi As Single
        Dim paroxiTemp As Single
        Dim apo As Date
        Dim mexri As Date
        Dim mexriDB As Date
        Dim imeresTotal As Int16
        Dim imeresPlirom As Int16
        Dim imeresPliromDB As Int16
        Dim ekptosi As Single
        Dim ekptosiDB As Single
        Dim ypnosDB As Single ' timi tis basis-> arxiki timi!->gia sugkrisi ean alaksan oi times apo user->xrisimeuei gia ypologismo "dedouleumenwn" stin allagi timwn stous diamenwntes!
        Dim ypnos As Single ' timi basis (alla me mia allagh->ean einai 0 i timi basis tote pairnei tin timi temp (sender.text)->gia upologismo ekptwsewn)
        Dim ypnosTemp As Single 'prwsorini apothikeusi allagwn timis ypnou (sender.text apo user) (-> gia na mporei na 'paizei' kaneis me ekptoseis epi twv arxikwn timwn
        Dim prwinoDB As Single
        Dim prwino As Single
        Dim prwinoTemp As Single
        Dim geumaDB As Single
        Dim geuma As Single
        Dim geumaTemp As Single
        Dim deipnoDB As Single
        Dim deipno As Single
        Dim deipnoTemp As Single
        Dim synoloDB As Single
        Dim synolo As Single
        Dim synoloTemp As Single
    End Structure


    'edw globale Variable fuer Emfanisis Analytikis Kinishs Tmimatwn
    Dim tmimaKd As Integer
    Structure Koordinaten ' exw Daiforetiko Anzahl apo Fpa sta tmimata-> merken Location sto malen pou einai i kefalida !!!!
        Dim locX As Single
        Dim fpa As Single 'Mono gia to FPA stin epikefalida-> alliws einai -1!!!!!!!
    End Structure

    'edw globale Variable fuer Ektiposi Analytikis Kinishs LOGISTIRIO
    Dim fpaLog() As Single 'ola ta fpa pou paizoun-> apo etaireia (fpatriofis1,2,3) gia timologioanalysis DB kathws kasi ola ta fpa tmimatwn
    'edw globale Variablen twn tmimata METRITOIS
    Structure Kinisi
        Dim kwdKin As Integer
        Dim fpa As Single
        Dim poso As Single
        Dim netopos As Single
        Dim fpapos As Single
        Dim maizon As Single
        Dim netomaizon As Single
        Dim fpamaizon As Single
        'Dim fpapos As Single
    End Structure
    'Dim sum(5) As Single
    Dim kiniseis() As Kinisi
    'Dim parastCboxKwd() As Integer
    Dim tmimaMKwd, eggrafiKwd As Integer 'DB kwdikoi von Tmimata kai TmimataEggrafes
    Dim afmdapter1 As New dbhotelDataSet1TableAdapters.afmTableAdapter
    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles KleimoImerasTreeView.AfterSelect
        Select Case KleimoImerasTreeView.SelectedNode.Name.ToString
            Case "katast_elegxou"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.katastasi_elegxou_apy()
            Case "ekdosi_apy"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekdosi_apy()
            Case "ekdosi_extra_parastatikwn"
                Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
                'Me.ParastatikaTableAdapter.FillApyPistotika(Me.DbhotelDataSet.parastatika, 2, 5)
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                'Me.ParastatikaTableAdapter.FilApyPistotiko(Me.DbhotelDataSet.parastatika) ' fortwnw mono apy kai psitwtiko timologio->PREPEI na einai ta 2 prwta stin DB
                'Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ekdosi_extra_parastatikwn()
            Case "ektiposi_extra_par"
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                'Me.ParastatikaTableAdapter.FillApyPistotika(Me.DbhotelDataSet.parastatika, 2, 5)
                'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
                'Me.ParastatikaTableAdapter.FilApyPistotiko(Me.DbhotelDataSet.parastatika) ' fortwnw mono apy kai psitwtiko timologio->PREPEI na einai ta 2 prwta stin DB
                'Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ektiposi_extra_parastatikwn()
            Case "logariasmoi_pelatwn"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                logariasmoi_anaxwrountwn()

            Case "ekdosi_ge"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ekdosi_ge_maziki()
            Case "elegxos_afixewn"
                'status = 1
                praktoreiokwd = -1
                praktoreiokwdValue = -1
                'DateTimePicker2.Enabled = True
                'Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)
                'Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                elegxos_afixewn()
            Case "koutsour"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ektiposi_bibliou_portas_koutsour()
            Case "europe"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ektiposi_bibliou_portas_house_europe()
            Case "ekt_biblio_portas"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ektiposi_bibliou_portas()
            Case "ekt_atheorita_apy"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                ektiposi_atheorita_apy()
            Case "kleisimo_imeras"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                kleisimo_imeras()
            Case "akyrosi_kleisimatos"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                akyrosi_kleisimatos()
            Case "emf_anal_kin_imeras"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.emf_anal_kin_imeras()
            Case "ekt_sigkentr_kin_imeras"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_sigkentr_kin_imeras()
            Case "ekt_logistirio"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_logistirio()
            Case "allages_kinisi_tmimatwn"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.allages_kinisi_tmimatwn()
            Case "main_courante"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_main_courante()
            Case "daily_report"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_daily_report()
            Case "asty_kat"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_asty_kat()
            Case "Sigkentrotiki"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_sigkentrwtiki_tim()
            Case "Foroi"
                Me.KleisimoZentralPnl.Controls.Clear()
                Me.KleisimoZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.KleisimoZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.KleisimoZentralPnl.Dock = DockStyle.Fill
                Me.ekt_foroi()

        End Select

    End Sub



    Private Sub disable_nodes()
        For Each node As TreeNode In KleimoImerasTreeView.Nodes
            If node.Name = "elegxos_afixewn" Then
                node.ForeColor = Color.Gray
            End If
            GetAllChildren(node)
        Next
    End Sub

    Private Sub GetAllChildren(parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            If childNode.Name = "europe" Or childNode.Name = "koutsour" Or childNode.Name = "emf_anal_kin_imeras" Or childNode.Name = "ekdosi_extra_parastatikwn" Or childNode.Name = "ekt_sigkentr_kin_imeras" Or childNode.Name = "ekt_logistirio" Or childNode.Name = "allages_kinisi_tmimatwn" Then
                childNode.ForeColor = Color.Gray
            ElseIf Not childNode.BackColor = Color.Yellow Then
                childNode.BackColor = Color.Transparent
            End If
            GetAllChildren(childNode)
        Next
    End Sub
    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) _
     Handles KleimoImerasTreeView.BeforeSelect
        If (Color.Gray = e.Node.ForeColor) Or (rechte = 0 And Color.Transparent = e.Node.BackColor) Then
            e.Cancel = True
        End If
    End Sub

    'DIADIKASIA KLEISIMATOS:
    'automati EKTYPOSI API (mem,>stis Kratiseis markaretai to flag "timologio" me 1 kai to Atribute APY pairnei to AA tis APY pou exei ektdothei )
    '- ektiposi bibliou portas ->tote ginetai ousiastika Chekout (stin proxeiri ektiposi ektiponetai i MEXRI stigmis
    'katastasi ENW stin theorimeni (Episimi) prepei na exoun bgei OLA ta APY!!->to flag sto biblioportas dilwnei ean exei bgei theorimeni ektiposi-> EAN einai 1
    'tote se EPANEKTIPOSI tis theoirimenis DEN emfanizontai ta eintraege pou exoun IDI ektipothei ->stin PROXEIRH ektiposi  NAI )
    '(otan ginei ektiposi kathe mias apo tis 2 ektyposeis tou Bibliou Portas tote sto DB Etaireia markarwntai me 1 ta flags (ektportasflag,ektportasapyflag) )
    '- Gia to kleisimo imeras aparaithta einai:
    'Na exoun bgei ola ta APY, na Exei ginei ektiposi GEispraksis, na exei ksekatharisei i Katastasi me tous ANAMENWNTES, ne exoun Ginei kai oi
    ' 2 ektiposeis tou BiblPortas (theorimeni, katastasi APy->ta flags tou Table Etaireia sto Dataset einai me 1 gesetzt )
    '- Gia to AJYROSI kleisimatow imeras meta apo mia orismeni imerominia :
    'proeretika akyrosi twn afixewn-(m e oti auto sumepagetai me status Dwmat- over)
    'akyrosi twn grammatiwn Eispraksis(akyrosi tou Gramatiou sto Table kai midenismos tou aagramatio sto Table logariasmoidiam kai Enimerwsi tou 
    'table parastatika me to aktuelle pleon arrithmo GE)
    'Delete Anaxwrisewn apo BiblioPortas-Enimerwsi Kratisewn (me checkout=false, kai timologio flag=0 ,kai Apy=0)- 

    Public Sub New(ByVal imerominia As Date, ByVal flag As Byte)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        rechte = flag
        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)

        Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)

        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)

        Me.DwmatiaTableAdapter.Fill(Me.DbhotelDataSet.dwmatia)

        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        afmdapter1.Fill(Me.DbhotelDataSet1.afm)
        'TODO: This line of code loads data into the 'DbhotelDataSet.simbolaia' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
        'Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
        'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseis' table. You can move, or remove it, as needed.
        'Me.KratiseisTableAdapter.Fill(Me.DbhotelDataSet.kratiseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseisenilikes' table. You can move, or remove it, as needed.
        'Me.KratiseisenilikesTableAdapter.Fill(Me.DbhotelDataSet.kratiseisenilikes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.kiniseisjoineggrafes' table. You can move, or remove it, as needed.
        'Me.KiniseisjoineggrafesTableAdapter.Fill(Me.DbhotelDataSet.kiniseisjoineggrafes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.pistwtikes' table. You can move, or remove it, as needed.

        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Me.DbhotelDataSet.etaireia(0).connectionstring

        If imerominia = Me.DbhotelDataSet.etaireia(0).imeromergasias Then
            imeromErgasias = imerominia
            'imeromErgasias = "25/5/2007"
            etos = imerominia.Year
            Me.Text = "Κλείσιμο Ημέρας " + imeromErgasias
        Else
            MsgBox(" Εχει αλάξει η τρέχουσα Ημερομηνία Εργασίας! " & vbCrLf & "Πρέπει να τήν ελέγξτε στους Παράμετρους Λειτουργίας της Εταιρείας  ", MsgBoxStyle.Critical, "winfo\nikEl.")
            Me.Close()
        End If
        disable_nodes()

    End Sub

    Public Function get_imeromergasias() As Date
        Return imeromErgasias
    End Function

    '***************"ΚΑΤΑΣΤΑΣΗ ΕΛΕΓΧΟΥ Α.Π.Υ."**************"ΚΑΤΑΣΤΑΣΗ ΕΛΕΓΧΟΥ Α.Π.Υ."***************"ΚΑΤΑΣΤΑΣΗ ΕΛΕΓΧΟΥ Α.Π.Υ."
    Private Sub katastasi_elegxou_apy()

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ΚΑΤΑΣΤΑΣΗ ΕΛΕΓΧΟΥ Α.Π.Υ."

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaLbl.Location = New Point(KatastElegxouPnl.Width / 5, 25)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        KatastElegxouPnl.Location = New Point(10, EtiketaPnl.Height + 10)
        Me.KatastElegxouPnl.Size = New Point(684, 239)

        KatastElegxPck.Value = imeromErgasias
        rR = True
        bB = True
        hB = True
        fB = True
        aI = True
        ReDim xrewsXr(-1)
        'MsgBox(xrewsXr.Length)

        init_katastasi_variablen()
        fuehle_apy_cbx()
        ApyCbx.SelectedIndex = 0
        fuehle_chkbox_pnl()
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(KatastElegxouPnl)
    End Sub
    Private Sub fuehle_chkbox_pnl()
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.xrewseis.Count - 1
            Dim chkbox As New CheckBox
            chkbox.Name = "chk" + Me.DbhotelDataSet.xrewseis(j).xrewsi
            chkbox.Text = Me.DbhotelDataSet.xrewseis(j).xrewsi
            chkbox.Checked = True
            chkbox.Size = New Point(80, 30)
            chkbox.Location = New Point((j + 1) * 90, 10)
            KatastChkBoxPnl.Controls.Add(chkbox)

            AddHandler chkbox.CheckedChanged, AddressOf chkbox_changed

        Next
        'Dim st As String

        'st = Me.DbhotelDataSet.GetXmlSchema()

        'MsgBox(st)

    End Sub
    Private Sub chkbox_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xrewsi As String

        xrewsi = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
        Select Case xrewsi
            Case "AI"
                If sender.checked Then
                    aI = True
                Else
                    aI = False
                End If
            Case "HB"
                If sender.checked Then
                    hB = True
                Else
                    hB = False
                End If
            Case "RR"
                If sender.checked Then
                    rR = True
                Else
                    rR = False
                End If
            Case "FB"
                If sender.checked Then
                    fB = True
                Else
                    fB = False
                End If
            Case "BB"
                If sender.checked Then
                    bB = True
                Else
                    bB = False
                End If
        End Select
        ReDim xrewsXr(-1)
    End Sub
    Private Sub fuehle_apy_cbx()
        Dim j As Int16
        ApyCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet.afm.Count
            If j = 0 Then
                ApyCbx.Items.Add("<Εταιρεία>")
            Else
                ApyCbx.Items.Add(Me.DbhotelDataSet.afm(j - 1).epixirisi)
            End If

        Next

    End Sub
    Private Sub AkyrCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApyCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdApyAfm = -1
        Else
            kwdApyAfm = Me.DbhotelDataSet.afm(sender.selectedINdex - 1).kwd
        End If


    End Sub

    Private Sub KatastElegxouBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KatastElegxouBtn.Click
        Dim firstIndex, stepsIndex, startIndex As Int16
        Dim length As Int16

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DbhotelDataSet.ekt_katast_apy.Clear()

            fuehle_array_mit_xrewseis() ' edw bazw se ena array me strings tis xrewseis pou ''paizoun'

            length = xrewsXr.Length

            Me.DbhotelDataSet.katastasiapy.Clear()
            'kratiseis PRAKTOREIWN (kai oxi privat Apy) pou anaxwroyn XWRIS ekdwmeno timologio (timologio=0 stin DB)
            'EINAI sortiert kata paraktoreio.eponimia-arithmo kratisis-timeskratisis.apo-xrewseis.xrewsi
            Select Case length ' logw epilogis xrewsi apo user->4 Erwtimata(alazei mono to plithos xrewsi.xrewsi=?)
                Case 5
                    Me.KatastasiapyTableAdapter.FillKatastasiApyPraktoreiwnAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, False, False, kwdApyAfm)
                Case 4
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrakt4XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, False, False, xrewsXr(0), xrewsXr(1), xrewsXr(2), xrewsXr(3), kwdApyAfm)
                Case 3
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrakt3XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, False, False, xrewsXr(0), xrewsXr(1), xrewsXr(2), kwdApyAfm)
                Case 2
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrakt2XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, False, False, xrewsXr(0), xrewsXr(1), kwdApyAfm)
                Case 1
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrakt1XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, False, xrewsXr(0), False, kwdApyAfm)
            End Select

            'kratiseis PRAKTOREIWN (kai oxi privat Apy) pou anaxwroyn XWRIS ekdwmeno timologio (timologio=0 stin DB sto table Kratiseis)
            'EINAI sortiert kata paraktoreio.eponimia-arithmo kratisis-timeskratisis.apo-xrewseis.xrewsi

            'EINAI SORTIERT KATA KRATISI
            'Erwtima sto DB Kratiseisenilikes 
            Me.KratiseisenilikesTableAdapter.KatastApyEnilikesByAnaxTimolAFM(Me.DbhotelDataSet.kratiseisenilikes, KatastElegxPck.Value, 0, kwdApyAfm)

            Do Until firstIndex > Me.DbhotelDataSet.katastasiapy.Count - 1
                stepsIndex = 1 'posa eintraege 

                If firstIndex < Me.DbhotelDataSet.katastasiapy.Count - 1 Then
                    While Me.DbhotelDataSet.katastasiapy(firstIndex).praktimologio = Me.DbhotelDataSet.katastasiapy(firstIndex + stepsIndex).praktimologio
                        stepsIndex += 1
                        If firstIndex + stepsIndex > Me.DbhotelDataSet.katastasiapy.Count - 1 Then
                            Exit While
                        End If
                    End While
                    'MsgBox( stepsIndex)
                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                    apy_praktoreiou(firstIndex, stepsIndex, 1, "--") ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                    firstIndex = firstIndex + stepsIndex
                    'indexPrakt = 0
                Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                    'MsgBox(countIndex)
                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                    apy_praktoreiou(firstIndex, stepsIndex, 1, "--")
                    'indexPrakt = 0
                    Exit Do
                End If
            Loop

            Me.DbhotelDataSet.katastasiapy.Clear()

            'Kratiseis me private pelati pou den exei kopei mexri stigmis Timologio
            '(gia to Join anamesa se kratiseis-Apy->kathe kratisi mporei na exei MONO mia APY ->diplotipa stin DB sto Table APy den epitrepontai) 

            Select Case length
                Case 5
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrivTimAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, True, kwdApyAfm)
                Case 4
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrivTim4XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, True, xrewsXr(0), xrewsXr(1), xrewsXr(2), xrewsXr(3), kwdApyAfm)
                Case 3
                    Me.KatastasiapyTableAdapter.FillBykatastasiApyPrivTim3XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, True, xrewsXr(0), xrewsXr(1), xrewsXr(2), kwdApyAfm)
                Case 2
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrivTim2XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, True, xrewsXr(0), xrewsXr(1), kwdApyAfm)
                Case 1
                    Me.KatastasiapyTableAdapter.FillByKatastasiApyPrivTim1XrewsisAFM(Me.DbhotelDataSet.katastasiapy, KatastElegxPck.Value, 0, True, True, xrewsXr(0), kwdApyAfm)
            End Select

            firstIndex = 0
            stepsIndex = 0

            Do Until firstIndex > Me.DbhotelDataSet.katastasiapy.Count - 1
                stepsIndex = 1 'posa eintraege 

                If firstIndex < Me.DbhotelDataSet.katastasiapy.Count - 1 Then
                    While Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia = Me.DbhotelDataSet.katastasiapy(firstIndex + stepsIndex).eponimia
                        stepsIndex += 1
                        If firstIndex + stepsIndex > Me.DbhotelDataSet.katastasiapy.Count - 1 Then
                            Exit While
                        End If
                    End While
                    'MsgBox( stepsIndex)
                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                    apy_praktoreiou(firstIndex, stepsIndex, 2, "--") ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                    firstIndex = firstIndex + stepsIndex
                    'indexPrakt = 0
                Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                    'MsgBox(countIndex)
                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
                    apy_praktoreiou(firstIndex, stepsIndex, 2, "--")
                    'indexPrakt = 0
                    Exit Do
                End If
            Loop
            Me.DbhotelDataSet.katastasiapy.Clear()

            'KOMMENA TIMOLOGIA PRAKTOREIWN
            Select Case length
                Case 5
                    Me.EpanekdositimologiouTableAdapter.FillApyKatastElegxouByImeromina1AFM(Me.DbhotelDataSet.epanekdositimologiou, KatastElegxPck.Value, False, kwdApyAfm)
                Case 4
                    Me.EpanekdositimologiouTableAdapter.FillByApyKatastElegxouByImeromina4Xrewseis1AFM(Me.DbhotelDataSet.epanekdositimologiou, KatastElegxPck.Value, False, xrewsXr(0), xrewsXr(1), xrewsXr(2), xrewsXr(3), kwdApyAfm)
                Case 3
                    Me.EpanekdositimologiouTableAdapter.FillByApyKatastElegxouByImeromina3Xrewseis1AFM(Me.DbhotelDataSet.epanekdositimologiou, KatastElegxPck.Value, False, xrewsXr(0), xrewsXr(1), xrewsXr(2), kwdApyAfm)
                Case 2
                    Me.EpanekdositimologiouTableAdapter.FillByApyKatastElegxouByImeromina2Xrewseis1AFM(Me.DbhotelDataSet.epanekdositimologiou, KatastElegxPck.Value, False, xrewsXr(0), xrewsXr(1), kwdApyAfm)
                Case 1
                    Me.EpanekdositimologiouTableAdapter.FillByApyKatastElegxouByImeromina1Xrewsi1AFM(Me.DbhotelDataSet.epanekdositimologiou, KatastElegxPck.Value, xrewsXr(0), False, kwdApyAfm)
            End Select


            Do Until startIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1
                stepsIndex = 1 'posa eintraege 
                firstIndex = startIndex
                If startIndex < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                    While Me.DbhotelDataSet.epanekdositimologiou(startIndex).timkwd = Me.DbhotelDataSet.epanekdositimologiou(startIndex + stepsIndex).timkwd
                        stepsIndex += 1
                        If startIndex + stepsIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                            Exit While
                        End If
                    End While
                    fuelle_ekdomena_timologia(startIndex, stepsIndex, 3) ' ana praktoreio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                    startIndex = startIndex + stepsIndex
                    fuelle_synola_praktoreiou(Me.DbhotelDataSet.epanekdositimologiou(firstIndex).eponimia, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).fpa, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa, 3)
                    'sumsumPistosi = sumsumPistosi + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa
                    sumSynKrat = sumSynKrat + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola
                    init_times_variablen()
                Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                    fuelle_ekdomena_timologia(startIndex, stepsIndex, 3)
                    fuelle_synola_praktoreiou(Me.DbhotelDataSet.epanekdositimologiou(firstIndex).eponimia, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).fpa, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa, 3)
                    'sumsumPistosi = sumsumPistosi + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa
                    sumSynKrat = sumSynKrat + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola
                    init_times_variablen()
                    Exit Do
                End If

            Loop

            fuelle_synola_katastasis(5)

            proepiskopisi_katastasi_apy()
            ApyCbx.SelectedIndex = 0
            init_katastasi_variablen()


        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub apy_praktoreiou(ByVal firstIndex As Int16, ByVal stepsIndex As Int16, ByVal flag As Byte, ByVal arithmos As String)
        Dim startIndex, countIndex As Int16
        Dim sumPistosi As Single 'apo kratiseis to sunolo mias kratisis (me fpa)

        startIndex = firstIndex

        Do Until startIndex > firstIndex + stepsIndex - 1
            countIndex = 1 'posa eintraege 

            If startIndex < firstIndex + stepsIndex - 1 Then
                While Me.DbhotelDataSet.katastasiapy(startIndex).arithmos = Me.DbhotelDataSet.katastasiapy(startIndex + countIndex).arithmos 'se periptwsi pou exoume panw apo mia timeskratisis ana kratisi (>1 touristperiodoi)
                    countIndex += 1
                    If startIndex + countIndex > firstIndex + stepsIndex - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)
                'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(startIndex).synolo
                sumPistosi = sumPistosi + Me.DbhotelDataSet.katastasiapy(startIndex).synolo
                fuelle_ekt_katastasi(startIndex, countIndex, flag, arithmos) 'tempIndex arithmisi index gia CrReports->gia na einai ta Row twn sunolwn tou Prakt. stin swsti seira sto CR
                'fuelle_synola_praktoreiou(tempIndex, Me.DbhotelDataSet.katastasiapy(startIndex).eponimia, Me.DbhotelDataSet.katastasiapy(startIndex).praktimologio, Me.DbhotelDataSet.katastasiapy(startIndex).synolo)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(startIndex).synolo
                sumPistosi = sumPistosi + Me.DbhotelDataSet.katastasiapy(startIndex).synolo
                fuelle_ekt_katastasi(startIndex, countIndex, flag, arithmos)
                'fuelle_synola_praktoreiou(tempIndex, Me.DbhotelDataSet.katastasiapy(startIndex).eponimia, Me.DbhotelDataSet.katastasiapy(startIndex).praktimologio, Me.DbhotelDataSet.katastasiapy(startIndex).synolo)

                Exit Do
            End If
        Loop
        'MsgBox(sumPistosi)
        sumSynKrat = sumSynKrat + sumPistosi
        fuelle_synola_praktoreiou(Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia, sumPistosi, 0, 0, flag)
        init_times_variablen()

    End Sub
    Private Sub fuelle_ekt_katastasi(ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal flag As Byte, ByVal arithmos As String)
        Dim imer, minas, praktName As String
        'Dim praktKwd As Integer
        Dim onomTemp() As String
        Dim j, arKrat, ekptIndex, countPaidia As Int16 'ekptIndex i stelle(Row) sto Dataset pou mpainei i Ekptosi , tempIndex arithmisi index gia CrReports
        Dim ypnos, ypnosNeto, prwino, prwinoNeto, geuma, geumaNeto, deipno, deipnoNeto, extra, extraNeto, timiImeras, ypnosTemp, prwinoTemp, geumaTemp, deipnoTemp, extraTemp As Single

        arKrat = Me.DbhotelDataSet.katastasiapy(startIndex).arithmos

        praktName = Me.DbhotelDataSet.katastasiapy(startIndex).eponimia
        'MsgBox(praktName)
        onomTemp = suche_onomata_kratisis(arKrat)

        Array.Reverse(onomTemp)

        For j = startIndex To (startIndex + countIndex - 1)

            Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
            ' groups sto CR->flag,praktoreia,index
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag ' gia Group sto CR ->flag 1 einai kratiseis praktoreiwn, flag 2 memonomenous pelates (Timologio- EIntrag ssto Table APY), flag 3 idi komena timologia 

            indexPrakt += 1
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'j - startIndex + 1 'xreiazetai sto CReport

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = praktName

            'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = arKrat

            If j = startIndex Then
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = arithmos

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).dwmatio = Me.DbhotelDataSet.katastasiapy(j).dwmatio

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).enilikes = Me.DbhotelDataSet.katastasiapy(j).enilikes
                Try
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).paidia = Me.DbhotelDataSet.katastasiapy(j).paidia
                    countPaidia = Me.DbhotelDataSet.katastasiapy(j).paidia
                Catch ex As StrongTypingException
                    countPaidia = 0
                End Try
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).atoma = Me.DbhotelDataSet.katastasiapy(j).enilikes + countPaidia

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).voucher = Me.DbhotelDataSet.katastasiapy(j).voucher
            End If


            If j - startIndex < onomTemp.Length Then
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).onomateponimo = onomTemp(j - startIndex)
            End If

            imer = Me.DbhotelDataSet.katastasiapy(j).apo.Date.Day

            minas = Me.DbhotelDataSet.katastasiapy(j).apo.Date.Month

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = imer + "/" + minas + "-" + Me.DbhotelDataSet.katastasiapy(j).mexri.Date.ToShortDateString

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).meres = Me.DbhotelDataSet.katastasiapy(j).imeres

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).xrewsi = Me.DbhotelDataSet.katastasiapy(j).xrewsi

            'upologizw tis brutto times gia oli tin diarkeia diamonis 
            ypnos = (Me.DbhotelDataSet.katastasiapy(j).ypnos) * Me.DbhotelDataSet.katastasiapy(j).imeres
            prwino = (Me.DbhotelDataSet.katastasiapy(j).prwino) * Me.DbhotelDataSet.katastasiapy(j).imeres
            geuma = (Me.DbhotelDataSet.katastasiapy(j).geuma) * Me.DbhotelDataSet.katastasiapy(j).imeres
            deipno = (Me.DbhotelDataSet.katastasiapy(j).deipno) * Me.DbhotelDataSet.katastasiapy(j).imeres
            extra = (Me.DbhotelDataSet.katastasiapy(j).extra) * Me.DbhotelDataSet.katastasiapy(j).imeres

            timiImeras = Me.DbhotelDataSet.katastasiapy(j).ypnos + Me.DbhotelDataSet.katastasiapy(j).prwino + Me.DbhotelDataSet.katastasiapy(j).geuma + Me.DbhotelDataSet.katastasiapy(j).deipno + Me.DbhotelDataSet.katastasiapy(j).extra

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = timiImeras.ToString("N")

            ypnosNeto = (ypnos / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)))
            'ypnosNeto = (ypnos / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
            If Me.DbhotelDataSet.katastasiapy(j).xrewsi = "AI" Then
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = ypnosNeto.ToString("N")
                sumAllincl = sumAllincl + ypnosNeto
                'sumsumAllincl = sumsumAllincl + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv
            Else
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = ypnosNeto.ToString("N")
                sumYpnos = sumYpnos + ypnosNeto
                'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos
            End If
            ypnosTemp = ypnosTemp + ypnosNeto ' upnosTemp einai to Athroisma ypnou mias Kratisis die ueber 2 Tourist peroden geht->xrisimeuei gia ton Ypologismo
            'tis POSOSTIEAS EKPTWSHS (->alliws i ekptosi p.x. 10% tha itan mono epi tou posou tis Deuteris periodou)


            prwinoNeto = (prwino / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
            'prwinoNeto = (prwino / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = prwinoNeto.ToString("N")
            prwinoTemp = prwinoTemp + prwinoNeto ' prwinoTemp einai to Athroisma prwinou mias Kratisis die ueber 2 Tourist perioden geht->xrisimeuei gia ton Ypologismo
            'tis POSOSTIEAS EKPTWSHS (->alliws i ekptosi p.x. 10% tha itan mono epi tou posou tis Deuteris periodou)
            sumPrwino = sumPrwino + prwinoNeto
            'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino

            geumaNeto = (geuma / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
            geumaTemp = geumaTemp + geumaNeto
            'geumaNeto = (geuma / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
            deipnoNeto = (deipno / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
            deipnoTemp = deipnoTemp + deipnoNeto
            'deipnoNeto = (deipno / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = (geumaNeto + deipnoNeto).ToString("N")
            sumGeumata = sumGeumata + geumaNeto + deipnoNeto
            'sumsumGeumata = sumsumGeumata + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma

            extraNeto = (extra / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)))
            'extraNeto = (extra / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100))).ToString("N")
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = extraNeto.ToString("N")
            extraTemp = extraTemp + extraNeto
            sumExtra = sumExtra + extraNeto
            'sumsumExtra = sumsumExtra + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra

        Next

        If countIndex < onomTemp.Length Then

            For j = countIndex To onomTemp.Length - 1

                Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                indexPrakt += 1
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' j + 1 'xreiazetai sto CReport

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = praktName

                'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = arKrat

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).onomateponimo = onomTemp(j)

                If j = countIndex Then '   ekptIndex einai i Stelle sto Dataset pou mporw na balw tin ekptosi ean yparxei
                    ekptIndex = Me.DbhotelDataSet.ekt_katast_apy.Count - 1
                End If

            Next
        End If
        'koitw to teleutaio eintrag (startIndex + countIndex - 1) katastasiapy poy anaferei tis ekptoseis 
        If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptosi Then
            If ekptIndex = 0 Then ' den yparxei freie stelle ->dimiourgw nea Row
                Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                indexPrakt += 1
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' countIndex + 1 'xreiazetai sto CReport

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = praktName

                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = arKrat

                'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

                ekptIndex = Me.DbhotelDataSet.ekt_katast_apy.Count - 1 ' nea freeie stelle sto Dataset gia eisagwgi stoixeiwn ekptwsis
            End If

            'eisagwgi soixeiwn stin stelle ekptIndex
            If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto <> 0 Then

                Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).imerominies = "Ποσ.Εκπτ." + (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto).ToString + "%"

                If ypnosTemp <> 0 Then
                    If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).xrewsi = "AI" Then
                        Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).allinclusiv = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * ypnosTemp / 100).ToString("N")
                        sumAllincl = sumAllincl - (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * ypnosTemp / 100)
                        'sumsumAllincl = sumsumAllincl + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).allinclusiv
                    Else
                        Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * ypnosTemp / 100).ToString("N")
                        sumYpnos = sumYpnos - (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * ypnosTemp / 100)
                        'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos
                    End If


                End If
                If prwinoTemp <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).prwino = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * prwinoTemp / 100).ToString("N")
                    sumPrwino = sumPrwino - (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * prwinoTemp / 100)
                    'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).prwino
                End If
                If geumaTemp <> 0 Or deipnoTemp <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).geuma = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * (geumaTemp + deipnoTemp) / 100).ToString("N")
                    sumGeumata = sumGeumata - (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * (geumaTemp + deipnoTemp) / 100)
                    'sumsumGeumata = sumsumGeumata + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).geuma
                End If
                If extraTemp <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).extra = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * extraTemp / 100).ToString("N")
                    sumExtra = sumExtra - (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptpososto * extraTemp / 100)
                    'sumsumExtra = sumsumExtra + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).extra
                End If
            ElseIf Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo <> 0 Then

                Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).imerominies = "Εκπτ.Ευρώ:" + (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo).ToString

                'If ypnosNeto <> 0 Then
                If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).xrewsi = "AI" Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).allinclusiv = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                    sumAllincl = sumAllincl - Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                Else
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos = (-Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                    sumYpnos = sumYpnos - Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                End If
                'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos
                'End If

            ElseIf Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres <> 0 Then

                Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).imerominies = "Ημ.Free " + (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString

                If ypnosNeto <> 0 Then
                    If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).xrewsi = "AI" Then
                        Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).allinclusiv = (-ypnosNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString("N")
                        sumAllincl = sumAllincl - (ypnosNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres)
                    Else
                        Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos = (-ypnosNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString("N")
                        sumYpnos = sumYpnos - (ypnosNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres)
                    End If

                    'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos
                    'sumYpnos = sumYpnos - (ypnosNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
                End If
                If prwinoNeto <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).prwino = (-prwinoNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString("N")
                    sumPrwino = sumPrwino - (prwinoNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres)
                    'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).prwino
                End If
                If geumaNeto <> 0 Or deipnoNeto <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).geuma = (-(geumaNeto + deipnoNeto) / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString("N")
                    sumGeumata = sumGeumata - ((geumaNeto + deipnoNeto) / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres)
                    'sumsumGeumata = sumsumGeumata + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).geuma
                End If
                If extraNeto <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).extra = (-extraNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres).ToString("N")
                    sumExtra = sumExtra - (extraNeto / Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).imeres * Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).ekptimeres)
                    'sumsumExtra = sumsumExtra + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).extra
                End If

            ElseIf Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee <> 0 Then

                Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).imerominies = "Cancel.Fee" + (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee).ToString

                'If ypnosNeto <> 0 Then
                If Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).xrewsi = "AI" Then
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).allinclusiv = (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee * timiImeras / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                    sumAllincl = sumAllincl + Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee * timiImeras / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                Else
                    Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos = (Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee * timiImeras / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                    sumYpnos = sumYpnos + Me.DbhotelDataSet.katastasiapy(startIndex + countIndex - 1).fee * timiImeras / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                End If

                'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(ekptIndex).ypnos
                'End If
            End If
        End If

    End Sub
    Private Sub fuelle_synola_praktoreiou(ByVal praktName As String, ByVal genikoSynolo As Single, ByVal fpaSynolo As Single, ByVal kathSynolo As Single, ByVal flag As Byte)
        Dim sumPistosi, sumFpaYpnos, sumFpaAllincl, sumFpaPrwino, sumFpaGeumata, sumFpaExtra As Single

        'edw Row me Synola katharwn poswn
        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
        indexPrakt += 1
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'tempIndex 'xreiazetai sto CReport

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = praktName

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Συνολ. ΑΠΥ :"


        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = sumAllincl.ToString("N")
        sumsumAllincl = sumsumAllincl + sumAllincl.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = sumYpnos.ToString("N")
        sumsumYpnos = sumsumYpnos + sumYpnos.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = sumPrwino.ToString("N")
        sumsumPrwino = sumsumPrwino + sumPrwino.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = sumGeumata.ToString("N")
        sumsumGeumata = sumsumGeumata + sumGeumata.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = sumExtra.ToString("N")
        sumsumExtra = sumsumExtra + sumExtra.ToString("N")
        sumPistosi = (sumYpnos + sumAllincl + sumPrwino + sumGeumata + sumExtra).ToString("N")
        If fpaSynolo = 0 And kathSynolo = 0 Then ' xwris ekdwmeno apy
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = sumPistosi
        Else ' me ekdomeno apy->uparxei periptwsi dekadikis apoklisis meta tin ekdosi APY->akolouthw to poso pou ekdothike me to timologio
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = kathSynolo.ToString("N")
        End If
        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = sumPistosi '(sumYpnos + sumPrwino + sumGeumata + sumExtra).ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).pistosi = "Πίστωση"
        sumsumPistosi = sumsumPistosi + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras
        'MsgBox(Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras)
        'edw Row fpa
        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
        indexPrakt += 1
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'tempIndex + 1 'xreiazetai sto CReport

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = praktName

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "ΦΠΑ-Γεν.Συνολο :"

        sumFpaAllincl = (sumAllincl * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = sumFpaAllincl.ToString("N")
        sumsumFpaAllincl = sumsumFpaAllincl + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv

        sumFpaYpnos = (sumYpnos * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = sumFpaYpnos.ToString("N")
        sumsumFpaYpnos = sumsumFpaYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos

        sumFpaPrwino = (sumPrwino * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = sumFpaPrwino.ToString("N")
        sumsumFpaPrwino = sumsumFpaPrwino + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino

        sumFpaGeumata = (sumGeumata * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = sumFpaGeumata.ToString("N")
        sumsumFpaGeumata = sumsumFpaGeumata + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma

        sumFpaExtra = (sumExtra * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = sumFpaExtra.ToString("N")
        sumsumFpaExtra = sumsumFpaExtra + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra
        'timimeras einai to Synolo tou fpa->kanw to idio trik opws kai me tin ekdosi memonom,enw apy->apo to sunoliko podso ths kratisis kanw berechnen to Fpa

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = (sumFpaYpnos + sumFpaPrwino + sumFpaGeumata + sumFpaExtra).ToString("N")

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).pistosi = genikoSynolo.ToString("N")
        If fpaSynolo = 0 And kathSynolo = 0 Then
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = (genikoSynolo - sumPistosi).ToString("N")
        Else
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = fpaSynolo
            'MsgBox(Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras)

        End If


    End Sub
    Private Sub fuelle_ekdomena_timologia(ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal flag As Byte)
        Dim j As Int16
        'Dim sumYpnos, sumPrwino, sumGeumata, sumExtra As Single
        Dim countPaidia As Int16
        Dim imer, minas As String


        For j = startIndex To (startIndex + countIndex - 1)

            Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
            ' groups sto CR->flag,praktoreia,index
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag ' gia Group sto CR ->flag 1 einai kratiseis praktoreiwn, flag 2 memonomenous pelates (Timologio- EIntrag ssto Table APY), flag 3 idi komena timologia 

            indexPrakt += 1
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'j - startIndex + 1 'xreiazetai sto CReport

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = Me.DbhotelDataSet.epanekdositimologiou(j).eponimia

            'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = Me.DbhotelDataSet.epanekdositimologiou(j).arithmos

            'If Me.DbhotelDataSet.epanekdositimologiou(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Then
            '    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = "ΑΠΥ" + Me.DbhotelDataSet.epanekdositimologiou(j).aa.ToString
            'ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
            '    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = "ΤΠΥ" + Me.DbhotelDataSet.epanekdositimologiou(j).aa.ToString
            'Else
            '    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = Me.DbhotelDataSet.epanekdositimologiou(j).aa.ToString
            'End If
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = Me.DbhotelDataSet.epanekdositimologiou(j).aa.ToString
            'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).apy = Me.DbhotelDataSet.epanekdositimologiou(j).aa

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).dwmatio = Me.DbhotelDataSet.epanekdositimologiou(j).dwmatio

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).enilikes = Me.DbhotelDataSet.epanekdositimologiou(j).enilikes
            Try
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).paidia = Me.DbhotelDataSet.epanekdositimologiou(j).paidia
                countPaidia = Me.DbhotelDataSet.epanekdositimologiou(j).paidia
            Catch ex As StrongTypingException
                countPaidia = 0
            End Try
            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).atoma = Me.DbhotelDataSet.epanekdositimologiou(j).enilikes + countPaidia

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).voucher = Me.DbhotelDataSet.epanekdositimologiou(j).voucher


            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).onomateponimo = Me.DbhotelDataSet.epanekdositimologiou(j).onomateponumo

            imer = Me.DbhotelDataSet.epanekdositimologiou(j).apo.Date.Day

            minas = Me.DbhotelDataSet.epanekdositimologiou(j).apo.Date.Month

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = imer + "/" + minas + "-" + Me.DbhotelDataSet.epanekdositimologiou(j).mexri.Date.ToShortDateString

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).meres = Me.DbhotelDataSet.epanekdositimologiou(j).imeres

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).xrewsi = Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi


            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = Me.DbhotelDataSet.epanekdositimologiou(j).preistag.ToString("N")


            If Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi = "AI" Then
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = Me.DbhotelDataSet.epanekdositimologiou(j).ypnos.ToString("N")
                sumAllincl = sumAllincl + Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
            Else
                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = Me.DbhotelDataSet.epanekdositimologiou(j).ypnos.ToString("N")
                sumYpnos = sumYpnos + Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
                'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos
            End If
            ' upnosTemp einai to Athroisma ypnou mias Kratisis die ueber 2 Tourist peroden geht->xrisimeuei gia ton Ypologismo
            'tis POSOSTIEAS EKPTWSHS (->alliws i ekptosi p.x. 10% tha itan mono epi tou posou tis Deuteris periodou)

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = Me.DbhotelDataSet.epanekdositimologiou(j).prwino.ToString("N")
            ' prwinoTemp einai to Athroisma prwinou mias Kratisis die ueber 2 Tourist perioden geht->xrisimeuei gia ton Ypologismo
            'tis POSOSTIEAS EKPTWSHS (->alliws i ekptosi p.x. 10% tha itan mono epi tou posou tis Deuteris periodou)
            sumPrwino = sumPrwino + Me.DbhotelDataSet.epanekdositimologiou(j).prwino
            'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino

            'geumaNeto = (geuma / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
            'geumaTemp = geumaTemp + geumaNeto

            'deipnoNeto = (deipno / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
            'deipnoTemp = deipnoTemp + deipnoNeto

            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno).ToString("N")
            sumGeumata = sumGeumata + Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno


            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = Me.DbhotelDataSet.epanekdositimologiou(j).extra.ToString("N")
            sumExtra = sumExtra + Me.DbhotelDataSet.epanekdositimologiou(j).extra


            If Me.DbhotelDataSet.epanekdositimologiou(j).ekptosi Then


                If Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto <> 0 Then
                    Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                    indexPrakt += 1
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' countIndex + 1 'xreiazetai sto CReport
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = Me.DbhotelDataSet.epanekdositimologiou(j).eponimia
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = Me.DbhotelDataSet.epanekdositimologiou(j).arithmos
                    Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Ποσοστ.Εκπτ." + (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto).ToString + "%"

                    If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                        If Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi = "AI" Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100).ToString("N")
                            sumAllincl = sumAllincl - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100)
                            'sumsumAllincl = sumsumAllincl + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv
                        Else
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100).ToString("N")
                            sumYpnos = sumYpnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100)
                            'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos
                        End If
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100).ToString("N")
                        sumPrwino = sumPrwino - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100)
                        'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100).ToString("N")
                        sumGeumata = sumGeumata - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100)
                        'sumsumGeumata = sumsumGeumata + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100).ToString("N")
                        sumExtra = sumExtra - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100)
                        'sumsumExtra = sumsumExtra + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo <> 0 Then
                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                        indexPrakt += 1
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' countIndex + 1 'xreiazetai sto CReport
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = Me.DbhotelDataSet.epanekdositimologiou(j).eponimia
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = Me.DbhotelDataSet.epanekdositimologiou(j).arithmos
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Εκπτ.Ευρώ:" + (Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo).ToString

                        'If ypnosNeto <> 0 Then
                        If Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi = "AI" Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                            sumAllincl = sumAllincl - Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        Else
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                            sumYpnos = sumYpnos - Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        End If
                    End If


                    'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos
                    'End If

                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres <> 0 Then
                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                        indexPrakt += 1
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' countIndex + 1 'xreiazetai sto CReport
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = Me.DbhotelDataSet.epanekdositimologiou(j).eponimia
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = Me.DbhotelDataSet.epanekdositimologiou(j).arithmos
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Ημερες Free " + (Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString

                        If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                            If Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi = "AI" Then
                                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = (-Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                                sumAllincl = sumAllincl - (Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            Else
                                Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                                sumYpnos = sumYpnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            End If

                            'sumsumYpnos = sumsumYpnos + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos
                            'sumYpnos = sumYpnos - (ypnosNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = (-Me.DbhotelDataSet.epanekdositimologiou(j).prwino / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumPrwino = sumPrwino - (Me.DbhotelDataSet.epanekdositimologiou(j).prwino / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumsumPrwino = sumsumPrwino + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = (-(Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumGeumata = sumGeumata - ((Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumsumGeumata = sumsumGeumata + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = (-Me.DbhotelDataSet.epanekdositimologiou(j).extra / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumExtra = sumExtra - (Me.DbhotelDataSet.epanekdositimologiou(j).extra / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumsumExtra = sumsumExtra + Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra
                        End If
                    End If

                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).fee <> 0 Then
                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
                        indexPrakt += 1
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt ' countIndex + 1 'xreiazetai sto CReport
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = Me.DbhotelDataSet.epanekdositimologiou(j).eponimia
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).arkrat = Me.DbhotelDataSet.epanekdositimologiou(j).arithmos
                        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Cancelation Fee" + (Me.DbhotelDataSet.epanekdositimologiou(j).fee).ToString

                        If Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi = "AI" Then
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = (Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                            sumAllincl = sumAllincl + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        Else
                            Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = (Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                            sumYpnos = sumYpnos + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        End If
                    End If
                End If
            End If
        Next


    End Sub

    Private Sub fuelle_synola_katastasis(ByVal flag As Byte)


        'edw Row me Synola katharwn poswn
        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
        indexPrakt += 1
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'tempIndex 'xreiazetai sto CReport

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = "Σύνολα Κατάστασης"

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "Σύνολα Κατάστασης"


        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = sumsumAllincl.ToString("N")

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = sumsumYpnos.ToString("N")

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = sumsumPrwino.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = sumsumGeumata.ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = sumsumExtra.ToString("N")
        'sumsumPistosi = sumsumYpnos + sumsumPrwino + sumsumGeumata + sumsumExtra

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = (sumsumPistosi).ToString("N")
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).pistosi = "Πίστωση"

        'edw Row fpa
        Me.DbhotelDataSet.ekt_katast_apy.Rows.Add()
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).flag = flag
        indexPrakt += 1
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).index = indexPrakt 'tempIndex + 1 'xreiazetai sto CReport

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktoreio = "Σύνολα Κατάστασης"

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).praktkwd = praktKwd

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).imerominies = "ΦΠΑ-Γεν.Συνολο :"

        'sumsumFpaAllincl = (sumsumAllincl * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).allinclusiv = sumsumFpaAllincl.ToString("N")

        'sumsumFpaYpnos = (sumsumYpnos * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).ypnos = sumsumFpaYpnos.ToString("N")


        'sumsumFpaPrwino = (sumsumPrwino * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).prwino = sumsumFpaPrwino.ToString("N")

        'sumsumFpaGeumata = (sumsumGeumata * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).geuma = sumsumFpaGeumata.ToString("N")

        'sumsumFpaExtra = (sumsumExtra * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)
        'MsgBox(sumsumExtra)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).extra = sumsumFpaExtra.ToString("N")

        'timimeras einai to Synolo tou fpa->kanw to idio trik opws kai me tin ekdosi memonom,enw apy->apo to sunoliko podso ths kratisis kanw berechnen to Fpa

        'Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = (sumFpaYpnos + sumFpaPrwino + sumFpaGeumata + sumFpaExtra).ToString("N")
        'MsgBox(sumsumPistosi)
        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).pistosi = sumSynKrat.ToString("N")

        Me.DbhotelDataSet.ekt_katast_apy(Me.DbhotelDataSet.ekt_katast_apy.Count - 1).timiimeras = (sumSynKrat - sumsumPistosi).ToString("N")

    End Sub
    'kanei return ena Array me ta onomata tis kratisis
    Private Function suche_onomata_kratisis(ByVal arKrat As Int16) As String()
        Dim found As Boolean = False
        Dim onomTemp() As String
        Dim startIndex, countIndex As Int16

        ReDim onomTemp(-1)

        While Not found
            If Me.DbhotelDataSet.kratiseisenilikes(startIndex).arithmos = arKrat Then
                found = True
            Else
                startIndex += 1
            End If

        End While

        countIndex = 1
        If startIndex < Me.DbhotelDataSet.kratiseisenilikes.Count - 1 Then
            While Me.DbhotelDataSet.kratiseisenilikes(startIndex).arithmos = Me.DbhotelDataSet.kratiseisenilikes(startIndex + countIndex).arithmos
                countIndex += 1
                If startIndex + countIndex > Me.DbhotelDataSet.kratiseisenilikes.Count - 1 Then
                    Exit While
                End If
            End While
            'MsgBox(countIndex)
            fuelle_onomata(startIndex, countIndex, onomTemp)
            startIndex = startIndex + countIndex
        Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
            'MsgBox(countIndex)
            fuelle_onomata(startIndex, countIndex, onomTemp)

        End If

        Return onomTemp

    End Function
    Private Sub fuelle_onomata(ByVal startIndex As Int16, ByVal countIndex As Int16, ByRef onomTemp() As String)
        Dim j As Int16
        Dim laenge As Int16 = -1

        For j = startIndex To (startIndex + countIndex - 1)
            laenge += 1
            ReDim Preserve onomTemp(laenge)
            onomTemp(onomTemp.Length - 1) = Me.DbhotelDataSet.kratiseisenilikes(j).onomateponimo
        Next


    End Sub

    Private Sub fuehle_array_mit_xrewseis() 'edw bazw se ena array me strings tis xrewseis pou ''paizoun'
        Dim laenge As Int16 = -1

        If rR Then
            laenge += 1
            ReDim Preserve xrewsXr(laenge)
            xrewsXr(xrewsXr.Length - 1) = "RR"
        End If
        If bB Then
            laenge += 1
            ReDim Preserve xrewsXr(laenge)
            xrewsXr(xrewsXr.Length - 1) = "BB"
        End If
        If hB Then
            laenge += 1
            ReDim Preserve xrewsXr(laenge)
            xrewsXr(xrewsXr.Length - 1) = "HB"
        End If
        If fB Then
            laenge += 1
            ReDim Preserve xrewsXr(laenge)
            xrewsXr(xrewsXr.Length - 1) = "FB"
        End If
        If aI Then
            laenge += 1
            ReDim Preserve xrewsXr(laenge)
            xrewsXr(xrewsXr.Length - 1) = "AI"
        End If
    End Sub
    Private Sub init_times_variablen()
        sumYpnos = 0
        sumAllincl = 0
        sumPrwino = 0
        sumGeumata = 0
        sumExtra = 0
    End Sub

    Private Sub init_katastasi_variablen()
        Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter
        afmadapter.Fill(Me.DbhotelDataSet.afm)
        kwdApyAfm = -1

        sumsumYpnos = 0
        sumsumFpaYpnos = 0
        sumsumAllincl = 0
        sumsumFpaAllincl = 0
        sumsumPrwino = 0
        sumsumFpaPrwino = 0
        sumsumGeumata = 0
        sumsumFpaGeumata = 0
        sumsumExtra = 0
        sumsumFpaExtra = 0
        sumSynKrat = 0
        sumsumPistosi = 0
        indexPrakt = 0
    End Sub
    Private Sub proepiskopisi_katastasi_apy()


        'For j = 0 To Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1
        '    MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio(j).fpa3)
        'Next
        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
        If kwdApyAfm <> -1 Then
            Dim Form1 As New EktiposeisFrm()
            Dim ektiposi As New KatastasiApyDomisi()

            Me.DbhotelDataSet.afm.Clear()
            Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter
            afmadapter.FillByKwd(Me.DbhotelDataSet.afm, kwdApyAfm)
            ektiposi.SetDataSource(DbhotelDataSet)
            'CrystalReportViewer1.DisplayGroupTree = False

            CrystalReportViewer1.ReportSource = ektiposi
            CrystalReportViewer1.DisplayGroupTree = False
            Form1.Controls.Add(CrystalReportViewer1)
            CrystalReportViewer1.Dock = DockStyle.Fill
            CrystalReportViewer1.Visible = True

            Form1.ShowDialog()

            ektiposi.Close()
            ektiposi.Dispose()
            CrystalReportViewer1.Visible = False
        End If

    End Sub

    '***************EKDOSI APY*******************EKDOSI APY**************************EKDOSI APY***********EKDOSI APY***********EKDOSI APY*******
    '***************EKDOSI APY*******************EKDOSI APY**************************EKDOSI APY***********EKDOSI APY***********EKDOSI APY*******
    '***************EKDOSI APY*******************EKDOSI APY**************************EKDOSI APY***********EKDOSI APY***********EKDOSI APY*******
    Private Sub ekdosi_apy()

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "ΕΚΔΟΣΗ ΑΠΟΔΕΙΞΕΩΝ-ΤΙΜΟΛΟΓΙΩΝ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
        EtiketaLbl.Location = New Point(EkdosiApyPnl.Width / 10, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        EkdosiApyPnl.Location = New Point(10, EtiketaPnl.Height + 10)
        EkdosiApyPnl.Size = New Point(682, 263)
        'Me.KatastElegxouPnl.Size = New Point(KleisimoZentralPnl.Width - 10, KleisimoZentralPnl.Height - 10)
        EkdosiApyPck.Value = imeromErgasias

        init_glob_var_apy_praktoreiou()

        fuehle_ekd_apy_cbx()
        apyEkdCbx.SelectedIndex = 0
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EkdosiApyPnl)



    End Sub
    Private Sub fuehle_ekd_apy_cbx()
        Dim j As Int16
        apyEkdCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet1.afm.Count
            If j = 0 Then
                apyEkdCbx.Items.Add("<Εταιρεία>")
            Else
                apyEkdCbx.Items.Add(Me.DbhotelDataSet1.afm(j - 1)._alias)
            End If

        Next
    End Sub
    Private Sub apyEkdCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apyEkdCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdApyAfm = -1
        Else
            kwdApyAfm = Me.DbhotelDataSet.afm(sender.selectedINdex - 1).kwd
        End If

    End Sub
    'mazika
    'Private Sub EkdosiApy1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiApy1Btn.Click
    '    'imeromErgasias = "1/6/2007"
    '    If kwdApyAfm <> -1 Then
    '        Randomize()
    '        ' Generate random value between 1 and 6.
    '        timolID = -CInt(Int((10000000 * Rnd()) + 1))

    '        apy_erstellen(1)
    '    End If


    'End Sub
    ''ena ena
    'Private Sub EkdosiApy2Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiApy2Btn.Click
    '    If kwdApyAfm <> -1 Then
    '        Randomize()
    '        ' Generate random value between 1 and 6.
    '        timolID = -CInt(Int((10000000 * Rnd()) + 1))
    '        apy_erstellen(2)
    '    End If
    'End Sub

    Private Sub EkdosiApy3Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiApy3Btn.Click
        Dim parastatiko, kwdikos As Integer
        Try
            If CType(EkdosiApyTbx.Text, Int16) > 0 Then
                Try
                    Me.Cursor = Cursors.WaitCursor
                    dataset_clear()
                    parastatiko = epanekdosi_apy()
                    If ForosChk.Checked Then

                        Dim adapter As New dbhotelDataSet1TableAdapters.forosdiamonisTableAdapter
                        adapter.FillByKratEtosApyParast(Me.DbhotelDataSet1.forosdiamonis, EkdosiApyPck.Value.Year, (CType(EkdosiApyTbx.Text, Int16)), parastatiko)

                        Using connection As New SqlConnection(connectionString)
                            Dim command As New SqlCommand()
                            Dim myReader As SqlDataReader

                            connection.Open()
                            command.Connection = connection
                            command.Parameters.AddWithValue("@etos", CType(etos, Short))
                            command.Parameters.AddWithValue("@apy", (CType(EkdosiApyTbx.Text, Int16)))
                            command.Parameters.AddWithValue("@parastatiko", parastatiko)
                            command.CommandText = "SELECT forosdiamonis.kratisi FROM forosdiamonis INNER JOIN kratiseis ON forosdiamonis.kratisi = kratiseis.kwd WHERE (kratiseis.etos = @etos) AND (kratiseis.apy = @apy) AND (kratiseis.parastatiko = @parastatiko)"

                            myReader = command.ExecuteReader()
                            While myReader.Read()
                                kwdikos = myReader.GetInt32(0)
                                adapter.FillByKratisi(Me.DbhotelDataSet1.forosdiamonis, kwdikos)
                                Dim Form1 As New EktiposeisFrm()
                                Dim ektiposi As New ForosEidik()
                                Dim adapter2 As New dbhotelDataSet1TableAdapters.etaireiaTableAdapter
                                adapter2.Fill(Me.DbhotelDataSet1.etaireia)
                                ektiposi.SetDataSource(DbhotelDataSet1)
                                CrystalReportViewer1.ReportSource = ektiposi
                                CrystalReportViewer1.DisplayGroupTree = False
                                Form1.Controls.Add(CrystalReportViewer1)
                                CrystalReportViewer1.Dock = DockStyle.Fill
                                CrystalReportViewer1.Visible = True
                                Form1.ShowDialog()
                                ektiposi.Close()
                                ektiposi.Dispose()
                            End While
                            myReader.Close()
                            command.Parameters.Clear()
                        End Using
                    End If
                Catch ex1 As System.Exception
                    Me.Cursor = Cursors.Default
                    System.Windows.Forms.MessageBox.Show(ex1.Message)
                End Try
                Me.Cursor = Cursors.Default
            End If
        Catch ex As InvalidCastException
            MsgBox("Δώστε τον Α/Α της υπό επανέκδοση Απόδειξης", MsgBoxStyle.Information, "winfo\nikEl.")
            EkdosiApyTbx.Clear()
        Catch ex1 As OverflowException
            EkdosiApyTbx.Clear()
        End Try
    End Sub

    Private Function get_apy_timol_kwd_afm(ByVal index As Byte) As Integer
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.afm.Count - 1
            If Me.DbhotelDataSet.afm(j).kwd = kwdApyAfm AndAlso index = 1 Then
                Return Me.DbhotelDataSet.afm(j).apykwd
            ElseIf Me.DbhotelDataSet.afm(j).kwd = kwdApyAfm AndAlso index = 2 Then
                Return Me.DbhotelDataSet.afm(j).timolkwd
            End If
        Next
        Return -1
    End Function
    'status=2 ->perimenw meta apo kathe APY, status=1 monomias ola mazi
    'Private Sub apy_erstellen(ByVal status As Byte)
    '    Dim firstIndex, stepsIndex As Int16
    '    Dim groupID As Int16 'gia grouparisma APY ana Praktoreio gia to CReport
    '    Dim seiraApy, seiraTim As String
    '    Dim aaApyparast, aaTimParast, kwdNeouTimol, kwdparastTim, kwdparastApy As Integer
    '    Dim arxi, telos As Date
    '    Dim response As MsgBoxResult
    '    Dim existOK As Boolean = False 'true=uparxoun kratiseis gia timologisi
    '    Dim isApy As Boolean
    '    Try
    '        Me.Cursor = Cursors.WaitCursor
    '        arxi = "1/1/" + etos.ToString
    '        telos = "31/12/" + etos.ToString


    '        Me.DbhotelDataSet.katastasiapy.Clear()
    '        'einai geordnet nach praktoreio zuerst 
    '        Me.KatastasiapyTableAdapter.FillKatastasiApyPraktoreiwnAFM(Me.DbhotelDataSet.katastasiapy, imeromErgasias, 0, True, False, False, kwdApyAfm) 'EkdosiApyPck.Value

    '        'anagkaio gia to onoma pelati sto Timologio
    '        Me.KratiseisenilikesTableAdapter.KatastApyEnilikesByAnaxTimolAFM(Me.DbhotelDataSet.kratiseisenilikes, imeromErgasias, 0, kwdApyAfm) 'EkdosiApyPck.Value

    '        kwdparastApy = get_apy_timol_kwd_afm(1)
    '        Me.ParastatikaTableAdapter.FillByKwd(Me.DbhotelDataSet.parastatika, kwdparastApy) 'Me.DbhotelDataSet.etaireia(0).apykwd
    '        If Me.DbhotelDataSet.parastatika(0).seira Is Nothing Then
    '            seiraApy = ""
    '        Else
    '            seiraApy = Me.DbhotelDataSet.parastatika(0).seira
    '        End If
    '        aaApyparast = Me.DbhotelDataSet.parastatika(0).aritthmos

    '        kwdparastTim = get_apy_timol_kwd_afm(2)
    '        Me.ParastatikaTableAdapter.FillByKwd(Me.DbhotelDataSet.parastatika, kwdparastTim) 'Me.DbhotelDataSet.etaireia(0).timolkwd
    '        If Me.DbhotelDataSet.parastatika(0).seira Is Nothing Then
    '            seiraTim = ""
    '        Else
    '            seiraTim = Me.DbhotelDataSet.parastatika(0).seira
    '        End If
    '        aaTimParast = Me.DbhotelDataSet.parastatika(0).aritthmos
    '        'seira = Me.ParastatikaTableAdapter.GetSeiraParastByKwd(Me.DbhotelDataSet.etaireia(0).aaapy)

    '        'Try 'blepw to meglytero aa sto Table->concurency Problem
    '        '    aaApyparast = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(Me.DbhotelDataSet.etaireia(0).aaapy, arxi, telos)
    '        'Catch ex As InvalidOperationException
    '        '    aaApyparast = Me.ParastatikaTableAdapter.GetArxikoAAParast(Me.DbhotelDataSet.etaireia(0).aaapy)
    '        'End Try
    '        'Dim adaptAfm As New dbhotelDataSetTableAdapters.afmTableAdapter
    '        'MsgBox(kwdApyAfm)
    '        'adaptAfm.FillByKwd(Me.DbhotelDataSet.afm, kwdApyAfm)
    '        If Me.DbhotelDataSet.katastasiapy.Count <> 0 Then
    '            existOK = True
    '            Do Until firstIndex > Me.DbhotelDataSet.katastasiapy.Count - 1
    '                stepsIndex = 1 'posa eintraege 
    '                groupID += 1
    '                init_glob_var_apy_praktoreiou()
    '                isApy = Me.PraktoreiaTableAdapter.IstIndividualByKwd(Me.DbhotelDataSet.katastasiapy(firstIndex).praktimologio)
    '                If isApy Then
    '                    aaApyparast = aaApyparast + 1
    '                Else
    '                    aaTimParast = aaTimParast + 1
    '                End If

    '                If firstIndex < Me.DbhotelDataSet.katastasiapy.Count - 1 Then
    '                    'gia kathe praktoreio
    '                    While Me.DbhotelDataSet.katastasiapy(firstIndex).praktimologio = Me.DbhotelDataSet.katastasiapy(firstIndex + stepsIndex).praktimologio
    '                        stepsIndex += 1
    '                        If firstIndex + stepsIndex > Me.DbhotelDataSet.katastasiapy.Count - 1 Then
    '                            Exit While
    '                        End If
    '                    End While
    '                    'MsgBox( stepsIndex)
    '                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
    '                    Me.DbhotelDataSet.ekt_apy_group.Rows.Add()
    '                    Me.DbhotelDataSet.ekt_apy_group(Me.DbhotelDataSet.ekt_apy_group.Count - 1).praktzaehler = groupID ' gia grouparisma praktoreiou sto CReport
    '                    apy_praktoreiou_ana_kratisi_erstellen(firstIndex, stepsIndex, groupID) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
    '                    If isApy Then
    '                        kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraApy, aaApyparast, isApy, kwdparastApy)
    '                    Else
    '                        kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraTim, aaTimParast, isApy, kwdparastTim)
    '                    End If

    '                    If status = 2 And kwdNeouTimol <> -1 Then ' status=2 ->perimenw meta apo kathe APY,  status=1 monomias ola mazi
    '                        proepiskopisi_maziki_ekdosi_apy()
    '                        If isApy Then
    '                            response = MsgBox("Να καταχωρηθεί η ΑΠΥ A/A " + aaApyparast.ToString + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        Else
    '                            response = MsgBox("Να καταχωρηθεί το Παραστατικό A/A " + aaTimParast.ToString + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        End If
    '                        'response = MsgBox("Να καταχωρηθεί το τιμολόγιο A/A " + aaApyparast.ToString + " ;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        If response = MsgBoxResult.No Then

    '                            'Me.TimologioanalysisTableAdapter.RollbackTimAnalysis(kwdNeouTimol, timolID)
    '                            'Me.TimologiaTableAdapter.RollBackTimologia(timolID, kwdNeouTimol)
    '                            If isApy Then
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastApy)
    '                                aaApyparast -= 1
    '                            Else
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastTim)
    '                                aaTimParast -= 1
    '                            End If

    '                            dataset_clear()
    '                        Else
    '                            dataset_clear()
    '                        End If
    '                    End If
    '                    firstIndex = firstIndex + stepsIndex
    '                Else
    '                    Me.DbhotelDataSet.ekt_apy_group.Rows.Add()
    '                    Me.DbhotelDataSet.ekt_apy_group(Me.DbhotelDataSet.ekt_apy_group.Count - 1).praktzaehler = groupID
    '                    apy_praktoreiou_ana_kratisi_erstellen(firstIndex, stepsIndex, groupID)
    '                    If isApy Then
    '                        kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraApy, aaApyparast, isApy, kwdparastApy)
    '                    Else
    '                        kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraTim, aaTimParast, isApy, kwdparastTim)
    '                    End If

    '                    If status = 2 And kwdNeouTimol <> -1 Then
    '                        proepiskopisi_maziki_ekdosi_apy()
    '                        If isApy Then
    '                            response = MsgBox("Να καταχωρηθεί η ΑΠΥ A/A " + aaApyparast.ToString + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        Else
    '                            response = MsgBox("Να καταχωρηθεί το Παραστατικό A/A " + aaTimParast.ToString + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        End If

    '                        If response = MsgBoxResult.No Then

    '                            'Me.TimologioanalysisTableAdapter.RollbackTimAnalysis(kwdNeouTimol, timolID)
    '                            'Me.TimologiaTableAdapter.RollBackTimologia(timolID, kwdNeouTimol)
    '                            If isApy Then
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastApy)
    '                                aaApyparast -= 1
    '                            Else
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastTim)
    '                                aaTimParast -= 1
    '                            End If
    '                            dataset_clear()
    '                        Else
    '                            dataset_clear()
    '                        End If
    '                    End If
    '                    Exit Do
    '                End If
    '            Loop

    '        End If
    '        Me.DbhotelDataSet.katastasiapy.Clear()

    '        'Ekdosi APY gia PRIVAT pelates!!!!!!!!!!!
    '        Me.KatastasiapyTableAdapter.FillByKatastasiApyPrivTimAFM(Me.DbhotelDataSet.katastasiapy, imeromErgasias, 0, True, True, kwdApyAfm) 'EkdosiApyPck.Value

    '        If Me.DbhotelDataSet.katastasiapy.Count <> 0 Then
    '            existOK = True
    '            firstIndex = 0
    '            Do Until firstIndex > Me.DbhotelDataSet.katastasiapy.Count - 1
    '                stepsIndex = 1 'posa eintraege 
    '                groupID += 1
    '                init_glob_var_apy_praktoreiou()
    '                aaApyparast = aaApyparast + 1
    '                isApy = True
    '                If firstIndex < Me.DbhotelDataSet.katastasiapy.Count - 1 Then
    '                    'gia kathe pelati
    '                    While Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia = Me.DbhotelDataSet.katastasiapy(firstIndex + stepsIndex).eponimia
    '                        stepsIndex += 1
    '                        If firstIndex + stepsIndex > Me.DbhotelDataSet.katastasiapy.Count - 1 Then
    '                            Exit While
    '                        End If
    '                    End While
    '                    'MsgBox( stepsIndex)
    '                    'sumSumSyn = sumSumSyn + Me.DbhotelDataSet.katastasiapy(firstIndex).synolo
    '                    Me.DbhotelDataSet.ekt_apy_group.Rows.Add()
    '                    Me.DbhotelDataSet.ekt_apy_group(Me.DbhotelDataSet.ekt_apy_group.Count - 1).praktzaehler = groupID ' gia grouparisma praktoreiou sto CReport

    '                    apy_praktoreiou_ana_kratisi_erstellen(firstIndex, stepsIndex, groupID) ' ana praktoreio (firstindex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
    '                    kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraApy, aaApyparast, isApy, kwdparastApy)
    '                    If status = 2 And kwdNeouTimol <> -1 Then ' flag=2 ->perimenw meta apo kathe APY, flag=1 monomias ola mazi
    '                        proepiskopisi_maziki_ekdosi_apy()
    '                        response = MsgBox("Να καταχωρηθεί το τιμολόγιο A/A " + aaApyparast.ToString + " ;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        If response = MsgBoxResult.No Then
    '                            If isApy Then
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastApy)
    '                            Else
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastTim)
    '                            End If

    '                            'Me.TimologioanalysisTableAdapter.RollbackTimAnalysis(kwdNeouTimol, timolID)
    '                            'Me.TimologiaTableAdapter.RollBackTimologia(timolID, kwdNeouTimol)
    '                            aaApyparast -= 1
    '                            dataset_clear()
    '                        Else
    '                            dataset_clear()
    '                        End If
    '                    End If
    '                    firstIndex = firstIndex + stepsIndex
    '                Else
    '                    Me.DbhotelDataSet.ekt_apy_group.Rows.Add()
    '                    Me.DbhotelDataSet.ekt_apy_group(Me.DbhotelDataSet.ekt_apy_group.Count - 1).praktzaehler = groupID
    '                    'MsgBox(Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia)
    '                    'MsgBox(Me.DbhotelDataSet.katastasiapy(firstIndex).titlostimolog)
    '                    apy_praktoreiou_ana_kratisi_erstellen(firstIndex, stepsIndex, groupID)
    '                    kwdNeouTimol = apy_praktoreiou_ekdosi(groupID, firstIndex, stepsIndex, seiraApy, aaApyparast, isApy, kwdparastApy)
    '                    If status = 2 And kwdNeouTimol <> -1 Then
    '                        proepiskopisi_maziki_ekdosi_apy()
    '                        response = MsgBox("Να καταχωρηθεί το τιμολόγιο A/A " + aaApyparast.ToString + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                        If response = MsgBoxResult.No Then
    '                            If isApy Then
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastApy)
    '                            Else
    '                                rollback_timologio_transaction(connectionString, kwdNeouTimol, Me.DbhotelDataSet.katastasiapy(firstIndex).anaxwrisi, isApy, kwdparastTim)
    '                            End If

    '                            'Me.TimologioanalysisTableAdapter.RollbackTimAnalysis(kwdNeouTimol, timolID)
    '                            'Me.TimologiaTableAdapter.RollBackTimologia(timolID, kwdNeouTimol)
    '                            aaApyparast -= 1
    '                            dataset_clear()
    '                        Else
    '                            dataset_clear()
    '                        End If
    '                    End If
    '                    Exit Do
    '                End If
    '            Loop

    '        End If

    '        If existOK Then
    '            If status = 1 And kwdNeouTimol <> -1 Then
    '                proepiskopisi_maziki_ekdosi_apy()
    '                dataset_clear()
    '            End If
    '        Else
    '            MsgBox("Δεν υπάρχουν στοιχεία προς Τιμολόγιση!", MsgBoxStyle.Information, "winfo\nikEl.")
    '        End If
    '        init_glob_var_apy_praktoreiou()
    '    Catch ex As System.Exception
    '        Me.Cursor = Cursors.Default
    '        System.Windows.Forms.MessageBox.Show(ex.Message)

    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'edw diaxwrizw to Dataset se Eintraege tou praktoreiou me tin idia kratisi->(ean uparxei mia touristiki periodo einai ena Eintrag ean poles tote polla)
    'Private Sub apy_praktoreiou_ana_kratisi_erstellen(ByVal firstIndex As Int16, ByVal stepsIndex As Int16, ByVal groupId As Int16)
    '    Dim startIndex, countIndex, aaApy As Int16
    '    'Dim sumPistosi As Single 'apo kratiseis to sunolo mias kratisis (me fpa)

    '    aaApy = 0
    '    startIndex = firstIndex

    '    Do Until startIndex > firstIndex + stepsIndex - 1
    '        countIndex = 1 'posa eintraege 

    '        If startIndex < firstIndex + stepsIndex - 1 Then
    '            While Me.DbhotelDataSet.katastasiapy(startIndex).arithmos = Me.DbhotelDataSet.katastasiapy(startIndex + countIndex).arithmos 'se periptwsi pou exoume panw apo mia timeskratisis ana kratisi (>1 touristperiodoi)
    '                countIndex += 1
    '                If startIndex + countIndex > firstIndex + stepsIndex - 1 Then
    '                    Exit While
    '                End If
    '            End While
    '            'enimerwsi tou timologiou analysi Table kathws kai tou DATASET gia kathe kratisi ksexwrtista! 
    '            enimerwsi_timolanalysis_table(startIndex, countIndex, aaApy, groupId) 'tempIndex arithmisi index gia CrReports->gia na einai ta Row twn sunolwn tou Prakt. stin swsti seira sto CR
    '            startIndex = startIndex + countIndex
    '        Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
    '            enimerwsi_timolanalysis_table(startIndex, countIndex, aaApy, groupId)
    '            Exit Do
    '        End If
    '    Loop
    'End Sub
    'Private Sub enimerwsi_timolanalysis_table(ByVal startIndex As Int16, ByVal countIndex As Int16, ByRef aaApy As Int16, ByVal groupID As Int16)
    '    Dim onomTemp() As String
    '    Dim j As Int16
    '    Dim imeres, ypnos, ypnosNeto, prwino, prwinoNeto, geuma, geumaNeto, deipno, deipnoNeto, extra, extraNeto, ypnosFpa, prwinoFpa, geumaFpa, deipnoFpa, extraFpa, timiImeras, timPoso, sinola As Single
    '    Dim diarkeia As String

    '    onomTemp = suche_onomata_kratisis(Me.DbhotelDataSet.katastasiapy(startIndex).arithmos)

    '    Array.Reverse(onomTemp)


    '    'se peroptosi pou exoume perisoteres apo mia toyristikes periodous
    '    For j = startIndex To startIndex + countIndex - 1

    '        Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()

    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).group_id = groupID ' grouparisma APY Praktoreiou gia CR

    '        aaApy += 1
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).aa = aaApy


    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).dwmatio = Me.DbhotelDataSet.katastasiapy(j).dwmatio 'Me.DbhotelDataSet.kratiseis(0).dwmatio
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).enilikes = Me.DbhotelDataSet.katastasiapy(j).enilikes 'Me.DbhotelDataSet.kratiseis(0).enilikes
    '        Try
    '            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).paidia = Me.DbhotelDataSet.katastasiapy(j).paidia
    '        Catch ex As StrongTypingException
    '            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).paidia = 0
    '        End Try
    '        ' Me.DbhotelDataSet.kratiseis(0).anzethnikotites - Me.DbhotelDataSet.kratiseis(0).enilikes
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).atoma = Me.DbhotelDataSet.katastasiapy(j).enilikes + Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).paidia 'Me.DbhotelDataSet.kratiseis(0).anzethnikotites
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).voucher = Me.DbhotelDataSet.katastasiapy(j).voucher 'Me.DbhotelDataSet.kratiseis(0).voucher
    '        If onomTemp.Length > 0 Then
    '            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).client = onomTemp(0)
    '        End If
    '        diarkeia = Me.DbhotelDataSet.katastasiapy(j).apo.Date
    '        diarkeia = diarkeia + "-" + Me.DbhotelDataSet.katastasiapy(j).mexri.Date


    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = diarkeia

    '        'edw alaksa recht spaet (Febrouarios 2010!) ->oi imeres upologizwntai ssto timologio basi tin diarkeia kai oxi tis imeres st
    '        'stis timeskratisis Table pou dilwnoun tin Ekptwsi->EXW 2 dynatotites:1) EAN thelw na fainontai oi imeres ekptwsis sto timologio
    '        'tote EKPTWSI apo KATW (imeres free!!)->2)EAN DEN thelw tote imeres apo imeres/imeres sto panelaki twn timwn->exei san apotelesma
    '        'h ekptwsi na aporofatai apot tis epimerous times (ypnou ktl) KAI DEN tha fainonontai sto timologio
    '        If Me.DbhotelDataSet.katastasiapy(j).mexri = Me.DbhotelDataSet.katastasiapy(j).anaxwrisi Then
    '            imeres = Me.DbhotelDataSet.katastasiapy(j).mexri.DayOfYear - Me.DbhotelDataSet.katastasiapy(j).apo.DayOfYear
    '        Else
    '            imeres = Me.DbhotelDataSet.katastasiapy(j).mexri.DayOfYear - Me.DbhotelDataSet.katastasiapy(j).apo.DayOfYear + 1
    '        End If
    '        'imeres = Me.DbhotelDataSet.katastasiapy(j).imeres

    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = imeres.ToString("N1")
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).xrewsi = Me.DbhotelDataSet.katastasiapy(j).xrewsi

    '        'upologizw tis brutto times gia oli tin diarkeia diamonis 
    '        ypnos = (Me.DbhotelDataSet.katastasiapy(j).ypnos) * imeres
    '        prwino = (Me.DbhotelDataSet.katastasiapy(j).prwino) * imeres
    '        geuma = (Me.DbhotelDataSet.katastasiapy(j).geuma) * imeres
    '        deipno = (Me.DbhotelDataSet.katastasiapy(j).deipno) * imeres
    '        extra = (Me.DbhotelDataSet.katastasiapy(j).extra) * imeres

    '        'timiImeras = ypnos + prwino + geuma + deipno + extra 'brutto timi imeras
    '        timiImeras = Me.DbhotelDataSet.katastasiapy(j).ypnos + Me.DbhotelDataSet.katastasiapy(j).prwino + Me.DbhotelDataSet.katastasiapy(j).geuma + Me.DbhotelDataSet.katastasiapy(j).deipno + Me.DbhotelDataSet.katastasiapy(j).extra
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).preistag = timiImeras.ToString("N")

    '        'upologizw diadoxika tis netto times gia oli tin diarkeia diamonis
    '        'kathws kai to fpa autwn->STO DB timologiaanalysis apothikeuontai autes oi (neto kathares times)
    '        ypnosNeto = (ypnos / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)))
    '        'ypnosNeto = (ypnos / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = ypnosNeto.ToString("N")
    '        ypnosFpa = (ypnosNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
    '        'ypnosFpa = (ypnosNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100).ToString("N")
    '        sumYpnos = sumYpnos + ypnosNeto

    '        prwinoNeto = (prwino / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
    '        'prwinoNeto = (prwino / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = prwinoNeto.ToString("N")
    '        prwinoFpa = (prwinoNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
    '        'prwinoFpa = (prwinoNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100).ToString("N")
    '        sumPrwino = sumPrwino + prwinoNeto

    '        geumaNeto = (geuma / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
    '        'geumaNeto = (geuma / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
    '        geumaFpa = (geumaNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
    '        'geumaFpa = (geumaNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100).ToString("N")
    '        sumGeumata = sumGeumata + geumaNeto

    '        deipnoNeto = (deipno / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)))
    '        'deipnoNeto = (deipno / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))).ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (geumaNeto + deipnoNeto).ToString("N")
    '        deipnoFpa = (deipnoNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
    '        'deipnoFpa = (deipnoNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100).ToString("N")
    '        sumGeumata = sumGeumata + deipnoNeto

    '        extraNeto = (extra / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)))
    '        'extraNeto = (extra / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100))).ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = extraNeto.ToString("N")
    '        extraFpa = (extraNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)
    '        'extraFpa = (extraNeto * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100).ToString("N")

    '        sumExtra = sumExtra + extraNeto

    '        sumSimet = sumSimet + Me.DbhotelDataSet.katastasiapy(j).simetoxi
    '        sumProkat = sumProkat + Me.DbhotelDataSet.katastasiapy(j).prokataboli1


    '        sumKratPosa = ypnosNeto + prwinoNeto + geumaNeto + deipnoNeto + extraNeto
    '        sumKratFpa = ypnosFpa + prwinoFpa + geumaFpa + deipnoFpa + extraFpa

    '        sinola = sumKratPosa + sumKratFpa 'bruto synolo

    '        'PROSOXI->STO DB TIMOLOGIOANALYSIS APOTHHKEUONTAI OI NETO TIMES GIA OLI TIHN DAIRKEIA PARAMONIS KATHWS KAI TO FPA (SYNOLO DIAMONIS)
    '        Me.TimologioanalysisTableAdapter.InsertTimologAnalysis(-1, imeres, ypnosNeto, ypnosFpa, prwinoNeto, prwinoFpa, _
    '        geumaNeto, geumaFpa, deipnoNeto, deipnoFpa, extraNeto, extraFpa, 0, 0, sumKratPosa, sumKratFpa, sinola, Me.DbhotelDataSet.katastasiapy(j).xrewsikwd, Me.DbhotelDataSet.katastasiapy(j).apo, _
    '        Me.DbhotelDataSet.katastasiapy(j).mexri, timiImeras, Me.DbhotelDataSet.katastasiapy(j).ekptposo, Me.DbhotelDataSet.katastasiapy(j).ekptpososto, Me.DbhotelDataSet.katastasiapy(j).ekptimeres, Me.DbhotelDataSet.katastasiapy(j).fee, Me.DbhotelDataSet.katastasiapy(j).voucher, Me.DbhotelDataSet.katastasiapy(j).kwd, Me.DbhotelDataSet.katastasiapy(j).ekptosi, timolID, aaApy, onomTemp(0))


    '        If j = startIndex + countIndex - 1 Then

    '            Me.KratiseisTableAdapter.UpdateTimologioByKwdTimologio(2, Me.DbhotelDataSet.katastasiapy(j).kwd, 0) '[setze status upo ekdosi =2
    '            timPoso = Me.DbhotelDataSet.katastasiapy(j).synolo 'apli zuweisung (mono mia fora-> giauto edw) gia to synoliko poso tis kratisis
    '        End If



    '        'edw ypologizw ekptoseis!!!!!!!!!!!!!!!!!
    '        If Me.DbhotelDataSet.katastasiapy(j).ekptosi Then
    '            If Me.DbhotelDataSet.katastasiapy(j).ekptpososto <> 0 Then
    '                Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).group_id = groupID ' grouparisma APY Praktoreiou gia CR

    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Ποσοστ.Εκπτωσης"
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = Me.DbhotelDataSet.katastasiapy(j).ekptpososto.ToString
    '                If ypnosNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-Me.DbhotelDataSet.katastasiapy(j).ekptpososto * ypnosNeto / 100).ToString("N")
    '                    sumYpnos = sumYpnos - (Me.DbhotelDataSet.katastasiapy(j).ekptpososto * ypnosNeto / 100)
    '                    'sumYpnos = sumYpnos - (MemApyPosostoTbx.Text * ypnosNeto / 100).ToString("N")
    '                End If
    '                If prwinoNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = (-Me.DbhotelDataSet.katastasiapy(j).ekptpososto * prwinoNeto / 100).ToString("N")
    '                    sumPrwino = sumPrwino - (Me.DbhotelDataSet.katastasiapy(j).ekptpososto * prwinoNeto / 100)
    '                    'sumPrwino = sumPrwino - (MemApyPosostoTbx.Text * prwinoNeto / 100).ToString("N")
    '                End If
    '                If geumaNeto <> 0 Or deipno <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (-Me.DbhotelDataSet.katastasiapy(j).ekptpososto * (geumaNeto + deipnoNeto) / 100).ToString("N")
    '                    sumGeumata = sumGeumata - (Me.DbhotelDataSet.katastasiapy(j).ekptpososto * (geumaNeto + deipnoNeto) / 100)
    '                    'sumGeumata = sumGeumata - (MemApyPosostoTbx.Text * (geumaNeto + deipnoNeto) / 100).ToString("N")
    '                End If
    '                If extraNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = (-Me.DbhotelDataSet.katastasiapy(j).ekptpososto * extraNeto / 100).ToString("N")
    '                    sumExtra = sumExtra - (Me.DbhotelDataSet.katastasiapy(j).ekptpososto * extraNeto / 100)
    '                    'sumExtra = sumExtra - (MemApyPosostoTbx.Text * extraNeto / 100).ToString("N")
    '                End If
    '            ElseIf Me.DbhotelDataSet.katastasiapy(j).ekptposo <> 0 AndAlso j = startIndex + countIndex - 1 Then
    '                Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).group_id = groupID ' grouparisma APY Praktoreiou gia CR

    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Εκπτωση σε Ευρω"

    '                'If ypnosNeto <> 0 Then
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-Me.DbhotelDataSet.katastasiapy(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
    '                sumYpnos = sumYpnos - (Me.DbhotelDataSet.katastasiapy(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)))
    '                'sumYpnos = sumYpnos - (MemApyPosoTbx.Text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
    '                'End If
    '            ElseIf Me.DbhotelDataSet.katastasiapy(j).ekptimeres <> 0 AndAlso j = startIndex + countIndex - 1 Then
    '                Dim d As Single
    '                d = Me.DbhotelDataSet.katastasiapy(j).ekptimeres
    '                Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).group_id = groupID ' grouparisma APY Praktoreiou gia CR

    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Ημερες Free"
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = d.ToString("N")
    '                If ypnosNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-ypnosNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres).ToString("N")
    '                    sumYpnos = sumYpnos - (ypnosNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres)
    '                    'sumYpnos = sumYpnos - (ypnosNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
    '                End If
    '                If prwinoNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = (-prwinoNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres).ToString("N")
    '                    sumPrwino = sumPrwino - (prwinoNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres)
    '                    'sumPrwino = sumPrwino - (prwinoNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
    '                End If
    '                If geumaNeto <> 0 Or deipnoNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (-(geumaNeto + deipnoNeto) / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres).ToString("N")
    '                    sumGeumata = sumGeumata - ((geumaNeto + deipnoNeto) / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres)
    '                    'sumGeumata = sumGeumata - ((geumaNeto + deipnoNeto) / imeres * MemApyImerFreeTbx.Text).ToString("N")
    '                End If
    '                If extraNeto <> 0 Then
    '                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = (-extraNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres).ToString("N")
    '                    sumExtra = sumExtra - (extraNeto / imeres * Me.DbhotelDataSet.katastasiapy(j).ekptimeres)
    '                    'sumExtra = sumExtra - (extraNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
    '                End If
    '            ElseIf Me.DbhotelDataSet.katastasiapy(j).fee <> 0 AndAlso j = startIndex + countIndex - 1 Then
    '                Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).group_id = groupID ' grouparisma APY Praktoreiou gia CR

    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Cancelation Fee"
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = Me.DbhotelDataSet.katastasiapy(j).fee.ToString
    '                'If ypnosNeto <> 0 Then
    '                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (Me.DbhotelDataSet.katastasiapy(j).fee * timiImeras / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")

    '                sumYpnos = sumYpnos + Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos
    '                'End If
    '            End If
    '        End If

    '        sumSumPosa = sumYpnos + sumPrwino + sumGeumata + sumExtra  'athroisma (se periptosi synexeia ektiposis) twn katharwn poswn

    '    Next

    '    'epeleksa na ypologizw to fpa pou fainetai sto timologio sto telos wste na min yparxei apoklisi sto timologio pano
    '    'otan upologizw ta epi tois ekato tou fpa apo tis neto SUM times

    '    sumYpnosFpa = (sumYpnos * (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)) '.ToString("N")
    '    sumPrwinoFpa = (sumPrwino * (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)) '.ToString("N")
    '    sumGeumataFpa = (sumGeumata * (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)) '.ToString("N")
    '    sumExtraFpa = (sumExtra * (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)) '.ToString("N")
    '    'sumSumFpa = sumYpnosFpa + sumPrwinoFpa + sumGeumataFpa + sumExtraFpa

    '    sumSynola = sumSynola + timPoso ' gia na isoute 100% to poso stin APY me to poso stin kratisi!->(to athroisma kratisewn gia praktoreio)


    'End Sub
    'ekdosi ana Praktoreio (poles kratiseis mazi)
    'Private Function apy_praktoreiou_ekdosi(ByVal groupId As Int16, ByVal firstIndex As Int16, ByVal countIndex As Int16, ByVal seira As String, ByVal aaApyparast As Integer, ByVal isAPy As Boolean, ByVal parastatiko As Integer) As Integer
    '    Dim sumSumFpa As Single
    '    Dim arxi, telos As Date
    '    Dim kwdNeouTimol As Integer

    '    arxi = "1/1/" + etos.ToString
    '    telos = "31/12/" + etos.ToString
    '    'MsgBox(firstIndex)
    '    If Me.DbhotelDataSet.ekt_apy_mem.Count <> 0 Then
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa.Rows.Add()
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).group_id = groupId ' grouparisma APY Praktoreiou gia CR

    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).sum_kath_posa = sumSumPosa.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).ypnos = sumYpnos.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).prwino = sumPrwino.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).geumata = sumGeumata.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).extras = sumExtra.ToString("N")

    '        Me.DbhotelDataSet.ekt_apy_sumfpa.Rows.Add()
    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).group_id = groupId ' grouparisma APY Praktoreiou gia CR

    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).ypnos = sumYpnosFpa.ToString("N")

    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).prwino = sumPrwinoFpa.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).geumata = sumGeumataFpa.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).extras = sumExtraFpa.ToString("N")

    '        Me.DbhotelDataSet.ekt_apy_diafora.Rows.Add()
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).group_id = groupId ' grouparisma APY Praktoreiou gia CR
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).eponimia = Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia
    '        'MsgBox(Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).eponimia)
    '        Try
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).aitiologia = Me.DbhotelDataSet.katastasiapy(firstIndex).titlostimolog
    '        Catch ex As StrongTypingException
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).aitiologia = Me.DbhotelDataSet.katastasiapy(firstIndex).eponimia
    '        End Try

    '        'Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).eponimia = Me.DbhotelDataSet.katastasiapy(firstIndex).titlostimolog
    '        If isAPy Then
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).titlos = "ΑΠΟΔΕΙΞΗ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
    '        Else
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).titlos = "ΤΙΜΟΛΟΓΙΟ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
    '        End If
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).address = Me.DbhotelDataSet.katastasiapy(firstIndex).dieuthinsi
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).afm_adt = Me.DbhotelDataSet.katastasiapy(firstIndex).afm
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).doy = Me.DbhotelDataSet.katastasiapy(firstIndex).doy

    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1)._date = imeromErgasias

    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).dim_foros = (sumYpnos - sumYpnos / (1 + Me.DbhotelDataSet.etaireia(0).dimforos1 / 100)).ToString("N") + " €"
    '        If sumSimet <> 0 Then
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).simetoxi = sumSimet.ToString("N")
    '        Else
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).simetoxi = -1
    '        End If
    '        If sumProkat <> 0 Then
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).prokataboli = sumProkat.ToString("N")
    '        Else
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).prokataboli = -1
    '        End If

    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).geniko_synolo = sumSynola.ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).tropos_pliromis = "Επί Πιστώση"
    '        'edw ekana DIORTHOSI _>ipirxe apoklisi anamesa to synolo tis kratisis kai to geniko sinolo tis APY->
    '        'ypologizw ta sum kathara posa alla to sumfpa to bgazw meta apo aferesi->sumsumfpa=suynola(apo kratiseis)- sumkathposa
    '        sumSumFpa = (Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).geniko_synolo - Me.DbhotelDataSet.ekt_apy_sumkathposa(Me.DbhotelDataSet.ekt_apy_sumkathposa.Count - 1).sum_kath_posa).ToString("N")
    '        Me.DbhotelDataSet.ekt_apy_sumfpa(Me.DbhotelDataSet.ekt_apy_sumfpa.Count - 1).sum_fpa = sumSumFpa.ToString("N")

    '        If sumProkat <> 0 Or sumSimet <> 0 Then
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).ypoloipon = (sumSynola - sumSimet - sumProkat).ToString("N")
    '        Else
    '            Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).ypoloipon = -1
    '        End If
    '        Using connection As New SqlConnection(connectionString)
    '            Dim kwdKratTemp As Integer = -1
    '            Dim counter, rows, j As Int16
    '            Dim pliromi As String = ""
    '            Dim command As New SqlCommand
    '            Dim transaction As SqlTransaction = Nothing
    '            'Dim parastatiko As Integer
    '            Try
    '                'If isAPy Then
    '                '    parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd
    '                'Else
    '                '    parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd
    '                'End If
    '                connection.Open()
    '                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

    '                ' Assign transaction object for a pending local transaction.
    '                command.Connection = connection
    '                command.Transaction = transaction
    '                '     Me.TimologiaTableAdapter.InsertTimologio(Me.DbhotelDataSet.etaireia(0).aaapy, imeromErgasias, seira, aaApyparast, Me.DbhotelDataSet.katastasiapy(firstIndex).praktimologio, Nothing, sumSumFpa, sumSynola, _
    '                'sumProkat, Nothing, sumSumPosa, False, False, sumSimet, Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).ypoloipon, _
    '                'Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).afm_adt, Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).address, Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).doy, Nothing, Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).eponimia, Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).dim_foros, False, True, False, simbKrat, timolID)

    '                command.Parameters.Add("@parastatiko", SqlDbType.Int).Value = parastatiko
    '                command.Parameters.Add("@imerominia", SqlDbType.DateTime2).Value = imeromErgasias
    '                command.Parameters.Add("@seira", SqlDbType.NVarChar, 20).Value = seira
    '                command.Parameters.Add("@aa", SqlDbType.SmallInt).Value = aaApyparast
    '                command.Parameters.Add("@praktoreio", SqlDbType.Int).Value = Me.DbhotelDataSet.katastasiapy(firstIndex).praktimologio
    '                command.Parameters.Add("@simbolaio", SqlDbType.Int).Value = simbKrat
    '                command.Parameters.Add("@eponimia", SqlDbType.NVarChar, 50).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).aitiologia
    '                command.Parameters.Add("@dieuthinsi", SqlDbType.NVarChar, 50).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).address
    '                command.Parameters.Add("@afm", SqlDbType.NVarChar, 50).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).afm_adt
    '                command.Parameters.Add("@doy", SqlDbType.NVarChar, 50).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).doy
    '                command.Parameters.Add("@sumkathposa", SqlDbType.Real).Value = sumSumPosa
    '                command.Parameters.Add("@fpa", SqlDbType.Real).Value = sumSumFpa
    '                command.Parameters.Add("@synola", SqlDbType.Real).Value = sumSynola
    '                command.Parameters.Add("@prokataboli", SqlDbType.Real).Value = sumProkat
    '                command.Parameters.Add("@simetoxi", SqlDbType.Real).Value = sumSimet
    '                command.Parameters.Add("@ypoloipon", SqlDbType.Real).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).ypoloipon
    '                command.Parameters.Add("@pliromi", SqlDbType.NVarChar, 50).Value = pliromi
    '                command.Parameters.Add("@dimforos", SqlDbType.Real).Value = Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).dim_foros
    '                command.Parameters.Add("@exoflithi", SqlDbType.Bit).Value = False
    '                command.Parameters.Add("@akyromeno", SqlDbType.Bit).Value = False
    '                command.Parameters.Add("@extra", SqlDbType.Bit).Value = False
    '                command.Parameters.Add("@memonomeno", SqlDbType.Bit).Value = True
    '                command.Parameters.Add("@mauro", SqlDbType.Bit).Value = ist_mauri_etaireia(parastatiko)
    '                command.Parameters.Add("@identifikation", SqlDbType.Int).Value = timolID

    '                command.CommandText = "INSERT INTO timologia (parastatiko, imerominia, seira, aa, praktoreio, simbolaio, eponimia, dieuthinsi, afm, doy, sumkathposa, fpa, synola, prokataboli, simetoxi, ypoloipon, pliromi, dimforos, exoflithi, akyromeno, extra, memonomeno, mauro, identifikation) " &
    '"VALUES (@parastatiko, @imerominia, @seira, @aa, @praktoreio, @simbolaio, @eponimia, @dieuthinsi, @afm, @doy, @sumkathposa, @fpa, @synola, @prokataboli, @simetoxi, @ypoloipon, @pliromi, @dimforos, @exoflithi, @akyromeno, @extra, @memonomeno, @mauro, @identifikation)"
    '                command.ExecuteNonQuery()
    '                command.Parameters.Clear()


    '                command.Parameters.Add("@parastatiko", SqlDbType.Int).Value = parastatiko
    '                command.Parameters.Add("@imerominia", SqlDbType.DateTime2).Value = imeromErgasias
    '                command.Parameters.Add("@aa", SqlDbType.SmallInt).Value = aaApyparast
    '                'command.Parameters.AddWithValue("@identifikation", timolID)
    '                command.CommandText = "SELECT kwd FROM timologia WHERE (parastatiko = @parastatiko) AND (imerominia = @imerominia) AND (aa = @aa) AND (akyromeno = 0)" 'AND (identifikation = @identifikation)
    '                Dim myReader As SqlDataReader
    '                myReader = command.ExecuteReader()
    '                ' Always call Read before accessing data.
    '                While myReader.Read()
    '                    kwdNeouTimol = myReader.GetInt32(0)
    '                    counter += 1
    '                End While
    '                ' Always call Close when done reading.
    '                myReader.Close()
    '                command.Parameters.Clear()

    '                If counter <> 1 Then ' paei na pei oti brethikan parapanw timologia me ton idio arithmo aa
    '                    transaction.Rollback()
    '                    rollback_timanalysis_transaction(connectionString, firstIndex, countIndex)
    '                    MsgBox("Η Διαδικασία έκδοσης της ΑΠΥ απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                    Return -1
    '                End If

    '                command.Parameters.AddWithValue("@timologio", kwdNeouTimol)
    '                command.Parameters.AddWithValue("@identifikation", timolID)
    '                command.CommandText = "UPDATE timologioanalysis SET timologio = @timologio WHERE (timologio = -1) AND (identifikation = @identifikation)"
    '                command.ExecuteNonQuery()
    '                command.Parameters.Clear()


    '                For j = firstIndex To firstIndex + countIndex - 1
    '                    'elegxw kathe pote alazei i kratisi kai enimerwnw to kratiseis table->timologio atribute 1 setzen wo 2 war!
    '                    If kwdKratTemp <> Me.DbhotelDataSet.katastasiapy(j).kwd Then
    '                        command.Parameters.AddWithValue("@apy", SqlDbType.SmallInt).Value = aaApyparast
    '                        command.Parameters.AddWithValue("@parastatiko", SqlDbType.Int).Value = parastatiko
    '                        command.Parameters.AddWithValue("@kwd", SqlDbType.Int).Value = kwdKratTemp
    '                        command.CommandText = "UPDATE kratiseis SET timologio = 1, apy = @apy, parastatiko = @parastatiko WHERE (kwd = @kwd) AND (timologio = 2)"
    '                        rows = command.ExecuteNonQuery()
    '                        command.Parameters.Clear()

    '                        If rows <> 1 Then
    '                            transaction.Rollback()
    '                            rollback_timanalysis_transaction(connectionString, firstIndex, countIndex)
    '                            MsgBox("Η Διαδικασία έκδοσης της ΑΠΥ απέτυχε: Πιθανώς έχει ήδη εκδοθεί Τιμολόγιο για την Κράτηση!", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                            Return -1
    '                        End If

    '                    End If
    '                Next

    '                command.Parameters.AddWithValue("@aritthmos", SqlDbType.Int).Value = aaApyparast
    '                command.Parameters.AddWithValue("@kwd", SqlDbType.Int).Value = parastatiko
    '                command.CommandText = "UPDATE parastatika SET aritthmos = @aritthmos WHERE (kwd = @kwd)"
    '                command.ExecuteNonQuery()
    '                command.Parameters.Clear()


    '                transaction.Commit()
    '            Catch ex As Exception
    '                MsgBox("Η Διαδικασία έκδοσης της ΑΠΥ απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Try
    '                    transaction.Rollback()
    '                    rollback_timanalysis_transaction(connectionString, firstIndex, countIndex)
    '                    Return -1
    '                Catch
    '                    Return -1
    '                End Try
    '            End Try

    '        End Using


    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).aa_apy = aaApyparast
    '        Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).seira = seira
    '    End If

    '    Return kwdNeouTimol
    'End Function
    'Private Function ist_mauri_etaireia(ByVal kwd As Integer)
    '    Dim istEikoniki As Boolean
    '    Using connection As New OleDb.OleDbConnection(connectionString)
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim myReader As OleDb.OleDbDataReader
    '        connection.Open()
    '        command.Connection = connection
    '        command.Parameters.AddWithValue("kwd", kwd)
    '        command.CommandText = "SELECT afm.eikoniko FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
    '        myReader = command.ExecuteReader()
    '        ' Always call Read before accessing data.
    '        myReader.Read()
    '        Try
    '            istEikoniki = CType(myReader.Item(0), Integer)
    '        Catch ex As InvalidOperationException
    '            myReader.Close()
    '            connection.Close()
    '            Return False
    '        End Try
    '        ' always call Close when done reading.
    '        myReader.Close()
    '    End Using
    '    Return istEikoniki
    'End Function
    Private Function ist_mauri_etaireia(ByVal kwd As Integer) As Boolean
        Dim istEikoniki As Boolean
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("kwd", kwd)
            command.CommandText = "SELECT afm.eikoniko FROM parastatika INNER JOIN afm ON parastatika.etaireia = afm.kwd WHERE (parastatika.kwd = @kwd)"
            Dim myReader As SqlDataReader = command.ExecuteReader()
            If myReader.Read() Then
                Try
                    istEikoniki = Convert.ToBoolean(myReader("eikoniko"))
                Catch ex As InvalidOperationException
                    myReader.Close()
                    connection.Close()
                    Return False
                End Try
            End If
            myReader.Close()
        End Using
        Return istEikoniki
    End Function

    'edw pairnww pisw tis egrafes pou ekana sto timologio analysis
    'Private Sub rollback_timanalysis_transaction(ByVal connectionstring As String, ByVal firstIndex As Int16, ByVal countIndex As Int16)

    '    Using connection As New OleDb.OleDbConnection(connectionstring)
    '        Dim j As Int16
    '        Dim kwdKratTemp As Integer
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim transaction As OleDb.OleDbTransaction = Nothing
    '        Try
    '            connection.Open()
    '            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

    '            ' Assign transaction object for a pending local transaction.
    '            command.Connection = connection
    '            command.Transaction = transaction


    '            command.Parameters.Clear()
    '            command.Parameters.AddWithValue("identifikation", timolID)
    '            command.CommandText = "DELETE FROM timologioanalysis where (timologio=-1) and (identifikation=?)"
    '            command.ExecuteNonQuery()
    '            command.Parameters.Clear()

    '            For j = firstIndex To firstIndex + countIndex - 1
    '                If kwdKratTemp <> Me.DbhotelDataSet.katastasiapy(j).kwd Then
    '                    kwdKratTemp = Me.DbhotelDataSet.katastasiapy(j).kwd

    '                    command.Parameters.AddWithValue("kwd", kwdKratTemp)
    '                    command.CommandText = "UPDATE kratiseis SET timologio=0, apy=0, parastatiko=0 where (kwd=?) and (timologio=2)"
    '                    command.ExecuteNonQuery()
    '                    command.Parameters.Clear()
    '                End If

    '            Next

    '            transaction.Commit()

    '        Catch ex As Exception
    '            transaction.Rollback()
    '            'MsgBox("H ΑΠΥ δεν πορεί να εκδοθεί !", MsgBoxStyle.Information, "winfo\nikEl.")
    '        End Try
    '    End Using
    'End Sub
    'Private Sub rollback_timologio_transaction(ByVal connectionstring As String, ByVal kwdTml As Integer, ByVal anaxwrisi As Date, ByVal isApy As Boolean, ByVal parastatiko As Integer)
    '    Using connection As New OleDb.OleDbConnection(connectionstring)
    '        Dim aa, aaParast As Integer
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim transaction As OleDb.OleDbTransaction = Nothing

    '        Try
    '            'If isApy Then
    '            '    parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd
    '            'Else
    '            '    parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd
    '            'End If
    '            connection.Open()
    '            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

    '            ' Assign transaction object for a pending local transaction.
    '            command.Connection = connection
    '            command.Transaction = transaction
    '            command.Parameters.Clear()
    '            command.Parameters.Clear()
    '            command.Parameters.AddWithValue("timologio", kwdTml)
    '            command.CommandText = "DELETE FROM timologioanalysis where (timologio=?)"
    '            command.ExecuteNonQuery()
    '            command.Parameters.Clear()

    '            command.Parameters.AddWithValue("kwd", kwdTml)
    '            command.CommandText = "SELECT aa, parastatiko FROM timologia where (kwd=?)" 'and (identifikation=?)
    '            Dim myReader As OleDb.OleDbDataReader
    '            myReader = command.ExecuteReader()
    '            ' Always call Read before accessing data.
    '            While myReader.Read()
    '                aa = myReader.GetInt16(0)
    '                parastatiko = myReader.GetInt32(1)
    '            End While
    '            ' always call Close when done reading.
    '            myReader.Close()
    '            command.Parameters.Clear()


    '            command.Parameters.AddWithValue("kwd", kwdTml)
    '            command.CommandText = "DELETE FROM timologia where (kwd=?)"
    '            command.ExecuteNonQuery()
    '            command.Parameters.Clear()

    '            command.Parameters.AddWithValue("anaxwrisi", anaxwrisi)
    '            command.Parameters.AddWithValue("apy", aa)
    '            command.Parameters.AddWithValue("parastatiko", parastatiko)
    '            command.CommandText = "UPDATE kratiseis SET timologio=0, apy=0 where (anaxwrisi=?) and (timologio=1) and (apy=?) and (parastatiko=?)"
    '            command.ExecuteNonQuery()
    '            command.Parameters.Clear()

    '            command.Parameters.AddWithValue("kwd", parastatiko)
    '            command.CommandText = "SELECT aritthmos FROM parastatika where (kwd=?)" 'and (identifikation=?)
    '            myReader = command.ExecuteReader()
    '            ' Always call Read before accessing data.
    '            While myReader.Read()
    '                aaParast = myReader.GetInt32(0)
    '            End While
    '            ' always call Close when done reading.
    '            myReader.Close()
    '            command.Parameters.Clear()

    '            If aa = aaParast Then
    '                command.Parameters.AddWithValue("aritthmos", aaParast - 1)
    '                command.Parameters.AddWithValue("kwd", parastatiko)
    '                command.CommandText = "UPDATE parastatika SET aritthmos=? WHERE (kwd=?)"
    '                command.ExecuteNonQuery()
    '                command.Parameters.Clear()
    '                transaction.Commit()
    '            Else
    '                transaction.Rollback()
    '                MsgBox(" Ακύρωση ειναι εφικτή μόνο απ'το μενού 'ακύρωση του κλεισίματος' παρακάτω !", MsgBoxStyle.Information, "winfo\nikEl.")
    '                Exit Sub
    '            End If

    '        Catch ex As Exception
    '            transaction.Rollback()
    '            MsgBox("H έκδοση της ΑΠΥ δεν μπόρεσε να ακυρωθεί !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '        End Try
    '    End Using


    'End Sub
    Private Function epanekdosi_apy() As Int32
        Dim j As Int16
        Dim sumYpnos, ypnosFpa, sumPrwino, prwinoFpa, sumGeumata, geumataFpa, sumExtra, extraFpa As Single
        Dim diarkeia As String
        Dim fpaYpnou, fpaTrofis, fpaExtra As Single
        Dim imeres, paidia As Int16
        Dim arxi, telos As Date
        Dim parastatiko As Integer

        arxi = "1/1/" + EkdosiApyPck.Value.Year.ToString
        telos = "31/12/" + EkdosiApyPck.Value.Year.ToString

        If TimologioChk.Checked Then
            parastatiko = get_apy_timol_kwd_afm(2) 'Me.DbhotelDataSet.etaireia(0).timolkwd
        Else

            parastatiko = get_apy_timol_kwd_afm(1) 'Me.DbhotelDataSet.etaireia(0).apykwd
        End If
        Me.EpanekdositimologiouTableAdapter.FillEpanekdosiByAAParastEtos(Me.DbhotelDataSet.epanekdositimologiou, (CType(EkdosiApyTbx.Text, Int16)), arxi, telos, False, parastatiko)

        If Me.DbhotelDataSet.epanekdositimologiou.Count > 0 Then


            For j = 0 To Me.DbhotelDataSet.epanekdositimologiou.Count - 1

                Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).aa = j + 1

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).dwmatio = Me.DbhotelDataSet.epanekdositimologiou(j).dwmatio 'Me.DbhotelDataSet.kratiseis(0).dwmatio
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).enilikes = Me.DbhotelDataSet.epanekdositimologiou(j).enilikes 'Me.DbhotelDataSet.kratiseis(0).enilikes
                Try
                    paidia = Me.DbhotelDataSet.epanekdositimologiou(j).paidia ' Me.DbhotelDataSet.kratiseis(0).anzethnikotites - Me.DbhotelDataSet.kratiseis(0).enilikes
                Catch ex As StrongTypingException
                    paidia = 0
                End Try
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).paidia = paidia
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).atoma = Me.DbhotelDataSet.epanekdositimologiou(j).enilikes + paidia  'Me.DbhotelDataSet.kratiseis(0).anzethnikotites
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).voucher = Me.DbhotelDataSet.epanekdositimologiou(j).voucher 'Me.DbhotelDataSet.kratiseis(0).voucher

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).client = Me.DbhotelDataSet.epanekdositimologiou(j).onomateponumo

                diarkeia = Me.DbhotelDataSet.epanekdositimologiou(j).apo.Date
                diarkeia = diarkeia + "-" + Me.DbhotelDataSet.epanekdositimologiou(j).mexri.Date
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = diarkeia
                imeres = Me.DbhotelDataSet.epanekdositimologiou(j).imeres

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = imeres.ToString("N1")
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).xrewsi = Me.DbhotelDataSet.epanekdositimologiou(j).xrewsi

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).preistag = Me.DbhotelDataSet.epanekdositimologiou(j).preistag.ToString("N")

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = Me.DbhotelDataSet.epanekdositimologiou(j).ypnos.ToString("N")
                'ypnosFpa = ypnosFpa + Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa
                sumYpnos = sumYpnos + Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
                If fpaYpnou = 0 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                    fpaYpnou = Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
                End If

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = Me.DbhotelDataSet.epanekdositimologiou(j).prwino.ToString("N")
                'prwinoFpa = prwinoFpa + Me.DbhotelDataSet.epanekdositimologiou(j).prwinofpa
                sumPrwino = sumPrwino + Me.DbhotelDataSet.epanekdositimologiou(j).prwino
                If fpaTrofis = 0 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                    fpaTrofis = Me.DbhotelDataSet.epanekdositimologiou(j).prwinofpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).prwino
                End If
                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno).ToString("N")
                'geumataFpa = geumataFpa + Me.DbhotelDataSet.epanekdositimologiou(j).geumafpa + Me.DbhotelDataSet.epanekdositimologiou(j).deipnofpa
                sumGeumata = sumGeumata + Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno
                If fpaTrofis = 0 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Then
                    fpaTrofis = Me.DbhotelDataSet.epanekdositimologiou(j).geumafpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).geuma
                End If
                If fpaTrofis = 0 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                    fpaTrofis = Me.DbhotelDataSet.epanekdositimologiou(j).deipnofpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).deipno
                End If

                Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = Me.DbhotelDataSet.epanekdositimologiou(j).extra.ToString("N")
                'extraFpa = extraFpa + Me.DbhotelDataSet.epanekdositimologiou(j).extrfpa
                sumExtra = sumExtra + Me.DbhotelDataSet.epanekdositimologiou(j).extra
                If fpaExtra = 0 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                    fpaExtra = Me.DbhotelDataSet.epanekdositimologiou(j).extrfpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).extra
                End If


                'edw ypologizw ekptoseis!!!!!!!!!!!!!!!!!
                If Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto <> 0 Then
                    Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Ποσοστ.Εκπτωσης"
                    Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto.ToString("N")
                    If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100).ToString("N")
                        sumYpnos = sumYpnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100).ToString("N")
                        sumPrwino = sumPrwino - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100).ToString("N")
                        sumGeumata = sumGeumata - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100)
                        'sumGeumata = sumGeumata - (MemApyPosostoTbx.Text * (geumaNeto + deipnoNeto) / 100).ToString("N")
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100).ToString("N")
                        sumExtra = sumExtra - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100)
                        'sumExtra = sumExtra - (MemApyPosostoTbx.Text * extraNeto / 100).ToString("N")
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo <> 0 Then
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Εκπτωση σε Ευρω"

                        'If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then

                        'prosdiorismos FPA trofis apo Werte (gia to Fall pou to FPA alakse!)
                        If fpaYpnou = 0 Then
                            If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                                fpaYpnou = Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
                            Else
                                fpaYpnou = Me.DbhotelDataSet.etaireia(0).fpatrofis1
                            End If
                        End If
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (fpaYpnou / 100))).ToString("N")
                        sumYpnos = sumYpnos - Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (fpaYpnou / 100))
                        'sumYpnos = sumYpnos - (MemApyPosoTbx.Text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))).ToString("N")
                        'End If
                    End If

                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres <> 0 Then
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        Dim d As Single
                        d = Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres
                        Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Ημερες Free"
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = d.ToString("N")
                        If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (-Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumYpnos = sumYpnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumYpnos = sumYpnos - (ypnosNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).prwino = (-Me.DbhotelDataSet.epanekdositimologiou(j).prwino / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumPrwino = sumPrwino - (Me.DbhotelDataSet.epanekdositimologiou(j).prwino / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumPrwino = sumPrwino - (prwinoNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).geuma_deipno = (-(Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumGeumata = sumGeumata - ((Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumGeumata = sumGeumata - ((geumaNeto + deipnoNeto) / imeres * MemApyImerFreeTbx.Text).ToString("N")
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                            Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).extras = (-Me.DbhotelDataSet.epanekdositimologiou(j).extra / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres).ToString("N")
                            sumExtra = sumExtra - (Me.DbhotelDataSet.epanekdositimologiou(j).extra / imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                            'sumExtra = sumExtra - (extraNeto / imeres * MemApyImerFreeTbx.Text).ToString("N")
                        End If
                    End If

                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).fee <> 0 Then
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        Me.DbhotelDataSet.ekt_apy_mem.Rows.Add()
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).diarkeia_ekptosi = "Cancelation Fee"
                        'prosdiorismos FPA  apo Werte (gia to Fall pou to FPA alakse!)
                        If fpaYpnou = 0 Then
                            If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                                fpaYpnou = Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa * 100 / Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
                            Else
                                fpaYpnou = Me.DbhotelDataSet.etaireia(0).fpatrofis1
                            End If
                        End If

                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).imeres_ekptposost = Me.DbhotelDataSet.epanekdositimologiou(j).fee.ToString("N1")
                        'If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                        Me.DbhotelDataSet.ekt_apy_mem(Me.DbhotelDataSet.ekt_apy_mem.Count - 1).ypnos = (Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (fpaYpnou / 100))).ToString("N")
                        sumYpnos = sumYpnos + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (fpaYpnou / 100))
                        'End If
                    End If

                End If
            Next
            If Me.DbhotelDataSet.ekt_apy_mem.Count <> 0 Then
                Me.DbhotelDataSet.ekt_apy_sumkathposa.Rows.Add()
                Me.DbhotelDataSet.ekt_apy_sumkathposa(0).sum_kath_posa = (Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).sumkathposa).ToString("N")
                Me.DbhotelDataSet.ekt_apy_sumkathposa(0).ypnos = sumYpnos.ToString("N")
                Me.DbhotelDataSet.ekt_apy_sumkathposa(0).prwino = sumPrwino.ToString("N")
                Me.DbhotelDataSet.ekt_apy_sumkathposa(0).geumata = sumGeumata.ToString("N")
                Me.DbhotelDataSet.ekt_apy_sumkathposa(0).extras = sumExtra.ToString("N")

                Me.DbhotelDataSet.ekt_apy_sumfpa.Rows.Add()

                ypnosFpa = sumYpnos * fpaYpnou / 100
                Me.DbhotelDataSet.ekt_apy_sumfpa(0).ypnos = ypnosFpa.ToString("N")
                prwinoFpa = sumPrwino * fpaTrofis / 100
                Me.DbhotelDataSet.ekt_apy_sumfpa(0).prwino = prwinoFpa.ToString("N")
                geumataFpa = sumGeumata * fpaTrofis / 100
                Me.DbhotelDataSet.ekt_apy_sumfpa(0).geumata = geumataFpa.ToString("N")
                extraFpa = sumExtra * fpaExtra / 100
                Me.DbhotelDataSet.ekt_apy_sumfpa(0).extras = extraFpa.ToString("N")

                'edw ekana DIORTHOSI _>ipirxe apoklisi anamesa to synolo tis kratisis kai to geniko sinolo tis APY->
                'ypologizw ta sum kathara posa alla to sumfpa to bgazw meta apo aferesi->sumsumfpa=suynola(apo kratiseis)- sumkathposa

                ''sumSumFpa = sumSumFpa + Me.DbhotelDataSet.ekt_apy_sumfpa(0).ypnos + Me.DbhotelDataSet.ekt_apy_sumfpa(0).prwino + Me.DbhotelDataSet.ekt_apy_sumfpa(0).geumata + Me.DbhotelDataSet.ekt_apy_sumfpa(0).extras


                Me.DbhotelDataSet.ekt_apy_diafora.Rows.Add()
                'MemApyLogarLbl.Text
                If Not TimologioChk.Checked Then
                    Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).titlos = "ΑΠΟΔΕΙΞΗ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
                Else
                    Me.DbhotelDataSet.ekt_apy_diafora(Me.DbhotelDataSet.ekt_apy_diafora.Count - 1).titlos = "ΤΙΜΟΛΟΓΙΟ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
                End If
                Me.DbhotelDataSet.ekt_apy_diafora(0).aitiologia = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).eponimia
                Me.DbhotelDataSet.ekt_apy_diafora(0).address = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).dieuthinsi
                Me.DbhotelDataSet.ekt_apy_diafora(0).afm_adt = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).afm
                Me.DbhotelDataSet.ekt_apy_diafora(0).doy = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).doy

                Me.DbhotelDataSet.ekt_apy_diafora(0)._date = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).imerominia
                Me.DbhotelDataSet.ekt_apy_diafora(0).dim_foros = (Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).dimforos).ToString("N") + " €"
                If Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).simetoxi <> 0 Then
                    Me.DbhotelDataSet.ekt_apy_diafora(0).simetoxi = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).simetoxi.ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_apy_diafora(0).simetoxi = -1
                End If
                If Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).prokataboli <> 0 Then
                    Me.DbhotelDataSet.ekt_apy_diafora(0).prokataboli = (Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).prokataboli).ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_apy_diafora(0).prokataboli = -1
                End If

                Me.DbhotelDataSet.ekt_apy_diafora(0).geniko_synolo = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).synola.ToString("N")
                If Not IsDBNull(Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).Item("qrcode")) AndAlso Not Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).qrcode.Length = 0 Then '
                    Me.DbhotelDataSet.ekt_apy_diafora(0).qrcode = create_qrcode(Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).qrcode)
                End If

                'Me.DbhotelDataSet.ekt_apy_diafora(0).qrcode = create_qrcode(Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).qrcode)
                'edw ekana DIORTHOSI _>ipirxe apoklisi anamesa to synolo tis kratisis kai to geniko sinolo tis APY->
                'ypologizw ta sum kathara posa alla to sumfpa to bgazw meta apo aferesi->sumsumfpa=suynola(apo kratiseis)- sumkathposa

                Me.DbhotelDataSet.ekt_apy_sumfpa(0).sum_fpa = (Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).fpa).ToString("N")

                If Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).prokataboli <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).simetoxi <> 0 Then
                    Me.DbhotelDataSet.ekt_apy_diafora(0).ypoloipon = (Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).synola - Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).simetoxi - Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).prokataboli).ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_apy_diafora(0).ypoloipon = -1
                End If
                'edw pairnw ton aktuelle aa apo table parastatika(->stin etaireia exw apothikeusei ton DB kwd tou APY sta Parastatika Table)
                'If Me.DbhotelDataSet.kratiseis(0).prokataboli + Me.DbhotelDataSet.kratiseis(0).simetoxi = sumSynola Then
                '    exoflithi = True
                Try
                    Me.DbhotelDataSet.ekt_apy_diafora(0).tropos_pliromis = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).pliromi
                Catch ex As StrongTypingException
                    Me.DbhotelDataSet.ekt_apy_diafora(0).tropos_pliromis = Nothing
                End Try


                'edw epeidi h Access den kanei unterstuetzen Transactionen, prospathw na kanw miniemieren to Lathos se periptwsi 
                'pou enas allos user tautoxrona prospathei na bgalei timologio
                Me.DbhotelDataSet.ekt_apy_diafora(0).aa_apy = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).aa
                Me.DbhotelDataSet.ekt_apy_diafora(0).seira = Me.DbhotelDataSet.epanekdositimologiou(Me.DbhotelDataSet.epanekdositimologiou.Count - 1).seira

                proepiskopisi_apy()
                Return parastatiko
            End If

        Else


            'mikrotero kai megalutero AA apy A SEIRAS!!!!!!!!
            Me.TimologiaTableAdapter.FillMaxMinAAByEtosAkyrParasttipos(Me.DbhotelDataSet.timologia, arxi, telos, False, parastatiko)
            If Me.DbhotelDataSet.timologia.Count > 0 Then
                If CType(EkdosiApyTbx.Text, Int16) >= Me.DbhotelDataSet.timologia(0).aa And CType(EkdosiApyTbx.Text, Int16) <= Me.DbhotelDataSet.timologia(Me.DbhotelDataSet.timologia.Count - 1).aa Then
                    MsgBox("Extra Παραστατικά επανεκδίδωνται στο επόμενο μενού! ", MsgBoxStyle.Information, "winfo\nikEl.")
                Else
                    If TimologioChk.Checked Then
                        MsgBox("Δεν βρέθηκε Τιμολόγιο με αυτόν τον Αριθμό ! (A/A Τιμολ. έτους από " + Me.DbhotelDataSet.timologia(0).aa.ToString + " μέχρι " + Me.DbhotelDataSet.timologia(Me.DbhotelDataSet.timologia.Count - 1).aa.ToString + ")", MsgBoxStyle.Information, "winfo\nikEl.")
                    Else
                        MsgBox("Δεν βρέθηκε ΑΠΥ με αυτόν τον Αριθμό ! (A/A ΑΠΥ έτους από " + Me.DbhotelDataSet.timologia(0).aa.ToString + " μέχρι " + Me.DbhotelDataSet.timologia(Me.DbhotelDataSet.timologia.Count - 1).aa.ToString + ")", MsgBoxStyle.Information, "winfo\nikEl.")
                    End If
                End If

            Else
                If TimologioChk.Checked Then
                    MsgBox("Δεν βρέθηκε Τιμολόγιο με αυτόν τον Αριθμό ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                Else
                    MsgBox("Δεν βρέθηκε ΑΠΥ με αυτόν τον Αριθμό ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                End If

            End If

        End If

    End Function
    Function create_qrcode(ByVal url) As Byte()
        Dim encoder As New QRCodeEncoder()

        ' Set encoding properties
        encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE
        encoder.QRCodeScale = 4
        encoder.QRCodeVersion = 8
        encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L

        ' Encode the string as a QR code and get the Bitmap
        Dim qrBitmap As Bitmap = encoder.Encode(url)

        ' Convert Bitmap to Byte array
        Return BitmapToByteArray(qrBitmap)
    End Function
    Function BitmapToByteArray(bitmap As Bitmap) As Byte()
        Using stream As New MemoryStream()
            ' Save the Bitmap to the MemoryStream with the desired format (e.g., PNG)
            bitmap.Save(stream, Imaging.ImageFormat.Png)

            ' Convert the MemoryStream to a Byte array
            Return stream.ToArray()
        End Using
    End Function
    Private Sub proepiskopisi_maziki_ekdosi_apy()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ApyEkdMzDomisi()
        Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter
        afmadapter.FillByKwd(Me.DbhotelDataSet.afm, kwdApyAfm)

        'If Me.DbhotelDataSet.afm.Count <> 0 Then
        ektiposi.SetDataSource(DbhotelDataSet)
        'CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
        'End If

    End Sub
    Private Sub proepiskopisi_apy()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ApyMemDomisi()
        Dim adaptAfm As New dbhotelDataSetTableAdapters.afmTableAdapter
        adaptAfm.FillByKwd(Me.DbhotelDataSet.afm, kwdApyAfm)
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        adaptAfm.Fill(Me.DbhotelDataSet.afm)
    End Sub
    Private Sub Wait(ByVal seconds As Single)

        Dim newDate As Date

        newDate = Now.AddSeconds(seconds)

        While Now.Ticks <= newDate.Ticks

            Application.DoEvents()

        End While

    End Sub

    Private Sub init_glob_var_apy_praktoreiou()
        Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter
        afmadapter.Fill(Me.DbhotelDataSet.afm)
        'kwdApyAfm = -1
        sumYpnos = 0
        sumPrwino = 0
        sumGeumata = 0
        sumExtra = 0
        sumSumPosa = 0
        sumYpnosFpa = 0
        sumPrwinoFpa = 0
        sumGeumataFpa = 0
        sumExtraFpa = 0
        sumSimet = 0
        sumProkat = 0
        sumSynola = 0

    End Sub

    Private Sub dataset_clear()

        Me.DbhotelDataSet.ekt_apy_mem.Clear()
        Me.DbhotelDataSet.ekt_apy_sumfpa.Clear()
        Me.DbhotelDataSet.ekt_apy_sumkathposa.Clear()
        Me.DbhotelDataSet.ekt_apy_diafora.Clear()
        Me.DbhotelDataSet.ekt_apy_group.Clear()
    End Sub
    '**********************EKDOSI EXTRA  PARASTATIKWN***************************EKDOSI EXTRA  PARASTATIKWN*****EKDOSI EXTRA  PARASTATIKWN********************
    '**********************EKDOSI EXTRA  PARASTATIKWN***************************EKDOSI EXTRA  PARASTATIKWN*****EKDOSI EXTRA  PARASTATIKWN********************
    '**********************EKDOSI EXTRA  PARASTATIKWN***************************EKDOSI EXTRA  PARASTATIKWN*****EKDOSI EXTRA  PARASTATIKWN********************
    '**********************EKDOSI EXTRA  PARASTATIKWN***************************EKDOSI EXTRA  PARASTATIKWN*****EKDOSI EXTRA  PARASTATIKWN********************
    '**********************EKDOSI EXTRA  PARASTATIKWN***************************EKDOSI EXTRA  PARASTATIKWN*****EKDOSI EXTRA  PARASTATIKWN********************
    'EDW MPOREI KANEIS NA DWSEI-FORTWSEI ENA TIMOLOGIO GIA PRAKTOREIO->PROSOXH STA A/A MPOREI KANEIS NA YPERPIDISEI A/A ETSI WSTE NA MEINEI KENO 
    'ENDIAMESA->(HANDHABEN->RWTA MANIKI)

    Private Sub ekdosi_extra_parastatikwn()
        Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter

        afmadapter.Fill(Me.DbhotelDataSet.afm)
        fuehle_parast_cbx()
        statusParast = Nothing
        dataset_clear()
        'EkdosiParastSynolaLbl.Size = New Point(85, 22)
        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "ΕΚΔΟΣΗ EXTRA ΠΑΡΑΣΤΑΤΙΚΩΝ"
        EtiketaLbl.Location = New Point(EkdosiParastPnl.Width / 7, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        EkdosiParastPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.EkdosiParastPnl.Size = New Point(730, KleisimoZentralPnl.Height - 100)
        EkdosiParastPck.MinDate = arxiEtous
        EkdosiParastPck.MaxDate = telosEtous
        EkdosiParastPck.Value = imeromErgasias
        'EkdosiParastPck.Enabled = False
        EkdosiParastTrPliromCbx.Items.Clear()
        'trop_pliromis_parast_cbox_fuelle()
        'init_cboxen()
        kwdParastAfm = -1
        init_parast_felder(True)

        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EkdosiParastPnl)

    End Sub
    'Private Sub EkdosiParastParastCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastParastCbx.SelectedIndexChanged

    '    If sender.selectedindex <> -1 Then
    '        If parastParastKwd <> Nothing Then
    '            init_parast_felder(False)
    '        End If

    '        'sTO parastcboxKwd einai apothikeuemenoi oi Kwdikoi twn typwn parastatikwn (APY B seira kai Pistotiko Timologio) 
    '        parastParastKwd = parastCboxKwd(sender.selectedindex)
    '        Try
    '            'edw arxika kanw laden ton arithmo apo to table Parastaika->ACHTUNG->prin tin apothikeusi NOCHMAL abfragen 
    '            'gia to aktuelle AA apo table TIMOLOGIA
    '            Me.ParastatikaTableAdapter.FillByKwd(Me.DbhotelDataSet.parastatika, parastParastKwd)


    '            'aaParast = Me.ParastatikaTableAdapter.GetArxikoAAParastByKwdiko()
    '            aaParast = Me.DbhotelDataSet.parastatika(0).aritthmos1 + 1
    '            EkdosiParastAATbx.Text = aaParast

    '        Catch ex As InvalidOperationException
    '            If parastParastKwd = 5 Then
    '                aaParast = Me.DbhotelDataSet.etaireia(0).aabapy
    '            ElseIf parastParastKwd = 2 Then
    '                aaParast = Me.DbhotelDataSet.etaireia(0).aagramatio
    '            End If
    '        End Try
    '    End If


    'End Sub
    'Private Sub EkdosiParastPraktTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastPraktTbx.Enter, EkdosiParastPraktTbx.Click
    '    Dim PraktForm As New SimbolaiaFrm()
    '    Dim kwdikos As Integer

    '    PraktForm.StartPosition = FormStartPosition.CenterParent
    '    PraktForm.ShowDialog()
    '    kwdikos = PraktForm.return_praktoreio_kwdikos

    '    If kwdikos = Nothing Then
    '        MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        If praktParastKwd = Nothing Then
    '            EkdosiParastPraktTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
    '            Exit Sub
    '        End If
    '    Else
    '        praktParastKwd = kwdikos
    '        EkdosiParastPraktTbx.Text = PraktForm.return_praktoreio
    '    End If
    '    'Me.SimbolaiaTabl
    'End Sub
    'Private Sub EkdosiParastAATbx_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastAATbx.Click

    '    sender.SelectAll()
    'End Sub
    'Private Sub EkdosiParastAATbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastAATbx.Leave
    '    Try
    '        'EkdosiParastAATbx.Text = Math.Abs(CType(sender.text, Int16))
    '        'If parastParastKwd = 5 AndAlso sender.text < Me.DbhotelDataSet.etaireia(0).aabapy Then
    '        '    MsgBox(" AA Τιμολόγιου δεν μπορεί να είναι μικρότερο απο το αρχικό ετους ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        '    EkdosiParastAATbx.Text = aaParast
    '        '    Exit Sub
    '        'ElseIf parastParastKwd = 2 AndAlso sender.text < Me.DbhotelDataSet.etaireia(0).aagramatio Then
    '        '    MsgBox(" AA Τιμολόγιου δεν μπορεί να είναι μικρότερο απο το αρχικό ετους ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        '    EkdosiParastAATbx.Text = aaParast
    '        '    Exit Sub
    '        'End If
    '        If Math.Abs(CType(sender.text, Int16)) < 1 Then
    '            MsgBox(" AA Τιμολόγιου δεν μπορεί να είναι μικρότερο απο το αρχικό ετους ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '            EkdosiParastAATbx.Text = aaParast
    '            Exit Sub
    '        End If
    '        aaParast = EkdosiParastAATbx.Text
    '    Catch ex As InvalidCastException
    '        sender.text = aaParast
    '    End Try
    'End Sub
    'Private Sub EkdosiParastParastFindeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastParastFindeBtn.Click
    '    If Not EkdosiParastAATbx.Text.Equals("") Then
    '        Me.TimologiaTableAdapter.FillByParImeromAAExtra(Me.DbhotelDataSet.timologia, parastParastKwd, EkdosiParastPck.Value.Date, EkdosiParastAATbx.Text, False, True)
    '        If Me.DbhotelDataSet.timologia.Count = 1 Then
    '            Me.TimologioanalysisTableAdapter.FillByTimologio(Me.DbhotelDataSet.timologioanalysis, Me.DbhotelDataSet.timologia(0).kwd)
    '            fortosi_timologiou()
    '        End If

    '    End If

    'End Sub
    Private Sub fortosi_timologiou()


        EkdosiParastPraktTbx.Text = Me.get_praktoreio_by_kwdiko(Me.DbhotelDataSet.timologia(0).praktoreio)
        praktParastKwd = Me.DbhotelDataSet.timologia(0).praktoreio

        EkdosiParastYpnosTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).ypnos).ToString("N")
        aktWerte(0) = (Me.DbhotelDataSet.timologioanalysis(0).ypnos).ToString("N") 'gia na parakolouthisw ean alaksei to wert gia thn ifairesi

        EkdosiParastYpnosFpaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa).ToString("N")

        EkdosiParastPrwinoTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).prwino).ToString("N")
        aktWerte(1) = (Me.DbhotelDataSet.timologioanalysis(0).prwino).ToString("N")
        EkdosiParastPrwinoFpaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).prwinofpa).ToString("N")

        EkdosiParastGeumaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).geuma).ToString("N")
        aktWerte(2) = (Me.DbhotelDataSet.timologioanalysis(0).geuma).ToString("N")
        EkdosiParastGeumaFpaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).geumafpa).ToString("N")

        EkdosiParastDeipnoTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).deipno).ToString("N")
        aktWerte(3) = (Me.DbhotelDataSet.timologioanalysis(0).deipno).ToString("N")
        EkdosiParastDeipnoFpaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).deipnofpa).ToString("N")

        EkdosiParastAllTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).allinclusiv).ToString("N")
        aktWerte(4) = (Me.DbhotelDataSet.timologioanalysis(0).allinclusiv).ToString("N")
        EkdosiParastAllFpaTbx.Text = (Me.DbhotelDataSet.timologioanalysis(0).allinclusivfpa).ToString("N")

        EkdosiParastSynolaTbx.Text = (Me.DbhotelDataSet.timologia(0).synola).ToString("N")

        EkdosiParastProkatabTbx.Text = (Me.DbhotelDataSet.timologia(0).prokataboli).ToString("N")

        EkdosiParastParastAitTbx.Text = Me.DbhotelDataSet.timologia(0).aitiologia

        EkdosiParastTrPliromCbx.SelectedIndex = get_index_tropos_pliromis_cboxen_extraparast(Me.DbhotelDataSet.timologia(0).pliromi)
        statusParast = 2 'Status= Update

    End Sub

    Private Sub EkdosiParastYpnosTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastYpnosTbx.Leave, EkdosiParastPrwinoTbx.Leave,
       EkdosiParastGeumaTbx.Leave, EkdosiParastDeipnoTbx.Leave, EkdosiParastAllTbx.Leave, EkdosiParastProkatabTbx.Leave
        Dim s, d As Single
        Dim find() As Control


        Try
            If CType(sender.text, Single) Then
                s = CType(sender.text, Single)
                sender.text = s.ToString("N")
                If sender.name.Equals("EkdosiParastYpnosTbx") And s <> aktWerte(0) Then
                    find = EkdosiParast2Pnl.Controls.Find("EkdosiParastYpnosFpaTbx", False)

                    If Not EkdosiParastYpnosChk.Checked Then
                        find(0).Text = (s.ToString("N") * (Me.DbhotelDataSet.etaireia(0).fpatrofis1) / 100).ToString("N")
                    Else
                        d = sender.text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        sender.text = d.ToString("N")
                        aktWerte(0) = d.ToString("N")
                        find(0).Text = (s - d).ToString("N")
                    End If

                ElseIf sender.name.Equals("EkdosiParastPrwinoTbx") And s <> aktWerte(1) Then
                    find = EkdosiParast2Pnl.Controls.Find("EkdosiParastPrwinoFpaTbx", False)

                    If Not EkdosiParastYpnosChk.Checked Then
                        find(0).Text = (s.ToString("N") * (Me.DbhotelDataSet.etaireia(0).fpatrofis2) / 100).ToString("N")
                    Else
                        d = sender.text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))
                        sender.text = d.ToString("N")
                        aktWerte(1) = d.ToString("N")
                        find(0).Text = (s - d).ToString("N")
                    End If
                ElseIf sender.name.Equals("EkdosiParastGeumaTbx") And s <> aktWerte(2) Then
                    find = EkdosiParast2Pnl.Controls.Find("EkdosiParastGeumaFpaTbx", False)

                    If Not EkdosiParastYpnosChk.Checked Then
                        find(0).Text = (s.ToString("N") * (Me.DbhotelDataSet.etaireia(0).fpatrofis2) / 100).ToString("N")
                    Else
                        d = sender.text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))
                        sender.text = d.ToString("N")
                        aktWerte(2) = d.ToString("N")
                        find(0).Text = (s - d).ToString("N")
                    End If

                ElseIf sender.name.Equals("EkdosiParastDeipnoTbx") And s <> aktWerte(3) Then
                    find = EkdosiParast2Pnl.Controls.Find("EkdosiParastDeipnoFpaTbx", False)

                    If Not EkdosiParastYpnosChk.Checked Then
                        find(0).Text = (s.ToString("N") * (Me.DbhotelDataSet.etaireia(0).fpatrofis2) / 100).ToString("N")
                    Else
                        d = sender.text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100))
                        sender.text = d.ToString("N")
                        aktWerte(3) = d.ToString("N")
                        find(0).Text = (s - d).ToString("N")
                    End If
                ElseIf sender.name.Equals("EkdosiParastAllTbx") And s <> aktWerte(4) Then
                    find = EkdosiParast2Pnl.Controls.Find("EkdosiParastAllFpaTbx", False)

                    If Not EkdosiParastYpnosChk.Checked Then
                        find(0).Text = (s.ToString("N") * (Me.DbhotelDataSet.etaireia(0).fpatrofis3) / 100).ToString("N")
                    Else
                        d = sender.text / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100))
                        sender.text = d.ToString("N")
                        aktWerte(4) = d.ToString("N")
                        find(0).Text = (s - d).ToString("N")
                    End If
                End If



            End If
        Catch ex As InvalidCastException
            s = 0
            sender.text = s.ToString("N")
            EkdosiParastYpnosTbx_TextChanged(sender, e)
        End Try
        s = berechne_synolo()
        EkdosiParastSynolaTbx.Text = s.ToString("N")
    End Sub
    Private Sub EkdosiParastYpnosFpaTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastYpnosTbx.Leave, EkdosiParastPrwinoTbx.Leave,
       EkdosiParastGeumaTbx.Leave, EkdosiParastDeipnoTbx.Leave, EkdosiParastAllTbx.Leave, EkdosiParastProkatabTbx.Leave, EkdosiParastYpnosFpaTbx.Leave, EkdosiParastPrwinoFpaTbx.Leave,
       EkdosiParastGeumaFpaTbx.Leave, EkdosiParastDeipnoFpaTbx.Leave, EkdosiParastAllFpaTbx.Leave, EkdosiParastProkatabTbx.Leave
        Dim s As Single
        Try
            If CType(sender.text, Single) >= 0 Then
                s = CType(sender.text, Single)
                sender.text = s.ToString("N")
            End If
        Catch ex As InvalidCastException
            s = 0
            sender.text = s.ToString("N")
            EkdosiParastYpnosFpaTbx_TextChanged(sender, e)
        End Try
        s = berechne_synolo()
        EkdosiParastSynolaTbx.Text = s.ToString("N")
    End Sub
    Private Sub EkdosiParastYpnosTbx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastYpnosTbx.Click, EkdosiParastPrwinoTbx.Click,
      EkdosiParastGeumaTbx.Click, EkdosiParastDeipnoTbx.Click, EkdosiParastAllTbx.Click, EkdosiParastProkatabTbx.Click, EkdosiParastYpnosFpaTbx.Click, EkdosiParastPrwinoFpaTbx.Click,
       EkdosiParastGeumaFpaTbx.Click, EkdosiParastDeipnoFpaTbx.Click, EkdosiParastAllFpaTbx.Click, EkdosiParastProkatabTbx.Click

        sender.SelectAll()
    End Sub
    Private Sub EkdosiParastYpnosTbx_Keypress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles EkdosiParastYpnosTbx.KeyPress, EkdosiParastPrwinoTbx.KeyPress,
   EkdosiParastGeumaTbx.KeyPress, EkdosiParastDeipnoTbx.KeyPress, EkdosiParastAllTbx.KeyPress, EkdosiParastProkatabTbx.KeyPress, EkdosiParastYpnosFpaTbx.KeyPress, EkdosiParastPrwinoFpaTbx.KeyPress,
    EkdosiParastGeumaFpaTbx.KeyPress, EkdosiParastDeipnoFpaTbx.KeyPress, EkdosiParastAllFpaTbx.KeyPress, EkdosiParastProkatabTbx.KeyPress

        Me.komma_einschalten(sender, e)

    End Sub
    Private Function berechne_synolo() As Single
        Dim s, ypnos, ypnosFpa, prwino, prwinoFpa, geuma, geumaFpa, deipno, deipnoFpa, allinc, allincFpa As Single
        Dim find() As Control
        ypnos = ypnosFpa = prwino = prwinoFpa = geuma = geumaFpa = deipno = deipnoFpa = allinc = allincFpa = 0

        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastYpnosTbx", False)
        ypnos = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastYpnosFpaTbx", False)
        ypnosFpa = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastPrwinoTbx", False)
        prwino = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastPrwinoFpaTbx", False)
        prwinoFpa = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastGeumaTbx", False)
        geuma = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastGeumaFpaTbx", False)
        geumaFpa = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastDeipnoTbx", False)
        deipno = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastDeipnoFpaTbx", False)
        deipnoFpa = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastAllTbx", False)
        allinc = find(0).Text
        find = EkdosiParast2Pnl.Controls.Find("EkdosiParastAllFpaTbx", False)
        allincFpa = find(0).Text

        synolKathPosa = (ypnos + prwino + geuma + deipno + allinc)
        synolFpa = (ypnosFpa + prwinoFpa + geumaFpa + deipnoFpa + allincFpa)
        s = synolKathPosa + synolFpa
        Return s
    End Function
    'Private Sub EkdosiParastKataxBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastKataxBtn.Click
    '    Try
    '        If ekdosi_extra_parastatikou() Then
    '            init_parast_felder(True)
    '            MsgBox(" Επιτυχής καταχώριση ! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        End If
    '    Catch ex As Exception
    '        MsgBox(" H καταχώριση απέτυχε ! ", MsgBoxStyle.Critical, "winfo\nikEl.")
    '    End Try

    'End Sub
    'Private Sub EkdosiParastEktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastEktBtn.Click
    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Me.DbhotelDataSet.ekt_apy_sumkathposa.Clear()
    '        Me.DbhotelDataSet.ekt_apy_sumfpa.Clear()
    '        Me.DbhotelDataSet.ekt_apy_diafora.Clear()
    '        If ekdosi_extra_parastatikou() Then
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa.Rows.Add()
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa(0).sum_kath_posa = sumSumPosa.ToString("N")
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa(0).ypnos = EkdosiParastYpnosTbx.Text
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa(0).prwino = EkdosiParastPrwinoTbx.Text
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa(0).geumata = (CType(EkdosiParastGeumaTbx.Text, Single) + CType(EkdosiParastDeipnoTbx.Text, Single)).ToString("N")
    '            Me.DbhotelDataSet.ekt_apy_sumkathposa(0).extras = EkdosiParastAllTbx.Text

    '            Me.DbhotelDataSet.ekt_apy_sumfpa.Rows.Add()

    '            Me.DbhotelDataSet.ekt_apy_sumfpa(0).ypnos = EkdosiParastYpnosFpaTbx.Text
    '            Me.DbhotelDataSet.ekt_apy_sumfpa(0).prwino = EkdosiParastPrwinoFpaTbx.Text
    '            Me.DbhotelDataSet.ekt_apy_sumfpa(0).geumata = (CType(EkdosiParastGeumaFpaTbx.Text, Single) + CType(EkdosiParastDeipnoFpaTbx.Text, Single)).ToString("N")
    '            Me.DbhotelDataSet.ekt_apy_sumfpa(0).extras = EkdosiParastAllFpaTbx.Text


    '            Me.DbhotelDataSet.ekt_apy_diafora.Rows.Add()


    '            Me.DbhotelDataSet.ekt_apy_diafora(0).eponimia = Me.DbhotelDataSet.praktoreia(0).titlostimolog
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).address = Me.DbhotelDataSet.praktoreia(0).dieuthinsi
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).afm_adt = Me.DbhotelDataSet.praktoreia(0).afm
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).doy = Me.DbhotelDataSet.praktoreia(0).doy

    '            Me.DbhotelDataSet.ekt_apy_diafora(0)._date = EkdosiParastPck.Value

    '            Me.DbhotelDataSet.ekt_apy_diafora(0).prokataboli = EkdosiParastProkatabTbx.Text


    '            Me.DbhotelDataSet.ekt_apy_diafora(0).geniko_synolo = EkdosiParastSynolaTbx.Text

    '            Me.DbhotelDataSet.ekt_apy_diafora(0).ypoloipon = (EkdosiParastSynolaTbx.Text - EkdosiParastProkatabTbx.Text).ToString("N")

    '            'edw pairnw ton aktuelle aa apo table parastatika(->stin etaireia exw apothikeusei ton DB kwd tou APY sta Parastatika Table)

    '            Me.DbhotelDataSet.ekt_apy_diafora(0).aa_apy = aaParast
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).seira = Me.DbhotelDataSet.parastatika(0).seira
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).dim_foros = EkdosiParastParastAitTbx.Text
    '            If (EkdosiParastTrPliromCbx.SelectedItem) = Nothing OrElse (EkdosiParastTrPliromCbx.SelectedItem) = "Επί Πιστώση" Then
    '                Me.DbhotelDataSet.ekt_apy_diafora(0).tropos_pliromis = "Επί Πιστώση"
    '                Me.DbhotelDataSet.ekt_apy_diafora(0).ypoloipon = (EkdosiParastSynolaTbx.Text - EkdosiParastProkatabTbx.Text).ToString("N")
    '            Else
    '                Me.DbhotelDataSet.ekt_apy_diafora(0).tropos_pliromis = EkdosiParastTrPliromCbx.SelectedItem
    '                Me.DbhotelDataSet.ekt_apy_diafora(0).ypoloipon = "0,00"
    '            End If

    '            Me.DbhotelDataSet.ekt_apy_diafora(0).aitiologia = EkdosiParastParastAitTbx.Text

    '            'If parastParastKwd = 2 Then
    '            '    preopisk_extra_pistotiko()
    '            'ElseIf parastParastKwd = Me.DbhotelDataSet.etaireia(0).timolkwd Then
    '            '    Me.DbhotelDataSet.ekt_apy_diafora(0).titlos = "ΤΙΜΟΛΟΓΙΟ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
    '            '    preopisk_extra_parastat()
    '            'Else
    '            '    Me.DbhotelDataSet.ekt_apy_diafora(0).titlos = "ΑΠΟΔΕΙΞΗ ΠΑΡΟΧΗΣ ΥΠΗΡΕΣΙΩΝ"
    '            '    preopisk_extra_parastat()
    '            'End If
    '            Me.DbhotelDataSet.ekt_apy_diafora(0).titlos = Me.DbhotelDataSet.parastatika(0).tipos
    '            preopisk_extra_parastat()
    '            init_parast_felder(True)

    '            'MsgBox(" Επιτυχής καταχώριση ! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        End If
    '    Catch ex As System.Exception
    '        Me.Cursor = Cursors.Default
    '        System.Windows.Forms.MessageBox.Show(ex.Message)

    '    End Try
    '    Me.Cursor = Cursors.Default
    'End Sub
    'Private Sub preopisk_extra_parastat()
    '    Dim Form1 As New EktiposeisFrm()
    '    Dim ektiposi As New ExtraParastatikaDomisi
    '    Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter

    '    afmadapter.FillByKwd(Me.DbhotelDataSet.afm, kwdParastAfm)
    '    ektiposi.SetDataSource(DbhotelDataSet)
    '    CrystalReportViewer1.ReportSource = ektiposi
    '    CrystalReportViewer1.DisplayGroupTree = False
    '    'CrystalReportViewer1.DisplayGroupTree = False
    '    Form1.Controls.Add(CrystalReportViewer1)
    '    CrystalReportViewer1.Dock = DockStyle.Fill
    '    CrystalReportViewer1.Visible = True

    '    Form1.ShowDialog()

    '    ektiposi.Close()
    '    ektiposi.Dispose()
    '    ektiposi.Dispose()
    '    afmadapter.Fill(Me.DbhotelDataSet.afm)
    'End Sub
    'Private Sub preopisk_extra_pistotiko()
    '    Dim Form1 As New EktiposeisFrm()
    '    Dim ektiposi As New ExtraParastPistotiko()
    '    'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
    '    'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
    '    'sender.Enabled = False
    '    ektiposi.SetDataSource(DbhotelDataSet)
    '    CrystalReportViewer1.ReportSource = ektiposi
    '    CrystalReportViewer1.DisplayGroupTree = False
    '    'CrystalReportViewer1.DisplayGroupTree = False
    '    Form1.Controls.Add(CrystalReportViewer1)
    '    CrystalReportViewer1.Dock = DockStyle.Fill
    '    CrystalReportViewer1.Visible = True

    '    Form1.ShowDialog()

    '    ektiposi.Close()
    '    ektiposi.Dispose()
    'End Sub
    'Private Function ekdosi_extra_parastatikou() As Boolean
    '    Dim seira As String
    '    Dim exoflithi As Boolean = False
    '    Dim akyro As Boolean = False
    '    Dim kwdTimolog As Integer
    '    Dim ypoloipon As Single = 0
    '    'Dim response As MsgBoxResult
    '    Dim aktAAParast As Integer
    '    Dim timID, aaMax As Int16
    '    Dim response As MsgBoxResult
    '    Try
    '        seira = Me.DbhotelDataSet.parastatika(0).seira
    '        'seira = Me.ParastatikaTableAdapter.GetSeiraParastByKwd(parastParastKwd)
    '    Catch ex As InvalidOperationException
    '        seira = Nothing
    '    End Try

    '    Try
    '        ypoloipon = EkdosiParastSynolaTbx.Text - EkdosiParastProkatabTbx.Text
    '    Catch ex As InvalidCastException
    '        ypoloipon = 0
    '    End Try
    '    'If EkdosiParastTrPliromCbx.SelectedIndex <> -1 AndAlso EkdosiParastTrPliromCbx.SelectedItem.Equals("Μετρητοίς") Then
    '    '    exoflithi = True
    '    'Else
    '    '    exoflithi = False
    '    'End If
    '    If EkdosiParastTrPliromCbx.SelectedIndex <> -1 Then
    '        If EkdosiParastTrPliromCbx.SelectedItem.Equals("Επί Πιστώση") Then
    '            exoflithi = False
    '        Else
    '            exoflithi = True
    '        End If
    '    Else
    '        exoflithi = False
    '    End If

    '    If statusParast = 1 Then 'Insert neo Timologio

    '        If timID = 20000 Then
    '            Randomize()
    '            timID = -CInt(Int((10000 * Rnd()) + 1))
    '        End If

    '        Try
    '            'kanw Abfrage to megalytero kataxwrimeno aa sto Table timologia giato enlogw eidos parastatikou
    '            aktAAParast = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(parastParastKwd, arxiEtous, telosEtous, False)
    '            aktAAParast = aktAAParast + 1

    '            If aktAAParast <> aaParast Then
    '                response = MsgBox("Ο Α/Α " + aaParast.ToString + " ενδέχεται να δημιουργήσει κενό στην συνεχόμενη αρίθμηση Τιμολογίων ! " & vbCrLf & "Να αντικατασταθεί με τον σωστό Αύξωντα Αριθμό ;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '                If response = MsgBoxResult.Yes Then
    '                    aaParast = aktAAParast
    '                End If
    '            End If
    '        Catch ex As InvalidOperationException
    '        End Try

    '        If EkdosiParastPck.Value.Date <> imeromErgasias Then
    '            response = MsgBox("ΠΡΟΣΟΧΗ: Η Ημερομηνία (διαφορετική απο την σημερινή) θα δημιουργήσει κενό στην συνεχόμενη Αρίθμηση Τιμολογίων ! Διακοπή έκδοσης;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '            If response = MsgBoxResult.Yes Then
    '                Return False
    '            End If
    '        End If

    '        If aaParast <> Nothing And parastParastKwd <> Nothing And praktParastKwd <> Nothing And CType(EkdosiParastSynolaTbx.Text, Single) <> 0 Then 'And EkdosiParastPck.Value.Date >= minParastDate

    '            If Me.TimologiaTableAdapter.ExistAAByAAPaarastEtosAkyromeno(aaParast, parastParastKwd, arxiEtous, telosEtous, False) Then
    '                MsgBox(" Υπάρχει ήδη καταχωρημένο Τιμολόγιο με ΑΑ " + aaParast.ToString, MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Return False
    '            End If
    '            Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, praktParastKwd)
    '            Try
    '                kwdTimolog = insert_extra_parast_transaction(connectionString, aaParast, seira, synolKathPosa, synolFpa, exoflithi, ypoloipon)
    '            Catch ex As Exception
    '                MsgBox("Η Διαδικασία έκδοσης της Παραστατικού απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Return False
    '            End Try

    '            If kwdTimolog = -1 Then
    '                Return False
    '            Else
    '                Me.TimologioanalysisTableAdapter.InsertTimologAnalysis(kwdTimolog, 0, EkdosiParastYpnosTbx.Text, EkdosiParastYpnosFpaTbx.Text, _
    '                                EkdosiParastPrwinoTbx.Text, EkdosiParastPrwinoFpaTbx.Text, EkdosiParastGeumaTbx.Text, EkdosiParastGeumaFpaTbx.Text, _
    '                                EkdosiParastDeipnoTbx.Text, EkdosiParastDeipnoFpaTbx.Text, 0, 0, EkdosiParastAllTbx.Text, EkdosiParastAllFpaTbx.Text, synolKathPosa, synolFpa, EkdosiParastSynolaTbx.Text, Nothing, Nothing, Nothing, 0, 0, 0, 0, 0, Nothing, -1, False, timID, 1, Nothing)
    '            End If
    '        Else
    '            MsgBox(" Ελέγξτε τα στοιχεία του Τιμολογίου ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '            Return False
    '        End If
    '    ElseIf statusParast = 2 Then 'Update =->uparxin timlogio!
    '        If aaParast <> Nothing And parastParastKwd <> Nothing And praktParastKwd <> Nothing Then 'And EkdosiParastPck.Value.Date >= imeromErgasias
    '            If aaParast <> Me.DbhotelDataSet.timologia(0).aa Then 'user alakse to aa
    '                If Me.TimologiaTableAdapter.ExistAAByAAPaarastEtosAkyromeno(aaParast, parastParastKwd, arxiEtous, telosEtous, False) Then
    '                    MsgBox(" Υπάρχει ήδη καταχωρημένο Τιμολόγιο με ΑΑ " + aaParast.ToString, MsgBoxStyle.Critical, "winfo\nikEl.")
    '                    Return False
    '                End If
    '            End If
    '            If EkdosiParastSynolaTbx.Text = 0 Then 'user midenise tis times ->AKYROSI timologioy!
    '                Try
    '                    aaMax = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(parastParastKwd, arxiEtous, telosEtous, False)
    '                    If aaParast = aaMax Then 'ean einai to teleutaio kataxwrimeno tote OK gia diagrafi _>alliws den gunetai Diagrafi-> apla MHDENIKO TIMOLOGIO
    '                        akyro = True
    '                    End If
    '                Catch ex As InvalidOperationException
    '                    MsgBox(" Ελέγξτε τα στοιχεία του Τιμολογίου ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '                    Return False
    '                End Try

    '            End If

    '            Me.TimologioanalysisTableAdapter.UpdateTimologAnalysis(Me.DbhotelDataSet.timologioanalysis(0).timologio, 0, EkdosiParastYpnosTbx.Text, EkdosiParastYpnosFpaTbx.Text, _
    '                        EkdosiParastPrwinoTbx.Text, EkdosiParastPrwinoFpaTbx.Text, EkdosiParastGeumaTbx.Text, EkdosiParastGeumaFpaTbx.Text, _
    '                        EkdosiParastDeipnoTbx.Text, EkdosiParastDeipnoFpaTbx.Text, 0, 0, EkdosiParastAllTbx.Text, EkdosiParastAllFpaTbx.Text, synolKathPosa, synolFpa, EkdosiParastSynolaTbx.Text, 0, Nothing, Nothing, 0, 0, 0, 0, 0, Nothing, Me.DbhotelDataSet.timologioanalysis(0).kwd)


    '            If aaMax <> 0 AndAlso aaParast <> Me.DbhotelDataSet.timologia(0).aa Then 'o user alakes to aa->kanw abfragen (ean den to exw kanei idi)
    '                'gia to megelutero AA sto DB  
    '                Try
    '                    aaMax = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(parastParastKwd, arxiEtous, telosEtous, False)
    '                Catch ex As Exception
    '                End Try
    '            End If

    '            Me.TimologiaTableAdapter.UpdateTimologio(parastParastKwd, EkdosiParastPck.Value.Date, seira, aaParast, praktParastKwd, EkdosiParastParastAitTbx.Text, synolFpa, _
    '                                                                            EkdosiParastSynolaTbx.Text, EkdosiParastProkatabTbx.Text, EkdosiParastTrPliromCbx.SelectedItem, synolKathPosa, akyro, exoflithi, 0, ypoloipon, Me.DbhotelDataSet.praktoreia(0).afm, Me.DbhotelDataSet.praktoreia(0).dieuthinsi, Me.DbhotelDataSet.praktoreia(0).doy, Nothing, Me.DbhotelDataSet.praktoreia(0).titlostimolog, 0, False, Me.DbhotelDataSet.timologia(0).kwd)
    '            If aaParast > aaMax And Not akyro Then ' ean to neo aa einai megalutero apo to max stin DB->enimerwsi tou TBLE parastatika pou exei to trexon AA gia to eidos tou Parastatikou
    '                Me.ParastatikaTableAdapter.SetaaAPYByKwd(aaParast, parastParastKwd)
    '            End If
    '            If akyro Then 'ean o user to midenise->enimerwse
    '                Try
    '                    aaMax = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(parastParastKwd, arxiEtous, telosEtous, False)
    '                Catch ex As Exception ' den Yparxei KANENA katwxwrimieno parstatiko->apo DB etaireia to arxiko etous !!!
    '                    If parastParastKwd = 5 Then
    '                        aaMax = Me.DbhotelDataSet.etaireia(0).aabapy - 1
    '                    ElseIf parastParastKwd = 2 Then
    '                        aaMax = Me.DbhotelDataSet.etaireia(0).aagramatio - 1
    '                    End If

    '                End Try
    '                Me.ParastatikaTableAdapter.SetaaAPYByKwd(aaMax, parastParastKwd)
    '            End If

    '            Me.XrewseispraktoreiaTableAdapter.DeleteByTimologio(Me.DbhotelDataSet.timologia(0).kwd)
    '            'init_parast_felder(True)
    '            'Else
    '            '    MsgBox(" Μη επιτρεπτή Αλλαγή ΑΑ Τιμολογίου! Εισάγετε " + Me.DbhotelDataSet.timologia(0).aa.ToString, MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '            '    EkdosiParastAATbx.Focus()
    '            '    Return False


    '    Else
    '        MsgBox(" Ελέγξτε τα στοιχεία του Τιμολογίου ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '        Return False
    '    End If

    '    End If
    '    Return True
    'End Function
    '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\dbhotel.mdb"
    'Private Function insert_extra_parast_transaction(ByVal connectionstring As String, ByVal aaParast As Integer, ByVal seira As String, ByVal synolKathPosa As Single, ByVal synolFpa As Single, ByVal exoflithi As Boolean, ByVal ypoloipon As Single) As Integer
    '    Using connection As New OleDb.OleDbConnection(connectionstring)
    '        Dim kwdNeouTimol As Integer
    '        Dim counter, rows As Int16
    '        Dim pliromi As String = Nothing
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim transaction As OleDb.OleDbTransaction = Nothing
    '        Try
    '            connection.Open()
    '            transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

    '            ' Assign transaction object for a pending local transaction.
    '            Command.Connection = connection
    '            Command.Transaction = transaction

    '            Command.Parameters.AddWithValue("parastatiko", CType(parastParastKwd, Integer))
    '            command.Parameters.AddWithValue("imerominia", EkdosiParastPck.Value.Date)
    '            If seira Is Nothing Then
    '                command.Parameters.AddWithValue("seira", "") ' anaxwrisi
    '            Else
    '                command.Parameters.AddWithValue("seira", seira) ' anaxwrisi
    '            End If

    '            Command.Parameters.AddWithValue("aa", aaParast)
    '            Command.Parameters.AddWithValue("praktoreio", praktParastKwd)

    '            'command.Parameters.AddWithValue("simbolaio", simbKrat) 'Me.DbhotelDataSet.kratiseis(0).dwmatio
    '            command.Parameters.AddWithValue("eponimia", Me.DbhotelDataSet.praktoreia(0).eponimia)
    '            Command.Parameters.AddWithValue("dieuthinsi", Me.DbhotelDataSet.praktoreia(0).dieuthinsi)
    '            Command.Parameters.AddWithValue("afm", Me.DbhotelDataSet.praktoreia(0).afm)
    '            Command.Parameters.AddWithValue("doy", Me.DbhotelDataSet.praktoreia(0).doy)
    '            Command.Parameters.AddWithValue("aitiologia", EkdosiParastParastAitTbx.Text)
    '            Command.Parameters.AddWithValue("sumkathposa", synolKathPosa)

    '            Command.Parameters.AddWithValue("fpa", synolFpa)
    '            Command.Parameters.AddWithValue("synola", CType(EkdosiParastSynolaTbx.Text, Single))
    '            Command.Parameters.AddWithValue("prokataboli", CType(EkdosiParastProkatabTbx.Text, Single))
    '            Command.Parameters.AddWithValue("simetoxi", 0)
    '            Command.Parameters.AddWithValue("ypoloipon", ypoloipon)
    '            If (EkdosiParastTrPliromCbx.SelectedItem) = Nothing Then
    '                pliromi = "Επί Πιστώση"
    '            Else
    '                pliromi = EkdosiParastTrPliromCbx.SelectedItem
    '            End If
    '            Command.Parameters.AddWithValue("pliromi", pliromi)
    '            'command.Parameters.AddWithValue("dimforos", Me.DbhotelDataSet.ekt_apy_diafora(0).dim_foros)
    '            Command.Parameters.AddWithValue("exoflithi", exoflithi)
    '            'command.Parameters.AddWithValue("akyromeno", CType(myReader.Item("imerominia"), Date))
    '            'command.Parameters.AddWithValue("extra", CType(myReader.Item("imerominia"), Date))
    '            'command.Parameters.AddWithValue("memonomeno", CType(myReader.Item("synolo"), Single))
    '            'command.Parameters.AddWithValue("mauro", CType(myReader.Item("imerominia"), Date))
    '            Command.Parameters.AddWithValue("identifikation", timolID)
    '            Command.CommandText = "INSERT INTO timologia (parastatiko, imerominia, seira, aa, praktoreio, simbolaio, eponimia, dieuthinsi," & _
    '            "afm, doy, aitiologia, sumkathposa, fpa,  synola, prokataboli, simetoxi, ypoloipon, pliromi, exoflithi, akyromeno, extra, memonomeno, mauro,identifikation) " & _
    '            "VALUES (parastatiko, imerominia, seira, aa, praktoreio, -1, eponimia, dieuthinsi, afm, doy, aitiologia, sumkathposa, fpa,  synola, prokataboli, simetoxi, ypoloipon," & _
    '            " pliromi,  exoflithi, false, true, false, false, identifikation)"
    '            Command.ExecuteNonQuery()
    '            Command.Parameters.Clear()

    '            'Me.ParastatikaTableAdapter.UpdateAAByKwd(aaParast, parastParastKwd) 'Enimerwsi tou aktuelle aa sto table parastatika   

    '            Command.Parameters.AddWithValue("aritthmos", aaParast)
    '            Command.Parameters.AddWithValue("kwd", CType(parastParastKwd, Integer))
    '            Command.CommandText = "UPDATE parastatika SET aritthmos=? WHERE (kwd=?)"
    '            rows = Command.ExecuteNonQuery()
    '            Command.Parameters.Clear()

    '            Command.Parameters.AddWithValue("parastatiko", CType(parastParastKwd, Integer))
    '            Command.Parameters.AddWithValue("imerominia", EkdosiParastPck.Value.Date)
    '            Command.Parameters.AddWithValue("aa", aaParast)
    '            'command.Parameters.AddWithValue("identifikation", timolID)
    '            Command.CommandText = "SELECT kwd FROM timologia where (parastatiko=?) and (imerominia=?) and (aa=?) and (akyromeno=false)" 'and (identifikation=?)
    '            Dim myReader As OleDb.OleDbDataReader
    '            myReader = Command.ExecuteReader()
    '            ' Always call Read before accessing data.
    '            While myReader.Read()
    '                kwdNeouTimol = myReader.GetInt32(0)
    '                counter += 1
    '            End While
    '            ' always call Close when done reading.
    '            myReader.Close()
    '            Command.Parameters.Clear()

    '            If counter <> 1 And rows <> 0 Then ' paei na pei oti brethikan parapanw timologia me ton idio aa
    '                transaction.Rollback()
    '                'rollback_timanalysis_transaction(connectionstring)
    '                MsgBox("Η Διαδικασία έκδοσης της Παραστατικού απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Return -1
    '            Else
    '                transaction.Commit()
    '            End If
    '            Return kwdNeouTimol
    '        Catch ex As Exception
    '            MsgBox("Η Διαδικασία έκδοσης της Παραστατικού απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '            Try
    '                transaction.Rollback()
    '                Return -1
    '            Catch ex1 As Exception
    '                Return -1
    '            End Try

    '        End Try

    '    End Using


    'End Function
    'Private Sub trop_pliromis_parast_cbox_fuelle()
    '    Dim j As Int16
    '    For j = 0 To Me.DbhotelDataSet.pistwtikes.Count + 1
    '        If j = 0 Then
    '            EkdosiParastTrPliromCbx.Items.Add("Επί Πιστώση")
    '        ElseIf j = 1 Then
    '            EkdosiParastTrPliromCbx.Items.Add("Μετρητοίς")
    '        Else
    '            EkdosiParastTrPliromCbx.Items.Add(Me.DbhotelDataSet.pistwtikes(j - 2).karta)

    '        End If
    '    Next
    'End Sub
    Private Sub EkdosiParastNeoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastNeoBtn.Click
        init_parast_felder(True)
    End Sub
    Private Sub ParastCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParastCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdParastAfm = -1
        Else
            kwdParastAfm = Me.DbhotelDataSet.afm(sender.selectedINdex - 1).kwd
        End If

        init_cboxen()
    End Sub
    Private Sub fuehle_parast_cbx()
        Dim j As Int16
        ParastCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet.afm.Count
            If j = 0 Then
                ParastCbx.Items.Add("<Εταιρεία>")
            Else
                ParastCbx.Items.Add(Me.DbhotelDataSet.afm(j - 1).epixirisi)
            End If

        Next
    End Sub
    Private Sub init_cboxen()
        Dim j As Int16
        aaParast = Nothing
        EkdosiParastAATbx.Clear()
        Me.ParastatikaTableAdapter.FillParastByAfm(Me.DbhotelDataSet.parastatika, kwdParastAfm)
        Me.EkdosiParastParastCbx.SelectedIndex = -1
        Me.EkdosiParastParastCbx.Items.Clear()
        ReDim parastCboxKwd(Me.DbhotelDataSet.parastatika.Count - 1)
        For j = 0 To Me.DbhotelDataSet.parastatika.Count - 1
            Me.EkdosiParastParastCbx.Items.Add(Me.DbhotelDataSet.parastatika(j).tipos + " Σειρά " + Me.DbhotelDataSet.parastatika(j).seira)
            parastCboxKwd(j) = Me.DbhotelDataSet.parastatika(j).kwd
        Next
        'For j = 0 To Me.DbhotelDataSet.pistwtikes.Count + 1
        '    If j = 0 Then
        '        EkdosiParastTrPliromCbx.Items.Add("Επί Πιστώση")
        '    ElseIf j = 1 Then
        '        EkdosiParastTrPliromCbx.Items.Add("Μετρητοίς")
        '    Else
        '        EkdosiParastTrPliromCbx.Items.Add(Me.DbhotelDataSet.pistwtikes(j - 2).karta)

        '    End If
        'Next
        'EkdosiParastTrPliromCbx
    End Sub
    Private Sub init_parast_felder(ByVal initIndex As Boolean)
        Dim s As Single = 0

        statusParast = 1 'Insert
        If initIndex Then
            EkdosiParastParastCbx.SelectedIndex = -1
        End If

        EkdosiParastPraktTbx.Clear()
        parastParastKwd = Nothing
        EkdosiParastAATbx.Clear()
        aaParast = Nothing
        EkdosiParastParastAitTbx.Clear()
        'MsgBox(minParastDate)

        EkdosiParastPck.Value = imeromErgasias

        EkdosiParastYpnosTbx.Text = s.ToString("N")
        EkdosiParastPrwinoTbx.Text = s.ToString("N")
        EkdosiParastGeumaTbx.Text = s.ToString("N")
        EkdosiParastDeipnoTbx.Text = s.ToString("N")
        EkdosiParastAllTbx.Text = s.ToString("N")
        EkdosiParastYpnosFpaTbx.Text = s.ToString("N")
        EkdosiParastPrwinoFpaTbx.Text = s.ToString("N")
        EkdosiParastGeumaFpaTbx.Text = s.ToString("N")
        EkdosiParastDeipnoFpaTbx.Text = s.ToString("N")
        EkdosiParastAllFpaTbx.Text = s.ToString("N")
        EkdosiParastSynolaTbx.Text = s.ToString("N")
        EkdosiParastProkatabTbx.Text = s.ToString("N")
        EkdosiParastTrPliromCbx.SelectedIndex = -1
    End Sub

    Private Sub EkdosiParastTrPliromCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiParastTrPliromCbx.TextUpdate
        MsgBox("Δεν επιτρέπεται αλλαγή (Γιά εισαγωγή νέας πιστωτικής κάρτας ανατρέξτε στους Παράμετρους της Εφαρμογής) !", MsgBoxStyle.Information, "winfo\nikEl.")
        EkdosiParastTrPliromCbx.SelectedIndex = -1
    End Sub

    Private Function get_index_tropos_pliromis_cboxen_extraparast(ByVal pliromi As String) As Int16
        Dim i As Int16

        For i = 0 To EkdosiParastTrPliromCbx.Items.Count - 1
            If EkdosiParastTrPliromCbx.Items(i).ToString = pliromi Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub ektiposi_extra_parastatikwn()
        'EkdosiParastSynolaLbl.Size = New Point(85, 22)
        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        EtiketaLbl.Text = "ΕΚΤΥΠΩΣΗ EXTRA  ΠΑΡΑΣΤΑΤΙΚΩΝ"
        EtiketaLbl.Location = New Point(ExtraParEktPnl.Width / 12, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        ExtraParEktPnl.Size = New Point(351, 182)
        ExtraParEktPnl.Location = New Point(40, EtiketaPnl.Height)
        ExtraParEktPck1.MinDate = arxiEtous
        ExtraParEktPck2.MaxDate = telosEtous
        ExtraParEktPck1.Value = imeromErgasias
        ExtraParEktPck2.Value = telosEtous
        'EkdosiParastPck.Enabled = False

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(ExtraParEktPnl)

    End Sub
    Private Sub ExtraParEktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraParEktBtn.Click
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ExtraParastEkt()

        Me.EpanekdositimologiouTableAdapter.FillExtraParastByImerominies(Me.DbhotelDataSet.epanekdositimologiou, ExtraParEktPck1.Value.Date, ExtraParEktPck2.Value.Date, False, True)
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    '***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN
    '***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN
    '***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN***************SIGKENTRWTIKH TIMOLOGIWN

    Private Sub ekt_sigkentrwtiki_tim()
        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString


        EtiketaLbl.Text = "ΕΚΤΥΠΩΣΗ ΣΥΓΚΕΝΤΡΩΤΙΚΗΣ ΤΙΜΟΛΟΓΙΩΝ"
        EtiketaLbl.Location = New Point(ExtraParEktPnl.Width / 12, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        SigkPnl.Size = New Point(351, 207)
        SigkPnl.Location = New Point(140, EtiketaPnl.Height)
        SigkPck1.MinDate = arxiEtous
        SigkPck1.MaxDate = telosEtous
        SigkPck1.Value = arxiEtous
        SigkPck2.Value = imeromErgasias
        'EkdosiParastPck.Enabled = False
        init_sigk_variablen()
        fuehle_ekd_sigk_cbx()
        sigkEkdCbx.SelectedIndex = 0
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(SigkPnl)
    End Sub
    Private Sub init_sigk_variablen()
        'Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter

        kwdApyAfm = -1
    End Sub
    Private Sub fuehle_ekd_sigk_cbx()
        Dim j As Int16
        sigkEkdCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet1.afm.Count
            If j = 0 Then
                sigkEkdCbx.Items.Add("<Εταιρεία>")
            Else
                sigkEkdCbx.Items.Add(Me.DbhotelDataSet1.afm(j - 1)._alias)
            End If
        Next
    End Sub
    Private Sub sigkEkdCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sigkEkdCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdSigkAfm = -1
        Else
            kwdSigkAfm = Me.DbhotelDataSet1.afm(sender.selectedINdex - 1).kwd
        End If
    End Sub
    Private Sub SigkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SigkBtn.Click
        Dim j, i As Int64
        Dim drarray() As DataRow
        Dim filterExp As String
        'Dim kwd As Integer = 0 
        If kwdSigkAfm <> -1 Then
            Dim sigkAdapter As New dbhotelDataSetTableAdapters.SigkentrwtikiTimologiwnTableAdapter
            Dim onomataAdapter As New dbhotelDataSetTableAdapters.timologioanalysisTableAdapter
            Dim afmadapter As New dbhotelDataSetTableAdapters.afmTableAdapter
            afmadapter.FillByKwd(Me.DbhotelDataSet.afm, kwdSigkAfm)
            sigkAdapter.SigkentrwtikiTimologiwn(Me.DbhotelDataSet.SigkentrwtikiTimologiwn, kwdSigkAfm, SigkPck1.Value.Date, SigkPck2.Value.Date, False)
            onomataAdapter.OnomataSigkByIm1Im2Akyr(Me.DbhotelDataSet.timologioanalysis, SigkPck1.Value.Date, SigkPck2.Value.Date, False)
            For j = 0 To Me.DbhotelDataSet.SigkentrwtikiTimologiwn.Count - 1
                'If kwd <> Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).kwd Then
                'kwd = Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).kwd

                If Math.Abs((Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).synola - Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).analsynola)) < 0.1 Then
                    '  MsgBox(Math.Abs((Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).synola - Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).analsynola)))
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).ekptosikathposo = 0
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).ekptosifpa = 0
                Else
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).ekptosikathposo = Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).analsumkathposa - Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).sumkathposa
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).ekptosifpa = Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).analfpa - Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).fpa
                End If

                'End If
                If ist_pistotiko(Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).parastatiko) Then
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).sumkathposa = (-1) * Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).sumkathposa
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).fpa = (-1) * Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).fpa
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).synola = (-1) * Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).synola
                End If
                filterExp = "timologio= " + Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).kwd.ToString
                drarray = Me.DbhotelDataSet.timologioanalysis.Select(filterExp)
                For i = 0 To drarray.Length - 1
                    Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).onomateponumo = Me.DbhotelDataSet.SigkentrwtikiTimologiwn(j).onomateponumo + " - " + drarray(i)("onomateponumo")
                Next
            Next

            ektiposi_sigk()
            init_sigk_variablen()
        End If

    End Sub
    Private Sub ektiposi_sigk()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New SigkTimologiwn()

        Me.DbhotelDataSet.ekt_status_ekdosi.Clear()
        Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()
        Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = SigkPck1.Value.Date
        Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = SigkPck2.Value.Date
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    '**************************LOGARIAMOI ANAXWROUNTWN PELATWN*********LOGARIAMOI ANAXWROUNTWN PELATWN***********************LOGARIAMOI ANAXWROUNTWN PELATWN
    Private Sub logariasmoi_anaxwrountwn()
        statusParast = Nothing
        dataset_clear()
        'EkdosiParastSynolaLbl.Size = New Point(85, 22)
        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Κατάσταση Λογαριασμών Αναχωρούντων"
        EtiketaLbl.Location = New Point(LogarAnaxPnl.Width / 8, 25)

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        LogarAnaxPnl.Location = New Point(122, EtiketaPnl.Height)
        Me.LogarAnaxPnl.Size = New Point(336, 212)

        LogarAnaxPck.Value = imeromErgasias

        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(LogarAnaxPnl)

    End Sub
    Private Sub LogarAnaxBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogarAnaxBtn.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
            Me.DbhotelDataSet.logariasmoianaxwrountwn.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            If LogRdb1.Checked Then
                Me.LogariasmoianaxwrountwnTableAdapter.FillAnexoflitousLogariasmousAnaxwrountwn(Me.DbhotelDataSet.logariasmoianaxwrountwn, New System.Nullable(Of Date)(CType(LogarAnaxPck.Value, Date)), 0)
            Else
                Me.LogariasmoianaxwrountwnTableAdapter.FillLogariasmoiAnaxwrountwn(Me.DbhotelDataSet.logariasmoianaxwrountwn, New System.Nullable(Of Date)(CType(LogarAnaxPck.Value, Date)))
            End If



            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = LogarAnaxPck.Value
            proepiskopisi_katastasi_logariamwn()
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub proepiskopisi_katastasi_logariamwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New LogariasmoiAnaxwrountwn()

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True
        Form1.ShowDialog()
        ektiposi.Close()
        ektiposi.Dispose()
    End Sub

    Private Sub ekdosi_ge_maziki()

        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Μαζική έκδοση Γραμμάτιων Είσπραξης"
        EtiketaLbl.Location = New Point(EkdosiGEMazikiPnl.Width / 8, 25)

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        EkdosiGEMazikiPnl.Location = New Point(122, EtiketaPnl.Height)
        Me.EkdosiGEMazikiPnl.Size = New Point(336, 212)

        EkdosiGEMazikiPck.Value = imeromErgasias

        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EkdosiGEMazikiPnl)


        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EkdosiGEMazikiPnl)
    End Sub
    Private Sub EkdosiGEMazikiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkdosiGEMazikiBtn.Click
        'EDW KANW MERKEN MEXRI PIO AA EXEI BGEI (grammatia exoun kwd 3 sto Table->STARRES)

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ParastatikaTableAdapter.FillByKwd(Me.DbhotelDataSet.parastatika, 3)
            'PRWTA KANW TRANSACTION ME KATHE KRATISI KSEXWRISTA

            ekdosi_ge()
            'TWRA KANW LADEN TA nea GRAMATIA (me aa > apo ) 
            Me.LogariasmoidiamTableAdapter.FillForMazikiEkdosiGEByAAgramm(Me.DbhotelDataSet.logariasmoidiam, Me.DbhotelDataSet.parastatika(0).aritthmos)

            If Me.DbhotelDataSet.logariasmoidiam.Count <> 0 Then
                Me.DbhotelDataSet.ektiposeis_genika.Rows.Clear()
                Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
                Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias

                Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
                Me.KratiseisTableAdapter.FillByEtos(Me.DbhotelDataSet.kratiseis, etos)
                Me.EnilikesTableAdapter.FillDiamenwntesByCheckinCheckout(Me.DbhotelDataSet.enilikes, True, False)

                proepiskopisi_mazikwn_ge()
            Else
                MsgBox("Δεν υπάρχουν εκκρεμή Γραμμάτια Είσπραξης προς Εκδοση !", MsgBoxStyle.Information, "winfo\nikEl.")
            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ekdosi_ge()
        Dim startIndex, stepsIndex As Int16
        Dim pistosi, pliromi As Single
        ' prwta anaksofliotous Logariamous Laden (einai sortiert kata kratisi kwd)
        Me.LogariasmoianaxwrountwnTableAdapter.FillAnexoflitAnaxwrforMazikiEkdGE(Me.DbhotelDataSet.logariasmoianaxwrountwn, New System.Nullable(Of Date)(CType(EkdosiGEMazikiPck.Value, Date)), 0)

        'kanw hinzufuegen oles tous kRatiseis kwdikoous sto exoflKrat() gia na kanw metepaita transaktion!
        Do Until startIndex > Me.DbhotelDataSet.logariasmoianaxwrountwn.Count - 1
            stepsIndex = 1 'posa eintraege 
            pistosi = 0
            pliromi = 0
            'firstIndex = startIndex
            If startIndex < Me.DbhotelDataSet.logariasmoianaxwrountwn.Count - 1 Then
                While Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex).kratkwd = Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex + stepsIndex).kratkwd
                    stepsIndex += 1
                    pistosi = pistosi + Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex).pistosi
                    pliromi = pliromi + Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex).pliromi
                    If startIndex + stepsIndex > Me.DbhotelDataSet.logariasmoianaxwrountwn.Count - 1 Then
                        Exit While
                    End If
                End While
                'If Me.DbhotelDataSet.epanekdositimologiou(startIndex).exoflithi = False Then
                exoflise_kratisi_transaction(connectionString, startIndex, pistosi, pliromi) ' ana praktoreio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                startIndex = startIndex + stepsIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'If Me.DbhotelDataSet.epanekdositimologiou(startIndex).exoflithi = False Then
                pistosi = pistosi + Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex).pistosi
                pliromi = pliromi + Me.DbhotelDataSet.logariasmoianaxwrountwn(startIndex).pliromi
                exoflise_kratisi_transaction(connectionString, startIndex, pistosi, pliromi)  ' ana praktoreio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                Exit Do
            End If
        Loop


    End Sub
    Private Function exoflise_kratisi_transaction(ByVal connectionstring As String, ByVal firstIndex As Int16, ByVal pistosi As Single, ByVal pliromi As Single) As Boolean
        Dim aa As Int16
        Using connection As New OleDb.OleDbConnection(connectionstring)

            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Try
                connection.Open()
                'tha mporeousa na xrisimopoiisw IsolationsLevel.ReadUncommited gia na apofugw tin extrem periptwsi pou 2 user diabasoun ton
                'tautoxrona ton Idio aage apo etaireia->alla ich nehme das schon im Kauf, da aage Nicht so wichtig!
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                command.Connection = connection
                command.Transaction = transaction

                'command.CommandText = "CREATE TABLE Simple (ID long)"

                'diabazw o aa twn GE apo etaireia 
                command.CommandText = "SELECT aritthmos FROM parastatika where (kwd=3)" 'and (identifikation=?)
                Dim myReader As OleDb.OleDbDataReader
                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                myReader.Read()
                aa = myReader.GetInt32(0)
                ' always call Close when done reading.
                myReader.Close()
                command.Parameters.Clear()

                aa += 1

                command.Parameters.AddWithValue("aa", aa)
                command.Parameters.AddWithValue("imerominia", imeromErgasias)
                command.Parameters.AddWithValue("diamenwn", Me.DbhotelDataSet.logariasmoianaxwrountwn(firstIndex).diamenwn)
                command.Parameters.AddWithValue("poso", (pistosi - pliromi))
                command.CommandText = "INSERT INTO gramatia (aa, imerominia, diamenwn, poso, akyro)" &
                "VALUES (aa, imerominia, diamenwn, poso, false)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()


                command.Parameters.AddWithValue("aagramatio", aa)
                command.Parameters.AddWithValue("kratisi", Me.DbhotelDataSet.logariasmoianaxwrountwn(firstIndex).kratkwd)
                command.CommandText = "UPDATE logariasmoidiam SET aagramatio=? WHERE (kratisi=?)and (aagramatio=0)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()


                command.Parameters.AddWithValue("aage", aa)
                'command.Parameters.AddWithValue("identifikation", timolID)
                command.CommandText = "UPDATE parastatika SET aritthmos=? where (kwd=3)" 'and (identifikation=?)
                command.ExecuteNonQuery()
                command.Parameters.Clear()


                transaction.Commit()

            Catch ex As Exception
                Try
                    transaction.Rollback()
                    Return -1
                Catch
                    Return -1
                End Try

            End Try
        End Using

        Return aa

    End Function
    Private Sub proepiskopisi_mazikwn_ge()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New GrammEispraksisMazika

        If EkdosiGEMazikiRdb2.Checked Then
            ektiposi.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
        End If
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True
        Form1.ShowDialog()
        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    '**************************ELEGXOS KRATISEIS**********ELEGXOS KRATISEIS*************************************ELEGXOS KRATISEIS***
    '**************************ELEGXOS KRATISEIS*****************ELEGXOS KRATISEIS*************************************ELEGXOS KRATISEIS***
    '**************************ELEGXOS KRATISEIS*****************ELEGXOS KRATISEIS*************************************ELEGXOS KRATISEIS***
    '**************************ELEGXOS KRATISEIS*****************ELEGXOS KRATISEIS*************************************ELEGXOS KRATISEIS***
#Region "Commented Out Code"
    Private Sub elegxos_afixewn()
        Dim j, countDB As Int16
        DateTimePicker2.CustomFormat = " dd/MM/yy  -  H:mm "
        DateTimePicker3.CustomFormat = " dd/MM/yy  " ' " dd/MM/yy  -  H:mm "
        DateTimePicker2.MinDate = "1/1/" + etos.ToString
        status = 1
        sesionID = get_sesion()
        Me.KratiseisTableAdapter.FillAnamenwntesByAfixCheckinTimol(Me.DbhotelDataSet.kratiseis, imeromErgasias, False, 0)

        ReDim kwdKratAnam(-1)

        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1 'silegw ola ta kwd sto Array
            ReDim Preserve kwdKratAnam(j)
            kwdKratAnam(j) = Me.DbhotelDataSet.kratiseis(j).kwd
        Next
        If kwdKratAnam.Length > 0 Then 'gia to prwto kwd sto Array
            Me.DbhotelDataSet.kratiseis.Clear()
            countDB = Me.KratiseisTableAdapter.FillByKwd(Me.DbhotelDataSet.kratiseis, kwdKratAnam(0))
            kwdKratAnam(0) = -1 ' meta -1
            If countDB = 1 Then
                suche_anamenontes(Me.DbhotelDataSet.kratiseis(0).kwd, Me.DbhotelDataSet.kratiseis(0).arithmos)
            End If
            init_kratiseis_anamenwntes()
        Else
            MsgBox("Δεν υπάρχουν εκκρεμείς Αφίξεις !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If

    End Sub

    Private Sub next_anamenwnta()
        Dim j, countDB As Int16


        For j = 0 To kwdKratAnam.Length - 1
            If kwdKratAnam(j) <> -1 Then 'den exei idi ginei
                Me.DbhotelDataSet.kratiseis.Clear()
                countDB = Me.KratiseisTableAdapter.FillByKwd(Me.DbhotelDataSet.kratiseis, kwdKratAnam(j))
                kwdKratAnam(j) = -1
                If countDB = 1 Then
                    suche_anamenontes(Me.DbhotelDataSet.kratiseis(0).kwd, Me.DbhotelDataSet.kratiseis(0).arithmos)
                    Exit Sub
                End If
            End If
        Next
        MsgBox("Ο Έλγχος Αφίξεων ολοκληρώθηκε !", MsgBoxStyle.Information, "winfo\nikEl.")
        KleisimoZentralPnl.Controls.Clear()

    End Sub


    Private Sub suche_anamenontes(ByVal kwdKratTemp As Integer, ByVal kratisiArithm As String)
        kwdikoKratisisDB = kwdKratTemp
        Me.KratiseisTableAdapter.FillByKwd(Me.DbhotelDataSet.kratiseis, kwdikoKratisisDB)
        KratisiTbx.Text = kratisiArithm
        kwdikoKratisisDB = kwdKratTemp
        ekptPoso = Me.DbhotelDataSet.kratiseis(0).ekptposo
        ekptPososto = Me.DbhotelDataSet.kratiseis(0).ekptpososto
        ekptFree = Me.DbhotelDataSet.kratiseis(0).ekptimeres
        ekptCFee = Me.DbhotelDataSet.kratiseis(0).fee
        Kratiseis4Pnl.Controls.Clear()
        ButtonsPnl.Controls.Clear()
        Kratiseis2Pnl.Enabled = True
        Kratiseis3Pnl.Enabled = True
        kratiseis_zeig(True)
        ButtonsPnl.Enabled = True
        Kratiseis4Pnl.Enabled = True
    End Sub

    Private Sub init_kratiseis_anamenwntes()
        'Etiketa panel initialisieren
        'KleisimoZentralPnl.Controls.Clear()

        EtiketaLbl.Text = "ΕΛΕΓΧΟΣ ΑΦΙΞΕΩΝ"
        EtiketaPnl.Controls.Add(Me.EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)

        ImeromKratTbx.Text = imeromErgasias.Date
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        Kratiseis1Pnl.Location = New Point(5, EtiketaPnl.Height)
        Kratiseis2Pnl.Location = New Point(Kratiseis1Pnl.Width + 10, EtiketaPnl.Height)

        Kratiseis3Pnl.Location = New Point(5, Kratiseis1Pnl.Location.Y + Kratiseis1Pnl.Height + 5)

        Kratiseis4Pnl.Location = New Point(Kratiseis1Pnl.Location.X, Kratiseis1Pnl.Location.Y + Kratiseis1Pnl.Height + Kratiseis3Pnl.Height + 10)
        SynolPnl.Location = New Point(Kratiseis4Pnl.Location.X + Kratiseis4Pnl.Width - SynolPnl.Width, Kratiseis4Pnl.Location.Y + Kratiseis4Pnl.Height + 5)
        'NonShowLbl.Text = ""
        'Kratiseis1Pnl.Enabled = False
        DateTimePicker2.Enabled = False
        KleisimoZentralPnl.Controls.Add(Kratiseis1Pnl)
        KleisimoZentralPnl.Controls.Add(Kratiseis2Pnl)
        KleisimoZentralPnl.Controls.Add(Kratiseis3Pnl)
        KleisimoZentralPnl.Controls.Add(Kratiseis4Pnl)
        KleisimoZentralPnl.Controls.Add(SynolPnl)
    End Sub
    Private Sub kratiseis_zeig(ByVal remalen As Boolean)
        If remalen AndAlso Me.DbhotelDataSet.kratiseis.Count <> 0 AndAlso kwdikoKratisisDB <> -1 Then
            isDBEintrag = True
            remale_kratisi()
        End If
    End Sub
    Private Sub remale_kratisi()
        Dim j As Int16
        Dim find() As Control
        Dim index As Int16
        Dim simbolAA As Int16
        Dim ekptosiPoso As Single

        'EtikLbl.Text = "ΚΡΑΤΗΣΕΙΣ ΑΦΙΞΕΙΣ ΕΠΕΞΕΡΓΑΣΙΑ ΚΡΑΤΗΣΗΣ-ΑΦΙΞΗΣ"
        PraktTbx.Text = get_praktoreio_by_kwdiko(Me.DbhotelDataSet.kratiseis(0).praktoreio)
        KwdPraktTbx1.Text = Me.DbhotelDataSet.kratiseis(0).praktoreio
        PraktTimolTbx.Text = get_praktoreio_by_kwdiko(Me.DbhotelDataSet.kratiseis(0).praktimologio)
        KwdPraktTbx2.Text = Me.DbhotelDataSet.kratiseis(0).praktimologio
        VoucherTbx.Text = Me.DbhotelDataSet.kratiseis(0).voucher
        ImeromKratTbx.Text = Me.DbhotelDataSet.kratiseis(0).imeromkratisis

        'DateTimePicker2.Value = Me.DbhotelDataSet.kratiseis(0).afixi
        DateTimePicker2.Value = New DateTime(Me.DbhotelDataSet.kratiseis(0).afixi.Year, Me.DbhotelDataSet.kratiseis(0).afixi.Month,
        Me.DbhotelDataSet.kratiseis(0).afixi.Day, Me.DbhotelDataSet.kratiseis(0).wra.Hour.ToString, Me.DbhotelDataSet.kratiseis(0).wra.Minute.ToString, 0)
        currentAfixi = DateTimePicker2.Value.Date
        DateTimePicker3.Value = Me.DbhotelDataSet.kratiseis(0).anaxwrisi
        currentAnaxwrisi = DateTimePicker3.Value.Date

        praktoreiokwd = Me.DbhotelDataSet.kratiseis(0).praktoreio
        praktortimolkwd = Me.DbhotelDataSet.kratiseis(0).praktimologio
        DwmTbx.Text = Me.DbhotelDataSet.kratiseis(0).dwmatio

        SimbCbx.Items.Clear()
        If isDBEintrag Then     'EDW ALAKSA ->O USER DEN PREPEI GIA NEO EINTRAG NA KSANADWSEI EK NEOY PRAKTOREIO(BLEPE MANIKI->synexomena to idio prakt gia neue Eintraege) 
            'Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

            'fuehle_simbol_cboxen()
            'Try
            '    simbolAA = Me.SimbolaiaTableAdapter.GetAAByKwd(Me.DbhotelDataSet.kratiseis(0).simbolaio)
            '    index = get_index_simbolaio_cbox(simbolAA)
            '    SimbCbx.SelectedIndex = index
            'Catch ex As StrongTypingException
            '    SimbCbx.SelectedIndex = -1
            'End Try
            Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
            fuehle_simbol_cboxen()

            'simbolAA = Me.SimbolaiaTableAdapter.GetAAByKwd(Me.DbhotelDataSet.kratiseis(0).simbolaio)
            simbolAA = get_aa_simbolaiou_by_kwd(Me.DbhotelDataSet.kratiseis(0).simbolaio)
            If simbolAA <> -1 Then
                index = get_index_simbolaio_cbox(simbolAA)
                SimbCbx.SelectedIndex = index
            Else
                SimbCbx.SelectedIndex = -1
            End If

        End If



        If KlinesCbx.Items.Count = 0 OrElse TipiCbx.Items.Count = 0 Then
            init_klines_tipoi_cboxen()
        End If
        'MsgBox(Me.DbhotelDataSet.kratiseis(0).klines)
        'MsgBox(Me.DbhotelDataSet.kratiseis(0).tipos)
        currenttipos = Me.DbhotelDataSet.kratiseis(0).tipos
        currentklines = Me.DbhotelDataSet.kratiseis(0).klines
        index = get_index_klines(Me.DbhotelDataSet.kratiseis(0).klines)
        KlinesCbx.SelectedIndex = index + 1
        index = get_index_tipos(Me.DbhotelDataSet.kratiseis(0).tipos)
        TipiCbx.SelectedIndex = index + 1
        'isDBEintrag = False
        CheckBox1.Checked = Me.DbhotelDataSet.kratiseis(0).guarantie
        EnilikTbx.Text = Me.DbhotelDataSet.kratiseis(0).enilikes
        Me.EnilikesTableAdapter.FillByKratisi(Me.DbhotelDataSet.enilikes, kwdikoKratisisDB) 'laden toys enilikes sortiert nach DB kwdiko toys-> Gia metepeita Update!!!!!
        Dim countEnilikes As Int16
        OnomTbx1.Clear()
        OnomTbx2.Clear()
        OnomTbx3.Clear()
        If Me.DbhotelDataSet.enilikes.Count > 3 Then 'giati stin forma exw mono 3 felder gia onomata enilikwn
            countEnilikes = 3
        Else
            countEnilikes = Me.DbhotelDataSet.enilikes.Count
        End If
        For j = 0 To countEnilikes - 1
            find = Kratiseis2Pnl.Controls.Find("OnomTbx" + (j + 1).ToString, False)
            find(0).Text = Me.DbhotelDataSet.enilikes(j).onomateponimo
        Next

        Me.PaidiaTableAdapter.FillByKratisi(Me.DbhotelDataSet.paidia, kwdikoKratisisDB)
        Dim countPaidia As Int16
        CotTbx1.Clear()
        CotTbx2.Clear()
        CotTbx3.Clear()
        PaidiTbx1.Text = 0
        PaidiTbx2.Text = 0
        PaidiTbx3.Text = 0
        If Me.DbhotelDataSet.paidia.Count > 3 Then 'giati stin forma exw mono 3 felder gia onomata PAIDIWN
            countPaidia = 3
        Else
            countPaidia = Me.DbhotelDataSet.paidia.Count
        End If
        For j = 0 To countPaidia - 1
            find = Kratiseis2Pnl.Controls.Find("PaidiTbx" + (j + 1).ToString, False)
            find(0).Text = Me.DbhotelDataSet.paidia(j).ilikia
            find = Kratiseis2Pnl.Controls.Find("CotTbx" + (j + 1).ToString, False)
            find(0).Text = Me.DbhotelDataSet.paidia(j).cot
        Next

        'Ethnikotites
        EthnAnzTbx1.Text = Me.DbhotelDataSet.kratiseis(0).anzethnikotites
        Try
            'MsgBox(Me.DbhotelDataSet.kratiseis(0).ethnikotites)
            EthnKwd1.Text = Me.DbhotelDataSet.kratiseis(0).ethnikotites
            If Me.DbhotelDataSet.kratiseis(0).ethnikotites <> 0 Then
                kwdEthnik1.Text = Me.DbhotelDataSet.kratiseis(0).ethnikotites
            Else
                kwdEthnik1.Clear()
            End If
            EthnikTbx1.Text = get_ethikotita_by_kwdiko(Me.DbhotelDataSet.kratiseis(0).ethnikotites)
        Catch ex As StrongTypingException
            EthnikTbx1.Clear()
            kwdEthnik1.Clear()
        End Try
        EthnAnzTbx2.Text = Me.DbhotelDataSet.kratiseis(0).anzethnikotites2
        Try
            EthnKwd2.Text = Me.DbhotelDataSet.kratiseis(0).ethnikotites2
            If Me.DbhotelDataSet.kratiseis(0).ethnikotites2 <> 0 Then
                kwdEthnik2.Text = Me.DbhotelDataSet.kratiseis(0).ethnikotites2
            Else
                kwdEthnik2.Clear()
            End If
            EthnikTbx2.Text = get_ethikotita_by_kwdiko(Me.DbhotelDataSet.kratiseis(0).ethnikotites2)
        Catch ex As StrongTypingException
            EthnikTbx2.Clear()
            kwdEthnik2.Clear()
        End Try

        TilefTbx.Text = Me.DbhotelDataSet.kratiseis(0).tilefonomem
        DateTimePicker4.Value = Me.DbhotelDataSet.kratiseis(0).epithimdate
        EpithimTbx.Text = Me.DbhotelDataSet.kratiseis(0).epithimia
        SimetTbx.Text = Me.DbhotelDataSet.kratiseis(0).simetoxi.ToString("F")
        ProkatTbx.Text = Me.DbhotelDataSet.kratiseis(0).prokataboli.ToString("F")
        DateTimePicker5.Value = Me.DbhotelDataSet.kratiseis(0).prokatdate
        PliromCbx.SelectedIndex = Me.get_index_von_pliromicbox(Me.DbhotelDataSet.kratiseis(0).pliromi)


        'If Me.DbhotelDataSet.touristperiodoi.Count = 0 Then
        Me.TouristperiodoiTableAdapter.FillBySimbAnaxwrisiAfixi(Me.DbhotelDataSet.touristperiodoi, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date,
                        currentsimbolaio, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date)
        'End If
        'MsgBox(Me.DbhotelDataSet.touristperiodoi.Count)
        Me.TimeskratisisTableAdapter.FillByKratisi(Me.DbhotelDataSet.timeskratisis, kwdikoKratisisDB)
        male_timokatalogous_pnl(Me.DbhotelDataSet.timeskratisis.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True, 1)

        If Me.DbhotelDataSet.kratiseis(0).ekptosi Then
            ekptosiPoso = rechne_ekptosi_vom_synola(Me.DbhotelDataSet.kratiseis(0).synolo, Me.DbhotelDataSet.kratiseis(0).ekptposo, Me.DbhotelDataSet.kratiseis(0).ekptpososto, Me.DbhotelDataSet.kratiseis(0).ekptimeres, Me.DbhotelDataSet.kratiseis(0).fee)
            EkptosiLbl.Text = "Έκπτωση: " + ekptosiPoso.ToString("N")
        End If

        SynolLbl.Text = Me.DbhotelDataSet.kratiseis(0).synolo.ToString("N")
        'firstLoadDBEintrag = False
    End Sub
    Private Sub init_klines_tipoi_cboxen()
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.klines.Count
            If j <> 0 Then
                KlinesCbx.Items.Add(Me.DbhotelDataSet.klines(j - 1).perigrafi)
            Else
                KlinesCbx.Items.Add("Όλες")
            End If
        Next
        For j = 0 To Me.DbhotelDataSet.tipoi.Count
            If j <> 0 Then
                TipiCbx.Items.Add(Me.DbhotelDataSet.tipoi(j - 1).tipos)
            Else
                TipiCbx.Items.Add("Όλοι")
            End If
        Next
    End Sub
    Private Sub PraktTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()
        Dim kwdikos, xrewsikwdikos As Integer
        Dim praktname As String
        'MsgBox(sender.backcolor)
        'Dim praktoreiokwd, praktortimolkwd, currentklines, currenttipos, currentsimbolaio As Integer ' apoimeres
        'If status = 1 Or status = 2 And isDBEintrag Then

        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        kwdikos = PraktForm.return_praktoreio_kwdikos
        xrewsikwdikos = PraktForm.return_praktoreio_xrewsi
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If praktoreiokwd = Nothing Then
                PraktTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
                VoucherTbx.Focus()
                Exit Sub
            End If
        Else
            Kratiseis4Pnl.Controls.Clear()
            ButtonsPnl.Controls.Clear()
            If status = 2 AndAlso kwdikos <> praktoreiokwd Then 'diamewntes allagi Praktoreiou kata'AndAlso currentAfixi < imeromErgasias
                'thn diarkeia diamonis (oxi 1 mera)->touristperios stis timeskratiseis DB pairnei -1 
                MsgBox(" Με την Αλλαγή του Πρακτορείου πρέπει να ελεχθούν ξανά οι τιμές !", MsgBoxStyle.Information, "winfo\nikEl.")
                praktoreiokwdValue = kwdikos ' se autin tin periptwsi 
            Else
                praktoreiokwd = kwdikos
            End If

            If xrewsikwdikos = 0 Then
                praktXrewsKwd = -1
            Else
                praktXrewsKwd = xrewsikwdikos
            End If
            KwdPraktTbx1.Text = kwdikos
            KwdPraktTbx2.Text = kwdikos
            praktortimolkwd = kwdikos
            currentsimbolaio = -1
            'currentsimbolaioValue = -1
            If KlinesCbx.Items.Count = 0 OrElse TipiCbx.Items.Count = 0 Then
                init_klines_tipoi_cboxen()
            Else
                KlinesCbx.SelectedIndex = -1
                TipiCbx.SelectedIndex = -1
            End If
            SimbCbx.Items.Clear()
            Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

            fuehle_simbol_cboxen()
            ReDim timokatalog(-1)
        End If
        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos
        currenttipos = 0
        currentklines = 0
        praktname = PraktForm.return_praktoreio
        If praktname = Nothing Then
            PraktTbx.Text = sender.text
        Else
            PraktTbx.Text = praktname
        End If
        'PraktTbx.Text = PraktForm.return_praktoreio
        If praktoreiokwd = praktortimolkwd Then
            PraktTimolTbx.Text = PraktTbx.Text
        End If

        PraktForm.Dispose()

        If isDBEintrag Then
            Me.TouristperiodoiTableAdapter.FillBySimbAnaxwrisiAfixi(Me.DbhotelDataSet.touristperiodoi, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date,
                           currentsimbolaio, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date)

        End If

        VoucherTbx.Focus()
        If SimbCbx.Items.Count <> 0 Then
            SimbCbx.SelectedIndex = 0
        End If
        'Else
        'MsgBox("Δεν επιλέχθηκε Διαμένων: Πατήστε τον φακό για επιλογή απο Λίστα ή εισάγετε τον Αρ.Κράτησης στο αντίστοιχο πεδίο και μετά πατήστε τον φακό!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        'End If

    End Sub
    Private Sub PraktTimologioTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktTimolTbx.Click
        Dim PraktForm As New SimbolaiaFrm()

        'If status = 1 Or status = 2 And isDBEintrag Then
        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        praktortimolkwd = PraktForm.return_praktoreio_kwdikos

        If praktortimolkwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            PraktTimolTbx.Text = PraktTbx.Text
            praktortimolkwd = praktoreiokwd
            Exit Sub
        End If
        'Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
        PraktTimolTbx.Text = PraktForm.return_praktoreio
        KwdPraktTbx2.Text = PraktForm.return_praktoreio_kwdikos
        PraktForm.Dispose()
        'End If
    End Sub
    Private Sub DateTimePicker3_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.Enter
        ButtonsPnl.Enabled = False
        Kratiseis4Pnl.Enabled = False
    End Sub
    Private Function DateTimePicker3_ValueChanged() As Boolean 'ByVal sender As System.Object, ByVal e As System.EventArgs Handles DateTimePicker3.Leave
        'Dim index, count As Int16

        If DateTimePicker3.Value.Date <= currentAfixi Then
            MsgBox("Αναχώριση προγεγενέστερα της Αφιξης !", MsgBoxStyle.Critical, "winfo\nikEl.")

            DateTimePicker3.Value = currentAnaxwrisi
            Kratiseis4Pnl.Enabled = True
            ButtonsPnl.Enabled = True
            Return False
        End If

        'If status = 2 Then
        '    If DateTimePicker3.Value < imeromErgasias.Date Then
        '        MsgBox("Αναχώρηση προγενέστερα της τρέχουσας Ημερομηνίας Εργασίας !", MsgBoxStyle.Critical, "winfo\nikEl.")
        '        Return False
        '    Else
        '        anaxSperre = False
        '    End If
        'End If

        ButtonsPnl.Enabled = True
        Kratiseis4Pnl.Enabled = True

        Return DateTimePicker3_Validating()
    End Function
    Private Function DateTimePicker3_Validating() As Boolean ' Handles DateTimePicker3.Validating

        If DateTimePicker3.Value.Date <> currentAnaxwrisi Then 'kanw to TextChanged simulieren!!!!
            'If (status = 2 And DateTimePicker3.Value.Date <= currentAfixi) Or (status = 2 And DateTimePicker3.Value.Date < imeromErgasias.Date) Or anaxSperre Then
            '    Return False
            'End If
            If DateTimePicker3.Value.Date <= DateTimePicker2.Value.Date Then
                MsgBox("Αναχώριση προγεγενέστερα της Αφιξης !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Kratiseis4Pnl.Controls.Clear()
                ButtonsPnl.Controls.Clear()
                TimesBtn.Enabled = False
                Return False
            Else
                If currentsimbolaio > 0 Then
                    Dim arxiTourPer, lixiTourPer As Date

                    lixiTourPer = Me.TouristperiodoiTableAdapter.GetLixiToyrPeriodBySimb(currentsimbolaio)
                    If DateTimePicker3.Value.Date > lixiTourPer.AddDays(1) Then
                        MsgBox("Η Αναχώριση είναι αργότερα απο την τελευταία Τουριστική Περίοδο (" + lixiTourPer + ")", MsgBoxStyle.Critical, "winfo\nikEl.")
                        Return False
                    End If
                    arxiTourPer = Me.TouristperiodoiTableAdapter.GetArxiTourPeriodBySimbolaikwd(currentsimbolaio)
                    If DateTimePicker2.Value.Date < arxiTourPer Then
                        MsgBox("Η Άφιξη είναι νωρίτερα απο την πρώτη Τουριστική Περίοδο (" + arxiTourPer + ")", MsgBoxStyle.Critical, "winfo\nikEl.")
                        Return False
                    End If
                End If
            End If

        End If
        currentAnaxwrisi = DateTimePicker3.Value.Date
        Return True
    End Function
    Private Sub elegxos_timwn()
        Dim count, j As Int16 'index,
        Dim pnl(), find() As Object
        count = Me.DbhotelDataSet.touristperiodoi.Count - 1
        If isDBEintrag AndAlso count >= 0 Then
            'count>0 simainei oti uparxoun touristikoi periodoi uberhaupt
            'ean tourist periodoi>= apo times kratisis.count->se periptwsi apothikeumenis ktratisis h diamenwntes pou Alazw tin diamoni (anaxwrisi)
            'se nea touristiki periodo  
            Dim e As System.EventArgs = Nothing
            If flagKr = 1 Then
                For j = 0 To Me.DbhotelDataSet.touristperiodoi.Count - 1
                    pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + Me.DbhotelDataSet.touristperiodoi(j).kwd.ToString, False)

                    Try
                        find = pnl(0).Controls.Find("Hme1" + Me.DbhotelDataSet.touristperiodoi(j).kwd.ToString, False)
                        imeres_leave(find(0), e)
                    Catch ex As IndexOutOfRangeException
                        MsgBox("ΠΡΟΣΟΧΗ: Πρέπει να ελεχθούν οι τιμές ξανά !", MsgBoxStyle.Exclamation, "winfo\nikEl.")


                    End Try
                Next
            ElseIf flagKr = 2 Then
                For j = 0 To Me.DbhotelDataSet.timeskratisis.Count - 1
                    ' MONO ta  Eintraege apo timeskratisis   pou eiai PRIN tin Nea Anaxwrisi !!
                    If Me.DbhotelDataSet.timeskratisis(j).apo <= DateTimePicker3.Value.AddDays(-1) Then
                        'If Me.DbhotelDataSet.timeskratisis(j).mexri <= Me.DateTimePicker3.Value Then
                        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + Me.DbhotelDataSet.timeskratisis(j).kwd.ToString, False)

                        Try
                            find = pnl(0).Controls.Find("Hme1" + Me.DbhotelDataSet.timeskratisis(j).kwd.ToString, False)
                            imeres_leave(find(0), e)
                        Catch ex As IndexOutOfRangeException
                            MsgBox("ΠΡΟΣΟΧΗ: Πρέπει να ελεχθούν οι τιμές ξανά !", MsgBoxStyle.Exclamation, "winfo\nikEl.")

                        End Try
                    End If

                Next
            End If
        End If
    End Sub
    'Epilogi katigorias(klines,tipos) + elegxos ean yparxei ueberhaupt, Default currntklines kai currnttipos=0 ean den epilegei tipota 
    Private Sub KlinesTipoiCbx_IndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlinesCbx.SelectedIndexChanged, TipiCbx.SelectedIndexChanged
        Dim anzahl As Int16
        'If currentsimbolaio <> -1 Then
        'If Not isDBEintrag Then
        If sender.name.Equals("KlinesCbx") Then
            Kratiseis4Pnl.Controls.Clear()
            ButtonsPnl.Controls.Clear()
            If sender.selectedindex <> -1 Then
                currentklines = get_kwd_klins_byname(sender.selectedItem.ToString)
            Else
                currentklines = -1
            End If
            If currentklines = -1 Then
                currentklines = 0
                If SimbCbx.Items.Count <> 0 Then
                    If Not isDBEintrag Then
                        SimbCbx.SelectedIndex = 0
                    End If
                End If
            End If
            If currentklines > 0 Then
                anzahl = Me.KatigoriesTableAdapter.ExistEintrag2(currentklines)
                If anzahl = 0 Then
                    MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    KlinesCbx.SelectedIndex = 0
                Else
                    If SimbCbx.Items.Count <> 0 Then
                        If Not isDBEintrag Then
                            SimbCbx.SelectedIndex = 0
                        End If
                    End If
                End If
            End If
        ElseIf sender.name.Equals("TipiCbx") Then
            Kratiseis4Pnl.Controls.Clear()
            ButtonsPnl.Controls.Clear()
            If sender.selectedindex <> -1 Then
                currenttipos = get_kwd_tipos_byname(sender.selectedItem.ToString)
            Else
                currenttipos = -1
            End If
            If currenttipos = -1 Then
                currenttipos = 0
                If SimbCbx.Items.Count <> 0 Then
                    If Not isDBEintrag Then
                        SimbCbx.SelectedIndex = 0
                    End If
                End If
            End If
            If currenttipos > 0 Then
                anzahl = Me.KatigoriesTableAdapter.ExistEintrag(currenttipos)
                If anzahl = 0 Then
                    MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    TipiCbx.SelectedIndex = 0
                Else
                    If SimbCbx.Items.Count <> 0 Then
                        If Not isDBEintrag Then
                            SimbCbx.SelectedIndex = 0
                        End If
                    End If
                End If
            End If
        End If
        If currentklines > 0 And currenttipos > 0 Then
            anzahl = Me.KatigoriesTableAdapter.ExistKatigoria(currentklines, currenttipos)
            If anzahl = 0 Then
                MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                TipiCbx.SelectedIndex = 0
                KlinesCbx.SelectedIndex = 0
            Else
                If SimbCbx.Items.Count <> 0 Then
                    If Not isDBEintrag Then
                        SimbCbx.SelectedIndex = 0
                    End If
                End If
            End If
        End If
        'Else
        '    MsgBox("kALLERGIS")
        'End If
    End Sub
    'Ola ta Simbolaia toy Praktoreiu gia to etos
    Private Sub fuehle_simbol_cboxen()
        Dim j As Int16
        SimbCbx.Items.Clear()
        SimbLbl.Text = ""
        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If j <> 0 Then
                Try
                    If Me.DbhotelDataSet.simbolaia(j - 1).aasimbolaiou.Equals("") Then
                        SimbCbx.Items.Add(j)
                    Else
                        SimbCbx.Items.Add(Me.DbhotelDataSet.simbolaia(j - 1).aasimbolaiou)
                    End If
                Catch ex As NullReferenceException
                    SimbCbx.Items.Add(j)
                End Try
            Else
                SimbCbx.Items.Add("<A/A Συμβoλαίου>")
            End If

        Next
    End Sub
    'Epilogi Simbolaiou
    Private Sub SimbCbx_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimbCbx.SelectedIndexChanged
        'Dim simbolaioTemp As Integer

        'If sender.selectedindex > 0 Then
        '    simbolaioTemp = get_kwd_simbol_byAA(SimbCbx.SelectedItem.ToString) ', praktoreiokwd)
        '    If simbolaioTemp = -1 Then
        '        Exit Sub
        '    Else
        '        currentsimbolaio = simbolaioTemp
        '    End If
        '    'Poies Seasons paizoun
        'End If
        Dim simbolaioTemp As Integer

        If sender.selectedindex > 0 Then
            simbolaioTemp = get_kwd_simbolaiou_by_aa(SimbCbx.SelectedItem) ', praktoreiokwd)
            If simbolaioTemp = -1 Then
                Exit Sub
            Else
                'If currentsimbolaio <> simbolaioTemp Then
                currentsimbolaio = simbolaioTemp
                Me.SimbLbl.Text = get_perigrafi_simb_by_aa(SimbCbx.SelectedItem)
                ButtonsPnl.Enabled = False
                Kratiseis4Pnl.Enabled = False
                'End If

            End If
        End If

    End Sub
    Private Sub times_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimesBtn.Click
        Dim imeromOK As Boolean = True

        If Me.DateTimePicker2.Value.Date < Me.DateTimePicker3.Value.Date Then
            ButtonsPnl.Enabled = True
            Kratiseis4Pnl.Enabled = True
            'If currentAfixi <> Me.DateTimePicker2.Value Then
            '    imeromOK = Me.DateTimePicker2_change()
            'End If
            If imeromOK Then
                If currentAnaxwrisi <> Me.DateTimePicker3.Value Then
                    imeromOK = Me.DateTimePicker3_ValueChanged()
                End If
            End If

            If imeromOK Then
                ButtonsPnl.Controls.Clear()
                If Not isDBEintrag Then
                    'SimbCbx.SelectedIndex = -1
                    ReDim timokatalog(-1)
                End If
                Kratiseis4Pnl.Focus()
                Kratiseis4Pnl.Controls.Clear()

                Cursor = Cursors.WaitCursor

                TimesBtn.Enabled = False
                'Dim t As New System.Threading.Thread(AddressOf pruefe_imerominies_allotment)
                't.Start() 'pruefe_imerominies_allotment()
                'SynolLbl.Text = "0,00"
                Try
                    If pruefe_imerominies_allotment() Then
                        elegxos_timwn()
                        If SynolLbl.Text = "0,00" Then
                            Me.setze_sum_timokat()
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Παρουσιάστηκε σφάλμα ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    ButtonsPnl.Enabled = False
                    Cursor = Cursors.Default
                    Exit Sub
                End Try

                Cursor = Cursors.Default
                TimesBtn.Enabled = True
            Else
                MsgBox(" Ελέγξτε τις Ημερομηνίες !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                ButtonsPnl.Enabled = False
            End If
        Else
            MsgBox(" Ελέγξτε τις Ημερομηνίες !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            ButtonsPnl.Enabled = False
        End If

    End Sub
    Private Function pruefe_imerominies_allotment() As Boolean
        Dim allotmOK As Boolean
        Dim response As MsgBoxResult
        'Dim count, extraPnl As Int16
        'EINAI SORTIERT NACH APO (AFIKXI)
        Me.TouristperiodoiTableAdapter.FillBySimbAnaxwrisiAfixi(Me.DbhotelDataSet.touristperiodoi, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date,
                         currentsimbolaio, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date)
        If Not pruefe_ob_touristikes_periodoi_richtig() Then
            MsgBox(" Υπάρχει Λάθος στα χρονικά όρια των τουριστικών Περιόδων του Πρακτορείου !" & vbCrLf & " Διορθώστε τα όρια στο Μενού <Συμφωνίες->Τουριστικές Περίοδοι> !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Return False
        End If

        If currentsimbolaio > 0 Then
            If Me.DbhotelDataSet.touristperiodoi.Count <> 0 Then
                If DateTimePicker2.Value.Date < Me.DbhotelDataSet.touristperiodoi(0).apo Then
                    MsgBox("Η Άφιξη είναι νωρίτερα απο την πρώτη Τουριστική Περίοδο (" + Me.DbhotelDataSet.touristperiodoi(0).apo + ")", MsgBoxStyle.Critical, "winfo\nikEl.")
                    'If isDBEintrag Then
                    '    DateTimePicker2.Value = Me.DbhotelDataSet.touristperiodoi(0).apo
                    'End If
                    TimesBtn.Enabled = True
                    Return False
                ElseIf DateTimePicker3.Value.Date.AddDays(-1) > Me.DbhotelDataSet.touristperiodoi(Me.DbhotelDataSet.touristperiodoi.Count - 1).mexri Then
                    MsgBox("Η Αναχώριση είναι αργότερα απο την τελευταία Τουριστική Περίοδο (" + Me.DbhotelDataSet.touristperiodoi(Me.DbhotelDataSet.touristperiodoi.Count - 1).mexri + ")", MsgBoxStyle.Critical, "winfo\nikEl.")
                    TimesBtn.Enabled = True
                    Return False
                Else
                    allotmOK = pruefe_allotment()
                    Wait(0.1)
                    If Not allotmOK Then
                        response = MsgBox("Δεν υπάρχει Allotment ! Συνέχεια;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                        If response = MsgBoxResult.Yes Then
                            'Kratiseis4Pnl.Controls.Clear()
                            'ButtonsPnl.Controls.Clear()
                            If Not isDBEintrag Then
                                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, -1, True, 1) 'male timokatalogo gia kathe Season!
                            Else
                                'If status = 1 Then
                                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True, 1)

                                'End If

                            End If
                        Else
                            Exit Function
                        End If
                    Else

                        male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True, 1)

                    End If

                End If

            Else

                MsgBox(" Ημερομηνίες εκτός ορίων τουριστικής περιόδου για το Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                TimesBtn.Enabled = True
                Return False
            End If
        Else

            MsgBox(" Δεν έγινε επιλογή Συμβολαίου για το Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            TimesBtn.Enabled = True
            Return False
        End If
        Return True
    End Function
    Private Function pruefe_allotment() As Boolean
        Dim allotmOK As Boolean = False

        If currentklines <= 0 And currenttipos <= 0 Then 'arxika elgxos ob (0,0) ola me ola->(exw balei >=0 gia na sumperilambanei to -1)
            'Me.AllotmentTableAdapter.AllotmKatigoriesBySimbolaio(Me.DbhotelDataSet.allotment, currentsimbolaio)
            'ola ta Allotment pou einai MEGALYTERA tou 0
            Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date, 0, 0,
                                            currentsimbolaio, CheckBox1.Checked, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, 0, 0,
                                              currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, 0, 0)

            Return check_tupel_allotment_ob_nacheinander()


        Else
            If currenttipos > 0 AndAlso currentklines > 0 Then 'elegxos ob (x,y)
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date, currentklines, currenttipos,
                                              currentsimbolaio, CheckBox1.Checked, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentklines, currenttipos,
                                                currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, currentklines, currenttipos)

                allotmOK = check_tupel_allotment_ob_nacheinander()
            End If
            ' ean den yparxei (x,y) tote elegxos gia (0,y) kai (x,0)
            If Not allotmOK AndAlso currentklines > 0 Then
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date, currentklines, 0,
                                              currentsimbolaio, CheckBox1.Checked, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentklines, 0,
                                                currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, currentklines, 0)


                allotmOK = check_tupel_allotment_ob_nacheinander()
            End If
            If Not allotmOK AndAlso currenttipos > 0 Then
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date, 0, currenttipos,
                                              currentsimbolaio, CheckBox1.Checked, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, 0, currenttipos,
                                                currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, 0, currenttipos)


                allotmOK = check_tupel_allotment_ob_nacheinander()
            End If
            If Not allotmOK Then
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date, 0, 0,
                                                              currentsimbolaio, CheckBox1.Checked, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, 0, 0,
                                                                currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, 0, 0)


                allotmOK = check_tupel_allotment_ob_nacheinander()
            End If

            Return allotmOK


        End If




    End Function

    Private Function check_tupel_allotment_ob_nacheinander() As Boolean
        Dim j As Int16

        If Me.DbhotelDataSet.allotment.Count <> 0 Then
            If Me.DbhotelDataSet.allotment(0).apo <= DateTimePicker2.Value.Date And Me.DbhotelDataSet.allotment(Me.DbhotelDataSet.allotment.Count - 1).mexri >= DateTimePicker3.Value.AddDays(-1).Date Then
                If Me.DbhotelDataSet.allotment.Count = 1 Then
                    Return True
                Else
                    For j = 0 To Me.DbhotelDataSet.allotment.Count - 2
                        If Me.DbhotelDataSet.allotment(j).mexri.AddDays(1) <> Me.DbhotelDataSet.allotment(j + 1).apo Then
                            Return False
                            Exit For
                        End If
                    Next
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If

        Return True

    End Function
    Private Sub male_timokatalogous_pnl(ByVal arseasons As Int16, ByVal arkratisis As Int16, ByVal timokPnlMalen As Boolean, ByVal flag As Byte) 'male timokatalogo gia kathe Season!
        Dim i, count, stepy, timesCount, imeresTotal, index, extraPnl As Int16
        Dim zahl As Single 'sum,
        Dim response As MsgBoxResult

        flagKr = flag

        If timokPnlMalen Then

            Kratiseis4Pnl.Controls.Clear()
            ButtonsPnl.Controls.Clear()

            stepy = 0
            ReDim timokatalog(arseasons - 1)
            init_timokatalog()
            Me.DbhotelDataSet.timeskratisis.Clear()
            Me.DbhotelDataSet.times.Clear()
            If arkratisis <> -1 AndAlso isDBEintrag Then
                ''ACHTUNG: FILLBYKRATISI EINAI SORTIERT KATA APO (HMER/NIA)=> TO TELEYTAIO RECORD EMPERIEXEI THN ANAXWRISI=> -1 MERA HMERESTOTAL!!!!!!!!!!!!!!!!!!
                ''(H IMERES TIS DB EINAI OI OI IMERESPLIROMIS )

                'Dim praktKwdTemp As Integer
                'Try
                '    praktKwdTemp = Me.KratiseisTableAdapter.GetPraktkwdByKwd(kwdikoKratisisDB)
                'Catch ex As InvalidOperationException
                '    praktKwdTemp = -1
                'End Try
                'If praktoreiokwd = praktKwdTemp Then
                '    Me.TimeskratisisTableAdapter.FillByKratisi(Me.DbhotelDataSet.timeskratisis, kwdikoKratisisDB)
                '    Wait(0.1)
                '    timesCount = Me.DbhotelDataSet.timeskratisis.Count
                'Else
                '    response = MsgBox(" ΠΡΟΣΟΧΗ: Οι τιμές του πρηγούμενου Πρακτορείου δεν μπορούν να μεταφερθούν στο νέο: " & vbCrLf & " Για να καταχωρίσετε νέες τιμές πρέπει να διαγραφούν οι παλαιές !  " & vbCrLf & " Να Διαγραφούν οι παλαιές τιμές;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                '    If response = MsgBoxResult.Yes Then
                '        Me.TimeskratisisTableAdapter.DeleteTimesByKratisiEtos(kwdikoKratisisDB)
                '        Me.DbhotelDataSet.timeskratisis.Clear()
                '        timesCount = 0
                '    Else
                '        Exit Sub
                '    End If
                'End If
                Me.TimeskratisisTableAdapter.FillByKratisi(Me.DbhotelDataSet.timeskratisis, kwdikoKratisisDB)
                Wait(0.1)
                timesCount = Me.DbhotelDataSet.timeskratisis.Count
            End If
            'se periptwsi pou stis kratiseis o user alaksei tin AFIXI (wste na alaksei periodos) tote alazw to timesCount wste na min exw problima 
            'imeresTotal-pliromis-(to timesCount tsekarei ean to Eintrag timeskratiseis einai to teleuataio->tote einai imeresTotal 1 mera
            'ligotero apoti sinithws logw anaxwrisis)
            'ACHTUNG_>to timescount DEN einai aparaitita idio me to timekratiseis.count!!!!!!!!!!!
            If timesCount <> 0 Then
                If flag = 1 Then
                    For count = 0 To Me.DbhotelDataSet.timeskratisis.Count - 1
                        If Me.DbhotelDataSet.timeskratisis(count).mexri < DateTimePicker2.Value.Date Then
                            timesCount = timesCount - 1
                        End If
                    Next
                End If
            End If
            If flag = 2 Then
                If DateTimePicker3.Value < Me.DbhotelDataSet.kratiseis(0).anaxwrisi Then
                    'periptwsi diamenwnta pou o user mikreinei tin diamoni (anaxwrisi Datetimepicker3) stin parakatw toyristiki 
                    'periodo->epeidi controls exoun kwdikous apo timeskratisis koitw poia Eintraege apo timeskratisis  einai meta tin Nea Anaxwrisi kai DEN ta kanw malen!!
                    For count = 0 To Me.DbhotelDataSet.timeskratisis.Count - 1
                        If Me.DbhotelDataSet.timeskratisis(count).apo > DateTimePicker3.Value.AddDays(-1) Then
                            'timesCount = 0 'timesCount - 1 '0
                            Exit For
                        End If
                    Next
                    arseasons = count
                End If

            End If
            ReDim timokatalog(arseasons - 1)
            init_timokatalog()
            'kathe touristiki periodo kane mplok timis
            'edwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
            For count = 0 To arseasons - 1
                Dim KatalogPnl As New Panel
                Dim TimokChk As New CheckBox
                Dim EtiketLbl, SimfLbl, XrewsLbl, KlnsLbl, HmeresLbl, EkptLbl, TimiApoLbl, IsonLbl, HmrsLbl, InfoLbl, Info2Lbl, DedoulLbl, DedoulPosLbl, Imerom1Lbl, Imerom2Lbl As New Label 'ParoxLbl,
                Dim SimfCbx, XrewsCbx, KlnsCbx As New ComboBox
                Dim EkptTbx, Hmer1Tbx, YpnosTbx, PrwinTbx, GeumTbx, DeipTbx, ExtrTbx, SumTbx As New TextBox ', Imerom1Tbx, Imerom2Tbx, ParoxTbx,

                If flag = 1 Then
                    timokatalog(count).tourist = Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString

                    KatalogPnl.Name = "Ktlg" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString 'AChTUNG->kwd tousristikis periodou

                    SynolPnl.Name = "Synl" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString 'AChTUNG->kwd tousristikis periodou


                    TimokChk.CheckAlign = ContentAlignment.MiddleRight
                    TimokChk.Text = "Τιμοκατ."
                    TimokChk.Name = "Tmkt" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    SimfCbx.Name = "Simf" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString 'AChTUNG->kwd tousristikis periodou
                    XrewsCbx.Name = "Xres" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    KlnsCbx.Name = "Klns" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    Hmer1Tbx.Name = "Hme1" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    'ParoxTbx.Name = "Parx" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                Else
                    timokatalog(count).tourist = Me.DbhotelDataSet.timeskratisis(count).touristperiod.ToString

                    KatalogPnl.Name = "Ktlg" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString 'AChTUNG->kwd tousristikis periodou

                    SynolPnl.Name = "Synl" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString 'AChTUNG->kwd tousristikis periodou


                    TimokChk.CheckAlign = ContentAlignment.MiddleRight
                    TimokChk.Text = "Τιμοκατ."
                    TimokChk.Name = "Tmkt" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    SimfCbx.Name = "Simf" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString 'AChTUNG->kwd timis kratisis
                    XrewsCbx.Name = "Xres" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    KlnsCbx.Name = "Klns" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    Hmer1Tbx.Name = "Hme1" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    'ParoxTbx.Name = "Parx" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                End If
                EkptTbx.TabStop = False
                Hmer1Tbx.TabStop = False

                TimokChk.Height = 20
                TimokChk.Width = 90
                SimfCbx.Width = 60
                XrewsCbx.Width = 60
                KlnsCbx.Width = 185
                'ParoxTbx.Width = 60
                Hmer1Tbx.Width = 40
                EkptTbx.Width = 60

                YpnosTbx.MaxLength = 7
                PrwinTbx.MaxLength = 7
                GeumTbx.MaxLength = 7
                DeipTbx.MaxLength = 7

                EkptTbx.MaxLength = 5
                Hmer1Tbx.MaxLength = 3
                'ParoxTbx.MaxLength = 9
                'Hmer2Tbx.Name = "Hme2" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString

                If flag = 1 Then
                    EkptTbx.Name = "Ekpt" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    Imerom1Lbl.Name = "Imr1" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    Imerom2Lbl.Name = "Imr2" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    YpnosTbx.Name = "Ypno" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    PrwinTbx.Name = "Prwi" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    GeumTbx.Name = "Geum" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    DeipTbx.Name = "Dipn" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    ExtrTbx.Name = "Extr" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                    SumTbx.Name = "Summ" + Me.DbhotelDataSet.touristperiodoi(count).kwd.ToString
                Else
                    EkptTbx.Name = "Ekpt" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    Imerom1Lbl.Name = "Imr1" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    Imerom2Lbl.Name = "Imr2" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    YpnosTbx.Name = "Ypno" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    PrwinTbx.Name = "Prwi" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    GeumTbx.Name = "Geum" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    DeipTbx.Name = "Dipn" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    ExtrTbx.Name = "Extr" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                    SumTbx.Name = "Summ" + Me.DbhotelDataSet.timeskratisis(count).kwd.ToString
                End If

                ' to index deixnei tin stelle sto timokatalog DSTR to opoio parakolouthei tis times se kathe panelaki->ean uparxei timeskratisis->laden
                '(ean DEN uparxoun (index=-1) tote initial werte px touristiki periodo neas kratisis ;h touristiki periodo pou proekipse apo allagi anaxwrisis)
                If flag = 1 Then 'FLAG 1 ->  psaxnw to Eintrag stis Timeskratisis me to idio kwdiko Touristikis periodou gia na to kanw malen
                    index = get_index_timeskratisis(Me.DbhotelDataSet.touristperiodoi(count).kwd) 'ME TO INDEX KOITW GIA TAYTOPOIHSH TOURISTIKIHS PERIODOU ME TIMIKRATISIS
                Else
                    index = count
                End If

                ' otan uparxei timesktatiseis Eintrag tote eneimrwnw to timokatalog Dstruktur
                '(uparxei ka i i periptwsi pou o User paizwntas me tis IMerominies dimiourgise extra panelaki (logw allagis touristikis periodou)
                'sto opoio den antistixei eintrag apo timeskratisis->tote initial Werte

                If index <> -1 And timesCount <> 0 Then

                    timokatalog(count).kwdDB = Me.DbhotelDataSet.timeskratisis(index).kwd
                    timokatalog(count).timi = Me.DbhotelDataSet.timeskratisis(index).timi
                    timokatalog(count).xrewsi = Me.DbhotelDataSet.timeskratisis(index).xrewsi
                    timokatalog(count).xrewsiDB = Me.DbhotelDataSet.timeskratisis(index).xrewsi


                    zahl = Me.DbhotelDataSet.timeskratisis(index).ekptosi
                    timokatalog(count).ekptosi = zahl
                    timokatalog(count).ekptosiDB = zahl

                    EkptTbx.Text = zahl.ToString("F")
                    Imerom1Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).apo.Date
                    timokatalog(count).apo = Me.DbhotelDataSet.timeskratisis(index).apo.Date
                    Imerom2Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).mexri.Date
                    timokatalog(count).mexri = Me.DbhotelDataSet.timeskratisis(index).mexri.Date
                    timokatalog(count).mexriDB = Me.DbhotelDataSet.timeskratisis(index).mexri.Date

                    zahl = Me.DbhotelDataSet.timeskratisis(index).imeres
                    timokatalog(count).imeresPlirom = zahl
                    timokatalog(count).imeresPliromDB = zahl
                    Hmer1Tbx.Text = zahl.ToString("F")

                    If index = Me.DbhotelDataSet.timeskratisis.Count - 1 Then 'timesCount - 1 Then 'orelsecount = arseasons - 1
                        timokatalog(count).imeresTotal = (timokatalog(count).mexri - timokatalog(count).apo).Days
                    Else
                        timokatalog(count).imeresTotal = (timokatalog(count).mexri - timokatalog(count).apo).Days + 1
                    End If



                    'edw enimerwnw ta stsoixeia tou timokatalog Dstruktur->achtung p.x. o ypnos pairnei arxika tin timi tou db alla ean imeresPliromis<>imerestotal
                    'pairnei diamorfwmeni timi apo (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom)
                    'ypnosTemp einai i timi pou fainetai sto panel (kai alazei otan tin alazei o user)
                    zahl = Me.DbhotelDataSet.timeskratisis(index).ypnos
                    timokatalog(count).ypnosTemp = zahl
                    'sum = sum + zahl
                    If timokatalog(count).ekptosi <> 100 Then
                        timokatalog(count).ypnos = zahl * 100 / (100 - timokatalog(count).ekptosi)
                    Else
                        timokatalog(count).ypnos = zahl
                    End If

                    If timokatalog(count).imeresPlirom <> 0 AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresTotal Then ' AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresPliromDB
                        timokatalog(count).ypnos = (timokatalog(count).ypnos * (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom))
                    End If
                    YpnosTbx.Text = zahl.ToString("F")


                    zahl = Me.DbhotelDataSet.timeskratisis(index).prwino
                    timokatalog(count).prwinoTemp = zahl
                    'sum = sum + zahl
                    If timokatalog(count).ekptosi <> 0 Then
                        timokatalog(count).prwino = zahl * 100 / (100 - timokatalog(count).ekptosi)
                    Else
                        timokatalog(count).prwino = zahl
                    End If
                    If timokatalog(count).imeresPlirom <> 0 AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresTotal Then
                        timokatalog(count).prwino = (timokatalog(count).prwino * (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom))
                    End If
                    PrwinTbx.Text = zahl.ToString("F")


                    zahl = Me.DbhotelDataSet.timeskratisis(index).geuma
                    timokatalog(count).geumaTemp = zahl
                    'sum = sum + zahl
                    If timokatalog(count).ekptosi <> 0 Then
                        timokatalog(count).geuma = zahl * 100 / (100 - timokatalog(count).ekptosi)
                    Else
                        timokatalog(count).geuma = zahl
                    End If
                    If timokatalog(count).imeresPlirom <> 0 AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresTotal Then
                        timokatalog(count).geuma = (timokatalog(count).geuma * (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom))
                    End If
                    GeumTbx.Text = zahl.ToString("F")


                    zahl = Me.DbhotelDataSet.timeskratisis(index).deipno
                    timokatalog(count).deipnoTemp = zahl
                    'sum = sum + zahl
                    If timokatalog(count).ekptosi <> 0 Then
                        timokatalog(count).deipno = zahl * 100 / (100 - timokatalog(count).ekptosi)
                    Else
                        timokatalog(count).deipno = zahl
                    End If
                    If timokatalog(count).imeresPlirom <> 0 AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresTotal Then
                        timokatalog(count).deipno = (timokatalog(count).deipno * (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom))
                    End If
                    DeipTbx.Text = zahl.ToString("F")


                    zahl = Me.DbhotelDataSet.timeskratisis(index).extra

                    timokatalog(count).paroxiTemp = zahl
                    'sum = sum + zahl
                    If timokatalog(count).ekptosi <> 0 Then
                        timokatalog(count).paroxi = zahl * 100 / (100 - timokatalog(count).ekptosi)
                    Else
                        timokatalog(count).paroxi = zahl
                    End If
                    If timokatalog(count).imeresPlirom <> 0 AndAlso timokatalog(count).imeresPlirom <> timokatalog(count).imeresTotal Then
                        timokatalog(count).paroxi = (timokatalog(count).paroxi * (timokatalog(count).imeresTotal / timokatalog(count).imeresPlirom))
                    End If
                    ExtrTbx.Text = zahl.ToString("F")

                    zahl = Me.DbhotelDataSet.timeskratisis(index).synolo
                    timokatalog(count).synolo = zahl
                    timokatalog(count).synoloTemp = zahl
                    SumTbx.Text = zahl.ToString("N")
                    'DateTimePicker3_Validating()
                    'MsgBox(zahl)

                    'Edw orizw ean tha emfanizetai to info2Lbl( sto katw meros katw apo SUM timwn) me tis plirofories gia Xrewsi(RR,HB ktl) Klines, paidia
                    If timokatalog(count).timi > 0 Then
                        TimokChk.Checked = True
                        Info2Lbl.Text = info_timiskratisis_by_kwdtimis(timokatalog(count).timi)

                    ElseIf timokatalog(count).timi = -1 Then
                        TimokChk.Checked = False
                        Info2Lbl.Text = info_timiskratisis_by_xrewsi(timokatalog(count).xrewsi)

                    End If
                Else 'If isDBEintrag Then

                    zahl = 0
                    TimokChk.Checked = True
                    Hmer1Tbx.Text = zahl.ToString
                    EkptTbx.Text = zahl.ToString("F")
                    YpnosTbx.Text = zahl.ToString("F")
                    PrwinTbx.Text = zahl.ToString("F")
                    GeumTbx.Text = zahl.ToString("F")
                    DeipTbx.Text = zahl.ToString("F")
                    ExtrTbx.Text = zahl.ToString("F")
                    SumTbx.Text = zahl.ToString("F")


                End If

                EkptTbx.TextAlign = HorizontalAlignment.Right
                YpnosTbx.Width = 60
                YpnosTbx.TextAlign = HorizontalAlignment.Right
                PrwinTbx.Width = 60
                PrwinTbx.TextAlign = HorizontalAlignment.Right
                GeumTbx.Width = 60
                GeumTbx.TextAlign = HorizontalAlignment.Right
                DeipTbx.Width = 60
                DeipTbx.TextAlign = HorizontalAlignment.Right
                ExtrTbx.Width = 60
                ExtrTbx.TextAlign = HorizontalAlignment.Right
                SumTbx.Width = 80
                SumTbx.TextAlign = HorizontalAlignment.Right
                Imerom1Lbl.TextAlign = ContentAlignment.MiddleCenter
                Imerom2Lbl.TextAlign = ContentAlignment.MiddleCenter

                Imerom1Lbl.Width = 90
                Imerom2Lbl.Width = 90

                'Imerom1Tbx.Enabled = False
                'Imerom2Tbx.Enabled = False

                Imerom1Lbl.ForeColor = Color.Black
                Imerom2Lbl.ForeColor = Color.Black
                Imerom1Lbl.BackColor = Color.Azure
                Imerom2Lbl.BackColor = Color.Azure

                SumTbx.ForeColor = Color.Maroon
                If count Mod 2 <> 0 Then
                    KatalogPnl.BackColor = Color.Khaki
                Else
                    KatalogPnl.BackColor = Color.DarkKhaki
                End If

                If flag = 1 Then
                    Me.SimfoniesTableAdapter.FillByTiposSeason(Me.DbhotelDataSet.simfonies, currentsimbolaio, currenttipos, Me.DbhotelDataSet.touristperiodoi(count).season)
                Else
                    Me.SimfoniesTableAdapter.FillByTiposTouristperkwd(Me.DbhotelDataSet.simfonies, currentsimbolaio, currenttipos, Me.DbhotelDataSet.timeskratisis(index).touristperiod)
                End If
                Wait(0.1)

                If Me.DbhotelDataSet.simfonies.Count <> 0 Then
                    TimokChk.Checked = True
                    For i = 0 To Me.DbhotelDataSet.simfonies.Count - 1
                        SimfCbx.Items.Add(Me.DbhotelDataSet.simfonies(i).aa)
                    Next
                Else
                    If flag = 1 Then
                        Me.SimfoniesTableAdapter.FillByTiposSeason(Me.DbhotelDataSet.simfonies, currentsimbolaio, 0, Me.DbhotelDataSet.touristperiodoi(count).season)
                    Else
                        Me.SimfoniesTableAdapter.FillByTiposTouristperkwd(Me.DbhotelDataSet.simfonies, currentsimbolaio, 0, Me.DbhotelDataSet.timeskratisis(index).touristperiod)
                    End If

                    If Me.DbhotelDataSet.simfonies.Count <> 0 Then
                        TimokChk.Checked = True
                        currenttipos = 0
                        For i = 0 To Me.DbhotelDataSet.simfonies.Count - 1
                            SimfCbx.Items.Add(Me.DbhotelDataSet.simfonies(i).aa)
                        Next
                    Else
                        'edw alaksa-> ean DEN yparxei timokatalogos tote h xrewsi prepei na einai i idia me auti tou praktoreiou DB stous parametrous
                        TimokChk.Checked = False
                        timokatalog(count).timi = -1
                        If timokatalog(count).xrewsi = -1 Then
                            timokatalog(count).xrewsi = praktXrewsKwd
                        End If
                        TimokChk.Enabled = False
                        SimfCbx.Enabled = False
                        KlnsCbx.Enabled = False
                        For i = 0 To Me.DbhotelDataSet.xrewseis.Count - 1
                            XrewsCbx.Items.Add(Me.DbhotelDataSet.xrewseis(i).xrewsi)
                            If Me.DbhotelDataSet.xrewseis(i).kwd = timokatalog(count).xrewsi Then
                                XrewsCbx.SelectedIndex = i
                            End If
                        Next
                    End If
                End If

                'AddHandler SimfCbx.SelectedIndexChanged, AddressOf fuehle_xrewseis_cbxen
                SimfLbl.Text = "Συμφωνία:"
                SimfLbl.Width = 80
                SimfLbl.TextAlign = ContentAlignment.MiddleRight
                XrewsLbl.Text = "Χρεώσεις:"
                XrewsLbl.Width = 80
                XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                KlnsLbl.Text = "Κλίνες:"
                KlnsLbl.Width = 60
                KlnsLbl.TextAlign = ContentAlignment.MiddleRight
                'ParoxLbl.Text = "Παροχή:"
                'ParoxLbl.Width = 80
                'ParoxLbl.TextAlign = ContentAlignment.MiddleRight

                'HmeresLbl.Text = "Ημέρες:"
                HmeresLbl.TextAlign = ContentAlignment.MiddleRight
                EkptLbl.Text = "Εκπτωση(%):"
                EkptLbl.TextAlign = ContentAlignment.MiddleRight
                TimiApoLbl.Text = "Τιμή από "
                TimiApoLbl.TextAlign = ContentAlignment.MiddleRight
                'TimiApoLbl.ForeColor = Color.Maroon
                TimiApoLbl.Width = 80
                'HmrsLbl.ForeColor = Color.Maroon
                HmrsLbl.TextAlign = ContentAlignment.MiddleRight
                HmrsLbl.Width = 60
                IsonLbl.Text = "="
                IsonLbl.TextAlign = ContentAlignment.MiddleCenter
                IsonLbl.Width = 30
                InfoLbl.Text = "Ημέρες Χ [Υπνος-    Πρωϊνό-  Γεύμα-  Δείπνo-   Extra]"
                InfoLbl.Width = 400
                'InfoLbl.BackColor = Color.Azure
                Info2Lbl.Width = 300
                'Info2Lbl.BackColor = Color.Azure
                IsonLbl.ForeColor = Color.Maroon
                'SynolLbl.Text = " ΣΥΝΟΛΟ:"
                Info2Lbl.ForeColor = Color.Blue

                TimokChk.Location = New Point(1, count * stepy)

                SimfLbl.Location = New Point(5, count * stepy + 20)
                SimfCbx.Location = New Point(5 + SimfLbl.Width, count * stepy + 20)

                XrewsLbl.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width, count * stepy + 20)
                XrewsCbx.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width + XrewsLbl.Width, count * stepy + 20)

                KlnsLbl.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width + XrewsLbl.Width + XrewsCbx.Width, count * stepy + 20)
                KlnsCbx.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width + XrewsLbl.Width + XrewsCbx.Width + KlnsLbl.Width, count * stepy + 20)

                'ParoxLbl.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width + XrewsLbl.Width + XrewsCbx.Width + KlnsLbl.Width + KlnsCbx.Width, count * stepy + 20)
                'ParoxTbx.Location = New Point(5 + SimfLbl.Width + SimfCbx.Width + XrewsLbl.Width + XrewsCbx.Width + KlnsLbl.Width + KlnsCbx.Width + ParoxLbl.Width, count * stepy + 20)

                'Ypologismos Hmeres/apoHmeres gia Ekptosi!
                If count = 0 Then
                    If count = arseasons - 1 Then
                        'Hmer1Tbx.Text = (DateTimePicker3.Value - DateTimePicker2.Value).Days.ToString
                        imeresTotal = (DateTimePicker3.Value.Date - DateTimePicker2.Value.Date).Days.ToString
                        HmrsLbl.Text = imeresTotal.ToString + " X "
                        Imerom1Lbl.Text = DateTimePicker2.Value.Date
                        Imerom2Lbl.Text = DateTimePicker3.Value.Date
                    Else
                        'Hmer1Tbx.Text = (Me.DbhotelDataSet.touristperiodoi(count).mexri - DateTimePicker2.Value).Days.ToString
                        If flag = 1 Then
                            imeresTotal = (Me.DbhotelDataSet.touristperiodoi(count).mexri - DateTimePicker2.Value.Date).Days.ToString + 1
                        Else
                            imeresTotal = (Me.DbhotelDataSet.timeskratisis(index).mexri - DateTimePicker2.Value.Date).Days.ToString + 1
                        End If

                        HmrsLbl.Text = imeresTotal.ToString + " X "
                        Imerom1Lbl.Text = DateTimePicker2.Value.Date
                        If flag = 1 Then
                            Imerom2Lbl.Text = Me.DbhotelDataSet.touristperiodoi(count).mexri.Date
                        Else
                            Imerom2Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).mexri.Date
                        End If


                    End If
                Else
                    If count = arseasons - 1 Then
                        'Hmer1Tbx.Text = (DateTimePicker3.Value - Me.DbhotelDataSet.touristperiodoi(count).apo).Days.ToString
                        If flag = 1 Then
                            imeresTotal = (DateTimePicker3.Value - Me.DbhotelDataSet.touristperiodoi(count).apo).Days.ToString
                        Else
                            imeresTotal = (DateTimePicker3.Value - Me.DbhotelDataSet.timeskratisis(index).apo).Days.ToString
                        End If

                        'HmrsLbl.Text = Hmer1Tbx.Text + " X "
                        HmrsLbl.Text = imeresTotal.ToString + " X "
                        If flag = 1 Then
                            Imerom1Lbl.Text = Me.DbhotelDataSet.touristperiodoi(count).apo.Date
                        Else
                            Imerom1Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).apo.Date
                        End If
                        Imerom2Lbl.Text = DateTimePicker3.Value.Date
                    Else
                        'Hmer1Tbx.Text = (Me.DbhotelDataSet.touristperiodoi(count).mexri - Me.DbhotelDataSet.touristperiodoi(count).apo).Days.ToString
                        If flag = 1 Then
                            imeresTotal = (Me.DbhotelDataSet.touristperiodoi(count).mexri - Me.DbhotelDataSet.touristperiodoi(count).apo).Days.ToString + 1
                            Imerom1Lbl.Text = Me.DbhotelDataSet.touristperiodoi(count).apo.Date
                            Imerom2Lbl.Text = Me.DbhotelDataSet.touristperiodoi(count).mexri.Date
                        Else
                            imeresTotal = (Me.DbhotelDataSet.timeskratisis(index).mexri - Me.DbhotelDataSet.timeskratisis(index).apo).Days.ToString + 1
                            Imerom1Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).apo.Date
                            Imerom2Lbl.Text = Me.DbhotelDataSet.timeskratisis(index).mexri.Date
                        End If
                        HmrsLbl.Text = imeresTotal.ToString + " X "
                    End If
                End If


                'edw upologizw tis imerespliromis ->apo timeskratisis DB (imeres Attribute) ;h ean o User eixei paiksei me tis imerominies 
                'afixis- anaxwrisis tote timi apo imestotal pou exei upologisthei apo panw!
                If timesCount - count > 0 Then ' panelakia me antistixia se timeskratisis eintrag
                    If index <> -1 Then
                        If timokatalog(count).apo = CType(Imerom1Lbl.Text, Date) And timokatalog(count).mexriDB = CType(Imerom2Lbl.Text, Date) Then 'den exei alaksei i Afixi
                            If count = arseasons - 1 Then ' TELEUTAIO PANEL->EXEI NA KANEI ME TON ARIUTMO HMERWN (->-1 LOGW ANAXWRISHS)
                                If index <> Me.DbhotelDataSet.timeskratisis.Count - 1 Then 'DEN EINAI TO TELEUTAIO EINTRAG APO TIMESKRATISEIS
                                    Hmer1Tbx.Text = Me.DbhotelDataSet.timeskratisis(index).imeres - 1 '->IMERES APO DB -1
                                    timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                                Else 'TELEUTAIO EINTRAG APO TIMESKRATISEIS->OK IMERES TAYTIZWNTAI
                                    Hmer1Tbx.Text = Me.DbhotelDataSet.timeskratisis(index).imeres
                                    timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                                End If
                            Else 'DEN EINAI TO TELEUTAIO PANEL
                                If index <> Me.DbhotelDataSet.timeskratisis.Count - 1 Then 'DEN EINAI TO TELEUTAIO EINTRAG APO TIMESKRATISEIS
                                    Hmer1Tbx.Text = Me.DbhotelDataSet.timeskratisis(index).imeres
                                    timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                                Else 'EINAI TO TELEUTAIO EINTRAG APO TIMESKRATISEIS
                                    Hmer1Tbx.Text = Me.DbhotelDataSet.timeskratisis(index).imeres + 1
                                    timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                                End If
                            End If
                        Else
                            Hmer1Tbx.Text = imeresTotal
                            timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                        End If
                    Else
                        Hmer1Tbx.Text = imeresTotal
                        timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                    End If
                Else ' panelakia XWRIS antistixia se timeskratisis eintrag-> o user feripin exei paratinei tin anaxwrisi toso wste na alaksei touristiki periodo!
                    Hmer1Tbx.Text = imeresTotal
                    timokatalog(count).imeresPlirom = Hmer1Tbx.Text
                End If
                timokatalog(count).imeresTotal = imeresTotal
                timokatalog(count).apo = Imerom1Lbl.Text
                timokatalog(count).mexri = Imerom2Lbl.Text

                HmeresLbl.Text = "Ημέρες " + imeresTotal.ToString + "/"

                TimiApoLbl.Location = New Point(5, count * stepy + 2 * EkptTbx.Height + 10) '10 + SimfLbl.Height 
                Imerom1Lbl.Location = New Point(5 + TimiApoLbl.Width, count * stepy + 2 * EkptTbx.Height + 10)
                Imerom2Lbl.Location = New Point(10 + TimiApoLbl.Width + Imerom1Lbl.Width, count * stepy + 2 * EkptTbx.Height + 10)
                HmeresLbl.Location = New Point(5 + TimiApoLbl.Width + Imerom1Lbl.Width + Imerom2Lbl.Width, count * stepy + 2 * EkptTbx.Height + 10)
                Hmer1Tbx.Location = New Point(5 + TimiApoLbl.Width + Imerom1Lbl.Width + Imerom2Lbl.Width + HmeresLbl.Width, count * stepy + 2 * EkptTbx.Height + 10)
                EkptLbl.Location = New Point(5 + TimiApoLbl.Width + Imerom1Lbl.Width + Imerom2Lbl.Width + HmeresLbl.Width + Hmer1Tbx.Width, count * stepy + 2 * EkptTbx.Height + 10)
                EkptTbx.Location = New Point(5 + TimiApoLbl.Width + Imerom1Lbl.Width + Imerom2Lbl.Width + HmeresLbl.Width + Hmer1Tbx.Width + EkptLbl.Width, count * stepy + 2 * EkptTbx.Height + 10)

                HmrsLbl.Location = New Point(55, count * stepy + 4 * EkptTbx.Height)
                YpnosTbx.Location = New Point(55 + YpnosTbx.Width, count * stepy + 4 * EkptTbx.Height)
                PrwinTbx.Location = New Point(55 + YpnosTbx.Width + YpnosTbx.Width, count * stepy + 4 * EkptTbx.Height)
                GeumTbx.Location = New Point(55 + YpnosTbx.Width + 2 * YpnosTbx.Width, count * stepy + 4 * EkptTbx.Height)
                DeipTbx.Location = New Point(55 + YpnosTbx.Width + 3 * YpnosTbx.Width, count * stepy + 4 * EkptTbx.Height)
                ExtrTbx.Location = New Point(55 + YpnosTbx.Width + 4 * YpnosTbx.Width, count * stepy + 4 * EkptTbx.Height)
                IsonLbl.Location = New Point(55 + YpnosTbx.Width + 4 * YpnosTbx.Width + 2 * IsonLbl.Width, count * stepy + 4 * EkptTbx.Height)
                SumTbx.Location = New Point(55 + YpnosTbx.Width + 4 * YpnosTbx.Width + 3 * IsonLbl.Width, count * stepy + 4 * EkptTbx.Height)

                InfoLbl.Location = New Point(35, count * stepy + 5 * EkptTbx.Height + 3)
                Info2Lbl.Location = New Point(35 + InfoLbl.Width, count * stepy + 5 * EkptTbx.Height + 3)

                KatalogPnl.Size = New Point(Kratiseis4Pnl.Width - 30, 120)
                KatalogPnl.Location = New Point(3, count * (80 + 20 + SimfLbl.Height))


                AddHandler TimokChk.CheckedChanged, AddressOf timok_chk_changed
                AddHandler SimfCbx.SelectedIndexChanged, AddressOf simfon_cboxen_index
                AddHandler XrewsCbx.SelectedIndexChanged, AddressOf xrews_cboxen_index
                AddHandler KlnsCbx.SelectedIndexChanged, AddressOf klins_cboxen_index
                AddHandler ExtrTbx.Leave, AddressOf txtboxen_leave
                AddHandler ExtrTbx.Click, AddressOf TextBox_SelectAllText
                AddHandler YpnosTbx.Leave, AddressOf txtboxen_leave
                AddHandler YpnosTbx.Click, AddressOf TextBox_SelectAllText
                AddHandler PrwinTbx.Leave, AddressOf txtboxen_leave
                AddHandler PrwinTbx.Click, AddressOf TextBox_SelectAllText
                AddHandler GeumTbx.Leave, AddressOf txtboxen_leave
                AddHandler GeumTbx.Click, AddressOf TextBox_SelectAllText
                AddHandler DeipTbx.Leave, AddressOf txtboxen_leave
                AddHandler DeipTbx.Click, AddressOf TextBox_SelectAllText
                AddHandler SumTbx.Leave, AddressOf txtboxen_leave
                AddHandler EkptTbx.Leave, AddressOf ekptbox_leave
                AddHandler Hmer1Tbx.Leave, AddressOf imeres_leave

                KatalogPnl.Controls.Add(TimokChk)
                KatalogPnl.Controls.Add(SimfLbl)
                KatalogPnl.Controls.Add(SimfCbx)
                KatalogPnl.Controls.Add(XrewsLbl)
                KatalogPnl.Controls.Add(XrewsCbx)
                KatalogPnl.Controls.Add(KlnsLbl)
                KatalogPnl.Controls.Add(KlnsCbx)
                'KatalogPnl.Controls.Add(ParoxLbl)
                'KatalogPnl.Controls.Add(ParoxTbx)
                KatalogPnl.Controls.Add(HmeresLbl)
                KatalogPnl.Controls.Add(Hmer1Tbx)
                'KatalogPnl.Controls.Add(Hmer2Tbx)
                KatalogPnl.Controls.Add(EkptLbl)
                KatalogPnl.Controls.Add(EkptTbx)
                KatalogPnl.Controls.Add(TimiApoLbl)
                KatalogPnl.Controls.Add(Imerom1Lbl)
                KatalogPnl.Controls.Add(Imerom2Lbl)
                KatalogPnl.Controls.Add(HmrsLbl)
                KatalogPnl.Controls.Add(YpnosTbx)
                KatalogPnl.Controls.Add(PrwinTbx)
                KatalogPnl.Controls.Add(GeumTbx)
                KatalogPnl.Controls.Add(DeipTbx)
                KatalogPnl.Controls.Add(ExtrTbx)
                KatalogPnl.Controls.Add(InfoLbl)
                KatalogPnl.Controls.Add(Info2Lbl)
                KatalogPnl.Controls.Add(IsonLbl)
                KatalogPnl.Controls.Add(SumTbx)

                Kratiseis4Pnl.Controls.Add(KatalogPnl)

            Next
            'SynolPnl.Location = New Point(Kratiseis4Pnl.Location.X + Kratiseis4Pnl.Width - SynolPnl.Width, Kratiseis4Pnl.Location.Y + Kratiseis4Pnl.Height + 5)
            'SynolPnl.Location = New Point(5, 616) 'Kratiseis1Pnl.Location.Y + Kratiseis1Pnl.Height + Kratiseis3Pnl.Height + 55 + Kratiseis4Pnl.Height
            'KleisimoZentralPnl.Controls.Add(SynolPnl)
        End If

        Dim DeleteButton As New Button
        DeleteButton.BackColor = Color.Azure
        DeleteButton.ForeColor = Color.Maroon
        DeleteButton.Text = "Διαγραφή"
        DeleteButton.Size = New Point(140, 30)
        DeleteButton.Cursor = Cursors.Hand
        DeleteButton.Location = New Point(SynolPnl.Width / 2 + 150, 20)
        'DeleteButton.Location = New Point(SynolPnl.Width / 2 - 50, Kratiseis4Pnl.Location.Y + Kratiseis4Pnl.Height + 60)

        AddHandler DeleteButton.Click, AddressOf delete_kratisi
        Dim AfixiButton As New Button
        AfixiButton.Name = "Afixi"
        AfixiButton.BackColor = Color.Azure
        AfixiButton.ForeColor = Color.Green
        AfixiButton.Text = "Άφιξη"
        AfixiButton.Size = New Point(140, 30)
        AfixiButton.Cursor = Cursors.Hand
        AfixiButton.Location = New Point(SynolPnl.Width / 2 - 300, 20)

        If imeromErgasias <> DateTimePicker2.Value.Date Then
            AfixiButton.Enabled = False
        End If
        Dim OverButton As New Button
        OverButton.Name = "Over"
        OverButton.BackColor = Color.Azure
        OverButton.ForeColor = Color.Green
        OverButton.Text = "OV-BOOK"
        OverButton.Size = New Point(140, 30)
        OverButton.Cursor = Cursors.Hand
        OverButton.Location = New Point(SynolPnl.Width / 2 - 0, 20)

        'If imeromErgasias <> DateTimePicker2.Value.Date Then
        '    OverButton.Enabled = False
        'End If
        Dim NonShowButton As New Button
        NonShowButton.BackColor = Color.Azure
        NonShowButton.ForeColor = Color.Maroon
        NonShowButton.Text = "Non show"
        NonShowButton.Name = "nshow"
        NonShowButton.Size = New Point(140, 30)
        NonShowButton.Cursor = Cursors.Hand
        NonShowButton.Location = New Point(SynolPnl.Width / 2 - 150, 20)


        AddHandler NonShowButton.Click, AddressOf non_show_kratisi
        NonShowLbl.Text = ""
        AddHandler OverButton.Click, AddressOf timokat_speichern
        AddHandler AfixiButton.Click, AddressOf timokat_speichern

        ButtonsPnl.Location = New Point(5, 675) 'Kratiseis1Pnl.Location.Y + Kratiseis1Pnl.Height + Kratiseis3Pnl.Height + 55 + Kratiseis4Pnl.Height + SynolPnl.Height
        ButtonsPnl.Size = New Point(SynolPnl.Width, 80)
        'ButtonsPnl.Location = New Point(5, SynolPnl.Location.Y + SynolPnl.Height)

        ButtonsPnl.Controls.Add(AfixiButton)
        ButtonsPnl.Controls.Add(NonShowButton)
        ButtonsPnl.Controls.Add(OverButton)
        ButtonsPnl.Controls.Add(DeleteButton)

        KleisimoZentralPnl.Controls.Add(ButtonsPnl)

    End Sub
    'ean checked tote to timi attribute stin DB timeskratisis den einai -1 => mporw na antlisw plirofories apo to times Table
    ' gia xrewsi (RR,HB ktl) klines, paidia (->oi plirofories emfanizontai sto Info2Lbl ssto katw meros)
    Private Sub timok_chk_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB As Integer
        Dim index, i As Int16
        Dim pnl(), find() As Object

        If flagKr = 1 Then ' ena panelaki touristikis periodou tote to name tou emperiexei tin touristiki periodo kwd
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else 'panelaki me timeskratisis->to name emperiexei ton kwd tis DB timeskratisis->apo auto kanw identifizieren mesw tou .kwdDB
            'tou Pio index tou timokatalog Dstr ist angesprochen
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If
        'tourist = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
        'index = get_index_v_timokatalog(tourist)
        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        If sender.checked = True Then
            Try
                find = pnl(0).Controls.Find("Simf" + kwdDB.ToString, False)
                find(0).enabled = True
                If find(0).items.count > 0 Then
                    Try
                        find(0).SelectedIndex = -1
                    Catch ex As InvalidOperationException
                    End Try
                End If
                find = pnl(0).Controls.Find("Xres" + kwdDB.ToString, False)
                If find(0).items.count > 0 Then
                    Try
                        find(0).SelectedIndex = -1
                    Catch ex As Exception
                    End Try
                End If
                find(0).items.clear()
                find = pnl(0).Controls.Find("Klns" + kwdDB.ToString, False)
                If find(0).items.count > 0 Then
                    Try
                        find(0).SelectedIndex = -1
                    Catch ex As Exception
                    End Try
                End If
                'find(0).selectedindex = -1
                find(0).items.clear()
                find(0).enabled = True
                timokatalog(index).timi = Me.DbhotelDataSet.times(0).kwd
            Catch ex As IndexOutOfRangeException
                timokatalog(index).timi = -1
            End Try
        Else
            find = pnl(0).Controls.Find("Simf" + kwdDB.ToString, False)
            find(0).enabled = False
            find = pnl(0).Controls.Find("Xres" + kwdDB.ToString, False)
            find(0).items.clear()
            For i = 0 To Me.DbhotelDataSet.xrewseis.Count - 1
                find(0).Items.Add(Me.DbhotelDataSet.xrewseis(i).xrewsi)
            Next
            find = pnl(0).Controls.Find("Klns" + kwdDB.ToString, False)

            find(0).enabled = False
            timokatalog(index).timi = -1
        End If
    End Sub

    'kathe timokatalogos (PANEL) einai identifizierbar apo kwd toyristperiodou (kai oxi apo season->giati tha mporousame na eixame 
    'epanalambnaomenes xrewseis)-> mesa ston katalogo to xrewseisCBX mporei na einai identifierbar me kwd season (OXI omws oi simfoniesCBX)
    Private Sub simfon_cboxen_index(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB, season, simfonia As Integer
        Dim pnl(), find() As Object
        Dim i, index As Int16

        kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)

        If flagKr = 1 Then
            index = get_index_v_timokatalog(kwdDB)
        Else
            index = get_index_v_timokatalog_2(kwdDB)
        End If
        'kwd touristikis periodou->kathe timokatologos exei diaforetiko
        'tourist = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
        ''pios timokatalogos stin DSTR ?
        'index = get_index_v_timokatalog(tourist)

        'kwd season tou timokatalogou
        season = Me.TouristperiodoiTableAdapter.GetSeasonByKwd(timokatalog(index).tourist)
        'kwd simfonias tou timokatoalogou
        simfonia = (Me.SimfoniesTableAdapter.GetKwdBySimbolaioAaTiposSeason(currentsimbolaio, sender.selecteditem, currenttipos, season))
        'MsgBox(simfonia)
        'simfonia stin DSTR spechern
        timokatalog(index).simfonia = simfonia
        'rauskriegen olwn twn xrewsewn apo table times by simfonia kwd  
        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)

        Me.TimesTableAdapter.GetXrewseisBySimfonia(Me.DbhotelDataSet.times, simfonia)
        find = pnl(0).Controls.Find("Xres" + kwdDB.ToString, False)
        'gemise to xrewseis Cbox

        find(0).items.clear()


        For i = 0 To Me.DbhotelDataSet.times.Count - 1
            find(0).Items.Add(get_xrewsi_by_kwd(Me.DbhotelDataSet.times(i).xrewsi))
            'find(0).selectedIndex = 0
        Next
        If Me.DbhotelDataSet.times.Count > 0 Then
            find(0).selectedIndex = 0
        Else
            find(0).selectedIndex = -1
        End If


        'rauskriegen to xrewseisCbox  gia ton antistoixo timokatalogo (->identifizierbar me tousristKwd)

    End Sub
    Private Sub xrews_cboxen_index(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB, xrewsi As Integer
        Dim pnl(), find() As Object
        Dim i, index As Int16
        Dim str As String

        If flagKr = 1 Then
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else 'panelaki me timeskratisis->to name emperiexei ton kwd tis DB timeskratisis->apo auto kanw identifizieren mesw tou .kwdDB
            'tou Pio index tou timokatalog Dstr ist angesprochen
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If
        'kwd touristikis periodou->kathe timokatologos exei diaforetiko
        'tourist = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
        'index = get_index_v_timokatalog(tourist)
        'kwd season tou timokatalogou
        'Try
        xrewsi = Me.XrewseisTableAdapter.GetKwdByXrewsi(sender.selectedItem)
        'Catch ex As Exception

        'End Try

        timokatalog(index).xrewsi = xrewsi

        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)

        find = pnl(0).Controls.Find("Klns" + kwdDB.ToString, False)
        find(0).items.clear()

        Me.TimesTableAdapter.FillOrderByKlines(Me.DbhotelDataSet.times, timokatalog(index).simfonia, xrewsi)

        For i = 0 To Me.DbhotelDataSet.times.Count - 1
            str = Me.DbhotelDataSet.times(i).klines.ToString + " Κλιν./" + Me.DbhotelDataSet.times(i).paidi.ToString + " Παιδ.(" + Me.DbhotelDataSet.times(i).atoma.ToString + " Ατομ.)"
            find(0).Items.Add(str)
        Next
        If Me.DbhotelDataSet.times.Count > 0 Then
            find(0).selectedIndex = 0
        Else
            find(0).selectedIndex = -1
        End If

    End Sub
    Private Sub klins_cboxen_index(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB As Integer
        Dim klns, paid, atom, ilikiaPaid As Int16
        Dim index As Int16
        Dim split1 As String() = sender.selecteditem.ToString.Split(New [Char]() {"/"c})
        'Dim split2 As String = split1(1).Split(New [Char]() {"("c})
        If flagKr = 1 Then
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If
        'tourist = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
        'index = get_index_v_timokatalog(tourist)
        klns = CType(split1(0).Substring(0, split1(0).Length - 6).ToString, Int16)
        Dim split2 As String() = split1(1).ToString.Split(New [Char]() {"("c})
        paid = CType(split2(0).Substring(0, split2(0).Length - 6).ToString.Trim, Int16)
        atom = CType(split2(1).Substring(0, split2(1).Length - 7).ToString.Trim, Int16)
        'MsgBox(timokatalog(index).simfonia)
        'MsgBox(timokatalog(index).xrewsi)
        Try
            If klns = 1 Then
                If Not Me.PaidiTbx1.Text.Equals("") Then
                    ilikiaPaid = Me.SimfoniesTableAdapter.GetIlikiaPaidMonoklino(timokatalog(index).simfonia)
                    If ilikiaPaid <> 0 AndAlso ilikiaPaid < Me.PaidiTbx1.Text Then
                        MsgBox("Ηλικία Παιδιού μεγαλύτερη απο αυτήν στην συμφωνία !", MsgBoxStyle.Information, "winfo\nikEl.")
                    End If
                End If
            ElseIf klns = 2 Then
                If Not Me.PaidiTbx1.Text.Equals("") Then
                    ilikiaPaid = Me.SimfoniesTableAdapter.GetIlikiaPaidDiklino(timokatalog(index).simfonia)
                    If ilikiaPaid <> 0 AndAlso ilikiaPaid < Me.PaidiTbx1.Text Then
                        MsgBox("Ηλικία Παιδιού μεγαλύτερη απο αυτήν στην συμφωνία !", MsgBoxStyle.Information, "winfo\nikEl.")
                    End If
                End If
            Else
                If Not Me.PaidiTbx1.Text.Equals("") AndAlso Not Me.PaidiTbx1.Text.Equals("") Then
                    ilikiaPaid = Me.SimfoniesTableAdapter.GetIlikiaPrwtoPaidiapoDuo(timokatalog(index).simfonia)
                    If ilikiaPaid <> 0 AndAlso ilikiaPaid < Me.PaidiTbx1.Text Then
                        MsgBox("Ηλικία 1ου Παιδιού μεγαλύτερη απο αυτήν στην συμφωνία !", MsgBoxStyle.Information, "winfo\nikEl.")
                    End If
                    ilikiaPaid = Me.SimfoniesTableAdapter.GetIlikiaDeuteroPaidiapoDuo(timokatalog(index).simfonia)
                    If ilikiaPaid <> 0 AndAlso ilikiaPaid < Me.PaidiTbx2.Text Then
                        MsgBox("Ηλικία 2ου Παιδιού μεγαλύτερη απο αυτήν στην συμφωνία !", MsgBoxStyle.Information, "winfo\nikEl.")
                    End If

                End If

            End If
        Catch ex As InvalidOperationException

        End Try
        Me.TimesTableAdapter.FillBySimfXrewsPaidAtom(Me.DbhotelDataSet.times, timokatalog(index).simfonia, timokatalog(index).xrewsi, klns, atom, paid)
        'MsgBox(Me.DbhotelDataSet.times.Count)
        timokatalog(index).timi = Me.DbhotelDataSet.times(0).kwd
        timokatalog(index).ypnos = Me.DbhotelDataSet.times(0).ipnos
        timokatalog(index).prwino = Me.DbhotelDataSet.times(0).prwino
        timokatalog(index).geuma = Me.DbhotelDataSet.times(0).geuma
        timokatalog(index).deipno = Me.DbhotelDataSet.times(0).deipno
        timokatalog(index).paroxi = 0

        setze_times_anal(kwdDB, index)
    End Sub

    Private Sub setze_times_anal(ByVal kwdDB As Integer, ByVal indx As Int16)
        Dim pnl(), find() As Object
        Dim zahl, zahlai, zahlextr, sum As Single ', dedoulPoso

        sum = 0
        zahl = 0
        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)

        find = pnl(0).Controls.Find("Ypno" + kwdDB.ToString, False)
        zahl = timokatalog(indx).ypnos * (1 - timokatalog(indx).ekptosi / 100) * (timokatalog(indx).imeresPlirom / timokatalog(indx).imeresTotal)

        If timokatalog(indx).xrewsi = 6 AndAlso timokatalog(indx).paroxi = 0 AndAlso timokatalog(indx).deipno = 0 AndAlso timokatalog(indx).geuma = 0 AndAlso timokatalog(indx).prwino = 0 Then
            zahlai = (zahl * (100 - Me.DbhotelDataSet.etaireia(0).extras) / 100).ToString("F")
            zahlextr = zahl - zahlai
            find(0).text = zahlai.ToString("F")
            timokatalog(indx).ypnos = zahlai.ToString("F")
            timokatalog(indx).ypnosTemp = zahlai.ToString("F")
            sum = sum + zahlai.ToString("F")
            timokatalog(indx).paroxi = zahlextr.ToString("F")
            timokatalog(indx).paroxiTemp = zahlextr.ToString("F")
        Else
            find(0).text = zahl.ToString("F")
            timokatalog(indx).ypnosTemp = zahl.ToString("F")
            sum = sum + zahl.ToString("F")
        End If



        find = pnl(0).Controls.Find("Prwi" + kwdDB.ToString, False)

        zahl = timokatalog(indx).prwino * (1 - timokatalog(indx).ekptosi / 100) * (timokatalog(indx).imeresPlirom / timokatalog(indx).imeresTotal)

        find(0).text = zahl.ToString("F")
        timokatalog(indx).prwinoTemp = zahl.ToString("F")
        sum = sum + zahl.ToString("F")

        find = pnl(0).Controls.Find("Geum" + kwdDB.ToString, False)
        'If (timokatalog(indx).mexriDB <> timokatalog(indx).mexri) Then
        '    zahl = 0
        'Else
        zahl = timokatalog(indx).geuma * (1 - timokatalog(indx).ekptosi / 100) * (timokatalog(indx).imeresPlirom / timokatalog(indx).imeresTotal)
        'End If
        find(0).text = zahl.ToString("F")
        timokatalog(indx).geumaTemp = zahl.ToString("F")
        sum = sum + zahl.ToString("F")

        find = pnl(0).Controls.Find("Dipn" + kwdDB.ToString, False)
        'If (timokatalog(indx).mexriDB <> timokatalog(indx).mexri) Then
        '    zahl = 0
        'Else
        zahl = timokatalog(indx).deipno * (1 - timokatalog(indx).ekptosi / 100) * (timokatalog(indx).imeresPlirom / timokatalog(indx).imeresTotal)
        'End If
        find(0).text = zahl.ToString("F")
        timokatalog(indx).deipnoTemp = zahl.ToString("F")
        sum = sum + zahl.ToString("F")

        find = pnl(0).Controls.Find("Extr" + kwdDB.ToString, False)
        'If (timokatalog(indx).mexriDB <> timokatalog(indx).mexri) Then
        '    zahl = 0
        'Else
        zahl = timokatalog(indx).paroxi * (1 - timokatalog(indx).ekptosi / 100) * (timokatalog(indx).imeresPlirom / timokatalog(indx).imeresTotal)
        'End If

        find(0).text = zahl.ToString("F")
        timokatalog(indx).paroxiTemp = zahl.ToString("F")
        sum = sum + zahl.ToString("F")

        'If status = 2 Then ' se peptosi pou alaxthei stous diamenwntes
        '    If timokatalog(indx).apo < imeromErgasias AndAlso timokatalog(indx).mexri >= imeromErgasias Then ' meta tin imerominia afixis->simainei oti uparxei sto biblio portas Eintrag me times
        '        If timokatalog(indx).ypnosDB <> timokatalog(indx).ypnosTemp Or timokatalog(indx).prwinoDB <> timokatalog(indx).prwinoTemp Or timokatalog(indx).deipnoDB <> timokatalog(indx).deipnoTemp Or timokatalog(indx).geumaDB <> timokatalog(indx).geumaTemp Or timokatalog(indx).paroxiDB <> timokatalog(indx).paroxiTemp Then
        '            dedoulDays = imeromErgasias.DayOfYear - timokatalog(indx).apo.DayOfYear
        '            restDays = timokatalog(indx).imeresTotal - dedoulDays
        '        End If
        '    End If
        'End If
        zahl = timokatalog(indx).imeresTotal * sum
        'If status = 1 Then
        '    zahl = timokatalog(indx).imeresTotal * sum
        'Else ' stous diamenwntes meta tin afixi (imerominia)
        '    If restDays = 0 Then
        '        zahl = timokatalog(indx).imeresTotal * sum
        '        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        '        find = pnl(0).Controls.Find("Dedo", False)
        '        find(0).visible = False
        '        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        '        find = pnl(0).Controls.Find("DedP", False)
        '        find(0).text = dedoulPoso.ToString("N")
        '        find(0).visible = False
        '    Else
        '        zahl = restDays * sum
        '        dedoulPoso = dedoulDays * (timokatalog(indx).ypnosDB + timokatalog(indx).prwinoDB + timokatalog(indx).geumaDB + timokatalog(indx).deipnoDB + timokatalog(indx).paroxiDB)
        '        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        '        find = pnl(0).Controls.Find("Dedo", False)
        '        find(0).visible = True
        '        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        '        find = pnl(0).Controls.Find("DedP", False)
        '        find(0).text = dedoulPoso.ToString("N")
        '        find(0).visible = True
        '    End If
        'End If
        find = pnl(0).Controls.Find("Summ" + kwdDB.ToString, False)
        timokatalog(indx).synoloTemp = zahl '+ dedoulPoso
        find(0).text = zahl.ToString("N")
        setze_sum_timokat()
    End Sub
    Private Sub txtboxen_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB As Integer
        Dim index As Int16 ', dedoulDays 
        Dim zahl, zahl1, sum As Single ', dedoulPoso
        Dim pnl(), find() As Object

        sum = 0
        If flagKr = 1 Then 'prokeitai gia  panelaki xwris antistoixo eintrag stis timeskratiseis DB Table
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else 'panelaki me timeskratisis->to name emperiexei ton kwd tis DB timeskratisis->apo auto kanw identifizieren mesw tou .kwdDB
            'tou Pio index tou timokatalog Dstr ist angesprochen
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If

        Try
            zahl = Math.Abs(CType(sender.text, Single))
            sender.text = zahl.ToString("F")
        Catch ex As InvalidCastException
            zahl = 0
            sender.text = zahl.ToString("F")
        End Try

        If sender.name.Equals("Ypno" + kwdDB.ToString) Then

            If sender.text <> timokatalog(index).ypnosTemp.ToString Then
                If timokatalog(index).xrewsi = 6 Then ' Ean einai xrewsi All Inclusiv!!!!!!!!!!!!!
                    pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
                    find = pnl(0).Controls.Find("Extr" + kwdDB.ToString, False)
                    If sender.text <> timokatalog(index).ypnosTemp.ToString AndAlso find(0).text = 0 AndAlso timokatalog(index).deipno = 0 AndAlso timokatalog(index).geuma = 0 AndAlso timokatalog(index).prwino = 0 Then
                        zahl1 = (zahl * (100 - Me.DbhotelDataSet.etaireia(0).extras) / 100).ToString("F")
                        sender.text = zahl1.ToString("F")
                        timokatalog(index).ypnosTemp = sender.text
                        find(0).text = (zahl - zahl1).ToString("F")
                        timokatalog(index).paroxiTemp = find(0).text
                        If timokatalog(index).paroxi = 0 Then
                            timokatalog(index).paroxi = timokatalog(index).paroxiTemp
                        End If
                    Else
                        timokatalog(index).ypnosTemp = sender.text
                    End If
                Else
                    timokatalog(index).ypnosTemp = sender.text
                End If
            End If
            If timokatalog(index).ypnos = 0 Then
                timokatalog(index).ypnos = timokatalog(index).ypnosTemp
            End If

        ElseIf sender.name.Equals("Prwi" + kwdDB.ToString) Then
            If sender.text <> timokatalog(index).prwinoTemp.ToString Then
                timokatalog(index).prwinoTemp = sender.text
            End If
            If timokatalog(index).prwino = 0 Then
                timokatalog(index).prwino = timokatalog(index).prwinoTemp
            End If
        ElseIf sender.name.Equals("Geum" + kwdDB.ToString) Then
            If sender.text <> timokatalog(index).geumaTemp.ToString Then
                timokatalog(index).geumaTemp = sender.text
            End If
            If timokatalog(index).geuma = 0 Then
                timokatalog(index).geuma = timokatalog(index).geumaTemp
            End If
        ElseIf sender.name.Equals("Dipn" + kwdDB.ToString) Then
            If sender.text <> timokatalog(index).deipnoTemp.ToString Then
                timokatalog(index).deipnoTemp = sender.text
            End If
            If timokatalog(index).deipno = 0 Then
                timokatalog(index).deipno = timokatalog(index).deipnoTemp
            End If
        ElseIf sender.name.Equals("Extr" + kwdDB.ToString) Then
            If sender.text <> timokatalog(index).paroxiTemp.ToString Then
                timokatalog(index).paroxiTemp = sender.text
            End If
            If timokatalog(index).paroxi = 0 Then
                timokatalog(index).paroxi = timokatalog(index).paroxiTemp
            End If
        End If

        'sum = timokatalog(index).imeresTotal * (timokatalog(index).ypnosTemp + timokatalog(index).prwinoTemp + timokatalog(index).geumaTemp + timokatalog(index).deipnoTemp + timokatalog(index).paroxiTemp) * timokatalog(index).imeresPlirom / timokatalog(index).imeresTotal * (1 - timokatalog(index).ekptosi / 100)

        sum = timokatalog(index).imeresTotal * (timokatalog(index).ypnosTemp + timokatalog(index).prwinoTemp + timokatalog(index).geumaTemp + timokatalog(index).deipnoTemp + timokatalog(index).paroxiTemp)

        pnl = Kratiseis4Pnl.Controls.Find("Ktlg" + kwdDB.ToString, False)
        find = pnl(0).Controls.Find("Summ" + kwdDB.ToString, False)
        find(0).text = sum.ToString("N")
        timokatalog(index).synoloTemp = sum ' + dedoulPoso
        setze_sum_timokat()
    End Sub
    Private Sub ekptbox_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB As Integer
        Dim index As Int16
        Dim zahl As Single

        Try
            zahl = Math.Abs(CType(sender.text, Single)).ToString("F")
            If zahl > 100 Then
                zahl = 100
            End If
            sender.text = zahl.ToString("F")
        Catch ex As InvalidCastException
            zahl = 0
            sender.text = zahl.ToString("F")
        End Try
        If flagKr = 1 Then
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If


        If sender.text <> timokatalog(index).ekptosi Then
            timokatalog(index).ekptosi = sender.text

            setze_times_anal(kwdDB, index)

        End If

    End Sub
    Private Sub imeres_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdDB As Integer
        Dim index As Int16
        Dim zahl As Int16

        If flagKr = 1 Then
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog(kwdDB)
        Else
            kwdDB = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
            index = get_index_v_timokatalog_2(kwdDB)
        End If

        Try
            zahl = Math.Abs(CType(sender.text, Int16)).ToString("F")

            sender.text = zahl.ToString
            timokatalog(index).imeresPlirom = zahl.ToString

            'timokatalog(index).imeres = sender.text
        Catch ex As InvalidCastException
            zahl = timokatalog(index).imeresTotal
            sender.text = zahl.ToString
            timokatalog(index).imeresPlirom = zahl.ToString
        End Try
        setze_times_anal(kwdDB, index)
    End Sub
    Private Sub EkptosiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EkptosiBtn.Click
        Dim imeres As Int16
        imeres = Me.rechne_imeres_diamonis()

        Dim form As New EkptoseisFrm(SynolLbl.Text, imeres, ekptPoso, ekptPososto, ekptFree, ekptCFee)

        form.ShowDialog()

        ekptPoso = form.return_poso
        ekptPososto = form.return_pososto
        ekptFree = form.return_free
        ekptCFee = form.return_fee

        'kratisiArithm = form.return_arithmo_kratisis
        form.Dispose()
        setze_sum_timokat()
    End Sub
    Private Sub TextBox_SelectAllText(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnilikTbx.Click, PaidiTbx1.Click, PaidiTbx2.Click,
  EthnAnzTbx1.Click, EthnAnzTbx2.Click, SimetTbx.Click, ProkatTbx.Click, KratisiTbx.Click, PaidiTbx3.Click
        sender.SelectAll()
    End Sub
    Private Sub timokat_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs) 'alakse arketa se sxesi me tis ergasies_imearas
        ' afou den exoume apothikeusi neou alla mono afixi uparxwn kratisis, over 
        Dim countDB As Int16 ', arkrat
        Dim kwdikosOver As Integer
        Dim overOK As Boolean = False
        Dim arithDwmat As String = Nothing
        Dim epistrofi As Date = #1/1/1900#
        Dim response As MsgBoxResult
        Dim ekptosiOK As Boolean = False


        If sender.name.Equals("Over") Then
            overOK = True
        End If


        If timokatalog.Length <> 0 Then
            If Not ist_xrewsi_ok() Then
                MsgBox("Δεν έχει επιλεγεί τύπος χρέωσης !", MsgBoxStyle.Critical, "winfo\nikEl.")

                Exit Sub
            End If
            If SynolLbl.Text >= 0 Then
                ersetze_temp_vor_speichern()
            Else
                MsgBox(" Ελέγξτε τις τιμές - εκπτώσεις !", MsgBoxStyle.Critical, "winfo\nikEl.")
                'Me.Cursor = Cursors.Default
                'sender.enabled = True
                Exit Sub
            End If
            If CType(EnilikTbx.Text, Int16) <= 0 Then ' gia afixi prepei i arithmos twn enilikwn na einai > 0!
                MsgBox(" Δώστε Αριθμό Ενηλίκων !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                sender.enabled = True
                EnilikTbx.Focus()
                Exit Sub
            End If


            If Not sind_ethnikotites_ok(sender, e) Then
                Exit Sub
            End If

            If ekptPoso <> 0 OrElse ekptPososto <> 0 OrElse ekptFree <> 0 OrElse ekptCFee <> 0 Then
                ekptosiOK = True
            Else
                ekptosiOK = False
            End If
            '  If (overOK And (DwmTbx.Text.Equals("") Or DwmTbx.Text.Equals("Ov-Book"))) OrElse (Not overOK And Not DwmTbx.Text.Equals("")) Then
            If (overOK And (DwmTbx.Text.Equals("") Or DwmTbx.Text.Equals("OV-BOOK"))) OrElse (Not overOK And Not DwmTbx.Text.Equals("")) Then
                Try
                    If CType(EnilikTbx.Text, Int16) <= 0 Then ' gia afixi prepei i arithmos twn enilikwn na einai > 0!
                        MsgBox(" Δώστε Αριθμό Ενηλίκων !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.enabled = True
                        Me.Cursor = Cursors.Default
                        EnilikTbx.Focus()
                        Exit Sub
                    End If
                    If overOK Then
                        If DwmTbx.Text.Equals("") Or DwmTbx.Text.Equals("OV-BOOK") Then
                            'If status = 1 Then 'to Over Button!
                            response = MsgBox(" Διαδικασία Over;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                            If response = MsgBoxResult.No Then

                                Me.Cursor = Cursors.Default
                                sender.enabled = True
                                Exit Sub
                            End If

                            'End If
                        Else
                            MsgBox(" Over με Δωμάτιο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.enabled = True
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                    Else
                        If DwmTbx.Text.Equals("") Then
                            MsgBox(" Άφιξη χωρίς Δωμάτιο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.enabled = True
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                    'kanei return ta Eintraege tis kratiseis pou eginan Update i -1 ean eixa Exception zb keini Connection zu DB
                    countDB = execute_update_kratisi_afixi_transaction(connectionString, kwdikoKratisisDB, overOK, ekptosiOK, True)
                    If countDB = 1 Then 'Connection OK
                        If overOK Then
                            'If status = 1 Then 'to Over Button!

                            If response = MsgBoxResult.Yes Then
                                Dim UnterForm As New OverUnterkuenfteFrm(sesionID, imeromErgasias, DateTimePicker3.Value.Date, status)
                                Try
                                    UnterForm.ShowDialog()
                                Catch ex As InvalidOperationException

                                End Try
                                arithDwmat = "OV-BOOK"
                                'ean upirxe protiteri kratisi gia dwmatio deleten !!!!!!!!!!
                                If Not Me.DbhotelDataSet.kratiseis(0).dwmatio.Equals("") OrElse Not Me.DbhotelDataSet.kratiseis(0).dwmatio.Equals("OV-BOOK") Then
                                    If praktoreiokwd = 48 Or praktoreiokwd = 49 Then
                                        If Not (praktortimolkwd = 2 OrElse praktortimolkwd = 4 OrElse praktortimolkwd = 43 OrElse praktortimolkwd = 50) Then
                                            If Not set_availabilities_status("", DateTimePicker2.Value.Date, DateTimePicker3.Value.Date.AddDays(-1), kwdikoKratisisDB) Then
                                                MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση του HotelAvailabilities ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                            End If
                                        End If
                                    End If
                                    Me.StatusTableAdapter.DeleteByKratisiEnarxi(kwdikoKratisisDB, imeromErgasias)
                                End If
                            End If

                            'End If

                        Else
                            If praktoreiokwd = 48 Or praktoreiokwd = 49 Then
                                If Not (praktortimolkwd = 2 OrElse praktortimolkwd = 4 OrElse praktortimolkwd = 43 OrElse praktortimolkwd = 50) Then
                                    If Not set_availabilities_status(DwmTbx.Text, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date.AddDays(-1), kwdikoKratisisDB) Then
                                        MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση του HotelAvailabilities ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                    End If
                                End If
                            End If
                            If Me.DbhotelDataSet.kratiseis(0).dwmatio = Nothing Then
                                Me.StatusTableAdapter.InsertStatusDwmatiou(DwmTbx.Text, kwdikoKratisisDB, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date.AddDays(-1), 5)
                            Else
                                ' uparxei Status->Reservierung!->
                                Me.StatusTableAdapter.UpdateStatusByKratisi(5, DwmTbx.Text, DateTimePicker2.Value, DateTimePicker3.Value.AddDays(-1), kwdikoKratisisDB)
                            End If
                        End If
                    Else
                        If countDB = -1 Then
                            MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                            sender.enabled = True
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        ElseIf countDB = 0 Then
                            MsgBox(" Πιθανώς η Κράτηση έχει τροποποιηθεί απο άλλον User  !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.enabled = True
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If

                    End If

                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    sender.enabled = True
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End Try

            Else
                MsgBox(" Για Άφιξη πρέπει να δώσετε Αριθμό Δωματίου " & vbCrLf & " Overbooking αντιθέτως χωρίς Δωμάτιο ! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                sender.enabled = True
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            update_paidia()
            'Dim arKratisis As Int16
            Try
                'arKratisis = Me.DbhotelDataSet.kratiseis(0).arithmos
                If overOK Then
                    Try
                        epistrofi = Me.OverunterkuenfteTableAdapter.GetMaxHmerMexriByOver(sesionID)
                    Catch ex As Exception
                        'epistrofi = #1/1/1900#
                        epistrofi = DateTimePicker3.Value.AddDays(-1)
                    End Try
                    Try
                        Me.OverTableAdapter.InsertOver(kwdikoKratisisDB, epistrofi, imeromErgasias, epistrofi, False)
                        Try
                            kwdikosOver = Me.OverTableAdapter.GetKwdByKratisi(kwdikoKratisisDB, False)
                            Me.OverunterkuenfteTableAdapter.UpdateOverByOver(kwdikosOver, sesionID)
                        Catch ex As InvalidOperationException
                            MsgBox("Παρουσιάστηκε πρόβλημα στην καταχώριση των στοιχείων για Over", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End Try
                    Catch ex As OleDb.OleDbException
                        MsgBox("Παρουσιάστηκε πρόβλημα στην καταχώριση των στοιχείων για Over", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If
            Catch ex As InvalidOperationException
                MsgBox("Η Διαδικασία δεν μπόρεσε να ολοκληρωθεί επιτυχώς: Πιθανώς η Κράτηση διαγράφηκε απο άλλον User !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try


            kwdikoKratisisDB = -1
            sesionID = get_sesion()
            init_ekptoseis()
            ReDim timokatalog(-1)
            next_anamenwnta()
            'kratiseis_zeig(False)
        Else
            MsgBox("Η Διαδικασία δεν έχει ολοκληρωθεί ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            Exit Sub
        End If
        'MsgBox(" Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
    End Sub
    'return 1->alles OK 0->H Kratisi exei diagrafei apo allon User -1->kati then pige kalla me Connection zu DB
    Public Function execute_update_kratisi_afixi_transaction(ByVal connectionString As String, ByVal kwdikos As Integer, ByVal overOK As Boolean, ByVal ekptosiOK As Boolean, ByVal checkIn As Boolean) As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Dim rows, j, countPaidia As Int16
            Dim countTimesKrat As Int16
            Dim paratiriseis As String = ""

            If overOK Then
                paratiriseis = "OV-BOOK "
            End If
            If CheckBox1.Checked Then
                paratiriseis = paratiriseis + "Guarantee "
            End If
            If ekptosiOK Then
                paratiriseis = paratiriseis + "Εκπτωση"
            End If
            If Not PaidiTbx1.Text.Equals("0") And Not PaidiTbx2.Text.Equals("") Then
                countPaidia += 1
            End If
            If Not PaidiTbx2.Text.Equals("0") And Not PaidiTbx1.Text.Equals("") Then
                countPaidia += 1
            End If
            If Not PaidiTbx3.Text.Equals("0") And Not PaidiTbx3.Text.Equals("") Then
                countPaidia += 1
            End If
            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction
                command.Parameters.AddWithValue("praktoreio", CType(praktoreiokwd, Integer))
                command.Parameters.AddWithValue("praktimologio", CType(praktortimolkwd, Integer))
                command.Parameters.AddWithValue("voucher", CType(Me.VoucherTbx.Text, String))
                command.Parameters.AddWithValue("enilikes", CType(EnilikTbx.Text, Int16))
                command.Parameters.AddWithValue("paidia", countPaidia)
                command.Parameters.AddWithValue("afixi", CType(DateTimePicker2.Value.Date, Date))
                command.Parameters.AddWithValue("wra", CType(DateTimePicker2.Value.TimeOfDay.ToString, Date))
                command.Parameters.AddWithValue("anaxwrisi", CType(DateTimePicker3.Value, Date))
                command.Parameters.AddWithValue("klines", CType(currentklines, Integer))
                command.Parameters.AddWithValue("tipos", CType(currenttipos, Integer))
                command.Parameters.AddWithValue("guarantie", CType(CheckBox1.Checked, Boolean))
                If overOK Then
                    command.Parameters.AddWithValue("dwmatio", CType("OV-BOOK", String))
                Else
                    command.Parameters.AddWithValue("dwmatio", CType(DwmTbx.Text, String))
                End If
                command.Parameters.AddWithValue("pliromi", CType(PliromCbx.Text, String))
                command.Parameters.AddWithValue("synolo", CType(SynolLbl.Text, Single))
                command.Parameters.AddWithValue("ethnikotites", CType(EthnKwd1.Text, Int16))
                command.Parameters.AddWithValue("anzethnikotites", CType(EthnAnzTbx1.Text, Byte))
                command.Parameters.AddWithValue("anzethnikotita2", CType(EthnAnzTbx2.Text, Byte))
                command.Parameters.AddWithValue("ethnikotites2", CType(EthnKwd2.Text, Int16))
                command.Parameters.AddWithValue("epithimdate", CType(DateTimePicker4.Value.Date, Date))
                command.Parameters.AddWithValue("epithimia", CType(EpithimTbx.Text, String))
                command.Parameters.AddWithValue("prokataboli", CType(ProkatTbx.Text, Single))
                command.Parameters.AddWithValue("prokatdate", CType(DateTimePicker5.Value.Date, Date))
                command.Parameters.AddWithValue("simetoxi", CType(SimetTbx.Text, Int16))
                command.Parameters.AddWithValue("tilefonomem", CType(TilefTbx.Text, String))
                command.Parameters.AddWithValue("simbolaio", CType(currentsimbolaio, Integer))
                command.Parameters.AddWithValue("ekptosi", CType(ekptosiOK, Boolean))
                command.Parameters.AddWithValue("ekptposo", CType(ekptPoso, Single))
                command.Parameters.AddWithValue("ekptpososto", CType(ekptPososto, Single))
                command.Parameters.AddWithValue("ekptimeres", CType(ekptFree, Single))
                command.Parameters.AddWithValue("fee", CType(ekptCFee, Single))
                command.Parameters.AddWithValue("checkin", CType(checkIn, Boolean))
                command.Parameters.AddWithValue("kwd", CType(kwdikos, Integer))
                command.CommandText = "UPDATE kratiseis SET praktoreio=?,praktimologio=?, voucher=?, enilikes=?, paidia=?, afixi=?, wra=?, anaxwrisi=?, klines=?, tipos=?, guarantie=?, dwmatio=?," &
                "pliromi=?, synolo=?, ethnikotites=?, anzethnikotites=?, anzethnikotites2=?, ethnikotites2=?, epithimdate=?, epithimia=?," &
                "prokataboli=?, prokatdate=?, simetoxi=?, tilefonomem=?, simbolaio=?, ekptosi=?, ekptposo=?, ekptpososto=?, ekptimeres=?, fee=?, checkin=?, timologio=0 where (kwd=?) and (checkin=false)"
                rows = command.ExecuteNonQuery()
                command.Parameters.Clear()
                'command.CommandText = "UPDATE kratiseis SET praktoreio=?,praktimologio=?, voucher=?, enilikes=?, afixi=?, wra=?, anaxwrisi=?, klines=?, tipos=?, guarantie=?, dwmatio=?," & _
                '             "pliromi=?, synolo=?, ethnikotites=?, anzethnikotites=?, anzethnikotites2=?, ethnikotites2=?, epithimdate=?, epithimia=?," & _
                '             "prokataboli=?, prokatdate=?, simetoxi=?, tilefonomem=?, simbolaio=?, ekptosi=?, ekptposo=?, ekptpososto=?, ekptimeres=?, fee=?, checkin=?, timologio=0 where (kwd=?) and (checkin=false)"
                'rows = command.ExecuteNonQuery()
                'command.Parameters.Clear()
                If rows = 0 Then ' H Kratisi exei pithanws diagrafei apo allon User!!!!!!!!!!!!!!',
                    transaction.Rollback()
                    Return rows
                End If

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "SELECT * FROM timeskratisis where (kratisi=?)"

                Dim myReader As OleDb.OleDbDataReader
                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                While myReader.Read()
                    countTimesKrat += 1
                End While
                myReader.Close()
                command.Parameters.Clear()
                'MsgBox(countTimesKrat)
                If countTimesKrat = timokatalog.Length AndAlso timokatalog(0).kwdDB <> -1 Then
                    For j = 0 To timokatalog.Length - 1
                        command.Parameters.AddWithValue("timi", CType(timokatalog(j).timi, Integer))
                        command.Parameters.AddWithValue("ekptosi", CType(timokatalog(j).ekptosi, Single))
                        command.Parameters.AddWithValue("apo", CType(timokatalog(j).apo, Date))
                        command.Parameters.AddWithValue("mexri", CType(timokatalog(j).mexri, Date))
                        command.Parameters.AddWithValue("ypnos", CType(timokatalog(j).ypnos, Single))
                        command.Parameters.AddWithValue("prwino", CType(timokatalog(j).prwino, Single))
                        command.Parameters.AddWithValue("geuma", CType(timokatalog(j).geuma, Single))
                        command.Parameters.AddWithValue("deipno", CType(timokatalog(j).deipno, Single))
                        command.Parameters.AddWithValue("extra", CType(timokatalog(j).paroxi, Single))
                        command.Parameters.AddWithValue("synolo", CType(timokatalog(j).synolo, Single))
                        command.Parameters.AddWithValue("imeres", CType(timokatalog(j).imeresPlirom, Byte))

                        command.Parameters.AddWithValue("touristperiod", CType(timokatalog(j).tourist, Integer))
                        command.Parameters.AddWithValue("xrewsi", CType(timokatalog(j).xrewsi, Integer))
                        command.Parameters.AddWithValue("kwd", CType(timokatalog(j).kwdDB, Integer))
                        command.CommandText = "UPDATE timeskratisis SET  timi=?, ekptosi=?, apo=?, mexri=?, ypnos=?, prwino=?, geuma=?," &
                        "deipno=?, extra=?, synolo=?, imeres=?, touristperiod=?, xrewsi=? where (kwd=?)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    Next
                Else
                    command.Parameters.AddWithValue("kwd", CType(kwdikos, Integer))
                    command.CommandText = "DELETE FROM timeskratisis where (kratisi=?)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    For j = 0 To timokatalog.Length - 1
                        command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                        command.Parameters.AddWithValue("timi", CType(timokatalog(j).timi, Integer))
                        command.Parameters.AddWithValue("ekptosi", CType(timokatalog(j).ekptosi, Single))
                        command.Parameters.AddWithValue("apo", CType(timokatalog(j).apo, Date))
                        command.Parameters.AddWithValue("mexri", CType(timokatalog(j).mexri, Date))
                        command.Parameters.AddWithValue("imeres", CType(timokatalog(j).imeresPlirom, Byte))
                        command.Parameters.AddWithValue("ypnos", CType(timokatalog(j).ypnos, Single))
                        command.Parameters.AddWithValue("prwino", CType(timokatalog(j).prwino, Single))
                        command.Parameters.AddWithValue("geuma", CType(timokatalog(j).geuma, Single))
                        command.Parameters.AddWithValue("deipno", CType(timokatalog(j).deipno, Single))
                        command.Parameters.AddWithValue("extra", CType(timokatalog(j).paroxi, Single))
                        command.Parameters.AddWithValue("synolo", CType(timokatalog(j).synolo, Single))
                        command.Parameters.AddWithValue("touristperiod", CType(timokatalog(j).tourist, Integer))
                        command.Parameters.AddWithValue("xrewsi", CType(timokatalog(j).xrewsi, Integer))
                        command.CommandText = "INSERT INTO timeskratisis (kratisi, timi, ekptosi, apo, mexri, imeres, ypnos, prwino, geuma, deipno, extra, synolo, touristperiod, xrewsi)" &
                        "values (kratisi, timi, ekptosi, apo, mexri, imeres, ypnos, prwino, geuma, deipno, extra, synolo, touristperiod, xrewsi)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()
                    Next
                End If
                If checkIn Then
                    command.Parameters.AddWithValue("etos", CType(etos, Integer))
                    command.Parameters.AddWithValue("imerominia", CType(DateTimePicker2.Value.Date, Date))
                    command.Parameters.AddWithValue("status", CType(1, Byte))
                    command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                    command.Parameters.AddWithValue("voucher", CType(Me.VoucherTbx.Text, String))
                    command.Parameters.AddWithValue("dwmatio", CType(DwmTbx.Text, String))
                    command.Parameters.AddWithValue("enilikes", CType(EnilikTbx.Text, Int16))
                    command.Parameters.AddWithValue("anilika", CType(countPaidia, Int16))
                    command.Parameters.AddWithValue("atoma", CType(EnilikTbx.Text + countPaidia, Int16))
                    command.Parameters.AddWithValue("xrewsi", CType(timokatalog(0).xrewsi, Integer))
                    If Me.DbhotelDataSet.etaireia(0).biblportas = 1 Then
                        command.Parameters.AddWithValue("onomateponimo", CType(OnomTbx1.Text, String))
                    Else
                        command.Parameters.AddWithValue("onomateponimo", CType(OnomTbx1.Text + ChrW(13) + OnomTbx2.Text + ChrW(13) + OnomTbx3.Text, String))
                    End If
                    command.Parameters.AddWithValue("anzethnikotita", CType(EthnAnzTbx1.Text, Byte))
                    command.Parameters.AddWithValue("ethnikotita", CType(EthnKwd1.Text, Int16))
                    command.Parameters.AddWithValue("anzethnikotita2", CType(EthnAnzTbx2.Text, Byte))
                    command.Parameters.AddWithValue("ethnikotita2", CType(EthnKwd2.Text, Int16))
                    command.Parameters.AddWithValue("praktoreio", CType(praktortimolkwd, Integer))
                    command.Parameters.AddWithValue("ypnos", CType(timokatalog(0).ypnos, Single))
                    command.Parameters.AddWithValue("prwino", CType(timokatalog(0).prwino, Single))
                    command.Parameters.AddWithValue("geumata", CType(timokatalog(0).geuma + timokatalog(0).deipno, Single))
                    command.Parameters.AddWithValue("extras", CType(timokatalog(0).paroxi, Single))
                    command.Parameters.AddWithValue("synolo", CType((timokatalog(0).ypnos + timokatalog(0).prwino + timokatalog(0).deipno + timokatalog(0).geuma + timokatalog(0).paroxi), Single))
                    command.Parameters.AddWithValue("datum", CType(DateTimePicker3.Value.Date, Date))
                    command.Parameters.AddWithValue("paratiriseis", CType(paratiriseis, String))
                    command.CommandText = "INSERT INTO biblioportas (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma, xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2," &
                    "praktoreio, ypnos, prwino, geumata, extras, synolo, datum, paratiriseis, flag) values (etos, imerominia, status, kratisi, voucher, dwmatio, enilikes, anilika, atoma," &
                    "xrewsi, onomateponimo, anzethnikotita, ethnikotita, anzethnikotita2, ethnikotita2,praktoreio, ypnos, prwino, geumata, extras, synolo, datum, paratiriseis, 0)"

                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                End If

                transaction.Commit()
                Return rows
            Catch ex As Exception
                MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return -1
                Catch
                    Return -1
                End Try
            End Try
        End Using
    End Function
    Private Function set_availabilities_status(ByVal dwmNew As String, ByVal neaEnarxi As Date, ByVal neaLixi As Date, ByVal kwdikosKrat As Integer) As Boolean
        Dim roomRateTiposOld As String = ""
        Dim roomRateTiposNew As String = ""
        Dim dwmOld As String = ""
        Dim enarxiOld, lixiOld As Date
        Dim hotel As SetMainCalendarKratisis

        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            ' Assign transaction object for a pending local transaction.
            command.Connection = connection
            command.Parameters.AddWithValue("kratisi", kwdikosKrat)
            command.CommandText = "SELECT dwmatio, enarxi,lixi, dwmatiostatus FROM status WHERE kratisi=?"
            myReader = command.ExecuteReader()
            While myReader.Read
                dwmOld = myReader.GetString(0)
                enarxiOld = myReader.GetDateTime(1)
                lixiOld = myReader.GetDateTime(2)
            End While
            command.Parameters.Clear()
            myReader.Close()
            If dwmOld <> "" Then
                command.Parameters.AddWithValue("arithmos", dwmOld)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?))"
                'WHERE tbl_dwmatia.arithmos NOT IN (
                '   SELECT DISTINCT tbl_kratiseis.dwmatio
                '   FROM tbl_kratiseis
                '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
                myReader = command.ExecuteReader()
                While myReader.Read()
                    roomRateTiposOld = myReader.GetString(0)
                    Exit While
                End While
                command.Parameters.Clear()
                myReader.Close()
            End If
            If dwmNew <> "" Then
                command.Parameters.AddWithValue("arithmos", dwmNew)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?))"
                'WHERE tbl_dwmatia.arithmos NOT IN (
                '   SELECT DISTINCT tbl_kratiseis.dwmatio
                '   FROM tbl_kratiseis
                '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
                myReader = command.ExecuteReader()
                While myReader.Read()
                    roomRateTiposNew = myReader.GetString(0)
                    Exit While
                End While
                command.Parameters.Clear()
                myReader.Close()
            End If
            If dwmNew <> dwmOld Then
                If roomRateTiposNew <> roomRateTiposOld Then
                    If roomRateTiposOld <> "" Then
                        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxiOld, lixiOld, "1")
                        hotel.set_roomratetype_id(roomRateTiposOld)
                        hotel.set_availabilities_operator("plus")
                        File.AppendAllText(availPath, "1502 " + roomRateTiposOld + " " + enarxiOld + " " + lixiOld + " " + "plus" + vbCrLf)

                    End If
                    If roomRateTiposNew <> "" Then
                        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaEnarxi, neaLixi, "1")
                        hotel.set_roomratetype_id(roomRateTiposNew)
                        hotel.set_availabilities_operator("minus")
                        File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaEnarxi + " " + neaLixi + " " + "minus" + vbCrLf)

                    End If


                End If

            ElseIf dwmOld = dwmNew And dwmNew <> "" Then
                If enarxiOld < neaEnarxi Then ' nea afixi pio meta apo programatismeni -> eleyuervse damtio
                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxiOld, neaEnarxi.AddDays(-1), "1")
                    hotel.set_roomratetype_id(roomRateTiposNew)
                    hotel.set_availabilities_operator("plus")
                    File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + enarxiOld + " " + neaEnarxi.AddDays(-1) + " " + "plus" + vbCrLf)
                ElseIf neaEnarxi < enarxiOld Then
                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaEnarxi, enarxiOld.AddDays(-1), "1")
                    hotel.set_roomratetype_id(roomRateTiposNew)
                    hotel.set_availabilities_operator("minus")
                    File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaEnarxi + " " + enarxiOld.AddDays(-1) + " " + "minus" + vbCrLf)
                End If
                If lixiOld < neaLixi Then ' epektasi anxwrisis
                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", lixiOld.AddDays(+1), neaLixi, "1")
                    hotel.set_roomratetype_id(roomRateTiposNew)
                    hotel.set_availabilities_operator("minus")
                    File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + lixiOld.AddDays(+1) + " " + neaLixi + " " + "minus" + vbCrLf)
                ElseIf neaLixi < lixiOld Then
                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaLixi.AddDays(+1), lixiOld, "1")
                    hotel.set_roomratetype_id(roomRateTiposNew)
                    hotel.set_availabilities_operator("plus")
                    File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaLixi.AddDays(+1) + " " + lixiOld + " " + "plus" + vbCrLf)
                End If
            End If




        End Using
    End Function
    Private Function sind_ethnikotites_ok(ByVal sender As System.Object, ByVal e As System.EventArgs) As Boolean
        If EthnAnzTbx1.Text.Equals("0") AndAlso EthnKwd1.Text > 0 Then
            EthnKwd1.Text = 0
            EthnikTbx1.Clear()
        End If

        If Not EthnAnzTbx1.Text.Equals("0") AndAlso EthnKwd1.Text = 0 Then
            MsgBox("Επιλέξτε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            sender.enabled = True
            Me.Cursor = Cursors.Default
            EthnikTbx1.Focus()
            If EthnKwd1.Text = 0 Then
                MsgBox("Δέν ολοκληρώθηκε η Αποθήκευση !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Return False
            End If
            '
        End If
        If EthnAnzTbx2.Text.Equals("0") AndAlso EthnKwd2.Text > 0 Then
            EthnKwd2.Text = 0
            EthnikTbx2.Clear()
        End If
        If Not EthnAnzTbx2.Text.Equals("0") AndAlso EthnKwd2.Text = 0 Then
            MsgBox("Επιλέξτε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            sender.enabled = True
            Me.Cursor = Cursors.Default
            EthnikTbx2.Focus()
            If EthnKwd2.Text = 0 Then
                MsgBox("Δέν ολοκληρώθηκε η Αποθήκευση !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Return False
            End If
            'Exit Sub
        End If
        If EthnKwd1.Text = 0 AndAlso EthnAnzTbx1.Text.Equals("0") AndAlso EthnKwd2.Text <> 0 AndAlso Not EthnAnzTbx2.Text.Equals("0") Then
            EthnKwd1.Text = EthnKwd2.Text
            EthnKwd2.Text = 0
            EthnAnzTbx1.Text = EthnAnzTbx2.Text
            EthnAnzTbx2.Text = 0
        End If
        Return True
    End Function

    Private Sub release_period_pruefen()
        Dim releazeP, diff As Int16
        'MsgBox(timokatalog(0).tourist.ToString)
        Try
            releazeP = Me.TouristperiodoiTableAdapter.GetReleazeByKwd(timokatalog(0).tourist.ToString)
        Catch ex As InvalidOperationException
            releazeP = 0
        End Try
        Try
            diff = Me.DateTimePicker2.Value.Date.DayOfYear - (CType(ImeromKratTbx.Text, Date).DayOfYear + releazeP)
        Catch ex As InvalidCastException
            diff = 0
        End Try
        If releazeP <> 0 AndAlso diff < 0 Then
            MsgBox(" Εκτός Release Period ! (" + diff.ToString + ")", MsgBoxStyle.Information, "winfo\nikEl.")
        End If

    End Sub
    Private Sub OnomTbx1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnomTbx1.Enter, OnomTbx2.Enter, OnomTbx3.Enter
        Dim j, count As Int16
        Dim find() As Control
        Dim kwdikos As Integer

        'Dim kwdEnilikwn() As Integer
        'If kwdikoKratisisDB <> -1 Then
        If kwdikoKratisisDB = -1 Then
            kwdikos = sesionID
        Else
            kwdikos = kwdikoKratisisDB
        End If
        Dim form As New OnomataKratisisFrm(kwdikos, imeromErgasias, praktortimolkwd)
        form.StartPosition = FormStartPosition.CenterParent
        Try
            form.ShowDialog()
        Catch ex As InvalidOperationException

        End Try
        Me.EnilikesTableAdapter.FillByKratisi(Me.DbhotelDataSet.enilikes, kwdikos)
        If Me.DbhotelDataSet.enilikes.Count <= 3 Then
            count = Me.DbhotelDataSet.enilikes.Count
        Else
            count = 3
        End If
        OnomTbx1.Clear()
        OnomTbx2.Clear()
        OnomTbx3.Clear()
        For j = 0 To count - 1
            find = Kratiseis2Pnl.Controls.Find("OnomTbx" + (j + 1).ToString, False)
            find(0).Text = Me.DbhotelDataSet.enilikes(j).onomateponimo
        Next

        PaidiTbx1.Focus()
        'Else
        'MsgBox(" Υπάρχει η Δυνατότητα εισαγωγής πλέον των 3 Ατόμων: Εισάγετε τα 3 πρώτα Ονομ/πώνυμα στα 3 αντίστοιχα πεδία, " & vbCrLf & " ολοκληρώστε την εισαγωγή της νέας κράτησης με αποθήκευση και έπειτα μπορείτε να εισάγετε και άλλα Ατομα" & vbCrLf & " πατώντας αυτό το κουμπί ξανά ! ", MsgBoxStyle.Information, "winfo\nikEl.")
        'End If
    End Sub
    Private Sub apy_Btn_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApyBtn.Click
        Dim kwdikos As Integer

        If kwdikoKratisisDB = -1 Then
            kwdikos = sesionID
        Else
            kwdikos = kwdikoKratisisDB
        End If

        Dim form As New ApyFrm(kwdikos)
        form.StartPosition = FormStartPosition.CenterParent
        Try
            form.ShowDialog()
            form.Dispose()
        Catch ex As InvalidOperationException
        End Try
        'Me.ApyTableAdapter.FillByKratisi(Me.DbhotelDataSet.apy, kwdikoKratisisDB)
    End Sub
    Private Sub delete_kratisi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim response As MsgBoxResult
        Dim countDB As Int16

        If kwdikoKratisisDB <> -1 Then
            response = MsgBox(" ΠΡΟΣΟΧΗ: Να γίνει διαγραφή αυτής της Κράτησης;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then

                Try
                    If praktoreiokwd = 48 Or praktoreiokwd = 49 Then
                        If Not (praktortimolkwd = 2 OrElse praktortimolkwd = 4 OrElse praktortimolkwd = 43 OrElse praktortimolkwd = 50) Then
                            If Not set_availabilities_deleted(kwdikoKratisisDB) Then
                                MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση του HotelAvailabilities ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            End If
                        End If
                    End If
                    countDB = delete_kratisi_transaction(connectionString, kwdikoKratisisDB)
                    If currenttipos > 0 And currenttipos < 13 Then
                        Dim calender As New GoogleCalendar("", "", Me.DbhotelDataSet.kratiseis(0).afixi, Me.DbhotelDataSet.kratiseis(0).anaxwrisi, Me.DbhotelDataSet.kratiseis(0).dwmatio, Me.DbhotelDataSet.kratiseis(0).dwmatio, "", "")
                        calender.delete_entry()
                    End If

                Catch ex As OleDb.OleDbException
                    MsgBox(" Παρουσιάστηκε σφάλμα κατά την διαδικασία Διαγραφής !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    Exit Sub
                End Try
                If countDB = 1 Then
                    MsgBox(" H Κράτηση διαγράφηκε !", MsgBoxStyle.Information, "winfo\nikEl.")
                ElseIf countDB = 0 Then
                    MsgBox(" Η Κράτηση εχει πιθανώς διαγραφεί από άλλον User !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If

                Me.DbhotelDataSet.kratiseis.Clear()
                kwdikoKratisisDB = -1
                'sesionID = get_sesion()
                'init_ekptoseis()
                ReDim timokatalog(-1)
                init_ekptoseis()
                next_anamenwnta()
                'kratiseis_zeig(False)
            End If
        Else
            MsgBox(" Δεν έχει επιλεχθεί Κράτηση προς Διαγραφή !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End If
    End Sub
    Private Function set_availabilities_deleted(ByVal kwdikos As Int16) As Boolean
        Dim roomRateTipos As String = ""
        Dim dwm As String = ""
        Dim apo, mexri As Date
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            ' Assign transaction object for a pending local transaction.
            command.Connection = connection
            command.Parameters.AddWithValue("kratisi", kwdikos)
            command.CommandText = "SELECT  dwmatio, enarxi, lixi FROM status WHERE (kratisi=?)"
            myReader = command.ExecuteReader()
            ' PROSOXi ALAKSA Noembrios 2018 !!! giat;i den doyleue to systhma gia kratiseis Xristougennwn  pou patousan se 2 eti
            While myReader.Read()
                'kalutera diktes apo pou mexri pou sto imeresStat
                dwm = myReader.GetString(0)
                apo = myReader.GetDateTime(1)
                mexri = myReader.GetDateTime(2)


            End While
            myReader.Close()
            command.Parameters.Clear()

            If dwm <> "" Then
                command.Parameters.AddWithValue("arithmos", dwm)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?))"
                'WHERE tbl_dwmatia.arithmos NOT IN (
                '   SELECT DISTINCT tbl_kratiseis.dwmatio
                '   FROM tbl_kratiseis
                '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
                myReader = command.ExecuteReader()
                While myReader.Read()
                    roomRateTipos = myReader.GetString(0)
                    Exit While
                End While
            End If

            ' Always call Read before accessing data.
            If roomRateTipos <> "" Then
                Dim hotel As New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", apo, mexri, "1")
                hotel.set_roomratetype_id(roomRateTipos)
                hotel.set_availabilities_operator("plus")
                If hotel.make_send_XML_file_for_Availabilities_request() Then
                    File.AppendAllText(availPath, DateTime.Now + " " + "1502 " + roomRateTipos + " " + apo + " " + mexri + " " + "plus" + vbCrLf)
                Else
                    Return False
                End If

                'Return hotel.make_send_XML_file_for_request()


            End If

        End Using
        Return True
    End Function
    Private Function delete_kratisi_transaction(ByVal connectionString As String, ByVal kwdikos As Integer) As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim overKwd As Integer = -1
            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Dim rows As Int16
            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM timeskratisis where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM paidia where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM enilikes where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM apy where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM status where (kratisi=?)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                'If status = 2 Then
                '    command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                '    command.CommandText = "SELECT kwd FROM over where (kratisi=?)"
                '    Dim myReader As OleDb.OleDbDataReader
                '    myReader = command.ExecuteReader()
                '    ' Always call Read before accessing data.
                '    While myReader.Read()
                '        overKwd = myReader.GetInt32(0)
                '    End While
                '    myReader.Close()
                '    If overKwd <> -1 Then ' paei na pei oti brethikan parapanw kratiseis me ton idio arithmo kratisis
                '        command.Parameters.Clear()
                '        command.Parameters.AddWithValue("over", overKwd)
                '        command.CommandText = "DELETE FROM overunterkuenfte where (over=?)"
                '        command.ExecuteNonQuery()
                '        command.Parameters.Clear()

                '        command.Parameters.Clear()
                '        command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                '        command.CommandText = "DELETE FROM over where (kratisi=?)"
                '        command.ExecuteNonQuery()
                '        command.Parameters.Clear()
                '    End If
                '    'command.Parameters.Clear()
                '    'command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                '    'command.CommandText = "DELETE FROM nonshow where (kratisi=?)"
                '    'command.ExecuteNonQuery()
                '    'command.Parameters.Clear()
                'End If

                command.Parameters.Clear()
                command.Parameters.AddWithValue("kratisi", CType(kwdikos, Integer))
                command.CommandText = "DELETE FROM kratiseis where (kwd=?)"
                rows = command.ExecuteNonQuery()
                command.Parameters.Clear()

                transaction.Commit()
                Return rows
            Catch ex As Exception
                MsgBox("Η Διαδικασία απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return -1
                Catch
                    Return -1
                End Try

            End Try



        End Using


    End Function

    'Private Sub delete_kratisi(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim response As MsgBoxResult
    '    If kwdikoKratisisDB <> -1 Then
    '        response = MsgBox(" ΠΡΟΣΟΧΗ: Να γίνει διαγραφή αυτής της Κράτησης;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '        If response = MsgBoxResult.Yes Then
    '            Try
    '                Me.TimeskratisisTableAdapter.DeleteTimesByKratisiEtos(kwdikoKratisisDB)
    '                Me.PaidiaTableAdapter.DeletePaidiaByKratisi(kwdikoKratisisDB)
    '                Me.EnilikesTableAdapter.DeleteEnilikesByKratisi(kwdikoKratisisDB)
    '                Me.ApyTableAdapter.DeleteApyByKratisi(kwdikoKratisisDB)
    '                Me.StatusTableAdapter.DeleteStatusDwmatiouByKratisi(kwdikoKratisisDB)
    '            Catch ex As OleDb.OleDbException
    '                MsgBox(" Παρουσιάστηκε σφάλμα κατά την Διαδικασία Διαγραφής !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Exit Sub
    '            End Try
    '            Try
    '                'Me.StatusTableAdapter.DeleteReservationByKratisi(kwdikoKratisisDB)
    '                Me.KratiseisTableAdapter.DeleteKratisi(kwdikoKratisisDB)
    '            Catch ex As OleDb.OleDbException
    '                MsgBox(" Δεν επιτρέπεται η Διαγραφή αυτής της Κράτησης !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                Exit Sub
    '            End Try

    '            MsgBox(" H Κράτηση διαγράφηκε !", MsgBoxStyle.Information, "winfo\nikEl.")
    '            Me.DbhotelDataSet.kratiseis.Clear()
    '            kwdikoKratisisDB = -1
    '            'sesionID = get_sesion()
    '            ReDim timokatalog(-1)
    '            init_ekptoseis()
    '            next_anamenwnta()
    '            'kratiseis_zeig(False)
    '        End If
    '    Else
    '        MsgBox(" Δεν έχει επιλεχθεί Κράτηση προς Διαγραφή !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    '    End If
    'End Sub
    Private Sub non_show_kratisi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim response As MsgBoxResult
        Dim countDB As Int16

        If kwdikoKratisisDB <> -1 Then
            response = MsgBox(" Εισαγωγή αυτής της Κράτησης στις non show Κρατήσεις ;", MsgBoxStyle.YesNo, "winfo\nikEl.")

            If response = MsgBoxResult.Yes Then
                Me.NonshowkratiseisTableAdapter.InsertNonShowKratisi(ImeromKratTbx.Text, etos, Me.DbhotelDataSet.kratiseis(0).arithmos, Me.DbhotelDataSet.kratiseis(0).simbolaio,
                     praktoreiokwd, praktortimolkwd, Me.DbhotelDataSet.kratiseis(0).privatimologio, VoucherTbx.Text, Me.DbhotelDataSet.kratiseis(0).enilikes, Me.DbhotelDataSet.kratiseis(0).paidia,
                     Me.DbhotelDataSet.kratiseis(0).ethnikotites, Me.DbhotelDataSet.kratiseis(0).anzethnikotites, Me.DbhotelDataSet.kratiseis(0).ethnikotites2, Me.DbhotelDataSet.kratiseis(0).anzethnikotites2,
                      Me.DbhotelDataSet.kratiseis(0).afixi, Me.DbhotelDataSet.kratiseis(0).anaxwrisi, currentklines, currenttipos, Me.DbhotelDataSet.kratiseis(0).guarantie, Me.DbhotelDataSet.kratiseis(0).dwmatio,
                      Me.DbhotelDataSet.kratiseis(0).synolo, OnomTbx1.Text, OnomTbx2.Text, OnomTbx3.Text, timokatalog(0).xrewsi)

                Try
                    countDB = delete_kratisi_transaction(connectionString, kwdikoKratisisDB)
                Catch ex As OleDb.OleDbException
                    MsgBox(" Παρουσιάστηκε σφάλμα κατά την διαδικασία !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    Exit Sub
                End Try
                If countDB = 1 Then
                    MsgBox(" Επιτυχής Διαδικασία !", MsgBoxStyle.Information, "winfo\nikEl.")
                ElseIf countDB = 0 Then
                    MsgBox(" Η Κράτηση εχει πιθανώς διαγραφεί από άλλον User !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If

                Me.DbhotelDataSet.kratiseis.Clear()
                kwdikoKratisisDB = -1
                'sesionID = get_sesion()
                'init_ekptoseis()
                ReDim timokatalog(-1)
                init_ekptoseis()
                next_anamenwnta()
            End If
        Else
            MsgBox(" Στις Non Show Κρατήσεις μπαίνουν μόνο ήδη υπάρχουσες Κρατήσεις !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If


    End Sub
    'Private Sub update_stoixeia_diamenwnta(ByVal sender As System.Object, ByVal e As System.EventArgs) ' xrisimopoieitai panw stin non_show_kratisi gia apothikeusi stoixeiwn tis kratisis me chckin = true
    '    Dim j As Int16
    '    Dim ekptosiOK As Boolean = False
    '    If Not sind_ethnikotites_ok(sender, e) Then
    '        Exit Sub
    '    End If
    '    If ekptPoso <> 0 OrElse ekptPososto <> 0 OrElse ekptFree <> 0 OrElse ekptCFee <> 0 Then
    '        ekptosiOK = True
    '    Else
    '        ekptosiOK = False
    '    End If
    '    Me.KratiseisTableAdapter.UpdateKleisimoNonShowkratisi(praktoreiokwd, praktortimolkwd, VoucherTbx.Text, EnilikTbx.Text, 0, _
    '                                                        DateTimePicker2.Value, DateTimePicker2.Value.TimeOfDay.ToString, DateTimePicker3.Value, currentklines, currenttipos, CheckBox1.Checked, DwmTbx.Text, _
    '                                                        PliromCbx.SelectedItem, False, SynolLbl.Text, EthnKwd1.Text, EthnAnzTbx1.Text, EthnAnzTbx2.Text, EthnKwd2.Text, DateTimePicker4.Value.Date, EpithimTbx.Text, ProkatTbx.Text, DateTimePicker5.Value.Date, SimetTbx.Text, TilefTbx.Text, currentsimbolaio, ekptosiOK, ekptPoso, ekptPososto, ekptFree, ekptCFee, True, 0, kwdikoKratisisDB)


    '    Dim countTimesKrat As Int16
    '    Try
    '        countTimesKrat = Me.TimeskratisisTableAdapter.GetAnzahlTimByKratisi(kwdikoKratisisDB)
    '    Catch ex As InvalidOperationException
    '        countTimesKrat = 0
    '    End Try

    '    ersetze_temp_vor_speichern()

    '    If countTimesKrat = timokatalog.Length Then
    '        For j = 0 To timokatalog.Length - 1
    '            Try
    '                Me.TimeskratisisTableAdapter.UpdateTimiKratisis(timokatalog(j).timi, timokatalog(j).ekptosi, timokatalog(j).apo, timokatalog(j).mexri, _
    '                                       timokatalog(j).ypnos, timokatalog(j).prwino, timokatalog(j).geuma, timokatalog(j).deipno, timokatalog(j).paroxi, timokatalog(j).synolo, timokatalog(j).imeresPlirom, timokatalog(j).tourist, timokatalog(j).xrewsi, timokatalog(j).kwdDB)
    '            Catch ex As OleDb.OleDbException
    '                MsgBox("Η Αποθήκευση των αλλαγών των τιμών απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                'sender.enabled = True
    '                'Me.Cursor = Cursors.Default
    '                'Exit Sub
    '            End Try
    '        Next
    '    Else
    '        Me.TimeskratisisTableAdapter.DeleteTimesByKratisiEtos(kwdikoKratisisDB)
    '        For j = 0 To timokatalog.Length - 1
    '            Try
    '                Me.TimeskratisisTableAdapter.InsertTimiKratisis(kwdikoKratisisDB, timokatalog(j).timi, timokatalog(j).ekptosi, timokatalog(j).apo, timokatalog(j).mexri, _
    '                                       timokatalog(j).imeresPlirom, timokatalog(j).ypnos, timokatalog(j).prwino, timokatalog(j).geuma, timokatalog(j).deipno, timokatalog(j).paroxi, timokatalog(j).synolo, timokatalog(j).tourist, timokatalog(j).xrewsi)
    '            Catch ex As OleDb.OleDbException
    '                MsgBox("Η Αποθήκευση των αλλαγών των τιμών απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
    '                'sender.enabled = True
    '                'Me.Cursor = Cursors.Default
    '                'Exit Sub
    '            End Try
    '        Next
    '    End If
    'End Sub

    Private Sub DwmTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmTbx.Leave
        Dim count, j As Int16
        Dim anaforaDwm, info As String
        Dim afixi, anaxwrisi As Date
        anaforaDwm = "Status Δωματίου " + sender.text + " :"
        If Not sender.text.Equals("") Then
            afixi = DateTimePicker2.Value.Date
            anaxwrisi = DateTimePicker3.Value.AddDays(-1).Date

            Try
                Me.Cursor = Cursors.WaitCursor

                Me.StatusTableAdapter.StatusDwmatiouByDiamoni(Me.DbhotelDataSet.status, kwdikoKratisisDB, sender.text, afixi, afixi, kwdikoKratisisDB, sender.text, anaxwrisi, anaxwrisi, kwdikoKratisisDB, sender.text, afixi, anaxwrisi)

                If Me.DbhotelDataSet.status.Count <> 0 Then

                    For j = 0 To Me.DbhotelDataSet.status.Count - 1
                        If Me.DbhotelDataSet.status(j).dwmatiostatus = 5 Then
                            info = "Κατειλημμένο " + Me.DbhotelDataSet.status(j).enarxi + " μέχρι και " + Me.DbhotelDataSet.status(j).lixi + " (Αρ.Κρατ.: " + Me.DbhotelDataSet.status(j).arithmos.ToString + ")"

                            anaforaDwm = anaforaDwm + ChrW(13) + info


                            'MsgBox(" Το Δωμάτιο " + DwmTbx.Text + " είναι κατειλημμένο!", MsgBoxStyle.Information, "winfo\nikEl.")
                            'Exit Sub
                        ElseIf (Me.DbhotelDataSet.status(j).dwmatiostatus = 1) Then
                            info = "Reservation " + Me.DbhotelDataSet.status(j).enarxi + " μέχρι και " + Me.DbhotelDataSet.status(j).lixi + " (Αρ.Κρατ.: " + Me.DbhotelDataSet.status(j).arithmos.ToString + ")"
                            anaforaDwm = anaforaDwm + ChrW(13) + info
                            'MsgBox(" Υπάρχει Reservation για το Δωμάτιο " + DwmTbx.Text + " !", MsgBoxStyle.Information, "winfo\nikEl.")
                            'Exit Sub
                        End If
                    Next
                    MsgBox(anaforaDwm, MsgBoxStyle.Information, "winfo\nikEl.")
                Else
                    count = Me.DwmatiaTableAdapter.ExistArDwmatiou(sender.text)
                    If count = 0 And Not DwmTbx.Text.Equals("OV-BOOK") Then
                        MsgBox(" Δεν υπάρχει αυτό το Δωμάτιο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.clear()
                        sender.focus()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        count = 0
                        If currentklines > 0 Or currenttipos > 0 Then
                            count = Me.DwmatiaTableAdapter.IstDwmatioVomKatigoria(sender.text, currenttipos, sender.text, currentklines)
                            If count = 0 Then
                                MsgBox(" Δωμάτιο άλλης Κατηγορίας !", MsgBoxStyle.Information, "winfo\nikEl.")
                            End If
                        End If
                    End If
                End If

            Catch ex As System.Exception
                Me.Cursor = Cursors.Default
                System.Windows.Forms.MessageBox.Show(ex.Message)

            End Try
            Me.Cursor = Cursors.Default

        End If
    End Sub
    Private Sub DwmatFreeBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmatFreeBtn.Click
        Dim klines, tipos As Integer
        Dim index As Int16
        Dim dwmArith As String

        Try
            klines = Me.get_kwd_klins_byname(KlinesCbx.SelectedItem.ToString)
        Catch ex As NullReferenceException
            klines = 0
        End Try
        If klines = -1 Then
            klines = 0
        End If
        Try
            tipos = Me.get_kwd_tipos_byname(TipiCbx.SelectedItem.ToString)
        Catch ex As Exception
            tipos = 0
        End Try
        If tipos = -1 Then
            tipos = 0
        End If
        Dim form1 As New FreeDwmatia(DateTimePicker2.Value.Date, DateTimePicker3.Value.Date.AddDays(-1), klines, tipos)
        'form1.Text = "Ελεύθερα Δωμάτια " + DateTimePicker2.Value.Date + "-" + DateTimePicker3.Value.Date
        form1.ShowDialog()
        dwmArith = form1.return_arithmo_dwmatiou()
        If dwmArith <> Nothing Then
            DwmTbx.Text = form1.return_arithmo_dwmatiou()
            'DOMISI-> apenergopoiisi klinwn!!!
            'If klines = 0 Then
            '    klines = form1.return_klines_dwmatiou
            '    index = get_index_klines(klines)
            '    KlinesCbx.SelectedIndex = index + 1
            'End If
            If tipos = 0 Then
                tipos = form1.return_tipos_dwmatiou()
                index = get_index_tipos(tipos)
                TipiCbx.SelectedIndex = index + 1
            End If
        End If


        form1.Dispose()

    End Sub
    Private Sub DwmSucheImeromBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmSucheImeromBtn.Click
        Dim klines, tipos As Integer
        Dim dwmArith As String
        Dim index As Int16
        Try
            klines = Me.get_kwd_klins_byname(KlinesCbx.SelectedItem.ToString)
        Catch ex As NullReferenceException
            klines = 0
        End Try
        If klines = -1 Then
            klines = 0
        End If
        Try
            tipos = Me.get_kwd_tipos_byname(TipiCbx.SelectedItem.ToString)
        Catch ex As Exception
            tipos = 0
        End Try
        If tipos = -1 Then
            tipos = 0
        End If
        Dim form1 As New FreeDwmatImerom(klines, tipos, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date.AddDays(-1))
        'form1.Text = "Ελεύθερα Δωμάτια " + DateTimePicker2.Value.Date + "-" + DateTimePicker3.Value.Date
        form1.ShowDialog()
        dwmArith = form1.return_arithmo_dwmatiou()
        If dwmArith <> Nothing Then
            DwmTbx.Text = form1.return_arithmo_dwmatiou()
            'DOMISI-> apenergopoiisi klinwn!!!
            'If klines = 0 Then
            '    klines = form1.return_klines_dwmatiou
            '    index = get_index_klines(klines)
            '    KlinesCbx.SelectedIndex = index + 1
            'End If
            If tipos = 0 Then
                tipos = form1.return_tipos_dwmatiou()
                index = get_index_tipos(tipos)
                TipiCbx.SelectedIndex = index + 1
            End If
        End If


        form1.Dispose()
    End Sub
    Private Sub DwmatiaKratisisBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmatiaKratisisBtn.Click
        'imeromErgasias = imeromErgasias.AddDays(+3)
        If kwdikoKratisisDB <> -1 Then
            Dim form1 As New DwmatiaKratisis(kwdikoKratisisDB, Me.DbhotelDataSet.kratiseis(0).afixi, Me.DbhotelDataSet.kratiseis(0).anaxwrisi, Me.DbhotelDataSet.kratiseis(0).checkin)
            form1.Text = "Δωμάτια Διαμονής Κράτησης " + Me.DbhotelDataSet.kratiseis(0).arithmos.ToString
            form1.ShowDialog()
            form1.Dispose()
        End If

    End Sub
    Private Sub paidia_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim form As New PaidiaFrm(kwdikoKratisisDB)
        Dim j, count As Int16
        Dim find() As Control

        If kwdikoKratisisDB <> -1 Then
            form.ShowDialog()

            form.Dispose()
            Me.PaidiaTableAdapter.FillByKratisi(Me.DbhotelDataSet.paidia, kwdikoKratisisDB)

            If Me.DbhotelDataSet.paidia.Count <= 3 Then
                count = Me.DbhotelDataSet.paidia.Count
            Else
                count = 3
            End If
            PaidiTbx1.Clear()
            PaidiTbx2.Clear()
            PaidiTbx3.Clear()
            CotTbx1.Clear()
            CotTbx2.Clear()
            CotTbx3.Clear()
            For j = 0 To count - 1
                find = Kratiseis2Pnl.Controls.Find("CotTbx" + (j + 1).ToString, False)
                find(0).Text = Me.DbhotelDataSet.paidia(j).cot
                find = Kratiseis2Pnl.Controls.Find("PaidiTbx" + (j + 1).ToString, False)
                find(0).Text = Me.DbhotelDataSet.paidia(j).ilikia
            Next
        Else
            MsgBox(" Υπάρχει η Δυνατότητα εισαγωγής πλέον των 2 Παιδιών: Εισάγετε τα 2 πρώτα παιδιά στα 2 αντίστοιχα πεδία, " & vbCrLf & " ολοκληρώστε την εισαγωγή της νέας κράτησης με αποθήκευση και έπειτα μπορείτε να εισάγετε και άλλα Παιδιά" & vbCrLf & " πατώντας αυτό το κουμπί ξανά ! ", MsgBoxStyle.Information, "winfo\nikEl.")
        End If
    End Sub
    Private Sub update_paidia()
        Dim find1(), find2() As Control
        Dim j, i, count, moeglichNeu As Int16
        Dim neuPaidi As Boolean = False
        'Me.EnilikesTableAdapter.FillByKratisi(Me.DbhotelDataSet.enilikes, kwdikoKratisisDB)

        Me.PaidiaTableAdapter.FillByKratisi(Me.DbhotelDataSet.paidia, kwdikoKratisisDB)
        If Me.DbhotelDataSet.paidia.Count >= 3 Then
            count = Me.DbhotelDataSet.paidia.Count
        ElseIf Me.DbhotelDataSet.paidia.Count = 2 Then
            count = 2
            neuPaidi = True
            moeglichNeu = 1
        ElseIf Me.DbhotelDataSet.paidia.Count = 1 Then
            count = 1
            neuPaidi = True
            moeglichNeu = 2
        ElseIf Me.DbhotelDataSet.paidia.Count = 0 Then
            neuPaidi = True
            moeglichNeu = 3
        End If
        For j = 0 To count - 1
            find1 = Kratiseis2Pnl.Controls.Find("PaidiTbx" + (j + 1).ToString, False)
            find2 = Kratiseis2Pnl.Controls.Find("CotTbx" + (j + 1).ToString, False)
            Try
                If LTrim(find1(0).Text) <> LTrim(Me.DbhotelDataSet.paidia(j).ilikia) Or LTrim(find2(0).Text) <> LTrim(Me.DbhotelDataSet.paidia(j).cot) Then
                    If LTrim(find1(0).Text).Length <> 0 And LTrim(find1(0).Text) > 0 Then
                        Me.PaidiaTableAdapter.UpdatePaidi(LTrim(find2(0).Text), LTrim(find1(0).Text), Me.DbhotelDataSet.paidia(j).kwd)
                    ElseIf LTrim(find1(0).Text).Equals("0") Then
                        Me.PaidiaTableAdapter.DeletePaidi(Me.DbhotelDataSet.paidia(j).kwd)
                    End If
                End If
            Catch ex As OleDb.OleDbException
                MsgBox("Η Αποθήκευση των αλλαγών στα παιδιά απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                'If LTrim(find1(0).Text).Length <> 0 Then
                '    Me.PaidiaTableAdapter.InsertPaidi(kwdikoKratisisDB, LTrim(find2(0).Text), LTrim(find1(0).Text))
                'End If
            End Try
        Next
        If neuPaidi Then
            For i = j To j + moeglichNeu - 1
                find1 = Kratiseis2Pnl.Controls.Find("PaidiTbx" + (i + 1).ToString, False)
                find2 = Kratiseis2Pnl.Controls.Find("CotTbx" + (i + 1).ToString, False)
                If LTrim(find1(0).Text).Length <> 0 AndAlso LTrim(find1(0).Text) > 0 Then
                    Me.PaidiaTableAdapter.InsertPaidi(kwdikoKratisisDB, LTrim(find2(0).Text), LTrim(find1(0).Text))
                End If
            Next
        End If
    End Sub
    Private Sub KwdEthnikot_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kwdEthnik1.Leave, kwdEthnik2.Leave
        Try

            If CType(sender.text, Integer) > 0 Then

                Me.EthnikotitesTableAdapter.FillByKwdiko(Me.DbhotelDataSet.ethnikotites, CType(sender.text, Integer))
                If Me.DbhotelDataSet.ethnikotites.Count = 1 Then
                    If sender.name.Equals("kwdEthnik1") Then
                        kwdEthnik1.Text = Me.DbhotelDataSet.ethnikotites(0).kwd
                        EthnKwd1.Text = Me.DbhotelDataSet.ethnikotites(0).kwd
                        EthnikTbx1.Text = Me.DbhotelDataSet.ethnikotites(0).sintomeusi
                    Else
                        kwdEthnik2.Text = Me.DbhotelDataSet.ethnikotites(0).kwd
                        EthnKwd2.Text = Me.DbhotelDataSet.ethnikotites(0).kwd
                        EthnikTbx2.Text = Me.DbhotelDataSet.ethnikotites(0).sintomeusi
                    End If
                Else
                    MsgBox("Δεν επιλέχθηκε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    If sender.name.Equals("kwdEthnik1") Then
                        If EthnKwd1.Text = 0 Then
                            EthnikTbx1.Text = "<κλίκ εδώ>"
                            sender.clear()
                        Else
                            sender.text = EthnKwd1.Text
                        End If
                    ElseIf sender.name.Equals("kwdEthnik2") Then
                        If EthnKwd2.Text = 0 Then
                            EthnikTbx2.Text = "<κλίκ εδώ>"
                            sender.clear()
                        Else
                            sender.text = EthnKwd2.Text
                        End If
                    End If
                    TilefTbx.Focus()
                    Exit Sub
                End If
            Else
                MsgBox(" Δεν υπάρχει αυτός ο κωδικός Εθνικότητας ! (Επιλέξτε από λίστα κάνωντας κλίκ στο διπλανό πεδίο)", MsgBoxStyle.Information, "winfo\nikEl.")
                If sender.name.Equals("kwdEthnik1") Then
                    If EthnKwd1.Text = 0 Then
                        EthnikTbx1.Text = "<κλίκ εδώ>"
                        sender.clear()
                    Else
                        sender.text = EthnKwd1.Text
                    End If
                ElseIf sender.name.Equals("kwdEthnik2") Then
                    If EthnKwd2.Text = 0 Then
                        EthnikTbx2.Text = "<κλίκ εδώ>"
                        sender.clear()
                    Else
                        sender.text = EthnKwd2.Text
                    End If
                End If
                TilefTbx.Focus()
                Exit Sub
            End If
        Catch ex As InvalidCastException
            If Not sender.text.Equals("") Then
                MsgBox(" Δώστε κωδικό Εθνικότητας ή επιλέξτε από λίστα κάνωντας κλίκ στο διπλανό πεδίο !", MsgBoxStyle.Information, "winfo\nikEl.")
                sender.clear()
            Else
                If sender.name.Equals("kwdEthnik1") Then
                    If EthnKwd1.Text = 0 AndAlso EthnAnzTbx1.Text > 0 Then
                        EthnikTbx1.Text = "<κλίκ εδώ>"
                    ElseIf EthnKwd1.Text = 0 AndAlso EthnAnzTbx1.Text = 0 Then
                        sender.clear()
                    Else
                        sender.text = EthnKwd1.Text
                    End If
                ElseIf sender.name.Equals("kwdEthnik2") Then
                    If EthnKwd2.Text = 0 AndAlso EthnAnzTbx2.Text > 0 Then
                        EthnikTbx2.Text = "<κλίκ εδώ>"
                    ElseIf EthnKwd2.Text = 0 AndAlso EthnAnzTbx2.Text = 0 Then
                        sender.clear()
                    Else
                        sender.text = EthnKwd2.Text
                    End If
                End If
            End If

        End Try


    End Sub
    Private Sub EthnikTbx1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EthnikTbx1.Enter, EthnikTbx2.Enter
        Dim EthnForm As New EthnikotitesFrm()
        Dim EthnikKwd As Integer
        Dim ethnosSintom As String

        EthnForm.StartPosition = FormStartPosition.CenterParent
        EthnForm.ShowDialog()
        EthnikKwd = EthnForm.return_ethnos_kwdikos
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        'EthnKwd1.Clear()
        If EthnikKwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If sender.name.Equals("EthnikTbx1") Then
                If EthnKwd1.Text = 0 Then
                    EthnikTbx1.Text = "<κλίκ εδώ>"
                End If
            ElseIf sender.name.Equals("EthnikTbx2") Then
                If EthnKwd2.Text = 0 Then
                    EthnikTbx2.Text = "<κλίκ εδώ>"
                End If
            End If
            TilefTbx.Focus()
            Exit Sub
        Else
            If sender.name.Equals("EthnikTbx1") Then
                EthnKwd1.Text = EthnikKwd
                kwdEthnik1.Text = EthnikKwd
            ElseIf sender.name.Equals("EthnikTbx2") Then
                EthnKwd2.Text = EthnikKwd
                kwdEthnik2.Text = EthnikKwd
            End If
        End If
        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos

        ethnosSintom = EthnForm.return_ethnos_sintomeusi
        If ethnosSintom = Nothing Then
            If sender.name.Equals("EthnikTbx1") Then
                EthnikTbx1.Text = "<κλίκ εδώ>"
            ElseIf sender.name.Equals("EthnikTbx2") Then
                EthnikTbx2.Text = "<κλίκ εδώ>"
            End If
        Else
            If sender.name.Equals("EthnikTbx1") Then
                EthnikTbx1.Text = ethnosSintom
            ElseIf sender.name.Equals("EthnikTbx2") Then
                EthnikTbx2.Text = ethnosSintom
            End If
        End If
        EthnForm.Dispose()
        TilefTbx.Focus()
    End Sub

    Private Sub setze_sum_timokat()
        Dim i As Int16
        Dim sum, ekptosiPoso, timiImeras As Single

        For i = 0 To timokatalog.Length - 1
            sum = sum + timokatalog(i).synoloTemp
        Next
        timiImeras = rechne_timi_imeras()
        ekptosiPoso = rechne_ekptosi(sum, timiImeras)
        SynolLbl.Text = (sum - ekptosiPoso).ToString("N")
        EkptosiLbl.Text = "Έκπτωση: " + ekptosiPoso.ToString("N")
    End Sub
    Private Function rechne_timi_imeras() As Single
        Dim timiImeras As Single
        Try
            timiImeras = timokatalog(timokatalog.Length - 1).ypnosTemp + timokatalog(timokatalog.Length - 1).prwinoTemp + timokatalog(timokatalog.Length - 1).geumaTemp + timokatalog(timokatalog.Length - 1).deipnoTemp + timokatalog(timokatalog.Length - 1).paroxiTemp
        Catch ex As IndexOutOfRangeException
            MsgBox("Δεν υπάρχουν τιμές !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            Me.init_ekptoseis()
        End Try

        Return timiImeras
    End Function
    Private Function rechne_imeres_diamonis() As Single
        Dim i As Int16
        Dim sum As Single
        For i = 0 To timokatalog.Length - 1
            sum = sum + timokatalog(i).imeresTotal
        Next

        Return sum
    End Function
    Private Function rechne_ekptosi(ByVal synolo As Single, ByVal timiImeras As Single) As Single


        If ekptPososto <> 0 Then
            Return (synolo * ekptPososto / 100)

        ElseIf ekptPoso <> 0 Then

            Return (ekptPoso)

        ElseIf ekptFree <> 0 Then

            Return (ekptFree * timiImeras)

        ElseIf ekptCFee <> 0 Then
            Return -(ekptCFee * timiImeras)
        End If
        Return 0
    End Function
    Private Function rechne_ekptosi_vom_synola(ByVal synolo As Single, ByVal poso As Single, ByVal pososto As Single, ByVal free As Single, ByVal fee As Single) As Single
        Dim timiImeras As Single

        If ekptPososto <> 0 Then
            Return (synolo / (1 - ekptPososto / 100) - synolo)

        ElseIf ekptPoso <> 0 Then

            Return ekptPoso

        ElseIf ekptFree <> 0 Then
            timiImeras = rechne_timi_imeras()
            Return (ekptFree * timiImeras)

        ElseIf ekptCFee <> 0 Then
            timiImeras = rechne_timi_imeras()
            Return -(ekptCFee * timiImeras)
        End If
        Return 0
    End Function
    Public Sub init_ekptoseis()
        ekptPososto = 0
        ekptPoso = 0
        ekptFree = 0
        ekptCFee = 0
        Me.EkptosiLbl.Text = ""
        'EkptosiBtn.Visible = False
    End Sub
    Private Sub init_timokatalog()
        Dim i As Int16
        For i = 0 To timokatalog.Length - 1
            'timokatalog(i).status = 0
            timokatalog(i).kwdDB = -1
            timokatalog(i).tourist = -1
            timokatalog(i).simfonia = -1
            timokatalog(i).xrewsi = -1
            timokatalog(i).timi = -1
            timokatalog(i).apo = "1/1/" + etos.ToString
            timokatalog(i).mexri = "1/1/" + etos.ToString
            timokatalog(i).imeresTotal = 0
            timokatalog(i).imeresPlirom = 0
            timokatalog(i).ekptosi = 0
            timokatalog(i).ypnos = 0
            timokatalog(i).ypnosTemp = 0
            timokatalog(i).prwino = 0
            timokatalog(i).prwinoTemp = 0
            timokatalog(i).geuma = 0
            timokatalog(i).geumaTemp = 0
            timokatalog(i).deipno = 0
            timokatalog(i).deipnoTemp = 0
            timokatalog(i).paroxi = 0
            timokatalog(i).paroxiTemp = 0
            timokatalog(i).synolo = 0
            timokatalog(i).synoloTemp = 0
        Next
    End Sub
    Private Function ist_xrewsi_ok() As Boolean
        Dim index As Int16
        'Dim tempXrewsi As Integer
        For index = 0 To timokatalog.Length - 1

            If timokatalog(index).xrewsi = -1 Then
                Return False
            End If
            'If index = 0 Then
            '    tempXrewsi = timokatalog(index).xrewsi
            'ElseIf tempXrewsi <> timokatalog(index).xrewsi Then
            '    Return False
            'End If
        Next
        Return True

    End Function
    Private Sub ersetze_temp_vor_speichern()
        Dim index As Int16

        For index = 0 To timokatalog.Length - 1
            timokatalog(index).ypnos = timokatalog(index).ypnosTemp
            timokatalog(index).prwino = timokatalog(index).prwinoTemp
            timokatalog(index).geuma = timokatalog(index).geumaTemp
            timokatalog(index).deipno = timokatalog(index).deipnoTemp
            timokatalog(index).paroxi = timokatalog(index).paroxiTemp
            timokatalog(index).synolo = timokatalog(index).synoloTemp
        Next

    End Sub
    Private Function info_timiskratisis_by_kwdtimis(ByVal timi As Integer) As String
        Dim simf, xrews, klin, paid, info As String
        Dim kwdikosSimf As Integer
        'get_xrewsi_by_kwd(Me.DbhotelDataSet.times(i).xrewsi)
        Try
            kwdikosSimf = Me.TimesTableAdapter.GetSimfoniaByKwd(timi).ToString
            simf = Me.SimfoniesTableAdapter.GetAAByKwd(kwdikosSimf)
            xrews = get_xrewsi_by_kwd(Me.TimesTableAdapter.GetXrewsiByKwd(timi))
            klin = Me.TimesTableAdapter.GetKlinesByKwd(timi)
            paid = Me.TimesTableAdapter.GetPaidiByklines(timi)
            info = "[(Συμφ:" + simf + ")(Χρ.:" + xrews + ")(Κλ.:" + klin + ")(Παιδ:" + paid + ")]"
        Catch ex As InvalidOperationException
            info = Nothing
        End Try

        Return info
    End Function
    Private Function info_timiskratisis_by_xrewsi(ByVal xrews As Integer) As String
        Dim info As String
        'get_xrewsi_by_kwd(Me.DbhotelDataSet.times(i).xrewsi)
        Try
            info = get_xrewsi_by_kwd(xrews)
            info = "[(Χρ.:" + info + ")]"
        Catch ex As InvalidOperationException
            info = "--"
        End Try

        Return info
    End Function
    Private Function get_index_timeskratisis(ByVal kwdTourPerDB As Integer) As Int16
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.timeskratisis.Count - 1
            If Me.DbhotelDataSet.timeskratisis(j).touristperiod = kwdTourPerDB Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Function get_ethikotita_by_kwdiko(ByVal kwd As Integer) As String
        Try
            Return Me.EthnikotitesTableAdapter.GetSintomeusiByKwd(kwd)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function get_praktoreio_by_kwdiko(ByVal kwd As Integer) As String

        Try
            Return Me.PraktoreiaTableAdapter.GetEponimiaByKwd(kwd)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function get_xrewsi_by_kwd(ByVal kwdikos As Integer) As String
        Try
            Return Me.XrewseisTableAdapter.GetXrewsiByKwd(kwdikos)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function get_aa_simbolaiou_by_kwd(ByVal kwdikos As Integer) As Int16
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If Me.DbhotelDataSet.simbolaia(j).kwd = kwdikos Then
                Return Me.DbhotelDataSet.simbolaia(j).aasimbolaiou
            End If
        Next
        Return -1

    End Function
    Private Function get_aasimbolaiou_by_kwd(ByVal kwdikos As Integer) As String
        Try
            Return Me.SimbolaiaTableAdapter.GetAAByKwd(kwdikos)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function get_kwd_simbol_byAA(ByVal aa As String) As Integer

        Try

            Return Me.SimbolaiaTableAdapter.GetKwdByAaPraktEtos(aa, praktoreiokwd, etos)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Function get_kwd_simbolaiou_by_aa(ByVal aa As Int16) As Integer
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If Me.DbhotelDataSet.simbolaia(j).aasimbolaiou = aa Then
                Return Me.DbhotelDataSet.simbolaia(j).kwd
            End If
        Next
        Return -1
    End Function

    Private Function get_perigrafi_simb_by_aa(ByVal aa As Int16) As String
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If Me.DbhotelDataSet.simbolaia(j).aasimbolaiou = aa Then
                Return Me.DbhotelDataSet.simbolaia(j).perigrafi
            End If
        Next
        Return ""
    End Function
    Private Function get_kwd_klins_byname(ByVal name As String) As Integer
        Try
            Return Me.KlinesTableAdapter.GetKwdByPerigrafi(name)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Private Function get_kwd_tipos_byname(ByVal name As String) As Integer
        Try
            Return Me.TipoiTableAdapter.GetKwdByTipo(name)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    Private Function get_index_v_timokatalog(ByVal tourist As Integer)
        Dim j As Int16
        For j = 0 To timokatalog.Length - 1
            If timokatalog(j).tourist = tourist Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Function get_index_v_timokatalog_2(ByVal timeskratKwd As Integer)
        Dim j As Int16
        For j = 0 To timokatalog.Length - 1
            If timokatalog(j).kwdDB = timeskratKwd Then
                Return j
            End If
        Next
        Return -1

    End Function
    Private Function get_klines_by_kwdikos(ByVal kwdikos As Integer) As String
        Dim i As Int16
        For i = 0 To Me.DbhotelDataSet.klines.Count - 1
            If kwdikos = Me.DbhotelDataSet.klines(i).kwd Then
                Return Me.DbhotelDataSet.klines(i).perigrafi
            End If
        Next
        Return Nothing
    End Function
    Private Function get_tipos_by_kwdikos(ByVal kwdikos As Integer) As String
        'Dim i As Int16
        Try
            Return Me.TipoiTableAdapter.GetTiposByKwdiko(kwdikos)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim form As New ParametroiF

        form.Show()
    End Sub
    'Status=2 DIAMENWNTES!!!!!!!!!!!!!!!!

    Private Sub Tbx_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnilikTbx.Leave, PaidiTbx1.Leave,
    PaidiTbx2.Leave, PaidiTbx3.Leave, EthnAnzTbx2.Leave
        Dim k As Byte = 0
        Try
            If CType(sender.text, Int16) < 0 Then
                sender.text = Math.Abs(CType(sender.text, Int16))
            End If
        Catch ex As InvalidCastException
            sender.text = 0
        End Try
        If PaidiTbx1.Text <> 0 Then
            k = k + 1
        End If
        If PaidiTbx2.Text <> 0 Then
            k = k + 1
        End If
        If PaidiTbx3.Text <> 0 Then
            k = k + 1
        End If
        If sender.name.Equals("EnilikTbx") Then
            If EnilikTbx.Text = 0 Then
                EthnKwd1.Text = 0
                kwdEthnik1.Clear()
                EthnikTbx1.Clear()
                EthnKwd2.Text = 0
                EthnikTbx2.Clear()
                kwdEthnik2.Clear()
                EthnAnzTbx1.Text = 0
                EthnAnzTbx2.Text = 0
            End If
        End If
        If sender.name.Equals("EthnAnzTbx2") Then
            If sender.text = 0 Then
                EthnKwd2.Text = 0
                kwdEthnik2.Clear()
                EthnikTbx2.Clear()
            End If
        End If
        If EnilikTbx.Text + k >= EthnAnzTbx2.Text Then
            EthnAnzTbx1.Text = EnilikTbx.Text + k - EthnAnzTbx2.Text
        Else
            EthnAnzTbx1.Text = 0
            EthnAnzTbx1.Focus()
        End If
    End Sub
    Private Sub CotTbx1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CotTbx1.Leave, CotTbx2.Leave
        'Dim k As Byte = 0
        'Try
        '    If CType(sender.text, Int16) < 0 Then
        '        sender.text = Math.Abs(CType(sender.text, Int16))
        '    End If
        'Catch ex As InvalidCastException
        '    sender.text = 0
        'End Try
    End Sub
    Private Sub EthnAnzTbx1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EthnAnzTbx1.Leave
        Dim k As Byte = 0
        Try
            If CType(sender.text, Int16) < 0 Then
                sender.text = Math.Abs(CType(sender.text, Int16))
            End If
        Catch ex As InvalidCastException
            sender.text = 0

        End Try
        If sender.text = 0 Then
            EthnikTbx1.Clear()
            kwdEthnik1.Clear()
            EthnKwd1.Text = 0
        End If
        If PaidiTbx1.Text <> 0 Then
            k = k + 1
        End If
        If PaidiTbx2.Text <> 0 Then
            k = k + 1
        End If
        If PaidiTbx3.Text <> 0 Then
            k = k + 1
        End If
        If EthnAnzTbx1.Text <= EnilikTbx.Text + k Then
            EthnAnzTbx2.Text = EnilikTbx.Text + k - EthnAnzTbx1.Text
        Else
            EthnAnzTbx2.Text = 0
            EthnKwd2.Text = 0
            kwdEthnik1.Focus()
            'EthnAnzTbx2.Focus()
        End If
    End Sub
    Private Sub TextBox15_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimetTbx.Leave, ProkatTbx.Leave
        Dim y As Single = 0
        Try
            If CType(sender.text, Integer) Then
                y = sender.text
                sender.text = y.ToString("F")
            End If
        Catch ex As InvalidCastException
            sender.text = y.ToString("F")
        End Try
    End Sub
    Private Sub KwdPraktTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KwdPraktTbx1.Leave, KwdPraktTbx2.Leave
        Try
            If CType(sender.text, Integer) > 0 Then
                If status = 1 Or status = 2 And isDBEintrag Then
                    Dim count As Int16
                    count = Me.PraktoreiaTableAdapter.ExistPraktoreia(sender.text)
                    If count <> 0 Then
                        Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, sender.text)
                    Else
                        MsgBox("O κωδικός δεν αντιστοιχεί σε  Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.clear()
                        'sender.focus()
                        Exit Sub
                    End If
                    'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
                    If sender.name.Equals("KwdPraktTbx1") AndAlso praktoreiokwd <> sender.text Then
                        Kratiseis4Pnl.Controls.Clear()
                        ButtonsPnl.Controls.Clear()
                        If status = 2 AndAlso Me.DbhotelDataSet.praktoreia(0).kwd <> praktoreiokwd Then 'diamewntes allagi Praktoreiou kata'AndAlso currentAfixi < imeromErgasias
                            'thn diarkeia diamonis (oxi 1 mera)->touristperios stis timeskratiseis DB pairnei -1 
                            MsgBox(" Με την Αλλαγή του Πρακτορείου πρέπει να ελεχθούν ξανά οι τιμές !", MsgBoxStyle.Information, "winfo\nikEl.")
                            praktoreiokwdValue = Me.DbhotelDataSet.praktoreia(0).kwd ' se autin tin periptwsi 
                        Else
                            praktoreiokwd = Me.DbhotelDataSet.praktoreia(0).kwd
                        End If
                        'praktoreiokwd = Me.DbhotelDataSet.praktoreia(0).kwd
                        praktortimolkwd = Me.DbhotelDataSet.praktoreia(0).kwd
                        currentsimbolaio = -1
                        'currentsimbolaioValue = -1
                        If KlinesCbx.Items.Count = 0 OrElse TipiCbx.Items.Count = 0 Then
                            init_klines_tipoi_cboxen()
                        Else
                            KlinesCbx.SelectedIndex = -1
                            TipiCbx.SelectedIndex = -1
                        End If
                        SimbCbx.Items.Clear()
                        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

                        fuehle_simbol_cboxen()
                        ReDim timokatalog(-1)
                        'End If
                        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos
                        currenttipos = 0
                        currentklines = 0

                        Dim praktname As String

                        praktname = Me.DbhotelDataSet.praktoreia(0).eponimia

                        PraktTbx.Text = praktname
                        PraktTimolTbx.Text = praktname
                        KwdPraktTbx2.Text = KwdPraktTbx1.Text
                        If isDBEintrag Then
                            Me.TouristperiodoiTableAdapter.FillBySimbAnaxwrisiAfixi(Me.DbhotelDataSet.touristperiodoi, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker2.Value.Date,
                                           currentsimbolaio, DateTimePicker3.Value.AddDays(-1).Date, DateTimePicker3.Value.AddDays(-1).Date, currentsimbolaio, DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date)

                        End If
                        VoucherTbx.Focus()
                        If SimbCbx.Items.Count <> 0 Then
                            SimbCbx.SelectedIndex = 0
                        End If
                    Else
                        PraktTimolTbx.Text = Me.DbhotelDataSet.praktoreia(0).eponimia
                        praktortimolkwd = Me.DbhotelDataSet.praktoreia(0).kwd
                    End If
                Else
                    MsgBox("Δεν επιλέχθηκε Διαμένων: Πατήστε τον φακό για επιλογή απο Λίστα ή εισάγετε τον Αρ.Κράτησης στο αντίστοιχο πεδίο και μετά πατήστε τον φακό!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If

            End If
        Catch ex As InvalidCastException
            If Not sender.text.Equals("") Then
                MsgBox(" Δώστε Αριθμό !", MsgBoxStyle.Information, "winfo\nikEl.")
                sender.clear()
            End If

        End Try
    End Sub
    Private Function pruefe_ob_touristikes_periodoi_richtig() As Boolean
        Dim startIndex As Int16
        Dim istOK As Boolean = True

        Do Until startIndex > Me.DbhotelDataSet.touristperiodoi.Count - 1
            'posa eintraege 
            'firstIndex = startIndex
            If startIndex < Me.DbhotelDataSet.touristperiodoi.Count - 1 Then
                'gia kathemia kRatisi
                While Me.DbhotelDataSet.touristperiodoi(startIndex).mexri.AddDays(1) = Me.DbhotelDataSet.touristperiodoi(startIndex + 1).apo
                    startIndex = startIndex + 1
                    If startIndex + 1 > Me.DbhotelDataSet.touristperiodoi.Count - 1 Then
                        Exit Do
                    End If
                End While
                istOK = False
                Exit Do
            Else
                startIndex = startIndex + 1
                Exit Do
            End If
        Loop

        If istOK Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function get_index_von_pliromicbox(ByVal pliromi As String) As Byte
        Dim j As Int16
        For j = 0 To PliromCbx.Items.Count - 1
            If PliromCbx.Items(j).ToString = Trim(pliromi) Then
                Return j
            End If
        Next
        Return Nothing
    End Function
    Private Sub PliromiCbx_Update(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PliromCbx.TextUpdate

        MsgBox("Πατήστε το βελάκι δεξιά για επιλογή  !", MsgBoxStyle.Information, "winfo\nikEl.")
        PliromCbx.SelectedIndex = 0

    End Sub
    Private Function get_index_klines(ByVal kwdikos As Integer) As Int16
        Dim i As Int16
        For i = 0 To Me.DbhotelDataSet.klines.Count - 1
            If Me.DbhotelDataSet.klines(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function get_index_tipos(ByVal kwdikos As Integer) As Int16
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1
            If Me.DbhotelDataSet.tipoi(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function get_index_simbolaio_cbox(ByVal simbolaio As String) As Int16
        Dim i As Int16

        For i = 0 To Me.SimbCbx.Items.Count - 1
            If Me.SimbCbx.Items(i).ToString = simbolaio Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub selectall(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SelectAll()

    End Sub
    Private Sub pruefe_yperbasi_allotment()
        Dim yperbOK As Boolean
        Dim form1 As New AllotmentYperbasi(DateTimePicker2.Value.Date, DateTimePicker3.Value.AddDays(-1).Date, currentklines, currenttipos, currentsimbolaio, CheckBox1.Checked)

        yperbOK = form1.ist_yeprabasi
        If yperbOK Then
            form1.zeig_yperbasi_form()
            form1.ShowDialog()
        End If
        '
        form1.Dispose()
    End Sub
    Private Function get_sesion() As Integer
        Randomize()
        ' Generate random value between 1 and 6.
        Return -CInt(Int((1000000 * Rnd()) + 1))

    End Function

#End Region

    '**************************ektiposi bibliou portas**********ektiposi bibliou portas**************************************ektiposi bibliou portas***
    '**************************ektiposi bibliou portas**********ektiposi bibliou portas**************************************ektiposi bibliou portas***
    '**************************ektiposi bibliou portas**********ektiposi bibliou portas**************************************ektiposi bibliou portas***
    '**************************ektiposi bibliou portas**********ektiposi bibliou portas**************************************ektiposi bibliou portas***
    Private Sub ektiposi_bibliou_portas_koutsour()


        EtiketaLbl.Text = "Εκτύπωση Βιβλίου Πόρτας Κουτσουράκη"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaLbl.Location = New Point(BiblPortasPnl.Width / 8, 25)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        KoutsPnl.Location = New Point(40, EtiketaPnl.Height)
        KoutsPnl.Size = New Point(336, 152)
        If Me.DbhotelDataSet.etaireia(0).biblportastimes Then
            MorfiRdb1.Checked = True
        Else
            MorfiRdb2.Checked = True
        End If
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(KoutsPnl)
    End Sub
    Private Sub KoutsPnlPortasBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KoutsBtn.Click
        Dim ok As Boolean = False
        Dim biblioPortas As New BiblioPortasFormclass(imeromErgasias, True, False, 2, 2)

        Try
            Me.Cursor = Cursors.WaitCursor
            'EDW OUSIASTIKA GINETAI EGGRAFI STO BIBLIO PORTAS KAI TO KAI TO CHECKOUT!
            ok = biblioPortas.biblPortas() ' ok ola kala->(px den exei ginei allagi imeromergasias apo allon Usser)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default

        biblioPortas.Dispose()
        'exei ginei gesetzt to flag gai tin ektiposi->reload gia ananewsi
        Me.EtaireiaTableAdapter.SetFlagsEktiposewn(0, 0, imeromErgasias)
        Me.DbhotelDataSet.etaireia(0).ektportasflag = 0
        Me.DbhotelDataSet.etaireia(0).ektportasapyflag = 0

    End Sub
    Private Sub ektiposi_bibliou_portas_house_europe()


        EtiketaLbl.Text = "Εκτύπωση Βιβλίου Πόρτας House of Europe"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaLbl.Location = New Point(BiblPortasPnl.Width / 8, 25)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        HouseEuropePnl.Location = New Point(40, EtiketaPnl.Height)
        HouseEuropePnl.Size = New Point(336, 212)
        If Me.DbhotelDataSet.etaireia(0).biblportastimes Then
            MorfiRdb1.Checked = True
        Else
            MorfiRdb2.Checked = True
        End If
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(HouseEuropePnl)
    End Sub
    Private Sub HouseEuropeiblPortasBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HouseEuropeBtn.Click
        Dim ok As Boolean = False
        Dim biblioPortas As New BiblioPortasFormclass(imeromErgasias, True, False, 2, 1)

        Try
            Me.Cursor = Cursors.WaitCursor
            'EDW OUSIASTIKA GINETAI EGGRAFI STO BIBLIO PORTAS KAI TO KAI TO CHECKOUT!
            ok = biblioPortas.biblPortas() ' ok ola kala->(px den exei ginei allagi imeromergasias apo allon Usser)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default

        biblioPortas.Dispose()
        'exei ginei gesetzt to flag gai tin ektiposi->reload gia ananewsi
        Me.EtaireiaTableAdapter.SetFlagsEktiposewn(0, 0, imeromErgasias)
        Me.DbhotelDataSet.etaireia(0).ektportasflag = 0
        Me.DbhotelDataSet.etaireia(0).ektportasapyflag = 0

    End Sub







    Private Sub ektiposi_bibliou_portas()


        EtiketaLbl.Text = "Εκτύπωση Βιβλίου Πόρτας"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaLbl.Location = New Point(BiblPortasPnl.Width / 8, 25)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        BiblPortasPnl.Location = New Point(40, EtiketaPnl.Height)
        Me.BiblPortasPnl.Size = New Point(336, 212)
        If Me.DbhotelDataSet.etaireia(0).biblportastimes Then
            MorfiRdb1.Checked = True
        Else
            MorfiRdb2.Checked = True
        End If
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(BiblPortasPnl)
    End Sub

    Private Sub BiblPortasBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiblPortasBtn.Click
        Dim ok As Boolean = False
        Dim biblioPortas As New BiblioPortasFormclass(imeromErgasias, MorfiRdb1.Checked, TheorimRdb.Checked, 2, 0)

        Try
            Me.Cursor = Cursors.WaitCursor
            'EDW OUSIASTIKA GINETAI EGGRAFI STO BIBLIO PORTAS KAI TO KAI TO CHECKOUT!
            ok = biblioPortas.biblPortas() ' ok ola kala->(px den exei ginei allagi imeromergasias apo allon Usser)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default

        biblioPortas.Dispose()
        'exei ginei gesetzt to flag gai tin ektiposi->reload gia ananewsi
        If TheorimRdb.Checked Then
            If ok Then
                Me.DbhotelDataSet.etaireia(0).ektportasflag = 1
            Else
                Me.EtaireiaTableAdapter.SetFlagsEktiposewn(0, 0, imeromErgasias)
                Me.DbhotelDataSet.etaireia(0).ektportasflag = 0
                Me.DbhotelDataSet.etaireia(0).ektportasapyflag = 0
            End If

        End If

    End Sub

    Private Sub ektiposi_atheorita_apy()

        Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Βιβλίου Πόρτας για αθεώρητα Α.Π.Υ."
        EtiketaLbl.Location = New Point(BiblPortApyPnl.Width / 8, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        BiblPortApyPnl.Location = New Point(140, EtiketaPnl.Height)
        BiblPortApyPnl.Size = New Point(336, 180)
        BiblPortApyPck.Value = imeromErgasias
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(BiblPortApyPnl)
    End Sub
    Private Sub BiblPortApyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BiblPortApyBtn.Click
        Dim j As Int16
        Dim countDB As Int16
        Me.DbhotelDataSet.timologia.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Clear()


        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = BiblPortApyPck.Value.Date

        Me.TimologiaTableAdapter.FillByImerominiaAkyr(Me.DbhotelDataSet.timologia, BiblPortApyPck.Value.Date, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                Me.DbhotelDataSet.timologia(j).sumkathposa = -Math.Abs(Me.DbhotelDataSet.timologia(j).sumkathposa)
                Me.DbhotelDataSet.timologia(j).fpa = -Math.Abs(Me.DbhotelDataSet.timologia(j).fpa)
                Me.DbhotelDataSet.timologia(j).synola = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
            End If
        Next
        If Me.DbhotelDataSet.timologia.Count <> 0 Then 'XRISIMOPOIW AUTA TA 2 FELDER GIA TA SE/APO METAFORA STIN EKTIPOSI
            Me.DbhotelDataSet.timologia(0).kwd = -1
            Me.DbhotelDataSet.timologia(Me.DbhotelDataSet.timologia.Count - 1).identifikation = -1
            proepiskopisi_biblioportas_apy()
        Else
            proepiskopisi_biblioportas_apy_keno()
            'MsgBox(" Δεν έχουν εκδοθεί Τιμολόγια αυτήν την Ημερομηνία !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If

        If Me.DbhotelDataSet.etaireia(0).ektportasflag = 1 AndAlso BiblPortApyPck.Value = imeromErgasias Then 'wenn Biblio Portas Exei ektipothei->tote kai to allo flag auf 1 setzen
            countDB = Me.EtaireiaTableAdapter.SetFlagEktiposiBiblPortApy(1, imeromErgasias)
            If countDB = 1 Then
                Me.DbhotelDataSet.etaireia(0).ektportasapyflag = 1 'flag auf 1 setzen!
            Else 'kata pasa pithanotita exei allaskei i imeromergasias apo allon user
                MsgBox(" Παρουσιάστηκε πρόβλημα κατά την Διαδικασία !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Me.Close()
            End If

        End If
    End Sub
    Private Sub proepiskopisi_biblioportas_apy()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioPortasApy()

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True
        Form1.ShowDialog()
        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    Private Sub proepiskopisi_biblioportas_apy_keno()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BiblioPortasApyKeno()

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        'CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True
        Form1.ShowDialog()
        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    Private Sub kleisimo_imeras()

        EtiketaLbl.Text = "Κλείσιμο Ημέρας"
        EtiketaLbl.Location = New Point(KleisimoPnl.Width / 5, 25)
        Try
            arrivalLbl.Text = imeromErgasias.AddDays(CType(daysbeforeTbx.Text, Int16) + 1).ToString("dd/MM/yyyy")
        Catch ex As InvalidCastException
            daysbeforeTbx.Text = 15
        End Try
        blinkLbl2.Text = ""
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        KleisimoPnl.Location = New Point(40, EtiketaPnl.Height)
        KleisimoPnl.Size = New Point(440, 250)
        KleisImerErgLbl.Text = imeromErgasias
        KleisimoPck1.Value = imeromErgasias.AddDays(1)
        EtiketaPnl.Controls.Add(EtiketaLbl)

        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(KleisimoPnl)

    End Sub


    Private Function fuhre_kleisimo_imeras_aus() As Boolean
        Dim countKrat As Int16
        Dim response As MsgBoxResult
        'ksanakanw reload gia na dw mpas kai alakse allos user ta flags
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'elegxos gia imerominia kai oti den exei entwmetaksu alaksei i imeromergasias apo allon user
        If KleisimoPck1.Value > imeromErgasias AndAlso Me.DbhotelDataSet.etaireia(0).imeromergasias = imeromErgasias Then

            countKrat = Me.KratiseisTableAdapter.GetAkopesAnaxwriseisByImerTimologiostatus(CType(KleisImerErgLbl.Text, Date), 0, 0)
            If countKrat <> 0 Then
                Me.EtaireiaTableAdapter.SetFlagsEktiposewn(0, 0, imeromErgasias)
                MsgBox("Υπάρχουν Αναχωρήσεις προς Τιμολόγηση ! " & vbCrLf & "Πρέπει να τις τιμολογήσετε στο Μενού <Εκδοση ΑΠΥ>  ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Return False
            End If
            Me.LogariasmoianaxwrountwnTableAdapter.FillAnexoflitAnaxwrforMazikiEkdGE(Me.DbhotelDataSet.logariasmoianaxwrountwn, New System.Nullable(Of Date)(CType(KleisImerErgLbl.Text, Date)), 0)
            If Me.DbhotelDataSet.logariasmoianaxwrountwn.Count <> 0 Then
                MsgBox("Υπάρχουν αναξόφλητοι Λογαριασμοί Πελατών με Ημερομηνία Αναχώρησης " + KleisImerErgLbl.Text + " !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Return False
            End If
            Me.KratiseisTableAdapter.FillAnamenwntesByAfixCheckinTimol(Me.DbhotelDataSet.kratiseis, CType(KleisImerErgLbl.Text, Date), False, 0)
            If Me.DbhotelDataSet.kratiseis.Count <> 0 Then
                Me.EtaireiaTableAdapter.SetFlagsEktiposewn(0, 0, CType(KleisImerErgLbl.Text, Date))
                MsgBox("Υπάρχουν εκρεμείς Αφίξεις ! " & vbCrLf & "Πρέπει να ελεχθούν στο Μενού <Έλεγχος Αφίξεων>  ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Return False
            End If
            If Me.DbhotelDataSet.etaireia(0).ektportasflag = 1 AndAlso Me.DbhotelDataSet.etaireia(0).imeromergasias = imeromErgasias Then ' AndAlso Me.DbhotelDataSet.etaireia(0).ektportasapyflag = 1
                response = MsgBox(" ΕΠΙΒΕΒΑΙΩΣΗ: Κλείσιμο :" + KleisImerErgLbl.Text & vbCrLf & "             Νέα Ημερομηνία :" + KleisimoPck1.Value.Date, MsgBoxStyle.YesNo, "winfo\nikEl.")
                If response = MsgBoxResult.Yes Then
                    Me.EtaireiaTableAdapter.SetAlagiImerasergasias(KleisimoPck1.Value.Date, CType(KleisImerErgLbl.Text, Date), 0, 0)
                    imeromErgasias = KleisimoPck1.Value.Date
                    KleisImerErgLbl.Text = imeromErgasias
                    KleisimoPck1.Value = imeromErgasias.AddDays(1)
                    Me.Text = "Κλείσιμο Ημέρας " + imeromErgasias
                Else
                    Return False
                End If
            Else
                MsgBox("Δεν έχουν γίνει όλες οι Εκτυπώσεις του Βιβλίου Πόρτας !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Return False
            End If
        Else
            MsgBox("Ελέγξτε την νέα Ημερομηνία !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            Return False
        End If
        Return True
    End Function
    Private Sub KleisimoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KleisimoBtn.Click
        Dim threadQuestion, threadDiamenontes, threadElegxos, threadElegxosPrakt As Threading.Thread 'threadQuestion,
        Try
            'myTimer2.Interval = 1000
            'myTimer2.Start()

            If Application.OpenForms().Count <> 2 Then
                MsgBox("Κλείστε τα ανοικτά παράθυρα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Exit Sub
            End If

            If fuhre_kleisimo_imeras_aus() Then
                EtiketaLbl.Text = "Wait....sending emails"
                blinkLbl2.Text = "Wait....sending emails........."

                Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
                Dim dwnatioadapter As New dbhotelDataSetTableAdapters.dwmatiaTableAdapter
                mailadapter.Fill(Me.DbhotelDataSet.Mail)

                'If questChk.Checked Then
                '    threadQuestion = SendMailQuestionare(mailadapter)
                '    While threadQuestion.IsAlive

                '    End While
                'End If
                Me.Cursor = Cursors.WaitCursor

                'If directChk.Checked Then
                '    threadDirections = SendMailwithDirections(mailadapter)

                '    While threadDirections.IsAlive

                '    End While

                'End If
                'If directChk.Checked Then
                '    threadDirections = SendMailwithDirectionsInk(mailadapter)

                '    While threadDirections.IsAlive

                '    End While

                'End If
                'If sendresidentsOK.Checked Then
                '    threadDiamenontes = SendMailtoDiamenontes(mailadapter)

                '    While threadDiamenontes.IsAlive

                '    End While

                'End If

                If kenaCkb.Checked Then
                    threadElegxos = SendMailElegxos(mailadapter)

                    While threadElegxos.IsAlive

                    End While

                    threadElegxosPrakt = SendMailPraktElegxos(mailadapter)

                    While threadElegxosPrakt.IsAlive

                    End While

                ElseIf imeromErgasias.DayOfWeek = DayOfWeek.Tuesday Then
                    threadElegxos = SendMailElegxos(mailadapter)

                    While threadElegxos.IsAlive

                    End While

                ElseIf imeromErgasias.DayOfWeek = DayOfWeek.Monday Then
                    threadElegxosPrakt = SendMailPraktElegxos(mailadapter)


                    While threadElegxosPrakt.IsAlive

                    End While

                End If
                Me.Cursor = Cursors.Default

                blinkLbl2.Text = ""
                EtiketaLbl.Text = "Κλείσιμο ημέρας"
                MsgBox("Το κλείσιμο Ημέρας ολοκληρώθηκε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Το κλείσιμο Ημέρας δεν μπόρεσε να ολοκληρωθεί !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End Try


    End Sub

    Private Sub daysbeforeTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            arrivalLbl.Text = imeromErgasias.AddDays(CType(sender.Text, Int16) + 1).ToString("dd/MM/yyyy")
        Catch ex As InvalidCastException
            arrivalLbl.Text = 15
        End Try

    End Sub
    Function SendMail(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
        Dim theThread _
            As New Threading.Thread(AddressOf SendMailto)

        theThread.Start()
        Return theThread

        'Dim theThread1 _
        '   As New Threading.Thread(AddressOf SendMailDirections)
        'theThread1.Start()
        'Stopped = True
    End Function
    Function SendMailElegxos(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
        Dim theThread _
            As New Threading.Thread(AddressOf elegxos_kenwn)
        theThread.Start()
        Return theThread
    End Function
    Function SendMailPraktElegxos(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
        Dim theThread _
            As New Threading.Thread(AddressOf elegxos_prakt_kenwn)
        theThread.Start()
        Return theThread
    End Function
    'Function SendMailwithDirections(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
    '    Dim theThread _
    '        As New Threading.Thread(AddressOf SendMailDirections)
    '    theThread.Start()

    '    Return theThread

    'End Function
    'Function SendMailwithDirectionsInk(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
    '    Dim theThread _
    '        As New Threading.Thread(AddressOf SendMailDirectionsInk)
    '    theThread.Start()

    '    Return theThread

    'End Function
    Function SendMailQuestionare(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
        Dim theThread _
            As New Threading.Thread(AddressOf SendMailto)
        theThread.Start()

        Return theThread

    End Function
    Private Sub SendMailto(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)

        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject, attach As String
        Dim mailTemp, name, perigrafi, linktrip As String
        Dim j, i As Int16
        Dim datum As Date
        mailTemp = ""
        name = ""
        perigrafi = ""
        'mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        Dim dwnatioadapter As New dbhotelDataSetTableAdapters.dwmatiaTableAdapter
        ' mailadapter.Fill(Me.DbhotelDataSet.Mail)
        Dim response As MsgBoxResult
        Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis1TableAdapter
        ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
        datum = imeromErgasias.AddDays(-Me.DbhotelDataSet.etaireia(0).apykwd - 1)
        anaxadapter.FillAnaxMailByAnaxChkoutTipoi(Me.DbhotelDataSet.AfixeisAnaxwriseis1, datum, True, 1, 12)


        Dim linksadapter As New dbhotelDataSetTableAdapters.linksTableAdapter

        from = Me.DbhotelDataSet.Mail(0).ffrom

        subject = Me.DbhotelDataSet.Mail(0).subject


        attach = Me.DbhotelDataSet.Mail(0).attachment

        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        'too = "mkallergis@gmail.com"

        For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis1.Count - 1
            If Not Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).eponimia.Equals("Βασιλάκης Κώστας") Then
                If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).Item("voucher")) Then

                    i = Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                    If i <> -1 Then
                        'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                        If Not Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).voucher.Equals(mailTemp) Then
                            mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).voucher
                            If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).Item("onomateponimo")) Then
                                name = Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).onomateponimo
                            Else
                                name = ""
                            End If

                            response = MsgBox("Να αποσταλεί Questionare στον " + name + ";", MsgBoxStyle.YesNo, "winfo\nikEl.")

                            If response = MsgBoxResult.Yes Then
                                linksadapter.FillLinksByVilaDescr(Me.DbhotelDataSet.links, Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).dwmatio, "tripadvisor")
                                perigrafi = dwnatioadapter.GetPerigrafiByVila(Me.DbhotelDataSet.AfixeisAnaxwriseis1(j).dwmatio)
                                If Me.DbhotelDataSet.links.Count <> 0 Then
                                    If Not IsDBNull(Me.DbhotelDataSet.links(0).Item("link")) And Not IsDBNull(Me.DbhotelDataSet.links(0).Item("description")) Then
                                        linktrip = Me.DbhotelDataSet.links(0).description + ChrW(13) + Me.DbhotelDataSet.links(0).link.Replace("#", "")
                                        perigrafi = Me.DbhotelDataSet.Mail(0).body.Replace("$", perigrafi)
                                        body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + perigrafi.Replace("&", linktrip) ' + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.links(0).description.Replace("&", linktrip) + ChrW(13)
                                        ' MsgBox(body)
                                    Else
                                        body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(0).body.Replace("$", perigrafi)
                                    End If
                                Else
                                    body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(0).body.Replace("$", perigrafi)
                                End If

                                'MsgBox(body)

                                SendMail(from, mailTemp, subject, body, attach, smtpServer, smtpUsername, smtpPassword)
                                ' mailTemp
                            End If

                        End If
                    End If
                End If

            End If

        Next
        'Me.DbhotelDataSet.AfixeisAnaxwriseis2.Clear()
        'MsgBox(Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count)
    End Sub
    Public Shared Sub SendMailCheck(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        Try

            Dim message As New MailMessage(from, [to], subject, body)



            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)



        Catch ex As Exception
            MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
        End Try




    End Sub
    Public Shared Sub SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal fileName As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        Dim instance As Attachment
        Dim pathstart As String = ""
        Try
            Try
                pathstart = Environment.GetEnvironmentVariable("location")

                If pathstart <> "" Then
                    fileName = fileName.Replace("N:", pathstart)
                    instance = New Attachment(fileName)
                Else
                    instance = New Attachment(fileName)
                End If

            Catch ex1 As ArgumentNullException
                instance = New Attachment(fileName)
            End Try
            ' Dim instance As New Attachment(fileName)
            Dim message As New MailMessage(from, [to], subject, body)
            ' MsgBox(fileName)
            message.Attachments.Add(instance)

            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)


        Catch ex1 As System.IO.FileNotFoundException
            MsgBox("Δεν βρέθηκε το Attachment για Questionare" + fileName, MsgBoxStyle.Exclamation)
        Catch ex3 As System.FormatException
            MsgBox("Η Διεύθυνση email για αποστολή Questionare είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
        Catch ex2 As System.IO.DirectoryNotFoundException
            MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Questionare ", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox("Αδυναμία αποστολής email " + fileName, MsgBoxStyle.Exclamation)
        End Try




    End Sub
    'Private Sub SendMailDirections(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)
    '    Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String
    '    Dim mailTemp, name As String
    '    Dim j, i As Int16
    '    Dim datum As Date
    '    mailTemp = ""
    '    name = ""
    '    '   Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    '    '   mailadapter.Fill(Me.DbhotelDataSet.Mail)

    '    Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter

    '    ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
    '    Try
    '        datum = imeromErgasias.AddDays(15)
    '    Catch ex As InvalidCastException
    '        datum = imeromErgasias.AddDays(15)
    '    End Try


    '    'Me.AfixeisAnaxwriseis2TableAdapter.AfixeisByEtosImerom_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date)
    '    anaxadapter.AfixeisByEtosImeromTpoikwd_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, datum, datum, datum, datum, 1, 12, etos, datum, datum, datum, 1, 12, datum)

    '    from = Me.DbhotelDataSet.Mail(0).ffrom
    '    subject = Me.DbhotelDataSet.Mail(2).subject
    '    smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
    '    smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
    '    smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
    '    'too = "mkallergis@gmail.com"

    '    For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1

    '        If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).eponimia.Equals("Βασιλάκης Κώστας") Then
    '            If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then
    '                i = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
    '                If i <> -1 Then
    '                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
    '                    If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then
    '                        mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher
    '                        If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
    '                            name = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).onomateponimo
    '                        Else
    '                            name = ""
    '                        End If

    '                        body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(2).body
    '                        SendMailMultiAttach(from, mailTemp, subject, body, Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, smtpServer, smtpUsername, smtpPassword)

    '                    End If
    '                End If
    '            End If
    '        End If

    '    Next

    'End Sub
    'Private Sub SendMailDirectionsInk(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)
    '    Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String
    '    Dim mailTemp, name As String
    '    Dim j, i As Int16
    '    Dim datum As Date
    '    mailTemp = ""
    '    name = ""
    '    '   Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    '    '   mailadapter.Fill(Me.DbhotelDataSet.Mail)

    '    Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter

    '    ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
    '    Try
    '        datum = imeromErgasias.AddDays(5)
    '    Catch ex As InvalidCastException
    '        datum = imeromErgasias.AddDays(5)
    '    End Try


    '    'Me.AfixeisAnaxwriseis2TableAdapter.AfixeisByEtosImerom_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date)
    '    anaxadapter.AfixeisByEtosImeromTpoikwd_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, datum, datum, datum, datum, 13, 25, etos, datum, datum, datum, 13, 25, datum)

    '    from = Me.DbhotelDataSet.Mail(0).ffrom
    '    subject = "Informations to the Hotel you booked in Crete"
    '    smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
    '    smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
    '    smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
    '    'too = "mkallergis@gmail.com"

    '    For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1

    '        If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).eponimia.Equals("Βασιλάκης Κώστας") Then
    '            If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then
    '                i = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
    '                If i <> -1 Then
    '                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
    '                    If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then
    '                        mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher
    '                        If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
    '                            name = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).onomateponimo
    '                        Else
    '                            name = ""
    '                        End If

    '                        body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + "in the Attachment you can find useful Informations how to to entry the Hotel on your Arrival" + ChrW(13) + ChrW(13) + "Best regards, " + ChrW(13) + "Stelios Christidis" + ChrW(13) + " Executive Director"
    '                        SendMailMultiAttachInk(from, mailTemp, subject, body, Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, smtpServer, smtpUsername, smtpPassword)

    '                    End If
    '                End If
    '            End If
    '        End If

    '    Next

    'End Sub
    Public Sub SendMailMultiAttach(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal dwmatio As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        Dim j As Int16
        Dim fileName As String = ""
        Dim instance, instance2 As Attachment
        Dim pathstart As String = ""
        Dim directionsAdapter As New dbhotelDataSetTableAdapters.directionsTableAdapter
        directionsAdapter.FillDirectionsByVila(Me.DbhotelDataSet.directions, dwmatio)
        Try

            Dim message As New MailMessage(from, [to], subject, body)
            pathstart = Environment.GetEnvironmentVariable("location")

            For j = 0 To Me.DbhotelDataSet.directions.Count - 1
                If Not IsDBNull(Me.DbhotelDataSet.directions(j).Item("path")) Then
                    Try
                        Try

                            If pathstart <> "" Then
                                fileName = Me.DbhotelDataSet.directions(j).path.Replace("N:", pathstart)
                                instance = New Attachment(fileName)
                            Else
                                instance = New Attachment(Me.DbhotelDataSet.directions(j).path)
                            End If

                        Catch ex1 As ArgumentNullException
                            instance = New Attachment(Me.DbhotelDataSet.directions(j).path)
                        End Try

                        message.Attachments.Add(instance)

                    Catch ex As System.IO.DirectoryNotFoundException
                        MsgBox("Αδυναμία επισύναψης questionare ", MsgBoxStyle.Exclamation)
                    End Try

                End If
            Next
            Try
                If pathstart <> "" Then
                    instance2 = New Attachment(Me.DbhotelDataSet.etaireia(0).dieuthinsi)
                Else
                    fileName = Me.DbhotelDataSet.etaireia(0).dieuthinsi.Replace("N:", pathstart)
                    instance2 = New Attachment(fileName)
                End If

                message.Attachments.Add(instance2)
            Catch ex As System.IO.DirectoryNotFoundException
                MsgBox("Αδυναμία επισύναψης έντυπου υποδοχής ", MsgBoxStyle.Exclamation)
            End Try


            If message.Attachments.Count <> 0 Then
                Dim smtpClient As New SmtpClient(smtpServer, 25)

                smtpClient.UseDefaultCredentials = False

                Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                smtpClient.Credentials = credentials
                smtpClient.EnableSsl = True
                'TEST
                smtpClient.Send(message)
            End If


            'Dim instance As New Attachment(fileName)




        Catch ex1 As System.IO.FileNotFoundException
            MsgBox("Δεν βρέθηκε Attachment για Directions ", MsgBoxStyle.Exclamation)
        Catch ex3 As System.FormatException
            MsgBox("Η Διεύθυνση email για αποστολή Directions είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
        Catch ex2 As System.IO.DirectoryNotFoundException
            MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Directions ", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Public Sub SendMailMultiAttachInk(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal dwmatio As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        Dim j As Int16
        Dim instance As Attachment
        Dim fileName As String = ""
        Dim pathstart As String = ""
        Dim directionsAdapter As New dbhotelDataSetTableAdapters.directionsTableAdapter
        Dim directionsTable As New dbhotelDataSet.directionsDataTable
        directionsAdapter.FillDirectionsByVila(directionsTable, dwmatio)
        Try

            Dim message As New MailMessage(from, [to], subject, body)

            For j = 0 To directionsTable.Count - 1
                If Not IsDBNull(directionsTable(j).Item("path")) Then
                    Try

                        Try
                            pathstart = Environment.GetEnvironmentVariable("location")
                            If pathstart <> "" Then
                                fileName = directionsTable(j).path.Replace("N:", pathstart)
                                instance = New Attachment(fileName)
                            Else
                                instance = New Attachment(directionsTable(j).path)
                            End If

                        Catch ex As ArgumentNullException
                            instance = New Attachment(directionsTable(j).path)
                        End Try


                        message.Attachments.Add(instance)

                    Catch ex As System.IO.DirectoryNotFoundException
                        MsgBox("Αδυναμία επισύναψης DIRECTIONS ", MsgBoxStyle.Exclamation)
                    End Try
                    'Try
                    '    Dim instance2 As New Attachment(Me.DbhotelDataSet.etaireia(0).dieuthinsi)
                    '    message.Attachments.Add(instance2)
                    'Catch ex As System.IO.DirectoryNotFoundException
                    '    MsgBox("Αδυναμία επισύναψης έντυπου υποδοχής ", MsgBoxStyle.Exclamation)
                    'End Try
                End If
            Next

            If message.Attachments.Count <> 0 Then
                Dim smtpClient As New SmtpClient(smtpServer, 25)

                smtpClient.UseDefaultCredentials = False

                Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                smtpClient.Credentials = credentials
                smtpClient.EnableSsl = True
                'TEST
                smtpClient.Send(message)
            End If


            'Dim instance As New Attachment(fileName)




        Catch ex1 As System.IO.FileNotFoundException
            MsgBox("Δεν βρέθηκε Attachment για Directions ", MsgBoxStyle.Exclamation)
        Catch ex3 As System.FormatException
            MsgBox("Η Διεύθυνση email για αποστολή Directions είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
        Catch ex2 As System.IO.DirectoryNotFoundException
            MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Directions ", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            MsgBox("Αδυναμία αποστολής email " + ex.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub elegxos_kenwn(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject As String

        'Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        'DbhotelDataSet.EnforceConstraints = False
        'mailadapter.Fill(Me.DbhotelDataSet.Mail)
        Me.DbhotelDataSet1.kratiseis.Clear()
        Dim kratadapter As New dbhotelDataSet1TableAdapters.kratiseisTableAdapter

        kratadapter.FillKratiseisLeer(Me.DbhotelDataSet1.kratiseis, imeromErgasias.AddDays(30), imeromErgasias.AddDays(90))
        body = ""

        If Me.DbhotelDataSet1.kratiseis.Count > 1 Then
            '  MsgBox(Me.DbhotelDataSet1.kratiseis.Count)
            body = kane_elegxo_7_kenwn()
        End If
        from = Me.DbhotelDataSet.Mail(0).ffrom
        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        SendMailCheck(from, "stakap15@gmail.com", "ΚΕΝΑ ΒΙΛΩΝ", body, smtpServer, smtpUsername, smtpPassword)
        'stakap15@gmail.com
    End Sub


    Private Sub elegxos_prakt_kenwn(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)
        Dim i, j As Int16
        Dim from, body, smtpServer, smtpUsername, smtpPassword As String
        'Dim lastDate As String = "01/11/" + imeromErgasias.Year.ToString
        'Dim lDate As DateTime = Convert.ToDateTime(lastDate)
        'Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        'DbhotelDataSet.EnforceConstraints = False
        'mailadapter.Fill(Me.DbhotelDataSet.Mail)
        Me.DbhotelDataSet1.kratiseis.Clear()
        Dim kratadapter As New dbhotelDataSet1TableAdapters.kratiseisTableAdapter
        Me.Vilapraktoreia1TableAdapter.Fill(Me.DbhotelDataSet1.vilapraktoreia1)
        kratadapter.FillKratiseisLeer(Me.DbhotelDataSet1.kratiseis, imeromErgasias.AddDays(7), "31/12/" + etos.ToString)
        body = ""


        from = Me.DbhotelDataSet.Mail(0).ffrom
        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        ' subject = "AVAILABILITY"

        DbhotelDataSet1.EnforceConstraints = False
        Dim mailadapter1 As New dbhotelDataSet1TableAdapters.praktoreiaTableAdapter
        mailadapter1.FillPraktoreiaforNewsetter(Me.DbhotelDataSet1.praktoreia)

        For j = 0 To Me.DbhotelDataSet1.praktoreia.Count - 1

            Try
                i = Me.DbhotelDataSet1.praktoreia(j).email.IndexOf("@") ' einai sosto to mail->dld periexei @??
                If i <> -1 Then
                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)

                    'If Not IsDBNull(Me.DbhotelDataSet.praktoreia(j).Item("ipeuthinos")) Then
                    '    Name = Me.DbhotelDataSet.praktoreia(j).ipeuthinos
                    'Else
                    '    Name = ""
                    'End If
                    '    Name = ""

                    'MsgBox("Sending Email to " + Me.DbhotelDataSet1.vilapraktoreia1(j).email)
                    If Me.DbhotelDataSet1.kratiseis.Count > 1 Then
                        '  MsgBox(Me.DbhotelDataSet1.kratiseis.Count)
                        body = kane_elegxo_prakt_kenwn(Me.DbhotelDataSet1.praktoreia(j).kwd)
                    End If

                    'SendMailCheck(from, Me.DbhotelDataSet1.praktoreia(j).email, "AVAILABILITY DOMISI", body, smtpServer, smtpUsername, smtpPassword)
                    If body <> "" Then
                        SendMailCheck(from, Me.DbhotelDataSet1.praktoreia(j).email, "AVAILABILITY DOMISI", body, smtpServer, smtpUsername, smtpPassword)
                        body = ""
                    End If

                    '    Me.DbhotelDataSet1.praktoreia(j).email
                End If
            Catch ex As NullReferenceException

            End Try

        Next
        ' SendMailCheck(from, "stakap15@gmail.com", "ΚΕΝΑ ΒΙΛΩΝ", body, smtpServer, smtpUsername, smtpPassword)
        'stakap15@gmail.com
    End Sub
    Private Function ist_vila_prakt(ByVal vila As String, ByVal prakt As Int32) As Boolean
        Dim i As Int16
        Dim drarray() As DataRow
        Dim filterExp As String

        filterExp = "vila= '" + vila + "'"

        drarray = Me.DbhotelDataSet1.vilapraktoreia1.Select(filterExp)

        For i = 0 To drarray.Length - 1
            If drarray(i)("praktoreio") = prakt Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Function kane_elegxo_7_kenwn() As String
        Dim startIndex, countIndex As Int16
        Dim kena7 As String = "κενά >= 7 ημερών:"
        Dim kena3 As String = "κενά < 3 ημερών:"
        Do Until startIndex > Me.DbhotelDataSet1.kratiseis.Count - 2
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet1.kratiseis.Count - 2 Then
                While Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio = Me.DbhotelDataSet1.kratiseis(startIndex + countIndex).dwmatio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet1.kratiseis.Count - 2 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)
                berechne_kena_vilas(startIndex, countIndex, kena7, kena3)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_kena_vilas(startIndex, countIndex, kena7, kena3)
                Exit Do
            End If
        Loop
        Return kena7 + ChrW(13) + ChrW(13) + ChrW(13) + kena3
        'MsgBox(kena3)
    End Function
    Private Sub berechne_kena_vilas(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByRef kena7 As String, ByRef kena3 As String)

        '   Dim lastDate As String =
        Dim fDate As Date = imeromErgasias.AddDays(30)
        Dim lDate As DateTime = imeromErgasias.AddDays(90) ' Convert.ToDateTime(lastDate)

        Dim startIndex, daysdif As Int16

        startIndex = datasetIndex
        'MsgBox(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio)
        kena7 = kena7 + ChrW(13) + ChrW(13) + Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio + ":"
        kena3 = kena3 + ChrW(13) + ChrW(13) + Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio + ":"

        If Me.DbhotelDataSet1.kratiseis(startIndex).afixi > fDate Then
            daysdif = Me.DbhotelDataSet1.kratiseis(startIndex).afixi.Subtract(fDate).Days
            If daysdif >= 7 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + fDate + "-" + Me.DbhotelDataSet1.kratiseis(startIndex).afixi.AddDays(-1) + ")]"
            End If
            If daysdif < 3 Then
                kena3 = kena3 + " [" + daysdif.ToString + " days (" + fDate + "-" + Me.DbhotelDataSet1.kratiseis(startIndex).afixi.AddDays(-1) + ")]"
            End If

        End If

        Do Until startIndex > (datasetIndex + countIndex - 2)
            daysdif = Me.DbhotelDataSet1.kratiseis(startIndex + 1).afixi.Subtract(Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi).Days

            If daysdif >= 7 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + Me.DbhotelDataSet1.kratiseis(startIndex + 1).afixi.AddDays(-1) + ")]"
            End If
            If daysdif < 3 And daysdif > 0 Then

                kena3 = kena3 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + Me.DbhotelDataSet1.kratiseis(startIndex + 1).afixi.AddDays(-1) + ")]"
            End If

            startIndex += 1
        Loop

        If Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi < lDate Then
            daysdif = lDate.Subtract(Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi).Days
            If daysdif >= 7 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + lDate + ")]"
            End If
            If daysdif < 3 Then

                kena3 = kena3 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + lDate + ")]"
            End If

        End If




    End Sub
    Private Function kane_elegxo_prakt_kenwn(ByVal praktkwd As Int32) As String
        Dim startIndex, countIndex As Int16
        Dim kena7 As String = "availability:"
        ' Dim kena3 As String = "κενά < 3 ημερών:"
        Dim sb As New System.Text.StringBuilder
        Do Until startIndex > Me.DbhotelDataSet1.kratiseis.Count - 2
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet1.kratiseis.Count - 2 Then
                While Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio = Me.DbhotelDataSet1.kratiseis(startIndex + countIndex).dwmatio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet1.kratiseis.Count - 2 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)
                If ist_vila_prakt(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio, praktkwd) Then
                    sb.AppendLine(berechne_kena_prakt_vilas(startIndex, countIndex, kena7))
                End If

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                If ist_vila_prakt(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio, praktkwd) Then
                    sb.AppendLine(berechne_kena_prakt_vilas(startIndex, countIndex, kena7))
                End If

                Exit Do
            End If
        Loop
        Return sb.ToString
        'MsgBox(kena3)
    End Function
    Private Function berechne_kena_prakt_vilas(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByVal kena7 As String) As String

        '   Dim lastDate As String =
        Dim fDate As Date = imeromErgasias.AddDays(7)
        Dim lDate As DateTime = imeromErgasias.AddDays(90) ' Convert.ToDateTime(lastDate)

        lDate = Convert.ToDateTime("31/12/" + etos.ToString)
        Dim startIndex, daysdif As Int16

        startIndex = datasetIndex
        'MsgBox(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio)
        kena7 = ChrW(13) + get_onoma_villa(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio) + ": "
        '  kena3 = kena3 + ChrW(13) + ChrW(13) + Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio + ":"

        If Me.DbhotelDataSet1.kratiseis(startIndex).afixi > fDate Then
            daysdif = Me.DbhotelDataSet1.kratiseis(startIndex).afixi.Subtract(fDate).Days
            If daysdif >= 1 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + fDate + "-" + Me.DbhotelDataSet1.kratiseis(startIndex).afixi.AddDays(-1) + ")]"
            End If

        End If

        Do Until startIndex > (datasetIndex + countIndex - 2)
            daysdif = Me.DbhotelDataSet1.kratiseis(startIndex + 1).afixi.Subtract(Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi).Days

            If daysdif >= 1 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + Me.DbhotelDataSet1.kratiseis(startIndex + 1).afixi.AddDays(-1) + ")]"
            End If

            startIndex += 1
        Loop

        If Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi < lDate Then
            daysdif = lDate.Subtract(Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi).Days
            If daysdif >= 1 Then
                kena7 = kena7 + " [" + daysdif.ToString + " days (" + Me.DbhotelDataSet1.kratiseis(startIndex).anaxwrisi + "-" + lDate + ")]"
            End If

        End If

        Return kena7


    End Function
    Private Sub TestBtn_Click(sender As Object, e As EventArgs)
        '     SendMailElegxos()
    End Sub

    Function SendMailtoDiamenontes(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter) As Threading.Thread
        Dim theThread _
            As New Threading.Thread(AddressOf SendMailDiamenontes)
        theThread.Start()

        Return theThread

    End Function
    Private Sub SendMailDiamenontes(ByVal mailadapter As dbhotelDataSetTableAdapters.MailTableAdapter)
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject, attach, pathstart, fileName As String
        Dim recipients As New List(Of String)
        Dim mailTemp As String
        Dim j, i As Int16
        Dim datum As Date
        mailTemp = ""

        pathstart = ""

        'Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        ' mailadapter.Fill(Me.DbhotelDataSet.Mail)

        Dim diamenadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
        ' exei idi alaksei i imeromergasias-> ean apykwd =O tote stelnontai mailme to poy alaksei imeromergasias s'autoys pou efugan
        'Try
        '    datum = imeromErgasias.AddDays(CType(daysbeforeTbx.Text, Int16))
        'Catch ex As InvalidCastException
        '    datum = imeromErgasias.AddDays(15)
        'End Try


        'Me.AfixeisAnaxwriseis2TableAdapter.AfixeisByEtosImerom_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, etos, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date, ImerKatastPicker.Value.Date)
        diamenadapter.FillDiamenontesByAfixi(Me.DbhotelDataSet.AfixeisAnaxwriseis2, imeromErgasias.AddDays(-1), etos)

        from = Me.DbhotelDataSet.Mail(0).ffrom

        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        subject = Me.DbhotelDataSet.Mail(7).subject
        If Not IsDBNull(Me.DbhotelDataSet.Mail(7).Item("attachment")) Then

            attach = Me.DbhotelDataSet.Mail(7).attachment

        Else
            attach = ""
        End If
        body = "Dear Mrs./Mr. ," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(7).body


        'too = "mkallergis@gmail.com"

        For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1


            If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then
                i = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                If i <> -1 Then
                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                    If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then
                        mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher



                        recipients.Add(mailTemp)

                        'mailTemp
                    End If
                End If
            End If


        Next
        If recipients.Count > 0 Then
            SendMailDIamenontesAttach(from, recipients, subject, body, attach, smtpServer, smtpUsername, smtpPassword)

        End If
    End Sub
    Public Sub SendMailDIamenontesAttach(ByVal from As String, ByVal recipients As List(Of String), ByVal subject As String, ByVal body As String, ByVal attachment As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        Dim j As Int16

        Try
            Dim message As New MailMessage()

            message.From = New MailAddress(from)
            For Each recipient As String In recipients
                message.Bcc.Add(recipient)
            Next

            message.Subject = subject
            message.Body = body


            If attachment <> "" Then
                Try
                    Dim instance As New Attachment(attachment)

                    message.Attachments.Add(instance)

                Catch ex As System.IO.DirectoryNotFoundException
                    '  MsgBox("Αδυναμία επισύναψης αρχείου για αποστολή προς Διαμένοντες ", MsgBoxStyle.Exclamation)
                End Try

            End If



            'Dim instance As New Attachment(fileName)

            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)


        Catch ex1 As System.IO.FileNotFoundException
            'MsgBox("Δεν βρέθηκε Attachment για Διαμένοντες ", MsgBoxStyle.Exclamation)
        Catch ex3 As System.FormatException
            ' MsgBox("Η Διεύθυνση email για αποστολή σε Διαμένοντες είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
        Catch ex2 As System.IO.DirectoryNotFoundException
            '  MsgBox("Δεν βρέθηκε o φάκελος για αποστολή σε Διαμένοντες ", MsgBoxStyle.Exclamation)

        Catch ex As Exception
            '  MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
        End Try

    End Sub
    Private Function get_onoma_villa(ByVal dwm As String) As String
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.dwmatia.Count - 1
            If Me.DbhotelDataSet.dwmatia(i).arithmos.Equals(dwm) Then
                Return Me.DbhotelDataSet.dwmatia(i).perigrafi
            End If
        Next
        Return ""

    End Function
    'Private Sub myTimer_Tick2(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTimer2.Tick

    '    'Static labelText As String = Label1.Text
    '    showLblText = Not showLblText

    '    If showLblText = True Then
    '        blinkLbl2.Text = "Wait.......sending emails!"
    '    Else
    '        blinklbl2.Text = String.Empty
    '    End If

    'End Sub
    Private Sub akyrosi_kleisimatos()
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        EtiketaLbl.Text = "Ακύρωση κλεισίματος Ημέρας"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        AkyrosiPnl.Location = New Point(40, EtiketaPnl.Height)
        AkyrosiPnl.Size = New Point(445, 196)
        AkyrosiPck1.Value = Me.DbhotelDataSet.etaireia(0).kleismenidate
        AkyrosiPck2.Value = imeromErgasias
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(AkyrosiPnl)
        If ist_imeromergasias_aktuel(connectionString) Then
            AkyrosiChk.Checked = True
            AkyrosiChk.Enabled = True
        Else
            AkyrosiChk.Checked = False
            AkyrosiChk.Enabled = False
        End If


    End Sub
    Private Sub AkyrosiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AkyrosiBtn.Click
        Dim response As MsgBoxResult
        Dim ok As Boolean = False
        Try
            Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
            If AkyrosiPck1.Value < Me.DbhotelDataSet.etaireia(0).kleismenidate Then
                MsgBox("ΠΡΟΣΟΧΗ: Ολες οι εργασίες όπως π.χ. Εκδοση Τιμολογίων " & vbCrLf & " που έχουν γίνει μετά την " + AkyrosiPck1.Value.ToShortDateString + " θα διαγραφούν μια για πάντα !" & vbCrLf & " Επιβάλεται πρίν την ακύρωση να ληφθεί Backup ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                response = MsgBox("ΠΡΟΣΟΧΗ: Θέλετε παρόλαταυτα να συνεχίσετε με την ακύρωση, με κίνδυνο να χαθούν Δεδομένα ; " & vbCrLf & "Επιλέξτε ΟΧΙ εάν θέλετε να κάνετε πρώτα Backup για να διασφαλίσετε τα Δεδομένα σας !", MsgBoxStyle.YesNo, "winfo\nikEl.")
                If response = MsgBoxResult.Yes Then
                    ok = akyrose_afixeis_ge_timologia()
                Else
                    MsgBox("Μπορείται να κάνετε τώρα Backup στο αρχικό Μενού !", MsgBoxStyle.Information, "winfo\nikEl.")
                    Exit Sub
                End If
            Else
                response = MsgBox("ΠΡΟΣΟΧΗ: Ολες οι εργασίες όπως π.χ. Εκδοση Τιμολογίων (εκτός Extra Παραστατικά)" & vbCrLf & " που έχουν γίνει σήμερα (" + imeromErgasias + ") θα ακυρωθούν! ", MsgBoxStyle.YesNo, "winfo\nikEl.")
                If response = MsgBoxResult.Yes Then
                    ok = akyrose_afixeis_ge_timologia()
                Else
                    Exit Sub
                End If

            End If

        Catch ex As Exception
            MsgBox("Η Διαδικασία Ακύρωσης Κλεισίματος Ημέρας δεν μπόρεσε να ολοκληρωθεί επιτυχώς ", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End Try

        If ok Then
            Me.EtaireiaTableAdapter.SetAlagiImerasergasias(AkyrosiPck2.Value.Date, AkyrosiPck1.Value.Date, 0, 0)

            MsgBox("Η Διαδικασία Ακύρωσης Κλεισίματος Ημέρας ολοκληρώθηκε επιτυχώς !" & vbCrLf & "Μπορείτε να αλάξετε την τρέχουσα Ημερομηνία Εργασίας στο Μενού " & vbCrLf & "<Σταθερές Εταιρείας->Λειτουργία> στους Παράμετρους της Εφαρμογής ", MsgBoxStyle.Information, "winfo\nikEl.")
        End If
    End Sub
    Private Function akyrose_afixeis_ge_timologia() As Boolean
        Dim startIndex, stepsIndex, aaMax, count As Int16
        Dim delKrat() As Integer ' sto delKrat einai kwdikoi olwn twn Kratisewn tou Timologiou! 
        Dim apo, mexri As Date

        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString
        If AkyrosiChk.Checked Then
            'arxika Oles oi afixeis (pou DEN exei kopei timologio ) KATA THN AKTUELLE IMEROMINIA ERGASIAS
            Me.KratiseisTableAdapter.FillAfixeiProsAkyrosiByAfixiCheckinTimologio(Me.DbhotelDataSet.kratiseis, imeromErgasias, True, 0)

            If Me.DbhotelDataSet.kratiseis.Count <> 0 Then
                'den Yparxoun spaetere eintraege sto Biblio Portas (tha ypirxan ean exei ginei akyrosi kleisimatos apo spaetere imerominia!)
                count = Me.BiblioportasTableAdapter.ExistSpaetereEintraegeByImerominia(imeromErgasias)
                If count = 0 Then
                    If Not akyrosi_afixewn_xwris_ekdomeno_timologio() Then ' kati pige straba
                        MsgBox("Η Ακύρωση Αφίξεων δεν μπόρεσε να ολοκληρωθεί: Η Διαδικασία Ακύρωσης Κλεισίματος διακόπηκε ! ", MsgBoxStyle.Critical, "winfo\nikEl.")
                        Return False
                    End If
                Else
                    MsgBox("Η Διαδικασία Ακύρωσης Κλεισίματος διακόπηκε : Το κουτάκι της ακύρωσης των Αφίξεων δεν πρέπει να είναι τσεκαρισμένο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    Return False
                End If

            End If
        End If

        Me.GramatiaTableAdapter.FillGEProsAkyrosiByImerAkyro(Me.DbhotelDataSet.gramatia, AkyrosiPck2.Value.Date, False)
        If Me.DbhotelDataSet.gramatia.Count <> 0 Then
            If Not akyrose_gramatia_eispraksis() Then
                MsgBox("Η Ακύρωση Γραμμάτιων Είσπραξης δεν μπόρεσε να ολοκληρωθεί: Η Διαδικασία Ακύρωσης Κλεισίματος διακόπηκε ! ", MsgBoxStyle.Critical, "winfo\nikEl.")
                Return False
            End If
        End If
        'timologia-kratiseis OLWN meta tin kleismeni imerominia akyrose
        'PROSOXI->Prepei meta apo kathe akyromeno timologio na enhmerwnw to parastatika Table pou exei to aktuelste Arithmo Timologiou pou exei bgei!
        Me.EpanekdositimologiouTableAdapter.FillTimologiaProsAkyrosiByImerom(Me.DbhotelDataSet.epanekdositimologiou, AkyrosiPck2.Value, False)

        Do Until startIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1
            stepsIndex = 1 'posa eintraege 
            ReDim delKrat(-1)
            'firstIndex = startIndex
            If startIndex < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                While Me.DbhotelDataSet.epanekdositimologiou(startIndex).aa = Me.DbhotelDataSet.epanekdositimologiou(startIndex + stepsIndex).aa
                    stepsIndex += 1
                    If startIndex + stepsIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                        Exit While
                    End If
                End While
                'kratiseis zwischenlagern!
                fuege_kratisi_hinzu(startIndex, stepsIndex, delKrat) ' ana praktoreio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                If akyrose_timologio_me_kratiseis(Me.DbhotelDataSet.epanekdositimologiou(startIndex).timkwd, Me.DbhotelDataSet.epanekdositimologiou(startIndex).afixi.Date, Me.DbhotelDataSet.epanekdositimologiou(startIndex).aa, delKrat) Then
                    startIndex = startIndex + stepsIndex 'weiter stin do until
                Else
                    MsgBox("Η Διαδικασία διακόπηκε ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                    Return False
                End If
                'Else
                '    MsgBox("To Τιμολογίο " + Me.DbhotelDataSet.epanekdositimologiou(startIndex).ToString + " έχει εξοφληθεί: Μπορεί να ακυρωθεί μόνο στο Μενού Ακύρωσης Τιμολογίου (Εργασίες Ημέρας)!", MsgBoxStyle.Information, "winfo\nikEl.")
                'End If
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'If Me.DbhotelDataSet.epanekdositimologiou(startIndex).exoflithi = False Then
                fuege_kratisi_hinzu(startIndex, stepsIndex, delKrat) ' ana praktoreio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                If akyrose_timologio_me_kratiseis(Me.DbhotelDataSet.epanekdositimologiou(startIndex).timkwd, Me.DbhotelDataSet.epanekdositimologiou(startIndex).afixi.Date, Me.DbhotelDataSet.epanekdositimologiou(startIndex).aa, delKrat) Then
                    Exit Do
                Else
                    MsgBox("Η Διαδικασία διακόπηκε ! ", MsgBoxStyle.Information, "winfo\nikEl.")
                    Return False
                End If
                '    Else
                '    MsgBox("To Τιμολογίο " + Me.DbhotelDataSet.epanekdositimologiou(startIndex).ToString + " έχει εξοφληθεί: Μπορεί να ακυρωθεί μόνο στο Μενού <Εργασίες Ημέρας->Ακύρωση Τιμολογίου>!", MsgBoxStyle.Information, "winfo\nikEl.")
                'End If
            End If
        Loop
        ' edw recht spaet da->otan kanw akyrwsitote prepei na kanw set to flag twn eintraege proigoumenwn kratisewn (pou eixan idi afixthei
        'se proigoumeni imerominia) kai eixan egrafei tin imera tis akyrosi (px durch <automati> allagi timwn)
        '->ACHTUNG->DEN DIAGRAFW APWS AFIXEIS IMERAS ALLA KANW SETZEN TO FLAG APO 1 SE O WSTE NA KSANABGOUN STIN EPOMENI THEORIMENI EKTIPOSI
        Me.BiblioportasTableAdapter.SetFlagMetapoImerominia(0, AkyrosiPck2.Value.Date)

        Try
            aaMax = Me.TimologiaTableAdapter.GetMaxAAByParastatikoEtos(1, apo, mexri, False)
        Catch ex As Exception
            aaMax = Me.DbhotelDataSet.etaireia(0).aaapy - 1
        End Try
        'Me.ParastatikaTableAdapter.UpdateParastByKwdiko(aaMax, 1)
        Me.ParastatikaTableAdapter.SetaaAPYByKwd(aaMax, 1)

        Me.KratiseisTableAdapter.AkyrosiAnaxGuarantieByAnChkinOutGuar(False, AkyrosiPck2.Value.Date, True, True, True)
        Me.EtaireiaTableAdapter.SetAlagiImerasergasias(AkyrosiPck2.Value.Date, AkyrosiPck1.Value.Date, 0, 0)
        imeromErgasias = AkyrosiPck2.Value.Date

        AkyrosiChk.Checked = False
        AkyrosiChk.Enabled = False
        Me.Text = "Κλείσιμο Ημέρας " + imeromErgasias
        Return True
    End Function
    Private Sub fuege_kratisi_hinzu(ByVal firstIndex As Int16, ByVal countIndex As Int16, ByRef delKrat() As Integer)
        Dim j As Int16
        Dim laenge As Int16
        Dim kwdKrat As Integer = -1

        laenge = -1

        For j = firstIndex To firstIndex + countIndex - 1
            If kwdKrat <> Me.DbhotelDataSet.epanekdositimologiou(j).kratisi Then
                kwdKrat = Me.DbhotelDataSet.epanekdositimologiou(j).kratisi
                laenge += 1

                ReDim Preserve delKrat(laenge)

                delKrat(laenge) = kwdKrat

            End If

        Next


    End Sub
    'aenderung nach absprache mit Manikis-> den diagrafetai tipota-.Sinn tis akyrosis kleiematos einai na mporei na paei o User 
    'se progrenesteri imeromoinia gia na alaksei kati kai meta na ksanagirisei stin aktuele imerominia zurueck kanwntas diadoxika kleiseimata pali 
    '(apo ta Aufruf parameter tis Procedure den xreiazetai pleon h Afixi)
    Public Function akyrose_timologio_me_kratiseis(ByVal kwdTimol As Integer, ByVal afixi As Date, ByVal aa As Int16, ByVal delKrat() As Integer) As Boolean
        Dim rows As Int16
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim transaction As SqlTransaction = Nothing
            Dim j As Int16
            Dim kwdOver As Integer = -1

            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction
                'gia kathe mia kratisi tou timologiou
                'ACHTUNG: NACH ABSPRACHE MIT MANIKIS TA ALAKSA->DEN I DIAGRAFETAI TIPOTA APTO BIBLIO PORTAS!!!!!!!!!!!!!
                For j = 0 To delKrat.Length - 1
                    'diagrafi apo biblioportas olwn twn kataxwrisewn tis Kratisis meta apo tin klismeni imerominia 

                    command.Parameters.AddWithValue("@imerominia", CType(AkyrosiPck2.Value.Date, Date))
                    command.Parameters.AddWithValue("@kratisi", delKrat(j))
                    command.CommandText = "DELETE FROM biblioportas WHERE (imerominia>=@imerominia) and (status=2) and (kratisi=@kratisi)and (arapy<>0)" '
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@imerominia", CType(AkyrosiPck2.Value.Date, Date))
                    command.Parameters.AddWithValue("@kratisi", delKrat(j))
                    command.CommandText = "UPDATE biblioportas SET flag=0 WHERE (imerominia>=@imerominia) and (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    'If afixi >= AkyrosiPck2.Value Then ' se periptwsi pou i akyrosi paei poli pisw imerologiaka!
                    'ean afixi metA tin kleismeni imerominia tote akyrosi afixis kai to timologio-apy=0
                    'command.Parameters.AddWithValue("dwmatio", "")
                    command.Parameters.AddWithValue("@kwd", delKrat(j))
                    'command.CommandText = "UPDATE kratiseis SET dwmatio=?, checkin=false, checkout=false, timologio=0, apy=0 WHERE (kwd=?)"
                    command.CommandText = "UPDATE kratiseis SET checkout=0, timologio=0, apy=0 WHERE (kwd=@kwd)"
                    rows = command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    'diegrapse to status dwmatiou tis kratisis pou i enarxi tou einai MEta tin kleismeni imerominia
                    'command.Parameters.AddWithValue("kratisi", delKrat(j))
                    'command.Parameters.AddWithValue("enarxi", CType(AkyrosiPck2.Value, Date))
                    'command.CommandText = "DELETE FROM status WHERE (kratisi=?) and (enarxi>=?)"
                    'command.ExecuteNonQuery()
                    'command.Parameters.Clear()
                    ''to idio kai me ta oVer ean uparxoun 
                    'command.Parameters.AddWithValue("kratisi", delKrat(j))
                    'command.Parameters.AddWithValue("apo", CType(AkyrosiPck2.Value, Date))
                    'command.CommandText = "SELECT kwd FROM over WHERE (kratisi=?) and (apo>=?)"
                    'Dim myReader As OleDb.OleDbDataReader
                    'myReader = command.ExecuteReader()
                    '' Always call Read before accessing data.
                    'While myReader.Read()
                    '    'ean uparxei kanw setzen to kwdiko->aliws paramenei -1
                    '    kwdOver = myReader.GetInt32(0)
                    'End While
                    'myReader.Close()
                    'command.Parameters.Clear()

                    'If kwdOver <> -1 Then
                    '    command.Parameters.AddWithValue("kwd", kwdOver)
                    '    command.CommandText = "DELETE FROM overunterkuenfte WHERE (over=?)"
                    '    command.ExecuteNonQuery()
                    '    command.Parameters.Clear()

                    '    command.Parameters.AddWithValue("over", kwdOver)
                    '    command.CommandText = "DELETE FROM over WHERE (kwd=?)"
                    '    command.ExecuteNonQuery()
                    '    command.Parameters.Clear()

                    '    kwdOver = -1

                    'End If

                    'Else
                    '    command.Parameters.AddWithValue("kwd", delKrat(j))
                    '    command.CommandText = "UPDATE kratiseis SET checkout=false, timologio=0, apy=0 WHERE (kwd=?)"
                    '    command.ExecuteNonQuery()
                    '    command.Parameters.Clear()
                    'End If

                Next
                command.Parameters.AddWithValue("@kwd", kwdTimol)
                command.CommandText = "UPDATE timologia SET akyromeno=1 WHERE (kwd=@kwd)"
                command.ExecuteNonQuery()
                command.Parameters.Clear()

                'TOKANA ABSTELLEN LOGW MERDEMATOS ME AA APO EXTRA PARASTATIKA
                'enimerwsi tou parastatika me to neo aa gia APY 
                'command.Parameters.AddWithValue("aritthmos", aa - 1)
                'command.CommandText = "UPDATE parastatika SET aritthmos=? WHERE (kwd=1)" 'APY STARRES KWD=1!!!!!!!
                'command.ExecuteNonQuery()
                'command.Parameters.Clear()

                transaction.Commit()

                Return True

            Catch ex As Exception
                MsgBox("Η Διαδικασία Ακύρωσης του Τιμολογίου " + aa.ToString + " απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return False
                Catch
                    Return False
                End Try
            End Try
        End Using

    End Function
    Private Function akyrosi_afixewn_xwris_ekdomeno_timologio() As Boolean
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim transaction As SqlTransaction = Nothing
            Dim j As Int16
            Dim kwdOver As Integer = -1
            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
                    'diagrafi apo biblioportas olwn twn kataxwrisewn tis Kratisis meta apo tin klismeni imerominia 
                    command.Parameters.AddWithValue("@imerominia", CType(AkyrosiPck2.Value.Date, Date))
                    command.Parameters.AddWithValue("@kratisi", Me.DbhotelDataSet.kratiseis(j).kwd)
                    command.CommandText = "DELETE FROM biblioportas WHERE (imerominia>=@imerominia) and (kratisi=@kratisi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@dwmatio", "")
                    command.Parameters.AddWithValue("@kwd", Me.DbhotelDataSet.kratiseis(j).kwd)
                    command.CommandText = "UPDATE kratiseis SET dwmatio=@dwmatio, checkin=0 WHERE (kwd=@kwd)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    command.Parameters.AddWithValue("@kratisi", Me.DbhotelDataSet.kratiseis(j).kwd)
                    command.Parameters.AddWithValue("@enarxi", CType(AkyrosiPck2.Value, Date))
                    command.CommandText = "DELETE FROM status WHERE (kratisi=@kratisi) and (enarxi>=@enarxi)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("@kratisi", Me.DbhotelDataSet.kratiseis(j).kwd)
                    command.Parameters.AddWithValue("@apo", CType(AkyrosiPck2.Value, Date))
                    command.CommandText = "SELECT kwd FROM over WHERE (kratisi=@kratisi) and (apo>=@apo)"
                    Dim myReader As SqlDataReader
                    myReader = command.ExecuteReader()
                    ' Always call Read before accessing data.
                    While myReader.Read()
                        'ean uparxei kanw setzen to kwdiko->aliws paramenei -1
                        kwdOver = myReader.GetInt32(0)
                    End While
                    myReader.Close()
                    command.Parameters.Clear()

                    If kwdOver <> -1 Then
                        command.Parameters.AddWithValue("@kwd", kwdOver)
                        command.CommandText = "DELETE FROM overunterkuenfte WHERE ([over]=@kwd)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()

                        command.Parameters.AddWithValue("@over", kwdOver)
                        command.CommandText = "DELETE FROM [over] WHERE (kwd=@over)"
                        command.ExecuteNonQuery()
                        command.Parameters.Clear()

                        kwdOver = -1
                    End If

                Next

                transaction.Commit()

                Return True
            Catch ex As Exception
                MsgBox("Η Διαδικασία Ακύρωσης Αφίξεων δεν μπόρεσε να ολοκληρωθεί επιτυχώς !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return False
                Catch
                    Return False
                End Try
            End Try
        End Using
    End Function

    Public Function akyrose_gramatia_eispraksis() As Boolean
        Dim datum As Date
        Dim j As Int16
        datum = "1/1/" + etos.ToString
        'Public Function akyrose_timologia_kratiseis() As Boolean
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim transaction As SqlTransaction = Nothing

            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                For j = 0 To Me.DbhotelDataSet.gramatia.Count - 1
                    command.Parameters.AddWithValue("@imerominia", datum)
                    command.Parameters.AddWithValue("@aagramatio", Me.DbhotelDataSet.gramatia(j).aa)
                    command.CommandText = "UPDATE logariasmoidiam SET aagramatio=0 WHERE (imerominia>@imerominia) and (aagramatio=@aagramatio)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                    command.Parameters.AddWithValue("@kwd", Me.DbhotelDataSet.gramatia(j).kwd)
                    command.CommandText = "UPDATE gramatia SET akyro=1 WHERE (kwd=@kwd)"
                    command.ExecuteNonQuery()
                    command.Parameters.Clear()

                Next


                command.Parameters.AddWithValue("@aritthmos", Me.DbhotelDataSet.gramatia(0).aa - 1)
                command.CommandText = "UPDATE parastatika SET aritthmos=@aritthmos WHERE (kwd=3)" 'APY STARRES KWD=1!!!!!!!
                command.ExecuteNonQuery()
                command.Parameters.Clear()



                transaction.Commit()
                Return True
            Catch ex As Exception
                'MsgBox("Η Διαδικασία Ακύρωσης του ΓΕ " + aa.ToString + " απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Try
                    transaction.Rollback()
                    Return False
                Catch
                    Return False
                End Try
            End Try
        End Using

    End Function
    Private Function ist_imeromergasias_aktuel(ByVal connectionString As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            Dim maxdatumBP As Date
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("@etos", etos)
            command.CommandText = "SELECT MAX(imerominia) FROM biblioportas where (etos=@etos)"
            myReader = command.ExecuteReader(CommandBehavior.SingleResult)
            myReader.Read()
            Try
                maxdatumBP = myReader.Item(0)
                If maxdatumBP > imeromErgasias Then
                    myReader.Close()
                    command.Parameters.Clear()
                    Return False
                Else
                    myReader.Close()
                    command.Parameters.Clear()
                    Return True
                End If
            Catch ex As InvalidCastException
                myReader.Close()
                command.Parameters.Clear()
                Return True
            End Try
        End Using
    End Function
    '***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn
    '***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn
    '***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn***************Emfanisis Analytikis Kinishs Tmimatwn
    Private Sub emf_anal_kin_imeras()
        Dim arxiEtous, telosEtous As Date
        tmimaKd = -1

        EtiketaLbl.Text = "Εμφάνιση αναλυτικής Κίνησης Ημέρας"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        TmimataKnsPnl.Location = New Point(5, EtiketaPnl.Height)
        Me.TmimataKnsPnl.Size = New Point(KleisimoZentralPnl.Width - 40, KleisimoZentralPnl.Height - 80)

        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        TmimKnsImerom.MinDate = arxiEtous
        TmimKnsImerom.MaxDate = telosEtous

        TmimKnsImerom.Value = imeromErgasias
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(TmimataKnsPnl)
    End Sub

    Private Sub TmimataTmTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmimataTmTbx.Enter
        Dim TmimaForm As New TmimataFrm(False)
        Dim kwdikos As Integer
        Dim tmimaName As String

        'Dim praktoreiokwd, praktortimolkwd, currentklines, currenttipos, currentsimbolaio As Integer ' apoimeres

        TmimaForm.StartPosition = FormStartPosition.CenterParent
        TmimaForm.ShowDialog()
        kwdikos = TmimaForm.return_tmima_kwdikos

        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If kwdikos = Nothing Then
            tmimaKd = -1
            MsgBox("Δεν επιλέχθηκε Τμήμα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            TmimataKns2Pnl.Focus()
            Exit Sub
        Else
            tmimaKd = kwdikos
        End If

        tmimaName = TmimaForm.return_tmima
        If tmimaName = Nothing Then
            TmimataTmTbx.Text = sender.text
        Else
            TmimataTmTbx.Text = tmimaName
        End If
        TmimaForm.Dispose()
        TmimataKns2Pnl.Controls.Clear()
        male_tmima_kiniseis_kefalida(tmimaKd)
        TmimataKns2Pnl.Focus()
    End Sub
    Private Sub TmimKnsImerom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmimKnsImerom.ValueChanged
        If tmimaKd <> -1 Then
            TmimataKns2Pnl.Controls.Clear()
            male_tmima_kiniseis_kefalida(tmimaKd)
        End If
    End Sub
    Private Sub male_tmima_kiniseis_kefalida(ByVal tmimaKwdikos As Integer)
        Dim fpaCount As Int16 = 0
        Dim fpa() As Single
        Dim j, stepy, stepx, xstart, ystart As Int16
        Dim locationX() As Koordinaten
        Dim kefalCount As Int16 = 0

        ReDim fpa(-1)

        stepx = 100
        stepy = 100
        xstart = 2
        ystart = 10
        'Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)
        Me.TmimataTableAdapter.FillByKwd(Me.DbhotelDataSet.tmimata, tmimaKwdikos)
        'edw epilogi posostwn FPA 
        'VORSICHT -> EAN PREPEI NA EXW KAI FPA 0,00% TOTE METATREPSE SE Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 (!) TA PARAKATW KLAUSEL
        For j = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            If Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa1, fpa) Then ' AndAlso Array.Exists(fpa, AddressOf Me.DbhotelDataSet.tmimata(j).fpa1)
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa1
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa2 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa2, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa2
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa3 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa3, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa3
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa4 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa4, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa4
            End If
        Next
        'posa fpa exei to tmima
        If fpaCount = 0 Then
            MsgBox("Δεν εχουν δωθεί Φ.Π.Α. Τμήματος : Ανατρέξτε στις Σταθερές Εταιρείας (Τμήματα) και ενημερώστε τα ποσά Φ.Π.Α. !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End If

        Dim AALbl, TPliromLbl, AitLbl, SinolLbl, LeerLbl As New Label

        AALbl.Text = "Α/Α"
        AALbl.TextAlign = ContentAlignment.MiddleCenter
        AALbl.Size = New Point(40, 20)
        AALbl.Location = New Point(xstart, ystart)
        AALbl.BackColor = Color.DarkKhaki
        AALbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1).locX = AALbl.Location.X
        locationX(kefalCount - 1).fpa = -1 'es handelt sich nicht um FPA
        TmimataKns2Pnl.Controls.Add(AALbl)

        TPliromLbl.Text = "Τρ.Πληρ."
        TPliromLbl.TextAlign = ContentAlignment.MiddleCenter
        TPliromLbl.Size = New Point(82, 20)
        TPliromLbl.Location = New Point(xstart + AALbl.Width + 2, ystart)
        TPliromLbl.BackColor = Color.DarkKhaki
        TPliromLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1).locX = TPliromLbl.Location.X
        locationX(kefalCount - 1).fpa = -1
        TmimataKns2Pnl.Controls.Add(TPliromLbl)


        AitLbl.Text = "Αιτιολογία"
        AitLbl.TextAlign = ContentAlignment.MiddleCenter
        AitLbl.Size = New Point(140, 20)
        AitLbl.Location = New Point(xstart + AALbl.Width + TPliromLbl.Width + 4, ystart)
        AitLbl.BackColor = Color.DarkKhaki
        AitLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1).locX = AitLbl.Location.X
        locationX(kefalCount - 1).fpa = -1
        TmimataKns2Pnl.Controls.Add(AitLbl)


        'LeerLbl.TextAlign = ContentAlignment.MiddleCenter
        LeerLbl.Size = New Point(94, 20)
        LeerLbl.Location = New Point(xstart + AALbl.Width + TPliromLbl.Width + AitLbl.Width + 4, ystart)
        LeerLbl.BackColor = Color.DarkKhaki
        LeerLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1).locX = LeerLbl.Location.X
        locationX(kefalCount - 1).fpa = -1
        TmimataKns2Pnl.Controls.Add(LeerLbl)


        For j = 0 To fpa.Length - 1
            Dim FpaXXLbl As New Label
            FpaXXLbl.Text = fpa(j).ToString + " %"
            FpaXXLbl.TextAlign = ContentAlignment.MiddleCenter
            FpaXXLbl.Size = New Point(98, 20)
            FpaXXLbl.Location = New Point(xstart + AALbl.Width + TPliromLbl.Width + AitLbl.Width + (j + 1) * stepx, ystart)
            FpaXXLbl.BackColor = Color.DarkKhaki
            FpaXXLbl.ForeColor = Color.Blue
            kefalCount = kefalCount + 1
            ReDim Preserve locationX(kefalCount - 1)
            locationX(kefalCount - 1).locX = FpaXXLbl.Location.X
            locationX(kefalCount - 1).fpa = fpa(j)
            TmimataKns2Pnl.Controls.Add(FpaXXLbl)
        Next

        SinolLbl.Text = "Συν. Ποσό"
        SinolLbl.TextAlign = ContentAlignment.MiddleCenter
        SinolLbl.Size = New Point(98, 20)
        SinolLbl.Location = New Point(xstart + AALbl.Width + TPliromLbl.Width + AitLbl.Width + (j + 1) * stepx, ystart)
        SinolLbl.BackColor = Color.DarkKhaki
        SinolLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1).locX = SinolLbl.Location.X
        locationX(kefalCount - 1).fpa = -1
        TmimataKns2Pnl.Controls.Add(SinolLbl)

        zeige_werte_tmimata(tmimaKwdikos, locationX)

    End Sub
    Private Sub zeige_werte_tmimata(ByVal tmimaKwdikos As Integer, ByVal koord() As Koordinaten)
        Dim j, i, index As Int16
        Dim stepy As Int16
        Dim sumKathAxies(), sumFpa(), sumGenSyn() As Koordinaten
        'MsgBox(tmimaKwdikos)
        stepy = 60
        ReDim sumKathAxies(0)
        ReDim sumFpa(0)
        ReDim sumGenSyn(0)
        init_sum(sumKathAxies, sumFpa, sumGenSyn, koord)

        Me.TmimataegrafesTableAdapter.FillByTmimaImerominia(Me.DbhotelDataSet.tmimataegrafes, TmimKnsImerom.Value.Date, tmimaKwdikos)
        'MsgBox(Me.DbhotelDataSet.tmimataegrafes.Count)

        For j = 0 To Me.DbhotelDataSet.tmimataegrafes.Count - 1

            Dim AALbl, TPliromLbl, AitLbl, SinolKathLbl, SinolFpaLbl, LeerLbl As New Label

            AALbl.Text = (j + 1).ToString
            'AALbl.ForeColor = Color.Maroon
            AALbl.TextAlign = ContentAlignment.MiddleCenter
            AALbl.Size = New Point(40, 20)
            AALbl.Location = New Point(koord(0).locX, (j + 1) * stepy)
            TmimataKns2Pnl.Controls.Add(AALbl)
            'TPliromLbl.BackColor = Color.Azure
            Try
                If Me.DbhotelDataSet.tmimataegrafes(j).pliromi.Length > 9 Then
                    TPliromLbl.Text = Me.DbhotelDataSet.tmimataegrafes(j).pliromi.Substring(0, 9)
                Else
                    TPliromLbl.Text = Me.DbhotelDataSet.tmimataegrafes(j).pliromi
                End If

            Catch ex As StrongTypingException
            End Try
            TPliromLbl.TextAlign = ContentAlignment.TopLeft
            TPliromLbl.Size = New Point(82, 20)
            TPliromLbl.Location = New Point(koord(1).locX, (j + 1) * stepy)
            TmimataKns2Pnl.Controls.Add(TPliromLbl)

            'AitLbl.BackColor = Color.Azure
            AitLbl.Text = Me.DbhotelDataSet.tmimataegrafes(j).aitiologia
            'AitLbl.ForeColor = Color.Maroon
            AitLbl.TextAlign = ContentAlignment.MiddleCenter
            AitLbl.Size = New Point(230, 20)
            AitLbl.Location = New Point(koord(2).locX, (j + 1) * stepy)
            TmimataKns2Pnl.Controls.Add(AitLbl)

            LeerLbl.TextAlign = ContentAlignment.MiddleRight
            LeerLbl.Text = "(Φ.Π.Α)"
            LeerLbl.Size = New Point(94, 20)
            LeerLbl.Location = New Point(koord(3).locX, (j + 1) * stepy + 25)
            TmimataKns2Pnl.Controls.Add(LeerLbl)

            Dim eggrafKD As Integer
            eggrafKD = Me.DbhotelDataSet.tmimataegrafes(j).kwd
            Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafKD)


            Dim poso, kathPos, fpaPos, synKathPoso, synFpaPoso As Single
            synKathPoso = 0
            synFpaPoso = 0

            For i = 0 To Me.DbhotelDataSet.eggrafitakiniseis.Count - 1 'DIAFORETIKA fpa STO eggrafitakiniseis (ANA tmimataegrafes)
                Dim PosoKathTbx As New Label
                Dim PosoFpaTbx As New Label
                'FpaMTbx.Text = fpa(j).ToString + " %"
                PosoKathTbx.TextAlign = ContentAlignment.MiddleRight
                'PosoKathTbx.ForeColor = Color.Maroon
                PosoKathTbx.Size = New Point(98, 20)
                PosoFpaTbx.TextAlign = ContentAlignment.MiddleRight
                'PosoFpaTbx.ForeColor = Color.Maroon
                PosoFpaTbx.Size = New Point(98, 20)

                index = finde_fpapos_in_array(Me.DbhotelDataSet.eggrafitakiniseis(i).fpa, koord)
                'poso = Me.EggrafitakiniseisTableAdapter.SumPosaByTmimaeggrFpa(eggrafKD, Me.DbhotelDataSet.eggrafitakiniseis(i).fpa)
                poso = Me.DbhotelDataSet.eggrafitakiniseis(i).poso.ToString("N")
                'kathPos = (Me.DbhotelDataSet.eggrafitakiniseis(i).poso / (1 + Me.DbhotelDataSet.eggrafitakiniseis(i).fpa / 100)).ToString("N")
                kathPos = Me.DbhotelDataSet.eggrafitakiniseis(i).posoneto.ToString("N")
                'fpaPos = (Me.DbhotelDataSet.eggrafitakiniseis(i).poso - kathPos).ToString("N")
                fpaPos = Me.DbhotelDataSet.eggrafitakiniseis(i).fpaposo.ToString("N")

                synKathPoso = (synKathPoso + kathPos).ToString("N")
                synFpaPoso = synFpaPoso + fpaPos



                addiere_wert(sumKathAxies, kathPos.ToString("N"), Me.DbhotelDataSet.eggrafitakiniseis(i).fpa)
                addiere_wert(sumFpa, fpaPos.ToString("N"), Me.DbhotelDataSet.eggrafitakiniseis(i).fpa)
                addiere_wert(sumGenSyn, poso, Me.DbhotelDataSet.eggrafitakiniseis(i).fpa)

                'ean feripin exei alaksei entwmetaksi to fpa tmimatos (->index=-1) to poso den grafetai katw apo tin stili tou neou fpa
                'alla athrizetai apla stin deksia stili twn synolon
                If index <> -1 Then
                    PosoKathTbx.Text = kathPos.ToString("N")
                    PosoFpaTbx.Text = fpaPos.ToString("N")
                    PosoKathTbx.Location = New Point(koord(index).locX, (j + 1) * stepy)
                    PosoFpaTbx.Location = New Point(koord(index).locX, (j + 1) * stepy + 25)

                End If

                TmimataKns2Pnl.Controls.Add(PosoKathTbx)
                TmimataKns2Pnl.Controls.Add(PosoFpaTbx)

            Next

            SinolKathLbl.Text = synKathPoso.ToString("N")
            'AitLbl.ForeColor = Color.Maroon
            SinolKathLbl.TextAlign = ContentAlignment.BottomRight
            SinolKathLbl.Size = New Point(98, 20)
            SinolKathLbl.Location = New Point(koord(koord.Length - 1).locX, (j + 1) * stepy)
            TmimataKns2Pnl.Controls.Add(SinolKathLbl)

            SinolFpaLbl.Text = synFpaPoso.ToString("N")
            'AitLbl.ForeColor = Color.Maroon
            SinolFpaLbl.TextAlign = ContentAlignment.BottomRight
            SinolFpaLbl.Size = New Point(98, 20)
            SinolFpaLbl.Location = New Point(koord(koord.Length - 1).locX, (j + 1) * stepy + 25)
            TmimataKns2Pnl.Controls.Add(SinolFpaLbl)

        Next

        Dim SynTxtLbl, FpaTxtLbl, GenSynTxtLbl As New Label
        Dim sumsumKAxies, sumsumFpa, sumsumGenSynol As Single


        SynTxtLbl.Text = "Σύνολο Τμήματος (Καθ.Αξία):"
        SynTxtLbl.TextAlign = ContentAlignment.MiddleRight
        SynTxtLbl.Size = New Point(240, 20)
        SynTxtLbl.Location = New Point(koord(2).locX, (j + 1) * (stepy + 10))
        TmimataKns2Pnl.Controls.Add(SynTxtLbl)

        For i = 0 To sumKathAxies.Length - 1
            Dim SynWertLbl As New Label
            index = finde_fpapos_in_array(sumKathAxies(i).fpa, koord)

            SynWertLbl.Text = sumKathAxies(i).locX.ToString("N")
            sumsumKAxies = sumsumKAxies + sumKathAxies(i).locX
            'MsgBox(SynWertLbl.Text)
            SynWertLbl.TextAlign = ContentAlignment.MiddleRight
            SynWertLbl.Size = New Point(98, 20)
            SynWertLbl.Location = New Point(koord(index).locX, (j + 1) * (stepy + 10))
            TmimataKns2Pnl.Controls.Add(SynWertLbl)
        Next


        FpaTxtLbl.Text = "(Φ.Π.Α):"
        FpaTxtLbl.TextAlign = ContentAlignment.MiddleRight
        FpaTxtLbl.Size = New Point(240, 20)
        FpaTxtLbl.Location = New Point(koord(2).locX, (j + 1) * (stepy + 10) + 25)
        TmimataKns2Pnl.Controls.Add(FpaTxtLbl)
        For i = 0 To sumFpa.Length - 1
            Dim SynFpaWertLbl As New Label
            index = finde_fpapos_in_array(sumFpa(i).fpa, koord)

            SynFpaWertLbl.Text = sumFpa(i).locX.ToString("N")
            sumsumFpa = sumsumFpa + sumFpa(i).locX
            'MsgBox(SynWertLbl.Text)
            SynFpaWertLbl.TextAlign = ContentAlignment.MiddleRight
            SynFpaWertLbl.Size = New Point(98, 20)
            SynFpaWertLbl.Location = New Point(koord(index).locX, (j + 1) * (stepy + 10) + 25)
            TmimataKns2Pnl.Controls.Add(SynFpaWertLbl)
        Next

        GenSynTxtLbl.Text = "Γεν. Σύνολα:"
        GenSynTxtLbl.TextAlign = ContentAlignment.MiddleRight
        GenSynTxtLbl.Size = New Point(240, 20)
        GenSynTxtLbl.Location = New Point(koord(2).locX, (j + 1) * (stepy + 10) + 50)
        TmimataKns2Pnl.Controls.Add(GenSynTxtLbl)

        For i = 0 To sumGenSyn.Length - 1
            Dim SynGenWertLbl As New Label
            index = finde_fpapos_in_array(sumGenSyn(i).fpa, koord)
            SynGenWertLbl.Text = sumGenSyn(i).locX.ToString("N")
            sumsumGenSynol = sumsumGenSynol + sumGenSyn(i).locX
            'MsgBox(SynWertLbl.Text)
            SynGenWertLbl.TextAlign = ContentAlignment.MiddleRight
            SynGenWertLbl.Size = New Point(98, 20)
            SynGenWertLbl.Location = New Point(koord(index).locX, (j + 1) * (stepy + 10) + 50)
            TmimataKns2Pnl.Controls.Add(SynGenWertLbl)
        Next

        Dim SumSumKathAxiesLbl As New Label
        SumSumKathAxiesLbl.TextAlign = ContentAlignment.MiddleRight
        SumSumKathAxiesLbl.Size = New Point(98, 20)
        SumSumKathAxiesLbl.Text = sumsumKAxies.ToString("N")
        SumSumKathAxiesLbl.Location = New Point(koord(koord.Length - 1).locX, (j + 1) * (stepy + 10))
        TmimataKns2Pnl.Controls.Add(SumSumKathAxiesLbl)

        Dim SumSumFpaLbl As New Label
        SumSumFpaLbl.TextAlign = ContentAlignment.MiddleRight
        SumSumFpaLbl.Size = New Point(98, 20)
        SumSumFpaLbl.Text = sumsumFpa.ToString("N")
        SumSumFpaLbl.Location = New Point(koord(koord.Length - 1).locX, (j + 1) * (stepy + 10) + 25)
        TmimataKns2Pnl.Controls.Add(SumSumFpaLbl)

        Dim SumSumGenSynLbl As New Label
        SumSumGenSynLbl.TextAlign = ContentAlignment.MiddleRight
        SumSumGenSynLbl.Size = New Point(98, 20)
        SumSumGenSynLbl.Text = sumsumGenSynol.ToString("N")
        SumSumGenSynLbl.Location = New Point(koord(koord.Length - 1).locX, (j + 1) * (stepy + 10) + 50)
        TmimataKns2Pnl.Controls.Add(SumSumGenSynLbl)
    End Sub
    Private Sub addiere_wert(ByRef sumXXX() As Koordinaten, ByVal wert As Single, ByVal fpa As Single)
        Dim j As Int16

        For j = 0 To sumXXX.Length - 1
            If sumXXX(j).fpa = fpa Then
                sumXXX(j).locX = sumXXX(j).locX + wert
                Exit Sub
            End If
        Next
    End Sub


    Private Sub init_sum(ByRef sumKathAxies() As Koordinaten, ByRef sumFpa() As Koordinaten, ByRef sumGenSyn() As Koordinaten, ByVal koord() As Koordinaten)
        Dim j, index As Int16

        index = 0
        For j = 0 To koord.Length - 1
            If koord(j).fpa <> -1 Then

                ReDim Preserve sumKathAxies(index)
                sumKathAxies(index).locX = 0
                sumKathAxies(index).fpa = koord(j).fpa
                ReDim Preserve sumFpa(index)
                sumFpa(index).locX = 0
                sumFpa(index).fpa = koord(j).fpa

                ReDim Preserve sumGenSyn(index)
                sumGenSyn(index).locX = 0
                sumGenSyn(index).fpa = koord(j).fpa

                index = index + 1
            End If
        Next

    End Sub



    Private Function finde_fpapos_in_array(ByVal fpa As Single, ByVal koord() As Koordinaten) As Int16
        Dim j As Int16

        For j = 0 To koord.Length - 1
            If koord(j).fpa = fpa Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Function kommt_vor(ByVal nummer As Single, ByVal fpa() As Single) As Boolean
        Dim j As Int16
        Try
            For j = 0 To fpa.Length - 1
                If nummer = fpa(j) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As NullReferenceException
            Return False
        End Try


    End Function


    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    '***************Ektiposi LOGISTIRIO***************Ektiposi LOGISTIRIO**************Ektiposi LOGISTIRIO****************************
    Private Sub ekt_logistirio()
        Dim arxiEtous, telosEtous As Date
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση αναλυτικής Κίνησης Ημέρας για το Λογιστήριο"
        EtiketaLbl.Location = New Point(LogistirioEktPnl.Width / 14, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        LogistirioEktPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.LogistirioEktPnl.Size = New Point(KleisimoZentralPnl.Width - 80, KleisimoZentralPnl.Height - 80)

        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        Logistirio1Pck.MinDate = arxiEtous
        Logistirio1Pck.MaxDate = telosEtous

        Logistirio2Pck.MinDate = arxiEtous
        Logistirio2Pck.MaxDate = telosEtous

        Logistirio1Pck.Value = imeromErgasias.AddDays(-1)
        Logistirio2Pck.Value = imeromErgasias.AddDays(-1)

        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        'timologia kai kentrika tmimata (restaurant/kafeteria usw) metritois
        fuelle_fpa(True, True)
        fuelle_fpa_werte_zu_dataset()
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(LogistirioEktPnl)
    End Sub
    Private Sub LogistirioEktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogistirioEktBtn.Click
        Me.DbhotelDataSet.ekt_analkin_logistirio.Clear()
        'Me.DbhotelDataSet.ekt_fpa_logistirio.Clear()
        vorbereite_dataset()
        proepiskopisi_anal()
    End Sub
    Private Sub vorbereite_dataset()
        Dim j, i, trofi1Fpa, trofi2Fpa, trofi3Fpa, eggrkinFpa, startIndex, stepsIndex, firstIndex As Int16
        Dim imerom As Date
        Dim kathPoso, fpaPoso As Single
        Dim onomaTmim, pliromi As String
        'Dim command As New OleDb.OleDbCommand()

        Try
            Me.Cursor = Cursors.WaitCursor
            'index(->se pia thesi einai sto Array) von trofifpa sto fpaLog
            trofi1Fpa = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis1)
            trofi2Fpa = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2)
            trofi3Fpa = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis3)



            If Me.Logistirio1Rdb.Checked Then
                Me.EpanekdositimologiouTableAdapter.FillLogistirioByImIm(Me.DbhotelDataSet.epanekdositimologiou, Logistirio1Pck.Value.Date, Logistirio2Pck.Value.Date, False, False)
            ElseIf Me.Logistirio2Rdb.Checked Then
                Me.EpanekdositimologiouTableAdapter.FillLogistirioByImImPlirom(Me.DbhotelDataSet.epanekdositimologiou, Logistirio1Pck.Value.Date, Logistirio2Pck.Value.Date, False, False, "Επί Πιστώση")
            ElseIf Me.Logistirio3Rdb.Checked Then
                Me.EpanekdositimologiouTableAdapter.FillLogistirioByImImMetritois(Me.DbhotelDataSet.epanekdositimologiou, Logistirio1Pck.Value.Date, Logistirio2Pck.Value.Date, False, False, True)
            Else
                Me.EpanekdositimologiouTableAdapter.FillLogistirioByImImKarta(Me.DbhotelDataSet.epanekdositimologiou, Logistirio1Pck.Value.Date, Logistirio2Pck.Value.Date, False, False, True, "Μετρητοίς")
            End If

            Do Until startIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1
                stepsIndex = 1 'posa eintraege 
                firstIndex = startIndex
                If startIndex < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                    While Me.DbhotelDataSet.epanekdositimologiou(startIndex).timkwd = Me.DbhotelDataSet.epanekdositimologiou(startIndex + stepsIndex).timkwd
                        stepsIndex += 1
                        If startIndex + stepsIndex > Me.DbhotelDataSet.epanekdositimologiou.Count - 1 Then
                            Exit While
                        End If
                    End While
                    bearbeite_ekdomena_timologia(startIndex, stepsIndex, trofi1Fpa, trofi2Fpa, trofi3Fpa) ' ana timologio (startIndex,stepsindex siganalisieren wo in dataset sind die eintraege toy Praktoreiou
                    startIndex = startIndex + stepsIndex
                    'fuelle_synola_praktoreiou(Me.DbhotelDataSet.epanekdositimologiou(firstIndex).eponimia, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).fpa, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa, 3)
                    'sumsumPistosi = sumsumPistosi + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa
                    sumSynKrat = sumSynKrat + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola
                    init_times_variablen()
                Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                    bearbeite_ekdomena_timologia(startIndex, stepsIndex, trofi1Fpa, trofi2Fpa, trofi3Fpa)
                    'fuelle_synola_praktoreiou(Me.DbhotelDataSet.epanekdositimologiou(firstIndex).eponimia, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).fpa, Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa, 3)
                    'sumsumPistosi = sumsumPistosi + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).sumkathposa
                    sumSynKrat = sumSynKrat + Me.DbhotelDataSet.epanekdositimologiou(firstIndex).synola
                    init_times_variablen()
                    Exit Do
                End If

            Loop

            'Epeidi stin analytiki yparxoyn mono ta KENTRIKA tmimata->JOIN anfrage ueber tmimata mit zentralOK = true
            Me.TmimataegrafesTableAdapter.FillEgrrafesvonzentralByApoMexri(Me.DbhotelDataSet.tmimataegrafes, True, Logistirio1Pck.Value.Date, Logistirio2Pck.Value.Date)

            ' edw alaksa xarin grigoradas!!!!!!!!!!!

            Using connection As New OleDb.OleDbConnection(connectionString)
                Dim command As New OleDb.OleDbCommand()
                'Dim transaction As OleDb.OleDbTransaction = Nothing

                Try
                    connection.Open()
                    'transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                    command.Connection = connection
                    For j = 0 To Me.DbhotelDataSet.tmimataegrafes.Count - 1
                        imerom = Me.DbhotelDataSet.tmimataegrafes(j).imerominia
                        pliromi = "Μετρητοίς"
                        Try
                            onomaTmim = Me.DbhotelDataSet.tmimataegrafes(j).tmimaname 'Me.TmimataTableAdapter.GetOnomaByKwd(Me.DbhotelDataSet.tmimataegrafes(j).tmima)
                        Catch ex As StrongTypingException
                            onomaTmim = "anonymous"
                        End Try

                        Me.DbhotelDataSet.ekt_analkin_logistirio.Rows.Add()
                        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).imerominia = imerom
                        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).pliromi = pliromi
                        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).prakt_tmima = LTrim(onomaTmim)
                        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).aitiologia = Me.DbhotelDataSet.tmimataegrafes(j).aitiologia
                        'command.Transaction = transaction
                        command.Parameters.AddWithValue("tmimataeggrafi", Me.DbhotelDataSet.tmimataegrafes(j).kwd)
                        'command.Parameters.AddWithValue("identifikation", timolID)
                        command.CommandText = "SELECT * FROM Eggrafitakiniseis where (tmimataeggrafi=?)" 'and (identifikation=?)
                        Dim myReader As OleDb.OleDbDataReader
                        myReader = command.ExecuteReader()
                        ' Always call Read before accessing data.
                        While myReader.Read()
                            eggrkinFpa = fpa_index(myReader.GetFloat(2))
                            If myReader.GetFloat(3) <> 0 Then
                                kathPoso = myReader.GetFloat(4)
                                fpaPoso = myReader.GetFloat(5)
                                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolo = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolo + myReader.GetFloat(3)
                                If eggrkinFpa <> -1 Then
                                    plaziere_richtige_stili_fpa_netto(eggrkinFpa, kathPoso)
                                    plaziere_richtige_stili_fpa(eggrkinFpa, fpaPoso)
                                End If

                            End If
                        End While
                        ' always call Close when done reading.
                        myReader.Close()
                        command.Parameters.Clear()
                    Next
                Catch ex As Exception

                End Try

            End Using

        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub bearbeite_ekdomena_timologia(ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal trofi1Fpa As Int16, ByVal trofi2Fpa As Int16, ByVal trofi3Fpa As Int16)
        Dim j As Int16
        Dim ypnos, prwino, geumata, extra, allinclusiv, ypnosFpa, prwinoFpa, geumataFpa, extraFpa, allinclusivFpa As Single
        Dim imerom, pliromi, onomaPrakt As String

        imerom = Me.DbhotelDataSet.epanekdositimologiou(startIndex).imerominia
        pliromi = Me.DbhotelDataSet.epanekdositimologiou(startIndex).pliromi
        onomaPrakt = Me.DbhotelDataSet.epanekdositimologiou(startIndex).eponimia
        If pliromi = Nothing Then
            pliromi = "Επί Πιστώση"
        End If
        'Try
        '    onomaPrakt = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.epanekdositimologiou(j).praktoreio)
        'Catch ex As InvalidOperationException
        '    onomaPrakt = "anonymous"
        'End Try

        Me.DbhotelDataSet.ekt_analkin_logistirio.Rows.Add()
        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).imerominia = imerom
        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).pliromi = pliromi
        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).prakt_tmima = LTrim(onomaPrakt)
        Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).aitiologia = Me.DbhotelDataSet.epanekdositimologiou(startIndex).seira + " " + Me.DbhotelDataSet.epanekdositimologiou(startIndex).aa.ToString

        For j = startIndex To (startIndex + countIndex - 1)
            ypnos = 0
            prwino = 0
            geumata = 0
            extra = 0
            'me ta plaziere bazw to swsto katharo poso kai fpa sto antistoixo column tou ekt_analkin_logistirio 
            'If j = 17 Then
            '    MsgBox(j)
            '    ypnos = 0
            'End If

            ypnos = Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
            prwino = Me.DbhotelDataSet.epanekdositimologiou(j).prwino
            geumata = Me.DbhotelDataSet.epanekdositimologiou(j).geuma
            geumata = geumata + Me.DbhotelDataSet.epanekdositimologiou(j).deipno
            extra = Me.DbhotelDataSet.epanekdositimologiou(j).extra
            allinclusiv = Me.DbhotelDataSet.epanekdositimologiou(j).allinclusiv

            If Me.DbhotelDataSet.epanekdositimologiou(j).ekptosi Then
                'MsgBox(Me.DbhotelDataSet.epanekdositimologiou(j).arithmos)
                If Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto <> 0 Then
                    If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                        ypnos = ypnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                        prwino = prwino - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                        geumata = geumata - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                        extra = extra - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100)
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo <> 0 Then

                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        ypnos = ypnos - Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres <> 0 Then
                    'MsgBox(Me.DbhotelDataSet.epanekdositimologiou(j).timkwd)
                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                            ypnos = ypnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                            prwino = prwino - (Me.DbhotelDataSet.epanekdositimologiou(j).prwino / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                            geumata = geumata - ((Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                            extra = extra - (Me.DbhotelDataSet.epanekdositimologiou(j).extra / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).fee <> 0 Then
                    If (j < (startIndex + countIndex - 1) AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = (startIndex + countIndex - 1)) Then
                        ypnos = ypnos + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                        'sumYpnos = sumYpnos + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                    End If
                End If
            End If

            If ypnos <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).ypnos, Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis1) Then
                    plaziere_richtige_stili_fpa_netto(trofi1Fpa, ypnos)
                    ypnosFpa = (ypnos * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
                    plaziere_richtige_stili_fpa(trofi1Fpa, ypnosFpa)
                End If

            End If
            If prwino <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).prwino, Me.DbhotelDataSet.epanekdositimologiou(j).prwinofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    plaziere_richtige_stili_fpa_netto(trofi2Fpa, prwino)
                    prwinoFpa = (prwino * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
                    plaziere_richtige_stili_fpa(trofi2Fpa, prwinoFpa)
                End If

            End If
            If geumata <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).geuma, Me.DbhotelDataSet.epanekdositimologiou(j).geumafpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) _
                OrElse ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).deipno, Me.DbhotelDataSet.epanekdositimologiou(j).deipnofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    plaziere_richtige_stili_fpa_netto(trofi2Fpa, geumata)
                    geumataFpa = (geumata * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
                    plaziere_richtige_stili_fpa(trofi2Fpa, geumataFpa)
                End If
            End If
            If extra <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).extra, Me.DbhotelDataSet.epanekdositimologiou(j).extrfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
                    plaziere_richtige_stili_fpa_netto(trofi3Fpa, extra)
                    extraFpa = (extra * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)
                    plaziere_richtige_stili_fpa(trofi3Fpa, extraFpa)
                End If
            ElseIf allinclusiv <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).allinclusiv, Me.DbhotelDataSet.epanekdositimologiou(j).allinclusivfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
                    plaziere_richtige_stili_fpa_netto(trofi3Fpa, allinclusiv)
                    allinclusivFpa = (allinclusiv * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)
                    plaziere_richtige_stili_fpa(trofi3Fpa, allinclusivFpa)
                End If

            End If

            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolneto = Me.DbhotelDataSet.epanekdositimologiou(j).sumkathposa.ToString("N")
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolfpa = Me.DbhotelDataSet.epanekdositimologiou(j).fpa.ToString("N")
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolo = Me.DbhotelDataSet.epanekdositimologiou(j).synola.ToString("N")
            'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolneto)
        Next
    End Sub

    Private Sub proepiskopisi_anal()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New LogistirioAnalKinisi()


        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
        ektiposi.SetDataSource(DbhotelDataSet)


        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    Private Sub fuelle_fpa(ByVal timolOK As Boolean, ByVal tmimatZentralOK As Boolean)
        Dim j, fpaCount As Int16

        ReDim fpaLog(-1)
        fpaCount = 0
        If timolOK Then
            fpaCount = fpaCount + 1
            ReDim Preserve fpaLog(fpaCount - 1)
            fpaLog(fpaCount - 1) = 0

            fpaCount = fpaCount + 1
            ReDim Preserve fpaLog(fpaCount - 1)
            fpaLog(fpaCount - 1) = Me.DbhotelDataSet.etaireia(0).fpatrofis1

            If Not kommt_vor(Me.DbhotelDataSet.etaireia(0).fpatrofis2, fpaLog) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.etaireia(0).fpatrofis2
            End If
            If Not kommt_vor(Me.DbhotelDataSet.etaireia(0).fpatrofis3, fpaLog) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.etaireia(0).fpatrofis3
            End If
        End If

        'edw epilogi posostwn FPA 
        'VORSICHT -> EAN PREPEI NA EXW KAI FPA 0,00% TOTE METATREPSE SE Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 (!) TA PARAKATW KLAUSEL
        If tmimatZentralOK Then
            Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True) 'mONO TA KENTRIKA-> oXI mHDEN fPA->GI AUTO ...fpaX<>0
        Else
            Me.TmimataTableAdapter.FillOla(Me.DbhotelDataSet.tmimata) 'ola ta tmimata -> KAI mHDEN fPA->GI AUTO ...fpaX>=0
        End If

        For j = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            If Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa1, fpaLog) Then ' AndAlso Array.Exists(fpa, AddressOf Me.DbhotelDataSet.tmimata(j).fpa1)
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa1
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa2 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa2, fpaLog) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa2
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa3 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa3, fpaLog) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa3
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa4 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa4, fpaLog) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpaLog(fpaCount - 1)
                fpaLog(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa4
            End If
        Next



        'posa fpa exei to tmima
        If fpaCount = 0 Then
            MsgBox("Δεν εχουν δωθεί Φ.Π.Α. Τμήματος : Ανατρέξτε στις Σταθερές Εταιρείας (Τμήματα) και ενημερώστε τα ποσά Φ.Π.Α. !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End If


        Array.Sort(fpaLog)

    End Sub
    Private Sub plaziere_richtige_stili_fpa_netto(ByVal index As Int16, ByVal poso As Single)
        Select Case index
            Case 0
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa1neto = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa1neto + poso
            Case 1
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa2neto = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa2neto + poso
            Case 2
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa3neto = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa3neto + poso
            Case 3
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa4neto = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa4neto + poso
        End Select

    End Sub
    Private Sub plaziere_richtige_stili_fpa(ByVal index As Int16, ByVal poso As Single)
        Select Case index
            Case 0
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa1 = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa1 + poso
            Case 1
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa2 = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa2 + poso
            Case 2
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa3 = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa3 + poso
                'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa3)
            Case 3
                Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa4 = Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).fpa4 + poso
        End Select

    End Sub
    Private Sub fuelle_fpa_werte_zu_dataset()
        Dim j As Int16
        If fpaLog.Length <> 0 Then
            Me.DbhotelDataSet.ekt_fpa_logistirio.Clear()
            Me.DbhotelDataSet.ekt_fpa_logistirio.Rows.Add()
        End If

        For j = 0 To fpaLog.Length - 1
            If j = 0 Then
                Me.DbhotelDataSet.ekt_fpa_logistirio(0).fpa1 = fpaLog(j)
                'MsgBox(Me.DbhotelDataSet.ekt_fpa_logistirio(0).fpa1)
            ElseIf j = 1 Then
                Me.DbhotelDataSet.ekt_fpa_logistirio(0).fpa2 = fpaLog(j)
            ElseIf j = 2 Then
                Me.DbhotelDataSet.ekt_fpa_logistirio(0).fpa3 = fpaLog(j)
            ElseIf j = 3 Then
                Me.DbhotelDataSet.ekt_fpa_logistirio(0).fpa4 = fpaLog(j)
            End If

        Next
        'MsgBox(Me.DbhotelDataSet.ekt_fpa_logistirio(Me.DbhotelDataSet.ekt_fpa_logistirio.Count - 1).fpa4)
    End Sub
    Private Function fpa_index(ByVal nummer As Single) As Int16
        Dim j As Int16
        Try
            For j = 0 To fpaLog.Length - 1
                If nummer = fpaLog(j) Then
                    Return j
                End If
            Next
            Return -1
        Catch ex As NullReferenceException
            Return -1
        End Try


    End Function
    Private Function ist_fpa_aktuell(ByVal kathposo As Single, ByVal fpaposo As Single, ByVal fpa As Single) As Boolean
        Dim posoFpa As Single
        posoFpa = (kathposo * fpa / 100) '.ToString("N")
        If posoFpa.ToString("N") = fpaposo.ToString("N") Then
            Return True
        Else
            Return False
        End If

    End Function


    '***************Ektiposi sigkentrwtikis kinisis***************Ektiposi sigkentrwtikis kinisis**************Ektiposi sigkentrwtikis kinisis****************************
    Private Sub ekt_sigkentr_kin_imeras()
        Dim arxiEtous, telosEtous As Date
        tmimaKd = -1
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση ημερ. συγκεντρωτικής Κίνησης Τμημάτων"
        EtiketaLbl.Location = New Point(TmimSigkentrPnl.Width / 12, 25)

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 40, 60)
        TmimSigkentrPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.TmimSigkentrPnl.Size = New Point(KleisimoZentralPnl.Width - 80, KleisimoZentralPnl.Height - 80)

        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString

        TmimSigkentrPnlerPck.MinDate = arxiEtous
        TmimSigkentrPnlerPck.MaxDate = telosEtous

        TmimSigkentrPnlerPck.Value = imeromErgasias
        init_PliromCbxoen()
        fuelle_fpa(False, False)
        fuelle_fpa_werte_zu_dataset()
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(TmimSigkentrPnl)
    End Sub

    Private Sub TmimSigkentrBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmimSigkentrBtn.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DbhotelDataSet.ekt_analkin_logistirio.Clear()
            vorbereite_sigkentr_dataset()
            proepiskopisi_sigkentr()
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub vorbereite_sigkentr_dataset()
        Dim j, indexFpa As Int16
        Dim kathPoso, fpaPoso As Single
        Dim onomaTmim As String
        Me.DbhotelDataSet.tmimataegrafes.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Clear()
        'To (eikoniko) data table kiniseisjoineggrafes einai COPY tou pragmatikou eggrafeskiniseis me prsthiki 2 columns tmima kai pliromi gia
        'na dexetai ta data apo to Join Query!!!!!!!!
        If TmimSigkentrPnlerCbx.SelectedIndex > 0 Then
            Me.KiniseisjoineggrafesTableAdapter.FilJoinByApoMexriPliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, TmimSigkentrPnlerPck.Value, TmimSigkentrPnlerPck.Value, TmimSigkentrPnlerCbx.SelectedItem)
        Else
            Me.KiniseisjoineggrafesTableAdapter.FillOlaJoinByApoMexri(Me.DbhotelDataSet.kiniseisjoineggrafes, TmimSigkentrPnlerPck.Value, TmimSigkentrPnlerPck.Value)
        End If

        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
            Me.DbhotelDataSet.ekt_analkin_logistirio.Rows.Add()
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).imerominia = Me.DbhotelDataSet.kiniseisjoineggrafes(j).imerominia
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).pliromi = Me.DbhotelDataSet.kiniseisjoineggrafes(j).pliromi
            Try
                onomaTmim = Me.TmimataTableAdapter.GetOnomaByKwd(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
            Catch ex As InvalidOperationException
                onomaTmim = "anonymous"
            End Try
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).prakt_tmima = onomaTmim
            indexFpa = fpa_index(Me.DbhotelDataSet.kiniseisjoineggrafes(j).fpa)

            kathPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(j).posoneto
            fpaPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(j).fpaposo
            Me.DbhotelDataSet.ekt_analkin_logistirio(Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1).synolo = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
            If indexFpa <> -1 Then
                plaziere_richtige_stili_fpa_netto(indexFpa, kathPoso)
                plaziere_richtige_stili_fpa(indexFpa, fpaPoso)
            End If

        Next

        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = TmimSigkentrPnlerPck.Value.Date


    End Sub
    Private Sub proepiskopisi_sigkentr()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New TmimataSigkentrotika()

        'Dim j As Int16

        'For j = 0 To Me.DbhotelDataSet.ekt_analkin_logistirio.Count - 1
        '    MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio(j).fpa3)
        'Next
        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
        ektiposi.SetDataSource(DbhotelDataSet)
        'CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    Private Sub init_PliromCbxoen()
        TmimSigkentrPnlerCbx.Items.Clear()
        TmimSigkentrPnlerCbx.Items.Add("Ολοι")
        TmimSigkentrPnlerCbx.Items.Add("Μετρητοίς")
        TmimSigkentrPnlerCbx.Items.Add("Επί Πιστώση")
    End Sub

    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    '**************************ALLAGES KINISEIS TMIMATWN*****************ALLAGES KINISEIS TMIMATWN***********************************ALLAGES KINISEIS TMIMATWN************
    Private Sub allages_kinisi_tmimatwn()
        'tmimaMKwd = -1
        DateTimePicker1.Value = imeromErgasias
        'Etiketa panel initialisieren
        EtiketaLbl.Text = "Αλλαγές Κίνησης Τμημάτων"
        EtiketaLbl.Location = New Point(KatastElegxouPnl.Width / 5, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 40, 60)

        PlirCbx.Items.Clear()
        init_cbx()
        MetritoisPnl.Location = New Point(5, EtiketaPnl.Height)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        Me.MetritoisPnl.Size = New Point(783, KleisimoZentralPnl.Height - 100)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        Me.KleisimoZentralPnl.Controls.Add(MetritoisPnl)
    End Sub
    Private Sub felder_clear()
        FpaPnl.Controls.Clear()
        PosaPnl.Controls.Clear()
        MetritisSpeichPnl.Controls.Clear()
        'SPosaPnl.Controls.Clear()
        'Sum1Pnl.Controls.Clear()
        'Sum2Pnl.Controls.Clear()
        AitiaTbx.Clear()
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        felder_clear()
        EggrafiCbx.SelectedIndex = -1
        'ReDim eggrafesKwd(-1)
        EggrafiCbx.Items.Clear()

        If tmimaMKwd <> Nothing Then
            fuelle_eggrafi_cbox()
        End If
    End Sub
    Private Sub TmimaTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmimaTbx.Enter
        Dim TmimaForm As New TmimataFrm(False)
        Dim kwdikos As Integer
        Dim tmimaName As String

        'Dim praktoreiokwd, praktortimolkwd, currentklines, currenttipos, currentsimbolaio As Integer ' apoimeres

        TmimaForm.StartPosition = FormStartPosition.CenterParent
        TmimaForm.ShowDialog()
        kwdikos = TmimaForm.return_tmima_kwdikos
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Τμήμα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If tmimaMKwd = Nothing Then
                TmimaTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
                Exit Sub
            End If
        Else
            'Guarant2Pnl.Controls.Clear()
            tmimaMKwd = kwdikos
        End If
        felder_clear()
        tmimaName = TmimaForm.return_tmima
        If tmimaName = Nothing Then
            TmimaTbx.Text = sender.text
        Else
            TmimaTbx.Text = tmimaName
        End If
        TmimaForm.Dispose()
        PlirCbx.SelectedIndex = -1
        EggrafiCbx.SelectedIndex = -1
        EggrafiCbx.Items.Clear()
        'ReDim eggrafesKwd(-1)
        AitiaTbx.Clear()
        fuelle_eggrafi_cbox()

        EggrafiCbx.Focus()
    End Sub
    Private Sub fuelle_eggrafi_cbox()
        Dim j As Int16

        Me.TmimataegrafesTableAdapter.FillByTmimaImerominia(Me.DbhotelDataSet.tmimataegrafes, DateTimePicker1.Value, tmimaMKwd)

        For j = 0 To Me.DbhotelDataSet.tmimataegrafes.Count
            If j <> 0 Then
                EggrafiCbx.Items.Add(Me.DbhotelDataSet.tmimataegrafes(j - 1).eggrafi)
                'ReDim Preserve eggrafesKwd(j - 1)
                'eggrafesKwd(j - 1) = Me.DbhotelDataSet.tmimataegrafes(j - 1).kwd
            Else
                EggrafiCbx.Items.Add("ΝΕΑ")
            End If
        Next

    End Sub

    Private Sub EggrafiCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EggrafiCbx.SelectedIndexChanged
        'Dim eggrafiKwd As Integer
        'MsgBox(EggrafiCbx.SelectedIndex)
        If tmimaMKwd > 0 Then
            If EggrafiCbx.SelectedIndex <> -1 Then
                FpaPnl.Controls.Clear()
                PosaPnl.Controls.Clear()
                'SPosaPnl.Controls.Clear()
                'Sum1Pnl.Controls.Clear()
                'Sum2Pnl.Controls.Clear()
                AitiaTbx.Clear()
                PlirCbx.SelectedIndex = -1
                If EggrafiCbx.SelectedIndex > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    'AitiaTbx.Text = Me.DbhotelDataSet.tmimataegrafes(EggrafiCbx.SelectedIndex - 1).aitiologia
                    eggrafiKwd = Me.TmimataegrafesTableAdapter.GetKwdByTmimaImerominiaEggrafi(tmimaMKwd, DateTimePicker1.Value, EggrafiCbx.SelectedItem)
                    male_posa_kinisis(eggrafiKwd)
                    Me.Cursor = Cursors.Default
                Else
                    eggrafiKwd = -1
                    male_posa_kinisis(eggrafiKwd)
                End If
            End If
        Else
            MsgBox("Δεν επιλέχθηκε Τμήμα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End If


    End Sub

    Private Sub male_posa_kinisis(ByVal eggrafiKwd As Integer)
        Dim fpaCount As Int16 = 0
        Dim fpa() As Single
        Dim j, stepy As Int16
        Dim pliromi As String

        stepy = 35
        ReDim fpa(-1)
        If EggrafiCbx.SelectedIndex > 0 Then
            AitiaTbx.Text = Me.DbhotelDataSet.tmimataegrafes(EggrafiCbx.SelectedIndex - 1).aitiologia
            Try
                PlirCbx.SelectedIndex = get_index_tropos_pliromis_cbox(Me.DbhotelDataSet.tmimataegrafes(EggrafiCbx.SelectedIndex - 1).pliromi)
            Catch ex As StrongTypingException
                PlirCbx.SelectedIndex = -1
            End Try
        End If

        'Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)
        Me.TmimataTableAdapter.FillByKwd(Me.DbhotelDataSet.tmimata, tmimaMKwd)
        'edw epilogi posostwn FPA 
        'VORSICHT -> EAN PREPEI NA EXW KAI FPA 0,00% TOTE METATREPSE SE Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 (!) TA PARAKATW KLAUSEL
        For j = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            If Me.DbhotelDataSet.tmimata(j).fpa1 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa1, fpa) Then ' AndAlso Array.Exists(fpa, AddressOf Me.DbhotelDataSet.tmimata(j).fpa1)
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa1
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa2 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa2, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa2
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa3 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa3, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa3
            End If
            If Me.DbhotelDataSet.tmimata(j).fpa4 >= 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.tmimata(j).fpa4, fpa) Then
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.tmimata(j).fpa4
            End If
        Next
        If tmimaMKwd <> -1 Then
            'kanw Join-> oles oi kiniseis tou tmimatos autin tin imera
            Me.EggrafitakiniseisTableAdapter.FillJoinKiniseisByTmima(Me.DbhotelDataSet.eggrafitakiniseis, tmimaMKwd, DateTimePicker1.Value)
        End If
        'se periptosi poy exei alaksei o FPA tou tmimatos kai anatreksoume se mia palaioteri Imerominia-> palaiotero FPA erscheinen lassen!
        For j = 0 To Me.DbhotelDataSet.eggrafitakiniseis.Count - 1
            If Me.DbhotelDataSet.eggrafitakiniseis(j).fpa <> 0 AndAlso Not kommt_vor(Me.DbhotelDataSet.eggrafitakiniseis(j).fpa, fpa) Then ' AndAlso Array.Exists(fpa, AddressOf Me.DbhotelDataSet.tmimata(j).fpa1)
                fpaCount = fpaCount + 1
                ReDim Preserve fpa(fpaCount - 1)
                fpa(fpaCount - 1) = Me.DbhotelDataSet.eggrafitakiniseis(j).fpa
            End If
        Next
        If fpaCount = 0 Then
            MsgBox("Δεν εχουν δωθεί Φ.Π.Α. Τμήματος : Ανατρέξτε στις Σταθερές Εταιρείας (Τμήματα) και ενημερώστε τα ποσά Φ.Π.Α. !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End If
        If eggrafiKwd <> -1 Then
            Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)
        End If


        Dim counter As Int16 = 0
        'Dim ssPoso, ssFpa, ssMaizon, ssMaizFpa As Single
        'diekse ta fpa
        For j = 0 To fpa.Length - 1
            ReDim Preserve kiniseis(fpaCount - 1)
            Dim FpawertLbl As New Label

            counter = get_index_von_dataset(fpa(j))
            FpawertLbl.TextAlign = ContentAlignment.TopCenter
            FpawertLbl.Size = New Point(50, 30)
            FpawertLbl.Text = fpa(j).ToString + "%"

            FpaPnl.Controls.Add(FpawertLbl)
            FpawertLbl.Location = New Point(FpaLbl.Location.X, 10 + j * stepy)

            Dim PosoTbx As New TextBox
            PosoTbx.ForeColor = Color.Maroon
            PosoTbx.TextAlign = HorizontalAlignment.Right
            PosoTbx.MaxLength = 7
            Dim FpaposoTbx As New TextBox
            FpaposoTbx.ForeColor = Color.Maroon
            FpaposoTbx.TextAlign = HorizontalAlignment.Right
            FpaposoTbx.MaxLength = 7
            PosoTbx.Location = New Point(PosoLbl.Location.X - FpaPnl.Width - XPnl.Width - 40, 10 + j * stepy)
            FpaposoTbx.Location = New Point(MaisonLbl.Location.X - FpaPnl.Width - XPnl.Width - 40, 10 + j * stepy)

            PosaPnl.Controls.Add(PosoTbx)
            PosaPnl.Controls.Add(FpaposoTbx)
            AddHandler PosoTbx.Leave, AddressOf wert_eingeben
            AddHandler FpaposoTbx.Leave, AddressOf wert_eingeben
            AddHandler PosoTbx.KeyPress, AddressOf komma_einschalten
            AddHandler FpaposoTbx.KeyPress, AddressOf komma_einschalten


            Dim kwdKinisis As Integer
            Try
                kwdKinisis = Me.EggrafitakiniseisTableAdapter.GetKwdByTmimaeggrFpaPoso(fpa(j), eggrafiKwd)
                PosoTbx.Name = "Poso" + fpa(j).ToString '+ "_" + kwdKinisis.ToString
                FpaposoTbx.Name = "Fpap" + fpa(j).ToString '+ "_" + kwdKinisis.ToString
                If eggrafiKwd <> -1 Then
                    PosoTbx.Text = Me.DbhotelDataSet.eggrafitakiniseis(counter).posoneto.ToString("N") '(Me.DbhotelDataSet.eggrafitakiniseis(counter).poso / (1 + fpa(j) / 100)).ToString("N")
                    'netoPoso = (Me.DbhotelDataSet.eggrafitakiniseis(counter).poso / (1 + fpa(j) / 100)).ToString("N")
                    FpaposoTbx.Text = Me.DbhotelDataSet.eggrafitakiniseis(counter).fpaposo.ToString("N")
                    kiniseis(j).kwdKin = kwdKinisis
                    kiniseis(j).fpa = fpa(j)
                    kiniseis(j).poso = (Me.DbhotelDataSet.eggrafitakiniseis(counter).posoneto + Me.DbhotelDataSet.eggrafitakiniseis(counter).fpaposo).ToString("N")
                    kiniseis(j).netopos = Me.DbhotelDataSet.eggrafitakiniseis(counter).posoneto
                    kiniseis(j).fpapos = Me.DbhotelDataSet.eggrafitakiniseis(counter).fpaposo
                    'Try
                    '    pliromi = Me.TmimataegrafesTableAdapter.GetPliromiByKwd(eggrafiKwd)
                    '    PlirCbx.SelectedIndex = get_index_tropos_pliromis_cbox(pliromi)
                    'Catch ex As InvalidOperationException

                    'End Try

                End If
                counter += 1
            Catch ex As InvalidOperationException
                PosoTbx.Name = "Poso" + fpa(j).ToString '+ "_" + (-1).ToString
                PosoTbx.Text = "0,00"
                FpaposoTbx.Name = "Fpap" + fpa(j).ToString '+ "_" + (-1).ToString
                FpaposoTbx.Text = "0,00"
                kiniseis(j).kwdKin = -1
                kiniseis(j).fpa = fpa(j)
                kiniseis(j).poso = 0
                kiniseis(j).netopos = 0
                kiniseis(j).fpapos = 0
            End Try
        Next

        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        'SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10))
        SpeicherButton.Location = New Point(MetritisSpeichPnl.Width / 2 - 80, 40)
        MetritisSpeichPnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf kiniseis_speichern   'MsgBox

    End Sub

    Private Sub kiniseis_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim j As Int16
        Dim maxEggr As Byte
        Dim neuEggr As Boolean = False
        Dim pliromi As String

        'Achtung 1 tmima exei ana imera poles Eggrafes kai kathe eggrafi exei kai polles kiniseis (fpa 9,19 usw) 

        pliromi = Me.PlirCbx.SelectedItem


        Me.TmimataegrafesTableAdapter.UpdatePliromiImeromAitioByKwd(pliromi, DateTimePicker1.Value, AitiaTbx.Text, eggrafiKwd)

        For j = 0 To kiniseis.Length - 1
            If kiniseis(j).kwdKin <> -1 Then 'yparxei i kinisi
                If kiniseis(j).poso = 0 Then
                    Try
                        Me.EggrafitakiniseisTableAdapter.DeleteKinisi(kiniseis(j).kwdKin)
                    Catch ex As OleDb.OleDbException
                        MsgBox("Παρουσιάστηκε πρόβλημα στην Διαγραφή μίας Κίνησης !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                Else 'update kinisi
                    Try
                        'Me.EggrafitakiniseisTableAdapter.UpdateKinisi(eggrafiKwd, kiniseis(j).fpa, kiniseis(j).poso, 0, kiniseis(j).kwdKin)
                        Me.EggrafitakiniseisTableAdapter.UpdateKinisi(eggrafiKwd, kiniseis(j).fpa, kiniseis(j).poso, kiniseis(j).maizon, kiniseis(j).netopos, kiniseis(j).fpapos, kiniseis(j).netomaizon, kiniseis(j).fpamaizon, kiniseis(j).kwdKin)
                    Catch ex As OleDb.OleDbException
                        MsgBox("Παρουσιάστηκε πρόβλημα στην Ενημέρωση μίας Κίνησης !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If
            ElseIf kiniseis(j).poso <> 0 Then
                If eggrafiKwd <> -1 Then 'Nea Kinisi-> h sxetiki eggrafi ston pinaka TMIMATAEGGRAFES iparxei 
                    Try
                        'Me.EggrafitakiniseisTableAdapter.InsertKinisi(eggrafiKwd, kiniseis(j).fpa, kiniseis(j).poso, 0)
                        Me.EggrafitakiniseisTableAdapter.InsertKinisi(eggrafiKwd, kiniseis(j).fpa, kiniseis(j).poso, kiniseis(j).maizon, kiniseis(j).netopos, kiniseis(j).fpapos, kiniseis(j).netomaizon, kiniseis(j).fpamaizon)
                    Catch ex As OleDb.OleDbException
                        MsgBox("Παρουσιάστηκε πρόβλημα στην Εισαγωγή νέας Κίνησης !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                Else 'Nea eggrafi + nea kratisi
                    Try
                        maxEggr = Me.TmimataegrafesTableAdapter.GetMaxEggrafiByTmimaImerom(tmimaMKwd, DateTimePicker1.Value)
                    Catch ex As InvalidOperationException
                        maxEggr = 0
                    End Try

                    Me.TmimataegrafesTableAdapter.InsertEggrafi(tmimaMKwd, DateTimePicker1.Value, (maxEggr + 1), AitiaTbx.Text, pliromi)
                    Try
                        eggrafiKwd = Me.TmimataegrafesTableAdapter.GetKwdByTmimaImerominiaEggrafi(tmimaMKwd, DateTimePicker1.Value, (maxEggr + 1))
                    Catch ex As InvalidOperationException
                        MsgBox("Παρουσιάστηκε πρόβλημα στην Εισαγωγή νέας Εγγραφής !", MsgBoxStyle.Critical, "winfo\nikEl.")
                        Exit Sub
                    End Try
                    Me.EggrafitakiniseisTableAdapter.InsertKinisi(eggrafiKwd, kiniseis(j).fpa, kiniseis(j).poso, 0, kiniseis(j).netopos, kiniseis(j).fpapos, 0, 0)
                    'EggrafiCbx.SelectedIndex = -1
                    neuEggr = True
                End If

            End If
        Next
        Me.TmimataegrafesTableAdapter.FillByTmimaImerominia(Me.DbhotelDataSet.tmimataegrafes, DateTimePicker1.Value, tmimaMKwd)
        If Not neuEggr Then
            FpaPnl.Controls.Clear()
            PosaPnl.Controls.Clear()
            'SPosaPnl.Controls.Clear()
            'Sum1Pnl.Controls.Clear()
            'Sum2Pnl.Controls.Clear()
            AitiaTbx.Clear()
            Try
                AitiaTbx.Text = Me.DbhotelDataSet.tmimataegrafes(EggrafiCbx.SelectedIndex - 1).aitiologia
            Catch ex As IndexOutOfRangeException

            End Try
            ReDim kiniseis(-1)
            'Me.TmimataegrafesTableAdapter.FillByTmimaImerominia(Me.DbhotelDataSet.tmimataegrafes, DateTimePicker1.Value, tmimaMKwd)
            male_posa_kinisis(eggrafiKwd)
        Else
            neuEggr = False
            EggrafiCbx.Items.Clear()
            ReDim kiniseis(-1)
            fuelle_eggrafi_cbox()

            EggrafiCbx.SelectedIndex = Me.DbhotelDataSet.tmimataegrafes.Count
        End If


    End Sub
    Private Sub wert_eingeben(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fpa As String = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)
        Dim index As Int16

        Try
            sender.text = CType(sender.text, Single).ToString("N")
        Catch ex As Exception
            sender.text = "0,00"
        End Try
        index = return_index(fpa)

        If sender.NAME.Substring(0, 4).Equals("Poso") AndAlso sender.text <> kiniseis(index).poso Then
            kiniseis(index).netopos = sender.text
        ElseIf sender.NAME.Substring(0, 4).Equals("Fpap") AndAlso sender.text <> kiniseis(index).fpapos Then
            kiniseis(index).fpapos = sender.text
        End If
        kiniseis(index).poso = kiniseis(index).netopos + kiniseis(index).fpapos
    End Sub
    Private Sub init_cbx()
        Dim j As Int16

        Me.PlirCbx.SelectedIndex = -1
        Me.PlirCbx.Items.Clear()
        'ReDim parastCboxKwd(Me.DbhotelDataSet.parastatika.Count - 1)
        'For j = 0 To Me.DbhotelDataSet.parastatika.Count - 1
        '    Me.PlirCbx.Items.Add(Me.DbhotelDataSet.parastatika(j).tipos + " " + Me.DbhotelDataSet.parastatika(j).seira)
        '    'parastCboxKwd(j) = Me.DbhotelDataSet.parastatika(j).kwd
        'Next
        For j = 0 To Me.DbhotelDataSet.pistwtikes.Count + 1
            If j = 0 Then
                PlirCbx.Items.Add("Επί Πιστώση")
            ElseIf j = 1 Then
                PlirCbx.Items.Add("Μετρητοίς")
            Else
                PlirCbx.Items.Add(Me.DbhotelDataSet.pistwtikes(j - 2).karta)

            End If
        Next
        'MsgBox(PliromCbx.Items.Count)
        'EkdosiParastTrPliromCbx
    End Sub
    Private Function return_index(ByVal fpa As Single) As Int16
        Dim j As Int16
        For j = 0 To kiniseis.Length - 1
            If kiniseis(j).fpa = fpa Then
                Return j
            End If
        Next
        Return -1
    End Function

    Private Function get_index_von_dataset(ByVal fpa As Single)
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.eggrafitakiniseis.Count - 1
            If Me.DbhotelDataSet.eggrafitakiniseis(j).fpa = fpa Then
                Return j
            End If
        Next
        Return -1

    End Function
    Private Sub PliromCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PliromCbx.TextUpdate
        MsgBox("Δεν επιτρέπεται αλλαγή !", MsgBoxStyle.Information, "winfo\nikEl.")
        PlirCbx.SelectedIndex = -1
    End Sub

    Private Function get_index_tropos_pliromis_cbox(ByVal pliromi As String) As Int16
        Dim i As Int16

        For i = 0 To PlirCbx.Items.Count - 1
            If PlirCbx.Items(i).ToString = pliromi Then
                Return i
            End If
        Next
        Return -1
    End Function

    '**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE
    '**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE
    '**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE
    '**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE**********************MAIN COURANTE
    Private Sub ekt_main_courante()
        'tmimaMKwd = -1
        MainCourantePck.Value = imeromErgasias.AddDays(-1)
        'Etiketa panel initialisieren
        EtiketaLbl.Text = "Εκτύπωση Main Courante"
        EtiketaLbl.Location = New Point(MainCourantePnl.Width / 5, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)

        MainCourantePnl.Location = New Point(70, EtiketaPnl.Height)
        Me.MainCourantePnl.Size = New Point(355, 194)

        'xrisimopoiw ta Idia Procedure kai FpaLog() me tis ektiposeis Logidtiriou gia kinisi Imeras
        'bazw ta fpa pou paizoun sto FpaLog
        Me.DbhotelDataSet.ekt_fpa_logistirio.Clear()
        fuelle_fpa(True, True)
        'kai meta sto Dataset ->Dynamiko Malen tis epikefalidas me ta FPA!
        fuelle_fpa_werte_zu_dataset()
        EtiketaPnl.Controls.Add(EtiketaLbl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        Me.KleisimoZentralPnl.Controls.Add(MainCourantePnl)
    End Sub

    Private Sub MainCouranteBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainCouranteBtn.Click
        Dim startIndex, stepsIndex As Int16
        Dim onomTemp As String()
        Dim isLeerOK As Boolean = False 'ta dataset main_curante einai keno->den uparxoun trexontes dianiktereuseis
        'einai sortiert kata seira->dwmatio, arithmos kratisi, apo
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DbhotelDataSet.main_curante.Clear()
            Me.DbhotelDataSet.ekt_main_courante.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            Me.DbhotelDataSet.ekt_dwmatia_mc.Clear()
            Me.DbhotelDataSet.ekt_prwina_mc.Clear()
            Me.DbhotelDataSet.ekt_geumata_mc.Clear()
            Me.DbhotelDataSet.ekt_extras_mc.Clear()
            Me.DbhotelDataSet.ekt_group_mcurante.Clear()
            Me.DbhotelDataSet.ekt_extra_parast_mc.Clear()
            Me.DbhotelDataSet.ekt_tmimata_mc.Clear()

            Me.DbhotelDataSet.ekt_analkin_logistirio.Clear()
            Me.DbhotelDataSet.ekt_sum_timol_mc.Clear()

            'Join anfrage gia to prwto skelos ths main courante
            Me.Main_curanteTableAdapter.MainCuranteByEtosChckinAnaxApo(Me.DbhotelDataSet.main_curante, etos, True, MainCourantePck.Value.Date, MainCourantePck.Value.Date)
            'tupel (onoma, arithmos kratisis) autwn menoun autin tin stigmi sto xenodoxeio (xwris autous pou anaxwroun)
            Me.KratiseisenilikesTableAdapter.MainCouranteByAnaxChin(DbhotelDataSet.kratiseisenilikes, MainCourantePck.Value.Date, True)

            Do Until startIndex > Me.DbhotelDataSet.main_curante.Count - 1
                stepsIndex = 1 'posa eintraege 

                'firstIndex = startIndex
                If startIndex < Me.DbhotelDataSet.main_curante.Count - 1 Then
                    'gia kathemia kRatisi
                    While Me.DbhotelDataSet.main_curante(startIndex).arithmos = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex).arithmos
                        stepsIndex += 1
                        If startIndex + stepsIndex > Me.DbhotelDataSet.main_curante.Count - 1 Then
                            Exit While
                        End If
                    End While
                    'bres ta onomta tis kratisis
                    onomTemp = suche_onomata_kratisis(Me.DbhotelDataSet.main_curante(startIndex).arithmos)
                    'ftiaxw to prwto meros tis ektiposis me tis kratiseis me trexouses times
                    make_ektiposi_dataset_section_1(startIndex, stepsIndex, onomTemp)
                    startIndex = startIndex + stepsIndex
                Else
                    onomTemp = suche_onomata_kratisis(Me.DbhotelDataSet.main_curante(startIndex).arithmos)

                    make_ektiposi_dataset_section_1(startIndex, stepsIndex, onomTemp)

                    Exit Do
                End If
            Loop


            If Me.DbhotelDataSet.ekt_main_courante.Count = 0 Then
                make_null_werte_dataset()
                '  (-> To keno praktoreio DEN emfanizetai stin Ektiposi
                'mono ws SYnolo praktotreiwn)
                isLeerOK = True
            End If


            init_ekt_mc_datasets()

            'ektiposi B' meros me ta timologia 
            make_ektiposi_dataset_section_2()

            'make_ektiposi_dataset_section_2(False)
            ' meros ektiposis me extra parststika (exoflimena)
            make_ektiposi_dataset_extra_parastatika(True)
            ' meros ektiposis me extra parststika (epi pistosi)
            make_ektiposi_dataset_extra_parastatika(False)
            'ektiposi tmimatwn (zentra) eggrafwn->ziemlich komlex da to CR DEN upostirizei sto Report Footer pola Reihen->mono MIA Reihe->
            'prospathw me allagis seiras (me to Chrw(16)) mesa se ena Kaestchen na kanw douleia! 
            make_dataset_tmimata_eggrafes()

            Me.DbhotelDataSet.ekt_sum_timol_mc.Rows.Add()
            Me.TimologiaTableAdapter.FillSumForMainCouranteByImerExoflMemAkyrDomisi(Me.DbhotelDataSet.timologia, MainCourantePck.Value.Date, True, True, False)
            If Me.DbhotelDataSet.timologia.Count = 1 Then
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).tameiobrutosum = Me.DbhotelDataSet.timologia(0).synola
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).tameiofpasum = Me.DbhotelDataSet.timologia(0).fpa
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).tameionetosum = Me.DbhotelDataSet.timologia(0).synola - Me.DbhotelDataSet.timologia(0).fpa 'Me.DbhotelDataSet.timologia(0).sumkathposa
            End If
            Me.TimologiaTableAdapter.FillSumForMainCouranteByImerExoflMemAkyrDomisi(Me.DbhotelDataSet.timologia, MainCourantePck.Value.Date, False, True, False)
            If Me.DbhotelDataSet.timologia.Count = 1 Then
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).xrewstesnetosum = Me.DbhotelDataSet.timologia(0).synola - Me.DbhotelDataSet.timologia(0).fpa ' Me.DbhotelDataSet.timologia(0).sumkathposa
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).xrewstesfpasum = Me.DbhotelDataSet.timologia(0).fpa
                Me.DbhotelDataSet.ekt_sum_timol_mc(0).xrewstesbrutosum = Me.DbhotelDataSet.timologia(0).synola

            End If
            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = MainCourantePck.Value.ToShortDateString
            Try
                'to proigoumeno Ypoloipo= SumMexriKaitrexousa - SumMonoTrexousa + KommenaMemonomenaTimologiaAnaxwrountwn + AkopaMemTimologiaAnaxwrountwn
                'kanw abfrage gia Akopa timologia anaxwrountwn kai to poso to kanw meson ektiposeis_genika(0).poso uebergeben sto CR 
                Me.DbhotelDataSet.ektiposeis_genika(0).poso = Me.KratiseisTableAdapter.GetPosoProsTimologisMCByAnaxChinTim(MainCourantePck.Value.Date, 0, True)
            Catch ex As InvalidOperationException
                Me.DbhotelDataSet.ektiposeis_genika(0).poso = 0
            End Try
            Me.DbhotelDataSet.ekt_group_mcurante.Clear()
            Me.DbhotelDataSet.ekt_group_mcurante.Rows.Add()
            Me.DbhotelDataSet.ekt_group_mcurante(0).group_id = 1
            proepiskopisi_maim_courante(isLeerOK)
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    ' foularw to Dataset ekt_main_courante gia to CR
    Private Sub make_ektiposi_dataset_section_1(ByVal startIndex As Int16, ByVal stepsIndex As Int16, ByVal onomTemp As String())
        Dim j, imeres As Int16
        Dim ypnossum, ypnosaisum, prwinosum, geumatasum, extrasum As Single
        Dim onomata As String = ""
        'mexri kai trexousa imerominia laufvariable
        ypnossum = 0
        ypnosaisum = 0
        prwinosum = 0
        geumatasum = 0
        extrasum = 0

        For j = startIndex To startIndex + stepsIndex - 1

            'imeres mexri kai simera
            If MainCourantePck.Value <= Me.DbhotelDataSet.main_curante(j).mexri Then
                imeres = MainCourantePck.Value.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
            Else
                imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
            End If


            If Me.DbhotelDataSet.main_curante(j).xrewsikwd = 6 Then 'STARR!!!!!!!!!!!!!!
                ypnosaisum = ypnosaisum + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            Else
                ypnossum = ypnossum + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            End If
            prwinosum = prwinosum + imeres * Me.DbhotelDataSet.main_curante(j).prwino
            geumatasum = geumatasum + imeres * (Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno)
            extrasum = extrasum + imeres * Me.DbhotelDataSet.main_curante(j).extra
        Next


        Me.DbhotelDataSet.ekt_main_courante.Rows.Add()
        'to group_id to xreiazomai gia na grouparw ta apotelesmata stoCR->Exw MONO ena DataTable gia Arxiko Group (ekt_group_mcurante) pou exei group_id panta 1 kai 
        'ola ta untergoups (praktoreia) exoun Verweis auf ekt_group_mcurante (gia na dimiourgisw optisch ta Untergroupen)
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).group_id = 1
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).eponimia = Me.DbhotelDataSet.main_curante(startIndex).eponimia

        If onomTemp.Length > 0 Then
            If onomTemp.Length > 1 Then
                onomata = onomTemp(0) + ChrW(13) + onomTemp(1)
            Else
                onomata = onomTemp(0)
            End If
        End If
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).onomateponima = LTrim(onomata)

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).diarkeia = Me.DbhotelDataSet.main_curante(startIndex).afixi.ToShortDateString + " -" + ChrW(13) + "  " + Me.DbhotelDataSet.main_curante(startIndex).anaxwrisi.ToShortDateString

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).dwmatio = Me.DbhotelDataSet.main_curante(startIndex).dwmatio

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).enilikes = Me.DbhotelDataSet.main_curante(startIndex).enilikes
        Try
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).paidia = Me.DbhotelDataSet.main_curante(startIndex).paidia
        Catch ex As StrongTypingException
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).paidia = 0
        End Try


        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).atoma = Me.DbhotelDataSet.main_curante(startIndex).enilikes + Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).paidia

        'xreiazomai to athroisma twn garantie kratisewn ana praktoreio->kathe garantie pairnei 1 gia na kanw to athroisma sto CReport
        If Me.DbhotelDataSet.main_curante(startIndex).guarantie Then
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).guarant = 1
        Else
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).guarant = 0
        End If

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnossum = ypnossum
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnosaisum = ypnosaisum
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).prwinosum = prwinosum
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).geumatasum = geumatasum
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).extrasum = extrasum
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).synolosum = ypnossum + ypnosaisum + prwinosum + geumatasum + extrasum

        If Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).xrewsikwd = 6 Then
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnosai = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).ypnos
        Else
            Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnos = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).ypnos
        End If
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).prwino = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).prwino
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).geumata = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).geuma + Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).deipno
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).extra = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).extra
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).synolo = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).ypnos + Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).prwino +
        Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).geuma + Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).deipno + Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).extra
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).xrewsi = Me.DbhotelDataSet.main_curante(startIndex + stepsIndex - 1).xrewsi

    End Sub
    'B meros Ektiposis ->Tameio kai Xrewseis apo MEMONOMENA timologia anaxwrountwn
    Private Sub make_ektiposi_dataset_section_2() 'ByVal exoflithiOK As Boolean
        Dim ypnos, prwino, geumata, extra, allinclusiv, ypnosFpa, prwinoFpa, geumataFpa, extraFpa As Single
        Dim j, index As Int16

        Me.EpanekdositimologiouTableAdapter.FillMainCouranteByImMemAkyr(Me.DbhotelDataSet.epanekdositimologiou, MainCourantePck.Value.Date, True, False)

        For j = 0 To Me.DbhotelDataSet.epanekdositimologiou.Count - 1
            ypnos = 0
            prwino = 0
            geumata = 0
            extra = 0
            'me ta plaziere bazw to swsto katharo poso kai fpa sto antistoixo column tou ekt_analkin_logistirio 
            'If j = 17 Then
            '    MsgBox(j)
            '    ypnos = 0
            'End If

            ypnos = Me.DbhotelDataSet.epanekdositimologiou(j).ypnos
            prwino = Me.DbhotelDataSet.epanekdositimologiou(j).prwino
            geumata = Me.DbhotelDataSet.epanekdositimologiou(j).geuma
            geumata = geumata + Me.DbhotelDataSet.epanekdositimologiou(j).deipno
            extra = Me.DbhotelDataSet.epanekdositimologiou(j).extra
            allinclusiv = Me.DbhotelDataSet.epanekdositimologiou(j).allinclusiv

            If Me.DbhotelDataSet.epanekdositimologiou(j).ekptosi Then
                'MsgBox(Me.DbhotelDataSet.epanekdositimologiou(j).arithmos)
                If Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto <> 0 Then
                    If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                        ypnos = ypnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                        prwino = prwino - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).prwino / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                        geumata = geumata - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * (Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / 100)
                    End If
                    If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                        extra = extra - (Me.DbhotelDataSet.epanekdositimologiou(j).ekptpososto * Me.DbhotelDataSet.epanekdositimologiou(j).extra / 100)
                    End If
                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo <> 0 Then
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        ypnos = ypnos - Me.DbhotelDataSet.epanekdositimologiou(j).ekptposo / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                    End If


                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres <> 0 Then
                    'MsgBox(Me.DbhotelDataSet.epanekdositimologiou(j).timkwd)
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        If Me.DbhotelDataSet.epanekdositimologiou(j).ypnos <> 0 Then
                            ypnos = ypnos - (Me.DbhotelDataSet.epanekdositimologiou(j).ypnos / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).prwino <> 0 Then
                            prwino = prwino - (Me.DbhotelDataSet.epanekdositimologiou(j).prwino / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).geuma <> 0 Or Me.DbhotelDataSet.epanekdositimologiou(j).deipno <> 0 Then
                            geumata = geumata - ((Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno) / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If
                        If Me.DbhotelDataSet.epanekdositimologiou(j).extra <> 0 Then
                            extra = extra - (Me.DbhotelDataSet.epanekdositimologiou(j).extra / Me.DbhotelDataSet.epanekdositimologiou(j).imeres * Me.DbhotelDataSet.epanekdositimologiou(j).ekptimeres)
                        End If

                    End If

                ElseIf Me.DbhotelDataSet.epanekdositimologiou(j).fee <> 0 Then
                    If (j < Me.DbhotelDataSet.epanekdositimologiou.Count - 1 AndAlso Me.DbhotelDataSet.epanekdositimologiou(j).arithmos <> Me.DbhotelDataSet.epanekdositimologiou(j + 1).arithmos) OrElse (j = Me.DbhotelDataSet.epanekdositimologiou.Count - 1) Then
                        ypnos = ypnos + Me.DbhotelDataSet.epanekdositimologiou(j).fee * Me.DbhotelDataSet.epanekdositimologiou(j).preistag / (1 + (Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100))
                    End If
                End If
            End If

            If ypnos <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).ypnos, Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis1) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis1) + 1
                    'kane plazieren tin timi stin richtige stili
                    mc_plaziere_dwmatio_stili(index, ypnos, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    ypnosFpa = (ypnos * Me.DbhotelDataSet.etaireia(0).fpatrofis1 / 100)
                    mc_plaziere_dwmatio_stili(index, ypnosFpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                Else
                    mc_plaziere_dwmatio_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).ypnos, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    mc_plaziere_dwmatio_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).ypnosfpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                End If
            End If
            If prwino <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).prwino, Me.DbhotelDataSet.epanekdositimologiou(j).prwinofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
                    mc_plaziere_prwino_stili(index, prwino, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    prwinoFpa = (prwino * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
                    mc_plaziere_prwino_stili(index, prwinoFpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                Else
                    mc_plaziere_prwino_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).prwino, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    mc_plaziere_prwino_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).prwinofpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                End If
            End If
            If geumata <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).geuma, Me.DbhotelDataSet.epanekdositimologiou(j).geumafpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) _
                OrElse ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).deipno, Me.DbhotelDataSet.epanekdositimologiou(j).deipnofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
                    mc_plaziere_geumata_stili(index, geumata, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    geumataFpa = (geumata * Me.DbhotelDataSet.etaireia(0).fpatrofis2 / 100)
                    mc_plaziere_geumata_stili(index, geumataFpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                Else
                    mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).geuma + Me.DbhotelDataSet.epanekdositimologiou(j).deipno, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).geumafpa + Me.DbhotelDataSet.epanekdositimologiou(j).deipnofpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                End If
            End If
            If extra <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.epanekdositimologiou(j).extra, Me.DbhotelDataSet.epanekdositimologiou(j).extrfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis3) + 1
                    mc_plaziere_extras_stili(index, extra, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    extraFpa = (extra * Me.DbhotelDataSet.etaireia(0).fpatrofis3 / 100)
                    mc_plaziere_extras_stili(index, extraFpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                Else
                    mc_plaziere_extras_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).extra, False, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                    mc_plaziere_extras_stili(1, Me.DbhotelDataSet.epanekdositimologiou(j).extrfpa, True, Me.DbhotelDataSet.epanekdositimologiou(j).exoflithi)
                End If
            End If

        Next
        'Me.TimologioanalysisTableAdapter.FillJoinSumForMainCuranteByMemImerExoflAkyro(Me.DbhotelDataSet.timologioanalysis, True, MainCourantePck.Value.Date, exoflithiOK, False)


        'If Me.DbhotelDataSet.timologioanalysis.Count = 1 Then
        '    If Me.DbhotelDataSet.timologioanalysis(0).ypnos <> 0 Then
        '        'einai to Fpa aktuel?
        '        If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).ypnos, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis1) Then
        '            'bres tin thesi tou fpa
        '            index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis1) + 1
        '            'kane plazieren tin timi stin richtige stili
        '            mc_plaziere_dwmatio_stili(index, Me.DbhotelDataSet.timologioanalysis(0).ypnos, False, exoflithiOK)
        '            mc_plaziere_dwmatio_stili(index, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, True, exoflithiOK)
        '        Else ' eaan exei alaksei to fpa i den uparxei tote stin stili tou O
        '            mc_plaziere_dwmatio_stili(1, Me.DbhotelDataSet.timologioanalysis(0).ypnos, False, exoflithiOK)
        '            mc_plaziere_dwmatio_stili(1, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, True, exoflithiOK)
        '        End If

        '    End If
        '    If Me.DbhotelDataSet.timologioanalysis(0).prwino <> 0 Then
        '        If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).prwino, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
        '            index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
        '            mc_plaziere_prwino_stili(index, Me.DbhotelDataSet.timologioanalysis(0).prwino, False, exoflithiOK)
        '            mc_plaziere_prwino_stili(index, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, True, exoflithiOK)
        '        Else ' eaan exei alaksei to fpa i den uparxei tote stin stili tou O
        '            mc_plaziere_prwino_stili(1, Me.DbhotelDataSet.timologioanalysis(0).prwino, False, exoflithiOK)
        '            mc_plaziere_prwino_stili(1, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, True, exoflithiOK)
        '        End If

        '    End If
        '    If Me.DbhotelDataSet.timologioanalysis(0).geuma <> 0 Then
        '        If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).geuma, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
        '            index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
        '            mc_plaziere_geumata_stili(index, Me.DbhotelDataSet.timologioanalysis(0).geuma, False, exoflithiOK)
        '            mc_plaziere_geumata_stili(index, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, True, exoflithiOK)
        '        Else
        '            mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.timologioanalysis(0).geuma, False, exoflithiOK)
        '            mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, True, exoflithiOK)
        '        End If
        '    End If
        '    If Me.DbhotelDataSet.timologioanalysis(0).deipno <> 0 Then
        '        If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).deipno, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
        '            index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
        '            mc_plaziere_geumata_stili(index, Me.DbhotelDataSet.timologioanalysis(0).deipno, False, exoflithiOK)
        '            mc_plaziere_geumata_stili(index, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, True, exoflithiOK)
        '        Else
        '            mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.timologioanalysis(0).deipno, False, exoflithiOK)
        '            mc_plaziere_geumata_stili(1, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, True, exoflithiOK)
        '        End If

        '    End If
        '    If Me.DbhotelDataSet.timologioanalysis(0).extra <> 0 Then
        '        If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).extra, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
        '            index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis3) + 1
        '            mc_plaziere_extras_stili(index, Me.DbhotelDataSet.timologioanalysis(0).extra, False, exoflithiOK)
        '            mc_plaziere_extras_stili(index, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, True, exoflithiOK)
        '        Else
        '            mc_plaziere_extras_stili(1, Me.DbhotelDataSet.timologioanalysis(0).extra, False, exoflithiOK)
        '            mc_plaziere_extras_stili(1, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, True, exoflithiOK)
        '        End If
        '    End If
        'End If


    End Sub
    'gia kathe Kostenstelle (dwmatio,prwina, geumata ,extras) anlyse tin timi tou timologiou ana fpa!
    Private Sub mc_plaziere_dwmatio_stili(ByVal index As Int16, ByVal poso As Single, ByVal isFpa As Boolean, ByVal exoflithi As Boolean)
        Select Case index
            Case 1
                If exoflithi Then '->TAMEIO!->aristero meros ektiposis
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa1poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa1fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa1fpa + poso
                    End If
                Else '_>Xrewstes->deksi meros ektiposis
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa1poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa1fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa1fpa + poso
                    End If
                End If
            Case 2
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa2poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa2fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa2fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa2poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa2fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa2fpa + poso
                    End If
                End If
            Case 3
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa3poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa3fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa3fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa3poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa3fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa3fpa + poso
                    End If
                End If
            Case 4

                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa4poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa4fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).metrfpa4fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa4poso = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa4fpa = Me.DbhotelDataSet.ekt_dwmatia_mc(0).pistfpa4fpa + poso
                    End If
                End If
        End Select
    End Sub
    Private Sub mc_plaziere_prwino_stili(ByVal index As Int16, ByVal poso As Single, ByVal isFpa As Boolean, ByVal exoflithi As Boolean)
        Select Case index
            Case 1
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa1poso = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa1fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa1fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa1poso = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa1fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa1fpa + poso
                    End If
                End If
            Case 2
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa2poso = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa2fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa2fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa2poso = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa2fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa2fpa + poso
                    End If
                End If
            Case 3
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa3poso = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa3fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa3fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa3poso = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa3fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa3fpa + poso
                    End If
                End If
            Case 4

                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa4poso = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa4fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).metrfpa4fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa4poso = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa4fpa = Me.DbhotelDataSet.ekt_prwina_mc(0).pistfpa4fpa + poso
                    End If
                End If
        End Select
    End Sub
    Private Sub mc_plaziere_geumata_stili(ByVal index As Int16, ByVal poso As Single, ByVal isFpa As Boolean, ByVal exoflithi As Boolean)
        Select Case index
            Case 1
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa1poso = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa1fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa1fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa1poso = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa1fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa1fpa + poso
                    End If
                End If
            Case 2
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa2poso = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa2fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa2fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa2poso = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa2fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa2fpa + poso
                    End If
                End If
            Case 3
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa3poso = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa3fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa3fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa3poso = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa3fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa3fpa + poso
                    End If
                End If
            Case 4

                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa4poso = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa4fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).metrfpa4fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa4poso = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa4fpa = Me.DbhotelDataSet.ekt_geumata_mc(0).pistfpa4fpa + poso
                    End If
                End If
        End Select
    End Sub
    Private Sub mc_plaziere_extras_stili(ByVal index As Int16, ByVal poso As Single, ByVal isFpa As Boolean, ByVal exoflithi As Boolean)
        Select Case index
            Case 1
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa1poso = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa1fpa = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa1fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa1poso = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa1fpa = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa1fpa + poso
                    End If
                End If
            Case 2
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa2poso = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa2fpa = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa2fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa2poso = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa2fpa = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa2fpa + poso
                    End If
                End If
            Case 3
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa3poso = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa3fpa = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa3fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa3poso = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa3fpa = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa3fpa + poso
                    End If
                End If
            Case 4

                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa4poso = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa4fpa = Me.DbhotelDataSet.ekt_extras_mc(0).metrfpa4fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa4poso = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa4fpa = Me.DbhotelDataSet.ekt_extras_mc(0).pistfpa4fpa + poso
                    End If
                End If
        End Select
    End Sub
    Private Sub make_ektiposi_dataset_extra_parastatika(ByVal exoflithiOK As Boolean)
        Dim index As Int16

        Me.TimologioanalysisTableAdapter.FillJoinSumExtraParastMCByExtrImerMaurAkyroExof(Me.DbhotelDataSet.timologioanalysis, True, MainCourantePck.Value.Date, False, exoflithiOK, False)


        If Me.DbhotelDataSet.timologioanalysis.Count = 1 Then
            If Me.DbhotelDataSet.timologioanalysis(0).ypnos <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).ypnos, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis1) Then

                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis1) + 1

                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).ypnos, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, True, exoflithiOK)
                Else ' eaan exei alaksei to fpa i den uparxei tote stin stili tou O
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).ypnos, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).ypnosfpa, True, exoflithiOK)
                End If

            End If
            If Me.DbhotelDataSet.timologioanalysis(0).prwino <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).prwino, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).prwino, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, True, exoflithiOK)
                Else
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).prwino, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).prwinofpa, True, exoflithiOK)
                End If

            End If
            If Me.DbhotelDataSet.timologioanalysis(0).geuma <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).geuma, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).geuma, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, True, exoflithiOK)
                Else
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).geuma, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).geumafpa, True, exoflithiOK)
                End If
            End If
            If Me.DbhotelDataSet.timologioanalysis(0).deipno <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).deipno, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, Me.DbhotelDataSet.etaireia(0).fpatrofis2) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis2) + 1
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).deipno, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, True, exoflithiOK)
                Else
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).deipno, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).deipnofpa, True, exoflithiOK)
                End If

            End If
            If Me.DbhotelDataSet.timologioanalysis(0).extra <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).extra, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis3) + 1
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).extra, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, True, exoflithiOK)
                Else
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).extra, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).extrfpa, True, exoflithiOK)
                End If
            End If
            If Me.DbhotelDataSet.timologioanalysis(0).allinclusiv <> 0 Then
                If ist_fpa_aktuell(Me.DbhotelDataSet.timologioanalysis(0).allinclusiv, Me.DbhotelDataSet.timologioanalysis(0).allinclusivfpa, Me.DbhotelDataSet.etaireia(0).fpatrofis3) Then
                    index = fpa_index(Me.DbhotelDataSet.etaireia(0).fpatrofis3) + 1
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).allinclusiv, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(index, Me.DbhotelDataSet.timologioanalysis(0).allinclusivfpa, True, exoflithiOK)
                Else
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).allinclusiv, False, exoflithiOK)
                    mc_plaziere_extra_parast_stili(1, Me.DbhotelDataSet.timologioanalysis(0).allinclusivfpa, True, exoflithiOK)
                End If
            End If
        End If


    End Sub
    Private Sub mc_plaziere_extra_parast_stili(ByVal index As Int16, ByVal poso As Single, ByVal isFpa As Boolean, ByVal exoflithi As Boolean)
        Select Case index
            Case 1
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa1poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa1fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa1fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa1poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa1poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa1fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa1fpa + poso
                    End If
                End If
            Case 2
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa2poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa2fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa2fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa2poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa2poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa2fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa2fpa + poso
                    End If
                End If
            Case 3
                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa3poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa3fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa3fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa3poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa3poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa3fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa3fpa + poso
                    End If
                End If
            Case 4

                If exoflithi Then
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa4poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa4fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).metrfpa4fpa + poso
                    End If
                Else
                    If Not isFpa Then
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa4poso = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa4poso + poso
                    Else
                        Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa4fpa = Me.DbhotelDataSet.ekt_extra_parast_mc(0).pistfpa4fpa + poso
                    End If
                End If
        End Select
    End Sub
    'edw to meros tis ektipois me ta tmimata (zentral) me tin analysi ana Fpa->PROBLEM sto CR pou DEN kanei Unterstuetzen sto ReportFooter 
    'pola Reihen->se MIA reihe OLA->me tin allagi seiras (Chrw(16))!!!!
    Private Sub make_dataset_tmimata_eggrafes()
        Dim j, index As Int16
        Dim kathPoso, fpaPoso As Single
        Dim temp As String = ""
        Dim posa() As Single ' bruto posa apo Me.DbhotelDataSet.kiniseisjoineggrafes(0).poso
        Dim tmimata() As String 'tmimata pou paizoun
        Dim laenge As Int16 = -1
        Dim zeileWechsel() As Boolean 'DSTR gia na parakolouthw pote prepei na alakse Zeile (otan alazei to Tmima)
        Dim indexis() As Int16 'edw parakolouthw pies Stiles FPA exei to tmima->gia na kanw swsta allagi seiras stis axrisimopoiites stiles FPA

        ReDim posa(-1)
        ReDim tmimata(-1)

        indexis = init_indexis() 'ola -1

        Me.DbhotelDataSet.ekt_analkin_logistirio.Rows.Add()
        'SUM kinisewn groupiert ana Praktoreio-FPA
        Me.KiniseisjoineggrafesTableAdapter.FillSumMainCouranteByImeromPliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, MainCourantePck.Value.Date, "Μετρητοίς")

        ReDim zeileWechsel(Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1)
        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
            If j = 0 Then
                zeileWechsel(0) = False
            Else
                If Not Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname.Equals(Me.DbhotelDataSet.kiniseisjoineggrafes(j - 1).tmimaname) Then
                    zeileWechsel(j - 1) = True ' merken praktorio wechsel sto Dataset
                End If
            End If
        Next


        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1

            If j = 0 Then
                Me.DbhotelDataSet.ekt_tmimata_mc.Rows.Add()
                temp = Me.DbhotelDataSet.kiniseisjoineggrafes(0).tmimaname

                kathPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(0).posoneto
                fpaPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(0).fpaposo

                laenge += 1
                ReDim Preserve tmimata(laenge)
                If temp.Length > 17 Then
                    'se peripotsi poli Megalou onomatos praktoreiou mono ena meros->gia na min ginei mpourdeo i allagi seiras!
                    tmimata(tmimata.Length - 1) = temp.Substring(0, 17)
                Else
                    tmimata(tmimata.Length - 1) = temp
                End If
                ReDim Preserve posa(laenge)

                posa(posa.Length - 1) = Me.DbhotelDataSet.kiniseisjoineggrafes(0).poso
                'bres stili FPA (0,1,2,3)->index
                index = fpa_index(Me.DbhotelDataSet.kiniseisjoineggrafes(0).fpa)
                If index <> -1 Then
                    'markiere tin stili tou FPA ws xrismpooiimeni gia to praktoreio
                    indexis = write_index(indexis, index)
                    'werte palzieran katw apo richtige Stili
                    plaziere_stili(index, kathPoso, fpaPoso, True, zeileWechsel(j), indexis)
                    plaziere_richtige_stili_fpa_netto(index, kathPoso)
                    plaziere_richtige_stili_fpa(index, fpaPoso)
                End If

            Else
                If temp.Equals(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname) Then
                    posa(posa.Length - 1) = posa(posa.Length - 1) + Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                Else
                    temp = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                    indexis = init_indexis()
                    laenge += 1
                    ReDim Preserve tmimata(laenge)
                    If temp.Length > 17 Then
                        tmimata(tmimata.Length - 1) = temp.Substring(0, 17)
                    Else
                        tmimata(tmimata.Length - 1) = temp
                    End If
                    ReDim Preserve posa(laenge)
                    posa(posa.Length - 1) = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If

                kathPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(j).posoneto
                fpaPoso = Me.DbhotelDataSet.kiniseisjoineggrafes(j).fpaposo
                index = fpa_index(Me.DbhotelDataSet.kiniseisjoineggrafes(j).fpa)
                If index <> -1 Then
                    indexis = write_index(indexis, index)
                    'werte palzieran katw apo richtige Stili
                    plaziere_stili(index, kathPoso, fpaPoso, False, zeileWechsel(j), indexis)
                    plaziere_richtige_stili_fpa_netto(index, kathPoso)
                    plaziere_richtige_stili_fpa(index, fpaPoso)
                End If
            End If
        Next
        'ftiakse (aristeres stiles) me ta boxen me ta praktoreia-synola-( "Ποσά:" + ChrW(13) + "Φ.Π.Α.:")
        For j = 0 To posa.Length - 1
            If j = 0 Then
                Me.DbhotelDataSet.ekt_tmimata_mc(0).prakt_tmima = tmimata(0) + ChrW(13)
                Me.DbhotelDataSet.ekt_tmimata_mc(0).synolo = posa(0).ToString("N") + ChrW(13)
                Me.DbhotelDataSet.ekt_tmimata_mc(0).bezeichnung = "Ποσά:" + ChrW(13) + "Φ.Π.Α.:"
            Else
                Me.DbhotelDataSet.ekt_tmimata_mc(0).prakt_tmima = Me.DbhotelDataSet.ekt_tmimata_mc(0).prakt_tmima + ChrW(13) + tmimata(j) + ChrW(13)
                Me.DbhotelDataSet.ekt_tmimata_mc(0).synolo = Me.DbhotelDataSet.ekt_tmimata_mc(0).synolo + ChrW(13) + posa(j).ToString("N") + ChrW(13)
                Me.DbhotelDataSet.ekt_tmimata_mc(0).bezeichnung = Me.DbhotelDataSet.ekt_tmimata_mc(0).bezeichnung + ChrW(13) + "Ποσά:" + ChrW(13) + "Φ.Π.Α.:"
            End If

        Next

    End Sub
    Private Sub plaziere_stili(ByVal index As Int16, ByVal poso As Single, ByVal fpa As Single, ByVal isFirst As Boolean, ByVal zeileWechsel As Boolean, ByVal indexis() As Int16)
        Dim returnValue As Char()
        Select Case index
            Case 0
                'kanw speichern to kathe String otu dataset gia na dw exei Mono ChrW(13)
                returnValue = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1.ToCharArray()
                If isFirst OrElse is_leere_string(returnValue) Then ' Then
                    'einai prwti reihe h einai exei mono ChrW(13)(->se periptwsi pou px to 3o tmima exei mia stili fpa pou 
                    'proigoumenws DEN exei xrisimpopoiithei apo kanena (proigoumeno) Tmima  
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 = LTrim(Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 + ChrW(13) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                End If
                If zeileWechsel Then 'ean meta alazei to praktoreio t
                    If Not is_index(1, indexis) Then 'ean DEN exei xrisimopoithei i FPA stili apo to Praktotreio tote alakse tis seira 
                        '->gia na einai optisch se MIA seira kathe tmima me ta Werte tou!!!!!!!
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(2, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(3, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 + ChrW(13) + ChrW(13)
                    End If

                End If
            Case 1
                returnValue = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2.ToCharArray()
                If isFirst OrElse is_leere_string(returnValue) Then 'Trim(Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2).Equals("") Then
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 = LTrim(Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 + ChrW(13) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                End If
                If zeileWechsel Then
                    If Not is_index(0, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(2, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(3, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 + ChrW(13) + ChrW(13)
                    End If

                End If
            Case 2
                returnValue = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3.ToCharArray()
                If isFirst OrElse is_leere_string(returnValue) Then
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 = LTrim(Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 + ChrW(13) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                End If
                If zeileWechsel Then
                    If Not is_index(0, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(1, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(3, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 + ChrW(13) + ChrW(13)
                    End If

                End If
            Case 3
                returnValue = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4.ToCharArray()
                If isFirst OrElse is_leere_string(returnValue) Then
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 = LTrim(Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")
                Else
                    Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso4 + ChrW(13) + poso.ToString("N") + ChrW(13) + fpa.ToString("N")

                End If
                If zeileWechsel Then
                    If Not is_index(0, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso1 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(1, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso2 + ChrW(13) + ChrW(13)
                    End If
                    If Not is_index(2, indexis) Then
                        Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 = Me.DbhotelDataSet.ekt_tmimata_mc(0).poso3 + ChrW(13) + ChrW(13)
                    End If
                End If
        End Select

    End Sub
    Private Function is_leere_string(ByVal returnValue As Char()) As Boolean
        Dim j As Int16
        For j = 0 To returnValue.Length - 1
            If Not returnValue(j).Equals(ChrW(13)) Then
                Return False
            End If
        Next
        Return True
    End Function
    Private Function is_index(ByVal Index As Int16, ByVal indexis() As Int16) As Boolean
        Dim j As Int16
        For j = 0 To indexis.Length - 1
            If indexis(j) = Index Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function write_index(ByVal indexis() As Int16, ByVal index As Int16) As Int16()
        Dim j As Int16
        For j = 0 To indexis.Length - 1
            If indexis(j) = -1 Then
                indexis(j) = index
                Return indexis
            End If
        Next
        Return indexis
    End Function

    'ean DEN uparxoun trexwntes dianiktereuseis (dataset ekt_main_courante.count =0) tote exw problima me to Report giati xrisimopooiei 
    'RunningTotal sto prwto Section->dimiourgw mideniikes eggrafes enos kenou praktoreiou (-> To keno praktoreio DEN emfanizetai stin Ektiposi
    'mono ws SYnolo praktotreiwn)
    Private Sub make_null_werte_dataset()
        Me.DbhotelDataSet.ekt_main_courante.Rows.Add()
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).group_id = 1
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).eponimia = ""
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).enilikes = 0

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).paidia = 0


        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).atoma = 0


        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).guarant = 0


        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnossum = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnosaisum = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).prwinosum = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).geumatasum = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).extrasum = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).synolosum = 0

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).ypnos = 0

        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).prwino = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).geumata = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).extra = 0
        Me.DbhotelDataSet.ekt_main_courante(Me.DbhotelDataSet.ekt_main_courante.Count - 1).synolo = 0
    End Sub
    Private Sub init_ekt_mc_datasets()
        Me.DbhotelDataSet.ekt_dwmatia_mc.Rows.Add()
        Me.DbhotelDataSet.ekt_geumata_mc.Rows.Add()
        Me.DbhotelDataSet.ekt_prwina_mc.Rows.Add()
        Me.DbhotelDataSet.ekt_extras_mc.Rows.Add()
        Me.DbhotelDataSet.ekt_extra_parast_mc.Rows.Add()

    End Sub
    Private Function init_indexis() As Int16()
        Dim indexis() As Int16

        ReDim indexis(3)
        Dim j As Int16
        For j = 0 To 3
            indexis(j) = -1
        Next
        Return indexis
    End Function
    Private Sub proepiskopisi_maim_courante(ByVal isLeerOK As Boolean)
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New MainCourante()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)
        If MainCouranteRdb2.Checked Then ' edw epilogi MONO B Meros Ektiposis MC
            ektiposi.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            ektiposi.GroupHeaderSection1.SectionFormat.EnableSuppress = True
            ektiposi.Section3.SectionFormat.EnableSuppress = True
            ektiposi.GroupFooterSection1.SectionFormat.EnableSuppress = True
            ektiposi.GroupFooterSection1.SectionFormat.EnableNewPageAfter = False
            ektiposi.GroupFooterSection2.SectionFormat.EnableSuppress = True
            ektiposi.GroupFooterSection3.SectionFormat.EnableSuppress = True
        End If
        If isLeerOK Then
            ektiposi.GroupHeaderSection2.SectionFormat.EnableSuppress = True
            ektiposi.GroupHeaderSection1.SectionFormat.EnableSuppress = True
            ektiposi.Section3.SectionFormat.EnableSuppress = True
            ektiposi.GroupFooterSection1.SectionFormat.EnableSuppress = True
        End If


        ektiposi.SetDataSource(DbhotelDataSet)
        'CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub





    '**********************DAILY REPORT**********************DAILY REPORT*******************DAILY REPORT***********************DAILY REPORT*
    '**********************DAILY REPORT**********************DAILY REPORT*******************DAILY REPORT***********************DAILY REPORT*
    '**********************DAILY REPORT**********************DAILY REPORT*******************DAILY REPORT***********************DAILY REPORT*
    '**********************DAILY REPORT**********************DAILY REPORT*******************DAILY REPORT***********************DAILY REPORT*
    Private Sub ekt_daily_report()
        DailyReportPck.Value = imeromErgasias.AddDays(-1)
        'Etiketa panel initialisieren
        EtiketaLbl.Text = "Εκτύπωση Daily Report"
        EtiketaLbl.Location = New Point(DailyReportPnl.Width / 5, 25)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)

        DailyReportPnl.Location = New Point(70, EtiketaPnl.Height)
        Me.DailyReportPnl.Size = New Point(355, 194)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        Try
            DailyReportTbx.Text = Me.KratiseisTableAdapter.GetProigoumenoEtosDRByEtos(etos)
        Catch ex As InvalidOperationException
            DailyReportTbx.Clear()
        End Try
        EtiketaPnl.Controls.Add(EtiketaLbl)
        Me.KleisimoZentralPnl.Controls.Add(DailyReportPnl)
    End Sub
    Private Sub DialyReportBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DialyReportBtn.Click
        Dim lastYearOK As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor
            init_datasets_dr()
            this_year_ektiposi()
            berechne_xrewseis_overs()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = DailyReportPck.Value.Date
            If Not DailyReportTbx.Text.Equals("") Then
                Try
                    If CType(DailyReportTbx.Text, Int16) > 2000 Then 'Not Me.DailyReportTbx.Text.Equals("") Then
                        last_year_ektiposi()
                        berechne_xrewseis_overs_last()
                        Me.DbhotelDataSet.ektiposeis_genika(0).etos = DailyReportTbx.Text
                        lastYearOK = True
                    End If
                Catch ex As InvalidCastException
                    DailyReportTbx.Clear()
                End Try
            End If
            tmimata_report(lastYearOK)
            proepiskopisi_daily_report()
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    'prwto mreos tou CR-> dwmatia,prwina usw. - timologia metritois - timologia extra -
    Private Sub this_year_ektiposi()
        Dim j, imeres, countKrat, atoma, paidia As Int16
        Dim arxi, telos As Date
        Dim ekptPoso As Single = 0
        'prwta imeras athroismata->xrisimopoiw to main_curante virtual dataset gia apothikeusi athroismatwn kratisewn pou menoun (den exoun fugei)
        'ta SUM einai grouparismena ana apo,mexri atribute apo timeskratisis (to JOIN kratiseis X timeskratiseis edw exei 1X1 resultat, da mono 
        '1 periodos apo timeskratisis in Frage kommt)
        Me.Main_curanteTableAdapter.DailyReportImerasByChkinDate(Me.DbhotelDataSet.main_curante, True, DailyReportPck.Value.Date, DailyReportPck.Value.Date, DailyReportPck.Value.Date)

        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1

            Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia11 = Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia11 + Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_imeras_dr(0).prwina11 = Me.DbhotelDataSet.ekt_imeras_dr(0).prwina11 + Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_imeras_dr(0).geumata11 = Me.DbhotelDataSet.ekt_imeras_dr(0).geumata11 + Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno
            Me.DbhotelDataSet.ekt_imeras_dr(0).extras11 = Me.DbhotelDataSet.ekt_imeras_dr(0).extras11 + Me.DbhotelDataSet.main_curante(j).extra
            paidia = Me.DbhotelDataSet.main_curante(j).paidia

            atoma = atoma + Me.DbhotelDataSet.main_curante(j).enilikes + paidia
            countKrat = countKrat + Me.DbhotelDataSet.main_curante(j).arithmos
        Next

        'extras parastatika
        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, DailyReportPck.Value.Date, DailyReportPck.Value.Date)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metrimer1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metrimer1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistimer1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistimer1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next

        'ta athroismata timologiwn Hmeras(->sto Dataset ta atibute einai ta 21 (row 2 spalte 1) ean blepw to CR ws pinaka!!!) 
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, DailyReportPck.Value.Date, DailyReportPck.Value.Date)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia21 = Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia21 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).prwina21 = Me.DbhotelDataSet.ekt_imeras_dr(0).prwina21 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).geumata21 = Me.DbhotelDataSet.ekt_imeras_dr(0).geumata21 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).extras21 = Me.DbhotelDataSet.ekt_imeras_dr(0).extras21 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa

            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then '->exei exoflithei?
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemimer1 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemimer1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, DailyReportPck.Value.Date, DailyReportPck.Value.Date, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistimera1 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metrimera1 = Me.DbhotelDataSet.timologia(j).synola
                'MsgBox(Me.DbhotelDataSet.timologia(j).synola)
            End If
        Next
        'dynamiKlines = Me.DbhotelDataSet.etaireia(0).minklines
        'Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmimer1 = 100 * countKrat / ((dynamiKlines) * (telos.DayOfYear - arxi.DayOfYear + 1))

        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmimer1 = 100 * countKrat / (Me.DbhotelDataSet.etaireia(0).mindwmatia)

        '  dynamiKlines = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinimer1 = 100 * atoma / Me.DbhotelDataSet.etaireia(0).minklines

        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatimer1 = atoma

        'dwmatia sto telos tou Report
        Me.DbhotelDataSet.ekt_imeras_dr(0).kratiseis11 = countKrat



        'MINAS***********
        arxi = "1/" + DailyReportPck.Value.Date.Month.ToString + "/" + etos.ToString
        telos = DailyReportPck.Value.Date
        'twra MINA athroismata->xrisimopoiw to main_curante virtual dataset gia apothikeusi athroismatwn kratisewn pou menoun (den exoun fugei)
        'ta SUM einai grouparismena ana apo,mexri atribute apo imeskratisis (to JOIN kratiseis X timeskratiseis edw exei 1 X N resultate, da OLOI 
        'oi periodoi mexri to 'telos' apo timeskratisis in Frage kommen)
        Me.Main_curanteTableAdapter.DailyReportMinaEtousByChkinArxiTelos(Me.DbhotelDataSet.main_curante, True, arxi, arxi, True, telos, telos, True, arxi, telos)

        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If telos < Me.DbhotelDataSet.main_curante(j).mexri Then
                If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                End If

            Else
                If Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                    End If
                Else
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                    End If
                End If
            End If
            Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia11 = Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia11 + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_mina_dr(0).prwina11 = Me.DbhotelDataSet.ekt_mina_dr(0).prwina11 + imeres * Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_mina_dr(0).geumata11 = Me.DbhotelDataSet.ekt_mina_dr(0).geumata11 + imeres * (Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno)
            Me.DbhotelDataSet.ekt_mina_dr(0).extras11 = Me.DbhotelDataSet.ekt_mina_dr(0).extras11 + imeres * Me.DbhotelDataSet.main_curante(j).extra
        Next


        'EXTRA PARASTATIKA MINA
        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metrmin1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metrmin1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistmin1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistmin1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        'ta athroismata timologiwn Mina
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, arxi, telos)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia21 = Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia21 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_mina_dr(0).prwina21 = Me.DbhotelDataSet.ekt_mina_dr(0).prwina21 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_mina_dr(0).geumata21 = Me.DbhotelDataSet.ekt_mina_dr(0).geumata21 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_mina_dr(0).extras21 = Me.DbhotelDataSet.ekt_mina_dr(0).extras21 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa

            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then '->exei exoflithei?
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemminas1 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemminas1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, arxi, telos, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistminas1 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metrminas1 = Me.DbhotelDataSet.timologia(j).synola
                'MsgBox(Me.DbhotelDataSet.ekt_synola_timol_dr(0).metrminas1)
            End If
        Next
        countKrat = 0
        atoma = 0
        imeres = 0
        Me.KratiseisTableAdapter.FillJoinKratInZeitIntervallByAfixiAnaxwrisi(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
            If arxi <= Me.DbhotelDataSet.kratiseis(j).afixi.Date Then
                If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                    imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear + 1
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                    imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - arxi.DayOfYear
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                End If
            End If
        Next
        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmminas1 = 100 * countKrat / ((Me.DbhotelDataSet.etaireia(0).mindwmatia) * (telos.DayOfYear - arxi.DayOfYear + 1))

        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinminas1 = 100 * atoma / (Me.DbhotelDataSet.etaireia(0).minklines * (telos.DayOfYear - arxi.DayOfYear + 1))

        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatminas1 = atoma
        Me.DbhotelDataSet.ekt_mina_dr(0).kratiseis11 = countKrat

        'ETOS************************
        arxi = "1/1/" + etos.ToString
        telos = DailyReportPck.Value.Date

        'twra ETOS athroismata->
        Me.Main_curanteTableAdapter.DailyReportMinaEtousByChkinArxiTelos(Me.DbhotelDataSet.main_curante, True, arxi, arxi, True, telos, telos, True, arxi, telos)
        'MsgBox(Me.DbhotelDataSet.main_curante.Count)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If telos < Me.DbhotelDataSet.main_curante(j).mexri Then
                If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                End If

            Else
                If Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                    End If
                Else
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                    End If
                End If
            End If
            Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia11 = Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia11 + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_etos_dr(0).prwina11 = Me.DbhotelDataSet.ekt_etos_dr(0).prwina11 + imeres * Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_etos_dr(0).geumata11 = Me.DbhotelDataSet.ekt_etos_dr(0).geumata11 + imeres * (Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno)
            Me.DbhotelDataSet.ekt_etos_dr(0).extras11 = Me.DbhotelDataSet.ekt_etos_dr(0).extras11 + imeres * Me.DbhotelDataSet.main_curante(j).extra
        Next

        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metretos1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metretos1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistetos1 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistetos1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next

        'ta athroismata timologiwn ETOUS
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, arxi, telos)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia21 = Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia21 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_etos_dr(0).prwina21 = Me.DbhotelDataSet.ekt_etos_dr(0).prwina21 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_etos_dr(0).geumata21 = Me.DbhotelDataSet.ekt_etos_dr(0).geumata21 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_etos_dr(0).extras21 = Me.DbhotelDataSet.ekt_etos_dr(0).extras21 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemetos1 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemetos1 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, arxi, telos, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistetos1 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metretos1 = Me.DbhotelDataSet.timologia(j).synola
            End If
        Next
        countKrat = 0
        atoma = 0
        imeres = 0
        Me.KratiseisTableAdapter.FillJoinKratInZeitIntervallByAfixiAnaxwrisi(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
            If arxi <= Me.DbhotelDataSet.kratiseis(j).afixi.Date Then
                If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                    imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear + 1
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                    imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - arxi.DayOfYear
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    countKrat = countKrat + imeres
                    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                End If
            End If
        Next
        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmetos1 = 100 * countKrat / ((Me.DbhotelDataSet.etaireia(0).mindwmatia) * (telos.DayOfYear - arxi.DayOfYear + 1))

        'dynamiKlines = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
        'countKlines = telos.DayOfYear - arxi.DayOfYear
        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinetos1 = 100 * atoma / (Me.DbhotelDataSet.etaireia(0).minklines * (telos.DayOfYear - arxi.DayOfYear + 1))
        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatetos1 = atoma
        Me.DbhotelDataSet.ekt_etos_dr(0).kratiseis11 = countKrat
    End Sub
    Private Sub last_year_ektiposi()
        Dim j, imeres, countKrat, atoma, arKrat As Int16
        Dim lastDate, arxi, telos As Date
        Dim timPoso As Single = 0
        'prwta imeras athroismata->xrisimopoiw to main_curante virtual dataset gia apothikeusi athroismatwn kratisewn pou menoun (den exoun fugei)
        'ta SUM einai grouparismena ana apo,mexri atribute apo imeskratisis (to JOIN kratiseis X timeskratiseis edw exei 1X1 resultat, da mono 
        '1 periodos apo timeskratisis in Frage kommt)

        lastDate = DailyReportPck.Value.Day.ToString + "/" + DailyReportPck.Value.Month.ToString + "/" + DailyReportTbx.Text

        Me.Main_curanteTableAdapter.DailyReportImerasByChkinDate(Me.DbhotelDataSet.main_curante, True, lastDate, lastDate, lastDate)

        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1

            Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia12 = Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia12 + Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_imeras_dr(0).prwina12 = Me.DbhotelDataSet.ekt_imeras_dr(0).prwina12 + Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_imeras_dr(0).geumata12 = Me.DbhotelDataSet.ekt_imeras_dr(0).geumata12 + Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno
            Me.DbhotelDataSet.ekt_imeras_dr(0).extras12 = Me.DbhotelDataSet.ekt_imeras_dr(0).extras12 + Me.DbhotelDataSet.main_curante(j).extra
            atoma = atoma + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
            countKrat = countKrat + Me.DbhotelDataSet.main_curante(j).arithmos
        Next

        'extras parastatika
        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, lastDate, lastDate)

        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metrimer2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metrimer2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistimer2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistimer2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next

        'ta athroismata timologiwn Hmeras(->sto Dataset ta atibute einai ta 22 row 2 spalte1 ean blepw to CR ws pinaka!!!) 
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, lastDate, lastDate)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia22 = Me.DbhotelDataSet.ekt_imeras_dr(0).dwmatia22 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).prwina22 = Me.DbhotelDataSet.ekt_imeras_dr(0).prwina22 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).geumata22 = Me.DbhotelDataSet.ekt_imeras_dr(0).geumata22 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_imeras_dr(0).extras22 = Me.DbhotelDataSet.ekt_imeras_dr(0).extras22 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemimer2 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemimer2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, lastDate, lastDate, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistimera2 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metrimera2 = Me.DbhotelDataSet.timologia(j).synola
            End If
        Next
        'Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmimer2 = 100 * countKrat / (Me.DbhotelDataSet.etaireia(0). * (telos.DayOfYear - arxi.DayOfYear + 1))

        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmimer2 = 100 * countKrat / (Me.DbhotelDataSet.etaireia(0).mindwmatia)

        'dynamiKlines = Me.DbhotelDataSet.etaireia(0).minklines 'Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinimer2 = 100 * atoma / Me.DbhotelDataSet.etaireia(0).minklines

        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatimer2 = atoma

        'dwmatia sto telos tou Report
        Me.DbhotelDataSet.ekt_imeras_dr(0).kratiseis12 = countKrat



        'MINAS***********
        arxi = "1/" + lastDate.Month.ToString + "/" + lastDate.Year.ToString
        telos = lastDate
        'twra MINA athroismata->xrisimopoiw to main_curante virtual dataset gia apothikeusi athroismatwn kratisewn pou menoun (den exoun fugei)
        'ta SUM einai grouparismena ana apo,mexri atribute apo imeskratisis (to JOIN kratiseis X timeskratiseis edw exei 1 X N resultate, da OLOI 
        'oi periodoi mexri to 'telos' apo timeskratisis in Frage kommen)
        Me.Main_curanteTableAdapter.DailyReportMinaEtousByChkinArxiTelos(Me.DbhotelDataSet.main_curante, True, arxi, arxi, True, telos, telos, True, arxi, telos)

        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If telos < Me.DbhotelDataSet.main_curante(j).mexri Then
                If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                End If

            Else
                If Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                    End If
                Else
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                    End If
                End If
            End If

            Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia12 = Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia12 + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_mina_dr(0).prwina12 = Me.DbhotelDataSet.ekt_mina_dr(0).prwina12 + imeres * Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_mina_dr(0).geumata12 = Me.DbhotelDataSet.ekt_mina_dr(0).geumata12 + imeres * (Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno)
            Me.DbhotelDataSet.ekt_mina_dr(0).extras12 = Me.DbhotelDataSet.ekt_mina_dr(0).extras12 + imeres * Me.DbhotelDataSet.main_curante(j).extra
        Next
        'EXTRA PARASTATIKA MINA
        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metrmin2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metrmin2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistmin2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistmin2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        'ta athroismata timologiwn Mina
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, arxi, telos)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia22 = Me.DbhotelDataSet.ekt_mina_dr(0).dwmatia22 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_mina_dr(0).prwina22 = Me.DbhotelDataSet.ekt_mina_dr(0).prwina22 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_mina_dr(0).geumata22 = Me.DbhotelDataSet.ekt_mina_dr(0).geumata22 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_mina_dr(0).extras22 = Me.DbhotelDataSet.ekt_mina_dr(0).extras22 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemminas2 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemminas2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, arxi, telos, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistminas2 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metrminas2 = Me.DbhotelDataSet.timologia(j).synola
            End If
        Next
        countKrat = 0
        atoma = 0
        imeres = 0
        arKrat = 0
        Me.KratiseisTableAdapter.FillJoinKratInZeitIntervallByAfixiAnaxwrisi(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
            'einai Join Kratiseis X Timeakratisis->ean  se mia kratisi, die ueber mehrere TouristPeriodoi hinaus geht, wenn
            'autoi oi Tourist periodoi kata lathos exoun diaforetiki Xrewsi (HB,RR..)apo mia tote to Join anfrage kanei resultieren mehrere 
            'rows->atoma dipla kai tripla (jenachdem)->giauto elegxw arithmo kratisis !(anfrage einai kata arithmo kratisis sortiert !)
            If arKrat <> Me.DbhotelDataSet.kratiseis(j).arithmos Then
                arKrat = Me.DbhotelDataSet.kratiseis(j).arithmos
                If arxi <= Me.DbhotelDataSet.kratiseis(j).afixi.Date Then
                    If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                        imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                        'ElseIf Me.DbhotelDataSet.kratiseis(j).anaxwrisi = telos Then
                        '    imeres = telos.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear
                        '    countKrat = countKrat + imeres
                        '    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    Else
                        imeres = telos.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear + 1
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    End If
                Else
                    If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                        imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - arxi.DayOfYear
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                        'ElseIf Me.DbhotelDataSet.kratiseis(j).anaxwrisi = telos Then
                        '    imeres = telos.DayOfYear - arxi.DayOfYear
                        '    countKrat = countKrat + imeres
                        '    atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)

                    Else
                        imeres = telos.DayOfYear - arxi.DayOfYear + 1
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    End If
                End If
            End If

        Next
        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmminas2 = 100 * countKrat / ((Me.DbhotelDataSet.etaireia(0).mindwmatia) * (telos.DayOfYear - arxi.DayOfYear + 1))

        'dynamiKlines = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
        'countKlines = (telos.DayOfYear - arxi.DayOfYear + 1) * dynamiKlines
        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinminas2 = 100 * atoma / (Me.DbhotelDataSet.etaireia(0).minklines * (telos.DayOfYear - arxi.DayOfYear + 1))
        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatminas2 = atoma
        Me.DbhotelDataSet.ekt_mina_dr(0).kratiseis12 = countKrat

        'ETOS************************
        arxi = "1/1/" + etos.ToString
        telos = DailyReportPck.Value.Date

        arxi = "1/1/" + lastDate.Year.ToString
        telos = lastDate

        'twra ETOS athroismata->
        Me.Main_curanteTableAdapter.DailyReportMinaEtousByChkinArxiTelos(Me.DbhotelDataSet.main_curante, True, arxi, arxi, True, telos, telos, True, arxi, telos)

        'MsgBox(Me.DbhotelDataSet.main_curante.Count)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If telos < Me.DbhotelDataSet.main_curante(j).mexri Then
                If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                End If

            Else
                If Me.DbhotelDataSet.main_curante(j).mexri = Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                    End If
                Else
                    If arxi < Me.DbhotelDataSet.main_curante(j).apo Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                    End If
                End If
            End If
            Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia12 = Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia12 + imeres * Me.DbhotelDataSet.main_curante(j).ypnos
            Me.DbhotelDataSet.ekt_etos_dr(0).prwina12 = Me.DbhotelDataSet.ekt_etos_dr(0).prwina12 + imeres * Me.DbhotelDataSet.main_curante(j).prwino
            Me.DbhotelDataSet.ekt_etos_dr(0).geumata12 = Me.DbhotelDataSet.ekt_etos_dr(0).geumata12 + imeres * (Me.DbhotelDataSet.main_curante(j).geuma + Me.DbhotelDataSet.main_curante(j).deipno)
            Me.DbhotelDataSet.ekt_etos_dr(0).extras12 = Me.DbhotelDataSet.ekt_etos_dr(0).extras12 + imeres * Me.DbhotelDataSet.main_curante(j).extra
        Next

        Me.TimologioanalysisTableAdapter.FillJoinExtraParastforDailyReportByExtrMaurAkyrImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, False, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET (EPIDI EINAI BOOLEAN) GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_extrparast_dr(0).metretos2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).metretos2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            Else
                Me.DbhotelDataSet.ekt_extrparast_dr(0).pistetos2 = Me.DbhotelDataSet.ekt_extrparast_dr(0).pistetos2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next

        'ta athroismata timologiwn ETOUS
        Me.TimologioanalysisTableAdapter.FillJoinSumForDailyReportByMemAkyroImer1Imer2(Me.DbhotelDataSet.timologioanalysis, True, False, arxi, telos)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis.Count)
        'MsgBox(Me.DbhotelDataSet.timologioanalysis(0).ypnos)
        For j = 0 To Me.DbhotelDataSet.timologioanalysis.Count - 1
            Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia22 = Me.DbhotelDataSet.ekt_etos_dr(0).dwmatia22 + Me.DbhotelDataSet.timologioanalysis(j).ypnos + Me.DbhotelDataSet.timologioanalysis(j).ypnosfpa
            Me.DbhotelDataSet.ekt_etos_dr(0).prwina22 = Me.DbhotelDataSet.ekt_etos_dr(0).prwina22 + Me.DbhotelDataSet.timologioanalysis(j).prwino + Me.DbhotelDataSet.timologioanalysis(j).prwinofpa
            Me.DbhotelDataSet.ekt_etos_dr(0).geumata22 = Me.DbhotelDataSet.ekt_etos_dr(0).geumata22 + Me.DbhotelDataSet.timologioanalysis(j).geuma + Me.DbhotelDataSet.timologioanalysis(j).geumafpa +
            Me.DbhotelDataSet.timologioanalysis(j).deipno + Me.DbhotelDataSet.timologioanalysis(j).deipnofpa
            Me.DbhotelDataSet.ekt_etos_dr(0).extras22 = Me.DbhotelDataSet.ekt_etos_dr(0).extras22 + Me.DbhotelDataSet.timologioanalysis(j).extra + Me.DbhotelDataSet.timologioanalysis(j).extrfpa
            'ACHTUNG->EDW XRISIMOPOIISA TO ATRIBUTE EKPTOSI STO DATASET EPIDI EINAI BOOLEAN GIA EXOFLITHI APO TIMOLOGIA!!!!!!!!!!
            'ARA ->GIA METRITOIS!!!!!!!!!!!!!!!(KAI OXI EKPTOSI)
            If Me.DbhotelDataSet.timologioanalysis(j).ekptosi Then
                Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemetos2 = Me.DbhotelDataSet.ekt_tim_metr_dr(0).timmemetos2 + Me.DbhotelDataSet.timologioanalysis(j).synola
            End If
        Next
        Me.TimologiaTableAdapter.FillSynolaMetrPistDailyReportByImer1Imer2AkyroMauro(Me.DbhotelDataSet.timologia, arxi, telos, False, False)
        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).pistetos2 = Me.DbhotelDataSet.timologia(j).synola
            Else
                Me.DbhotelDataSet.ekt_synola_timol_dr(0).metretos2 = Me.DbhotelDataSet.timologia(j).synola
            End If
        Next
        countKrat = 0
        atoma = 0
        imeres = 0
        arKrat = 0
        Me.KratiseisTableAdapter.FillJoinKratInZeitIntervallByAfixiAnaxwrisi(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
            'einai Join Kratiseis X Timeakratisis->ean  se mia kratisi, die ueber mehrere TouristPeriodoi hinaus geht, wenn
            'autoi oi Tourist periodoi kata lathos exoun diaforetiki Xrewsi (HB,RR..)apo mia tote to Join anfrage kanei resultieren mehrere 
            'rows->atoma dipla kai tripla (jenachdem)->giauto elegxw arithmo kratisis !(anfrage einai kata arithmo kratisis sortiert !)
            If arKrat <> Me.DbhotelDataSet.kratiseis(j).arithmos Then
                arKrat = Me.DbhotelDataSet.kratiseis(j).arithmos
                If arxi <= Me.DbhotelDataSet.kratiseis(j).afixi.Date Then
                    If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                        imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    Else
                        imeres = telos.DayOfYear - Me.DbhotelDataSet.kratiseis(j).afixi.DayOfYear + 1
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    End If
                Else
                    If Me.DbhotelDataSet.kratiseis(j).anaxwrisi <= telos Then
                        imeres = Me.DbhotelDataSet.kratiseis(j).anaxwrisi.DayOfYear - arxi.DayOfYear
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    Else
                        imeres = telos.DayOfYear - arxi.DayOfYear + 1
                        countKrat = countKrat + imeres
                        atoma = atoma + ((Me.DbhotelDataSet.kratiseis(j).enilikes + Me.DbhotelDataSet.kratiseis(j).paidia) * imeres)
                    End If
                End If
            End If

        Next
        Me.DbhotelDataSet.ekt_plirotites_dr(0).dwmetos2 = 100 * countKrat / ((Me.DbhotelDataSet.etaireia(0).mindwmatia) * (telos.DayOfYear - arxi.DayOfYear + 1))

        'dynamiKlines = Me.DwmatiaTableAdapter.GetKlinesXenodoxeiou()
        'countKlines = telos.DayOfYear - arxi.DayOfYear
        Me.DbhotelDataSet.ekt_plirotites_dr(0).klinetos2 = 100 * atoma / (Me.DbhotelDataSet.etaireia(0).minklines * (telos.DayOfYear - arxi.DayOfYear + 1))
        Me.DbhotelDataSet.ekt_plirotites_dr(0).pelatetos2 = atoma
        Me.DbhotelDataSet.ekt_etos_dr(0).kratiseis12 = countKrat
    End Sub
    'meros tou CR pou afora ta tmimata metritois (Cafeteria usw.)
    Private Sub tmimata_report(ByVal lastyearOK As Boolean)
        Dim j As Int16
        Dim tmimatakwds() As Integer ' edw apothikeuw temporaer tous kwdikous twn tmimatwn pou eisagw sto Dataset->analoga me index kai i Stelle tou
        Dim index As Int16
        Dim arxi, telos, lastDate As Date
        'tmimatos sto Dataset!!!!

        ReDim tmimatakwds(-1)
        Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
        init_tmimatakwds(Me.DbhotelDataSet.tmimata.Count - 1, tmimatakwds)

        Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, DailyReportPck.Value.Date, DailyReportPck.Value.Date, "Μετρητοίς")


        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
            index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
            If index = -1 Then
                index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                If index <> -1 Then
                    Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1 'gia CR 
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).imera1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Else
                Me.DbhotelDataSet.ekt_tmimata_dr(index).imera1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
            End If
        Next

        arxi = "1/" + DailyReportPck.Value.Date.Month.ToString + "/" + etos.ToString
        telos = DailyReportPck.Value.Date
        Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, arxi, telos, "Μετρητοίς")
        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
            index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
            If index = -1 Then
                index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                If index <> -1 Then
                    Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).minas1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Else
                Me.DbhotelDataSet.ekt_tmimata_dr(index).minas1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
            End If
        Next

        arxi = "1/1/" + etos.ToString
        telos = DailyReportPck.Value.Date
        Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, arxi, telos, "Μετρητοίς")
        For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
            index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
            If index = -1 Then
                index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                If index <> -1 Then
                    Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).etos1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Else
                Me.DbhotelDataSet.ekt_tmimata_dr(index).etos1 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
            End If
        Next

        If lastyearOK Then ' kai gia proigoumeno etos 
            lastDate = DailyReportPck.Value.Day.ToString + "/" + DailyReportPck.Value.Month.ToString + "/" + DailyReportTbx.Text

            Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, lastDate, lastDate, "Μετρητοίς")
            For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
                index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
                If index = -1 Then
                    index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                    If index <> -1 Then
                        Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).imera2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                    End If
                Else
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).imera2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Next

            arxi = "1/" + lastDate.Month.ToString + "/" + lastDate.Year.ToString
            telos = lastDate
            Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, arxi, telos, "Μετρητοίς")
            For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
                index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
                If index = -1 Then
                    index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                    If index <> -1 Then
                        Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).minas2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                    End If
                Else
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).minas2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Next

            arxi = "1/1/" + lastDate.Year.ToString
            telos = lastDate
            Me.KiniseisjoineggrafesTableAdapter.FillSumForDailyReportByImer1Imer2Pliromi(Me.DbhotelDataSet.kiniseisjoineggrafes, arxi, telos, "Μετρητοίς")
            For j = 0 To Me.DbhotelDataSet.kiniseisjoineggrafes.Count - 1
                index = is_kwdikos_drinnen(Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima, tmimatakwds)
                If index = -1 Then
                    index = write_neue_kwdikos(tmimatakwds, Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmima)
                    If index <> -1 Then
                        Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).goup_id = 1
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).tmima = Me.DbhotelDataSet.kiniseisjoineggrafes(j).tmimaname
                        Me.DbhotelDataSet.ekt_tmimata_dr(index).etos2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                    End If
                Else
                    Me.DbhotelDataSet.ekt_tmimata_dr(index).etos2 = Me.DbhotelDataSet.kiniseisjoineggrafes(j).poso
                End If
            Next
        End If

    End Sub
    'gia to teleutaio meros tou CR->xrewseis - overs
    Private Sub berechne_xrewseis_overs()
        Dim datum As Date
        Dim xronia As Int16
        Dim arxi, telos As Date
        Dim j, imeres, atoma As Int16 ' , arKrat

        datum = DailyReportPck.Value.Date
        xronia = etos
        'xrewseis - overs imeras
        Me.Main_curanteTableAdapter.DailyReportImerasXrewsisOverByChkinDate(Me.DbhotelDataSet.main_curante, True, datum, datum, datum)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_imeras_dr(0).rr1 = Me.DbhotelDataSet.ekt_imeras_dr(0).rr1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 2
                    Me.DbhotelDataSet.ekt_imeras_dr(0).bb1 = Me.DbhotelDataSet.ekt_imeras_dr(0).bb1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 3
                    Me.DbhotelDataSet.ekt_imeras_dr(0).hb1 = Me.DbhotelDataSet.ekt_imeras_dr(0).hb1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 4
                    Me.DbhotelDataSet.ekt_imeras_dr(0).fb1 = Me.DbhotelDataSet.ekt_imeras_dr(0).fb1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 6
                    Me.DbhotelDataSet.ekt_imeras_dr(0).ai1 = Me.DbhotelDataSet.ekt_imeras_dr(0).ai1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_imeras_dr(0).over1 = Me.DbhotelDataSet.ekt_imeras_dr(0).over1 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
            End If
        Next
        'xrewseis - overs minos
        arxi = "1/" + datum.Month.ToString + "/" + xronia.ToString
        telos = datum
        imeres = 0
        atoma = 0

        'ACHTUNG ->EDW ALAKSA DEDOMENOU OTI MIA KRATISI MPOREI NA EXEI MEHRERE XREWSEIS UEBER TIS TOURISTIKES PERIODOUS!!!!!!!!!!!!!!!!
        'Me.KratiseisTableAdapter.FillJoinKratInZeitInervDailyReportByAfixiAnax(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If arxi <= Me.DbhotelDataSet.main_curante(j).apo Then
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1

                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If

                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            End If
            'DEN einai praktoreio alla o kwd xrewsis->xrisimopoiisa sto dataset to praktoreio gia apothikeusi tou kwd xrewsis tis Abfrage
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_mina_dr(0).rr1 = Me.DbhotelDataSet.ekt_mina_dr(0).rr1 + atoma
                Case 2
                    Me.DbhotelDataSet.ekt_mina_dr(0).bb1 = Me.DbhotelDataSet.ekt_mina_dr(0).bb1 + atoma
                Case 3
                    Me.DbhotelDataSet.ekt_mina_dr(0).hb1 = Me.DbhotelDataSet.ekt_mina_dr(0).hb1 + atoma
                Case 4
                    Me.DbhotelDataSet.ekt_mina_dr(0).fb1 = Me.DbhotelDataSet.ekt_mina_dr(0).fb1 + atoma
                Case 6
                    Me.DbhotelDataSet.ekt_mina_dr(0).ai1 = Me.DbhotelDataSet.ekt_mina_dr(0).ai1 + atoma
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_mina_dr(0).over1 = Me.DbhotelDataSet.ekt_mina_dr(0).over1 + atoma
            End If
            'End If

        Next
        'xrewseis - overs etous
        arxi = "1/1/" + etos.ToString
        telos = datum
        imeres = 0
        atoma = 0
        'arKrat = 0

        'ACHTUNG ->EDW ALAKSA DEDOMENOU OTI MIA KRATISI MPOREI NA EXEI MEHRERE XREWSEIS UEBER TIS TOURISTIKES PERIODOUS!!!!!!!!!!!!!!!!
        'Me.KratiseisTableAdapter.FillJoinKratInZeitInervDailyReportByAfixiAnax(Me.DbhotelDataSet.kratiseis, arxi, arxi, telos, telos, arxi, telos)
        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1

            If arxi <= Me.DbhotelDataSet.main_curante(j).apo Then
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1

                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            End If
            'DEN einai tpraktoreio alla o kwd xrewsis->xrisimopoiisa sto dataset to praktoreio gia apothikeusi tou kwd xrewsis tis Abfrage
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_etos_dr(0).rr1 = Me.DbhotelDataSet.ekt_etos_dr(0).rr1 + atoma
                Case 2
                    Me.DbhotelDataSet.ekt_etos_dr(0).bb1 = Me.DbhotelDataSet.ekt_etos_dr(0).bb1 + atoma
                Case 3
                    Me.DbhotelDataSet.ekt_etos_dr(0).hb1 = Me.DbhotelDataSet.ekt_etos_dr(0).hb1 + atoma
                Case 4
                    Me.DbhotelDataSet.ekt_etos_dr(0).fb1 = Me.DbhotelDataSet.ekt_etos_dr(0).fb1 + atoma
                Case 6
                    Me.DbhotelDataSet.ekt_etos_dr(0).ai1 = Me.DbhotelDataSet.ekt_etos_dr(0).ai1 + atoma
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_etos_dr(0).over1 = Me.DbhotelDataSet.ekt_etos_dr(0).over1 + atoma
            End If

        Next

    End Sub

    Private Sub berechne_xrewseis_overs_last()
        Dim datum As Date
        Dim xronia, arKrat As Int16
        Dim arxi, telos As Date
        Dim j, imeres, atoma As Int16

        datum = DailyReportPck.Value.Day.ToString + "/" + DailyReportPck.Value.Month.ToString + "/" + DailyReportTbx.Text
        xronia = DailyReportTbx.Text
        'xrewseis - overs imeras
        Me.Main_curanteTableAdapter.DailyReportImerasXrewsisOverByChkinDate(Me.DbhotelDataSet.main_curante, True, datum, datum, datum)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_imeras_dr(0).rr2 = Me.DbhotelDataSet.ekt_imeras_dr(0).rr2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 2
                    Me.DbhotelDataSet.ekt_imeras_dr(0).bb2 = Me.DbhotelDataSet.ekt_imeras_dr(0).bb2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 3
                    Me.DbhotelDataSet.ekt_imeras_dr(0).hb2 = Me.DbhotelDataSet.ekt_imeras_dr(0).hb2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 4
                    Me.DbhotelDataSet.ekt_imeras_dr(0).fb2 = Me.DbhotelDataSet.ekt_imeras_dr(0).fb2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
                Case 6
                    Me.DbhotelDataSet.ekt_imeras_dr(0).ai2 = Me.DbhotelDataSet.ekt_imeras_dr(0).ai2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_imeras_dr(0).over2 = Me.DbhotelDataSet.ekt_imeras_dr(0).over2 + Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia
            End If
        Next
        'xrewseis - overs minos
        arxi = "1/" + datum.Month.ToString + "/" + xronia.ToString
        telos = datum
        imeres = 0
        atoma = 0
        arKrat = 0
        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1
            If arxi <= Me.DbhotelDataSet.main_curante(j).apo Then
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1

                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If

                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            End If
            'DEN einai praktoreio alla o kwd xrewsis->xrisimopoiisa sto dataset to praktoreio gia apothikeusi tou kwd xrewsis tis Abfrage
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_mina_dr(0).rr2 = Me.DbhotelDataSet.ekt_mina_dr(0).rr2 + atoma
                Case 2
                    Me.DbhotelDataSet.ekt_mina_dr(0).bb2 = Me.DbhotelDataSet.ekt_mina_dr(0).bb2 + atoma
                Case 3
                    Me.DbhotelDataSet.ekt_mina_dr(0).hb2 = Me.DbhotelDataSet.ekt_mina_dr(0).hb2 + atoma
                Case 4
                    Me.DbhotelDataSet.ekt_mina_dr(0).fb2 = Me.DbhotelDataSet.ekt_mina_dr(0).fb2 + atoma
                Case 6
                    Me.DbhotelDataSet.ekt_mina_dr(0).ai2 = Me.DbhotelDataSet.ekt_mina_dr(0).ai2 + atoma
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_mina_dr(0).over2 = Me.DbhotelDataSet.ekt_mina_dr(0).over2 + atoma
            End If
            'End If

        Next
        'xrewseis - overs etous
        arxi = "1/1/" + xronia.ToString
        telos = datum
        imeres = 0
        atoma = 0
        arKrat = 0


        Me.Main_curanteTableAdapter.DailyReportMinaEtosXrewsiOverByAfixAnax(Me.DbhotelDataSet.main_curante, arxi, arxi, telos, telos, arxi, telos)
        For j = 0 To Me.DbhotelDataSet.main_curante.Count - 1

            If arxi <= Me.DbhotelDataSet.main_curante(j).apo Then
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - Me.DbhotelDataSet.main_curante(j).apo.DayOfYear + 1

                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            Else
                If Me.DbhotelDataSet.main_curante(j).mexri <= telos Then
                    If Me.DbhotelDataSet.main_curante(j).mexri <> Me.DbhotelDataSet.main_curante(j).anaxwrisi Then
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear + 1
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    Else
                        imeres = Me.DbhotelDataSet.main_curante(j).mexri.DayOfYear - arxi.DayOfYear
                        atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                    End If
                Else
                    imeres = telos.DayOfYear - arxi.DayOfYear + 1
                    atoma = ((Me.DbhotelDataSet.main_curante(j).enilikes + Me.DbhotelDataSet.main_curante(j).paidia) * imeres)
                End If
            End If
            'DEN einai tpraktoreio alla o kwd xrewsis->xrisimopoiisa sto dataset to praktoreio gia apothikeusi tou kwd xrewsis tis Abfrage
            Select Case Me.DbhotelDataSet.main_curante(j).xrewsikwd
                Case 1
                    Me.DbhotelDataSet.ekt_etos_dr(0).rr2 = Me.DbhotelDataSet.ekt_etos_dr(0).rr2 + atoma
                Case 2
                    Me.DbhotelDataSet.ekt_etos_dr(0).bb2 = Me.DbhotelDataSet.ekt_etos_dr(0).bb2 + atoma
                Case 3
                    Me.DbhotelDataSet.ekt_etos_dr(0).hb2 = Me.DbhotelDataSet.ekt_etos_dr(0).hb2 + atoma
                Case 4
                    Me.DbhotelDataSet.ekt_etos_dr(0).fb2 = Me.DbhotelDataSet.ekt_etos_dr(0).fb2 + atoma
                Case 6
                    Me.DbhotelDataSet.ekt_etos_dr(0).ai2 = Me.DbhotelDataSet.ekt_etos_dr(0).ai2 + atoma
            End Select
            If Me.DbhotelDataSet.main_curante(j).dwmatio.Equals("OV-BOOK") Then
                Me.DbhotelDataSet.ekt_etos_dr(0).over2 = Me.DbhotelDataSet.ekt_etos_dr(0).over2 + atoma
            End If

        Next

    End Sub
    Private Sub init_datasets_dr()
        Me.DbhotelDataSet.ekt_group_dailyreport.Clear()
        Me.DbhotelDataSet.ekt_imeras_dr.Clear()
        Me.DbhotelDataSet.ekt_mina_dr.Clear()
        Me.DbhotelDataSet.ekt_etos_dr.Clear()
        Me.DbhotelDataSet.ekt_tmimata_dr.Clear()
        Me.DbhotelDataSet.ekt_synola_timol_dr.Clear()
        Me.DbhotelDataSet.ekt_tim_metr_dr.Clear()
        Me.DbhotelDataSet.ekt_extrparast_dr.Clear()
        Me.DbhotelDataSet.ekt_plirotites_dr.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Clear()

        Me.DbhotelDataSet.ekt_group_dailyreport.Rows.Add()
        Me.DbhotelDataSet.ekt_group_dailyreport(0).group_id = 1

        Me.DbhotelDataSet.ekt_imeras_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_mina_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_etos_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_synola_timol_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_tim_metr_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_extrparast_dr.Rows.Add()
        Me.DbhotelDataSet.ekt_plirotites_dr.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        'Me.DbhotelDataSet.ekt_tmimata_dr.Rows.Add()
        'Me.DbhotelDataSet.ekt_tmimata_dr(0).goup_id = 1
    End Sub

    Private Sub init_tmimatakwds(ByVal count As Int16, ByRef tmimatakwd() As Integer)

        ReDim tmimatakwd(count)
        Dim j As Int16
        For j = 0 To count
            tmimatakwd(j) = -1
        Next
    End Sub
    'einai o kwdikos tmimatos schon gespeichert?
    Private Function is_kwdikos_drinnen(ByVal kwdikos As Integer, ByVal tmimakwdikoi() As Integer) As Int16
        Dim j As Int16
        For j = 0 To tmimakwdikoi.Length - 1
            If tmimakwdikoi(j) = kwdikos Then
                Return j
            End If
        Next

        Return -1
    End Function
    'speichere kwdiko tmimatos
    Private Function write_neue_kwdikos(ByRef tmimakwds() As Integer, ByVal kwdikos As Integer) As Int16
        Dim j As Int16
        For j = 0 To tmimakwds.Length - 1
            If tmimakwds(j) = -1 Then
                tmimakwds(j) = kwdikos
                Return j
            End If
        Next
        Return j
    End Function
    Private Sub proepiskopisi_daily_report()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New DailyReport()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)


        ektiposi.SetDataSource(DbhotelDataSet)
        'CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    '**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI
    '**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI
    '**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI
    '**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI**********ASTYNOMIA KATASTASI

    Private Sub ekt_asty_kat()
        AstyKatPck.Value = imeromErgasias
        'Etiketa panel initialisieren
        EtiketaLbl.Text = "Εκτύπωση κατάστασης Αστυνομίας"
        EtiketaLbl.Location = New Point(AstyKatPnl.Width / 8, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)

        AstyKatPnl.Location = New Point(70, EtiketaPnl.Height)
        Me.AstyKatPnl.Size = New Point(355, 222)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)

        Me.KleisimoZentralPnl.Controls.Add(AstyKatPnl)

    End Sub
    Private Sub AstyKatBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AstyKatBtn.Click

        If AstyKatRdb3.Checked Then 'ola
            asty_katastasi(3)
        ElseIf AstyKatRdb1.Checked Then 'mono afixeis
            asty_katastasi(1)
        ElseIf AstyKatRdb2.Checked Then 'mono anaxwriseis
            asty_katastasi(2)
        End If


    End Sub
    Private Sub asty_katastasi(ByVal flag As Byte)

        Me.DbhotelDataSet.katastasi_astynomias.Clear()
        Me.DbhotelDataSet.ekt_asty_katast.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Clear()

        If flag = 1 Then
            Me.Katastasi_astynomiasTableAdapter.FillJoinForAstynomiaByAfixi(Me.DbhotelDataSet.katastasi_astynomias, AstyKatPck.Value.Date)
            make_asty_dataset(1)
        ElseIf flag = 2 Then
            Me.Katastasi_astynomiasTableAdapter.FillJoinForAstynomiaByAnaxwrisi(Me.DbhotelDataSet.katastasi_astynomias, AstyKatPck.Value.Date)
            make_asty_dataset(2)
        ElseIf flag = 3 Then
            Me.Katastasi_astynomiasTableAdapter.FillJoinForAstynomiaByAfixi(Me.DbhotelDataSet.katastasi_astynomias, AstyKatPck.Value.Date)
            make_asty_dataset(1)
            Me.Katastasi_astynomiasTableAdapter.FillJoinForAstynomiaByAnaxwrisi(Me.DbhotelDataSet.katastasi_astynomias, AstyKatPck.Value.Date)
            make_asty_dataset(2)
        End If

        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = AstyKatPck.Value.Date
        proepiskopisi_asty_katastasi()
    End Sub
    Private Sub make_asty_dataset(ByVal flag As Byte)
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.katastasi_astynomias.Count - 1
            Me.DbhotelDataSet.ekt_asty_katast.Rows.Add()

            If flag = 1 Then 'afixeis
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).group_id = 1
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).imerominia = Me.DbhotelDataSet.katastasi_astynomias(j).anaxwrisi
            ElseIf flag = 2 Then 'anaxwriseis
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).group_id = 2
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).imerominia = Me.DbhotelDataSet.katastasi_astynomias(j).afixi
            End If
            Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).dwmatio = Me.DbhotelDataSet.katastasi_astynomias(j).dwmatio
            Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).onomateponimo = Me.DbhotelDataSet.katastasi_astynomias(j).onomateponimo
            Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).patronimo = Me.DbhotelDataSet.katastasi_astynomias(j).patronimo

            Try
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).genisi = Me.DbhotelDataSet.katastasi_astynomias(j).genisi
            Catch ex As StrongTypingException
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).genisi = "------"
            End Try

            Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).toposgenisis = Me.DbhotelDataSet.katastasi_astynomias(j).toposgenisis
            Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).diabatirio = Me.DbhotelDataSet.katastasi_astynomias(j).diabatirio
            Try
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ekdosi = Me.DbhotelDataSet.katastasi_astynomias(j).ekdosi
            Catch ex As StrongTypingException
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ekdosi = "------"
            End Try

            Try
                Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ethnikotita = Me.DbhotelDataSet.katastasi_astynomias(j).ethnikotita
            Catch ex As StrongTypingException
                Try
                    Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ethnikotita = Me.DbhotelDataSet.katastasi_astynomias(j).ethnikotita2
                Catch ex1 As StrongTypingException
                End Try

            End Try
            'If Not Me.DbhotelDataSet.katastasi_astynomias(j).ethnikotita.Equals("") Then
            '    Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ethnikotita = Me.DbhotelDataSet.katastasi_astynomias(j).ethnikotita
            'Else
            '    Me.DbhotelDataSet.ekt_asty_katast(Me.DbhotelDataSet.ekt_asty_katast.Count - 1).ethnikotita = Me.DbhotelDataSet.katastasi_astynomias(j).ethnikotita2
            'End If


        Next

    End Sub
    Private Sub proepiskopisi_asty_katastasi()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New AstyKatast()
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)


        ektiposi.SetDataSource(DbhotelDataSet)
        'CrystalReportViewer1.DisplayGroupTree = False

        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        CrystalReportViewer1.Visible = False
    End Sub
    'Private Function get_calender_id(ByVal dwmatio As String) As String
    '    Dim j As Int16
    '    For j = 0 To Me.DbhotelDataSet.calendar.Count - 1
    '        If Me.DbhotelDataSet.calendar(j).vila = dwmatio Then
    '            Return Me.DbhotelDataSet.calendar(j).calendarid
    '        End If
    '    Next
    '    Return ""
    'End Function
    Private Function ist_pistotiko(ByVal kwdikos As Integer) As Boolean
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.pistwtikaparast.Count - 1
            If Me.DbhotelDataSet.pistwtikaparast(j).parastatiko = kwdikos Then
                Return True
            End If
        Next
        Return False

    End Function
    Private Sub KleisimoHmeras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet1.vilapraktoreia1' table. You can move, or remove it, as needed.
        Me.Vilapraktoreia1TableAdapter.Fill(Me.DbhotelDataSet1.vilapraktoreia1)
        'TODO: This line of code loads data into the 'DbhotelDataSet1.kratiseis' table. You can move, or remove it, as needed.
        Me.KratiseisTableAdapter1.Fill(Me.DbhotelDataSet1.kratiseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.calendar' table. You can move, or remove it, as needed.
        Me.CalendarTableAdapter.Fill(Me.DbhotelDataSet.calendar)
        'TODO: This line of code loads data into the 'DbhotelDataSet.nonshowkratiseis' table. You can move, or remove it, as needed.
        Me.NonshowkratiseisTableAdapter.Fill(Me.DbhotelDataSet.nonshowkratiseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.logariasmoidiam' table. You can move, or remove it, as needed.
        'Me.LogariasmoidiamTableAdapter.Fill(Me.DbhotelDataSet.logariasmoidiam)
        'TODO: This line of code loads data into the 'DbhotelDataSet.gramatia' table. You can move, or remove it, as needed.
        'Me.GramatiaTableAdapter.Fill(Me.DbhotelDataSet.gramatia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.kiniseisjoineggrafes' table. You can move, or remove it, as needed.
        'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.pistwtikes' table. You can move, or remove it, as needed.
        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
        'Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
        'TODO: This line of code loads data into the 'DbhotelDataSet.dwmatia' table. You can move, or remove it, as needed.
        Me.DwmatiaTableAdapter.Fill(Me.DbhotelDataSet.dwmatia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories' table. You can move, or remove it, as needed.
        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
        'TODO: This line of code loads data into the 'DbhotelDataSet.klines' table. You can move, or remove it, as needed.
        maxklines = Me.DbhotelDataSet.etaireia(0).maxklines
        Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)
        Me.CalendarTableAdapter.Fill(Me.DbhotelDataSet.calendar)
        'TODO: This line of code loads data into the 'DbhotelDataSet.tipoi' table. You can move, or remove it, as needed.
        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
        Dim pistparastAdapter As New dbhotelDataSetTableAdapters.pistwtikaparastTableAdapter
        pistparastAdapter.Fill(Me.DbhotelDataSet.pistwtikaparast)
        'Dim pathstart As String = "n:\winfo\client_secrets.json"
        'Dim filename As String
        'If File.Exists(pathstart) Then
        '    fileName = "n:\winfo\client_secrets.json"
        'Else
        '    ' File does not exist at the specified path
        '    ' Use the default path 'c:\winfo\client_secrets.json' instead
        '    fileName = "c:\winfo\client_secrets.json"
        '    ' Use the 'path' variable for further processing
        'End If
    End Sub


    Private Sub komma_einschalten(ByVal sender As System.Object, ByVal e As KeyPressEventArgs)
        Select Case e.KeyChar
            ' Modify '.' to ',' and forward the key.
            Case ChrW(46)
                e.KeyChar = ","
                e.Handled = False
                ' Modify 'b' to 'a' and forward the key.
        End Select



    End Sub

    'Private Sub foreach(treeNode As TreeNode)
    '    Throw New NotImplementedException
    'End Sub
    Private Sub ekt_foroi()
        arxiEtous = "1/1/" + etos.ToString
        telosEtous = "31/12/" + etos.ToString


        EtiketaLbl.Text = "ΕΚΤΥΠΩΣΗ ΦΟΡΩΝ ΔΙΑΜΟΝΗΣ"
        EtiketaLbl.Location = New Point(ExtraParEktPnl.Width / 3, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(KleisimoZentralPnl.Width - 20, 60)
        ForoiPnl.Size = New Point(351, 182)
        ForoiPnl.Location = New Point(140, EtiketaPnl.Height)
        ForoiPicker1.MinDate = arxiEtous
        ForoiPicker1.MaxDate = telosEtous
        ForoiPicker2.MinDate = arxiEtous
        ForoiPicker2.MaxDate = telosEtous
        ForoiPicker1.Value = arxiEtous
        ForoiPicker2.Value = imeromErgasias
        'EkdosiParastPck.Enabled = False
        fuehle_ekd_foroi_cbx()
        Me.KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(EtiketaPnl)
        KleisimoZentralPnl.Controls.Add(ForoiPnl)
    End Sub


    Private Sub fuehle_ekd_foroi_cbx()
        Dim j As Int16
        ForoiCbx.Items.Clear()
        For j = 0 To Me.DbhotelDataSet1.afm.Count
            If j = 0 Then
                ForoiCbx.Items.Add("<Εταιρεία>")
            Else
                ForoiCbx.Items.Add(Me.DbhotelDataSet1.afm(j - 1)._alias)
            End If
        Next
    End Sub
    Private Sub foroiCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForoiCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdForoiAfm = -1
        Else
            kwdForoiAfm = Me.DbhotelDataSet1.afm(sender.selectedINdex - 1).kwd
        End If
    End Sub
    Private Sub ForoiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForoiBtn.Click
        DbhotelDataSet1.EnforceConstraints = False

        If kwdForoiAfm Then
            Dim foroi As New dbhotelDataSet1TableAdapters.forosdiamonisTableAdapter
            If OloiRdb.Checked Then
                foroi.FillForoiByImerominiesEtaireia(Me.DbhotelDataSet1.forosdiamonis, ForoiPicker1.Value.Date, ForoiPicker2.Value.Date, kwdForoiAfm)
            ElseIf MetrRdb.Checked Then
                foroi.FillByImeromPliromEtaireia(Me.DbhotelDataSet1.forosdiamonis, ForoiPicker1.Value.Date, ForoiPicker2.Value.Date, "Μετρητοίς", kwdForoiAfm)
            ElseIf pistosiRdb.Checked Then
                foroi.FillByImeromPliromEtaireia(Me.DbhotelDataSet1.forosdiamonis, ForoiPicker1.Value.Date, ForoiPicker2.Value.Date, "Επί Πιστώση", kwdForoiAfm)
            ElseIf KartesRdb.Checked Then
                foroi.FillByImerKartesEtaireia(Me.DbhotelDataSet1.forosdiamonis, ForoiPicker1.Value.Date, ForoiPicker2.Value.Date, "Μετρητοίς", "Επί Πιστώση", "", kwdForoiAfm)
            End If

            '    MsgBox(Me.DbhotelDataSet.forosdiamonis.Count)
            ektiposi_forwn_diamonis()
        End If

    End Sub

    Private Sub ektiposi_forwn_diamonis()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New TeloiDiamonwn()

        Me.DbhotelDataSet1.ekt_status_ekdosi.Rows.Clear()
        Me.DbhotelDataSet1.ekt_status_ekdosi.Rows.Add()
        Me.DbhotelDataSet1.ekt_status_ekdosi(0).arxi = ForoiPicker1.Value.Date
        Me.DbhotelDataSet1.ekt_status_ekdosi(0).ekdosi = ForoiPicker2.Value.Date

        ektiposi.SetDataSource(DbhotelDataSet1)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True


        Form1.Controls.Add(CrystalReportViewer1)


        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub



    'Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    '    Me.TopMost = True
    'End Sub


End Class