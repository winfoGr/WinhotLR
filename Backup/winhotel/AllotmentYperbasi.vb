Public Class AllotmentYperbasi
    Dim currentsimbolaio, currentklines, currenttipos As Integer
    Dim afixi, anaxwrisi As Date
    Dim guarant As Boolean
    Dim imeresCount As Int16
    Dim allotmDay(), kratDay(), YperbDay() As Int16


   
    Public Sub New(ByVal afixiDate As Date, ByVal anaxwrisiDate As Date, ByVal klines As Integer, ByVal tipos As Integer, ByVal simbolaio As Integer, ByVal guaranti As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        afixi = afixiDate
        anaxwrisi = anaxwrisiDate
        imeresCount = anaxwrisi.DayOfYear - afixi.DayOfYear + 1
        currentsimbolaio = simbolaio
        currentklines = klines
        currenttipos = tipos
        guarant = guaranti
        ReDim allotmDay(imeresCount - 1)
        ReDim kratDay(imeresCount - 1)
        ReDim YperbDay(imeresCount - 1)
        lade_allotment_kratiseis()
    End Sub
    Public Sub zeig_yperbasi_form()
        Dim j, pos As Int16

        For j = 0 To imeresCount - 1

            Dim yperbLbl As New Label
            yperbLbl.ForeColor = Color.Blue
            yperbLbl.Size = New Point(40, 25)
            'If kratDay(j) > allotmDay(j) Then
            '    yperbLbl.Text = kratDay(j) - allotmDay(j)
            'Else
            '    yperbLbl.Text = 0
            'End If
            yperbLbl.Text = YperbDay(j)
            yperbLbl.Location = New Point((pos + 1) * yperbLbl.Width, 5)
            YperbasiPnl.Controls.Add(yperbLbl)

            pos = pos + 1
        Next
    End Sub
    Public Function ist_yeprabasi() As Boolean
        Dim j As Int16
        For j = 0 To YperbDay.Length - 1
            If YperbDay(j) > 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub lade_allotment_kratiseis()
        Dim allotFoundOK As Boolean = False

        If currentklines <= 0 And currenttipos <= 0 Then 'arxika elgxos ob (0,0) ola me ola->o user paei na kanei kratisi xwris na dialeksei tipo,klines

            'ola ta Allotment pou einai MEGALYTERA(->anzahl) tou 0
            'ean yaprxei allotment (0,0) tote den yparxei allo allotment (x,y) me x,y >=0 ! => to (0,0) allotment praktisch isxuei gia oles tis
            'katigories (x,y)=> psaxnw kratiseis sinolika
            'labe ipopsi oti ayti h Klasse wird aufgerugen otan to allotment YPARXEI kai mono tote (ean feripin yparxei ena allotment (x,y) kai 
            'o user stiws kratiseis den epileksei klines, tipos (ARA (0,0)) tote den mporei na ginei aufgerufen auti i Klasse
            Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, guarant, afixi, afixi, 0, 0, _
                                               currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, 0, 0, _
                                                 currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, 0, 0)

            Me.KratiseisTableAdapter.FillKratInZeitIntervalBySimbGuarImer(Me.DbhotelDataSet.kratiseis, currentsimbolaio, guarant, afixi, afixi, _
              currentsimbolaio, guarant, anaxwrisi.AddDays(-1), anaxwrisi.AddDays(-1), currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1))
            If Me.DbhotelDataSet.allotment.Count <> 0 AndAlso Me.DbhotelDataSet.kratiseis.Count > 0 Then
                setze_werte_pro_tag()

            End If

        Else 'o user paei na kanei kratisi exwntas dialeksei tipo,klines
            If currenttipos > 0 AndAlso currentklines > 0 Then 'elegxos ob (x,y)
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, guarant, afixi, afixi, currentklines, currenttipos, _
                                              currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, currentklines, currenttipos, _
                                                currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, currentklines, currenttipos)

                Me.KratiseisTableAdapter.FillKratZeitIntervalBySimbGuarImeromKlTip(Me.DbhotelDataSet.kratiseis, currentsimbolaio, guarant, afixi, afixi, currentklines, currenttipos, _
                                                              currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, currentklines, currenttipos, _
                                                                currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, currentklines, currenttipos)

                If Me.DbhotelDataSet.allotment.Count <> 0 Then
                    allotFoundOK = True
                    If Me.DbhotelDataSet.kratiseis.Count > 0 Then
                        setze_werte_pro_tag()
                    End If

                End If

            End If
            ' ean den yparxei (x,y) tote elegxos gia (0,y) kai (x,0)
            If Not allotFoundOK AndAlso currentklines > 0 Then
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, guarant, afixi, afixi, currentklines, 0, _
                                              currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, currentklines, 0, _
                                                currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, currentklines, 0)

                Me.KratiseisTableAdapter.FillKratInZeitintervalBySimbGuarImeromKlines(Me.DbhotelDataSet.kratiseis, currentsimbolaio, guarant, afixi, afixi, currentklines, _
                                                             currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, currentklines, _
                                                               currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, currentklines)
                If Me.DbhotelDataSet.allotment.Count <> 0 Then
                    allotFoundOK = True
                    If Me.DbhotelDataSet.kratiseis.Count > 0 Then
                        setze_werte_pro_tag()
                    End If

                End If
            End If
            If Not allotFoundOK AndAlso currenttipos > 0 Then 'kai (x,0)
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, guarant, afixi, afixi, 0, currenttipos, _
                                              currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, 0, currenttipos, _
                                                currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, 0, currenttipos)

                Me.KratiseisTableAdapter.FillKratZeitIntervalBySimbGuarImeromTipos(Me.DbhotelDataSet.kratiseis, currentsimbolaio, guarant, afixi, afixi, currenttipos, _
                                                              currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, currenttipos, _
                                                                currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, currenttipos)
                If Me.DbhotelDataSet.allotment.Count <> 0 Then
                    allotFoundOK = True
                    If Me.DbhotelDataSet.kratiseis.Count > 0 Then
                        setze_werte_pro_tag()
                    End If

                End If
            End If
            If Not allotFoundOK Then 'edw telikos elegxos gia(0,0)-.Yparxei periptosi an iparxei allotment (0,0)->o user kanei kratisi gia (x,y) (->mporei giati
                'to (0,0)perilambanei ola ta epimerous (x,y)=> edw elegxos ean iparxei (0,0) allotment kai schliesslich abruf oles tis kratiseis aneksartita klines,tipos 
                Me.AllotmentTableAdapter.FillAllotmBySimbGuarKlinesTiposApoMexri(Me.DbhotelDataSet.allotment, currentsimbolaio, guarant, afixi, afixi, 0, 0, _
                                                            currentsimbolaio, guarant, anaxwrisi.AddDays(-1).Date, anaxwrisi.AddDays(-1).Date, 0, 0, _
                                                              currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1).Date, 0, 0)


                Me.KratiseisTableAdapter.FillKratInZeitIntervalBySimbGuarImer(Me.DbhotelDataSet.kratiseis, currentsimbolaio, guarant, afixi, afixi, _
                            currentsimbolaio, guarant, anaxwrisi.AddDays(-1), anaxwrisi.AddDays(-1), currentsimbolaio, guarant, afixi, anaxwrisi.AddDays(-1))

                If Me.DbhotelDataSet.allotment.Count <> 0 AndAlso Me.DbhotelDataSet.kratiseis.Count > 0 Then
                    setze_werte_pro_tag()
                End If

            End If
        End If


    End Sub
    Private Sub setze_werte_pro_tag()
        Dim j As Int16


        For j = 0 To imeresCount - 1

            allotmDay(j) = setze_anzahl_von_allotment_am_tag(j)
            kratDay(j) = kratDay(j) + setze_anzahl_von_kratiseis_am_tag(j)

            If (kratDay(j) + 1) > allotmDay(j) Then 'TO KRAT +1 TOKANA GIATI O USER PREPEI NA DEI PRIN THN APOTHIKEUSI OTI ME THN
                'KRATISI POU PAEI NA KANEI DHMIOURGITAI YPERBASI
                YperbDay(j) = (kratDay(j) + 1) - allotmDay(j)
            Else
                YperbDay(j) = 0
            End If

        Next


    End Sub
    Private Function setze_anzahl_von_allotment_am_tag(ByVal indTag As Int16) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.allotment.Count - 1

            If Me.DbhotelDataSet.allotment(j).apo <= afixi.AddDays(indTag) And Me.DbhotelDataSet.allotment(j).mexri >= afixi.AddDays(indTag) Then
                Return Me.DbhotelDataSet.allotment(j).anzahl
            End If
        Next
        Return 0

    End Function
    Private Function setze_anzahl_von_kratiseis_am_tag(ByVal indTag As Int16) As Int16
        Dim j, count As Int16

        count = 0
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1

            If Me.DbhotelDataSet.kratiseis(j).afixi <= afixi.AddDays(indTag) And Me.DbhotelDataSet.kratiseis(j).anaxwrisi > afixi.AddDays(indTag) Then
                count = count + 1
            End If
        Next
        Return count

    End Function
    Private Sub escape(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress

        Select Case e.KeyChar

            Case ChrW(27)
                Me.Close()
                Me.Finalize()
        End Select


    End Sub
    'Private Sub zeig_allotment_iperbasi()
    '    Dim j, k, pos As Int16
    '    Dim imeresCount As Int16
    '    Dim arDwm As String
    '    Dim count As Integer



    '    imeresCount = anaxwrisi.DayOfYear - afixi.DayOfYear 'afixi.DayOfYear

    '    pos = 0
    '    For j = 0 To imeresCount - 1
    '        If Not chkInOk Then
    '            Dim dwmLbl As New Label
    '            dwmLbl.ForeColor = Color.Blue
    '            dwmLbl.Size = New Point(50, 30)
    '            dwmLbl.Text = Me.DbhotelDataSet.status(0).dwmatio
    '            dwmLbl.Location = New Point((pos + 1) * dwmLbl.Width, 5)
    '            DwmatiaKratPnl.Controls.Add(dwmLbl)
    '        Else
    '            arDwm = get_dwm_at_day(afixi.Date.AddDays(j + k))

    '            If arDwm Is Nothing Then
    '                count = Me.OverTableAdapter.ExistOverByKratsisi(kwdKratisis)
    '                If count <> 0 Then
    '                    arDwm = "Ov-Book"
    '                End If
    '            End If
    '            Dim dwmLbl As New Label
    '            dwmLbl.ForeColor = Color.Blue
    '            dwmLbl.Size = New Point(50, 30)
    '            dwmLbl.Text = arDwm
    '            dwmLbl.Location = New Point((pos + 1) * dwmLbl.Width, 5)
    '            DwmatiaKratPnl.Controls.Add(dwmLbl)
    '        End If
    '        pos = pos + 1
    '    Next
    'End Sub
    'Private Function get_dwm_at_day(ByVal datum As Date) As String
    '    Dim j As Int16

    '    For j = 0 To Me.DbhotelDataSet.status.Count - 1
    '        If Me.DbhotelDataSet.status(j).enarxi <= datum And Me.DbhotelDataSet.status(j).lixi >= datum Then
    '            Return Me.DbhotelDataSet.status(j).dwmatio
    '        End If
    '    Next
    '    Return Nothing

    'End Function

    'Private Sub copy()
    '    If currentklines <> 0 Or currenttipos <> 0 Then
    '        Try
    '            anzahl = Me.AllotmentTableAdapter.AnzahlBySimbKlinesTiposGuarImerom(currentsimbolaio, currentklines, currenttipos, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date)

    '        Catch ex As InvalidOperationException
    '            anzahl = 0
    '        End Try
    '        If anzahl = 0 Then 'oles oi klines??
    '            Try
    '                anzahl = Me.AllotmentTableAdapter.AnzahlBySimbTiposGuarImerom(currentsimbolaio, currenttipos, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date)
    '            Catch ex As InvalidOperationException
    '                anzahl = 0
    '            End Try
    '        End If
    '        If anzahl = 0 Then 'oloi oi tipoi??'HIERRRRRRRRRRRRR=5
    '            Try
    '                anzahl = Me.AllotmentTableAdapter.AnzahlBySimbKlinesGuarImerom(currentsimbolaio, currentklines, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date)
    '            Catch ex As InvalidOperationException
    '                anzahl = 0
    '            End Try
    '        End If
    '        If anzahl = 0 Then 'oles klines oloi oi tipoi
    '            Try
    '                anzahl = Me.AllotmentTableAdapter.AnzahlBySimbGuarImerom(currentsimbolaio, CheckBox1.Checked, DateTimePicker2.Value.Date, DateTimePicker3.Value.Date)
    '            Catch ex As InvalidOperationException
    '                anzahl = 0
    '            End Try
    '        End If

    '        If anzahl = 0 Then
    '            response = MsgBox("Δεν υπάρχει Allotment για την επιλεγμένη κατηγορία! Συνέχεια;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '            If response = MsgBoxResult.Yes Then
    '                'Kratiseis4Pnl.Controls.Clear()
    '                'ButtonsPnl.Controls.Clear()
    '                If Not isDBEintrag Then
    '                    male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, -1, True) 'male timokatalogo gia kathe Season!
    '                Else
    '                    male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True)
    '                End If
    '            Else
    '                Exit Sub
    '            End If
    '        Else
    '            'MsgBox("3" + Me.DbhotelDataSet.timeskratisis.Count.ToString)
    '            'Kratiseis4Pnl.Controls.Clear()
    '            'ButtonsPnl.Controls.Clear()
    '            If Not isDBEintrag Then
    '                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, -1, True)
    '            Else
    '                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True)
    '            End If

    '        End If
    '    ElseIf currentklines = 0 And currenttipos = 0 Then
    '        'MsgBox("4" + Me.DbhotelDataSet.timeskratisis.Count.ToString)
    '        Me.AllotmentTableAdapter.AllotmKatigoriesBySimbolaio(Me.DbhotelDataSet.allotment, currentsimbolaio)
    '        If Me.DbhotelDataSet.allotment.Count = 0 Then
    '            response = MsgBox("Δεν υπάρχει Allotment για καμία κατηγορία! Συνέχεια;", MsgBoxStyle.YesNo, "winfo\nikEl.")
    '            If response = MsgBoxResult.Yes Then
    '                'Kratiseis4Pnl.Controls.Clear()
    '                'ButtonsPnl.Controls.Clear()
    '                If Not isDBEintrag Then
    '                    male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, -1, True) 'male timokatalogo gia kathe Season!
    '                Else
    '                    male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True)
    '                End If
    '            Else
    '                Exit Sub
    '            End If
    '        Else
    '            'MsgBox("5" + Me.DbhotelDataSet.timeskratisis.Count.ToString)
    '            'Kratiseis4Pnl.Controls.Clear()
    '            'ButtonsPnl.Controls.Clear()
    '            If Not isDBEintrag Then
    '                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, -1, True) 'male timokatalogo gia kathe Season!
    '            Else
    '                male_timokatalogous_pnl(Me.DbhotelDataSet.touristperiodoi.Count, Me.DbhotelDataSet.kratiseis(0).arithmos, True)
    '            End If
    '        End If
    '    End If
    'End Sub





    'Private Sub AllotmentYperbasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'TODO: This line of code loads data into the 'DbhotelDataSet.kratiseis' table. You can move, or remove it, as needed.
    '    Me.KratiseisTableAdapter.Fill(Me.DbhotelDataSet.kratiseis)

    'End Sub

    
    Private Sub AllotmentYperbasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    
    
End Class