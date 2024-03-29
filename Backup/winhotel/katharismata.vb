Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop

Public Class katharismata
    Dim imeromErgasias As Date
    Dim datumApo, datumMexri As Date
    Dim path As String
    Dim firstC, lastC, resultC, wresF, wresL As Int16
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    'Dim engCult As New System.Globalization.CultureInfo("en-US", False)
    'Dim grCult As New System.Globalization.CultureInfo("el", False)
    Structure zelle
        Dim month As Int16
        Dim day As Int16
    End Structure
    Structure kathviles
        Dim wresvila As Single()
    End Structure
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles planoBtn.Click
        Dim workSheet As Int16 'minas apo apr kai meta 
        'Start a new workbook in Excel.
        System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
        datumApo = FirstDateMonthPck.Value
        Try
            datumMexri = "31/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
        Catch ex As InvalidCastException
            datumMexri = "30/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
        End Try
        workSheet = FirstDateMonthPck.Value.Month - 3 ' anagogi giati ksekinaw apo Aprilio
        Me.DbhotelDataSet.praktoreia.Constraints.Clear()
        Me.KatharismataTableAdapter.FillKatharismataByApoMexri(Me.DbhotelDataSet.katharismata, datumApo, datumMexri)

        make_katharismata(workSheet)
        'For j = 1 To 31
        'datum = j.ToString + "/12/2014"
        'oSheet(9).Cells(j + 1, 1).value = datum
        'Next
    End Sub
   
    Private Sub make_katharismata(ByVal workSheet As Int16)
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
        Dim j, i As Int16
        'Dim range As String
        If Me.DbhotelDataSet.katharismata.Count <> 0 Then
            Try
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Open(path)
                oSheet = oBook.Worksheets
                'katharismos OLOY tou planou mina->Problhma: katharismoi prohgoumenwn afixewn->Den to theloume!!
                'For j = (datumApo.Day + 1) To datumMexri.Day + 1
                '    For i = FirstColumnTbx.Text To LastColumnTbx.Textzxczx
                '        oSheet(workSheet).Cells(j, i).value = ""
                '        range = get_range(i, j)

                '        oSheet(workSheet).Range(range).Interior.Color = RGB(255, 250, 250)
                '        oSheet(workSheet).Range(range).Font.Bold = True
                '        oSheet(workSheet).Range(range).HorizontalAlignment = 3
                '        'oSheet(workSheet).Range(range).Style.Font.Size = 20 '= "Times New Roman"
                '    Next

                'Next
                'oExcel.Quit()
                'Exit Sub

                'oSheet(workSheet).Range("B2:B2").Style.Font.Size = 12
                'oExcel.Quit()
                'Exit Sub
                For j = 0 To Me.DbhotelDataSet.katharismata.Count - 1

                    berechne_katharismata_kratisis(j, oBook, oSheet)

                    Try
                        datumMexri = "31/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
                    Catch ex As InvalidCastException
                        datumMexri = "30/" + FirstDateMonthPck.Value.Month.ToString + "/" + imeromErgasias.Year.ToString
                    End Try
                Next
            Catch ex As Runtime.InteropServices.COMException
                MsgBox("Ελέγξτε την τοποθεσία του cleanings.xls", MsgBoxStyle.Critical)
                'MsgBox(ex)
                oExcel.Quit()
                Exit Sub
            Catch ex1 As Exception
                MsgBox("Πρόβλημα στο άνοιγμα τουν αρχείου cleanings", MsgBoxStyle.Critical)
                oExcel.Quit()
            End Try
            oExcel.Quit()
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
            If kathOK Then
               
                'MsgBox(sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value)
                If (Not sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "") AndAlso sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value.Contains("O") Then
                    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,D," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"

                    sheet(cell.month).Range(range).Interior.Color = RGB(255, 0, 0)
                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                ElseIf datum = Me.DbhotelDataSet.katharismata(index).afixi Then
                    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,I," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 0) 'RGB(255, 255, 0)(255,255,0)
                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                Else
                    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255)
                    '.SILVER
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                End If
            Else
                sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,S," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",A," + Me.DbhotelDataSet.katharismata(index).wresallagi.ToString + ")"
                sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 255) 'RGB(0, 255, 0)
                'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
            End If

            For j = 0 To Me.DbhotelDataSet.katharismata(index).sentonia - 1
                datum = datum.AddDays(1)
                cell = get_zelle(datum)
                range = get_range((Me.DbhotelDataSet.katharismata(index).excelcolumn), cell.day)
                sheet(cell.month).Range(range).Font.Bold = True
                sheet(cell.month).Range(range).HorizontalAlignment = 3
                sheet(cell.month).Range(range).Style.Font.Size = 11
                If datum = Me.DbhotelDataSet.katharismata(index).anaxwrisi Then
                    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = "(9,O," + Me.DbhotelDataSet.katharismata(index).anzethnikotites.ToString + ",K," + Me.DbhotelDataSet.katharismata(index).wreskath.ToString + ")"
                    sheet(cell.month).Range(range).Interior.Color = RGB(0, 255, 0)
                    'style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue)
                    'sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).style = "NewStyle"
                    Exit Sub
                Else
                    sheet(cell.month).Cells(cell.day, Me.DbhotelDataSet.katharismata(index).excelcolumn).value = ""
                    sheet(cell.month).Range(range).Interior.Color = RGB(255, 255, 255)
                End If
            Next
            kathOK = Not kathOK

        Loop

    End Sub
    Private Function get_zelle(ByVal datum As Date) As zelle
        Dim zelle As zelle

        zelle.month = datum.Month - 3
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

        End Select
        Return range
        'oSheet.Range("A1:A1").Interior.Color = RGB(255, 100, 120)
    End Function
    Public Sub New(ByVal datum As Date)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'Dim newCulture As New System.Globalization.CultureInfo("en-US", False)
        System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","
        FirstColumnTbx.Text = "B" '2
        firstC = 2
        LastColumnTbx.Text = "H" '8
        lastC = 8
        wresFirstTbx.Text = "B" '2
        wresF = 2
        wresLastTbx.Text = "N" '14
        wresL = 14
        resultColumnTbx.Text = "O" ' 15
        resultC = 15
        imeromErgasias = datum.Date
        FirstDateMonthPck.Value = imeromErgasias
        ' Add any initialization after the InitializeComponent() call.
        excelTbx.Text = "\\SYNOLOGYNAS\Data\winfo\cleanings.xls"
        path = excelTbx.Text
    End Sub


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
                            If tupel.Substring(7, 1).ToUpper.Equals("K") Or tupel.Substring(7, 1).ToUpper.Equals("Κ") Then
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

                            If tupel.Substring(7, 1).ToUpper.Equals("K") Or tupel.Substring(7, 1).ToUpper.Equals("Κ") Then
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
            MsgBox("Ελέγξτε την τοποθεσία του cleanings.xls", MsgBoxStyle.Critical)
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
                sent = Me.DbhotelDataSet.katharismata(j).geomada.ToString + Me.DbhotelDataSet.katharismata(j).sentkanap.ToString + Me.DbhotelDataSet.katharismata(j).sentdipla.ToString + _
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
        ReDim wres(6) 'mexri 7 katharistries


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
                            If tupelArr(0).Substring(1, 1).ToUpper.Equals("A") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Α") Then
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wres(0).wresvila(i - wresF) = wres(0).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)

                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("B") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Β") Then
                                'hilfstring = tupelArr(4).Replace(")", "")
                                'MsgBox(CType(hilfstring.Replace(".", ","), Single))
                                wres(1).wresvila(i - wresF) = wres(1).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("C") Then
                                wres(2).wresvila(i - wresF) = wres(2).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("D") Then
                                wres(3).wresvila(i - wresF) = wres(3).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("E") OrElse tupelArr(0).Substring(1, 1).ToUpper.Equals("Ε") Then
                                wres(4).wresvila(i - wresF) = wres(4).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("F") Then
                                wres(5).wresvila(i - wresF) = wres(5).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
                            ElseIf tupelArr(0).Substring(1, 1).ToUpper.Equals("G") Then
                                wres(6).wresvila(i - wresF) = wres(6).wresvila(i - wresF) + CType(hilfstring.Replace(".", ","), Single)
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
            Next

        Catch ex As Runtime.InteropServices.COMException
            MsgBox("Ελέγξτε την τοποθεσία του cleanings.xls", MsgBoxStyle.Critical)
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
        End Select

    End Sub
    Private Sub katharismata_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
    End Sub
End Class