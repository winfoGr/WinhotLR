Imports System.IO
Imports System.Threading
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Web
Imports WebConnect
Module CalendarExtrernalInit
    Dim connectionString_ As String


    Private service As CalendarService
    Sub Main(ByVal conn As String)
        connectionString_ = conn


        ' Authenticate and obtain access to calendars
        Authenticate()
        Dim querySelect As String = "SELECT calendar.vila, calendar.ical " &
                             "FROM calendar " &
                             "WHERE calendar.shared=@shared;"

        Dim queryDelete As String = "DELETE FROM status WHERE kratisi=-1 AND enarxi >= @currentTime;"
        Dim deletedCount As Integer = 0 ' Variable to store the count of deleted records
        Using connection As New SqlConnection(connectionString_)
            connection.Open()

            ' Execute the delete command
            Using deleteCommand As New SqlCommand(queryDelete, connection)
                ' Set the parameter for current time
                deleteCommand.Parameters.AddWithValue("@currentTime", DateTime.UtcNow)
                deletedCount = deleteCommand.ExecuteNonQuery()
            End Using

            ' Execute the select command
            Using selectCommand As New SqlCommand(querySelect, connection)
                ' Add the shared parameter to the select command
                selectCommand.Parameters.AddWithValue("@shared", 1)

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = selectCommand.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row
                        Dim calendarid As String = HttpUtility.UrlDecode(reader.GetString(1))
                        Dim eventid As String
                        eventid = ListEvents(reader.GetString(0), calendarid)
                        If Not String.IsNullOrEmpty(eventid) Then
                            Console.WriteLine($"eventid: {eventid},  calendarid: {calendarid}")
                        End If
                        ' Process the retrieved values (e.g., display or store them)
                    End While
                End Using
            End Using
        End Using

    End Sub

    Private Sub Authenticate()
        ' Path to the client secrets JSON file
        Dim clientSecretsPath As String = "c:\winfo\client_secrets.json"

        ' Define scopes (permissions) required for accessing calendars
        Dim scopes As New List(Of String)()
        scopes.Add(CalendarService.Scope.Calendar)

        ' Load client secrets and authenticate user
        Try
            Using stream As New FileStream(clientSecretsPath, FileMode.Open, FileAccess.Read)
                Dim credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                                                                             scopes,
                                                                             "domisioffice@gmail.com",
                                                                             CancellationToken.None,
                                                                             New FileDataStore("Calendar.VB.Sample")).Result
                ' Create the calendar service using an initializer instance
                Dim initializer As New BaseClientService.Initializer()
                initializer.HttpClientInitializer = credential
                initializer.ApplicationName = "VB.NET Calendar Sample"
                service = New CalendarService(initializer)
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error authenticating: {ex.Message}")
        End Try
    End Sub
    Private Function ListEvents(villa As String, calendarId As String) As String
        Try
            ' Define parameters for the events request
            'Dim request As EventsResource.ListRequest = service.Events.List(calendarId)
            'request.TimeMin = New DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)

            '' Set the end of the year 2023 as the maximum time
            'request.TimeMax = New DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc)
            'request.ShowDeleted = False
            'request.SingleEvents = True
            'request.MaxResults = 100
            Dim currentDate As DateTime = DateTime.UtcNow
            Dim endOfYear As DateTime = New DateTime(currentDate.Year, 12, 31, 23, 59, 59, DateTimeKind.Utc)

            Dim request As EventsResource.ListRequest = service.Events.List(calendarId)
            request.TimeMin = currentDate
            request.TimeMax = endOfYear
            request.ShowDeleted = False
            request.SingleEvents = True
            request.MaxResults = 100
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime

            ' Execute the request and retrieve the events
            Dim events As Events = request.Execute()

            ' Display the events
            If events.Items IsNot Nothing AndAlso events.Items.Count > 0 Then
                Console.WriteLine($"Upcoming events from {calendarId}:")
                For Each eventItem As [Event] In events.Items
                    Dim start As String = If(eventItem.Start.DateTime.HasValue, eventItem.Start.DateTime.ToString(), eventItem.Start.Date)
                    Console.WriteLine($"{start} - {eventItem.Id} - {eventItem.Start.Date}- {eventItem.End.Date}- {eventItem.Summary} -{eventItem.Description}")
                    InsertStatus(villa, eventItem.Start.Date, eventItem.End.Date)

                Next
            Else
                Console.WriteLine($"No upcoming events found in {calendarId}.")
                Return Nothing
            End If
        Catch ex As Exception
            Console.WriteLine($"Error listing events from {calendarId}: {ex.Message}")
            Return Nothing
        End Try
    End Function
    Sub InsertStatus(villa As String, startDate As Date, endDate As Date)
        ' SQL query to insert a new record into the status table
        'Dim status As Integer
        'Dim insertStatusQuery As String = "INSERT INTO status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) " &
        '                        "VALUES (@dwmatio, @kratisi, @enarxi, @lixi, @dwmatiostatus);"
        'Dim insertEventQuery As String = "INSERT INTO eventarkratisi (etos, calendarid, calendarname, eventid, status) " &
        '                        "VALUES (@etos, @calendarid, @calendarname, @eventid, @status);"

        ' Create a new SqlConnection object using the connection string
        Using connection As New SqlConnection(connectionString_)
            ' Open the connection
            connection.Open()

            ' Create a new SqlCommand object and set the connection
            Dim command As New SqlCommand()
            command.Connection = connection

            ' Set the SQL query for inserting into status table
            command.Parameters.AddWithValue("@dwmatio", villa)
            command.Parameters.AddWithValue("@kratisi", -1)
            command.Parameters.AddWithValue("@enarxi", startDate)
            command.Parameters.AddWithValue("@lixi", endDate)
            command.Parameters.AddWithValue("@dwmatiostatus", 4)
            command.CommandText = "INSERT INTO status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) " &
                      "VALUES (@dwmatio, @kratisi, @enarxi, @lixi, @dwmatiostatus);"
            command.ExecuteNonQuery()
            command.Parameters.Clear()

            ' Add parameters to the command
            'command.Parameters.AddWithValue("@dwmatio", villa_)
            'command.Parameters.AddWithValue("@kratisi", -1)
            'command.Parameters.AddWithValue("@enarxi", startDate)
            'command.Parameters.AddWithValue("@lixi", endDate)
            'command.Parameters.AddWithValue("@dwmatiostatus", 4)
            'command.CommandText = "INSERT INTO status (dwmatio, kratisi, enarxi, lixi, dwmatiostatus) " &
            '          "OUTPUT INSERTED.kwd " &
            '          "VALUES (@dwmatio, @kratisi, @enarxi, @lixi, @dwmatiostatus);"

            ' Execute the command to insert the new record and retrieve the inserted status ID
            ' After executing the insert status query, retrieve the generated ID using SCOPE_IDENTITY()

            'status = CInt(command.ExecuteScalar())

            ' Retrieve the generated ID using SCOPE_IDENTITY()


            ' Set the SQL query for inserting into eventarkratisi table


            ' Clear existing parameters and add parameters for inserting into eventarkratisi table
            'command.Parameters.Clear()
            'command.Parameters.AddWithValue("@etos", etos_)
            'command.Parameters.AddWithValue("@calendarid", calendarid)
            'command.Parameters.AddWithValue("@calendarname", villa_)
            'command.Parameters.AddWithValue("@eventid", eventid)
            'command.Parameters.AddWithValue("@status", status)
            'command.CommandText = "INSERT INTO eventarkratisi (etos, calendarid, calendarname, eventid, status) " &
            '                    "VALUES (@etos, @calendarid, @calendarname, @eventid, @status);"
            '' Execute the command to insert into eventarkratisi table
            'command.ExecuteNonQuery()
        End Using
    End Sub


End Module

