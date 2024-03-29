
Imports System.Collections.Generic
Imports System.IO


Imports System.Threading

Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Calendar.v3.EventsResource
Imports Google.Apis.Services
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports Google.Apis.Requests

Public Class GoogleCalendar


    '' Calendar scopes which is initialized on the main method.
    Dim scopes As IList(Of String) = New List(Of String)()

    '' Calendar service.
    Dim service As CalendarService

    Public CalEvents As List(Of [Event]) = New List(Of [Event])     'List of events in the calendar
    'Dim serv As New Google.GData.Calendar.CalendarService("GCal")
    Dim sGoogleUserName As String
    Dim sGooglePassword As String
    Friend arkrat As String
    Dim name As String
    Dim timeIn As Date
    Dim timeOut As Date
    Dim kalender As String
    Dim vila As String
    Dim epithimia As String
    Dim praktoreio As String = ""
    Dim url As String
    Dim calid As String
    Const all As String = "default"
    Const url1 As String = "https://www.google.com/calendar/feeds/"
    Const url2 As String = "/private/full"

    Private Function Authenticate()     'Function that gets authenticates with google servers
        Dim pathstart As String = ""
        Dim fileName As String = ""

        'Try
        '    pathstart = Environment.GetEnvironmentVariable("location")
        '    If pathstart <> "" Then
        '        fileName = pathstart + "\winfo\client_secrets.json" '"n:\winfo\client_secrets.json".Replace("n:", pathstart)

        '    Else
        '        fileName = "n:\winfo\client_secrets.json"
        '    End If

        'Catch ex1 As ArgumentNullException
        '    fileName = "n:\winfo\client_secrets.json"
        'End Try


        pathstart = "n:\winfo\client_secrets.json"

        If File.Exists(pathstart) Then
            fileName = "n:\winfo\client_secrets.json"
        Else

            fileName = "c:\winfo\client_secrets.json"

        End If

        ' Add the calendar specific scope to the scopes list.



        scopes.Add(CalendarService.Scope.Calendar)





        Dim credential As UserCredential

        Try
            Using stream As New FileStream(fileName, FileMode.Open, FileAccess.Read)

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets, scopes, "domisi", CancellationToken.None,
                        New FileDataStore("Calendar.VB.Sample")).Result

            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        ' Create the calendar service using an initializer instance
        Dim initializer As New BaseClientService.Initializer()
        initializer.HttpClientInitializer = credential
        initializer.ApplicationName = "VB.NET Calendar Sample"
        service = New CalendarService(initializer)
        Return 0
    End Function

    Public Sub send_entry()
        'Dim theThread _
        '    As New Threading.Thread(AddressOf create_NewEntry)
        'theThread.Start()
        create_NewEntry()
    End Sub
    Public Sub delete_entry()
        'Dim theThread _
        '    As New Threading.Thread(AddressOf delete_Calendar)
        'theThread.Start()
        delete_Calendar()
    End Sub

    Public Sub delete_Calendar()
        Dim kalCounter As Int16
        Dim laenge As Int64
        'Dim nevent As New Data.Event()

        Dim list As IList(Of CalendarListEntry) = service.CalendarList.List().Execute().Items()     'List of all the google calendars the user has
        kalCounter = get_kalender_name(list)
        Dim EventRequest As ListRequest = service.Events.List(list(kalCounter).Id)     'Specifies which google calendar to perform the query

        EventRequest.TimeMin = timeIn      'Specifies the minimum date to look for in the query
        EventRequest.TimeMax = timeOut

        For Each CalendarEvent As Data.Event In EventRequest.Execute.Items  'For each event in the google calendar add to CalEvents
            If Not String.IsNullOrEmpty(CalendarEvent.Summary) Then
                laenge = CalendarEvent.Summary.Length
                Try
                    If laenge >= 4 Then
                        If CalendarEvent.Summary.Substring(0, 4).Equals(vila.Substring(0, 4).Trim) AndAlso CalendarEvent.Start.Date = timeIn AndAlso CalendarEvent.End.Date = timeOut Then 'AndAlso CalendarEvent.Start.Date.Equals(timeIn) AndAlso CalendarEvent.End.Date.Equals(timeOut)
                            'MsgBox("Delete!!!!!")
                            Dim Request As New DeleteRequest(service, list(kalCounter).Id, CalendarEvent.Id)
                            Request.CreateRequest()
                            Request.Execute()
                        End If
                    Else
                        If CalendarEvent.Summary.Substring(0, 3).Equals(vila.Substring(0, 3).Trim) AndAlso CalendarEvent.Start.Date = timeIn AndAlso CalendarEvent.End.Date = timeOut Then 'AndAlso CalendarEvent.Start.Date.Equals(timeIn) AndAlso CalendarEvent.End.Date.Equals(timeOut)
                            'MsgBox("Delete!!!!!")
                            Dim Request As New DeleteRequest(service, list(kalCounter).Id, CalendarEvent.Id)
                            Request.CreateRequest()
                            Request.Execute()
                        End If
                    End If

                Catch ex As ArgumentOutOfRangeException
                    If CalendarEvent.Summary.Substring(0, 2).Equals(vila.Substring(0, 2).Trim) AndAlso CalendarEvent.Start.Date = timeIn AndAlso CalendarEvent.End.Date = timeOut Then 'AndAlso CalendarEvent.Start.Date.Equals(timeIn) AndAlso CalendarEvent.End.Date.Equals(timeOut)
                        'MsgBox("Delete!!!!!")
                        Dim Request As New DeleteRequest(service, list(kalCounter).Id, CalendarEvent.Id)
                        Request.CreateRequest()
                        Request.Execute()
                    End If
                End Try
            End If

        Next
        'delete_main()
    End Sub



    '    Next

    'End Sub
    Public Sub create_NewEntry()
        Dim kalCounter As Int16
        'Dim nevent As New Data.Event()

        Dim list As IList(Of CalendarListEntry) = service.CalendarList.List().Execute().Items()     'List of all the google calendars the user has
        kalCounter = get_kalender_name(list)
        Dim formato As String = "yyyy-MM-dd"
        Dim CalendarEvent As New Data.Event
        Dim StartDateTime As New Data.EventDateTime
        Dim EndDateTime As New Data.EventDateTime

        StartDateTime.Date = Format(timeIn, formato) ' "2014-12-14" 'timeIn '.ToString \ timeIn.ToString(format)
        EndDateTime.Date = Format(timeOut, formato) '"2014-12-20" 'timeOut '.AddDays(-1).ToString(format)

        CalendarEvent.Start = StartDateTime
        CalendarEvent.End = EndDateTime
        CalendarEvent.Summary = vila + "   " + name
        CalendarEvent.Description = "(Αρ. Κράτ: " + arkrat + ") " + praktoreio.Substring(0, 4) + " " + epithimia
        'CalendarEvent.Id = System.Guid.NewGuid.ToString
        'CalendarEvent.Description = "Test"


        Dim Request As New InsertRequest(service, CalendarEvent, list(kalCounter).Id)
        Request.CreateRequest()
        Request.Execute()

        '2022 mallon edw enhmerwnei to kentriko calendar biles->den enhmerwnei pleon????
        'kalCounter = get_kalender_name(list, True)
        'Dim Request2 As New InsertRequest(service, CalendarEvent, list(kalCounter).Id)
        'Request2.CreateRequest()
        'Request2.Execute()


    End Sub
    Private Function get_kalender_name(ByVal list As IList(Of CalendarListEntry), Optional ByVal istPrimary As Boolean = False) As Int16
        Dim j As Int16
        Dim laenge As Int16
        If istPrimary Then
            For j = 0 To list.Count - 1
                If list(j).Primary Then
                    Return j
                End If
            Next

        Else
            For j = 0 To list.Count - 1
                If Not String.IsNullOrEmpty(list(j).Summary) Then
                    laenge = list(j).Summary.Length

                    Try
                        If laenge >= 4 Then
                            If list(j).Summary.Substring(0, 4).Equals(kalender.Substring(0, 4).Trim) Then
                                Return j
                            End If
                        Else
                            If list(j).Summary.Substring(0, 3).Equals(kalender.Substring(0, 3).Trim) Then
                                Return j
                            End If
                        End If
                    Catch ex As ArgumentOutOfRangeException
                        If list(j).Summary.Substring(0, 2).Equals(kalender.Substring(0, 2).Trim) Then
                            Return j
                        End If

                    End Try

                End If



            Next
        End If

        Return -1
    End Function



    Public Sub set_values(ByVal arithkrat As String, ByVal onoma As String, ByVal datumIn As Date, ByVal datumOut As Date, ByVal calender As String, ByVal villa As String, ByVal wuensch As String, ByVal prakt As String)
        arkrat = arithkrat
        name = onoma
        timeIn = datumIn
        timeOut = datumOut
        kalender = calender
        vila = villa
        epithimia = wuensch
        'calid = kalenderid
        praktoreio = prakt + "    "
    End Sub

    Public Sub New(ByVal arithkrat As String, ByVal onoma As String, ByVal datumIn As Date, ByVal datumOut As Date, ByVal calender As String, ByVal villa As String, ByVal wuensch As String, ByVal prakt As String)

        'Dim google As New ClsGoogle
        arkrat = arithkrat
        name = onoma
        timeIn = datumIn
        timeOut = datumOut
        kalender = calender
        vila = villa
        epithimia = wuensch
        'calid = kalenderid
        praktoreio = prakt + "    "

        Try
            Authenticate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Authenticate()

        ' send_entry()
        'delete_entry()
    End Sub
End Class
