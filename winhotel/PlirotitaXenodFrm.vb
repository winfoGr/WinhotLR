Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Data.SqlClient
Public Class PlirotitaXenodFrm
    Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim imeromErgasias As Date
    Dim connectionString As String
    Dim dwmatia() As String
    Dim zeigerDwm1, zeigerDwm2 As Int16 ' Zeiger sto dwmatia() gia na bgazei kathe fora mia dekada
    Dim kwdKratMetaf As Integer = 0
    Dim dwmProsMetaf As String = ""
    Dim klinesKwd, tiposKwd As Int32
    Dim KratiseisTableAdapter1 As New dbhotelDataSet1TableAdapters.kratiseisTableAdapter
    Private Sub plirotita_dwmatiwn()
        zeigerDwm1 = -1
        zeigerDwm2 = -1

        PlirDwmPlithImerTbx.Text = "31"
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
        ImeromPlirotDwm.Value = imeromErgasias

        'EtikLbl.Text = "ΠΛΗΡΟΤΗΤΑ ΔΩΜΑΤΙΩΝ"
        'EtikLbl.Location = New Point(EtiketaErgHmPnl.Width / 3, 25)
        'EtiketaErgHmPnl.Controls.Add(EtikLbl)
        'EtiketaErgHmPnl.Location = New Point(5, 5)
        'EtiketaErgHmPnl.Size = New Point(ZentralPnl.Width - 20, 60)
        'ZentralPnl.Controls.Add(EtiketaErgHmPnl)

        'LogariasmoiPnl.Controls.Add(LogarHeaderPnl)
        DwmPlirotitaPnl.Location = New Point(2, 2)

        'Me.DwmPlirotitaPnl.Size = New Point(830, ZentralPnl.Height + 1)
        Me.ZentralPnl.Controls.Add(DwmPlirotitaPnl)
        'Me.Diamenontes2Pnl.Size = New Point(Diamenontes1Pnl.Width, 2 * Diamenontes1Pnl.Height)
        'ProepDiamBtn.Location = New Point(DiamenBtn.Location.X, Diamenontes2Pnl.Location.Y + Diamenontes2Pnl.Height + 20)


    End Sub
 
    'Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    '    Me.TopMost = True
    'End Sub
    Private Sub ImeromPlirotDwm_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImeromPlirotDwm.ValueChanged

        zeigerDwm1 = -1
        zeigerDwm2 = -1
        Me.ProgressBar1.Value = 0
        EktStatusDwmBtn.Enabled = False
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
    End Sub

    Private Sub DwmPlirotBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DwmPlirotBtn.Click

        BtnsPnl.Enabled = True
        DwmPlirot2Pnl.Controls.Clear()
        DwmPlirot3Pnl.Controls.Clear()
        'If zeigerDwm1 = -1 And zeigerDwm2 = -1 Then
        fuele_alle_zimmer()

        If dwmatia.Length - 1 <= 9 Then
            zeigerDwm1 = 0
            zeigerDwm2 = dwmatia.Length - 1
            zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
        Else
            zeigerDwm1 = 0
            zeigerDwm2 = 9
            zeig_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), zeigerDwm1, zeigerDwm2)
        End If
        EktStatusDwmBtn.Enabled = True
        'End If

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
        'dateCount = arxiIm
        If index1 <> -1 Then
            'DOMISI kratiseis gia confirmation
            'Me.KratiseisTableAdapter.FillKratforConfirmByEtosApoMexrChkin(Me.DbhotelDataSet1.kratiseis, etos, arxiIm, telosIm, False)
            If telosIm.Year = arxiIm.Year Then
                tageCount = telosIm.DayOfYear - arxiIm.DayOfYear
            ElseIf (telosIm.Year - arxiIm.Year) = 1 Then
                Dim telos As Date
                telos = "31/12/" + arxiIm.Year.ToString

                tageCount = (telos.DayOfYear + telosIm.DayOfYear - arxiIm.DayOfYear)
            End If


            'Me.DbhotelDataSet1.ekt_imeres_status_dwm.Clear()
            'Me.DbhotelDataSet1.ekt_imeres_status_dwm.Rows.Add()
            For i = 0 To tageCount
                Dim ImeroLbl As New Label
                ImeroLbl.TextAlign = ContentAlignment.MiddleCenter
                ImeroLbl.Size = New Point(35, 35)

                Me.DwmPlirot2Pnl.Controls.Add(ImeroLbl)
                ImeroLbl.Location = New Point(locx + (i - 1) * stepx, locy - stepx) '(locx + (i - 1) * stepx, locy)
                ImeroLbl.Text = arxiIm.Date.AddDays(i).DayOfWeek.ToString.Substring(0, 2) + ChrW(13) + arxiIm.Date.AddDays(i).Day.ToString
                ImeroLbl.ForeColor = Color.Black
                'Me.DbhotelDataSet1.ekt_imeres_status_dwm(0).Item(i) = arxiIm.Date.AddDays(i).Day.ToString
            Next


            'Me.DbhotelDataSet1.ekt_status_dwm.Rows.Clear()
            For j = index1 To index2
                Dim MinasLbl As New Label
                MinasLbl.TextAlign = ContentAlignment.MiddleCenter
                MinasLbl.Size = New Point(70, 30)
                Me.DwmPlirot3Pnl.Controls.Add(MinasLbl)
                MinasLbl.Location = New Point(1, locy) 'New Point(locx + (i - 1) * stepx, locy
                MinasLbl.Text = dwmatia(j)
                'Me.DbhotelDataSet1.ekt_status_dwm.Rows.Add()
                'Me.DbhotelDataSet1.ekt_status_dwm(j - index1).dwmatio = dwmatia(j)
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
            '        ReDim imeresStat(tageCount)
            '        ReDim kwdKrat(tageCount)
            '        init_status_dwmatiou(imeresStat)
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
            '        While myReader.Read()
            '            'kalutera diktes apo pou mexri pou sto imeresStat
            '            Dim zeiger1, zeiger2 As Integer
            '            zeiger1 = arxiIm.DayOfYear - myReader.GetDateTime(3).DayOfYear
            '            If myReader.GetDateTime(3) < arxiIm Then
            '                zeiger1 = 0
            '            ElseIf myReader.GetDateTime(3) >= arxiIm And myReader.GetDateTime(3) <= telosIm Then
            '                zeiger1 = myReader.GetDateTime(3).DayOfYear - arxiIm.DayOfYear
            '            Else
            '                zeiger1 = -1
            '            End If

            '            If myReader.GetDateTime(4) >= telosIm Then
            '                zeiger2 = imeresStat.Length - 1
            '            ElseIf myReader.GetDateTime(4) >= arxiIm And myReader.GetDateTime(4) < telosIm Then
            '                zeiger2 = myReader.GetDateTime(4).DayOfYear - arxiIm.DayOfYear
            '            Else
            '                zeiger2 = -1
            '            End If
            '            If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
            '                'MsgBox(myReader.GetInt32(2))
            '                setze_status(zeiger1, zeiger2, myReader.GetInt32(5), imeresStat, myReader.GetInt32(2), kwdKrat) ', myReader.GetInt32(2)
            '            End If

            '        End While
            '        myReader.Close()
            '        command.Parameters.Clear()

            '        For i = 0 To imeresStat.Length - 1
            '            Dim ImeroWertLbl As New Label
            '            ImeroWertLbl.Name = kwdKrat(i).ToString
            '            ImeroWertLbl.TextAlign = ContentAlignment.MiddleCenter
            '            ImeroWertLbl.Size = New Point(30, 30)
            '            AddHandler ImeroWertLbl.MouseDoubleClick, AddressOf info_plano_zeigen

            '            '  AddHandler Control.MouseButtons.Right, AddressOf change_room
            '            ImeroWertLbl.BackColor = Color.Azure
            '            '(locx + (i - 1) * stepx, locy)
            '            If imeresStat(i) <> -1 Then
            '                If imeresStat(i) = 1 Or imeresStat(i) = 9 Then
            '                    ImeroWertLbl.ForeColor = Color.Blue
            '                ElseIf imeresStat(i) = 5 Then
            '                    ImeroWertLbl.ForeColor = Color.Maroon
            '                ElseIf imeresStat(i) = 3 Then
            '                    ImeroWertLbl.ForeColor = Color.Red
            '                ElseIf imeresStat(i) = 8 Then
            '                    ImeroWertLbl.ForeColor = Color.Black
            '                End If
            '                'ImeroWertLbl.Text = Me.DwmatiastatusTableAdapter.GetStatusByKwd(imeresStat(i))
            '                ImeroWertLbl.Text = get_status_by_kwd(imeresStat(i))
            '            Else
            '                ImeroWertLbl.ForeColor = Color.Green
            '                ImeroWertLbl.Text = "V"
            '                ImeroWertLbl.Name = "D" + dwmatia(j)
            '                'Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "F"
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
                Dim myReader As SqlDataReader
                connection.Open()
                command.Connection = connection

                For j = index1 To index2
                    Dim imeresStat() As Integer
                    Dim kwdKrat() As Integer
                    ReDim imeresStat(tageCount)
                    ReDim kwdKrat(tageCount)
                    init_status_dwmatiou(imeresStat)
                    init_kwd_krat(kwdKrat)
                    command.Parameters.AddWithValue("@dwmatio", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi", arxiIm)
                    command.Parameters.AddWithValue("@lixi", arxiIm)
                    command.Parameters.AddWithValue("@dwmatio2", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi2", telosIm)
                    command.Parameters.AddWithValue("@lixi2", telosIm)
                    command.Parameters.AddWithValue("@dwmatio3", dwmatia(j))
                    command.Parameters.AddWithValue("@enarxi3", arxiIm)
                    command.Parameters.AddWithValue("@lixi3", telosIm)
                    command.CommandText = "SELECT DISTINCT kwd, dwmatio, kratisi, enarxi, lixi, dwmatiostatus FROM status WHERE (dwmatio=@dwmatio AND enarxi<=@enarxi AND lixi>=@lixi) OR (dwmatio=@dwmatio2 AND enarxi<=@enarxi2 AND lixi>=@lixi2) OR (dwmatio=@dwmatio3 AND enarxi>@enarxi3 AND lixi<@lixi3)"
                    myReader = command.ExecuteReader()
                    While myReader.Read()
                        'kalutera diktes apo pou mexri pou sto imeresStat
                        Dim zeiger1, zeiger2 As Integer
                        zeiger1 = arxiIm.DayOfYear - myReader.GetDateTime(3).DayOfYear
                        If myReader.GetDateTime(3) < arxiIm Then
                            zeiger1 = 0
                        ElseIf myReader.GetDateTime(3) >= arxiIm And myReader.GetDateTime(3) <= telosIm Then
                            zeiger1 = myReader.GetDateTime(3).DayOfYear - arxiIm.DayOfYear
                        Else
                            zeiger1 = -1
                        End If

                        If myReader.GetDateTime(4) >= telosIm Then
                            zeiger2 = imeresStat.Length - 1
                        ElseIf myReader.GetDateTime(4) >= arxiIm And myReader.GetDateTime(4) < telosIm Then
                            zeiger2 = myReader.GetDateTime(4).DayOfYear - arxiIm.DayOfYear
                        Else
                            zeiger2 = -1
                        End If
                        If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
                            'MsgBox(myReader.GetInt32(2))
                            setze_status(zeiger1, zeiger2, myReader.GetInt32(5), imeresStat, myReader.GetInt32(2), kwdKrat) ', myReader.GetInt32(2)
                        End If
                    End While
                    myReader.Close()
                    command.Parameters.Clear()

                    ' Your existing code for adding labels
                    For i = 0 To imeresStat.Length - 1
                        Dim ImeroWertLbl As New Label
                        ImeroWertLbl.Name = kwdKrat(i).ToString
                        ImeroWertLbl.TextAlign = ContentAlignment.MiddleCenter
                        ImeroWertLbl.Size = New Point(30, 30)
                        AddHandler ImeroWertLbl.MouseDoubleClick, AddressOf info_plano_zeigen

                        '  AddHandler Control.MouseButtons.Right, AddressOf change_room
                        ImeroWertLbl.BackColor = Color.Azure
                        '(locx + (i - 1) * stepx, locy)
                        If imeresStat(i) <> -1 Then
                            If imeresStat(i) = 1 Or imeresStat(i) = 9 Then
                                ImeroWertLbl.ForeColor = Color.Blue
                            ElseIf imeresStat(i) = 5 Then
                                ImeroWertLbl.ForeColor = Color.Maroon
                            ElseIf imeresStat(i) = 3 Then
                                ImeroWertLbl.ForeColor = Color.Red
                            ElseIf imeresStat(i) = 8 Then
                                ImeroWertLbl.ForeColor = Color.Black
                            End If
                            'ImeroWertLbl.Text = Me.DwmatiastatusTableAdapter.GetStatusByKwd(imeresStat(i))
                            ImeroWertLbl.Text = get_status_by_kwd(imeresStat(i))
                        Else
                            ImeroWertLbl.ForeColor = Color.Green
                            ImeroWertLbl.Text = "V"
                            ImeroWertLbl.Name = "D" + dwmatia(j)
                            'Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "F"
                        End If
                        ImeroWertLbl.Location = New Point(locx + (i - 1) * stepx, locy) '(locx + (i - 1) * stepx, locy - stepx)
                        'ImeroWertLbl.ForeColor = Color.Maroon
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

            Me.ProgressBar1.Value = 0
        End If
        'Me.DwmPlirot2Pnl.Controls.Add(DwmPlirot3Pnl)

    End Sub
    Private Sub info_plano_zeigen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdikos As Integer = 0
        Dim dwmatio, onoma As String
        Dim response As MsgBoxResult
        Try
            dwmatio = ""
            kwdikos = CType(sender.name, Integer)

            '   kwdikos = CType(sender.name, Integer)
        Catch ex As InvalidCastException
            dwmatio = sender.name.Substring(1, sender.name.length - 1)
        End Try
        '     MsgBox(kwdikos)
        If kwdikos <> 0 Then
            Me.AfixeisAnaxwriseisTableAdapter.FillByKwdikoKratisis(Me.DbhotelDataSet1.AfixeisAnaxwriseis, kwdikos)
            If Me.DbhotelDataSet1.AfixeisAnaxwriseis.Count <> 0 Then 'kwdikos <> -1 AndAlso

                If Not IsDBNull(Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).Item("onomateponimo")) Then
                    onoma = Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).onomateponimo
                Else
                    onoma = ""
                End If
                response = MsgBox("Res.Nr.: " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).arithmos.ToString + ChrW(13) + "Agency: " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).eponimia + ChrW(13) + _
                        "Name : " + onoma + ChrW(13) + "Ενήλικες :" + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).enilikes.ToString + ChrW(13) + "Παιδιά :" + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).paidia.ToString + ChrW(13) + "Arrival : " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).afixi + ChrW(13) + "Departure : " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).anaxwrisi + ChrW(13) + _
                        "Change Room?", MsgBoxStyle.YesNo)
                If response = MsgBoxResult.Yes Then
                    kwdKratMetaf = kwdikos
                    dwmProsMetaf = Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).dwmatio

                Else
                    kwdKratMetaf = 0
                    dwmProsMetaf = ""
                End If

            End If
        Else
            If dwmatio <> "" Then
                If kwdKratMetaf <> 0 Then
                    response = MsgBox("Change from Room " + dwmProsMetaf + " to Room " + dwmatio, MsgBoxStyle.YesNoCancel)
                    If response = MsgBoxResult.Yes Then
                        If HAChk.Checked Then
                            If set_availabilities_all_status(dwmatio, dwmProsMetaf, kwdKratMetaf) AndAlso execute_allagi_dwmatiou(dwmatio) Then
                                DwmPlirotBtn_Click(sender, e)

                                kwdKratMetaf = 0
                                dwmProsMetaf = ""
                            Else
                                MsgBox(" Change Failed! (Propably HA error)", MsgBoxStyle.Critical, "winfo\nikEl.")
                            End If
                        Else
                            If execute_allagi_dwmatiou(dwmatio) Then
                                DwmPlirotBtn_Click(sender, e)

                                kwdKratMetaf = 0
                                dwmProsMetaf = ""
                                MsgBox(" Δεν έγινε ενημέρωση διαθεσιμότητας στην HA!", MsgBoxStyle.Information, "winfo\nikEl.")
                            Else
                                MsgBox(" Change Failed!", MsgBoxStyle.Critical, "winfo\nikEl.")
                            End If
                        End If
                       
                    End If
                End If
            End If


        End If


    End Sub
    Private Function execute_allagi_dwmatiou(ByVal seDwmatio As String) As Boolean
        Dim enarxi, lixi As Date

        Dim rowcount, rowaffected As Int16
        Dim kwdStatus, katigoria As Int32
        Dim foros As Single = 0
        rowcount = 0
        rowaffected = 0
        kwdStatus = 0
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim myReader As OleDb.OleDbDataReader
            Dim command As New OleDb.OleDbCommand()
            Dim transaction As OleDb.OleDbTransaction = Nothing
            Try
                connection.Open()
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction


                command.Parameters.Clear()
                command.Parameters.AddWithValue("kwd", kwdKratMetaf)
                command.Parameters.AddWithValue("dwmatiostatus", 1)
                command.CommandText = "SELECT status.kwd, status.enarxi, status.lixi, dwmatia.katigoria FROM status INNER JOIN dwmatia ON status.dwmatio=dwmatia.arithmos where (kratisi=?) and (dwmatiostatus=?)"
                myReader = command.ExecuteReader()
                While myReader.Read()
                    kwdStatus = CType(myReader.Item("kwd"), Int32)
                    enarxi = CType(myReader.Item("enarxi"), Date)
                    lixi = CType(myReader.Item("lixi"), Date)
                    katigoria = CType(myReader.Item("katigoria"), Int32)
                End While

                myReader.Close()

                command.Parameters.Clear()
                command.Parameters.AddWithValue("arithmos", seDwmatio)
                command.CommandText = "SELECT katigoria from dwmatia WHERE (arithmos=?)"
                myReader = command.ExecuteReader()

                myReader.Read()

                '   If katigoria = CType(myReader.Item("katigoria"), Int32) Then
                myReader.Close()

                If kwdStatus <> 0 Then
                    command.Parameters.Clear()
                    command.Parameters.AddWithValue("dwmatio", seDwmatio)
                    command.Parameters.AddWithValue("enarxi", enarxi)
                    command.Parameters.AddWithValue("lixi", enarxi)
                    command.Parameters.AddWithValue("dwmatio", seDwmatio)
                    command.Parameters.AddWithValue("enarxi", lixi)
                    command.Parameters.AddWithValue("lixi", lixi)
                    command.Parameters.AddWithValue("dwmatio", seDwmatio)
                    command.Parameters.AddWithValue("enarxi", enarxi)
                    command.Parameters.AddWithValue("lixi", lixi)
                    command.CommandText = "SELECT *  FROM status where (dwmatio=?) AND(enarxi <= ?) AND (lixi >= ?) OR " & _
                                            "(dwmatio=?) AND(enarxi <= ?) AND (lixi >= ?) OR " & _
                                            "(dwmatio=?) AND (enarxi > ?) AND (lixi < ?)"

                    myReader = command.ExecuteReader()
                    While myReader.Read

                        rowcount += 1

                    End While

                    myReader.Close()

                    If rowcount = 0 Then
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("dwmatio", seDwmatio)
                        command.Parameters.AddWithValue("kwd", kwdKratMetaf)
                        command.CommandText = "UPDATE kratiseis SET dwmatio=? WHERE (kwd=?)"
                        rowaffected = command.ExecuteNonQuery()

                        If rowaffected = 1 Then
                            rowaffected = 0
                            command.Parameters.Clear()
                            command.Parameters.AddWithValue("dwmatio", seDwmatio)
                            command.Parameters.AddWithValue("kwd", kwdStatus)
                            command.CommandText = "UPDATE status SET dwmatio=? WHERE (kwd=?)"
                            rowaffected = command.ExecuteNonQuery()
                        End If
                        If rowaffected = 1 Then



                            transaction.Commit()
                            Return True
                        Else
                            transaction.Rollback()
                            Return False
                        End If

                    Else
                        transaction.Rollback()
                        Return False
                    End If
                Else
                    transaction.Rollback()
                    Return False

                End If
                myReader.Close()
                transaction.Rollback()
                Return False

                'End If

                'Return False

            Catch ex As Exception
                transaction.Rollback()
                Return False
                'MsgBox("H ΑΠΥ δεν πορεί να εκδοθεί !", MsgBoxStyle.Information, "winfo\nikEl.")
            End Try
        End Using

    End Function
    'Private Function set_availabilities_status(ByVal dwmNew As String, ByVal dwmOld As String, ByVal kwdikosKrat As Integer) As Boolean
    '    Dim availPath As String = "c:\winfo\availabilities.txt"
    '    Dim roomRateTiposOld As String = ""
    '    Dim roomRateTiposNew As String = ""
    '    Dim dwmApo As String = ""
    '    Dim enarxi, lixi As Date
    '    Dim hotel As SetMainCalendarKratisis

    '    Using connection As New OleDb.OleDbConnection(connectionString)
    '        Dim command As New OleDb.OleDbCommand()
    '        Dim myReader As OleDb.OleDbDataReader
    '        connection.Open()
    '        ' Assign transaction object for a pending local transaction.
    '        command.Connection = connection
    '        command.Parameters.AddWithValue("kratisi", kwdikosKrat)
    '        command.CommandText = "SELECT dwmatio, enarxi,lixi, dwmatiostatus FROM status WHERE kratisi=?"
    '        myReader = command.ExecuteReader()
    '        While myReader.Read
    '            dwmApo = myReader.GetString(0)
    '            enarxi = myReader.GetDateTime(1)
    '            lixi = myReader.GetDateTime(2)
    '        End While
    '        command.Parameters.Clear()
    '        myReader.Close()
    '        If dwmOld.Equals(dwmApo) Then
    '            command.Parameters.AddWithValue("arithmos", dwmOld)
    '            '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
    '            command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?)) ORDER BY RoomRateTypes.id ASC"
    '            'WHERE tbl_dwmatia.arithmos NOT IN (
    '            '   SELECT DISTINCT tbl_kratiseis.dwmatio
    '            '   FROM tbl_kratiseis
    '            '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
    '            myReader = command.ExecuteReader()
    '            While myReader.Read()
    '                roomRateTiposOld = myReader.GetString(0)
    '                Exit While
    '            End While
    '            command.Parameters.Clear()
    '            myReader.Close()
    '        Else
    '            Return False
    '        End If
    '        If dwmNew <> "" Then
    '            command.Parameters.AddWithValue("arithmos", dwmNew)
    '            '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
    '            command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?))"
    '            'WHERE tbl_dwmatia.arithmos NOT IN (
    '            '   SELECT DISTINCT tbl_kratiseis.dwmatio
    '            '   FROM tbl_kratiseis
    '            '   WHERE tbl_kratiseis.afixi < STR_TO_DATE('$mexri','%d/%m/%Y') AND tbl_kratiseis.anaxwrisi > STR_TO_DATE('$apo','%d/%m/%Y')) order by tbl_dwmatia.arithmos ASC"
    '            myReader = command.ExecuteReader()
    '            While myReader.Read()
    '                roomRateTiposNew = myReader.GetString(0)
    '                Exit While
    '            End While
    '            command.Parameters.Clear()
    '            myReader.Close()

    '        End If
    '        If dwmNew <> dwmOld Then
    '            If roomRateTiposNew <> roomRateTiposOld Then
    '                If roomRateTiposOld <> "" Then

    '                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxi, lixi, "1")
    '                    hotel.set_roomratetype_id(roomRateTiposOld)

    '                    hotel.set_availabilities_operator("plus")

    '                    If hotel.make_send_XML_file_for_Availabilities_request() Then
    '                        File.AppendAllText(availPath, "1502 " + roomRateTiposOld + " " + enarxi + " " + lixi + " " + "plus" + vbCrLf)
    '                    Else
    '                        Return False
    '                    End If


    '                End If
    '                If roomRateTiposNew <> "" Then

    '                    hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxi, lixi, "1")
    '                    hotel.set_roomratetype_id(roomRateTiposNew)
    '                    hotel.set_availabilities_operator("minus")
    '                    If hotel.make_send_XML_file_for_Availabilities_request() Then
    '                        File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + enarxi + " " + lixi + " " + "minus" + vbCrLf)
    '                    Else
    '                        Return False
    '                    End If


    '                End If


    '            End If

    '            'ElseIf dwmOld = dwmNew And dwmNew <> "" Then
    '            '    If enarxiOld < neaEnarxi Then ' nea afixi pio meta apo programatismeni -> eleyuervse damtio
    '            '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxiOld, neaEnarxi.AddDays(-1), "1")
    '            '        hotel.set_roomratetype_id(roomRateTiposNew)
    '            '        hotel.set_availabilities_operator("plus")
    '            '        If hotel.make_send_XML_file_for_Availabilities_request() Then
    '            '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + enarxiOld + " " + neaEnarxi.AddDays(-1) + " " + "plus" + vbCrLf)
    '            '        Else
    '            '            Return False
    '            '        End If

    '            '    ElseIf neaEnarxi < enarxiOld Then
    '            '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaEnarxi, enarxiOld.AddDays(-1), "1")
    '            '        hotel.set_roomratetype_id(roomRateTiposNew)
    '            '        hotel.set_availabilities_operator("minus")
    '            '        If hotel.make_send_XML_file_for_Availabilities_request() Then
    '            '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaEnarxi + " " + enarxiOld.AddDays(-1) + " " + "minus" + vbCrLf)
    '            '        Else
    '            '            Return False
    '            '        End If

    '            '    End If
    '            '    If lixiOld < neaLixi Then ' epektasi anxwrisis
    '            '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", lixiOld.AddDays(+1), neaLixi, "1")
    '            '        hotel.set_roomratetype_id(roomRateTiposNew)
    '            '        hotel.set_availabilities_operator("minus")
    '            '        If hotel.make_send_XML_file_for_Availabilities_request() Then
    '            '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + lixiOld.AddDays(+1) + " " + neaLixi + " " + "minus" + vbCrLf)
    '            '        Else
    '            '            Return False
    '            '        End If

    '            '    ElseIf neaLixi < lixiOld Then
    '            '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaLixi.AddDays(+1), lixiOld, "1")
    '            '        hotel.set_roomratetype_id(roomRateTiposNew)
    '            '        hotel.set_availabilities_operator("plus")
    '            '        If hotel.make_send_XML_file_for_Availabilities_request() Then
    '            '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaLixi.AddDays(+1) + " " + lixiOld + " " + "plus" + vbCrLf)
    '            '        Else
    '            '            Return False
    '            '        End If

    '            '    End If
    '        End If




    '    End Using
    '    Return True
    'End Function
    Private Function set_availabilities_all_status(ByVal dwmNew As String, ByVal dwmOld As String, ByVal kwdikosKrat As Integer) As Boolean
        Dim availPath As String = "c:\winfo\availabilities.txt"
        Dim roomRateTiposOld As String = ""
        Dim roomRateTiposNew As String = ""
        Dim dwmApo As String = ""
        Dim enarxi, lixi As Date
        Dim hotel As SetAvailabilities
        Dim datumKlDwm() As Int16
        Dim anzahl, i As Int16

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
                dwmApo = myReader.GetString(0)
                enarxi = myReader.GetDateTime(1)
                lixi = myReader.GetDateTime(2)
            End While
            command.Parameters.Clear()
            myReader.Close()
            If dwmOld.Equals(dwmApo) Then
                command.Parameters.AddWithValue("arithmos", dwmOld)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?)) ORDER BY RoomRateTypes.id ASC"
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
            Else
                Return False
            End If
            If dwmNew <> "" Then
                command.Parameters.AddWithValue("arithmos", dwmNew)
                '  command.CommandText = "SELECT dwmatia.arithmos, dwmatia.klines FROM dwmatia INNER JOIN katigories ON dwmatia.katigoria=katigories.kwd WHERE (katigories.tipos=?) AND (dwmatia.arithmos NOT IN (SELECT DISTINCT kratiseis.dwmatio FROM kratiseis WHERE (kratiseis.afixi<?) and (kratiseis.anaxwrisi>?)))" 'WHERE   kratiseis.afixi<? AND   kratiseis.anaxwrisi>?
                command.CommandText = "SELECT RoomRateTypes.id, dwmatia.arithmos FROM RoomRateTypes INNER JOIN (katigories INNER JOIN dwmatia ON katigories.kwd = dwmatia.katigoria) ON RoomRateTypes.tipos = katigories.tipos WHERE (((dwmatia.arithmos)=?)) ORDER BY RoomRateTypes.id ASC"
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
                     
                        ReDim datumKlDwm(lixi.Subtract(enarxi).Days)
                        KratiseisTableAdapter1.FillByTipAfixeisAnax(Me.DbhotelDataSet1.kratiseis, lixi, enarxi, roomRateTiposOld)
                        If Me.DbhotelDataSet1.kratiseis.Count <> 0 Then
                            fuehle_datum_krat1_xenodox(datumKlDwm, enarxi, lixi)
                            For i = 0 To datumKlDwm.Length - 1
                                datumKlDwm(i) = datumKlDwm(i) - 1
                            Next
                        End If
                        '    anzahl = Me.KatigoriesTableAdapter.AnzahlByTipos(roomRateTiposOld)
                        anzahl = get_anzahl_rooms_by_kathgoria(roomRateTiposOld)
                        hotel = New SetAvailabilities("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxi, datumKlDwm, anzahl)

                        hotel.set_roomratetype_id(roomRateTiposOld)

                        '  hotel.set_availabilities_operator("plus")

                        If hotel.make_send_XML_file_for_Availabilities_request() Then
                            File.AppendAllText(availPath, DateTime.Now + " " + "1502 " + roomRateTiposOld + " " + enarxi + " " + lixi + " " + "plus" + vbCrLf)
                        Else
                            Return True
                        End If



                    End If
                    If roomRateTiposNew <> "" Then
                   
                        'hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaEnarxi, neaLixi, "1")
                        'hotel.set_roomratetype_id(roomRateTiposNew)
                        'hotel.set_availabilities_operator("minus")
                        ReDim datumKlDwm(lixi.Subtract(enarxi).Days)
                        Me.KratiseisTableAdapter1.FillByTipAfixeisAnax(Me.DbhotelDataSet1.kratiseis, lixi, enarxi, roomRateTiposNew)
                        If Me.DbhotelDataSet1.kratiseis.Count <> 0 Then
                            fuehle_datum_krat1_xenodox(datumKlDwm, enarxi, lixi)
                          
                        End If
                        For i = 0 To datumKlDwm.Length - 1
                            datumKlDwm(i) = datumKlDwm(i) + 1
                        Next
                        ' anzahl = Me.KatigoriesTableAdapter.AnzahlByTipos(roomRateTiposOld)
                        anzahl = get_anzahl_rooms_by_kathgoria(roomRateTiposNew)
                        hotel = New SetAvailabilities("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxi, datumKlDwm, anzahl)

                        hotel.set_roomratetype_id(roomRateTiposNew)

                        If hotel.make_send_XML_file_for_Availabilities_request() Then
                            File.AppendAllText(availPath, DateTime.Now + " " + "1502 " + roomRateTiposNew + " " + enarxi + " " + lixi + " " + "minus" + vbCrLf)
                        Else
                            Return False
                        End If



                    End If


                End If

                'ElseIf dwmOld = dwmNew And dwmNew <> "" Then
                '    If enarxiOld < neaEnarxi Then ' nea afixi pio meta apo programatismeni -> eleyuervse damtio
                '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", enarxiOld, neaEnarxi.AddDays(-1), "1")
                '        hotel.set_roomratetype_id(roomRateTiposNew)
                '        hotel.set_availabilities_operator("plus")
                '        If hotel.make_send_XML_file_for_Availabilities_request() Then
                '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + enarxiOld + " " + neaEnarxi.AddDays(-1) + " " + "plus" + vbCrLf)
                '        Else
                '            Return False
                '        End If

                '    ElseIf neaEnarxi < enarxiOld Then
                '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaEnarxi, enarxiOld.AddDays(-1), "1")
                '        hotel.set_roomratetype_id(roomRateTiposNew)
                '        hotel.set_availabilities_operator("minus")
                '        If hotel.make_send_XML_file_for_Availabilities_request() Then
                '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaEnarxi + " " + enarxiOld.AddDays(-1) + " " + "minus" + vbCrLf)
                '        Else
                '            Return False
                '        End If

                '    End If
                '    If lixiOld < neaLixi Then ' epektasi anxwrisis
                '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", lixiOld.AddDays(+1), neaLixi, "1")
                '        hotel.set_roomratetype_id(roomRateTiposNew)
                '        hotel.set_availabilities_operator("minus")
                '        If hotel.make_send_XML_file_for_Availabilities_request() Then
                '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + lixiOld.AddDays(+1) + " " + neaLixi + " " + "minus" + vbCrLf)
                '        Else
                '            Return False
                '        End If

                '    ElseIf neaLixi < lixiOld Then
                '        hotel = New SetMainCalendarKratisis("https://hotelavailabilities.com/pmsapi", "kallergisapi", "K@ll3rgisXML", "1502", neaLixi.AddDays(+1), lixiOld, "1")
                '        hotel.set_roomratetype_id(roomRateTiposNew)
                '        hotel.set_availabilities_operator("plus")
                '        If hotel.make_send_XML_file_for_Availabilities_request() Then
                '            File.AppendAllText(availPath, "1502 " + roomRateTiposNew + " " + neaLixi.AddDays(+1) + " " + lixiOld + " " + "plus" + vbCrLf)
                '        Else
                '            Return False
                '        End If

                '    End If
            End If




        End Using
        Return True
    End Function
    Private Sub fuehle_datum_krat1_xenodox(ByRef datumKrat() As Int16, ByVal apo As Date, ByVal mexri As Date)
        Dim j, index1, index2, k As Int16

        For j = 0 To Me.DbhotelDataSet1.kratiseis.Count - 1

            If Me.DbhotelDataSet1.kratiseis(j).afixi.Date <= apo Then
                index1 = 0
            Else
                index1 = Me.DbhotelDataSet1.kratiseis(j).afixi.DayOfYear - apo.DayOfYear
            End If
            If Me.DbhotelDataSet1.kratiseis(j).anaxwrisi.Date.AddDays(-1) >= mexri Then
                index2 = datumKrat.Length - 1
            Else
                index2 = Me.DbhotelDataSet1.kratiseis(j).anaxwrisi.Date.AddDays(-1).DayOfYear - apo.DayOfYear
            End If

            For k = index1 To index2
                datumKrat(k) = datumKrat(k) + 1
            Next
        Next

    End Sub
    Private Function get_anzahl_rooms_by_kathgoria(ByVal roomtype As Int32) As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim anzahl As Int16
            Dim overKwd As Integer = -1
            Dim command As New OleDb.OleDbCommand()

            Try
                connection.Open()

                ' Assign transaction object for a pending local transaction.
                command.Connection = connection

                command.Parameters.AddWithValue("id", roomtype)
                command.CommandText = "SELECT total_rooms FROM RoomRateTypes where (id=?)"

                Dim myReader As OleDb.OleDbDataReader
                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                While myReader.Read()
                    anzahl = myReader.GetInt16(0)
                End While
                myReader.Close()




                Return anzahl
            Catch ex As Exception


            End Try



        End Using


    End Function
    Private Sub change_room(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim kwdikos As Integer
        Dim onoma As String
        Try
            kwdikos = CType(sender.name, Integer)
        Catch ex As InvalidCastException
            Exit Sub
        End Try

        Me.AfixeisAnaxwriseisTableAdapter.FillByKwdikoKratisis(Me.DbhotelDataSet1.AfixeisAnaxwriseis, kwdikos)
        If kwdikos <> -1 AndAlso Me.DbhotelDataSet1.AfixeisAnaxwriseis.Count <> 0 Then

            If Not IsDBNull(Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).Item("onomateponimo")) Then
                onoma = Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).onomateponimo
            Else
                onoma = ""
            End If
            MsgBox("Αρ.Κρατ.: " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).arithmos.ToString + ChrW(13) + "Πρακτορ.: " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).eponimia + ChrW(13) + _
                    "Ονομα. : " + onoma + ChrW(13) + "Αφιξη : " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).afixi + ChrW(13) + "Αναχώριση : " + Me.DbhotelDataSet1.AfixeisAnaxwriseis(0).anaxwrisi)
        End If
    End Sub
    Private Sub ektiposi_plirotita_dwmatiwn(ByVal arxiIm As Date, ByVal telosIm As Date, ByVal index1 As Int16, ByVal index2 As Int16)
        Dim i, j As Int16
        Dim tageCount As Integer
        'Dim dateCount As Date
        'dateCount = arxiIm
        'tageCount = telosIm.DayOfYear - arxiIm.DayOfYear
        tageCount = telosIm.Subtract(arxiIm).Days

        Me.DbhotelDataSet1.ekt_imeres_status_dwm.Clear()
        Me.DbhotelDataSet1.ekt_imeres_status_dwm.Rows.Add()
        For i = 0 To tageCount
            Me.DbhotelDataSet1.ekt_imeres_status_dwm(0).Item(i) = arxiIm.Date.AddDays(i).DayOfWeek.ToString.Substring(0, 2) + ChrW(13) + arxiIm.Date.AddDays(i).Day.ToString
            'MsgBox(Me.DbhotelDataSet1.ekt_imeres_status_dwm(0).Item(i))
        Next

        Me.DbhotelDataSet1.ekt_status_dwm.Rows.Clear()
        For j = index1 To index2
            Me.DbhotelDataSet1.ekt_status_dwm.Rows.Add()
            Me.DbhotelDataSet1.ekt_status_dwm(j - index1).dwmatio = dwmatia(j)
        Next
        'Me.ProgressBar1.Value += 10


        'Using connection As New OleDb.OleDbConnection(connectionString)
        '    Dim command As New OleDb.OleDbCommand()
        '    Dim myReader As OleDb.OleDbDataReader
        '    connection.Open()
        '    command.Connection = connection
        '    For j = index1 To index2
        '        Dim imeresStat(), imeresPrakt() As Integer

        '        ReDim imeresStat(tageCount)
        '        ReDim imeresPrakt(tageCount)
        '        init_status_dwmatiou(imeresStat)
        '        init_status_dwmatiou(imeresPrakt)

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
        '        While myReader.Read()
        '            Dim zeiger1, zeiger2 As Integer
        '            zeiger1 = arxiIm.DayOfYear - myReader.GetDateTime(3).DayOfYear
        '            If myReader.GetDateTime(3) < arxiIm Then
        '                zeiger1 = 0
        '            ElseIf myReader.GetDateTime(3) >= arxiIm And myReader.GetDateTime(3) <= telosIm Then
        '                zeiger1 = myReader.GetDateTime(3).DayOfYear - arxiIm.DayOfYear
        '            Else
        '                zeiger1 = -1
        '            End If

        '            If myReader.GetDateTime(4) >= telosIm Then
        '                zeiger2 = imeresStat.Length - 1
        '            ElseIf myReader.GetDateTime(4) >= arxiIm And myReader.GetDateTime(4) < telosIm Then
        '                zeiger2 = myReader.GetDateTime(4).DayOfYear - arxiIm.DayOfYear
        '            Else
        '                zeiger2 = -1
        '            End If
        '            If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
        '                setze_status_praktoreio(zeiger1, zeiger2, myReader.GetInt32(5), imeresStat, imeresPrakt, myReader.GetInt32(2))
        '            End If

        '        End While
        '        myReader.Close()
        '        command.Parameters.Clear()
        '        'For i = 0 To imeresStat.Length - 1
        '        '    '(locx + (i - 1) * stepx, locy)
        '        '    If imeresStat(i) <> -1 Then

        '        '        Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = get_status_by_kwd(imeresStat(i)) ' + ChrW(13) + "(" + imeresPrakt(i).ToString + ")"

        '        '    Else
        '        '        Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "V"
        '        '    End If


        '        'Next
        '        Dim kratisiTemp As Integer = 0
        '        Dim change As Integer = 1
        '        For i = 0 To imeresStat.Length - 1

        '            '(locx + (i - 1) * stepx, locy)
        '            If imeresStat(i) <> -1 And imeresStat(i) <> 1 Then

        '                Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = get_status_by_kwd(imeresStat(i)) ' + ChrW(13) + "(" + imeresPrakt(i).ToString + ")"
        '            ElseIf imeresStat(i) = 1 Then
        '                If kratisiTemp <> imeresPrakt(i) Then
        '                    change = change * -1
        '                End If
        '                If change = 1 Then
        '                    Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "R"
        '                Else
        '                    Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "r"
        '                End If
        '            Else
        '                Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "V"
        '            End If

        '            kratisiTemp = imeresPrakt(i)
        '        Next
        '        Try
        '            Me.ProgressBar1.Value += 10
        '        Catch ex As ArgumentOutOfRangeException
        '            Me.ProgressBar1.Value = 0
        '        End Try

        '    Next

        '    Me.ProgressBar1.Value = 0
        'End Using
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            connection.Open()
            command.Connection = connection

            For j = index1 To index2
                Dim imeresStat(), imeresPrakt() As Integer
                ReDim imeresStat(tageCount)
                ReDim imeresPrakt(tageCount)
                init_status_dwmatiou(imeresStat)
                init_status_dwmatiou(imeresPrakt)

                command.Parameters.AddWithValue("@dwmatio", dwmatia(j))
                command.Parameters.AddWithValue("@enarxi", arxiIm)
                command.Parameters.AddWithValue("@lixi", arxiIm)
                command.Parameters.AddWithValue("@dwmatio2", dwmatia(j))
                command.Parameters.AddWithValue("@enarxi2", telosIm)
                command.Parameters.AddWithValue("@lixi2", telosIm)
                command.Parameters.AddWithValue("@dwmatio3", dwmatia(j))
                command.Parameters.AddWithValue("@enarxi3", arxiIm)
                command.Parameters.AddWithValue("@lixi3", telosIm)
                command.CommandText = "SELECT DISTINCT kwd, dwmatio, kratisi, enarxi, lixi, dwmatiostatus FROM status WHERE (dwmatio=@dwmatio AND enarxi<=@enarxi AND lixi>=@lixi) OR (dwmatio=@dwmatio2 AND enarxi<=@enarxi2 AND lixi>=@lixi2) OR (dwmatio=@dwmatio3 AND enarxi>@enarxi3 AND lixi<@lixi3)"
                myReader = command.ExecuteReader()

                While myReader.Read()
                    Dim zeiger1, zeiger2 As Integer
                    zeiger1 = arxiIm.DayOfYear - myReader.GetDateTime(3).DayOfYear
                    If myReader.GetDateTime(3) < arxiIm Then
                        zeiger1 = 0
                    ElseIf myReader.GetDateTime(3) >= arxiIm And myReader.GetDateTime(3) <= telosIm Then
                        zeiger1 = myReader.GetDateTime(3).DayOfYear - arxiIm.DayOfYear
                    Else
                        zeiger1 = -1
                    End If

                    If myReader.GetDateTime(4) >= telosIm Then
                        zeiger2 = imeresStat.Length - 1
                    ElseIf myReader.GetDateTime(4) >= arxiIm And myReader.GetDateTime(4) < telosIm Then
                        zeiger2 = myReader.GetDateTime(4).DayOfYear - arxiIm.DayOfYear
                    Else
                        zeiger2 = -1
                    End If

                    If zeiger1 >= 0 AndAlso zeiger2 >= 0 Then
                        setze_status_praktoreio(zeiger1, zeiger2, myReader.GetInt32(5), imeresStat, imeresPrakt, myReader.GetInt32(2))
                    End If
                End While

                myReader.Close()
                command.Parameters.Clear()

                Dim kratisiTemp As Integer = 0
                Dim change As Integer = 1

                For i = 0 To imeresStat.Length - 1
                    If imeresStat(i) <> -1 AndAlso imeresStat(i) <> 1 Then
                        Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = get_status_by_kwd(imeresStat(i))
                    ElseIf imeresStat(i) = 1 Then
                        If kratisiTemp <> imeresPrakt(i) Then
                            change = change * -1
                        End If
                        If change = 1 Then
                            Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "R"
                        Else
                            Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "r"
                        End If
                    Else
                        Me.DbhotelDataSet1.ekt_status_dwm(j - index1).Item(i + 1) = "V"
                    End If

                    kratisiTemp = imeresPrakt(i)
                Next

                Try
                    Me.ProgressBar1.Value += 10
                Catch ex As ArgumentOutOfRangeException
                    Me.ProgressBar1.Value = 0
                End Try
            Next

            Me.ProgressBar1.Value = 0
        End Using

        Me.ProgressBar1.Value = 0

    End Sub

    Private Sub setze_status(ByVal zeiger1 As Integer, ByVal zeiger2 As Integer, ByVal dwmStatus As Integer, ByRef imeresStat() As Integer, ByVal kwdikoskrat As Integer, ByRef kwdkrat() As Integer)
        Dim i As Integer

        For i = zeiger1 To zeiger2
            If imeresStat(i) = -1 Then
                imeresStat(i) = dwmStatus
            Else
                Select Case dwmStatus
                    Case 1
                        If imeresStat(i) = 1 Then
                            imeresStat(i) = 3 'reservation kwd=1
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
    'Private Function ist_kratisi_not_confirmed(ByVal kratisi As Integer) As Boolean
    '    Dim j As Int16
    '    For j = 0 To Me.DbhotelDataSet1.kratiseis.Count - 1
    '        If Me.DbhotelDataSet1.kratiseis(j).kwd = kratisi Then
    '            If Me.DbhotelDataSet1.kratiseis(0).prokataboli = 0 Then
    '                If imeromErgasias.DayOfYear - Me.DbhotelDataSet1.kratiseis(0).imeromkratisis.DayOfYear >= 0 AndAlso (imeromErgasias.DayOfYear - Me.DbhotelDataSet1.kratiseis(0).imeromkratisis.DayOfYear) >= Me.DbhotelDataSet1.etaireia(0).timolkwd Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            Else
    '                Return False
    '            End If

    '        End If
    '    Next
    '    Return False
    'End Function
    Private Sub setze_status_praktoreio(ByVal zeiger1 As Integer, ByVal zeiger2 As Integer, ByVal dwmStatus As Integer, ByRef imeresStat() As Integer, ByRef imeresPrakt() As Integer, ByVal kratisi As Integer)
        Dim i As Integer


        'For i = zeiger1 To zeiger2
        '    If imeresStat(i) = -1 Then
        '        imeresStat(i) = dwmStatus
        '        If dwmStatus = 1 Or dwmStatus = 8 Or dwmStatus = 5 Or dwmStatus = 3 Then
        '            imeresPrakt(i) = Me.KratiseisTableAdapter.GetPraktKwdByKwd(kratisi)
        '        End If

        '    Else
        '        Select Case dwmStatus
        '            'Case 1
        '            '    If imeresStat(i) = -1 Then
        '            '        imeresStat(i) = 1 'reservation kwd=1
        '            '    End If
        '            Case 8
        '                If imeresStat(i) = -1 OrElse imeresStat(i) = 1 Then
        '                    imeresStat(i) = 8 'n.S kwd=8
        '                    imeresPrakt(i) = Me.KratiseisTableAdapter.GetPraktKwdByKwd(kratisi)
        '                End If
        '            Case 5
        '                If imeresStat(i) = -1 OrElse imeresStat(i) = 1 OrElse imeresStat(i) = 8 Then
        '                    'MsgBox("KASDLFSLFD")
        '                    imeresStat(i) = 5 'S kwd=5
        '                    imeresPrakt(i) = Me.KratiseisTableAdapter.GetPraktKwdByKwd(kratisi)
        '                ElseIf imeresStat(i) = 5 Then
        '                    imeresStat(i) = 3 'D doppelStay
        '                    imeresPrakt(i) = Me.KratiseisTableAdapter.GetPraktKwdByKwd(kratisi)
        '                End If
        '        End Select

        '    End If
        'Next
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
    Private Sub init_kwd_krat(ByRef kwdkrat() As Integer)
        Dim j As Int16

        For j = 0 To kwdkrat.Length - 1
            kwdkrat(j) = -1
        Next
    End Sub
    Private Sub fuele_alle_zimmer()
        Dim i As Int16
        'Dim zimmerApo, zimmerEws As String


        'If PlirDwmApoTbx.Text.Equals("") Then
        '    zimmerApo = Me.DwmatiaTableAdapter.GetMinArDwmatiou()
        'Else
        '    zimmerApo = PlirDwmApoTbx.Text
        'End If
        'If PlirDwmEwsTbx.Text.Equals("") Then
        '    zimmerEws = Me.DwmatiaTableAdapter.GetMaxArDwmatiou()
        'Else
        '    zimmerEws = PlirDwmEwsTbx.Text
        'End If
        'If zimmerApo <= zimmerEws Then
        '    Me.DwmatiaTableAdapter.DwmatiaApoEws(Me.DbhotelDataSet1.dwmatia, zimmerApo, zimmerEws)
        'Else
        '    Me.DwmatiaTableAdapter.FillOhneOvBook(Me.DbhotelDataSet1.dwmatia)
        'End If
        Dim datumAllotm(), datumBook(), datumKlDwm(), anzahl As Int16

        ReDim datumAllotm(30)
        ReDim datumBook(30)
        ReDim datumKlDwm(30)
        Me.DwmatiaTableAdapter.FillByTipos(Me.DbhotelDataSet1.dwmatia, 11)
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    anzahl = 0
        '    DwmPlirot2Pnl.Controls.Clear()
        '    DwmPlirot3Pnl.Controls.Clear()
        '    If klinesKwd > 0 And tiposKwd > 0 Then 'enas orismenos tipos dwmatiou me kathorismeno arithmo klinwn
        '        Me.DwmatiaTableAdapter.FillByKlinesTipos(Me.DbhotelDataSet1.dwmatia, klinesKwd, tiposKwd)
        '    ElseIf klinesKwd = 0 And tiposKwd > 0 Then 'enas tipos (thea) Anexartitou klinwn
        '        Me.DwmatiaTableAdapter.FillByTipos(Me.DbhotelDataSet1.dwmatia, tiposKwd)
        '    ElseIf klinesKwd > 0 And tiposKwd = 0 Then 'kathorismnes klines anexartitou tipou dwmatiou
        '        Me.DwmatiaTableAdapter.FillDwmatiaXenodByKlines(Me.DbhotelDataSet1.dwmatia, klinesKwd, 13, 25)
        '    Else
        '        Me.DwmatiaTableAdapter.FillDwmXenodOla(Me.DbhotelDataSet1.dwmatia, 13, 25)
        '    End If


        '    'MsgBox(Me.DbhotelDataSet1.allotment.Count)

        'Catch ex As System.Exception
        '    Me.Cursor = Cursors.Default
        '    System.Windows.Forms.MessageBox.Show(ex.Message)
        'End Try
        Me.Cursor = Cursors.Default

        'pROSOXI-> ICH GEHE DAVON AUS DASS DAS mAX zIMMMER EINAI TO OVER-BOOK TO OPOIO DEN XREIAZETAI NA BGEI -> ARA DEN PAIRNW TO TELEYTAIO !!->EINAI SORTIERT KATA ARITHMO (sTRING!-> 102<2 !!!!)
        For i = 0 To Me.DbhotelDataSet1.dwmatia.Count - 1
            ReDim Preserve dwmatia(i)

            dwmatia(i) = Me.DbhotelDataSet1.dwmatia(i).arithmos
        Next
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
                If zeigerDwm1 - 9 >= 0 Then
                    zeigerDwm2 = zeigerDwm1
                    'meiwsw kata 9 ton prwto zeiger
                    zeigerDwm1 -= 9
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

                If zeigerDwm2 + 9 < dwmatia.Length - 1 Then
                    zeigerDwm2 += 9
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

        For j = 0 To Me.DbhotelDataSet1.dwmatiastatus.Count - 1
            If Me.DbhotelDataSet1.dwmatiastatus(j).kwd = kwdikos Then
                'MsgBox(Me.DbhotelDataSet1.dwmatiastatus(j).status)
                Return Me.DbhotelDataSet1.dwmatiastatus(j).status
            End If
        Next
        Return ""
    End Function
    Private Sub EktStatusDwmBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EktStatusDwmBtn.Click
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New StatusDwmatiwn()

        Try
            If dwmatia.Length <= 0 Then
                Exit Sub
            End If
        Catch ex As NullReferenceException
            MsgBox("Επιλέξτε πρώτα εμφάνιση !", MsgBoxStyle.Information, "winfo\nikEl.")
            Exit Sub
        End Try
        If PlirDwmPlithImerTbx.Text <= 31 Then
            ektiposi_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(PlirDwmPlithImerTbx.Text - 1), 0, dwmatia.Length - 1)
        Else
            ektiposi_plirotita_dwmatiwn(ImeromPlirotDwm.Value.Date, ImeromPlirotDwm.Value.Date.AddDays(30), 0, dwmatia.Length - 1)
        End If

        Me.DbhotelDataSet1.ekt_status_ekdosi.Clear()
        Me.DbhotelDataSet1.ekt_status_ekdosi.Rows.Add()
        Me.DbhotelDataSet1.ekt_status_ekdosi(0).ekdosi = imeromErgasias
        Me.DbhotelDataSet1.ekt_status_ekdosi(0).arxi = ImeromPlirotDwm.Value.Date

        'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet1.etaireia)
        sender.Enabled = False
        ektiposi.SetDataSource(DbhotelDataSet1)
        CrystalReportViewer1.ReportSource = ektiposi
        CrystalReportViewer1.DisplayGroupTree = False
        Form1.Controls.Add(CrystalReportViewer1)
        CrystalReportViewer1.Dock = DockStyle.Fill
        CrystalReportViewer1.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        sender.Enabled = True
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
        Me.DwmatiastatusTableAdapter.Fill(Me.DbhotelDataSet1.dwmatiastatus)
    End Sub

    Private Sub PlirotitaDwmFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.Mail' table. You can move, or remove it, as needed.
        ' Me.MailTableAdapter.Fill(Me.DbhotelDataSet.Mail)
        'TODO: This line of code loads data into the 'DbhotelDataSet1.klines' table. You can move, or remove it, as needed.
        Me.KlinesTableAdapter.Fill(Me.DbhotelDataSet1.klines)
        'TODO: This line of code loads data into the 'DbhotelDataSet1.dwmatia' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet1.katigories' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet1.tipoi' table. You can move, or remove it, as needed.
        Me.TipoiTableAdapter.FillTipoiXenodByKwd(Me.DbhotelDataSet1.tipoi, 13, 25)
        'TODO: This line of code loads data into the 'DbhotelDataSet1.tipoi' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet1.klines' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'DbhotelDataSet1.katigories' table. You can move, or remove it, as needed.

        init_klines_tipoi_cboxen_2() 'TODO: This line of code loads data into the 'DbhotelDataSet1.AfixeisAnaxwriseis2' table. You can move, or remove it, as needed.

    End Sub


    Private Sub XenodStatusKlinesCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XenodStatusKlinesCbx.SelectedIndexChanged, XenodStatusTiposCbx.SelectedIndexChanged
        Dim anzahl As Int16

        'If currentsimbolaio <> -1 Then

        'If Not isDBEintrag Then
        If sender.name.Equals("XenodStatusKlinesCbx") Then
            '  XenodStatus4Pnl.Controls.Clear()
            DwmPlirot2Pnl.Controls.Clear()
            DwmPlirot3Pnl.Controls.Clear()
            If sender.selectedindex <> -1 Then
                klinesKwd = get_kwd_klins_byname(sender.selectedItem.ToString)
            Else
                klinesKwd = -1
            End If
            If klinesKwd = -1 Then
                klinesKwd = 0
            End If
            If klinesKwd > 0 Then
                anzahl = Me.KatigoriesTableAdapter.ExistDwmXenodByklines(klinesKwd, 13, 25)
                If anzahl = 0 Then
                    MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    XenodStatusKlinesCbx.SelectedIndex = 0

                End If
            End If
        ElseIf sender.name.Equals("XenodStatusTiposCbx") Then
            DwmPlirot2Pnl.Controls.Clear()
            DwmPlirot3Pnl.Controls.Clear()
            If sender.selectedindex <> -1 Then
                tiposKwd = get_kwd_tipos_byname(sender.selectedItem.ToString)
            Else
                tiposKwd = -1
            End If
            If tiposKwd = -1 Then
                tiposKwd = 0
            End If
            If tiposKwd > 0 Then
                anzahl = Me.KatigoriesTableAdapter.ExistTiposXenod(tiposKwd)
                If anzahl = 0 Then
                    MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                    XenodStatusTiposCbx.SelectedIndex = 0
                End If
            End If
        End If
        If klinesKwd > 0 And tiposKwd > 0 Then
            anzahl = Me.KatigoriesTableAdapter.ExistKatigXenod(klinesKwd, tiposKwd)
            If anzahl = 0 Then
                MsgBox("Δεν υπάρχει αυτός ο τύπος Δωματίου στην Δύναμη του Ξενοδοχείου !", MsgBoxStyle.Exclamation, "winfo\nikEl.")
                XenodStatusTiposCbx.SelectedIndex = 0
                XenodStatusKlinesCbx.SelectedIndex = 0
                'Else
                '    If SimbCbx.Items.Count <> 0 Then
                '        If Not isDBEintrag Then
                '            SimbCbx.SelectedIndex = 0
                '        End If
                '    End If
            End If
        End If

    End Sub
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
    Private Sub init_klines_tipoi_cboxen_2()
        Dim j As Int16

        XenodStatusKlinesCbx.Items.Clear()
        XenodStatusTiposCbx.Items.Clear()
        For j = 0 To 3
            If j <> 0 Then
                XenodStatusKlinesCbx.Items.Add(Me.DbhotelDataSet1.klines(j - 1).perigrafi)
            Else
                XenodStatusKlinesCbx.Items.Add("Όλες")
            End If
        Next


        For j = 0 To Me.DbhotelDataSet1.tipoi.Count
            If j <> 0 Then
                XenodStatusTiposCbx.Items.Add(Me.DbhotelDataSet1.tipoi(j - 1).tipos)
            Else
                XenodStatusTiposCbx.Items.Add("Όλοι")
            End If
        Next
    End Sub


    Private Sub SendMialBtn_Click(sender As Object, e As EventArgs) Handles SendMialBtn.Click

        Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
        Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
        Dim j As Int16
        Dim filename As String
        Dim attachment As String()
        Dim counter As Int16 = 0
        Dim ektiposi As New StatusDwmatiwn()
        Dim threadList As List(Of Threading.Thread) = New List(Of Threading.Thread)
        'Dim proti As String
        'Dim protiDate As Date
        'Dim format() = {"dd/MM/yyyy", "d/M/yyyy"}

        'For j = ImeromPlirotDwm.Value.Month To 11
        '    proti = "1/" + j.ToString + "/" + ImeromPlirotDwm.Value.Year.ToString

        '    Date.TryParseExact(proti, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None, protiDate)
        '    MsgBox(protiDate.ToString)
        'Next
        ' System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture

        Me.Cursor = Cursors.WaitCursor
        Dim protiString As String
        '  j = ImeromPlirotDwm.Value.Month
        j = ImeromPlirotDwm.Value.Month
        Dim dateApo, dateMexri As DateTime


        For j = ImeromPlirotDwm.Value.Month To 12
            If j < 10 Then
                protiString = "01/0" + j.ToString + "/" + ImeromPlirotDwm.Value.Year.ToString
            Else
                protiString = "01/" + j.ToString + "/" + ImeromPlirotDwm.Value.Year.ToString
            End If


            If Not DateTime.TryParse(protiString, dateApo) Then
                Throw New ArgumentException("Unable to parse date")
            End If
            ' MsgBox("APO " + dateApo.ToString)
            dateMexri = dateApo.AddDays(DateTime.DaysInMonth(dateApo.Year, dateApo.Month) - 1)
            ' MsgBox(dateMexri.ToString("dd/MM/yyy"))
            Try
                ektiposi_plirotita_dwmatiwn(dateApo, dateMexri, 0, dwmatia.Length - 1)
            Catch ex As NullReferenceException
                MsgBox("Παρουσιάστηκε πρόβλημα. Επιλέξτε αρχικά εμφάνιση!", MsgBoxStyle.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try



            Me.DbhotelDataSet.ekt_status_ekdosi.Clear()
            Me.DbhotelDataSet.ekt_status_ekdosi.Rows.Add()
            Me.DbhotelDataSet.ekt_status_ekdosi(0).ekdosi = imeromErgasias
            Me.DbhotelDataSet.ekt_status_ekdosi(0).arxi = dateApo.Date

            'Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
            sender.Enabled = False
            ektiposi.SetDataSource(DbhotelDataSet)

            System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
            filename = "c:\winfo\" + MonthName(dateApo.Month) + ".xls"

            Try
                ektiposi.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, filename)
            Catch ex As System.IO.DirectoryNotFoundException
                MsgBox("Δεν βρέθηκε ο φάκελος προσωρινής αποθήκευσης", MsgBoxStyle.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try




            System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
            counter = counter + 1
            ReDim Preserve attachment(counter - 1)
            attachment(counter - 1) = filename

            CrystalReportViewer1.ReportSource = ektiposi
            CrystalReportViewer1.DisplayGroupTree = False
            'CrystalReportViewer1.DisplayGroupTree = False
            'Form1.Controls.Add(CrystalReportViewer1)
            'CrystalReportViewer1.Dock = DockStyle.Fill
            'CrystalReportViewer1.Visible = True
        Next

        Try
            If (attachment IsNot Nothing AndAlso attachment.Count > 0) Then
                Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
                mailadapter.Fill(Me.DbhotelDataSet.Mail)
                Dim theThread _
      As New Threading.Thread(AddressOf SendMailPlirotitaDwm)
                theThread.Start(attachment)
                threadList.Add(theThread)
                '     SendMailPlirotitaDwm(attachment)

                For Each theThread In threadList
                    theThread.Join()
                Next
                theThread.Abort()
                SendMialBtn.Enabled = True
                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.Default
            End If
        Catch ex As NullReferenceException
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Public Sub SendMailPlirotitaDwm(ByVal attachment As String())
        Dim j As Int16
        Dim instanceList As List(Of Attachment) = New List(Of Attachment)
        '    ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String, ByVal attach As String
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        'Dim instance As New Attachment(fileName)
        'MsgBox(Me.DbhotelDataSet.etaireia.Count)
        Dim message As New MailMessage(Me.DbhotelDataSet.Mail(0).ffrom, Me.DbhotelDataSet.etaireia(0).tilefono, "ΠΛΑΝΟ URBAN", "") ' 
        message.To.Add("stakap15@gmail.com")
        For j = 0 To attachment.Length - 1

            Dim instance As New Attachment(attachment(j))
            message.Attachments.Add(instance)
            instanceList.Add(instance)
            ' instance.Dispose()
        Next


        'message.Attachments.Add(instance)

        Dim smtpClient As New SmtpClient(Me.DbhotelDataSet.Mail(0).smtpServer, 25)

        smtpClient.UseDefaultCredentials = False

        Dim credentials As New NetworkCredential(Me.DbhotelDataSet.Mail(0).smtpUsername, Me.DbhotelDataSet.Mail(0).smtpPassword)

        smtpClient.Credentials = credentials
        smtpClient.EnableSsl = True
        smtpClient.Send(message)
        For Each item As Attachment In instanceList
            item.Dispose()
        Next
        'For Each prog As Process In Process.GetProcesses
        '    MsgBox(prog.ProcessName)
        '      prog.Kill()
        'Next
    End Sub
    'Private Sub frm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    '    Me.TopMost = True
    'End Sub
    'Private Sub frm_deActivated(sender As Object, e As EventArgs) Handles Me.Deactivate

    '    Me.TopMost = False
    'End Sub


    Private Sub PlirotitaXenodFrm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = False

    End Sub

  
End Class