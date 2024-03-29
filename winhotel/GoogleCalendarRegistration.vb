Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Auth.OAuth2.Flows
Imports Google.Apis.Auth.OAuth2.Web
Imports Google.Apis.Services
Imports Google.Apis.Calendar.v3
Imports Google.Apis.Calendar.v3.Data
Imports Google.Apis.Util.Store
Imports System.Reflection
Imports System.Threading

Partial Class GoogleCalendarRegistrationV3
    Inherits System.Web.UI.Page

    Private Shared myClientID As String = System.Configuration.ConfigurationManager.AppSettings("GoogleCalendarApplicationClientID").ToString()
    Private Shared ClientSecret As String = System.Configuration.ConfigurationManager.AppSettings("GoogleCalendarApplicationClientSecret").ToString()

    Public Shared myCalendarservice As CalendarService

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("group_cd") Is Nothing Then
            Response.Redirect("Logout.aspx")
        End If

        new_authentication()
    End Sub

    Protected Sub new_authentication()

        Dim datafolder As String = Server.MapPath("App_Data/CalendarService.api.auth.store")
        Dim scopes As IList(Of String) = New List(Of String)()
        Dim UserId As String = "GoogleID_" & Session("username").ToString.Trim

        scopes.Add(CalendarService.Scope.Calendar)
        Dim myclientsecret As New ClientSecrets() With { _
          .ClientId = myClientID, _
          .ClientSecret = ClientSecret _
        }

        Dim flow As GoogleAuthorizationCodeFlow

        flow = New GoogleAuthorizationCodeFlow(New GoogleAuthorizationCodeFlow.Initializer() With { _
           .DataStore = New FileDataStore(datafolder), _
          .ClientSecrets = myclientsecret, _
          .Scopes = scopes _
        })

        Dim uri As String = Request.Url.ToString()

        Dim code = Request("code")
        If code IsNot Nothing Then
            Dim token = flow.ExchangeCodeForTokenAsync(UserId, code, uri.Substring(0, uri.IndexOf("?")), CancellationToken.None).Result

            ' Extract the right state.
            Dim oauthState = AuthWebUtility.ExtracRedirectFromState(flow.DataStore, UserId, Request("state")).Result
            Response.Redirect(oauthState)
        Else
            Dim result = New AuthorizationCodeWebApp(flow, uri, uri).AuthorizeAsync(UserId, CancellationToken.None).Result
            If result.RedirectUri IsNot Nothing Then
                ' Redirect the user to the authorization server.
                Response.Redirect(result.RedirectUri)
            Else
                ' The data store contains the user credential, so the user has been already authenticated.
                'AppFlowMetadata.myCalendarservice = New CalendarService(New BaseClientService.Initializer() With { _
                '  .ApplicationName = "My Calendar", _
                '  .HttpClientInitializer = result.Credential _
                '})

                createcalendar()

                Response.Redirect("Default.aspx")

            End If
        End If

    End Sub

    Protected Sub createcalendar()
        Dim sfind As Boolean = False
        ' Fetch the list of calendar list
        Dim list As IList(Of CalendarListEntry) = GoogleCalendarRegistrationV3.myCalendarservice.CalendarList.List().Execute().Items()
        For Each item As CalendarListEntry In list

            If item.Summary.Trim = "Calendar Sample" Then
                sfind = True
                Exit For
            End If

        Next


        If sfind = False Then
            Dim calendar As New Calendar()

            calendar.Summary = "Calendar Sample"
            calendar.TimeZone = "Asia/Manila"
            calendar.Location = "Philippines"
            calendar.Description = "calendar sample description"

            Dim createdCalendar As Calendar = GoogleCalendarRegistrationV3.myCalendarservice.Calendars.Insert(calendar).Execute()


            Dim rule As New AclRule()
            Dim scope As New AclRule.ScopeData

            scope.Type = "default"
            scope.Value = "default"
            rule.Scope = scope
            rule.Role = "reader"

            Dim createdRule As AclRule = GoogleCalendarRegistrationV3.myCalendarservice.Acl.Insert(rule, createdCalendar.Id).Execute

        End If


    End Sub

End Class
