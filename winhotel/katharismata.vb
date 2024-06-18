Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop

Public Class katharismata
    Dim connectionString As String
    Dim dateIDiff As Int16
    Dim imeromErgasias As Date
    Dim datumApo, datumMexri As Date
    Dim path As String
    Dim firstC, lastC, resultC, wresF, wresL, sentonEbdom As Int16
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    'Dim engCult As New System.Globalization.CultureInfo("en-US", False)
    'Dim grCult As New System.Globalization.CultureInfo("el", False)
    Structure zelle
        Dim month As Int16
        Dim day As Int16
    End Structure

    Structure thal
        Dim prufsum As Single
        Dim eean As Single
        Dim mail As Single
        Dim pers As Single
        Dim thoi As Single
        Dim pue As Single
        Dim mavi As Single
    End Structure

    Dim thalasses() As thal
    Structure changed
        Dim column As Int16
        Dim old As Date
        Dim neu As Date
    End Structure
    Dim changes() As changed
    Structure kathviles
        Dim wresvila As Single()
    End Structure
    Structure geo1
        Dim prufsum As Single
        Dim iper As Single
        Dim ikr As Single
        Dim afr As Single
        Dim eos As Single
    End Structure
    Dim geomada1() As geo1

    'Structure geo2
    '    Dim prufsum As Single
    '    Dim mic As Single
    '    Dim ale As Single
    'End Structure
    'Dim geomada2() As geo2


    'alaksa sf6 me arch stiw 3/5/2022
    Structure geo3
        Dim prufsum As Single
        Dim arch As Single
        Dim iri As Single
    End Structure
    Dim geomada3() As geo3
    Dim geomada8() As geo8
    Structure geo8
        Dim prufsum As Single
        Dim ub1c As Single
        Dim ub2c As Single
        Dim ub4c As Single
        Dim ub1y As Single
        Dim ub3c As Single
        Dim ub1d As Single
        Dim ub3d As Single
        Dim blue As Single
        Dim gry As Single
        Dim gre As Single
        Dim red As Single
        Dim whi As Single
        Dim san As Single
        Dim coc As Single
        Dim yell As Single
        Dim ora As Single
        Dim purpl As Single
        Dim brown As Single
        Dim rea01 As Single
        Dim rea02 As Single
        Dim rea11 As Single
        Dim rea12 As Single
        Dim rea21 As Single
        Dim rea22 As Single
        Dim rea31 As Single
        Dim rea32 As Single
        Dim rea41 As Single
        Dim rea42 As Single

    End Structure
    'kyriana
    'Dim geomada4() As Int16
    Dim anzkath() As Int16
    Dim freietagekath1() As Byte
    Dim kratBdomHotel(6) As Int16
    Private Sub add_combos()
        HomeDayCbx.Items.Add("Κυρ")
        HomeDayCbx.Items.Add("Δευ")
        HomeDayCbx.Items.Add("Τρι")
        HomeDayCbx.Items.Add("Τετ")
        HomeDayCbx.Items.Add("Πεμ")
        HomeDayCbx.Items.Add("Παρ")
        HomeDayCbx.Items.Add("Σαβ")

        GrafeioForesCbx.Items.Add("0")
        GrafeioForesCbx.Items.Add("1")
        GrafeioForesCbx.Items.Add("2")



    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles planoBtn.Click
        Dim workSheet, freietage_kath1, homeDay, grafDay, thirdDay, fourDay As Int16 'minas apo apr kai meta 
        'Start a new workbook in Excel.

        ProgressBar1.Value = ProgressBar1.Minimum
        ProgressBar1.Value += 40
        System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
        datumApo = FirstDateMonthPck.Value

        'datumApo = get_monday_date_of_next_week()
        'FirstDateMonthPck.Value = datumApo
        Try
            datumMexri = "31/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
            'mexriDPck.Value = datumMexri
        Catch ex As InvalidCastException
            Try
                datumMexri = "30/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
            Catch ex1 As Exception
                datumMexri = "28/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
            End Try

        End Try
        dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
        workSheet = FirstDateMonthPck.Value.Month ' - 3 ' anagogi giati ksekinaw apo Aprilio
        Me.DbhotelDataSet.praktoreia.Constraints.Clear()
        'Me.KatharismataTableAdapter.FillKatharismataByApoMexri(Me.DbhotelDataSet.katharismata, datumApo, datumMexri)



        Me.KatharismataTableAdapter.FillKatharEbdomadas(Me.DbhotelDataSet.katharismata, mexriDPck.Value, FirstDateMonthPck.Value)
        ProgressBar1.Value += 10
        'Return

        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Try

            oExcel = CreateObject("Excel.Application")
            '    oBook = oExcel.Workbooks.Open(path)
            oBook = oExcel.Workbooks.Open(path, Type.Missing, False, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, True, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing)
            'oBook = oExcel.Workbooks.Open(path, ReadOnly:=False, Editable:=True, IgnoreReadOnlyRecommended:=True, CorruptLoad:=Excel.XlCorruptLoad.xlExtractData)
            oSheet = oBook.Worksheets



            Me.Cursor = Cursors.WaitCursor
            'MsgBox(get_home_date_of_next_week())
            sentonEbdom = 0
            make_katharismata(workSheet, oExcel, oBook, oSheet)

            'MsgBox(sentonEbdom)
            ReDim thalasses(-1)
            make_thalasses(workSheet, oExcel, oBook, oSheet)

            ReDim geomada1(-1)
            make_geo1(workSheet, oExcel, oBook, oSheet)
            'ReDim geomada2(-1)
            'make_geo2(workSheet, oExcel, oBook, oSheet)
            ReDim geomada3(-1)
            make_geo3(workSheet, oExcel, oBook, oSheet)
            ProgressBar1.Value += 10
            ReDim geomada8(-1)
            make_geo8(workSheet, oExcel, oBook, oSheet)
            ProgressBar1.Value += 10

            'edw apenergopoihsa xenod 4 grammes
            'kratBdomHotel = kratiseis_bdomadas_hotel(connectionString, datumApo, 1)
            'make_old_town(workSheet, oExcel, oBook, oSheet, kratBdomHotel, 27)
            'kratBdomHotel = kratiseis_bdomadas_hotel(connectionString, datumApo, 2)
            'make_old_town(workSheet, oExcel, oBook, oSheet, kratBdomHotel, 28)
            ProgressBar1.Value += 10
            ' poses katharisrties xreiazomai synolika ana mera sto xenodoxeiako komati 
            berechne_anzkath_periodou()



            ' Day einai i thesi stio array
            homeDay = get_home_date_of_next_week()
            grafDay = find_next_best_day_kath_1(homeDay, -1, -1)
            thirdDay = find_next_best_day_kath_1(homeDay, grafDay, -1)
            fourDay = find_next_best_day_kath_1(homeDay, grafDay, thirdDay)
            'poses free days exei i katharistria 1...gia na dw pote tha tin balw na kanei tis exoxenodoxeiakes douleies 
            freietage_kath1 = rechne_frei_tage_katharistria_1()


            'If freietage_kath1 = 0 Then
            '    'homeDay = find_next_best_day_kath_1(-1, -1, -1, -1)
            '    grafDay = find_next_best_day_kath_1(homeDay, -1, -1, -1)
            '    thirdDay = find_next_best_day_kath_1(homeDay, grafDay, -1, -1)
            '    fourDay = find_next_best_day_kath_1(homeDay, grafDay, thirdDay, -1)
            '    'zu_ordne_katharisties_u_rechne_sentonia(workSheet, oExcel, oBook, oSheet, homeDay, grafDay, thirdDay, fourDay)
            'ElseIf freietage_kath1 = 1 Then
            '    'homeDay = find_next_best_day_kath_1(-1, -1, -1, -1)
            '    grafDay = find_next_best_day_kath_1(homeDay, -1, -1, -1)
            '    thirdDay = find_next_best_day_kath_1(homeDay, grafDay, -1, -1)
            '    'zu_ordne_katharisties_u_rechne_sentonia(workSheet, oExcel, oBook, oSheet, homeDay, grafDay, thirdDay, -1)
            'ElseIf freietage_kath1 = 2 Then
            '    'homeDay = find_next_best_day_kath_1(-1, -1, -1, -1)
            '    grafDay = find_next_best_day_kath_1(homeDay, -1, -1, -1)
            '    'zu_ordne_katharisties_u_rechne_sentonia(workSheet, oExcel, oBook, oSheet, homeDay, grafDay, -1, -1)
            '    'ElseIf freietage_kath1 = 3 Then
            '    '    'homeDay = find_next_best_day_kath_1(-1, -1, -1, -1)
            '    '    zu_ordne_katharisties_u_rechne_sentonia(workSheet, oExcel, oBook, oSheet, homeDay, -1, -1, -1)
            'End If

            Me.KatharismataTableAdapter.FillSentonia(Me.DbhotelDataSet.katharismata)
            make_rest_plano(workSheet, oExcel, oBook, oSheet, homeDay, grafDay, thirdDay, fourDay)

            zu_ordne_katharisties_u_rechne_sentonia(workSheet, oExcel, oBook, oSheet, homeDay, grafDay, thirdDay, fourDay)

            oExcel.Quit()
        Catch ex As Runtime.InteropServices.COMException
            Me.Cursor = Cursors.Default
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            'MsgBox(ex)
            oExcel.Quit()
            Exit Sub
        Catch ex1 As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
            oExcel.Quit()
        End Try

        Me.Cursor = Cursors.Default
        ProgressBar1.Value = ProgressBar1.Maximum
        'For j = 1 To 31
        'datum = j.ToString + "/12/2014"
        'oSheet(9).Cells(j + 1, 1).value = datum
        'Next
    End Sub

    'Private Sub make_kyriana(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
    '    Dim i, length As Int16
    '    Dim cell As zelle
    '    length = 0
    '    Me.DbhotelDataSet.katharismata.Clear()

    '    ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
    '    Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 5)

    '    For i = 0 To dateIDiff
    '        cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
    '        ReDim Preserve geomada4(length)
    '        If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(0).excelcolumn).value = "") Then
    '            geomada4(length) = sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(0).excelcolumn).value.Substring(9, 1)
    '        Else
    '            geomada4(length) = 0
    '        End If
    '        length += 1
    '    Next
    'End Sub
    Private Sub make_geo3(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
        Dim j, i, length As Int16
        Dim cell As zelle
        Dim inhalt, range As String

        length = 0
        Me.DbhotelDataSet.katharismata.Clear()

        ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
        Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 4)
        'dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
        For i = 0 To dateIDiff
            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
            Dim newGeo3 As New geo3
            For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
                If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value = "") Then
                    Select Case j
                        Case 0
                            newGeo3.arch = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo3.prufsum = newGeo3.prufsum + newGeo3.arch
                        Case 1
                            newGeo3.iri = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo3.prufsum = newGeo3.prufsum + newGeo3.iri
                    End Select
                Else
                    Select Case j
                        Case 0
                            newGeo3.arch = 0
                        Case 1
                            newGeo3.iri = 0
                    End Select
                End If
            Next
            ReDim Preserve geomada3(length)
            geomada3(length) = newGeo3
            length += 1

        Next

        'Meta koitw sta elements sto array kai elegxw ean to prufsum > 8 
        'opou brw prospathw na to diorthosw metakinontas arxika tis Allages A kai meta ta Katharismata K
        ' apothikebv tis allages sto changes()

        ReDim changes(-1)
        length = 0
        For i = 0 To geomada3.Length - 1
            If geomada3(i).prufsum > 8 Then
                cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
                'MsgBox((sheet(cell.month).Cells(cell.day, get_column_vila_thalase("eean")).value))
                If Not sheet(cell.month).Cells(cell.day, get_column_vila("arch")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("arch")).value.contains("A")) _
                    AndAlso geomada3(i).prufsum - geomada3(i).arch <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("arch")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).arch
                    If i > 0 Then
                        geomada3(i - 1).prufsum = geomada3(i - 1).prufsum + geomada3(i).arch
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("iri")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("iri")).value.contains("A")) _
                    AndAlso geomada3(i).prufsum - geomada3(i).iri <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("iri")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).iri
                    If i > 0 Then
                        geomada3(i - 1).prufsum = geomada3(i - 1).prufsum + geomada3(i).iri
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("arch")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("arch")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("arch")).value.contains("D")) _
                 AndAlso geomada3(i).prufsum - geomada3(i).arch <= 8 Then

                    If Not Me.StatusTableAdapter.ExistStatusByDwmImerom("arch", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("arch")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).arch
                        If i < geomada3.Length - 1 Then
                            geomada3(i + 1).prufsum = geomada3(i + 1).prufsum + geomada3(i).arch
                        End If

                    Else ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("arch")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).arch
                        If i > 0 Then
                            geomada3(i - 1).prufsum = geomada3(i - 1).prufsum + geomada3(i).arch
                        End If
                    End If

                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("iri")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("iri")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("iri")).value.contains("D")) _
                    AndAlso geomada3(i).prufsum - geomada3(i).iri <= 8 Then

                    If Not Me.StatusTableAdapter.ExistStatusByDwmImerom("iri", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("iri")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).iri
                        If i < geomada3.Length - 1 Then
                            geomada3(i + 1).prufsum = geomada3(i + 1).prufsum + geomada3(i).iri
                        End If

                    Else
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("iri")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada3(i).prufsum = geomada3(i).prufsum - geomada3(i).iri
                        If i > 0 Then
                            geomada3(i - 1).prufsum = geomada3(i - 1).prufsum + geomada3(i).iri
                        End If
                    End If


                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("Πρόβλημα με καθαρίσματα geomada3 (arch,iri) στις " + FirstDateMonthPck.Value.AddDays(i).ToString("dd-MM-yyyy"), MsgBoxStyle.Exclamation)
                End If
            End If
        Next

        For j = 0 To changes.Length - 1
            cell = get_zelle(changes(j).old)
            range = get_range((changes(j).column), cell.day)
            inhalt = (sheet(cell.month).Cells(cell.day, changes(j).column).value)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = ""
            'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)

            cell = get_zelle(changes(j).neu)
            range = get_range((changes(j).column), cell.day)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = inhalt

            'If inhalt.Contains("A") Then
            '    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255)
            'Else
            '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
            'End If
            If inhalt.Contains("A") Then
                'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)

                sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)

            ElseIf inhalt.Contains("K") Then
                sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                'If inhalt.Contains("O") Then
                '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                'Else
                '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                'End If



            End If
        Next

    End Sub
    'Private Sub make_geo2(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
    '    Dim j, i, length As Int16
    '    Dim cell As zelle
    '    Dim inhalt, range As String

    '    length = 0
    '    Me.DbhotelDataSet.katharismata.Clear()

    '    ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
    '    Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 2)
    '    'dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
    '    For i = 0 To dateIDiff
    '        cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
    '        Dim newGeo2 As New geo2
    '        For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
    '            If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value = "") Then
    '                Select Case j
    '                    Case 0
    '                        newGeo2.mic = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
    '                        newGeo2.prufsum = newGeo2.prufsum + newGeo2.mic
    '                    Case 1
    '                        newGeo2.ale = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
    '                        newGeo2.prufsum = newGeo2.prufsum + newGeo2.ale
    '                End Select
    '            Else
    '                Select Case j
    '                    Case 0
    '                        newGeo2.mic = 0
    '                    Case 1
    '                        newGeo2.ale = 0
    '                End Select
    '            End If
    '        Next
    '        ReDim Preserve geomada2(length)
    '        geomada2(length) = newGeo2
    '        length += 1

    '    Next

    '    'Meta koitw sta elements sto array kai elegxw ean to prufsum > 8 
    '    'opou brw prospathw na to diorthosw metakinontas arxika tis Allages A kai meta ta Katharismata K
    '    ' apothikebv tis allages sto changes()

    '    ReDim changes(-1)
    '    length = 0
    '    For i = 0 To geomada2.Length - 1
    '        If geomada2(i).prufsum > 8 Then
    '            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
    '            'MsgBox((sheet(cell.month).Cells(cell.day, get_column_vila_thalase("eean")).value))
    '            If Not sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value.contains("A")) _
    '                AndAlso geomada2(i).prufsum - geomada2(i).mic <= 8 Then

    '                ReDim Preserve changes(length)
    '                changes(length).column = get_column_vila("mic")
    '                changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
    '                length += 1
    '                geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).mic
    '                If i > 0 Then
    '                    geomada2(i - 1).prufsum = geomada2(i - 1).prufsum + geomada2(i).mic
    '                End If
    '            ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value.contains("A")) _
    '                AndAlso geomada2(i).prufsum - geomada2(i).ale <= 8 Then

    '                ReDim Preserve changes(length)
    '                changes(length).column = get_column_vila("ale")
    '                changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
    '                length += 1
    '                geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).ale
    '                If i > 0 Then
    '                    geomada2(i - 1).prufsum = geomada2(i - 1).prufsum + geomada2(i).ale
    '                End If
    '            ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value.contains("D")) _
    '             AndAlso geomada2(i).prufsum - geomada2(i).mic <= 8 Then

    '                If i < geomada2.Length - 1 AndAlso geomada2(i + 1).prufsum + geomada2(i).mic < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mic", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
    '                    'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
    '                    ReDim Preserve changes(length)
    '                    changes(length).column = get_column_vila("mic")
    '                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
    '                    length += 1
    '                    geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).mic
    '                    'If i < geomada2.Length - 1 Then
    '                    geomada2(i + 1).prufsum = geomada2(i + 1).prufsum + geomada2(i).mic
    '                    'End If

    '                ElseIf i > 0 AndAlso geomada2(i - 1).prufsum + geomada2(i).mic < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mic")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mic", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
    '                    ReDim Preserve changes(length)
    '                    changes(length).column = get_column_vila("mic")
    '                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
    '                    length += 1
    '                    geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).mic
    '                    'If i > 0 Then
    '                    geomada2(i - 1).prufsum = geomada2(i - 1).prufsum + geomada2(i).mic
    '                    'End If
    '                End If

    '            ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value.contains("D")) _
    '                AndAlso geomada2(i).prufsum - geomada2(i).ale <= 8 Then

    '                If i < geomada2.Length - 1 AndAlso geomada2(i + 1).prufsum + geomada2(i).ale < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ale", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
    '                    ReDim Preserve changes(length)
    '                    changes(length).column = get_column_vila("ale")
    '                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
    '                    length += 1
    '                    geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).ale
    '                    'If i < geomada2.Length - 1 Then
    '                    geomada2(i + 1).prufsum = geomada2(i + 1).prufsum + geomada2(i).ale
    '                    'End If

    '                ElseIf i > 0 AndAlso geomada2(i - 1).prufsum + geomada2(i).ale < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ale")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ale", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
    '                    ReDim Preserve changes(length)
    '                    changes(length).column = get_column_vila("ale")
    '                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
    '                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
    '                    length += 1
    '                    geomada2(i).prufsum = geomada2(i).prufsum - geomada2(i).ale
    '                    'If i > 0 Then
    '                    geomada2(i - 1).prufsum = geomada2(i - 1).prufsum + geomada2(i).ale
    '                    'End If
    '                End If


    '            Else
    '                Me.Cursor = Cursors.Default
    '                MsgBox("Πρόβλημα με καθαρίσματα geomada2 (MIC,ALE) στις " + FirstDateMonthPck.Value.AddDays(i).ToString("dd-MM-yyyy"), MsgBoxStyle.Exclamation)
    '            End If
    '        End If
    '    Next

    '    For j = 0 To changes.Length - 1
    '        cell = get_zelle(changes(j).old)
    '        range = get_range((changes(j).column), cell.day)
    '        inhalt = (sheet(cell.month).Cells(cell.day, changes(j).column).value)
    '        sheet(cell.month).Cells(cell.day, changes(j).column).value = ""
    '        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)

    '        cell = get_zelle(changes(j).neu)
    '        range = get_range((changes(j).column), cell.day)
    '        sheet(cell.month).Cells(cell.day, changes(j).column).value = inhalt

    '        'If inhalt.Contains("A") Then
    '        '    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255)
    '        'Else
    '        '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
    '        'End If
    '        If inhalt.Contains("A") Then
    '            'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)

    '            sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)

    '        ElseIf inhalt.Contains("K") Then
    '            sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
    '            'If inhalt.Contains("O") Then
    '            '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
    '            'Else
    '            '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
    '            'End If



    '        End If
    '    Next

    'End Sub
    Private Sub make_geo1(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
        Dim j, i, length As Int16
        Dim cell As zelle
        Dim inhalt, range As String

        length = 0
        Me.DbhotelDataSet.katharismata.Clear()

        ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
        Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 1)

        'dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
        For i = 0 To dateIDiff
            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
            Dim newGeo1 As New geo1
            For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1

                If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value = "") Then

                    Select Case j
                        Case 0
                            newGeo1.iper = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo1.prufsum = newGeo1.prufsum + newGeo1.iper
                        Case 1
                            '      CType(hilfstring.Replace(".", ","), Single)
                            newGeo1.ikr = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)

                            newGeo1.prufsum = newGeo1.prufsum + newGeo1.ikr
                        Case 2
                            newGeo1.afr = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo1.prufsum = newGeo1.prufsum + newGeo1.afr
                            'Case 3
                            '    newGeo1.eos = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            '    newGeo1.prufsum = newGeo1.prufsum + newGeo1.eos
                    End Select
                Else
                    Select Case j
                        Case 0
                            newGeo1.iper = 0
                        Case 1
                            newGeo1.ikr = 0
                        Case 2
                            newGeo1.afr = 0
                            'Case 3
                            '    newGeo1.eos = 0
                    End Select
                End If
            Next
            ReDim Preserve geomada1(length)
            geomada1(length) = newGeo1
            length += 1

        Next

        'Meta koitw sta elements sto array kai elegxw ean to prufsum > 8 
        'opou brw prospathw na to diorthosw metakinontas arxika tis Allages A kai meta ta Katharismata K
        ' apothikebv tis allages sto changes()

        ReDim changes(-1)
        length = 0
        For i = 0 To geomada1.Length - 1
            If geomada1(i).prufsum > 8 Then
                cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
                'MsgBox((sheet(cell.month).Cells(cell.day, get_column_vila_thalase("eean")).value))
                If Not sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("A")) _
                    AndAlso geomada1(i).prufsum - geomada1(i).iper <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("IPER")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).iper
                    If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).iper
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("A")) _
                    AndAlso geomada1(i).prufsum - geomada1(i).ikr <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ikr")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).ikr
                    If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).ikr
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("A")) _
                    AndAlso geomada1(i).prufsum - geomada1(i).afr <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("afr")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).afr
                    If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).afr
                    End If
                    'ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("eos")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("eos")).value.contains("A")) _
                    '    AndAlso geomada1(i).prufsum - geomada1(i).eos <= 8 Then

                    '    ReDim Preserve changes(length)
                    '    changes(length).column = get_column_vila("eos")
                    '    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    '    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    '    length += 1
                    '    geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).eos
                    '    If i > 0 Then
                    '        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).eos
                    '    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("D")) _
                    AndAlso geomada1(i).prufsum - geomada1(i).iper <= 8 Then

                    'If Not (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("I")) Then
                    If (i < geomada1.Length - 1) AndAlso geomada1(i + 1).prufsum + geomada1(i).iper < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("IPER", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("IPER")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).iper
                        'If i < geomada1.Length - 1 Then
                        geomada1(i + 1).prufsum = geomada1(i + 1).prufsum + geomada1(i).iper
                        'End If


                    ElseIf i > 0 AndAlso geomada1(i - 1).prufsum + geomada1(i).iper < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("IPER")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("IPER", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("IPER")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).iper
                        'If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).iper
                        'End If
                    End If

                    'End If

                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("D")) _
                    AndAlso geomada1(i).prufsum - geomada1(i).ikr <= 8 Then
                    'If Not (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("I")) Then

                    If i < geomada1.Length - 1 AndAlso geomada1(i + 1).prufsum + geomada1(i).ikr < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ikr", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ikr")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).ikr
                        'If i < geomada1.Length - 1 Then
                        geomada1(i + 1).prufsum = geomada1(i + 1).prufsum + geomada1(i).ikr
                        'End If

                    ElseIf i > 0 AndAlso geomada1(i - 1).prufsum + geomada1(i).ikr < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ikr")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ikr", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ikr")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).ikr
                        'If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).ikr
                        'End If
                    End If



                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("D")) _
                AndAlso geomada1(i).prufsum - geomada1(i).afr <= 8 Then

                    'If Not (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("I")) Then

                    If i < geomada1.Length - 1 AndAlso geomada1(i + 1).prufsum + geomada1(i).afr < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("afr", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("afr")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).afr

                        geomada1(i + 1).prufsum = geomada1(i + 1).prufsum + geomada1(i).afr

                    ElseIf i > 0 AndAlso geomada1(i - 1).prufsum + geomada1(i).afr < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("afr")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("afr", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("afr")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).afr
                        'If i > 0 Then
                        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).afr
                        'End If
                    End If
                    'End If


                    'ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("eos")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("eos")).value.contains("K")) _
                    '    AndAlso geomada1(i).prufsum - geomada1(i).eos <= 8 Then
                    '    'If Not (sheet(cell.month).Cells(cell.day, get_column_vila("eos")).value.contains("I")) Then

                    '    If i < geomada1.Length - 1 AndAlso geomada1(i + 1).prufsum + geomada1(i).eos < 9 AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("eos", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                    '        ReDim Preserve changes(length)
                    '        changes(length).column = get_column_vila("eos")
                    '        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    '        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                    '        length += 1
                    '        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).eos

                    '        geomada1(i + 1).prufsum = geomada1(i + 1).prufsum + geomada1(i).eos

                    '    ElseIf i > 0 AndAlso geomada1(i - 1).prufsum + geomada1(i).eos < 9 AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("eos", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                    '        ReDim Preserve changes(length)
                    '        changes(length).column = get_column_vila("eos")
                    '        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    '        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    '        length += 1
                    '        geomada1(i).prufsum = geomada1(i).prufsum - geomada1(i).eos

                    '        geomada1(i - 1).prufsum = geomada1(i - 1).prufsum + geomada1(i).eos

                    '    End If
                    ' End If

                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("Πρόβλημα με καθαρίσματα geomada_1 (afr,g2-2,ikr,eos)στις " + FirstDateMonthPck.Value.AddDays(i).ToString("dd-MM-yyyy"), MsgBoxStyle.Exclamation)
                End If
            End If
        Next

        For j = 0 To changes.Length - 1
            cell = get_zelle(changes(j).old)
            range = get_range((changes(j).column), cell.day)
            inhalt = (sheet(cell.month).Cells(cell.day, changes(j).column).value)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = ""
            'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)

            cell = get_zelle(changes(j).neu)
            range = get_range((changes(j).column), cell.day)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = inhalt


            If inhalt.Contains("A") Then

                sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)

            ElseIf inhalt.Contains("K") Then
                sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
            End If
        Next

    End Sub

    Private Sub make_geo8(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
        Dim j, i, length As Int16
        Dim cell As zelle
        Dim inhalt, range As String

        length = 0
        Me.DbhotelDataSet.katharismata.Clear()

        ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
        Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 8)
        'dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
        For i = 0 To dateIDiff
            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
            Dim newGeo8 As New geo8
            For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
                If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value = "") Then
                    Select Case j
                        Case 0
                            newGeo8.ub1c = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub1c
                        Case 1
                            newGeo8.ub2c = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub2c
                        Case 2
                            newGeo8.ub4c = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub4c
                        Case 3
                            newGeo8.ub1y = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub1y
                        Case 4
                            newGeo8.ub3c = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub3c
                        Case 5
                            newGeo8.ub1d = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub1d
                        Case 6
                            newGeo8.ub3d = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ub3d
                        Case 7
                            newGeo8.blue = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.blue
                        Case 8
                            newGeo8.gry = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.gry
                        Case 9
                            newGeo8.red = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.red
                        Case 10
                            newGeo8.gre = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.gre
                        Case 11
                            newGeo8.whi = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.whi
                        Case 12
                            newGeo8.san = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.san
                        Case 13
                            newGeo8.coc = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.coc
                        Case 14
                            newGeo8.yell = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.yell
                        Case 15
                            newGeo8.ora = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.ora
                        Case 16
                            newGeo8.purpl = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.purpl
                        Case 17
                            newGeo8.brown = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.brown
                        Case 18
                            newGeo8.rea01 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea01
                        Case 19
                            newGeo8.rea02 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea02
                        Case 20
                            newGeo8.rea11 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea11
                        Case 21
                            newGeo8.rea12 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea12
                        Case 22
                            newGeo8.rea21 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea21
                        Case 23
                            newGeo8.rea22 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea22


                        Case 24
                            newGeo8.rea31 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea31
                        Case 25
                            newGeo8.rea32 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea32
                        Case 26
                            newGeo8.rea41 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea41
                        Case 27
                            newGeo8.rea42 = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newGeo8.prufsum = newGeo8.prufsum + newGeo8.rea42



                    End Select
                Else
                    Select Case j
                        Case 0
                            newGeo8.ub1c = 0
                        Case 1
                            newGeo8.ub2c = 0
                        Case 2
                            newGeo8.ub4c = 0
                        Case 3
                            newGeo8.ub1y = 0
                        Case 4
                            newGeo8.ub3c = 0
                        Case 5
                            newGeo8.ub1d = 0
                        Case 6
                            newGeo8.ub3d = 0
                        Case 7
                            newGeo8.blue = 0
                        Case 8
                            newGeo8.gry = 0
                        Case 9
                            newGeo8.red = 0
                        Case 10
                            newGeo8.gre = 0
                        Case 11
                            newGeo8.whi = 0
                        Case 12
                            newGeo8.san = 0
                        Case 13
                            newGeo8.coc = 0
                        Case 14
                            newGeo8.yell = 0
                        Case 15
                            newGeo8.ora = 0
                        Case 16
                            newGeo8.purpl = 0
                        Case 17
                            newGeo8.brown = 0
                        Case 18
                            newGeo8.rea01 = 0
                        Case 19
                            newGeo8.rea02 = 0
                        Case 20
                            newGeo8.rea11 = 0
                        Case 21
                            newGeo8.rea12 = 0
                        Case 22
                            newGeo8.rea21 = 0
                        Case 23
                            newGeo8.rea22 = 0
                        Case 24
                            newGeo8.rea31 = 0
                        Case 25
                            newGeo8.rea32 = 0
                        Case 26
                            newGeo8.rea41 = 0
                        Case 27
                            newGeo8.rea42 = 0

                    End Select
                End If
            Next
            ReDim Preserve geomada8(length)
            geomada8(length) = newGeo8
            length += 1

        Next

        'Meta koitw sta elements sto array kai elegxw ean to prufsum > 8 
        'opou brw prospathw na to diorthosw metakinontas arxika tis Allages A kai meta ta Katharismata K
        ' apothikebv tis allages sto changes()

        ReDim changes(-1)
        length = 0
        For i = 0 To geomada8.Length - 1
            If geomada8(i).prufsum > 8 Then
                cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
                'MsgBox((sheet(cell.month).Cells(cell.day, get_column_vila_thalase("eean")).value))
                If Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value.contains("A")) _
                   AndAlso geomada8(i).prufsum - geomada8(i).ub4c <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub1c")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1c
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1c
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value.contains("A")) _
             AndAlso geomada8(i).prufsum - geomada8(i).ub4c <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub2c")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub2c
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub2c
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value.contains("A")) _
            AndAlso geomada8(i).prufsum - geomada8(i).ub4c <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub4c")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub4c
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub4c
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value.contains("A")) _
                AndAlso geomada8(i).prufsum - geomada8(i).ub1y <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub1y")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1y
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1y
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value.contains("A")) _
                AndAlso geomada8(i).prufsum - geomada8(i).ub3c <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub3c")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3c
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub3c
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value.contains("A")) _
                AndAlso geomada8(i).prufsum - geomada8(i).ub1d <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub1d")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1d
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1d
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value.contains("A")) _
           AndAlso geomada8(i).prufsum - geomada8(i).ub1d <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ub3d")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3d
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub3d
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value.contains("A")) _
                AndAlso geomada8(i).prufsum - geomada8(i).blue <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("blue")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).blue
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).blue
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value.contains("A")) _
          AndAlso geomada8(i).prufsum - geomada8(i).gry <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("gry")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gry
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).gry
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("red")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("red")).value.contains("A")) _
      AndAlso geomada8(i).prufsum - geomada8(i).gry <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("red")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).red
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).red
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value.contains("A")) _
              AndAlso geomada8(i).prufsum - geomada8(i).gre <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("gre")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gre
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).gre
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value.contains("A")) _
             AndAlso geomada8(i).prufsum - geomada8(i).whi <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("whi")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).whi
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).whi
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("san")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("san")).value.contains("A")) _
                            AndAlso geomada8(i).prufsum - geomada8(i).san <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("san")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).san
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).san
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value.contains("A")) _
                   AndAlso geomada8(i).prufsum - geomada8(i).coc <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("coc")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).coc
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).coc
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value.contains("A")) _
                                AndAlso geomada8(i).prufsum - geomada8(i).yell <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("yell")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).yell
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).yell
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value.contains("A")) _
                                  AndAlso geomada8(i).prufsum - geomada8(i).ora <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("ora")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ora
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ora
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value.contains("A")) _
                              AndAlso geomada8(i).prufsum - geomada8(i).purpl <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("purpl")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).purpl
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).purpl
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value.contains("A")) _
                         AndAlso geomada8(i).prufsum - geomada8(i).brown <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("brown")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).brown
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).brown
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value.contains("A")) _
                         AndAlso geomada8(i).prufsum - geomada8(i).rea01 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea01")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea01
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea01
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value.contains("A")) _
                         AndAlso geomada8(i).prufsum - geomada8(i).rea02 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea02")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea02
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea02
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea11")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea11")).value.contains("A")) _
                         AndAlso geomada8(i).prufsum - geomada8(i).rea11 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea11")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea11
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea11
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value.contains("A")) _
                     AndAlso geomada8(i).prufsum - geomada8(i).rea12 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea12")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea12
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea12
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value.contains("A")) _
                     AndAlso geomada8(i).prufsum - geomada8(i).rea21 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea21")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea21
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea21
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value.contains("A")) _
               AndAlso geomada8(i).prufsum - geomada8(i).rea22 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea22")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea22
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea22
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value.contains("A")) _
          AndAlso geomada8(i).prufsum - geomada8(i).rea31 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea31")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea31
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea31
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value.contains("A")) _
          AndAlso geomada8(i).prufsum - geomada8(i).rea32 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea32")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea32
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea32
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value.contains("A")) _
          AndAlso geomada8(i).prufsum - geomada8(i).rea41 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea41")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea41
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea41
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value.contains("A")) _
          AndAlso geomada8(i).prufsum - geomada8(i).rea42 <= 8 Then

                    ReDim Preserve changes(length)
                    changes(length).column = get_column_vila("rea42")
                    changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                    changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                    length += 1
                    geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea42
                    If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea42
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value.contains("D")) _
            AndAlso geomada8(i).prufsum - geomada8(i).ub1c <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub1c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1c", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1c
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub1c
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub1c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1c")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1c", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1c
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1c
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value.contains("D")) _
       AndAlso geomada8(i).prufsum - geomada8(i).ub2c <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub2c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub2c", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub2c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub2c
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub2c
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub2c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub2c")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub2c", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub2c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub2c
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub2c
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value.contains("D")) _
                 AndAlso geomada8(i).prufsum - geomada8(i).ub4c <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub4c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub4c", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub4c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub4c
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub4c
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub4c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub4c")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub4c", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub4c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub4c
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub4c
                        'End If
                    End If

                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value.contains("D")) _
            AndAlso geomada8(i).prufsum - geomada8(i).ub1y <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub1y < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1y", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1y")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1y
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub1y
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub1y < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1y")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1y", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1y")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1y
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1y
                        'End If
                    End If

                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value.contains("D")) _
             AndAlso geomada8(i).prufsum - geomada8(i).ub3c <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub3c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub3c", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub3c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3c
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub3c
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub3c < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3c")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub3c", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub3c")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3c
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub3c
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value.contains("D")) _
    AndAlso geomada8(i).prufsum - geomada8(i).ub1d <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub1d < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1d", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1d")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1d
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub1d
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub1d < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub1d")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub1d", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub1d")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub1d
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub1d
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).ub3d <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ub3d < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub3d", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub3d")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3d
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ub3d
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ub3d < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ub3d")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ub3d", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then   ' diaforetika metakinw mia mera pio prin 
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ub3d")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ub3d
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ub3d
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value.contains("D")) _
                    AndAlso geomada8(i).prufsum - geomada8(i).blue <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).blue < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("blue", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("blue")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).blue
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).blue
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).blue < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("blue")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("blue", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("blue")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).blue
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).blue
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value.contains("D")) _
                                   AndAlso geomada8(i).prufsum - geomada8(i).gry <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).gry < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("gry", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("gry")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gry
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).gry
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).gry < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gry")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("gry", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("gry")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gry
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).gry
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("red")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("red")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("red")).value.contains("D")) _
                               AndAlso geomada8(i).prufsum - geomada8(i).red <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).red < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("red")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("red", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("red")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).red
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).red
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).red < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("red")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("red", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("red")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).red
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).red
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value.contains("D")) _
             AndAlso geomada8(i).prufsum - geomada8(i).gre <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).gre < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("gre", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("gre")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gre
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).gre
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).gre < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("gre")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("gre", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("gre")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).gre
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).gre
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value.contains("D")) _
                          AndAlso geomada8(i).prufsum - geomada8(i).whi <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).whi < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("whi", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("whi")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).whi
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).whi
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).whi < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("whi")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("whi", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("whi")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).whi
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).whi
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("san")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("san")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("san")).value.contains("D")) _
                      AndAlso geomada8(i).prufsum - geomada8(i).san <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).san < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("san")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("san", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("san")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).san
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).san
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).san < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("san")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("san", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("san")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).san
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).san
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value.contains("D")) _
                  AndAlso geomada8(i).prufsum - geomada8(i).coc <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).coc < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("coc", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("coc")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).coc
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).coc
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).coc < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("coc")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("coc", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("coc")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).coc
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).coc
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value.contains("D")) _
                                 AndAlso geomada8(i).prufsum - geomada8(i).yell <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).yell < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("yell", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("yell")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).yell
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).yell
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).yell < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("yell")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("yell", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("yell")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).yell
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).yell
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value.contains("D")) _
                                 AndAlso geomada8(i).prufsum - geomada8(i).ora <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).ora < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ora", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ora")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ora
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).ora
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).ora < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("ora")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("ora", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("ora")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).ora
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).ora
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value.contains("D")) _
                            AndAlso geomada8(i).prufsum - geomada8(i).purpl <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).purpl < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("purpl", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("purpl")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).purpl
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).purpl
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).purpl < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("purpl")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("purpl", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("purpl")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).purpl
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).purpl
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value.contains("D")) _
                       AndAlso geomada8(i).prufsum - geomada8(i).brown <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).brown < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("brown", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("brown")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).brown
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).brown
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).brown < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("brown")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("brown", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("brown")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).brown
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).brown
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value.contains("D")) _
                  AndAlso geomada8(i).prufsum - geomada8(i).rea01 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea01 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea01", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea01")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea01
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea01
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea01 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea01")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea01", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea01")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea01
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea01
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value.contains("D")) _
             AndAlso geomada8(i).prufsum - geomada8(i).rea02 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea02 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea02", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea02")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea02
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea02
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea02 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea02")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea02", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea02")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea02
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea02
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value.contains("D")) _
     AndAlso geomada8(i).prufsum - geomada8(i).rea12 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea12 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea12", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea12")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea12
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea12
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea12 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea12")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea12", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea12")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea12
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea12
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea21 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea21 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea21", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea21")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea21
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea21
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea21 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea21")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea21", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea21")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea21
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea21
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea22 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea22 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea22", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea22")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea22
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea22
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea22 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea22")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea22", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea22")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea22
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea22
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea31 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea31 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea31", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea31")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea31
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea31
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea31 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea31")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea31", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea31")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea31
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea31
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea32 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea32 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea32", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea32")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea32
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea32
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea32 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea32")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea32", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea32")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea32
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea32
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea41 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea41 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea41", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea41")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea41
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea41
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea41 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea41")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea41", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea41")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea41
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea41
                        'End If
                    End If
                ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value.contains("K")) AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value.contains("D")) _
