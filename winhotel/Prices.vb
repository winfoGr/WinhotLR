Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Public Class Prices
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    Dim path As String
    Dim oExcel As Microsoft.Office.Interop.Excel.Application
    Dim oBook As Microsoft.Office.Interop.Excel.Workbook
    Dim oSheet As Microsoft.Office.Interop.Excel.Sheets
    Dim connectionString As String
    Public Sub New(ByVal conn As String, ByVal index As Byte, ByVal file As String)

        Dim i As Int16
        ' This call is required by the Windows Form Designer.

        'Dim newCulture As New System.Globalization.CultureInfo("en-US", False)
        System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = ","

        ' Add any initialization after the InitializeComponent() call.

        ' excelTbx.Text = "c:\winfo\cleanings.xls"
        path = file
        oExcel = CreateObject("Excel.Application")
        oBook = oExcel.Workbooks.Open(path)
        oSheet = oBook.Worksheets
        connectionString = conn
        'row eidos
        Try
            make_timokatalogous(2, index)

            If index = 2 Then
                MsgBox(" Ενημερώθηκε η βάση!")
            End If
        Catch ex As Exception
            MsgBox(" Παρουσιάστηκε πρόβλημα!")
        End Try
    End Sub
    Private Sub make_timokatalogous(ByVal j As Int16, ByVal index As Byte)
        Dim i As Int16
        Dim tupel As String
        Dim tupelArr As String()
        'bres keno row
        i = finde_next_table(j)

        If i <= 100 Then
            ' (i,3) sto filo 6 iterationen ->3 giati prokeitai gia 3 simbolaia!!!! gia kathe row!!! sos
            tupel = oSheet(6).Cells(i, 1).value
            tupelArr = tupel.Split(".")
            If index = 1 Then
                'gia
                load_prices_to_excel(i, 3, tupelArr(0), tupelArr(1))
                make_timokatalogous(i + tupelArr(0) + 1, index)
            ElseIf index = 2 Then
                write_prices_to_db(i, 6, tupelArr(0), tupelArr(1))
                make_timokatalogous(i + tupelArr(0) + 1, index)
            End If
        Else
            oExcel.Quit()
        End If
        'If index = 2 Then
        '    MsgBox(" Ενημερώθηκε η βάση!")
        'End If

        ' MsgBox("Επιτυχής ενημέρωση τιμών!")
    End Sub
    Private Function finde_next_table(ByVal j As Int16) As Int16
        '    Dim j As Int16 = 1B
        Dim notFound As Boolean = True

        While notFound
            'MsgBox(oSheet(1).Cells(j, 1).value)
            If CType(oSheet(6).Cells(j, 1).value, String) <> "" Then
                notFound = False
            Else
                j += 1
                If j > 100 Then
                    Return j
                End If
            End If
        End While
        Return j
    End Function
    'Private Sub write_prices_to_db(ByVal i As Int16, ByVal j As Int16, ByVal high As Int16, ByVal width As Int16)
    '    Dim x, y As Int16
    '    Dim kwdtim As Int32
    '    Dim price As Single

    '    Using connection As New OleDb.OleDbConnection(connectionString)
    '        Dim command, command1 As New OleDb.OleDbCommand()

    '        connection.Open()
    '        command.Connection = connection
    '        command1.Connection = connection

    '        For y = i To i + high - 1

    '            For x = j To j + width - 1

    '                Try
    '                    price = CType(oSheet(3).Cells(y, x).value, Single)

    '                    kwdtim = CType(oSheet(6).Cells(y, x).value, Int32)
    '                    '      MsgBox(price.ToString + "   KWDIKOS" + kwdtim.ToString)
    '                    If price <> 0 AndAlso kwdtim > 0 Then
    '                        command.Parameters.AddWithValue("timiatomo", price)
    '                        command.Parameters.AddWithValue("ipnos", price)
    '                        command.Parameters.AddWithValue("kwd", kwdtim)
    '                        command.CommandText = "UPDATE times SET timiatomo=?, ipnos=? WHERE kwd=?" ' (simfonies.simbolaio=?) and (simfonies.aa=?)  and (simfonies.tipos=?) and and (simfonies.aa=?) and (simfonies.tipos=?) and (simfonies.season=?) (simfonies.simbolaio=?) and distinct simfonies.kwd  (simfonies.aa=?) and (simfonies.tipos=?) and (simfonies.season=?) and
    '                        command.ExecuteNonQuery()
    '                        command.Parameters.Clear()
    '                    End If


    '                Catch ex As InvalidCastException

    '                End Try

    '            Next

    '        Next
    '    End Using
    'End Sub
    Private Sub write_prices_to_db(ByVal i As Int16, ByVal j As Int16, ByVal high As Int16, ByVal width As Int16)
        Dim x, y As Int16
        Dim kwdtim As Int32
        Dim price As Single

        Using connection As New SqlConnection(connectionString)
            Dim command, command1 As New SqlCommand()

            connection.Open()
            command.Connection = connection
            command1.Connection = connection

            For y = i To i + high - 1
                For x = j To j + width - 1
                    Try
                        price = CType(oSheet(3).Cells(y, x).Value, Single)
                        kwdtim = CType(oSheet(6).Cells(y, x).Value, Int32)
                        If price <> 0 AndAlso kwdtim > 0 Then
                            command.Parameters.AddWithValue("@timiatomo", price)
                            command.Parameters.AddWithValue("@ipnos", price)
                            command.Parameters.AddWithValue("@kwd", kwdtim)
                            command.CommandText = "UPDATE times SET timiatomo=@timiatomo, ipnos=@ipnos WHERE kwd=@kwd"
                            command.ExecuteNonQuery()
                            command.Parameters.Clear()
                        End If
                    Catch ex As InvalidCastException
                        ' Handle the exception as needed
                    End Try
                Next
            Next
        End Using
    End Sub

    Private Sub load_prices_to_excel(ByVal i As Int16, ByVal j As Int16, ByVal high As Int16, ByVal width As Int16)
        Dim x, y As Int16
        Dim tupel As String
        Dim tupelArr As String()
        Dim simfkwd, kwdtim As Int32
        Dim price As Single

        Using connection As New SqlConnection(connectionString)
            Dim command, command1 As New SqlCommand()
            Dim myReader As SqlDataReader
            Dim myReader1 As SqlDataReader
            connection.Open()
            command.Connection = connection
            command1.Connection = connection

            For y = i To i + high - 1

                tupel = oSheet(6).Cells(y, 2).value
                '         MsgBox(oSheet(1).Cells(3, 14).value)
                '     MsgBox(oSheet(1).Cells(y, j + bima - 1).value)
                tupelArr = tupel.Split(".")

                For x = j To j + width - 1

                    command.Parameters.AddWithValue("@simbolaio", CType(tupelArr(x), Int32))
                    command.Parameters.AddWithValue("@aa", tupelArr(2))
                    command.Parameters.AddWithValue("@tipos", tupelArr(1).ToString())
                    command.Parameters.AddWithValue("@season", tupelArr(0))

                    command.CommandText = "SELECT DISTINCT simfonies.kwd FROM simfonies WHERE (simfonies.simbolaio=@simbolaio) AND (simfonies.aa=@aa) AND (simfonies.tipos=@tipos) AND (simfonies.season=@season)"

                    myReader = command.ExecuteReader()
                    command.Parameters.Clear()


                    While myReader.Read()

                        Try
                            simfkwd = myReader.GetInt32(0)

                            command1.Parameters.AddWithValue("simfonia", simfkwd)
                            command1.CommandText = "SELECT kwd,ipnos FROM times where simfonia=?"
                            myReader1 = command1.ExecuteReader()
                            command1.Parameters.Clear()

                            While myReader1.Read()
                                price = myReader1.GetFloat(1)
                                kwdtim = myReader1.GetInt32(0)
                                oSheet(3).Cells(y, x + 3).value = price
                                oSheet(6).Cells(y, x + 3).value = kwdtim
                            End While
                            myReader1.Close()

                        Catch ex As InvalidOperationException
                            ' myReader.Close()

                        End Try

                    End While

                    myReader.Close()

                Next

            Next
        End Using
    End Sub
End Class
