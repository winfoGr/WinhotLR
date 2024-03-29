Imports System.Threading
Imports WhatsAppApi
Imports WhatsAppApi.ApiBase
Imports WhatsAppApi.Helper
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Resources
Public Class SendWhatsApp

    Private wa As WhatsApp
    Private Delegate Sub UpdateTextBox(ByVal textbox As TextBox, ByVal value As String)
    Public Sub UpdateDataTextBox(ByVal textbox As TextBox, ByVal value As String)
        Dim box As TextBox = textbox
        box.Text = (box.Text & value)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles txtMessage.Click
        If ((Not String.IsNullOrEmpty(Me.txtMessage.Text) AndAlso (Not Me.wa Is Nothing)) AndAlso (Me.wa.ConnectionStatus = CONNECTION_STATUS.LOGGEDIN)) Then
            Me.wa.SendMessage(Me.txtTo.Text, Me.txtMessage.Text)
            Dim txtStatus As TextBox = Me.txtStatus
            txtStatus.Text = (txtStatus.Text & String.Format(Environment.NewLine & "{0}:{1}", txtName.Text, Me.txtMessage.Text))
            Me.txtMessage.Clear()
            Me.txtMessage.Focus()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim thread = New Thread(AddressOf ThreadTask)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub ThreadTask()
        Dim textbox As UpdateTextBox = New UpdateTextBox(AddressOf Me.UpdateDataTextBox)
        Me.wa = New WhatsApp(Me.txtPhoneNumber.Text, Me.txtPassword.Text, Me.txtName.Text, True, False)
        AddHandler Me.wa.OnConnectSuccess, Sub()
                                               If Me.txtStatus.InvokeRequired Then
                                                   Dim objArray1 As Object() = New Object() {Me.txtStatus, "Connected..."}
                                                   Me.Invoke(textbox, objArray1)
                                               End If
                                               AddHandler Me.wa.OnLoginSuccess, Sub(phone As String, data As Byte())
                                                                                    If Me.txtStatus.InvokeRequired Then
                                                                                        Dim args As Object() = New Object() {Me.txtStatus, Environment.NewLine & "Login success !"}
                                                                                        Me.Invoke(textbox, args)
                                                                                    End If
                                                                                    While Me.wa IsNot Nothing
                                                                                        Me.wa.PollMessages()
                                                                                        Thread.Sleep(200)
                                                                                        Continue While
                                                                                    End While
                                                                                End Sub

                                               AddHandler Me.wa.OnLoginFailed, Sub(data As String)
                                                                                   If Me.txtStatus.InvokeRequired Then
                                                                                       Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "Login failed: {0}", data)}
                                                                                       Me.Invoke(textbox, args)
                                                                                   End If
                                                                               End Sub

                                               AddHandler Me.wa.OnGetMessage, Sub(node As ProtocolTreeNode, from As String, id As String, name As String, message As String, receipt_sent As Boolean)
                                                                                  If Me.txtStatus.InvokeRequired Then
                                                                                      Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "{0}:{1}", name, message)}
                                                                                      Me.Invoke(textbox, args)
                                                                                  End If
                                                                              End Sub
                                               Me.wa.Login(Nothing)
                                           End Sub
        AddHandler Me.wa.OnConnectFailed, Sub(ex As Exception)
                                              If Me.txtStatus.InvokeRequired Then
                                                  Dim args As Object() = New Object() {Me.txtStatus, String.Format(Environment.NewLine & "Connect failed: {0}", ex.StackTrace)}
                                                  Me.Invoke(textbox, args)
                                              End If
                                          End Sub
        Me.wa.Connect()
    End Sub
    Public Function sendSMS()
        Dim apikey = "yourAPIkey"
        Dim message = "This is your message"
        Dim numbers = "447123456789"
        Dim strPost As String
        Dim sender = "Jims Autos"
        Dim url As String = "https://api.txtlocal.com/send/?"


        strPost = url + "apikey=" + apikey _
        + "&numbers=" + numbers _
        + "&message=" + WebUtility.UrlEncode(message) _
        + "&sender=" + sender

        Dim request As WebRequest = WebRequest.Create(strPost)
        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(strPost)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = request.GetResponse()
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Console.WriteLine(responseFromServer)
        Console.ReadLine()

        reader.Close()
        dataStream.Close()
        response.Close()

        If responseFromServer.Length > 0 Then
            Return responseFromServer
        Else
            Return CType(response, HttpWebResponse).StatusDescription
        End If
    End Function


End Class