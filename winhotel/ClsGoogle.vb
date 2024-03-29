'Imports DotNetOpenAuth.OAuth2

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


Public Class ClsGoogle


    '' Calendar scopes which is initialized on the main method.
    Dim scopes As IList(Of String) = New List(Of String)()

    '' Calendar service.
    Dim service As CalendarService

    Public CalEvents As List(Of [Event]) = New List(Of [Event])     'List of events in the calendar

    Sub New()       'Classes constructor, to authenticate with google servers everytime an object is created
        Authenticate()
    End Sub

    Private Function Authenticate()     'Function that gets authenticates with google servers

        ' Add the calendar specific scope to the scopes list.
        scopes.Add(CalendarService.Scope.Calendar)


        Dim credential As UserCredential
        Dim pathstart As String = "n:\winfo\client_secrets.json"
        Dim filename As String = ""
        If File.Exists(pathstart) Then
            filename = "n:\winfo\client_secrets.json"
        Else
            ' File does not exist at the specified path
            ' Use the default path 'c:\winfo\client_secrets.json' instead
            filename = "c:\winfo\client_secrets.json"
            ' Use the 'path' variable for further processing
        End If
        Using stream As New FileStream(filename, FileMode.Open, FileAccess.Read)
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, scopes, "domisi", CancellationToken.None,
                    New FileDataStore("Calendar.VB.Sample")).Result
        End Using

        ' Create the calendar service using an initializer instance
        Dim initializer As New BaseClientService.Initializer()
        initializer.HttpClientInitializer = credential
        initializer.ApplicationName = "VB.NET Calendar Sample"
        service = New CalendarService(initializer)
        Return 0
    End Function




    Sub GetCalendar(MinDate As Date, Optional MaxDate As Date = Nothing)
        Dim list As IList(Of CalendarListEntry) = service.CalendarList.List().Execute().Items()     'List of all the google calendars the user has
        MsgBox(list.Count)


        Dim EventRequest As ListRequest = service.Events.List(list("0").Id)     'Specifies which google calendar to perform the query

        EventRequest.TimeMin = MinDate      'Specifies the minimum date to look for in the query

        If Not MaxDate = Nothing Then
            EventRequest.TimeMax = MaxDate      'Specifies the maximum date to look for in the query
        End If
        For Each CalendarEvent As Data.Event In EventRequest.Execute.Items  'For each event in the google calendar add to CalEvents
            CalEvents.Add(CalendarEvent)
        Next
    End Sub


    Sub UpdateCalendar()
        Dim CalendarEvent As New Data.Event
        Dim StartDateTime As New Data.EventDateTime
        Dim A As Date
        A = "19/11/2014 12:00"
        StartDateTime.DateTime = A
        Dim b As Date
        b = A.AddHours(2)
        Dim EndDateTime As New Data.EventDateTime
        EndDateTime.DateTime = b
        CalendarEvent.Start = StartDateTime
        CalendarEvent.End = EndDateTime
        CalendarEvent.Id = System.Guid.NewGuid.ToString
        CalendarEvent.Description = "Test"


        'Dim Request As New InsertRequest(service, CalendarEvent, service.Events.List(list("0").Id))
        'Request.CreateRequest()
        'Request.Execute()

    End Sub

End Class