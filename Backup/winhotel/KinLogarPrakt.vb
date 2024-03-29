Public Class Praktoreia
    Dim imeromErgasias As Date
    Dim etos As Int16

    'edw globale Variablen gia isozigio emfanisi
    

    'edw globale Variablen gia kartela Praktoreiou
    Dim kwdKartPrakt, kwdKartSimb, kwdKartParast As Integer
    Dim parastCboxKwd() As Integer
    'edw globale Variablen gia kinisi Hmeras Praktoreiwn
    Dim locationX() As Int16
    'edw globale Variablen gia Eisprakseis Praktoreiwn
    Dim kwdEisprPrakt As Integer
    Dim kwdEispTimol, kwdEispXrews, kwdEispr As Integer

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles PraktoreiaTreeView.AfterSelect
        Select Case Me.PraktoreiaTreeView.SelectedNode.Name.ToString
            Case "metafora_ypoloipwn"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.metaf_ypol()
            Case "ekt_isozig_prakt"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.ekt_isosigiou_prakt()
            Case "emf_isozig_prakt"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.emf_isosigiou_prakt()
            Case "emf_kart_prakt"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.emf_logariasmou_praktoreiou()
            Case "EktHmerKin"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.ekt_imerisias_kinisis_praktor()
            Case "EmfHmerKin"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.emf_imerisias_kinisis_praktor()
            Case "Eispraxeis"
                Me.PraktZentralPnl.Controls.Clear()
                Me.PraktZentralPnl.BorderStyle = BorderStyle.Fixed3D
                Me.PraktZentralPnl.Location = New System.Drawing.Point(5, 5)
                Me.PraktZentralPnl.Dock = DockStyle.Fill
                Me.eisprakseis_praktoreia()
        End Select

    End Sub
    Private Sub metaf_ypol()

        EtiketaLbl.Text = "ΜΕΤΑΦΟΡΑ ΥΠΟΛOΙΠΩΝ ΣΕ ΝΕΑ SEASON"
        EtiketaLbl.Location = New Point(EtiketaPraktPnl.Width / 7, 15)

        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        MetafYpolPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.MetafYpolPnl.Size = New Point(PraktZentralPnl.Width - 10, PraktZentralPnl.Height - 10)
        MetafYpol1Tbx.Text = etos.ToString
        'MetafYpol2Tbx.Text = etos.ToString
        MetafYpol2Tbx.Text = (etos + 1)
        MetafYpolPck.MinDate = "1/1/" + (etos + 1).ToString
        MetafYpolPck.Value = "1/1/" + MetafYpol2Tbx.Text.ToString
        PraktZentralPnl.Controls.Add(MetafYpolPnl)
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
    End Sub
    'Private Sub MetafYpol2Tbx_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetafYpol2Tbx.Enter
    'End Sub
    Private Sub MetafYpol2Tbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetafYpol2Tbx.Leave
        Try
            If CType(sender.text, Int16) <= etos Then
                sender.text = etos + 1
            End If
        Catch ex As InvalidCastException
            sender.text = etos + 1
        End Try
    End Sub
    Private Sub MetafYpolBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetafYpolBtn.Click
        Dim apo, mexri As Date
        Dim j As Int16
        Dim aitio As String
        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString
        aitio = "Υπόλοπο Season " + etos.ToString
        Me.MetaforaypoloipwnTableAdapter.DeleteBySeasonaltneu(etos, MetafYpol2Tbx.Text)
        Me.DbhotelDataSet.isozigio_praktoreiwn.Clear()
        fuelle_isoz_prakt(apo, mexri, False, False)

        For j = 0 To Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1
            Me.MetaforaypoloipwnTableAdapter.InsertPrakt(Me.DbhotelDataSet.isozigio_praktoreiwn(j).kwdprakt, etos, MetafYpol2Tbx.Text, _
            MetafYpolPck.Value, Me.DbhotelDataSet.isozigio_praktoreiwn(j).ypoloipo, aitio)
          
        Next
        'etos = 2008
        'imeromErgasias = "25/5/2008"
    End Sub
    '*********************ΕΚΤΥΠΩΣΗ ΙΣΟΖΥΓΙΟΥ - ΗΛΙΚΙΑΣ ΥΠΟΛΟΙΠΩΝ ΠΡΑΚΤΟΡΕΙΩΝ*********************ΕΚΤΥΠΩΣΗ ΙΣΟΖΥΓΙΟΥ - ΗΛΙΚΙΑΣ ΥΠΟΛΟΙΠΩΝ ΠΡΑΚΤΟΡΕΙΩΝ

    Private Sub ekt_isosigiou_prakt()
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        IsozigioEktPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.IsozigioEktPnl.Size = New Point(PraktZentralPnl.Width - 10, PraktZentralPnl.Height - 10)

        EtiketaLbl.Text = "ΕΚΤΥΠΩΣΗ ΙΣΟΖΥΓΙΟΥ - ΗΛΙΚΙΑΣ ΥΠΟΛΟΙΠΩΝ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(15, 15)
        Isozigio1Pck.MinDate = "1/1/" + etos.ToString
        Isozigio2Pck.MinDate = "1/1/" + etos.ToString
        Isozigio1Pck.MaxDate = "31/12/" + etos.ToString
        Isozigio2Pck.MaxDate = "31/12/" + etos.ToString
        Isozigio1Pck.Value = "1/1/" + etos.ToString
        Isozigio2Pck.Value = imeromErgasias
        IsozEkt1Rdb.Checked = True
        Isozigio1Tbx.Text = 10
        Isozigio2Tbx.Text = 30
        Isozigio3Tbx.Text = 90
        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        PraktZentralPnl.Controls.Add(IsozigioEktPnl)
    End Sub
    Private Sub Isozigio1Tbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Isozigio1Tbx.Leave
        Try
            If CType(sender.text, Int16) <= 0 Then
                sender.text = 10
            End If
        Catch ex As InvalidCastException
            sender.text = 10
        End Try

    End Sub

    Private Sub Isozigio2Tbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Isozigio2Tbx.Leave
        Try

            If CType(sender.text, Int16) <= CType(Isozigio1Tbx.Text, Int16) Then
                sender.text = Isozigio1Tbx.Text + 20
            End If
        Catch ex As InvalidCastException
            sender.text = Isozigio1Tbx.Text + 20
        End Try
    End Sub

    Private Sub Isozigio3Tbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Isozigio3Tbx.Leave
        Try

            If CType(sender.text, Int16) <= CType(Isozigio2Tbx.Text, Int16) Then
                sender.text = Isozigio2Tbx.Text + 60
            End If
        Catch ex As InvalidCastException
            sender.text = Isozigio2Tbx.Text + 60
        End Try
    End Sub
    Private Sub IsozEktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsozEktBtn.Click
        Dim j, sortindex As Int16
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DbhotelDataSet.isozigia_ektiposi.Clear()
            Me.DbhotelDataSet.isozigio_praktoreiwn.Clear()

            Me.DbhotelDataSet.isozigia_ektiposi.Rows.Add()
            Me.DbhotelDataSet.isozigia_ektiposi(0).apo = Isozigio1Pck.Value.Date
            Me.DbhotelDataSet.isozigia_ektiposi(0).apo = Isozigio1Pck.Value.Date
            Me.DbhotelDataSet.isozigia_ektiposi(0).mexri = Isozigio2Pck.Value.Date
            Me.DbhotelDataSet.isozigia_ektiposi(0).period1 = "(ΚΑΤΩ - " + (Isozigio1Tbx.Text - 1).ToString + "]"
            Me.DbhotelDataSet.isozigia_ektiposi(0).period2 = "[" + (Isozigio1Tbx.Text).ToString + " - " + (Isozigio2Tbx.Text - 1).ToString + "]"
            Me.DbhotelDataSet.isozigia_ektiposi(0).period3 = "[" + (Isozigio2Tbx.Text).ToString + " - " + (Isozigio3Tbx.Text - 1).ToString + "]"
            Me.DbhotelDataSet.isozigia_ektiposi(0).period4 = "[" + (Isozigio3Tbx.Text).ToString + " - ΑΝΩ)"

            bereite_dataset_vor()

            'edw (opws kai stis emfaniseis) xrisimopooiw to trik me to DataGrid gia na kanw sortieren to dataset kata praktoreio
            Dim BindingSource1 As New BindingSource
            BindingSource1.DataSource = Me.DbhotelDataSet.isozigio_praktoreiwn
            BindingSource1.Sort = "praktoreio ASC"
            IsozigEktDtGrd.DataSource = BindingSource1

            'edw din a/a -> mono gia tin ektiposi
            For j = 0 To BindingSource1.Count - 1
                sortindex = get_count_isozigio_prakt(IsozigEktDtGrd.Item(11, j).Value)
                Me.DbhotelDataSet.isozigio_praktoreiwn(sortindex).aa = j + 1
            Next
            proepiskopisi_isozigiwn()
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default
       


    End Sub
    Private Sub bereite_dataset_vor()
        Dim apo As Date ', date1, date2

        apo = "1/1/" + etos.ToString
        If Isozigio1Pck.Value.Date <= Isozigio2Pck.Value.Date Then
            Me.DbhotelDataSet.isozigio_praktoreiwn.Clear()

            'edw xrisimopoiw thn procedure apo tis emfaniseis gia na foularw tis stiles xrewseis-eisprakseis tou Dataset
            fuelle_isoz_prakt(Isozigio1Pck.Value.Date, Isozigio2Pck.Value.Date, IsozEkt2Rdb.Checked, False)

            If apo <= Isozigio1Pck.Value.Date Then
                'stili me proigoumena Ypoloipa
                fuelle_isoz_prakt_ypoloipa(apo, Isozigio1Pck.Value.AddDays(-1), 0)

                'analysi Ypoloipou->prwti periodos(->period1)
                If apo <= Isozigio2Pck.Value.AddDays(-Isozigio1Tbx.Text + 1) Then
                    fuelle_isoz_prakt_ypoloipa(Isozigio2Pck.Value.AddDays(-Isozigio1Tbx.Text + 1), Isozigio2Pck.Value.Date, 1)
                Else
                    fuelle_isoz_prakt_ypoloipa(apo, Isozigio2Pck.Value.Date, 1)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period1 = "ΚΑΤΩ-" + (Isozigio1Tbx.Text - 1).ToString
                    Exit Sub
                End If

                'analysi Ypoloipou->deuteri  periodos
                If apo <= Isozigio2Pck.Value.AddDays(-Isozigio2Tbx.Text + 1) Then
                    fuelle_isoz_prakt_ypoloipa(Isozigio2Pck.Value.AddDays(-Isozigio2Tbx.Text + 1), Isozigio2Pck.Value.AddDays(-Isozigio1Tbx.Text), 2)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period2 = (Isozigio1Tbx.Text).ToString + "-" + (Isozigio2Tbx.Text - 1).ToString
                Else
                    fuelle_isoz_prakt_ypoloipa(apo, Isozigio2Pck.Value.AddDays(-Isozigio1Tbx.Text), 2)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period2 = (Isozigio1Tbx.Text).ToString + "-" + (Isozigio2Tbx.Text - 1).ToString
                    Exit Sub
                End If

                'analysi Ypoloipou->triti  periodos
                If apo <= Isozigio2Pck.Value.AddDays(-Isozigio3Tbx.Text + 1) Then
                    fuelle_isoz_prakt_ypoloipa(Isozigio2Pck.Value.AddDays(-Isozigio3Tbx.Text + 1), Isozigio2Pck.Value.AddDays(-Isozigio2Tbx.Text), 3)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period3 = (Isozigio2Tbx.Text).ToString + "-" + (Isozigio3Tbx.Text - 1).ToString
                Else
                    fuelle_isoz_prakt_ypoloipa(apo, Isozigio2Pck.Value.AddDays(-Isozigio2Tbx.Text), 3)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period3 = (Isozigio2Tbx.Text).ToString + "-" + (Isozigio3Tbx.Text - 1).ToString
                    Exit Sub
                End If
                'analysi Ypoloipou->tetarti  periodos
                If apo <= Isozigio2Pck.Value.AddDays(-Isozigio3Tbx.Text) Then
                    fuelle_isoz_prakt_ypoloipa(apo, Isozigio2Pck.Value.AddDays(-Isozigio3Tbx.Text), 4)
                    'Me.DbhotelDataSet.isozigia_ektiposi(0).period3 = (Isozigio3Tbx.Text).ToString + "-ΑΝΩ"
                End If
                'MsgBox(Me.DbhotelDataSet.isozigio_praktoreiwn.Count)
            End If
        End If
    End Sub
    Private Sub fuelle_isoz_prakt_ypoloipa(ByVal apo As Date, ByVal mexri As Date, ByVal period As Byte)
        Dim j, index As Int16
        Dim onomaPrakt As String


        'edw ftiaxnw to dataset-> stiles me proigoumena ypoloipa kai analysi (HLIKIA) ypoloipwn
        'ACHTUN:praktoreiametimologia einai VIEW (ERWTISI) kai oxi kanoniko Table!
        'periexei tis XREWSEIS (apo DB table XrewseisPraktoreiwn) olwn twn praktoreiwn
        Me.PraktoreiametimologiaTableAdapter.FillEnergaPraktorkwdSumxrewseisByXrewsiEtos(Me.DbhotelDataSet.praktoreiametimologia, apo, mexri)

        For j = 0 To Me.DbhotelDataSet.praktoreiametimologia.Count - 1
            index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiametimologia(j).praktoreia_kwd)
            If index <> -1 Then
                If Not Me.DbhotelDataSet.praktoreiametimologia(j).metritois Then
                    Select Case period
                        Case 0 'poigoumeno ypoloipo
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                            'Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis - Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis
                        Case 1 'ANALYSH YPOLOIPOWN
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                        Case 2
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                        Case 3
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                        Case 4
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                    End Select
                End If
            Else
                If period = 0 And Not Me.DbhotelDataSet.praktoreiametimologia(j).metritois Then
                    insert_neu_prakt_isozigio_proypoloipa(Me.DbhotelDataSet.praktoreiametimologia(j).praktoreia_kwd, Me.DbhotelDataSet.praktoreiametimologia(j).eponimia, Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi, 0)
                End If
            End If
        Next
        'edw praktoreiameeisprakseis einai VIEW tou DBTable eisprakseispraktoreiwn
        Me.PraktoreiameeisprakseisTableAdapter.FillEnergPraktSumeisprByEisprEtos(Me.DbhotelDataSet.praktoreiameeisprakseis, apo, mexri)
        For j = 0 To Me.DbhotelDataSet.praktoreiameeisprakseis.Count - 1
            index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiameeisprakseis(j).praktoreia_kwd)
            If index <> -1 Then
                Select Case period
                    Case 0
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                        'Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis - Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis
                    Case 1
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                    Case 2
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                    Case 3
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                    Case 4
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                End Select
            Else
                If period = 0 Then
                    insert_neu_prakt_isozigio_proypoloipa(Me.DbhotelDataSet.praktoreiameeisprakseis(j).praktoreia_kwd, Me.DbhotelDataSet.praktoreiameeisprakseis(j).eponimia, 0, Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi + Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                End If
            End If
        Next
        'edw praktoreiameparastatika einai VIEW tou DBTable TIMOLOGIA!!!!
        'Me.PraktoreiameparastatikaTableAdapter.FillEnergPrakBySynolaEtosExoflAkyrMauro(Me.DbhotelDataSet.praktoreiameparastatika, apo, mexri, False, False)
        Me.PraktoreiameparastatikaTableAdapter.FillEnerrgPraktByEtosExoflAkyrMauro(Me.DbhotelDataSet.praktoreiameparastatika, apo, mexri, False, False)
        For j = 0 To Me.DbhotelDataSet.praktoreiameparastatika.Count - 1
            index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd)
            If index <> -1 Then
                If Not Me.DbhotelDataSet.praktoreiameparastatika(j).exoflithi Then
                    Select Case period
                        Case 0
                            If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.praktoreiameparastatika(j).synola - Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli - Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                            End If

                            ' Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Me.DbhotelDataSet.praktoreiameparastatika(j).synola
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis - Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis
                        Case 1
                            If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 + Me.DbhotelDataSet.praktoreiameparastatika(j).synola - Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli - Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                            End If
                        Case 2
                            If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 + Me.DbhotelDataSet.praktoreiameparastatika(j).synola - Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli - Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                            End If
                        Case 3
                            If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 + Me.DbhotelDataSet.praktoreiameparastatika(j).synola - Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli - Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                            End If

                        Case 4
                            If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 + Me.DbhotelDataSet.praktoreiameparastatika(j).synola - Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli - Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))

                            End If

                    End Select
                End If
            Else
                If period = 0 And Not Me.DbhotelDataSet.praktoreiameparastatika(j).exoflithi Then
                    If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                        insert_neu_prakt_isozigio_proypoloipa(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, Me.DbhotelDataSet.praktoreiameparastatika(j).synola, Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli + Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                    Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                        insert_neu_prakt_isozigio_proypoloipa(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, -Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola), 0)
                    End If

                End If
            End If
        Next

        Me.MetaforaypoloipwnTableAdapter.FillBySeasonImerom(Me.DbhotelDataSet.metaforaypoloipwn, etos, apo, mexri)
        For j = 0 To Me.DbhotelDataSet.metaforaypoloipwn.Count - 1
            index = index_von_prakt_isozigio(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio)
            If index <> -1 Then
                Select Case period
                    Case 0
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo)
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).proypoloipo + Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis - Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis
                    Case 1
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod1 + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo)
                    Case 2
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod2 + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo)
                    Case 3
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod3 + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo)
                    Case 4
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypolperiod4 + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo)
                End Select
            Else
                If period = 0 Then
                    onomaPrakt = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio)
                    insert_neu_prakt_isozigio_proypoloipa(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio, onomaPrakt, Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo, 0)
                End If
            End If


        Next
      


    End Sub
    Private Sub proepiskopisi_isozigiwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New PraktoreiaIsozigio

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.DisplayGroupTree = False
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    Private Function index_von_prakt_isozigio_ypoloipa(ByVal kwd As Integer) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.isozigio_praktoreiwn(j).kwdprakt = kwd Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Sub insert_neu_prakt_isozigio_proypoloipa(ByVal kwd As Integer, ByVal onoma As String, ByVal xrewsi As Single, ByVal eispraksi As Single)
        Me.DbhotelDataSet.isozigio_praktoreiwn.Rows.Add()
        'Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).aa = Me.DbhotelDataSet.isozigio_praktoreiwn.Count
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).praktoreio = onoma
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).xrewseis = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).eisprakseis = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypoloipo = xrewsi - eispraksi
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).proypoloipo = xrewsi - eispraksi
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).kwdprakt = kwd
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).sortindex = Me.DbhotelDataSet.isozigio_praktoreiwn.Count
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod1 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod2 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod3 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod4 = 0
    End Sub
    Private Function get_count_isozigio_prakt(ByVal index As Int16) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.isozigio_praktoreiwn(j).sortindex = index Then
                Return j
            End If
        Next
        Return -1
    End Function

   


    '**********************ISOZIGIO PRAKTOREION EMFANISI ***************************ISOZIGIO PRAKTOREION EMFANISI * ****************ISOZIGIO PRAKTOREION EMFANISI  * *************************
    Private Sub emf_isosigiou_prakt()
        Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)


        EtiketaLbl.Text = "ΙΣΟΖΥΓΙΟ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPraktPnl.Width / 4, 15)

        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        IsozigioEmfPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.IsozigioEmfPnl.Size = New Point(PraktZentralPnl.Width - 10, PraktZentralPnl.Height - 10)
        IsozigioImeromErg.Text = imeromErgasias
        Isozigio1Rdb.Checked = True

        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        PraktZentralPnl.Controls.Add(IsozigioEmfPnl)
    End Sub
    
    Private Sub IsozigioEmfBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsozigioEmfBtn.Click
        Dim apo, mexri As Date
        Dim olaOk As Boolean
        apo = "1/1/" + etos.ToString
        mexri = "31/12/" + etos.ToString
        If Isozigio2Rdb.Checked Then
            olaOk = True
        End If

        Me.DbhotelDataSet.isozigio_praktoreiwn.Clear()
        fuelle_isoz_prakt(apo, mexri, olaOk, True)

    End Sub
    Private Sub fuelle_isoz_prakt(ByVal apo As Date, ByVal mexri As Date, ByVal olaOK As Boolean, ByVal emfanisiOK As Boolean)
        Dim j, praktCount, index As Int16
        Dim onomaPrakt As String
        praktCount = 0
        'ReDim aktivePrakt(-1)
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.PraktoreiametimologiaTableAdapter.FillEnergaPraktorkwdSumxrewseisByXrewsiEtos(Me.DbhotelDataSet.praktoreiametimologia, apo, mexri)
            'Praktoreiametimologia einai VIEW me ola ta praktoreia (energa) me (DB-table ) xrewseispraktoreiwn
            For j = 0 To Me.DbhotelDataSet.praktoreiametimologia.Count - 1
                index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiametimologia(j).praktoreia_kwd)
                If index <> -1 Then
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi)
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi

                    If Me.DbhotelDataSet.praktoreiametimologia(j).metritois Then
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis + Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi)
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi
                    End If

                Else
                    If Not Me.DbhotelDataSet.praktoreiametimologia(j).metritois Then
                        insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiametimologia(j).praktoreia_kwd, Me.DbhotelDataSet.praktoreiametimologia(j).eponimia, Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi, 0)
                    Else
                        insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiametimologia(j).praktoreia_kwd, Me.DbhotelDataSet.praktoreiametimologia(j).eponimia, Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi, Me.DbhotelDataSet.praktoreiametimologia(j).xrewsi)
                    End If
                End If
            Next
            'Praktoreiameeisprakseis einai VIEW me ola ta praktoreia (energa) me (DB-table )eisprakseispraktwreiwn
            Me.PraktoreiameeisprakseisTableAdapter.FillEnergPraktSumeisprByEisprEtos(Me.DbhotelDataSet.praktoreiameeisprakseis, apo, mexri)
            For j = 0 To Me.DbhotelDataSet.praktoreiameeisprakseis.Count - 1
                index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiameeisprakseis(j).praktoreia_kwd)
                If index <> -1 Then
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis + Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi + Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi - Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin
                Else
                    insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiameeisprakseis(j).praktoreia_kwd, Me.DbhotelDataSet.praktoreiameeisprakseis(j).eponimia, 0, Me.DbhotelDataSet.praktoreiameeisprakseis(j).eispraksi + Me.DbhotelDataSet.praktoreiameeisprakseis(j).sunplin)
                End If
            Next
            'VIEW me timologia db TABLE
            'Me.PraktoreiameparastatikaTableAdapter.FillEnergPrakBySynolaEtosExoflAkyrMauro(Me.DbhotelDataSet.praktoreiameparastatika, apo, mexri, False, False)
            Me.PraktoreiameparastatikaTableAdapter.FillEnerrgPraktByEtosExoflAkyrMauro(Me.DbhotelDataSet.praktoreiameparastatika, apo, mexri, False, False)

            For j = 0 To Me.DbhotelDataSet.praktoreiameparastatika.Count - 1
                index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd)
                If index <> -1 Then
                    If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis + Me.DbhotelDataSet.praktoreiameparastatika(j).synola)
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Me.DbhotelDataSet.praktoreiameparastatika(j).synola

                        If Me.DbhotelDataSet.praktoreiameparastatika(j).exoflithi Then
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis + Me.DbhotelDataSet.praktoreiameparastatika(j).synola)
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - Me.DbhotelDataSet.praktoreiameparastatika(j).synola
                        Else
                            If Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli <> 0 OrElse Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi <> 0 Then
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis + Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli + Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                                Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - (Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli + Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi)
                            End If
                        End If
                    Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                        Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola)
                        If Me.DbhotelDataSet.praktoreiameparastatika(j).exoflithi Then
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis = (Me.DbhotelDataSet.isozigio_praktoreiwn(index).eisprakseis - Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                            Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola)
                        End If
                    End If


                Else
                    If Not Me.DbhotelDataSet.praktoreiameparastatika(j).exoflithi Then
                        If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Then
                            insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, Me.DbhotelDataSet.praktoreiameparastatika(j).synola, (Me.DbhotelDataSet.praktoreiameparastatika(j).prokataboli + Me.DbhotelDataSet.praktoreiameparastatika(j).simetoxi))
                        Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                            insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, -Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola), 0)
                        End If
                    Else
                        If Not ist_pistotiko(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) And Not ist_grammatio(Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko) Then 'Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                            insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, Me.DbhotelDataSet.praktoreiameparastatika(j).synola, Me.DbhotelDataSet.praktoreiameparastatika(j).synola)
                        Else 'If Me.DbhotelDataSet.praktoreiameparastatika(j).parastatiko = 2 Then
                            insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreiameparastatika(j).kwd, Me.DbhotelDataSet.praktoreiameparastatika(j).eponimia, -Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola), -Math.Abs(Me.DbhotelDataSet.praktoreiameparastatika(j).synola))
                        End If

                    End If
                End If
            Next

            'edw kanw abfrage gia xrewseis pou exoun exoun metaferthei apo proigoumena xronia
            'Me.MetaforaypoloipwnTableAdapter.FillByEtos(Me.DbhotelDataSet.metaforaypoloipwn, etos)
            Me.MetaforaypoloipwnTableAdapter.FillBySeasonImerom(Me.DbhotelDataSet.metaforaypoloipwn, etos, apo, mexri)
            For j = 0 To Me.DbhotelDataSet.metaforaypoloipwn.Count - 1
                index = index_von_prakt_isozigio(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio)
                If index <> -1 Then
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis = Me.DbhotelDataSet.isozigio_praktoreiwn(index).xrewseis + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo
                    Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo = Me.DbhotelDataSet.isozigio_praktoreiwn(index).ypoloipo + Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo
                Else
                    onomaPrakt = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio)
                    insert_neu_prakt_isozigio(Me.DbhotelDataSet.metaforaypoloipwn(j).praktoreio, onomaPrakt, Me.DbhotelDataSet.metaforaypoloipwn(j).ypoloipo, 0)
                End If
            Next

            If olaOK Then
                Me.PraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreia)
                For j = 0 To Me.DbhotelDataSet.praktoreia.Count - 1
                    index = index_von_prakt_isozigio(Me.DbhotelDataSet.praktoreia(j).kwd)
                    If index = -1 Then
                        insert_neu_prakt_isozigio(Me.DbhotelDataSet.praktoreia(j).kwd, Me.DbhotelDataSet.praktoreia(j).eponimia, 0, 0)
                    End If
                Next
            End If
            If emfanisiOK Then
                Me.IsozigiopraktoreiwnBindingSource.Sort = "praktoreio ASC"
                For j = 0 To Me.IsozigiopraktoreiwnBindingSource.Count - 1
                    IsozigioDtGrd.Item(0, j).Value = j + 1
                Next
            End If

        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default


    End Sub
  
    Private Function index_von_prakt_isozigio(ByVal kwd As Integer) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1
            If Me.DbhotelDataSet.isozigio_praktoreiwn(j).kwdprakt = kwd Then
                Return j
            End If
        Next
        Return -1
    End Function
    Private Sub insert_neu_prakt_isozigio(ByVal kwd As Integer, ByVal onoma As String, ByVal xrewsi As Single, ByVal eispraksi As Single)
        Me.DbhotelDataSet.isozigio_praktoreiwn.Rows.Add()
        'Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).aa = Me.DbhotelDataSet.isozigio_praktoreiwn.Count
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).praktoreio = onoma
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).xrewseis = xrewsi
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).eisprakseis = eispraksi
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypoloipo = (xrewsi - eispraksi)
        'MsgBox(Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypoloipo)
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).kwdprakt = kwd
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).sortindex = Me.DbhotelDataSet.isozigio_praktoreiwn.Count
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).proypoloipo = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod1 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod2 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod3 = 0
        Me.DbhotelDataSet.isozigio_praktoreiwn(Me.DbhotelDataSet.isozigio_praktoreiwn.Count - 1).ypolperiod4 = 0
    End Sub

    
    '**********************KARTELA PRAKTOREIOY EMFANISI-EKTIPOSI **************************KARTELA PRAKTOREIOY EMFANISI-EKTIPOSI  * ***************KARTELA PRAKTOREIOY EMFANISI  * *************************
    Private Sub emf_logariasmou_praktoreiou()

        kwdKartPrakt = -1
        kwdKartSimb = -1
        kwdKartParast = -1
        ReDim locationX(-1)
        init_felder_kartela()

        EtiketaLbl.Text = "ΕΜΦΑΝΙΣΗ - ΕΚΤΥΠΩΣΗ ΛΟΓΑΡΙΑΣΜΟΥ ΠΡΑΚΤΟΡΕΙΟΥ"
        EtiketaLbl.Location = New Point(KartelaPraktPnl.Width / 10, 15)
        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        KartelaPraktPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.KartelaPraktPnl.Size = New Point(PraktZentralPnl.Width - 10, PraktZentralPnl.Height - 10)
        ImeromKartelaPraktPck.MinDate = "1/1/" + etos.ToString
        ImeromKartelaPraktPck.MaxDate = "31/12/" + etos.ToString
        ImeromKartelaPrakt2Pck.MinDate = "1/1/" + etos.ToString
        ImeromKartelaPrakt2Pck.MaxDate = "31/12/" + etos.ToString

        ImeromKartelaPraktPck.Value = imeromErgasias
        ImeromKartelaPrakt2Pck.Value = "31/12/" + etos.ToString
        OlaRdb.Checked = True

        init_cbxoen()
        male_kefalida_kartelas_prakt()
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        PraktZentralPnl.Controls.Add(KartelaPraktPnl)
    End Sub
    Private Sub ImeromKartelaPraktPck_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImeromKartelaPraktPck.ValueChanged, ImeromKartelaPrakt2Pck.ValueChanged

        KartelaPrakt3Pnl.Controls.Clear()
        KartelaPrakt4Pnl.Controls.Clear()
    End Sub
    Private Sub PraktTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PraktTbx.Enter, PraktTbx.Click
        Dim PraktForm As New SimbolaiaFrm()
        Dim kwdikos As Integer
        'initialisieren_felder_variablen()

        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        kwdikos = PraktForm.return_praktoreio_kwdikos

        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If kwdKartPrakt = -1 Then
                PraktTbx.Text = "< κλίκ εδώ πάνω >"
                Exit Sub
            End If
        ElseIf kwdKartPrakt <> kwdikos Then
            KartelaPrakt3Pnl.Controls.Clear()
            KartelaPrakt4Pnl.Controls.Clear()
            kwdKartPrakt = kwdikos
            PraktTbx.Text = PraktForm.return_praktoreio
        End If
        If kwdKartPrakt <> -1 Then
            fuelle_simb_cbx()
        End If


    End Sub

    'achtung: EPIDI TIMOLOGIA EKDIDW ANA PRAKTOREIO SYNOLIKA KAI OXI ANA SIMBOLAIO PRAKTOREIOU DEN MPORW NA KANW DIAXORISMO ANA SIMBOLAIO
    '->DEN EINAI ENABLED!!!!!!!!!!!!!!!!!!!!
    Private Sub SimbolCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimbolCbx.SelectedIndexChanged

        Dim simbolaioTemp As Integer

        KartelaPrakt3Pnl.Controls.Clear()
        KartelaPrakt4Pnl.Controls.Clear()
        If sender.selectedindex > 0 Then
            simbolaioTemp = get_kwd_simbol_byAA(SimbolCbx.SelectedItem.ToString) ', praktoreiokwd)
            If simbolaioTemp = -1 Then
                Exit Sub
            Else
                kwdKartSimb = simbolaioTemp
            End If
        Else
            kwdKartSimb = -1
        End If

    End Sub
    Private Sub ParastCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParastCbx.SelectedIndexChanged
        If sender.selectedindex <> -1 Then
            kwdKartParast = parastCboxKwd(sender.selectedindex)
        Else
            kwdKartParast = -1
        End If
        KartelaPrakt3Pnl.Controls.Clear()
        KartelaPrakt4Pnl.Controls.Clear()
    End Sub
    Private Sub OlaRdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OlaRdb.CheckedChanged
        KartelaPrakt3Pnl.Controls.Clear()
        KartelaPrakt4Pnl.Controls.Clear()
    End Sub
    Private Sub male_kefalida_kartelas_prakt()

        Dim stepy, stepx, xstart, ystart As Int16

        Dim kefalCount As Int16 = 0

        stepx = 100
        stepy = 100
        xstart = 2
        ystart = 10
        'Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)

        Dim ImeromLbl, ParastLbl, XrewsLbl, PistosLbl, YpoloipLbl, AitiolLbl As New Label

        ImeromLbl.Text = "Ημερ/νία"
        ImeromLbl.TextAlign = ContentAlignment.MiddleCenter
        ImeromLbl.Size = New Point(100, 20)
        ImeromLbl.Location = New Point(xstart, ystart)
        ImeromLbl.BackColor = Color.DarkKhaki
        ImeromLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart


        ParastLbl.Text = "Παραστατικό"
        ParastLbl.TextAlign = ContentAlignment.MiddleCenter
        ParastLbl.Size = New Point(120, 20)
        ParastLbl.Location = New Point(xstart + ImeromLbl.Width + 2, ystart)
        ParastLbl.BackColor = Color.DarkKhaki
        ParastLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2

        XrewsLbl.Text = "Χρεώσεις"
        XrewsLbl.TextAlign = ContentAlignment.MiddleCenter
        XrewsLbl.Size = New Point(100, 20)
        XrewsLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2, ystart)
        XrewsLbl.BackColor = Color.DarkKhaki
        XrewsLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2

        PistosLbl.Text = "Εισπράξεις"
        PistosLbl.TextAlign = ContentAlignment.MiddleCenter
        PistosLbl.Size = New Point(100, 20)
        PistosLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2, ystart)
        PistosLbl.BackColor = Color.DarkKhaki
        PistosLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2

        YpoloipLbl.Text = "Υπόλοιπο"
        YpoloipLbl.TextAlign = ContentAlignment.MiddleCenter
        YpoloipLbl.Size = New Point(100, 20)
        YpoloipLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2 + PistosLbl.Width + 2, ystart)
        YpoloipLbl.BackColor = Color.DarkKhaki
        YpoloipLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2 + PistosLbl.Width + 2

        AitiolLbl.Text = "Αιτιολογία"
        AitiolLbl.TextAlign = ContentAlignment.MiddleCenter
        AitiolLbl.Size = New Point(220, 20)
        AitiolLbl.Location = New Point(xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2 + PistosLbl.Width + 2 + YpoloipLbl.Width + 2, ystart)
        AitiolLbl.BackColor = Color.DarkKhaki
        AitiolLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + ImeromLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2 + PistosLbl.Width + 2 + YpoloipLbl.Width + 2

        KartelaPrakt2Pnl.Controls.Add(ImeromLbl)
        KartelaPrakt2Pnl.Controls.Add(ParastLbl)
        KartelaPrakt2Pnl.Controls.Add(XrewsLbl)
        KartelaPrakt2Pnl.Controls.Add(PistosLbl)
        KartelaPrakt2Pnl.Controls.Add(YpoloipLbl)
        KartelaPrakt2Pnl.Controls.Add(AitiolLbl)

    End Sub
    Private Sub KartelaPraktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KartelaPraktBtn.Click
        Dim j, ypos, ystep, sortindex As Int16
        Dim xrewsMetaf, xrewsTim, xrewsXrewsPrakt, xrewsProEtos, eisrEipsrPrakt, eisprMetaf, d, ypolMetaf, eisprTim, xrewsPeriod, eisprPeriod As Single
        Try
            Me.Cursor = Cursors.WaitCursor
            KartelaPrakt3Pnl.Controls.Clear()
            KartelaPrakt4Pnl.Controls.Clear()
            clear_dataset()
            If kwdKartPrakt <> -1 Then
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Clear()
                Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, kwdKartPrakt)
                ystep = 25

                'Abfragen gia ApoMetafora ->diadoxika apo 3 DB Tables-> Timologia,XrewseisPtakt kai EisprPrakt 
                If OlaRdb.Checked Then
                    If kwdKartSimb = -1 Then
                        If kwdKartParast = -1 Then
                            'Try
                            'xrewsTim = Me.TimologiaTableAdapter.ApoMetaforaXrewsByImeromPraktMauro(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, False)
                            Me.TimologiaTableAdapter.FillByApoMexriPraktMauroAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.MinDate, False, kwdKartPrakt, ImeromKartelaPraktPck.Value.AddDays(-1), False)
                            For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                    xrewsTim = xrewsTim + Me.DbhotelDataSet.timologia(j).synola
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).synola
                                        End If
                                    Else
                                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).prokataboli
                                        End If
                                        If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).simetoxi
                                        End If
                                    End If

                                Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                                    xrewsTim = xrewsTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                        End If
                                    End If

                                End If
                            Next
                            'Catch ex As InvalidOperationException
                            '    xrewsTim = 0
                            'End Try
                            'Try
                            '    eisprTim = Me.TimologiaTableAdapter.ApoMetaforaEisprByImeromPraktMauro(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, False, True)
                            'Catch ex As InvalidOperationException
                            '    eisprTim = 0
                            'End Try
                        Else
                            'Try
                            'xrewsTim = Me.TimologiaTableAdapter.ApoMetaforaXrewsByImeromPraktMauroParast(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, False, kwdKartParast)
                            Me.TimologiaTableAdapter.FillByApoMexriPraktMauroParastAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.MinDate, False, kwdKartPrakt, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartParast, False)
                            For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                    xrewsTim = xrewsTim + Me.DbhotelDataSet.timologia(j).synola
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).synola
                                        End If
                                    Else
                                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).prokataboli
                                        End If
                                        If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).simetoxi
                                        End If
                                    End If

                                Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                                    xrewsTim = xrewsTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                        End If
                                    End If

                                End If
                            Next
                            'Catch ex As InvalidOperationException
                            '    xrewsTim = 0
                            'End Try
                            'Try
                            '    eisprTim = Me.TimologiaTableAdapter.ApoMetaforaEisprByImeromPraktMauroParast(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, False, True, kwdKartParast)
                            'Catch ex As InvalidOperationException
                            '    eisprTim = 0
                            'End Try
                        End If

                    Else
                        If kwdKartParast = -1 Then
                            'If kwdKartParast = -1 Then
                            'Try
                            'xrewsTim = Me.TimologiaTableAdapter.ApoMetaforaXrewsByImeromPraktSimbolMauro(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, kwdKartSimb, False)
                            Me.TimologiaTableAdapter.FillByApoMexriPraktSimbMauroAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.MinDate, False, kwdKartPrakt, kwdKartSimb, ImeromKartelaPraktPck.Value.AddDays(-1), False)
                            For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                    xrewsTim = xrewsTim + Me.DbhotelDataSet.timologia(j).synola
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).synola
                                        End If
                                    Else
                                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).prokataboli
                                        End If
                                        If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).simetoxi
                                        End If
                                    End If

                                Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                                    xrewsTim = xrewsTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                    If Me.DbhotelDataSet.timologia(j).exoflithi Then
                                        If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                            eisprTim = eisprTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                        End If
                                    End If

                                End If
                            Next

                            'Try
                            '    eisprTim = Me.TimologiaTableAdapter.ApoMetaforaEisprByImeromPraktSimbMauro(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, kwdKartSimb, False, True)
                            'Catch ex As InvalidOperationException
                            '    eisprTim = 0
                            'End Try
                        Else

                            Me.TimologiaTableAdapter.FillByApoMexriPraktSimbMauroParastAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.MinDate, False, kwdKartPrakt, kwdKartSimb, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartParast, False)

                            For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                    xrewsTim = xrewsTim + Me.DbhotelDataSet.timologia(j).synola
                                    If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                        eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).synola
                                    Else
                                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).prokataboli
                                        End If
                                        If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                            eisprTim = eisprTim + Me.DbhotelDataSet.timologia(j).simetoxi
                                        End If
                                    End If
                                Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                                    xrewsTim = xrewsTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                    If Not Me.DbhotelDataSet.timologia(j).pliromi.Equals("Επί Πιστώση") Then
                                        eisprTim = eisprTim - Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                                    End If
                                End If
                            Next
                            'Try
                            '    eisprTim = Me.TimologiaTableAdapter.ApoMetaforaEisprByImeromPraktSimbMauroParast(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, kwdKartSimb, False, True, kwdKartParast)
                            'Catch ex As InvalidOperationException
                            '    eisprTim = 0
                            'End Try



                        End If

                        'ypolMetaf = xrewsMetaf - eisprMetaf
                    End If
                    If kwdKartSimb = -1 Then
                        If kwdKartParast = -1 Then
                            Try
                                xrewsXrewsPrakt = Me.XrewseispraktoreiaTableAdapter.ApoMetaforaByImerPrakt(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt)
                            Catch ex As InvalidOperationException
                                xrewsXrewsPrakt = 0
                            End Try
                        Else
                            Try
                                xrewsXrewsPrakt = Me.XrewseispraktoreiaTableAdapter.ApoMetaforaByImerPraktParast2(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt, kwdKartParast)
                            Catch ex As InvalidOperationException
                                xrewsXrewsPrakt = 0
                            End Try
                        End If

                    End If
                    If kwdKartSimb = -1 Then
                        If kwdKartParast = -1 Then
                            Try
                                xrewsProEtos = Me.MetaforaypoloipwnTableAdapter.ApoMetaforaByEtosPrakt(etos, kwdKartPrakt)

                            Catch ex As InvalidOperationException
                                xrewsProEtos = 0
                            End Try
                        End If



                    End If
                    xrewsMetaf = xrewsTim + xrewsXrewsPrakt + xrewsProEtos
                End If
                Try
                    eisrEipsrPrakt = Me.EisprakseispraktoreiaTableAdapter.ApoMetaforaByImerPrakt(ImeromKartelaPraktPck.MinDate, ImeromKartelaPraktPck.Value.AddDays(-1), kwdKartPrakt)
                Catch ex As InvalidOperationException
                    eisrEipsrPrakt = 0
                End Try

                eisprMetaf = eisprTim + eisrEipsrPrakt
                ypolMetaf = xrewsMetaf - eisprMetaf
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()

                'To sortindex to xrisimopoiw giati antimetopisa problima me sortieren basi imerominiwn stin Ektiposi->
                'to ekt_prakt_imer_kinisi den einai sortiert kata imerominia->gia Emfinisi kanw trik me Datagridview to opoio 
                'kanei sortieren tin Bindingsource tou datagridview kai OXI to table ekt_prakt_imer_kinisi-> gi"auto eisagw 
                'sotrindex, simfona me to opoio katw kanw sotrieren to Table ekt_prakt_imer_kinisi

                sortindex = sortindex + 1
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).sortindex = sortindex
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = "Από Μεταφορά:"
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = xrewsMetaf
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = eisprMetaf
                'Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).ypoloipon = ypolMetaf


                If OlaRdb.Checked Then
                    If kwdKartSimb = -1 Then
                        If kwdKartParast = -1 Then
                            Me.TimologiaTableAdapter.FillByApoMexriPraktMauroAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.Value, False, kwdKartPrakt, ImeromKartelaPrakt2Pck.Value, False)
                        Else
                            Me.TimologiaTableAdapter.FillByApoMexriPraktMauroParastAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.Value, False, kwdKartPrakt, ImeromKartelaPrakt2Pck.Value, kwdKartParast, False)
                        End If
                    Else
                        If kwdKartParast = -1 Then
                            Me.TimologiaTableAdapter.FillByApoMexriPraktSimbMauroAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.Value, False, kwdKartPrakt, kwdKartSimb, ImeromKartelaPrakt2Pck.Value, False)
                        Else
                            Me.TimologiaTableAdapter.FillByApoMexriPraktSimbMauroParastAkyr(Me.DbhotelDataSet.timologia, ImeromKartelaPraktPck.Value, False, kwdKartPrakt, kwdKartSimb, ImeromKartelaPrakt2Pck.Value, kwdKartParast, False)
                        End If
                    End If

                    For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
                        sortindex = sortindex + 1
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).sortindex = sortindex
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = Me.DbhotelDataSet.timologia(j).imerominia
                        Try
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.timologia(j).seira + " " + Me.DbhotelDataSet.timologia(j).aa.ToString
                        Catch ex As NullReferenceException
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.timologia(j).aa.ToString
                        End Try
                        If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = Me.DbhotelDataSet.timologia(j).synola
                        Else
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                        End If

                        If Me.DbhotelDataSet.timologia(j).exoflithi Then
                            If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = Me.DbhotelDataSet.timologia(j).synola
                            Else
                                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                            End If
                        Else
                            If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 OrElse Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = Me.DbhotelDataSet.timologia(j).simetoxi + Me.DbhotelDataSet.timologia(j).prokataboli
                            End If
                        End If
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.timologia(j).aitiologia
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).tropos = Me.DbhotelDataSet.timologia(j).pliromi
                    Next
                    If kwdKartSimb = -1 Then
                        If kwdKartParast = -1 Then
                            Me.XrewseispraktoreiaTableAdapter.FillOlesXrewseisByImeromPrakt(Me.DbhotelDataSet.xrewseispraktoreia, ImeromKartelaPraktPck.Value, kwdKartPrakt, ImeromKartelaPrakt2Pck.Value)
                        Else
                            Me.XrewseispraktoreiaTableAdapter.FillOlesxrewseisByImeromPraktParast(Me.DbhotelDataSet.xrewseispraktoreia, ImeromKartelaPraktPck.Value, kwdKartPrakt, ImeromKartelaPrakt2Pck.Value, kwdKartParast)
                        End If
                    End If

                    For j = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
                        sortindex = sortindex + 1
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).sortindex = sortindex
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = Me.DbhotelDataSet.xrewseispraktoreia(j).imerominia
                        Try
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.xrewseispraktoreia(j).parast1.ToString + " " + Me.DbhotelDataSet.xrewseispraktoreia(j).parast2.ToString + " " + Me.DbhotelDataSet.xrewseispraktoreia(j).parast3.ToString
                        Catch ex As NullReferenceException
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.xrewseispraktoreia(j).parast3.ToString
                        End Try

                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = Me.DbhotelDataSet.xrewseispraktoreia(j).xrewsi
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.xrewseispraktoreia(j).aitiologia
                        If Me.DbhotelDataSet.xrewseispraktoreia(j).metritois Then
                            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).tropos = "Μετρητοίς"
                        End If

                    Next
                End If
                If kwdKartSimb = -1 Then
                    Me.EisprakseispraktoreiaTableAdapter.FillOlesEisprakseisByImeromPrakt(Me.DbhotelDataSet.eisprakseispraktoreia, ImeromKartelaPraktPck.Value, kwdKartPrakt, ImeromKartelaPrakt2Pck.Value)
                End If

                For j = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
                    sortindex = sortindex + 1
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).sortindex = sortindex
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = Me.DbhotelDataSet.eisprakseispraktoreia(j).imerominia
                    Try
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.eisprakseispraktoreia(j).parast1.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(j).parast2.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(j).parast3.ToString
                    Catch ex As NullReferenceException
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.eisprakseispraktoreia(j).parast3.ToString
                    End Try

                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = Me.DbhotelDataSet.eisprakseispraktoreia(j).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(j).sunplin
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.eisprakseispraktoreia(j).aitiologia

                Next

                'to ekt_prakt_imer_kinisi den einai sortiert kata imerominia->gia Emfinisi kanw trik me Datagridview to opoio 
                'kanei sortieren tin Bindingsource tou datagridview kai OXI to table ekt_prakt_imer_kinisi
                KartelaPrakt3Pnl.Controls.Add(DataGridView1)
                DataGridView1.Visible = False
                Dim BindingSource1 As New BindingSource
                BindingSource1.DataSource = Me.DbhotelDataSet.ekt_prakt_imer_kinisi
                'BindingSource1.Filter = "xrewsi=0"
                BindingSource1.Sort = "imerominia ASC"
                DataGridView1.DataSource = BindingSource1
                'MsgBox(DataGridView1.Item(3, 0).Value)

                For j = 0 To BindingSource1.Count - 1

                    Dim Imeromlbl, ParastLbl, AitiolLbl, XrewsLbl, YpoloipLbl, PistosLbl As New Label

                    'Sotrieren kata imerominia tou table ekt_prakt_imer_kinisi gia sosti emfanisi stin Ektiposi Crystal Report
                    sortindex = get_count_ekt_prakt_kin_dataset(DataGridView1.Item(10, j).Value)
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(sortindex).sortindex = j

                    ypos = j * ystep + 5

                    If j <> 0 Then
                        'Imeromlbl.Text = Me.DbhotelDataSet.ekt_prakt_imer_kinisi(j - 1).imerominia
                        Imeromlbl.Text = DataGridView1.Item(3, j).Value
                    End If
                    Imeromlbl.TextAlign = ContentAlignment.MiddleCenter
                    Imeromlbl.Size = New Point(100, 20)
                    Imeromlbl.Location = New Point(locationX(0), ypos)
                    Imeromlbl.BackColor = Color.Azure
                    Imeromlbl.ForeColor = Color.Black

                    'If j <> 0 Then
                    '    'ParastLbl.Text = Me.DbhotelDataSet.timologia(j - 1).seira.ToString + " " + Me.DbhotelDataSet.timologia(j - 1).aa.ToString
                    ParastLbl.Text = DataGridView1.Item(2, j).Value
                    'Else
                    '    ParastLbl.Text = "Από μεταφορά"
                    'End If
                    ParastLbl.TextAlign = ContentAlignment.MiddleCenter
                    ParastLbl.Size = New Point(120, 20)
                    ParastLbl.Location = New Point(locationX(1), ypos)
                    ParastLbl.BackColor = Color.Azure
                    ParastLbl.ForeColor = Color.Black


                    If j <> 0 Then
                        d = DataGridView1.Item(5, j).Value
                        XrewsLbl.Text = d.ToString("N")
                        xrewsPeriod = xrewsPeriod + d
                        ypolMetaf = ypolMetaf + d
                        'Me.DbhotelDataSet.ekt_prakt_imer_kinisi(j).ypoloipon = ypolMetaf
                    Else
                        d = xrewsMetaf.ToString("N")
                        XrewsLbl.Text = d.ToString("N")
                    End If
                    XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                    XrewsLbl.Size = New Point(100, 20)
                    XrewsLbl.Location = New Point(locationX(2), ypos)
                    XrewsLbl.BackColor = Color.Azure
                    XrewsLbl.ForeColor = Color.Black

                    PistosLbl.TextAlign = ContentAlignment.MiddleRight
                    PistosLbl.Size = New Point(100, 20)
                    PistosLbl.Location = New Point(locationX(3), ypos)
                    PistosLbl.BackColor = Color.Azure
                    PistosLbl.ForeColor = Color.Black
                    If j <> 0 Then
                        'd = Me.DbhotelDataSet.timologia(j - 1).synola
                        d = DataGridView1.Item(6, j).Value
                        PistosLbl.Text = d.ToString("N")
                        eisprPeriod = eisprPeriod + d
                        ypolMetaf = ypolMetaf - d
                        'Me.DbhotelDataSet.ekt_prakt_imer_kinisi(j).ypoloipon = ypolMetaf
                    ElseIf j = 0 Then
                        d = eisprMetaf.ToString("N")
                        PistosLbl.Text = d.ToString("N")
                    End If


                    YpoloipLbl.TextAlign = ContentAlignment.MiddleRight
                    YpoloipLbl.Size = New Point(100, 20)
                    YpoloipLbl.Location = New Point(locationX(4), ypos)
                    YpoloipLbl.BackColor = Color.Azure
                    YpoloipLbl.ForeColor = Color.Black
                    d = ypolMetaf
                    YpoloipLbl.Text = d.ToString("N")
                    'YpoloipLbl()

                    If j <> 0 Then
                        'AitiolLbl.Text = Me.DbhotelDataSet.timologia(j - 1).aitiologia
                        Try
                            AitiolLbl.Text = DataGridView1.Item(4, j).Value
                        Catch ex As InvalidCastException

                        End Try

                    End If
                    AitiolLbl.TextAlign = ContentAlignment.MiddleCenter
                    AitiolLbl.Size = New Point(220, 20)
                    AitiolLbl.Location = New Point(locationX(5), ypos)
                    AitiolLbl.BackColor = Color.Azure
                    AitiolLbl.ForeColor = Color.Black

                    KartelaPrakt3Pnl.Controls.Add(Imeromlbl)
                    KartelaPrakt3Pnl.Controls.Add(AitiolLbl)
                    KartelaPrakt3Pnl.Controls.Add(XrewsLbl)
                    KartelaPrakt3Pnl.Controls.Add(ParastLbl)
                    KartelaPrakt3Pnl.Controls.Add(PistosLbl)
                    KartelaPrakt3Pnl.Controls.Add(YpoloipLbl)

                Next
                For j = 0 To 1
                    Dim ParastLbl, XrewsLbl, YpoloipLbl, PistosLbl As New Label
                    If j = 0 Then
                        ParastLbl.Text = "Σύνολο Περιόδου:"
                        ParastLbl.ForeColor = Color.Black
                    Else
                        ParastLbl.Text = "Σύνολα:"
                        ParastLbl.ForeColor = Color.Blue
                    End If
                    ParastLbl.TextAlign = ContentAlignment.MiddleRight
                    ParastLbl.Size = New Point(200, 20)
                    ParastLbl.Location = New Point(locationX(1) - 80, j * 25 + 5)
                    'ParastLbl.BackColor = Color.Azure


                    If j = 0 Then
                        XrewsLbl.Text = xrewsPeriod.ToString("N")
                        XrewsLbl.ForeColor = Color.Black
                    Else
                        d = xrewsMetaf + xrewsPeriod
                        XrewsLbl.Text = d.ToString("N")
                        XrewsLbl.ForeColor = Color.Maroon
                    End If
                    XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                    XrewsLbl.Size = New Point(100, 20)
                    XrewsLbl.Location = New Point(locationX(2), j * 25 + 5)
                    XrewsLbl.BackColor = Color.Azure

                    If j = 0 Then
                        PistosLbl.Text = eisprPeriod.ToString("N")
                        PistosLbl.ForeColor = Color.Black
                    Else
                        d = eisprMetaf + eisprPeriod
                        PistosLbl.Text = d.ToString("N")
                        PistosLbl.ForeColor = Color.Maroon
                    End If

                    PistosLbl.TextAlign = ContentAlignment.MiddleRight
                    PistosLbl.Size = New Point(100, 20)
                    PistosLbl.Location = New Point(locationX(3), j * 25 + 5)
                    PistosLbl.BackColor = Color.Azure


                    d = XrewsLbl.Text - PistosLbl.Text
                    If j = 0 Then
                        d = XrewsLbl.Text - PistosLbl.Text
                        YpoloipLbl.Text = d.ToString("N")
                        YpoloipLbl.ForeColor = Color.Black
                    Else
                        d = ypolMetaf
                        YpoloipLbl.Text = d.ToString("N")
                        YpoloipLbl.ForeColor = Color.Maroon
                    End If
                    YpoloipLbl.TextAlign = ContentAlignment.MiddleRight
                    YpoloipLbl.Size = New Point(100, 20)
                    YpoloipLbl.Location = New Point(locationX(4), j * 25 + 5)
                    YpoloipLbl.BackColor = Color.Azure


                    KartelaPrakt4Pnl.Controls.Add(XrewsLbl)
                    KartelaPrakt4Pnl.Controls.Add(ParastLbl)
                    KartelaPrakt4Pnl.Controls.Add(PistosLbl)
                    KartelaPrakt4Pnl.Controls.Add(YpoloipLbl)
                Next
                If Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count <> 0 Then
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(0).arxi = 1
                    Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).telos = 1
                End If


                Me.DbhotelDataSet.ekt_prakt_kart.Rows.Add()
                Me.DbhotelDataSet.ekt_prakt_kart(0).praktoreio = kwdKartPrakt
                Me.DbhotelDataSet.ekt_prakt_kart(0).apo = ImeromKartelaPraktPck.Value
                Me.DbhotelDataSet.ekt_prakt_kart(0).mexri = ImeromKartelaPrakt2Pck.Value
                Me.DbhotelDataSet.ekt_prakt_kart(0).xrewsiperiod = xrewsPeriod
                Me.DbhotelDataSet.ekt_prakt_kart(0).pistosiperiod = eisprPeriod
                Me.DbhotelDataSet.ekt_prakt_kart(0).ypoloipperiod = xrewsPeriod - eisprPeriod
                If SimbolCbx.SelectedIndex <> -1 Then
                    Me.DbhotelDataSet.ekt_prakt_kart(0).simbolaio = SimbolCbx.SelectedItem.ToString
                Else
                    Me.DbhotelDataSet.ekt_prakt_kart(0).simbolaio = "Ολα"
                End If

                If EisprRdb.Checked Then
                    Me.DbhotelDataSet.ekt_prakt_kart(0).olaeispraxeis = True
                Else
                    Me.DbhotelDataSet.ekt_prakt_kart(0).olaeispraxeis = False
                End If
                If ParastCbx.SelectedIndex <> -1 Then
                    Me.DbhotelDataSet.ekt_prakt_kart(0).parastatika = ParastCbx.SelectedItem.ToString
                Else
                    Me.DbhotelDataSet.ekt_prakt_kart(0).parastatika = "Ολα"

                End If


                'Me.XrewseispraktoreiaTableAdapter.FillOlesXrewseisByImerom(Me.DbhotelDataSet.xrewseispraktoreia, ImeromKartelaPraktPck.Value)
                'Dim BindingSource1 As New BindingSource

                'BindingSource1.DataSource = Me.DbhotelDataSet.ekt_prakt_imer_kinisi
                'BindingSource1.Sort = "Imerominia,Desc"
            Else
                MsgBox("Επιλέξτε Πρακτορείο !", MsgBoxStyle.Information, "winfo\nikEl.")
            End If
        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default
        

    End Sub
    Private Sub KartelaPraktΕktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KartelaPraktΕktBtn.Click
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New PraktoreioKartela()

        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.DisplayGroupTree = False
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    Private Sub init_cbxoen()
        Dim j As Int16

        Me.ParastCbx.SelectedIndex = -1
        Me.ParastCbx.Items.Clear()
        ReDim parastCboxKwd(Me.DbhotelDataSet.parastatika.Count)
        For j = 0 To Me.DbhotelDataSet.parastatika.Count
            If j <> 0 Then ' ektos apo grammatio eispraksis

                Me.ParastCbx.Items.Add(Me.DbhotelDataSet.parastatika(j - 1).tipos + " " + Me.DbhotelDataSet.parastatika(j - 1).seira + " Σειρά")
                parastCboxKwd(j) = Me.DbhotelDataSet.parastatika(j - 1).kwd

            Else
                Me.ParastCbx.Items.Add("Ολα")
                parastCboxKwd(0) = -1
            End If

        Next
        'EkdosiParastTrPliromCbx
    End Sub
    Private Sub init_felder_kartela()
        Me.PraktTbx.Clear()
        Me.SimbolCbx.SelectedIndex = -1
        Me.SimbolCbx.Items.Clear()
        KartelaPrakt2Pnl.Controls.Clear()
        KartelaPrakt3Pnl.Controls.Clear()
        KartelaPrakt4Pnl.Controls.Clear()
    End Sub
    Private Sub fuelle_simb_cbx()
        Dim j As Int16
        Me.SimbolCbx.SelectedIndex = -1
        Me.SimbolCbx.Items.Clear()
        Me.SimbolaiaTableAdapter.FillByPraktoreio(Me.DbhotelDataSet.simbolaia, kwdKartPrakt, etos)

        For j = 0 To Me.DbhotelDataSet.simbolaia.Count
            If j <> 0 Then
                SimbolCbx.Items.Add(Me.DbhotelDataSet.simbolaia(j - 1).aasimbolaiou)
            Else
                SimbolCbx.Items.Add("Ολα")
            End If

        Next
    End Sub
    Private Function get_kwd_simbol_byAA(ByVal aa As String) As Integer

        Try

            Return Me.SimbolaiaTableAdapter.GetKwdByAaPraktEtos(aa, kwdKartPrakt, etos)
        Catch ex As Exception
            Return -1
        End Try


    End Function
    Private Sub clear_dataset()
        Me.DbhotelDataSet.timologia.Clear()
        Me.DbhotelDataSet.xrewseispraktoreia.Clear()
        Me.DbhotelDataSet.eisprakseispraktoreia.Clear()
        Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Clear()
        Me.DbhotelDataSet.ekt_prakt_kart.Clear()
    End Sub
    Private Function get_count_ekt_prakt_kin_dataset(ByVal index As Int16) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1
            If Me.DbhotelDataSet.ekt_prakt_imer_kinisi(j).sortindex = index Then
                Return j
            End If
        Next
        Return -1
    End Function

    '**********************KINHSH HMERAS  EKTIPOSI *************************KINHSH HMERAS  EKTIPOSI * **************KINHSH HMERAS   EKTIPOSI  * *********KINHSH HMERAS  EKTIPOSI ***
    Private Sub ekt_imerisias_kinisis_praktor()

        EtiketaLbl.Text = "ΕΚΤΥΠΩΣΗ ΗΜΕΡΗΣΙΑΣ ΚΙΝΗΣΗΣ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPraktPnl.Width / 8, 15)

        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)

        KinisiPraktEktPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.KinisiPraktEktPnl.Size = New Point(830, PraktZentralPnl.Height)

        KinisiPraktEkt1Pck.Value = imeromErgasias
        KinisiPraktEkt2Pck.Value = imeromErgasias
        KinisiPraktEkt1Pck.MinDate = "1/1/" + etos.ToString
        KinisiPraktEkt1Pck.MaxDate = "31/12/" + etos.ToString
        KinisiPraktEkt2Pck.MinDate = "1/1/" + etos.ToString
        KinisiPraktEkt2Pck.MaxDate = "31/12/" + etos.ToString
        male_tmima_kiniseis_kefalida()
        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        PraktZentralPnl.Controls.Add(KinisiPraktEktPnl)
    End Sub

    Private Sub KinisiPraktEktBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KinisiPraktEktBtn.Click
        Dim count, j, index As Int16
        index = 0

        Me.Cursor = Cursors.WaitCursor
        Try
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Clear()

            If KinisiPraktEkt1Pck.Value <= KinisiPraktEkt2Pck.Value Then
                count = KinisiPraktEkt2Pck.Value.DayOfYear - KinisiPraktEkt1Pck.Value.DayOfYear
                pBar1.Minimum = 0
                pBar1.Maximum = count + 1
                pBar1.Value = 0
                pBar1.Step = 1
                For j = 0 To count
                    pBar1.Value += 1
                    fuelle_ekt_dataset(KinisiPraktEkt1Pck.Value.AddDays(j), index)
                Next
            Else
                pBar1.Minimum = 0
                pBar1.Maximum = count + 1
                fuelle_ekt_dataset(KinisiPraktEkt1Pck.Value, index)
            End If
            proepiskopisi_katastasis_praktoreiwn()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
        pBar1.Value = 0
        Me.Cursor = Cursors.Default
    End Sub

    'Private Sub fuelle_ekt_dataset(ByVal apo As Date, ByVal mexri As Date, ByRef index As Int16)
    Private Sub fuelle_ekt_dataset(ByVal imerominia As Date, ByRef index As Int16)
        Dim j, i, k, arxiInd As Int16
        Dim d As Single
        Dim praktoreio As String

        arxiInd = index

        Me.TimologiaTableAdapter.FillByImeromMauroAkyro(Me.DbhotelDataSet.timologia, imerominia, False, False)
        'Me.TimologiaTableAdapter.FillByApoMexriMauro(Me.DbhotelDataSet.timologia, apo, mexri, False)


        For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
            index = index + 1
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = imerominia
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aa = j + 1
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.timologia(j).praktoreio)
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.timologia(j).seira + " " + Me.DbhotelDataSet.timologia(j).aa.ToString
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.timologia(j).aitiologia
            If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                d = Me.DbhotelDataSet.timologia(j).synola
            Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                d = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
            End If

            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = d.ToString("N")
            If Me.DbhotelDataSet.timologia(j).exoflithi Then
                'd = Me.DbhotelDataSet.timologia(j).synola
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = d.ToString("N")
            Else
                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then 'apy
                    If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 OrElse Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                            d = Me.DbhotelDataSet.timologia(j).prokataboli
                        End If
                        If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                            d = d + Me.DbhotelDataSet.timologia(j).simetoxi
                        End If
                        Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = d.ToString("N")
                    End If

                End If

            End If

        Next

        Me.XrewseispraktoreiaTableAdapter.FillByImerominia(Me.DbhotelDataSet.xrewseispraktoreia, imerominia)
        'Me.XrewseispraktoreiaTableAdapter.FillXrewseisMina(Me.DbhotelDataSet.xrewseispraktoreia, apo, mexri)
        For i = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
            index = index + 1
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = imerominia
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aa = i + 1
            praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.xrewseispraktoreia(i).praktoreio)
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).praktoreio = praktoreio
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.xrewseispraktoreia(i).parast1.ToString + " " + Me.DbhotelDataSet.xrewseispraktoreia(i).parast2.ToString + " " + Me.DbhotelDataSet.xrewseispraktoreia(i).parast3.ToString
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.xrewseispraktoreia(i).aitiologia
            d = Me.DbhotelDataSet.xrewseispraktoreia(i).xrewsi
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).xrewsi = d.ToString("N")
            If Me.DbhotelDataSet.xrewseispraktoreia(i).metritois Then
                Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = d.ToString("N")
            End If

        Next

        Me.EisprakseispraktoreiaTableAdapter.FillByImerominia(Me.DbhotelDataSet.eisprakseispraktoreia, imerominia)
        'Me.EisprakseispraktoreiaTableAdapter.FillEisparakseisMina(Me.DbhotelDataSet.eisprakseispraktoreia, apo, mexri)
        For k = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1
            index = index + 1
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Rows.Add()
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).imerominia = imerominia
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aa = k + 1
            praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.eisprakseispraktoreia(k).praktoreio)
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).praktoreio = praktoreio
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).parastatiko = Me.DbhotelDataSet.eisprakseispraktoreia(k).parast1.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(k).parast2.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(k).parast3.ToString
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).aitiologia = Me.DbhotelDataSet.eisprakseispraktoreia(k).aitiologia
            d = Me.DbhotelDataSet.eisprakseispraktoreia(k).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(k).sunplin
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count - 1).pistosi = d.ToString("N")
        Next

        If arxiInd <> index Then
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(arxiInd).arxi = 1
            Me.DbhotelDataSet.ekt_prakt_imer_kinisi(index - 1).telos = 1
        End If

    End Sub
    Private Sub proepiskopisi_katastasis_praktoreiwn()
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New PraktoreiaImerisiaKinisi()



        'Me.DbhotelDataSet.ekt_status_ekdosi(0).perigrafi = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(praktStKwd)
        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'sender.Enabled = False
        ektiposi.SetDataSource(DbhotelDataSet)
        CrystalReportViewer1.DisplayGroupTree = False
        CrystalReportViewer1.ReportSource = ektiposi
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        If Me.DbhotelDataSet.ekt_prakt_imer_kinisi.Count <> 0 Then
            Form1.ShowDialog()
        Else
            MsgBox(" Καμία καταχώρηση !", MsgBoxStyle.Information, "winfo\nikEl.")
        End If


        ektiposi.Close()
        ektiposi.Dispose()
    End Sub
    '**********************KINHSH HMERAS  EMFANISI *************************KINHSH HMERAS  EMFANISI * **************KINHSH HMERAS  EMFANISI * *********KINHSH HMERAS  EMFANISI ***********
    Private Sub emf_imerisias_kinisis_praktor()

        EtiketaLbl.Text = "ΕΜΦΑΝΙΣΗ ΗΜΕΡΗΣΙΑΣ ΚΙΝΗΣΗΣ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPraktPnl.Width / 8, 15)
        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        KinisiEmfPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.KinisiEmfPnl.Size = New Point(830, PraktZentralPnl.Height)

        EmfHmerKiniPraktPck.Value = imeromErgasias
        EmfHmerKiniPraktPck.MinDate = "1/1/" + etos.ToString
        EmfHmerKiniPraktPck.MaxDate = "31/12/" + etos.ToString
        ReDim locationX(-1)
        male_tmima_kiniseis_kefalida()

        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        PraktZentralPnl.Controls.Add(KinisiEmfPnl)
    End Sub

    Private Sub male_tmima_kiniseis_kefalida()

        Dim stepy, stepx, xstart, ystart As Int16

        Dim kefalCount As Int16 = 0

        stepx = 100
        stepy = 100
        xstart = 2
        ystart = 10
        'Me.EggrafitakiniseisTableAdapter.FillByEggrafi(Me.DbhotelDataSet.eggrafitakiniseis, eggrafiKwd)

        Dim AALbl, EponimiaLbl, ParastLbl, XrewsLbl, PistosLbl As New Label

        AALbl.Text = "Α/Α"
        AALbl.TextAlign = ContentAlignment.MiddleCenter
        AALbl.Size = New Point(40, 20)
        AALbl.Location = New Point(xstart, ystart)
        AALbl.BackColor = Color.DarkKhaki
        AALbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart

        EponimiaLbl.Text = "Επωνυμία Πρακτορείου"
        EponimiaLbl.TextAlign = ContentAlignment.MiddleCenter
        EponimiaLbl.Size = New Point(220, 20)
        EponimiaLbl.Location = New Point(xstart + AALbl.Width + 2, ystart)
        EponimiaLbl.BackColor = Color.DarkKhaki
        EponimiaLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + AALbl.Width + 2

        ParastLbl.Text = "Παραστατικό"
        ParastLbl.TextAlign = ContentAlignment.MiddleCenter
        ParastLbl.Size = New Point(170, 20)
        ParastLbl.Location = New Point(xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2, ystart)
        ParastLbl.BackColor = Color.DarkKhaki
        ParastLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2

        XrewsLbl.Text = "Χρέωση"
        XrewsLbl.TextAlign = ContentAlignment.MiddleCenter
        XrewsLbl.Size = New Point(120, 20)
        XrewsLbl.Location = New Point(xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2 + ParastLbl.Width + 2, ystart)
        XrewsLbl.BackColor = Color.DarkKhaki
        XrewsLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2 + ParastLbl.Width + 2

        PistosLbl.Text = "Πίστωση"
        PistosLbl.TextAlign = ContentAlignment.MiddleCenter
        PistosLbl.Size = New Point(120, 20)
        PistosLbl.Location = New Point(xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2, ystart)
        PistosLbl.BackColor = Color.DarkKhaki
        PistosLbl.ForeColor = Color.Blue
        kefalCount = kefalCount + 1
        ReDim Preserve locationX(kefalCount - 1)
        locationX(kefalCount - 1) = xstart + AALbl.Width + 2 + EponimiaLbl.Width + 2 + ParastLbl.Width + 2 + XrewsLbl.Width + 2

        KinisiEmf2Pnl.Controls.Add(AALbl)
        KinisiEmf2Pnl.Controls.Add(EponimiaLbl)
        KinisiEmf2Pnl.Controls.Add(XrewsLbl)
        KinisiEmf2Pnl.Controls.Add(ParastLbl)
        KinisiEmf2Pnl.Controls.Add(PistosLbl)


    End Sub
    Private Sub KinisiEmfBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KinisiEmfBtn.Click
        Dim j, i, k, ystep, ypos, aa As Int16
        Dim sumXrewsi, sumPistosi As Single
        Dim d As Single
        Try
            Me.Cursor = Cursors.WaitCursor
            KinisiEmf3Pnl.Controls.Clear()
            KinisiEmf4Pnl.Controls.Clear()
            ystep = 25
            Me.TimologiaTableAdapter.FillByImeromMauroAkyro(Me.DbhotelDataSet.timologia, EmfHmerKiniPraktPck.Value.Date, False, False)

            For j = 0 To Me.DbhotelDataSet.timologia.Count - 1
                Dim praktoreio As String
                Dim AAlbl, ParastLbl, EponimiaLbl, XrewsLbl, PistosLbl, MertitoisLbl As New Label

                aa = j + 1
                ypos = j * ystep + 5


                AAlbl.Text = aa
                AAlbl.TextAlign = ContentAlignment.MiddleCenter
                AAlbl.Size = New Point(40, 20)
                AAlbl.Location = New Point(locationX(0), ypos)
                AAlbl.BackColor = Color.Azure
                AAlbl.ForeColor = Color.Black

                praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.timologia(j).praktoreio)
                EponimiaLbl.Text = praktoreio
                EponimiaLbl.TextAlign = ContentAlignment.MiddleCenter
                EponimiaLbl.Size = New Point(220, 20)
                EponimiaLbl.Location = New Point(locationX(1), ypos)
                EponimiaLbl.BackColor = Color.Azure
                EponimiaLbl.ForeColor = Color.Black

                'seira=
                ParastLbl.Text = Me.DbhotelDataSet.timologia(j).seira + " " + Me.DbhotelDataSet.timologia(j).aa.ToString
                ParastLbl.TextAlign = ContentAlignment.MiddleCenter
                ParastLbl.Size = New Point(170, 20)
                ParastLbl.Location = New Point(locationX(2), ypos)
                ParastLbl.BackColor = Color.Azure
                ParastLbl.ForeColor = Color.Black

                If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then '(Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                    d = Me.DbhotelDataSet.timologia(j).synola 'extra kai mem APY
                Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                    d = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola) 'pistwtika timologia
                End If

                XrewsLbl.Text = d.ToString("N")
                sumXrewsi = sumXrewsi + d
                XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                XrewsLbl.Size = New Point(120, 20)
                XrewsLbl.Location = New Point(locationX(3), ypos)
                XrewsLbl.BackColor = Color.Azure
                XrewsLbl.ForeColor = Color.Black

                PistosLbl.TextAlign = ContentAlignment.MiddleRight
                PistosLbl.Size = New Point(120, 20)
                PistosLbl.Location = New Point(locationX(4), ypos)
                PistosLbl.BackColor = Color.Azure
                PistosLbl.ForeColor = Color.Black
                If Me.DbhotelDataSet.timologia(j).exoflithi Then
                    If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                        d = Me.DbhotelDataSet.timologia(j).synola
                    Else 'If Me.DbhotelDataSet.timologia(j).parastatiko = 2 Then
                        'If Me.DbhotelDataSet.timologia(j).pliromi.Equals("Μετρητοίς") Then
                        d = -Math.Abs(Me.DbhotelDataSet.timologia(j).synola)
                        'End If
                    End If
                    PistosLbl.Text = d.ToString("N")
                    sumPistosi = sumPistosi + d
                    MertitoisLbl.Text = Me.DbhotelDataSet.timologia(j).pliromi.ToString ' "Μετρ."
                    MertitoisLbl.TextAlign = ContentAlignment.MiddleLeft
                    MertitoisLbl.Size = New Point(90, 20)
                    MertitoisLbl.Location = New Point(locationX(4) + PistosLbl.Width, ypos)
                    MertitoisLbl.ForeColor = Color.Black
                    KinisiEmf3Pnl.Controls.Add(MertitoisLbl)
                Else 'EDW EKANA ALLAGH GIA NA FAINONTAI OI PROKATABOLES-SIMETOXES !!!!!!!!!!!!!!!!!!!!!!
                    If Not ist_pistotiko(Me.DbhotelDataSet.timologia(j).parastatiko) AndAlso Not ist_grammatio(Me.DbhotelDataSet.timologia(j).parastatiko) Then 'Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).apykwd Or Me.DbhotelDataSet.timologia(j).parastatiko = Me.DbhotelDataSet.etaireia(0).timolkwd Then
                        If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 OrElse Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                            If Me.DbhotelDataSet.timologia(j).prokataboli <> 0 Then
                                d = Me.DbhotelDataSet.timologia(j).prokataboli
                                MertitoisLbl.Text = "Προκατ."
                            End If
                            If Me.DbhotelDataSet.timologia(j).simetoxi <> 0 Then
                                d = d + Me.DbhotelDataSet.timologia(j).simetoxi
                                MertitoisLbl.Text = "Συμετ."
                            End If
                            PistosLbl.Text = d.ToString("N")
                            sumPistosi = sumPistosi + d
                            'MertitoisLbl.Text = "Μετρ."
                            MertitoisLbl.TextAlign = ContentAlignment.MiddleLeft
                            MertitoisLbl.Size = New Point(50, 20)
                            MertitoisLbl.Location = New Point(locationX(4) + PistosLbl.Width, ypos)
                            MertitoisLbl.ForeColor = Color.Black
                            KinisiEmf3Pnl.Controls.Add(MertitoisLbl)
                        End If
                    End If
                End If


                KinisiEmf3Pnl.Controls.Add(AAlbl)
                KinisiEmf3Pnl.Controls.Add(EponimiaLbl)
                KinisiEmf3Pnl.Controls.Add(XrewsLbl)
                KinisiEmf3Pnl.Controls.Add(ParastLbl)
                KinisiEmf3Pnl.Controls.Add(PistosLbl)

            Next

            'xrewseis praktoreia entstehen wenn ein extra parastatiko wird zum mauro indem man in Meneu Praktoreia Eisparkseis kanei
            'laden to extra Parastatiko kai alaksei thn TImi!!!!->to kanoniko wird zum Mauro->H Pragmatiki Xrewsi Praktoreiou pou fainetai edw
            'einai i Nea pragmatiki xrewsi apo to praktoreiaxrewsis Table!
            Me.XrewseispraktoreiaTableAdapter.FillByImerominia(Me.DbhotelDataSet.xrewseispraktoreia, EmfHmerKiniPraktPck.Value.Date)

            For i = 0 To Me.DbhotelDataSet.xrewseispraktoreia.Count - 1
                Dim AAlbl, ParastLbl, EponimiaLbl, XrewsLbl, PistosLbl, MertitoisLbl As New Label
                Dim praktoreio As String
                aa = j + i + 1
                ypos = (j + i) * ystep + 5

                AAlbl.Text = aa
                AAlbl.TextAlign = ContentAlignment.MiddleCenter
                AAlbl.Size = New Point(40, 20)
                AAlbl.Location = New Point(locationX(0), ypos)
                AAlbl.BackColor = Color.Azure
                AAlbl.ForeColor = Color.Black

                praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.xrewseispraktoreia(i).praktoreio)
                EponimiaLbl.Text = praktoreio
                EponimiaLbl.TextAlign = ContentAlignment.MiddleCenter
                EponimiaLbl.Size = New Point(220, 20)
                EponimiaLbl.Location = New Point(locationX(1), ypos)
                EponimiaLbl.BackColor = Color.Azure
                EponimiaLbl.ForeColor = Color.Black
                'MsgBox(Me.DbhotelDataSet.xrewseispraktoreia(i).parast1)
                'MsgBox(Me.DbhotelDataSet.xrewseispraktoreia(i).parast3)
                ParastLbl.Text = Me.DbhotelDataSet.xrewseispraktoreia(i).parast1 + " " + Me.DbhotelDataSet.xrewseispraktoreia(i).parast2 + " " + Me.DbhotelDataSet.xrewseispraktoreia(i).parast3.ToString
                ParastLbl.TextAlign = ContentAlignment.MiddleCenter
                ParastLbl.Size = New Point(170, 20)
                ParastLbl.Location = New Point(locationX(2), ypos)
                ParastLbl.BackColor = Color.Azure
                ParastLbl.ForeColor = Color.Black

                d = Me.DbhotelDataSet.xrewseispraktoreia(i).xrewsi
                XrewsLbl.Text = d.ToString("N")
                sumXrewsi = sumXrewsi + d
                XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                XrewsLbl.Size = New Point(120, 20)
                XrewsLbl.Location = New Point(locationX(3), ypos)
                XrewsLbl.BackColor = Color.Azure
                XrewsLbl.ForeColor = Color.Black

                PistosLbl.TextAlign = ContentAlignment.MiddleRight
                PistosLbl.Size = New Point(120, 20)
                PistosLbl.Location = New Point(locationX(4), ypos)
                PistosLbl.BackColor = Color.Azure
                PistosLbl.ForeColor = Color.Black
                If Me.DbhotelDataSet.xrewseispraktoreia(i).metritois Then
                    PistosLbl.Text = d.ToString("N")
                    sumPistosi = sumPistosi + d
                    MertitoisLbl.Text = "Μετρ."
                    MertitoisLbl.TextAlign = ContentAlignment.MiddleLeft
                    MertitoisLbl.Size = New Point(50, 20)
                    MertitoisLbl.Location = New Point(locationX(4) + PistosLbl.Width, ypos)
                    MertitoisLbl.ForeColor = Color.Black
                    KinisiEmf3Pnl.Controls.Add(MertitoisLbl)
                End If


                KinisiEmf3Pnl.Controls.Add(AAlbl)
                KinisiEmf3Pnl.Controls.Add(EponimiaLbl)
                KinisiEmf3Pnl.Controls.Add(XrewsLbl)
                KinisiEmf3Pnl.Controls.Add(ParastLbl)
                KinisiEmf3Pnl.Controls.Add(PistosLbl)

            Next

            Me.EisprakseispraktoreiaTableAdapter.FillByImerominia(Me.DbhotelDataSet.eisprakseispraktoreia, EmfHmerKiniPraktPck.Value.Date)
            For k = 0 To Me.DbhotelDataSet.eisprakseispraktoreia.Count - 1
                Dim AAlbl, ParastLbl, EponimiaLbl, XrewsLbl, PistosLbl, MertitoisLbl As New Label
                Dim praktoreio As String
                aa = j + i + k + 1
                ypos = (j + i + k) * ystep + 5

                AAlbl.Text = aa
                AAlbl.TextAlign = ContentAlignment.MiddleCenter
                AAlbl.Size = New Point(40, 20)
                AAlbl.Location = New Point(locationX(0), ypos)
                AAlbl.BackColor = Color.Azure
                AAlbl.ForeColor = Color.Black

                praktoreio = Me.PraktoreiaTableAdapter.GetEponimiaByKwd(Me.DbhotelDataSet.eisprakseispraktoreia(k).praktoreio)
                EponimiaLbl.Text = praktoreio
                EponimiaLbl.TextAlign = ContentAlignment.MiddleCenter
                EponimiaLbl.Size = New Point(220, 20)
                EponimiaLbl.Location = New Point(locationX(1), ypos)
                EponimiaLbl.BackColor = Color.Azure
                EponimiaLbl.ForeColor = Color.Black

                ParastLbl.Text = Me.DbhotelDataSet.eisprakseispraktoreia(k).parast1.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(k).parast2.ToString + " " + Me.DbhotelDataSet.eisprakseispraktoreia(k).parast3.ToString
                ParastLbl.TextAlign = ContentAlignment.MiddleCenter
                ParastLbl.Size = New Point(170, 20)
                ParastLbl.Location = New Point(locationX(2), ypos)
                ParastLbl.BackColor = Color.Azure
                ParastLbl.ForeColor = Color.Black


                XrewsLbl.TextAlign = ContentAlignment.MiddleRight
                XrewsLbl.Size = New Point(120, 20)
                XrewsLbl.Location = New Point(locationX(3), ypos)
                XrewsLbl.BackColor = Color.Azure
                XrewsLbl.ForeColor = Color.Black

                d = Me.DbhotelDataSet.eisprakseispraktoreia(k).eispraksi + Me.DbhotelDataSet.eisprakseispraktoreia(k).sunplin
                sumPistosi = sumPistosi + d
                PistosLbl.TextAlign = ContentAlignment.MiddleRight
                PistosLbl.Size = New Point(120, 20)
                PistosLbl.Location = New Point(locationX(4), ypos)
                PistosLbl.BackColor = Color.Azure
                PistosLbl.ForeColor = Color.Black
                PistosLbl.Text = d.ToString("N")




                KinisiEmf3Pnl.Controls.Add(AAlbl)
                KinisiEmf3Pnl.Controls.Add(EponimiaLbl)
                KinisiEmf3Pnl.Controls.Add(XrewsLbl)
                KinisiEmf3Pnl.Controls.Add(ParastLbl)
                KinisiEmf3Pnl.Controls.Add(PistosLbl)


            Next

            Dim SynolaLbl, SumXrewsiLbl, SumPistosiLbl As New Label
            SynolaLbl.Text = "Σύνολα:"
            SynolaLbl.TextAlign = ContentAlignment.MiddleRight
            SynolaLbl.Size = New Point(170, 20)
            SynolaLbl.Location = New Point(locationX(2), 5)
            'SynolaLbl.BackColor = Color.Azure
            SynolaLbl.ForeColor = Color.Blue

            SumXrewsiLbl.Text = sumXrewsi.ToString("N")
            SumXrewsiLbl.TextAlign = ContentAlignment.MiddleRight
            SumXrewsiLbl.Size = New Point(120, 20)
            SumXrewsiLbl.Location = New Point(locationX(3), 5)
            SumXrewsiLbl.BackColor = Color.Azure
            SumXrewsiLbl.ForeColor = Color.Maroon

            SumPistosiLbl.TextAlign = ContentAlignment.MiddleRight
            SumPistosiLbl.Size = New Point(120, 20)
            SumPistosiLbl.Location = New Point(locationX(4), 5)
            SumPistosiLbl.BackColor = Color.Azure
            SumPistosiLbl.ForeColor = Color.Maroon
            SumPistosiLbl.Text = sumPistosi.ToString("N")

            KinisiEmf4Pnl.Controls.Add(SynolaLbl)
            KinisiEmf4Pnl.Controls.Add(SumXrewsiLbl)
            KinisiEmf4Pnl.Controls.Add(SumPistosiLbl)

        Catch ex As System.Exception
            Me.Cursor = Cursors.Default
            System.Windows.Forms.MessageBox.Show(ex.Message)

        End Try
        Me.Cursor = Cursors.Default
      
    End Sub


    '**********************EISPRAKSEIS *************************EISPRAKSEIS *****EISPRAKSEIS *************EISPRAKSEIS *********EISPRAKSEIS **************

    'YPARXOUN 2 DB TABLES->XREWSEISPRAKTOREIA KAI EISPRAKSEISPRAKTOREIA...EDW MPOREI KANEIS EPILEGWNTAS XREWSH NA FORTWSEI TIMOLOGIO POU EXEI EKDOTHEI APO TO MENU EXTRA 
    'PARASTATIKA (DINONTAS PRAKT-IMEROM KAI EPILEGVNTAS APO LISTA(->DTGRD KYALIA)->SE PERIPTWSI POU ALAKSEI THN XREWSH TOTE TO TIMOLOGIO POU EXEI 
    'EKDOTHEI APO TA EXTRA PARAST MARKARETAI WS MAYRO(!) KAI DEN THA PAIZEI ROLO STHN KARTELA TOY PRAKTOREIOY ALLA ANSTELLE H KAINOYRGIA XREWSH!
    '(RUECKGAENGIG MPOREI NA GINEI EAN KSANAPAEI STA EXTRA, FORTWSEI TO MAYRO KAI APOTHIKEUSEI PALI->KSEMARKARETAI APO MAYRO KAI H XREWSI POU EIXE 
    'DHMIOURGITHEI STO TABLE XREWSEISPRAKT DIAGRAFETAI ORISTIKA->ARXIKH KATASTASH LOIPON!
    'GIA EISPRAKSEIS TA PRAGMATA EINAI APLA->INSERT NEA EISPRAKSI KAI FORTWSI APO KIALIA MIAS PALAISA DINONTAS HMEROMINIA-PRAKTOREIO!

    Private Sub eisprakseis_praktoreia()

        initialisieren_felder_variablen()
        EtiketaPraktPnl.Location = New Point(5, 5)
        EtiketaPraktPnl.Size = New Point(PraktZentralPnl.Width - 20, 60)
        EtiketaLbl.Text = "ΕΙΣΠΡΑΞΕΙΣ - ΧΡΕΩΣΕΙΣ ΠΡΑΚΤΟΡΕΙΩΝ"
        EtiketaLbl.Location = New Point(EtiketaPraktPnl.Width / 6, 15)
        EispraxeisKataxPnl.Location = New Point(2, EtiketaPraktPnl.Height)
        Me.EispraxeisKataxPnl.Size = New Point(830, PraktZentralPnl.Height)
        EispKataxParTrPlirCbx.Items.Clear()
        EispraxeisKatax3Pnl.Visible = False
        EispKataxParEispRdb.Checked = True
        EispraxeisKataxPck.Value = imeromErgasias
        EispraxeisKataxPck.MinDate = "1/1/" + etos.ToString
        EispraxeisKataxPck.MaxDate = "31/12/" + etos.ToString

        'AddHandler EispKataxParEisprTbx.KeyPress, AddressOf komma_einschalten
        'AddHandler EispKataxParSinPlinTbx.KeyPress, AddressOf komma_einschalten
      
        AddHandler EispKataxParEisprTbx.KeyPress, AddressOf komma_einschalten
        AddHandler EispKataxParSinPlinTbx.KeyPress, AddressOf komma_einschalten
        AddHandler EispKataxParXrewsiTbx.KeyPress, AddressOf komma_einschalten
        AddHandler EispKataxParProkTbx.KeyPress, AddressOf komma_einschalten

        EtiketaPraktPnl.Controls.Add(EtiketaLbl)
        Me.PraktZentralPnl.Controls.Add(EtiketaPraktPnl)
        PraktZentralPnl.Controls.Add(EispraxeisKataxPnl)
    End Sub

    Private Sub EispKataxParEispRdb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParEispRdb.CheckedChanged, EispKataxParXrewsRdb.CheckedChanged
        If sender.name.Equals("EispKataxParEispRdb") Then
            KwdPrktTbx.Clear()
            initialisieren_felder_variablen()
            init_tr_plirom_cbox()

            EispraxeisKatax2Pnl.Location = New Point(10, 205)
            EispraxeisKatax3Pnl.Visible = False
            EispraxeisKatax2Pnl.Visible = True
        Else
            KwdPrktTbx.Clear()
            initialisieren_felder_variablen()
            EispraxeisKatax3Pnl.Location = New Point(10, 205)
            EispraxeisKatax2Pnl.Visible = False
            EispraxeisKatax3Pnl.Visible = True
        End If
    End Sub
    Private Sub KwdPrakt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KwdPrktTbx.Leave
        Dim kwdikos As Integer
        Try

            If CType(sender.text, Integer) > 0 Then
                Dim count As Int16
                kwdikos = sender.text
                initialisieren_felder_variablen()
                count = Me.PraktoreiaTableAdapter.ExistPraktoreia(kwdikos)
                If count <> 0 Then
                    Me.PraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.praktoreia, kwdikos)
                Else
                    MsgBox("O κωδικός δεν αντιστοιχεί σε  Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")

                    sender.clear()
                    KwdPrktTbx.Clear()
                    'sender.focus()
                    Exit Sub
                End If
                If Me.DbhotelDataSet.praktoreia.Count = 1 Then
                    EispraxeisKataxPraktTbx.Text = Me.DbhotelDataSet.praktoreia(0).eponimia
                    kwdEisprPrakt = Me.DbhotelDataSet.praktoreia(0).kwd
                    sender.text = kwdikos
                Else
                    'EispraxeisKataxPraktTbx.Text = "< κλίκ εδώ πάνω >"
                    initialisieren_felder_variablen()
                    kwdEisprPrakt = -1
                End If

            End If
        Catch ex As InvalidCastException
            If Not kwdikos.Equals("") Then
                MsgBox(" Δώστε Αριθμό !", MsgBoxStyle.Information, "winfo\nikEl.")
                initialisieren_felder_variablen()
                'sender.clear()
                'EispraxeisKataxPraktTbx.Text = "< κλίκ εδώ πάνω >"
                'KwdPrktTbx.Clear()
                kwdEisprPrakt = -1
            End If

        End Try




    End Sub
    Private Sub EispraxeisKataxPraktTbx_enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispraxeisKataxPraktTbx.Click
        Dim PraktForm As New SimbolaiaFrm()
        Dim kwdikos As Integer
        initialisieren_felder_variablen()
        PraktForm.StartPosition = FormStartPosition.CenterParent
        PraktForm.ShowDialog()
        kwdikos = PraktForm.return_praktoreio_kwdikos

        If kwdikos = Nothing Then
            MsgBox("Δεν επιλέχθηκε Πρακτορείο !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            If kwdEisprPrakt = -1 Then
                EispraxeisKataxPraktTbx.Text = "< κλίκ εδώ πάνω >"
                KwdPrktTbx.Clear()
                Exit Sub
            End If
        Else
            kwdEisprPrakt = kwdikos
            KwdPrktTbx.Text = kwdikos
            EispraxeisKataxPraktTbx.Text = PraktForm.return_praktoreio
            KwdPrktTbx.Text = PraktForm.return_praktoreio_kwdikos
        End If
    End Sub

    Private Sub EispKataxParSucheBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParSucheBtn.Click
        If EispKataxParEispRdb.Checked Then
            If kwdEisprPrakt <> -1 Then
                Dim form1 As New Eisprakseis(kwdEisprPrakt, EispraxeisKataxPck.Value.Date)
                form1.ShowDialog()
                kwdEispr = form1.return_kwd_eispraksis()
                If kwdEispr = Nothing Then
                    kwdEispr = -1
                End If
                form1.Dispose()
                fuelle_felder_eispraksis()
            End If
        Else
            If kwdEisprPrakt <> -1 Then
                Dim form1 As New XrewseisPrakt(kwdEisprPrakt, EispraxeisKataxPck.Value.Date)

                form1.ShowDialog()
                kwdEispTimol = form1.return_kwd_timolog
                If kwdEispTimol = Nothing Then
                    kwdEispTimol = -1
                End If
                kwdEispXrews = form1.return_kwd_xrewsisprakt
                If kwdEispXrews = Nothing Then
                    kwdEispXrews = -1
                End If
                form1.Dispose()
                fuelle_felder_xrewsis()
            End If
        End If
    End Sub
    Private Sub fuelle_felder_eispraksis()
        If kwdEispr <> -1 Then
            Me.EisprakseispraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.eisprakseispraktoreia, kwdEispr)
            EispKataxPar1Tbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).parast1
            EispKataxPar2Tbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).parast2
            EispKataxPar3Tbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).parast3
            EispraxeisKataxAitTbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).aitiologia
            EispKataxParEisprTbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).eispraksi.ToString("N")
            EispKataxParSinPlinTbx.Text = Me.DbhotelDataSet.eisprakseispraktoreia(0).sunplin.ToString("N")
        End If
    End Sub
    Private Sub fuelle_felder_xrewsis()
        If kwdEispTimol <> -1 Then
            Me.TimologiaTableAdapter.FillTimologioByKwdikoAkyr(Me.DbhotelDataSet.timologia, kwdEispTimol, False)
            EispKataxPar1Tbx.Text = Me.DbhotelDataSet.timologia(0).seira
            EispKataxPar2Tbx.Text = Me.DbhotelDataSet.timologia(0).parastatiko
            EispKataxPar3Tbx.Text = Me.DbhotelDataSet.timologia(0).aa
            EispraxeisKataxAitTbx.Text = Me.DbhotelDataSet.timologia(0).aitiologia
            EispKataxParXrewsiTbx.Text = Me.DbhotelDataSet.timologia(0).synola.ToString("N")
            EispKataxParProkTbx.Text = Me.DbhotelDataSet.timologia(0).prokataboli.ToString("N")
        ElseIf kwdEispXrews <> -1 Then
            Me.XrewseispraktoreiaTableAdapter.FillByKwdiko(Me.DbhotelDataSet.xrewseispraktoreia, kwdEispXrews)
            EispKataxPar1Tbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).parast1
            EispKataxPar2Tbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).parast2
            EispKataxPar3Tbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).parast3
            EispraxeisKataxAitTbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).aitiologia
            EispKataxParXrewsiTbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).xrewsi.ToString("N")
            EispKataxParProkTbx.Text = Me.DbhotelDataSet.xrewseispraktoreia(0).prokataboli.ToString("N")
            If Me.DbhotelDataSet.xrewseispraktoreia(0).metritois Then
                EispKataxParTrPlirCbx.SelectedIndex = 0
            Else
                EispKataxParTrPlirCbx.SelectedIndex = 1
            End If
        End If
    End Sub
    Private Sub EispKataxParTrPlirCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParTrPlirCbx.SelectedIndexChanged

    End Sub

    Private Sub EispKataxParKataxBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParKataxBtn.Click
        Dim metritoisOK As Boolean
        If EispKataxParEispRdb.Checked Then
            If kwdEisprPrakt <> -1 AndAlso CType(EispKataxParEisprTbx.Text, Single) <> 0 Then
                If kwdEispr = -1 Then 'kainouria eispraksi
                    Me.EisprakseispraktoreiaTableAdapter.InsertEispraksiPrakt(EispKataxPar1Tbx.Text, EispKataxPar2Tbx.Text, EispKataxPar3Tbx.Text, EispraxeisKataxPck.Value.Date, _
                                            kwdEisprPrakt, EispraxeisKataxAitTbx.Text, EispKataxParEisprTbx.Text, EispKataxParSinPlinTbx.Text)

                Else
                    Me.EisprakseispraktoreiaTableAdapter.UpdateEispraksi(EispKataxPar1Tbx.Text, EispKataxPar2Tbx.Text, EispKataxPar3Tbx.Text, EispraxeisKataxPck.Value.Date, _
                                            kwdEisprPrakt, EispraxeisKataxAitTbx.Text, EispKataxParEisprTbx.Text, EispKataxParSinPlinTbx.Text, kwdEispr)
                End If
                MsgBox("Η Είσπραξη καταχωρήθηκε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
                initialisieren_felder_variablen()
            End If
        Else
            If kwdEisprPrakt <> -1 Then 'AndAlso CType(EispKataxParXrewsiTbx.Text, Single) <> 0 
                If EispKataxParTrPlirCbx.SelectedIndex = 0 Then
                    metritoisOK = True
                Else
                    metritoisOK = False
                End If
                If (kwdEispTimol <> -1 OrElse kwdEispXrews = -1) AndAlso CType(EispKataxParXrewsiTbx.Text, Single) <> 0 Then
                    'kainouria xrewsi stin thesi tis timologiakis xrewsis (apo ta extra parastatika)
                    Try
                        Me.XrewseispraktoreiaTableAdapter.InsertXrewsiPrakt(EispKataxPar1Tbx.Text, EispKataxPar2Tbx.Text, EispKataxPar3Tbx.Text, kwdEispTimol, kwdEisprPrakt, _
                                                          EispraxeisKataxAitTbx.Text, EispKataxParXrewsiTbx.Text, EispKataxParProkTbx.Text, metritoisOK, EispraxeisKataxPck.Value.Date)
                        If kwdEispTimol <> -1 Then
                            Me.TimologiaTableAdapter.SetMauroByKwd(True, kwdEispTimol)
                        End If
                        MsgBox("Η Χρέωση καταχωρήθηκε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
                    Catch ex As Exception
                        MsgBox("Παρουσιάστηκε σφάλμα κατά την εκτέλεση αυτής της ενέργειας !", MsgBoxStyle.Critical, "winfo\nikEl.")
                    End Try
                    initialisieren_felder_variablen()
                    'to timologio einai twra Mayro->metraei gia to praktoreio i kainoyria xrewsi sto DB Table Xrewsiprakt...
                ElseIf kwdEispXrews <> -1 Then
                    If CType(EispKataxParXrewsiTbx.Text, Single) <> 0 Then
                        Me.XrewseispraktoreiaTableAdapter.UpdateXrewsiPraktoreiou(EispKataxPar1Tbx.Text, EispKataxPar2Tbx.Text, EispKataxPar3Tbx.Text, EispraxeisKataxAitTbx.Text, EispKataxParXrewsiTbx.Text, EispKataxParProkTbx.Text, metritoisOK, kwdEispXrews)
                    ElseIf CType(EispKataxParXrewsiTbx.Text, Single) = 0 Then
                        Me.XrewseispraktoreiaTableAdapter.DeleteByKwd(kwdEispXrews)

                    End If
                    MsgBox("Η Χρέωση καταχωρήθηκε επιτυχώς !", MsgBoxStyle.Information, "winfo\nikEl.")
                    initialisieren_felder_variablen()
                End If
            End If
        End If
    End Sub
    Private Sub EispKataxPar3Tbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxPar3Tbx.Leave
        Dim i As Integer
        Try
            i = CType(sender.text, Integer)
        Catch ex As InvalidCastException
            sender.text = 0
        End Try

    End Sub
    Private Sub posa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParEisprTbx.Leave, EispKataxParSinPlinTbx.Leave, EispKataxParXrewsiTbx.Leave, EispKataxParProkTbx.Leave
        Dim d As Single = 0

        Try
            d = CType(sender.text, Single)
            sender.text = d.ToString("N")
        Catch ex As Exception
            sender.text = d.ToString("N")
        End Try

    End Sub
    Private Sub initialisieren_felder_variablen()
        EispKataxParTrPlirCbx.SelectedIndex = -1

        clear_eispraks_panel()
        clear_panel_1()
        init_eispr_felder()
        init_global_var()
    End Sub
    Private Sub init_eispr_felder()
        Dim d As Single = 0
        EispKataxPar3Tbx.Text = d
        EispKataxParEisprTbx.Text = d.ToString("N")
        EispKataxParSinPlinTbx.Text = d.ToString("N")
        EispKataxParXrewsiTbx.Text = d.ToString("N")
        EispKataxParProkTbx.Text = d.ToString("N")
        EispraxeisKataxPraktTbx.Text = "< κλίκ εδώ πάνω >"
        KwdPrktTbx.Clear()
    End Sub
    Private Sub clear_eispraks_panel()
        EispKataxParEisprTbx.Clear()
        EispKataxParSinPlinTbx.Clear()
    End Sub
    Private Sub clear_panel_1()
        EispraxeisKataxPraktTbx.Clear()
        EispKataxPar1Tbx.Clear()
        EispKataxPar2Tbx.Clear()
        EispKataxPar3Tbx.Clear()
        EispraxeisKataxAitTbx.Clear()

    End Sub
    Private Sub init_global_var()
        kwdEisprPrakt = -1
        kwdEispTimol = -1
        kwdEispXrews = -1
        kwdEispr = -1
    End Sub
    Private Sub clear_xrews_panel()

        EispKataxParXrewsiTbx.Clear()
        EispKataxParProkTbx.Clear()
        EispKataxParTrPlirCbx.SelectedIndex = -1
        EispKataxParTrPlirCbx.Items.Clear()
        init_tr_plirom_cbox()
    End Sub
    Private Sub init_tr_plirom_cbox()
        EispKataxParTrPlirCbx.Items.Clear()
        EispKataxParTrPlirCbx.Items.Add("Μετρητοίς")
        EispKataxParTrPlirCbx.Items.Add("Επί Πιστώση")


    End Sub
    Private Sub EispKataxParClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParClearBtn.Click
        initialisieren_felder_variablen()
    End Sub


    Private Sub EisprakseispraktoreiaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.EisprakseispraktoreiaBindingSource.EndEdit()
        Me.EisprakseispraktoreiaTableAdapter.Update(Me.DbhotelDataSet.eisprakseispraktoreia)

    End Sub
    Private Sub EispKataxParEisprTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EispKataxParXrewsiTbx.Click, EispKataxParEisprTbx.Click, EispKataxParSinPlinTbx.Click, EispKataxParProkTbx.Click
        sender.selectall()
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
    'Private Sub KinLogarPrakt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.metaforaypoloipwn' table. You can move, or remove it, as needed.
    '    'Me.MetaforaypoloipwnTableAdapter.Fill(Me.DbhotelDataSet.metaforaypoloipwn)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreiameparastatika' table. You can move, or remove it, as needed.
    '    'Me.PraktoreiameparastatikaTableAdapter.Fill(Me.DbhotelDataSet.praktoreiameparastatika)
    '    ''TODO: This line of code loads data into the 'DbhotelDataSet.praktoreiameeisprakseis' table. You can move, or remove it, as needed.
    '    'Me.PraktoreiameeisprakseisTableAdapter.Fill(Me.DbhotelDataSet.praktoreiameeisprakseis)
    '    ''TODO: This line of code loads data into the 'DbhotelDataSet.praktoreiametimologia' table. You can move, or remove it, as needed.
    '    ''Me.PraktoreiametimologiaTableAdapter.Fill(Me.DbhotelDataSet.praktoreiametimologia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.parastatika' table. You can move, or remove it, as needed.
    '    'Me.ParastatikaTableAdapter.FilApyPistotiko(Me.DbhotelDataSet.parastatika)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.simbolaia' table. You can move, or remove it, as needed.
    '    'Me.SimbolaiaTableAdapter.Fill(Me.DbhotelDataSet.simbolaia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
    '    Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.praktoreia' table. You can move, or remove it, as needed.

    '    'TODO: This line of code loads data into the 'DbhotelDataSet.xrewseispraktoreia' table. You can move, or remove it, as needed.
    '    'Me.XrewseispraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.xrewseispraktoreia)
    '    ''TODO: This line of code loads data into the 'DbhotelDataSet.timologia' table. You can move, or remove it, as needed.
    '    'Me.TimologiaTableAdapter.Fill(Me.DbhotelDataSet.timologia)
    '    ''TODO: This line of code loads data into the 'DbhotelDataSet.eisprakseispraktoreia' table. You can move, or remove it, as needed.
    '    'Me.EisprakseispraktoreiaTableAdapter.Fill(Me.DbhotelDataSet.eisprakseispraktoreia)

    'End Sub


    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim j As Int16
    '    Dim kwd As Integer
    '    Dim onoma As String
    '    Dim xrewsi As Single
    '    Dim date1 As Date = "1/1/2007"
    '    onoma = "k"
    '    For j = 0 To 10
    '        xrewsi = 50 + j * 10
    '        onoma = onoma + "w"
    '        Me.PraktoreiaTableAdapter.InsertPraktoreia(onoma, 100)
    '        kwd = Me.PraktoreiaTableAdapter.GetKwdByEponimia(onoma)
    '        Me.XrewseispraktoreiaTableAdapter.InsertXrewsiPrakt(Nothing, Nothing, 0, -1, kwd, Nothing, xrewsi, 0, False, date1.AddDays(j * 10))

    '    Next

    'End Sub
    Private Function ist_pistotiko(ByVal kwdikos As Integer) As Boolean
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.pistwtikaparast.Count - 1
            If Me.DbhotelDataSet.pistwtikaparast(j).parastatiko = kwdikos Then
                Return True
            End If
        Next
        Return False

    End Function
    Private Function ist_grammatio(ByVal kwdikos As Integer) As Boolean
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.parastgrammeispr.Count - 1
            If Me.DbhotelDataSet.parastgrammeispr(j).grammatioeispraksis = kwdikos Then
                Return True
            End If
        Next
        Return False

    End Function
    Public Sub New(ByVal imerominia As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        imeromErgasias = imerominia
        etos = imeromErgasias.Year
        Dim pistparastAdapter As New dbhotelDataSetTableAdapters.pistwtikaparastTableAdapter
        pistparastAdapter.Fill(Me.DbhotelDataSet.pistwtikaparast)
        Dim grammAdapter As New dbhotelDataSetTableAdapters.parastgrammeisprTableAdapter
        grammAdapter.Fill(Me.DbhotelDataSet.parastgrammeispr)
        Dim parastAdapter As New dbhotelDataSetTableAdapters.parastatikaTableAdapter
        parastAdapter.Fill(Me.DbhotelDataSet.parastatika)
        'Me.ParastatikaTableAdapter.FillOlaplingrammatioBygramm(Me.DbhotelDataSet.parastatika, 3)
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        imeromErgasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Praktoreia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Finalize()
        Me.Dispose()
    End Sub
End Class