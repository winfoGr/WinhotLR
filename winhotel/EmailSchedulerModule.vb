Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Imports System.Threading
Imports System.Configuration
Imports System.IO
Imports System.Threading.Tasks

Module EmailSchedulerModule
    Dim dataset As New DataSet()
    Dim connectionString As String
    Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
    Dim dbhotelDataSet As New dbhotelDataSet()
    Public Sub Main()
        ' Retrieve the connection string from the configuration file
        LoadVillasLinksData(dataset)

        mailadapter.Fill(dbhotelDataSet.Mail)
        Dim schedulerThread As New Thread(AddressOf SchedulerThreadMethod)
        schedulerThread.Start()
    End Sub
    Public Sub MainKratisis(ByVal kwdikos As Int64)
        ' Retrieve the connection string from the configuration file
        LoadVillasLinksData(dataset)

        mailadapter.Fill(dbhotelDataSet.Mail)
        Dim kratisiThread As New Thread(AddressOf KratisiThreadMethod)
        kratisiThread.Start(kwdikos)
    End Sub
    Private Sub KratisiThreadMethod(ByVal kwdikos As Int16)
        Try

            If Not ReservationEmailSent(kwdikos) Then
                SendEmail(kwdikos)
            End If


        Finally
            ' Clean up resources and perform any necessary actions here
        End Try

    End Sub
    Private Sub SchedulerThreadMethod()
        While True
            ' Check if the email was not sent for any user at the specified time
            If Not WasTemplateEmailSent1() Then
                ' Send the email immediately
                SendEmail(1)
            End If
            If Not WasTemplateEmailSent60() Then
                ' Send the email immediately
                SendEmail(60)
            End If
            If Not WasTemplateEmailSentNewKratsisi() Then
                ' Send the email immediately
                SendEmail(-1)
            End If
            If Not WasDirectionsmailSentNewKratsisi() Then
                ' Send the email immediately
                SendEmailDirections(-1)
            End If
            If Not WasDirectionsmailSent15() Then
                ' Send the email immediately
                SendEmailDirections(15)
            End If
            If Not WasEmailResidents() Then
                ' Send the email immediately
                SendEmailResidents(-1)
            End If
            ' Calculate the time until the next target time
            If Not WasFeedbackEmailSent() Then
                ' Send the email immediately
                SendEmailFeedback()
            End If
            'SendEmailFeedback()
            Dim now As DateTime = DateTime.Now
            Dim targetTime As New DateTime(now.Year, now.Month, now.Day, 0, 0, 0)

            Dim nextTargetTime As DateTime
            If now < targetTime Then
                nextTargetTime = targetTime
            Else
                nextTargetTime = targetTime.AddDays(1)
            End If

            Dim sleepTime As TimeSpan = nextTargetTime - now

            ' Sleep until the next target time
            Thread.Sleep(sleepTime)
        End While
    End Sub
    Private Function WasFeedbackEmailSent() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos"
        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "FEEDBACK")
                'command.Parameters.AddWithValue("@state", 1)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Sub LoadVillasLinksData(ByVal dataset As DataSet)
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString
        Dim query As String = "SELECT * FROM dbo.villaslinks"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using adapter As New SqlDataAdapter(query, connection)
                adapter.Fill(dataset, "VillasLinks")
            End Using
        End Using
    End Sub
    Private Function ReservationEmailSent(ByVal arkratisis As Int16) As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE ReservationNumber=@arithmos AND Eidos = @eidos AND State=@state"


        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@arithmos", arkratisis)
                command.Parameters.AddWithValue("@eidos", "RESERVATION")
                command.Parameters.AddWithValue("@state", 4)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasEmailResidents() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "RESIDENTS")
                command.Parameters.AddWithValue("@state", 1)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasDirectionsmailSent15() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "DIRECTIONS")
                command.Parameters.AddWithValue("@state", 2)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasDirectionsmailSentNewKratsisi() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "DIRECTIONS")
                command.Parameters.AddWithValue("@state", 1)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasTemplateEmailSent1() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date
        currentDate = Date.Now.Date
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "TEMPLATE")
                command.Parameters.AddWithValue("@state", 3)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasTemplateEmailSent60() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "TEMPLATE")
                command.Parameters.AddWithValue("@state", 2)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function
    Private Function WasTemplateEmailSentNewKratsisi() As Boolean
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "SELECT COUNT(*) FROM SentEmails WHERE CAST(SentDateTime AS DATE) = @currentDate AND Eidos = @eidos AND State=@state"

        Dim currentDate As Date = Date.Now.Date

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@currentDate", currentDate)
                command.Parameters.AddWithValue("@eidos", "TEMPLATE")
                command.Parameters.AddWithValue("@state", 1)
                Dim result As Integer = CInt(command.ExecuteScalar())

                Return result > 0
            End Using
        End Using
    End Function

    Private Function getVilaData(ByVal dataset As DataSet, ByVal vilaToSearch As String) As List(Of String)
        Dim result As New List(Of String)()

        Dim rowIndex As Integer = -1
        Dim dataTable As DataTable = dataset.Tables("VillasLinks")
        For i As Integer = 0 To dataTable.Rows.Count - 1
            If dataTable.Rows(i)("vila").ToString() = vilaToSearch Then
                rowIndex = i
                Exit For ' Exit the loop when a match is found
            End If
        Next

        If rowIndex <> -1 Then
            ' The rowIndex variable now contains the index of the row with the matching vila name
            ' You can access other column values of that row if needed
            Dim vilaname As String = dataTable.Rows(rowIndex)("Vilaname").ToString()
            Dim vilamage As String = dataTable.Rows(rowIndex)("vilamage").ToString()
            Dim vilalink As String = dataTable.Rows(rowIndex)("vilalink").ToString()
            result.Add(dataTable.Rows(rowIndex)("Vilaname").ToString())
            result.Add(dataTable.Rows(rowIndex)("vilamage").ToString())
            result.Add(dataTable.Rows(rowIndex)("vilalink").ToString())

            Return result
            ' Do something with the retrieved values
            Console.WriteLine("Row found at index: " & rowIndex)
            Console.WriteLine("Vilaname: " & vilaname)
            Console.WriteLine("Vilamage: " & vilamage)
            Console.WriteLine("Vilalink: " & vilalink)
        Else
            ' No row found with the matching vila name
            Console.WriteLine("No matching row found.")
        End If
        Return result
    End Function


    Private Sub SendEmailFeedback()
        Dim portalPath As String = ConfigurationManager.AppSettings("PortalPath")
        'Dim datum As Date = Date.Today.AddDays(-27) 19
        Dim datum As Date = Date.Today.AddDays(2)

        ' Fill dataset with emails
        Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis1TableAdapter
        anaxadapter.FillQuestionareEmail(dbhotelDataSet.AfixeisAnaxwriseis1, datum, True, False, 1, 12)

        ' Create a thread-safe dictionary to track sent emails
        Dim sentEmails As New Concurrent.ConcurrentDictionary(Of String, Boolean)()

        ' Parallel processing for sending emails
        Parallel.ForEach(dbhotelDataSet.AfixeisAnaxwriseis1, Sub(row)
                                                                 If Not row.eponimia.Equals("Βασιλάκης Κώστας") Then
                                                                     If Not IsDBNull(row.Item("voucher")) Then
                                                                         Dim email As String = row.voucher
                                                                         Dim i As Integer = email.IndexOf("@")

                                                                         If i <> -1 Then
                                                                             ' Check if the email was already sent (use TryAdd to prevent duplicates)
                                                                             If sentEmails.TryAdd(email, True) Then
                                                                                 ' Get the guest's name and room description (perigrafi)
                                                                                 Dim name As String = If(Not IsDBNull(row.Item("onomateponimo")), row.onomateponimo, "")
                                                                                 Dim perigrafi As String = New dbhotelDataSetTableAdapters.dwmatiaTableAdapter().GetPerigrafiByVila(row.dwmatio)

                                                                                 ' Prepare email body for this specific email
                                                                                 Dim body As String = dbhotelDataSet.Mail(0).body
                                                                                 Dim questionFormPath As String = portalPath + row.kwd.ToString()
                                                                                 Dim questionnaireLink As String = "<a href='" & questionFormPath & "'>Follow this link to provide your feedback</a>"

                                                                                 ' Replace placeholders in the body for this specific email
                                                                                 body = body.Replace("[GuestName]", name).
                                    Replace("[VillaName]", perigrafi).
                                    Replace("[FeedbackLink]", questionnaireLink)

                                                                                 ' Send the email and log it if successful
                                                                                 If SendMailQuestion(dbhotelDataSet.Mail(0).ffrom, email, dbhotelDataSet.Mail(0).subject, body, dbhotelDataSet.Mail(0).smtpServer, dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword) Then
                                                                                     StoreEmailSent("FEEDBACK", email, Date.Today, row.dwmatio, name, row.afixi, row.anaxwrisi, row.arithmos, 1, Environment.MachineName)
                                                                                 End If
                                                                             End If
                                                                         End If
                                                                     End If
                                                                 End If
                                                             End Sub)
    End Sub



    Function SendMailQuestion(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String) As Boolean
        'Dim fileName As String = "C:\winfo\testAtach.xlsx"

        Dim pathstart As String = ""
        Try


            Dim message As New MailMessage(from, [to], subject, body)
            message.IsBodyHtml = True
            message.Bcc.Add("mkallergis@gmail.com")
            'message.Bcc.Add("stakap15@gmail.com")
            ' MsgBox(fileName)
            'message.Attachments.Add(instance)

            Dim smtpClient As New SmtpClient(smtpServer, 25)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)
            Return True



        Catch ex As Exception
            Return False
        End Try




    End Function


    Private Sub SendEmailResidents(ByVal daysAdd As Int16)
        Dim j, i As Int16
        Dim mailTemp, from, name As String
        Dim recipients As New List(Of String)


        Dim etos As Integer
        'Dim x As Integer = 7 ' Number of days in the future
        'Dim datum As Date
        Dim message As New MailMessage()
        'Dim htmlTemplate As String
        Dim diamenadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
        Dim datum As Date = Date.Today
        datum = datum.AddDays(daysAdd)
        'MsgBox(datum1)
        'etos = datum.Year

        'Dim datum As Date = New Date(2023, 7, 14) ' Replace with your desired date
        'MsgBox(datum)
        etos = datum.Year

        If daysAdd = -1 Then
            diamenadapter.FillDiamenontesByAfixi(
    dbhotelDataSet.AfixeisAnaxwriseis2, datum, etos)
        End If



        For j = 0 To dbhotelDataSet.AfixeisAnaxwriseis2.Count - 1


            If Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) And Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
                i = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                If i <> -1 Then
                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                    If Not dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then

                        mailTemp = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher

                        'mailTemp = "mkallergis@gmail.com"

                        recipients.Add(mailTemp)
                        'If mailTemp.Count > 0 Then




                    End If
                End If
            End If


        Next
        Try
            'Dim vilaData As New List(Of String)()
            'vilaData = getVilaData(dataset, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio)
            If Not IsDBNull(dbhotelDataSet.Mail(7).Item("attachment")) Then
                If recipients.Count > 0 Then
                    If SendMailDIamenontesAttach(dbhotelDataSet.Mail(0).ffrom, recipients, dbhotelDataSet.Mail(2).subject, dbhotelDataSet.Mail(2).body, dbhotelDataSet.Mail(7).Item("attachment"), dbhotelDataSet.Mail(0).smtpServer, dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword) Then
                        Dim concatenatedRecipients As String = String.Join(",", recipients)

                        StoreEmailSent("RESIDENTS", concatenatedRecipients, Date.Today, "", "", Date.Today, Date.Today, 0, 1, Environment.MachineName)
                    End If

                End If

            End If


            ' mailTemp = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher '"mkallergis@gmail.com" 'dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher



        Catch ex As Exception

        End Try

        ' Retrieve the email information from the dataset


        ' Store the email sent information in the database

    End Sub
    Function SendMailDIamenontesAttach(ByVal from As String, ByVal recipients As List(Of String), ByVal subject As String, ByVal body As String, ByVal attachment As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String) As Boolean
        Dim j As Int16

        Try
            Dim message As New MailMessage()

            message.From = New MailAddress(from)
            For Each recipient As String In recipients

                message.Bcc.Add(recipient)
                Exit For
            Next

            message.Subject = subject
            message.Body = body


            If attachment <> "" Then
                Try
                    Dim instance As New Attachment(attachment)

                    message.Attachments.Add(instance)

                Catch ex As System.IO.DirectoryNotFoundException
                    Return False
                End Try

            End If



            'Dim instance As New Attachment(fileName)

            Dim smtpClient As New SmtpClient(smtpServer, 587)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)
            Return True


        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub SendEmailDirections(ByVal daysAdd As Int16)
        Dim j, i As Int16
        Dim mailTemp, from, name As String
        'Dim dbhotelDataSet As New dbhotelDataSet()

        'Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        'mailadapter.Fill(dbhotelDataSet.Mail)
        Dim etos As Integer
        'Dim x As Integer = 7 ' Number of days in the future
        'Dim datum As Date
        Dim message As New MailMessage()
        'Dim htmlTemplate As String
        Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
        Dim datum As Date = Date.Today
        datum = datum.AddDays(daysAdd)
        'MsgBox(datum1)
        'etos = datum.Year

        'Dim datum As Date = New Date(2023, 7, 14) ' Replace with your desired date
        'MsgBox(datum)
        etos = datum.Year

        If daysAdd > 0 Then
            anaxadapter.AfixeisByEtosImeromTpoikwd_(
    dbhotelDataSet.AfixeisAnaxwriseis2,
    etos, datum, datum, datum, datum, 1, 12, etos, datum, datum, datum, 1, 12, datum
)
        ElseIf daysAdd = -1 Then

            anaxadapter.FillKratiseisByImeromKratisis(dbhotelDataSet.AfixeisAnaxwriseis2, datum)

        End If


        'Dim smtpClient As New SmtpClient(dbhotelDataSet.Mail(0).smtpServer, 25)

        'smtpClient.UseDefaultCredentials = False

        'Dim credentials As New NetworkCredential(dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword)
        'anaxadapter.Fill(dbhotelDataSet.AfixeisAnaxwriseis2)
        '    anaxadapter.AfixeisByEtosImeromTpoikwd_(
        '    dbhotelDataSet.AfixeisAnaxwriseis2, etos, datum, datum, datum, datum, 1, 12, etos, datum, datum, datum, 1, 12, datum
        ')
        'If dbhotelDataSet.AfixeisAnaxwriseis2.Rows.Count > 0 Then
        '    MsgBox("YES")
        'End If



        For j = 0 To dbhotelDataSet.AfixeisAnaxwriseis2.Count - 1


            If Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) And Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
                i = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                If i <> -1 Then
                    'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                    If Not dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then


                        'If mailTemp.Count > 0 Then


                        Try
                            'Dim vilaData As New List(Of String)()
                            'vilaData = getVilaData(dataset, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio)

                            from = dbhotelDataSet.Mail(0).ffrom

                            message.Subject = dbhotelDataSet.Mail(2).subject

                            If Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
                                name = dbhotelDataSet.AfixeisAnaxwriseis2(j).onomateponimo

                            Else
                                name = ""
                            End If
                            message.Body = "Dear Mrs./Mr. " + name + "," + ChrW(13) + ChrW(13) + dbhotelDataSet.Mail(2).body

                            'mailTemp = "mkallergis@gmail.com"
                            mailTemp = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher '"mkallergis@gmail.com" 'dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher

                            If SendMailMultiAttachKratisis(from, mailTemp, message.Subject, message.Body, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, dbhotelDataSet.Mail(0).smtpServer, dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword) Then
                                If daysAdd = 1 Then
                                    StoreEmailSent("DIRECTIONS", mailTemp, Date.Today, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 3, Environment.MachineName)

                                ElseIf daysAdd = 15 Then
                                    StoreEmailSent("DIRECTIONS", mailTemp, Date.Today, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 2, Environment.MachineName)
                                ElseIf daysAdd = -1 Then
                                    StoreEmailSent("DIRECTIONS", mailTemp, Date.Today, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio, name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 1, Environment.MachineName)
                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If
                End If
            End If


        Next


        ' Retrieve the email information from the dataset


        ' Store the email sent information in the database

    End Sub
    Function SendMailMultiAttachKratisis(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal dwmatio As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String) As Boolean
        Dim j As Int16
        Dim instance As Attachment
        Dim pathstart As String = ""
        Dim fileName As String = ""
        Dim directionsAdapter As New dbhotelDataSetTableAdapters.directionsTableAdapter
        Dim directionsTable As New dbhotelDataSet.directionsDataTable
        directionsAdapter.FillDirectionsByVila(directionsTable, dwmatio)
        Try

            Dim message As New MailMessage(from, [to], subject, body)

            For j = 0 To directionsTable.Count - 1
                If Not IsDBNull(directionsTable(j).Item("path")) Then
                    Try

                        instance = New Attachment(directionsTable(j).path)
                        message.Attachments.Add(instance)

                    Catch ex As System.IO.DirectoryNotFoundException
                        Return False
                    End Try

                End If
            Next

            If message.Attachments.Count <> 0 Then
                Dim smtpClient As New SmtpClient(smtpServer, 587)

                smtpClient.UseDefaultCredentials = False

                Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

                smtpClient.Credentials = credentials
                smtpClient.EnableSsl = True
                smtpClient.Send(message)
                Return True
            End If

            'Dim instance As New Attachment(fileName)

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub SendEmail(ByVal daysAdd As Int64)
        Dim anaxadapter As New dbhotelDataSetTableAdapters.AfixeisAnaxwriseis2TableAdapter
        Dim datum As Date = Date.Today
        Dim j, i As Int16
        Dim mailTemp, from, name, body As String
        'Dim dbhotelDataSet As New dbhotelDataSet()

        'Dim mailadapter As New dbhotelDataSetTableAdapters.MailTableAdapter
        'mailadapter.Fill(dbhotelDataSet.Mail)
        Dim etos As Integer
        'Dim x As Integer = 7 ' Number of days in the future
        'Dim datum As Date
        Dim message As New MailMessage()
        Dim htmlTemplate As String


        If daysAdd = 1 OrElse daysAdd = 60 OrElse daysAdd = -1 Then
            datum = datum.AddDays(daysAdd)
        End If




        'MsgBox(datum1)
        'etos = datum.Year

        'Dim datum As Date = New Date(2023, 7, 14) ' Replace with your desired date
        'MsgBox(datum)
        etos = datum.Year

        If daysAdd = 1 OrElse daysAdd = 60 Then
            anaxadapter.AfixeisByEtosImeromTpoikwd_(
    dbhotelDataSet.AfixeisAnaxwriseis2,
    etos, datum, datum, datum, datum, 1, 12, etos, datum, datum, datum, 1, 12, datum
)
        ElseIf daysAdd = -1 Then

            anaxadapter.FillKratiseisByImeromKratisis(dbhotelDataSet.AfixeisAnaxwriseis2, datum)
        Else
            anaxadapter.FillByArithmokratisis(dbhotelDataSet.AfixeisAnaxwriseis2, daysAdd)

        End If


        'Dim smtpClient As New SmtpClient(dbhotelDataSet.Mail(0).smtpServer, 587)

        'smtpClient.UseDefaultCredentials = False

        'Dim credentials As New NetworkCredential(dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword)

        body = GetHTMLTemplate()

        If Not String.IsNullOrEmpty(body) Then
            For j = 0 To dbhotelDataSet.AfixeisAnaxwriseis2.Count - 1

                If Not dbhotelDataSet.AfixeisAnaxwriseis2(j).eponimia.Equals("Βασιλάκης Κώστας") Then
                    If Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("voucher")) Then
                        i = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.IndexOf("@") ' einai sosto to mail->dld periexei @??
                        If i <> -1 Then
                            'gia  na min ksanasteilw sto IDIO mai (ean exoun kataxorithei >1 onmata se mia kratisi)
                            If Not dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher.Equals(mailTemp) Then


                                'If mailTemp.Count > 0 Then


                                Try
                                    Dim vilaData As New List(Of String)()
                                    vilaData = getVilaData(dataset, dbhotelDataSet.AfixeisAnaxwriseis2(j).dwmatio)
                                    If vilaData.Count > 0 Then
                                        from = dbhotelDataSet.Mail(0).ffrom

                                        message.Subject = "Your Reservation!"
                                        htmlTemplate = body
                                        htmlTemplate = htmlTemplate.Replace("[VILLA_NAME]", vilaData(0))
                                        If Not IsDBNull(dbhotelDataSet.AfixeisAnaxwriseis2(j).Item("onomateponimo")) Then
                                            htmlTemplate = htmlTemplate.Replace("[VILLA_PELATIS]", dbhotelDataSet.AfixeisAnaxwriseis2(j).onomateponimo)
                                            name = dbhotelDataSet.AfixeisAnaxwriseis2(j).onomateponimo
                                        Else
                                            htmlTemplate = htmlTemplate.Replace("[VILLA_PELATIS]", "Customer")
                                            name = ""
                                        End If
                                        htmlTemplate = htmlTemplate.Replace("[imglink]", vilaData(1))
                                        htmlTemplate = htmlTemplate.Replace("[vilalink]", vilaData(2))
                                        message.Body = htmlTemplate
                                        'message.IsBodyHtml = True
                                        'message.To.Add("mkallergis@gmail.com")
                                        'mailTemp = "mkallergis@gmail.com"
                                        mailTemp = dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher '"mkallergis@gmail.com" 'dbhotelDataSet.AfixeisAnaxwriseis2(j).voucher
                                        'If dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos = 4618 Then
                                        If SendMail(from, mailTemp, message.Subject, message.Body, dbhotelDataSet.Mail(0).smtpServer, dbhotelDataSet.Mail(0).smtpUsername, dbhotelDataSet.Mail(0).smtpPassword) Then
                                            If daysAdd = 1 Then
                                                StoreEmailSent("TEMPLATE", mailTemp, Date.Today, vilaData(0), name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 3, Environment.MachineName)

                                            ElseIf daysAdd = 60 Then
                                                StoreEmailSent("TEMPLATE", mailTemp, Date.Today, vilaData(0), name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 2, Environment.MachineName)
                                            ElseIf daysAdd = -1 Then
                                                StoreEmailSent("TEMPLATE", mailTemp, Date.Today, vilaData(0), name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 1, Environment.MachineName)
                                            Else
                                                StoreEmailSent("RESERVATION", mailTemp, Date.Today, vilaData(0), name, dbhotelDataSet.AfixeisAnaxwriseis2(j).afixi, dbhotelDataSet.AfixeisAnaxwriseis2(j).anaxwrisi, dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos, 4, Environment.MachineName)
                                            End If
                                        End If
                                        'End If


                                        'If dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos = 4620 Or dbhotelDataSet.AfixeisAnaxwriseis2(j).arithmos = 4618 Then

                                        'End If


                                    End If






                                Catch ex1 As System.IO.FileNotFoundException

                                End Try

                            End If
                        End If
                    End If
                End If

            Next
        Else
            MsgBox("Template not found! Can't send experience email!", MsgBoxStyle.Exclamation)
        End If

        ' Retrieve the email information from the dataset


        ' Store the email sent information in the database

    End Sub
    Function SendMail(ByVal from As String, ByVal [to] As String, ByVal subject As String, ByVal body As String, ByVal smtpServer As String, ByVal smtpUsername As String, ByVal smtpPassword As String) As Boolean

        Try

            Dim message As New MailMessage()
            message.From = New MailAddress(from)
            message.Subject = subject
            message.Body = body
            message.To.Add([to])
            'message.Bcc.Add("mkallergis@gmail.com")
            message.IsBodyHtml = True

            Dim smtpClient As New SmtpClient(smtpServer, 587)

            smtpClient.UseDefaultCredentials = False

            Dim credentials As New NetworkCredential(smtpUsername, smtpPassword)

            smtpClient.Credentials = credentials
            smtpClient.EnableSsl = True
            'TEST
            smtpClient.Send(message)

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
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
    Private Sub StoreEmailSent(ByVal eidos As String, ByVal recip As String, ByVal sentdate As Date, ByVal villa As String, ByVal pelatis As String, ByVal afixi As Date, ByVal anax As Date, ByVal kratisinumber As Int16, ByVal status As Byte, ByVal userpc As String)
        connectionString = ConfigurationManager.ConnectionStrings("winhotel.My.MySettings.dbhotelConnectionString1").ConnectionString ' Replace with your database connection string
        Dim query As String = "INSERT INTO dbo.SentEmails (Eidos, Recipient, SentDateTime, Villa, Onoma, Afixi, Anaxwrisi, ReservationNumber, State, Userpc ) " &
                              "VALUES (@eidos, @recipient, @sendTime, @villa, @onoma, @afixi, @anaxwrisi, @reservationNumber, @state, @userpc)"

        Dim currentTime As DateTime = DateTime.Now
        Dim targetTime As New DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 0, 0, 0)

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@eidos", eidos) ' Replace with the actual Eidos value
                command.Parameters.AddWithValue("@recipient", recip) ' Replace with the actual recipient value
                command.Parameters.AddWithValue("@sendTime", sentdate) ' Set the SentDateTime to the targetTime
                command.Parameters.AddWithValue("@villa", villa) ' Replace with the actual Villa value
                If pelatis Is Nothing Then
                    command.Parameters.AddWithValue("@onoma", DBNull.Value)
                Else
                    command.Parameters.AddWithValue("@onoma", pelatis)
                End If
                ' Replace with the actual Onoma value
                command.Parameters.AddWithValue("@afixi", afixi) ' Replace with the actual Afixi value
                command.Parameters.AddWithValue("@anaxwrisi", anax) ' Replace with the actual Anaxwrisi value
                command.Parameters.AddWithValue("@reservationNumber", kratisinumber) ' Replace with the actual ReservationNumber value

                command.Parameters.AddWithValue("@state", status)
                command.Parameters.AddWithValue("@userpc", userpc)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub


End Module
