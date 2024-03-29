Imports Microsoft.Office.Interop.Excel
Public Class RentingsXls
    Dim emailto, datei As String
    Public Sub New(ByVal email As String, ByVal connstring As String)
        emailto = email

        datei = get_directory(connstring) + "Renting_emails.xls"
        Dim theThread _
                    As New Threading.Thread(AddressOf write_adreess)

        theThread.Start()
        'MsgBox(datei)
    End Sub

    Private Sub write_adreess()
        Dim istFound As Boolean = False
        Dim row As Int16 = 1
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets

        Try
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(datei)
            oSheet = oBook.Worksheets
            oBook.Application.DisplayAlerts = False
            While Not istFound
                If oSheet(1).Cells(row, 1).value = "" Then
                    istFound = True

                Else

                    row += 1
                End If

            End While
            oSheet(1).Cells(row, 1).value = emailto
            oSheet.Application.SaveWorkspace()
            oExcel.Quit()
        Catch ex As Exception
            oExcel.Quit()
        End Try

    End Sub
    Private Function get_directory(ByVal name As String) As String
        Return name.Substring(0, name.Length - 11)
    End Function

End Class