AndAlso geomada8(i).prufsum - geomada8(i).rea42 <= 8 Then

                    If i < geomada8.Length - 1 AndAlso geomada8(i + 1).prufsum + geomada8(i).rea42 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value.contains("I")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea42", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea42")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea42
                        'If i < geomada2.Length - 1 Then
                        geomada8(i + 1).prufsum = geomada8(i + 1).prufsum + geomada8(i).rea42
                        'End If

                    ElseIf i > 0 AndAlso geomada8(i - 1).prufsum + geomada8(i).rea42 < 9 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("rea42")).value.contains("O")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("rea42", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("rea42")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        geomada8(i).prufsum = geomada8(i).prufsum - geomada8(i).rea42
                        'If i > 0 Then
                        geomada8(i - 1).prufsum = geomada8(i - 1).prufsum + geomada8(i).rea42
                        'End If
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("Πρόβλημα με καθαρίσματα geomada8 στις " + FirstDateMonthPck.Value.AddDays(i).ToString("dd-MM-yyyy"), MsgBoxStyle.Exclamation)
                End If
            End If
        Next

        For j = 0 To changes.Length - 1
            cell = get_zelle(changes(j).old)
            range = get_range((changes(j).column), cell.day)
            inhalt = (sheet(cell.month).Cells(cell.day, changes(j).column).value)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = ""
            'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)

            cell = get_zelle(changes(j).neu)
            range = get_range((changes(j).column), cell.day)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = inhalt

            'If inhalt.Contains("A") Then
            '    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255)
            'Else
            '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
            'End If
            If inhalt.Contains("A") Then
                'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)

                sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)

            ElseIf inhalt.Contains("K") Then
                sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                'If inhalt.Contains("O") Then
                '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                'Else
                '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                'End If



            End If
        Next

    End Sub

    Private Sub make_thalasses(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets)
        Dim j, i, length As Int16
        Dim cell As zelle
        Dim inhalt, range As String

        length = 0
        Me.DbhotelDataSet.katharismata.Clear()

        ' Diabazvw to excel kai apothikebw gia kathe mera synolika tis wres stiw viles thalases 
        Me.KatharismataTableAdapter.FillByGeomada(Me.DbhotelDataSet.katharismata, 3)
        'dateIDiff = Convert.ToInt16(mexriDPck.Value.Subtract(FirstDateMonthPck.Value).Days)
        For i = 0 To dateIDiff
            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
            Dim newThal As New thal
            For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
                If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value = "") Then
                    Select Case j
                        Case 1
                            newThal.eean = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)

                            newThal.prufsum = newThal.prufsum + newThal.eean
                        Case 2
                            newThal.mail = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newThal.prufsum = newThal.prufsum + newThal.mail
                        Case 3
                            newThal.pers = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newThal.prufsum = newThal.prufsum + newThal.pers
                        Case 4
                            newThal.thoi = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newThal.prufsum = newThal.prufsum + newThal.thoi
                        Case 5
                            newThal.pue = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newThal.prufsum = newThal.prufsum + newThal.pue
                        Case 0
                            newThal.mavi = CType(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(j).excelcolumn).value.Substring(9, 3).Replace(".", ","), Single)
                            newThal.prufsum = newThal.prufsum + newThal.mavi
                    End Select
                Else
                    Select Case j
                        Case 1
                            newThal.eean = 0
                        Case 2
                            newThal.mail = 0
                        Case 3
                            newThal.pers = 0
                        Case 4
                            newThal.thoi = 0
                        Case 5
                            newThal.pue = 0
                        Case 0
                            newThal.mavi = 0
                    End Select
                End If
            Next
            ReDim Preserve thalasses(length)
            thalasses(length) = newThal
            length += 1

        Next

        'Meta koitw sta elements sto array kai elegxw ean to prufsum > 8 
        'opou brw prospathw na to diorthosw metakinontas arxika tis Allages A kai meta ta Katharismata K
        ' apothikebv tis allages sto changes()

        ReDim changes(-1)
        length = 0
        Try
            For i = 0 To thalasses.Length - 1
                If thalasses(i).prufsum > 8 Then
                    cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
                    'MsgBox((sheet(cell.month).Cells(cell.day, get_column_vila_thalase("eean")).value))
                    If Not sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("A")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).eean <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("eean")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).eean
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).eean
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("A")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).mail <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("mail")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mail
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).mail
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("A")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).pers <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("pers")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pers
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).pers
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("A")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).thoi <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("thoi")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).thoi
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).thoi
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("A")) _
                   AndAlso thalasses(i).prufsum - thalasses(i).pue <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("pue")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pue
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).pue
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("A")) _
                    AndAlso thalasses(i).prufsum - thalasses(i).mavi <= 8 Then

                        ReDim Preserve changes(length)
                        changes(length).column = get_column_vila("mavi")
                        changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                        changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                        length += 1
                        thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mavi
                        If i > 0 Then
                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).mavi
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("K")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).eean <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).eean <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("eean", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            'metakinw to katharisma mia mera meta-> giati thewrw pws efyge
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("eean")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).eean

                            thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).eean


                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).eean <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("eean")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("eean", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then ' diaforetika metakinw mia mera pio prin 
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("eean")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).eean

                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).eean

                        End If

                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("K")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).mail <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).mail <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mail", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("mail")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mail

                            thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).mail

                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).mail <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("mail")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mail", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("mail")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mail

                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).mail

                        End If

                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("K")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).pers <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).pers <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("pers", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("pers")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pers

                            thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).pers


                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).pers <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("pers")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("pers", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("pers")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pers

                            thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).pers

                        End If

                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("K")) _
                        AndAlso thalasses(i).prufsum - thalasses(i).thoi <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).thoi <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("thoi", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("thoi")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).thoi
                            If i < thalasses.Length - 1 Then
                                thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).thoi
                            End If
                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).thoi <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("thoi")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("thoi", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("thoi")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).thoi
                            If i > 0 Then
                                thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).thoi
                            End If
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("K")) _
                   AndAlso thalasses(i).prufsum - thalasses(i).pue <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).pue <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("pue", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("pue")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pue
                            If i < thalasses.Length - 1 Then
                                thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).pue
                            End If
                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).pue <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("pue")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("pue", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("pue")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).pue
                            If i > 0 Then
                                thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).pue
                            End If
                        End If
                    ElseIf Not sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value = Nothing AndAlso (sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("K")) _
                AndAlso thalasses(i).prufsum - thalasses(i).mavi <= 8 Then

                        If i < thalasses.Length - 1 AndAlso thalasses(i + 1).prufsum + thalasses(i).mavi <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("I") Or sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mavi", Me.FirstDateMonthPck.Value.AddDays(i + 1), Me.FirstDateMonthPck.Value.AddDays(i + 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("mavi")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i + 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mavi
                            If i < thalasses.Length - 1 Then
                                thalasses(i + 1).prufsum = thalasses(i + 1).prufsum + thalasses(i).mavi
                            End If
                        ElseIf i > 0 AndAlso thalasses(i - 1).prufsum + thalasses(i).mavi <= 8 AndAlso Not (sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("O") Or sheet(cell.month).Cells(cell.day, get_column_vila("mavi")).value.contains("D")) AndAlso Not Me.StatusTableAdapter.ExistStatusByDwmImerom("mavi", Me.FirstDateMonthPck.Value.AddDays(i - 1), Me.FirstDateMonthPck.Value.AddDays(i - 1)) Then
                            ReDim Preserve changes(length)
                            changes(length).column = get_column_vila("mavi")
                            changes(length).old = Me.FirstDateMonthPck.Value.AddDays(i)
                            changes(length).neu = Me.FirstDateMonthPck.Value.AddDays(i - 1)
                            length += 1
                            thalasses(i).prufsum = thalasses(i).prufsum - thalasses(i).mavi
                            If i > 0 Then
                                thalasses(i - 1).prufsum = thalasses(i - 1).prufsum + thalasses(i).mavi
                            End If
                        End If
                    Else
                        Me.Cursor = Cursors.Default
                        MsgBox("Πρόβλημα με καθαρίσματα Thalasses στις " + FirstDateMonthPck.Value.AddDays(i).ToString("dd-MM-yyyy"), MsgBoxStyle.Exclamation)
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        For j = 0 To changes.Length - 1
            cell = get_zelle(changes(j).old)
            range = get_range((changes(j).column), cell.day)
            inhalt = (sheet(cell.month).Cells(cell.day, changes(j).column).value)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = ""
            'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)

            cell = get_zelle(changes(j).neu)
            range = get_range((changes(j).column), cell.day)
            sheet(cell.month).Cells(cell.day, changes(j).column).value = inhalt

            If inhalt.Contains("A") Then
                'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)

                sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)

            ElseIf inhalt.Contains("K") Then
                sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                'If inhalt.Contains("O") Then
                '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                '    'Else
                '    '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                'End If



            End If
        Next

    End Sub
    Private Function get_column_vila(ByVal vila As String) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
            If Me.DbhotelDataSet.katharismata(j).villa.Equals(vila.ToUpper) Then
                Return Me.DbhotelDataSet.katharismata(j).excelcolumn
            End If
        Next
        Return Nothing
    End Function
    Private Function get_index_vila(ByVal vila As String) As Int16
        Dim j As Int16

        For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
            If Me.DbhotelDataSet.katharismata(j).villa.Equals(vila.ToUpper) Then
                Return j
            End If
        Next
    End Function
    Private Function rechne_wres_per_day(ByVal thalasa() As thal) As Int16()
        Dim i, length As Int16

        Dim wres() As Int16
        ReDim wres(-1)
        length = 0

        For i = 0 To thalasa.Length - 1
            Dim newthal As thal
            newthal = thalasa(i)
            ReDim Preserve wres(length)
            wres(length) = newthal.thoi + newthal.pers + newthal.mail + newthal.eean + newthal.mavi
        Next

    End Function
    Private Function get_monday_date_of_next_week() As Date
        Dim x As Date
        x = imeromErgasias
        While (x.DayOfWeek <> 1)
            x = x.AddDays(+1)
        End While
        Return x


    End Function
    Private Function get_home_date_of_next_week() As Int16
        Dim x As Date = FirstDateMonthPck.Value.Date
        Dim i As Int16

        While (x.DayOfWeek) <> HomeDayCbx.SelectedIndex
            x = x.AddDays(+1)
            i += 1
        End While
        Return i
    End Function
    Private Sub make_rest_plano(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal day1 As Int16, ByRef day2 As Int16, ByRef day3 As Int16, ByRef day4 As Int16)

        Dim wresTemp, wresTemp1, wresGraf As Int16

        Dim founOK As Boolean

        founOK = False



        If day1 <> -1 Then
            make_home_grafio(workSheet, oExcel, book, sheet, day1, 1, wresTemp)

        End If
        wresTemp = 0
        If day2 <> -1 Then
            If GrafeioForesCbx.SelectedIndex > 0 Then
                make_home_grafio(workSheet, oExcel, book, sheet, day2, 2, wresGraf)
                wresTemp = wresGraf
                If FoundChk.Checked = True Then
                    If Not founOK Then
                        wresTemp1 = get_wres_kath("foyn")
                        If wresTemp + wresTemp1 < 9 Then
                            make_fountoulaki(workSheet, oExcel, book, sheet, day2)
                            wresTemp = wresTemp + wresTemp1
                            founOK = True
                        End If
                    End If

                    'If Not foukOK Then
                    '    wresTemp1 = get_wres_kath("foyk")
                    '    If wresTemp + wresTemp1 < 9 Then
                    '        make_fountoulaki_koin(workSheet, oExcel, book, sheet, day2)
                    '        foukOK = True
                    '    End If
                    'End If

                End If
            Else
                day4 = day3
                day3 = day2
                day2 = -1


            End If

        End If
        wresTemp = 0
        wresTemp1 = 0
        If day3 <> -1 Then
            If GrafeioForesCbx.SelectedIndex <> 0 AndAlso (GrafeioForesCbx.SelectedIndex = 2 Or (wresGraf * SentWra.Text) < sentonEbdom) Then
                make_home_grafio(workSheet, oExcel, book, sheet, day3, 2, wresGraf)
                wresTemp = wresGraf

                If FoundChk.Checked = True Then
                    If Not founOK Then
                        wresTemp1 = get_wres_kath("foyn")
                        If wresTemp + wresTemp1 < 9 Then
                            make_fountoulaki(workSheet, oExcel, book, sheet, day3)
                            wresTemp = wresTemp + wresTemp1
                            founOK = True
                        End If
                    End If

                    'If Not foukOK Then
                    '    wresTemp1 = get_wres_kath("foyk")
                    '    If wresTemp + wresTemp1 < 9 Then
                    '        make_fountoulaki_koin(workSheet, oExcel, book, sheet, day3)
                    '        foukOK = True
                    '    End If
                    'End If
                End If

            ElseIf FoundChk.Checked = True Then
                If Not founOK Then
                    wresTemp1 = get_wres_kath("foyn")

                    make_fountoulaki(workSheet, oExcel, book, sheet, day3)

                    founOK = True
                    wresTemp = wresTemp1
                End If

                'If Not foukOK Then
                '    wresTemp1 = get_wres_kath("foyk")
                '    If wresTemp + wresTemp1 < 9 Then
                '        make_fountoulaki_koin(workSheet, oExcel, book, sheet, day3)
                '        foukOK = True
                '    End If
                'End If
                If Not founOK Then 'And Not foukOK
                    day4 = day3
                    day3 = -1

                End If
            Else
                day4 = day3
                day3 = -1

            End If


        End If

        wresTemp = 0
        wresTemp1 = 0
        If day4 <> -1 Then
            If GrafeioForesCbx.SelectedIndex <> 0 And (2 * wresGraf * SentWra.Text) < sentonEbdom Then
                make_home_grafio(workSheet, oExcel, book, sheet, day4, 2, wresGraf)
                wresTemp = wresGraf
                If FoundChk.Checked = True Then
                    If Not founOK Then
                        wresTemp1 = get_wres_kath("foyn")
                        If wresTemp + wresTemp1 < 9 Then
                            make_fountoulaki(workSheet, oExcel, book, sheet, day4)
                            wresTemp = wresTemp + wresTemp1
                            founOK = True
                        End If
                    End If

                    'If Not foukOK Then
                    '    wresTemp1 = get_wres_kath("foyk")
                    '    If wresTemp + wresTemp1 < 9 Then
                    '        make_fountoulaki_koin(workSheet, oExcel, book, sheet, day4)
                    '        foukOK = True
                    '    End If
                    'End If
                End If
            ElseIf FoundChk.Checked = True Then
                If Not founOK Then
                    wresTemp1 = get_wres_kath("foyn")

                    make_fountoulaki(workSheet, oExcel, book, sheet, day4)

                    founOK = True
                    wresTemp = wresTemp1
                End If

                'If Not foukOK Then
                '    wresTemp1 = get_wres_kath("foyk")
                '    If wresTemp + wresTemp1 < 9 Then
                '        make_fountoulaki_koin(workSheet, oExcel, book, sheet, day4)
                '        foukOK = True
                '    End If
                'End If
                If Not founOK Then ' And Not foukOK
                    day4 = -1
                End If

            Else
                day4 = -1
            End If
        End If


    End Sub
    Private Sub make_home_grafio(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal day As Int16, ByVal flag As Byte, ByRef wreskat As Int16)
        Dim cell As zelle
        Dim range As String
        Dim index As Int16


        cell = get_zelle(FirstDateMonthPck.Value.Date.AddDays(day))
        If flag = 1 Then
            index = get_index_vila("home")
        ElseIf flag = 2 Then
            index = get_index_vila("off")
        End If

        range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
        sheet(cell.month).Range(range).Font.Bold = True
        sheet(cell.month).Range(range).HorizontalAlignment = 3
        sheet(cell.month).Range(range).Style.Font.Size = 11
        If flag = 1 Then
            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(1,H,0,K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
        ElseIf flag = 2 Then
            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(1,O,0,K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
        End If
        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
        wreskat = Me.DbhotelDataSet.katharismata(index).wreskath
    End Sub
    Private Sub make_fountoulaki(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal day As Int16)
        Dim cell As zelle
        Dim range As String
        Dim index As Int16

        cell = get_zelle(FirstDateMonthPck.Value.Date.AddDays(day))
        index = get_index_vila("foyn")
        range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
        sheet(cell.month).Range(range).Font.Bold = True
        sheet(cell.month).Range(range).HorizontalAlignment = 3
        sheet(cell.month).Range(range).Style.Font.Size = 11
        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(1,Φ,0,K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)

    End Sub
    'Private Sub make_fountoulaki_koin(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal day As Int16)
    '    Dim cell As zelle
    '    Dim range As String
    '    Dim index As Int16

    '    cell = get_zelle(FirstDateMonthPck.Value.Date.AddDays(day))
    '    index = get_index_vila("foyk")
    '    range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
    '    sheet(cell.month).Range(range).Font.Bold = True
    '    sheet(cell.month).Range(range).HorizontalAlignment = 3
    '    sheet(cell.month).Range(range).Style.Font.Size = 11

    '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(1,φ,0,K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
    '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)

    'End Sub
    Private Function get_wres_kath(ByVal vila As String) As Int16
        Dim index As Int16
        index = get_index_vila(vila)
        Return Me.DbhotelDataSet.katharismata(index).wreskath

    End Function
    Private Sub make_old_town(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal kratiseis() As Int16, ByVal excelcolumn As Byte)
        Dim i As Int16
        Dim cell As zelle

        For i = 0 To dateIDiff

            cell = get_zelle(FirstDateMonthPck.Value.AddDays(i))
            If kratiseis(i) <> 0 Then
                sheet(cell.month).Cells(cell.day, excelcolumn).value() = kratiseis(i)
            End If

        Next
    End Sub
    Private Sub make_katharismata(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal oBook As Microsoft.Office.Interop.Excel.Workbook, ByVal oSheet As Microsoft.Office.Interop.Excel.Sheets)
        'Dim oExcel As Microsoft.Office.Interop.Excel.Application
        'Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        'Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Dim j, i As Int16
        'Dim range As String
        If Me.DbhotelDataSet.katharismata.Count <> 0 Then
            Try
                'oExcel = CreateObject("Excel.Application")
                'oBook = oExcel.Workbooks.Open(path)
                'oSheet = oBook.Worksheets

                For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
                    'If Me.DbhotelDataSet.katharismata(j).villa = "IKR" Then
                    '    MsgBox("ikaros)")
                    'End If
                    'If j = 6 Then
                    '    MsgBox(Me.DbhotelDataSet.katharismata(j).villa)
                    'End If

                    berechne_katharismata_kratisis(j, oBook, oSheet)

                    Try
                        datumMexri = "31/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
                    Catch ex As InvalidCastException
                        Try
                            datumMexri = "30/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
                        Catch ex1 As Exception
                            datumMexri = "28/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
                        End Try

                    End Try
                Next
            Catch ex As Runtime.InteropServices.COMException
                MsgBox("Ελέγξτε την τοποθεσία του cleanings.xlsm", MsgBoxStyle.Critical)
                'MsgBox(ex)
                oExcel.Quit()
                Exit Sub
            Catch ex1 As Exception
                MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
                oExcel.Quit()
            End Try
            'oExcel.Quit()
        End If


    End Sub
    Private Sub berechne_katharismata_kratisis(ByVal index As Int16, ByVal book As Workbook, ByVal sheet As Sheets)
        Dim datum As Date
        Dim kathOK As Boolean = True
        Dim cell As zelle
        Dim j As Int16
        Dim range As String
        'cyan(0,255,255),red(255,0,0),yellow(255,255,0), silver (192,192,192), lime green (0,255,0), white(255,255,255)


        'sheet(1).Range("B2:B2").Interior.Color = RGB(255, 255, 0)
        'MsgBox(sheet(1).Range("B2:B2").Interior.Color.ToString) '= RGB(255, 255, 255)

        cell = get_zelle(Me.DbhotelDataSet.katharismata(index).afixi)

        datum = Me.DbhotelDataSet.katharismata(index).afixi


        'MsgBox(Me.DbhotelDataSet.katharismata(index).villa)
        Do While datum <= Me.DbhotelDataSet.katharismata(index).anaxwrisi
            If datum > datumMexri Then
                Try
                    datumMexri = "31/" + datum.Month.ToString + "/" + imeromErgasias.Year.ToString
                Catch ex As InvalidCastException
                    datumMexri = "30/" + datum.Month.ToString + "/" + imeromErgasias.Year.ToString
                End Try
            End If
            range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
            sheet(cell.month).Range(range).Font.Bold = True
            sheet(cell.month).Range(range).HorizontalAlignment = 3
            sheet(cell.month).Range(range).Style.Font.Size = 11

            If datum >= FirstDateMonthPck.Value Then
                If kathOK Then


                    'MsgBox(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value)
                    If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "") AndAlso sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value.Contains("O") Then
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,D," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,D," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        End If
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        'sheet(cell.month).Range(range).Style.Font.Color = RGB(51, 0, 0)
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                        'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                        'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    ElseIf datum = Me.DbhotelDataSet.katharismata(index).afixi Then
                        If Not check_ob_villa_schon_sauber(DaysClean.Text, datum, Me.DbhotelDataSet.katharismata(index).excelcolumn, book, sheet) Then

                            'cell1 = get_zelle(datum.AddDays(-1))

                            'range1 = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell1.day)
                            'sheet(cell1.month).Range(range).Font.Bold = True
                            'sheet(cell1.month).Range(range).HorizontalAlignment = 3
                            'sheet(cell1.month).Range(range).Style.Font.Size = 11

                            If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                                sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,I," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                            Else
                                sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,I," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"

                            End If
                            sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap

                        End If
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0) 'RGB(255, 255, 0)(255,255,0)
                        'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                        'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    ElseIf datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                        'cell = get_zelle(datum.AddDays(1))
                        'range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                        'sheet(cell.month).Range(range).Font.Bold = True
                        'sheet(cell.month).Range(range).HorizontalAlignment = 3
                        'sheet(cell.month).Range(range).Style.Font.Size = 11
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        End If

                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        Exit Sub
                    ElseIf DateDiff(DateInterval.Day, datum, Me.DbhotelDataSet.katharismata(index).anaxwrisi) > 1 AndAlso Me.DbhotelDataSet.katharismata(index).geomada <> 8 Then
                        'If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                        '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        'Else
                        '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"

                        'End If
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"

                        End If
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                    ElseIf Me.DbhotelDataSet.katharismata(index).geomada = 8 Then
                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                    End If
                Else
                    If datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                        'cell = get_zelle(datum.AddDays(1))
                        'range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                        'sheet(cell.month).Range(range).Font.Bold = True
                        'sheet(cell.month).Range(range).HorizontalAlignment = 3
                        'sheet(cell.month).Range(range).Style.Font.Size = 11
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"


                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"



                        End If
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                        Exit Sub
                    ElseIf Me.DbhotelDataSet.katharismata(index).geomada <> 8 Then
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"

                        End If
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        sheet(cell.month).Range(range).Font.Color = RGB(0, 153, 0)
                    ElseIf Me.DbhotelDataSet.katharismata(index).geomada = 8 Then
                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                    End If
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"
                    'sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255) 'RGB(0, 255, 0)
                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                End If
                'MsgBox("mona " + Me.DbhotelDataSet.katharismata(index).sentmona.ToString)
                'MsgBox("dilpa " + Me.DbhotelDataSet.katharismata(index).sentdipla.ToString)
                'MsgBox("kanape " + Me.DbhotelDataSet.katharismata(index).sentkanap.ToString)


            End If

            'MsgBox(Me.DbhotelDataSet.katharismata(index).sentonia)
            If Me.DbhotelDataSet.katharismata(index).simetoxi = 0 And Me.DbhotelDataSet.katharismata(index).geomada <> 3 Then
                For j = 0 To Me.DbhotelDataSet.katharismata(index).sentonia - 1
                    datum = datum.AddDays(1)
                    cell = get_zelle(datum)
                    range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                    sheet(cell.month).Range(range).Font.Bold = True
                    sheet(cell.month).Range(range).HorizontalAlignment = 3
                    sheet(cell.month).Range(range).Style.Font.Size = 11

                    If datum > mexriDPck.Value Then
                        Exit Sub


                    ElseIf datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                        'cell = get_zelle(datum.AddDays(1))
                        'range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                        'sheet(cell.month).Range(range).Font.Bold = True
                        'sheet(cell.month).Range(range).HorizontalAlignment = 3
                        'sheet(cell.month).Range(range).Style.Font.Size = 11
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        End If
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                        Exit Sub
                        'sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                        'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                        'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    ElseIf datum >= datumApo Then

                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        'Exit Sub
                    End If

                    'If datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                    '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                    '    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                    '    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                    '    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    '    Exit Sub
                    'ElseIf datum >= datumApo Then
                    '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                    '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                    'ElseIf datum > mexriDPck.Value Then
                    '    Exit Sub
                    'End If

                Next
            ElseIf Me.DbhotelDataSet.katharismata(index).simetoxi <> 0 Then
                For j = 0 To Me.DbhotelDataSet.katharismata(index).simetoxi - 1
                    datum = datum.AddDays(1)
                    cell = get_zelle(datum)
                    range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                    sheet(cell.month).Range(range).Font.Bold = True
                    sheet(cell.month).Range(range).HorizontalAlignment = 3
                    sheet(cell.month).Range(range).Style.Font.Size = 11

                    If datum > mexriDPck.Value Then
                        Exit Sub


                    ElseIf datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                        'cell = get_zelle(datum.AddDays(1))
                        'range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                        'sheet(cell.month).Range(range).Font.Bold = True
                        'sheet(cell.month).Range(range).HorizontalAlignment = 3
                        'sheet(cell.month).Range(range).Style.Font.Size = 11
                        If Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        Else
                            sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                        End If
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                        Exit Sub
                        'sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                        'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                        'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    ElseIf datum >= datumApo Then

                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        'Exit Sub
                    End If



                Next
            ElseIf Me.DbhotelDataSet.katharismata(index).geomada = 3 Then
                For j = 0 To 2
                    datum = datum.AddDays(1)
                    cell = get_zelle(datum)
                    range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                    sheet(cell.month).Range(range).Font.Bold = True
                    sheet(cell.month).Range(range).HorizontalAlignment = 3
                    sheet(cell.month).Range(range).Style.Font.Size = 11

                    If datum > mexriDPck.Value Then
                        Exit Sub


                    ElseIf datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                        'cell = get_zelle(datum.AddDays(1))
                        'range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                        'sheet(cell.month).Range(range).Font.Bold = True
                        'sheet(cell.month).Range(range).HorizontalAlignment = 3
                        'sheet(cell.month).Range(range).Style.Font.Size = 11

                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(2,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"

                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                        sheet(cell.month).Range(range).Font.Color = RGB(255, 0, 0)
                        sentonEbdom = sentonEbdom + Me.DbhotelDataSet.katharismata(index).sentmona + Me.DbhotelDataSet.katharismata(index).sentdipla + Me.DbhotelDataSet.katharismata(index).sentkanap
                        'sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                        Exit Sub
                        'sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                        'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                        'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    ElseIf datum >= datumApo Then

                        sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                        sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0)
                        'Exit Sub
                    End If

                    'If datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                    '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                    '    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                    '    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                    '    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    '    Exit Sub
                    'ElseIf datum >= datumApo Then
                    '    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                    '    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                    'ElseIf datum > mexriDPck.Value Then
                    '    Exit Sub
                    'End If

                Next

            End If


            kathOK = Not kathOK

        Loop
    End Sub
    Private Function check_ob_villa_schon_sauber(ByVal days As Int16, ByVal datum As Date, ByVal column As Int16, ByVal book As Workbook, ByVal sheet As Sheets) As Boolean
        Dim cell As zelle
        Dim i As Int16 = 0

        While i <> days
            i += 1
            cell = get_zelle(datum.AddDays(-i))
            If Not sheet(cell.month).Cells(cell.day, column).value = "" Then
                '      MsgBox(sheet(cell.month).Cells(cell.day, column).value)
                If sheet(cell.month).Cells(cell.day, column).value.contains("O") Then
                    Return True
                End If

            End If


        End While
        Return False

    End Function
    Private Function get_zelle(ByVal datum As Date) As zelle

        Dim zelle As zelle

        zelle.month = datum.Month '- 3
        zelle.day = datum.Day + 1
        Return zelle

    End Function
    Private Function get_range(ByVal column As Int16, ByVal row As Int16) As String
        Dim range As String = ""
        Select Case column
            Case 2
                range = "B" + row.ToString + ":B" + row.ToString
                Return range
            Case 3
                range = "C" + row.ToString + ":C" + row.ToString
                Return range
            Case 4
                range = "D" + row.ToString + ":D" + row.ToString
                Return range
            Case 5
                range = "E" + row.ToString + ":E" + row.ToString
                Return range
            Case 6
                range = "F" + row.ToString + ":F" + row.ToString
                Return range
            Case 7
                range = "G" + row.ToString + ":G" + row.ToString
                Return range
            Case 8
                range = "H" + row.ToString + ":H" + row.ToString
                Return range
            Case 9
                range = "I" + row.ToString + ":I" + row.ToString
                Return range
            Case 10
                range = "J" + row.ToString + ":J" + row.ToString
                Return range
            Case 11
                range = "K" + row.ToString + ":K" + row.ToString
                Return range
            Case 12
                range = "L" + row.ToString + ":L" + row.ToString
                Return range
            Case 13
                range = "M" + row.ToString + ":M" + row.ToString
                Return range
            Case 14
                range = "N" + row.ToString + ":N" + row.ToString
                Return range
            Case 15
                range = "O" + row.ToString + ":O" + row.ToString
                Return range
            Case 16
                range = "P" + row.ToString + ":P" + row.ToString
                Return range
            Case 17
                range = "Q" + row.ToString + ":Q" + row.ToString
                Return range
            Case 18
                range = "R" + row.ToString + ":R" + row.ToString
                Return range
            Case 19
                range = "S" + row.ToString + ":S" + row.ToString
                Return range
            Case 20
                range = "T" + row.ToString + ":T" + row.ToString
                Return range
            Case 21
                range = "U" + row.ToString + ":U" + row.ToString
                Return range
            Case 22
                range = "V" + row.ToString + ":V" + row.ToString
                Return range
            Case 23
                range = "W" + row.ToString + ":W" + row.ToString
                Return range
            Case 24
                range = "X" + row.ToString + ":X" + row.ToString
                Return range
            Case 25
                range = "Y" + row.ToString + ":Y" + row.ToString
                Return range
            Case 26
                range = "Z" + row.ToString + ":Z" + row.ToString
                Return range
            Case 27
                range = "AA" + row.ToString + ":AA" + row.ToString
                Return range
            Case 28
                range = "AB" + row.ToString + ":AB" + row.ToString
                Return range
            Case 29
                range = "AC" + row.ToString + ":AC" + row.ToString
                Return range
            Case 30
                range = "AD" + row.ToString + ":AD" + row.ToString
                Return range
            Case 31
                range = "AE" + row.ToString + ":AE" + row.ToString
                Return range
            Case 32
                range = "AF" + row.ToString + ":AF" + row.ToString
                Return range
            Case 33
                range = "AG" + row.ToString + ":AG" + row.ToString
                Return range
            Case 34
                range = "AH" + row.ToString + ":AH" + row.ToString
                Return range
            Case 35
                range = "AI" + row.ToString + ":AI" + row.ToString
                Return range
            Case 36
                range = "AJ" + row.ToString + ":AJ" + row.ToString
                Return range
            Case 37
                range = "AK" + row.ToString + ":AK" + row.ToString
                Return range
            Case 38
                range = "AL" + row.ToString + ":AL" + row.ToString
                Return range
            Case 39
                range = "AM" + row.ToString + ":AM" + row.ToString
                Return range
            Case 40
                range = "AN" + row.ToString + ":AN" + row.ToString
                Return range
            Case 41
                range = "AO" + row.ToString + ":AO" + row.ToString
                Return range
            Case 42
                range = "AP" + row.ToString + ":AP" + row.ToString
                Return range
            Case 42
                range = "AP" + row.ToString + ":AP" + row.ToString
                Return range
            Case 43
                range = "AQ" + row.ToString + ":AQ" + row.ToString
                Return range
            Case 44
                range = "AR" + row.ToString + ":AR" + row.ToString
                Return range
            Case 45
                range = "AS" + row.ToString + ":AS" + row.ToString
                Return range
            Case 46
                range = "AT" + row.ToString + ":AT" + row.ToString
                Return range
            Case 47
                range = "AU" + row.ToString + ":AU" + row.ToString
                Return range
            Case 48
                range = "AV" + row.ToString + ":AV" + row.ToString
                Return range
            Case 49
                range = "AW" + row.ToString + ":AV" + row.ToString
                Return range
            Case 50
                range = "AX" + row.ToString + ":AX" + row.ToString
                Return range
        End Select
        Return range
        'oSheet.Range("A1:A1").Interior.Color = RGB(255, 100, 120)
    End Function


    Private Sub zu_ordne_katharisties_u_rechne_sentonia(ByVal workSheet As Int16, ByVal oExcel As Microsoft.Office.Interop.Excel.Application, ByVal book As Microsoft.Office.Interop.Excel.Workbook, ByVal sheet As Microsoft.Office.Interop.Excel.Sheets, ByVal day1 As Int16, ByVal day2 As Int16, ByVal day3 As Int16, ByVal day4 As Int16)
        Dim j, i, dipla, mona, kanap, kathnumber, atoma, oldcolumn, resultcolumn As Int16
        Dim senton, tupel As String
        Dim datum As Date
        Dim cell As zelle


        Try
            datum = FirstDateMonthPck.Value.Date
            resultcolumn = CType(resultC, Int16)
            j = 0
            i = 0

            'ReDim anzkath(-1)
            Do While datum <= mexriDPck.Value.Date
                If i = day1 OrElse i = day2 OrElse i = day3 OrElse i = day4 Then
                    If thalasses(i).prufsum = 0 Then
                        kathnumber = 1
                    Else
                        kathnumber = 2
                    End If
                Else
                    kathnumber = 0
                End If

                oldcolumn = 0
                senton = ""
                mona = 0
                dipla = 0
                kanap = 0

                atoma = 0
                cell = get_zelle(datum)
                For j = firstC To lastC
                    ''  MsgBox(sheet(cell.month).Cells(cell.day, j).value)
                    If (Not sheet(cell.month).Cells(cell.day, j).value = "") Then
                        senton = get_infos_kath(j)

                        kanap = CType(senton.Substring(1, 1), Int16) + kanap
                        dipla = CType(senton.Substring(2, 1), Int16) + dipla
                        mona = CType(senton.Substring(3, senton.Length - 3), Int16) + mona

                        Try
                            atoma = sheet(cell.month).Cells(cell.day, j).value.Substring(5, 1) + atoma
                        Catch ex As InvalidCastException

                        End Try


                        If oldcolumn = 0 OrElse get_geomada(j) <> get_geomada(oldcolumn) Then

                            'If kathnumber < anzkath(i) Then
                            If get_geomada(j) <> 3 Then
                                kathnumber += 1
                            End If


                            'End If
                        End If

                        If get_geomada(j) <> 3 Then
                            tupel = sheet(cell.month).Cells(cell.day, j).value
                            tupel = Replace(tupel, "9", kathnumber, 1, 1)
                            sheet(cell.month).Cells(cell.day, j).value = tupel
                        End If

                        oldcolumn = j
                    End If

                Next
                If mona + dipla + kanap + atoma <> 0 Then
                    sheet(cell.month).Cells(cell.day, resultcolumn).value = mona
                    sheet(cell.month).Cells(cell.day, resultcolumn + 1).value = dipla
                    sheet(cell.month).Cells(cell.day, resultcolumn + 2).value = kanap
                    sheet(cell.month).Cells(cell.day, resultcolumn + 3).value = atoma
                End If
                i += 1
                datum = datum.AddDays(1)
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Function find_next_best_day_kath_1(ByVal iteration1 As Int16, ByVal iteration2 As Int16, ByVal iteration3 As Int16) As Int16

        Dim thesi, i As Int16
        Dim smallest As Integer = Int16.MaxValue
        thesi = -1
        i = 0
        For Each element As Int16 In anzkath
            If Not (i = iteration1 OrElse i = iteration2 OrElse i = iteration3) Then
                If element < smallest Then
                    smallest = element
                    thesi = i
                End If
            End If
            'largest = Math.Max(largest, element)
            'smallest = Math.Min(smallest, element)

            i += 1
        Next
        Return thesi
    End Function
    Private Function rechne_frei_tage_katharistria_1() As Int16
        Dim i, x As Int16
        x = 0

        For i = 0 To dateIDiff
            ReDim Preserve freietagekath1(i)
            If anzkath(i) = 0 OrElse (anzkath(i) = 1 AndAlso thalasses(i).prufsum <> 0) Then
                x += 1
            End If
        Next
        Return x
    End Function
    Private Function berechne_anzkath_periodou() As Int16
        Dim anzkathar, i, freeDays As Int16
        ReDim anzkath(-1)

        For i = 0 To dateIDiff
            anzkathar = anz_kath_imeras(i)
            ReDim Preserve anzkath(i)
            anzkath(i) = anzkathar
            If anzkathar = 0 Then
                freeDays += 1
            End If
        Next
        Return freeDays
    End Function
    Private Function anz_kath_imeras(ByVal i As Int16) As Int16
        Dim anz As Int16 = 0

        If geomada1(i).prufsum <> 0 Then
            anz += 1
        End If
        'If geomada2(i).prufsum <> 0 Then
        '    anz += 1
        'End If
        If geomada3(i).prufsum <> 0 Then
            anz += 1
        End If
        'If geomada4(i) <> 0 Then
        '    anz += 1
        'End If
        If geomada8(i).prufsum <> 0 Then
            anz += 1
        End If
        If thalasses(i).prufsum <> 0 Then
            anz += 1
        End If

        Return anz
    End Function
    Private Function get_geomada(ByVal column As Int16) As Int16
        Dim j As Int16
        For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
            If Me.DbhotelDataSet.katharismata(j).excelcolumn = column Then
                Return Me.DbhotelDataSet.katharismata(j).geomada
            End If
        Next
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SentBtn.Click
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Dim datum As Date
        Dim j, dipla, mona, kanap, anzkath, countgeo1, countgeo2, atoma, resultcolumn As Int16
        Dim senton, tupel As String
        Dim cell As zelle
        datum = apoKathPck.Value.Date
        Me.KatharismataTableAdapter.FillSentonia(Me.DbhotelDataSet.katharismata)
        Try
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(path)
            oSheet = oBook.Worksheets
            resultcolumn = CType(resultC, Int16)
            Do While datum <= mexriKathPck.Value.Date
                senton = ""
                mona = 0
                dipla = 0
                kanap = 0
                anzkath = 0
                atoma = 0
                countgeo1 = 0
                countgeo2 = 0
                cell = get_zelle(datum)
                For j = firstC To lastC
                    If (Not oSheet(cell.month).Cells(cell.day, j).value = "") Then
                        senton = get_infos_kath(j)

                        kanap = CType(senton.Substring(1, 1), Int16) + kanap
                        dipla = CType(senton.Substring(2, 1), Int16) + dipla
                        mona = CType(senton.Substring(3, senton.Length - 3), Int16) + mona

                        Try
                            atoma = oSheet(cell.month).Cells(cell.day, j).value.Substring(5, 1) + atoma
                        Catch ex As InvalidCastException

                        End Try
                        tupel = oSheet(cell.month).Cells(cell.day, j).value
                        If CType(senton.Substring(0, 1), Int16) = 1 Then
                            'MsgBox(tupel.Substring(7, 1).ToUpper)
                            If tupel.Substring(7, 1).ToUpper.Equals("K") Or tupel.Substring(7, 1).ToUpper.Equals("K") Then
                                countgeo1 = countgeo1 + 2
                            Else
                                countgeo1 = countgeo1 + 1
                            End If
                            anzkath = get_anz_katharistriwn(countgeo1)
                            'Str = Strings.Replace(Str, "J", "I", 1, 1)

                        Else
                            If countgeo2 = 0 Then
                                If (countgeo1 Mod 2) <> 0 Then
                                    countgeo2 = countgeo1 + 1
                                Else
                                    countgeo2 = countgeo1
                                End If
                            End If

                            If tupel.Substring(7, 1).ToUpper.Equals("K") Or tupel.Substring(7, 1).ToUpper.Equals("K") Then
                                countgeo2 = countgeo2 + 2
                            Else
                                countgeo2 = countgeo2 + 1

                            End If
                            anzkath = get_anz_katharistriwn(countgeo2)
                        End If

                        tupel = Replace(tupel, "9", anzkath, 1, 1)
                        oSheet(cell.month).Cells(cell.day, j).value = tupel '(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value())
                    End If
                Next
                If mona + dipla + kanap + atoma <> 0 Then
                    oSheet(cell.month).Cells(cell.day, resultcolumn).value = mona
                    oSheet(cell.month).Cells(cell.day, resultcolumn + 1).value = dipla
                    oSheet(cell.month).Cells(cell.day, resultcolumn + 2).value = kanap
                    oSheet(cell.month).Cells(cell.day, resultcolumn + 3).value = atoma
                End If
                datum = datum.AddDays(+1)
            Loop
        Catch ex As Runtime.InteropServices.COMException
            MsgBox("Ελέγξτε την τοποθεσία του cleanings.xlsm", MsgBoxStyle.Critical)
            'MsgBox(ex)
            oExcel.Quit()
            Exit Sub
        Catch ex3 As InvalidCastException
            MsgBox("Ελέγξτε τους παράμετρους", MsgBoxStyle.Critical)
            'MsgBox(ex)
            oExcel.Quit()
            Exit Sub
        Catch ex1 As Exception
            MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
            oExcel.Quit()
        End Try
        oExcel.Quit()
    End Sub
    'return kata seira->string: geoomada(1)+kanape(1)+dipl(1)+mona(Rest)
    Private Function get_infos_kath(ByVal column As Int16) As String
        Dim j As Int16
        Dim sent As String = ""
        For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1
            If column = Me.DbhotelDataSet.katharismata(j).excelcolumn Then
                sent = Me.DbhotelDataSet.katharismata(j).geomada.ToString + Me.DbhotelDataSet.katharismata(j).sentkanap.ToString + Me.DbhotelDataSet.katharismata(j).sentdipla.ToString +
                Me.DbhotelDataSet.katharismata(j).sentmona.ToString
                Return sent
            End If
        Next
        Return sent
    End Function
    Private Function get_anz_katharistriwn(ByVal count As Int16) As Int16
        Select Case count
            Case 0
                Return 0
            Case 1
                Return 1
            Case 2
                Return 1
            Case 3
                Return 2
            Case 4
                Return 2
            Case 5
                Return 3
            Case 6
                Return 3
            Case 7
                Return 4
            Case 8
                Return 4
            Case 9
                Return 5
            Case 10
                Return 5
            Case 11
                Return 6
            Case 12
                Return 6
            Case 13
                Return 7
            Case 14
                Return 7
            Case 15
                Return 8
            Case 16
                Return 8


        End Select
    End Function
    Private Sub KatharBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KatharBtn.Click
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Dim i, j As Int16
        Dim datum As Date
        Dim cell As zelle
        Dim tupel As String
        Dim wres As kathviles()
        Dim tupelArr As String()
        Dim hilfstring As String
        ReDim wres(9) 'mexri 7 katharistries


        For i = 0 To wres.Length - 1

            ReDim wres(i).wresvila(wresL - wresF + 1)

            'wres(i).wresvila = 0
        Next


        For i = 0 To wres.Length - 1
            For j = 0 To wres(i).wresvila.Length - 1
                wres(i).wresvila(j) = 0
            Next
            'wres(i).wresvila = 0
        Next
        Try
            'My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
            'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(path)
            oSheet = oBook.Worksheets
            'katharismos OLOY tou planou mina->Problhma: katharismoi prohgoumenwn afixewn->Den to theloume!!
            datum = vomKathPck.Value.Date
            Do While datum <= bisKahPck.Value.Date
                cell = get_zelle(datum)
                For i = wresF To wresL
                    If Not oSheet(cell.month).Cells(cell.day, i).value = "" Then '(Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""Then
                        tupel = oSheet(cell.month).Cells(cell.day, i).value
                        tupelArr = tupel.Split(",")
                        Try
                            hilfstring = Trim(tupelArr(4).Replace(")", ""))
                            If tupelArr(0).Substring(1, 1).Equals("1") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("A") Then
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wres(0).wresvila(i - wresF) = wres(0).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)


                            ElseIf tupelArr(0).Substring(1, 1).Equals("2") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Β") Then
                                'hilfstring = tupelArr(4).Replace(")", "")
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wres(1).wresvila(i - wresF) = wres(1).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("3") Then
                                wres(2).wresvila(i - wresF) = wres(2).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("4") Then
                                wres(3).wresvila(i - wresF) = wres(3).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("5") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Ε") Then
                                wres(4).wresvila(i - wresF) = wres(4).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("6") Then
                                wres(5).wresvila(i - wresF) = wres(5).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("7") Then
                                wres(6).wresvila(i - wresF) = wres(6).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("8") Then
                                wres(7).wresvila(i - wresF) = wres(7).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("9") Then
                                wres(8).wresvila(i - wresF) = wres(8).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            End If
                        Catch ex As InvalidCastException
                            oExcel.Quit()
                            MsgBox("Ελέγξτε τις ώρες καθαριστριών", MsgBoxStyle.Critical)
                        Catch ex1 As Exception
                            oExcel.Quit()
                            MsgBox("Ελέγξτε τήν μορφή (...)", MsgBoxStyle.Critical)
                        End Try


                    End If


                    'oSheet(workSheet).Range(range).Style.Font.Size = 20 '= "Times New Roman"
                Next
                datum = datum.AddDays(1)
            Loop
            For i = wresF To wresL
                If wres(0).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(34, i).value = Math.Round(wres(0).wresvila(i - wresF), 1)
                End If
                If wres(1).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(35, i).value = Math.Round(wres(1).wresvila(i - wresF), 1)
                End If
                If wres(2).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(36, i).value = Math.Round(wres(2).wresvila(i - wresF), 1)
                End If
                If wres(3).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(37, i).value = Math.Round(wres(3).wresvila(i - wresF), 1)
                End If
                If wres(4).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(38, i).value = Math.Round(wres(4).wresvila(i - wresF), 1)
                End If
                If wres(5).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(39, i).value = Math.Round(wres(5).wresvila(i - wresF), 1)
                End If
                If wres(6).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(40, i).value = Math.Round(wres(6).wresvila(i - wresF), 1)
                End If
                If wres(7).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(41, i).value = Math.Round(wres(7).wresvila(i - wresF), 1)
                End If
                If wres(8).wresvila(i - wresF) <> 0 Then
                    oSheet(cell.month).Cells(42, i).value = Math.Round(wres(8).wresvila(i - wresF), 1)
                End If
            Next

        Catch ex As Runtime.InteropServices.COMException
            MsgBox("Ελέγξτε την τοποθεσία του cleanings.xlsm", MsgBoxStyle.Critical)
            'MsgBox(ex)
            oExcel.Quit()
            Exit Sub
        Catch ex1 As Exception
            MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
            oExcel.Quit()
            Exit Sub
        End Try


        oExcel.Quit()
    End Sub

    Private Sub excelTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles excelTbx.Leave
        path = Trim(excelTbx.Text)

    End Sub

    Private Sub FirstColumnTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstColumnTbx.Leave, LastColumnTbx.Leave, resultColumnTbx.Leave, wresFirstTbx.Leave, wresLastTbx.Leave
        Dim column As String
        column = sender.text.toUpper
        Select Case column
            Case "B"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 2
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 2
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 2
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 2
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 2
                End If
            Case "C"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 3
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 3
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 3
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 3
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 3
                End If
            Case "D"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 4
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 4
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 4
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 4
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 4
                End If
            Case "E"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 5
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 5
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 5
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 5
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 5
                End If
            Case "F"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 6
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 6
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 6
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 6
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 6
                End If
            Case "G"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 7
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 7
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 7
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 7
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 7
                End If
            Case "H"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 8
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 8
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 8
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 8
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 8
                End If
            Case "I"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 9
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 9
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 9
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 9
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 9
                End If
            Case "J"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 10
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 10
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 10
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 10
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 10
                End If
            Case "K"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 11
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 11
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 11
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 11
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 11
                End If
            Case "L"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 12
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 12
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 12
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 12
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 12
                End If
            Case "M"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 13
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 13
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 13
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 13
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 13
                End If
            Case "N"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 14
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 14
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 14
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 14
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 14
                End If
            Case "O"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 15
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 15
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 15
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 15
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 15
                End If
            Case "P"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 16
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 16
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 16
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 16
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 16
                End If
            Case "Q"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 17
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 17
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 17
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 17
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 17
                End If
            Case "R"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 18
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 18
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 18
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 18
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 18

                End If
            Case "S"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 19
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 19
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 19
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 19
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 19

                End If
            Case "T"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 20
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 20
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 20
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 20
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 20

                End If
            Case "U"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 21
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 21
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 21
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 21
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 21

                End If
            Case "V"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 22
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 22
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 22
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 22
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 22

                End If
            Case "W"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 23
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 23
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 23
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 23
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 23

                End If
            Case "X"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 24
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 24
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 24
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 24
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 24

                End If
            Case "Y"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 25
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 25
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 25
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 25
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 25

                End If
            Case "Z"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 26
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 26
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 26
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 26
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 26

                End If
            Case "AA"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 27
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 27
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 27
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 27
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 27

                End If
            Case "AB"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 28
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 28
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 28
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 28
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 28

                End If
            Case "AC"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 29
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 29
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 29
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 29
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 29

                End If
            Case "AD"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 30
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 30
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 30
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 30
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 30

                End If
            Case "AE"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 31
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 31
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 31
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 31
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 31

                End If
            Case "AF"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 32
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 32
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 32
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 32
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 32

                End If
            Case "AG"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 33
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 33
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 33
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 33
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 33

                End If
            Case "AH"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 34
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 34
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 34
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 34
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 34

                End If
            Case "AI"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 35
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 35
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 35
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 35
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 35

                End If
            Case "AJ"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 36
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 36
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 36
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 36
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 36

                End If
            Case "AK"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 37
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 37
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 37
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 37
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 37

                End If
            Case "AL"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 38
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 38
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 38
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 38
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 38

                End If
            Case "AM"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 39
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 39
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 39
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 39
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 39

                End If
            Case "AN"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 40
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 40
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 40
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 40
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 40

                End If
            Case "AO"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 41
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 41
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 41
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 41
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 41

                End If
            Case "AP"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 42
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 42
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 42
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 42
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 42

                End If
            Case "AQ"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 43
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 43
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 43
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 43
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 43

                End If
            Case "AR"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 44
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 44
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 44
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 44
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 44

                End If
            Case "AS"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 45
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 45
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 45
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 45
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 45

                End If
            Case "AT"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 46
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 46
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 46
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 46
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 46

                End If
            Case "AU"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 47
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 47
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 47
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 47
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 47

                End If
            Case "AV"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 48
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 48
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 48
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 48
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 48

                End If
            Case "AW"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 49
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 49
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 49
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 49
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 49

                End If
            Case "AX"
                If sender.name.Equals("FirstColumnTbx") Then
                    firstC = 50
                End If
                If sender.name.Equals("LastColumnTbx") Then
                    lastC = 50
                End If
                If sender.name.Equals("resultColumnTbx") Then
                    resultC = 50
                End If
                If sender.name.Equals("wresFirstTbx") Then
                    wresF = 50
                End If
                If sender.name.Equals("wresLastTbx") Then
                    wresL = 50

                End If
        End Select

    End Sub
    Private Sub katharismata_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
    End Sub



    Private Sub FirstDateMonthPck_ValueChanged(sender As Object, e As EventArgs) Handles FirstDateMonthPck.Leave
        mexriDPck.Value = sender.value.addDays(6)
    End Sub

    Private Sub katharismata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.status' table. You can move, or remove it, as needed.
        Me.StatusTableAdapter.Fill(Me.DbhotelDataSet.status)

    End Sub
    Public Sub New(ByVal datum As Date, ByVal conn As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        connectionString = conn
        'Dim newCulture As New System.Globalization.CultureInfo("en-US", False)
        System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","
        FirstColumnTbx.Text = "B" '2
        firstC = 2
        'LastColumnTbx.Text = "AF" 'sentonia
        LastColumnTbx.Text = "AS" 'sentonia
        'lastC = 31 '15
        lastC = 43 '15
        wresFirstTbx.Text = "B" '2
        wresF = 2
        'wresLastTbx.Text = "AF" 'R 14
        wresLastTbx.Text = "AR" 'R 14
        'wresL = 32 '17
        wresL = 44 '17
        'resultColumnTbx.Text = "AH" 'S 15
        resultColumnTbx.Text = "AT" 'S 15
        'resultC = 34 '19
        resultC = 46 '19
        imeromErgasias = datum.Date
        FirstDateMonthPck.Value = get_monday_date_of_next_week() 'imeromErgasias
        Try
            mexriDPck.Value = FirstDateMonthPck.Value.AddDays(6)
        Catch ex As InvalidCastException
            'datumMexri = "30/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
        End Try
        ' Add any initialization after the InitializeComponent() call.
        'excelTbx.Text = "n:\winfo\cleanings.xls"
        excelTbx.Text = "n:\winfo\cleanings.xlsm"
        path = excelTbx.Text
        add_combos()
        HomeDayCbx.SelectedIndex = 6
        GrafeioForesCbx.SelectedIndex = 1
        SentWra.Text = 14
        DaysClean.Text = 3

    End Sub


    Private Sub SentWra_TextChanged(sender As Object, e As EventArgs) Handles SentWra.Leave
        Try
            If CType(sender.text, Int16) = 0 Then
                sender.text = 14
            End If
        Catch ex As InvalidCastException
            sender.text = 14
        End Try

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles DaysClean.Leave
        Try
            If CType(sender.text, Int16) < 0 Then
                sender.text = 3
            End If
        Catch ex As InvalidCastException
            sender.text = 3
        End Try
    End Sub

    Private Function kratiseis_bdomadas_hotel(ByVal connectionString As String, ByVal imerom As Date, ByVal flag As Byte) As Int16()
        Dim kratiseis(6) As Int16
        Dim j As Int16
        Using connection As New OleDb.OleDbConnection(connectionString)
            Dim command As New OleDb.OleDbCommand()
            Dim myReader As OleDb.OleDbDataReader
            Dim counter As Int16
            connection.Open()
            command.Connection = connection

            For j = 0 To 6

                command.Parameters.AddWithValue("datum", imerom.AddDays(j))
                If flag = 2 Then
                    command.Parameters.AddWithValue("kwd1", 13)
                    command.Parameters.AddWithValue("kwd2", 16)
                    command.Parameters.AddWithValue("kwd3", 22)
                    command.Parameters.AddWithValue("kwd4", 23)
                Else
                    command.Parameters.AddWithValue("kwd1", 17)
                    command.Parameters.AddWithValue("kwd2", 22)
                    command.Parameters.AddWithValue("kwd3", 24)
                    command.Parameters.AddWithValue("kwd4", 25)
                End If

                command.CommandText = " SELECT Count(*) FROM tipoi INNER JOIN (katigories INNER JOIN (dwmatia INNER JOIN kratiseis ON dwmatia.arithmos = kratiseis.dwmatio) ON katigories.kwd = dwmatia.katigoria) ON tipoi.kwd = katigories.tipos WHERE (((kratiseis.afixi)<=datum) AND ((kratiseis.anaxwrisi)>datum) AND (((tipoi.kwd)>=kwd1 And (tipoi.kwd)<=kwd2)  or   ((tipoi.kwd)>=kwd3 And (tipoi.kwd)<=kwd4))) "

                myReader = command.ExecuteReader(CommandBehavior.SingleResult)
                myReader.Read()


                Try
                    kratiseis(j) = myReader.Item(0)
                    myReader.Close()
                    command.Parameters.Clear()
                Catch ex As InvalidCastException
                    myReader.Close()
                    command.Parameters.Clear()
                    kratiseis(j) = 0
                End Try
            Next

            Return kratiseis



        End Using
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles WresBdomadas.Click
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Dim i, j As Int16
        Dim datum As Date
        Dim cell As zelle
        Dim tupel As String
        Dim wresDay() As Single
        Dim tupelArr As String()
        Dim hilfstring As String
        ReDim wresDay(9) 'mexri 7 katharistries


        For i = 0 To wresDay.Length - 1

            wresDay(i) = 0

            'wres(i).wresvila = 0
        Next


        
        Try
            'My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
            'System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(path)
            oSheet = oBook.Worksheets
            datumApo = FirstDateMonthPck.Value

            'clear all cells before write in
            datum = datumApo
            Do While datum <= mexriDPck.Value.Date
                cell = get_zelle(datum)
                For i = 0 To wresDay.Length - 1
                    oSheet(cell.month).Cells(cell.day, resultC + 4 + i).Value = ""
                Next
                datum = datum.AddDays(1)
            Loop
            ' Loop through each day in the selected range
            datum = datumApo
            Do While datum <= mexriDPck.Value.Date
                cell = get_zelle(datum)
                For i = wresF To wresL
                    If Not oSheet(cell.month).Cells(cell.day, i).value = "" Then '(Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""Then
                        tupel = oSheet(cell.month).Cells(cell.day, i).value
                        tupelArr = tupel.Split(",")
                        Try
                            hilfstring = Trim(tupelArr(4).Replace(")", ""))
                            If tupelArr(0).Substring(1, 1).Equals("1") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("A") Then
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wresDay(0) = wresDay(0) + CType(hilfstring.Replace(".", ","), Single)


                            ElseIf tupelArr(0).Substring(1, 1).Equals("2") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Β") Then
                                'hilfstring = tupelArr(4).Replace(")", "")
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wresDay(1) = wresDay(1) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("3") Then
                                wresDay(2) = wresDay(2) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("4") Then
                                wresDay(3) = wresDay(3) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("5") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Ε") Then
                                wresDay(4) = wresDay(4) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("6") Then
                                wresDay(5) = wresDay(5) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("7") Then
                                wresDay(6) = wresDay(6) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("8") Then
                                wresDay(7) = wresDay(7) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).Equals("9") Then
                                wresDay(8) = wresDay(8) + CType(hilfstring.Replace(".", ","), Single)
                            End If
                        Catch ex As InvalidCastException
                            oExcel.Quit()
                            MsgBox("Ελέγξτε τις ώρες καθαριστριών", MsgBoxStyle.Critical)
                        Catch ex1 As Exception
                            oExcel.Quit()
                            MsgBox("Ελέγξτε τήν μορφή (...)", MsgBoxStyle.Critical)
                        End Try


                    End If


                    'oSheet(workSheet).Range(range).Style.Font.Size = 20 '= "Times New Roman"
                Next
                For i = 0 To wresDay.Length - 1
                    If wresDay(i) <> 0 Then

                        oSheet(cell.month).Cells(cell.day, resultC + 4 + i).value = Math.Round(wresDay(i), 1)


                    End If
                Next
                For i = 0 To wresDay.Length - 1

                    wresDay(i) = 0

                    'wres(i).wresvila = 0
                Next
                datum = datum.AddDays(1)
            Loop


        Catch ex As Runtime.InteropServices.COMException
            MsgBox("Ελέγξτε την τοποθεσία του cleanings.xlsm", MsgBoxStyle.Critical)
            'MsgBox(ex)
            oExcel.Quit()
            Exit Sub
        Catch ex1 As Exception
            MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
            oExcel.Quit()
            Exit Sub
        End Try


        oExcel.Quit()





    End Sub

End Class