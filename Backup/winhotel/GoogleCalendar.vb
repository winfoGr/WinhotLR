Imports Google.GData.Calendar
Imports Google.GData.Extensions
Imports Google.GData.Client

Public Class GoogleCalendar
    Dim serv As New Google.GData.Calendar.CalendarService("GCal")
    Dim sGoogleUserName As String
    Dim sGooglePassword As String
    Friend arkrat As String
    Dim name As String
    Dim timeIn As Date
    Dim timeOut As Date
    Dim location As String
    Dim epithimia As String
    Dim praktoreio As String = ""
    'Private Sub GAuthenticate()

    '    Dim oCalendarUri = New Uri("http://www.google.com/calendar/feeds/" + _
    '                           sGoogleUserName + "/private/full")
    '    'Initialize Calendar Service
    '    Dim oCalendarService As New CalendarService("CalendarSampleApp")
    '    oCalendarService.setUserCredentials(sGoogleUserName, sGooglePassword)

    'End Sub
    'Public Sub set_values(ByVal user As String, ByVal password As String, ByVal arkrat As String, ByVal name As String, ByVal time As Date, ByVal location As String, ByVal epithimia As String)
    '    sGoogleUserName = user
    '    sGooglePassword = password
    '    arkrat = arkrat
    '    name = name
    '    time = time
    '    location = location
    '    epithimia = epithimia
    'End Sub
    Public Sub send_entry()
        Dim theThread _
            As New Threading.Thread(AddressOf create_new_entry)
        theThread.Start()
    End Sub
    Public Sub delete_entry()
        Dim theThread _
            As New Threading.Thread(AddressOf del_entry)
        theThread.Start()
    End Sub
    'Dim query As New CalendarQuery
    '        query.Uri = New Uri("https://www.google.com/calendar/feeds/default/allcalendars/full")
    'Dim resultFeed As CalendarFeed
    '        resultFeed = serv.Query(query)
    '        For Each newCal In resultFeed.Entries
    '            MsgBox(newCal.)
    '        Next
    Private Sub create_new_entry()
        Dim newEvent As New EventEntry
        Dim newatom As AtomEntry
        Try

            'Dim xroma As Color
            'xroma = Color.Blue
            'Dim wc As New WebContentLink()
            'wc.GadgetPreferences("color.id") = Color.Blue
            'newEvent.WebContentLink = wc
            'Dim stCalName As String = ""
            'Dim stURI As String = CType((serv), stCalName)


            newEvent.Title.Text = location + " " + name

            newEvent.Content.Content = "(Αρ. Κράτ: " + arkrat + ") " + praktoreio.Substring(0, 4) + " " + epithimia

            'newEvent.Summary.Text = "This calendar contains the practice schedule and game times."

            Dim newTime As New [When]()
            newTime.StartTime = timeIn
            newTime.AllDay = True
            newTime.EndTime = timeOut

            newEvent.Times.Add(newTime)

            Dim eventLocation As New Where()
            eventLocation.ValueString = location

            newEvent.Locations.Add(eventLocation)

            Dim uri As New Uri("https://www.google.com/calendar/feeds/default/private/full")

            newatom = serv.Insert(uri, newEvent)
        Catch ex As Exception
            MsgBox("Αποτυχία ενημέρωσης του Google Calendar", MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Public Function DeleteAllEvents() As String

        Dim str As String = ""


        Dim query As New FeedQuery
        query.Uri = New Uri("https://www.google.com/calendar/feeds/default/private/full")

        'query.StartDate
        Dim calFeed As AtomFeed
        calFeed = serv.Query(query)

        If calFeed.Entries.Count > 0 Then
            For x As Integer = 0 To calFeed.Entries.Count - 1
                MsgBox(calFeed.Entries(x).Title.Text.Substring(0, 3))
                str = str & calFeed.Entries(x).Title.Text & vbCrLf
                calFeed.Entries(x).Delete()
            Next
        End If

        Return str

    End Function
    Public Sub del_entry()
        Dim entry As New EventEntry()
        '        EventQuery myQuery = new EventQuery(feedUrl);
        'myQuery.StartTime = new DateTime(2007, 1, 5);
        'myQuery.EndTime = new DateTime(2007, 1, 7);
        Dim myQuery = New EventQuery("https://www.google.com/calendar/feeds/default/private/full")
        myQuery.StartTime = timeIn ' New DateTime(2014, 4, 1) ' time '"1/4/2014 1:00" 'New DateTime(2014, 4, 1)
        myQuery.EndTime = timeIn.AddDays(1) ' New DateTime(2014, 4, 2) '"1/4/2014 23:00" 'New DateTime(2014, 4, 2)
        Dim myResultsFeed As EventFeed
        myResultsFeed = serv.Query(myQuery)

        For Each entry In myResultsFeed.Entries
            If entry.Locations(0).ValueString.Equals(location) Then
                Try
                    entry.Delete()
                    Exit For
                Catch ex As GDataRequestException

                End Try

            End If
        Next
    End Sub

    'Private Sub del_entry()


    '    'EventFeed myResultsFeed = myService.Query(myQuery);
    '    Dim entry As New EventEntry()
    '    Dim startDatum, endDatum As Date
    '    Dim query As New FeedQuery
    '    time = "23/3/2014 0:00"
    '    startDatum = CType(time, Date)
    '    time = "2/4/2014 23:00"
    '    endDatum = CType(time, Date)
    '    'Dim Uri As New Uri("http://www.google.com/calendar/feeds/" + _
    '    '                    sGoogleUserName + "/private/full"
    '    'Dim uri As New Uri("https://www.google.com/calendar/feeds/default/private/full")
    '    'query.Uri = New Uri("http://www.google.com/calendar/feeds/" + _
    '    '                       sGoogleUserName + "/private/full")
    '    query.Uri = New Uri("https://www.google.com/calendar/feeds/default/private/full")
    '    'MsgBox(time)
    '    query.StartDate = startDatum     'optional but recommended so you don't get every single event, ever

    '    query.EndDate = endDatum

    '    query.ExtraParameters = "orderby=starttime&sortorder=ascending"

    '    System.Net.ServicePointManager.Expect100Continue = False
    '    Dim calfeed As AtomFeed

    '    calfeed = serv.Query(query)
    '    MsgBox(calfeed.Entries.Count)
    '    For Each entry In calfeed.Entries
    '        MsgBox("Hura")
    '        If entry.Locations(0).ValueString.Equals(location) Then
    '            Try
    '                entry.Delete()
    '                Exit For
    '            Catch ex As GDataRequestException

    '            End Try

    '        End If
    '        'If entry.Locations(0).Equals(location) Then
    '        '    entry.Delete()
    '        'End If
    '        'Try
    '        '    MsgBox(entry.Title.Text)
    '        'Catch ex As GDataRequestException
    '        '    MsgBox(ex)
    '        'End Try

    '        'If entry.title.text.contains(arkrat) Then
    '        'MsgBox(entry.title.text)
    '        'End If
    '    Next


    'End Sub
    Public Sub set_values(ByVal arithkrat As String, ByVal onoma As String, ByVal datumIn As Date, ByVal datumOut As Date, ByVal dwmatio As String, ByVal wuensch As String, ByVal prakt As String)
        arkrat = arithkrat
        name = onoma
        timeIn = datumIn
        timeOut = datumOut
        location = dwmatio
        epithimia = wuensch
        praktoreio = prakt + "    "
    End Sub
    Public Sub New(ByVal user As String, ByVal password As String, ByVal arithkrat As String, ByVal onoma As String, ByVal datumIn As Date, ByVal datumOut As Date, ByVal dwmatio As String, ByVal wuensch As String, ByVal prakt As String)
        sGoogleUserName = user
        sGooglePassword = password
        arkrat = arithkrat
        name = onoma
        timeIn = datumIn
        timeOut = datumOut
        location = dwmatio
        epithimia = wuensch
        praktoreio = prakt + "    "
        serv.setUserCredentials(sGoogleUserName, sGooglePassword)
    End Sub
End Class
