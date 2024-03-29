'Imports Microsoft.Office.Interop.Excel
Imports System.Net
Imports System.Net.Mail
Imports Google.GData.Calendar
Imports Google.GData.Extensions
Imports Google.GData.Client
Imports System.Configuration
Imports System.Data.SqlClient
Public Class SendMailDiamenontes
    Dim imeromergasias As Date
    Dim connectionString As String
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    Dim body, subject As String
    Dim attachList As New List(Of String)

    Private Sub emailagBtn_Click(sender As Object, e As EventArgs) Handles emailagBtn.Click
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand()
            'Dim myReader As OleDb.OleDbDataReader
            connection.Open()
            command.Connection = connection
            command.Parameters.AddWithValue("@subject", subjectagTbx.Text)
            command.Parameters.AddWithValue("@body", bodyagRTbx.Text)
            command.Parameters.AddWithValue("@attachment", attachTbx.Text)
            command.CommandText = "UPDATE Mail SET subject=@subject,body=@body,attachment=@attachment WHERE (kwd=6)" '  FROM parastatika INNER JOIN afm ON parastatika.etaireia=afm.kwd WHERE (parastatika.kwd=?)" 'and (identifikation=?)
            command.ExecuteNonQuery()
            ' Always call Read before accessing data.
        End Using
    End Sub


    Private Sub sendBtn_Click(sender As Object, e As EventArgs) Handles sendBtn.Click

        If CheckBox1.Checked Then
            Me.KratiseisTableAdapter.FillAnamenontesByAfIn(Me.DbhotelDataSet11.kratiseis, ImeromPck.Value.Date, ImeromPck.Value.Date, False)
        End If


        Dim response As MsgBoxResult
        Try
            If Not String.IsNullOrEmpty(bodyagRTbx.Text) Then
                If Not String.IsNullOrEmpty(subjectagTbx.Text) Then
                    If Not CheckBox1.Checked Then
                        response = MsgBox("Να αποσταλούν μαζικά mail σ'όλους τους Διαμένοντες;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                    Else
                        response = MsgBox("Να αποσταλούν μαζικά mail στους πελάτες που αναμένονται στις " + ImeromPck.Value.Date + " να διαμένουν ;", MsgBoxStyle.YesNo, "winfo\nikEl.")
                    End If

                    body = bodyagRTbx.Text
                    '    attach = attachTbx.Text
                    subject = subjectagTbx.Text
                    If response = MsgBoxResult.Yes Then
                        If Not CheckBox1.Checked Then
                            Dim theThread _
                               As New Threading.Thread(AddressOf SendMailtoAllDiamwenontes)
                            theThread.CurrentCulture = englishCulture
                            theThread.Start()
                        Else
                            Dim theThread _
                                                          As New Threading.Thread(AddressOf SendMailtoAllAnamenontes)
                            theThread.CurrentCulture = englishCulture
                            theThread.Start()
                        End If
                    End If
                Else
                    MsgBox("Subject δεν μπορεί να είναι κενό!", MsgBoxStyle.Critical)

                End If
            Else
                MsgBox("Body δεν μπορεί να είναι κενό!", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SendMailtoAllDiamwenontes()
        Dim from, smtpServer, smtpUsername, smtpPassword As String
        '  Dim mailTemp As String
        Dim mailTemp As New List(Of String)
        Dim i, j As Int16
        Dim mailCurrent As String = ""
        '  Dim instance As Attachment

        Try

            from = Me.DbhotelDataSet.Mail(0).ffrom
            subject = subjectagTbx.Text
            from = Me.DbhotelDataSet.Mail(0).ffrom



            smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
            smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
            smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
            'If Not attachTbx.Text.Equals("") Then
            '    Try
            '        instance = New Attachment(attachTbx.Text)
            '    Catch ex1 As System.IO.FileNotFoundException
            '        'MsgBox(ex1.ToString)
            '        MsgBox("Δεν βρέθηκε Attachment ", MsgBoxStyle.Exclamation)

            '        Exit Sub
            '    End Try
            'Else
            'End If

            For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1

                If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then

                    i = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                    If i <> -1 Then
                        'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                        If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailCurrent) Then
                            ' mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher
                            mailCurrent = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher


                            If Not mailTemp.Contains(mailCurrent) Then
                                mailTemp.Add(mailCurrent)
                            End If


                            ' mailTemp.Add(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher)
                            '     SendMail(from, mailTemp, subject, body, attach, smtpServer, smtpUsername, smtpPassword)
                        End If
                    End If
                End If



            Next

            If mailTemp.Count > 0 Then
                SendMail(from, mailTemp, subject, body, smtpServer, smtpUsername, smtpPassword)

            End If

            Exit Sub
        Catch ex As Exception
            'MsgBox("Ελέγξτε την τοποθεσία του Renting_emails.xls", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)

            Exit Sub
        End Try



    End Sub
    Private Sub SendMailtoAllAnamenontes()
        Dim from, smtpServer, smtpUsername, smtpPassword, name As String

        Dim mailCurrent As String = ""
        Dim i, j As Int16
        Dim mailTemp As New List(Of String)
        '  Dim instance As Attachment

        Try

            from = Me.DbhotelDataSet.Mail(0).ffrom
            subject = subjectagTbx.Text
            from = Me.DbhotelDataSet.Mail(0).ffrom



            smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
            smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
            smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword
            'If Not attachTbx.Text.Equals("") Then
            '    Try
            '        instance = New Attachment(attachTbx.Text)
            '    Catch ex1 As System.IO.FileNotFoundException
            '        MsgBox("Δεν βρέθηκε Attachment ", MsgBoxStyle.Exclamation)

            '        Exit Sub
            '    End Try
            'Else
            'End If

            For j = 0 To Me.DbhotelDataSet11.kratiseis.Count - 1

                If Not IsDBNull(Me.DbhotelDataSet11.kratiseis(j).Item("voucher")) Then

                    i = Me.DbhotelDataSet11.kratiseis(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                    If i <> -1 Then
                        'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                        If Not Me.DbhotelDataSet11.kratiseis(j).voucher.Equals(mailCurrent) Then
                            mailCurrent = Me.DbhotelDataSet11.kratiseis(j).voucher

                            If Not mailTemp.Contains(mailCurrent) Then
                                mailTemp.Add(mailCurrent)
                            End If





                            '     SendMail(from, mailTemp, subject, body, attach, smtpServer, smtpUsername, smtpPassword)
                        End If
                    End If
                End If



            Next
            'mailTemp.Add("mkallergis@gmail.com")
            'If Not mailTemp.Contains("mkallergis@gmail.com") Then
            '    mailTemp.Add("mkallergis@web.de")
            'End If
            'mailTemp.Add("mkallergis@web.de")
            'mailTemp.Add("nikallergis@gmail.com")
            'mailTemp.Add("dlahnidakis@yahoo.gr")
            'If Not mailTemp.Contains("stakap15@gmail.com") Then
            '    mailTemp.Add("stakap15@gmail.com")
            'End If
            'If Not mailTemp.Contains("stakap15@gmail.com") Then
            '    mailTemp.Add("creteholidayhome@gmail.com")
            'End If

            'mailTemp.Add("domisioffice@gmail.com")

            'mailTemp.Add("domisilogistirio@gmail.com ")
            If mailTemp.Count > 0 Then
                SendMail(from, mailTemp, subject, body, smtpServer, smtpUsername, smtpPassword)

            End If



            Exit Sub
        Catch ex As Exception
            'MsgBox("Ελέγξτε την τοποθεσία του Renting_emails.xls", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)

            Exit Sub
        End Try



    End Sub
    Public Sub SendMail(ByVal from As String, ByVal [to] As List(Of String), ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        Dim toAddress, item As String
        If attachList.Count = 0 Then
            Try

                'Dim instance As New Attachment(fileName)
                Dim message As New MailMessage()
                message.From = New MailAddress(from)
                message.Subject = subject
                message.Body = body
                For Each toAddress In [to]
                    message.Bcc.Add(toAddress)
                Next

                'message.Attachments.Add(instance)

                Dim smtpClient As New SmtpClient(smtpServer, 25)

                smtpClient.UseDefaultCredentials = False

                Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                smtpClient.Credentials = credentials
                smtpClient.EnableSsl = True
                smtpClient.Send(message)


            Catch ex1 As System.IO.FileNotFoundException
                MsgBox("Δεν βρέθηκε το Attachment για Questionare", MsgBoxStyle.Exclamation)
            Catch ex3 As System.FormatException
                MsgBox("Η Διεύθυνση email για αποστολή Questionare είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
            Catch ex2 As System.IO.DirectoryNotFoundException
                MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Questionare ", MsgBoxStyle.Exclamation)

            Catch ex As Exception
                MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
            End Try
        Else
            Try
                Dim message As New MailMessage()
                Dim instance As Attachment
                For Each item In attachList
                    instance = New Attachment(item)
                    message.Attachments.Add(instance)
                Next
                '  Dim message As New MailMessage(from, [to], subject, body)

                message.From = New MailAddress(from)
                message.Subject = subject
                message.Body = body

                For Each toAddress In [to]
                    message.Bcc.Add(toAddress)
                Next

                Dim smtpClient As New SmtpClient(smtpServer, 25)

                smtpClient.UseDefaultCredentials = False

                Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                smtpClient.Credentials = credentials
                smtpClient.EnableSsl = True
                smtpClient.Send(message)


            Catch ex1 As System.IO.FileNotFoundException
                MsgBox("Δεν βρέθηκε το Attachment για Questionare", MsgBoxStyle.Exclamation)
            Catch ex3 As System.FormatException
                MsgBox("Η Διεύθυνση email για αποστολή Questionare είναι λάθος καταχωρημένη ", MsgBoxStyle.Exclamation)
            Catch ex2 As System.IO.DirectoryNotFoundException
                MsgBox("Δεν βρέθηκε o φάκελος για αποστολή Questionare ", MsgBoxStyle.Exclamation)

            Catch ex As Exception
                MsgBox("Αδυναμία αποστολής email ", MsgBoxStyle.Exclamation)
            End Try
        End If





    End Sub


    Public Sub New()

        Dim dwmApo, dwmEws As String
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        CheckBox1.Checked = False
        ImeromPck.Enabled = False
        'System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture

        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ' Add any initialization after the InitializeComponent() call.
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Me.DbhotelDataSet.etaireia(0).connectionstring

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        If Not IsDBNull(Me.DbhotelDataSet.Mail(5).Item("subject")) Then
            subjectagTbx.Text = Me.DbhotelDataSet.Mail(5).subject
        End If
        If Not IsDBNull(Me.DbhotelDataSet.Mail(5).Item("body")) Then
            bodyagRTbx.Text = Me.DbhotelDataSet.Mail(5).body
        End If
        If Not IsDBNull(Me.DbhotelDataSet.Mail(5).Item("attachment")) Then
            attachTbx.Text = Me.DbhotelDataSet.Mail(5).attachment
        End If
        imeromergasias = Me.DbhotelDataSet.etaireia(0).imeromergasias
        dwmApo = ""
        dwmEws = Me.DwmatiaTableAdapter.GetMaxArDwmatiou
        Me.AfixeisAnaxwriseis2TableAdapter.DiamenontesByEtosImeromDwmTipoi_(Me.DbhotelDataSet.AfixeisAnaxwriseis2, imeromergasias.Year, dwmApo, dwmEws, True, imeromergasias, imeromergasias, imeromergasias, imeromergasias, imeromergasias, 1, 12, imeromergasias.Year, True, imeromergasias, imeromergasias, imeromergasias, 1, 12, imeromergasias, imeromergasias)

    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If sender.checked Then
            ImeromPck.Enabled = True
        Else
            ImeromPck.Enabled = False

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim j As Int16
        'set the root to the z drive
        openFileDialog1.InitialDirectory = "c:\"
        'make sure the root goes back to where the user started
        openFileDialog1.RestoreDirectory = True
        'show the dialog
        openFileDialog1.ShowDialog()
        Try
            attachTbx.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName)
            attachList.Add(attachTbx.Text)
        Catch ex As ArgumentException
            attachTbx.Text = String.Empty
        Catch ex1 As NullReferenceException
            attachTbx.Text = String.Empty
        End Try
        path1Lbl.Text = "selected file 1"
        path2Lbl.Text = "selected file 2"
        path3Lbl.Text = "selected file 3"
        If attachList.Count > 0 Then
            For j = 0 To attachList.Count - 1
                If j = 0 Then
                    path1Lbl.Text = attachList.Item(j)
                ElseIf j = 1 Then
                    path2Lbl.Text = attachList.Item(j)
                ElseIf j = 2 Then
                    path3Lbl.Text = attachList.Item(j)
                End If
            Next
        End If


    End Sub
End Class