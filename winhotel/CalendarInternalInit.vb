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
Imports System.Net

'Imports Event = Google.Apis.Calendar.v3.Data.Event

Module CalendarInternalInit
    Dim connectionString_ As String
    Dim etos_ As Int16
    Dim vila_ As String
    Private service As CalendarService

    Sub Main(ByVal conn As String, ByVal etos As Int16, ByVal vila As String)
        connectionString_ = conn
        etos_ = etos
        vila_ = vila
        ' Authenticate and obtain access to calendars
        Authenticate()
        Dim query As String = "SELECT kratiseis.kwd, kratiseis.arithmos, kratiseis.dwmatio, calendar.calendarid " &
                              "FROM kratiseis INNER JOIN calendar ON kratiseis.dwmatio=calendar.vila " &
                              "WHERE kratiseis.etos=@etos and kratiseis.dwmatio=@vila and kratiseis.afixi>'1/1/2024';"
        Using connection As New SqlConnection(connectionString_)
            Using command As New SqlCommand(query, connection)
                ' Add the year parameter to the command
                command.Parameters.AddWithValue("@etos", etos_)
                command.Parameters.AddWithValue("@vila", vila_)
                ' Open the connection
                connection.Open()

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row
                        Dim kwd As Integer = reader.GetInt32(0)
                        Dim arithmos As Integer = reader.GetInt16(1)
                        Dim dwmatio As String = reader.GetString(2)
                        Dim calendarid As String = HttpUtility.UrlDecode(reader.GetString(3))
                        Dim eventid As String
                        eventid = ListEvents(calendarid, arithmos)
                        If Not String.IsNullOrEmpty(eventid) Then
                            Console.WriteLine($"eventid: {eventid},  calendarid: {calendarid}")
                            InsertEventArkratisi(kwd, etos_, arithmos, calendarid, dwmatio, eventid)
                        End If
                        ' Process the retrieved values (e.g., display or store them)

                    End While
                End Using
            End Using

        End Using
        ' Example: List events from your own calendar


        ' Example: List events from calendars shared with you
        'ListSharedEvents()

        Console.ReadLine()
    End Sub
    Sub InsertEventArkratisi(kwd As Integer, etos As Int16, arithmos As Integer, calendarid As String, dwmatio As String, eventid As String)
        ' SQL query to insert a new record into the eventarkratisi table
        Dim insertQuery As String = "INSERT INTO eventarkratisi (kratisi, etos, arkratisis, calendarid, calendarname, eventid) " &
                                "VALUES (@kratisi, @etos, @arkratisis, @calendarid, @calendarname, @eventid);"

        ' Create a new SqlConnection object using the connection string
        Using connection As New SqlConnection(connectionString_)
            ' Create a new SqlCommand object with the insert query and connection
            Using command As New SqlCommand(insertQuery, connection)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@kratisi", kwd)
                command.Parameters.AddWithValue("@etos", etos)
                command.Parameters.AddWithValue("@arkratisis", arithmos)
                command.Parameters.AddWithValue("@calendarid", calendarid)
                command.Parameters.AddWithValue("@calendarname", dwmatio)
                command.Parameters.AddWithValue("@eventid", eventid)

                ' Open the connection
                connection.Open()

                ' Execute the command to insert the new record
                command.ExecuteNonQuery()
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
                                                                             "mkallergis",
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
    'Private Function ListEventsFromICS(url As String, arkratisis As Integer) As String
    '    Try
    '        ' Download the .ics file from the URL
    '        Dim client As New WebClient()
    '        Dim icsData As String = client.DownloadString(url)

    '        ' Parse the .ics data
    '        Using stream As New StringReader(icsData)
    '            Dim calendar As Ical.Net.Calendar = Ical.Net.Calendar.LoadFromStream(stream)

    '            ' Rest of your code...
    '        End Using

    '        ' If no matching event is found
    '        Return Nothing
    '    Catch ex As Exception
    '        Console.WriteLine($"Error listing events from {url}: {ex.Message}")
    '        Return Nothing
    '    End Try
    'End Function
    Private Function ListEvents(calendarId As String, arkratisis As Int16) As String
        Try
            ' Define parameters for the events request
            Dim request As EventsResource.ListRequest = service.Events.List(calendarId)
            request.TimeMin = New DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)

            ' Set the end of the year 2023 as the maximum time
            request.TimeMax = New DateTime(2024, 12, 31, 23, 59, 59, DateTimeKind.Utc)
            request.ShowDeleted = False
            request.SingleEvents = True
            request.MaxResults = 100
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime

            ' Execute the request and retrieve the events
            Dim events As Events = request.Execute()
            Dim pattern As String = "Αρ\. Κράτ:\s*(\d+)"
            ' Display the events
            If events.Items IsNot Nothing AndAlso events.Items.Count > 0 Then
                Console.WriteLine($"Upcoming events from {calendarId}:")
                For Each eventItem As Google.Apis.Calendar.v3.Data.Event In events.Items
                    Dim start As String = If(eventItem.Start.DateTime.HasValue, eventItem.Start.DateTime.ToString(), eventItem.Start.Date)
                    Console.WriteLine($"{start} - {eventItem.Id} - {eventItem.Start.Date}- {eventItem.End.Date}- {eventItem.Summary} -{eventItem.Description}")
                    Dim match As Match = Regex.Match(eventItem.Description, pattern)
                    If match.Success Then
                        ' Extract the number from the match
                        Dim number As String = match.Groups(1).Value
                        If number = arkratisis Then
                            Return eventItem.Id
                        End If
                        Console.WriteLine($"Number: {number}")
                    Else
                        Console.WriteLine("Number not found.")
                    End If
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

    Private Sub ListSharedEvents()
        Try
            'Dim kalCounter As Int16
            ''Dim nevent As New Data.Event()

            'Dim list As IList(Of CalendarListEntry) = service.CalendarList.List().Execute().Items()     'List of all the google calendars the user has
            'kalCounter = get_kalender_name(list)
            ' Request the list of calendars accessible to the authenticated user
            Dim calendarList As CalendarList = service.CalendarList.List().Execute()

            ' Iterate through the list of calendars
            If calendarList.Items IsNot Nothing Then
                For Each calendar As CalendarListEntry In calendarList.Items
                    ' Check if the calendar is shared with the user
                    If calendar.AccessRole = "owner" Then
                        ' List events from shared calendar
                        'ListEvents(calendar.Summary)
                        'ListEvents(calendar.Id)
                    End If
                    'If calendar.Summary = "IKR" Then
                    '    ' List events from shared calendar
                    '    ListEvents(calendar.Summary)
                    '    ListEvents(calendar.Id)
                    'End If
                Next
            Else
                Console.WriteLine("No calendars found.")
            End If
        Catch ex As Exception
            Console.WriteLine($"Error listing shared calendars: {ex.Message}")
        End Try
    End Sub

End Module

