Public Class TelosMinaErgasies
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim praktOK, ethnikOK, epaggOK, plirotOK As Boolean
    Dim ilikRande() As Int16
    'Katanomi esodwn praktoreiwn
    Dim kwdPrakt, kwdSimb As Integer
    Dim sumsumEnil, sumsumPaidia, sumsumDwm As Int16
    Dim sumsumDiam, sumsumAll, sumsumPrwin, sumsumGeum, sumsumExtr, sumsumSyn, sumsumDiaf, fpaYpnou, fpaPrwinou, fpaTrofis, fpaExtra, sumsum As Single
    Structure Rande
        Dim apo As Int16
        Dim mexri As Int16
    End Structure
    'Analysi esodwn B
    Structure TroposPl
        Dim pistosi As Single
        Dim metritois As Single
    End Structure
    'Diorthoseis
    Dim kwdDEthnik As Integer
    Dim indMina As Int16
    Dim ethnik() As Int16
    Structure ethnikPeriod
        Dim apo As Int16
        Dim mexri As Int16
        Dim anzahl As Integer
    End Structure
    '***************TELOS MHNA DIANIKTEREUSEIS ANA PRAKTOREIO*************TELOS MHNA DIANIKTEREUSEIS ANA PRAKTOREIO**************
    Private Sub TelosMinaTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TelosMinaTree.AfterSelect
        Select Case TelosMinaTree.SelectedNode.Name.ToString
            Case "dianiktereuseis"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                Me.dianiktereuseis(False, True, False, False)
            Case "ethnikotita"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                Me.dianiktereuseis(False, False, True, False)
            Case "epaggelma"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                Me.dianiktereuseis(False, False, False, True)
            Case "Hlikies"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                ilikies()
            Case "plirotita"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                Me.dianiktereuseis(True, False, False, True)
            Case "lista_over"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                lista_over()
            Case "esoda_prakt"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                esoda_ana_praktoreio()

            Case "analysi_a_esodwn"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                esoda_analysi_a()
            Case "analysi_b_esodwn"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                esoda_analysi_b()
            Case "diorthoseis"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                diorthoseis()
        End Select
    End Sub


    Private Sub dianiktereuseis(ByVal plirot As Boolean, ByVal prakt As Boolean, ByVal ethnik As Boolean, ByVal epagg As Boolean)


        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        If plirot Then
            EtiketaLbl.Text = "Πληρότητα Δωματίων ανά Πρακτορείο"
        ElseIf prakt Then
            EtiketaLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Πρακτορείο"
        ElseIf ethnik Then
            EtiketaLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Εθνικότητα"
        ElseIf epagg Then
            EtiketaLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Επάγγελμα"
        End If
        EtiketaLbl.Location = New Point(15, 25)

     
        DianiktereuseisPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.DianiktereuseisPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        MinasPck.MinDate = "1/1/" + etos.ToString
        MinasPck.MaxDate = "31/12/" + etos.ToString
        MinasPck.Value = imeromErgasias
        MinasPck.CustomFormat = "MM/yyyy"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(DianiktereuseisPnl)

        plirotOK = plirot
        praktOK = prakt
        ethnikOK = ethnik
        epaggOK = epagg
    End Sub



    Private Sub DianiktereuseisBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DianiktereuseisBtn.Click
        Dim arxiIm, telosIm, laufDate As Date
        Dim minas, daysCount As Int16

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DbhotelDataSet.dianiktereuseis_mina.Clear()
            Me.DbhotelDataSet.ekt_status_ekdosi.Clear()
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm1.Clear()

            minas = MinasPck.Value.Month

            arxiIm = "1/" + minas.ToString + "/" + etos.ToString
            If MinasPck.Value.Month + 1 <= 12 Then
                telosIm = "1/" + (minas + 1).ToString + "/" + etos.ToString
                telosIm = telosIm.AddDays(-1)
            Else
                telosIm = "31/12/" + etos.ToString
            End If

            'poses meres exei o minas ->28,30,31
            laufDate = arxiIm.AddDays(27)
            While laufDate.Month = MinasPck.Value.Month
                laufDate = laufDate.AddDays(1)
            End While

            daysCount = laufDate.AddDays(-1).Day

            If plirotOK Then
                'Join anfrage an DB->Kratiseis, Praktoreia
                Me.Dianiktereuseis_minaTableAdapter.FillPlirotitaByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                                  telosIm, arxiIm, telosIm)
                zeige_plirotita_ana_prakt(daysCount, arxiIm, telosIm)
            ElseIf praktOK Then
                'Join anfrage an DB->Kratiseis, Praktoreia, kai tou View PaidiaAnaKratisi
                Me.Dianiktereuseis_minaTableAdapter.FillDianiktereuseisByAfAnax(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                       telosIm, arxiIm, telosIm)

                zeige_ana_praktoreia(daysCount, arxiIm, telosIm)

            ElseIf ethnikOK Then
                Me.Dianiktereuseis_minaTableAdapter.FillEthnokotitesDianikterByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                                  telosIm, arxiIm, telosIm)
                zeige_ana_ethnikotita(daysCount, arxiIm, telosIm)

            ElseIf epaggOK Then
                Me.Dianiktereuseis_minaTableAdapter.FillEppagelmaByDianiktAfAnx(Me.DbhotelDataSet.dianiktereuseis_mina, True, arxiIm, arxiIm, True, telosIm, _
                                  telosIm, True, arxiIm, telosIm)

                zeige_ana_epaggelma(daysCount, arxiIm, telosIm)

            End If
            'JOIN Anfrage sortiert kata praktoreia 


            Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()

            Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias
            Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = get_minas(minas) + " " + etos.ToString
            Try
                Me.DbhotelDataSet.ekt_status_ekdosi(0).dynami = Me.DwmatiaTableAdapter.GetDynamiXenodoxeiou
                Me.DbhotelDataSet.ekt_status_ekdosi(0).days = daysCount
            Catch ex As Exception
            End Try


            If plirotOK Or praktOK Then
                Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = "ΠΡΑΚΤΟΡΕΙΟ"
            ElseIf ethnikOK Then
                Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = "ΕΘΝΙΚΟΤΗΤΑ"
                make_diorthoseis_ethnikotites(minas, etos, daysCount)
            ElseIf epaggOK Then
                Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = "ΕΠΑΓΓΕΛΜΑ"
            End If


            If plirotOK Then
                proepiskopisi_plirotitas_dwmatiwn(arxiIm, daysCount)
            Else
                proepiskopisi_dianiktereusewn(arxiIm, daysCount)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

      


    End Sub
    Private Sub zeige_plirotita_ana_prakt(ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex, countAfix As Int16
        Dim plirotPrakt() As Int16

        ReDim plirotPrakt(-1)

        'heraus kriegen von indexen in dataset Me.DbhotelDataSet.dianiktereuseis_mina me to idio praktoreio gia bearbeiten  
        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            countIndex = 1

            If startIndex < Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                'proipotheti oti to Dataset einai sortiert kata praktoreio
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + countIndex).praktoreio
                    countIndex += 1

                    If startIndex + countIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                        Exit While
                    End If
                End While
                ReDim plirotPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(plirotPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                countAfix = berechne_kratiseis_praktoreiou(startIndex, countIndex, arxiIM, telosIm, plirotPrakt)

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_plirotita(startIndex, plirotPrakt, countAfix, daysCount, arxiIM, telosIm)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim plirotPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(plirotPrakt)
                countAfix = berechne_kratiseis_praktoreiou(startIndex, countIndex, arxiIM, telosIm, plirotPrakt)

                fuelle_dataset_plirotita(startIndex, plirotPrakt, countAfix, daysCount, arxiIM, telosIm)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub zeige_ana_praktoreia(ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex, countDian As Int16
        Dim dianikPrakt() As Int16

        ReDim dianikPrakt(-1)

        'heraus kriegen von indexen  in dataset Me.DbhotelDataSet.dianiktereuseis_mina me to idio praktoreio gia bearbeiten  
        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            countIndex = 1

            If startIndex < Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + countIndex).praktoreio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                        Exit While
                    End If
                End While
                ReDim dianikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(dianikPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                countDian = berechne_dianiktereuontes_praktoreiou(startIndex, countIndex, arxiIM, telosIm, dianikPrakt)

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_praktoreia(startIndex, countDian, dianikPrakt)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim dianikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(dianikPrakt)
                countDian = berechne_dianiktereuontes_praktoreiou(startIndex, countIndex, arxiIM, telosIm, dianikPrakt)

                fuelle_dataset_praktoreia(startIndex, countDian, dianikPrakt)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub zeige_ana_ethnikotita(ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex, countEthnik As Int16
        Dim ethnikPrakt() As Int16

        ReDim ethnikPrakt(-1)

        'heraus kriegen von indexen in dataset Me.DbhotelDataSet.dianiktereuseis_mina me rin idia ethnikotita gia bearbeiten  
        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            countIndex = 1

            If startIndex < Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).ethnikotita = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + countIndex).ethnikotita
                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                        Exit While
                    End If
                End While
                ReDim ethnikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(ethnikPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                countEthnik = berechne_dianiktereuontes_ethnikotitas(startIndex, countIndex, arxiIM, telosIm, ethnikPrakt)
                'MsgBox(countEthnik)
                'fuelle zu dataset gia Crystal report
                fuelle_dataset_ethikotites(startIndex, countEthnik, ethnikPrakt)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim ethnikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(ethnikPrakt)
                countEthnik = berechne_dianiktereuontes_ethnikotitas(startIndex, countIndex, arxiIM, telosIm, ethnikPrakt)
                'MsgBox(countEthnik)
                fuelle_dataset_ethikotites(startIndex, countEthnik, ethnikPrakt)
                Exit Do
            End If
        Loop

        fuelle_zweite_ethnikotita_zu_dataset(daysCount, arxiIM, telosIm)

    End Sub
    Private Sub zeige_ana_epaggelma(ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex As Int16
        Dim dianikPrakt() As Int16

        ReDim dianikPrakt(-1)

        'heraus kriegen von indexen in dataset Me.DbhotelDataSet.dianiktereuseis_mina gia bearbeiten  
        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            countIndex = 1

            If startIndex < Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).epaggelma Like Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + countIndex).epaggelma

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                        Exit While
                    End If
                End While
                ReDim dianikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(dianikPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                berechne_dianiktereuontes_epaggelma(startIndex, countIndex, arxiIM, telosIm, dianikPrakt)

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_epaggelma(startIndex, dianikPrakt)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim dianikPrakt(daysCount - 1)
                init_dianiktreuseis_praktoreiou(dianikPrakt)
                berechne_dianiktereuontes_epaggelma(startIndex, countIndex, arxiIM, telosIm, dianikPrakt)

                fuelle_dataset_epaggelma(startIndex, dianikPrakt)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub proepiskopisi_plirotitas_dwmatiwn(ByVal arxiIm As Date, ByVal daysCount As Int16)
        Dim i As Int16
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New PlirotitaPraktoreiwn()

        Me.DbhotelDataSet.ekt_imeres_status_dwm.Rows.Add()
        Me.DbhotelDataSet.ekt_imeres_status_dwm1.Rows.Add()
        For i = 0 To daysCount - 1
            Me.DbhotelDataSet.ekt_imeres_status_dwm(0).Item(i) = arxiIm.AddDays(i).Day
            Me.DbhotelDataSet.ekt_imeres_status_dwm1(0).Item(i) = welche_tag_der_woche(arxiIm.AddDays(i).DayOfWeek)
        Next

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Sub proepiskopisi_dianiktereusewn(ByVal arxiIm As Date, ByVal daysCount As Int16)
        Dim i As Int16
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New DianiktereuseisMina()

        Me.DbhotelDataSet.ekt_imeres_status_dwm.Rows.Add()
        Me.DbhotelDataSet.ekt_imeres_status_dwm1.Rows.Add()

        For i = 0 To daysCount - 1
            Me.DbhotelDataSet.ekt_imeres_status_dwm(0).Item(i) = arxiIm.AddDays(i).Day
            Me.DbhotelDataSet.ekt_imeres_status_dwm1(0).Item(i) = welche_tag_der_woche(arxiIm.AddDays(i).DayOfWeek)
        Next

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Function berechne_kratiseis_praktoreiou(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef plirotPrakt() As Int16) As Int16
        Dim countAfix, startindex As Int16
        Dim counter As Int16 'metra tis kratiseis tou group tou praktoreiou->group= Idia afixi kai anaxwrisi

        startindex = datasetIndex
        'edw opws panw me ta praktoreia psaxnw tis kratiseis ana parktoreio me IDIA afixi, anaxwrisi (GROUP)

        Do Until startindex > (datasetIndex + countIndex - 1)
            counter = 1
            If startindex < (datasetIndex + countIndex - 1) Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startindex).afixi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).afixi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).anaxwrisi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).anaxwrisi
                    counter += 1
                    If startindex + counter > (datasetIndex + countIndex - 1) Then
                        Exit While
                    End If
                End While
                countAfix = countAfix + rechne_kratiseis_praktoreiou_ana_group(startindex, counter, arxiIm, telosIm, plirotPrakt)
                startindex = startindex + counter
            Else
                countAfix = countAfix + rechne_kratiseis_praktoreiou_ana_group(startindex, counter, arxiIm, telosIm, plirotPrakt)
                Exit Do

            End If
        Loop
        Return countAfix
    End Function
    Private Function rechne_kratiseis_praktoreiou_ana_group(ByVal k As Int16, ByVal counter As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef plirotPrakt() As Int16) As Int16
        Dim zeiger1, zeiger2, countAfix As Int16

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = plirotPrakt.Length - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
        Else
            zeiger2 = -1
        End If

        'If Me.DbhotelDataSet.dianiktereuseis_mina(k).checkin Then
        countAfix += counter
        'End If

        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            setze_kratiseis_praktoreiou(zeiger1, zeiger2, counter, plirotPrakt)
            'fulle_dataset()
        End If

        Return countAfix
    End Function
    Private Function berechne_dianiktereuontes_praktoreiou(ByVal datasetindex As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianikPrakt() As Int16)
        Dim countDian, startIndex, atoma, kinder, kind1, kind2 As Int16
        Dim counter As Int16 'metra tis kratiseis tou group tou praktoreiou->group= Idia afixi kai anaxwrisi

        startIndex = datasetindex
        'edw opws panw me ta praktoreia psaxnw tis kratiseis ana parktoreio me IDIA afixi, anaxwrisi (GROUP)

        Do Until startIndex > (datasetindex + countIndex - 1)
            counter = 1
            If startIndex < (datasetindex + countIndex - 1) Then
                'einai sortiert kata prakt,afix,anax, enilikes, paidia gia besseres programmieren
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).afixi = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).afixi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anaxwrisi = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).anaxwrisi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).enilikes = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).enilikes
                    'AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).paidia
                    'den mporw na balw stin while anfrage ean ta paidia einai ta idia giati ean i kratisi den exei paidia exei ERROR

                    Try
                        kind1 = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).paidia
                    Catch ex As StrongTypingException
                        kind1 = 0
                    End Try
                    Try
                        kind2 = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).paidia
                    Catch ex As StrongTypingException
                        kind2 = 0
                    End Try

                    If kind1 = kind2 Then
                        counter += 1
                        If startIndex + counter > (datasetindex + countIndex - 1) Then
                            Exit While
                        End If
                    Else
                        Exit While
                    End If

                End While

                Try
                    kinder = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).paidia
                Catch ex As StrongTypingException
                    kinder = 0
                End Try
                atoma = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).enilikes + kinder

                countDian = countDian + rechne_dianiktereuontes_praktoreiou_group(startIndex, counter * atoma, arxiIm, telosIm, dianikPrakt)
                startIndex = startIndex + counter
            Else
                Try
                    kinder = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).paidia
                Catch ex As StrongTypingException
                    kinder = 0
                End Try
                atoma = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).enilikes + kinder

                countDian = countDian + rechne_dianiktereuontes_praktoreiou_group(startIndex, counter * atoma, arxiIm, telosIm, dianikPrakt)
                Exit Do

            End If
        Loop
        Return countDian

    End Function
    Private Function rechne_dianiktereuontes_praktoreiou_group(ByVal k As Int16, ByVal atoma As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianikPrakt() As Int16) As Int16
        Dim zeiger1, zeiger2, countDian As Int16

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = dianikPrakt.Length - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
        Else
            zeiger2 = -1
        End If


        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            countDian = setze_dianiktereuontes_praktoreiou(zeiger1, zeiger2, atoma, dianikPrakt)
            'fulle_dataset()
        End If
        Return countDian
    End Function
    Private Function berechne_dianiktereuontes_ethnikotitas(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef ethnikPrakt() As Int16) As Int16
        Dim startIndex, counter, countEthnik, anzEthnik1 As Int16

        startIndex = datasetIndex
        Do Until startIndex > (datasetIndex + countIndex - 1)
            counter = 1
            If startIndex < (datasetIndex + countIndex - 1) Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).afixi = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).afixi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anaxwrisi = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).anaxwrisi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anzethnikotites = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + counter).anzethnikotites
                    counter += 1
                    If startIndex + counter > (datasetIndex + countIndex - 1) Then
                        Exit While
                    End If
                End While
                anzEthnik1 = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anzethnikotites
                countEthnik = countEthnik + rechne_dianiktereuontes_ethnikotitas(startIndex, counter * anzEthnik1, arxiIm, telosIm, ethnikPrakt)
                startIndex = startIndex + counter
            Else
                anzEthnik1 = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anzethnikotites
                countEthnik = countEthnik + rechne_dianiktereuontes_ethnikotitas(startIndex, anzEthnik1, arxiIm, telosIm, ethnikPrakt)
                Exit Do

            End If
        Loop
        Return countEthnik



    End Function
    Private Function rechne_dianiktereuontes_ethnikotitas(ByVal k As Int16, ByVal anzEthnik As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef ethnikPrakt() As Int16) As Int16
        Dim zeiger1, zeiger2, countEthnik As Int16


        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = ethnikPrakt.Length - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
        Else
            zeiger2 = -1
        End If



        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            countEthnik = setze_dianiktereuontes_ethnikotitas(zeiger1, zeiger2, anzEthnik, ethnikPrakt)
            'fulle_dataset()
        End If
        Return countEthnik

    End Function
    Private Sub berechne_dianiktereuontes_epaggelma(ByVal startindex As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianikPrakt() As Int16)
        Dim k, zeiger1, zeiger2 As Int16

        For k = startindex To (startindex + countIndex - 1)

            If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
                zeiger1 = 0
            ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
                zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
            Else
                zeiger1 = -1
            End If

            If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
                zeiger2 = dianikPrakt.Length - 1
            ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
                zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
            Else
                zeiger2 = -1
            End If
            If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
                setze_dianiktereuontes_epaggelmatos(zeiger1, zeiger2, dianikPrakt)
                'fulle_dataset()
            End If
        Next
    End Sub
    Private Sub setze_kratiseis_praktoreiou(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal counter As Int16, ByRef plirotPrakt() As Int16)
        Dim i As Int16


        For i = zeiger1 To zeiger2

            plirotPrakt(i) = plirotPrakt(i) + counter
        Next

    End Sub
    Private Function setze_dianiktereuontes_praktoreiou(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal atoma As Int16, ByRef dianikPrakt() As Int16) As Int16
        Dim i, sum As Int16 ', enilikes, paidia


        For i = zeiger1 To zeiger2
            dianikPrakt(i) = dianikPrakt(i) + atoma
            sum = sum + atoma
        Next
        Return sum
    End Function
    Private Function setze_dianiktereuontes_ethnikotitas(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal anzethnikotita As Int16, ByRef ethnikPrakt() As Int16) As Int16
        Dim i, sum As Int16


        For i = zeiger1 To zeiger2

            'anzethnikotita = Me.DbhotelDataSet.dianiktereuseis_mina(index).anzethnikotites

            ethnikPrakt(i) = ethnikPrakt(i) + anzethnikotita
            sum = sum + anzethnikotita
        Next
        Return sum
    End Function
    Private Sub setze_dianiktereuontes_epaggelmatos(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByRef dianikPrakt() As Int16)
        Dim i As Int16

        For i = zeiger1 To zeiger2
            dianikPrakt(i) = dianikPrakt(i) + 1
        Next

    End Sub
    Private Sub fuelle_dataset_plirotita(ByVal startIndex As Int16, ByVal plirotPrakt() As Int16, ByVal countAfix As Int16, ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim i, sum, sumAllotm As Int16


        Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).eponimia

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).afixeis = countAfix
        sumAllotm = berechne_sum_allotm_praktoreiou(Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).praktoreio, daysCount, arxiIM, telosIm)
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).allotment = sumAllotm

        For i = 0 To plirotPrakt.Length - 1
            If plirotPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = plirotPrakt(i).ToString
                sum = sum + plirotPrakt(i)
            End If
        Next
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = sum
        If sumAllotm <> 0 Then
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).kalypsi = (sum / sumAllotm) * 100
        End If

    End Sub

    Private Function berechne_sum_allotm_praktoreiou(ByVal praktKwd As Integer, ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date) As Int16
        Dim j As Int16
        Dim allotmDay(), sumAllotm As Int16

        ReDim allotmDay(daysCount - 1)
        Me.Allotment_praktoreouTableAdapter.FillAllotmByPraktApMexr(Me.DbhotelDataSet.allotment_praktoreou, praktKwd, arxiIM, arxiIM, praktKwd, telosIm, telosIm, praktKwd, arxiIM, telosIm)
        If Me.DbhotelDataSet.allotment_praktoreou.Count <> 0 Then
            For j = 0 To daysCount - 1
                allotmDay(j) = setze_anzahl_von_allotment_am_tag(j, arxiIM)
                sumAllotm = sumAllotm + allotmDay(j)
            Next

        End If
      
        Return sumAllotm

    End Function
    Private Function setze_anzahl_von_allotment_am_tag(ByVal indTag As Int16, ByVal arxiIM As Date) As Int16
        Dim j, sumAllotm As Int16

        For j = 0 To Me.DbhotelDataSet.allotment_praktoreou.Count - 1
            If Me.DbhotelDataSet.allotment_praktoreou(j).apo <= arxiIM.AddDays(indTag) And Me.DbhotelDataSet.allotment_praktoreou(j).mexri >= arxiIM.AddDays(indTag) Then

                sumAllotm = sumAllotm + Me.DbhotelDataSet.allotment_praktoreou(j).anzahl

            End If
        Next
        Return sumAllotm

    End Function
    Private Sub fuelle_dataset_praktoreia(ByVal startIndex As Int16, ByVal countDian As Int16, ByVal dianikPrakt() As Int16)
        Dim i As Int16


        Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).eponimia


        For i = 0 To dianikPrakt.Length - 1
            If dianikPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = dianikPrakt(i).ToString
                'sum = sum + dianikPrakt(i)
            End If
        Next
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = countDian
    End Sub
    Private Sub fuelle_dataset_ethikotites(ByVal startIndex As Int16, ByVal countEthnik As Int16, ByVal ethnikPrakt() As Int16)
        Dim i As Int16

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).ethnikotita
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).ethnikkwd = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).ethnikkwd1

        For i = 0 To ethnikPrakt.Length - 1
            If ethnikPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = ethnikPrakt(i).ToString
                'sum = sum + ethnikPrakt(i)
            End If
        Next
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = countEthnik
    End Sub
    Private Sub make_diorthoseis_ethnikotites(ByVal minas As Int16, ByVal etos As Int16, ByVal daysCount As Int16)
        Dim j, i, altzahl, neuzahl, index As Int16
        Dim tempEthnKwd() As Int16 '->o kwdikos twn ethnikotitwn sto db einai int16

        ReDim tempEthnKwd(-1)

        Me.EthnikdiorthoseisTableAdapter.FillEthnikotitesminos(Me.DbhotelDataSet.ethnikdiorthoseis, etos, minas)
        For j = 0 To Me.DbhotelDataSet.ethnikdiorthoseis.Count - 1
            ReDim Preserve tempEthnKwd(j)
            tempEthnKwd(j) = Me.DbhotelDataSet.ethnikdiorthoseis(j).ethnikotita
        Next

        For j = 0 To tempEthnKwd.Length - 1

            Me.EthnikdiorthoseisTableAdapter.FillByEthnikEtosMinas(Me.DbhotelDataSet.ethnikdiorthoseis, tempEthnKwd(j), etos, minas)

            kwdDEthnik = tempEthnKwd(j)
            ReDim ethnik(daysCount - 1)
            init_ethnik() '->setze alles -1 !
            lade_db_zu_dtstrk()
            index = finde_index_von_ethnik_in_dataset(kwdDEthnik)
            If index <> -1 Then
                For i = 0 To ethnik.Length - 1
                    If ethnik(i) <> -1 Then
                        Try
                            altzahl = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).Item(i + 1)
                        Catch ex As InvalidCastException
                            altzahl = 0
                        End Try

                        neuzahl = ethnik(i)
                        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).sum = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).sum - altzahl + neuzahl

                        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).Item(i + 1) = neuzahl

                    End If
                Next
            Else
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.get_ethikotita_by_kwdiko(kwdDEthnik)
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).ethnikkwd = kwdDEthnik
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = 0
                For i = 0 To ethnik.Length - 1
                    If ethnik(i) <> -1 Then
                        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum + ethnik(i)
                        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = ethnik(i)
                    End If
                Next
            End If

        Next
    End Sub
    Private Sub fuelle_dataset_epaggelma(ByVal startIndex As Int16, ByVal dianikPrakt() As Int16)
        Dim i, sum As Int16

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()

        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).epaggelma

        For i = 0 To dianikPrakt.Length - 1
            If dianikPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = dianikPrakt(i).ToString
                sum = sum + dianikPrakt(i)
            End If
        Next
        Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = sum
    End Sub
    Private Sub fuelle_zweite_ethnikotita_zu_dataset(ByVal daysCount As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            If Me.DbhotelDataSet.dianiktereuseis_mina(j).ethnikkwd2 > 0 AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(j).anzethnikotites2 > 0 Then

                zweite_ethnik_hinzu(j, Me.DbhotelDataSet.dianiktereuseis_mina(j).ethnikkwd2, Me.DbhotelDataSet.dianiktereuseis_mina(j).anzethnikotites2, arxiIM, telosIm, daysCount)

            End If

        Next
    End Sub
    Private Sub zweite_ethnik_hinzu(ByVal k As Int16, ByVal ethnKwd As Integer, ByVal anzahlEthn As Int16, ByVal arxiIM As Date, ByVal telosIm As Date, ByVal daysCount As Int16)
        Dim zeiger1, zeiger2, index, i, sum As Int16

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIM Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIM And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIM.DayOfYear
        Else
            zeiger1 = -1
        End If
        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = daysCount - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIM And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIM.DayOfYear
        Else
            zeiger2 = -1
        End If
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            index = finde_index_von_ethnik_in_dataset(ethnKwd)
            'MsgBox(ethnKwd)
            If index <> -1 Then
                For i = zeiger1 To zeiger2
                    'MsgBox(Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).Item(i + 1))
                    Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).Item(i + 1) = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).Item(i + 1) + anzahlEthn
                    sum = sum + anzahlEthn
                Next
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).sum = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(index).sum + sum
            Else
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()
                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = Me.get_ethikotita_by_kwdiko(ethnKwd)
                'MsgBox(Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio)

                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).ethnikkwd = ethnKwd

                For i = zeiger1 To zeiger2
                    Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = anzahlEthn
                    sum = sum + anzahlEthn
                Next

                Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = sum
            End If

            'fulle_dataset()
        End If
    End Sub
    Private Function finde_index_von_ethnik_in_dataset(ByVal ethnKwd As Integer) As Int16
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1
            'MsgBox(Me.DbhotelDataSet.ekt_dianikt_ana_prakt(j).ethnikkwd)
            'MsgBox(ethnKwd)
            If Me.DbhotelDataSet.ekt_dianikt_ana_prakt(j).ethnikkwd = ethnKwd Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Function get_ethikotita_by_kwdiko(ByVal kwd As Integer) As String
        Try
            Return Me.EthnikotitesTableAdapter.GetEthnikotitaByKwd(kwd)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub init_dianiktreuseis_praktoreiou(ByRef dianikPrakt() As Int16)
        Dim j As Int16

        For j = 0 To dianikPrakt.Length - 1
            dianikPrakt(j) = 0
        Next
    End Sub
    Private Function welche_tag_der_woche(ByVal day As Integer) As String
        Select Case day
            Case 0
                Return "Κυ"
            Case 1
                Return "Δε"
            Case 2
                Return "Τρ"
            Case 3
                Return "Τε"
            Case 4
                Return "Πε"
            Case 5
                Return "Πα"
            Case 6
                Return "Σα"
        End Select
        Return Nothing
    End Function
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
    '*******************HLIKIES*****************HLIKIES*****************HLIKIES*****************HLIKIES*****************HLIKIES
    Private Sub ilikies()
        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Ηλικίες"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        HlikiesPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.HlikiesPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        HlikiesPck.MinDate = "1/1/" + etos.ToString
        HlikiesPck.MaxDate = "31/12/" + etos.ToString
        Me.HlikiesPck.CustomFormat = "MM/yyyy"
        Me.HlikiesPck.Value = imeromErgasias
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(HlikiesPnl)
    End Sub
    Private Sub IlikiaTbx1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IlikiaTbx1.Leave, IlikiaTbx2.Leave, IlikiaTbx3.Leave, _
    IlikiaTbx4.Leave, IlikiaTbx5.Leave, IlikiaTbx6.Leave, IlikiaTbx7.Leave, IlikiaTbx8.Leave
        Dim s, zahl As Int16
        Dim find() As Control


       
        Try
            If CType(sender.text, Int16) <= 0 Then
                MsgBox(" Η Ηλικία πρέπει να είναι μεγαλύτερη από μηδέν !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                s = CType(sender.NAME.ToString.Substring(sender.NAME.ToString.Length - 1, 1), Int16)
                ilikRande(s - 1) = -1
                sender.clear()
                Exit Sub
            Else
                zahl = sender.text
            End If
        Catch ex As InvalidCastException
            s = CType(sender.NAME.ToString.Substring(sender.NAME.ToString.Length - 1, 1), Int16)
            ilikRande(s - 1) = -1
            sender.clear()
            Exit Sub
        End Try

        s = CType(sender.NAME.ToString.Substring(sender.NAME.ToString.Length - 1, 1), Int16)
        find = Hlikies2Pnl.Controls.Find("IlikiaTbx" + (s - 1).ToString, False)

        Try
            If CType(find(0).Text, Int16) > 0 Then
                If find(0).Text >= zahl - 1 Then
                    MsgBox(" Η Ηλικία πρέπει να είναι (αρκετά) μεγαλύτερη της προηγούμενης: " + find(0).Text, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    ilikRande(s - 1) = zahl
                    Exit Sub
                End If
            End If
        Catch ex As IndexOutOfRangeException
        Catch ex1 As InvalidCastException
            MsgBox("Δώστε αριθμό !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            ilikRande(s - 1) = zahl
            Exit Sub
        End Try
        find = Hlikies2Pnl.Controls.Find("IlikiaTbx" + (s + 1).ToString, False)
        Try
            If CType(find(0).Text, Int16) <= zahl + 1 Then
                MsgBox(" Η Ηλικία πρέπει να είναι (αρκετά) μικρότερη της επόμενης: " + find(0).Text, MsgBoxStyle.Exclamation, "winfo\nikEl.")
                ilikRande(s - 1) = zahl
                Exit Sub
            End If
        Catch ex As IndexOutOfRangeException
        Catch ex1 As InvalidCastException
        End Try

        ilikRande(s - 1) = zahl
    End Sub
    Private Sub HlikiesBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HlikiesBtn.Click
        Dim first, last, i, j, minas, daysCount As Int16 ', index
        Dim ilikKat() As Rande
        Dim arxiIm, telosIm, laufDate As Date
        Dim dianikIlik() As Int16
        'Dim katigoria As String

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DbhotelDataSet.dianiktereuseis_mina.Clear()
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Clear()
            Me.DbhotelDataSet.ekt_status_ekdosi.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm1.Clear()

            ReDim dianikIlik(-1)

            Try
                first = finde_first()
                last = finde_last(first)
            Catch ex As IndexOutOfRangeException
                MsgBox(" Λάθος Ηλικίες ", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try


            If first <> -1 And last <> -1 Then
                If first <= last Then
                    ReDim ilikKat(last - first)
                    For i = first To last

                        If i = first Then
                            ilikKat(0).apo = 0
                            ilikKat(0).mexri = ilikRande(first)
                        Else
                            ilikKat(i - first).apo = ilikRande(i - 1) + 1
                            ilikKat(i - first).mexri = ilikRande(i)
                        End If
                    Next
                    minas = HlikiesPck.Value.Month

                    arxiIm = "1/" + minas.ToString + "/" + etos.ToString
                    If HlikiesPck.Value.Month + 1 <= 12 Then
                        telosIm = "1/" + (minas + 1).ToString + "/" + etos.ToString
                        telosIm = telosIm.AddDays(-1)
                    Else
                        telosIm = "31/12/" + etos.ToString
                    End If

                    'poses meres exei o minas ->28,30,31
                    laufDate = arxiIm.AddDays(27)
                    While laufDate.Month = HlikiesPck.Value.Month
                        laufDate = laufDate.AddDays(1)
                    End While

                    daysCount = laufDate.AddDays(-1).Day
                    Me.Dianiktereuseis_minaTableAdapter.FillHlikiesPaidiaByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                                        telosIm, arxiIm, telosIm)
                    For j = 0 To Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
                        Try
                            If Me.DbhotelDataSet.dianiktereuseis_mina(j).ilikia <= 0 Then
                                Me.DbhotelDataSet.dianiktereuseis_mina(j).ilikia = -1
                            Else
                                rechne_ilikies(j, arxiIm, telosIm, daysCount, ilikKat)

                            End If
                        Catch ex As StrongTypingException

                        End Try
                    Next

                    Me.Dianiktereuseis_minaTableAdapter.FillHlikiesEnilikesByAfAnax(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                           telosIm, arxiIm, telosIm)

                    For j = 0 To Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
                        Try
                            If Me.DbhotelDataSet.dianiktereuseis_mina(j).genisi < imeromErgasias Then
                                Me.DbhotelDataSet.dianiktereuseis_mina(j).ilikia = imeromErgasias.Year - Me.DbhotelDataSet.dianiktereuseis_mina(j).genisi.Year
                                rechne_ilikies(j, arxiIm, telosIm, daysCount, ilikKat)
                            End If

                        Catch ex1 As StrongTypingException
                            Me.DbhotelDataSet.dianiktereuseis_mina(j).ilikia = -1
                        End Try

                    Next

                    Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()

                    Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias
                    Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = get_minas(minas) + " " + etos.ToString

                    Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = "ΗΛΙΚΙΕΣ"

                    proepiskopisi_dianiktereusewn(arxiIm, daysCount)
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try


    End Sub
    Private Sub rechne_ilikies(ByVal j As Int16, ByVal arxiIM As Date, ByVal telosIM As Date, ByVal daysCount As Int16, ByRef IlikKat() As Rande)
        Dim index As Int16
        Dim katigoria As String
        Dim dianikIlik() As Int16
        index = finde_stelle(IlikKat, Me.DbhotelDataSet.dianiktereuseis_mina(j).ilikia)

        If index <> -1 Then
            ReDim dianikIlik(daysCount - 1)
            berechne_ilikies(j, arxiIM, telosIM, dianikIlik)
            katigoria = IlikKat(index).apo.ToString + "-" + IlikKat(index).mexri.ToString
            index = finde_eintrag_in_dataset(IlikKat(index).apo.ToString + "-" + IlikKat(index).mexri.ToString)
            'If index <> -1 Then
            '    katigoria = IlikKat(index).apo.ToString + "-" + IlikKat(index).mexri.ToString
            'End If
            fuelle_dataset_ilikies(index, katigoria, dianikIlik)
        End If


    End Sub
    Private Sub berechne_ilikies(ByVal k As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianikIlik() As Int16)
        Dim zeiger1, zeiger2 As Int16

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = dianikIlik.Length - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
        Else
            zeiger2 = -1
        End If
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            setze_ilikies(zeiger1, zeiger2, k, dianikIlik)
            'fulle_dataset()
        End If

    End Sub
    Private Sub fuelle_dataset_ilikies(ByVal startIndex As Int16, ByVal katigoria As String, ByVal dianikIlik() As Int16)
        Dim i, sum As Int16

        If startIndex <> -1 Then
            For i = 0 To dianikIlik.Length - 1
                If dianikIlik(i) <> 0 Then
                    Me.DbhotelDataSet.ekt_dianikt_ana_prakt(startIndex).Item(i + 1) = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(startIndex).Item(i + 1) + dianikIlik(i).ToString
                    sum = sum + dianikIlik(i)
                End If
            Next
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt(startIndex).sum = Me.DbhotelDataSet.ekt_dianikt_ana_prakt(startIndex).sum + sum
        Else
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Rows.Add()
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio = katigoria
            For i = 0 To dianikIlik.Length - 1
                If dianikIlik(i) <> 0 Then
                    Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).Item(i + 1) = dianikIlik(i).ToString
                    sum = sum + dianikIlik(i)
                End If
            Next
            Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).sum = sum
        End If

    End Sub
    Private Function finde_eintrag_in_dataset(ByVal katigoria As String) As Int16
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1
            If Me.DbhotelDataSet.ekt_dianikt_ana_prakt(j).praktoreio = katigoria Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Function finde_stelle(ByVal IlikKat() As Rande, ByVal ilikia As Int16) As Int16
        Dim j As Int16

        For j = 0 To IlikKat.Length - 1
            If ilikia >= IlikKat(j).apo AndAlso ilikia <= IlikKat(j).mexri Then
                Return j
            End If
        Next
        Return -1

    End Function
    Private Sub setze_ilikies(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal index As Int16, ByRef dianikIlik() As Int16)
        Dim i As Int16


        For i = zeiger1 To zeiger2
            dianikIlik(i) = dianikIlik(i) + 1
        Next

    End Sub
    Private Function finde_first() As Int16
        Dim j As Int16

        For j = 0 To 7
            If ilikRande(j) <> -1 Then
                Return j
            End If
        Next
        Return -1

    End Function
    Private Function finde_last(ByVal first As Int16) As Int16
        Dim j As Int16

        For j = first To 6
            If ilikRande(j) >= ilikRande(j + 1) - 1 Then
                Return j
            End If
        Next
        If j = 7 AndAlso ilikRande(j - 1) < ilikRande(j) - 1 Then
            Return j
        Else
            Return j - 1
        End If
        Return -1

    End Function
    Private Sub init_rande()
        Dim j As Int16

        For j = 0 To 7
            ilikRande(j) = -1
        Next
    End Sub
    '*************LISTA OVER*********************************************
    Private Sub lista_over()

        EtiketaLbl.Text = "Διαμονές εκτός Ξενοδοχείου"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        OverPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.OverPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        overPck.MinDate = "1/1/" + etos.ToString
        overPck.MaxDate = "31/12/" + etos.ToString
        overPck.CustomFormat = "MM/yyyy"
        overPck.Value = "1/" + imeromErgasias.Month.ToString + "/" + etos.ToString
       
        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(OverPnl)

    End Sub
    Private Sub OverBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverBtn.Click
        Dim apo, mexri As Date
        apo = "1/" + overPck.Value.Month.ToString + "/" + etos.ToString
        mexri = "1/" + (overPck.Value.Month + 1).ToString + "/" + etos.ToString

        Me.OverTableAdapter.FillListaOverMina(Me.DbhotelDataSet.over, apo, mexri)
        proepiskopisi_over()
    End Sub
    Private Sub proepiskopisi_over()
        Dim i As Int16
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New OverLista()


        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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

    '***************ESODA ANA PRAKTOREIO*************ESODA ANA PRAKTOREIO********************ESODA ANA PRAKTOREIO***********ESODA ANA PRAKTOREIO*******
    '***************ESODA ANA PRAKTOREIO*************ESODA ANA PRAKTOREIO********************ESODA ANA PRAKTOREIO***********ESODA ANA PRAKTOREIO*******
    '***************ESODA ANA PRAKTOREIO*************ESODA ANA PRAKTOREIO********************ESODA ANA PRAKTOREIO***********ESODA ANA PRAKTOREIO*******
    '***************ESODA ANA PRAKTOREIO*************ESODA ANA PRAKTOREIO********************ESODA ANA PRAKTOREIO***********ESODA ANA PRAKTOREIO*******
    Private Sub esoda_ana_praktoreio()
        Dim mexri As Date

        kwdPrakt = -1
        PraktEsodaTbx.Clear()
        kwdSimb = -1
        PraktEsodaCbx.SelectedIndex = -1

        EtiketaLbl.Text = "Κατανομή Εσόδων ανά Πρακτορείο"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        PraktEsodaPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.PraktEsodaPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        ApoPck.MinDate = "1/1/" + etos.ToString
        ApoPck.MaxDate = "31/12/" + etos.ToString
        MexriPck.MinDate = "1/1/" + etos.ToString
        MexriPck.MaxDate = "31/12/" + etos.ToString
        ApoPck.Value = "1/" + imeromErgasias.Month.ToString + "/" + etos.ToString
        If imeromErgasias.Month + 1 <= 12 Then
            mexri = "1/" + (imeromErgasias.Month + 1).ToString + "/" + etos.ToString
            MexriPck.Value = mexri.AddDays(-1)
        Else
            MexriPck.Value = "31/12/" + etos.ToString
        End If
        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(PraktEsodaPnl)

    End Sub
    Private Sub PraktEsodaTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktEsodaTbx.Click
        Dim PraktForm As New SimbolaiaFrm()
        Dim kwdikos As Integer
        'initialisieren_felder_variablen()

        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        kwdikos = PraktForm.return_praktoreio_kwdikos

        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            kwdSimb = -1
            kwdPrakt = -1
            PraktEsodaTbx.Text = "< όλα >"
            PraktEsodaCbx.Enabled = False
            Exit Sub
        ElseIf kwdPrakt <> kwdikos Then
            kwdPrakt = kwdikos
            PraktEsodaTbx.Text = PraktForm.return_praktoreio

        End If
        If kwdPrakt <> -1 Then
            PraktEsodaCbx.Enabled = True
            fuelle_simb_cbx()
        End If
    End Sub
    Private Sub fuelle_simb_cbx()
        Dim j As Int16
        Me.PraktEsodaCbx.SelectedIndex = -1
        Me.PraktEsodaCbx.Items.Clear()
        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, kwdPrakt, etos)

        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If j <> 0 Then
                PraktEsodaCbx.Items.Add(Me.DbhotelDataSet.simbolaia(j - 1).aasimbolaiou)
            Else
                PraktEsodaCbx.Items.Add("Ολα")
            End If

        Next
    End Sub

    Private Sub PraktEsodaCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktEsodaCbx.SelectedIndexChanged
        Dim simbolaioTemp As Integer

     
        If sender.selectedindex > 0 Then
            simbolaioTemp = get_kwd_simbol_byAA(PraktEsodaCbx.SelectedItem.ToString) ', praktoreiokwd)
            If simbolaioTemp = -1 Then
                Exit Sub
            Else
                kwdSimb = simbolaioTemp
            End If
        Else
            kwdSimb = -1
        End If

    End Sub
    Private Sub PraktEsodaBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktEsodaBtn.Click
        Dim j As Int16
        Dim maxKwdPrakt, kwdAllIncl, startminas, stopminas As Integer
        'maxKwdPrakt einai o megaliteros kwdikos praktoreiou +1 ->TRIK gia ektiposi synolou Praktoreiwn sto CReport
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DbhotelDataSet.esoda_praktoreiwn.Clear()
            Me.DbhotelDataSet.ekt_esodwn_prakt.Clear()
            Me.DbhotelDataSet.ektiposeis_genika.Clear()

            If ApoPck.Value.Date <= MexriPck.Value.Date And ApoPck.Value.Year = MexriPck.Value.Year And ApoPck.Value.Year = imeromErgasias.Year Then
                'epeidi stin ektiposi yparxei sto telos SYNOLO olwn to praktoreiwn kanw manipulieren to praktoreio "synolo" me kwd max+1 wste to Crystal report na to balei sto telos
                maxKwdPrakt = Me.PraktoreiaTableAdapter.GetMaxKwd
                Try
                    kwdAllIncl = Me.XrewseisTableAdapter.GetKwdByXrewsi("AI")
                Catch ex As InvalidOperationException
                    kwdAllIncl = 0
                End Try

                maxKwdPrakt = maxKwdPrakt + 1
                startminas = ApoPck.Value.Month
                stopminas = MexriPck.Value.Month

                'analoga me epilogi PRAKTOREIOY kanw Join anfrage kratiseis X timeskratiseis sortiert kata praktoreia
                If kwdSimb = -1 And kwdPrakt = -1 Then
                    Me.Esoda_praktoreiwnTableAdapter.FillByAfAnx2(Me.DbhotelDataSet.esoda_praktoreiwn, True, ApoPck.Value.Date, ApoPck.Value.Date, True, ApoPck.Value.Date, ApoPck.Value.Date, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                              True, ApoPck.Value.Date, MexriPck.Value.Date)

                ElseIf kwdPrakt <> -1 And kwdSimb = -1 Then
                    Me.Esoda_praktoreiwnTableAdapter.FillByPraktAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, kwdPrakt, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdPrakt, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                                          kwdPrakt, True, ApoPck.Value.Date, MexriPck.Value.Date)

                ElseIf kwdPrakt <> -1 And kwdSimb <> -1 Then
                    Me.Esoda_praktoreiwnTableAdapter.FillBySimbAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, kwdSimb, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdSimb, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                             kwdSimb, True, ApoPck.Value.Date, MexriPck.Value.Date)
                End If


                If ImerisRdb.Checked Then
                    imerisia_ektiposi(maxKwdPrakt, kwdAllIncl)
                    Me.DbhotelDataSet.esoda_praktoreiwn.Clear()
                    'Join anfrage Kratiseis X timeskratiseis GROUPIERT kata kwdiko...etsi wste pro Kratisi 1 MONO tupel (1 X 1) etsi wste
                    'apo to synolo stin kratis kai to SUM(timeskratisis.synolo) na bgalw tin EKPTOSI !!!!!!!!! (se EURW)
                    If kwdSimb = -1 And kwdPrakt = -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FilDiaforeslByChkinAfAnxEkptosi(Me.DbhotelDataSet.esoda_praktoreiwn, True, True, ApoPck.Value.Date, ApoPck.Value.Date, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                 True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    ElseIf kwdPrakt <> -1 And kwdSimb = -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FillDiaforesByPraktAfAnx(Me.DbhotelDataSet.esoda_praktoreiwn, kwdPrakt, True, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdPrakt, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                                  kwdPrakt, True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    ElseIf kwdPrakt <> -1 And kwdSimb <> -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FillDiaforesBySimbAfAnx(Me.DbhotelDataSet.esoda_praktoreiwn, kwdSimb, True, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdSimb, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                                                    kwdSimb, True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    End If


                    berechne_imerisies_ekptoseis_prakt(maxKwdPrakt)
                    proepiskopisi_imerisiwn_esodwn_prakt()
                Else
                    For j = startminas To stopminas
                        miniaia_ektiposi(j, kwdAllIncl)

                        If kwdPrakt = -1 Then ' ean den exei epilogei praktoreio tote to teleutaio eintrag tha einai to synolo olwn twn praktoreiwn
                            Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = maxKwdPrakt
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = "ΣΥΝΟΛΟ"
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas_nummer = j
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas = Me.get_minas(j)
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).dwmatia = sumsumDwm
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).enilikes = sumsumEnil
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).paidia = sumsumPaidia
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diamoni = sumsumDiam
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).allinclusiv = sumsumAll
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).prwina = sumsumPrwin
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).geumata = sumsumGeum
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).extras = sumsumExtr
                            Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).synolo = sumsumSyn
                            'Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diafores = sumsumDiaf
                        End If
                        'berechne_miniaies_ekptoseis_prakt(maxKwdPrakt)
                        init_sumsum_variablen()
                    Next
                    If kwdSimb = -1 And kwdPrakt = -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FilDiaforeslByChkinAfAnxEkptosi(Me.DbhotelDataSet.esoda_praktoreiwn, True, True, ApoPck.Value.Date, ApoPck.Value.Date, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                 True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    ElseIf kwdPrakt <> -1 And kwdSimb = -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FillDiaforesByPraktAfAnx(Me.DbhotelDataSet.esoda_praktoreiwn, kwdPrakt, True, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdPrakt, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                                  kwdPrakt, True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    ElseIf kwdPrakt <> -1 And kwdSimb <> -1 Then
                        Me.Esoda_praktoreiwnTableAdapter.FillDiaforesBySimbAfAnx(Me.DbhotelDataSet.esoda_praktoreiwn, kwdSimb, True, True, ApoPck.Value.Date, ApoPck.Value.Date, kwdSimb, True, True, MexriPck.Value.Date, MexriPck.Value.Date, _
                                                                    kwdSimb, True, True, ApoPck.Value.Date, MexriPck.Value.Date)
                    End If
                    berechne_miniaies_ekptoseis_prakt(maxKwdPrakt)
                    proepiskopisi_miniaiwn_esodwn_prakt()
                End If


            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub imerisia_ektiposi(ByVal maxKwdPrakt As Integer, ByVal kwdAllIncl As Integer)
        Dim tempPraktKwd As Integer
        Dim j, sumEnil, sumPaidia, sumDwm As Int16
        Dim sumDiam, sumAll, sumPrwin, sumGeum, sumExtr, sumSyn, sumDiaf, posoDiaf As Single
        Dim laufDate As Date

        laufDate = ApoPck.Value.Date

        While laufDate <= MexriPck.Value.Date

            tempPraktKwd = -1
            sumDwm = 0
            sumEnil = 0
            sumPaidia = 0
            sumDiam = 0
            sumAll = 0
            sumPrwin = 0
            sumGeum = 0
            sumExtr = 0
            sumSyn = 0
            sumDiaf = 0

            For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1

                If (Me.DbhotelDataSet.esoda_praktoreiwn(j).timesapo <= laufDate) AndAlso (Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri >= laufDate And laufDate <> Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi) Then

                    If tempPraktKwd <> Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd Then
                        Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = Me.DbhotelDataSet.esoda_praktoreiwn(j).eponimia
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).datum = laufDate
                        tempPraktKwd = Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd
                    End If

                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).dwmatia = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).dwmatia + 1
                    sumDwm = sumDwm + 1

                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).enilikes = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).enilikes + Me.DbhotelDataSet.esoda_praktoreiwn(j).enilikes
                    sumEnil = sumEnil + Me.DbhotelDataSet.esoda_praktoreiwn(j).enilikes

                    Try
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).paidia = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).paidia + Me.DbhotelDataSet.esoda_praktoreiwn(j).paidia
                        sumPaidia = sumPaidia + Me.DbhotelDataSet.esoda_praktoreiwn(j).paidia
                    Catch ex As StrongTypingException

                    End Try

                    If Me.DbhotelDataSet.esoda_praktoreiwn(j).xrewsikwd = kwdAllIncl Then
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).allinclusiv = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).allinclusiv + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                        sumAll = sumAll + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                    Else
                        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diamoni = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diamoni + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                        sumDiam = sumDiam + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                    End If
                    'MsgBox(Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).prwina = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).prwina + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino
                    sumPrwin = sumPrwin + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).geumata = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).geumata + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno
                    sumGeum = sumGeum + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).extras = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).extras + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra
                    sumExtr = sumExtr + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra

                    ''EAN EXEI BGEI MEMONOMENO TIMOLOGIO ME EKPTOSI
                    'posoDiaf = berechne_ekptoseis_mem_timologown(j, 1)

                    'Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diafores + posoDiaf
                    'sumDiaf = sumDiaf + posoDiaf

                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).synolo + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos + _
                   Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra + posoDiaf

                    sumSyn = sumSyn + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos + _
                   Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra + posoDiaf
                End If

            Next
            If kwdPrakt = -1 AndAlso kwdSimb = -1 Then
                If sumDwm > 0 OrElse sumEnil > 0 OrElse sumPaidia > 0 OrElse sumDiam > 0 OrElse sumAll > 0 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = maxKwdPrakt
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = "ΣΥΝΟΛΟ"
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).datum = laufDate
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).dwmatia = sumDwm
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).enilikes = sumEnil
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).paidia = sumPaidia
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diamoni = sumDiam
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).allinclusiv = sumAll
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).prwina = sumPrwin
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).geumata = sumGeum
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).extras = sumExtr
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).synolo = sumSyn
                    'Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diafores = sumDiaf
                End If
            End If
            laufDate = laufDate.AddDays(1)
        End While

    End Sub
    ' edw kanw kateutheian berechnen tis ekptoseis (kata tin Imerominia anaxwrisis)
    Private Sub berechne_imerisies_ekptoseis_prakt(ByVal maxKwdPrakt As Integer)
        Dim j, index, index2 As Int16
        Dim posoDiaf As Single
        For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi <= MexriPck.Value.Date Then
                posoDiaf = 0
                index = finde_imerisia_stelle_in_dataset(Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd, Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi)
                If index = -1 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = Me.DbhotelDataSet.esoda_praktoreiwn(j).eponimia
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).datum = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi
                    index = Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
                End If
                index2 = finde_imerisia_stelle_in_dataset(maxKwdPrakt, Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi)
                If index2 = -1 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = maxKwdPrakt
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = "ΣΥΝΟΛΟ"
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).datum = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi
                    index2 = Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
                End If
                If Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo

                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto / 100) / (1 - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto / 100)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo <> 0 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo
                    'pososto = Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres / (Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(j).afixi.DayOfYear)
                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * pososto) / (1 - pososto)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).fee <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).synola
                    'pososto = Me.DbhotelDataSet.esoda_praktoreiwn(j).fee / (Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(j).afixi.DayOfYear)
                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * pososto) / (1 + pososto)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores + posoDiaf
                End If

            End If
        Next


    End Sub
    Private Function finde_imerisia_stelle_in_dataset(ByVal praktKwd As Integer, ByVal datum As Date) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
            If praktKwd = Me.DbhotelDataSet.ekt_esodwn_prakt(j).praktkwd AndAlso datum = Me.DbhotelDataSet.ekt_esodwn_prakt(j).datum Then
                Return j
            End If
        Next
        Return -1
    End Function

    'EDW EXW KANEI AUSCSHALTEN TIS ARXIKES MOU BERECHNUNGEN GIA YPOLOGISMO TWN EKPTWSEWN ANA HMERA APO TA TIMOLOGIA  

    'Private Function finde_imerisia_stelle_in_dataset_synola(ByVal praktKwd As Integer, ByVal datum As Date) As Int16
    '    Dim j As Int16

    '    For j = 0 To Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
    '        If praktKwd = Me.DbhotelDataSet.ekt_esodwn_prakt(j).praktkwd AndAlso datum = Me.DbhotelDataSet.ekt_esodwn_prakt(j).datum Then
    '            Return j
    '        End If
    '    Next
    '    Return -1
    'End Function
    'Private Function berechne_ekptoseis_mem_timologown(ByVal index As Int16, ByVal countIndex As Int16) As Single
    '    Dim poso, ypnos, prwino, geuma, extra, hilfszahl As Single

    '    'sti timologioanalysis ta posa ypnoy,ypnoufpa ktl einai ta synolika kathara (gia oli thn paramoni)-> i ekptosi prepei na upologizetai kathe
    '    'fora!->epeidi yparxei periptosi ta pososta FPA na exoun alakse-->upologizw to fpa (19% ktl) apo ta epimeroys posa (ypnou, ypnoufpa)
    '    'kai epeita ta posa twn ekptosewn pou mpainoun stin stili "daifores" tis  ektiposis
    '    Try
    '        If Me.DbhotelDataSet.esoda_praktoreiwn(index).sumkathposa >= 0 Then

    '            If Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto > 0 Then
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
    '                    'MsgBox(ypnosNeto)
    '                    If fpaYpnou = 0 Then
    '                        berechne_pososta_fpa(index)
    '                    End If
    '                    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (1 + fpaYpnou / 100))
    '                    ypnos = (-hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
    '                    If fpaPrwinou = 0 Then
    '                        berechne_pososta_fpa(index)
    '                    End If
    '                    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (1 + fpaPrwinou / 100))
    '                    prwino = (-hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Or Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
    '                    If fpaTrofis = 0 Then
    '                        berechne_pososta_fpa(index)
    '                    End If
    '                    hilfszahl = ((Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno) / (1 + fpaTrofis / 100))
    '                    geuma = (-hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
    '                    If fpaExtra = 0 Then
    '                        berechne_pososta_fpa(index)
    '                    End If
    '                    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (1 + fpaExtra / 100))
    '                    extra = (-hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                poso = countIndex * (ypnos + prwino + geuma + extra)

    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo > 0 Then
    '                If fpaYpnou = 0 Then
    '                    berechne_pososta_fpa(index)
    '                End If
    '                poso = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo / (1 + fpaYpnou / 100))
    '                poso = countIndex * (poso / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)

    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres > 0 Then
    '                If fpaYpnou = 0 OrElse fpaPrwinou = 0 OrElse fpaTrofis = 0 OrElse fpaExtra = 0 Then
    '                    berechne_pososta_fpa(index)
    '                End If

    '                hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (1 + fpaYpnou / 100))
    '                ypnos = (hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (1 + fpaPrwinou / 100)).ToString("N")
    '                hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (1 + fpaPrwinou / 100))
    '                prwino = (hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno / (1 + fpaTrofis / 100)).ToString("N")
    '                hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno / (1 + fpaTrofis / 100))
    '                geuma = (hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (1 + fpaExtra / 100)).ToString("N")
    '                hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (1 + fpaExtra / 100))
    '                extra = (hilfszahl * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                poso = countIndex * (ypnos + prwino + geuma + extra)
    '                'MsgBox(poso)
    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).fee > 0 Then
    '                If fpaYpnou = 0 Then
    '                    berechne_pososta_fpa(index)
    '                End If
    '                poso = countIndex * (Me.DbhotelDataSet.esoda_praktoreiwn(index).preistag / (1 + fpaYpnou / 100))

    '            End If

    '        End If
    '    Catch ex As StrongTypingException

    '        Return 0
    '    End Try
    '    Return poso.ToString("N")
    'End Function
    'Private Sub berechne_pososta_fpa(ByVal index As Int16)
    '    Dim hilfszahl As Single
    '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres <> 0 Then
    '        If fpaYpnou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
    '            hilfszahl = Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnosfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres
    '            fpaYpnou = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos - hilfszahl)) * 100).ToString("N1")

    '        End If
    '        If fpaPrwinou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
    '            hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwinofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '            fpaPrwinou = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino - hilfszahl)) * 100).ToString("N1")

    '        End If
    '        If fpaTrofis = 0 Then
    '            If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Then
    '                hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).geumafpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma - hilfszahl)) * 100).ToString("N1")
    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
    '                hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipnofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '                fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno - hilfszahl)) * 100).ToString("N1")
    '            End If

    '        End If
    '        If fpaExtra = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
    '            hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extrfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '            fpaExtra = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra - hilfszahl)) * 100).ToString("N1")

    '        End If
    '    End If


    'End Sub
    Private Sub miniaia_ektiposi(ByVal minas As Integer, ByVal kwdAllIncl As Integer)
        Dim startIndex, countIndex As Int16


        startIndex = 0
        Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            countIndex = 1

            If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).praktkwd = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).praktkwd

                    countIndex += 1

                    If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                        Exit While
                    End If

                End While

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_ekt_esodwn(startIndex, countIndex, minas, kwdAllIncl)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)

                fuelle_dataset_ekt_esodwn(startIndex, countIndex, minas, kwdAllIncl)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub fuelle_dataset_ekt_esodwn(ByVal startIndex As Int16, ByVal countIndex As Int16, ByVal minas As Integer, ByVal kwdAllIncl As Integer)
        Dim j, sumEnil, sumPaidia, sumDwm As Int16
        Dim sumDiam, sumAll, sumPrwin, sumGeum, sumExtr, sumSyn, sumDiaf, diafora As Single
        Dim laufdate, stopdate, startdate, endDate As Date

        If minas < 12 Then
            startdate = "1/" + (minas).ToString + "/" + etos.ToString
            stopdate = "1/" + (minas + 1).ToString + "/" + etos.ToString
            stopdate = stopdate.AddDays(-1)
        Else
            stopdate = "31/12/" + etos.ToString
        End If


        sumDwm = 0
        sumEnil = 0
        sumPaidia = 0
        sumDiam = 0
        sumAll = 0
        sumPrwin = 0
        sumGeum = 0
        sumExtr = 0
        sumSyn = 0
        sumDiaf = 0
        For j = startIndex To (startIndex + countIndex - 1)
            If Me.DbhotelDataSet.esoda_praktoreiwn(j).timesapo < startdate Then
                laufdate = startdate
            Else
                laufdate = Me.DbhotelDataSet.esoda_praktoreiwn(j).timesapo
            End If

            If Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri <= stopdate Then
                If Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi Then
                    endDate = Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri.AddDays(-1)
                Else
                    endDate = Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri
                End If
            Else
                endDate = stopdate
            End If

            While laufdate <= endDate
                'If Me.DbhotelDataSet.esoda_praktoreiwn(j).timesapo <= laufdate AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(j).timesmexri >= laufdate Then
                sumDwm = sumDwm + 1
                sumsumDwm = sumsumDwm + 1
                sumEnil = sumEnil + Me.DbhotelDataSet.esoda_praktoreiwn(j).enilikes
                sumsumEnil = sumsumEnil + Me.DbhotelDataSet.esoda_praktoreiwn(j).enilikes
                Try
                    sumPaidia = sumPaidia + Me.DbhotelDataSet.esoda_praktoreiwn(j).paidia
                    sumsumPaidia = sumsumPaidia + Me.DbhotelDataSet.esoda_praktoreiwn(j).paidia
                Catch ex As StrongTypingException
                End Try
                If Me.DbhotelDataSet.esoda_praktoreiwn(j).xrewsikwd = kwdAllIncl Then
                    sumAll = sumAll + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                    sumsumAll = sumsumAll + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                Else
                    sumDiam = sumDiam + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                    sumsumDiam = sumsumDiam + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos
                End If
                sumPrwin = sumPrwin + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino
                sumsumPrwin = sumsumPrwin + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino
                sumGeum = sumGeum + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno
                sumsumGeum = sumsumGeum + Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno
                sumExtr = sumExtr + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra
                sumsumExtr = sumsumExtr + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra
                'diafora = Me.berechne_ekptoseis_mem_timologown(j, 1)
                'sumDiaf = sumDiaf + diafora
                'sumsumDiaf = sumsumDiaf + diafora
                sumSyn = sumSyn + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino + _
                Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra + diafora
                sumsumSyn = sumsumSyn + Me.DbhotelDataSet.esoda_praktoreiwn(j).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(j).prwino + _
                                    Me.DbhotelDataSet.esoda_praktoreiwn(j).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(j).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(j).extra + diafora
                'End If
                laufdate = laufdate.AddDays(1)
            End While
        Next
        Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).praktkwd
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).eponimia
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas_nummer = minas
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas = Me.get_minas(minas)
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).dwmatia = sumDwm
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).enilikes = sumEnil
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).paidia = sumPaidia
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diamoni = sumDiam
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).allinclusiv = sumAll
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).prwina = sumPrwin
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).geumata = sumGeum
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).extras = sumExtr
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).synolo = sumSyn
        Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).diafores = sumDiaf
    End Sub
    Private Sub berechne_miniaies_ekptoseis_prakt(ByVal maxKwdPrakt As Integer)
        Dim j, index, index2 As Int16
        Dim posoDiaf As Single
        For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month >= ApoPck.Value.Date.Month AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month <= MexriPck.Value.Date.Month Then
                posoDiaf = 0
                index = finde_miniaia_stelle_in_dataset(Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd, Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month)
                If index = -1 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = Me.DbhotelDataSet.esoda_praktoreiwn(j).praktkwd
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = Me.DbhotelDataSet.esoda_praktoreiwn(j).eponimia
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas_nummer = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas = Me.get_minas(Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month)
                    index = Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
                End If
                index2 = finde_miniaia_stelle_in_dataset(maxKwdPrakt, Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month)
                If index2 = -1 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt.Rows.Add()
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktkwd = maxKwdPrakt
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).praktname = "ΣΥΝΟΛΟ"
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas_nummer = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month
                    Me.DbhotelDataSet.ekt_esodwn_prakt(Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1).minas = Me.get_minas(Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month)
                    index2 = Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
                End If
                If Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo

                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto / 100) / (1 - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto / 100)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo <> 0 Then
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo
                    'pososto = Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres / (Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(j).afixi.DayOfYear)
                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * pososto) / (1 - pososto)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo - posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).fee <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).synola
                    'pososto = Me.DbhotelDataSet.esoda_praktoreiwn(j).fee / (Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(j).afixi.DayOfYear)
                    'posoDiaf = (Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo * pososto) / (1 + pososto)
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index).diafores + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index).synolo + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).synolo + posoDiaf
                    Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores = Me.DbhotelDataSet.ekt_esodwn_prakt(index2).diafores + posoDiaf
                End If

            End If
        Next


    End Sub
    Private Function finde_miniaia_stelle_in_dataset(ByVal praktKwd As Integer, ByVal month As Integer) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.ekt_esodwn_prakt.Count - 1
            If praktKwd = Me.DbhotelDataSet.ekt_esodwn_prakt(j).praktkwd AndAlso month = Me.DbhotelDataSet.ekt_esodwn_prakt(j).minas_nummer Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Sub proepiskopisi_imerisiwn_esodwn_prakt()

        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EsodaPraktoreiwn()

        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        If kwdSimb <> -1 And Me.DbhotelDataSet.esoda_praktoreiwn.Count <> 0 Then
            If Me.DbhotelDataSet.esoda_praktoreiwn(0).aasimbolaiou > 0 Then
                Try
                    Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = Me.DbhotelDataSet.esoda_praktoreiwn(0).aasimbolaiou
                Catch ex As StrongTypingException
                    Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
                End Try
            Else
                Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
            End If
        Else
            Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
        End If

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Sub proepiskopisi_miniaiwn_esodwn_prakt()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New MiniaiaEsodaPraktor()

        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        If kwdSimb <> -1 And Me.DbhotelDataSet.esoda_praktoreiwn.Count <> 0 Then
            If Me.DbhotelDataSet.esoda_praktoreiwn(0).aasimbolaiou > 0 Then
                Try
                    Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = Me.DbhotelDataSet.esoda_praktoreiwn(0).aasimbolaiou
                Catch ex As StrongTypingException
                    Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
                End Try
            Else
                Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
            End If
        Else
            Me.DbhotelDataSet.ektiposeis_genika(0).aasimbolaiou = -1
        End If



        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Function get_kwd_simbol_byAA(ByVal aa As String) As Integer
        Try
            Return Me.SimbolaiaTableAdapter.GetKwdByAaPraktEtos(aa, kwdPrakt, etos)
        Catch ex As Exception
            Return -1
        End Try


    End Function

    Private Sub init_sumsum_variablen()
        sumsumDwm = 0
        sumsumEnil = 0
        sumsumPaidia = 0
        sumsumDiam = 0
        sumsumAll = 0
        sumsumPrwin = 0
        sumsumGeum = 0
        sumsumExtr = 0
        sumsumSyn = 0
        sumsumDiaf = 0
    End Sub
    '***************ESODA ANAlYSI A*************ESODA ANAlYSI A***************ESODA ANAlYSI A************ESODA ANAlYSI A*********
    '***************ESODA ANAlYSI A*************ESODA ANAlYSI A***************ESODA ANAlYSI A************ESODA ANAlYSI A*********
    '***************ESODA ANAlYSI A*************ESODA ANAlYSI A***************ESODA ANAlYSI A************ESODA ANAlYSI A*********
    Private Sub esoda_analysi_a()
        'imeromErgasias = "25/5/2006"
        Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση Α' Κατάστασης Ανάλυσης Εσόδων μηνός"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        EsodaAnalAPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.EsodaAnalAPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        EsodaAnalAPck.CustomFormat = "MM/yyyy"
        EsodaAnalAPck.MinDate = "1/1/" + etos.ToString
        EsodaAnalAPck.MaxDate = "31/12/" + etos.ToString
        EsodaAnalAPck.Value = imeromErgasias
       
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(EsodaAnalAPnl)

    End Sub

    Private Sub EsodaAnalABtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsodaAnalABtn.Click
        Dim arxiIm, telosIm, laufDate As Date
        Dim minas As Int16
        Dim daysCount As Int16
        Dim imerEsod() As Single 'sinolika esoda imeras
        Dim zahl As Single

        Try
            Me.Cursor = Cursors.WaitCursor
            sumsum = 0
            Me.DbhotelDataSet.ekt_status_dwm.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm.Clear()
            Me.DbhotelDataSet.ekt_imeres_status_dwm1.Clear()
            Me.DbhotelDataSet.ekt_analysi_esod_a.Clear()

            minas = EsodaAnalAPck.Value.Month

            arxiIm = "1/" + minas.ToString + "/" + etos.ToString

            If EsodaAnalAPck.Value.Month + 1 <= 12 Then
                telosIm = "1/" + (minas + 1).ToString + "/" + etos.ToString
                telosIm = telosIm.AddDays(-1)

            Else
                telosIm = "31/12/" + etos.ToString
            End If

            'poses meres exei o minas ->28,30,31
            laufDate = arxiIm.AddDays(27)
            While laufDate.Month = EsodaAnalAPck.Value.Month
                laufDate = laufDate.AddDays(1)
            End While

            daysCount = laufDate.AddDays(-1).Day
            ReDim imerEsod(daysCount - 1)

            'EDW EKANE THN ALLAGH TOU JOIN->H ARXIKH 1 JOIN ESPASE SE tris: kratiseis-OVER KAI DIAFORES(->TIMOLOGIA)
            If EsodaAnalAPck.Value.Year = imeromErgasias.Year Then
                'Anfrage me tis dainiktereuseis,over,diamenontes(atoma) ktl
                Me.DbhotelDataSet.esoda_praktoreiwn.Clear()
                Me.Esoda_praktoreiwnTableAdapter.FillKratImeromByAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, arxiIm, arxiIm, True, telosIm, telosIm, _
                                       True, arxiIm, telosIm)
                'Anfrage me ta tmimata ->sum posa ana imera
                Me.Analysi_esodwn_tmimatwn_minosTableAdapter.FillEsodaZentraltmimataMinosAnalysi(Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos, arxiIm, telosIm, True)
                'DImiourgw arxika 8 eintraege sto ekt_analysi_esod_a me dwmatia,atoma,dianiktereuseis...ktl (sinfona me ton x-Aksona tis ektiposis maniki)
                'meta dimiourgw tosa eintraege osa einai ta standard tmimata kai sto telos dimourgw ena eintrag me ta Hmerisisia authroismata

                init_kostenstellen()

                zeige_analysi_kostenwerte(arxiIm, telosIm, imerEsod)

                Me.DbhotelDataSet.esoda_praktoreiwn.Clear()
                Me.Esoda_praktoreiwnTableAdapter.FillOverByAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, telosIm, telosIm, _
                                                   True, arxiIm, telosIm)
                'MsgBox(Me.DbhotelDataSet.esoda_praktoreiwn.Count)
                zeige_analysi_over(arxiIm, telosIm)

                Me.DbhotelDataSet.esoda_praktoreiwn.Clear()
                'ektptoseis timologiwn->ALAKSA APO KATW 
                'Me.Esoda_praktoreiwnTableAdapter.FillTimologiaByAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
                '                                         True, True, arxiIm, telosIm, True)

                'EKPTWSEIS!!!!!!!!!!!!!!!!
                '->PAROMOIA ME ESODA PRAKTOREIWN->EKPTVSEIS OXI APO TIMOLOGIA ALLA APO SIGKRISI TOU SUM
                'APO TO SYNOLO STIS TIMESKRATISEIS ME TO SYNOLO APO KRATISEIS (jOIN KRATISEIS X TIMESKRATISEIS ME GROUPARISMA STIS TIMES ETSI WSTE
                'ANTI APO 1 X N NA BGALW 1 X 1 ->KAI META APO AFAIRESH BGAZW TIN EKPTWSH SE EURW!(->mono pou i ekptosi paei stin imerominia anaxwrisis
                'kai DEN thn katanemw se oles tis imeres diamonis)
                Me.Esoda_praktoreiwnTableAdapter.FilDiaforeslByChkinAfAnxEkptosi(Me.DbhotelDataSet.esoda_praktoreiwn, True, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
                                  True, True, arxiIm, telosIm)

                'zeige_analysi_diafora(arxiIm, telosIm, imerEsod, "a")
                berechne_ekptoseis_prakt(arxiIm, telosIm, imerEsod, "a")
                setze_imerisia_esoda(imerEsod)
                zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum
                sumsum = sumsum + zahl
                Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum = zahl.ToString("N")
                zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum
                sumsum = sumsum + zahl
                Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum = zahl.ToString("N")
                zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum
                sumsum = sumsum + zahl
                Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum = zahl.ToString("N")
                zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum
                sumsum = sumsum + zahl
                Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum = zahl.ToString("N")
                zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum
                sumsum = sumsum + zahl
                Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = zahl.ToString("N")

                Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).sum = sumsum.ToString("N")

                Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()

                Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias
                Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = get_minas(minas) + " " + etos.ToString

                proepiskopisi_analysis_esodwn_a(arxiIm, daysCount)
            Else
                MsgBox("Λάθος έτος !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            End If

        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Default

       
    End Sub
    Private Sub zeige_analysi_kostenwerte(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef imerEsod() As Single)
        Dim j, startIndex, countIndex, kind1, kind2 As Int16

        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).afixi = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).afixi AndAlso _
                Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).anaxwrisi = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).anaxwrisi AndAlso _
                 Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).enilikes = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).enilikes AndAlso _
                  Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ypnos = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ypnos AndAlso _
                  Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).prwino = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).prwino AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).geuma = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).geuma AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).deipno = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).deipno AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).extra = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).extra AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timesapo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timesapo AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timesmexri

                    Try
                        kind1 = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).paidia
                    Catch ex As StrongTypingException
                        kind1 = 0
                    End Try
                    Try
                        kind2 = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).paidia
                    Catch ex As StrongTypingException
                        kind2 = 0
                    End Try

                    If kind1 = kind2 Then
                        countIndex += 1
                        If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                            Exit While
                        End If
                    Else
                        Exit While
                    End If
                End While

                'If over1 + over2 = 0 Then
                '    overOK = False
                'Else
                '    overOK = True
                'End If
                'MsgBox(countIndex)
                berechne_kostenwerte(startIndex, countIndex, arxiIm, telosIm, imerEsod)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_kostenwerte(startIndex, countIndex, arxiIm, telosIm, imerEsod)
                Exit Do
            End If
        Loop

        'For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
        '    berechne_kostenwerte(j, arxiIm, telosIm, imerEsod)
        'Next
        For j = 0 To Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos.Count - 1
            'foularw sto dataset tis ektiposis Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos ta Eintraege pou
            'afotoun ta tmimata kathws kai tin DtStr imerEsod opou kanw ta imerisia athroismata 
            setze_kostenwerte_tmimata(j, arxiIm, imerEsod)
        Next
    End Sub
    Private Sub berechne_kostenwerte(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIM As Date, ByRef imerEsod() As Single)
        Dim zeiger1, zeiger2 As Int16

        'zeiger auf Imerominia->0=prwti  tou minos

        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo >= arxiIm And Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo <= telosIM Then
            zeiger1 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri > telosIM Then
            zeiger2 = telosIM.DayOfYear - arxiIm.DayOfYear
        ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri <= telosIM Then 'otan apothikeuw timeskratisis tote i teleutaia periodos exei imerominia mexri=anaxwrisi
            If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
                zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.AddDays(-1).DayOfYear - arxiIm.DayOfYear
            Else
                zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.DayOfYear - arxiIm.DayOfYear
            End If
        Else
            zeiger2 = -1
        End If
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            'foularw to dataseet tis ektiposis Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos kathws kai tin DtStr imerEsod opou
            'kanw ta imerisia athroismata 
            setze_kostenwerte(zeiger1, zeiger2, index, countIndex, imerEsod)
            'setze_diafores(zeiger1, zeiger2, index, countIndex, imerEsod)
        End If
    End Sub
  
    Private Sub setze_kostenwerte(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal index As Int16, ByVal countIndex As Int16, ByRef imerEsod() As Single)
        Dim j, atoma As Int16
        Dim zahl As Single

        For j = zeiger1 To zeiger2
            'to zeiger dixnei auf imerominies->ara Columns sto dataset 
            Me.DbhotelDataSet.ekt_analysi_esod_a(0).Item(j + 2) = Me.DbhotelDataSet.ekt_analysi_esod_a(0).Item(j + 2) + countIndex
            Me.DbhotelDataSet.ekt_analysi_esod_a(0).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(0).sum + countIndex

            atoma = countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).enilikes

            Try
                atoma = atoma + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).paidia
            Catch ex As StrongTypingException
            End Try
            Me.DbhotelDataSet.ekt_analysi_esod_a(1).Item(j + 2) = Me.DbhotelDataSet.ekt_analysi_esod_a(1).Item(j + 2) + atoma
            Me.DbhotelDataSet.ekt_analysi_esod_a(1).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(1).sum + atoma

            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(2).Item(j + 2) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos).ToString
            Me.DbhotelDataSet.ekt_analysi_esod_a(2).Item(j + 2) = zahl.ToString("N")
            imerEsod(j) = (imerEsod(j) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos)
            Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos
            'Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum = zahl.ToString("N")

            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(3).Item(j + 2) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino).ToString
            Me.DbhotelDataSet.ekt_analysi_esod_a(3).Item(j + 2) = zahl.ToString("N")
            imerEsod(j) = (imerEsod(j) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino)
            Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino
            'Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum = zahl.ToString("N")

            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(4).Item(j + 2) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno).ToString
            Me.DbhotelDataSet.ekt_analysi_esod_a(4).Item(j + 2) = zahl.ToString("N")
            imerEsod(j) = (imerEsod(j) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma)
            Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno
            'Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum = zahl.ToString("N")


            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(5).Item(j + 2) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra).ToString
            Me.DbhotelDataSet.ekt_analysi_esod_a(5).Item(j + 2) = zahl.ToString("N")
            imerEsod(j) = (imerEsod(j) + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra)
            Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum + countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra
            'Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum = zahl.ToString("N")

        Next
     


    End Sub
    Private Sub zeige_analysi_over(ByVal arxiIm As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex As Int16

        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ypnos = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ypnos AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).prwino = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).prwino AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).geuma = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).geuma AndAlso _
                     Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).deipno = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).deipno AndAlso _
                     Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).extra = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).extra AndAlso _
                     Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).overapo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).overapo AndAlso _
                     Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).overmexri = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).overmexri


                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                        Exit While
                    End If

                End While

                berechne_kostenwerte_over(startIndex, countIndex, arxiIm, telosIm)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)

                berechne_kostenwerte_over(startIndex, countIndex, arxiIm, telosIm)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub berechne_kostenwerte_over(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIM As Date)
        Dim zeiger1, zeiger2 As Int16
        Dim apoDate, mexriDate As Date

        If Me.DbhotelDataSet.esoda_praktoreiwn(index).overapo < Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo Then
            apoDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo
        Else
            apoDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).overapo
        End If
        If Me.DbhotelDataSet.esoda_praktoreiwn(index).overmexri < Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri Then
            mexriDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).overmexri
        Else
            mexriDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri
        End If
        'zeiger auf Imerominia->0=prwti  tou minos

        If apoDate < arxiIm Then
            zeiger1 = 0
        ElseIf apoDate >= arxiIm And apoDate <= telosIM Then
            zeiger1 = apoDate.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If
        ' to mexri Datum sto DB over deixnei (se antithesi me kratiseis - timeskratiseis) ti teleutaia nikta (imerominia)
        If mexriDate >= telosIM Then
            zeiger2 = telosIM.DayOfYear - arxiIm.DayOfYear
        ElseIf mexriDate < telosIM Then 'otan apothikeuw timeskratisis tote i teleutaia periodos exei imerominia mexri=anaxwrisi
            If mexriDate = "1/1/1900" Then
                zeiger2 = telosIM.DayOfYear - arxiIm.DayOfYear
            ElseIf mexriDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
                zeiger2 = mexriDate.AddDays(-1).DayOfYear - arxiIm.DayOfYear
            Else
                zeiger2 = mexriDate.DayOfYear - arxiIm.DayOfYear
            End If
        Else
            zeiger2 = -1
        End If
        'MsgBox(zeiger1)
        'MsgBox(zeiger2)
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            'foularw to dataseet tis ektiposis Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos kathws kai tin DtStr imerEsod opou
            'kanw ta imerisia athroismata 
            setze_kostenwerte_over(zeiger1, zeiger2, index, countIndex)

        End If
      

    End Sub
    Private Sub setze_kostenwerte_over(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal index As Int16, ByVal countIndex As Int16)
        Dim j As Int16
        Dim zahl As Single

        For j = zeiger1 To zeiger2
            zahl = countIndex * (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(index).extra)
            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(7).Item(j + 2) + zahl)
            Me.DbhotelDataSet.ekt_analysi_esod_a(7).Item(j + 2) = zahl.ToString("N")
            zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(7).sum + countIndex * (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(index).extra)
            Me.DbhotelDataSet.ekt_analysi_esod_a(7).sum = zahl.ToString("N")

            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(2).Item(j + 2) - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos
            'Me.DbhotelDataSet.ekt_analysi_esod_a(2).Item(j + 2) = zahl.ToString("N")
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos
            'Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum = zahl.ToString("N")

            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(3).Item(j + 2) - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino
            'Me.DbhotelDataSet.ekt_analysi_esod_a(3).Item(j + 2) = zahl.ToString("N")
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino
            'Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum = zahl.ToString("N")


            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(4).Item(j + 2) - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno
            'Me.DbhotelDataSet.ekt_analysi_esod_a(4).Item(j + 2) = zahl.ToString("N")
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno
            'Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum = zahl.ToString("N")


            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(5).Item(j + 2) - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra
            'Me.DbhotelDataSet.ekt_analysi_esod_a(5).Item(j + 2) = zahl.ToString("N")
            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum - countIndex * Me.DbhotelDataSet.esoda_praktoreiwn(index).extra
            'Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum = zahl.ToString("N")

        Next
    End Sub
    Private Sub berechne_ekptoseis_prakt(ByVal apo As Date, ByVal mexri As Date, ByRef imerEsod() As Single, ByVal analisi As Char)
        Dim j, index As Int16
        Dim zahl As Single
        Dim posoDiaf As Single
        For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
          
            If Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi <= mexri Then
                posoDiaf = 0
                index = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Day - 1
                If Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto <> 0 OrElse Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo <> 0 OrElse Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo
                    imerEsod(index) = (imerEsod(index) - posoDiaf)
                    If analisi = "a" Then
                        zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(index + 2) - posoDiaf) '.ToString
                        Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(index + 2) = zahl.ToString("N")
                        Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum - posoDiaf
                    End If

                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).fee <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).synola
                    imerEsod(index) = (imerEsod(index) + posoDiaf)
                    If analisi = "a" Then
                        zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(index + 2) + posoDiaf) '.ToString
                        Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(index + 2) = zahl.ToString("N")
                        Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum + posoDiaf
                    End If
                End If

            End If

        Next


    End Sub
    'ACHTUNG -> DEN XREIAZETAI PLEON GIA YPOLOGIZW TIS EKPTWSEIS DIAFORETIKA (KATA TN HMERA ANAXWRISHS) SIEHE PANW!!!!!!!!

    'Private Sub zeige_analysi_diafora(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef imerEsod() As Single, ByVal analisi As Char)
    '    Dim startIndex, countIndex As Int16

    '    ' startIndex = 0 'apo pio entrag sto dataset
    '    Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
    '        countIndex = 1 'posa eintraege 

    '        If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
    '            While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).sumkathposa = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).sumkathposa AndAlso _
    '            Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timolapo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timolapo AndAlso _
    '             Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timolmexri AndAlso _
    '              Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptimeres = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptimeres AndAlso _
    '              Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptpososto = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptpososto AndAlso _
    '                Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptposo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptposo AndAlso _
    '                Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).fee = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).fee

    '                countIndex += 1
    '                If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
    '                    Exit While
    '                End If
    '            End While
    '            'MsgBox(countIndex)
    '            berechne_diafores(startIndex, countIndex, arxiIm, telosIm, imerEsod, analisi)
    '            startIndex = startIndex + countIndex
    '        Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
    '            berechne_diafores(startIndex, countIndex, arxiIm, telosIm, imerEsod, analisi)
    '            Exit Do
    '        End If
    '    Loop
    'End Sub
    'Private Sub berechne_diafores(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIM As Date, ByRef ImerEsod() As Single, ByVal analisi As Char)
    '    Dim zeiger1, zeiger2 As Int16
    '    'Dim apoDate, mexriDate As Date


    '    'If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo < Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo Then
    '    '    apoDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo
    '    'Else
    '    '    apoDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo
    '    'End If
    '    'If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri < Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri Then
    '    '    mexriDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri
    '    'Else
    '    '    mexriDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri
    '    'End If
    '    'zeiger auf Imerominia->0=prwti  tou minos

    '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo < arxiIm Then
    '        zeiger1 = 0
    '    ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo >= arxiIm And Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo <= telosIM Then
    '        zeiger1 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear - arxiIm.DayOfYear
    '    Else
    '        zeiger1 = -1
    '    End If

    '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri >= telosIM Then
    '        zeiger2 = telosIM.DayOfYear - arxiIm.DayOfYear
    '    ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri < telosIM Then 'otan apothikeuw timeskratisis tote i teleutaia periodos exei imerominia mexri=anaxwrisi
    '        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
    '            zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).DayOfYear - arxiIm.DayOfYear
    '        Else
    '            zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.DayOfYear - arxiIm.DayOfYear
    '        End If
    '    Else
    '        zeiger2 = -1
    '    End If
    '    'MsgBox(zeiger1)
    '    'MsgBox(zeiger2)
    '    If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
    '        'foularw to dataseet tis ektiposis Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos kathws kai tin DtStr imerEsod opou
    '        'kanw ta imerisia athroismata 
    '        setze_diafores_a(zeiger1, zeiger2, index, countIndex, ImerEsod, analisi)

    '    End If
    'End Sub
    'Private Sub setze_diafores_a(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal startIndex As Int16, ByVal countIndex As Int16, ByRef imerEsod() As Single, ByVal analisi As Char)
    '    Dim j As Int16
    '    Dim diafora, zahl As Single

    '    'For i = startIndex To (startIndex + countIndex - 1)
    '    For j = zeiger1 To zeiger2
    '        diafora = berechne_ekptoseis_timologiwn(startIndex, countIndex)
    '        'MsgBox(diafora)
    '        imerEsod(j) = (imerEsod(j) + diafora)
    '        If analisi = "a" Then
    '            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(j + 2) + diafora) '.ToString
    '            Me.DbhotelDataSet.ekt_analysi_esod_a(6).Item(j + 2) = zahl.ToString("N")
    '            Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum + diafora
    '            'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum + diafora
    '            'Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = zahl.ToString("N")
    '        End If
    '    Next
    '    'Next
    'End Sub
    'Private Function berechne_ekptoseis_timologiwn(ByVal index As Int16, ByVal countIndex As Int16) As Single
    '    Dim poso, ypnos, prwino, geuma, extra As Single

    '    'sti timologioanalysis ta posa ypnoy,ypnoufpa ktl einai ta synolika kathara (gia oli thn paramoni)-> i ekptosi prepei na upologizetai kathe
    '    'fora!->epeidi yparxei periptosi ta pososta FPA na exoun alakse-->upologizw to fpa (19% ktl) apo ta epimeroys posa (ypnou, ypnoufpa)
    '    'kai epeita ta posa twn ekptosewn pou mpainoun stin stili "daifores" tis  ektiposis
    '    Try
    '        If Me.DbhotelDataSet.esoda_praktoreiwn(index).sumkathposa >= 0 Then

    '            If Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto > 0 Then
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
    '                    'MsgBox(ypnosNeto)
    '                    'If fpaYpnou = 0 Then
    '                    '    berechne_pososta_fpa(index)
    '                    'End If
    '                    'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (1 + fpaYpnou / 100))
    '                    ypnos = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                    'MsgBox(ypnos)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
    '                    'If fpaPrwinou = 0 Then
    '                    '    berechne_pososta_fpa(index)
    '                    'End If
    '                    'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (1 + fpaPrwinou / 100))
    '                    prwino = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Or Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
    '                    'If fpaTrofis = 0 Then
    '                    '    berechne_pososta_fpa(index)
    '                    'End If
    '                    'hilfszahl = ((Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno) / (1 + fpaTrofis / 100))
    '                    geuma = (-(Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno) / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                If Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
    '                    'If fpaExtra = 0 Then
    '                    '    berechne_pososta_fpa(index)
    '                    'End If
    '                    'hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (1 + fpaExtra / 100))
    '                    extra = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
    '                End If
    '                poso = countIndex * (ypnos + prwino + geuma + extra)

    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo > 0 Then
    '                If fpaYpnou = 0 Then
    '                    rechne_pososta_fpa(index)
    '                End If
    '                poso = (Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo / (1 + fpaYpnou / 100))
    '                poso = countIndex * (-poso / (Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).afixi.DayOfYear))

    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres > 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
    '                'If fpaYpnou = 0 OrElse fpaPrwinou = 0 OrElse fpaTrofis = 0 OrElse fpaExtra = 0 Then
    '                '    berechne_pososta_fpa(index)
    '                'End If

    '                'hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (1 + fpaYpnou / 100))
    '                ypnos = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))

    '                'hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (1 + fpaPrwinou / 100))
    '                prwino = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))
    '                'hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno / (1 + fpaTrofis / 100))
    '                geuma = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))
    '                'hilfszahl = -(Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (1 + fpaExtra / 100))
    '                extra = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))
    '                poso = countIndex * (ypnos + prwino + geuma + extra) * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres

    '                'MsgBox(poso)
    '            ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).fee > 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
    '                If fpaYpnou = 0 Then
    '                    rechne_pososta_fpa(index)
    '                End If
    '                poso = (Me.DbhotelDataSet.esoda_praktoreiwn(index).preistag / (1 + fpaYpnou / 100))
    '                poso = countIndex * (poso / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres) * Me.DbhotelDataSet.esoda_praktoreiwn(index).fee
    '            End If

    '        End If
    '    Catch ex As StrongTypingException

    '        Return 0
    '    End Try
    '    Return poso '.ToString("N")
    'End Function
    'Private Sub rechne_pososta_fpa(ByVal index As Int16)
    '    'Dim hilfszahl As Single
    '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres <> 0 Then
    '        If fpaYpnou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
    '            'hilfszahl = Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnosfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres
    '            fpaYpnou = ((Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnosfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos) * 100).ToString("N1")

    '        End If
    '        'If fpaPrwinou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
    '        '    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwinofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '        '    fpaPrwinou = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino - hilfszahl)) * 100).ToString("N1")

    '        'End If
    '        'If fpaTrofis = 0 Then
    '        '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Then
    '        '        hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).geumafpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '        '        fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma - hilfszahl)) * 100).ToString("N1")
    '        '    ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
    '        '        hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipnofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '        '        fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno - hilfszahl)) * 100).ToString("N1")
    '        '    End If

    '        'End If
    '        'If fpaExtra = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
    '        '    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extrfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
    '        '    fpaExtra = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra - hilfszahl)) * 100).ToString("N1")

    '        'End If
    '    End If


    'End Sub
    Private Sub setze_kostenwerte_tmimata(ByVal index As Int16, ByVal arxiIM As Date, ByRef imerEsod() As Single)
        Dim point As Int16
        Dim datumIndex As Int16
        Dim zahl As Single

        'pio Entrag sto dataset antistixei ston db kwdiko tou tmimatos
        point = finde_stelle_in_dataset(Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).kwd)

        If point <> -1 Then
            'datum index eianai i stelle tis imerominias eggrafis tmimatos pou antistoixei se Column sto Dataseet(->+2 giati ta 2 prwta columns den einai imerominies)
            datumIndex = Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).imerominia.DayOfYear - arxiIM.DayOfYear
            zahl = (Me.DbhotelDataSet.ekt_analysi_esod_a(point).Item(datumIndex + 2) + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).sumposo).ToString
            Me.DbhotelDataSet.ekt_analysi_esod_a(point).Item(datumIndex + 2) = zahl.ToString("N")
            imerEsod(datumIndex) = (imerEsod(datumIndex) + zahl).ToString("N")
            zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(point).sum + zahl
            Me.DbhotelDataSet.ekt_analysi_esod_a(point).sum = zahl.ToString("N")
            sumsum = sumsum + zahl
        End If

    End Sub
    Private Sub proepiskopisi_analysis_esodwn_a(ByVal arxiIm As Date, ByVal daysCount As Int16)
        Dim i As Int16
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EsodaAnalA()
        'Dim zahl As Single
        'Dim sum As Single

        'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum
        'sum = sum + zahl
        'Me.DbhotelDataSet.ekt_analysi_esod_a(2).sum = zahl.ToString("N")
        'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum
        'sum = sum + zahl
        'Me.DbhotelDataSet.ekt_analysi_esod_a(3).sum = zahl.ToString("N")
        'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum
        'sum = sum + zahl
        'Me.DbhotelDataSet.ekt_analysi_esod_a(4).sum = zahl.ToString("N")
        'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum
        'sum = sum + zahl
        'Me.DbhotelDataSet.ekt_analysi_esod_a(5).sum = zahl.ToString("N")
        'zahl = Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum
        'sum = sum + zahl
        'Me.DbhotelDataSet.ekt_analysi_esod_a(6).sum = zahl.ToString("N")



        Me.DbhotelDataSet.ekt_imeres_status_dwm.Rows.Add()
        Me.DbhotelDataSet.ekt_imeres_status_dwm1.Rows.Add()
        For i = 0 To daysCount - 1
            Me.DbhotelDataSet.ekt_imeres_status_dwm(0).Item(i) = arxiIm.AddDays(i).Day
            Me.DbhotelDataSet.ekt_imeres_status_dwm1(0).Item(i) = welche_tag_der_woche(arxiIm.AddDays(i).DayOfWeek)
        Next
        'MsgBox(Me.DbhotelDataSet.ekt_analysi_esod_a.Count)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Function finde_stelle_in_dataset(ByVal id As Int16) As Int16
        Dim j As Int16

        For j = 8 To Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1
            If Me.DbhotelDataSet.ekt_analysi_esod_a(j).kosten_id = id + 8 Then
                Return j
            End If
        Next
        Return -1
    End Function

    Private Sub setze_imerisia_esoda(ByVal imerEsod() As Single)
        Dim j As Int16
        'Dim sumsum As Single
        For j = 0 To imerEsod.Length - 1
            Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).Item(j + 2) = imerEsod(j).ToString("N")
            'sumsum = sumsum + imerEsod(j)
        Next
        'Return sumsum.ToString("N")

    End Sub
    Private Sub init_kostenstellen()
        Dim j As Int16

        'DImiourgw arxika 8 eintraege sto ekt_analysi_esod_a me dwmatia,atoma,dianiktereuseis...ktl (sinfona me ton x-Aksona tis ektiposis maniki)
        'meta dimiourgw tosa eintraege osa einai ta standard tmimata kai sto telos dimourgw ena eintrag me ta Hmerisisia authroismata
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 1
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΔΩΜΑΤIA"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 2
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΑΤΟΜΑ"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 3
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΔΙΑΝΥΚΤ."
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 4
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΠΡΩΙΝΑ"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 5
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΓΕΥΜΑΤΑ"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 6
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "EXTRAS"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 7
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΕΚΠΤΩΣΕΙΣ*"
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 8
        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "OVER"

        'eintrag einai identifizierbar me to unique kosten_id pou tou dinw
        'ta tmimata einai o db kwdikos tou + 8 (->ta proigoumena eintraege panw) 
        For j = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
            Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = Me.DbhotelDataSet.tmimata(j).kwd + 8
            Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = Me.DbhotelDataSet.tmimata(j).tmima
        Next
        Me.DbhotelDataSet.ekt_analysi_esod_a.Rows.Add()
        If Me.DbhotelDataSet.tmimata.Count <> 0 Then
            Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = Me.DbhotelDataSet.tmimata(j - 1).kwd + 9
        Else
            Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kosten_id = 9
        End If

        Me.DbhotelDataSet.ekt_analysi_esod_a(Me.DbhotelDataSet.ekt_analysi_esod_a.Count - 1).kostenstelle = "ΕΣΟΔ. ΗΜΕΡ."
    End Sub

    '***************ESODA ANAlYSI β*************ESODA ANAlYSIβ***************ESODA ANAlYSIβ************ESODA ANAlYSI β*********
    Private Sub esoda_analysi_b()
        Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)

        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Εκτύπωση B' Κατάστασης Ανάλυσης Εσόδων μηνός"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        EsodaAnalBPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.EsodaAnalBPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)
        EsodaAnalBPck.MinDate = "1/1/" + etos.ToString
        EsodaAnalBPck.MaxDate = "31/12/" + etos.ToString
        EsodaAnalBPck.CustomFormat = "MM/yyyy"
        EsodaAnalBPck.Value = imeromErgasias

        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(EsodaAnalBPnl)
        AddHandler EsodaAnalBTbx.KeyPress, AddressOf komma_einschalten
        AddHandler EsodaAnalBTbx.Click, AddressOf selectall
    End Sub
    Private Sub EsodaAnalBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsodaAnalBtn.Click
        Dim arxiIm, telosIm, laufdate As Date
        Dim j, minas, daysCount As Int16
        Dim esodIm() As Single
        Dim pliromIm() As TroposPl

        Try
            Me.Cursor = Cursors.WaitCursor

            minas = EsodaAnalBPck.Value.Month
            arxiIm = "1/" + minas.ToString + "/" + etos.ToString
            If EsodaAnalBPck.Value.Month + 1 <= 12 Then
                telosIm = "1/" + (minas + 1).ToString + "/" + etos.ToString
                telosIm = telosIm.AddDays(-1)
            Else
                telosIm = "31/12/" + etos.ToString
            End If

            'poses meres exei o minas ->28,30,31
            laufdate = arxiIm.AddDays(27)
            While laufdate.Month = EsodaAnalBPck.Value.Month
                laufdate = laufdate.AddDays(1)
            End While

            daysCount = laufdate.AddDays(-1).Day
            ReDim esodIm(daysCount - 1)
            ReDim pliromIm(daysCount - 1)

            'ACHTUNG ALLAGH PLEUSIS !!!
            'PRIN HTAN:
            'sta esoda einai ousiastika to athroisma ana imera tis proigoumenis ektiposis A'. Stous Xrewstes mpainoun ta timologia (ola kai ta extra parastatika)
            'kathws kai pistoseis apo OLA ta tmimata->sto tameio  mpainoun metroita apo ola ta tmimata kai timologia efoson einai metrita 
            'TWRA EINAI:
            'esoda ->ola apo arrangment (diamoni ktl) kai tmimata wste h prwtis stili me ta esoda imeras na taytizetai me to sunolo esodwn tis
            'ektiposis A' ->stin stili xxrewseis mpainoun ola ta kommena timologia apo arrangment ->oxi ta extra timologia pou aforoun GUARANTEE
            'diamones (xwris times) . Stin stili tameio mpainoun ta tmimata kathws kai ta mem timologia metritois (exoflimena)
            'Skopos einai sto telos (esoda - xrewseis - tameio) na einai 0 ! (-> esoda apo tmimata kai tameio apo tmimata apaleifwntai ->ara menei
            'na timologithoyn oles oi kratiseis (diamones)-> ean ypoloipo einai > 0 tote simainei oti yparxoun atimologites diamones, ean ypoloipo=0
            'tote simainei oti oi diamones exoun timologithei (sto extrem falll pou <0 tote exoun timologithei perisootero apoti to hotel exei doylepsei
            'mexri stigmis!
            If EsodaAnalBPck.Value.Year = imeromErgasias.Year Then
                'Me.Esoda_praktoreiwnTableAdapter.FillByAfAnx(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, arxiIm, arxiIm, True, telosIm, telosIm, _
                'True, arxiIm, telosIm)
                Me.Esoda_praktoreiwnTableAdapter.FillAnalEsodBBySimbAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, arxiIm, arxiIm, True, telosIm, telosIm, _
                            True, arxiIm, telosIm)
                berechne_esoda(arxiIm, telosIm, esodIm)
                'anfrage gia timologia pou exoun ekptosi gia upologismo diaforas
                'Me.Esoda_praktoreiwnTableAdapter.FillTimologiaByAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
                '                                                   True, True, arxiIm, telosIm, True)
                'zeige_analysi_diafora(arxiIm, telosIm, esodIm, "b")
                Me.Esoda_praktoreiwnTableAdapter.FilDiaforeslByChkinAfAnxEkptosi(Me.DbhotelDataSet.esoda_praktoreiwn, True, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
                                True, True, arxiIm, telosIm)

                berechne_ekptoseis_prakt(arxiIm, telosIm, esodIm, "b")
                'Anfrage me ta tmimata ->sum posa ana imera
                Me.Analysi_esodwn_tmimatwn_minosTableAdapter.FillEsodaOlatmimataMinosAnalysi(Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos, arxiIm, telosIm)


                'edw ALAKSA -> MONO MEM TIMOLOGIA (DHLADH OXI EXTRA TIMOLOGIA )
                Me.TimologiaTableAdapter.FillMemTimologiaByAfAnAkyr(Me.DbhotelDataSet.timologia, arxiIm, telosIm, True, False)
                'edw ALAKSA -> APENERGOPOIHSA OTI EXEI NA KANEI ME PRAKTOREIA XREWSEIS-EISPRAKSEIS
                'Me.XrewseispraktoreiaTableAdapter.FillXrewseisMina(Me.DbhotelDataSet.xrewseispraktoreia, arxiIm, telosIm)

                'Me.EisprakseispraktoreiaTableAdapter.FillEisparakseisMina(Me.DbhotelDataSet.eisprakseispraktoreia, arxiIm, telosIm)

                'EDW ESODA TMIMATWN
                For j = 0 To Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos.Count - 1
                    berechne_esod_tmimatwn(j, arxiIm, pliromIm, esodIm)
                Next
                'EDW MEM TIMOLOGIA
                For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                    berechne_xrewstes_apo_timologia(j, arxiIm, pliromIm)
                Next
                'edw ALAKSA -> APENERGOPOIHSA OTI EXEI NA KANEI ME PRAKTOREIA XREWSEIS-EISPRAKSEIS
                'For j = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
                '    berechne_xrewstes_apo_praktoreia(j, arxiIm, pliromIm)
                'Next
                'For j = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1
                '    berechne_eisprakseis_apo_praktoreia(j, arxiIm, pliromIm)
                'Next

                fuelle_anal_esod_b_dataset(arxiIm, esodIm, pliromIm)

                Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
                Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias
                Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = get_minas(minas) + " " + etos.ToString

                proepiskopisi_analysis_esodwn_b()


            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Default

       
    End Sub
    Private Sub berechne_esoda(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef imerEsod() As Single)
        Dim j, startIndex, countIndex As Int16

        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).afixi = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).afixi AndAlso _
                Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).anaxwrisi = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).anaxwrisi AndAlso _
                            Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ypnos = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ypnos AndAlso _
                    Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).prwino = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).prwino AndAlso _
                      Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).geuma = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).geuma AndAlso _
                      Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).deipno = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).deipno AndAlso _
                      Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).extra = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).extra AndAlso _
                      Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timesapo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timesapo AndAlso _
                      Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timesmexri

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)
                berechne_esoda_imeras(startIndex, countIndex, arxiIm, telosIm, imerEsod)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_esoda_imeras(startIndex, countIndex, arxiIm, telosIm, imerEsod)
                Exit Do
            End If
        Loop

    End Sub
    Private Sub berechne_esoda_imeras(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIM As Date, ByRef esodIm() As Single)
        Dim zeiger1, zeiger2 As Int16


        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo >= arxiIm And Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo <= telosIM Then
            zeiger1 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri > telosIM Then
            zeiger2 = telosIM.DayOfYear - arxiIm.DayOfYear
        ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri <= telosIM Then 'otan apothikeuw timeskratisis tote i teleutaia periodos exei imerominia mexri=anaxwrisi
            If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
                zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.AddDays(-1).DayOfYear - arxiIm.DayOfYear
            Else
                zeiger2 = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.DayOfYear - arxiIm.DayOfYear
            End If
        Else
            zeiger2 = -1
        End If
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            'foularw to dataseet tis ektiposis Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos kathws kai tin DtStr imerEsod opou
            'kanw ta imerisia athroismata 
            setze_esoda(zeiger1, zeiger2, index, countIndex, esodIm)
        End If
    End Sub
    Private Sub berechne_esod_tmimatwn(ByVal j As Int16, ByVal arxiIM As Date, ByRef pliromIm() As TroposPl, ByRef esodIm() As Single)
        Dim index As Int16

        index = Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).imerominia.DayOfYear - arxiIM.DayOfYear
        Try
            If Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).pliromi.Equals("Μετρητοίς") Then
                pliromIm(index).metritois = pliromIm(index).metritois + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
            Else
                pliromIm(index).pistosi = pliromIm(index).pistosi + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
            End If
        Catch ex As NullReferenceException
            pliromIm(index).pistosi = pliromIm(index).pistosi + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
        End Try
        If Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).zentralOK Then
            esodIm(index) = esodIm(index) + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
        End If
    End Sub
    Private Sub berechne_xrewstes_apo_timologia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromIm() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.timologia(j).imerominia.DayOfYear - arxiIm.DayOfYear
        Try
            If Me.DbhotelDataSet.timologia(j).parastatiko <> 2 Then 'den einai pistoriko timologio
                If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                    pliromIm(index).pistosi = pliromIm(index).pistosi + Me.DbhotelDataSet.timologia(j).synola '- (Me.DbhotelDataSet.timologia(j).prokataboli + Me.DbhotelDataSet.timologia(j).simetoxi)
                    'If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 OrElse Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                    '    pliromIm(index).metritois = pliromIm(index).metritois + Me.DbhotelDataSet.timologia(j).prokataboli + Me.DbhotelDataSet.timologia(j).simetoxi
                    'End If
                End If
             
            Else
                If Not Me.DbhotelDataSet.timologia(j).exoflithi Then
                    pliromIm(index).pistosi = pliromIm(index).pistosi - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                End If

            End If
            If Me.DbhotelDataSet.timologia(j).exoflithi Then
                'If Me.DbhotelDataSet.timologia(j).pliromi.Equals("Μετρητοίς") Then
                If Me.DbhotelDataSet.timologia(j).parastatiko <> 2 Then
                    pliromIm(index).metritois = pliromIm(index).metritois + Me.DbhotelDataSet.timologia(j).synola
                Else
                    pliromIm(index).metritois = pliromIm(index).metritois - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                End If

            End If
        Catch ex As NullReferenceException

        End Try

    End Sub
    Private Sub berechne_xrewstes_apo_praktoreia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromIm() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.xrewseispraktoreia(j).imerominia.DayOfYear - arxiIm.DayOfYear

        pliromIm(index).pistosi = pliromIm(index).pistosi + Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
        If Me.DbhotelDataSet.xrewseispraktoreia(j).metritois Then
            pliromIm(index).metritois = pliromIm(index).metritois + Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
        End If
    End Sub
    Private Sub berechne_eisprakseis_apo_praktoreia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromIm() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.eisprakseispraktoreia(j).imerominia.DayOfYear - arxiIm.DayOfYear

        pliromIm(index).metritois = pliromIm(index).metritois + Me.DbhotelDataSet.eisprakseispraktoreia(j).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(j).sunplin

    End Sub
    Private Sub setze_esoda(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal index As Int16, ByVal countIndex As Int16, ByRef imerEsod() As Single)
        Dim j As Int16
        Dim poso As Single

        'diafora = Me.berechne_ekptoseis_mem_timologown(index, 1)
        poso = countIndex * (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + _
        Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(index).extra)

        For j = zeiger1 To zeiger2
            imerEsod(j) = imerEsod(j) + poso
        Next
    End Sub
    Private Sub fuelle_anal_esod_b_dataset(ByVal arxiIm As Date, ByVal esodIm() As Single, ByVal pliromIm() As TroposPl)
        Dim j, last As Int16
        last = -1

        Me.DbhotelDataSet.ekt_analysi_esod_b.Clear()


        For j = 0 To esodIm.Length - 1

            If esodIm(j) <> 0 OrElse pliromIm(j).pistosi <> 0 OrElse pliromIm(j).metritois <> 0 Then
                Me.DbhotelDataSet.ekt_analysi_esod_b.Rows.Add()
                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).imerominia = arxiIm.AddDays(j)
                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).esoda = esodIm(j)

                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).xrewstes = pliromIm(j).pistosi
                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).tameio = pliromIm(j).metritois
                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).ypoloipo = esodIm(j) - pliromIm(j).metritois - pliromIm(j).pistosi
                If last = -1 Then
                    Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).proigoumeno = EsodaAnalBTbx.Text
                Else
                    Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).proigoumeno = Me.DbhotelDataSet.ekt_analysi_esod_b(last).metafora
                End If
                Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).metafora = Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).ypoloipo + Me.DbhotelDataSet.ekt_analysi_esod_b(Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1).proigoumeno
                last = Me.DbhotelDataSet.ekt_analysi_esod_b.Count - 1
            End If
        Next
    End Sub
    Private Sub proepiskopisi_analysis_esodwn_b()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EsodaAnalB()
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
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
    Private Sub EsodaAnalBTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsodaAnalBTbx.Leave
        'Try
        Try
            sender.text = CType(sender.text, Single).ToString("N")
        Catch ex As InvalidCastException
            sender.text = "0,00"
        End Try
        'Catch ex As InvalidCastException
        '    sender.text = 0
        'End Try


    End Sub

    '***************DIORTHOSEIS*************DIORTHOSEIS*****************DIORTHOSEIS**************DIORTHOSEIS********DIORTHOSEIS****

    'PROSXI-> SINFONA ME MANIK DEN XREIAZETAI
    Private Sub diorthoseis()

        indMina = imeromErgasias.Month
        kwdDEthnik = -1

        Me.ZentralPnl.Controls.Add(EtiketaPnl)
        EtiketaLbl.Text = "Διορθώσεις στοιχείων Εθνικοτήτων-Πρακτορείων"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        DiorthoseisPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.DiorthoseisPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)

        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(DiorthoseisPnl)

    End Sub

    Private Sub RdButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diorthoseis1Rdb.Click, Diorthoseis2Rdb.Click, Diorthoseis3Rdb.Click, Diorthoseis4Rdb.Click
        If Diorthoseis1Rdb.Checked Then
            male_panel_2(1)
        Else
            MsgBox("Αυτή η Επιλογή δεν έχει εγκατασταθεί !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If

    End Sub
    Private Sub male_panel_2(ByVal ind As Byte)

        Select Case ind
            Case 1

                Dim EthnikLbl As New Label
                EthnikLbl.ForeColor = Color.Blue
                EthnikLbl.Size = New Point(100, 30)
                EthnikLbl.Text = "Εθνικότητα:"
                EthnikLbl.TextAlign = ContentAlignment.TopRight
                EthnikLbl.Location = New Point(10, 10)
                Dim EthikTbx As New TextBox
                EthikTbx.BackColor = Me.ZentralPnl.BackColor
                EthikTbx.Size = New Point(150, 30)
                EthikTbx.Location = New Point(EthnikLbl.Location.X + EthnikLbl.Width, 10)
                EthikTbx.Text = "<κάνετε κλίκ εδώ>"
                EthikTbx.TextAlign = HorizontalAlignment.Center

                Dim MinasLbl As New Label
                MinasLbl.ForeColor = Color.Blue
                MinasLbl.Size = New Point(100, 30)
                MinasLbl.TextAlign = ContentAlignment.TopRight
                MinasLbl.Location = New Point(EthnikLbl.Location.X + EthnikLbl.Width + EthikTbx.Width + 5, 10)
                MinasLbl.Text = "Επιλ. Μήνα:"

                Dim MinasPck As New DateTimePicker
                MinasPck.Size = New Point(110, 20)
                MinasPck.Format = DateTimePickerFormat.Custom
                MinasPck.CustomFormat = "MM/yyyy"
                MinasPck.Value = imeromErgasias

                MinasPck.Location = New Point(EthnikLbl.Location.X + EthnikLbl.Width + EthikTbx.Width + 5 + MinasLbl.Width + 5, 10)



                Dim ZeigeBtn As New Button
                ZeigeBtn.BackColor = Color.Azure
                ZeigeBtn.ForeColor = Color.Maroon
                ZeigeBtn.Text = "Εμφάνιση"
                ZeigeBtn.Size = New Point(140, 30)
                ZeigeBtn.Cursor = Cursors.Hand
                ZeigeBtn.Location = New Point(Me.Diorthoseis2Pnl.Width / 2 - 80, Me.Diorthoseis2Pnl.Height - 35)


                Me.Diorthoseis2Pnl.Controls.Add(EthnikLbl)
                Me.Diorthoseis2Pnl.Controls.Add(EthikTbx)
                Me.Diorthoseis2Pnl.Controls.Add(MinasLbl)
                Me.Diorthoseis2Pnl.Controls.Add(MinasPck)
                Me.Diorthoseis2Pnl.Controls.Add(ZeigeBtn)
                AddHandler EthikTbx.Enter, AddressOf ethikotita_enter
                AddHandler MinasPck.Leave, AddressOf minas_leave
                AddHandler ZeigeBtn.Click, AddressOf emfanisi_click

        End Select
    End Sub
    Private Sub ethikotita_enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim EthnForm As New EthnikotitesFrm()
        Dim kwdikos As Integer

        EthnForm.StartPosition = FormStartPosition.CenterParent
        EthnForm.ShowDialog()
        kwdikos = EthnForm.return_ethnos_kwdikos
        'praktoreiokwd = PraktForm.return_praktoreio_kwdikos
        'EthnKwd1.Clear()
        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Εθνικότητα !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            sender.text = "<κάνετε κλίκ εδώ>"
            kwdDEthnik = -1
            Exit Sub
        Else
            sender.text = EthnForm.return_ethnos_name
            kwdDEthnik = kwdikos
        End If
        ' edw kanw herauskriegen ola ta simbolaia tou praktoreiou gia to etos

    End Sub
    Private Sub minas_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        indMina = sender.value.month

    End Sub
    Private Sub emfanisi_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim arxi, laufDate, arxiIm, telosIm As Date
        Dim j, daysCount As Int16
        Dim ethnikPrakt() As Int16

        arxiIm = "1/" + indMina.ToString + "/" + etos.ToString

        If MinasPck.Value.Month + 1 <= 12 Then
            telosIm = "1/" + (indMina + 1).ToString + "/" + etos.ToString
            telosIm = telosIm.AddDays(-1)
        Else
            telosIm = "31/12/" + etos.ToString
        End If
        If kwdDEthnik <> -1 AndAlso indMina > 0 Then
            arxi = "1/" + indMina.ToString + "/" + etos.ToString
            'poses meres exei o minas ->28,30,31
            laufDate = arxi.AddDays(27)
            While laufDate.Month = indMina
                laufDate = laufDate.AddDays(1)
            End While

            daysCount = laufDate.AddDays(-1).Day

            Me.Diorthoseis3Pnl.Controls.Clear()
            'PRWTA YPOLOGIZW OPWS PANW TIS ETHNIKOTITES 
            Me.Dianiktereuseis_minaTableAdapter.FillEthnikotitaDianByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, kwdDEthnik, _
            arxiIm, arxiIm, kwdDEthnik, telosIm, telosIm, kwdDEthnik, telosIm, telosIm, kwdDEthnik, _
            arxiIm, telosIm, kwdDEthnik, arxiIm, telosIm, kwdDEthnik)
            '->dstr gia speichern werte
            ReDim ethnikPrakt(daysCount - 1)
            'init_ethnik_dianikt(ethnikPrakt) '->setze alles -1 !
            For j = 0 To Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
                berechne_dianikt_ethnikotitas(j, arxiIm, telosIm, ethnikPrakt)
            Next
            'KANW LADEN TO DB ETNIKDIOORTHOSEIS
            Me.EthnikdiorthoseisTableAdapter.FillByEthnikEtosMinas(Me.DbhotelDataSet.ethnikdiorthoseis, kwdDEthnik, etos, indMina)
            '->dstr gia speichern werte
            ReDim ethnik(daysCount - 1)

            init_ethnik() '->setze alles -1 !
            lade_db_zu_dtstrk()


            Dim MinasLbl As New Label
            MinasLbl.ForeColor = Color.Maroon
            MinasLbl.Text = Me.get_minas(indMina)
            MinasLbl.Size = New Point(140, 20)
            MinasLbl.Location = New Point(5, 5)
            Me.Diorthoseis3Pnl.Controls.Add(MinasLbl)

            For j = 0 To daysCount - 1
                Dim ImerLbl As New Label
                ImerLbl.ForeColor = Color.Blue
                ImerLbl.Size = New Point(35, 20)
                ImerLbl.Text = j + 1
                ImerLbl.TextAlign = ContentAlignment.MiddleCenter
                ImerLbl.Location = New Point(1 + 40 * j, 20)

                Dim ImerTbx As New TextBox
                ImerTbx.Name = "Imer" + j.ToString
                ImerTbx.Size = New Point(35, 30)
                ImerTbx.Location = New Point(1 + 40 * j, 20 + ImerLbl.Height)
                ImerTbx.MaxLength = 4
                'ImerTbx.Text = "<κάνετε κλίκ εδώ>"
                ImerTbx.TextAlign = HorizontalAlignment.Center
                If ethnik(j) <> -1 Then 'ean uparxei eintrag sto db diorthoseis tha protimithei 
                    ImerTbx.Text = ethnik(j)
                ElseIf ethnikPrakt(j) <> 0 Then
                    ImerTbx.Text = ethnikPrakt(j)
                End If


                Me.Diorthoseis3Pnl.Controls.Add(ImerLbl)
                Me.Diorthoseis3Pnl.Controls.Add(ImerTbx)

                AddHandler ImerTbx.Leave, AddressOf imera_leave
                AddHandler ImerTbx.Click, AddressOf selectall

            Next

            Dim SpeicherBtn As New Button
            SpeicherBtn.BackColor = Color.Azure
            SpeicherBtn.ForeColor = Color.Maroon
            SpeicherBtn.Text = "Αποθήκευση"
            SpeicherBtn.Size = New Point(140, 30)
            SpeicherBtn.Cursor = Cursors.Hand
            SpeicherBtn.Location = New Point(Me.Diorthoseis2Pnl.Width / 2 - 80, 10)
            Me.Diorthoseis4Pnl.Controls.Add(SpeicherBtn)
            AddHandler SpeicherBtn.Click, AddressOf speicher_ethnik
        End If

    End Sub
    Private Sub berechne_dianikt_ethnikotitas(ByVal k As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef ethnikPrakt() As Int16)
        Dim zeiger1, zeiger2 As Int16

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi < arxiIm Then
            zeiger1 = 0
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.DayOfYear - arxiIm.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= telosIm Then
            zeiger2 = ethnikPrakt.Length - 1
        ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) >= arxiIm And Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1) < telosIm Then
            zeiger2 = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).DayOfYear - arxiIm.DayOfYear
        Else
            zeiger2 = -1
        End If
        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            setze_dianikt_ethnikotitas(zeiger1, zeiger2, k, ethnikPrakt)
            'fulle_dataset()
        End If

    End Sub
    Private Sub setze_dianikt_ethnikotitas(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal index As Int16, ByRef ethnikPrakt() As Int16)
        Dim i, anzethnikotita As Int16


        For i = zeiger1 To zeiger2
            If Me.DbhotelDataSet.dianiktereuseis_mina(index).ethnikkwd1 = kwdDEthnik Then
                anzethnikotita = Me.DbhotelDataSet.dianiktereuseis_mina(index).anzethnikotites
            ElseIf Me.DbhotelDataSet.dianiktereuseis_mina(index).ethnikkwd2 = kwdDEthnik Then
                anzethnikotita = Me.DbhotelDataSet.dianiktereuseis_mina(index).anzethnikotites2
            End If
            ethnikPrakt(i) = ethnikPrakt(i) + anzethnikotita
        Next

    End Sub
    Private Sub speicher_ethnik(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim periodoi() As ethnikPeriod
        Dim j, i, startIndex, countIndex, laenge As Int16
        Dim arxiMina As Date

        laenge = -1

        ReDim periodoi(-1)

        startIndex = 0
        Do Until startIndex > ethnik.Length - 1
            countIndex = 1

            If startIndex < ethnik.Length - 1 Then
                While ethnik(startIndex) = ethnik(startIndex + countIndex)

                    countIndex += 1

                    If startIndex + countIndex > ethnik.Length - 1 Then
                        Exit While
                    End If

                End While

                If ethnik(startIndex) <> -1 Then
                    laenge += 1
                    ReDim Preserve periodoi(laenge)
                    periodoi(laenge).apo = startIndex + 1
                    periodoi(laenge).mexri = startIndex + countIndex
                    periodoi(laenge).anzahl = ethnik(startIndex)

                End If
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                If ethnik(startIndex) <> -1 Then
                    laenge += 1
                    ReDim Preserve periodoi(laenge)
                    periodoi(laenge).apo = startIndex + 1
                    periodoi(laenge).mexri = startIndex + 1
                    periodoi(laenge).anzahl = ethnik(startIndex)
                End If
                Exit Do
            End If
        Loop

        arxiMina = "1/" + indMina.ToString + "/" + etos.ToString

        If Me.DbhotelDataSet.ethnikdiorthoseis.Count <= periodoi.Length Then
            For j = 0 To Me.DbhotelDataSet.ethnikdiorthoseis.Count - 1
                Me.EthnikdiorthoseisTableAdapter.UpdateEthnikotitesDiorth(etos, indMina, arxiMina.AddDays(periodoi(j).apo - 1), arxiMina.AddDays(periodoi(j).mexri - 1), periodoi(j).anzahl, kwdDEthnik, Me.DbhotelDataSet.ethnikdiorthoseis(j).kwd)
            Next
            For i = j To periodoi.Length - 1
                Me.EthnikdiorthoseisTableAdapter.InsertEthnikDiorthosi(etos, indMina, arxiMina.AddDays(periodoi(i).apo - 1), arxiMina.AddDays(periodoi(i).mexri - 1), periodoi(i).anzahl, kwdDEthnik)
            Next
            'indMina = imeromErgasias.Month
            'kwdDEthnik = -1
        ElseIf Me.DbhotelDataSet.ethnikdiorthoseis.Count > periodoi.Length Then
            For j = 0 To Me.DbhotelDataSet.ethnikdiorthoseis.Count - 1
                Me.EthnikdiorthoseisTableAdapter.DeleteEthnikDiorthoseis(Me.DbhotelDataSet.ethnikdiorthoseis(j).kwd)
            Next
            For j = 0 To periodoi.Length - 1
                Me.EthnikdiorthoseisTableAdapter.InsertEthnikDiorthosi(etos, indMina, arxiMina.AddDays(periodoi(j).apo - 1), arxiMina.AddDays(periodoi(j).mexri - 1), periodoi(j).anzahl, kwdDEthnik)
            Next

        End If
        Me.Diorthoseis2Pnl.Controls.Clear()
        Me.Diorthoseis3Pnl.Controls.Clear()
        Me.Diorthoseis4Pnl.Controls.Clear()
        male_panel_2(1)
    End Sub

    Private Sub imera_leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ethnik(sender.name.substring(4)) = sender.text
        Catch ex As InvalidCastException
            ethnik(sender.name.substring(4)) = -1
        End Try


    End Sub
    Private Sub lade_db_zu_dtstrk()
        Dim j, i, index1, index2 As Int16

        For j = 0 To Me.DbhotelDataSet.ethnikdiorthoseis.Count - 1
            index1 = Me.DbhotelDataSet.ethnikdiorthoseis(j).apo.Day
            index2 = Me.DbhotelDataSet.ethnikdiorthoseis(j).mexri.Day

            For i = index1 To index2
                ethnik(i - 1) = Me.DbhotelDataSet.ethnikdiorthoseis(j).anzahl
            Next

        Next

    End Sub
    Private Sub init_ethnik()
        Dim j As Int16

        For j = 0 To ethnik.Length - 1
            ethnik(j) = -1
        Next
    End Sub
    Private Sub init_ethnik_dianikt(ByRef ethnikPrakt() As Int16)
        Dim j As Int16

        For j = 0 To ethnikPrakt.Length - 1
            ethnikPrakt(j) = -1
        Next
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
    Private Sub selectall(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SelectAll()
    End Sub

    Private Sub TelosMinaErgasies_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub

    'Private Sub TelosMinaErgasies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ''TODO: This line of code loads data into the 'DbhotelDataSet.over' table. You can move, or remove it, as needed.
    'Me.OverTableAdapter.Fill(Me.DbhotelDataSet.over)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.ethnikdiorthoseis' table. You can move, or remove it, as needed.
    ''Fill(Me.DbhotelDataSet.ethnikdiorthoseis)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.eisprakseispraktoreia' table. You can move, or remove it, as needed.
    ''Me.EisprakseispraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.eisprakseispraktoreia)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.timologia' table. You can move, or remove it, as needed.
    ''Me.TimologiaTableAdapter.Fill(Me.DbhotelDataSet.timologia)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
    'Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
    'Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.simbolaia' table. You can move, or remove it, as needed.
    ''Me.SimbolaiaTableAdapter.Fill(Me.DbhotelDataSet.simbolaia)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.dwmatia' table. You can move, or remove it, as needed.
    'Me.DwmatiaTableAdapter.Fill(Me.DbhotelDataSet.dwmatia)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
    'Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
    ''TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
    'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)

    'ReDim ilikRande(7)
    'init_rande()

    'Me.SplitContainer1.Panel2.Controls.Clear()
    'Me.SplitContainer1.Panel2.Controls.Add(ZentralPnl)
    'End Sub


    Public Sub New(ByVal imerominia As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imeromErgasias.Year

        Me.OverTableAdapter.Fill(Me.DbhotelDataSet.over)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikdiorthoseis' table. You can move, or remove it, as needed.
        'Fill(Me.DbhotelDataSet.ethnikdiorthoseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.eisprakseispraktoreia' table. You can move, or remove it, as needed.
        'Me.EisprakseispraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.eisprakseispraktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.timologia' table. You can move, or remove it, as needed.
        'Me.TimologiaTableAdapter.Fill(Me.DbhotelDataSet.timologia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseis' table. You can move, or remove it, as needed.
        Me.XrewseisTableAdapter.Fill(Me.DbhotelDataSet.xrewseis)
        'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.simbolaia' table. You can move, or remove it, as needed.
        'Me.SimbolaiaTableAdapter.Fill(Me.DbhotelDataSet.simbolaia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.dwmatia' table. You can move, or remove it, as needed.
        Me.DwmatiaTableAdapter.Fill(Me.DbhotelDataSet.dwmatia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)

        ReDim ilikRande(7)
        init_rande()

        Me.SplitContainer1.Panel2.Controls.Clear()
        Me.SplitContainer1.Panel2.Controls.Add(ZentralPnl)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
