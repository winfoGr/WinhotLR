Imports System.Configuration
Imports System.Data.SqlClient

Public Class SimfoniesFrm

    Structure Periode 'Datastruktur gia speichern twn Periodwn
        Dim belegt As Boolean 'mia uparxousa einai schon belegt beim laden, mia nea mono otan epilegei kai to season
        Dim delete As Boolean 'beim lalden alle false gesetzt
        Dim kwd As Integer 'gia neue periodoi kwd=-1!
        Dim apo As Date
        Dim mexri As Date
        Dim season As Int16 'selectedindex tou COMBOBOX
        Dim release As Integer
    End Structure
    Dim etos As Int16
    Dim imeromErgasias As Date
    Dim praktoreiokwd As Integer
    Dim simbolaiokwd As Integer 'o kwdikos sumbolaioy twn periodwn pou kanw laden (->prepei san globale gia to Insert,Update, delete meta otan kanw speichern/ (-1 einai NEO sumbolaio)
    Dim defaultdate As Date  '= #1/1/2007#als default(->dh leere periodos) date sto Periode (apo,mexri)
    Dim periodoi() As Periode
    Dim currentuser As Int16
    'allotmant A kai B Tropos
    Structure Allotment1
        Dim kwd As Integer ' kwd tis DB
        Dim status As Int16 '1 update- 2 Insert- 
        'Dim delete As Boolean
        Dim apo As Date
        Dim anzahl As Int16
    End Structure
    Dim currentklines, currenttipos As Integer ' xrisimopoiountai sto Allotment a & b tropos gia na kanw elegxo ean to anzahl dwmatiwn sigkekrimenou 
    'tipou pou dinei o xristis einai <= tis dinamis tis katigorias (einai oi DB kwdikoi) ->0 gia ola(siehe manikis)
    Dim allotmstatus As Byte '1 =A tropos 2= B tropos
    Dim firstdatum As Date ' Sto Allotment A&B initialisieren ola ta nea Datums me to arxiko Datum apo tin 1h Toyristiki Periodo tou Simbolaiou
    Dim lastdatum As Date
    Dim maxklines As Int16 = 4
    Dim allotm(30, 11) As Integer
    Dim allotmentA() As Allotment1
    'allotmt B tropos (mono)
    Structure feld
        Dim i As Int16
        Dim j As Int16
    End Structure
    Structure AllotmPeriod
        Dim apo As Date
        Dim mexri As Date
        Dim anzahl As Integer
    End Structure


    'Booking pos
    Dim firstdatumAllotm As Date 'bei Allotment (tupels(simboliaokwd,currentklines,currentipoi,guaranti,kanw raus kriegen MIN(apo)!!!)
    Dim lastdatumAllotm As Date 'bei Allotment
    Dim book(30, 11) As Integer
    Dim currentguarant As Boolean 'sto booking position ean eiani garanti i oxi i katigoria
    Dim bookListe() As Allotment1 ' DStruktur pou tin xrisimopoiw sta BookingPos A tropos gia tin periptwsi pou Imerominia ekdosis exei energopoiithei(=> blepw mono Untermenge twn apothikeumenwn Booking Periodwn!)


    'simfonies
    Structure Timi
        Dim kwd As Integer '0=neu- kai DB kwd gia ta palia! 
        Dim status As Int16 '1=update(GELEDEN APO DB) 2=insert(otan oloklirvthei i eisagwgi klinwn,timwn) 3=FHLERHAFT -1=otan einai neo kai den exei parei akoma to status Insert(=2)
        Dim klines As Int16 ' simpimptei me db kwdiko afou oi klines eiani stin DB (1,monoklinino) (2,diklino) usw.
        Dim paidia As Int16
        Dim atoma As Int16
        Dim timiatomo As Single
        Dim xrwesi As Single
        Dim ypnos As Single
        Dim prwino As Single
        Dim geuma As Single
        Dim deipno As Single
    End Structure
    Dim times() As Timi

    '' Otan kanw laden times exoun mia arxiki timi ana atomo, i opoia apo ton user mporei na alaksei
    ''=> prepei na alaksoun se kathw timi einzeln i xrewsi (me ENTER),kai oi analysi se prwino,geuma ktl
    ''=>i currenttimiatomo apothikeuei tin arxiki timi ana atomo (sto make_times_pnl) gia metepeita elegxo 
    'Dim currenttimiatomo As Decimal
    Dim showhide() As Panel
    Dim simftipos, simfseason, currentsimfonia, currentxrewsi As Integer ' Kwdikoi DB bei SIMFONIES (gesetztz bei den Comboboxen /Radiobutttons)

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect


        Select Case Me.TreeView1.SelectedNode.Name.ToString
            Case "Node20"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.tipoi_xrewsis_zeig()
            Case "Node22"
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.praktoreia_zeig()
            Case "Node23"
                ReDim periodoi(0)
                'EtaireiaPnl.Size = New Point(0, 0)
                Me.HauptPnl.Controls.Clear()
                PeriodoiPnl.Controls.Clear()
                AASimbolPnl.Controls.Clear()
                SimbolaioTbx.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.tourist_periodoi_zeig()
            Case "Node241"
                'Me.DbhotelDataSet.simbolaia.Clear()
                InfoPnl.Controls.Clear()
                ArxiTbx.Clear()
                AASimbPnl.Controls.Clear()
                Allotm2Pnl.Hide()
                Allotm3Pnl.Controls.Clear()
                Allotm3Pnl.Hide()
                Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)

                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.allotment_a()
            Case "Node242"
                'EtaireiaPnl.Size = New Point(0, 0)
                InfoPnl.Controls.Clear()
                ArxiTbx.Clear()
                AASimbPnl.Controls.Clear()
                Allotm2Pnl.Hide()
                Allotm3Pnl.Controls.Clear()
                Allotm3Pnl.Hide()
                Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.allotment_b()
            Case "Node251"
                'EtaireiaPnl.Size = New Point(0, 0)
                ArxiTbx.Clear()
                BPSimbPnl.Controls.Clear()
                AllotmRBPnl.Controls.Clear()
                AllotmSichtPnl.Hide()
                BookPos1Pnl.Controls.Clear()
                BookPos1Pnl.Hide()
                Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.booking_a()
            Case "Node252"
                'EtaireiaPnl.Size = New Point(0, 0)
                ArxiTbx.Clear()
                SimbBPbPnl.Controls.Clear()
                AllotmRBbPnl.Controls.Clear()
                BookPos2Pnl.Controls.Clear()
                BookPos2Pnl.Hide()
                Me.KlinesTableAdapter.FillByMexriKlines(Me.DbhotelDataSet.klines, maxklines)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.booking_b()
            Case "Node26"
                Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
                SimfPnlPnl.Controls.Clear()
                SimfParamPnl.Controls.Clear()
                SimfSimbAAPnl.Controls.Clear()
                SimfAAPnl.Controls.Clear()
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                Me.simfonies()
                show_hide_pnls(0)
            Case "praktoreia"
                'SimfPaidiaPnl.Hide()
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                euretirio_praktoreiwn()
            Case "ektiposi_periodoi"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                euretirio_periodoi()
            Case "ektiposiallotment"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                ektiposi_allotment()
            Case "ektiposibookpos"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                ektiposi_bookpos()
            Case "ekttimokatalog"
                Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                ektiposi_timokatalogoi()
            Case "ekt_ethnikotites"
                Me.HauptPnl.Controls.Clear()
                Me.HauptPnl.BorderStyle = BorderStyle.FixedSingle
                Me.HauptPnl.Dock = DockStyle.Fill
                ektiposi_ethnikotites()
            Case "fortosi"
                fortosi()
            Case "enimerosi"
                enimerosi()
        End Select
    End Sub
    Private Sub fortosi()
        Dim prices As New Prices(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, 1, Me.DbhotelDataSet.etaireia(0).epixirisi)

    End Sub
    Private Sub enimerosi()
        Dim prices As New Prices(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString, 2, Me.DbhotelDataSet.etaireia(0).epixirisi)


    End Sub
    Private Sub ektiposi_ethnikotites()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New Ethnikotites()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
        Me.XoresTableAdapter.Fill(Me.DbhotelDataSet.xores)


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
    End Sub
    '*******************ΕΚΤΥΠΩΣΗ  Τιμοκαταλόγων Πρακτορείω*********************ΕΚΤΥΠΩΣΗ  Τιμοκαταλόγων Πρακτορείω*************ΕΚΤΥΠΩΣΗ  Τιμοκαταλόγων Πρακτορείω*******
    Private Sub ektiposi_timokatalogoi()
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Τιμοκαταλόγων Πρακτορείων"

        EktTimokPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        EktTimokPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        EktTimokTbx.Text = "< όλα >"
        praktoreiokwd = -1
        HauptPnl.Controls.Add(EktTimokPnl)
    End Sub
    Private Sub EktTimokTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktTimokTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen
        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            EktTimokTbx.Text = "< όλα >"
            EktTimokBtn.Focus()
            Exit Sub
        End If

        EktTimokTbx.Text = PraktForm.return_praktoreio
        EktTimokBtn.Focus()
    End Sub
    Private Sub EktTimokBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktTimokBtn.Click
        Dim laufindex, countGroup, groupZaehler As Int16 ', countTimes

        'GRrouparw kata seira->praktname, (praktoreio,tipos,xrewsi,periodos) wobei tipos=studio...,xrewsi=HB...,periodos=Low...
        'xrisimopoiw dataset times_ekt_join opou kanw join sta tables kai silegw ola ta atribute pou xreiazome
        'stin sinexeia xrisimopoiw to times_ekt_join gia na kanw 2 nea datasets->ekt_simf_group kai ekt_TIMES_group 
        'to prwto periexei ola ta (praktoreio,tipos,xrewsi,periodos) eindeutig identifizierbar durch groupzaehler 
        'kai to deutero tis times ana group (verwseis auf group)


        Me.DbhotelDataSet.times_ekt_join.Clear()
        Me.DbhotelDataSet.ekt_simf_group.Clear()
        Me.DbhotelDataSet.ekt_times_group.Clear()
        Me.Cursor = Cursors.WaitCursor
        'apotelesmata tis anfrage einai sortiert kata praktname, usw
        If praktoreiokwd = Nothing Or praktoreiokwd = -1 Then
            Me.Times_ekt_joinTableAdapter.FillJoinByEtos_(Me.DbhotelDataSet.times_ekt_join, etos)
        Else
            Me.Times_ekt_joinTableAdapter.FillJoinByEtosPrakt_(Me.DbhotelDataSet.times_ekt_join, etos, praktoreiokwd)
        End If

        laufindex = 0 'ola ta eintraege durchlaufen
        groupZaehler = 1 'metra OLA ta group->den ginetai RESET->Xrisimeuei sto Crystal Report san kwdiko tou ekt_simf_group gia syndesi me
        'to times_group 
        countGroup = 1 '->poses fore epanlambanetai to IDIO group->otan alaskei ginetai reset=1
        'countTimes = 1

        Do Until laufindex > Me.DbhotelDataSet.times_ekt_join.Count - 1 'ola ta eintraege durchlaufen

            If laufindex + 1 <= Me.DbhotelDataSet.times_ekt_join.Count - 1 Then

                While Me.DbhotelDataSet.times_ekt_join(laufindex).praktoreio = Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).praktoreio


                    If Me.DbhotelDataSet.times_ekt_join(laufindex).tipos <> Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).tipos OrElse
                           Me.DbhotelDataSet.times_ekt_join(laufindex).aasimbolaiou <> Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).aasimbolaiou OrElse
                                   Me.DbhotelDataSet.times_ekt_join(laufindex).xrewsi <> Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).xrewsi OrElse
                                       Me.DbhotelDataSet.times_ekt_join(laufindex).periodos <> Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).periodos Then

                        make_eintrag_bei_ekt_simf_group(laufindex, groupZaehler) 'ftiakse neo group->(praktoreio,tipos,xrewsi,periodos)


                        If countGroup = 1 Then 'MONO mia timi
                            make_eintrag_ekt_timi_group(laufindex, groupZaehler)
                        Else
                            make_eintrag_ekt_timi_group(laufindex + countGroup - 1, groupZaehler)
                        End If

                        groupZaehler += 1 'to ID +1 
                        laufindex = laufindex + countGroup 'anipsose laufindex->durchlauft ola ta eintraege tou times_ekt_join
                        countGroup = 1
                        If laufindex = Me.DbhotelDataSet.times_ekt_join.Count - 1 Then 'telos erreicht?
                            'ftiakse neo group/me mia timi ->(einai opwsdipote NEO giiati ean to teleutaio eintrag htan tou idiou group me to
                            'proteleutaio tote tha empene sto * (koita else...) 
                            make_eintrag_ekt_timi_group(Me.DbhotelDataSet.times_ekt_join.Count - 1, groupZaehler)
                            make_eintrag_bei_ekt_simf_group(Me.DbhotelDataSet.times_ekt_join.Count - 1, groupZaehler)
                            Exit Do
                        End If
                    Else 'poles times (diklina me 1 paidi, triklina ...usw) tou idiou group_>otan ftasoume stin teleutaia tote pame pano kai ftiaxnoume to group->dil. prwta times me groupzaehler
                        'der auf group zeigt und dann der group mit groupzaehler als ID

                        make_eintrag_ekt_timi_group(laufindex + countGroup - 1, groupZaehler)
                        'countTimes += 1
                        countGroup += 1
                        If laufindex + countGroup > Me.DbhotelDataSet.times_ekt_join.Count - 1 Then '(*)->teleutaio einrtag IDIOU group me to proteleutaio
                            make_eintrag_ekt_timi_group(Me.DbhotelDataSet.times_ekt_join.Count - 1, groupZaehler)
                            make_eintrag_bei_ekt_simf_group(Me.DbhotelDataSet.times_ekt_join.Count - 1, groupZaehler)
                            Exit Do
                        End If
                        If Me.DbhotelDataSet.times_ekt_join(laufindex).praktoreio <> Me.DbhotelDataSet.times_ekt_join(laufindex + countGroup).praktoreio Then
                            laufindex = laufindex + countGroup - 1
                            countGroup = 1
                        End If
                    End If

                End While

                make_eintrag_ekt_timi_group(laufindex, groupZaehler)
                make_eintrag_bei_ekt_simf_group(laufindex, groupZaehler)
                groupZaehler += 1
                laufindex = laufindex + countGroup
                countGroup = 1
            Else
                make_eintrag_ekt_timi_group(laufindex, groupZaehler)
                make_eintrag_bei_ekt_simf_group(laufindex, groupZaehler)
                Exit Do
            End If


        Loop
        Me.Cursor = Cursors.Default
        proep_timokatalog()


    End Sub
    Private Sub proep_timokatalog()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New Timokatalogos()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        If Me.DbhotelDataSet.ekt_simf_group.Count <> 0 Then
            Me.DbhotelDataSet.ekt_simf_group(0).etos = etos
        End If

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
    End Sub
    Private Sub make_eintrag_bei_ekt_simf_group(ByVal index As Int16, ByVal goupzaehler As Int16)
        Dim tips As String

        tips = Me.get_tipos_by_kwdikos(Me.DbhotelDataSet.times_ekt_join(index).tipos)
        'MsgBox(tips)
        Me.DbhotelDataSet.ekt_simf_group.Rows.Add()
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).groupzaehler = goupzaehler

        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).praktkwd = Me.DbhotelDataSet.times_ekt_join(index).praktoreio
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).praktname = Me.DbhotelDataSet.times_ekt_join(index).eponimia
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).aasimbolaiou = Me.DbhotelDataSet.times_ekt_join(index).aasimbolaiou
        If tips = Nothing Then
            Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).tipos = "ΟΛΟΙ"
        Else
            Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).tipos = tips
        End If

        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).season = Me.DbhotelDataSet.times_ekt_join(index).periodos
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).oroi = Me.DbhotelDataSet.times_ekt_join(index).xrewsiname
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).paidi1klinofree = Me.DbhotelDataSet.times_ekt_join(index).paidi1klinofree
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).paidi1klinoews = Me.DbhotelDataSet.times_ekt_join(index).paidi1klinoews
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).paidi2klinofree = Me.DbhotelDataSet.times_ekt_join(index).paidi2klinofree
        Me.DbhotelDataSet.ekt_simf_group(Me.DbhotelDataSet.ekt_simf_group.Count - 1).paidi2klinoews = Me.DbhotelDataSet.times_ekt_join(index).paidi2klinoews
    End Sub
    Private Sub make_eintrag_ekt_timi_group(ByVal index As Int16, ByVal groupzaehler As Int16)
        Dim klines, paidia, atoma As String
        Me.DbhotelDataSet.ekt_times_group.Rows.Add()

        paidia = Nothing

        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).groupzeiger = groupzaehler
        'Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).groupzaehler = countTimes

        klines = Me.DbhotelDataSet.klines(Me.DbhotelDataSet.times_ekt_join(index).klines - 1).perigrafi
        If Me.DbhotelDataSet.times_ekt_join(index).paidi = 1 Then
            paidia = "1 Παιδί"
        ElseIf Me.DbhotelDataSet.times_ekt_join(index).paidi > 1 Then
            paidia = Me.DbhotelDataSet.times_ekt_join(index).paidi.ToString + " Παιδιά"
        End If

        atoma = Me.DbhotelDataSet.times_ekt_join(index).atoma.ToString + " Aτομ."

        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).bezeichnung = klines + " " + paidia + "(" + atoma + ")"
        'MsgBox(klines + " " + paidia + "(" + atoma + ")")
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).timiatomo = Me.DbhotelDataSet.times_ekt_join(index).timiatomo
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).ipnos = Me.DbhotelDataSet.times_ekt_join(index).ipnos
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).prwino = Me.DbhotelDataSet.times_ekt_join(index).prwino
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).geuma = Me.DbhotelDataSet.times_ekt_join(index).geuma
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).deipno = Me.DbhotelDataSet.times_ekt_join(index).deipno
        Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).synolo = Me.DbhotelDataSet.times_ekt_join(index).synolo
        'MsgBox(Me.DbhotelDataSet.ekt_times_group(Me.DbhotelDataSet.ekt_times_group.Count - 1).synolo)
    End Sub
    '*******************ΕΚΤΥΠΩΣΗ  BOOKING POS*********************ΕΚΤΥΠΩΣΗ  BOOKING POS*************ΕΚΤΥΠΩΣΗ   BOOKING POS**************
    Private Sub ektiposi_bookpos()
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Booking Positions Πρακτορείων"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        EktBookPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        EktBookPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        EktBookTbx.Text = "< όλα >"
        praktoreiokwd = -1
        HauptPnl.Controls.Add(EktBookPnl)
    End Sub
    Private Sub EktBookTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktBookTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen
        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            EktBookTbx.Text = "< όλα >"
            EktBookBtn.Focus()
            Exit Sub
        End If

        EktBookTbx.Text = PraktForm.return_praktoreio
        EktBookBtn.Focus()
    End Sub
    Private Sub EktBookBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktBookBtn.Click
        Dim apo, mexri As Date
        Dim startIndex, countIndex, countGroup As Int16
        Dim bookAnzahl(30, 11) As Int16

        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString

        Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()
        Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias

        Me.DbhotelDataSet.ekt_allotment.Clear()

        If praktoreiokwd = Nothing Or praktoreiokwd = -1 Then
            Me.BookingposTableAdapter.FillSortOrderByApoMexri(Me.DbhotelDataSet.bookingpos, apo, mexri)
            Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
            Me.SimbolaiaTableAdapter.FillByEtos(Me.DbhotelDataSet.simbolaia, etos)
        Else
            Me.BookingposTableAdapter.FillSOrtOrderByApoMexriPraktoreio(Me.DbhotelDataSet.bookingpos, apo, mexri, praktoreiokwd)
            Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
            Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, praktoreiokwd)
        End If


        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.bookingpos.Count - 1
            countIndex = 1
            'countGroup = 0
            If startIndex < Me.DbhotelDataSet.bookingpos.Count - 1 Then
                While Me.DbhotelDataSet.bookingpos(startIndex).simbolaio = Me.DbhotelDataSet.bookingpos(startIndex + countIndex).simbolaio
                    'MsgBox(Me.DbhotelDataSet.allotment(startIndex).klines)
                    'MsgBox(Me.DbhotelDataSet.allotment(startIndex).tipos)
                    If Me.DbhotelDataSet.bookingpos(startIndex).klines = Me.DbhotelDataSet.bookingpos(startIndex + countIndex).klines AndAlso
                    Me.DbhotelDataSet.bookingpos(startIndex).tipos = Me.DbhotelDataSet.bookingpos(startIndex + countIndex).tipos AndAlso
                        Me.DbhotelDataSet.bookingpos(startIndex).guarantee = Me.DbhotelDataSet.bookingpos(startIndex + countIndex).guarantee Then
                        countIndex += 1
                    Else
                        Exit While
                    End If
                    If startIndex + countIndex > Me.DbhotelDataSet.bookingpos.Count - 1 Then
                        Exit While
                    End If
                End While
                countGroup += 1
                ReDim bookAnzahl(30, 11)
                init_book()
                lade_von_db_zu_book_datastruktur(startIndex, countIndex, bookAnzahl)
                fuelle_ekt_bookpos(startIndex, countGroup, bookAnzahl)

                startIndex = startIndex + countIndex
            Else 'esdw???????????????????/
                countGroup += 1
                ReDim bookAnzahl(30, 11)
                init_book()
                lade_von_db_zu_book_datastruktur(startIndex, countIndex, bookAnzahl)
                fuelle_ekt_bookpos(startIndex, countGroup, bookAnzahl)
                Exit Do
            End If

        Loop

        proepiskopisi_ekt_bookpos()

    End Sub
    Private Sub proepiskopisi_ekt_bookpos()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New BookPosPrakt()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    End Sub
    Private Sub lade_von_db_zu_book_datastruktur(ByVal start As Int16, ByVal lauf As Int16, ByRef bookAnzahl(,) As Int16)
        Dim i, j, z As Int16

        Dim epomina, mexrimina As Int16

        For z = 1 To lauf

            epomina = Me.DbhotelDataSet.bookingpos(start + z - 1).apo.Date.Month
            'mexrimera = Me.DbhotelDataSet.allotment(z).mexri.Date.Day
            mexrimina = Me.DbhotelDataSet.bookingpos(start + z - 1).mexri.Date.Month

            For j = Me.DbhotelDataSet.bookingpos(start + z - 1).apo.Date.Month To Me.DbhotelDataSet.bookingpos(start + z - 1).mexri.Date.Month
                For i = 1 To 31
                    If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                    OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                        Exit For
                    End If
                    If (Not j = Me.DbhotelDataSet.bookingpos(start + z - 1).apo.Month Or Not i < Me.DbhotelDataSet.bookingpos(start + z - 1).apo.Day) And
                                    (Not j = Me.DbhotelDataSet.bookingpos(start + z - 1).mexri.Month Or Not i > Me.DbhotelDataSet.bookingpos(start + z - 1).mexri.Day) Then
                        bookAnzahl(i - 1, j - 1) = Me.DbhotelDataSet.bookingpos(start + z - 1).anzahl
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub fuelle_ekt_bookpos(ByVal start As Int16, ByVal zaehler As Int16, ByVal bookAnzahl(,) As Int16)
        Dim j, i As Int16
        Dim klins, tips As String

        For j = 0 To 30
            If exist_anzahl_am_tag(j, bookAnzahl) Then

                Me.DbhotelDataSet.ekt_allotment.Rows.Add()

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).groupzaehler = zaehler

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).simbolaio = Me.DbhotelDataSet.bookingpos(start).simbolaio

                klins = Me.get_klines_by_kwdikos(Me.DbhotelDataSet.bookingpos(start).klines)
                If klins = Nothing Then
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).klines = "ΟΛΕΣ"
                Else
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).klines = klins
                End If
                tips = Me.get_tipos_by_kwdikos(Me.DbhotelDataSet.bookingpos(start).tipos)
                If tips = Nothing Then
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).tipos = "ΟΛΟΙ"
                Else
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).tipos = tips
                End If
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).guaranti = Me.DbhotelDataSet.bookingpos(start).guarantee

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).imera = j + 1


                For i = 0 To 11
                    plaziere_anzahl(Me.DbhotelDataSet.ekt_allotment.Count - 1, i, bookAnzahl(j, i))

                Next


                'plaziere_anzahl(Me.DbhotelDataSet.ekt_allotment.Count - 1,

            End If
        Next
    End Sub
    '*******************ΕΚΤΥΠΩΣΗ  ΑΛΛΟΤΜΕΝΤ*********************ΕΚΤΥΠΩΣΗ  ΑΛΛΟΤΜΕΝΤ**************ΕΚΤΥΠΩΣΗ  ΑΛΛΟΤΜΕΝΤ*******************
    Private Sub ektiposi_allotment()
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Allotment Πρακτορείων"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        EktAllotmentPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        EktAllotmentPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        EktAllotmentTbx.Text = "< όλα >"
        praktoreiokwd = -1
        HauptPnl.Controls.Add(EktAllotmentPnl)
    End Sub

    Private Sub EktAllotmentTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktAllotmentTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen
        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            EktAllotmentTbx.Text = "< όλα >"
            EktAllotment1Btn.Focus()
            Exit Sub
        End If

        EktAllotmentTbx.Text = PraktForm.return_praktoreio
        EktAllotment1Btn.Focus()
    End Sub
    Private Sub EktAllotment1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktAllotment1Btn.Click
        Dim apo, mexri As Date
        Dim startIndex, countIndex, countGroup As Int16
        Dim allotmAnzahl(30, 11) As Int16

        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString

        Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()
        Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias

        Me.DbhotelDataSet.ekt_allotment.Clear()

        If praktoreiokwd = Nothing Or praktoreiokwd = -1 Then
            Me.AllotmentTableAdapter.FillSortOrderByApoMexri(Me.DbhotelDataSet.allotment, apo, mexri)
            Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
            Me.SimbolaiaTableAdapter.FillByEtos(Me.DbhotelDataSet.simbolaia, etos)
        Else
            Me.AllotmentTableAdapter.FillSortOrderByApoMexrPraktoreio(Me.DbhotelDataSet.allotment, apo, mexri, praktoreiokwd)
            Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
            Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, praktoreiokwd)
        End If


        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.allotment.Count - 1
            countIndex = 1
            'countGroup = 0
            If startIndex < Me.DbhotelDataSet.allotment.Count - 1 Then
                While Me.DbhotelDataSet.allotment(startIndex).simbolaio = Me.DbhotelDataSet.allotment(startIndex + countIndex).simbolaio
                    'MsgBox(Me.DbhotelDataSet.allotment(startIndex).klines)
                    'MsgBox(Me.DbhotelDataSet.allotment(startIndex).tipos)
                    If Me.DbhotelDataSet.allotment(startIndex).klines = Me.DbhotelDataSet.allotment(startIndex + countIndex).klines AndAlso
                    Me.DbhotelDataSet.allotment(startIndex).tipos = Me.DbhotelDataSet.allotment(startIndex + countIndex).tipos AndAlso
                        Me.DbhotelDataSet.allotment(startIndex).guaranti = Me.DbhotelDataSet.allotment(startIndex + countIndex).guaranti Then
                        countIndex += 1
                    Else
                        Exit While
                    End If
                    If startIndex + countIndex > Me.DbhotelDataSet.allotment.Count - 1 Then
                        Exit While
                    End If
                End While
                countGroup += 1
                ReDim allotmAnzahl(30, 11)
                init_allotm()
                lade_von_db_zu_datastruktur(startIndex, countIndex, allotmAnzahl)
                fuelle_ekt_allotm(startIndex, countGroup, allotmAnzahl)

                startIndex = startIndex + countIndex
            Else 'esdw???????????????????/
                countGroup += 1
                ReDim allotmAnzahl(30, 11)
                init_allotm()
                lade_von_db_zu_datastruktur(startIndex, countIndex, allotmAnzahl)
                fuelle_ekt_allotm(startIndex, countGroup, allotmAnzahl)
                Exit Do
            End If

        Loop

        proepiskopisi_ekt_alotment()


    End Sub
    Private Sub proepiskopisi_ekt_alotment()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New AllotmentPrakt()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    End Sub
    Private Sub fuelle_ekt_allotm(ByVal start As Int16, ByVal zaehler As Int16, ByVal allotmAnzahl(,) As Int16)
        Dim j, i As Int16
        Dim klins, tips As String

        For j = 0 To 30
            If exist_anzahl_am_tag(j, allotmAnzahl) Then

                Me.DbhotelDataSet.ekt_allotment.Rows.Add()

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).groupzaehler = zaehler

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).simbolaio = Me.DbhotelDataSet.allotment(start).simbolaio

                klins = Me.get_klines_by_kwdikos(Me.DbhotelDataSet.allotment(start).klines)
                If klins = Nothing Then
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).klines = "ΟΛΕΣ"
                Else
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).klines = klins
                End If
                tips = Me.get_tipos_by_kwdikos(Me.DbhotelDataSet.allotment(start).tipos)
                If tips = Nothing Then
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).tipos = "ΟΛΟΙ"
                Else
                    Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).tipos = tips
                End If
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).guaranti = Me.DbhotelDataSet.allotment(start).guaranti

                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).imera = j + 1


                For i = 0 To 11
                    plaziere_anzahl(Me.DbhotelDataSet.ekt_allotment.Count - 1, i, allotmAnzahl(j, i))

                Next


                'plaziere_anzahl(Me.DbhotelDataSet.ekt_allotment.Count - 1,

            End If
        Next




    End Sub
    Private Sub lade_von_db_zu_datastruktur(ByVal start As Int16, ByVal lauf As Int16, ByRef allotmAnzahl(,) As Int16)
        Dim i, j, z As Int16
        'Dim allotmAnzahl(30, 11) As Int16
        Dim apomina, mexrimina As Int16

        'ReDim allotmAnzahl(30, 11)

        For z = 1 To lauf
            apomina = Me.DbhotelDataSet.allotment(start + z - 1).apo.Date.Month
            mexrimina = Me.DbhotelDataSet.allotment(start + z - 1).mexri.Date.Month
            For j = Me.DbhotelDataSet.allotment(start + z - 1).apo.Date.Month To Me.DbhotelDataSet.allotment(start + z - 1).mexri.Date.Month
                For i = 1 To 31
                    If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                    OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                        Exit For
                    End If
                    If (Not j = Me.DbhotelDataSet.allotment(start + z - 1).apo.Month Or Not i < Me.DbhotelDataSet.allotment(start + z - 1).apo.Day) And
                                    (Not j = Me.DbhotelDataSet.allotment(start + z - 1).mexri.Month Or Not i > Me.DbhotelDataSet.allotment(start + z - 1).mexri.Day) Then

                        allotmAnzahl(i - 1, j - 1) = Me.DbhotelDataSet.allotment(start + z - 1).anzahl

                    End If
                Next
            Next

        Next

    End Sub
    Private Sub plaziere_anzahl(ByVal index As Int16, ByVal monat As Int16, ByVal anzahl As Int16)

        Select Case monat
            Case 0
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).jan = anzahl
            Case 1
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).feb = anzahl
            Case 2
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).mar = anzahl
            Case 3
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).apr = anzahl
            Case 4
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).mai = anzahl
            Case 5
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).jun = anzahl
            Case 6
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).jul = anzahl
            Case 7
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).aug = anzahl
            Case 8
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).sep = anzahl
            Case 9
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).okt = anzahl
            Case 10
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).nov = anzahl
            Case 11
                Me.DbhotelDataSet.ekt_allotment(Me.DbhotelDataSet.ekt_allotment.Count - 1).dez = anzahl
        End Select


    End Sub
    Private Function exist_anzahl_am_tag(ByVal i As Int16, ByVal allotmAnzahl(,) As Int16) As Boolean
        Dim j As Int16
        For j = 0 To 11
            If allotmAnzahl(i, j) <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    '******************EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI
    '******************EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI
    '******************EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI***EYRETHRIO PERIODOI

    Private Sub euretirio_periodoi()

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Ευρετήριο Τουριστικών Περιόδων"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        HauptPnl.Controls.Add(EuretirioPeriodoiPnl)
        EuretirioPeriodoiPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        EuretirioPeriodoiPnl.Location = New Point(5, EtiketaPnl.Height + 5)
    End Sub
    Private Sub EuretirioPeriodoiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EuretirioPeriodoiBtn.Click
        Dim apo, mexri As Date
        Dim startIndex, countIndex As Int16

        Me.DbhotelDataSet.touristperiodoi1.Clear()
        Me.DbhotelDataSet.ekt_tourist_period.Clear()

        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString
        If OrderPraktRdb.Checked Then
            'to touristperiodoi einai sortiert prwta kata simbolaiokwd kai meta kata apo (imerominia) ->oloi o periodoi enos simbolaiou einai mazemenoi mazi
            Me.Touristperiodoi1TableAdapter.FillAlleEtousOrderAlfaBita(Me.DbhotelDataSet.touristperiodoi1, apo, mexri)
        Else
            Me.Touristperiodoi1TableAdapter.FillAlleEtousOrderKwd(Me.DbhotelDataSet.touristperiodoi1, apo, mexri)
        End If


        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.touristperiodoi1.Count - 1
            countIndex = 1
            If startIndex < Me.DbhotelDataSet.touristperiodoi1.Count - 1 Then
                While Me.DbhotelDataSet.touristperiodoi1(startIndex).simbolaio = Me.DbhotelDataSet.touristperiodoi1(startIndex + countIndex).simbolaio
                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.touristperiodoi1.Count - 1 Then
                        Exit While
                    End If
                End While
                fuelle_ekt_tourist_periodoi(startIndex, countIndex)
                startIndex = startIndex + countIndex
            Else
                fuelle_ekt_tourist_periodoi(Me.DbhotelDataSet.touristperiodoi1.Count - 1, 1)
                Exit Do
            End If

        Loop

        proepiskopisi_tourist_periodoi()


    End Sub
    Private Sub proepiskopisi_tourist_periodoi()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New TouristPeriodoi()

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    End Sub

    Private Sub fuelle_ekt_tourist_periodoi(ByVal start As Int16, ByVal lauf As Int16)
        Dim j As Int16
        Me.DbhotelDataSet.ekt_tourist_period.Rows.Add()

        Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).praktkwd = Me.DbhotelDataSet.touristperiodoi1(start).praktoreio
        Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).praktname = Me.DbhotelDataSet.touristperiodoi1(start).eponimia
        Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).simbolaio = Me.DbhotelDataSet.touristperiodoi1(start).perigrafi


        For j = 1 To lauf
            Select Case j
                Case 1
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo1 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri1 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod1 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason1 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 2
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo2 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri2 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod2 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason2 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 3
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo3 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri3 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod3 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason3 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 4
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo4 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri4 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod4 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason4 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.'Substring(0, 4)
                Case 5
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo5 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri5 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod5 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason5 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 6
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo6 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri6 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod6 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason6 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 7
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo7 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri7 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod7 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason7 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 8
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo8 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri8 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod8 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason8 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 9
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo9 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri9 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod9 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason9 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 10
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo10 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri10 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod10 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason10 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
                Case 11
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perapo11 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).apo
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).permexri11 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).mexri
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perrelperiod11 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).relperiod
                    Me.DbhotelDataSet.ekt_tourist_period(Me.DbhotelDataSet.ekt_tourist_period.Count - 1).perseason11 = Me.DbhotelDataSet.touristperiodoi1(start + j - 1).periodos '.Substring(0, 4)
            End Select
        Next

    End Sub
    '*******************ΕΥΡΕΤΗΡΙΟ ΠΡΑΚΤΟΡΕΙΩΝ*******************ΕΥΡΕΤΗΡΙΟ ΠΡΑΚΤΟΡΕΙΩΝ******************ΕΥΡΕΤΗΡΙΟ ΠΡΑΚΤΟΡΕΙΩΝ******
    Private Sub euretirio_praktoreiwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New PraktoreiaEuretirio()

        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    '*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES
    '*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES
    '*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES
    '*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES*******************SIMFONIES
    Private Sub simfonies()
        Dim locx, locy As Int16

        praktoreiokwd = Nothing
        'Dim InfoLbl As New Label
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10

        simftipos = -1 'kwdikoi DB tis cuurent simfonias
        simfseason = -1

        init_showhide()

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ΤΙΜΟΚΑΤΑΛΟΓΟΙ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        HauptPnl.Controls.Add(SimfoniesPnl)
        SimfoniesPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        SimfoniesPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        SimfPraktTbx.Text = " <Κάνετε κλίκ εδώ> "
        InfSinfLbl.Size = New Point(200, SimfPnlPnl.Height - 20)
        InfSinfLbl.Text = "Επιλέξτε διαδοχικά Κλίνες και αρθμό Παιδιών. Το Πρόγραμμα υπολογίζει αυτόματα το πλήθος Ατόμων, την Συνολική Χρέωση κατά την είσοδο στο αντίστοιχο κελί, καθώς και την Αναλυσή της με την έξοδο. " & vbCrLf & " (Στίς τιμές περιέχονται οι προβλεπόμενοι φόροι) "
    End Sub

    Private Sub SimfPraktTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimfPraktTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()
        Dim praktTemp As Integer
        PraktForm.StartPosition = FormStartPosition.CenterScreen


        PraktForm.ShowDialog()
        praktTemp = PraktForm.return_praktoreio_kwdikos
        If praktTemp = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If praktoreiokwd = Nothing Then
                SimfPraktTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
                SimfSimbAAPnl.Focus()
                SimfSimbAAPnl.Controls.Clear()
                Exit Sub
            Else
                Exit Sub
            End If
        Else
            praktoreiokwd = praktTemp
        End If


        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

        SimfPraktTbx.Text = PraktForm.return_praktoreio
        SimfSimbAAPnl.Focus()

        PraktForm.Dispose()
        show_hide_pnls(0)
        zeige_simbolia_RB(0, 2) ' 'Me.PraktoreioTbx.Location.X, Label21.Location.Y - 5
    End Sub
    Private Sub zeige_simbolia_RB(ByVal x As Integer, ByVal y As Integer)
        Dim Erstesbuttn As New RadioButton
        Dim line As Int16 = 0
        Dim i, k As Int16

        k = -1

        SimfSimbAAPnl.Controls.Clear()
        'SimbPerigrTbx.Clear()
        Erstesbuttn.Checked = False
        ' Ta radiobuttons einai panw sto panel SimfSimbAAPnl gia eukoloteri xrisi...
        For i = 0 To Me.DbhotelDataSet.simbolaia.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 70
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleRight

            SimfSimbAAPnl.Controls.Add(AArdbuttn)

            AArdbuttn.Cursor = Cursors.Hand
            AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.simbolaia(i).kwd.ToString
            If i = Me.DbhotelDataSet.simbolaia.Count - 1 Then
                AArdbuttn.Checked = True
            End If
            AArdbuttn.Text = Me.DbhotelDataSet.simbolaia(i).aasimbolaiou
            If i Mod 4 = 0 Then
                line = line + 20
                k = 0
            Else
                k = k + 1
            End If

            AArdbuttn.Location = New Point(x + k * AArdbuttn.Width + 5, y + line - 20)
            If i = 0 Then
                Erstesbuttn = AArdbuttn
            End If
            AddHandler AArdbuttn.CheckedChanged, AddressOf simbolia_RB_CheckedChanged

        Next

        Erstesbuttn.Checked = False ' Proepilogi to 1o simbolaio is checked!
        Erstesbuttn.Checked = True
    End Sub

    Private Sub simbolia_RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        SimfParamPnl.Controls.Clear()
        show_hide_pnls(0)
        If sender.checked = True Then
            Try

                simbolaiokwd = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
                Me.SimbolaiaTableAdapter.PerigrafiByKwd(Me.DbhotelDataSet.simbolaia, simbolaiokwd)

                Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)

                zeige_simfonia_parametroi_pnl()
            Catch ex As InvalidCastException

            End Try

        End If
    End Sub


    Private Sub zeige_simfonia_parametroi_pnl()
        Dim SimbTbx As New TextBox
        Dim SimbLbl As New Label
        Dim TiposLbl As New Label
        Dim SeasLbl As New Label

        'SimfAAPnl.Show()
        'SimfPaidiaPnl.Show()
        'SimfPososPnl.Show()
        'TimesCBoxenPnl.Show()

        SimbTbx.TextAlign = HorizontalAlignment.Center
        SimbTbx.Text = Me.DbhotelDataSet.simbolaia(0).perigrafi

        SimbTbx.Size = New Point(270, 20)
        SimbTbx.Location = New Point(180, 14)
        SimbLbl.Text = "Περιγραφή:"

        SimbLbl.Location = New Point(96, 18)

        TiposLbl.Text = "Τύπος (Θέα):"
        TiposLbl.ForeColor = Color.Blue
        TiposLbl.Location = New Point(21, 53)

        SeasLbl.Text = "Season:"
        SeasLbl.ForeColor = Color.Blue
        SeasLbl.Size = New Point(70, 20)
        SeasLbl.Location = New Point(367, 54)

        SimfParamPnl.Controls.Add(SimbTbx)
        SimfParamPnl.Controls.Add(SimbLbl)
        SimfParamPnl.Controls.Add(TiposLbl)
        SimfParamPnl.Controls.Add(SeasLbl)


        Dim j, anzahl1, anzahl2, seasoncount As Int16 ' Anzahl1 ->count DB allotment me tipo=0(->OLOI OI TIPOI), Anzahl2 count DB allotment me SIGKEKRIMENO tipo
        Dim TipoiCbx As New ComboBox
        Dim SeasCbx As New ComboBox

        TipoiCbx.ForeColor = Color.Maroon
        TipoiCbx.Name = "TpsCbx"
        SeasCbx.Name = "SsnCbx"
        SeasCbx.ForeColor = Color.Maroon
        SimfParamPnl.Controls.Add(TipoiCbx)
        SimfParamPnl.Controls.Add(SeasCbx)

        TipoiCbx.Location = New Point(TiposLbl.Location.X + TiposLbl.Width, TiposLbl.Location.Y - 5)
        SeasCbx.Location = New Point(SeasLbl.Location.X + SeasLbl.Width, SeasLbl.Location.Y - 5)
        TipoiCbx.Items.Clear()
        SeasCbx.Items.Clear()

        'anzahl1 = Me.AllotmentTableAdapter.ExistAllotmByTiposSimbol(simbolaiokwd, 0)
        'If anzahl1 = 0 Then   ' Des an iparxei allotment me sigkekromeno Tipo 
        '    For j = 0 To Me.DbhotelDataSet.tipoi.Count
        '        If j <> 0 Then
        '            anzahl2 = Me.AllotmentTableAdapter.ExistAllotmByTiposSimbol(simbolaiokwd, Me.DbhotelDataSet.tipoi(j - 1).kwd)
        '            If anzahl2 <> 0 Then
        '                TipoiCbx.Items.Add(Me.DbhotelDataSet.tipoi(j - 1).tipos)
        '            End If
        '        Else
        '            TipoiCbx.Items.Add("Όλοι")
        '        End If

        '    Next
        'Else ' OLOI oi tipoi
        '    For j = 0 To Me.DbhotelDataSet.tipoi.Count
        '        If j <> 0 Then
        '            TipoiCbx.Items.Add(Me.DbhotelDataSet.tipoi(j - 1).tipos)
        '        Else
        '            TipoiCbx.Items.Add("Όλοι")
        '        End If

        '    Next
        'End If
        For j = 0 To Me.DbhotelDataSet.tipoi.Count
            If j <> 0 Then
                TipoiCbx.Items.Add(Me.DbhotelDataSet.tipoi(j - 1).tipos)
            Else
                TipoiCbx.Items.Add("Όλοι")
            End If

        Next

        For j = 0 To Me.DbhotelDataSet.seasons.Count - 1
            seasoncount = Me.TouristperiodoiTableAdapter.ExistSeasonBySimbolaio(simbolaiokwd, Me.DbhotelDataSet.seasons(j).kwd)
            If seasoncount <> 0 Then
                SeasCbx.Items.Add(get_periodos_season(Me.DbhotelDataSet.seasons(j).kwd))
            End If
        Next
        AddHandler TipoiCbx.SelectedIndexChanged, AddressOf comboxen_selected_index_changed
        AddHandler SeasCbx.SelectedIndexChanged, AddressOf comboxen_selected_index_changed

    End Sub
    Private Sub comboxen_selected_index_changed(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'simftipos, simfseason
        SimfTipoiXrewsPnl.Controls.Clear()
        TimesCBoxenPnl.Controls.Clear()
        SimfAAPnl.Controls.Clear()
        'MsgBox("stop")
        zeige_neu_paidia_times_parametroi()

        If sender.name.Equals("TpsCbx") Then

            simftipos = get_kwd_tipos_by_simfonia(sender.selectedindex, sender)
            If simftipos = -11 Then 'exei epilexthei OLOI
                simftipos = 0
            End If
        ElseIf sender.name.Equals("SsnCbx") Then

            simfseason = get_kwd_season_by_simfonia(sender.selectedindex, sender)

        End If
        Me.SimfoniesTableAdapter.FillByTiposSeason(Me.DbhotelDataSet.simfonies, simbolaiokwd, simftipos, simfseason)

        If simfseason <> -1 And simftipos <> -1 Then
            zeig_aa_simfonies_radiobuttons(0, 2, False)
        End If
        'MsgBox("stop1")
        show_hide_pnls(1)
        'MsgBox("stop2")
    End Sub
    Private Sub zeig_aa_simfonies_radiobuttons(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean)

        Dim i As Int16
        SimfAAPnl.Controls.Clear()
        ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...
        For i = 0 To Me.DbhotelDataSet.simfonies.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 70
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleRight
            AArdbuttn.Cursor = Cursors.Hand

            AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.simfonies(i).kwd.ToString
            If i = Me.DbhotelDataSet.simfonies.Count - 1 AndAlso remalen Then
                AArdbuttn.Checked = True
            End If
            AArdbuttn.Text = Me.DbhotelDataSet.simfonies(i).aa
            AArdbuttn.Location = New Point(x + i * AArdbuttn.Width + 10, y)
            AddHandler AArdbuttn.Click, AddressOf ΑΑ_RB_Click
            SimfAAPnl.Controls.Add(AArdbuttn)
        Next
        Dim NEWbuttn As New RadioButton
        NEWbuttn.Width = 70
        NEWbuttn.CheckAlign = ContentAlignment.MiddleRight
        NEWbuttn.TextAlign = ContentAlignment.MiddleRight
        NEWbuttn.Cursor = Cursors.Hand

        NEWbuttn.Name = "Neu"

        NEWbuttn.Text = "Νέος"
        NEWbuttn.Location = New Point(x + i * NEWbuttn.Width + 10, y)

        If Me.DbhotelDataSet.simfonies.Count <> 0 Then
            Dim DelSimfBtn As New Button
            DelSimfBtn.BackColor = Color.Azure
            DelSimfBtn.ForeColor = Color.Red
            DelSimfBtn.Text = "Διαγραφή"
            DelSimfBtn.Size = New Point(100, 25)
            DelSimfBtn.Cursor = Cursors.Hand
            DelSimfBtn.Location = New Point(x + (i + 2) * NEWbuttn.Width + 10, y)
            SimfAAPnl.Controls.Add(DelSimfBtn)
            AddHandler DelSimfBtn.Click, AddressOf delete_simfonia
        End If


        SimfAAPnl.Controls.Add(NEWbuttn)

        AddHandler NEWbuttn.Click, AddressOf ΑΑ_RB_Click

    End Sub
    Private Sub ΑΑ_RB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TimesCBoxenPnl.Controls.Clear()

        If Not sender.name.Equals("Neu") Then
            currentsimfonia = sender.name.Substring(3, sender.NAME.ToString.Length - 3) 'DB kwd simfonias
            Me.DbhotelDataSet.simfonies.Clear()

            Me.SimfoniesTableAdapter.FillByKwd(Me.DbhotelDataSet.simfonies, currentsimfonia)

            zeige_paidia_times_parametroi()
            zeige_comboboxen_times(True)
        Else 'NEUE simfonia 
            currentsimfonia = -1
            zeige_neu_paidia_times_parametroi()
            zeige_comboboxen_times(False)
        End If
        'SimfPaidiaPnl.Show()
        'SimfPososPnl.Show()
        'TimesCBoxenPnl.Show()
        zeig_xrewseis_radiobuttons(0, 2, False)
        show_hide_pnls(5)
    End Sub

    Private Sub zeige_paidia_times_parametroi()


        TextBox10.Text = Me.DbhotelDataSet.simfonies(0).prosauxisisnono
        TextBox13.Text = Me.DbhotelDataSet.simfonies(0).ekptositrito

        TextBox14.Text = Me.DbhotelDataSet.simfonies(0).paidi1klinofree
        TextBox15.Text = Me.DbhotelDataSet.simfonies(0).paidi1klinoews
        TextBox16.Text = Me.DbhotelDataSet.simfonies(0).paidi1klinoekpt

        TextBox19.Text = Me.DbhotelDataSet.simfonies(0).paidi2klinofree
        TextBox18.Text = Me.DbhotelDataSet.simfonies(0).paidi2klinoews
        TextBox17.Text = Me.DbhotelDataSet.simfonies(0).paidi2klinoekpt

        TextBox22.Text = Me.DbhotelDataSet.simfonies(0).paidia1free
        TextBox21.Text = Me.DbhotelDataSet.simfonies(0).paidia1ews
        TextBox20.Text = Me.DbhotelDataSet.simfonies(0).paidia1ekpt

        TextBox25.Text = Me.DbhotelDataSet.simfonies(0).paidia2free
        TextBox24.Text = Me.DbhotelDataSet.simfonies(0).paidia2ews
        TextBox23.Text = Me.DbhotelDataSet.simfonies(0).paidia2ekpt


    End Sub
    Private Sub zeige_comboboxen_times(ByVal eintrag As Boolean) ' initialisieren ta combo boxen me tis monades metrisis
        Dim PrwinCbx, GeumCbx, DeipnCbx As New ComboBox

        If eintrag And Me.DbhotelDataSet.simfonies.Count <> 0 Then
            PrwinTbx.Text = Me.DbhotelDataSet.simfonies(0).prwino.ToString("F")
            GeumTbx.Text = Me.DbhotelDataSet.simfonies(0).geuma.ToString("F")
            DeipnTbx.Text = Me.DbhotelDataSet.simfonies(0).dipno.ToString("F")
        End If

        PrwinCbx.Name = "Prwino"
        GeumCbx.Name = "Geuma"
        DeipnCbx.Name = "Deipno"

        PrwinCbx.Width = 50
        GeumCbx.Width = 50
        DeipnCbx.Width = 50

        PrwinCbx.ForeColor = Color.Black
        DeipnCbx.ForeColor = Color.Black
        GeumCbx.ForeColor = Color.Black

        PrwinCbx.Items.Add("€")
        PrwinCbx.Items.Add("%")
        PrwinCbx.Items.Add("OXI")
        If eintrag Then
            If Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).prwinomonada.Equals("€") Then
                PrwinCbx.SelectedIndex = 0
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).prwinomonada.Equals("%") Then
                PrwinCbx.SelectedIndex = 1
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 Then
                PrwinCbx.SelectedIndex = 2
            End If
        Else
            PrwinCbx.SelectedIndex = 0
        End If


        GeumCbx.Items.Add("€")
        GeumCbx.Items.Add("%")
        GeumCbx.Items.Add("OXI")

        If eintrag Then
            If Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).geumamonada.Equals("€") Then
                GeumCbx.SelectedIndex = 0
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).geumamonada.Equals("%") Then
                GeumCbx.SelectedIndex = 1
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 Then
                GeumCbx.SelectedIndex = 2
            End If
        Else
            GeumCbx.SelectedIndex = 0
        End If


        DeipnCbx.Items.Add("€")
        DeipnCbx.Items.Add("%")
        DeipnCbx.Items.Add("OXI")
        If eintrag Then
            If Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).dipnomonada.Equals("€") Then
                DeipnCbx.SelectedIndex = 0
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 AndAlso Me.DbhotelDataSet.simfonies(0).dipnomonada.Equals("%") Then
                DeipnCbx.SelectedIndex = 1
            ElseIf Me.DbhotelDataSet.simfonies.Count <> 0 Then
                DeipnCbx.SelectedIndex = 2
            End If
        Else
            DeipnCbx.SelectedIndex = 0
        End If


        TimesCBoxenPnl.Controls.Add(PrwinCbx)
        TimesCBoxenPnl.Controls.Add(GeumCbx)
        TimesCBoxenPnl.Controls.Add(DeipnCbx)

        PrwinCbx.Location = New Point(1, PrwinTbx.Location.Y)
        GeumCbx.Location = New Point(1, GeumTbx.Location.Y)
        DeipnCbx.Location = New Point(1, DeipnTbx.Location.Y)
        AddHandler PrwinCbx.SelectedIndexChanged, AddressOf cboxen_selected_index
        AddHandler GeumCbx.SelectedIndexChanged, AddressOf cboxen_selected_index
        AddHandler DeipnCbx.SelectedIndexChanged, AddressOf cboxen_selected_index

    End Sub
    Private Sub zeig_xrewseis_radiobuttons(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean)

        Dim i As Int16
        SimfTipoiXrewsPnl.Show()
        SimfTipoiXrewsPnl.Controls.Clear()
        ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...
        For i = 0 To Me.DbhotelDataSet.xrewseis.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 50
            AArdbuttn.ForeColor = Color.Blue
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleRight
            AArdbuttn.Cursor = Cursors.Hand
            SimfTipoiXrewsPnl.Controls.Add(AArdbuttn)
            AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.xrewseis(i).kwd.ToString
            If i = Me.DbhotelDataSet.simfonies.Count - 1 AndAlso remalen Then
                AArdbuttn.Checked = True
            End If
            AArdbuttn.Text = Me.DbhotelDataSet.xrewseis(i).xrewsi
            AArdbuttn.Location = New Point(x + (i + 1) * 80, y)
            AddHandler AArdbuttn.Click, AddressOf Xrewseis_RB_Click

        Next

    End Sub
    Private Sub cboxen_selected_index(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim y As Decimal


        If sender.name.Equals("Prwino") Then
            If sender.selectedindex = 2 Then
                y = 0
                PrwinTbx.Text = y.ToString("F")
            End If
        ElseIf sender.name.Equals("Geuma") Then
            If sender.selectedindex = 2 Then
                y = 0
                GeumTbx.Text = y.ToString("F")
            End If
        ElseIf sender.name.Equals("Deipno") Then
            If sender.selectedindex = 2 Then
                y = 0
                DeipnTbx.Text = y.ToString("F")
            End If
        End If
    End Sub
    Private Sub zeige_neu_paidia_times_parametroi()
        Dim y As Decimal = 0
        TextBox10.Text = 0
        TextBox13.Text = 0

        TextBox14.Text = 0
        TextBox15.Text = 0
        TextBox16.Text = 0

        TextBox19.Text = 0
        TextBox18.Text = 0
        TextBox17.Text = 0

        TextBox22.Text = 0
        TextBox21.Text = 0
        TextBox20.Text = 0

        TextBox25.Text = 0
        TextBox24.Text = 0
        TextBox23.Text = 0

        PrwinTbx.Text = y.ToString("F")
        GeumTbx.Text = y.ToString("F")
        DeipnTbx.Text = y.ToString("F")
        TimiAtomoTbx.Text = y.ToString("F")

    End Sub
    Private Sub Xrewseis_RB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If sender.checked = True Then
            currentxrewsi = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
            Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)
            show_hide_pnls(7)
            make_times_pnl()

            TimiAtomoTbx.Focus()

        End If

    End Sub

    Private Sub make_times_pnl() 'kentriko 
        Dim i, count, anzahlklines As Int16 'poses fores PNL
        Dim btnlocx As Integer ' apothikeuw to location tou teleutaiou Tmk panel gia na mporw meta tin FOR-schleife na kanw plazieren sto swsto topo to  AddTimesBtn
        Dim y As Decimal

        SimfPnlPnl.Controls.Clear()
        'anzahl = Me.TimesTableAdapter.AnzahlTimes(currentsimfonia, currentxrewsi)
        Me.TimesTableAdapter.FillOrderByKlines(Me.DbhotelDataSet.times, currentsimfonia, currentxrewsi)

        If Me.DbhotelDataSet.times.Count <> 0 Then
            anzahlklines = Me.DbhotelDataSet.times(Me.DbhotelDataSet.times.Count - 1).klines ' maximum se klines bei currentsimfonia-currentxrewsi
            y = Me.DbhotelDataSet.times(0).timiatomo
            'currenttimiatomo = y ' apothikeusi tis arxikis timis ana atomo gia metepeita elegxo->PROSOXI ICH GEHE DAVON AUS DASS OLES OI  EINZELNE TIMES EXOYN TO IDIO TIMIANAATOMO!!!!
            TimiAtomoTbx.Text = y.ToString("F")
        Else
            y = 0
            TimiAtomoTbx.Text = y.ToString("F")
            anzahlklines = -1
        End If

        ReDim times(Me.DbhotelDataSet.times.Count - 1)

        For count = 0 To Me.DbhotelDataSet.times.Count - 1

            Dim Tmk As New Panel
            Dim klCbx, kindCbx As New ComboBox
            Dim AtmTbx, SynolTbx As New TextBox
            Dim AtmLbl, SynolLbl, AnalLbl, YpnosLbl, YpnosValue, PrwinLbl, PrwinValue, GeumLbl, GeumValue, DeipnLbl, DeipnValue As New Label

            times(count).kwd = Me.DbhotelDataSet.times(count).kwd
            times(count).status = 1 ' etoimo gia apoyhikeysi->UPDATE
            times(count).timiatomo = Me.DbhotelDataSet.times(count).timiatomo 'oder tha mporouse na itan i CURRENTTIMIATOMO->PROSOXI ICH GEHE DAVON AUS DASS OLES OI  EINZELNE TIMES EXOYN TO IDIO TIMIANAATOMO!!!!


            klCbx.Width = 105
            kindCbx.Width = 105
            klCbx.ForeColor = Color.Maroon
            kindCbx.ForeColor = Color.Maroon
            AtmTbx.ForeColor = Color.Maroon
            SynolTbx.ForeColor = Color.Maroon

            Tmk.Name = "Tmk" + Me.DbhotelDataSet.times(count).kwd.ToString
            klCbx.Name = "kln" + Me.DbhotelDataSet.times(count).kwd.ToString
            kindCbx.Name = "knd" + Me.DbhotelDataSet.times(count).kwd.ToString
            AtmTbx.Name = "Atm" + Me.DbhotelDataSet.times(count).kwd.ToString
            SynolTbx.Name = "Syn" + Me.DbhotelDataSet.times(count).kwd.ToString
            YpnosValue.Name = "Ypn" + Me.DbhotelDataSet.times(count).kwd.ToString
            PrwinValue.Name = "Prw" + Me.DbhotelDataSet.times(count).kwd.ToString
            GeumValue.Name = "Geu" + Me.DbhotelDataSet.times(count).kwd.ToString
            DeipnValue.Name = "Dpn" + Me.DbhotelDataSet.times(count).kwd.ToString


            AtmTbx.MaxLength = 1
            SynolTbx.MaxLength = 7
            SynolTbx.Width = 60

            If count Mod 2 <> 0 Then
                Tmk.BackColor = Color.DarkKhaki
            Else
                Tmk.BackColor = Color.Khaki
            End If


            For i = 0 To anzahlklines + 1
                klCbx.Items.Add(Me.DbhotelDataSet.klines(i).perigrafi)
            Next
            klCbx.SelectedIndex = Me.DbhotelDataSet.times(count).klines - 1
            times(count).klines = Me.DbhotelDataSet.times(count).klines  ' simpiptei ME db kwdiko!!!(gia klines mono)

            kindCbx.Items.Add("Κανένα Παιδί")
            For i = 0 To Me.DbhotelDataSet.times(count).paidi + 1

                If i <> 0 Then
                    kindCbx.Items.Add((i + 1).ToString + " Παιδιά")
                Else
                    kindCbx.Items.Add((i + 1).ToString + " Παιδί")
                End If
            Next
            kindCbx.SelectedIndex = Me.DbhotelDataSet.times(count).paidi
            times(count).paidia = Me.DbhotelDataSet.times(count).paidi

            klCbx.Location = New Point(5, 5)
            kindCbx.Location = New Point(klCbx.Width + 5, 5)
            Tmk.Width = klCbx.Width + kindCbx.Width + 10

            Tmk.Controls.Add(klCbx)
            Tmk.Controls.Add(kindCbx)

            Tmk.Location = New Point(1 + count * Tmk.Width, 1)
            SimfPnlPnl.Controls.Add(Tmk)

            AtmLbl.Text = "Άτομα συνολικά:"
            AtmLbl.Width = 120
            AtmLbl.TextAlign = ContentAlignment.MiddleRight
            AtmTbx.Text = Me.DbhotelDataSet.times(count).atoma
            AtmTbx.Width = 30
            AtmTbx.TextAlign = HorizontalAlignment.Center

            AtmLbl.Location = New Point(30, 12 + klCbx.Height)
            AtmTbx.Location = New Point(30 + AtmLbl.Width, 10 + klCbx.Height)

            Tmk.Controls.Add(AtmLbl)
            Tmk.Controls.Add(AtmTbx)
            times(count).atoma = Me.DbhotelDataSet.times(count).atoma

            SynolLbl.Text = "Συνολική Χρέωση:"
            SynolLbl.TextAlign = ContentAlignment.MiddleRight
            SynolLbl.Width = 120

            y = Me.DbhotelDataSet.times(count).synolo
            SynolTbx.Text = y.ToString("F")
            SynolTbx.TextAlign = HorizontalAlignment.Right
            SynolLbl.Location = New Point(30, 14 + klCbx.Height + AtmLbl.Height)
            SynolTbx.Location = New Point(30 + AtmLbl.Width, 14 + klCbx.Height + AtmLbl.Height)


            Tmk.Controls.Add(SynolLbl)
            Tmk.Controls.Add(SynolTbx)
            times(count).xrwesi = y
            AnalLbl.Width = 70
            AnalLbl.Text = "ΑΝΑΛΥΣΗ:"
            AnalLbl.TextAlign = ContentAlignment.MiddleRight
            AnalLbl.ForeColor = Color.Blue
            AnalLbl.Location = New Point(20, 40 + klCbx.Height + AtmLbl.Height)
            Tmk.Controls.Add(AnalLbl)


            YpnosLbl.Width = 70
            YpnosLbl.Text = "Ύπνος:"
            YpnosLbl.TextAlign = ContentAlignment.MiddleRight
            YpnosLbl.ForeColor = Color.Black
            YpnosLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height)
            Tmk.Controls.Add(YpnosLbl)

            YpnosValue.Width = 70
            y = Me.DbhotelDataSet.times(count).ipnos
            times(count).ypnos = y
            YpnosValue.Text = y.ToString("F")
            YpnosValue.TextAlign = ContentAlignment.MiddleRight
            YpnosValue.ForeColor = Color.Black
            YpnosValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(YpnosValue)


            PrwinLbl.Width = 70
            PrwinLbl.Text = "Πρωϊνό:"
            PrwinLbl.TextAlign = ContentAlignment.MiddleRight
            PrwinLbl.ForeColor = Color.Black
            PrwinLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(PrwinLbl)

            PrwinValue.Width = 70
            y = Me.DbhotelDataSet.times(count).prwino
            times(count).prwino = y
            PrwinValue.Text = y.ToString("F")
            PrwinValue.TextAlign = ContentAlignment.MiddleRight
            PrwinValue.ForeColor = Color.Black
            PrwinValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(PrwinValue)


            GeumLbl.Width = 70
            GeumLbl.Text = "Γεύμα:"
            GeumLbl.TextAlign = ContentAlignment.MiddleRight
            GeumLbl.ForeColor = Color.Black
            GeumLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height)
            Tmk.Controls.Add(GeumLbl)

            GeumValue.Width = 70
            y = Me.DbhotelDataSet.times(count).geuma
            times(count).geuma = y
            GeumValue.Text = y.ToString("F")
            GeumValue.TextAlign = ContentAlignment.MiddleRight
            GeumValue.ForeColor = Color.Black
            GeumValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height)
            Tmk.Controls.Add(GeumValue)


            DeipnLbl.Width = 70
            DeipnLbl.Text = "Δείπνο:"
            DeipnLbl.TextAlign = ContentAlignment.MiddleRight
            DeipnLbl.ForeColor = Color.Black
            DeipnLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height + GeumLbl.Height)
            Tmk.Controls.Add(DeipnLbl)

            DeipnValue.Width = 70
            y = Me.DbhotelDataSet.times(count).deipno
            times(count).deipno = y
            DeipnValue.Text = y.ToString("F")
            DeipnValue.TextAlign = ContentAlignment.MiddleRight
            DeipnValue.ForeColor = Color.Black
            DeipnValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height + GeumLbl.Height)
            Tmk.Controls.Add(DeipnValue)

            Tmk.BorderStyle = BorderStyle.FixedSingle
            Tmk.Height = SimfPnlPnl.Height - 20



            Dim DeleteBtn As New Button

            DeleteBtn.BackColor = Color.Azure
            DeleteBtn.ForeColor = Color.Black
            DeleteBtn.Text = "Διαγραφή"
            DeleteBtn.Name = "Del" + Me.DbhotelDataSet.times(count).kwd.ToString
            DeleteBtn.Size = New Point(140, 30)
            DeleteBtn.Cursor = Cursors.Hand
            DeleteBtn.Location = New Point(Tmk.Width / 2 - 60, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height + GeumLbl.Height + DeipnValue.Height)
            Tmk.Controls.Add(DeleteBtn)
            AddHandler SynolTbx.Enter, AddressOf berechne_times
            AddHandler SynolTbx.Click, AddressOf selectall
            AddHandler SynolTbx.KeyPress, AddressOf komma_einschalten

            AddHandler AtmTbx.Leave, AddressOf atomatbx_leave
            AddHandler DeleteBtn.Click, AddressOf delete_timi   'MsgBox(allotm(29, 3))
            AddHandler SynolTbx.Leave, AddressOf berechne_analysis ' bazei apla 2 dekadika sto telos meta tin ipodiastoli
            AddHandler klCbx.SelectedIndexChanged, AddressOf navigiere_user
            AddHandler kindCbx.SelectedIndexChanged, AddressOf navigiere_user
        Next

        For count = count To count
            Dim Tmk As New Panel
            Dim klCbx, kindCbx As New ComboBox
            Dim AtmTbx, SynolTbx As New TextBox
            Dim AtmLbl, SynolLbl, AnalLbl, YpnosLbl, YpnosValue, PrwinLbl, PrwinValue, GeumLbl, GeumValue, DeipnLbl, DeipnValue As New Label

            ReDim Preserve times(count)

            times(count).kwd = 0
            times(count).status = -1 'Insert->2
            times(count).timiatomo = -1

            klCbx.Width = 105
            kindCbx.Width = 105
            klCbx.ForeColor = Color.Maroon
            kindCbx.ForeColor = Color.Maroon
            AtmTbx.ForeColor = Color.Maroon
            SynolTbx.ForeColor = Color.Maroon

            Tmk.Name = "Tmk0"
            klCbx.Name = "kln0"
            kindCbx.Name = "knd0"
            AtmTbx.Name = "Atm0"
            SynolTbx.Name = "Syn0"
            YpnosValue.Name = "Ypn0"
            PrwinValue.Name = "Prw0"
            GeumValue.Name = "Geu0"
            DeipnValue.Name = "Dpn0"

            AtmTbx.MaxLength = 1
            SynolTbx.MaxLength = 7
            SynolTbx.Width = 60

            If count Mod 2 <> 0 Then
                Tmk.BackColor = Color.DarkKhaki
            Else
                Tmk.BackColor = Color.Khaki
            End If


            For i = 0 To maxklines
                klCbx.Items.Add(Me.DbhotelDataSet.klines(i).perigrafi)
            Next
            'klCbx.SelectedIndex = Me.DbhotelDataSet.times(count).klines - 1

            kindCbx.Items.Add("Κανένα Παιδί")
            For i = 0 To 2
                If i <> 0 Then
                    kindCbx.Items.Add((i + 1).ToString + " Παιδιά")
                Else
                    kindCbx.Items.Add((i + 1).ToString + " Παιδί")
                End If
            Next
            'kindCbx.SelectedIndex = Me.DbhotelDataSet.times(count).paidi
            klCbx.Location = New Point(5, 5)
            kindCbx.Location = New Point(klCbx.Width + 5, 5)

            Tmk.Width = klCbx.Width + kindCbx.Width + 10

            Tmk.Controls.Add(klCbx)
            Tmk.Controls.Add(kindCbx)

            Tmk.Location = New Point(1 + count * Tmk.Width, 1)
            SimfPnlPnl.Controls.Add(Tmk)

            AtmLbl.Text = "Άτομα συνολικά:"
            AtmLbl.Width = 120
            AtmLbl.TextAlign = ContentAlignment.MiddleRight
            AtmTbx.Text = 0
            AtmTbx.Width = 30
            AtmTbx.TextAlign = HorizontalAlignment.Center

            AtmLbl.Location = New Point(30, 12 + klCbx.Height)
            AtmTbx.Location = New Point(30 + AtmLbl.Width, 10 + klCbx.Height)

            Tmk.Controls.Add(AtmLbl)
            Tmk.Controls.Add(AtmTbx)

            SynolLbl.Text = "Συνολική Χρέωση:"
            SynolLbl.TextAlign = ContentAlignment.MiddleRight
            SynolLbl.Width = 120

            y = 0
            SynolTbx.Text = y.ToString("F")
            SynolTbx.TextAlign = HorizontalAlignment.Right
            SynolLbl.Location = New Point(30, 14 + klCbx.Height + AtmLbl.Height)
            SynolTbx.Location = New Point(30 + AtmLbl.Width, 14 + klCbx.Height + AtmLbl.Height)

            Tmk.Controls.Add(SynolLbl)
            Tmk.Controls.Add(SynolTbx)

            AnalLbl.Width = 70
            AnalLbl.Text = "ΑΝΑΛΥΣΗ:"
            AnalLbl.TextAlign = ContentAlignment.MiddleRight
            AnalLbl.ForeColor = Color.Blue
            AnalLbl.Location = New Point(20, 40 + klCbx.Height + AtmLbl.Height)
            Tmk.Controls.Add(AnalLbl)


            YpnosLbl.Width = 70
            YpnosLbl.Text = "Ύπνος:"
            YpnosLbl.TextAlign = ContentAlignment.MiddleRight
            YpnosLbl.ForeColor = Color.Black
            YpnosLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height)
            Tmk.Controls.Add(YpnosLbl)

            YpnosValue.Width = 70
            y = 0
            YpnosValue.Text = y.ToString("F")
            YpnosValue.TextAlign = ContentAlignment.MiddleRight
            YpnosValue.ForeColor = Color.Black
            YpnosValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(YpnosValue)


            PrwinLbl.Width = 70
            PrwinLbl.Text = "Πρωϊνό:"
            PrwinLbl.TextAlign = ContentAlignment.MiddleRight
            PrwinLbl.ForeColor = Color.Black
            PrwinLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(PrwinLbl)

            PrwinValue.Width = 70
            y = 0
            times(count).prwino = y
            PrwinValue.Text = y.ToString("F")
            PrwinValue.TextAlign = ContentAlignment.MiddleRight
            PrwinValue.ForeColor = Color.Black
            PrwinValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height)
            Tmk.Controls.Add(PrwinValue)


            GeumLbl.Width = 70
            GeumLbl.Text = "Γεύμα:"
            GeumLbl.TextAlign = ContentAlignment.MiddleRight
            GeumLbl.ForeColor = Color.Black
            GeumLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height)
            Tmk.Controls.Add(GeumLbl)

            GeumValue.Width = 70
            y = 0
            times(count).geuma = y
            GeumValue.Text = y.ToString("F")
            GeumValue.TextAlign = ContentAlignment.MiddleRight
            GeumValue.ForeColor = Color.Black
            GeumValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height)
            Tmk.Controls.Add(GeumValue)


            DeipnLbl.Width = 70
            DeipnLbl.Text = "Δείπνο:"
            DeipnLbl.TextAlign = ContentAlignment.MiddleRight
            DeipnLbl.ForeColor = Color.Black
            DeipnLbl.Location = New Point(2 + AnalLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height + GeumLbl.Height)
            Tmk.Controls.Add(DeipnLbl)

            DeipnValue.Width = 70
            y = 0
            times(count).deipno = y
            DeipnValue.Text = y.ToString("F")
            DeipnValue.TextAlign = ContentAlignment.MiddleRight
            DeipnValue.ForeColor = Color.Black
            DeipnValue.Location = New Point(2 + AnalLbl.Width + YpnosLbl.Width, 25 + klCbx.Height + AtmLbl.Height + AnalLbl.Height + YpnosLbl.Height + PrwinLbl.Height + GeumLbl.Height)
            Tmk.Controls.Add(DeipnValue)
            Tmk.BorderStyle = BorderStyle.FixedSingle
            Tmk.Height = SimfPnlPnl.Height - 20

            btnlocx = 1 + count * Tmk.Width + Tmk.Width + 10

            AddHandler AtmTbx.Leave, AddressOf atomatbx_leave
            AddHandler SynolTbx.Enter, AddressOf berechne_times
            AddHandler SynolTbx.Click, AddressOf selectall
            AddHandler SynolTbx.KeyPress, AddressOf komma_einschalten
            AddHandler SynolTbx.Leave, AddressOf berechne_analysis
            AddHandler klCbx.SelectedIndexChanged, AddressOf setze_atoma_von_timi_cboxen
            AddHandler kindCbx.SelectedIndexChanged, AddressOf setze_atoma_von_timi_cboxen


        Next

        SimfPnlPnl.Controls.Add(AddTimesBtn)
        SimfPnlPnl.Controls.Add(InfSinfLbl)
        AddTimesBtn.Location = New Point(btnlocx, (SimfPnlPnl.Height - 20) / 2 - 60)
        InfSinfLbl.Location = New Point(btnlocx + AddTimesBtn.Width + 10, (SimfPnlPnl.Height - 20) / 2 - 60)

        'AddHandler AddTimesBtn.Click, AddressOf speicher_times
    End Sub
    'ean EINAI PALIO TOTE EAN ALAZE O USER MONO KATI STA COMBO BOXEN(KLINES i PAIDIA) KAI PATISEI APOTHIKEYSI XWRIS NA KANEI ENTER STIN
    ' SYNOLIKH XREWSH TEXTBOX TOTE H APOTHIKEUSI DEN 8A GINOTAN GIATI TO DSTR TIMES() DEN UA EIXE ENHMEROTHEI 
    'GIAYTO KANW FOCUS() STON TEXT BOX WSTE NA ENERGOPOITHEI berechne_times KAI berechne_analysis wste na mporei na geini i apothikeysi
    'xwris o user manuel na eiselthei sto synolo text box apo monos toy!!!
    Private Sub navigiere_user(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim panel(), find() As Object
        Dim tmkpnl As New Panel
        Dim timikwd As Integer
        timikwd = sender.name.Substring(3, sender.NAME.ToString.Length - 3)

        panel = SimfPnlPnl.Controls.Find("Tmk" + timikwd.ToString, False)
        tmkpnl = panel(0)
        find = tmkpnl.Controls.Find("Syn" + timikwd.ToString, False)
        find(0).focus()

    End Sub
    Private Sub berechne_times(ByVal sender As System.Object, ByVal e As System.EventArgs) 'otan SynolTbx.Enter!!!!!!!!!!!!!!!!!!!!!1
        Dim y As Decimal
        Dim panel(), find() As Object
        Dim tmkpnl As New Panel
        Dim klino, kinds, atom, index As Int16
        Dim timikwd As Integer

        timikwd = sender.name.Substring(3, sender.NAME.ToString.Length - 3)

        panel = SimfPnlPnl.Controls.Find("Tmk" + timikwd.ToString, False)
        tmkpnl = panel(0)
        find = tmkpnl.Controls.Find("kln" + timikwd.ToString, False)
        klino = (find(0).selectedindex) + 1
        find = tmkpnl.Controls.Find("knd" + timikwd.ToString, False)
        kinds = (find(0).selectedindex)
        find = tmkpnl.Controls.Find("Atm" + timikwd.ToString, False)
        atom = find(0).text

        If Not klino = 0 And Not kinds = -1 Then ' ean exei ginei epilogi klinvn kai paidiwn apo combo boxen
            If TimiAtomoTbx.Text <> 0 Then
                y = ausrechne_timi_me_ekptosi(klino, kinds, atom, TimiAtomoTbx.Text) 'ypologismos tis timis synolou apo tis ekptwseis!!!!
                sender.text = y.ToString("F")
            Else
                y = sender.text 'ypologismos tis timis synolou apo tis ekptwseis!!!!
                sender.text = y.ToString("F")
            End If

            index = get_index_times_by_kwd(timikwd.ToString) 'enimerwsi tou times() DSTR. (ena meros mono->to upoloipo (geuma ktl.) enimervnetai apo berechne_analysis
            If index <> -1 Then
                times(index).klines = klino
                times(index).paidia = kinds
                times(index).atoma = atom
                times(index).xrwesi = y
            End If

        Else

            MsgBox(" Επιλέξτε πρώτα κλίνες και αριθμό παιδιών !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If


    End Sub

    Private Sub setze_atoma_von_timi_cboxen(ByVal sender As System.Object, ByVal e As System.EventArgs) ' apo tis epiloges twn Cboxen (klines,paidia) upologizw ta atoma
        Dim panel(), find() As Object
        Dim tmkpnl As New Panel
        Dim klino, kinds, atom As Int16

        panel = SimfPnlPnl.Controls.Find("Tmk0", False)
        tmkpnl = panel(0)
        find = tmkpnl.Controls.Find("kln0", False)
        klino = (find(0).selectedindex) + 1

        find = tmkpnl.Controls.Find("knd0", False)
        kinds = (find(0).selectedindex)
        find = tmkpnl.Controls.Find("Atm0", False)
        atom = find(0).text

        If kinds = -1 Then
            find(0).text = klino
        Else
            find(0).text = klino + kinds
        End If

    End Sub
    Private Sub berechne_analysis(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim panel(), find() As Object
        Dim tmkpnl As New Panel
        Dim atom, klino, kinds As Int16
        Dim y As Decimal = 0
        Dim istypnos, istprwino, istgeuma, istdeipno As Boolean
        Dim prwinovalue, geumavalue, deipnovalue, synolo, ypnos, prwino, geuma, deipno As Decimal

        Dim timikwd As Integer

        timikwd = sender.name.Substring(3, sender.NAME.ToString.Length - 3)

        Try
            synolo = Math.Abs(CType(sender.text, Decimal))
        Catch ex As InvalidCastException
            sender.text = y.ToString("F")
            Exit Sub
        End Try


        panel = SimfPnlPnl.Controls.Find("Tmk" + timikwd.ToString, False)
        tmkpnl = panel(0)

        find = tmkpnl.Controls.Find("kln" + timikwd.ToString, False)
        klino = (find(0).selectedindex) + 1
        find = tmkpnl.Controls.Find("knd" + timikwd.ToString, False)
        kinds = (find(0).selectedindex)
        If Not klino = 0 And Not kinds = -1 Then 'ean exei ginei epilogi sta cboxen

            find = tmkpnl.Controls.Find("Atm" + timikwd.ToString, False)
            atom = find(0).text

            prwinovalue = PrwinTbx.Text
            geumavalue = GeumTbx.Text
            deipnovalue = DeipnTbx.Text
            'Blepw stin DB ti Analysi exei isigkekrimeni xrewsi (px. RR exei monno Ypno)
            istypnos = Me.XrewseisTableAdapter.YpnosByKwd(currentxrewsi)
            istprwino = Me.XrewseisTableAdapter.PrwinoByKwd(currentxrewsi)
            istgeuma = Me.XrewseisTableAdapter.GeumaByKwd(currentxrewsi)
            istdeipno = Me.XrewseisTableAdapter.DeipnoByKwd(currentxrewsi)

            If istprwino AndAlso prwinovalue <> 0 Then
                find = TimesCBoxenPnl.Controls.Find("Prwino", False)
                If find(0).selectedindex = 0 Then
                    prwino = ausrechne_timi_me_ekptosi(klino, kinds, atom, prwinovalue.ToString)
                    'prwino = atom * prwinovalue
                ElseIf find(0).selectedindex = 1 Then
                    prwino = ausrechne_timi_me_ekptosi(klino, kinds, atom, (TimiAtomoTbx.Text * prwinovalue / 100).ToString)
                Else
                    prwino = 0
                End If
            End If
            If istgeuma AndAlso geumavalue <> 0 Then
                find = TimesCBoxenPnl.Controls.Find("Geuma", False)
                If find(0).selectedindex = 0 Then
                    geuma = ausrechne_timi_me_ekptosi(klino, kinds, atom, geumavalue.ToString)
                ElseIf find(0).selectedindex = 1 Then
                    geuma = ausrechne_timi_me_ekptosi(klino, kinds, atom, (TimiAtomoTbx.Text * geumavalue / 100).ToString)
                Else
                    geumavalue = 0
                End If
            End If
            If istdeipno AndAlso deipnovalue <> 0 Then
                find = TimesCBoxenPnl.Controls.Find("Deipno", False)
                If find(0).selectedindex = 0 Then
                    deipno = ausrechne_timi_me_ekptosi(klino, kinds, atom, deipnovalue.ToString)
                ElseIf find(0).selectedindex = 1 Then
                    deipno = ausrechne_timi_me_ekptosi(klino, kinds, atom, (TimiAtomoTbx.Text * deipnovalue / 100).ToString)
                Else
                    deipno = 0
                End If
            End If

            y = synolo - prwino - geuma - deipno ' einai o Ypnos Thetiko???)
            ypnos = y.ToString("F")
            If ypnos < 0 Then
                find = tmkpnl.Controls.Find("Ypn" + timikwd.ToString, False)
                find(0).text = ypnos
                find(0).backcolor = Color.Red
                find = tmkpnl.Controls.Find("Prw" + timikwd.ToString, False)
                find(0).text = prwino
                find = tmkpnl.Controls.Find("Geu" + timikwd.ToString, False)
                find(0).text = geuma
                find = tmkpnl.Controls.Find("Dpn" + timikwd.ToString, False)
                find(0).text = deipno
                MsgBox("Προκύπτει αρνητική τιμή για Υπνο: Αλλάξτε την Τιμή ανά Ατομο !", MsgBoxStyle.Critical, "winfo\nikEl.")
                Dim index As Int16
                index = get_index_times_by_kwd(timikwd.ToString)
                If index <> -1 Then
                    times(index).status = 3 'FEHLERHAFT an einai gia update (ean einai neo den pernei status=2 pou gia na einai etoimo gia INSERT  ->paramenei status=-1 gia ta nea
                End If
                Exit Sub
            Else

                find = tmkpnl.Controls.Find("Ypn" + timikwd.ToString, False)
                find(0).text = ypnos.ToString("F")
                find = tmkpnl.Controls.Find("Prw" + timikwd.ToString, False)
                find(0).text = prwino.ToString("F")
                find = tmkpnl.Controls.Find("Geu" + timikwd.ToString, False)
                find(0).text = geuma.ToString("F")
                find = tmkpnl.Controls.Find("Dpn" + timikwd.ToString, False)
                find(0).text = deipno.ToString("F")

                Dim index As Int16
                index = get_index_times_by_kwd(timikwd.ToString)

                If index <> -1 Then ' kanw setzen ta upoloipa apo DSTR times()
                    times(index).xrwesi = sender.text
                    times(index).ypnos = ypnos
                    times(index).prwino = prwino
                    times(index).geuma = geuma
                    times(index).deipno = deipno
                    times(index).timiatomo = TimiAtomoTbx.Text
                    If times(index).kwd = 0 Then 'NEA
                        times(index).status = 2 'ETOIMO gia Insert
                    ElseIf times(index).kwd > 0 Then
                        times(index).status = 1 'Etoimo gia UPDATE
                    End If

                End If

            End If
            find = tmkpnl.Controls.Find("Ypn" + timikwd.ToString, False)
            find(0).text = ypnos
            find(0).backcolor = tmkpnl.BackColor

            sender.text = synolo.ToString("F")
        End If
    End Sub
    Private Function ausrechne_timi_me_ekptosi(ByVal klino As Int16, ByVal kinds As Int16, ByVal atom As Int16, ByVal timiatomo As String) As Decimal
        Dim y As Decimal
        If klino + kinds = atom Then
            If (klino = 1 And kinds = 0) Then 'AndAlso TextBox10.Text <> 0 
                y = timiatomo + timiatomo * TextBox10.Text / 100 ' PROSAYJISI se monoklino
                Return y.ToString("F")
            ElseIf (klino = 1 And kinds = 1) Then 'AndAlso TextBox16.Text <> 0 
                y = timiatomo + timiatomo * (1 - TextBox16.Text / 100) ' PAIDI SE MONOKLINO
                Return y.ToString("F")
            ElseIf (klino = 2 And kinds = 1) Then 'AndAlso TextBox17.Text <> 0
                y = klino * timiatomo + timiatomo * (1 - TextBox17.Text / 100) ' PAIDI SE DIKLINO kai panw 
                Return y.ToString("F")
            ElseIf (klino > 2 And kinds = 1) Then
                y = 2 * timiatomo + (klino - 2) * timiatomo * (1 - TextBox13.Text / 100) + timiatomo * (1 - TextBox17.Text / 100)
                Return y.ToString("F")
            ElseIf (kinds >= 2) Then ' 2paidia me ekptosi .............AndAlso (TextBox20.Text <> 0 Or TextBox23.Text <> 0)
                If klino < 3 Then 'mexri diklino
                    y = klino * timiatomo + timiatomo * (1 - TextBox20.Text / 100) + (kinds - 1) * timiatomo * (1 - TextBox23.Text / 100) ' PAIDI SE DIKLINO)
                    Return y.ToString("F")
                Else 'apo trilkino kai panw 
                    y = 2 * timiatomo + (klino - 2) * timiatomo * (1 - TextBox13.Text / 100) + timiatomo * (1 - TextBox20.Text / 100) + (kinds - 1) * timiatomo * (1 - TextBox23.Text / 100) ' PAIDI SE DIKLINO)
                    Return y.ToString("F")
                End If
            ElseIf kinds = 0 Then 'xwris paidia@!!!!
                If klino < 3 Then 'mexri diklino
                    y = klino * timiatomo
                    Return y.ToString("F")
                Else 'apo trilkino kai panw 
                    y = 2 * timiatomo + (klino - 2) * timiatomo * (1 - TextBox13.Text / 100)
                    Return y.ToString("F")
                End If
            End If
        Else
            y = atom * timiatomo
            Return y.ToString("F")
        End If

    End Function
    Private Sub AddTimesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTimesBtn.Click
        Dim i, maxAA As Int16

        'Dim response As MsgBoxResult
        Dim ok As Boolean = True
        Dim find() As Object
        Dim prwimonas, geummonas, dipnmonas As String
        Dim negativypnos As Boolean = False


        If Not final_kontrole_times() Then
            MsgBox(" Έγινε αλλαγή της Τιμής ανά Άτομο χωρίς να γίνει ενημέρωση των επιμέρους Τιμών. Δεν μπορεί να γίνει η Αποθήκευση !" & vbCrLf & vbCrLf & " ΠΡΟΣΟΧΗ: Εάν γίνει Αλλαγή της Τιμής ανά Άτομο, τότε το Πρόγραμμα υπολογίζει Αυτόματα την Συνολική Χρέωση κάνωντας κλίκ στο πεδίο τής Συνολικής Χρέωσης και έπειτα πατώντας TAB (βελάκια!) την Ανάλυσή της. Εάν ΔΕΝ επιθυμείτε Αυτόματο Υπολογισμό, αλλάξτε δια χειρός την προτεινώμενη τιμή στο κουτάκι της Συνολικής Χρέωσης !", MsgBoxStyle.Critical, "winfo\nikEl.")
            'If response = MsgBoxResult.Yes Then
            '    ok = True
            'Else
            '    ok = False
            'End If
        End If

        If ok Then

            find = TimesCBoxenPnl.Controls.Find("Prwino", False)
            If find(0).selectedindex = 0 Then
                prwimonas = "€"
            ElseIf find(0).selectedindex = 1 Then
                prwimonas = "%"
            ElseIf find(0).selectedindex = 2 Then
                prwimonas = "OXI"
            Else
                prwimonas = ""
            End If
            find = TimesCBoxenPnl.Controls.Find("Geuma", False)
            If find(0).selectedindex = 0 Then
                geummonas = "€"
            ElseIf find(0).selectedindex = 1 Then
                geummonas = "%"
            ElseIf find(0).selectedindex = 2 Then
                geummonas = "OXI"
            Else
                geummonas = ""
            End If
            find = TimesCBoxenPnl.Controls.Find("Deipno", False)
            If find(0).selectedindex = 0 Then
                dipnmonas = "€"
            ElseIf find(0).selectedindex = 1 Then
                dipnmonas = "%"
            ElseIf find(0).selectedindex = 2 Then
                dipnmonas = "OXI"
            Else
                dipnmonas = ""
            End If

            'simftipos, simfseason, currentsimfonia, currentxrewsi
            If currentsimfonia = -1 Then
                Try
                    maxAA = Me.SimfoniesTableAdapter.GetMaxaaBySimbTiposSeason(simbolaiokwd, simftipos, simfseason)
                    maxAA = maxAA + 1
                Catch ex As InvalidOperationException
                    maxAA = 1
                End Try
                'Apothikeysi neas Simfonias
                Me.SimfoniesTableAdapter.InsertSimfonia(simbolaiokwd, maxAA, simftipos, simfseason, PrwinTbx.Text, GeumTbx.Text, DeipnTbx.Text, TextBox10.Text, TextBox13.Text,
                TextBox14.Text, TextBox15.Text, TextBox16.Text, TextBox19.Text, TextBox18.Text, TextBox17.Text, TextBox20.Text, TextBox21.Text, TextBox22.Text,
                TextBox23.Text, TextBox24.Text, TextBox25.Text, dipnmonas, geummonas, prwimonas)

                'kai gleich rauskreigen tou DB Key poumolis pire apo thn eisagwgi
                'ACHTUNG:  kanonika to (simbolaiokwd, aa, simftipos, simfseason) sto Table Times Prepei na einai MONADIKO(diladi 1 h kanena)!!!!!!!!!!!!
                currentsimfonia = Me.SimfoniesTableAdapter.GetKwdBySimbolaioAaTiposSeason(simbolaiokwd, maxAA, simftipos, simfseason)
            Else
                Try
                    maxAA = Me.SimfoniesTableAdapter.GetAAByKwd(currentsimfonia)
                Catch ex As InvalidOperationException
                    maxAA = 1
                End Try

                Me.SimfoniesTableAdapter.UpdateSimfonia(simbolaiokwd, maxAA, simftipos, simfseason, PrwinTbx.Text, GeumTbx.Text, DeipnTbx.Text, TextBox10.Text, TextBox13.Text,
                TextBox14.Text, TextBox15.Text, TextBox16.Text, TextBox19.Text, TextBox18.Text, TextBox17.Text, TextBox20.Text, TextBox21.Text, TextBox22.Text,
                TextBox23.Text, TextBox24.Text, TextBox25.Text, dipnmonas, geummonas, prwimonas, currentsimfonia)
            End If



            For i = 0 To times.Length - 1

                If times(i).kwd > 0 And times(i).status = 1 Then 'Update
                    'abfrage ob schon ein ANDEREr eintrag (d.h. mit verschiedene DB kwd) mit aehnliche signatur (simfonia,xrewsi,klines,paidia,atoma)-> ean nai DEN ginetai to Update giati tha djmiourgisei DIPLOEGGRAFI
                    Dim anzahl As Int16
                    anzahl = Me.TimesTableAdapter.ExistAhnlichEintrag(currentsimfonia, currentxrewsi, times(i).klines, times(i).paidia, times(i).atoma, times(i).kwd)

                    If anzahl = 0 Then
                        Me.TimesTableAdapter.UpdateTimes(currentsimfonia, currentxrewsi, times(i).klines, times(i).paidia, times(i).timiatomo, times(i).ypnos, times(i).prwino, times(i).geuma, times(i).deipno, times(i).xrwesi, times(i).atoma, times(i).kwd)

                    Else
                        MsgBox(" Δεν ήταν δυνατή η Αλλαγή του τύπου Kλίνες: " + times(i).klines.ToString + ", Παιδιά: " + times(i).paidia.ToString + ", Ατομα: " + times(i).atoma.ToString + " γιατί θα δημιουργούσε διπλή Εγγραφή στα Δεδομένα !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    End If

                ElseIf times(i).kwd = 0 And times(i).status = 2 Then
                    'ACHTUNG:  kanonika to (simfonia, xrewsi,klines,paidia,atoma) sto Table Times Prepei na einai MONADIKO(diladi 1 h kanena)!!!

                    Dim anzahl As Int16
                    anzahl = Me.TimesTableAdapter.ExistEintrag(currentsimfonia, currentxrewsi, times(i).klines, times(i).paidia, times(i).atoma)
                    If anzahl = 0 Then
                        Me.TimesTableAdapter.InsertTimes(currentsimfonia, currentxrewsi, times(i).klines, times(i).paidia, times(i).timiatomo, times(i).ypnos, times(i).prwino, times(i).geuma, times(i).deipno, times(i).xrwesi, times(i).atoma)
                    Else
                        MsgBox(" Η Αποθήκευση του τύπου Kλίνες: " + times(i).klines.ToString + ", Παιδιά: " + times(i).paidia.ToString + ", Ατομα: " + times(i).atoma.ToString + " δεν κατάστη δυνατή γιατί θα δημιουργούσε διπλή Εγγραφή στα Δεδομένα !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    End If

                ElseIf times(i).status = 3 Then
                    negativypnos = False
                End If
            Next


            If negativypnos Then
                MsgBox(" Δεν ήταν δυνατή η Αποθήκεση των τιμών με αρνητική τιμή Ύπνου !", MsgBoxStyle.Critical, "winfo\nikEl.")
            End If
            make_times_pnl()

        End If

    End Sub

    Private Sub delete_timi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim panel(), find() As Object
        Dim tmkpnl As New Panel
        Dim atom As Int16
        Dim response As MsgBoxResult

        panel = SimfPnlPnl.Controls.Find("Tmk0", False)
        tmkpnl = panel(0)

        find = tmkpnl.Controls.Find("Atm0", False)
        atom = find(0).text

        If atom <> 0 Then
            response = MsgBox("Με την Διαγραφή αυτής της τιμής θα χρειαστεί να εισάγετε ξανά την νέα τιμή δεξιά, η οποία δεν έχει αποθηκευθεί ακόμα ! Διαγραφή;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                Me.TimesTableAdapter.DeleteTimi(sender.name.Substring(3, sender.NAME.ToString.Length - 3))
                make_times_pnl()
            End If
        Else
            Me.TimesTableAdapter.DeleteTimi(sender.name.Substring(3, sender.NAME.ToString.Length - 3))
            make_times_pnl()
        End If

    End Sub
    Private Sub delete_simfonia(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim j As Int16

        If currentsimfonia > 0 Then
            Me.TimesTableAdapter.FillKwdikousBySimfonia(Me.DbhotelDataSet.times, currentsimfonia)
            For j = 0 To Me.DbhotelDataSet.times.Count - 1
                Me.TimeskratisisTableAdapter.UpdateTimiByTimikwd(-1, Me.DbhotelDataSet.times(j).kwd)
            Next
            Me.TimesTableAdapter.DeleteBySimfonia(currentsimfonia)
            Me.SimfoniesTableAdapter.DeleteByKwd(currentsimfonia)
            SimfTipoiXrewsPnl.Controls.Clear()
            TimesCBoxenPnl.Controls.Clear()
            SimfAAPnl.Controls.Clear()
            If simfseason <> -1 And simftipos <> -1 Then
                Me.SimfoniesTableAdapter.FillByTiposSeason(Me.DbhotelDataSet.simfonies, simbolaiokwd, simftipos, simfseason)
                zeig_aa_simfonies_radiobuttons(0, 2, False)
            End If
            show_hide_pnls(1)
        End If


    End Sub

    Private Sub atomatbx_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim index As Integer
        index = sender.name.Substring(3, sender.NAME.ToString.Length - 3)

        Try
            If CType(sender.text, Decimal) = 0 Then
                If index = 0 Then
                    sender.text = 1
                    times(times.Length - 1).atoma = 1
                ElseIf index > 0 Then
                    sender.text = 1
                    times(get_index_times_by_kwd(index)).atoma = 1
                End If
            ElseIf sender.text > 0 Then
                If index = 0 Then
                    times(times.Length - 1).atoma = sender.text
                ElseIf index > 0 Then
                    times(get_index_times_by_kwd(index)).atoma = sender.text
                End If
            End If
        Catch ex As InvalidCastException
            If index = 0 Then
                sender.text = 1
                times(times.Length - 1).atoma = 1
            ElseIf index > 0 Then
                sender.text = 1
                times(get_index_times_by_kwd(index)).atoma = 1
            End If
        End Try
    End Sub

    Private Sub TextBoxen_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.Leave, TextBox13.Leave, TextBox14.Leave,
    TextBox15.Leave, TextBox16.Leave, TextBox17.Leave, TextBox18.Leave, TextBox19.Leave, TextBox20.Leave, TextBox21.Leave, TextBox22.Leave, TextBox23.Leave, TextBox24.Leave, TextBox25.Leave

        Try
            If CType(sender.text, Int16) < 0 Then
                sender.text = 0
            End If
        Catch ex As InvalidCastException
            sender.text = 0
        End Try


    End Sub
    Private Sub TextBoxen_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.Click, TextBox13.Click, TextBox14.Click,
   TextBox15.Click, TextBox16.Click, TextBox17.Click, TextBox18.Click, TextBox19.Click, TextBox20.Click, TextBox21.Click, TextBox22.Click, TextBox23.Click, TextBox24.Click, TextBox25.Click

        Me.selectall(sender, e)

    End Sub
    ' Private Sub TextBoxen_Textchanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged, TextBox13.TextChanged, TextBox14.TextChanged, _
    'TextBox15.TextChanged, TextBox16.TextChanged, TextBox17.TextChanged, TextBox18.TextChanged, TextBox19.TextChanged, TextBox20.TextChanged, TextBox21.TextChanged, TextBox22.TextChanged, TextBox23.TextChanged, TextBox24.TextChanged, TextBox25.TextChanged

    '     istsinfochanged = True ' gia na dw pote sin apothikeysi tha kanw Update tin Sinfonia
    ' End Sub
    Private Sub Prwino_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrwinTbx.Leave, GeumTbx.Leave, DeipnTbx.Leave, TimiAtomoTbx.Leave
        Dim y As Decimal = 0

        Try
            If CType(sender.text, Integer) < 0 Then
                sender.text = 0
            Else
                y = sender.text
                sender.text = y.ToString("F")
            End If
        Catch ex As InvalidCastException
            sender.text = y.ToString("F")
        End Try
        If sender.name.Equals("TimiAtomoTbx") Then
            SimfPnlPnl.Focus()
        End If
    End Sub
    'Private Sub panel_TextLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimesCBoxenPnl.Leave
    '    SimfTipoiXrewsPnl.Focus()
    'End Sub
    Private Sub Prwino_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrwinTbx.Click, GeumTbx.Click, DeipnTbx.Click, TimiAtomoTbx.Click
        selectall(sender, e)
    End Sub
    Private Sub Prwino_komma_einschalten(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles PrwinTbx.KeyPress, GeumTbx.KeyPress, DeipnTbx.KeyPress, TimiAtomoTbx.KeyPress
        Me.komma_einschalten(sender, e)
    End Sub

    Private Sub show_hide_pnls(ByVal index As Int16)
        Dim i As Int16

        For i = 0 To index - 1
            showhide(i).Show()
        Next

        For i = index To showhide.Length - 1
            showhide(i).Hide()

        Next


    End Sub
    Private Sub init_showhide()

        ReDim showhide(6)
        showhide(0) = SimfAAPnl
        showhide(1) = SimfPaidiaPnl
        showhide(2) = SimfPososPnl
        showhide(3) = TimesCBoxenPnl
        showhide(4) = SimfTipoiXrewsPnl
        showhide(5) = TimiAtomoPnl
        showhide(6) = SimfPnlPnl
    End Sub

    Private Function final_kontrole_times() As Boolean ' elegxos ean iparxei diaforpoiisi twn synolikwn xrewsewn/analysis apo timi ana atomo pou anagrafetai sto TimiAtomo>tbx
        Dim i As Int16


        For i = 0 To times.Length - 1

            If times(i).status = 1 Or times(i).status = 2 Then
                If CType(times(i).timiatomo, Single) <> CType(TimiAtomoTbx.Text, Single) Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Function get_index_times_by_kwd(ByVal kwdikos As Integer) As Int16
        Dim i As Int16

        For i = 0 To times.Length - 1
            If times(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1

    End Function
    Private Function get_kwd_tipos_by_simfonia(ByVal index As Int16, ByVal sender As System.Object) As Integer

        Try
            Return Me.TipoiTableAdapter.GetKwdByTipo(sender.Items(index).ToString)
        Catch ex As Exception
            Return -11
        End Try


    End Function
    Private Function get_kwd_season_by_simfonia(ByVal index As Int16, ByVal sender As System.Object) As Integer

        Try
            Return Me.SeasonsTableAdapter.GetKwdByName(sender.Items(index).ToString)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Function get_periodos_season(ByVal kwdikos As Integer) As String
        Dim i As Integer

        For i = 0 To Me.DbhotelDataSet.seasons.Count - 1
            If Me.DbhotelDataSet.seasons(i).kwd = kwdikos Then
                Return Me.DbhotelDataSet.seasons(i).periodos
            End If
        Next
        Return Nothing
    End Function




    'booking_b___________________-booking_b--------------------------------booking_b-------------------------------booking_b--------------------------------------
    Private Sub booking_b()
        ' H diadikasia (beim erstmal laden) einai os eksis: booking_b->PraktorBTbx_Enter->zeige_simbolia_radiobuttons-> zeige_allotment_radiobuttons(einai bei a tropos)->setze_globale_variablen(einai addhadler sta RadioButtons twn katigoriwn, bei erst laden to prwto einai gecheckd=>automtische AUSLOESUNG des Handlers)->
        '->  lade_von_db_zu_allotm(apouhkeuw ta Allotm ana mera von DB->lade_von_db_zu_book(laden von DB zu Datentruktur book(,) IDIA me allotm(,))->zeig_book_b_felder()


        Dim locx, locy As Int16
        praktoreiokwd = Nothing
        'Dim InfoLbl As New Label
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10
        allotmstatus = 2

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)


        EtiketaLbl.Text = "BOOKING POSITION  ΠΡΑΚΤΟΡΕΙΩΝ B' ΤΡΟΠΟΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        HauptPnl.Controls.Add(BookingBPnl)
        BookingBPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        BookingBPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        PraktorBTbx.Text = " <Κάνετε κλίκ εδώ> "

    End Sub

    Private Sub PraktorBTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktorBTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen
        AllotmRBbPnl.Controls.Clear()
        SimbBPbPnl.Controls.Clear()
        BookPos2Pnl.Controls.Clear()
        AllotmRBbPnl.Focus()

        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            PraktorBTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"

            Exit Sub
        End If
        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

        PraktorBTbx.Text = PraktForm.return_praktoreio

        PraktForm.Dispose()
        'PeriodoiPnl.Controls.Clear()
        'HauptPnl.Controls.Remove(PeriodoiPnl)
        zeige_simbolia_radiobuttons(0, 2, False, 2) ' 'Me.PraktoreioTbx.Location.X, Label21.Location.Y - 5
        AllotmRBbPnl.Focus()
    End Sub
    Private Sub lade_von_db_zu_book()
        Dim i, j, z As Int16

        Dim apomina, mexrimina As Int16

        For z = 0 To Me.DbhotelDataSet.bookingpos.Count - 1

            apomina = Me.DbhotelDataSet.bookingpos(z).apo.Date.Month
            'mexrimera = Me.DbhotelDataSet.allotment(z).mexri.Date.Day
            mexrimina = Me.DbhotelDataSet.bookingpos(z).mexri.Date.Month

            For j = Me.DbhotelDataSet.bookingpos(z).apo.Date.Month To Me.DbhotelDataSet.bookingpos(z).mexri.Date.Month
                For i = 1 To 31
                    If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                    OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                        Exit For
                    End If
                    If (Not j = Me.DbhotelDataSet.bookingpos(z).apo.Month Or Not i < Me.DbhotelDataSet.bookingpos(z).apo.Day) And
                                    (Not j = Me.DbhotelDataSet.bookingpos(z).mexri.Month Or Not i > Me.DbhotelDataSet.bookingpos(z).mexri.Day) Then

                        'allotm(i - 1, j - 1) = Me.DbhotelDataSet.allotment(z).anzahl
                        book(i - 1, j - 1) = Me.DbhotelDataSet.bookingpos(z).anzahl
                    End If
                Next
            Next
        Next
    End Sub
    Private Sub zeig_book_b_felder()
        Dim Button2 As New Button
        'Dim EtiketaLbl As New Label

        Dim i, j As Int16
        Dim locx, locy, stepx, stepy As Int16

        locx = 100
        locy = 30

        stepx = 30
        stepy = 15
        BookPos2Pnl.Show()
        For i = 1 To 31
            Dim ImeroLbl As New Label
            ImeroLbl.TextAlign = ContentAlignment.MiddleCenter
            ImeroLbl.Size = New Point(30, 30)

            Me.BookPos2Pnl.Controls.Add(ImeroLbl)
            ImeroLbl.Location = New Point(locx + (i - 1) * stepx, locy - stepx) '(locx + (i - 1) * stepx, locy)
            ImeroLbl.Text = i
            ImeroLbl.ForeColor = Color.Blue

        Next
        For j = firstdatumAllotm.Date.Month To lastdatumAllotm.Date.Month

            Dim MinasLbl As New Label
            MinasLbl.TextAlign = ContentAlignment.BottomCenter

            MinasLbl.Size = New Point(100, 30)

            Me.BookPos2Pnl.Controls.Add(MinasLbl)
            MinasLbl.Location = New Point(1, locy - 15)
            MinasLbl.Text = get_minas(j)
            locy = locy + stepx + stepy

            MinasLbl.ForeColor = Color.Blue
        Next
        locx = 100
        locy = 30

        For j = firstdatumAllotm.Date.Month To lastdatumAllotm.Date.Month

            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then

                    Exit For
                End If
                If (Not j = firstdatumAllotm.Date.Month Or Not i < firstdatumAllotm.Date.Day) And
                (Not j = lastdatumAllotm.Date.Month Or Not i > lastdatumAllotm.Date.Day) Then
                    Dim Txtbx As New TextBox
                    Dim Altlbl As New Label

                    Altlbl.TextAlign = ContentAlignment.MiddleCenter
                    Txtbx.MaxLength = 3
                    Txtbx.TextAlign = HorizontalAlignment.Center
                    If i Mod 2 = 0 Then
                        Txtbx.BackColor = Color.Bisque
                    End If
                    Txtbx.Name = "Txtbx" + i.ToString + "_" + j.ToString

                    Txtbx.Size = New Point(30, 30)
                    Altlbl.Size = New Point(30, 20)


                    Me.BookPos2Pnl.Controls.Add(Txtbx)
                    Me.BookPos2Pnl.Controls.Add(Altlbl)

                    Txtbx.Location = New Point(locx + (i - 1) * stepx, locy)
                    Altlbl.Location = New Point(locx + (i - 1) * stepx, locy + 15)

                    If book(i - 1, j - 1) = -1 Then
                        Txtbx.Text = 0
                    Else
                        Txtbx.Text = book(i - 1, j - 1)
                    End If

                    If Txtbx.Text <> 0 Then
                        Txtbx.ForeColor = Color.Red
                    End If

                    If book(i - 1, j - 1) = -1 Then
                        Altlbl.Text = 0
                    Else
                        Altlbl.Text = allotm(i - 1, j - 1)
                    End If


                    AddHandler Txtbx.Leave, AddressOf BookBox_Leave
                    AddHandler Txtbx.KeyPress, AddressOf BookBox_KeyPress
                End If

            Next
            locy = locy + stepx + stepy
        Next

        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        SpeicherButton.Location = New Point(BookPos2Pnl.Width / 2 + 50, locy)
        BookPos2Pnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf bookB_speichern   'MsgBox(allotm(29, 3))
    End Sub
    Private Sub bookB_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j, index, k1, k2 As Int16
        Dim currentanzahl As Integer = 0
        Dim punkt As feld
        Dim ende As Boolean = False
        Dim periodoiallotm() As AllotmPeriod
        'ReDim Preserve 

        index = 0
        For j = firstdatumAllotm.Date.Month To lastdatumAllotm.Date.Month
            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                    Exit For
                End If
                If (Not j = firstdatumAllotm.Date.Month Or Not i < firstdatumAllotm.Date.Day) And
                (Not j = lastdatumAllotm.Date.Month Or Not i > lastdatumAllotm.Date.Day) Then
                    If book(i - 1, j - 1) <> -1 Then
                        If book(i - 1, j - 1) <> currentanzahl Then
                            punkt = return_wechselanzahl_bookfeld(i, j, currentanzahl)
                            'MsgBox(punkt.i)
                            If punkt.i = -1 Or punkt.j = -1 Then
                                ende = True
                                Exit For
                            End If

                            ReDim Preserve periodoiallotm(index)
                            index = index + 1
                            periodoiallotm(index - 1).apo = "#" + punkt.i.ToString + "/" + punkt.j.ToString + "/" + etos.ToString + "#"
                            periodoiallotm(index - 1).anzahl = book(punkt.i - 1, punkt.j - 1)
                            'MsgBox(periodoiallotm(index - 1).apo)
                            currentanzahl = periodoiallotm(index - 1).anzahl

                            i = punkt.i
                            j = punkt.j
                        End If
                    End If
                End If
            Next
            If ende Then
                Exit For
            End If
        Next

        Try
            For i = 0 To periodoiallotm.Length - 1
                If i <> periodoiallotm.Length - 1 Then
                    periodoiallotm(i).mexri = periodoiallotm(i + 1).apo.AddDays(-1)
                Else
                    periodoiallotm(i).mexri = lastdatumAllotm
                End If
            Next
        Catch ex As NullReferenceException
            Exit Sub
        End Try
        'For i = 0 To periodoiallotm.Length - 1
        '    MsgBox(periodoiallotm(i).apo)
        'Next

        'MsgBox(Me.DbhotelDataSet.bookingpos.Count)
        'MsgBox(periodoiallotm.Length)

        If Me.DbhotelDataSet.bookingpos.Count <= periodoiallotm.Length Then
            For k1 = 0 To Me.DbhotelDataSet.bookingpos.Count - 1
                If k1 <> periodoiallotm.Length - 1 Then
                    Me.BookingposTableAdapter.UpdateBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k1).apo, periodoiallotm(k1 + 1).apo.AddDays(-1), periodoiallotm(k1).anzahl, currentguarant, Me.DbhotelDataSet.bookingpos(k1).kwd)
                Else
                    Me.BookingposTableAdapter.UpdateBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k1).apo, lastdatumAllotm, periodoiallotm(k1).anzahl, currentguarant, Me.DbhotelDataSet.bookingpos(k1).kwd)
                End If

            Next
            For k2 = k1 To periodoiallotm.Length - 1
                If k2 <> periodoiallotm.Length - 1 Then
                    Me.BookingposTableAdapter.InsertBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, periodoiallotm(k2 + 1).apo.AddDays(-1), periodoiallotm(k2).anzahl, currentguarant)
                Else
                    Me.BookingposTableAdapter.InsertBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, lastdatumAllotm, periodoiallotm(k2).anzahl, currentguarant)
                End If

            Next
        ElseIf Me.DbhotelDataSet.bookingpos.Count > periodoiallotm.Length Then

            For k1 = 0 To Me.DbhotelDataSet.bookingpos.Count - 1
                Me.BookingposTableAdapter.DeleteBook(Me.DbhotelDataSet.bookingpos(k1).kwd)
            Next
            For k2 = 0 To periodoiallotm.Length - 1
                If k2 <> periodoiallotm.Length - 1 Then
                    Me.BookingposTableAdapter.InsertBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, periodoiallotm(k2 + 1).apo.AddDays(-1), periodoiallotm(k2).anzahl, currentguarant)
                Else
                    Me.BookingposTableAdapter.InsertBook(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, lastdatumAllotm, periodoiallotm(k2).anzahl, currentguarant)
                End If
            Next
        End If
        Me.BookingposTableAdapter.FillByBookB(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant)
    End Sub
    Private Sub BookBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim split As String() = sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5).Split(New [Char]() {"_"c})
        Dim value As Int16


        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then ' Or
            Try
                If split(0) = 1 Then
                    Try
                        value = book(max_imerom(split(1) - 1) - 1, split(1) - 2)
                    Catch ex As IndexOutOfRangeException
                        Exit Sub
                    End Try
                    'edw CRASHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHh
                    If value <> 0 Then
                        sender.text = value
                        sender.forecolor = Color.Red
                    Else
                        sender.text = 0
                        sender.forecolor = Color.Black
                    End If

                Else
                    value = book(split(0) - 2, split(1) - 1)
                    If value <> 0 Then
                        sender.text = value
                        sender.forecolor = Color.Red
                    Else
                        sender.text = 0
                        sender.forecolor = Color.Black
                    End If
                End If


                'End If
            Catch ex As InvalidCastException

                sender.text = 0
                sender.forecolor = Color.Black
            End Try


        End If


    End Sub

    Private Sub BookBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim split As String() = sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5).Split(New [Char]() {"_"c})
        Try

            If CType(sender.Text, Int16) > 0 Then
                If sender.text <> book(split(0) - 1, split(1) - 1) Then
                    If sender.text > allotm(split(0) - 1, split(1) - 1) Then
                        MsgBox("Το πλήθος δωματίων δεν μπορεί ναι είναι μεγαλύτερο απο το καταχωρημένο Allotment!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.text = book(split(0) - 1, split(1) - 1)
                    End If
                End If
                book(split(0) - 1, split(1) - 1) = sender.text
                sender.forecolor = Color.Red
            Else

                sender.Text = 0
                sender.forecolor = Color.Black
                book(split(0) - 1, split(1) - 1) = 0
            End If
        Catch ex As InvalidCastException
            sender.Text = 0
            book(split(0) - 1, split(1) - 1) = 0
            'MsgBox(sender.name)
        End Try



    End Sub
    Private Function return_wechselanzahl_bookfeld(ByVal mera As Int16, ByVal minas As Int16, ByVal anzahl As Integer) As feld
        Dim i, j As Int16
        Dim punkt As feld

        For j = minas To lastdatumAllotm.Date.Month
            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                    Exit For
                End If
                If (Not j = minas Or Not i < mera) Then
                    If book(i - 1, j - 1) <> anzahl Then
                        punkt.i = i
                        punkt.j = j
                        'MsgBox(punkt.i)
                        Return punkt
                    End If
                End If
            Next
        Next

        punkt.i = -1
        punkt.j = -1
        Return punkt
    End Function
    Private Sub init_book()
        Dim i, j As Int16

        For j = 1 To 12
            For i = 1 To 31
                book(i - 1, j - 1) = 0
            Next
        Next


    End Sub

    'BOOKING POSITION  A BOOKING POSITION  A_____BOOKING POSITION  A____-BOOKING POSITION  A BOOKING POSITION  A BOOKING POSITION  A____________________
    Private Sub booking_a()
        Dim locx, locy As Int16

        praktoreiokwd = Nothing
        'Dim InfoLbl As New Label
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10
        allotmstatus = 1

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "BOOKING POSITION  ΠΡΑΚΤΟΡΕΙΩΝ Α' ΤΡΟΠΟΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        HauptPnl.Controls.Add(BookingAPnl)
        BookingAPnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        BookingAPnl.Location = New Point(5, EtiketaPnl.Height + 5)
        PraktorTbx.Text = " <Κάνετε κλίκ εδώ> "
        ImeromEkdoDtp.MinDate = "1/1/" + etos.ToString
        ImeromEkdoDtp.MaxDate = "31/12/" + etos.ToString
        ImeromEkdoDtp.Value = imeromErgasias
    End Sub
    Private Sub Praktoreio_BookingPos_Tbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktorTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen


        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")

            PraktorTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
            AllotmRBPnl.Focus()
            AllotmRBPnl.Controls.Clear()
            AllotmSichtPnl.Hide()
            AllotmSichtPnl.Controls.Clear()
            BookPos1Pnl.Controls.Clear()
            BPSimbPnl.Controls.Clear()
            Me.BPSimbPnl.Focus()

            Exit Sub
        End If

        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

        If allotmstatus = 1 Then
            AllotmSichtPnl.Controls.Clear()
            BookPos1Pnl.Controls.Clear()
            BPSimbPnl.Controls.Clear()
            PraktorTbx.Text = PraktForm.return_praktoreio
            'ElseIf allotmstatus = 2 Then
            '    PraktorBTbx.Text = PraktForm.return_praktoreio
        End If

        PraktForm.Dispose()
        'PeriodoiPnl.Controls.Clear()
        'HauptPnl.Controls.Remove(PeriodoiPnl)

        zeige_simbolia_radiobuttons(0, 2, False, 1) ' 'Me.PraktoreioTbx.Location.X, Label21.Location.Y - 5


        Me.BPSimbPnl.Focus()

    End Sub
    Private Sub zeige_simbolia_radiobuttons(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean, ByVal allotropos As Byte)
        Dim Erstesbuttn As New RadioButton
        Dim line As Int16 = 0
        Dim i, k As Int16

        k = -1
        If allotmstatus = 1 Then
            BPSimbPnl.Controls.Clear()
        ElseIf allotmstatus = 2 Then
            SimbBPbPnl.Controls.Clear()
        End If
        ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...
        For i = 0 To Me.DbhotelDataSet.simbolaia.Count - 1
            Me.AllotmentTableAdapter.AllotmKatigoriesBySimbolaio(Me.DbhotelDataSet.allotment, Me.DbhotelDataSet.simbolaia(i).kwd)
            If Me.DbhotelDataSet.allotment.Count <> 0 Then
                Me.DbhotelDataSet.allotment.Clear()
                Dim AArdbuttn As New RadioButton
                AArdbuttn.Width = 70
                AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
                AArdbuttn.TextAlign = ContentAlignment.MiddleRight
                If allotmstatus = 1 Then
                    BPSimbPnl.Controls.Add(AArdbuttn)
                ElseIf allotmstatus = 2 Then
                    SimbBPbPnl.Controls.Add(AArdbuttn)
                End If

                AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.simbolaia(i).kwd.ToString
                If i = Me.DbhotelDataSet.simbolaia.Count - 1 AndAlso remalen Then
                    AArdbuttn.Checked = True
                End If
                AArdbuttn.Text = Me.DbhotelDataSet.simbolaia(i).aasimbolaiou
                If i Mod 4 = 0 Then
                    line = line + 20
                    k = 0
                Else
                    k = k + 1
                End If

                AArdbuttn.Location = New Point(x + k * AArdbuttn.Width + 5, y + line - 20)
                If i = 0 Then
                    Erstesbuttn = AArdbuttn
                End If
                AddHandler AArdbuttn.Click, AddressOf simbolia_radiobuttons_CheckedChanged
            End If


        Next
        If Me.DbhotelDataSet.simbolaia.Count <> 0 Then
            simbolaio_waehlen(Me.DbhotelDataSet.simbolaia(0).kwd)
            Erstesbuttn.Checked = True
        End If
    End Sub
    Private Sub simbolia_radiobuttons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        If sender.checked = True Then
            Try
                simbolaiokwd = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
                Me.SimbolaiaTableAdapter.PerigrafiByKwd(Me.DbhotelDataSet.simbolaia, simbolaiokwd)

                Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)
                If Not pruefe_ob_touristikes_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στις Τουριστικές Περιόδους: Ελέγξτε τα χρονικά όρια !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    AllotmRBPnl.Focus()
                    AllotmRBPnl.Controls.Clear()
                    AllotmSichtPnl.Hide()
                    AllotmSichtPnl.Controls.Clear()
                    BookPos1Pnl.Controls.Clear()
                    BPSimbPnl.Controls.Clear()
                    Me.BPSimbPnl.Focus()
                    Exit Sub
                End If
                zeige_allotment_radiobuttons(0, 2, False, allotmstatus)
            Catch ex As InvalidCastException

            End Try

        End If
    End Sub
    Private Sub simbolaio_waehlen(ByVal kwdikos As Integer)
        simbolaiokwd = kwdikos
        Me.SimbolaiaTableAdapter.PerigrafiByKwd(Me.DbhotelDataSet.simbolaia, simbolaiokwd)
        Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)
        If Not pruefe_ob_touristikes_periodoi_richtig() Then
            MsgBox(" Υπάρχει Λάθος στις Τουριστικές Περιόδους: Ελέγξτε τα χρονικά όρια !", MsgBoxStyle.Critical, "winfo\nikEl.")
            AllotmRBPnl.Focus()
            AllotmRBPnl.Controls.Clear()
            AllotmSichtPnl.Hide()
            AllotmSichtPnl.Controls.Clear()
            BookPos1Pnl.Controls.Clear()
            BPSimbPnl.Controls.Clear()
            Me.BPSimbPnl.Focus()
            Exit Sub
        End If
        zeige_allotment_radiobuttons(0, 2, False, allotmstatus)
    End Sub
    Private Sub zeige_allotment_radiobuttons(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean, ByVal allotropos As Byte)
        Dim Erstesbuttn As New RadioButton
        Dim line As Int16 = 0
        Dim i, k As Int16
        Dim klinesname, tiposname, guarantee As String
        k = -1
        If allotmstatus = 1 Then
            AllotmRBPnl.Controls.Clear()
        ElseIf allotmstatus = 2 Then
            AllotmRBbPnl.Controls.Clear()
        End If
        ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...


        Me.AllotmentTableAdapter.AllotmKatigoriesBySimbolaio(Me.DbhotelDataSet.allotment, simbolaiokwd)

        For i = 0 To Me.DbhotelDataSet.allotment.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 240
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleCenter
            AArdbuttn.Cursor = Cursors.Hand
            AArdbuttn.BackColor = Color.Silver
            'AArdbuttn.BackColor = Color.Yellow
            If allotmstatus = 1 Then
                AllotmRBPnl.Controls.Add(AArdbuttn)
            ElseIf allotmstatus = 2 Then
                AllotmRBbPnl.Controls.Add(AArdbuttn)
            End If
            AArdbuttn.Name = Me.DbhotelDataSet.allotment(i).klines.ToString + "_" + Me.DbhotelDataSet.allotment(i).tipos.ToString + "/" + Me.DbhotelDataSet.allotment(i).guaranti.ToString
            'MsgBox(AArdbuttn.Name)
            'If i = Me.DbhotelDataSet.simbolaia.Count - 1 AndAlso remalen Then
            '    AArdbuttn.Checked = True
            'End If
            'MsgBox((Me.DbhotelDataSet.allotment(i).tipos))
            If Me.DbhotelDataSet.allotment(i).klines <> 0 Then
                klinesname = get_klines_by_kwdikos(Me.DbhotelDataSet.allotment(i).klines)
            Else
                klinesname = "Όλες Κλίνες"
            End If
            If Me.DbhotelDataSet.allotment(i).tipos <> 0 Then
                tiposname = get_tipos_by_kwdikos(Me.DbhotelDataSet.allotment(i).tipos)
            Else
                tiposname = "Όλα Δωμ."
            End If

            If Me.DbhotelDataSet.allotment(i).guaranti Then
                guarantee = "(guarantee)"
            Else
                guarantee = ""
            End If
            AArdbuttn.Text = klinesname + " " + tiposname + " " + guarantee

            line = line + 30
            AArdbuttn.Location = New Point(20, y + line - 20)
            If i = 0 Then
                Erstesbuttn = AArdbuttn
            End If
            AddHandler AArdbuttn.CheckedChanged, AddressOf setze_globale_variablen

        Next
        Erstesbuttn.Checked = True ' Proepilogi to 1o simbolaio is checked!


    End Sub
    'Private Sub ImeromEkdoDtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImeromEkdoDtp.Leave

    'End Sub
    Private Sub Ananewsi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If allotmstatus = 1 AndAlso praktoreiokwd <> Nothing AndAlso Me.DbhotelDataSet.allotment.Count > 0 Then
            AllotmSichtPnl.Controls.Clear()
            BookPos1Pnl.Controls.Clear()
            If ImeromEkdoDtp.Value > lastdatumAllotm Then
                MsgBox(" Η Ημερομηνία είναι εκτός ορίων κράτησης: " + lastdatumAllotm, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Exit Sub
            End If
            zeig_allotm_labels()
            zeig_book_felder()

        End If


    End Sub
    Private Sub setze_globale_variablen(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        'edw kane setzen ta currentklines currenttipos kai ean einai guaranti gewaehlt kathws kai to first-last Datum apo ta ALLOTMENT
        'If allotmstatus = 1 Then
        '    AllotmSichtPnl.Controls.Clear()
        '    BookPos1Pnl.Controls.Clear()
        'ElseIf allotmstatus = 2 Then

        '    BookPos2Pnl.Controls.Clear()

        'End If


        If sender.checked Then
            Dim split As String() = sender.NAME.ToString.Split(New [Char]() {"/"c})
            Dim split1 As String() = split(0).ToString.Split(New [Char]() {"_"c})

            Dim n As Int16 = 14

            currentklines = split1(0)
            currenttipos = split1(1)
            currentguarant = split(1)
            firstdatumAllotm = Me.AllotmentTableAdapter.FirstDatumBy(simbolaiokwd, currentklines, currenttipos, currentguarant)
            lastdatumAllotm = Me.AllotmentTableAdapter.LastDatumBy(simbolaiokwd, currentklines, currenttipos, currentguarant)
            ImeromEkdoDtp.Format = DateTimePickerFormat.Custom
            ImeromEkdoDtp.CustomFormat = "dd /MMMM/yyyy"
            ImeromEkdoDtp.Value = firstdatumAllotm
            If allotmstatus = 1 Then
                AllotmSichtPnl.Controls.Clear()
                BookPos1Pnl.Controls.Clear()
                zeig_allotm_labels()
            ElseIf allotmstatus = 2 Then
                BookPos2Pnl.Controls.Clear()
                ReDim allotm(30, 11)
                ReDim book(30, 11)
                init_allotm()
                init_book()
                Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, currentguarant)
                If Not pruefe_ob_allotment_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στo Allotment: Ελέγξτε τα χρονικά όρια !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    AllotmRBbPnl.Controls.Clear()
                    SimbBPbPnl.Controls.Clear()
                    BookPos2Pnl.Controls.Clear()
                    AllotmRBbPnl.Focus()
                    Exit Sub
                End If
                Me.BookingposTableAdapter.FillByBookB(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant)
                If Not Me.pruefe_ob_booking_pos_periodoi_richtig Then
                    MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους των Booking Positions: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If
                lade_von_db_zu_allotm()
                lade_von_db_zu_book()
                zeig_book_b_felder()
            End If

        End If


    End Sub
    Private Sub zeig_allotm_labels()
        Dim i As Int16
        Dim locx, locy As Int16
        Me.AllotmentTableAdapter.FillByKlinesTiposImerom(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, currentguarant, ImeromEkdoDtp.Value)
        If Not pruefe_ob_allotment_periodoi_richtig() Then
            MsgBox(" Υπάρχει Λάθος στo Allotment: Ελέγξτε τα χρονικά όρια !", MsgBoxStyle.Critical, "winfo\nikEl.")
            AllotmRBPnl.Focus()
            AllotmRBPnl.Controls.Clear()
            AllotmSichtPnl.Hide()
            AllotmSichtPnl.Controls.Clear()
            BookPos1Pnl.Controls.Clear()
            BPSimbPnl.Controls.Clear()
            Me.BPSimbPnl.Focus()
            Exit Sub
        End If
        locx = 13
        locy = 3


        AllotmSichtPnl.Show()

        Dim ImerLbl As New Label

        ImerLbl.ForeColor = Color.Blue
        ImerLbl.Width = 120
        ImerLbl.Text = "Ημερομηνία από..."

        ImerLbl.Location = New Point(locx + 20, locy)


        Dim DwmLbl As New Label

        DwmLbl.ForeColor = Color.Blue
        DwmLbl.Text = "Δωμάτια"
        DwmLbl.Width = 60

        DwmLbl.Location = New Point(locx + ImerLbl.Width + 30, locy)



        AllotmSichtPnl.Controls.Add(ImerLbl)
        AllotmSichtPnl.Controls.Add(DwmLbl)


        For i = 0 To Me.DbhotelDataSet.allotment.Count - 1

            Dim Datum As New Label

            Datum.Name = "Datum" + i.ToString
            Datum.Text = Me.DbhotelDataSet.allotment(i).apo
            Datum.TextAlign = ContentAlignment.MiddleCenter
            Datum.BackColor = Color.Silver
            Datum.ForeColor = Color.Black

            Dim Anzhl As New Label

            Anzhl.Name = "Anzhl" + i.ToString

            Anzhl.TextAlign = HorizontalAlignment.Center
            Anzhl.Text = Me.DbhotelDataSet.allotment(i).anzahl
            Anzhl.TextAlign = ContentAlignment.MiddleCenter
            Anzhl.BackColor = Color.Silver
            Anzhl.ForeColor = Color.Black
            Anzhl.Size = New Point(40, Datum.Height)


            AllotmSichtPnl.Controls.Add(Datum)
            AllotmSichtPnl.Controls.Add(Anzhl)


            Datum.Location = New Point(locx + 20, locy + ImerLbl.Height + i * (Datum.Height + 10))
            Anzhl.Location = New Point(locx + 20 + Datum.Width + 40, locy + ImerLbl.Height + i * (Datum.Height + 10))

        Next
        'MsgBox("klasdfldsfk")
        zeig_book_felder()
        'If allotmstatus = 1 Then

        'ElseIf allotmstatus = 2 Then
        '    BookPos2Pnl.Controls.Clear()
        '    ReDim allotm(30, 11)
        '    ReDim book(30, 11)
        '    init_allotm()
        '    init_book()
        '    Me.BookingposTableAdapter.FillByBookB(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant)
        '    Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, currentguarant)
        '    lade_von_db_zu_allotm()
        '    lade_von_db_zu_book()
        '    zeig_book_b_felder()
        'End If




    End Sub
    Private Sub zeig_book_felder()

        Dim n As Int16 = 5
        Dim i, k As Int16
        Dim locx, locy As Int16
        Dim listeOK As Boolean = False

        BookPos1Pnl.Show()
        Me.BookingposTableAdapter.FillByBookingListe(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant, ImeromEkdoDtp.Value)

        If Me.DbhotelDataSet.bookingpos.Count <> 0 Then
            ReDim bookListe(Me.DbhotelDataSet.bookingpos.Count - 1)
            listeOK = True
            'MsgBox("bookliste" + bookListe.Length.ToString)
            speichere_bookperioden_zu_bookliste()
        Else
            ReDim bookListe(-1)
        End If
        'MsgBox(bookListe.Length)

        Me.DbhotelDataSet.bookingpos.Clear()
        Me.BookingposTableAdapter.FillByKlinesTiposImerom(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant, ImeromEkdoDtp.Value)
        'MsgBox(Me.DbhotelDataSet.bookingpos.Count)
        locx = 3
        locy = 3

        If n <= Me.DbhotelDataSet.bookingpos.Count - 1 Then
            n = Me.DbhotelDataSet.bookingpos.Count - 1 + 3
        End If
        ReDim allotmentA(n)


        'DeleteLbl.Location = New Point(1, locy)
        Dim ImerLbl As New Label

        ImerLbl.ForeColor = Color.Blue
        ImerLbl.Width = 120
        ImerLbl.Text = "Ημερομηνία από..."

        'SeasonLbl.Size = New Point(170, 20)
        ImerLbl.Location = New Point(locx + 20, locy)
        BookPos1Pnl.Controls.Add(ImerLbl)

        Dim DwmLbl As New Label

        DwmLbl.ForeColor = Color.Blue
        DwmLbl.Text = "Δωμάτια"
        DwmLbl.Width = 60

        DwmLbl.Location = New Point(locx + ImerLbl.Width + 110, locy)
        BookPos1Pnl.Controls.Add(DwmLbl)

        For i = 0 To Me.DbhotelDataSet.bookingpos.Count - 1
            'Dim DeleteChbx As New CheckBox

            'allotmentA(i).delete = False
            'DeleteChbx.Name = "Delet" + i.ToString
            'DeleteChbx.ForeColor = Color.Red
            ''DeleteChbx.Location = New Point(locx - 60, locy + 2 * PeriodosLbl.Height * (i + 1))
            'DeleteChbx.Width = 15


            Dim Datum As New DateTimePicker

            allotmentA(i).kwd = Me.DbhotelDataSet.bookingpos(i).kwd
            allotmentA(i).status = 1 '->UPDATE!
            Datum.Name = "Datum" + i.ToString
            If i = 0 AndAlso listeOK Then
                Datum.Value = ImeromEkdoDtp.Value
                allotmentA(i).apo = ImeromEkdoDtp.Value
            Else
                Datum.Value = Me.DbhotelDataSet.bookingpos(i).apo
                allotmentA(i).apo = Me.DbhotelDataSet.bookingpos(i).apo
            End If

            Datum.MinDate = firstdatumAllotm
            Datum.MaxDate = lastdatumAllotm
            Datum.Format = DateTimePickerFormat.Custom
            Datum.CustomFormat = "dd /MMMM/yyyy"


            AddHandler Datum.Enter, AddressOf Datum_Booking_Enter
            AddHandler Datum.LostFocus, AddressOf Datum_Booking_LostFocus


            Dim Anzhl As New TextBox

            Anzhl.Name = "Anzhl" + i.ToString
            Anzhl.MaxLength = 3
            Anzhl.TextAlign = HorizontalAlignment.Center
            Anzhl.Text = Me.DbhotelDataSet.bookingpos(i).anzahl
            allotmentA(i).anzahl = Anzhl.Text
            Anzhl.Size = New Point(40, Datum.Width)
            AddHandler Anzhl.Leave, AddressOf Anzhl_Booking_Leave

            BookPos1Pnl.Controls.Add(Datum)
            BookPos1Pnl.Controls.Add(Anzhl)


            'DeleteChbx.Location = New Point(locx + 10, locy - 2 + ImerLbl.Height + i * (Datum.Height + 10))
            Datum.Location = New Point(locx + 20, locy + ImerLbl.Height + i * (Datum.Height + 10))
            Anzhl.Location = New Point(locx + 20 + Datum.Width + 20, locy + ImerLbl.Height + i * (Datum.Height + 10))

        Next

        For k = i To n

            Dim Datum As New DateTimePicker


            allotmentA(k).kwd = -1
            allotmentA(k).status = -1
            If k = 0 Then
                allotmentA(k).apo = ImeromEkdoDtp.Value
                Datum.Value = ImeromEkdoDtp.Value
            Else
                allotmentA(k).apo = lastdatumAllotm
                Datum.Value = lastdatumAllotm
            End If


            Datum.Name = "Datum" + k.ToString

            Datum.Format = DateTimePickerFormat.Custom
            Datum.MinDate = firstdatumAllotm
            Datum.MaxDate = lastdatumAllotm
            AddHandler Datum.Enter, AddressOf Datum_Booking_Enter
            AddHandler Datum.LostFocus, AddressOf Datum_Booking_LostFocus
            If k = 0 Then
                Datum.CustomFormat = "dd /MMMM/yyyy"
                allotmentA(k).apo = Datum.Value
            Else
                Datum.CustomFormat = " "
            End If
            If k <> i Then
                Datum.Enabled = False
            End If



            Dim Anzhl As New TextBox
            Anzhl.Name = "Anzhl" + k.ToString
            Anzhl.MaxLength = 3
            Anzhl.TextAlign = HorizontalAlignment.Center
            Anzhl.Size = New Point(40, Datum.Width)
            allotmentA(k).anzahl = -1
            If k <> 0 Then
                Anzhl.Enabled = False
            Else
                Anzhl.Enabled = True
            End If

            AddHandler Anzhl.Enter, AddressOf Anzhl_Booking_Enter
            AddHandler Anzhl.Leave, AddressOf Anzhl_Booking_Leave


            'Allotm3Pnl.Controls.Add(DeleteChbx)
            BookPos1Pnl.Controls.Add(Datum)
            BookPos1Pnl.Controls.Add(Anzhl)
            'DeleteChbx.Location = New Point(locx + 10, locy - 2 + ImerLbl.Height + k * (Datum.Height + 10))
            Datum.Location = New Point(locx + 20, locy + ImerLbl.Height + k * (Datum.Height + 10))
            Anzhl.Location = New Point(locx + 20 + Datum.Width + 20, locy + ImerLbl.Height + k * (Datum.Height + 10))

        Next

        BookPos1Pnl.Location = New Point(BookingAPnl.Width / 2 + 50, 5)
        BookPos1Pnl.Size = New Point(BookingAPnl.Width / 2 - 80, BookingAPnl.Height)

        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        'SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10))
        SpeicherButton.Location = New Point(BookPos1Pnl.Width / 2 - 80, locy + k * (ImerLbl.Height + 10))
        BookPos1Pnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf bookingA_speichern
        AddHandler SpeicherButton.Leave, AddressOf speichbtn_next_tab

        Dim DeleteButton As New Button
        DeleteButton.BackColor = Color.Azure
        DeleteButton.ForeColor = Color.Maroon
        DeleteButton.Text = "Διαγραφή"
        DeleteButton.Size = New Point(140, 30)
        DeleteButton.Cursor = Cursors.Hand
        DeleteButton.Location = New Point(BookPos1Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10) + SpeicherButton.Height)
        'MsgBox(bookListe.Length)
        If bookListe.Length > 0 Then
            DeleteButton.Enabled = False
        Else
            DeleteButton.Enabled = True

        End If
        BookPos1Pnl.Controls.Add(DeleteButton)

        AddHandler DeleteButton.Click, AddressOf bookingA_delete

        Dim InfoLbl As New Label

        InfoLbl.TextAlign = HorizontalAlignment.Center
        InfoLbl.Text = " Δώσετε τις Booking Positions. Σε περίπτωση που θέλετε να διαγράψετε ΜΙΑ μόνο περίοδο 'σβήστε' τα Δωμάτια ώστε το κουτάκι δεξιά να είναι ΚΕΝΟ ! Με το κουμπί της Διαγραφής διαγράφετε μονομιάς ΟΛΕΣ τις περιόδους. (Σε περίπτωση που έχει επιλεχθεί Ημερ/νία Έκδοσης μεταγενέσταρα μιας περιόδου, πράγμα που σημαίνει πως δεν ειναι ορατές ΟΛΕΣ οι Περίοδοι, τότε το κουμπί της Διαγραφής είναι ΑΠΕΝΕΡΓΟΠΟΙΗΜΕΝΟ!)"
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.BackColor = Color.Silver
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Size = New Point(BookPos1Pnl.Width - 20, 150)
        InfoLbl.Location = New Point(5, locy + ImerLbl.Height + k * (ImerLbl.Height + 10) + SpeicherButton.Height + 2 * DeleteButton.Height)
        BookPos1Pnl.Controls.Add(InfoLbl)
    End Sub
    Private Sub bookingA_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'PROSOXI-> stin DB to sto allotment den iparxei elegxo ean ta felder tou( klines,tipos) existrieren sta antistoixa Tables=> ean einai OLES 
        'oi klines i tipoi Tote sto allotment ta felder exoun 0! 

        Dim i, counter1 As Int16


        If alles_ok() Then 'teleutaios elegxos prin tin apothikeusi

            For i = 0 To allotmentA.Length - 1

                If allotmentA(i).anzahl <> -1 Then ' dh anzahl feld ist belegt (dwmatia)
                    counter1 = find_next_aktive_allotm(i)
                    If counter1 <> -1 Then '(oxi to teleuetaio)
                        If allotmentA(i).status = 2 Then 'Insert
                            Me.BookingposTableAdapter.InsertBooking(simbolaiokwd, currentklines, currenttipos, allotmentA(i).apo, allotmentA(counter1).apo.AddDays(-1), allotmentA(i).anzahl, currentguarant)
                        ElseIf allotmentA(i).status = 1 Then 'uPDATe
                            Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, allotmentA(i).apo, allotmentA(counter1).apo.AddDays(-1), allotmentA(i).anzahl, currentguarant, allotmentA(i).kwd)
                        End If
                    ElseIf counter1 = -1 Then
                        If allotmentA(i).status = 1 Then 'uPDATE
                            Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, allotmentA(i).apo, lastdatumAllotm, allotmentA(i).anzahl, currentguarant, allotmentA(i).kwd)
                        Else
                            Me.BookingposTableAdapter.InsertBooking(simbolaiokwd, currentklines, currenttipos, allotmentA(i).apo, lastdatumAllotm, allotmentA(i).anzahl, currentguarant)
                        End If
                    End If
                Else 'to feld anzahl exei sbistei=> delete 
                    If allotmentA(i).status = 1 Then ' den mporei naeinai allo ektos apo 1( an itan 2 -> Insert (neo) feld me sbismeno anzahl=> NICHT beruecksichtigen!
                        Me.BookingposTableAdapter.DeleteBooking(allotmentA(i).kwd)
                    End If
                End If

            Next

        Else
            MsgBox("false)")
        End If

        Try
            If bookListe.Length > 0 Then
                korigiere_book_perioden() ' dIORTHOSE TIS OPOIES DISKREPANZEN EXOUN DIMIOURGITHEI (KOITA TIN SUB GIA PERISOTERES EKSIGISEIS)
            End If
        Catch ex As NullReferenceException
        End Try


        BookPos1Pnl.Controls.Clear()
        'Me.BookingposTableAdapter.FillByKlinesTiposImerom(Me.DbhotelDataSet.bookingpos, simbolaiokwd, currentklines, currenttipos, currentguarant, ImeromEkdoDtp.Value)
        zeig_book_felder()
    End Sub
    Private Sub bookingA_delete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Int16
        Dim response As MsgBoxResult

        If es_gibt_felder_to_delete() Then
            response = MsgBox("Να διαγραφούν ΟΛΕΣ οι καταχωρίσεις (Ημερ/νίες, Πλήθος Δωματίων) για την συγκεκριμένη κατηγορία;" & vbCrLf & vbCrLf & "(Για Διαγραφή μόνο ΜΙΑΣ περιόδου σβήστε το πλήθος δωματίων ώστε το κουτάκι δεξιά να είναι κενό)", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                For i = 0 To allotmentA.Length - 1
                    If allotmentA(i).kwd <> -1 Then
                        Me.BookingposTableAdapter.DeleteBooking(allotmentA(i).kwd)
                    End If
                Next
            Else
                Exit Sub
            End If
            BookPos1Pnl.Controls.Clear()
            'Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
            zeig_book_felder()
        End If
    End Sub
    Private Sub Anzhl_Booking_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) '
        Dim k, index1, index2, anzahl As Int16

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        Try
            If CType(sender.text, Int16) >= 0 Then

                If sender.text <> allotmentA(k).anzahl Then

                    If currentklines > 0 And currenttipos > 0 Then ' Manikis XY
                        anzahl = Me.AllotmentTableAdapter.AnzahlBySimbKlinesTiposGuarImerom(simbolaiokwd, currentklines, currenttipos, currentguarant, allotmentA(k).apo, allotmentA(k).apo)
                        'MsgBox(anzahl)
                        'MsgBox(sender.text)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο το Allotment (" + anzahl.ToString + ") στήν συγκεκριμένη περίοδο! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines > 0 And currenttipos = 0 Then
                        anzahl = Me.AllotmentTableAdapter.AnzahlBySimbKlinesGuarImerom(simbolaiokwd, currentklines, currentguarant, allotmentA(k).apo, allotmentA(k).apo)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο το Allotment (" + anzahl.ToString + ") στήν συγκεκριμένη περίοδο! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos > 0 Then
                        anzahl = Me.AllotmentTableAdapter.AnzahlBySimbTiposGuarImerom(simbolaiokwd, currenttipos, currentguarant, allotmentA(k).apo, allotmentA(k).apo)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο το Allotment (" + anzahl.ToString + ") στήν συγκεκριμένη περίοδο! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos = 0 Then

                        anzahl = Me.AllotmentTableAdapter.AnzahlBySimbGuarImerom(simbolaiokwd, currentguarant, allotmentA(k).apo, allotmentA(k).apo)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο το Allotment (" + anzahl.ToString + ") στήν συγκεκριμένη περίοδο! ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If

                    End If
                    index1 = find_last_aktive_allotm(k)
                    index2 = find_next_aktive_allotm(k)
                    If index1 <> -1 Then
                        If allotmentA(index1).anzahl = sender.text Then
                            MsgBox(" Το πλήθος Δωματίων που δώσατε είναι το ίδιο με αυτό της προηγούμενης περιόδου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.clear()
                            allotmentA(k).anzahl = -1
                            Exit Sub

                        End If
                    End If
                    If index2 <> -1 Then
                        If allotmentA(index2).anzahl = sender.text Then
                            MsgBox(" Το πλήθος Δωματίων που δώσατε είναι το ίδιο με αυτό της επόμενης περιόδου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.clear()
                            allotmentA(k).anzahl = -1
                            Exit Sub
                        End If
                    End If
                    allotmentA(k).anzahl = sender.text

                    If allotmentA(k).status = -1 Then 'ean Neo
                        allotmentA(k).status = 2 'Insert
                    End If

                End If
            Else
                sender.clear()
                allotmentA(k).anzahl = -1
            End If

        Catch ex As InvalidCastException
            sender.clear()
            allotmentA(k).anzahl = -1

        End Try
    End Sub
    Private Sub Datum_Booking_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k, index, index1 As Int16

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        If sender.value <> allotmentA(k).apo Then 'alakse kati???

            index = find_last_aktive_allotm(k)

            If index <> -1 AndAlso allotmentA(index).apo < sender.value Then 'meta to prwto
                index = find_next_aktive_allotm(k)
                If index = -1 OrElse allotmentA(index).apo > sender.value Then
                    If sender.value <= lastdatumAllotm Then
                        allotmentA(k).apo = sender.text
                        If allotmentA(k).status = -1 Then
                            allotmentA(k).status = 2
                        End If
                    Else
                        MsgBox("Η Ημερομηνία είναι εκτός ορίων συμβολαίου (" + lastdatumAllotm + ")!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.value = lastdatumAllotm
                        allotmentA(k).apo = sender.value
                        If allotmentA(k).status = -1 Then
                            allotmentA(k).status = 2
                        End If
                    End If

                ElseIf allotmentA(index).apo <= sender.value Then
                    MsgBox("Επικάλυψης περιόδων1 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    sender.value = allotmentA(k).apo
                End If
            ElseIf index = -1 Then
                If sender.value >= firstdatumAllotm Then
                    index1 = find_next_aktive_allotm(k)
                    If index1 <> -1 Then
                        If sender.value < allotmentA(index1).apo Then
                            allotmentA(k).apo = sender.value
                            'Me.ImeromEkdoDtp.Value = sender.value 'EEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRDSRDSDFSFFDSFFFFFFFFFFFFFFFFFFFFF
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        Else
                            MsgBox("Επικάλυψης περιόδων2 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.value = allotmentA(k).apo
                        End If
                    Else 'edw allagh
                        If sender.value <= lastdatumAllotm Then
                            allotmentA(k).apo = sender.value
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        Else
                            MsgBox("Η Ημερομηνία είναι εκτός ορίων συμβολαίου (" + lastdatumAllotm + ")!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.value = lastdatumAllotm
                            allotmentA(k).apo = sender.value
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        End If
                        'allotmentA(k).apo = sender.text
                        'If allotmentA(k).status = -1 Then
                        '    allotmentA(k).status = 2
                        'End If
                    End If
                Else
                    MsgBox("Η αρχική Συμφωνία με το συγκεκριμένο Πρακτορείο εχεί οριστεί για μεταγενέστερο χρόνο (βλ. Αρχή Season): " + firstdatumAllotm, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    sender.value = firstdatumAllotm
                    allotmentA(k).apo = sender.value
                    If allotmentA(k).status = -1 Then
                        allotmentA(k).status = 2
                    End If
                End If
            ElseIf allotmentA(index).apo >= sender.value Then
                MsgBox("Επικάλυψης περιόδων3 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                If allotmentA(k).apo > allotmentA(index).apo Then
                    sender.value = allotmentA(k).apo
                Else
                    sender.value = allotmentA(index).apo.AddDays(1)
                    allotmentA(k).apo = sender.value
                End If

            End If


        End If


    End Sub
    Private Sub Anzhl_Booking_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) 'ENERGOPOIEI to epomeno Datum
        Dim k As Int16
        Dim find() As Object

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString
        find = BookPos1Pnl.Controls.Find("Datum" + (k + 1).ToString, False)
        Try
            find(0).enabled = True
        Catch ex As Exception

        End Try

    End Sub
    'Energopoiei da DatumPicker
    Private Sub Datum_Booking_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As Int16
        Dim find() As Object


        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        If sender.value = lastdatumAllotm Then
            If k <> 0 AndAlso allotmentA(k - 1).apo <> lastdatumAllotm Then
                If allotmentA(k - 1).status <> -1 AndAlso allotmentA(k - 1).anzahl <> -1 Then 'ean einai to prwto(insert) i ean to proigoumeno exei oloklirothei->to staus tou demn einai -1!
                    If k > Me.DbhotelDataSet.bookingpos.Count - 1 Then  ' Einai neo Feld

                        find = BookPos1Pnl.Controls.Find("Datum" + k.ToString, False)
                        Try
                            find(0).CustomFormat = "dd /MMMM/yyyy"
                            'find(0).value = allotmentA(k - 1).apo.Date.AddDays(1)
                            find(0).value = lastdatumAllotm
                        Catch ex As IndexOutOfRangeException

                        End Try
                        find = BookPos1Pnl.Controls.Find("Anzhl" + k.ToString, False)
                        Try

                            find(0).enabled = True
                        Catch ex As IndexOutOfRangeException

                        End Try
                    End If
                End If
            End If
        End If



    End Sub
    ' Auta pou blepw (uposinolo) apohikeuontai sto allotmA kai  auta pou den blepw sto bookListe (Uberscheidung to prwto to allotm me to teleutaio tou
    'bookliste, ektos tin periptosi pou to "Blick" peftei akribws panw se periodo(->allotmentA(k).kwd <> bookListe(i).kwd)
    'stin sub speichern apothiketai to Blick xwris na lambanetai ipopsin oi poigoumenes periodoi=> se auto to sub ginetai i diorthosi mittels
    ' allotm kai bookliste

    Private Sub korigiere_book_perioden()
        Dim i, k, counter, z As Int16

        k = find_next_aktive_allotm(-1)
        counter = find_next_aktive_allotm(k)


        If k = -1 Then
            Exit Sub
        End If

        'For i = 0 To allotmentA.Length - 1
        '    MsgBox(allotmentA(i).apo)
        '    MsgBox(allotmentA(i).anzahl)

        'Next
        i = bookListe.Length - 1
        'Blick arxizei kapou sto meso mias periodou
        If allotmentA(k).kwd = bookListe(i).kwd And bookListe(i).anzahl = allotmentA(k).anzahl And bookListe(i).apo <= allotmentA(k).apo Then

            If counter = -1 Then
                Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(i).apo, lastdatumAllotm, allotmentA(k).anzahl, currentguarant, allotmentA(k).kwd)

            Else
                Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(i).apo, allotmentA(counter).apo.AddDays(-1), allotmentA(k).anzahl, currentguarant, allotmentA(k).kwd)

            End If
            'o xristis allazei tin arxiki imerominia tou Blick kai tin pisogirna etsi wste dimiourgitai Ueberschneidung kai me proigoumenes periodous
        ElseIf allotmentA(k).kwd = bookListe(i).kwd And (bookListe(i).anzahl <> allotmentA(k).anzahl Or bookListe(i).apo > allotmentA(k).apo) Then
            z = i
            While z >= 0 AndAlso bookListe(z).apo >= allotmentA(k).apo
                If z <> i Then
                    Me.BookingposTableAdapter.DeleteBooking(bookListe(z).kwd)
                End If
                ReDim Preserve bookListe(z)
                z -= 1
            End While
            If z >= 0 AndAlso bookListe(z).apo <= allotmentA(k).apo Then
                If z = i Then
                    Me.BookingposTableAdapter.InsertBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, allotmentA(k).apo.AddDays(-1), bookListe(z).anzahl, currentguarant)
                Else
                    If bookListe(z).anzahl = allotmentA(k).anzahl Then
                        If counter = -1 Then
                            Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, lastdatumAllotm, bookListe(z).anzahl, currentguarant, allotmentA(k).kwd)

                        Else
                            Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, allotmentA(counter).apo.AddDays(-1), bookListe(z).anzahl, currentguarant, allotmentA(k).kwd)

                        End If

                        Me.BookingposTableAdapter.DeleteBooking(bookListe(z).kwd)

                        ReDim Preserve bookListe(z - 1)

                    Else
                        Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, allotmentA(k).apo.AddDays(-1), bookListe(z).anzahl, currentguarant, bookListe(z).kwd)

                    End If
                End If


            End If
        ElseIf allotmentA(k).kwd <> bookListe(i).kwd Then
            z = i
            While z >= 0 AndAlso bookListe(z).apo >= allotmentA(k).apo

                Me.BookingposTableAdapter.DeleteBooking(bookListe(z).kwd)

                ReDim Preserve bookListe(z)
                z -= 1
            End While
            If z >= 0 Then
                If bookListe(z).anzahl = allotmentA(k).anzahl Then
                    If counter = -1 Then
                        Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, lastdatumAllotm, bookListe(z).anzahl, currentguarant, bookListe(z).kwd)
                    Else
                        Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, allotmentA(counter).apo.AddDays(-1), bookListe(z).anzahl, currentguarant, bookListe(z).kwd)
                    End If
                    Me.BookingposTableAdapter.DeleteBooking(allotmentA(k).kwd)
                ElseIf bookListe(z).apo < allotmentA(k).apo Then
                    Me.BookingposTableAdapter.UpdateBooking(simbolaiokwd, currentklines, currenttipos, bookListe(z).apo, allotmentA(k).apo.AddDays(-1), bookListe(z).anzahl, currentguarant, bookListe(z).kwd)
                End If

            End If


        End If

        Me.ImeromEkdoDtp.Value = allotmentA(k).apo


    End Sub

    Private Sub speichere_bookperioden_zu_bookliste()
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.bookingpos.Count - 1

            bookListe(i).kwd = Me.DbhotelDataSet.bookingpos(i).kwd
            bookListe(i).status = 1
            bookListe(i).apo = Me.DbhotelDataSet.bookingpos(i).apo
            bookListe(i).anzahl = Me.DbhotelDataSet.bookingpos(i).anzahl

        Next

    End Sub
    Private Sub speichbtn_next_tab(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BookPos1Pnl.Focus()


    End Sub

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
        Dim i As Int16

        For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1
            If kwdikos = Me.DbhotelDataSet.tipoi(i).kwd Then
                Return Me.DbhotelDataSet.tipoi(i).tipos
            End If
        Next

        Return Nothing

    End Function

    Private Function pruefe_ob_booking_pos_periodoi_richtig() As Boolean
        Dim startIndex As Int16
        Dim istOK As Boolean = True

        Do Until startIndex > Me.DbhotelDataSet.bookingpos.Count - 1
            'posa eintraege 
            'firstIndex = startIndex
            If startIndex < Me.DbhotelDataSet.bookingpos.Count - 1 Then
                'gia kathemia kRatisi
                While Me.DbhotelDataSet.bookingpos(startIndex).mexri.AddDays(1) = Me.DbhotelDataSet.bookingpos(startIndex + 1).apo
                    startIndex = startIndex + 1
                    If startIndex + 1 > Me.DbhotelDataSet.bookingpos.Count - 1 Then
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




    '************************************************************************************************************************
    '************************************************************************************************************************
    '************************************************************************************************************************
    Private Sub allotment_b()
        Dim locx, locy As Int16
        'Dim InfoLbl As New Label
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10

        'Allotm1Pnl.Size = New Point(800, 250)
        allotmstatus = 2
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ALLOTMENT ΠΡΑΚΤΟΡΕΙΩΝ Β' ΤΡΟΠΟΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)

        HauptPnl.Controls.Add(Allotm1Pnl)
        Allotm1Pnl.BorderStyle = BorderStyle.Fixed3D
        Allotm1Pnl.Size = New Point(Me.HauptPnl.Width - 30, 4 * EtiketaPnl.Height)
        Allotm1Pnl.Location = New Point(5, EtiketaPnl.Height + 5)
        Me.HauptPnl.Controls.Add(AllotmBPnl)
        'Me.AllotmBPnl.Dock = DockStyle.Fill
        AllotmBPnl.Size = New Point(Me.HauptPnl.Width + 200, 7 * EtiketaPnl.Height)
        AllotmBPnl.AutoScroll = True
        AllotmBPnl.Location = New Point(5, EtiketaLbl.Height + Allotm1Pnl.Height + 50)
        PraktTbx.Text = " <Κάνετε κλίκ εδώ> "
        fuehle_comboboxen()
        KlinsCbx.SelectedIndex = -1
        TipiCbx.SelectedIndex = -1
        'KlinsCbx.SelectedIndex = 1
    End Sub
    Private Sub zeig_allotmentB_felder()
        Dim Button2 As New Button
        'Dim EtiketaLbl As New Label

        Dim i, j As Int16
        Dim locx, locy, stepx As Int16

        locx = 100
        locy = 30


        stepx = 30
        For i = 1 To 31
            Dim ImeroLbl As New Label
            ImeroLbl.TextAlign = ContentAlignment.MiddleCenter
            ImeroLbl.Size = New Point(30, 30)
            'Me.SplitContainer1.Panel2.Controls.Add(ImeroLbl)
            Me.AllotmBPnl.Controls.Add(ImeroLbl)
            ImeroLbl.Location = New Point(locx + (i - 1) * stepx, locy - stepx) '(locx + (i - 1) * stepx, locy)
            ImeroLbl.Text = i
            ImeroLbl.ForeColor = Color.Blue
            'ImeroLbl.Font.Height0
        Next
        For j = firstdatum.Date.Month To lastdatum.Date.Month

            Dim MinasLbl As New Label
            MinasLbl.TextAlign = ContentAlignment.BottomCenter

            MinasLbl.Size = New Point(100, 30)
            'Me.SplitContainer1.Panel2.Controls.Add(MinasLbl)
            Me.AllotmBPnl.Controls.Add(MinasLbl)
            MinasLbl.Location = New Point(1, locy - 15)
            MinasLbl.Text = get_minas(j)
            locy = locy + stepx

            'MinasLbl.Text = i
            MinasLbl.ForeColor = Color.Blue
        Next
        locx = 100
        locy = 30
        'locx = 100

        'locy = EtiketaLbl.Height + Allotm1Pnl.Height + 70
        For j = firstdatum.Date.Month To lastdatum.Date.Month

            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then

                    Exit For
                End If
                If (Not j = firstdatum.Date.Month Or Not i < firstdatum.Date.Day) And
                (Not j = lastdatum.Date.Month Or Not i > lastdatum.Date.Day) Then
                    Dim Txtbx As New TextBox
                    Txtbx.MaxLength = 3
                    Txtbx.TextAlign = HorizontalAlignment.Center
                    If i Mod 2 = 0 Then
                        Txtbx.BackColor = Color.Bisque
                    End If
                    Txtbx.Name = "Txtbx" + i.ToString + "_" + j.ToString
                    'MsgBox(Txtbx.Name)
                    Txtbx.Size = New Point(30, 30)
                    'Me.SplitContainer1.Panel2.Controls.Add(Txtbx)
                    Me.AllotmBPnl.Controls.Add(Txtbx)
                    Txtbx.Location = New Point(locx + (i - 1) * stepx, locy)
                    If allotm(i - 1, j - 1) = -1 Then
                        Txtbx.Text = 0
                    Else
                        Txtbx.Text = allotm(i - 1, j - 1)
                    End If

                    If Txtbx.Text <> 0 Then
                        Txtbx.ForeColor = Color.Red
                    End If

                    'allotm(i - 1, j - 1) = -1

                    AddHandler Txtbx.Leave, AddressOf TextBox_Leave
                    AddHandler Txtbx.KeyPress, AddressOf TextBox_KeyPress
                End If

            Next
            locy = locy + stepx
        Next

        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        'SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10))
        SpeicherButton.Location = New Point(AllotmBPnl.Width / 2 - 80, locy)
        AllotmBPnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf allotmetB_speichern   'MsgBox(allotm(29, 3))

    End Sub
    Private Sub allotmetB_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j, index, k1, k2 As Int16
        Dim currentanzahl As Integer = 0
        Dim punkt As feld
        Dim ende As Boolean = False
        Dim periodoiallotm() As AllotmPeriod
        'ReDim Preserve 

        index = 0
        For j = firstdatum.Date.Month To lastdatum.Date.Month
            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                    Exit For
                End If
                If (Not j = firstdatum.Date.Month Or Not i < firstdatum.Date.Day) And
                (Not j = lastdatum.Date.Month Or Not i > lastdatum.Date.Day) Then
                    If allotm(i - 1, j - 1) <> -1 Then
                        If allotm(i - 1, j - 1) <> currentanzahl Then
                            punkt = return_wechselanzahl_feld(i, j, currentanzahl)
                            If punkt.i = -1 Or punkt.j = -1 Then
                                ende = True
                                Exit For
                            End If

                            ReDim Preserve periodoiallotm(index)
                            index = index + 1
                            periodoiallotm(index - 1).apo = "#" + punkt.i.ToString + "/" + punkt.j.ToString + "/" + etos.ToString + "#"
                            periodoiallotm(index - 1).anzahl = allotm(punkt.i - 1, punkt.j - 1)
                            'MsgBox(periodoiallotm(index - 1).apo)
                            currentanzahl = periodoiallotm(index - 1).anzahl

                            i = punkt.i
                            j = punkt.j
                        End If
                    End If
                End If
            Next
            If ende Then
                Exit For
            End If
        Next

        Try
            For i = 0 To periodoiallotm.Length - 1
                If i <> periodoiallotm.Length - 1 Then
                    periodoiallotm(i).mexri = periodoiallotm(i + 1).apo.AddDays(-1)
                Else
                    periodoiallotm(i).mexri = lastdatum
                End If
            Next
        Catch ex As NullReferenceException
            Exit Sub
        End Try
        'For i = 0 To periodoiallotm.Length - 1
        '    MsgBox(periodoiallotm(i).apo)
        'Next

        'MsgBox(Me.DbhotelDataSet.allotment.Count)
        'MsgBox(periodoiallotm.Length)
        Try
            If Me.DbhotelDataSet.allotment.Count <= periodoiallotm.Length Then
                For k1 = 0 To Me.DbhotelDataSet.allotment.Count - 1
                    If k1 <> periodoiallotm.Length - 1 Then
                        Me.AllotmentTableAdapter.UpdateAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k1).apo, periodoiallotm(k1 + 1).apo.AddDays(-1), periodoiallotm(k1).anzahl, GuaraRB.Checked, Me.DbhotelDataSet.allotment(k1).kwd)
                    Else

                        Me.AllotmentTableAdapter.UpdateAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k1).apo, lastdatum, periodoiallotm(k1).anzahl, GuaraRB.Checked, Me.DbhotelDataSet.allotment(k1).kwd)
                    End If
                Next
                For k2 = k1 To periodoiallotm.Length - 1
                    If k2 <> periodoiallotm.Length - 1 Then
                        Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, periodoiallotm(k2 + 1).apo.AddDays(-1), periodoiallotm(k2).anzahl, GuaraRB.Checked)
                    Else
                        Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, lastdatum, periodoiallotm(k2).anzahl, GuaraRB.Checked)
                    End If

                Next
            ElseIf Me.DbhotelDataSet.allotment.Count > periodoiallotm.Length Then
                For k1 = 0 To Me.DbhotelDataSet.allotment.Count - 1
                    Me.AllotmentTableAdapter.DeleteAllotm(Me.DbhotelDataSet.allotment(k1).kwd)
                Next
                For k2 = 0 To periodoiallotm.Length - 1
                    If k2 <> periodoiallotm.Length - 1 Then
                        Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, periodoiallotm(k2 + 1).apo.AddDays(-1), periodoiallotm(k2).anzahl, GuaraRB.Checked)
                    Else
                        Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, currentklines, currenttipos, periodoiallotm(k2).apo, lastdatum, periodoiallotm(k2).anzahl, GuaraRB.Checked)
                    End If
                Next
            End If
            Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
            MsgBox(" Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
        Catch ex As Exception
            MsgBox(" H Αποθήκευση απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
        End Try

    End Sub

    Private Function return_wechselanzahl_feld(ByVal mera As Int16, ByVal minas As Int16, ByVal anzahl As Integer) As feld
        Dim i, j As Int16
        Dim punkt As feld

        For j = minas To lastdatum.Date.Month
            For i = 1 To 31
                If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                    Exit For
                End If
                If (Not j = minas Or Not i < mera) Then
                    If allotm(i - 1, j - 1) <> anzahl Then
                        punkt.i = i
                        punkt.j = j
                        'MsgBox(punkt.i)
                        Return punkt
                    End If
                End If
            Next
        Next

        punkt.i = -1
        punkt.j = -1
        Return punkt
    End Function
    Private Sub lade_von_db_zu_allotm()
        Dim i, j, z As Int16

        Dim apomina, mexrimina As Int16

        For z = 0 To Me.DbhotelDataSet.allotment.Count - 1

            apomina = Me.DbhotelDataSet.allotment(z).apo.Date.Month
            'mexrimera = Me.DbhotelDataSet.allotment(z).mexri.Date.Day
            mexrimina = Me.DbhotelDataSet.allotment(z).mexri.Date.Month

            For j = Me.DbhotelDataSet.allotment(z).apo.Date.Month To Me.DbhotelDataSet.allotment(z).mexri.Date.Month
                For i = 1 To 31
                    If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                    OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then
                        Exit For
                    End If
                    If (Not j = Me.DbhotelDataSet.allotment(z).apo.Month Or Not i < Me.DbhotelDataSet.allotment(z).apo.Day) And
                                    (Not j = Me.DbhotelDataSet.allotment(z).mexri.Month Or Not i > Me.DbhotelDataSet.allotment(z).mexri.Day) Then

                        allotm(i - 1, j - 1) = Me.DbhotelDataSet.allotment(z).anzahl

                    End If
                Next
            Next
        Next
    End Sub
    Private Sub init_allotm()
        Dim i, j As Int16

        For j = 1 To 12
            For i = 1 To 31
                allotm(i - 1, j - 1) = 0
            Next
        Next


    End Sub
    Private Function get_minas(ByVal j As Int16) As String
        Select Case j
            Case 1
                Return "Ιανουάριος"
            Case 2
                Return "Φεβρουάριος"
            Case 3
                Return "Μάρτιος"
            Case 4
                Return "Απρίλιος"
            Case 5
                Return "Μαϊος"
            Case 6
                Return "Ιούνιος"
            Case 7
                Return "Ιούλιος"
            Case 8
                Return "Αύγουστος"
            Case 9
                Return "Σεπτέμβριος"
            Case 10
                Return "Οκτώβριος"
            Case 11
                Return "Νοέμβριος"
            Case 12
                Return "Δεκέμβριος"

        End Select
        Return ""
    End Function

    Private Function max_imerom(ByVal j As Integer) As Int16

        Dim i As Int16

        For i = 31 To 1 Step -1
            If (j = 2 And i = 31) OrElse (j = 2 And i = 30) OrElse (j = 4 And i = 31) _
                                                       OrElse (j = 6 And i = 31) OrElse (j = 9 And i = 31) OrElse (j = 11 And i = 31) Then

            Else
                Return i
            End If

        Next
        Return -1
    End Function
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim split As String() = sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5).Split(New [Char]() {"_"c})
        Dim value As Int16
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then ' Or

            Try

                If split(0) = 1 Then
                    Try
                        value = allotm(max_imerom(split(1) - 1) - 1, split(1) - 2)
                    Catch ex As IndexOutOfRangeException
                        Exit Sub
                    End Try
                    'edw CRASHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHh
                    If value <> 0 Then
                        sender.text = value
                        sender.forecolor = Color.Red
                    Else
                        sender.text = 0
                        sender.forecolor = Color.Black
                    End If

                Else
                    value = allotm(split(0) - 2, split(1) - 1)
                    If value <> 0 Then
                        sender.text = value
                        sender.forecolor = Color.Red
                    Else
                        sender.text = 0
                        sender.forecolor = Color.Black
                    End If
                End If


                'End If
            Catch ex As InvalidCastException

                sender.text = 0
                sender.forecolor = Color.Black
            End Try


        End If


    End Sub



    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) ' edw itan anzahl global definiert den katalaba giati -> to allaksa -> 
        Dim anzahl As Int16
        Dim split As String() = sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5).Split(New [Char]() {"_"c})
        Try

            If CType(sender.Text, Int16) > 0 Then
                If sender.text <> allotm(split(0) - 1, split(1) - 1) Then

                    If currentklines > 0 And currenttipos > 0 Then ' Manikis XY
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByKlinesTipos(currentklines, currenttipos)
                        'MsgBox(anzahl)
                        'MsgBox(sender.text)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε αυτήν την κατηγορία !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines > 0 And currenttipos = 0 Then
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByKlines(currentklines)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε Δωμάτια με αυτόν τον αριθμό κλινών ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos > 0 Then
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByTipos(currenttipos)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε αυτόν τον τύπο Δωματίου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos = 0 Then

                        anzahl = Me.KatigoriesTableAdapter.AnzahlBy()
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε Δωμάτια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If

                    End If
                End If
                allotm(split(0) - 1, split(1) - 1) = sender.text
                sender.forecolor = Color.Red
            Else

                sender.Text = 0
                sender.forecolor = Color.Black
                allotm(split(0) - 1, split(1) - 1) = 0
            End If
        Catch ex As InvalidCastException
            sender.Text = 0
            allotm(split(0) - 1, split(1) - 1) = 0
            'MsgBox(sender.name)
        End Try



    End Sub
    'ALLOTMENT A tropos___ALLOTMENT A tropos-------ALLOTMENT A tropos------------ALLOTMENT A tropos------ALLOTMENT A tropos-------
    'ALLOTMENT A tropos___ALLOTMENT A tropos-------ALLOTMENT A tropos------------ALLOTMENT A tropos------ALLOTMENT A tropos-------
    'ALLOTMENT A tropos___ALLOTMENT A tropos-------ALLOTMENT A tropos------------ALLOTMENT A tropos------ALLOTMENT A tropos-------
    'ALLOTMENT A tropos___ALLOTMENT A tropos-------ALLOTMENT A tropos------------ALLOTMENT A tropos------ALLOTMENT A tropos-------
    'ALLOTMENT A tropos___ALLOTMENT A tropos-------ALLOTMENT A tropos------------ALLOTMENT A tropos------ALLOTMENT A tropos-------
    Private Sub allotment_a()
        Dim locx, locy As Int16
        'Dim InfoLbl As New Label
        praktoreiokwd = Nothing
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10
        allotmstatus = 1

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ALLOTMENT ΠΡΑΚΤΟΡΕΙΩΝ A' ΤΡΟΠΟΣ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 220, 25)
        HauptPnl.Controls.Add(Allotm1Pnl)
        Allotm1Pnl.Size = New Point(Me.HauptPnl.Width - 30, HauptPnl.Height - EtiketaPnl.Height - 30)
        Allotm1Pnl.Location = New Point(5, EtiketaPnl.Height + 5)
        PraktTbx.Text = " <Κάνετε κλίκ εδώ> "
        fuehle_comboboxen()

        KlinsCbx.SelectedIndex = -1
        TipiCbx.SelectedIndex = -1
    End Sub
    Private Function get_index_klines(ByVal kwdikos As Integer) As Int16
        Dim i As Integer

        For i = 0 To Me.DbhotelDataSet.klines.Count - 1
            If Me.DbhotelDataSet.klines(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Function get_index_tipos(ByVal kwdikos As Integer) As Int16
        Dim i As Integer

        For i = 0 To Me.DbhotelDataSet.tipoi.Count - 1
            If Me.DbhotelDataSet.tipoi(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub fuehle_comboboxen()
        Dim j As Int16

        KlinsCbx.Items.Clear()


        For j = 0 To Me.DbhotelDataSet.klines.Count
            If j <> 0 Then
                KlinsCbx.Items.Add(Me.DbhotelDataSet.klines(j - 1).perigrafi)
            Else
                KlinsCbx.Items.Add("Όλες")
            End If
        Next
        TipiCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet.tipoi.Count
            If j <> 0 Then
                TipiCbx.Items.Add(Me.DbhotelDataSet.tipoi(j - 1).tipos)
            Else
                TipiCbx.Items.Add("Όλοι")
            End If
        Next
        If currentklines <> 0 Then ' sto prwto laden den einai gesetzt->produziert fehler
            KlinsCbx.SelectedIndex = get_index_klines(currentklines) + 1
        End If
        If currenttipos <> 0 Then
            TipiCbx.SelectedIndex = get_index_tipos(currenttipos) + 1
        End If

    End Sub
    Private Sub PraktTbx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktTbx.Click
        PraktTbx_Enter(sender, e)
    End Sub

    Private Sub PraktTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen


        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            PraktTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
            ArxiTbx.Focus()
            AASimbPnl.Controls.Clear()
            Allotm2Pnl.Hide()
            Exit Sub
        End If
        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)

        PraktTbx.Text = PraktForm.return_praktoreio

        PraktForm.Dispose()

        simbol_radiobuttons_zeig(0, 2, False, allotmstatus) 'Me.PraktoreioTbx.Location.X, Label21.Location.Y - 5

        KlinsCbx.SelectedIndex = -1
        TipiCbx.SelectedIndex = -1
        'klines_changed()

        'GuaraRB.Enabled = False
        'AllotmRB.Enabled = False
    End Sub

    Private Sub simbol_radiobuttons_zeig(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean, ByVal allotropos As Byte)
        Dim Erstesbuttn As New RadioButton
        Dim line As Int16 = 0
        Dim i, k As Int16
        Dim InfoLbl As New Label
        k = -1
        AASimbPnl.Controls.Clear() ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...
        For i = 0 To Me.DbhotelDataSet.simbolaia.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 70
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleRight
            AASimbPnl.Controls.Add(AArdbuttn)
            AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.simbolaia(i).kwd.ToString
            If i = Me.DbhotelDataSet.simbolaia.Count - 1 AndAlso remalen Then
                AArdbuttn.Checked = True
            End If
            AArdbuttn.Text = Me.DbhotelDataSet.simbolaia(i).aasimbolaiou
            If i Mod 4 = 0 Then
                line = line + 20
                k = 0
            Else
                k = k + 1
            End If

            AArdbuttn.Location = New Point(x + k * AArdbuttn.Width + 5, y + line - 20)
            If i = 0 Then
                Erstesbuttn = AArdbuttn
            End If
            AddHandler AArdbuttn.CheckedChanged, AddressOf RdButton_CheckedChanged
        Next
        Erstesbuttn.Checked = True ' Proepilogi to 1o simbolaio is checked!
        If allotmstatus = 1 Then
            InfoLbl.Size = New Point(Allotm2Pnl.Width - 10, 220)
            'InfoLbl.Text = "< Για κάθε Πρακτορείο η κράτηση μίας κατηγορίας Δωματίων αποκλείει την χρήση όλων των άλλων. Εάν π.χ. επιλεγεί 'ολοι οι τύποι', τότε ΔΕΝ μπορεί να γίνει έπειτα νέα κράτηση για ένα μόνο συγκεκριμένο τύπο Δωματίου (για τον επιλεγμένο αριθμό κλινών). Π.χ. επιλογή (δίκλινα,ολοι) εμπεριέχει όλους τους τύπους δωματίων με 2 κρεβάτια. Επιλογή (ολες,ολοι) εμπεριέχει ολους τους τύπους αναξαρτήτως κλινών" & vbCrLf & " Επιλέξτε έπειτα allotment ή guaranti σύμφωνα με τον τύπο του συμβολαίου μαρκάρωντας το κυκλάκι " & vbCrLf & " Εισάγετε μετά Ημερομηνίες και πλήθος Δωματίων ! Το πρόγραμμα ΔΕΝ επιτρέπει την εισαγωγή Ημερ/νιών εκτός ορίων συμβολαίου (Για διαγραφή μιας Ημερ/νίας απλώς σβήστε το πλήθος Δωματίων ώστε το αντίστοιχο κουτάκι δεξιά να είναι κενό. Για Δαγραφή ΟΛΩΝ των Ημερ/νιών κλίκ στο κουμπί της Διαγραφής) Οριστική επικύρωση των αλλαγών ΜΟΝΟ έπειτα από απλό κλίκ στο κουμπάκι της Αποθήκευσης !>"
            InfoLbl.Text = "< Η Επιλογή 'ολες οι κλίνες' εμπεριέχει όλες τις επιμέρους κλίνες (μονόκλινα, δικλινα κ.τ.λ.) έτσι ώστε σε περίπτωση ίδιου Allotment για ολες τις κλίνες (για έναν συγκεκριμένο τύπο-θέα), να μην χρειάζεται η εργασία να επαναληφθεί παρά μόνο μία φορά. Αντίστοιχα ισχύει το ίδιο και για την επιλογή 'ολοι οι τύποι' για έναν συγκεκριμένο αριθμό κρεβατιών >"
            InfoPnl.Controls.Add(InfoLbl)
            InfoLbl.Location = New Point(2, 2)
        End If

    End Sub

    Private Sub RdButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        'Dim split As String() = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3).Split(New [Char]() {"_"c})
        If allotmstatus = 1 Then
            Allotm3Pnl.Controls.Clear()
        Else
            AllotmBPnl.Controls.Clear()
        End If
        GuaraRB.Enabled = False
        AllotmRB.Enabled = False
        If sender.checked = True Then
            Try

                simbolaiokwd = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
                Me.SimbolaiaTableAdapter.PerigrafiByKwd(Me.DbhotelDataSet.simbolaia, simbolaiokwd)

                SimbTxb.Text = Me.DbhotelDataSet.simbolaia(0).perigrafi
                Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)
                If Me.DbhotelDataSet.touristperiodoi.Count <> 0 Then
                    If Not pruefe_ob_touristikes_periodoi_richtig() Then
                        ArxiTbx.Focus()
                        AASimbPnl.Controls.Clear()
                        Allotm2Pnl.Hide()
                        MsgBox(" Υπάρχει Λάθος στις Τουριστικές Περιόδους: Ελέγξτε τα χρονικά όρια !", MsgBoxStyle.Critical, "winfo\nikEl.")
                        Exit Sub
                    End If
                End If
                firstdatum = Me.TouristperiodoiTableAdapter.PrwtoDatumBySimbolaio(simbolaiokwd)
                lastdatum = Me.TouristperiodoiTableAdapter.TeleutaioDatumBySimbolaio(simbolaiokwd)
                ArxiTbx.Text = firstdatum
                If allotmstatus = 1 Then
                    Allotm2Pnl.Location = New Point(7, 240)
                Else
                    Allotm2Pnl.Location = New Point(Allotm2Pnl.Width, 5)
                End If
                Allotm2Pnl.Show()
                If allotmstatus = 1 Then
                    Allotm3Pnl.Controls.Clear()
                Else
                    AllotmBPnl.Controls.Clear()
                End If
            Catch ex As InvalidCastException

            End Try


            'MsgBox(sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3))
        End If
    End Sub
    Private Sub SimbCbx_Update(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlinsCbx.TextUpdate, TipiCbx.TextUpdate

        MsgBox("Πατήστε το βελάκι δεξιά για επιλογή  !", MsgBoxStyle.Information, "winfo\nikEl.")
        sender.SelectedIndex = -1
    End Sub
    Private Sub KlinsCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlinsCbx.SelectedIndexChanged
        klines_changed()
    End Sub
    Private Sub klines_changed()
        Dim eintr As Int16
        Dim klines, tipos As Integer
        Dim count1, count2, count3 As Int16

        'Elegxw ean iparxei dilwmeni dinami gia tin katigoria dwmatiou [katigoria= 2er Tupel (klines,tipos)]
        If allotmstatus = 1 Then
            Allotm3Pnl.Controls.Clear()
        Else
            AllotmBPnl.Controls.Clear()
        End If
        'klines = get_kwd_klins(KlinsCbx.SelectedIndex)
        'tipos = get_kwd_tipos(TipiCbx.SelectedIndex)
        'MsgBox(klines)
        'MsgBox(tipos)


        If KlinsCbx.SelectedIndex <> -1 Then

            klines = get_kwd_klins(KlinsCbx.SelectedIndex)
            tipos = get_kwd_tipos(TipiCbx.SelectedIndex)
            If klines = -1 And tipos <> -1 Then
                klines = Nothing ' VORSICHT:Zuweisung NOTHING senan integer dinei 0 !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ElseIf klines <> -1 And tipos = -1 Then
                tipos = Nothing
            ElseIf klines = -1 And tipos = -1 Then
                klines = Nothing
                tipos = Nothing
            End If
            'MsgBox(klines)
            'MsgBox(tipos)

            If KlinsCbx.SelectedIndex > 0 And TipiCbx.SelectedIndex > 0 Then
                eintr = (Me.KatigoriesTableAdapter.ExistEintrag3(klines, tipos))
                If eintr = 0 Then
                    MsgBox("Δεν έχει δηλωθεί δύναμη για αυτόν τον τύπο Δωματίου: Ελέγξτε ξανά την Δυναμικότητα στους Παράμετρους της εφαρμογής!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    GuaraRB.Enabled = False
                    AllotmRB.Enabled = False
                Else 'XY => DEN UPARXOUN 0Y AND X0 and 00
                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, klines, 0, False)
                    count2 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, tipos, False)
                    count3 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, False)
                    If count1 = 0 And count2 = 0 And count3 = 0 Then
                        'GuaraRB.Enabled = False
                        AllotmRB.Enabled = True
                        'GuaraRB.Checked = False
                        AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        'GuaraRB.Enabled = False
                        AllotmRB.Enabled = False
                    End If
                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, klines, 0, True)
                    count2 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, tipos, True)
                    count3 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, True)
                    If count1 = 0 And count2 = 0 And count3 = 0 Then
                        GuaraRB.Enabled = True
                        'AllotmRB.Enabled = True
                        GuaraRB.Checked = False
                        'AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        GuaraRB.Enabled = False
                        'AllotmRB.Enabled = False
                    End If

                End If
            ElseIf TipiCbx.SelectedIndex > 0 And KlinsCbx.SelectedIndex = 0 Then '0Y=> DEN IPARXI 00 AND DEN YPARXEI iY OPOU i=OLES OI KLINES EKTOS TOU O('OLES')
                eintr = (Me.KatigoriesTableAdapter.ExistEintrag(get_kwd_tipos(TipiCbx.SelectedIndex)))
                If eintr = 0 Then
                    MsgBox("Δεν έχει δηλωθεί δύναμη για αυτόν τον τύπο Δωματίου: Ελέγξτε ξανά την Δυναμικότητα στους Παράμετρους της εφαρμογής!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    GuaraRB.Enabled = False
                    AllotmRB.Enabled = False
                Else
                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, 0)
                    count2 = Me.AllotmentTableAdapter.ExistKlinesBySimbolaio(simbolaiokwd, 0, tipos, 0)
                    If count1 = 0 And count2 = 0 Then
                        'GuaraRB.Enabled = True
                        AllotmRB.Enabled = True
                        'GuaraRB.Checked = False
                        AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        'GuaraRB.Enabled = False
                        AllotmRB.Enabled = False
                    End If

                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, 1)
                    count2 = Me.AllotmentTableAdapter.ExistKlinesBySimbolaio(simbolaiokwd, 0, tipos, 1)
                    If count1 = 0 And count2 = 0 Then
                        GuaraRB.Enabled = True
                        'AllotmRB.Enabled = True
                        GuaraRB.Checked = False
                        'AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        GuaraRB.Enabled = False
                        'AllotmRB.Enabled = False
                    End If
                End If
            ElseIf KlinsCbx.SelectedIndex > 0 And TipiCbx.SelectedIndex = 0 Then 'XO=> den iparxei 00 and den iparxei Xi opou I=oloi oi tipoi ektos 0
                eintr = (Me.KatigoriesTableAdapter.ExistEintrag2(get_kwd_klins(KlinsCbx.SelectedIndex)))
                If eintr = 0 Then
                    MsgBox("Δεν έχει δηλωθεί δύναμη για αυτόν τον τύπο Δωματίου: Ελέγξτε ξανά την Δυναμικότητα στους Παράμετρους της εφαρμογής!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    GuaraRB.Enabled = False
                    AllotmRB.Enabled = False
                Else
                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, 0)
                    count2 = Me.AllotmentTableAdapter.ExistTiposBySimbolaio(simbolaiokwd, 0, klines, 0)
                    If count1 = 0 And count2 = 0 Then
                        'GuaraRB.Enabled = True
                        AllotmRB.Enabled = True
                        'GuaraRB.Checked = False
                        AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        'GuaraRB.Enabled = False
                        AllotmRB.Enabled = False
                    End If
                    count1 = Me.AllotmentTableAdapter.ExistKlinesTiposBySimbolaio(simbolaiokwd, 0, 0, 1)
                    count2 = Me.AllotmentTableAdapter.ExistTiposBySimbolaio(simbolaiokwd, 0, klines, 1)
                    If count1 = 0 And count2 = 0 Then
                        GuaraRB.Enabled = True
                        'AllotmRB.Enabled = True
                        GuaraRB.Checked = False
                        'AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        GuaraRB.Enabled = False
                        'AllotmRB.Enabled = False
                    End If
                End If
            ElseIf KlinsCbx.SelectedIndex = -1 Or TipiCbx.SelectedIndex = -1 Then
                GuaraRB.Enabled = False
                AllotmRB.Enabled = False
            ElseIf KlinsCbx.SelectedIndex = 0 And TipiCbx.SelectedIndex = 0 Then 'OO=> den iparxei i klines (i<>0) kai den iparxei i tipos(i<>0)
                eintr = (Me.KatigoriesTableAdapter.ExistEintragUeberhaupt())
                If eintr = 0 Then
                    MsgBox("Δεν έχει δηλωθεί καμία απολύτως δύναμη : Εισάγετε πρώτα την Δυναμικότητα Δωματίων στους Παράμετρους της εφαρμογής!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    GuaraRB.Enabled = False
                    AllotmRB.Enabled = False
                Else
                    count1 = Me.AllotmentTableAdapter.ExistKlinesByOO(simbolaiokwd, 0, False)
                    count2 = Me.AllotmentTableAdapter.ExistTiposByOO(simbolaiokwd, 0, False)
                    If count1 = 0 And count2 = 0 Then
                        'GuaraRB.Enabled = True
                        AllotmRB.Enabled = True
                        'GuaraRB.Checked = False
                        AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        'GuaraRB.Enabled = False
                        AllotmRB.Enabled = False
                    End If
                    count1 = Me.AllotmentTableAdapter.ExistKlinesByOO(simbolaiokwd, klines, 1)
                    count2 = Me.AllotmentTableAdapter.ExistTiposByOO(simbolaiokwd, tipos, 1)
                    If count1 = 0 And count2 = 0 Then
                        GuaraRB.Enabled = True
                        'AllotmRB.Enabled = True
                        GuaraRB.Checked = False
                        'AllotmRB.Checked = False
                    Else
                        'MsgBox(" Έχει γίνει ήδη κράτηση: Δεν επιτρέπεται να γίνει νέα κράτηση (βλέπε κείμενο αριστερά κάτω) !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        GuaraRB.Enabled = False
                        'AllotmRB.Enabled = False
                    End If
                End If
            Else

                GuaraRB.Enabled = True
                AllotmRB.Enabled = True
                GuaraRB.Checked = False
                AllotmRB.Checked = False
            End If

        End If
    End Sub
    Private Function get_kwd_klins(ByVal index As Int16) As Integer

        Try
            Return Me.KlinesTableAdapter.GetKwdByPerigrafi(KlinsCbx.Items(index).ToString)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Sub TipiCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipiCbx.SelectedIndexChanged
        klines_changed() 'MsgBox(get_kwd_tipos(TipiCbx.SelectedIndex))
    End Sub
    Private Function get_kwd_tipos(ByVal index As Int16) As Integer

        Try
            Return Me.TipoiTableAdapter.GetKwdByTipo(TipiCbx.Items(index).ToString)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Sub GuaraRB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuaraRB.Click, AllotmRB.Click

        If allotmstatus = 1 Then
            Allotm3Pnl.Controls.Clear()
        Else
            AllotmBPnl.Controls.Clear()
            ReDim allotm(30, 11)
            init_allotm()
        End If


        'AllotmBPnl.Controls.Clear()
        If KlinsCbx.SelectedIndex <> -1 And TipiCbx.SelectedIndex <> -1 Then
            If KlinsCbx.SelectedIndex = 0 And TipiCbx.SelectedIndex = 0 Then '<=> 00 maniki->Aneksartitou arithmvn klinwn kai aneksartitou theas
                currentklines = 0
                currenttipos = 0
                Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
                'MsgBox(Me.DbhotelDataSet.allotment.Count)
                If Not pruefe_ob_allotment_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If
                If allotmstatus = 1 Then
                    Allotm3Pnl.Show()
                    zeig_allotmA_felder()
                Else

                    lade_von_db_zu_allotm()
                    zeig_allotmentB_felder()
                End If



            ElseIf KlinsCbx.SelectedIndex = 0 Then 'den to exei o manikis->oles oi klines gia enan tipo
                currentklines = 0
                currenttipos = get_kwd_tipos(TipiCbx.SelectedIndex)
                Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
                If Not pruefe_ob_allotment_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If
                If allotmstatus = 1 Then
                    Allotm3Pnl.Show()
                    zeig_allotmA_felder()
                Else

                    lade_von_db_zu_allotm()
                    zeig_allotmentB_felder()
                End If
            ElseIf TipiCbx.SelectedIndex = 0 Then 'sigkekrimens klines gia olous tipoys (MANIK: Dwmatia me sigkekrimeno arithmos klinwn anaksartitou theas)
                currentklines = get_kwd_klins(KlinsCbx.SelectedIndex)
                currenttipos = 0
                Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
                If Not pruefe_ob_allotment_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If
                If allotmstatus = 1 Then
                    Allotm3Pnl.Show()
                    zeig_allotmA_felder()
                Else

                    lade_von_db_zu_allotm()
                    zeig_allotmentB_felder()
                End If
            Else ' (MANIK: Dwmatia me sigkekrimeno arithmos klinwn kai sigkekrimenis theas XY)
                currentklines = get_kwd_klins(KlinsCbx.SelectedIndex)
                currenttipos = get_kwd_tipos(TipiCbx.SelectedIndex)
                Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
                If Not pruefe_ob_allotment_periodoi_richtig() Then
                    MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End If
                If allotmstatus = 1 Then
                    Allotm3Pnl.Show()
                    zeig_allotmA_felder()
                Else
                    ReDim allotm(30, 11)
                    init_allotm()
                    lade_von_db_zu_allotm()
                    zeig_allotmentB_felder()
                End If
            End If
        End If



    End Sub
    Private Sub zeig_allotmA_felder()
        Dim n As Int16 = 14
        Dim i, k As Int16
        Dim locx, locy As Int16



        locx = 3
        locy = 3

        If n <= Me.DbhotelDataSet.allotment.Count - 1 Then
            n = Me.DbhotelDataSet.allotment.Count - 1 + 3
        End If
        ReDim allotmentA(n)

        'Dim DeleteLbl As New Label
        'DeleteLbl.ForeColor = Color.Red
        'DeleteLbl.Text = "DELETE"
        'DeleteLbl.Width = 60
        'DeleteLbl.Height = 15
        'Allotm3Pnl.Controls.Add(DeleteLbl)

        'DeleteLbl.Location = New Point(1, locy)
        Dim ImerLbl As New Label

        ImerLbl.ForeColor = Color.Blue
        ImerLbl.Width = 120
        ImerLbl.Text = "Ημερομηνία από..."

        'SeasonLbl.Size = New Point(170, 20)
        ImerLbl.Location = New Point(locx + 20, locy)
        Allotm3Pnl.Controls.Add(ImerLbl)

        Dim DwmLbl As New Label

        DwmLbl.ForeColor = Color.Blue
        DwmLbl.Text = "Δωμάτια"
        DwmLbl.Width = 60

        DwmLbl.Location = New Point(locx + ImerLbl.Width + 110, locy)
        Allotm3Pnl.Controls.Add(DwmLbl)

        For i = 0 To Me.DbhotelDataSet.allotment.Count - 1
            'Dim DeleteChbx As New CheckBox

            'allotmentA(i).delete = False
            'DeleteChbx.Name = "Delet" + i.ToString
            'DeleteChbx.ForeColor = Color.Red
            ''DeleteChbx.Location = New Point(locx - 60, locy + 2 * PeriodosLbl.Height * (i + 1))
            'DeleteChbx.Width = 15


            Dim Datum As New DateTimePicker

            allotmentA(i).kwd = Me.DbhotelDataSet.allotment(i).kwd
            allotmentA(i).status = 1 '->UPDATE!
            Datum.Name = "Datum" + i.ToString
            Datum.Value = Me.DbhotelDataSet.allotment(i).apo
            Datum.Format = DateTimePickerFormat.Custom
            Datum.MinDate = firstdatum
            Datum.MaxDate = lastdatum
            Datum.CustomFormat = "dd /MMMM/yyyy"
            allotmentA(i).apo = Me.DbhotelDataSet.allotment(i).apo
            'AddHandler Datum.LostFocus, AddressOf Datum_Allotm_LostFocus
            AddHandler Datum.Enter, AddressOf Datum_Allotm_Enter
            AddHandler Datum.LostFocus, AddressOf Datum_Allotm_LostFocus


            Dim Anzhl As New TextBox

            Anzhl.Name = "Anzhl" + i.ToString
            Anzhl.MaxLength = 3
            Anzhl.TextAlign = HorizontalAlignment.Center
            Anzhl.Text = Me.DbhotelDataSet.allotment(i).anzahl
            allotmentA(i).anzahl = Anzhl.Text
            Anzhl.Size = New Point(40, Datum.Width)
            AddHandler Anzhl.Leave, AddressOf Anzhl_Allotm_Leave

            'Allotm3Pnl.Controls.Add(DeleteChbx)
            Allotm3Pnl.Controls.Add(Datum)
            Allotm3Pnl.Controls.Add(Anzhl)


            'DeleteChbx.Location = New Point(locx + 10, locy - 2 + ImerLbl.Height + i * (Datum.Height + 10))
            Datum.Location = New Point(locx + 20, locy + ImerLbl.Height + i * (Datum.Height + 10))
            Anzhl.Location = New Point(locx + 20 + Datum.Width + 20, locy + ImerLbl.Height + i * (Datum.Height + 10))

        Next

        For k = i To n
            'Dim DeleteChbx As New CheckBox

            'allotmentA(k).delete = False
            'DeleteChbx.Name = "Delet" + k.ToString
            'DeleteChbx.ForeColor = Color.Red
            ''DeleteChbx.Location = New Point(locx - 60, locy + 2 * PeriodosLbl.Height * (i + 1))
            'DeleteChbx.Width = 15
            'DeleteChbx.Enabled = False



            Dim Datum As New DateTimePicker

            'allotmentA(k).delete = False
            allotmentA(k).kwd = -1
            allotmentA(k).status = -1
            If k = 0 Then
                allotmentA(k).apo = firstdatum
                Datum.Value = firstdatum
            Else
                allotmentA(k).apo = lastdatum
                Datum.Value = lastdatum
            End If


            Datum.Name = "Datum" + k.ToString

            Datum.Format = DateTimePickerFormat.Custom
            Datum.MinDate = firstdatum
            Datum.MaxDate = lastdatum
            AddHandler Datum.Enter, AddressOf Datum_Allotm_Enter
            AddHandler Datum.LostFocus, AddressOf Datum_Allotm_LostFocus
            If k = 0 Then
                Datum.CustomFormat = "dd /MMMM/yyyy"
                allotmentA(k).apo = Datum.Value
            Else
                Datum.CustomFormat = " "
            End If
            If k <> i Then
                Datum.Enabled = False
            End If



            Dim Anzhl As New TextBox
            Anzhl.Name = "Anzhl" + k.ToString
            Anzhl.MaxLength = 3
            Anzhl.TextAlign = HorizontalAlignment.Center
            Anzhl.Size = New Point(40, Datum.Width)
            allotmentA(k).anzahl = -1
            If k <> 0 Then
                Anzhl.Enabled = False
            Else
                Anzhl.Enabled = True
            End If

            AddHandler Anzhl.Enter, AddressOf Anzhl_Allotm_Enter
            AddHandler Anzhl.Leave, AddressOf Anzhl_Allotm_Leave


            'Allotm3Pnl.Controls.Add(DeleteChbx)
            Allotm3Pnl.Controls.Add(Datum)
            Allotm3Pnl.Controls.Add(Anzhl)
            'DeleteChbx.Location = New Point(locx + 10, locy - 2 + ImerLbl.Height + k * (Datum.Height + 10))
            Datum.Location = New Point(locx + 20, locy + ImerLbl.Height + k * (Datum.Height + 10))
            Anzhl.Location = New Point(locx + 20 + Datum.Width + 20, locy + ImerLbl.Height + k * (Datum.Height + 10))

        Next

        Allotm3Pnl.Location = New Point(Allotm2Pnl.Width + 20, 5)
        Allotm3Pnl.Size = New Point(Allotm1Pnl.Width - Allotm2Pnl.Width - 80, Allotm1Pnl.Height)

        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        'SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10))
        SpeicherButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + k * (ImerLbl.Height + 10))
        Allotm3Pnl.Controls.Add(SpeicherButton)
        AddHandler SpeicherButton.Click, AddressOf allotmetA_speichern
        AddHandler SpeicherButton.Leave, AddressOf speicherbutton_next_tab

        Dim DeleteButton As New Button
        DeleteButton.BackColor = Color.Azure
        DeleteButton.ForeColor = Color.Maroon
        DeleteButton.Text = "Διαγραφή"
        DeleteButton.Size = New Point(140, 30)
        DeleteButton.Cursor = Cursors.Hand
        DeleteButton.Location = New Point(Allotm3Pnl.Width / 2 - 80, locy + ImerLbl.Height + k * (ImerLbl.Height + 10) + SpeicherButton.Height)
        Allotm3Pnl.Controls.Add(DeleteButton)

        AddHandler DeleteButton.Click, AddressOf allotmetA_delete
    End Sub

    Private Sub allotmetA_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'PROSOXI-> stin DB to sto allotment den iparxei elegxo ean ta felder tou( klines,tipos) existrieren sta antistoixa Tables=> ean einai OLES 
        'oi klines i tipoi Tote sto allotment ta felder exoun 0! 

        Dim i, counter1 As Int16
        Dim klines, tipos As Integer


        klines = get_kwd_klins(KlinsCbx.SelectedIndex)
        tipos = get_kwd_tipos(TipiCbx.SelectedIndex)

        If klines = -1 And tipos <> -1 Then
            klines = Nothing ' VORSICHT:Zuweisung NOTHING senan integer dinei 0 !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        ElseIf klines <> -1 And tipos = -1 Then
            tipos = Nothing
        ElseIf klines = -1 And tipos = -1 Then
            klines = Nothing
            tipos = Nothing
        End If


        If alles_ok() Then 'teleutaios elegxos prin tin apothikeusi

            For i = 0 To allotmentA.Length - 1

                If allotmentA(i).anzahl <> -1 Then ' dh anzahl feld ist belegt (dwmatia)
                    counter1 = find_next_aktive_allotm(i)
                    If counter1 <> -1 Then '(oxi to teleuetaio)
                        If allotmentA(i).status = 2 Then 'Insert
                            Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, klines, tipos, allotmentA(i).apo, allotmentA(counter1).apo.AddDays(-1), allotmentA(i).anzahl, GuaraRB.Checked)
                        ElseIf allotmentA(i).status = 1 Then 'uPDATe
                            Me.AllotmentTableAdapter.UpdateAllotm(simbolaiokwd, klines, tipos, allotmentA(i).apo, allotmentA(counter1).apo.AddDays(-1), allotmentA(i).anzahl, GuaraRB.Checked, allotmentA(i).kwd)
                        End If
                    ElseIf counter1 = -1 Then
                        If allotmentA(i).status = 1 Then 'uPDATE
                            Me.AllotmentTableAdapter.UpdateAllotm(simbolaiokwd, klines, tipos, allotmentA(i).apo, lastdatum, allotmentA(i).anzahl, GuaraRB.Checked, allotmentA(i).kwd)
                        Else
                            Me.AllotmentTableAdapter.InsertAllotm(simbolaiokwd, klines, tipos, allotmentA(i).apo, lastdatum, allotmentA(i).anzahl, GuaraRB.Checked)
                        End If
                    End If
                Else 'to feld anzahl exei sbistei=> delete 
                    If allotmentA(i).status = 1 Then ' den mporei naeinai allo ektos apo 1( an itan 2 -> Insert (neo) feld me sbismeno anzahl=> NICHT beruecksichtigen!
                        Me.AllotmentTableAdapter.DeleteAllotm(allotmentA(i).kwd)
                    End If
                End If

            Next
        Else
            MsgBox(" H Αποθήκευση απέτυχε !", MsgBoxStyle.Critical, "winfo\nikEl.")
            Exit Sub
        End If

        Allotm3Pnl.Controls.Clear()
        Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
        zeig_allotmA_felder()
        MsgBox(" Επιτυχής Αποθήκευση !", MsgBoxStyle.Information, "winfo\nikEl.")
    End Sub
    Private Sub allotmetA_delete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Int16
        Dim response As MsgBoxResult

        If es_gibt_felder_to_delete() Then
            response = MsgBox("Να Διαγραφούν όλες οι καταχωρίσεις (Ημερ/νίες, Πλήθος Δωματίων) για την συγκεκριμένη κατηγορία;  ", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                For i = 0 To allotmentA.Length - 1
                    If allotmentA(i).kwd <> -1 Then
                        Me.AllotmentTableAdapter.DeleteAllotm(allotmentA(i).kwd)
                    End If
                Next
            Else
                Exit Sub
            End If
            Allotm3Pnl.Controls.Clear()
            Me.AllotmentTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet.allotment, simbolaiokwd, currentklines, currenttipos, GuaraRB.Checked)
            zeig_allotmA_felder()
        End If
    End Sub
    Private Function es_gibt_felder_to_delete() As Boolean
        Dim i As Int16
        For i = 0 To allotmentA.Length - 1
            If allotmentA(i).kwd <> -1 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub speicherbutton_next_tab(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Allotm3Pnl.Focus()


    End Sub


    Private Sub Datum_Allotm_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k, index, index1 As Int16

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        If sender.value <> allotmentA(k).apo Then 'alakse kati???

            index = find_last_aktive_allotm(k)

            If index <> -1 AndAlso allotmentA(index).apo < sender.value Then 'meta to prwto
                index = find_next_aktive_allotm(k)
                If index = -1 OrElse allotmentA(index).apo > sender.value Then
                    If sender.value <= lastdatum Then
                        allotmentA(k).apo = sender.text
                        If allotmentA(k).status = -1 Then
                            allotmentA(k).status = 2
                        End If
                    Else
                        MsgBox("Η Ημερομηνία είναι εκτός ορίων συμβολαίου (" + lastdatum + ")!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        sender.value = lastdatum
                        allotmentA(k).apo = sender.value
                        If allotmentA(k).status = -1 Then
                            allotmentA(k).status = 2
                        End If
                    End If

                ElseIf allotmentA(index).apo <= sender.value Then
                    MsgBox("Επικάλυψης περιόδων1 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    sender.value = allotmentA(k).apo
                End If
            ElseIf index = -1 Then
                If sender.value >= firstdatum Then
                    index1 = find_next_aktive_allotm(k)
                    If index1 <> -1 Then
                        If sender.value < allotmentA(index1).apo Then
                            allotmentA(k).apo = sender.value
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        Else
                            MsgBox("Επικάλυψης περιόδων2 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.value = allotmentA(k).apo
                        End If
                    Else 'edw allagh
                        If sender.value <= lastdatum Then
                            allotmentA(k).apo = sender.value
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        Else
                            MsgBox("Η Ημερομηνία είναι εκτός ορίων συμβολαίου (" + lastdatum + ")!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.value = lastdatum
                            allotmentA(k).apo = sender.value
                            If allotmentA(k).status = -1 Then
                                allotmentA(k).status = 2
                            End If
                        End If
                        'allotmentA(k).apo = sender.text
                        'If allotmentA(k).status = -1 Then
                        '    allotmentA(k).status = 2
                        'End If
                    End If
                Else
                    MsgBox("Η αρχική Συμφωνία με το συγκεκριμένο Πρακτορείο εχεί οριστεί για μεταγενέστερο χρόνο (βλ. Αρχή Season): " + firstdatum, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    sender.value = firstdatum
                    allotmentA(k).apo = sender.value
                    If allotmentA(k).status = -1 Then
                        allotmentA(k).status = 2
                    End If
                End If
            ElseIf allotmentA(index).apo >= sender.value Then
                MsgBox("Επικάλυψης περιόδων3 !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                If allotmentA(k).apo > allotmentA(index).apo Then
                    sender.value = allotmentA(k).apo
                Else
                    sender.value = allotmentA(index).apo.AddDays(1)
                    allotmentA(k).apo = sender.value
                End If

            End If


        End If


    End Sub
    Private Function alles_ok() As Boolean
        Dim i As Int16
        Dim counter1 As Int16

        'MsgBox(periodoi(0).mexri)
        For i = 0 To allotmentA.Length - 1
            If allotmentA(i).anzahl <> -1 Then
                counter1 = find_next_aktive_allotm(i)
                If counter1 <> -1 Then
                    If allotmentA(counter1).anzahl <> -1 Then
                        If allotmentA(counter1).apo <= allotmentA(i).apo Then
                            Return False
                        End If
                    End If
                End If
            End If
        Next
        Return True

    End Function

    Private Function find_last_aktive_allotm(ByVal index As Int16) As Int16
        Dim i As Int16

        For i = index - 1 To 0 Step -1
            If allotmentA(i).status <> -1 And allotmentA(i).anzahl <> -1 Then
                Return i
            End If
        Next
        Return -1

    End Function
    Private Function find_next_aktive_allotm(ByVal index As Int16) As Int16
        Dim i As Int16

        For i = index + 1 To allotmentA.Length - 1

            If allotmentA(i).status <> -1 AndAlso allotmentA(i).anzahl <> -1 Then
                Return i
            End If
        Next
        Return -1

    End Function
    Private Sub Anzhl_Allotm_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) '
        Dim k, index1, index2, anzahl As Int16

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        Try
            If CType(sender.text, Int16) >= 0 Then

                If sender.text <> allotmentA(k).anzahl Then

                    If currentklines > 0 And currenttipos > 0 Then ' Manikis XY
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByKlinesTipos(currentklines, currenttipos)
                        'MsgBox(anzahl)
                        'MsgBox(sender.text)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε αυτήν την κατηγορία !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines > 0 And currenttipos = 0 Then
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByKlines(currentklines)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε Δωμάτια με αυτόν τον αριθμό κλινών ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos > 0 Then
                        anzahl = Me.KatigoriesTableAdapter.AnzahlByTipos(currenttipos)
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε αυτόν τον τύπο Δωματίου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If
                    ElseIf currentklines = 0 And currenttipos = 0 Then

                        anzahl = Me.KatigoriesTableAdapter.AnzahlBy()
                        If sender.text > anzahl Then
                            MsgBox(" Τα Δωμάτια που δώσατε είναι πιο πολλά απο την συνολική δύναμη (" + anzahl.ToString + ") του Ξενοδοχείου σε Δωμάτια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.text = anzahl
                        End If

                    End If
                    index1 = find_last_aktive_allotm(k)
                    index2 = find_next_aktive_allotm(k)
                    If index1 <> -1 Then
                        If allotmentA(index1).anzahl = sender.text Then
                            MsgBox(" Το πλήθος Δωματίων που δώσατε είναι το ίδιο με αυτό της προηγούμενης περιόδου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.clear()
                            allotmentA(k).anzahl = -1
                            Exit Sub

                        End If
                    End If
                    If index2 <> -1 Then
                        If allotmentA(index2).anzahl = sender.text Then
                            MsgBox(" Το πλήθος Δωματίων που δώσατε είναι το ίδιο με αυτό της επόμενης περιόδου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.clear()
                            allotmentA(k).anzahl = -1
                            Exit Sub
                        End If
                    End If
                    allotmentA(k).anzahl = sender.text

                    If allotmentA(k).status = -1 Then 'ean Neo
                        allotmentA(k).status = 2 'Insert
                    End If

                End If
            Else
                sender.clear()
                allotmentA(k).anzahl = -1
            End If

        Catch ex As InvalidCastException
            sender.clear()
            allotmentA(k).anzahl = -1

        End Try
    End Sub
    Private Sub Anzhl_Allotm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) 'ENERGOPOIEI to epomeno Datum
        Dim k As Int16
        Dim find() As Object

        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString
        find = Allotm3Pnl.Controls.Find("Datum" + (k + 1).ToString, False)
        Try
            find(0).enabled = True

        Catch ex As Exception

        End Try

    End Sub
    'Energopoiei da DatumPicker
    Private Sub Datum_Allotm_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim k As Int16
        Dim find() As Object


        k = (sender.NAME.ToString.Substring(5, sender.NAME.ToString.Length - 5)).ToString

        If sender.value = lastdatum Then
            If k <> 0 AndAlso allotmentA(k - 1).apo <> lastdatum Then
                If allotmentA(k - 1).status <> -1 AndAlso allotmentA(k - 1).anzahl <> -1 Then 'ean einai to prwto(insert) i ean to proigoumeno exei oloklirothei->to staus tou demn einai -1!
                    If k > Me.DbhotelDataSet.allotment.Count - 1 Then  ' Einai neo Feld

                        find = Allotm3Pnl.Controls.Find("Datum" + k.ToString, False)
                        Try
                            find(0).CustomFormat = "dd /MMMM/yyyy"
                            'find(0).value = allotmentA(k - 1).apo.Date.AddDays(1)
                            find(0).value = lastdatum
                        Catch ex As IndexOutOfRangeException

                        End Try
                        find = Allotm3Pnl.Controls.Find("Anzhl" + k.ToString, False)
                        Try

                            find(0).enabled = True
                        Catch ex As IndexOutOfRangeException

                        End Try
                    End If
                End If
            End If
        End If



    End Sub

    Private Function pruefe_ob_allotment_periodoi_richtig() As Boolean
        Dim startIndex As Int16
        Dim istOK As Boolean = True

        Do Until startIndex > Me.DbhotelDataSet.allotment.Count - 1
            'posa eintraege 
            'firstIndex = startIndex
            If startIndex < Me.DbhotelDataSet.allotment.Count - 1 Then
                'gia kathemia kRatisi
                While Me.DbhotelDataSet.allotment(startIndex).mexri.AddDays(1) = Me.DbhotelDataSet.allotment(startIndex + 1).apo
                    startIndex = startIndex + 1
                    If startIndex + 1 > Me.DbhotelDataSet.allotment.Count - 1 Then
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

    'touristikes PERIODOI-SYMBOLAIA------------------------------------------------------------------------------------------------------------------------

    Private Sub tourist_periodoi_zeig()
        Dim locx, locy As Int16
        praktoreiokwd = Nothing
        locx = 30
        locy = 2 * EtiketaLbl.Height + 10
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "ΤΟΥΡΙΣΤΙΚΕΣ ΠΕΡΙΟΔΟΙ"
        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 150, 25)
        'EtosSimbTbx.Text = etos

        SimbolaioPnl.Size = New Point(700, 370)

        SimbolaioPnl.Size = New Point(Me.HauptPnl.Width - 30, 180)
        SimbolaioPnl.Location = New Point(5, locy)

        AASimbolPnl.Location = New Point(PraktoreioTbx.Location.X, Label21.Location.Y - 5) 'Panel me ta RadioButtons me tous aa sumbolaiwn
        PraktoreioTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
        SimbolaioPnl.Controls.Add(AASimbolPnl)
        HauptPnl.Controls.Add(SimbolaioPnl)
    End Sub
    Private Sub PraktoreioTbx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktoreioTbx.Click
        PraktoreioTbx_Enter(sender, e)
    End Sub

    Private Sub PraktoreioTbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktoreioTbx.Enter
        Dim PraktForm As New SimbolaiaFrm()

        PraktForm.StartPosition = FormStartPosition.CenterScreen


        PraktForm.ShowDialog()
        praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        If praktoreiokwd = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            PraktoreioTbx.Text = "< Κάνετε απλό κλίκ εδώ πάνω >"
            PeriodoiPnl.Controls.Clear()
            AASimbolPnl.Controls.Clear()
            HauptPnl.Controls.Remove(PeriodoiPnl)
            SimbolaioTbx.Clear()
            SimbolaioTbx.Focus()
            Exit Sub
        End If

        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
        PraktoreioTbx.Text = PraktForm.return_praktoreio
        PraktForm.Dispose()
        PeriodoiPnl.Controls.Clear()
        HauptPnl.Controls.Remove(PeriodoiPnl)
        simbolaio_radiobuttons_zeig(0, 2, False) 'Me.PraktoreioTbx.Location.X, Label21.Location.Y - 5
        Me.PeriodoiPnl.Focus()





    End Sub

    Private Sub simbolaio_radiobuttons_zeig(ByVal x As Integer, ByVal y As Integer, ByVal remalen As Boolean)

        Dim i As Int16
        AASimbolPnl.Controls.Clear() ' Ta radiobuttons einai panw sto panel AASimbolPnl gia eukoloteri xrisi...
        'SimbolaioTbx.Clear()
        AASimbolPnl.AutoScroll = True
        For i = 0 To Me.DbhotelDataSet.simbolaia.Count - 1
            Dim AArdbuttn As New RadioButton
            AArdbuttn.Width = 70
            AArdbuttn.CheckAlign = ContentAlignment.MiddleRight
            AArdbuttn.TextAlign = ContentAlignment.MiddleRight
            AArdbuttn.Cursor = Cursors.Hand
            AASimbolPnl.Controls.Add(AArdbuttn)
            AArdbuttn.Name = "Rdb" + Me.DbhotelDataSet.simbolaia(i).kwd.ToString
            If i = Me.DbhotelDataSet.simbolaia.Count - 1 AndAlso remalen Then
                AArdbuttn.Checked = True
            End If
            AArdbuttn.Text = Me.DbhotelDataSet.simbolaia(i).aasimbolaiou
            AArdbuttn.Location = New Point(x + i * AArdbuttn.Width + 10, y)
            AddHandler AArdbuttn.Click, AddressOf RadioButton_Click

        Next
        Dim NEWbuttn As New RadioButton
        NEWbuttn.Width = 70
        NEWbuttn.CheckAlign = ContentAlignment.MiddleRight
        NEWbuttn.TextAlign = ContentAlignment.MiddleRight
        NEWbuttn.Cursor = Cursors.Hand
        AASimbolPnl.Controls.Add(NEWbuttn)
        NEWbuttn.Name = "Neu"

        NEWbuttn.Text = "Νέο"
        NEWbuttn.Location = New Point(x + i * NEWbuttn.Width + 10, y)
        AddHandler NEWbuttn.Click, AddressOf RadioButton_Click

    End Sub
    Private Sub RadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.Click

        'Dim split As String() = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3).Split(New [Char]() {"_"c})
        'MsgBox("kaligouals")
        If sender.checked = True Then
            Try

                simbolaiokwd = sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3)
                Me.SimbolaiaTableAdapter.PerigrafiByKwd(Me.DbhotelDataSet.simbolaia, simbolaiokwd)

                SimbolaioTbx.Text = Me.DbhotelDataSet.simbolaia(0).perigrafi
                Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)
                If Me.DbhotelDataSet.touristperiodoi.Count <> 0 Then
                    If Not pruefe_ob_touristikes_periodoi_richtig() Then
                        MsgBox(" Υπάρχει Λάθος στις χρονικές Περιόδους: Ελέγξτε τα όρια !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End If
                End If
                ReDim periodoi(0)
                PeriodoiPnl.Controls.Clear()
                HauptPnl.Controls.Remove(PeriodoiPnl)
                periodoi_felder_malen()

            Catch ex As InvalidCastException
                simbolaiokwd = -1
                SimbolaioTbx.Text = "< ΝΕΟ ΣΥΜΒΟΛΑΙΟ >"
                ReDim periodoi(0)
                Me.DbhotelDataSet.touristperiodoi.Clear()
                PeriodoiPnl.Controls.Clear()
                HauptPnl.Controls.Remove(PeriodoiPnl)
                SimbolaioTbx.Clear()
                periodoi_felder_malen()
            End Try

            'MsgBox(sender.NAME.ToString.Substring(3, sender.NAME.ToString.Length - 3))
        End If

    End Sub
    Private Sub periodoi_felder_malen()
        Dim n As Int16 = 10 'dinatotita eisagwgis mexri kai 11 periodoi
        Dim i, k As Int16
        Dim PeriodosLbl As New Label
        Dim locx, locy As Integer

        locx = 70
        locy = 45

        PeriodoiPnl.Width = EtiketaPnl.Width

        'se periptwsi pou exantlithoun oi 11 periodoi->+3!!!
        If n <= Me.DbhotelDataSet.touristperiodoi.Count - 1 Then
            n = n + 7
        End If
        ReDim periodoi(n)

        Dim DeleteLbl As New Label
        DeleteLbl.ForeColor = Color.Red
        DeleteLbl.Text = "DELETE"
        DeleteLbl.Height = 15

        DeleteLbl.Location = New Point(locx - 73, locy + 15)

        Dim InfLbl As New Label
        InfLbl.ForeColor = Color.Black
        InfLbl.Size = New Point(PeriodoiPnl.Width, 40)
        '(Δώστε το τέλος μιας Περιόδου->η αρχή (εκτός από την 1.) μπαίνει αυτόματα!)(καταχωρήσεων/αλλαγών/διαγραφών)- Επιλέξτε μετά οπωσδήποτε Season 
        InfLbl.Text = "<Καταχωρίστε Περίοδους - Διαγράψτε μία περίοδο κλικάρωντας το κουτάκι 'DELETE' αριστερά της. ΠΡΟΣΟΧΗ: Οριστική επικύρωση των αλλαγών γίνεται μετά από απλό κλίκ στο κουμπί της Αποθήκευσης κάτω>"

        InfLbl.Location = New Point(locx - 60, locy - PeriodosLbl.Height - 20)

        'PeriodosLbl.Width = 250
        PeriodosLbl.Height = 15
        PeriodosLbl.ForeColor = Color.Blue
        PeriodosLbl.Text = "ΠΕΡΙΟΔΟΣ"

        PeriodosLbl.Location = New Point(locx, locy)



        Dim SeasonLbl As New Label
        SeasonLbl.ForeColor = Color.Blue
        SeasonLbl.Text = "SEASON"
        'SeasonLbl.Size = New Point(170, 20)
        SeasonLbl.Location = New Point(6 * PeriodosLbl.Width - 30, locy)



        Dim RelPeriodLbl As New Label
        RelPeriodLbl.Location = New Point(7 * PeriodosLbl.Width - 30, locy)
        RelPeriodLbl.ForeColor = Color.Blue
        RelPeriodLbl.Size = New Point(200, 30)
        RelPeriodLbl.Text = "RELEASE PERIOD"


        PeriodoiPnl.Size = New Point(EtiketaPnl.Width, (DeleteLbl.Height + SeasonLbl.Height) + InfLbl.Height)
        PeriodoiPnl.Location = New Point(5, EtiketaPnl.Height + SimbolaioPnl.Height)

        For i = 0 To Me.DbhotelDataSet.touristperiodoi.Count - 1
            Dim DeleteChbx As New CheckBox
            Dim NumberLbl As New Label
            Dim Datum1, Datum2 As New DateTimePicker
            Dim AnzLbl As New Label
            Dim SeasCbx As New ComboBox
            Dim RelTbx As New TextBox
            'Dim SeasonSource As New BindingSource

            periodoi(i).belegt = True
            periodoi(i).delete = False

            NumberLbl.Name = "Numb" + i.ToString
            NumberLbl.ForeColor = Color.Blue
            NumberLbl.Width = 40
            NumberLbl.Text = "(" + (i + 1).ToString + ".)"
            NumberLbl.TextAlign = ContentAlignment.MiddleCenter

            NumberLbl.Location = New Point(locx - 40, locy + 2 * PeriodosLbl.Height * (i + 1))
            periodoi(i).kwd = Me.DbhotelDataSet.touristperiodoi(i).kwd

            DeleteChbx.Name = "Delt" + i.ToString
            DeleteChbx.ForeColor = Color.Red
            DeleteChbx.Location = New Point(locx - 60, locy + 2 * PeriodosLbl.Height * (i + 1))
            DeleteChbx.Width = 15

            AddHandler DeleteChbx.CheckedChanged, AddressOf delete_chkbx_CheckedChanged

            Datum1.Name = "Datm" + i.ToString + "_" + "1"
            Datum1.MinDate = "1/1/" + etos.ToString
            'Datum1.MaxDate = "31/12/" + etos.ToString

            Datum1.Value = Me.DbhotelDataSet.touristperiodoi(i).apo

            Datum1.Format = DateTimePickerFormat.Custom
            Datum1.CustomFormat = "dd /MMMM/yyyy"
            periodoi(i).apo = Me.DbhotelDataSet.touristperiodoi(i).apo.Date

            Datum1.Location = New Point(locx, locy + 2 * PeriodosLbl.Height * (i + 1))
            If i = 0 Then
                AddHandler Datum1.LostFocus, AddressOf Datum_LostFocus

                'AddHandler Datum1.ValueChanged, AddressOf Datum_value_valid
            Else
                Datum1.Enabled = False
            End If

            Datum2.Name = "Datm" + i.ToString + "_" + "2"
            Datum2.MinDate = "1/1/" + etos.ToString
            'Datum2.MaxDate = "31/12/" + etos.ToString
            Datum2.Value = Me.DbhotelDataSet.touristperiodoi(i).mexri
            Datum2.Format = DateTimePickerFormat.Custom
            Datum2.CustomFormat = "dd /MMMM/yyyy"

            periodoi(i).mexri = Me.DbhotelDataSet.touristperiodoi(i).mexri.Date

            Datum2.Location = New Point(locx + Datum1.Width + 20, locy + 2 * PeriodosLbl.Height * (i + 1))
            AddHandler Datum2.LostFocus, AddressOf Datum_LostFocus

            If i = Me.DbhotelDataSet.touristperiodoi.Count - 1 Then
                AddHandler Datum2.ValueChanged, AddressOf Datum_value_valid
            End If
            'AddHandler Datum2.ValueChanged, AddressOf Datum_value_valid

            AnzLbl.Name = "AnzT" + i.ToString
            AnzLbl.Width = 60
            AnzLbl.Text = (Datum2.Value.DayOfYear - Datum1.Value.DayOfYear).ToString + 1
            AnzLbl.TextAlign = ContentAlignment.MiddleCenter

            AnzLbl.Location = New Point(locx + Datum1.Width + Datum2.Width + 20, locy + 2 * PeriodosLbl.Height * (i + 1))

            If periodoi(i).mexri.Date.Year = periodoi(i).apo.Date.Year Then
                AnzLbl.Text = periodoi(i).mexri.Date.DayOfYear - periodoi(i).apo.Date.DayOfYear + 1
            ElseIf periodoi(i).mexri.Date.Year - periodoi(i).apo.Date.Year = 1 Then
                AnzLbl.Text = periodoi(i).mexri.Date.DayOfYear + (periodoi(i).mexri.Date.AddDays(-periodoi(i).mexri.Date.DayOfYear).DayOfYear - periodoi(i).apo.Date.DayOfYear) + 1
            Else
                AnzLbl.Text = "!"
            End If

            'SeasonSource.DataSource = Me.DbhotelDataSet.seasons
            Dim j As Int16
            For j = 0 To Me.DbhotelDataSet.seasons.Count - 1
                SeasCbx.Items.Add(Me.DbhotelDataSet.seasons(j).periodos)
            Next
            SeasCbx.Name = "SeaP" + i.ToString
            SeasCbx.SelectedIndex = get_index_season(Me.DbhotelDataSet.touristperiodoi(i).season)
            periodoi(i).season = SeasCbx.SelectedIndex

            SeasCbx.Location = New Point(6 * PeriodosLbl.Width - 50, locy + 2 * PeriodosLbl.Height * (i + 1))
            AddHandler SeasCbx.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged

            RelTbx.Name = "RelP" + i.ToString
            RelTbx.Text = Me.DbhotelDataSet.touristperiodoi(i).relperiod
            periodoi(i).release = Me.DbhotelDataSet.touristperiodoi(i).relperiod
            RelTbx.Width = 50
            RelTbx.MaxLength = 3

            RelTbx.Location = New Point(6 * PeriodosLbl.Width - 50 + SeasCbx.Width + 40, locy + 2 * PeriodosLbl.Height * (i + 1))
            AddHandler RelTbx.Leave, AddressOf RelPeriod_Leave

            PeriodoiPnl.Height = PeriodoiPnl.Height + Datum1.Height + 15

            PeriodoiPnl.Controls.Add(NumberLbl)
            PeriodoiPnl.Controls.Add(DeleteChbx)
            PeriodoiPnl.Controls.Add(Datum1)
            PeriodoiPnl.Controls.Add(Datum2)
            PeriodoiPnl.Controls.Add(AnzLbl)
            PeriodoiPnl.Controls.Add(SeasCbx)
            PeriodoiPnl.Controls.Add(RelTbx)
        Next


        For k = i To n 'Dimiourgia KENWN periodwn gia eisagwgi 
            Dim DeleteChbx As New CheckBox
            Dim NumberLbl As New Label
            Dim Datum1, Datum2 As New DateTimePicker
            Dim AnzLbl As New Label
            Dim SeasCbx As New ComboBox
            Dim RelTbx As New TextBox
            'Dim SeasonSource As New BindingSource

            periodoi(k).belegt = False
            periodoi(k).delete = False
            periodoi(k).kwd = -1

            NumberLbl.Name = "Numb" + k.ToString

            NumberLbl.ForeColor = Color.Blue
            NumberLbl.Width = 40
            NumberLbl.Text = "(" + (k + 1).ToString + ".)"
            NumberLbl.TextAlign = ContentAlignment.MiddleCenter

            NumberLbl.Location = New Point(locx - 40, locy + 2 * PeriodosLbl.Height * (k + 1))

            DeleteChbx.Name = "Delt" + k.ToString
            DeleteChbx.ForeColor = Color.Red
            DeleteChbx.Location = New Point(locx - 60, locy + 2 * PeriodosLbl.Height * (k + 1))
            DeleteChbx.Width = 15

            DeleteChbx.Enabled = False
            AddHandler DeleteChbx.CheckedChanged, AddressOf delete_chkbx_CheckedChanged


            Datum1.CustomFormat = " "

            Datum1.Format = DateTimePickerFormat.Custom
            Datum1.Name = "Datm" + k.ToString + "_" + "1"
            Datum1.MinDate = "1/1/" + etos.ToString
            'Datum1.MaxDate = "31/12/" + etos.ToString
            Datum1.Value = defaultdate
            periodoi(k).apo = defaultdate 'einai 1/1/1900 constant

            Datum1.Location = New Point(locx, locy + 2 * PeriodosLbl.Height * (k + 1))
            'AddHandler Datum1.Leave, AddressOf Datum_ValueLeave
            'AddHandler Datum1.Enter, AddressOf Datum_Enter
            If k = 0 Then
                Datum1.Enabled = True
                Datum1.MaxDate = "31/12/" + etos.ToString
                AddHandler Datum1.LostFocus, AddressOf Datum_LostFocus
                AddHandler Datum1.Enter, AddressOf Datum_Enter
            Else
                Datum1.TabStop = False
                Datum1.Enabled = False
            End If
            'AddHandler Datum1.ValueChanged, AddressOf DateTimePicker_ValueChanged

            Datum2.CustomFormat = " "
            Datum2.Format = DateTimePickerFormat.Custom
            Datum2.MinDate = "1/1/" + etos.ToString
            'Datum2.MaxDate = "31/12/" + etos.ToString
            Datum2.Value = defaultdate
            periodoi(k).mexri = defaultdate 'einai 1/1/1900 constant
            Datum2.Name = "Datm" + k.ToString + "_" + "2"

            Datum2.Location = New Point(locx + Datum1.Width + 20, locy + 2 * PeriodosLbl.Height * (k + 1))
            AddHandler Datum2.LostFocus, AddressOf Datum_LostFocus
            AddHandler Datum2.ValueChanged, AddressOf Datum_value_valid
            AddHandler Datum2.Enter, AddressOf Datum_Enter



            AnzLbl.Name = "AnzT" + k.ToString
            AnzLbl.Width = 60
            'AnzLbl.Text = (Datum2.Value.DayOfYear - Datum1.Value.DayOfYear).ToString
            AnzLbl.TextAlign = ContentAlignment.MiddleCenter

            AnzLbl.Location = New Point(locx + Datum1.Width + Datum2.Width + 20, locy + 2 * PeriodosLbl.Height * (k + 1))


            'SeasonSource.DataSource = Me.DbhotelDataSet.seasons
            Dim j As Int16
            For j = 0 To Me.DbhotelDataSet.seasons.Count - 1
                SeasCbx.Items.Add(Me.DbhotelDataSet.seasons(j).periodos)
            Next
            SeasCbx.Name = "SeaP" + k.ToString
            'periodoi(k).season = -1
            'SeasCbx.SelectedIndex = get_position_season(Me.DbhotelDataSet.touristperiodoi(i).season)

            SeasCbx.Location = New Point(6 * PeriodosLbl.Width - 50, locy + 2 * PeriodosLbl.Height * (k + 1))
            AddHandler SeasCbx.SelectedIndexChanged, AddressOf ComboBox_SelectedIndexChanged

            If k <> 0 Then
                SeasCbx.Enabled = False
            End If


            RelTbx.Name = "RelP" + k.ToString
            RelTbx.Width = 50
            RelTbx.MaxLength = 3
            RelTbx.Enabled = False


            RelTbx.Location = New Point(6 * PeriodosLbl.Width - 50 + SeasCbx.Width + 40, locy + 2 * PeriodosLbl.Height * (k + 1))
            AddHandler RelTbx.Leave, AddressOf RelPeriod_Leave


            PeriodoiPnl.Height = PeriodoiPnl.Height + Datum1.Height + 14
            PeriodoiPnl.Controls.Add(NumberLbl)
            PeriodoiPnl.Controls.Add(DeleteChbx)
            PeriodoiPnl.Controls.Add(Datum1)
            PeriodoiPnl.Controls.Add(Datum2)
            PeriodoiPnl.Controls.Add(AnzLbl)
            PeriodoiPnl.Controls.Add(SeasCbx)
            PeriodoiPnl.Controls.Add(RelTbx)
        Next
        Dim SpeicherButton As New Button
        SpeicherButton.BackColor = Color.Azure
        SpeicherButton.ForeColor = Color.Maroon
        SpeicherButton.Text = "Αποθήκευση"
        SpeicherButton.Size = New Point(140, 30)
        SpeicherButton.Cursor = Cursors.Hand
        SpeicherButton.Location = New Point(PeriodoiPnl.Width / 2 - 20, locy + 2 * PeriodosLbl.Height * (k + 1) + 10)
        PeriodoiPnl.Controls.Add(SpeicherButton)
        PeriodoiPnl.Controls.Add(DeleteLbl)
        PeriodoiPnl.Controls.Add(InfLbl)
        PeriodoiPnl.Controls.Add(PeriodosLbl)
        PeriodoiPnl.Controls.Add(SeasonLbl)
        PeriodoiPnl.Controls.Add(RelPeriodLbl)
        HauptPnl.Controls.Add(PeriodoiPnl)

        AddHandler SpeicherButton.Click, AddressOf periodoi_speichern
        AddHandler SpeicherButton.Leave, AddressOf speicherbtn_next_tab

    End Sub
    Private Sub Datum_value_valid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.value > "31/12/" + etos.ToString Then
            MsgBox("Λάθος Ημερομηνία !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            'sender.value = "31/12/" + etos.ToString
        End If
    End Sub
    Private Sub periodoi_speichern(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Int16
        Dim aa As Int16
        Dim count As Int16

        If final_kontrolle() Then 'kontrolarei min exei gieni kamia strabi kai iparxoun epikalipseis
            If simbolaiokwd = -1 Then ' Neo simbolaio
                Try
                    aa = Me.SimbolaiaTableAdapter.MaxAA(praktoreiokwd, etos) ' pairnw aa arirthmo
                    Me.SimbolaiaTableAdapter.InsertNeoSimbolaio((aa + 1), praktoreiokwd, etos, SimbolaioTbx.Text)
                    simbolaiokwd = Me.SimbolaiaTableAdapter.GetKwdByAaPraktEtos((aa + 1), praktoreiokwd, etos)
                    Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
                    simbolaio_radiobuttons_zeig(0, 2, True)
                Catch ex As InvalidOperationException
                    Me.SimbolaiaTableAdapter.InsertNeoSimbolaio(1, praktoreiokwd, etos, SimbolaioTbx.Text)
                    simbolaiokwd = Me.SimbolaiaTableAdapter.GetKwdByAaPraktEtos(1, praktoreiokwd, etos)
                    Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
                    simbolaio_radiobuttons_zeig(0, 2, True)
                End Try
            Else

                Me.SimbolaiaTableAdapter.UpdatePerigrafi(SimbolaioTbx.Text, simbolaiokwd)

            End If

            For i = 0 To periodoi.Length - 1

                Try
                    If periodoi(i).kwd = -1 And periodoi(i).belegt = True And periodoi(i).delete = False Then
                        count = Me.TouristperiodoiTableAdapter.InsertPeriodoi(simbolaiokwd, periodoi(i).apo, periodoi(i).mexri, get_kwd_season(periodoi(i).season), periodoi(i).release)
                    End If
                    If periodoi(i).kwd <> -1 And periodoi(i).belegt = True And periodoi(i).delete = False Then
                        count = Me.TouristperiodoiTableAdapter.UpdatePeriodoi(simbolaiokwd, periodoi(i).apo, periodoi(i).mexri, get_kwd_season(periodoi(i).season), periodoi(i).release, periodoi(i).kwd)
                    End If

                    If periodoi(i).kwd <> -1 And periodoi(i).delete = True Then
                        count = Me.TouristperiodoiTableAdapter.DeletePeriodoi(periodoi(i).kwd)
                    End If
                Catch ex As SqlException
                    count = 0
                    MsgBox(" Παρουσιάστηκε Πρόβλημα κατά τήν Αποθήκευση των Περιόδων!", MsgBoxStyle.Critical, "winfo\nikEl.")

                    Exit For
                End Try
            Next

            If (test_ob_alles_leer()) Then
                Try
                    Me.SimbolaiaTableAdapter.DeleteSimbolaio(simbolaiokwd)
                Catch ex As OleDb.OleDbException
                    'MsgBox("ΠΡΟΣΟΧΗ: Λόγω ύπαρξης Allotment η Διαγραφή δεν μπόρεσε να ολοκληρωθεί!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

                ReDim periodoi(0)
                Me.DbhotelDataSet.touristperiodoi.Clear()
                PeriodoiPnl.Controls.Clear()
                SimbolaioTbx.Clear()
                HauptPnl.Controls.Remove(PeriodoiPnl)
                Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, etos)
                simbolaio_radiobuttons_zeig(0, 2, False)
            Else
                Me.DbhotelDataSet.touristperiodoi.Clear()
                Me.TouristperiodoiTableAdapter.FillBySimbolaio(Me.DbhotelDataSet.touristperiodoi, simbolaiokwd)
                'MsgBox(Me.DbhotelDataSet.touristperiodoi.Count)
                ReDim periodoi(0)
                PeriodoiPnl.Controls.Clear()
                'SimbolaioTbx.Clear()
                HauptPnl.Controls.Remove(PeriodoiPnl)
                periodoi_felder_malen()

                If count <> 0 Then
                    MsgBox(" Επιτυχής Αποθήκευση των Περιόδων!", MsgBoxStyle.Information, "winfo\nikEl.")
                End If
            End If

        Else
            MsgBox("ΠΡΟΣΟΧΗ: Λόγω επικάλυψης των χρονικών ορίων δεν μπορεί να γίνει η Αποθήκευση των Περιόδων!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End If

        'If (test_ob_alles_leer()) Then
        '    Try
        '        Me.SimbolaiaTableAdapter.DeleteSimbolaio(simbolaiokwd)
        '    Catch ex As OleDb.OleDbException
        '        'MsgBox("ΠΡΟΣΟΧΗ: Λόγω ύπαρξης Allotment η Διαγραφή δεν μπόρεσε να ολοκληρωθεί!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        '    End Try

        '    ReDim periodoi(0)
        '    Me.DbhotelDataSet.touristperiodoi.Clear()
        '    PeriodoiPnl.Controls.Clear()
        '    HauptPnl.Controls.Remove(PeriodoiPnl)
        '    Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, praktoreiokwd, 2007)
        '    simbolaio_radiobuttons_zeig(0, 2, False)
        'End If
    End Sub
    Private Sub speicherbtn_next_tab(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PeriodoiPnl.Focus()
    End Sub
    Private Function test_ob_alles_leer() As Boolean
        Dim i As Int16
        For i = 0 To periodoi.Length - 1

            If (Not periodoi(i).kwd <> -1 Or Not periodoi(i).delete = True) And (Not periodoi(i).kwd = -1 Or Not periodoi(i).belegt = False) Then
                Return False
            End If
            Return True
        Next

    End Function
    Private Sub delete_chkbx_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cbx, counter As Int16 'cbx einai apla o arithmos toy delete checkbox, counter eiani i amesws epomeni ENERGH periodos(se periptwsi pou yparxoyn anenergoi periodoi->markarismeno to delete chkbox!) 
        Dim find1(), find2 As Object


        cbx = (sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)).ToString
        find1 = PeriodoiPnl.Controls.Find("Delt" + cbx.ToString, False)
        'If find1(0).checked And periodoi(cbx).belegt = True Then
        If find1(0).checked Then 'delete chekbox markarete
            periodoi(cbx).delete = True
            If cbx = 0 Then
                find2 = PeriodoiPnl.Controls.Find("Datm" + cbx.ToString + "_" + "1", False)
                Try
                    find2(0).enabled = False
                Catch ex As IndexOutOfRangeException

                End Try
            End If
            find2 = PeriodoiPnl.Controls.Find("Datm" + cbx.ToString + "_" + "2", False)
            Try
                find2(0).enabled = False
            Catch ex As IndexOutOfRangeException

            End Try


            counter = find_next_aktive_periodo(cbx)
            'MsgBox(counter)
            If counter <> -1 Then
                find2 = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "1", False)
                Try
                    find2(0).value = periodoi(cbx).apo
                    periodoi(cbx + 1).apo = periodoi(cbx).apo
                Catch ex As IndexOutOfRangeException

                End Try
            End If

            'End If

        Else 'delete chekbox XEmarkarete
            periodoi(cbx).delete = False
            If cbx = 0 Then
                find2 = PeriodoiPnl.Controls.Find("Datm" + cbx.ToString + "_" + "1", False)
                Try
                    find2(0).enabled = True
                Catch ex As IndexOutOfRangeException

                End Try
            End If

            find2 = PeriodoiPnl.Controls.Find("Datm" + cbx.ToString + "_" + "2", False)
            Try
                find2(0).enabled = True
            Catch ex As IndexOutOfRangeException

            End Try

            find2 = PeriodoiPnl.Controls.Find("Datm" + cbx.ToString + "_" + "1", False)
            counter = find_last_aktive_periodo(cbx)
            'MsgBox(counter)
            If counter <> -1 Then

                Try
                    find2(0).value = periodoi(counter).mexri.Date.AddDays(1)
                    periodoi(cbx).apo = find2(0).value
                Catch ex As IndexOutOfRangeException

                End Try

            End If
            counter = find_next_aktive_periodo(cbx)

            If counter <> -1 Then
                find2 = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "1", False)
                find2(0).value = periodoi(cbx).mexri.Date.AddDays(1)
                periodoi(counter).apo = find2(0).value
                find2 = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "2", False)
                If periodoi(counter).apo > periodoi(counter).mexri Then
                    periodoi(counter).mexri = periodoi(counter).apo
                    find2 = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "2", False)
                    find2(0).value = periodoi(counter).mexri
                    'If Not final_kontrolle() Then
                    '    MsgBox("ΠΡΟΣΟΧΗ: Δημιουργείται με την ακύρωση της Διαγραφής επικάλυψη Περιόδων (Τέλος προγενέστερο αρχής!)" & vbCrLf & "Απαιτείται διόρθωση πριν την οριστική Αποθήκευση!" & vbCrLf & " (Για αυτόματη διόρθωση κάνετε κλίκ στο τέλος της προηγούμενης περιόδου και μετά πατήστε TAB", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    'End If
                End If

            End If

        End If
        If Not final_kontrolle() Then
            MsgBox("ΠΡΟΣΟΧΗ: Δημιουργείται με την ακύρωση της Διαγραφής επικάλυψη Περιόδων (Τέλος προγενέστερο αρχής!)" & vbCrLf & "Απαιτείται διόρθωση πριν την οριστική Αποθήκευση!" & vbCrLf & " (Για αυτόματη διόρθωση κάνετε κλίκ στο τέλος της προηγούμενης περιόδου και μετά πατήστε TAB", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End If


    End Sub
    Private Function find_last_aktive_periodo(ByVal index As Int16) As Int16
        Dim i As Int16

        For i = index - 1 To 0 Step -1

            If periodoi(i).mexri <> defaultdate And periodoi(i).delete = False Then
                Return i
            End If
        Next
        Return -1

    End Function
    Private Function find_next_aktive_periodo(ByVal index As Int16) As Int16
        Dim i As Int16

        For i = index + 1 To periodoi.Length - 1

            If periodoi(i).mexri <> defaultdate And periodoi(i).delete = False Then
                Return i
            End If
        Next
        Return -1

    End Function
    Private Sub RelPeriod_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cbx As Int16

        cbx = (sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)).ToString

        Try
            periodoi(cbx).release = Math.Abs(CType(sender.Text, Integer))
            sender.Text = periodoi(cbx).release.ToString
        Catch ex As InvalidCastException
            periodoi(cbx).release = 0
            sender.Text = 0
        End Try


    End Sub
    Private Sub ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cbx As Int16
        Dim find() As Control

        cbx = (sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4)).ToString

        If cbx < Me.DbhotelDataSet.touristperiodoi.Count Then 'YPARXON periodos->schon belegt=TRUE
            periodoi(cbx).season = sender.selectedindex
        Else
            periodoi(cbx).season = sender.selectedindex
            periodoi(cbx).belegt = True         'edw wird BELEGT gesetzt dh. to tupel periodos(apo,mexri,season) einai eparkes
            find = PeriodoiPnl.Controls.Find("RelP" + cbx.ToString, False)
            find(0).Enabled = True
            find = PeriodoiPnl.Controls.Find("Delt" + cbx.ToString, False)
            find(0).Enabled = True
            If periodoi(cbx).release = Nothing Then ' stis nees periodous kanw setzen release = 0 als default(STIS schon iparxouses stin DB prepei to feld 'reperiod' na min einai DBnull sonst crash!!!!
                periodoi(cbx).release = 0
                find(0).Text = 0
            End If

        End If

    End Sub
    Private Sub Datum_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) 'gia ENERGOPOIHSH twn Datetime picker gia NEA kataxwrisi
        Dim split As String() = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4).Split(New [Char]() {"_"c})
        Dim find As Object
        Dim counter As Int16
        'MsgBox("mouse")
        'MsgBox(sender.value)
        If sender.value = defaultdate Then 'dh neue Periode
            If split(0) = 0 Then ' Proti Periodos
                'MsgBox(periodoi(split(0)).apo)
                If split(1) = 1 Then 'apo
                    sender.CustomFormat = "dd /MMMM/yyyy"
                    sender.value = imeromErgasias

                    'sender.value = periodoi(split(0) - 1).mexri.AddDays(1) 'mia mera parapanw apo tin mexri.date tis proigoumenis periodou
                Else 'i mexri date
                    If periodoi(split(0)).apo >= defaultdate Then 'dh i apo.date einai idi kataxwrimeni
                        sender.value = periodoi(split(0)).apo ' to idio value opws i apo 
                        sender.CustomFormat = "dd /MMMM/yyyy"
                        'sender.format = DateTimePickerFormat.Short
                    End If
                End If

            Else 'alli periodos ektos prwtis
                If (Not periodoi(split(0)).belegt) AndAlso (periodoi(split(0) - 1).belegt = True) AndAlso (periodoi(split(0) - 1).mexri < "31/12/" + etos.ToString) Then 'einai auti i periodos MH kataxwrimeni kai i proigoumeni periodos kataxwrimeni? -> gia na odigite o xristis na kataxwrei nacheinander tis periodous!
                    If split(1) = 2 Then 'i apo date!!!!And periodoi(split(0)).apo > defaultdate
                        sender.CustomFormat = "dd /MMMM/yyyy"
                        counter = find_last_aktive_periodo(split(0))
                        If periodoi(counter).mexri.Date < sender.maxdate Then
                            If counter <> -1 Then
                                periodoi(split(0)).apo = periodoi(counter).mexri.Date.AddDays(1)
                                'MsgBox(periodoi(split(0)).apo)
                            Else

                                periodoi(split(0)).apo = periodoi(0).mexri.Date.AddDays(1)

                            End If
                        Else
                            Exit Sub
                        End If


                        find = PeriodoiPnl.Controls.Find("Datm" + (split(0)).ToString + "_" + "1", False)
                        find(0).CustomFormat = "dd /MMMM/yyyy" 'energopoiisi kai to APO datetimepicker

                        find(0).value = periodoi(split(0)).apo

                        Try
                            sender.value = periodoi(split(0)).apo.AddDays(21) 'mia mera parapanw apo tin mexri.date tis proigoumenis periodou
                        Catch ex As ArgumentOutOfRangeException
                            sender.value = sender.maxdate
                        End Try

                        find = PeriodoiPnl.Controls.Find("SeaP" + (split(0)).ToString, False)
                        find(0).enabled = True
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub Datum_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim split As String() = sender.NAME.ToString.Substring(4, sender.NAME.ToString.Length - 4).Split(New [Char]() {"_"c})
        Dim find() As Object
        Dim response As MsgBoxResult
        Dim counter As Int16

        'If split(1) = 2 Then 'Anagkastika na diorthwsw to sender.value giati kamia fora DEN to pairnei!@!!!!!!!!!!!!!!!!!!!!!!!!!!
        '    find = PeriodoiPnl.Controls.Find("Datm" + (split(0)).ToString + "_" + "2", False)
        '    find(0).value = sender.value            'MsgBox(find(0).value)
        'End If
        'MsgBox(sender.value)
        If periodoi(split(0)).delete = False Then


            If split(0) < Me.DbhotelDataSet.touristperiodoi.Count Then 'Yparxousa Periodos ->EINAI H PRWTI!!!(schon belegt)

                Select Case split(1) 'Ksexwrizei datum1 apo Datum2
                    Case 1 'APO
                        If sender.value > periodoi(split(0)).mexri Then
                            response = MsgBox("Δημιουργείται λανθασμένη Περίοδος (Τέλος προγενέστερο αρχής!). Επαναφορά;  " & vbCrLf & "(Ναι->Διόρθωση της αρχικής Ημερ/νίας)" & vbCrLf & "(Οχι->Προσπάθεια διόρθωσης της Ημερ/νίας στο τέλος της Περιόδου)", MsgBoxStyle.YesNo, "winfo\nikEl.")
                            If response = MsgBoxResult.Yes Then
                                sender.value = periodoi(split(0)).apo
                                'periodoi(split(0)).apo = sender.value
                            Else
                                find = PeriodoiPnl.Controls.Find("Datm" + (split(0)).ToString + "_" + "2", False)
                                If preuefe_ob_es_erzeugt_epikalipsi(split(0), sender.value) Then 'mporw na alaksw thn amesws epomen periodo
                                    find(0).value = sender.value
                                    periodoi(split(0)).apo = sender.value
                                    periodoi(split(0)).mexri = sender.value
                                    counter = find_next_aktive_periodo(split(0))

                                    find = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "1", False)
                                    Try
                                        find(0).value = periodoi(split(0)).mexri.Date.AddDays(1)
                                        periodoi(counter).apo = periodoi(split(0)).mexri.Date.AddDays(1)
                                    Catch ex As IndexOutOfRangeException

                                    End Try

                                    'setze_anz_tage(split(0) + 1)
                                    find = PeriodoiPnl.Controls.Find("AnzT" + split(0).ToString, False)
                                    If periodoi(split(0)).mexri.Date.Year = periodoi(split(0)).apo.Date.Year Then
                                        find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear - periodoi(split(0)).apo.Date.DayOfYear + 1
                                    Else
                                        If periodoi(split(0)).mexri.Date.Year - periodoi(split(0)).apo.Date.Year = 1 Then
                                            find(0).text = periodoi(split(0)).mexri.Date.DayOfYear + (periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear).DayOfYear - periodoi(split(0)).apo.Date.DayOfYear) + 1
                                        Else
                                            find(0).text = "!"
                                        End If
                                    End If
                                Else
                                    MsgBox(" Δεν είναι δυνατή η Διόρθωση της Ημερ/νίας στο τέλος της Περιόδου " & vbCrLf & " γιατί θα δημιουργήσει πρόβλημα στην επόμενη !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                    sender.value = periodoi(split(0)).apo
                                End If

                            End If
                        Else
                            periodoi(split(0)).apo = sender.value
                            'setze_anz_tage(split(0) + 1)
                            find = PeriodoiPnl.Controls.Find("AnzT" + split(0).ToString, False)
                            If periodoi(split(0)).mexri.Date.Year = periodoi(split(0)).apo.Date.Year Then
                                find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear - periodoi(split(0)).apo.Date.DayOfYear + 1
                            Else
                                If periodoi(split(0)).mexri.Date.Year - periodoi(split(0)).apo.Date.Year = 1 Then
                                    find(0).text = periodoi(split(0)).mexri.Date.DayOfYear + (periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear).DayOfYear - periodoi(split(0)).apo.Date.DayOfYear) + 1
                                Else
                                    find(0).text = "!"
                                End If
                            End If
                        End If
                    Case 2 'Mexri                                                                                                                                                                                                                                                                       
                        If pruefe_epikalipsis_mexri_ok(split(0), sender.Value) Then
                            periodoi(split(0)).mexri = sender.value
                            counter = find_next_aktive_periodo(split(0))

                            find = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "1", False)
                            Try
                                find(0).value = periodoi(split(0)).mexri.Date.AddDays(1)
                                periodoi(counter).apo = periodoi(split(0)).mexri.Date.AddDays(1)
                                setze_anz_tage(counter)
                            Catch ex As IndexOutOfRangeException

                            End Try

                            find = PeriodoiPnl.Controls.Find("AnzT" + split(0).ToString, False)
                            If periodoi(split(0)).mexri.Date.Year = periodoi(split(0)).apo.Date.Year Then
                                find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear - periodoi(split(0)).apo.Date.DayOfYear + 1
                            Else
                                If periodoi(split(0)).mexri.Date.Year - periodoi(split(0)).apo.Date.Year = 1 Then
                                    find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear + (periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear).DayOfYear - periodoi(split(0)).apo.Date.DayOfYear) + 1
                                Else
                                    find(0).text = "!"
                                End If
                            End If
                        Else
                            MsgBox(" Δεν είναι δυνατή η αλλαγή της Ημερ/νίας στο τέλος της Περιόδου " & vbCrLf & " γιατί θα δημιουργήσει επικάλυψη!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                            sender.value = periodoi(split(0)).mexri
                        End If
                End Select
            Else 'NEA PERIODOS 
                Try
                    If sender.value > defaultdate AndAlso periodoi(split(0) - 1).belegt = True Then 'iparxei proigoumeni
                        'sender.format = DateTimePickerFormat.Short
                        If split(1) = 2 Then 'MEXRI-> apo den yparxei!!!!
                            If pruefe_epikalipsis_mexri_ok(split(0), sender.value) Then
                                periodoi(split(0)).mexri = sender.value
                                counter = find_next_aktive_periodo(split(0))

                                find = PeriodoiPnl.Controls.Find("Datm" + counter.ToString + "_" + "1", False)
                                Try
                                    find(0).value = periodoi(split(0)).mexri.Date.AddDays(1)
                                    periodoi(counter).apo = periodoi(split(0)).mexri.Date.AddDays(1)
                                    setze_anz_tage(counter)
                                Catch ex As IndexOutOfRangeException

                                End Try

                                find = PeriodoiPnl.Controls.Find("AnzT" + (split(0)).ToString, False)
                                If periodoi(split(0)).mexri.Date.Year = periodoi(split(0)).apo.Date.Year Then
                                    find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear - periodoi(split(0)).apo.Date.DayOfYear + 1
                                Else
                                    If periodoi(split(0)).mexri.Date.Year - periodoi(split(0)).apo.Date.Year = 1 Then
                                        find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear + (periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear).DayOfYear - periodoi(split(0)).apo.Date.DayOfYear) + 1
                                        'MsgBox(periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear))
                                        'MsgBox(periodoi(split(0)).apo.Date.DayOfYear)
                                    Else

                                        find(0).text = "!"
                                    End If
                                End If
                            Else
                                MsgBox("Επικάλυψη Περιόδων ! Ελέγξτε τα Δεδομένα ", MsgBoxStyle.Exclamation, "winfo\nikEl.")

                                If periodoi(split(0)).mexri <> defaultdate Then
                                    sender.value = periodoi(split(0)).mexri
                                Else
                                    sender.value = periodoi(split(0)).apo
                                    periodoi(split(0)).mexri = sender.value
                                End If
                                Exit Sub
                            End If
                        End If

                    End If
                Catch ex As IndexOutOfRangeException ' sE PERIPTWSI POU EINAI I PRWTI PERIODOS UEBERHAYPT (->splt(0)-1 dinei EXCEPTION)
                    Select Case split(1) 'Ksexwrizei datum1 apo Datum2
                        Case 1 'APO
                            If periodoi(split(0)).mexri <> defaultdate Then
                                If sender.value <= periodoi(split(0)).mexri Then
                                    periodoi(split(0)).apo = sender.value
                                Else
                                    MsgBox("Επικάλυψη Περιόδων ! Ελέγξτε τα Δεδομένα ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                    sender.value = periodoi(split(0)).apo
                                End If
                            Else
                                periodoi(split(0)).apo = sender.value
                            End If


                        Case 2 'Mexri
                            'MsgBox(sender.value)
                            If pruefe_epikalipsis_mexri_ok(split(0), sender.value) Then
                                periodoi(split(0)).mexri = sender.value
                                counter = find_next_aktive_periodo(split(0))

                                find = PeriodoiPnl.Controls.Find("Datm" + (counter).ToString + "_" + "1", False)
                                Try
                                    find(0).value = periodoi(split(0)).mexri.Date.AddDays(1)
                                    periodoi(counter).apo = periodoi(split(0)).mexri.Date.AddDays(1)
                                    setze_anz_tage(counter)
                                Catch ex1 As IndexOutOfRangeException
                                    'Exit Sub
                                End Try


                                find = PeriodoiPnl.Controls.Find("AnzT" + (split(0)).ToString, False)
                                If periodoi(split(0)).mexri.Date.Year = periodoi(split(0)).apo.Date.Year Then
                                    find(0).tEXT = periodoi(split(0)).mexri.Date.DayOfYear - periodoi(split(0)).apo.Date.DayOfYear + 1
                                Else
                                    If periodoi(split(0)).mexri.Date.Year - periodoi(split(0)).apo.Date.Year = 1 Then
                                        find(0).text = periodoi(split(0)).mexri.Date.DayOfYear + (periodoi(split(0)).mexri.Date.AddDays(-periodoi(split(0)).mexri.Date.DayOfYear).DayOfYear - periodoi(split(0)).apo.Date.DayOfYear) + 1
                                    Else
                                        find(0).text = "!"
                                    End If
                                End If

                            Else
                                MsgBox("Επικάλυψη Περιόδων ! Ελέγξτε τα Δεδομένα ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                                If periodoi(split(0)).mexri <> defaultdate Then
                                    sender.value = periodoi(split(0)).mexri
                                Else
                                    sender.value = periodoi(split(0)).apo
                                    periodoi(split(0)).mexri = sender.value
                                End If
                                'periodoi(split(0)).mexri = sender.value
                                Exit Sub
                            End If
                    End Select
                End Try

            End If
        End If
    End Sub
    Private Function preuefe_ob_es_erzeugt_epikalipsi(ByVal index As Int16, ByVal datum As Date) As Boolean
        Dim counter As Int16

        counter = find_next_aktive_periodo(index)
        Try ' Mono gia th=in prwti periodo pou uparxei idi!


            If periodoi(counter).belegt = True Then  '
                If datum.Date.AddDays(1) > periodoi(counter).mexri Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As IndexOutOfRangeException
            Return True
        End Try


    End Function
    Private Sub setze_anz_tage(ByVal index As Int16)
        Dim find As Object
        find = PeriodoiPnl.Controls.Find("AnzT" + index.ToString, False)
        If periodoi(index).mexri <> defaultdate Then
            If periodoi(index).apo.Date.Year = periodoi(index).mexri.Date.Year Then
                find(0).text = periodoi(index).mexri.Date.DayOfYear - periodoi(index).apo.Date.DayOfYear + 1
                'MsgBox(periodoi(index).apo)
            Else
                If periodoi(index).mexri.Date.Year - periodoi(index).apo.Date.Year = 1 Then
                    find(0).text = periodoi(index).mexri.Date.DayOfYear + (periodoi(index).mexri.Date.AddDays(-periodoi(index).mexri.Date.DayOfYear).DayOfYear - periodoi(index).apo.Date.DayOfYear) + 1
                Else
                    find(0).text = "!"
                End If
            End If

        End If


    End Sub

    Private Function pruefe_epikalipsis_mexri_ok(ByVal index As Int16, ByVal datum As Date) As Boolean
        Dim counter As Int16
        counter = find_next_aktive_periodo(index)
        If datum < periodoi(index).apo Then
            Return False
        Else
            Try
                If periodoi(counter).mexri <> defaultdate AndAlso datum >= periodoi(counter).mexri Then
                    Return False
                End If
            Catch ex As IndexOutOfRangeException

            End Try
        End If
        Return True
    End Function

    'delete_chkbx_changed
    Private Function get_index_season(ByVal kwdikos As Integer) As Int16
        Dim i As Integer

        For i = 0 To Me.DbhotelDataSet.seasons.Count - 1
            If Me.DbhotelDataSet.seasons(i).kwd = kwdikos Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function get_kwd_season(ByVal index As Int16) As Integer
        Dim find() As Object
        'ComboBox1.Items(i).ToString()
        find = PeriodoiPnl.Controls.Find("SeaP" + "1", False)

        Try
            Return Me.SeasonsTableAdapter.GetKwdByName(find(0).Items(index).ToString)
        Catch ex As Exception
            Return -1
        End Try


    End Function

    Private Function final_kontrolle() As Boolean
        Dim i As Int16
        Dim counter1, counter2 As Int16


        For i = 0 To periodoi.Length - 1
            counter1 = find_next_aktive_periodo(i - 1)
            If counter1 <> -1 Then
                'If counter1 = 0 Then

                'End If
                If periodoi(counter1).belegt = True Then
                    If periodoi(counter1).apo > periodoi(counter1).mexri Then
                        Return False
                    Else
                        Try
                            counter2 = find_next_aktive_periodo(counter1)
                            If periodoi(counter2).belegt = True Then
                                If (periodoi(counter2).apo.DayOfYear - periodoi(counter1).mexri.DayOfYear <> 1) Then
                                    If (periodoi(counter1).mexri.Date.Year - periodoi(counter2).apo.Date.Year = 0) Then
                                        Return False
                                    Else
                                        If (periodoi(counter2).apo.DayOfYear - periodoi(counter1).mexri.DayOfYear > -362) Then
                                            Return False
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As IndexOutOfRangeException

                        End Try
                        'Return False
                    End If
                End If
            Else
                Exit For
            End If
        Next
        Return True
    End Function
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

    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************
    Private Sub seasons_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        HauptPnl.Controls.Add(EtiketaPnl)

        EtiketaLbl.Text = "SEASONS       !!!!!!!!!!!!!!!!!"

        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Seasons χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        InfoLbl.Size = New Point(SeasonPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(SeasonPnl)
        SeasonPnl.Size = New Point(600, 370)
        InfoLbl.Width = SeasonPnl.Width
        SeasonPnl.Location = New Point(locx, locy)
    End Sub
    Private Sub ToolStripButton35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton35.Click
        Dim i As Int16
        SeasonsDataGridView.EndEdit()
        For i = 0 To SeasonsBindingSource.Count - 1
            'Try

            If Me.SeasonsTableAdapter.ExistSeason(SeasonsDataGridView.Item(0, i).Value) Then

                Try
                    Me.SeasonsTableAdapter.UpdateSeason(SeasonsDataGridView.Item(1, i).Value, SeasonsDataGridView.Item(2, i).Value.ToString, SeasonsDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + SeasonsDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not SeasonsDataGridView.Item(1, i).Value.ToString.Equals("") Then
                    Try

                        Me.SeasonsTableAdapter.InsertSeason(SeasonsDataGridView.Item(1, i).Value, SeasonsDataGridView.Item(2, i).Value)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + SeasonsDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try


        Next
        Me.SeasonsTableAdapter.Fill(Me.DbhotelDataSet.seasons)
    End Sub
    Private Sub ToolStripButton30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton30.Click
        If Me.SeasonsTableAdapter.ExistSeason((SeasonsDataGridView.Item(0, SeasonsDataGridView.CurrentRow.Index).Value)) Then
            Try

                Me.SeasonsTableAdapter.DeleteSeason((SeasonsDataGridView.Item(0, SeasonsDataGridView.CurrentRow.Index).Value))

            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try
        End If
    End Sub
    Private Sub SeasonsBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles SeasonsBindingSource.AddingNew
        If SeasonsBindingSource.Count = 0 Then
            ToolStripButton30.Visible = False
        Else
            ToolStripButton30.Visible = True
        End If

    End Sub



    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************
    Private Sub praktoreia_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 120
        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)

        EtiketaLbl.Text = " ΠΡΑΚΤΟΡΕΙΑ"
        EtiketaLbl.Location = New Point(PraktoreiaPnl.Width / 2 + 50, 25)
        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Για να δείτε τις Λεπτομέρειες Πρακτορείου κάνετε διπλό κλίκ πάνω του>" & vbCrLf &
        "<(Για ευκολότερη ανεύρεση ενός Πρακτορείου μπορείτε να ταξινομίσετε την λίστα αλφαβητικά κάνωντας απλό κλίκ στην επικεφάλίδα της στήλης ΕΠΩΝΥΜΙΑ>" & vbCrLf &
        "<Εισάγετε νέο πρακτορείο στο τέλος της λίστας και αποθηκεύστε πατώντας το αντίστοιχο εικονίδιο της Δισκέτας.>" & vbCrLf &
        "<Αφού αποθηκεύσετε το νέο Πρακτορείο κανετε διπλό κλικ πάνω του για να εισάγετε αναλυτικά τα στοιχεία που το αφορούν>"

        InfoLbl.Size = New Point(PraktoreiaPnl.Width, 120)
        InfoLbl.Location = New Point(locx, locy - 100)

        PraktoreiaPnl.Size = New Point(600, 370)
        InfoLbl.Width = PraktoreiaPnl.Width
        PraktoreiaPnl.Location = New Point(locx, locy + 30)

        HauptPnl.Controls.Add(EtiketaPnl)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(PraktoreiaPnl)
    End Sub

    Private Sub PraktoreiaDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles PraktoreiaDataGridView.DataError
        MsgBox(" Ο Κωδικός υπάρχει ήδη!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
    End Sub
    Private Sub PraktoreiaDataGridView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PraktoreiaDataGridView.DoubleClick
        Dim praktkwd As Integer


        PraktoreiaDataGridView.EndEdit()
        If PraktoreiaDataGridView.RowCount <> 0 Then

            Try
                praktkwd = (PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value)

                ' If praktkwd <> Nothing And Me.PraktoreiaTableAdapter.ExistPraktoreia(PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value.ToString <> 0 Then
                If praktkwd <> Nothing Then
                    If Me.PraktoreiaTableAdapter.ExistPraktoreia(PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value) Then
                        'MsgBox(praktkwd)
                        Dim NewForm As New PraktoreioFrm(praktkwd)
                        NewForm.StartPosition = FormStartPosition.CenterScreen
                        NewForm.ShowDialog()
                        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
                    Else
                        If PraktoreiaDataGridView.Item(1, PraktoreiaDataGridView.CurrentRow.Index).Value.ToString.Equals("") Then
                            MsgBox(" Δεν επιλέχθηκε Πρακτορείο!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        Else
                            MsgBox(" Το Πρακτορείο πρεπει πρώτα να αποθηκευθεί (κλικ στο εικονίδιο της Δισκέτας) πριν επιλεχθεί!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End If

                    End If
                End If

            Catch ex As ArgumentOutOfRangeException

            Catch ex1 As InvalidCastException
                'Catch ex1 As IndexOutOfRangeException

            End Try


        End If




    End Sub 'keypressed


    Private Sub save_praktoreia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton28.Click
        Dim i As Int16


        PraktoreiaDataGridView.EndEdit()
        For i = 0 To PraktoreiaBindingSource.Count - 1
            Try

                If Me.PraktoreiaTableAdapter.ExistPraktoreia(CType(PraktoreiaDataGridView.Item(0, i).Value, Integer)) Then

                    Try
                        Me.PraktoreiaTableAdapter.UpdatePraktoreia(PraktoreiaDataGridView.Item(1, i).Value, PraktoreiaDataGridView.Item(0, i).Value)
                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αλλαγή του" + PraktoreiaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try

                Else
                    If Not PraktoreiaDataGridView.Item(1, i).Value.ToString.Equals("") And Not PraktoreiaDataGridView.Item(0, i).Value.ToString.Equals("") Then
                        Try
                            Me.PraktoreiaTableAdapter.InsertPraktoreia(PraktoreiaDataGridView.Item(1, i).Value, 1, PraktoreiaDataGridView.Item(0, i).Value)

                        Catch ex As OleDb.OleDbException
                            MsgBox("Η Αποθήκευση του " + PraktoreiaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                        End Try
                    End If

                End If

            Catch ex As InvalidCastException
                If Not PraktoreiaDataGridView.Item(1, i).Value.ToString.Equals("") And Not PraktoreiaDataGridView.Item(0, i).Value.ToString.Equals("") Then
                    Try

                        Me.PraktoreiaTableAdapter.InsertPraktoreia(PraktoreiaDataGridView.Item(1, i).Value, 1, PraktoreiaDataGridView.Item(0, i).Value)

                    Catch ex1 As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + PraktoreiaDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End Try


        Next
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)

        Me.PraktoreiaBindingSource.MoveLast()
    End Sub
    Private Sub delete_praktoreia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton23.Click
        Try
            If Me.PraktoreiaTableAdapter.ExistPraktoreia((PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value)) Then
                Try

                    Me.PraktoreiaTableAdapter.DeletePraktoreia((PraktoreiaDataGridView.Item(0, PraktoreiaDataGridView.CurrentRow.Index).Value))

                Catch ex As OleDb.OleDbException
                    MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try
            End If
        Catch ex As InvalidCastException
            MsgBox("Αποτυχία!", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End Try

    End Sub
    Private Sub PraktoreiaBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles PraktoreiaBindingSource.AddingNew
        If PraktoreiaBindingSource.Count = 0 Then
            ToolStripButton23.Visible = False
        Else
            ToolStripButton23.Visible = True
            'maxKwd += 1
            'PraktoreiaDataGridView.Item(0, PraktoreiaBindingSource.Count - 1).Value = maxKwd

        End If

    End Sub


    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************
    '********************************************************************************************************************
    '*********************************************************************************************************************



    Private Sub tipoi_xrewsis_zeig()
        Dim locx, locy As Int16

        locx = 30
        locy = 2 * EtiketaLbl.Height + 80

        EtiketaPnl.Size = New Point(Me.HauptPnl.Width - 30, 60) 'Etiketa panel initialisieren

        EtiketaPnl.Location = New Point(5, 5)


        EtiketaLbl.Text = "   ΤΥΠΟΙ ΧΡΕΩΣΗΣ      "


        Dim InfoLbl As New Label
        InfoLbl.TextAlign = ContentAlignment.MiddleCenter
        InfoLbl.ForeColor = Color.Black
        InfoLbl.Text = "<Εισάγετε, αλλάξτε ή διαγράψτε Τύπους χρέωσης χρησιμοποιώντας τα αντίστοιχα εικονίδια." & vbCrLf & " (Αποθήκευση-> εικονίδιο δισκέτας. Διαγραφή -> Χ-εικονίδιο)>"

        InfoLbl.Size = New Point(TipoiXrewsisPnl.Width, 50)
        InfoLbl.Location = New Point(locx, locy - 50)
        HauptPnl.Controls.Add(InfoLbl)
        HauptPnl.Controls.Add(TipoiXrewsisPnl)
        TipoiXrewsisPnl.Size = New Point(700, 370)
        InfoLbl.Width = TipoiXrewsisPnl.Width
        TipoiXrewsisPnl.Location = New Point(locx, locy)

        EtiketaLbl.Location = New Point(EtiketaPnl.Width / 2 - 150, 25)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        HauptPnl.Controls.Add(EtiketaPnl)
    End Sub
    Private Sub save_tipous_xrewsis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click
        Dim i As Int16

        TXrewsisDataGridView.EndEdit()
        For i = 0 To XrewseisBindingSource.Count - 1
            'Try

            If Me.XrewseisTableAdapter.ExistXrewsi(TXrewsisDataGridView.Item(0, i).Value) Then

                Try
                    Me.XrewseisTableAdapter.UpdateXrewsi(TXrewsisDataGridView.Item(1, i).Value, TXrewsisDataGridView.Item(2, i).Value, TXrewsisDataGridView.Item(3, i).Value, TXrewsisDataGridView.Item(4, i).Value, TXrewsisDataGridView.Item(5, i).Value, TXrewsisDataGridView.Item(6, i).Value, TXrewsisDataGridView.Item(0, i).Value)
                Catch ex As OleDb.OleDbException
                    MsgBox("Η Αλλαγή του" + TXrewsisDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                End Try

            Else
                If Not TXrewsisDataGridView.Item(1, i).Value.ToString.Equals("") Then
                    Try

                        Me.XrewseisTableAdapter.InsertXrewsi(TXrewsisDataGridView.Item(1, i).Value, TXrewsisDataGridView.Item(2, i).Value, TXrewsisDataGridView.Item(3, i).Value, TXrewsisDataGridView.Item(4, i).Value, TXrewsisDataGridView.Item(5, i).Value, TXrewsisDataGridView.Item(6, i).Value)

                    Catch ex As OleDb.OleDbException
                        MsgBox("Η Αποθήκευση του " + TXrewsisDataGridView.Item(1, i).Value + " δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    End Try
                End If

            End If

            'Catch ex As InvalidCastException

            'End Try


        Next
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)

    End Sub
    Private Sub delete_tipous_xrewsis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        If Me.XrewseisTableAdapter.ExistXrewsi((TXrewsisDataGridView.Item(0, TXrewsisDataGridView.CurrentRow.Index).Value)) Then
            Try

                Me.XrewseisTableAdapter.DeleteXrewsi((TXrewsisDataGridView.Item(0, TXrewsisDataGridView.CurrentRow.Index).Value))

            Catch ex As OleDb.OleDbException
                MsgBox("Η Διαγραφή δεν κατέστη δυνατή", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End Try
        End If
    End Sub
    Private Sub selectall(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SelectAll()

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

    Private Sub SimfoniesFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub
    Private Sub SimfoniesFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
        Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)
        'TODO: This line of code loads data into the 'DbhotelDataSet.pistwtikes' table. You can move, or remove it, as needed.
        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
        Me.SeasonsTableAdapter.Fill(Me.DbhotelDataSet.seasons)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.users' table. You can move, or remove it, as needed.
        'Me.UsersTableAdapter.Fill(Me.DbhotelDataSet.users)
        'TODO: This line of code loads data into the 'DbhotelDataSet.pistwtikes' table. You can move, or remove it, as needed.
        currentuser = 1 'Ocurrent User 1=admin ,ktl. tha erthei san Parametros apo to Aufruf
        Me.PistwtikesTableAdapter.Fill(Me.DbhotelDataSet.pistwtikes)
        'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
        Me.ParastatikaTableAdapter.Fill(Me.DbhotelDataSet.parastatika)

        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories1' table. You can move, or remove it, as needed.
        'Me.Katigories1TableAdapter.Fill(Me.DbhotelDataSet.katigories1)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories' table. You can move, or remove it, as needed.
        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        HauptPnl.Controls.Clear()
        HauptPnl.AutoScroll = True

        'InitializeMyScrollBar()
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
        etos = imeromErgasias.Year
        defaultdate = "1/1/" + etos.ToString
    End Sub




End Class