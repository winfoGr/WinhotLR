Imports System.Data.SqlClient
Public Class PlirotitaDwmFrm
    Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim imeromErgasias As Date
    Dim etos As Int16
    Dim connectionString As String
    Dim dwmatia() As String
    Dim zeigerDwm1, zeigerDwm2 As Int16 ' Zeiger sto dwmatia() gia na bgazei kathe fora mia dekada
    Dim klinesKwd, tiposKwd As Int32
    Private Sub plirotita_dwmatiwn()
        zeigerDwm1 = -1
        zeigerDwm2 = -1

        Dim numDays As Integer = DateTime.DaysInMonth(Now.Year, imeromErgasias.Date.Month)

        PlirDwmPlithImerTbx.Text = numDays.ToString
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
        ImeromPlirotDwm.Value = imeromErgasias


        '  Me.DwmPlirotitaPnl.Size = New Point(1500, ZentralPnl.Height)

        Me.ZentralPnl.Controls.Add(DwmPlirotitaPnl)
        'Me.Diamenontes2Pnl.Size = New Point(Diamenontes1Pnl.Width, 2 * Diamenontes1Pnl.Height)
        'ProepDiamBtn.Location = New Point(DiamenBtn.Location.X, Diamenontes2Pnl.Location.Y + Diamenontes2Pnl.Height + 20)


    End Sub
    Private Sub ImeromPlirotDwm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImeromPlirotDwm.ValueChanged

        zeigerDwm1 = -1
        zeigerDwm2 = -1
        Me.ProgressBar1.Value = 0
        'EktStatusDwmBtn.Enabled = False
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
    End Sub

    Private Sub ImeromPlirotDwm_ValueLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImeromPlirotDwm.Leave
        Dim numDays As Integer = DateTime.DaysInMonth(Now.Year, ImeromPlirotDwm.Value.Date.Month)
        'MsgBox(numDays)
        PlirDwmPlithImerTbx.Text = numDays.ToString
    End Sub


    Private Sub DwmPlirotBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmPlirotBtn.Click
        'Dim count As Single
        BtnsPnl.Enabled = True
        If zeigerDwm1 = -1 And zeigerDwm2 = -1 Then
            fuele_alle_zimmer()
            'PlirDwmPlithImerTbx
            'PlirDwmEwsTbx
            'count = dwmatia.Length / 10
            If dwmatia.Length - 1 <= 22 Then
                zeigerDwm1 = 0
                zeigerDwm2 = dwmatia.Length - 1
                zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
            Else
                zeigerDwm1 = 0
                zeigerDwm2 = 21
                zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
            End If
            'EktStatusDwmBtn.Enabled = True
        End If

    End Sub
    Private Sub sortkatichk_CheckedChanged(sender As Object, e As EventArgs) Handles sortkatichk.CheckedChanged
        zeigerDwm1 = -1
        zeigerDwm2 = -1
        Me.ProgressBar1.Value = 0
        'EktStatusDwmBtn.Enabled = False
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
    End Sub
    Private Sub zeig_plirotita_dwmatiwn(ByVal arxiIm As Date, ByVal telosIm As Date, ByVal index1 As Int16, ByVal index2 As Int16)
        Dim i, j As Int16
        Dim tageCount As Integer
        'Dim dateCount As Date
        Dim locx, locy, stepx As Int16
        'If zeigerDwm1 = -1 And zeigerDwm2 = -1 Then
        'End If
        locx = 40
        locy = 32

        stepx = 33
        If RadioButton3.Checked Then
            Me.TimokatDiathesTableAdapter.FillTimokForDiathesByPraktPerigraEtos(Me.DbhotelDataSet1.TimokatDiathes, 39, arxiIm.Year, "Nnet")
        ElseIf RadioButton2.Checked Then
            Me.TimokatDiathesTableAdapter.FillTimokForDiathesByPraktPerigraEtos(Me.DbhotelDataSet1.TimokatDiathes, 1, arxiIm.Year, "Nwebsite")
        Else
            Me.TimokatDiathesTableAdapter.FillTimokForDiathesByPraktPerigraEtos(Me.DbhotelDataSet1.TimokatDiathes, 2, arxiIm.Year, "Nbooking")
        End If

        'dateCount = arxiIm
        If index1 <> -1 Then
            'DOMISI kratiseis gia confirmation
            '     Me.KratiseisTableAdapter.FillKratforConfirmByEtosApoMexrChkin(Me.DbhotelDataSet.kratiseis, etos, arxiIm, telosIm, False)
            '     MsgBox(Me.DbhotelDataSet.kratiseis.Count)
            '   tageCount = telosIm.DayOfYear - arxiIm.DayOfYear
            tageCount = telosIm.Subtract(arxiIm).Days()
            'Me.DbhotelDataSet.ekt_imeres_status_dwm.Clear()
            'Me.DbhotelDataSet.ekt_imeres_status_dwm.Rows.Add()
            For i = 0 To tageCount
                Dim ImeroLbl As New Label
                ImeroLbl.TextAlign = ContentAlignment.MiddleCenter
                ImeroLbl.Size = New Point(35, 35)

                Me.DwmPlirot2Pnl.Controls.Add(ImeroLbl)
                ImeroLbl.Location = New Point(locx + (i - 1) * stepx, locy - stepx) '(locx + (i - 1) * stepx, locy)
                ImeroLbl.Text = arxiIm.Date.AddDays(i).DayOfWeek.ToString.Substring(0, 2) + ChrW(13) + arxiIm.Date.AddDays(i).Day.ToString
                ImeroLbl.ForeColor = Color.Black
                'Me.DbhotelDataSet.ekt_imeres_status_dwm(0).Item(i) = arxiIm.Date.AddDays(i).Day.ToString
            Next


            'Me.DbhotelDataSet.ekt_status_dwm.Rows.Clear()
            For j = index1 To index2
                Dim MinasLbl As New Label
                MinasLbl.TextAlign = ContentAlignment.MiddleCenter
                MinasLbl.Size = New Point(70, 30)
                Me.DwmPlirot3Pnl.Controls.Add(MinasLbl)
                MinasLbl.Location = New Point(1, locy) 'New Point(locx + (i - 1) * stepx, locy
                MinasLbl.Text = dwmatia(j)
                'Me.DbhotelDataSet.ekt_status_dwm.Rows.Add()
                'Me.DbhotelDataSet.ekt_status_dwm(j - index1).dwmatio = dwmatia(j)
                locy = locy + stepx

                MinasLbl.ForeColor = Color.Blue
            Next

            locx = 40
            locy = 30
            'Me.ProgressBar1.Value += 10
            'Using connection As New OleDb.OleDbConnection(connectionString)
            '    Dim command As New OleDb.OleDbCommand()
            '    Dim myReader As OleDb.OleDbDataReader
            '    connection.Open()
            '    command.Connection = connection

            '    For j = index1 To index2

            '        Dim imeresStat() As Integer
            '        Dim kwdKrat() As Integer
            '        Dim timesIndiv() As Single
            '        ReDim imeresStat(tageCount)
            '        ReDim timesIndiv(tageCount)
            '        ReDim kwdKrat(tageCount)
            '        init_status_dwmatiou(imeresStat)
            '        init_times_individual(timesIndiv)
            '        init_kwd_krat(kwdKrat)

            '        command.Parameters.AddWithValue("dwmatio", dwmatia(j))
            '        command.Parameters.AddWithValue("enarxi", arxiIm)
            '        command.Parameters.AddWithValue("lixi", arxiIm)
            '        command.Parameters.AddWithValue("dwmatio", dwmatia(j))
            '        command.Parameters.AddWithValue("enarxi", telosIm)
            '        command.Parameters.AddWithValue("lixi", telosIm)
            '        command.Parameters.AddWithValue("dwmatio", dwmatia(j))
            '        command.Parameters.AddWithValue("enarxi", arxiIm)
            '        command.Parameters.AddWithValue("lixi", telosIm)
            '        command.CommandText = "SELECT DISTINCT kwd, dwmatio, kratisi, enarxi, lixi, dwmatiostatus FROM status WHERE (dwmatio=?) AND (enarxi<=?) AND (lixi>=?) OR (dwmatio=? ) AND (enarxi<=?) AND (lixi>=?) OR (dwmatio=?) AND (enarxi>?) AND (lixi<?)"
            '        myReader = command.ExecuteReader()
            '        ' PROSOXi ALAKSA Noembrios 2018 !!! giat;i den doyleue to systhma gia kratiseis Xristougennwn  pou patousan se 2 eti
            '        While myReader.Read()
            '            'kalutera diktes apo pou mexri pou sto imeresStat
            '            Dim zeiger1, zeiger2 As Integer
            '            ' zeiger1 = arxiIm.DayOfYear - myReader.GetDateTime(3).DayOfYear
            '            zeiger1 = arxiIm.Subtract(myReader.GetDateTime(3)).Days()
            '            If myReader.GetDateTime(3) < arxiIm Then
            '                zeiger1 = 0
            '            ElseIf myReader.GetDateTime(3) >= arxiIm And myReader.GetDateTime(3) <= telosIm Then
            '                '  zeiger1 = myReader.GetDateTime(3).DayOfYear - arxiIm.DayOfYear
            '                zeiger1 = myReader.GetDateTime(3).Subtract(arxiIm).Days()
            '            Else
            '                zeiger1 = -1
            '            End If

            '            If myReader.GetDateTime(4) >= telosIm Then
            '                zeiger2 = imeresStat.Length - 1
            '            ElseIf myReader.GetDateTime(4) >= arxiIm And myReader.GetDateTime(4) < telosIm Then
            '                ' zeiger2 = myReader.GetDateTime(4).DayOfYear - arxiIm.DayOfYear
            '                zeiger2 = myReader.GetDateTime(4).Subtract(arxiIm).Days()
            '            Else
            '                zeiger2 = -1
            '            End If
            '            If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            '                'DOMISI -> allagh gia na blepw not Confirmed Kratiseis
            '                setze_status(zeiger1, zeiger2, myReader.GetInt32(5), imeresStat, myReader.GetInt32(2), kwdKrat)
            '            End If

            '        End While
            '        myReader.Close()
            '        command.Parameters.Clear()

            '        For i = 0 To imeresStat.Length - 1
            '            Dim ImeroWertLbl As New Label
            '            ImeroWertLbl.Name = kwdKrat(i).ToString
            '            ImeroWertLbl.TextAlign = ContentAlignment.MiddleCenter

            '            ImeroWertLbl.Size = New Point(30, 30)
            '            '   AddHandler ImeroWertLbl.MouseClick, AddressOf info_plano_zeigen
            '            ImeroWertLbl.BackColor = Color.Azure
            '            '(locx + (i - 1) * stepx, locy)
            '            If imeresStat(i) <> -1 Then
            '                If imeresStat(i) = 1 Or imeresStat(i) = 21 Then
            '                    If ist_heat_pisina(kwdKrat(i).ToString) Then
            '                        ImeroWertLbl.ForeColor = Color.SkyBlue
            '                    Else
            '                        ImeroWertLbl.ForeColor = Color.Blue
            '                    End If

            '                ElseIf imeresStat(i) = 5 Then
            '                    ImeroWertLbl.ForeColor = Color.Maroon


            '                ElseIf imeresStat(i) = 3 Then
            '                    ImeroWertLbl.ForeColor = Color.Red
            '                ElseIf imeresStat(i) = 8 Then
            '                    ImeroWertLbl.ForeColor = Color.Black
            '                End If
            '                'ImeroWertLbl.Text = Me.DwmatiastatusTableAdapter.GetStatusByKwd(imeresStat(i))
            '                ImeroWertLbl.Text = get_preis_kratisis(kwdKrat(i))
            '            Else
            '                ImeroWertLbl.ForeColor = Color.Green
            '                'ImeroWertLbl.Text = "V"
            '                ImeroWertLbl.Text = get_preis_keno(dwmatia(j), arxiIm, telosIm, i)
            '            End If
            '            ImeroWertLbl.Location = New Point(locx + (i - 1) * stepx, locy) '(locx + (i - 1) * stepx, locy - stepx)
            '            'ImeroWertLbl.ForeColor = Color.Maroon
            '            Me.DwmPlirot2Pnl.Controls.Add(ImeroWertLbl)

            '        Next
            '        locy = locy + stepx
            '        Try
            '            Me.ProgressBar1.Value += 10
            '        Catch ex As ArgumentOutOfRangeException
            '            Me.ProgressBar1.Value = 0
            '        End Try

            '    Next
            'End Using
            Using connection As New SqlConnection(connectionString)
                Dim command As New SqlCommand()
                Dim reader As SqlDataReader

                connection.Open()
                command.Connection = connection

                For j = index1 To index2
                    Dim imeresStat() As Integer
                    Dim kwdKrat() As Integer
                    Dim timesIndiv() As Single

                    ReDim imeresStat(tageCount)
                    ReDim timesIndiv(tageCount)
                    ReDim kwdKrat(tageCount)

                    init_status_dwmatiou(imeresStat)
                    init_times_individual(timesIndiv)
                    init_kwd_krat(kwdKrat)

                    command.Parameters.AddWithValue("@dwmatio1", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi1", arxiIm)
                    command.Parameters.AddWithValue("@lixi1", arxiIm)
                    command.Parameters.AddWithValue("@dwmatio2", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi2", telosIm)
                    command.Parameters.AddWithValue("@lixi2", telosIm)
                    command.Parameters.AddWithValue("@dwmatio3", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi3", arxiIm)
                    command.Parameters.AddWithValue("@lixi3", telosIm)

                    command.CommandText = "SELECT DISTINCT kwd, dwmatio, kratisi, enarxi, lixi, dwmatiostatus FROM status WHERE (dwmatio=@dwmatio1) AND (enarxi<=@enarxi1) AND (lixi>=@lixi1) OR (dwmatio=@dwmatio2) AND (enarxi<=@enarxi2) AND (lixi>=@lixi2) OR (dwmatio=@dwmatio3) AND (enarxi>@enarxi3) AND (lixi<@lixi3)"

                    reader = command.ExecuteReader()

                    While reader.Read()
                        Dim zeiger1, zeiger2 As Integer
                        zeiger1 = arxiIm.Subtract(reader.GetDateTime(3)).Days()

                        If reader.GetDateTime(3) < arxiIm Then
                            zeiger1 = 0
                        ElseIf reader.GetDateTime(3) >= arxiIm And reader.GetDateTime(3) <= telosIm Then
                            zeiger1 = reader.GetDateTime(3).Subtract(arxiIm).Days()
                        Else
                            zeiger1 = -1
                        End If

                        If reader.GetDateTime(4) >= telosIm Then
                            zeiger2 = imeresStat.Length - 1
                        ElseIf reader.GetDateTime(4) >= arxiIm And reader.GetDateTime(4) < telosIm Then
                            zeiger2 = reader.GetDateTime(4).Subtract(arxiIm).Days()
                        Else
                            zeiger2 = -1
                        End If

                        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
                            setze_status(zeiger1, zeiger2, reader.GetInt32(5), imeresStat, reader.GetInt32(2), kwdKrat)
                        End If
                    End While

                    reader.Close()
                    command.Parameters.Clear()

                    For i = 0 To imeresStat.Length - 1
                        Dim ImeroWertLbl As New Label
                        ImeroWertLbl.Name = kwdKrat(i).ToString()
                        ImeroWertLbl.TextAlign = ContentAlignment.MiddleCenter
                        ImeroWertLbl.Size = New Point(30, 30)
                        ImeroWertLbl.BackColor = Color.Azure

                        If imeresStat(i) <> -1 Then
                            If imeresStat(i) = 1 Or imeresStat(i) = 21 Then
                                If ist_heat_pisina(kwdKrat(i).ToString()) Then
                                    ImeroWertLbl.ForeColor = Color.SkyBlue
                                Else
                                    ImeroWertLbl.ForeColor = Color.Blue
                                End If
                            ElseIf imeresStat(i) = 5 Then
                                ImeroWertLbl.ForeColor = Color.Maroon
                            ElseIf imeresStat(i) = 3 Then
                                ImeroWertLbl.ForeColor = Color.Red
                            ElseIf imeresStat(i) = 8 Then
                                ImeroWertLbl.ForeColor = Color.Black
                            End If

                            If kwdKrat(i) <> -1 Then
                                ImeroWertLbl.Text = get_preis_kratisis(kwdKrat(i))
                            Else
                                ImeroWertLbl.Text = "0"
                            End If
                        Else
                            ImeroWertLbl.ForeColor = Color.Green
                            ImeroWertLbl.Text = get_preis_keno(dwmatia(j), arxiIm, telosIm, i)
                        End If

                        ImeroWertLbl.Location = New Point(locx + (i - 1) * stepx, locy)
                        Me.DwmPlirot2Pnl.Controls.Add(ImeroWertLbl)
                    Next

                    locy = locy + stepx

                    Try
                        Me.ProgressBar1.Value += 10
                    Catch ex As ArgumentOutOfRangeException
                        Me.ProgressBar1.Value = 0
                    End Try
                Next
            End Using
            'Me.DwmPlirot2Pnl.Controls.Add(DwmPlirot3Pnl)
            Me.ProgressBar1.Value = 0
        End If
    End Sub
    'Private Function get_preis_kratisis(ByVal kwdikos As Int32) As String
    '    Dim price As Single
    '    Dim afixi, anaxwrisi As Date
    '    Using connection As New OleDb.OleDbConnection(connectionString)
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim myReader As OleDb.OleDbDataReader
    '        connection.Open()
    '        command.Connection = connection
    '        command.Parameters.AddWithValue("kwd", kwdikos)
    '        command.CommandText = "SELECT  kratiseis.synolo,kratiseis.afixi,kratiseis.anaxwrisi FROM kratiseis WHERE (kwd=?)"

    '        myReader = command.ExecuteReader()
    '        myReader.Read()

    '        price = myReader.GetFloat(0)
    '        afixi = myReader.GetDateTime(1)
    '        anaxwrisi = myReader.GetDateTime(2)
    '        price = Math.Round(price / DateDiff(DateInterval.Day, afixi, anaxwrisi), 0)
    '        ' always call Close when done reading.
    '        myReader.Close()
    '        Return price
    '    End Using

    'End Function
    Private Function get_preis_kratisis(ByVal kwdikos As Integer) As String
        Dim price As Single
        Dim afixi, anaxwrisi As Date

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim reader As SqlDataReader

            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("@kwd", kwdikos)
            command.CommandText = "SELECT kratiseis.synolo, kratiseis.afixi, kratiseis.anaxwrisi FROM kratiseis WHERE (kwd=@kwd)"

            reader = command.ExecuteReader()
            reader.Read()

            price = reader.GetFloat(0)
            afixi = reader.GetDateTime(1)
            anaxwrisi = reader.GetDateTime(2)
            price = Math.Round(price / DateDiff(DateInterval.Day, afixi, anaxwrisi), 0)

            ' Always call Close when done reading.
            reader.Close()

            Return price.ToString()
        End Using
    End Function


    Private Function get_preis_keno(ByVal dwmatio As String, ByVal arxiIm As Date, ByVal telosIm As Date, ByVal i As Int16) As String
        Dim price As Single
        Dim drarray() As DataRow
        Dim filterExp As String
        Dim j As Int16
        '   MsgBox(Me.DbhotelDataSet1.TimokatDiathes.Count)
        If dwmatio.Equals("ALE") OrElse dwmatio.Equals("MIC") OrElse dwmatio.Equals("EEAN") OrElse dwmatio.Equals("BLUE") Then
            filterExp = "arithmos ='" + dwmatio + "' AND aa= " + "'2'" + " AND apo <= '" + arxiIm.AddDays(i) + "' AND mexri >= '" + arxiIm.AddDays(i) + "'"
        ElseIf dwmatio.Equals("MAIL") OrElse dwmatio.Equals("UB1Y") Then
            filterExp = "arithmos ='" + dwmatio + "' AND aa= " + "'3'" + " AND apo <= '" + arxiIm.AddDays(i) + "' AND mexri >= '" + arxiIm.AddDays(i) + "'"
        ElseIf dwmatio.Equals("UB3C") OrElse dwmatio.Equals("UB4C") Then
            filterExp = "arithmos ='" + dwmatio + "' AND aa= " + "'4'" + " AND apo <= '" + arxiIm.AddDays(i) + "' AND mexri >= '" + arxiIm.AddDays(i) + "'"
        Else

            filterExp = "arithmos ='" + dwmatio + "' AND aa= " + "'1'" + " AND apo <= '" + arxiIm.AddDays(i) + "' AND mexri >= '" + arxiIm.AddDays(i) + "'"
        End If

        ' filterExp = "arithmos='" + dwmatio.ToString + "'"
        drarray = Me.DbhotelDataSet1.TimokatDiathes.Select(filterExp)

        For j = 0 To drarray.Length - 1
            price = drarray(j)("synolo")
            Return price.ToString
        Next
        Return "-"

    End Function
    Private Function ist_heat_pisina(ByVal kratisi As String) As Boolean
        Dim i As Int16
        Dim drarray() As DataRow
        Dim filterExp As String

        filterExp = "kwd= " + kratisi
        drarray = Me.DbhotelDataSet.kratiseis.Select(filterExp)

        For i = 0 To drarray.Length - 1

            If drarray(i)("allagesdwmatiwn") = True Then
                Return True
            End If
        Next

        Return False
    End Function
    'Private Sub info_plano_zeigen(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim kwdikos As Integer
    '    Dim onoma As String
    '    Try
    '        kwdikos = CType(sender.name, Integer)
    '    Catch ex As InvalidCastException
    '        Exit Sub
    '    End Try

    '    Me.AfixeisAnaxwriseis2TableAdapter.FillBykwdikokratisis(Me.DbhotelDataSet.AfixeisAnaxwriseis2, kwdikos)
    '    If kwdikos <> -1 AndAlso Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count <> 0 Then

    '        If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).Item("onomateponimo")) Then
    '            onoma = Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).onomateponimo
    '        Else
    '            onoma = ""
    '        End If
    '        MsgBox("Αρ.Κρατ.: " + Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).arithmos.ToString + ChrW(13) + "Πρακτορ.: " + Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).eponimia + ChrW(13) + _
    '                "Ονομα. : " + onoma + ChrW(13) + "Αφιξη : " + Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).afixi + ChrW(13) + "Αναχώριση : " + Me.DbhotelDataSet.AfixeisAnaxwriseis2(0).anaxwrisi)
    '    End If
    'End Sub
    'DOMISI
    Private Sub setze_status(ByVal zeiger1 As Integer, ByVal zeiger2 As Integer, ByVal dwmStatus As Integer, ByRef imeresStat() As Integer, ByVal kwdikoskrat As Integer, ByRef kwdkrat() As Integer)
        Dim i As Integer

        For i = zeiger1 To zeiger2
            If imeresStat(i) = -1 Then

                'DOMISI
                If dwmStatus = 1 Then
                    If ist_kratisi_not_confirmed(kwdikoskrat) Then
                        imeresStat(i) = 21
                    Else
                        imeresStat(i) = dwmStatus
                    End If
                Else
                    imeresStat(i) = dwmStatus
                End If

                'End If

            Else
                Select Case dwmStatus
                    'Case 1
                    '    If imeresStat(i) = -1 Then
                    '        If ist_kratisi_not_confirmed(kwdkrat) Then
                    '            imeresStat(i) = 21
                    '        Else
                    '            imeresStat(i) = 1
                    '        End If
                    '    End If

                    Case 1
                        If imeresStat(i) = 1 Then
                            imeresStat(i) = 3
                        End If
                    Case 8
                        If imeresStat(i) = -1 OrElse imeresStat(i) = 1 Then
                            imeresStat(i) = 8 'n.S kwd=8
                        End If
                    Case 5
                        If imeresStat(i) = -1 OrElse imeresStat(i) = 1 OrElse imeresStat(i) = 8 Then
                            'MsgBox("KASDLFSLFD")
                            imeresStat(i) = 5 'S kwd=5
                        ElseIf imeresStat(i) = 5 Then
                            imeresStat(i) = 3 'D doppelStay
                        End If
                End Select

            End If
            kwdkrat(i) = kwdikoskrat
        Next

    End Sub
    Private Function ist_kratisi_not_confirmed(ByVal kratisi As Integer) As Boolean
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.kratiseis.Count - 1
            If Me.DbhotelDataSet.kratiseis(j).kwd = kratisi Then
                If Me.DbhotelDataSet.kratiseis(0).prokataboli = 0 Then
                    If imeromErgasias.DayOfYear - Me.DbhotelDataSet.kratiseis(0).imeromkratisis.DayOfYear >= 0 AndAlso (imeromErgasias.DayOfYear - Me.DbhotelDataSet.kratiseis(0).imeromkratisis.DayOfYear) >= Me.DbhotelDataSet.etaireia(0).timolkwd Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            End If
        Next
        Return False
    End Function
    Private Sub setze_status_praktoreio(ByVal zeiger1 As Integer, ByVal zeiger2 As Integer, ByVal dwmStatus As Integer, ByRef imeresStat() As Integer, ByRef imeresPrakt() As Integer, ByVal kratisi As Integer)
        Dim i As Integer


        For i = zeiger1 To zeiger2
            If imeresStat(i) = -1 Then
                imeresStat(i) = dwmStatus
                If dwmStatus = 1 Or dwmStatus = 8 Or dwmStatus = 5 Or dwmStatus = 3 Then
                    imeresPrakt(i) = kratisi 'Me.KratiseisTableAdapter.GetPraktkwdByKwd(kratisi)
                End If

            Else
                Select Case dwmStatus
                    'Case 1
                    '    If imeresStat(i) = -1 Then
                    '        imeresStat(i) = 1 'reservation kwd=1
                    '    End If
                    Case 8
                        If imeresStat(i) = -1 OrElse imeresStat(i) = 1 Then
                            imeresStat(i) = 8 'n.S kwd=8
                            imeresPrakt(i) = kratisi 'Me.KratiseisTableAdapter.GetPraktkwdByKwd(kratisi)
                        End If
                    Case 5
                        If imeresStat(i) = -1 OrElse imeresStat(i) = 1 OrElse imeresStat(i) = 8 Then
                            'MsgBox("KASDLFSLFD")
                            imeresStat(i) = 5 'S kwd=5
                            imeresPrakt(i) = kratisi 'Me.KratiseisTableAdapter.GetPraktkwdByKwd(kratisi)
                        ElseIf imeresStat(i) = 5 Then
                            imeresStat(i) = 3 'D doppelStay
                            imeresPrakt(i) = kratisi 'Me.KratiseisTableAdapter.GetPraktkwdByKwd(kratisi)
                        End If
                End Select

            End If
        Next

    End Sub
    Private Sub init_status_dwmatiou(ByRef imeresStat() As Integer)
        Dim j As Int16

        For j = 0 To imeresStat.Length - 1
            imeresStat(j) = -1
        Next
    End Sub
    Private Sub init_times_individual(ByRef timesInd() As Single)
        Dim j As Int16

        For j = 0 To timesInd.Length - 1
            timesInd(j) = -1
        Next
    End Sub
    Private Sub init_kwd_krat(ByRef kwdkrat() As Integer)
        Dim j As Int16

        For j = 0 To kwdkrat.Length - 1
            kwdkrat(j) = -1
        Next
    End Sub
    Private Sub fuele_alle_zimmer()
        Dim i As Int16
        Dim zimmerApo, zimmerEws As String


        If PlirDwmApoTbx.Text.Equals("") Then
            zimmerApo = Me.DwmatiaTableAdapter.GetMinArDwmatiou()
        Else
            zimmerApo = PlirDwmApoTbx.Text
        End If
        If PlirDwmEwsTbx.Text.Equals("") Then
            zimmerEws = Me.DwmatiaTableAdapter.GetMaxArDwmatiou()
        Else
            zimmerEws = PlirDwmEwsTbx.Text
        End If
        If zimmerApo <= zimmerEws Then
            If sortkatichk.Checked Then
                Me.DwmatiaTableAdapter.DwmatiaApoEws1(Me.DbhotelDataSet.dwmatia, zimmerApo, zimmerEws)
            Else
                Me.DwmatiaTableAdapter.DwmatiaApoEws(Me.DbhotelDataSet.dwmatia, zimmerApo, zimmerEws)
            End If

        Else
            Me.DwmatiaTableAdapter.FillOhneOvBook(Me.DbhotelDataSet.dwmatia)
        End If

        ''pROSOXI-> ICH GEHE DAVON AUS DASS DAS mAX zIMMMER EINAI TO OVER-BOOK TO OPOIO DEN XREIAZETAI NA BGEI -> ARA DEN PAIRNW TO TELEYTAIO !!->EINAI SORTIERT KATA ARITHMO (sTRING!-> 102<2 !!!!)
        'For i = 0 To Me.DbhotelDataSet.dwmatia.Count - 1
        '    ReDim Preserve dwmatia(i)

        '    dwmatia(i) = Me.DbhotelDataSet.dwmatia(i).arithmos
        'Next
        'ReDim dwmatia(25)
        'dwmatia(0) = "EEAN"
        'dwmatia(1) = "MAIL"
        'dwmatia(2) = "PERS"
        'dwmatia(3) = "THOI"
        'dwmatia(4) = "PUE"
        'dwmatia(5) = "IKR"
        ''dwm(5) = "ALE"
        ''dwm(6) = "MIC"
        'dwmatia(6) = "ARCH"
        'dwmatia(7) = "IRI"
        'dwmatia(8) = "AFR"
        'dwmatia(9) = "G2-2"
        '' dwm(11) = "SF6"
        'dwmatia(10) = "UB1Y"
        'dwmatia(11) = "UB3C"
        'dwmatia(12) = "UB4C"
        'dwmatia(13) = "BLUE"
        'dwmatia(14) = "GRY"
        'dwmatia(15) = "COC"
        'dwmatia(16) = "GRE"
        'dwmatia(17) = "SAN"
        'dwmatia(18) = "WHI"
        'dwmatia(19) = "MARU"
        'dwmatia(20) = "HRA"
        'dwmatia(21) = "ORA"
        'dwmatia(22) = "YELL"
        'dwmatia(23) = "MHILL"
        'dwmatia(24) = "THET"
        'dwmatia(25) = "OLDRE"
        'ReDim dwmatia(22)
        'dwmatia(0) = "EEAN"
        'dwmatia(1) = "MAIL"
        'dwmatia(2) = "PERS"
        'dwmatia(3) = "THOI"
        'dwmatia(4) = "IKR"
        'dwmatia(5) = "ALE"
        'dwmatia(6) = "MIC"
        'dwmatia(7) = "ARCH"
        'dwmatia(8) = "IRI"
        'dwmatia(9) = "AFR"
        'dwmatia(10) = "G2-2"
        'dwmatia(11) = "SF6"
        'dwmatia(12) = "UB1Y"
        'dwmatia(13) = "UB3C"
        'dwmatia(14) = "UB4C"
        'dwmatia(15) = "BLUE"
        'dwmatia(16) = "GRY"
        'dwmatia(17) = "COC"
        'dwmatia(18) = "GRE"
        'dwmatia(19) = "SAN"
        'dwmatia(20) = "WHI"
        'dwmatia(21) = "MARU"
        'dwmatia(22) = "HRA"
        Dim dwmatiaList As New List(Of String)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Execute the first command to populate dwmatiaList
            Dim command As New SqlCommand("SELECT villa FROM planovilles ORDER BY displayorder", connection)
            Dim reader As SqlDataReader = command.ExecuteReader()

            While reader.Read()
                dwmatiaList.Add(reader.GetString(0)) ' Assuming the villa names are stored as strings
            End While
            reader.Close()

            ' Execute the second command to append more values to dwmatiaList
            Dim command2 As New SqlCommand("SELECT arithmos FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria = katigories.kwd INNER JOIN tipoi ON katigories.tipos = tipoi.kwd WHERE tipoi.kwd = 11", connection)
            reader = command2.ExecuteReader()

            While reader.Read()
                dwmatiaList.Add(reader.GetString(0)) ' Assuming the arithmos values are stored as strings
            End While
            reader.Close()

            connection.Close()
        End Using


        ' Convert the List to an array if needed
        dwmatia = dwmatiaList.ToArray()
        'ReDim dwmatia(34)
        'dwmatia(0) = "EEAN"
        'dwmatia(1) = "MAIL"
        'dwmatia(2) = "PERS"
        'dwmatia(3) = "THOI"
        'dwmatia(4) = "PUE"
        'dwmatia(5) = "MAVI"
        'dwmatia(6) = "IKR"
        ''dwmatia(5) = "ALE"
        ''dwmatia(6) = "MIC"
        'dwmatia(7) = "ARCH"
        'dwmatia(8) = "IRI"
        'dwmatia(9) = "AFR"
        'dwmatia(10) = "IPER"
        '' dwmatia(11) = "SF6"
        'dwmatia(11) = "UB1Y"

        'dwmatia(12) = "UB1C" 'neo
        'dwmatia(13) = "UB2C" 'neo

        'dwmatia(14) = "UB3C"
        'dwmatia(15) = "UB4C"


        'dwmatia(16) = "UB1D" 'neo
        'dwmatia(17) = "UB3D" 'neo


        'dwmatia(18) = "BLUE"
        'dwmatia(19) = "GRY"

        'dwmatia(20) = "ORA"
        'dwmatia(21) = "YELL"

        'dwmatia(22) = "RED" 'neo


        'dwmatia(23) = "COC"
        'dwmatia(24) = "GRE"
        'dwmatia(25) = "SAN"
        'dwmatia(26) = "WHI"
        'dwmatia(27) = "MARU"
        ''dwmatia(20) = "HRA"


        ''dwmatia(23) = "MHILL" 'bgainei!
        'dwmatia(28) = "THET"
        'dwmatia(29) = "OLDRE"

        'dwmatia(30) = "SKANT" 'neo
        'dwmatia(31) = "THEROS" 'neo
        'dwmatia(32) = "P1ATH" 'neo
        'dwmatia(33) = "P2ATH" 'neo
        'dwmatia(34) = "ORTH" 'neo
    End Sub
    Private Sub PlirDwmPlithImerTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlirDwmPlithImerTbx.Leave

        Try
            sender.text = Math.Abs(CType(sender.text, Int16))
            zeigerDwm1 = -1
            zeigerDwm2 = -1
            DwmPlirot2Pnl.Controls.Clear()
            DwmPlirot3Pnl.Controls.Clear()
            BtnsPnl.Enabled = False
        Catch ex As InvalidCastException
            MsgBox("Δώστε Αριθμό !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
            sender.text = "21"
        End Try

    End Sub
    Private Sub PlirDwmApoTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlirDwmApoTbx.TextChanged, PlirDwmEwsTbx.TextChanged
        zeigerDwm1 = -1
        zeigerDwm2 = -1
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
        BtnsPnl.Enabled = False
    End Sub
    Private Sub dwmatia_apo_ews_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlirDwmApoTbx.Leave, PlirDwmEwsTbx.Leave
        Dim count As Integer
        If Not sender.text.Equals("") Then
            count = Me.DwmatiaTableAdapter.ExistArDwmatiou(sender.text)

            If count = 0 Then
                MsgBox("Δεν υπάρχει Δωμάτιο μ'αυτόν τον Αριθμό !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                sender.clear()
            End If
        End If

    End Sub
    Private Sub PrDwmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrDwmBtn.Click
        Try
            If dwmatia.Length <> 0 Then
                If zeigerDwm1 <> 0 And zeigerDwm2 <> 0 Then
                    DwmPlirot2Pnl.Controls.Clear()
                    DwmPlirot3Pnl.Controls.Clear()
                End If
                If zeigerDwm1 - 21 >= 0 Then
                    zeigerDwm2 = zeigerDwm1
                    'meiwsw kata 9 ton prwto zeiger
                    zeigerDwm1 -= 21
                    zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
                Else
                    zeigerDwm1 = 0
                End If

            End If
        Catch ex As NullReferenceException

        End Try

    End Sub
    Private Sub EpomDwmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EpomDwmBtn.Click
        Try
            If zeigerDwm2 < dwmatia.Length - 1 Then
                DwmPlirot2Pnl.Controls.Clear()
                DwmPlirot3Pnl.Controls.Clear()
                zeigerDwm1 = zeigerDwm2

                If zeigerDwm2 + 21 < dwmatia.Length - 1 Then
                    zeigerDwm2 += 21
                Else

                    zeigerDwm2 = dwmatia.Length - 1
                End If
                zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
            End If
        Catch ex As NullReferenceException
        End Try

    End Sub
    Private Function get_status_by_kwd(ByVal kwdikos As Int32) As String
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.dwmatiastatus.Count - 1
            If Me.DbhotelDataSet.dwmatiastatus(j).kwd = kwdikos Then
                'MsgBox(Me.DbhotelDataSet.dwmatiastatus(j).status)
                Return Me.DbhotelDataSet.dwmatiastatus(j).status
            End If
        Next
        Return ""
    End Function

    Private Sub PlirotitaDwmFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.tipoi' table. You can move, or remove it, as needed.
        Me.TipoiTableAdapter.Fill(Me.DbhotelDataSet.tipoi)
        'TODO: This line of code loads data into the 'DbhotelDataSet.klines' table. You can move, or remove it, as needed.
        Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet.klines)
        'TODO: This line of code loads data into the 'DbhotelDataSet.katigories' table. You can move, or remove it, as needed.
        Me.KatigoriesTableAdapter.Fill(Me.DbhotelDataSet.katigories)
        ' init_klines_tipoi_cboxen_2()
        'TODO: This line of code loads data into the 'DbhotelDataSet.AfixeisAnaxwriseis2' table. You can move, or remove it, as needed.
        Me.AfixeisAnaxwriseis2TableAdapter.Fill(Me.DbhotelDataSet.AfixeisAnaxwriseis2)

    End Sub
    Public Sub New(ByVal conn As String, ByVal imerom As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.Text = "ΠΛΑΝΟ ΔΩΜΑΤΙΩΝ"
        connectionString = conn
        imeromErgasias = imerom
        ' Add any initialization after the InitializeComponent() call.
        Me.Controls.Add(ZentralPnl)
        Me.ZentralPnl.Controls.Clear()
        Me.ZentralPnl.BorderStyle = BorderStyle.Fixed3D
        Me.ZentralPnl.Dock = DockStyle.Fill
        plirotita_dwmatiwn()
        Me.DwmatiastatusTableAdapter.Fill(Me.DbhotelDataSet.dwmatiastatus)

    End Sub



    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        zeigerDwm1 = -1
        zeigerDwm2 = -1
        Me.ProgressBar1.Value = 0
        'EktStatusDwmBtn.Enabled = False
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        zeigerDwm1 = -1
        zeigerDwm2 = -1
        Me.ProgressBar1.Value = 0
        'EktStatusDwmBtn.Enabled = False
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
    End Sub
    Private Sub PlirotitaXenodFrm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = False

    End Sub
End Class
