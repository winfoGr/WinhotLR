Option Strict Off
Option Explicit On
'Imports System.Runtime.CompilerServices

Friend Class Leisure
    'Dim target As String = "https://www.leisure-group.net"
    Dim target As String '= "  https://www.leisure-group.net/cgi/lars/eign/huis/huisplan?R=0x0000000000068f80&hspl=0x0000000000013fc5&Jaar=2014"
    'Dim username As String = "reservations@grecianland.gr"
    'Dim passwd As String = "sk7re4"
    Dim pageready As Boolean = False
    Dim datum As String
    Public Sub New(ByVal trgt As String, ByVal imerom As Date)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        linkTbx.Text = "https://www.leisure-group.net"
        userTbx.Text = "reservations@grecianland.gr"
        passwdTbx.Text = "sk7re4"
        datum = Format(imerom, "dd-MM-yyyy").ToString '"21-06-2014"
        target = trgt.Replace("#", "")
        Navigate(linkTbx.Text)
        'TextBox1.Text = "reservations@grecianland.gr"
        'TextBox2.Text = "sk7re4"
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Navigate(ByVal address As String)
        'Dim docElements As HtmlElementCollection
        'Dim j As HtmlElement

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        'If Not address.StartsWith("http://") Then
        '    address = "https://" & address
        'End If
        Try
            wbrWebBrowser.Navigate(New Uri(address))
            'Dim doc As Xml.XmlDocument = wbrWebBrowser.Document
        Catch ex As System.UriFormatException
            Return
        End Try
    End Sub
    Private Sub ReloadBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Login.Click
        Dim Identifiers() As String = {"loginid", "passwd"}

        'Dim oXML As Object = wbrWebBrowser.Document.DomDocument.XMLDocument
        'Dim XmlNodeList = oXML.SelectNodes(path).length

        Dim Items = _
        ( _
            From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
            Where Identifiers.Contains(T.GetAttribute("name").ToString) _
        ).ToList
        'MsgBox(Items(0).Inne)

        'Dim docElements As HtmlElementCollection
        If Items.Count > 0 Then
            For x As Integer = 0 To Items.Count - 1

                If Items(x).Name = "loginid" Then
                    Items(x).SetAttribute("value", userTbx.Text) 'Console.WriteLine("Label1.Text={0} from id=dn", Items(x).InnerHtml)
                ElseIf Items(x).Name = "passwd" Then
                    Items(x).SetAttribute("value", passwdTbx.Text)  '  Console.WriteLine("Label2.Text={0} from id=dl", Items(x).InnerHtml)
                End If

            Next
        End If
        Items.Clear()
        Dim Identifiers2() As String = {"submit"}
        Items = _
       ( _
           From T In wbrWebBrowser.Document.GetElementsByTagName("input").Cast(Of HtmlElement)() _
           Where Identifiers2.Contains(T.GetAttribute("type").ToString) _
       ).ToList
        If Items.Count > 0 Then
            Items(0).InvokeMember("click")
        End If
        WaitForPageLoad()
        'Threading.Thread.Sleep(5000)

        Navigate(target)
        WaitForPageLoad()
        fuehle_datum()
        
    End Sub


    Private Sub fuehle_datum()
        Dim Identifiers() As String = {datum}

        'Dim oXML As Object = wbrWebBrowser.Document.DomDocument.XMLDocument
        'Dim XmlNodeList = oXML.SelectNodes(path).length

        Dim Items = _
        ( _
            From T In wbrWebBrowser.Document.GetElementsByTagName("td").Cast(Of HtmlElement)() _
            Where Identifiers.Contains(T.GetAttribute("title").ToString) _
        ).ToList
        'MsgBox(Items(0).Inne)

        'Dim docElements As HtmlElementCollection
        If Items.Count > 0 Then
            For x As Integer = 0 To Items.Count - 1
                Items(x).InvokeMember("click")
            Next
        End If


    End Sub

    Private Sub WaitForPageLoad()
        AddHandler wbrWebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        While Not pageready
            Application.DoEvents()
        End While
        pageready = False
    End Sub

    Private Sub PageWaiter(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        If wbrWebBrowser.ReadyState = WebBrowserReadyState.Complete Then
            pageready = True
            RemoveHandler wbrWebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf PageWaiter)
        End If
    End Sub

    Private Sub ReloadBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadBtn.Click
        Navigate(linkTbx.Text)
    End Sub
End Class