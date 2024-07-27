Imports System.IO


Imports System.Threading

Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Calendar.v3.EventsResource
Imports Google.Apis.Services
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports System.Data.SqlClient
Imports System.Web
Imports WebConnect
Public Class GoogleCalendarNew
    Dim connectionString_ As String

    '' Calendar scopes which is initialized on the main method.
    Dim scopes As IList(Of String) = New List(Of String)()

    '' Calendar service.
    Dim service As CalendarService
    Dim calendaridNew As String
    Dim calendaridOld As String
    Public CalEvents As List(Of [Event]) = New List(Of [Event])
    Dim kwdikosKrat_ As Integer
    Friend arkrat As String
    Dim name As String
    Dim timeIn As Date
    Dim timeOut As Date
    Dim villaold_ As String
    Dim villanew_ As String
    Dim epithimia As String
    Dim praktoreio As String = ""

    Public Sub New(ByVal conn As String, ByVal kratisikwd As Integer, ByVal arithkrat As String, ByVal onoma As String, ByVal datumIn As Date, ByVal datumOut As Date, ByVal calendarold As String, ByVal calendarnew As String, ByVal wuensch As String, ByVal prakt As String)
        connectionString_ = conn
        kwdikosKrat_ = kratisikwd
        'Dim google As New ClsGoogle
        arkrat = arithkrat
        name = onoma
        timeIn = datumIn
        timeOut = datumOut
        villaold_ = calendarold
        villanew_ = calendarnew
        epithimia = wuensch
        'calid = kalenderid
        praktoreio = prakt + "    "
        set_calendarid()
        If calendarold <> calendarnew Then
            set_calendarid_old()
        Else
            calendaridOld = calendaridNew
        End If


        Try
            Authenticate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        ' send_entry()
        'delete_entry()
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
    Sub set_calendarid()

        Dim query As String = "SELECT calendarid FROM calendar WHERE vila=@villa;"
        Using connection As New SqlConnection(connectionString_)
            Using command As New SqlCommand(query, connection)
                ' Add the year parameter to the command
                command.Parameters.AddWithValue("@villa", villanew_)

                ' Open the connection
                connection.Open()

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row

                        calendaridNew = HttpUtility.UrlDecode(reader.GetString(0))


                    End While
                End Using
            End Using

        End Using
    End Sub
    Public Sub set_calendarid_thalasses(ByVal flag As Byte) '1 =for create , 2=for delete

        Dim query As String = "SELECT calendarid FROM calendar WHERE vila=@villa;"
        Using connection As New SqlConnection(connectionString_)
            Using command As New SqlCommand(query, connection)
                ' Add the year parameter to the command
                command.Parameters.AddWithValue("@villa", "THLS")

                ' Open the connection
                connection.Open()

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row
                        If flag = 1 Then
                            calendaridNew = HttpUtility.UrlDecode(reader.GetString(0))
                        Else
                            calendaridOld = HttpUtility.UrlDecode(reader.GetString(0))
                        End If




                    End While
                End Using
            End Using

        End Using
    End Sub
    Sub set_calendarid_old()

        Dim query As String = "SELECT calendarid FROM calendar WHERE vila=@villa;"
        Using connection As New SqlConnection(connectionString_)
            Using command As New SqlCommand(query, connection)
                ' Add the year parameter to the command
                command.Parameters.AddWithValue("@villa", villaold_)

                ' Open the connection
                connection.Open()

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row

                        calendaridOld = HttpUtility.UrlDecode(reader.GetString(0))


                    End While
                End Using
            End Using

        End Using
    End Sub
    Function get_eventid() As String

        Dim query As String = "SELECT eventid FROM eventarkratisi WHERE kratisi=@kwdikos and calendarid=@calendarid;"
        Using connection As New SqlConnection(connectionString_)
            Using command As New SqlCommand(query, connection)
                ' Add the year parameter to the command
                command.Parameters.AddWithValue("@kwdikos", kwdikosKrat_)
                command.Parameters.AddWithValue("@calendarid", calendaridOld)

                ' Open the connection
                connection.Open()

                ' Execute the command and retrieve the data
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate over the result set
                    While reader.Read()
                        ' Retrieve values from the current row

                        Return reader.GetString(0)


                    End While
                End Using
            End Using

        End Using
        Return Nothing
    End Function
    Public Sub create_new_entry()
        Dim StartDateTime As New Data.EventDateTime
        Dim EndDateTime As New Data.EventDateTime
        Dim formato As String = "yyyy-MM-dd"
        StartDateTime.Date = Format(timeIn, formato) ' "2014-12-14" 'timeIn '.ToString \ timeIn.ToString(format)
        EndDateTime.Date = Format(timeOut, formato)

        Dim newEvent As New [Event]() With {
        .Summary = villanew_ + "   " + name,
        .Start = StartDateTime,
        .End = EndDateTime,
        .Description = "(Αρ. Κράτ: " + arkrat + ") " + praktoreio.Substring(0, 4) + " " + epithimia
    }

        ' Call the Google Calendar API to insert the event into the calendar
        Dim request As EventsResource.InsertRequest = service.Events.Insert(newEvent, calendaridNew)
        Dim createdEvent As [Event] = request.Execute()

        ' Retrieve the ID of the newly created event
        Dim eventId As String = createdEvent.Id
        If Not String.IsNullOrEmpty(eventId) Then
            Console.WriteLine($"eventid: {eventId},  calendarid: {calendaridNew}")
            InsertEventArkratisiDB(kwdikosKrat_, timeIn.Year, arkrat, calendaridNew, villanew_, eventId)
        End If
        ' Use the event ID as needed (e.g., store it in your application)
        Console.WriteLine($"Created event with ID: {eventId}")


    End Sub
    Public Sub update_entry()
        Dim eventID As String

        Dim StartDateTime As New Data.EventDateTime
        Dim EndDateTime As New Data.EventDateTime
        Dim formato As String = "yyyy-MM-dd"
        StartDateTime.Date = Format(timeIn, formato)
        EndDateTime.Date = Format(timeOut, formato)

        ' Create a new event with updated information
        Dim updatedEvent As New [Event]() With {
            .Summary = villanew_ + "   " + name,
            .Start = StartDateTime,
            .End = EndDateTime,
            .Description = "(Αρ. Κράτ: " + arkrat + ") " + praktoreio.Substring(0, 4) + " " + epithimia
        }

        eventID = get_eventid()
        If Not String.IsNullOrEmpty(eventID) Then
            Dim request As EventsResource.UpdateRequest = service.Events.Update(updatedEvent, calendaridNew, eventID)


            ' Execute the request to update the event
            Dim updatedEventResponse As [Event] = request.Execute()
        Else
            create_new_entry()
        End If
        ' Call the Google Calendar API to update the event


        ' Specify the event ID of the event to be updated



    End Sub
    Public Sub delete_entry()
        Dim eventID As String

        'Dim StartDateTime As New Data.EventDateTime
        'Dim EndDateTime As New Data.EventDateTime
        'Dim formato As String = "yyyy-MM-dd"
        'StartDateTime.Date = Format(timeIn, formato)
        'EndDateTime.Date = Format(timeOut, formato)

        '' Create a new event with updated information
        'Dim updatedEvent As New [Event]() With {
        '    .Summary = vila + "   " + name,
        '    .Start = StartDateTime,
        '    .End = EndDateTime,
        '    .Description = "(Αρ. Κράτ: " + arkrat + ") " + praktoreio.Substring(0, 4) + " " + epithimia
        '}

        eventID = get_eventid()
        If Not String.IsNullOrEmpty(eventID) Then
            Dim request As EventsResource.DeleteRequest = service.Events.Delete(calendaridOld, eventID)
            DeleteEventDB(eventID, calendaridOld)
            Dim deleteResult As String = request.Execute()
            ' Execute the request to update the event


        End If
        ' Call the Google Calendar API to update the event


        ' Specify the event ID of the event to be updated



    End Sub
    Sub InsertEventArkratisiDB(kwd As Integer, etos As Int16, arithmos As Integer, calendarid As String, dwmatio As String, eventid As String)
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
    Sub DeleteEventDB(eventid As String, calendarid As String)

        ' SQL query to insert a new record into the eventarkratisi table
        Dim deleteQuery As String = "Delete eventarkratisi where eventid=@eventid and calendarid=@calendarid;"

        ' Create a new SqlConnection object using the connection string
        Using connection As New SqlConnection(connectionString_)
            ' Create a new SqlCommand object with the insert query and connection
            Using command As New SqlCommand(deleteQuery, connection)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@eventid", eventid)
                command.Parameters.AddWithValue("@calendarid", calendarid)

                ' Open the connection
                connection.Open()

                ' Execute the command to insert the new record
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
