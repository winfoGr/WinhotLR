Public Class ErgasiesTelosEtous
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim praktOK, ethnikOK, plirotOK As Boolean
    'Sigkritikos Piinakas
    Structure TroposPl
        Dim pistosi As Single
        Dim metritois As Single
    End Structure
    Dim fpaYpnou, fpaPrwinou, fpaTrofis, fpaExtra As Single
    Dim kratiseisadapter As New dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Dim statistikaadapter As New dbhotelDataSet1TableAdapters.KratVillaPraktTableAdapter

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TelosEtousTree.AfterSelect
        Select Case TelosEtousTree.SelectedNode.Name.ToString
            Case "plirotita_dwmatiwn"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                katastasi(True, False, False)
            Case "praktoreia"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                katastasi(False, True, True)
            Case "ethnikotites"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                katastasi(False, False, True)
            Case "pinakas_esodwn"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                pinakas_esodwn()
            Case "tim_politiki"
                Me.ZentralPnl.Controls.Clear()
                Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.ZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.ZentralPnl.Dock = DockStyle.Fill
                timologiaki_politiki()

        End Select


    End Sub



    Private Sub katastasi(ByVal plirot As Boolean, ByVal prakt As Boolean, ByVal ethnik As Boolean)
        Me.ZentralPnl.Controls.Add(EtiketaPnl)

        If plirot Then
            EtiketaLbl.Text = "Ετήσια Πληρότητα Δωματίων ανά Πρακτορείο"
            KatastLbl.Text = "Εκτύπωση Πληρότητας Δωματίων"
        ElseIf prakt Then
            EtiketaLbl.Text = "Ετήσιες Διανυκτερεύσεις ανά Πρακτορείο"
            KatastLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Πρακτορείο"
        ElseIf ethnik Then
            EtiketaLbl.Text = "Ετήσιες Διανυκτερεύσεις ανά Εθνικότητα"
            KatastLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Εθνικότητα"
            'ElseIf epagg Then
            '    EtiketaLbl.Text = "Εκτύπωση Διανυκτερεύσεων ανά Επάγγελμα"
        End If


        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        KatastasiPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.KatastasiPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)


        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(KatastasiPnl)

        plirotOK = plirot
        praktOK = prakt
        ethnikOK = ethnik
        'epaggOK = epagg
    End Sub


    
    Private Sub KatastasiBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KatastasiBtn.Click
        Dim arxiIm, telosIm As Date

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DbhotelDataSet.ektiposeis_genika.Clear()
            Me.DbhotelDataSet.ekt_telos_season.Clear()

            arxiIm = "1/1/" + etos.ToString
            telosIm = "31/12/" + etos.ToString

            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = "Ετους " + etos.ToString
            If plirotOK Then
                'Join anfrage an DB->Kratiseis, Praktoreia->(einai sortiert kata seira-> praktoreia,afixi,anaxwrisi
                ' wste na exw ta Group mazi->besseres programmieren!)
                Me.Dianiktereuseis_minaTableAdapter.FillPlirotitaByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                                  telosIm, arxiIm, telosIm)
                zeige_plirotita_etous_ana_prakt(arxiIm, telosIm)
            ElseIf praktOK Then
                'Join anfrage an DB->Kratiseis, Praktoreia, kai tou View PaidiaAnaKratisi
                Me.Dianiktereuseis_minaTableAdapter.FillDianiktereuseisByAfAnax(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                       telosIm, arxiIm, telosIm)
                zeige_dianikt_ana_praktoreio(arxiIm, telosIm)
                Me.DbhotelDataSet.ektiposeis_genika(0).aa = 1
            ElseIf ethnikOK Then
                Me.Dianiktereuseis_minaTableAdapter.FillEthnokotitesDianikterByAfAn(Me.DbhotelDataSet.dianiktereuseis_mina, arxiIm, arxiIm, telosIm, _
                                            telosIm, arxiIm, telosIm)
                zeige_ana_ethnikotita(arxiIm, telosIm)
                Me.DbhotelDataSet.ektiposeis_genika(0).aa = 2
            End If



            If plirotOK Then
                proepiskopisi_plirotitas()
            ElseIf praktOK Or ethnikOK Then

                proepiskopisi_dianikt_praktoreia()
            End If

        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub zeige_plirotita_etous_ana_prakt(ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex, countAfix As Int16
        Dim plirotPrakt() As Int16

        ReDim plirotPrakt(-1)
        'ola ta Eintraege ENOS praktoreiou
        'heraus kriegen von indexen in dataset Me.DbhotelDataSet.dianiktereuseis_mina gia bearbeiten  
        startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                While Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex + countIndex).praktoreio
                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1 Then
                        Exit While
                    End If
                End While
                ReDim plirotPrakt(11) '->gia kathe mina 
                init_dianiktreuseis_praktoreiou(plirotPrakt)

                'berechne afixeis praktoreiou
                countAfix = berechne_kratiseis_praktoreiou(startIndex, countIndex, arxiIM, telosIm, plirotPrakt)

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_plirotita_etous(startIndex, plirotPrakt, countAfix, arxiIM, telosIm)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim plirotPrakt(11)
                init_dianiktreuseis_praktoreiou(plirotPrakt)
                countAfix = berechne_kratiseis_praktoreiou(startIndex, countIndex, arxiIM, telosIm, plirotPrakt)

                fuelle_dataset_plirotita_etous(startIndex, plirotPrakt, countAfix, arxiIM, telosIm)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub zeige_dianikt_ana_praktoreio(ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim startIndex, countIndex, countDian As Int16
        Dim dianikPrakt() As Int16

        ReDim dianikPrakt(-1)

        'heraus kriegen von indexen in dataset Me.DbhotelDataSet.dianiktereuseis_mina gia bearbeiten  
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
                ReDim dianikPrakt(11)
                init_dianiktreuseis_praktoreiou(dianikPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                countDian = berechne_dianiktereuontes_praktoreiou(startIndex, countIndex, arxiIM, telosIm, dianikPrakt) 'countDian +

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_dianiktereuseis_praktoreia(startIndex, dianikPrakt, countDian)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim dianikPrakt(11)
                init_dianiktreuseis_praktoreiou(dianikPrakt)
                countDian = berechne_dianiktereuontes_praktoreiou(startIndex, countIndex, arxiIM, telosIm, dianikPrakt) ' countDian +

                fuelle_dataset_dianiktereuseis_praktoreia(startIndex, dianikPrakt, countDian)
                Exit Do
            End If
        Loop
    End Sub
    Private Sub zeige_ana_ethnikotita(ByVal arxiIM As Date, ByVal telosIm As Date)
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
                ReDim ethnikPrakt(11)
                init_dianiktreuseis_praktoreiou(ethnikPrakt)

                'speicher in Datastruktur to anzahl twn dainiktereuntwn (enilikes+paidia)
                countEthnik = berechne_dianiktereuontes_ethnikotitas(startIndex, countIndex, arxiIM, telosIm, ethnikPrakt)

                'fuelle zu dataset gia Crystal report
                fuelle_dataset_ethnikotites(startIndex, ethnikPrakt, countEthnik)

                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                ReDim ethnikPrakt(11)
                init_dianiktreuseis_praktoreiou(ethnikPrakt)
                countEthnik = berechne_dianiktereuontes_ethnikotitas(startIndex, countIndex, arxiIM, telosIm, ethnikPrakt)

                fuelle_dataset_ethnikotites(startIndex, ethnikPrakt, countEthnik)
                Exit Do
            End If
        Loop

        fuelle_zweite_ethnikotita_zu_dataset()

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
                countAfix = countAfix + setze_kratiseis_prakt_group(startindex, counter, plirotPrakt)
                startindex = startindex + counter
            Else
                countAfix = countAfix + setze_kratiseis_prakt_group(startindex, counter, plirotPrakt)
                Exit Do

            End If
        Loop
        Return countAfix
    End Function
    Private Function berechne_dianiktereuontes_praktoreiou(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianikPrakt() As Int16) As Int16
        Dim countDian, startindex, atoma As Int16 ', kinder, kind1, kind2
        Dim counter As Int16 'metra tis kratiseis tou group tou praktoreiou->group= Idia afixi kai anaxwrisi

        startindex = datasetIndex
        'edw opws panw me ta praktoreia psaxnw tis kratiseis ana parktoreio me IDIA afixi, anaxwrisi (GROUP)

        Do Until startindex > (datasetIndex + countIndex - 1)
            counter = 1
            If startindex < (datasetIndex + countIndex - 1) Then
                'einai sortiert kata prakt,afix,anax, enilikes, paidia gia besseres programmieren
                While Me.DbhotelDataSet.dianiktereuseis_mina(startindex).afixi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).afixi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).anaxwrisi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).anaxwrisi _
                    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).enilikes = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).enilikes _
                   AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).paidia
                    counter += 1
                    If startindex + counter > (datasetIndex + countIndex - 1) Then
                        Exit While
                    End If
                   
                    'den mporw na balw stin while anfrage erwtima ean ta paidia einai ta idia giati ean i kratisi den exei paidia exei ERROR
                    'Try
                    '    kind1 = Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia
                    'Catch ex As StrongTypingException
                    '    kind1 = 0
                    'End Try
                    'Try
                    '    kind2 = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).paidia
                    'Catch ex As StrongTypingException
                    '    kind2 = 0
                    'End Try

                    'If kind1 = kind2 Then
                    '    counter += 1
                    '    If startindex + counter > (datasetIndex + countIndex - 1) Then
                    '        Exit While
                    '    End If
                    'Else
                    '    Exit While
                    'End If

                End While

                'Try
                '    kinder = Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia
                'Catch ex As StrongTypingException
                '    kinder = 0
                'End Try


                atoma = Me.DbhotelDataSet.dianiktereuseis_mina(startindex).enilikes + Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia ' kinder

                countDian = countDian + setze_dianiktereuseis_prakt_group(startindex, counter * atoma, dianikPrakt)
                startindex = startindex + counter
            Else
                'Try
                '    kinder = Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia
                'Catch ex As StrongTypingException
                '    kinder = 0
                'End Try
                atoma = Me.DbhotelDataSet.dianiktereuseis_mina(startindex).enilikes + Me.DbhotelDataSet.dianiktereuseis_mina(startindex).paidia 'kinder

                countDian = countDian + setze_dianiktereuseis_prakt_group(startindex, atoma, dianikPrakt)
                Exit Do

            End If
        Loop
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
                countEthnik = countEthnik + setze_ethnik_krat_group(startIndex, counter * anzEthnik1, ethnikPrakt)
                startIndex = startIndex + counter
            Else
                anzEthnik1 = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).anzethnikotites
                countEthnik = countEthnik + setze_ethnik_krat_group(startIndex, anzEthnik1, ethnikPrakt)
                Exit Do

            End If
        Loop
        Return countEthnik


    End Function
    Private Function setze_kratiseis_prakt_group(ByVal index As Int16, ByVal counter As Int16, ByRef plirotPrakt() As Int16) As Int16
        Dim i, countAfix As Int16
        Dim laufDate As Date

        laufDate = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi
        'kanw setzen stin Dstruktur
        For i = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi.Month To Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month

            If i = Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month Then

                While laufDate <= Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1)
                    laufDate = laufDate.AddDays(1)
                    plirotPrakt(i - 1) = plirotPrakt(i - 1) + counter
                    countAfix = countAfix + counter
                End While
            Else
                While laufDate.Month = i
                    laufDate = laufDate.AddDays(1)
                    plirotPrakt(i - 1) = plirotPrakt(i - 1) + counter
                    countAfix = countAfix + counter
                End While

            End If

        Next
        Return countAfix
    End Function
    Private Function setze_dianiktereuseis_prakt_group(ByVal index As Int16, ByVal atoma As Int16, ByRef dianikPrakt() As Int16) As Int16
        Dim i, countDian As Int16
        Dim laufDate As Date

        laufDate = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi

        'kanw setzen stn Dstr ta atoma tou group twn kratisewn sto antistoixo mina sthn Dstr  

        For i = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi.Month To Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month

            If i = Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month Then 'kratisi erxete kai feugei ton idio mina 

                While laufDate <= Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1)
                    laufDate = laufDate.AddDays(1)
                    dianikPrakt(i - 1) = dianikPrakt(i - 1) + atoma
                    countDian = countDian + atoma
                End While
            Else 'kratisi erxete kai feugei (ton) allo mina 
                While laufDate.Month = i
                    laufDate = laufDate.AddDays(1)
                    dianikPrakt(i - 1) = dianikPrakt(i - 1) + atoma
                    countDian = countDian + atoma
                End While
            End If

        Next
        Return countDian
    End Function
    Private Function setze_ethnik_krat_group(ByVal index As Int16, ByVal anzEthnik1 As Int16, ByRef ethnikPrakt() As Int16) As Int16
        Dim i, countEthnik As Int16
        Dim laufDate As Date

        laufDate = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi

        For i = Me.DbhotelDataSet.dianiktereuseis_mina(index).afixi.Month To Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month

            If i = Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1).Month Then

                While laufDate <= Me.DbhotelDataSet.dianiktereuseis_mina(index).anaxwrisi.AddDays(-1)
                    laufDate = laufDate.AddDays(1)
                    ethnikPrakt(i - 1) = ethnikPrakt(i - 1) + anzEthnik1
                    countEthnik = countEthnik + anzEthnik1
                End While
            Else
                While laufDate.Month = i
                    laufDate = laufDate.AddDays(1)
                    ethnikPrakt(i - 1) = ethnikPrakt(i - 1) + anzEthnik1
                    countEthnik = countEthnik + anzEthnik1
                End While

            End If

        Next
        Return countEthnik

    End Function
    Private Sub fuelle_dataset_plirotita_etous(ByVal startIndex As Int16, ByVal plirotPrakt() As Int16, ByVal countAfix As Int16, ByVal arxiIM As Date, ByVal telosIm As Date)
        Dim i, sumAllotm As Int16
        Dim allotmPrakt() As Int16

        ReDim allotmPrakt(11)

        Me.DbhotelDataSet.ekt_telos_season.Rows.Add()

        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).eponimia

        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).sumreal = countAfix

        sumAllotm = berechne_sum_etous_allotm_praktoreiou(Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).praktoreio, arxiIM, telosIm, allotmPrakt)
        'Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).allotment = sumAllotm
        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).sumallotm = sumAllotm
        If sumAllotm <> 0 Then
            Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).pososto = ((countAfix / sumAllotm) * 100).ToString("N")
        End If

        For i = 0 To plirotPrakt.Length - 1
            If plirotPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).Item(2 * i) = plirotPrakt(i).ToString
            End If
        Next

        For i = 0 To allotmPrakt.Length - 1
            If allotmPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).Item(2 * i + 1) = allotmPrakt(i).ToString
            End If
        Next

    End Sub
    Private Sub fuelle_dataset_dianiktereuseis_praktoreia(ByVal startIndex As Int16, ByVal dianPrakt() As Int16, ByVal countDian As Int16)
        Dim i As Int16
       
        Me.DbhotelDataSet.ekt_telos_season.Rows.Add()

        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).eponimia

        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).sumreal = countDian


        For i = 0 To dianPrakt.Length - 1
            If dianPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).Item(2 * i) = dianPrakt(i).ToString
            End If
        Next

    End Sub
    Private Sub fuelle_dataset_ethnikotites(ByVal startIndex As Int16, ByVal ethnikPrakt() As Int16, ByVal countEthnik As Int16)
        Dim i As Int16

        Me.DbhotelDataSet.ekt_telos_season.Rows.Add()

        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).praktoreio = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).ethnikotita
        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).ethnikkwd = Me.DbhotelDataSet.dianiktereuseis_mina(startIndex).ethnikkwd1
        Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).sumreal = countEthnik


        For i = 0 To ethnikPrakt.Length - 1
            If ethnikPrakt(i) <> 0 Then
                Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).Item(2 * i) = ethnikPrakt(i).ToString
            End If
        Next

    End Sub
    Private Sub fuelle_zweite_ethnikotita_zu_dataset()
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.dianiktereuseis_mina.Count - 1
            If Me.DbhotelDataSet.dianiktereuseis_mina(j).ethnikkwd2 > 0 AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(j).anzethnikotites2 > 0 Then

                zweite_ethnik_hinzu(j, Me.DbhotelDataSet.dianiktereuseis_mina(j).ethnikkwd2, Me.DbhotelDataSet.dianiktereuseis_mina(j).anzethnikotites2)

            End If

        Next

    End Sub
    Private Sub zweite_ethnik_hinzu(ByVal k As Int16, ByVal ethnKwd As Integer, ByVal anzahlEthn2 As Int16)
        Dim i, count2Ethnik, index As Int16
        Dim laufDate As Date
        Dim ethnik2Prakt() As Int16

        ReDim ethnik2Prakt(11)

        laufDate = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi

        For i = Me.DbhotelDataSet.dianiktereuseis_mina(k).afixi.Month To Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).Month

            If i = Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1).Month Then

                While laufDate <= Me.DbhotelDataSet.dianiktereuseis_mina(k).anaxwrisi.AddDays(-1)
                    laufDate = laufDate.AddDays(1)
                    ethnik2Prakt(i - 1) = ethnik2Prakt(i - 1) + anzahlEthn2
                    count2Ethnik = count2Ethnik + anzahlEthn2
                End While
            Else
                While laufDate.Month = i
                    laufDate = laufDate.AddDays(1)
                    ethnik2Prakt(i - 1) = ethnik2Prakt(i - 1) + anzahlEthn2
                    count2Ethnik = count2Ethnik + anzahlEthn2
                End While

            End If

        Next
        index = finde_index_von_ethnik_in_dataset(ethnKwd)
        'MsgBox(ethnKwd)
        If index <> -1 Then
            For i = 0 To ethnik2Prakt.Length - 1
                If ethnik2Prakt(i) <> 0 Then
                    Me.DbhotelDataSet.ekt_telos_season(index).Item(2 * i) = Me.DbhotelDataSet.ekt_telos_season(index).Item(2 * i) + ethnik2Prakt(i).ToString
                End If
            Next
            Me.DbhotelDataSet.ekt_telos_season(index).sumreal = Me.DbhotelDataSet.ekt_telos_season(index).sumreal + count2Ethnik
        Else
            Me.DbhotelDataSet.ekt_telos_season.Rows.Add()
            Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).praktoreio = get_ethikotita_by_kwdiko(ethnKwd)
            'MsgBox(Me.DbhotelDataSet.ekt_dianikt_ana_prakt(Me.DbhotelDataSet.ekt_dianikt_ana_prakt.Count - 1).praktoreio)
            Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).ethnikkwd = ethnKwd
            For i = 0 To ethnik2Prakt.Length - 1
                If ethnik2Prakt(i) <> 0 Then
                    Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).Item(2 * i) = ethnik2Prakt(i).ToString
                End If
            Next
            Me.DbhotelDataSet.ekt_telos_season(Me.DbhotelDataSet.ekt_telos_season.Count - 1).sumreal = count2Ethnik
        End If
    End Sub

    Private Function finde_index_von_ethnik_in_dataset(ByVal ethnKwd As Integer) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.ekt_telos_season.Count - 1
            If Me.DbhotelDataSet.ekt_telos_season(j).ethnikkwd = ethnKwd Then
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
    Private Function berechne_sum_etous_allotm_praktoreiou(ByVal praktKwd As Integer, ByVal arxiIM As Date, ByVal telosIm As Date, ByRef allotmPrakt() As Int16) As Int16
        Dim j, sumAllotm As Int16


        Me.Allotment_praktoreouTableAdapter.FillAllotmByPraktApMexr(Me.DbhotelDataSet.allotment_praktoreou, praktKwd, arxiIM, arxiIM, praktKwd, telosIm, telosIm, praktKwd, arxiIM, telosIm)

        For j = 0 To 11
            setze_anzahl_von_allotment_am_monat((j + 1), allotmPrakt)

            sumAllotm = sumAllotm + allotmPrakt(j)
        Next

        Return sumAllotm

    End Function
    Private Function setze_anzahl_von_allotment_am_monat(ByVal indMonth As Int16, ByRef allotmPrakt() As Int16) As Int16
        Dim j, sumAllotm As Int16
        Dim laufDate, arxiMonth, telosMonth As Date

        arxiMonth = "1/" + indMonth.ToString + "/" + etos.ToString
        laufDate = arxiMonth.AddDays(27)
        While laufDate.Month = indMonth
            laufDate = laufDate.AddDays(1)
        End While

        telosMonth = laufDate.AddDays(-1)

        For j = 0 To Me.DbhotelDataSet.allotment_praktoreou.Count - 1
            rechne_allotm_prakt_in_monat(j, arxiMonth, telosMonth, allotmPrakt)
        Next
        Return sumAllotm

    End Function
    Private Function rechne_allotm_prakt_in_monat(ByVal k As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef allotmPrakt() As Int16) As Int16
        Dim zeiger1, zeiger2, countAfix As Int16
        If Me.DbhotelDataSet.allotment_praktoreou(k).apo < arxiIm Then
            zeiger1 = arxiIm.DayOfYear
        ElseIf Me.DbhotelDataSet.allotment_praktoreou(k).apo >= arxiIm And Me.DbhotelDataSet.allotment_praktoreou(k).apo <= telosIm Then
            zeiger1 = Me.DbhotelDataSet.allotment_praktoreou(k).apo.DayOfYear
        Else
            zeiger1 = -1
        End If

        If Me.DbhotelDataSet.allotment_praktoreou(k).mexri >= telosIm Then
            zeiger2 = telosIm.DayOfYear
        ElseIf Me.DbhotelDataSet.allotment_praktoreou(k).mexri >= arxiIm And Me.DbhotelDataSet.allotment_praktoreou(k).mexri < telosIm Then
            zeiger2 = Me.DbhotelDataSet.allotment_praktoreou(k).mexri.DayOfYear
        Else
            zeiger2 = -1
        End If



        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            allotmPrakt(arxiIm.Month - 1) = allotmPrakt(arxiIm.Month - 1) + ((zeiger2 - zeiger1) + 1) * Me.DbhotelDataSet.allotment_praktoreou(k).anzahl
            'fulle_dataset()
        End If

        Return countAfix
    End Function
    Private Sub proepiskopisi_plirotitas()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EtisiaPlirotita()


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
    Private Sub proepiskopisi_dianikt_praktoreia()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EtisiesDianiktPrakt()


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
    Private Sub init_dianiktreuseis_praktoreiou(ByRef dianikPrakt() As Int16)
        Dim j As Int16

        For j = 0 To dianikPrakt.Length - 1
            dianikPrakt(j) = 0
        Next
    End Sub
    '***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN
    '***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN
    '***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN
    '***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN***************************PINAKAS ESODWN
    Private Sub pinakas_esodwn()

        Me.TmimataTableAdapter.FillByZentral(Me.DbhotelDataSet.tmimata, True)
        EtiketaLbl.Text = "Συγκριτικός Πίνακας Εσόδων τρέχουσας χρήσης"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        PinakEsodPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.PinakEsodPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)

        PinakEsodTbx.Text = etos - 1
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(PinakEsodPnl)
    End Sub


   

    Private Sub PinakEsodTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PinakEsodTbx.Leave

        Try
            If CType(sender.text, Int16) Then
                If sender.text.length = 2 Then
                    sender.text = CType(sender.text, Int16) + 2000
                End If
            End If
        Catch ex As InvalidCastException
            MsgBox("Δώστε Ετος Σύγκρισης !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
        End Try

    End Sub

    Private Sub PinakEsodBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PinakEsodBtn.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            init_kostenstellen() 'kosten id gia na mporw metepeita na brw tin stelle twn diannikt-esoda-xrewstes kai tameio

            etos_esoda_rechnen(etos, 0)
            etos_esoda_rechnen(PinakEsodTbx.Text, 12)
            Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
            Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias
            Me.DbhotelDataSet.ektiposeis_genika(0).etos = PinakEsodTbx.Text
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = etos.ToString + " - " + PinakEsodTbx.Text

            proepiskopisi_sygkrisi_esodwn()
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try

        Me.Cursor = Cursors.Default
      

    End Sub
    Private Sub etos_esoda_rechnen(ByVal xronos As Int16, ByVal count As Int16)
        Dim arxiIm, telosIm As Date
        Dim j As Int16
        Dim dianMin(), tmimMin() As Single 'miniaia Esoda apo dianiktereuseis kai zentral tmimata
        Dim pliromMin() As TroposPl 'miniaia xrewstes-tameio

        arxiIm = "1/1/" + xronos.ToString
        telosIm = "31/12/" + xronos.ToString
        'poses meres exei o minas ->28,30,31
        'ReDim esodMin(11)
        ReDim pliromMin(11)
        ReDim dianMin(11)
        ReDim tmimMin(11)

        'dianiktereuseis, deipna geumata ktl.
        Me.Esoda_praktoreiwnTableAdapter.FillAnalEsodBBySimbAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, arxiIm, arxiIm, True, telosIm, telosIm, _
                      True, arxiIm, telosIm)
        berechne_esoda(arxiIm, telosIm, dianMin)
        Me.Esoda_praktoreiwnTableAdapter.FilDiaforeslByChkinAfAnxEkptosi(Me.DbhotelDataSet.esoda_praktoreiwn, True, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
                                    True, True, arxiIm, telosIm)
        berechne_miniaies_ekptoseis_prakt(arxiIm, telosIm, dianMin)
        'berechne ekptoseis ws diafora
        'Me.Esoda_praktoreiwnTableAdapter.FillTimologiaByAfAn(Me.DbhotelDataSet.esoda_praktoreiwn, True, arxiIm, arxiIm, True, True, telosIm, telosIm, _
        '                                                            True, True, arxiIm, telosIm, True)
        ''MsgBox(Me.DbhotelDataSet.esoda_praktoreiwn.Count)
        ''MsgBox("sdfsf")
        'berechne_diafora(arxiIm, telosIm, dianMin)

        'Anfrage me ta tmimata ->sum posa ana imera
        Me.Analysi_esodwn_tmimatwn_minosTableAdapter.FillEsodaOlatmimataMinosAnalysi(Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos, arxiIm, telosIm)
        Me.TimologiaTableAdapter.FillByApoMexriAkyr(Me.DbhotelDataSet.timologia, arxiIm, telosIm, False)
        Me.XrewseispraktoreiaTableAdapter.FillXrewseisMina(Me.DbhotelDataSet.xrewseispraktoreia, arxiIm, telosIm)
        Me.EisprakseispraktoreiaTableAdapter.FillEisparakseisMina(Me.DbhotelDataSet.eisprakseispraktoreia, arxiIm, telosIm)

        'For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
        '    'esoda apo dianiktereuseis
        '    berechne_esoda(j, dianMin)
        'Next
        For j = 0 To Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos.Count - 1
            'esoda apo zental tmimata-xrewstes tameio
            berechne_esod_tmimatwn(j, arxiIm, pliromMin, tmimMin)
            fuelle_dataset_tmimata(j, count) 'to 0 gia na briskw ta Item tou Dataset->anaferetai sta 12 prwta Item tou dataset
        Next
        'ta esoda kai dianiktereuseis einai etoima!->fuelle to eintrag Esoda sto Dataset ekt_telos_esoda
        fuelle_dataset_dianikt_esoda(dianMin, tmimMin, count) 'kwdikos+2 einai to ID twn esodwn sto dataset ekt_telos_esoda

        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            berechne_xrewstes_apo_timologia(j, arxiIm, pliromMin)
        Next
        For j = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
            berechne_xrewstes_apo_praktoreia(j, arxiIm, pliromMin)
        Next
        For j = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1
            berechne_eisprakseis_apo_praktoreia(j, arxiIm, pliromMin)
        Next

        fuelle_xrewstes_tameio_zu_dataset(pliromMin, count)

    End Sub
    
    Private Sub berechne_esoda(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianMin() As Single)
        Dim startIndex, countIndex As Int16

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
                berechne_esoda_etous(startIndex, countIndex, arxiIm, telosIm, dianMin)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_esoda_etous(startIndex, countIndex, arxiIm, telosIm, dianMin)
                Exit Do
            End If
        Loop

    End Sub
    Private Sub berechne_esoda_etous(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianMin() As Single)
        Dim i, counter As Int16
        Dim laufDate As Date
        Dim apoMonth, mexriMonth As Int16
        Dim poso, zahl As Single

        laufDate = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo
        'kanw setzen stin Dstruktur
        'diafora = Me.berechne_ekptoseis_mem_timologown(index)
        poso = countIndex * (Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos + Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino + Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + _
Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno + Me.DbhotelDataSet.esoda_praktoreiwn(index).extra)


        apoMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesapo.Month
        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
            mexriMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.AddDays(-1).Month
        Else
            mexriMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.Month
        End If

        For i = apoMonth To mexriMonth

            If i = mexriMonth Then
                counter = 0
                zahl = 0
                If Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
                    While laufDate <= Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri.AddDays(-1)
                        counter += 1
                        laufDate = laufDate.AddDays(1)
                    End While
                Else
                    While laufDate <= Me.DbhotelDataSet.esoda_praktoreiwn(index).timesmexri
                        counter += 1
                        laufDate = laufDate.AddDays(1)
                    End While
                End If

            Else
                counter = 0
                zahl = 0
                While laufDate.Month = i 'And laufDate <= Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi.AddDays(-1)
                    counter += 1
                    laufDate = laufDate.AddDays(1)
                End While

            End If
            zahl = poso * counter
            dianMin(i - 1) = dianMin(i - 1) + zahl
        Next

    End Sub
    Private Sub berechne_miniaies_ekptoseis_prakt(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianMin() As Single)
        Dim j, index As Int16
        Dim posoDiaf As Single
        For j = 0 To Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month >= arxiIm.Month AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month <= telosIm.Month Then
                posoDiaf = 0
                index = Me.DbhotelDataSet.esoda_praktoreiwn(j).anaxwrisi.Date.Month - 1

                If Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptpososto <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo
                    dianMin(index) = dianMin(index) - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo <> 0 Then
                    dianMin(index) = dianMin(index) - Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptposo
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).ekptimeres <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synola - Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo
                    dianMin(index) = dianMin(index) - posoDiaf
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(j).fee <> 0 Then
                    posoDiaf = Me.DbhotelDataSet.esoda_praktoreiwn(j).synolo - Me.DbhotelDataSet.esoda_praktoreiwn(j).synola
                    dianMin(index) = dianMin(index) + posoDiaf
                End If

            End If
        Next


    End Sub
    'Private Sub berechne_diafora(ByVal arxiIm As Date, ByVal telosIm As Date, ByRef dianMin() As Single)
    '    Dim startIndex, countIndex As Int16

    '    ' startIndex = 0 'apo pio entrag sto dataset
    '    Do Until startIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1
    '        countIndex = 1 'posa eintraege 

    '        If startIndex < Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
    '            While Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).sumkathposa = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).sumkathposa AndAlso _
    '        Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timolapo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timolapo AndAlso _
    '         Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).timolmexri AndAlso _
    '          Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptimeres = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptimeres AndAlso _
    '          Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptpososto = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptpososto AndAlso _
    '            Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).ekptposo = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).ekptposo AndAlso _
    '            Me.DbhotelDataSet.esoda_praktoreiwn(startIndex).fee = Me.DbhotelDataSet.esoda_praktoreiwn(startIndex + countIndex).fee

    '                countIndex += 1
    '                If startIndex + countIndex > Me.DbhotelDataSet.esoda_praktoreiwn.Count - 1 Then
    '                    Exit While
    '                End If
    '            End While

    '            berechne_diafores(startIndex, countIndex, arxiIm, telosIm, dianMin)
    '            startIndex = startIndex + countIndex
    '        Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
    '            berechne_diafores(startIndex, countIndex, arxiIm, telosIm, dianMin)
    '            Exit Do
    '        End If
    '    Loop
    'End Sub
    'Private Sub berechne_diafores(ByVal index As Int16, ByVal countIndex As Int16, ByVal arxiIm As Date, ByVal telosIM As Date, ByRef dianMin() As Single)
    '    Dim zeiger1, zeiger2 As Int16
    '    Dim apoMonth, mexriMonth As Int16

    '    ' ta zeiger diexoun tous Betrefende Mines tou eintrag
    '    apoMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.Month

    '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
    '        mexriMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).Month
    '    Else
    '        mexriMonth = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.Month
    '    End If


    '    If apoMonth < arxiIm.Month Then
    '        zeiger1 = 0
    '    ElseIf apoMonth >= arxiIm.Month And apoMonth <= telosIM.Month Then
    '        zeiger1 = apoMonth - arxiIm.Month
    '    Else
    '        zeiger1 = -1
    '    End If

    '    If mexriMonth >= telosIM.Month Then
    '        zeiger2 = telosIM.Month - arxiIm.Month
    '    ElseIf mexriMonth < telosIM.Month Then 'otan apothikeuw timeskratisis tote i teleutaia periodos exei imerominia mexri=anaxwrisi
    '        zeiger2 = mexriMonth - arxiIm.Month
    '    Else
    '        zeiger2 = -1
    '    End If


    '    If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then

    '        setze_diafores(zeiger1, zeiger2, index, countIndex, dianMin)
    '    End If
    'End Sub
    'Private Sub setze_diafores(ByVal zeiger1 As Int16, ByVal zeiger2 As Int16, ByVal startIndex As Int16, ByVal countIndex As Int16, ByRef dianMin() As Single)
    '    Dim j As Int16
    '    Dim diafora As Single

    '    For j = zeiger1 To zeiger2
    '        diafora = Me.berechne_ekptoseis_mem_timologown(j + 1, startIndex, countIndex)
    '        dianMin(j) = (dianMin(j) + diafora)
    '    Next

    'End Sub
    Private Sub berechne_esod_tmimatwn(ByVal j As Int16, ByVal arxiIM As Date, ByRef pliromMin() As TroposPl, ByRef tmimMin() As Single)
        Dim index As Int16

        index = Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).imerominia.Month
        Try
            If Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).pliromi.Equals("Μετρητοίς") Then
                pliromMin(index - 1).metritois = pliromMin(index - 1).metritois + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
            Else
                pliromMin(index - 1).pistosi = pliromMin(index - 1).pistosi + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
            End If
        Catch ex As NullReferenceException
            pliromMin(index - 1).pistosi = pliromMin(index - 1).pistosi + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
        End Try
        'an EINAI zentral tmima(kfeteria,Restourant...ktl) tote paizei rolo sta esoda, alliws mono stoys xrewstes-tameio...
        If Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).zentralOK Then
            tmimMin(index - 1) = tmimMin(index - 1) + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(j).sumposo
        End If
    End Sub
    Private Sub fuelle_dataset_tmimata(ByVal index As Int16, ByVal count As Int16)
        Dim point As Int16
        Dim monatIndex As Int16

        'pio Entrag sto dataset antistixei ston db kwdiko tou tmimatos
        point = finde_stelle_in_dataset(Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).kwd)

        If point <> -1 Then
            'datum index eianai i stelletou mina eggrafis tmimatos pou antistoixei se Column sto Dataseet(->+2 giati ta 2 prwta columns den einai imerominies)
            monatIndex = Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).imerominia.Month - 1 + count
            Me.DbhotelDataSet.ekt_etos_esoda(point).Item(monatIndex) = Me.DbhotelDataSet.ekt_etos_esoda(point).Item(monatIndex) + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).sumposo
            If count = 0 Then 'aktuelles jahr sum
                Me.DbhotelDataSet.ekt_etos_esoda(point).sumakt = Me.DbhotelDataSet.ekt_etos_esoda(point).sumakt + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).sumposo
            Else 'previous jahr sum 
                Me.DbhotelDataSet.ekt_etos_esoda(point).sumprev = Me.DbhotelDataSet.ekt_etos_esoda(point).sumprev + Me.DbhotelDataSet.analysi_esodwn_tmimatwn_minos(index).sumposo
            End If

        End If

    End Sub
    Private Sub fuelle_dataset_dianikt_esoda(ByVal dianMin() As Single, ByVal tmimMin() As Single, ByVal count As Int16)
        Dim j As Int16


        For j = 0 To 11
            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).Item(j + count) = dianMin(j) + tmimMin(j)
            'MsgBox(Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).Item(j + count))
            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 4).Item(j + count) = dianMin(j)
            If count = 0 Then 'aktuelles jahr sum
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).sumakt = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).sumakt + dianMin(j) + tmimMin(j)
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 4).sumakt = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 4).sumakt + dianMin(j)
            Else 'previous jahr sum 
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).sumprev = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 3).sumprev + dianMin(j) + tmimMin(j)
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 4).sumprev = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 4).sumprev + dianMin(j)
            End If
        Next

    End Sub
    Private Sub fuelle_xrewstes_tameio_zu_dataset(ByVal pliromMin() As TroposPl, ByVal count As Int16)
        Dim j As Int16

        For j = 0 To pliromMin.Length - 1

            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 2).Item(j + count) = pliromMin(j).pistosi
            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).Item(j + count) = pliromMin(j).metritois
            If count = 0 Then 'aktuelles jahr sum
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 2).sumakt = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 2).sumakt + pliromMin(j).pistosi
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).sumakt = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).sumakt + pliromMin(j).metritois
            Else 'previous jahr sum 
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 2).sumprev = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 2).sumprev + pliromMin(j).pistosi
                Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).sumprev = Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).sumprev + pliromMin(j).metritois
            End If
        Next
    End Sub
    Private Function finde_stelle_in_dataset(ByVal id As Int16) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.ekt_etos_esoda.Count - 1
            If Me.DbhotelDataSet.ekt_etos_esoda(j).kosten_id = id Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Sub berechne_xrewstes_apo_timologia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromMin() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.timologia(j).imerominia.Month
        Try
            If Me.DbhotelDataSet.timologia(j).parastatiko <> 2 Then
                pliromMin(index - 1).pistosi = pliromMin(index - 1).pistosi + Me.DbhotelDataSet.timologia(j).synola
            Else
                pliromMin(index - 1).pistosi = pliromMin(index - 1).pistosi - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
            End If
            If Me.DbhotelDataSet.timologia(j).exoflithi Then
                'If Me.DbhotelDataSet.timologia(j).pliromi.Equals("Μετρητοίς") Then
                If Me.DbhotelDataSet.timologia(j).parastatiko <> 2 Then
                    pliromMin(index - 1).metritois = pliromMin(index - 1).metritois + Me.DbhotelDataSet.timologia(j).synola
                Else
                    pliromMin(index - 1).metritois = pliromMin(index - 1).metritois - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                End If

            End If
        Catch ex As NullReferenceException

        End Try

    End Sub
    Private Sub berechne_xrewstes_apo_praktoreia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromMin() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.xrewseispraktoreia(j).imerominia.Month

        pliromMin(index - 1).pistosi = pliromMin(index - 1).pistosi + Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
        If Me.DbhotelDataSet.xrewseispraktoreia(j).metritois Then
            pliromMin(index - 1).metritois = pliromMin(index - 1).metritois + Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
        End If
    End Sub
    Private Sub berechne_eisprakseis_apo_praktoreia(ByVal j As Int16, ByVal arxiIm As Date, ByRef pliromMin() As TroposPl)
        Dim index As Int16
        index = Me.DbhotelDataSet.eisprakseispraktoreia(j).imerominia.Month

        pliromMin(index - 1).metritois = pliromMin(index - 1).metritois + Me.DbhotelDataSet.eisprakseispraktoreia(j).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(j).sunplin

    End Sub
    Private Sub init_kostenstellen()
        Dim j, kwdikos As Int16

        'DImiourgw arxika 8 eintraege sto ekt_analysi_esod_a me dwmatia,atoma,dianiktereuseis...ktl (sinfona me ton x-Aksona tis ektiposis maniki)
        'meta dimiourgw tosa eintraege osa einai ta standard tmimata kai sto telos dimourgw ena eintrag me ta Hmerisisia authroismata
        Me.DbhotelDataSet.ekt_etos_esoda.Clear()
        'eintrag einai identifizierbar me to unique kosten_id pou tou dinw
        'ta tmimata einai o db kwdikos tou + 8 (->ta proigoumena eintraege panw) 
        For j = 0 To Me.DbhotelDataSet.tmimata.Count - 1
            Me.DbhotelDataSet.ekt_etos_esoda.Rows.Add()
            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kosten_id = Me.DbhotelDataSet.tmimata(j).kwd
            Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kostenstelle = Me.DbhotelDataSet.tmimata(j).tmima
            If Me.DbhotelDataSet.tmimata(j).kwd > kwdikos Then
                kwdikos = Me.DbhotelDataSet.tmimata(j).kwd
            End If
        Next
        Me.DbhotelDataSet.ekt_etos_esoda.Rows.Add()
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kosten_id = kwdikos + 1
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kostenstelle = "ΔΙΑΝΥΚΤΕΡ."
        Me.DbhotelDataSet.ekt_etos_esoda.Rows.Add()
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kosten_id = kwdikos + 2
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kostenstelle = "ΜΗΝΙΑΪΑ ΕΣΟΔΑ"
        Me.DbhotelDataSet.ekt_etos_esoda.Rows.Add()
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kosten_id = kwdikos + 3
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kostenstelle = "ΧΡΕΩΣΤΕΣ"
        Me.DbhotelDataSet.ekt_etos_esoda.Rows.Add()
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kosten_id = kwdikos + 4
        Me.DbhotelDataSet.ekt_etos_esoda(Me.DbhotelDataSet.ekt_etos_esoda.Count - 1).kostenstelle = "ΤΑΜΕΙΟ"
    End Sub
    Private Sub proepiskopisi_sygkrisi_esodwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New EsodaSigkrisi()

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
    Private Function berechne_ekptoseis_mem_timologown(ByVal minas As Int16, ByVal index As Int16, ByVal countIndex As Int16) As Single
        Dim poso, ypnos, prwino, geuma, extra As Single
        Dim imeres As Int16
        Dim firstmonth, endmonth As Date

        'imerominies arxis-telous mina
        firstmonth = "1/" + (minas).ToString + "/" + etos.ToString
        endmonth = firstmonth.AddDays(27)
        While endmonth.Month = minas
            endmonth = endmonth.AddDays(1)
        End While
        endmonth = endmonth.AddDays(-1)

        'to eintrag mporei na epekteinetai kai ston epomeno mina 
        If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
            If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1) <= endmonth Then 'telos entos mina
                If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo >= firstmonth Then 'arxi entos mina
                    'imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear + 1
                    imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres
                Else 'arxi to proigoumeno mina
                    imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).DayOfYear - firstmonth.DayOfYear + 1
                End If
            Else 'telos ton epomeno mina
                If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo >= firstmonth Then 'arxi entos mina
                    'imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear + 1
                    imeres = endmonth.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear + 1
                Else 'arxi to proigoumeno mina
                    imeres = endmonth.DayOfYear - firstmonth.DayOfYear + 1
                End If
            End If
        Else 'pera tis mias touristikes periodoi
            If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri <= endmonth Then 'telos entos mina
                If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo >= firstmonth Then
                    imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres
                Else
                    imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.DayOfYear - firstmonth.DayOfYear + 1
                End If
            Else
                If Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo >= firstmonth Then 'arxi entos mina
                    'imeres = Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri.AddDays(-1).DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear + 1
                    imeres = endmonth.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).timolapo.DayOfYear + 1
                Else 'arxi to proigoumeno mina
                    imeres = endmonth.DayOfYear - firstmonth.DayOfYear + 1
                End If
            End If

        End If

        'sti timologioanalysis ta posa ypnoy,ypnoufpa ktl einai ta synolika kathara (gia oli thn paramoni)-> i ekptosi prepei na upologizetai kathe
        'fora!-

        Try
            If Me.DbhotelDataSet.esoda_praktoreiwn(index).sumkathposa >= 0 Then

                If Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto > 0 Then
                    If Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
                     
                        ypnos = imeres * (-Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)

                    End If
                    If Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
                    
                        prwino = imeres * (-Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
                    End If
                    If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Or Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
                       
                        geuma = imeres * (-(Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma + Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno) / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
                    End If
                    If Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
                       
                        extra = imeres * (-Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptpososto / 100)
                    End If
                    poso = countIndex * (ypnos + prwino + geuma + extra)

                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo > 0 Then
                  

                    If fpaYpnou = 0 Then
                        rechne_pososta_fpa(index)
                    End If
                    poso = (Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptposo / (1 + fpaYpnou / 100))
                    poso = countIndex * (-poso / (Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi.DayOfYear - Me.DbhotelDataSet.esoda_praktoreiwn(index).afixi.DayOfYear)) * imeres

                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres > 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then

                    ypnos = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))

                    prwino = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))

                    geuma = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))

                    extra = (-Me.DbhotelDataSet.esoda_praktoreiwn(index).extra / (Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres))

                    poso = countIndex * (ypnos + prwino + geuma + extra) * Me.DbhotelDataSet.esoda_praktoreiwn(index).ekptimeres
                ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).fee > 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).timolmexri = Me.DbhotelDataSet.esoda_praktoreiwn(index).anaxwrisi Then
                    If fpaYpnou = 0 Then
                        rechne_pososta_fpa(index)
                    End If
                    poso = (Me.DbhotelDataSet.esoda_praktoreiwn(index).preistag / (1 + fpaYpnou / 100))
                    poso = countIndex * poso * Me.DbhotelDataSet.esoda_praktoreiwn(index).fee
                End If

            End If
        Catch ex As StrongTypingException

            Return 0
        End Try
        Return poso.ToString("N")
    End Function
    Private Sub rechne_pososta_fpa(ByVal index As Int16)
        'Dim hilfszahl As Single
        If Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres <> 0 Then
            If fpaYpnou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos <> 0 Then
                'hilfszahl = Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnosfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres
                fpaYpnou = ((Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnosfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).ypnos) * 100).ToString("N1")

            End If
            'If fpaPrwinou = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino <> 0 Then
            '    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwinofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
            '    fpaPrwinou = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).prwino - hilfszahl)) * 100).ToString("N1")

            'End If
            'If fpaTrofis = 0 Then
            '    If Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma <> 0 Then
            '        hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).geumafpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
            '        fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).geuma - hilfszahl)) * 100).ToString("N1")
            '    ElseIf Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno <> 0 Then
            '        hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipnofpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
            '        fpaTrofis = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).deipno - hilfszahl)) * 100).ToString("N1")
            '    End If

            'End If
            'If fpaExtra = 0 AndAlso Me.DbhotelDataSet.esoda_praktoreiwn(index).extra <> 0 Then
            '    hilfszahl = (Me.DbhotelDataSet.esoda_praktoreiwn(index).extrfpa / Me.DbhotelDataSet.esoda_praktoreiwn(index).imeres)
            '    fpaExtra = ((hilfszahl / (Me.DbhotelDataSet.esoda_praktoreiwn(index).extra - hilfszahl)) * 100).ToString("N1")

            'End If
        End If


    End Sub
    ' TIMOLOGIAKH POLITIKH DOMISI TIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISI
    'TIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISI
    'TIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISITIMOLOGIAKH POLITIKH DOMISI
    Private Sub timologiaki_politiki()

        EtiketaLbl.Text = "Τιμολογιακή πολιτική χρήσης"

        EtiketaPnl.Location = New Point(5, 5)
        EtiketaPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        TimpolPnl.Location = New Point(2, EtiketaPnl.Height)
        Me.TimpolPnl.Size = New Point(ZentralPnl.Width - 10, ZentralPnl.Height - 10)

        etosTbx.Text = "2016"
        EtiketaPnl.Controls.Add(EtiketaLbl)
        ZentralPnl.Controls.Add(EtiketaPnl)
        ZentralPnl.Controls.Add(TimpolPnl)
    End Sub

    Private Sub TimpolBtn_Click(sender As Object, e As EventArgs) Handles TimpolBtn.Click
        Try
            If Not StatistChk.Checked Then
                kratiseisadapter.FillTimolPolitikiDomisByEtos(Me.DbhotelDataSet1.kratiseis, CType(etosTbx.Text, Short))
                berechne_timol_politiki()
            Else
                'Me.KratVillaPraktTableAdapter.FillKratiseisVillaPraktoreia(Me.DbhotelDataSet1.KratVillaPrakt, CType(etosTbx.Text, Short))
                statistikaadapter.FillKratiseisVillaPraktoreia(Me.DbhotelDataSet1.KratVillaPrakt, (CType(etosTbx.Text, Short)))
                proepiskopisi_statistika_prakt()
            End If

        Catch ex As InvalidCastException
            MsgBox("Εισάγετε σωστό έτος")
            Exit Sub
        End Try

    End Sub

    Private Sub berechne_timol_politiki()
        Dim startIndex, countIndex As Int16
        Dim esoda() As Single
        Dim kratiseis() As Int16
        Dim kleisimata() As Int16
        Dim days() As Int16

        Me.DbhotelDataSet1.timol_politiki.Clear()
        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet1.kratiseis.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet1.kratiseis.Count - 1 Then
              
                While Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio = Me.DbhotelDataSet1.kratiseis(startIndex + countIndex).dwmatio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet1.kratiseis.Count - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)

                ReDim esoda(11)
                ReDim kratiseis(11)
                ReDim kleisimata(11)
                ReDim days(11)
                berechne_timol_politiki_villas(startIndex, countIndex, esoda, kratiseis, kleisimata, days)
                fuelle_dataset_timol_poltitki(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio, esoda, kratiseis, kleisimata, days)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)

                ReDim esoda(11)
                ReDim kratiseis(11)
                ReDim kleisimata(11)
                ReDim days(11)
                berechne_timol_politiki_villas(startIndex, countIndex, esoda, kratiseis, kleisimata, days)
                fuelle_dataset_timol_poltitki(Me.DbhotelDataSet1.kratiseis(startIndex).dwmatio, esoda, kratiseis, kleisimata, days)
                Exit Do
            End If
        Loop

        proepiskopisi_timol_politik()

    End Sub
    Private Sub fuelle_dataset_timol_poltitki(ByVal dwm As String, ByVal esoda() As Single, ByVal krat() As Int16, ByVal kleisim() As Int16, ByVal days() As Int16)
        Me.DbhotelDataSet1.timol_politiki.Rows.Add()

        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(0) = dwm

        If krat(0) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(1) = esoda(0) / krat(0)
        End If
        If krat(1) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(2) = esoda(1) / krat(1)
        End If
        If krat(2) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(3) = esoda(2) / krat(2)
        End If
        If krat(3) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(4) = esoda(3) / krat(3)
        End If
        If krat(4) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(5) = esoda(4) / krat(4)
        End If
        If krat(5) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(6) = esoda(5) / krat(5)
        End If
        If krat(6) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(7) = esoda(6) / krat(6)
        End If
        If krat(7) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(8) = esoda(7) / krat(7)
        End If
        If krat(8) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(9) = esoda(8) / krat(8)
        End If
        If krat(9) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(10) = esoda(9) / krat(9)
        End If
        If krat(10) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(11) = esoda(10) / krat(10)
        End If
        If krat(11) <> 0 Then
            Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(12) = esoda(11) / krat(11)
        End If

        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(13) = krat(0)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(14) = krat(1)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(15) = krat(2)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(16) = krat(3)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(17) = krat(4)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(18) = krat(5)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(19) = krat(6)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(20) = krat(7)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(21) = krat(8)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(22) = krat(9)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(23) = krat(10)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(24) = krat(11)

        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(25) = kleisim(0)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(26) = kleisim(1)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(27) = kleisim(2)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(28) = kleisim(3)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(29) = kleisim(4)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(30) = kleisim(5)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(31) = kleisim(6)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(32) = kleisim(7)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(33) = kleisim(8)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(34) = kleisim(9)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(35) = kleisim(10)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(36) = kleisim(11)

        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(37) = days(0)

        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(38) = days(1)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(39) = days(2)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(40) = days(3)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(41) = days(4)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(42) = days(5)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(43) = days(6)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(44) = days(7)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(45) = days(8)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(46) = days(9)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(47) = days(10)
        Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(48) = days(11)
        'MsgBox(Me.DbhotelDataSet1.timol_politiki(Me.DbhotelDataSet1.timol_politiki.Count - 1).Item(42))
    End Sub
    Private Sub berechne_timol_politiki_villas(ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByRef esod() As Single, ByRef krat() As Int16, ByRef kleisim() As Int16, ByRef day() As Int16)
        Dim minas, startindex, days As Int16

        'Dim counter As Int16 'metra tis kratiseis tou group tou praktoreiou->group= Idia afixi kai anaxwrisi

        startindex = datasetIndex
        'edw opws panw me ta praktoreia psaxnw tis kratiseis ana parktoreio me IDIA afixi, anaxwrisi (GROUP)

        Do Until startindex > (datasetIndex + countIndex - 1)

            If startindex < (datasetIndex + countIndex - 1) Then
                'While Me.DbhotelDataSet.dianiktereuseis_mina(startindex).afixi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).afixi _
                '    AndAlso Me.DbhotelDataSet.dianiktereuseis_mina(startindex).anaxwrisi = Me.DbhotelDataSet.dianiktereuseis_mina(startindex + counter).anaxwrisi
                '    counter += 1
                '    If startindex + counter > (datasetIndex + countIndex - 1) Then
                '        Exit While
                '    End If
                'End While


                minas = Me.DbhotelDataSet1.kratiseis(startindex).afixi.Month - 1

                days = Me.DbhotelDataSet1.kratiseis(startindex).anaxwrisi.Subtract(Me.DbhotelDataSet1.kratiseis(startindex).afixi).Days
                day(minas) = day(minas) + days
                esod(minas) = esod(minas) + (Me.DbhotelDataSet1.kratiseis(startindex).synolo / days)
                krat(minas) = krat(minas) + 1
                minas = Me.DbhotelDataSet1.kratiseis(startindex).imeromkratisis.Month - 1
                kleisim(minas) = kleisim(minas) + 1
                startindex = startindex + 1
            Else
                minas = Me.DbhotelDataSet1.kratiseis(startindex).afixi.Month - 1
                days = Me.DbhotelDataSet1.kratiseis(startindex).anaxwrisi.Subtract(Me.DbhotelDataSet1.kratiseis(startindex).afixi).Days
                day(minas) = day(minas) + days
                esod(minas) = esod(minas) + (Me.DbhotelDataSet1.kratiseis(startindex).synolo / days)
                krat(minas) = krat(minas) + 1
                minas = Me.DbhotelDataSet1.kratiseis(startindex).imeromkratisis.Month - 1
                kleisim(minas) = kleisim(minas) + 1
                Exit Do

            End If
        Loop

    End Sub
    Private Sub proepiskopisi_timol_politik()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New TimolPolitik()

        'MsgBox(Me.DbhotelDataSet.ekt_analysi_esod_a.Count)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ektiposi.SetDataSource(DbhotelDataSet1)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()

    End Sub
    Private Sub proepiskopisi_statistika_prakt()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New KratiseisVillaPrakt()

        'MsgBox(Me.DbhotelDataSet.ekt_analysi_esod_a.Count)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ektiposi.SetDataSource(DbhotelDataSet1)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()

    End Sub
    Private Sub ErgasiesTelosEtous_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub
    'Private Sub ErgasiesTelosEtous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    'End Sub

    Public Sub New(ByVal imerominia As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imeromErgasias.Year

        Me.ZentralPnl.Controls.Clear()
        'TODO: This line of code loads data into the 'DbhotelDataSet.eisprakseispraktoreia' table. You can move, or remove it, as needed.
        Me.EisprakseispraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.eisprakseispraktoreia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.timologia' table. You can move, or remove it, as needed.
        'Me.TimologiaTableAdapter.Fill(Me.DbhotelDataSet.timologia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.ethnikotites' table. You can move, or remove it, as needed.
        Me.EthnikotitesTableAdapter.Fill(Me.DbhotelDataSet.ethnikotites)
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

  

End Class