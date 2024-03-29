Imports Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Net.Mail
Imports Google.GData.Calendar
Imports Google.GData.Extensions
Imports Google.GData.Client
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Newsletter
    Dim connectionString As String
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    Private Sub planoBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendBtn.Click
        Dim response As MsgBoxResult

        If PraktChk.Checked Then

            response = MsgBox("Να αποσταλούν μαζικά mail σ'όλα τα επιλεγμένα πρακτορεία;", MsgBoxStyle.YesNo, "winfo\nikEl.")
            If response = MsgBoxResult.Yes Then
                Dim theThread _
                        As New Threading.Thread(AddressOf SendMailtoPraktoreia)

                theThread.Start()
            End If

        Else

            response = MsgBox("Να αποσταλούν μαζικά mail σ'όλες τις Διευθύνσεις του αρχείου 'Renting_emails';", MsgBoxStyle.YesNo, "winfo\nikEl.")

            If response = MsgBoxResult.Yes Then
                Dim theThread _
                        As New Threading.Thread(AddressOf SendMailtoAll)
                theThread.CurrentCulture = englishCulture
                theThread.Start()
            End If

        End If


    End Sub
    Private Sub SendMailtoPraktoreia()
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject, name As String
        Dim instance As Attachment
        Dim j, i As Int16
        name = ""
        from = Me.DbhotelDataSet.Mail(0).ffrom
        subject = Me.DbhotelDataSet.Mail(3).subject
        smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
        smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
        smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
        body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(3).body

        If Not attachTbx.Text.Equals("") Then
            Try
                instance = New Attachment(attachTbx.Text)
            Catch ex1 As System.IO.FileNotFoundException
                MsgBox("Δεν βρέθηκε Attachment ", MsgBoxStyle.Exclamation)

                Exit Sub
            End Try
        Else
        End If
        DbhotelDataSet1.EnforceConstraints = False
        Dim mailadapter1 As New dbhotelDataSet1TableAdapters.praktoreiaTableAdapter
        mailadapter1.FillPraktoreiaforNewsetter(Me.DbhotelDataSet1.praktoreia)

        For j = 0 To Me.DbhotelDataSet1.praktoreia.Count - 1

            Try
                i = Me.DbhotelDataSet1.praktoreia(j).email.IndexOf("@") ' einai sosto to mail->dld periexei @??
                If i <> -1 Then
                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)

                    'If Not IsDBNull(Me.DbhotelDataSet.praktoreia(j).Item("ipeuthinos")) Then
                    '    Name = Me.DbhotelDataSet.praktoreia(j).ipeuthinos
                    'Else
                    '    Name = ""
                    'End If
                    name = ""

                    'MsgBox("Sending Email to " + Me.DbhotelDataSet1.vilapraktoreia1(j).email)

                    SendMail(from, Me.DbhotelDataSet1.praktoreia(j).email, subject, body, instance, smtpServer, smtpUsername, smtpPassword)
                End If
            Catch ex As NullReferenceException

            End Try

        Next

        'SendMail(from, "mkallergis@gmail.com", "TEST", body, instance, smtpServer, smtpUsername, smtpPassword)
    End Sub


    Private Sub SendMailtoAll()
        Dim from, body, smtpServer, smtpUsername, smtpPassword, subject, name As String
        Dim mailTemp As String
        Dim endOK As Boolean = False
        Dim i, k As Int16
        Dim instance As Attachment
        Dim oExcel As Microsoft.Office.Interop.Excel.Application
        Dim oBook As Microsoft.Office.Interop.Excel.Workbook
        Dim oSheet As Microsoft.Office.Interop.Excel.Sheets

        Try
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Open(excelTbx.Text)
            oSheet = oBook.Worksheets
            from = Me.DbhotelDataSet.Mail(0).ffrom
            subject = Me.DbhotelDataSet.Mail(3).subject
            smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
            smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
            smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
            If Not attachTbx.Text.Equals("") Then
                Try
                    instance = New Attachment(attachTbx.Text)
                Catch ex1 As System.IO.FileNotFoundException
                    MsgBox("Δεν βρέθηκε Attachment ", MsgBoxStyle.Exclamation)
                    oExcel.Quit()
                    Exit Sub
                End Try
            Else
            End If
            i = 1
            Do While True
                mailTemp = oSheet(1).Cells(i, 1).value
                Try
                    If mailTemp.Equals("") Then
                        Exit Do
                    End If
                Catch ex As NullReferenceException
                    Exit Do
                End Try
                Try
                    name = oSheet(1).Cells(i, 2).value
                Catch ex As NullReferenceException
                    name = ""
                End Try

                body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + Me.DbhotelDataSet.Mail(3).body 'Me.DbhotelDataSet.Mail(3).body
                k = mailTemp.IndexOf("@")

                If k <> -1 Then
                    SendMail(from, mailTemp, subject, body, instance, smtpServer, smtpUsername, smtpPassword)
                    i += 1
                End If
            Loop
            oExcel.Quit()
            Exit Sub
        Catch ex As Runtime.InteropServices.COMException
            'MsgBox("Ελέγξτε την τοποθεσία του Renting_emails.xls", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)
            oExcel.Quit()
            Exit Sub
        End Try


    End Sub
    Public Shared Sub SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal instance As Attachment, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        Try

            Dim mailMessage As New MailMessage(from, [to], subject, body)
            If instance IsNot Nothing Then
                mailMessage.Attachments.Add(instance)
            End If

            'Dim LinkedImage As New LinkedResource("C:\winfo\iperion.jpg")
            Dim LinkedImage As New LinkedResource("C:\winfo\eugenios.jpg")
            LinkedImage.ContentId = "MyPic"
            ' Dim LinkedImage2 As New LinkedResource("C:\winfo\ikaros.jpg")
            Dim LinkedImage2 As New LinkedResource("C:\winfo\rethymno.jpg")
            LinkedImage2.ContentId = "MyPic2"
            Dim htmlView As AlternateView
            htmlView = AlternateView.CreateAlternateViewFromString(
               body + " <img src=cid:MyPic> <br> <img src=cid:MyPic2>", Nothing, "text/html")

            htmlView.LinkedResources.Add(LinkedImage)
            htmlView.LinkedResources.Add(LinkedImage2)
            mailMessage.AlternateViews.Add(htmlView)

            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True

            smtpClient.Send(mailMessage)

        Catch ex1 As System.IO.FileNotFoundException
            MsgBox("Δεν βρέθηκε το Attachment ", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture
        excelTbx.Text = "\\SYNOLOGYNAS\Data\winfo\Renting_emails.xls"
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ' Add any initialization after the InitializeComponent() call.
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString 'Me.DbhotelDataSet.etaireia(0).connectionstring

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        If Not IsDBNull(Me.DbhotelDataSet.Mail(3).Item("subject")) Then
            subjectagTbx.Text = Me.DbhotelDataSet.Mail(3).subject
        End If
        If Not IsDBNull(Me.DbhotelDataSet.Mail(3).Item("body")) Then
            bodyagRTbx.Text = Me.DbhotelDataSet.Mail(3).body
        End If
        If Not IsDBNull(Me.DbhotelDataSet.Mail(3).Item("attachment")) Then
            attachTbx.Text = Me.DbhotelDataSet.Mail(3).attachment
        End If

    End Sub

    Private Sub emailagBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles emailagBtn.Click
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            'Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("@subject", subjectagTbx.Text)
            command.Parameters.AddWithValue("@body", bodyagRTbx.Text)
            command.Parameters.AddWithValue("@attachment", attachTbx.Text)
            command.CommandText = "UPDATE Mail SET subject=@subject,body=@body,attachment=@attachment WHERE (kwd=4)" '  FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
            command.ExecuteNonQuery()
            ' Always call Read before accessing data.
        End Using
    End Sub
    Private Sub bodyagRTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bodyagRTbx.Leave
        Me.DbhotelDataSet.Mail(3).body = sender.text
    End Sub

    Private Sub subjectagTbx_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles subjectagTbx.Leave
        Me.DbhotelDataSet.Mail(3).subject = sender.text
    End Sub

    Private Sub Newsletter_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'System.Threading.Thread.CurrentThread.CurrentCulture = greekCulture
    End Sub

    Private Sub PraktChk_CheckedChanged(sender As Object, e As EventArgs) Handles PraktChk.CheckedChanged
        If sender.checked Then
            excelTbx.Enabled = False
            Label7.Enabled = False
            Label2.Enabled = False
        Else
            excelTbx.Enabled = True
            Label7.Enabled = True
            Label2.Enabled = True
        End If
    End Sub


    Private Sub Image1_Click(sender As Object, e As EventArgs) Handles Image1.Click
        Dim dialog As New OpenFileDialog
        Image1Txt.Clear()
        dialog.InitialDirectory = "C:\winfo\images\"
        dialog.Filter = "Image files|*.jpg"


        If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Image1Txt.Text = dialog.FileName
        End If
        '    My.Computer.FileSystem.WriteAllText(TextBox1.Text, TextBox1.Text, False)
    End Sub
End Class