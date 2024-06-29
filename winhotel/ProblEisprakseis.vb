Imports System.Configuration
Imports System.Data.SqlClient
Public Class ProblEisprakseis
    Dim dwmTable As DataTable = New DataTable("dwmatia")
    Dim afmadapter As New dbhotelDataSet1TableAdapters.afmTableAdapter
    Dim kwdParastAfm As Integer

    Dim imeromErgasias As Date


    Dim roomMap As New Dictionary(Of String, Single?)
    Private Sub ParastCbx_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParastCbx.SelectedIndexChanged
        If sender.selectedIndex < 1 Then
            kwdParastAfm = -1
        Else
            kwdParastAfm = Me.DbhotelDataSet1.afm(sender.selectedINdex - 1).kwd
        End If

    End Sub
    Private Sub apoPck_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apoPck.Leave
        mexriPck.Value = apoPck.Value.AddDays(1)
    End Sub
    Private Sub fuehle_parast_cbx()
        Dim j As Int16
        ParastCbx.Items.Clear()

        For j = 0 To Me.DbhotelDataSet1.afm.Count
            If j = 0 Then
                ParastCbx.Items.Add("<όλες εταιρείες>")

            Else
                'If Me.DbhotelDataSet1.afm(j - 1).kwd <> 4 Then
                ParastCbx.Items.Add(Me.DbhotelDataSet1.afm(j - 1)._alias)
                '    Else
                '    MsgBox("alias")
                'End If

            End If

        Next
    End Sub
    Private Sub ProblEisprBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProblEisprBtn.Click
        Dim esodaSumsum As Single
        Dim daysSumsum As Int16
        Me.DbhotelDataSet.EsodaProbepsi.Clear()
        Me.DbhotelDataSet.ektiposeis_genika.Clear()
        If ist_pwd_ok(Trim(pswdTbx.Text)) Then
            If VilesRdb.Checked Then
                Me.KratiseisTableAdapter.FillProblepsiEispakseisDwmByEtosAnaxAfixi(Me.DbhotelDataSet.kratiseis, apoPck.Value.Date, mexriPck.Value.Date, 99)

                berechne_esoda_viles(esodaSumsum, daysSumsum)
            ElseIf ThalassRdb.Checked Then
                Me.KratiseisTableAdapter.FillProblepseisByTipos(Me.DbhotelDataSet.kratiseis, apoPck.Value.Date, mexriPck.Value.Date, 10, 99)
                berechne_esoda_viles(esodaSumsum, daysSumsum)
            ElseIf UrbanRdb.Checked Then
                Me.KratiseisTableAdapter.FillProblepseisByTipos(Me.DbhotelDataSet.kratiseis, apoPck.Value.Date, mexriPck.Value.Date, 11, 99)
                berechne_esoda_viles(esodaSumsum, daysSumsum)

            Else
                Dim praktAdapter As New dbhotelDataSetTableAdapters.praktoreiaTableAdapter
                praktAdapter.Fill(Me.DbhotelDataSet.praktoreia)
                Me.KratiseisTableAdapter.FillProblepsiEispPraktByEtosAnaxAfix(Me.DbhotelDataSet.kratiseis, apoPck.Value.Date, mexriPck.Value.Date, 99)
                berechne_esoda_prakt(esodaSumsum, daysSumsum)
            End If
            ektiposi_problepsis(esodaSumsum, daysSumsum)
        Else
            MsgBox("No Entry!", MsgBoxStyle.Exclamation)

        End If


    End Sub

    Private Sub berechne_esoda_viles(ByRef esodaSumsum As Single, ByRef daysSumsum As Int16)
        Dim startIndex, countIndex As Int16
        Dim esodaSum As Single = 0
        Dim daysSum As Int16 = 0
        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.kratiseis.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.kratiseis.Count - 1 Then
                While Me.DbhotelDataSet.kratiseis(startIndex).dwmatio = Me.DbhotelDataSet.kratiseis(startIndex + countIndex).dwmatio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.kratiseis.Count - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)

                berechne_esoda_etous_vilas(1, startIndex, countIndex, esodaSum, daysSum)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_esoda_etous_vilas(1, startIndex, countIndex, esodaSum, daysSum)
                Exit Do
            End If
        Loop
        'Return esodaSum
        esodaSumsum = esodaSumsum + esodaSum
        daysSumsum = daysSumsum + daysSum
    End Sub
    Private Function berechne_esoda_prakt(ByRef esodaSumsum As Single, ByRef daysSumsum As Int16) As Single
        Dim startIndex, countIndex As Int16
        Dim esodaSum As Single = 0
        Dim daysSum As Int16 = 0
        ' startIndex = 0 'apo pio entrag sto dataset
        Do Until startIndex > Me.DbhotelDataSet.kratiseis.Count - 1
            countIndex = 1 'posa eintraege 

            If startIndex < Me.DbhotelDataSet.kratiseis.Count - 1 Then
                While Me.DbhotelDataSet.kratiseis(startIndex).praktimologio = Me.DbhotelDataSet.kratiseis(startIndex + countIndex).praktimologio

                    countIndex += 1
                    If startIndex + countIndex > Me.DbhotelDataSet.kratiseis.Count - 1 Then
                        Exit While
                    End If
                End While
                'MsgBox(countIndex)
                berechne_esoda_etous_vilas(2, startIndex, countIndex, esodaSum, daysSum)
                startIndex = startIndex + countIndex
            Else 'teleutaio i prwto  record->(macht fehler bei while abfrage)
                'MsgBox(countIndex)
                berechne_esoda_etous_vilas(2, startIndex, countIndex, esodaSum, daysSum)
                Exit Do
            End If
        Loop

        esodaSumsum = esodaSumsum + esodaSum
        daysSumsum = daysSumsum + daysSum
    End Function

    Private Function berechne_esoda_etous_vilas(ByVal index As Byte, ByVal datasetIndex As Int16, ByVal countIndex As Int16, ByRef esodaSum As Single, ByRef daysSum As Int16) As Single
        Dim startIndex, imeresOut, imeresPr As Int16
        Dim esodaOut, esodaPr, pososto, posostoTemp As Single
        Dim roomPososto As Single? ' pososto Staurou
        Dim room As String
        If index = 1 Then 'vila
            pososto = ist_vila_epinoikOK(Me.DbhotelDataSet.kratiseis(datasetIndex).dwmatio)
        End If

        imeresOut = 0
        esodaOut = 0
        imeresPr = 0
        esodaPr = 0
        startIndex = datasetIndex

        Do Until startIndex > (datasetIndex + countIndex - 1)
            posostoTemp = 0
            If kwdParastAfm = -1 OrElse ist_villa_etaireias(Me.DbhotelDataSet.kratiseis(startIndex).dwmatio) Then
                If Me.DbhotelDataSet.kratiseis(startIndex).checkout Then
                    'imeresOut = imeresOut + (Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(startIndex).afixi.DayOfYear)
                    imeresOut = imeresOut + (Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.Subtract(Me.DbhotelDataSet.kratiseis(startIndex).afixi).TotalDays)
                    If domisichk.Checked Then
                        If index = 1 Then
                            If pososto = -1 Then
                                'roomCode As Single? ' declare roomCode as nullable Single
                                room = Me.DbhotelDataSet.kratiseis(datasetIndex).dwmatio ' set the key to look up in the dictionary
                                If roomMap.TryGetValue(room, roomPososto) Then
                                    ' The key exists, so roomCode has a value
                                    If roomPososto.HasValue Then
                                        esodaOut = esodaOut + roomPososto * (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                        ' ...
                                    Else
                                        esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                    End If
                                Else
                                    ' The key does not exist, so roomCode is null
                                    esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                End If

                            Else
                                posostoTemp = pososto - get_pososto_praktoreiou(Me.DbhotelDataSet.kratiseis(startIndex).praktimologio)
                                esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo) * posostoTemp / 100
                            End If
                        ElseIf index = 2 Then
                            pososto = ist_vila_epinoikOK(Me.DbhotelDataSet.kratiseis(startIndex).dwmatio)
                            If pososto = -1 Then
                                esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                            Else
                                posostoTemp = pososto - get_pososto_praktoreiou(Me.DbhotelDataSet.kratiseis(startIndex).praktimologio)
                                esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo) * posostoTemp / 100
                            End If
                        End If
                    Else
                        esodaOut = esodaOut + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                    End If

                Else
                    If Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.DayOfYear <> 1 Then
                        'Dim days As Integer
                        'days = Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.Subtract(Me.DbhotelDataSet.kratiseis(startIndex).afixi).TotalDays
                        'imeresPr = imeresPr + (Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.DayOfYear - Me.DbhotelDataSet.kratiseis(startIndex).afixi.DayOfYear)
                        imeresPr = imeresPr + Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.Subtract(Me.DbhotelDataSet.kratiseis(startIndex).afixi).TotalDays
                    Else
                        imeresPr = imeresPr + (Me.DbhotelDataSet.kratiseis(startIndex).anaxwrisi.AddDays(-1).DayOfYear + 1 - Me.DbhotelDataSet.kratiseis(startIndex).afixi.DayOfYear)

                    End If

                    If domisichk.Checked Then
                        If index = 1 Then
                            If pososto = -1 Then
                                room = Me.DbhotelDataSet.kratiseis(datasetIndex).dwmatio ' set the key to look up in the dictionary
                                If roomMap.TryGetValue(room, roomPososto) Then
                                    ' The key exists, so roomCode has a value
                                    If roomPososto.HasValue Then
                                        'esodaOut = esodaOut + roomPososto * Me.DbhotelDataSet.kratiseis(startIndex).synolo
                                        esodaPr = esodaPr + roomPososto * (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                    Else
                                        esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                    End If
                                Else
                                    ' The key does not exist, so roomCode is null
                                    esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                End If
                                'esodaPr = esodaPr + Me.DbhotelDataSet.kratiseis(startIndex).synolo
                            Else
                                posostoTemp = pososto - get_pososto_praktoreiou(Me.DbhotelDataSet.kratiseis(startIndex).praktimologio)
                                esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo) * posostoTemp / 100
                            End If
                        ElseIf index = 2 Then
                            pososto = ist_vila_epinoikOK(Me.DbhotelDataSet.kratiseis(startIndex).dwmatio)
                            If pososto = -1 Then
                                room = Me.DbhotelDataSet.kratiseis(datasetIndex).dwmatio ' set the key to look up in the dictionary
                                If roomMap.TryGetValue(room, roomPososto) Then
                                    ' The key exists, so roomCode has a value
                                    If roomPososto.HasValue Then

                                        esodaPr = esodaPr + roomPososto * (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                        'esodaPr = esodaPr + Me.DbhotelDataSet.kratiseis(startIndex).synolo
                                    Else
                                        esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                        'esodaPr = esodaPr + Me.DbhotelDataSet.kratiseis(startIndex).synolo
                                    End If
                                Else
                                    ' The key does not exist, so roomCode is null
                                    esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                                    'esodaPr = esodaPr + Me.DbhotelDataSet.kratiseis(startIndex).synolo
                                End If



                                'esodaPr = esodaPr + Me.DbhotelDataSet.kratiseis(startIndex).synolo
                            Else
                                posostoTemp = pososto - get_pososto_praktoreiou(Me.DbhotelDataSet.kratiseis(startIndex).praktimologio)
                                esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo) * posostoTemp / 100
                            End If
                        End If
                    Else
                        esodaPr = esodaPr + (Me.DbhotelDataSet.kratiseis(startIndex).synolo)
                    End If
                End If
            End If


            startIndex += 1
        Loop
        If esodaOut <> 0 Or imeresOut <> 0 Or esodaPr <> 0 Or imeresPr <> 0 Then
            Me.DbhotelDataSet.EsodaProbepsi.Rows.Add()
            If index = 1 Then
                Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).dwmprakt = Me.DbhotelDataSet.kratiseis(datasetIndex).dwmatio
            Else
                Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).dwmprakt = get_onoma_praktoreiou(Me.DbhotelDataSet.kratiseis(datasetIndex).praktimologio)
            End If

            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda1 = esodaOut
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeres1 = imeresOut
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda2 = esodaPr
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeres2 = imeresPr
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esodaSum = esodaPr + esodaOut
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeresSum = imeresPr + imeresOut
        End If

        esodaSum = esodaSum + esodaPr + esodaOut
        daysSum = daysSum + imeresPr + imeresOut
    End Function

    Private Function get_onoma_praktoreiou(ByVal kwd As Integer) As String
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.praktoreia.Count - 1
            If kwd = Me.DbhotelDataSet.praktoreia(j).kwd Then
                Return Me.DbhotelDataSet.praktoreia(j).eponimia
            End If
        Next
        Return ""
    End Function
    Private Sub sortiere_problepisis()
        Dim sortExp As String = "esodaSum DESC"
        Dim drarray() As DataRow
        Dim i As Integer

        drarray = Me.DbhotelDataSet.EsodaProbepsi.Select(Nothing, sortExp)

        Dim datatable As New dbhotelDataSet.EsodaProbepsiDataTable
        For i = 0 To (drarray.Length - 1)
            datatable.Rows.Add()
            Try
                datatable(datatable.Count - 1).dwmprakt = drarray(i)("dwmprakt")
            Catch ex As InvalidCastException
                datatable(datatable.Count - 1).dwmprakt = ""
            End Try

            datatable(datatable.Count - 1).esoda1 = drarray(i)("esoda1")
            datatable(datatable.Count - 1).imeres1 = drarray(i)("imeres1")
            datatable(datatable.Count - 1).esoda2 = drarray(i)("esoda2")
            datatable(datatable.Count - 1).imeres2 = drarray(i)("imeres2")
            datatable(datatable.Count - 1).esodaSum = drarray(i)("esodaSum")
            datatable(datatable.Count - 1).imeresSum = drarray(i)("imeresSum")
        Next
        Me.DbhotelDataSet.EsodaProbepsi.Clear()
        For i = 0 To datatable.Count - 1
            Me.DbhotelDataSet.EsodaProbepsi.Rows.Add()
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).dwmprakt = datatable(i).dwmprakt
            'If datatable(i).dwmprakt.Equals("MAVI") Then
            '    Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda1 = datatable(i).esoda1 / 2
            '    Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda2 = datatable(i).esoda2 / 2
            '    Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esodaSum = datatable(i).esodaSum / 2
            '    'Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).dwmprakt = "MAVI"
            'Else
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda1 = datatable(i).esoda1
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda2 = datatable(i).esoda2
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esodaSum = datatable(i).esodaSum
            'End If
            '  Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda1 = datatable(i).esoda1
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeres1 = datatable(i).imeres1
            '   Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esoda2 = datatable(i).esoda2
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeres2 = datatable(i).imeres2
            '  Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).esodaSum = datatable(i).esodaSum
            Me.DbhotelDataSet.EsodaProbepsi(Me.DbhotelDataSet.EsodaProbepsi.Count - 1).imeresSum = datatable(i).imeresSum
        Next
    End Sub
    Private Sub ektiposi_problepsis(ByVal esodaSumsum As Single, ByVal daysSumsum As Int16)
        'Dim epixeirisi As String
        Dim Form1 As New EktiposeisFrm()
        Dim ektiposi As New ProblEsodaDwmPrakt()
        Dim cryRpt As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        'MsgBox(Me.DbhotelDataSet.ekt_analkin_logistirio.Count)
        Me.DbhotelDataSet.ektiposeis_genika.Rows.Add()
        Me.DbhotelDataSet.ektiposeis_genika(0).poso = esodaSumsum
        Me.DbhotelDataSet.ektiposeis_genika(0).etos = daysSumsum
        If kwdParastAfm <> -1 Then
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = get_onoma_etaireia(kwdParastAfm)
        Else
            Me.DbhotelDataSet.ektiposeis_genika(0).perigrafi = "Όλες οι Εταιρείες"
        End If
        sortiere_problepisis()
        If VilesRdb.Checked Then
            Me.DbhotelDataSet.ektiposeis_genika(0).flag = 1
        Else
            Me.DbhotelDataSet.ektiposeis_genika(0).flag = 2
        End If
        Me.DbhotelDataSet.ektiposeis_genika(0).ekdosi = imeromErgasias
        Me.DbhotelDataSet.ektiposeis_genika(0).imerominia = apoPck.Value.Date
        Me.DbhotelDataSet.ektiposeis_genika(0).imerominia2 = mexriPck.Value.Date
        ektiposi.SetDataSource(DbhotelDataSet)
        cryRpt.DisplayGroupTree = False

        cryRpt.ReportSource = ektiposi
        Form1.Controls.Add(cryRpt)
        cryRpt.Dock = DockStyle.Fill
        cryRpt.Visible = True

        Form1.ShowDialog()

        ektiposi.Close()
        ektiposi.Dispose()
        cryRpt.Visible = False
        'Dim BindingSource1 As New BindingSource
        'BindingSource1.DataSource = Me.DbhotelDataSet.ekt_prakt_imer_kinisi
        ''BindingSource1.Filter = "xrewsi=0"
        'BindingSource1.Sort = "imerominia ASC"
        'DataGridView1.DataSource = BindingSource1
    End Sub

    Public Sub New(ByVal datum As Date)
        Dim prok As Single
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        kwdParastAfm = -1
        Dim rechteAdapter As New dbhotelDataSetTableAdapters.rechteTableAdapter
        rechteAdapter.Fill(Me.DbhotelDataSet.rechte)
        Dim praktAdapter As New dbhotelDataSetTableAdapters.praktoreiaTableAdapter
        praktAdapter.Fill(Me.DbhotelDataSet.praktoreia)
        Dim epinoikAdapter As New dbhotelDataSetTableAdapters.epinoikiasiTableAdapter
        epinoikAdapter.Fill(Me.DbhotelDataSet.epinoikiasi)

        afmadapter.FillByOhneVirtual(Me.DbhotelDataSet1.afm)
        Dim etaireiaAdapter As New dbhotelDataSetTableAdapters.etaireiaTableAdapter
        etaireiaAdapter.Fill(Me.DbhotelDataSet.etaireia)

        roomMap.Add("MAVI", 0.5)
        'roomMap.Add("SKANT", 0)
        roomMap.Add("THET", 0)
        'roomMap.Add("THEROS", 0)
        'Dim roomCode As Single? ' declare roomCode as nullable Single
        'Dim room As String = "zscdc" ' set the key to look up in the dictionary
        'If roomMap.TryGetValue(room, roomCode) Then
        '    ' The key exists, so roomCode has a value
        '    If roomCode.HasValue Then
        '        ' roomCode has a value, so you can use it
        '        ' ...
        '    Else
        '        ' roomCode is null, so you can handle the null case here
        '        ' ...
        '    End If
        'Else
        '    ' The key does not exist, so roomCode is null
        '    ' ...
        'End If


        dwmTable.Columns.Add("villa", Type.GetType("System.String"))
        dwmTable.Columns.Add("etaireia", System.Type.GetType("System.Int32"))

        Using connection As New SqlConnection(ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString)
            Dim command As New SqlCommand()
            Dim myReader As SqlDataReader
            Try
                connection.Open()
                command.Connection = connection
                command.CommandText = "SELECT arithmos, afm FROM dwmatia" '   where (aa=?) and (imerominia>=?) and (imerominia<=?) and (parastatiko=?)
                myReader = command.ExecuteReader()
                ' Always call Read before accessing data.
                While myReader.Read()
                    dwmTable.Rows.Add(myReader.GetString(0), myReader.GetInt32(1))
                    'Dim Row1 As DataRow
                    'Row1 = dwmTable.NewRow()

                    'Row1.Item("villa") = myReader.GetString(0)
                    'Row1.Item("etaireia") = myReader.GetInt32(0)
                    'dwmTable.Rows.Add(Row1)

                End While
                ' always call Close when done reading.
                myReader.Close()

            Catch ex As Exception

            End Try
        End Using
        imeromErgasias = datum
        ' Add any initialization after the InitializeComponent() call.
        apoPck.Value = "1/1/" + imeromErgasias.Year.ToString
        mexriPck.Value = "31/12/" + imeromErgasias.Year.ToString
        fuehle_parast_cbx()

        prok = Me.KratiseisTableAdapter.SumProkatabolesDomisi()
        Me.Prokataboles.Text = "(ατιμολόγητες προκ/βολές: " + prok.ToString("N2") + ")"
    End Sub
    Private Function ist_villa_etaireias(ByVal dwm As String) As Boolean
        Dim j As Int16
        For j = 0 To dwmTable.Rows.Count - 1
            'MsgBox(dwmTable.Rows(j).Item(0))
            If dwmTable.Rows(j).Item(0) = dwm Then
                If dwmTable.Rows(j).Item(1) = kwdParastAfm Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return False
    End Function
    Private Function get_onoma_etaireia(ByVal kwd As Integer) As String
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet1.afm.Count - 1
            If Me.DbhotelDataSet1.afm(j).kwd = kwd Then
                Return Me.DbhotelDataSet1.afm(j)._alias
            End If
        Next
        Return ""
    End Function

    Private Function ist_pwd_ok(ByVal pswd As String) As Boolean
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.rechte.Count - 1
            If Me.DbhotelDataSet.rechte(j).password.Equals(pswd) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function get_pososto_praktoreiou(ByVal kwd As Integer) As Single
        Dim drarray() As DataRow

        Dim filtExpr As String = "kwd=" + kwd.ToString
        drarray = Me.DbhotelDataSet.praktoreia.Select(filtExpr)
        If drarray.Length = 1 Then
            Return drarray(0)("telex")
        End If
        Return -1
    End Function
    Private Function ist_vila_epinoikOK(ByVal vila As String) As Single
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.epinoikiasi.Count - 1
            If Me.DbhotelDataSet.epinoikiasi(j).vila.Equals(vila) Then
                Return Me.DbhotelDataSet.epinoikiasi(j).pososto
            End If
        Next
        Return -1
    End Function


End Class