Imports System.Net
Imports System.Net.Mail
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class SendEmailTemplate
    Dim imeromergasias As Date
    Dim connectionString As String
    Dim greekCulture As New System.Globalization.CultureInfo("el-GR", False)
    Dim englishCulture As New System.Globalization.CultureInfo("en-US", False)
    Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    Dim subject, body As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        ' Add any initialization after the InitializeComponent() call.
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Me.DbhotelDataSet.etaireia(0).connectionstring

        mailadapter.Fill(Me.DbhotelDataSet.Mail)
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim from, smtpServer, smtpUsername, smtpPassword As String
        Dim mailTemp As New List(Of String)
        Try

            from = Me.DbhotelDataSet.Mail(0).ffrom
            subject = subjectagTbx.Text
            from = Me.DbhotelDataSet.Mail(0).ffrom



            smtpServer = Me.DbhotelDataSet.Mail(0).smtpServer
            smtpUsername = Me.DbhotelDataSet.Mail(0).smtpUsername
            smtpPassword = Me.DbhotelDataSet.Mail(0).smtpPassword


            'For j = 0 To Me.DbhotelDataSet.AfixeisAnaxwriseis2.Count - 1

            '    If Not IsDBNull(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then

            '        i = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
            '        If i <> -1 Then
            '            'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
            '            If Not Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailCurrent) Then
            '                ' mailTemp = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher
            '                mailCurrent = Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher


            '                If Not mailTemp.Contains(mailCurrent) Then
            '                    mailTemp.Add(mailCurrent)
            '                End If


            '                ' mailTemp.Add(Me.DbhotelDataSet.AfixeisAnaxwriseis2(j).voucher)
            '                '     SendMail(from, mailTemp, subject, body, attach, smtpServer, smtpUsername, smtpPassword)
            '            End If
            '        End If
            '    End If



            'Next
            'mailTemp.Add("stakap15@gmail.com")
            mailTemp.Add("mkallergis@gmail.com")
            'If mailTemp.Count > 0 Then
            body = GetHTMLTemplate()
            SendMail(from, mailTemp, subject, body, smtpServer, smtpUsername, smtpPassword)

            'End If

            Exit Sub
        Catch ex As Exception
            'MsgBox("Ελέγξτε την τοποθεσία του Renting_emails.xls", MsgBoxStyle.Critical)
            MsgBox(ex.ToString)

            Exit Sub
        End Try
    End Sub
    Function GetHTMLTemplate() As String
        'Dim templatePath As String = "C:\Users\user\source\repos\winhotSSTxWebCm_dom\winhotel\email_template.html"
        Dim templatePath As String = ConfigurationManager.AppSettings("EmailTemplatePath")
        If File.Exists(templatePath) Then
            Return File.ReadAllText(templatePath)
        Else
            Console.WriteLine("Template file not found.")
            Return String.Empty
        End If
    End Function



    Public Sub SendMail(ByVal from As String, ByVal [to] As List(Of String), ByVal subject As String, ByVal htmlTemplate As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String)
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"
        Dim toAddress, item As String

        Try

            'Dim instance As New Attachment(fileName)
            Dim message As New MailMessage()
            message.From = New MailAddress(from)
            message.Subject = subject
            htmlTemplate = htmlTemplate.Replace("[VILLA_NAME]", "Ikaros")
            htmlTemplate = htmlTemplate.Replace("[VILLA_PELATIS]", "Marinakis")
            htmlTemplate = htmlTemplate.Replace("[imglink]", "https://creteholidayhome.com/wp-content/uploads/2023/04/test.webp")
            htmlTemplate = htmlTemplate.Replace("[vilalink]", "https://creteholidayhome.com/accommodation/villa-theros/")
            message.Body = htmlTemplate
            message.IsBodyHtml = True
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





    End Sub


    Private Sub SendEmailTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbhotelDataSet.etaireia' table. You can move, or remove it, as needed.
        Me.EtaireiaTableAdapter.Fill(Me.DbhotelDataSet.etaireia)
        'TODO: This line of code loads data into the 'DbhotelDataSet.Mail' table. You can move, or remove it, as needed.
        Me.MailTableAdapter.Fill(Me.DbhotelDataSet.Mail)

    End Sub
End Class